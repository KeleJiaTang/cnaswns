using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public class DBServer
	{
		/// <summary>
		/// 服务端
		/// </summary>
		private CnasRemotCall _remoteClient = new CnasRemotCall();

		/// <summary>
		/// 根据器械包条形码查询器械包信息
		/// </summary>
		/// <param name="setBarCode">器械包条形码</param>
		public Dictionary<string, string> GetPackageByBarCode(string barCode)
		{
			Dictionary<string, string> packageInfo = null;
			SortedList condition = new SortedList();
			condition.Add(1, barCode);
			bool isTempSet = BarCodeHelper.IsTempSet(barCode);
			string sql = BarCodeHelper.IsTempSet(barCode) ? "HCS_temp_set_sec001" : "HCS-procedure-info-config-sec002";
			string testSql = _remoteClient.RemotInterface.CheckSelectData(sql, condition);
			DataTable data = _remoteClient.RemotInterface.SelectData(sql, condition);
			packageInfo = new Dictionary<string, string>();

			if (data != null)
			{
				if (data.Rows != null && data.Rows.Count > 0)
				{
					DataRow row = data.Rows[0] as DataRow;
					if (isTempSet)
					{
						if (row["id"] != null) packageInfo.Add("id", row["id"].ToString());
						if (row["bar_code"] != null) packageInfo.Add("bar_code", row["bar_code"].ToString());
						if (row["ca_name"] != null) packageInfo.Add("ca_name", row["ca_name"].ToString());
					}
					else
					{
						if (row["id"] != null) packageInfo.Add("id", row["id"].ToString());
						if (row["bar_code"] != null) packageInfo.Add("bar_code", row["bar_code"].ToString());
						if (row["base_setcode"] != null) packageInfo.Add("base_setcode", row["base_setcode"].ToString());
						if (row["ca_name"] != null) packageInfo.Add("ca_name", row["ca_name"].ToString());
						if (row["pa_type"] != null) packageInfo.Add("pa_type", row["pa_type"].ToString());
						if (row["department_id"] != null) packageInfo.Add("department_id", row["department_id"].ToString());
						if (row["cre_date"] != null) packageInfo.Add("cre_date", row["cre_date"].ToString());
						if (row["st_pr_Name"] != null) packageInfo.Add("st_pr_Name", row["st_pr_Name"].ToString());
						if (row["wa_pr_Name"] != null) packageInfo.Add("wa_pr_Name", row["wa_pr_Name"].ToString());
						if (row["cost_center_name"] != null) packageInfo.Add("cost_center_name", row["cost_center_name"].ToString());
						if (row["pa_priorty"] != null) packageInfo.Add("pa_priorty", row["pa_priorty"].ToString());
					}
				}
			}

			return packageInfo;
		}

	}
}
