using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasBaseInterface
{
	/// <summary>
	/// rfid 命令
	/// </summary>
	public enum RFIDCommand
	{
		Begin = 1,//开始
		Datas = 2,//传输数据
		Stop = 3,//结束
	}

	/// <summary>
	/// 委托
	/// </summary>
	/// <param name="rfidDic"></param>
	public delegate void AddData(Dictionary<string, string> rfidDic,RFIDCommand cmd=RFIDCommand.Datas);

	/// <summary>
	/// 接口
	/// </summary>
	public interface RFIDInterface
	{
		/// <summary>
		/// COM口
		/// </summary>
		string StrPort { get;}
		/// <summary>
		/// 是否可打开Com
		/// </summary>
		bool IsOpenCom { get;}
		/// <summary>
		/// 是否连接
		/// </summary>
		bool IsConnected { get;}
		/// <summary>
		/// 是否开始高速扫描
		/// </summary>
		bool IsStartScan { get; }
		/// <summary>
		/// 事件
		/// </summary>
		event AddData GetNoneAddData;
		/// <summary>
		/// 建立连接
		/// </summary>
		/// <returns></returns>
		bool Connecttion();
		/// <summary>
		/// 修改存储字典
		/// </summary>
		/// <param name="dicSource"></param>
		/// <param name="type"></param>
		void DicAddData(Dictionary<string, string> dicSource, int type);
		/// <summary>
		/// 断开连接(全部停止)
		/// </summary>
		/// <returns></returns>
		bool DisConnecttion();
		/// <summary>
		/// 重置可继续执行事件
		/// </summary>
		void SetTagToZero();
	}
}
