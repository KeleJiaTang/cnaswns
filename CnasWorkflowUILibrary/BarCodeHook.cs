using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	/// <summary>
	/// 获取键盘输入或者USB扫描枪数据 可以是没有焦点 应为使用的是全局钩子
	/// USB扫描枪 是模拟键盘按下
	/// 这里主要处理扫描枪的值，手动输入的值不太好处理
	/// </summary>
	public class BarCodeHook
	{
		public const int WH_KEYBOARD_LL = 13;
		public ILog Logger = null;
		public delegate void BardCodeDeletegate(BarCodes barCode);
		public event BardCodeDeletegate BarCodeEvent;

		//定义成静态，这样不会抛出回收异常
		//private static HookProc hookproc;
		private HookProc hookproc;
		delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
		public IntPtr hKeyboardHook = IntPtr.Zero;
		public struct BarCodes
		{
			public int VirtKey;//虚拟码
			public int ScanCode;//扫描码
			public string KeyName;//键名
			public uint Ascll;//Ascll
			public char Chr;//字符

			public string OriginalChrs; //原始 字符
			public string OriginalAsciis;//原始 ASCII

			public string OriginalBarCode;  //原始数据条码

			public bool IsValid;//条码是否有效
			public DateTime Time;//扫描时间,

			public string BarCode;//条码信息   保存最终的条码
		}

		private struct EventMsg
		{
			public int message;
			public int paramL;
			public int paramH;
			public int Time;
			public int hwnd;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern bool UnhookWindowsHookEx(IntPtr idHook);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern int CallNextHookEx(IntPtr idHook, int nCode, Int32 wParam, IntPtr lParam);

		[DllImport("user32", EntryPoint = "GetKeyNameText")]
		private static extern int GetKeyNameText(int IParam, StringBuilder lpBuffer, int nSize);

		[DllImport("user32", EntryPoint = "GetKeyboardState")]
		private static extern int GetKeyboardState(byte[] pbKeyState);

		[DllImport("user32", EntryPoint = "ToAscii")]
		private static extern bool ToAscii(int VirtualKey, int ScanCode, byte[] lpKeySate, byte[] lpChar, int uFlags);

		[DllImport("kernel32.dll")]
		private static extern int GetCurrentThreadId();

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string name);

		BarCodes barCode = new BarCodes();

		StringBuilder sbBarCode = new StringBuilder();

		public BarCodeHook()
		{
			Logger = LogManager.GetLogger("CnasWNSClient");
		}

		private const int WM_KEYDOWN = 0x100;//KEYDOWN
		
		private const int WM_KEYUP = 0x101;//KEYUP
		
		private const int WM_SYSKEYDOWN = 0x104;//SYSKEYDOWN
		
		private const int WM_SYSKEYUP = 0x105;//SYSKEYUP

		private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
		{
			int i_calledNext = 0;

			try
				{
				 i_calledNext = -10;
				if (nCode == 0)
				{
					EventMsg msg = (EventMsg)Marshal.PtrToStructure(lParam, typeof(EventMsg));
					if (wParam == WM_KEYDOWN)//WM_KEYDOWN=0x100
					{
						barCode.VirtKey = msg.message & 0xff;//虚拟吗
						barCode.ScanCode = msg.paramL & 0xff;//扫描码
						StringBuilder strKeyName = new StringBuilder(255);
						if (GetKeyNameText(barCode.ScanCode * 65536, strKeyName, 255) > 0)
						{
							barCode.KeyName = strKeyName.ToString().Trim(new char[] { ' ', '\0' });
						}
						else
						{
							barCode.KeyName = "";
						}
						byte[] keyState = new byte[256];
						byte[] inBuffer = new byte[2];
						GetKeyboardState(keyState);
						//for (int i = 0; i < keyState.Length; i++)
						//{
						//	if (keyState[i] > 0)
						//		keyState[i] =1;
						//}

						//if (barCode.Chr == 41 || barCode.Chr == 48)
						//{
						//	for (int i = 0; i < keyState.Length; i++)
						//	{
						//		if (keyState[i] != 0)
						//			Logger.Info(string.Format("i:{0}, keyState:{1}", i, keyState[i]));
						//	}
						//}

						if (ToAscii(barCode.VirtKey, barCode.ScanCode, keyState, inBuffer, 0))
						{
							barCode.Ascll = inBuffer[0];//ConvertToNum(inBuffer[0]);
							barCode.Chr = Convert.ToChar(barCode.Ascll);
							barCode.OriginalChrs += " " + Convert.ToString(barCode.Chr);
							barCode.OriginalAsciis += " " + Convert.ToString(barCode.Ascll);
							barCode.OriginalBarCode += Convert.ToString(barCode.Chr);
						}

						TimeSpan ts = DateTime.Now.Subtract(barCode.Time);

						if (ts.TotalMilliseconds > 20)
						{//时间戳，大于50 毫秒表示手动输入
							// strBarCode = barCode.Chr.ToString();
							sbBarCode.Remove(0, sbBarCode.Length);
							sbBarCode.Append(barCode.Chr.ToString());

							barCode.OriginalChrs = " " + Convert.ToString(barCode.Chr);
							barCode.OriginalAsciis = " " + Convert.ToString(barCode.Ascll);

							barCode.OriginalBarCode = Convert.ToString(barCode.Chr);
						}
						else
						{
							if ((msg.message & 0xff) == 13 && sbBarCode.Length > 3)
							{
								barCode.BarCode = barCode.OriginalBarCode;
								barCode.IsValid = true;
								sbBarCode.Remove(0, sbBarCode.Length);
							}
							sbBarCode.Append(barCode.Chr.ToString());
							//Logger.Info(string.Format("CurrentTime: {0} {1}", DateTime.Now.ToString("HH:mm:sss"), DateTime.Now.Millisecond.ToString()));
							//Logger.Info(string.Format("Key char:{0}, KeyName:{1}, VirtKey: {2}, ScanCode:{3}， Scanned Code:{4}",
										//barCode.Chr, barCode.KeyName, barCode.VirtKey, barCode.ScanCode, sbBarCode));
						}
						if (BarCodeEvent != null && barCode.IsValid)
						{
							//barCode.BarCode = barCode.BarCode.Replace("\b", "").Replace("\0","");  可以不需要 因为大于50毫秒已经处理
							//先进行 WINDOWS事件往下传
							//i_calledNext = CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
							barCode.IsValid = false; //最后一定要 设置barCode无效


							BarCodeEvent(barCode);//触发事件 
							barCode.BarCode = "";
							barCode.OriginalChrs = "";
							barCode.OriginalAsciis = "";
							barCode.OriginalBarCode = "";
						}

						barCode.IsValid = false; //最后一定要 设置barCode无效
						barCode.Time = DateTime.Now;
					}
				}
				if (i_calledNext == -10)
				{
					//Logger.Info("CallNextHookEx while [i_calledNext == -10]");
					i_calledNext = CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
				}
			}
			catch (Exception ex)
			{
				Logger.Error("KeyboardHookProc throw exception.", ex);
				Console.WriteLine(ex);
			}
			
			return i_calledNext;
		}

		//安装钩子
		public void Start(bool isPrivateHook)
		{
			if (hKeyboardHook == IntPtr.Zero)
			{
				hookproc = new HookProc(KeyboardHookProc);
				//私有键盘钩子  2
				//全局键盘钩子  13
				if (isPrivateHook)
				{
					hKeyboardHook = SetWindowsHookEx(2, hookproc, IntPtr.Zero, GetCurrentThreadId());
				}
				else
				{
					IntPtr modulePtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
					hKeyboardHook = SetWindowsHookEx(13, hookproc, modulePtr, 0);
				}
			}

			
			if (hKeyboardHook == IntPtr.Zero)
			{
				Logger.Info("安装键盘钩子失败.....");
			}
		}

		//卸载钩子
		public bool Stop()
		{
			bool retKeyboard = true;

			if (hKeyboardHook != IntPtr.Zero)
			{
				retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
				hKeyboardHook = IntPtr.Zero;
				hookproc = null;
				GC.Collect();
			}

			if (!(retKeyboard))
			{
				Logger.Info("UnhookWindowsHookEx failed.....");
			}
			return retKeyboard;
		}

		public byte ConvertToNum(byte originalKey)
		{
			byte result = originalKey;
			switch (originalKey)
			{
				case 21:		 //!
					result = 49;	  // number 1
					break;
				case 64:		 //@
					result = 50;	   // number 2
					break;
				case 35:		 //#
					result = 51;	  // number 3
					break;
				case 36:		//$
					result = 52;	  // number 4
					break;
				case 37:		//%
					result = 53;	   // number 5
					break;
				case 94:		//^
					result = 54;	   // number 6
					break;
				case 38:		//&
					result = 55;	  // number 7
					break;
				case 42:		//*
					result = 56;	  // number 8
					break;
				case 40:		//(
					result = 57;	// number 9
					break;
				case 41:	   //）
					result = 48;	  // number 0
					break;
				default:
					break;
			}
			return result;
		}

	}
}
