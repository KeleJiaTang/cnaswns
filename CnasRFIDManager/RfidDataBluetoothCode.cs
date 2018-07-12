using Cnas.wns.CnasBaseInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Cnas.wns.CnasRFIDManager
{
	public class RfidDataBluetoothCode : RFIDInterface
	{
		/// <summary>
		/// COM口
		/// </summary>
		private string _strPort = ConfigurationManager.AppSettings["RFIDName"].ToString();
		/// <summary>
		/// COM口
		/// </summary>
		public string StrPort { get { return _strPort; } }
		/// <summary>
		/// 是否连接
		/// </summary>
		private bool _isConnected = false;
		/// <summary>
		/// 是否连接
		/// </summary>
		public bool IsConnected { get { return _isConnected; } }
		/// <summary>
		/// 是否可打开Com
		/// </summary>
		private bool _isOpenCom = false;
		/// <summary>
		/// 是否可打开Com
		/// </summary>
		public bool IsOpenCom { get { return _isOpenCom; } }
		/// <summary>
		/// 是否停止扫描
		/// </summary>
		private bool _isStopScan = false;
		/// <summary>
		/// 是否停止扫描
		/// </summary>
		public bool IsStopScan { get { return _isStopScan; } }
		/// <summary>
		/// 是否开始高速扫描
		/// </summary>
		private bool _isStartScan = false;
		/// <summary>
		/// 是否开始高速扫描
		/// </summary>
		public bool IsStartScan { get { return _isStartScan; } }
		
		/// <summary>
		/// 蓝牙设备
		/// </summary>
		public SerialPort BluetoothConnection { get { return _BluetoothConnection; } }
		/// <summary>
		/// 蓝牙设备
		/// </summary>
		private SerialPort _BluetoothConnection = new SerialPort();
		/// <summary>
		/// 事件
		/// </summary>
		public event AddData GetNoneAddData;
		/// <summary>
		/// 初始化
		/// </summary>
		public RfidDataBluetoothCode() { }

		/// <summary>
		/// 建立连接
		/// </summary>
		/// <returns></returns>
		public bool Connecttion()
		{
			//连接
			if (!BluetoothConnection.IsOpen)
			{
				try
				{
					_BluetoothConnection = new SerialPort();
					_BluetoothConnection.PortName = _strPort;
					_BluetoothConnection.Open();
					_BluetoothConnection.ReadTimeout = 10000;
					_BluetoothConnection.DataReceived += new SerialDataReceivedEventHandler(BlueToothDataReceived);
					_isOpenCom = true;
					_isConnected = true;
					_isStartScan = true;
					_isStopScan = false;
					return true;
				}
				catch
				{
					_isOpenCom = false;
					_isConnected = false;
				}
			}
			else { _isOpenCom = true; _isConnected = false; }
			return false;
		}

		/// <summary>
		/// 断开连接(全部停止)
		/// </summary>
		/// <returns></returns>
		public bool DisConnecttion()
		{
			try
			{
				if (_BluetoothConnection != null)
				{
					_BluetoothConnection.Close();
					_BluetoothConnection.Dispose();
					_isStartScan = false;
					_isStartScan = true;
					_isConnected = false;
					_isOpenCom = false;
				}
			}
			catch { return false; }
			return true;
		}

		/// <summary>
		/// 修改存储字典
		/// </summary>
		/// <param name="dicSource"></param>
		/// <param name="type"></param>
		public void DicAddData(Dictionary<string, string> dicSource, int type) { }

		/// <summary>
		/// 重置可继续执行事件
		/// </summary>
		public void SetTagToZero() { }

		public string str_RfidDatas = string.Empty;

		//[蓝牙接收数据事件响应函数，在按钮连接事件中声明的该事件，用于响应蓝牙数据接收] (是否需要加临界锁)
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void BlueToothDataReceived(object o, SerialDataReceivedEventArgs e)
		{
			str_RfidDatas = str_RfidDatas + _BluetoothConnection.ReadExisting().Replace("\n", "").Replace("\0", "");
			string str_end = str_RfidDatas.Substring(str_RfidDatas.Length - 2, 2);
			//Console.WriteLine(str_RfidDatas);
			if (str_end != "}>")
			{
				Dictionary<string, string> dic = new Dictionary<string, string>();
				Regex reg = new Regex("Begin");
				bool isBegin = reg.IsMatch(str_RfidDatas);
				if (isBegin && GetNoneAddData != null) GetNoneAddData(dic, RFIDCommand.Begin);
				reg = new Regex("stop");
				bool isEnd = reg.IsMatch(str_RfidDatas);
				if (isEnd && GetNoneAddData != null) GetNoneAddData(dic, RFIDCommand.Stop);
				if (isBegin || isEnd) str_RfidDatas = string.Empty;
			}
			else
			{
				Dictionary<string, string> item;
				int i = RfidCodeHelperDatas.DataType(str_RfidDatas, out item);
				if (i == 2 && item.Count > 0 && GetNoneAddData != null)
				{
					GetNoneAddData(item,RFIDCommand.Datas);//作为响应的事件是否要加临界锁
				}
				str_RfidDatas = string.Empty;
			}
		}
	}
}
