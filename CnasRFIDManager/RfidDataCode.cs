using HAWKVOR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using Cnas.wns.CnasBaseInterface;

namespace Cnas.wns.CnasRFIDManager
{
	public class RfidDataCode:RFIDInterface
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
		/// Antenna
		/// </summary>
		private byte _Antenna = 15;
		/// <summary>
		/// Antenna
		/// </summary>
		public byte Antenna {	get{ return _Antenna;}  }
		/// <summary>
		/// 是否可打开Com
		/// </summary>
		private bool _isOpenCom = false;
		/// <summary>
		/// 是否可打开Com
		/// </summary>
		public bool IsOpenCom { get { return _isOpenCom; } }
		/// <summary>
		/// 是否连接
		/// </summary>
		private bool _isConnected = false;
		/// <summary>
		/// 是否连接
		/// </summary>
		public bool IsConnected { get { return _isConnected; } }
		/// <summary>
		/// isSetAntena
		/// </summary>
		private bool _isSetAntena = false;
		/// <summary>
		/// IsSetAntena
		/// </summary>
		public bool IsSetAntena{ get { return _isSetAntena;} }
		/// <summary>
		/// 是否开启线程
		/// </summary>
		private bool _isStartThread = false;
		/// <summary>
		/// 是否开启线程
		/// </summary>
		public bool IsStartThread { get { return _isStartThread;} }
		/// <summary>
		/// 是否停止扫描
		/// </summary>
		private bool _isStopScan = false;
		/// <summary>
		/// 是否停止扫描
		/// </summary>
		public bool IsStopScan{ get { return _isStopScan; } }
		/// <summary>
		/// 是否开始高速扫描
		/// </summary>
		private bool _isStartScan = false;
		/// <summary>
		/// 是否开始高速扫描
		/// </summary>
		public bool IsStartScan{ get{ return _isStartScan;} }
		/// <summary>
		/// 是否停止
		/// </summary>
		private bool _isStop = false;
		/// <summary>
		/// 是否停止
		/// </summary>
		public bool IsStop { get { return _isStop;} }
		/// <summary>
		/// 比特率
		/// </summary>
		private int _nRaudRate = 115200;
		/// <summary>
		/// 值越大可扫到的rfid越多(文档所说)
		/// </summary>
		private byte _queryValue=2;
		/// <summary>
		/// 建立连接次数
		/// </summary>
		private int _connectCount = 5;
		/// <summary>
		/// 设置角度次数
		/// </summary>
		private int _SetAntenaCount = 5;
		/// <summary>
		/// 开始扫描的次数
		/// </summary>
		private int _startScanCount = 10;
		/// <summary>
		/// Read rfid Class
		/// </summary>
		private RFIDScanner rfidScaner = new RFIDScanner();
		/// <summary>
		/// 线程
		/// </summary>
		private Thread thread = null;
		/// <summary>
		/// 数据项
		/// </summary>
		private Dictionary<string, string> dic = new Dictionary<string, string>();
		/// <summary>
		/// 事件
		/// </summary>
		public event AddData GetNoneAddData;
		/// <summary>
		/// 标识dic的数量
		/// </summary>
		private int dicCount_tag = 0;
		/// <summary>
		/// 用于标识是否只执行一次
		/// </summary>
		private int isFirst_tag = 0;
		/// <summary>
		/// 锁资源
		/// </summary>
		private object threadObj = new object();
		/// <summary>
		/// 锁字典
		/// </summary>
		private object dicObj = new object();

		/// <summary>
		/// 线程
		/// </summary>
		private void ReadTagThreadProc()
		{
			while (!_isStop)
			{
				try
				{
					TagInfo tag = new TagInfo();
					if (rfidScaner.GetTagInfo(tag))
					{
						StringBuilder sb = new StringBuilder();
						foreach (byte item in tag.EPC)
						{
							sb.Append(item.ToString("X2"));
						}
						string tempStr = sb.ToString();
						Dictionary<string, string> tempDic = new Dictionary<string, string>();
						tempDic.Add(tempStr, string.Empty);
						DicAddData(tempDic, 1);
					}
					else
					{
						if (dic != null && dic.Count > 0)
						{
							if (dic != null && dicCount_tag == dic.Count)
							{
								if (isFirst_tag == 0)
								{
									lock (threadObj)
									{
										isFirst_tag = 1;
										if (GetNoneAddData != null)
										{
											GetNoneAddData(dic);
											Thread.Sleep(800);
										}
									}
								}
							}
							else
							{
								if (isFirst_tag == 0)
								{
									dicCount_tag = dic == null ? 0 : dic.Count;
								}
							}
						}
					}
				}
				catch
				{ }
			}
		}

