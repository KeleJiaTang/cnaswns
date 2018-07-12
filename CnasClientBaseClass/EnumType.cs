using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasBaseClassClient
{
	public enum EUploadType
	{
		/// <summary>
		/// 器械包
		/// </summary>
		Set =1,
		/// <summary>
		/// 器械
		/// </summary>
		Instrument =2 ,
		/// <summary>
		/// 安全报告
		/// </summary>
		SafetyTimeReport = 3,
		/// <summary>
		/// 清洗结果
		/// </summary>
		WashingResultMonitor = 4,
		/// <summary>
		/// 灭菌结果
		/// </summary>
		SterilizerResultMonitor =5,
		/// <summary>
		/// 生物监测
		/// </summary>
		SetResultMonitor = 6,
		/// <summary>
		/// 订单
		/// </summary>
		Order=7,
	}

	public enum EIndicator
	{
		WashingFailed= 1,
		SecondSend,
		morrowsend,
		disposeinstrument,
		disposedressing,
	}

}