		/// <summary>
		/// 获取端口是否可打开
		/// </summary>
		private void GetComOpen()
		{
			try
			{
				SerialPort _temp = new SerialPort(_strPort);
				if (!_temp.IsOpen)
					_isOpenCom = true;
				else
					_isOpenCom = false;

			}
			catch
			{
				_isOpenCom = false;
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		public RfidDataCode() {}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="nRaudRate">比特率</param>
		/// <param name="queryValue">值越大可扫到的rfid越多</param>
		public RfidDataCode(int nRaudRate, byte queryValue)
		{
			Connecttion();
		}

		/// <summary>
		/// 让扫描仪响应(递归)
		/// </summary>
		/// <param name="queryValue"></param>
		/// <param name="isStarScan"></param>
		private void StartScan(byte queryValue, ref bool isStarScan)
		{
			int count=0;
			isStarScan = false;
			while (!isStarScan&&count<_startScanCount)
			{
				try
				{
					count++;
					rfidScaner.StartScanning(queryValue);
					isStarScan = true;
					StartThread();
				}
				catch
				{ }
			}
		}

		/// <summary>
		/// 端口打开连接
		/// </summary>
		/// <param name="nRaudRate"></param>
		/// <param name="queryValue"></param>
		/// <param name="isConnected"></param>
		private void Connect(int nRaudRate, byte queryValue, ref bool isConnected)
		{
			int count=0;
			isConnected = false;
			while (!isConnected&&count<_connectCount)
			{
				try
				{
					count++;
					if (rfidScaner.IsConnected)
						rfidScaner.Disconnect();
					rfidScaner.Connect(_strPort, nRaudRate);
					isConnected = true;
				}
				catch
				{ }
			}

		}

		/// <summary>
		/// 停止
		/// </summary>
		public void StopReadThread()
		{
			try
			{
				_isStop = true;
				if (rfidScaner != null)
				{
					try
					{
						rfidScaner.StopScanning();
					}
					catch
					{ }
					try
					{
						rfidScaner.Disconnect();
					}
					catch
					{ }
				}
				_isStopScan = true;
				_isStartThread = false;
				_isConnected = false;
				dic = null;
			}
			catch
			{ }
		}

		/// <summary>
		/// set Antenna
		/// </summary>
		/// <param name="isSetAntena"></param>
		private void NewSetAntenna(ref bool isSetAntena)
		{
			int count = 0;
			isSetAntena = false;
			while (!isSetAntena&&count<_SetAntenaCount)
			{
				try
				{
					rfidScaner.SetAntenna(_Antenna);
					isSetAntena = true;
				}
				catch
				{ }
			}
		}

		/// <summary>
		/// 操作字典
		/// </summary>
		/// <param name="dic"></param>
		/// <param name="type">1添加2删除</param>
		public void DicAddData(Dictionary<string, string> dicSource, int type)
		{
			if (dic != null)
			{
				lock (dicObj)
				{
					if (type == 1)
					{
						foreach (KeyValuePair<string, string> item in dicSource)
						{
							if (!dic.ContainsKey(item.Key))
							{
								dic.Add(item.Key, string.Empty);
							}
						}
					}
					else
					{
						foreach (KeyValuePair<string, string> item in dicSource)
						{
							if (dic.ContainsKey(item.Key))
								dic.Remove(item.Key);
						}
					}
				}
			}
		}

		/// <summary>
		/// 重置可继续执行事件
		/// </summary>
		public void SetTagToZero()
		{
			dicCount_tag = -1;
			isFirst_tag = 0;
		}

		/// <summary>
		/// 打开连接
		/// </summary>
		/// <param name="nRaudRate">比特率</param>
		/// <param name="queryValue"></param>
		public void Connect(int nRaudRate, byte queryValue)
		{
			if (_isOpenCom)
			{
				Connect(nRaudRate, queryValue, ref _isConnected);
			}
		}

		/// <summary>
		/// SetAntenna
		/// </summary>
		public void NewSetAntenna()
		{
			if (_isConnected)
			{
				NewSetAntenna(ref _isSetAntena);
			}
		}

		/// <summary>
		/// 开始扫描
		/// </summary>
		public void StartScan()
		{
			if (_isConnected)
			{
				StartScan(_queryValue, ref _isStartScan);
			}
		}

		/// <summary>
		/// 停止扫描
		/// </summary>
		public void StopScan()
		{
			try
			{
				if (_isConnected)
				{
					rfidScaner.StopScanning();
					StopThread();
					_isStopScan = true;
					dic = new Dictionary<string, string>();
				}
			}
			catch
			{
				_isStopScan = false;
			}
		}

		/// <summary>
		/// 启动线程
		/// </summary>
		public void StartThread()
		{
			try
			{
				if (_isStartScan&&thread==null)
				{
					_isStop = false;
					thread = new Thread(ReadTagThreadProc);
					thread.Start();
					_isStartThread = true;
				}
			}
			catch
			{
				_isStartThread = false;
			}
		}

		/// <summary>
		/// 停止线程
		/// </summary>
		public void StopThread()
		{
			try
			{
				_isStop = true;
				thread = null;
				_isStartThread = false;
				dic = new Dictionary<string, string>();
			}
			catch
			{
				if (thread != null && _isStartScan)
				{
					_isStartThread = true;
				}
			}
		}

		/// <summary>
		/// 建立连接
		/// </summary>
		/// <returns></returns>
		public bool Connecttion()
		{
			try
			{
				GetComOpen();
				if (_isOpenCom)
				{
					Connect(_nRaudRate, _queryValue);
					NewSetAntenna();
					StartScan();
					return true;
				}
			}
			catch
			{
				try
				{
					if (rfidScaner.IsConnected) rfidScaner.Disconnect();
				}
				catch
				{ }
			}
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
				StopReadThread();
				return true;
			}
			catch
			{ }
			return false;
		}
	}


}
