using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasWebAPI;
using Cnas.wns.CnasWorkflowArithmetic;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace Cnas.wns.CnasWebAPI.Controllers
{
    public class WFController : ApiController
    {
		[HttpPost]
		public HttpResponseMessage CheckScanCode(dynamic content)
		{
			HttpResponseMessage result = null;
			try
			{
				string sessionKey = Convert.ToString(content.SessionKey);
				HttpSessionState session = HttpContext.Current.Application[sessionKey] as HttpSessionState;
				CnasHCSWorkflowInterface wfLogic = WFHelper.Instance.GetWFLogic(session);
				string barCode = Convert.ToString(content.BarCode);
				Dictionary<string, string> condition = JsonHelper.GetJsonObject<Dictionary<string, string>>(content.ScanCodes.ToString());
				Dictionary<string, dynamic> resultData = new Dictionary<string, dynamic>();
				SortedList checkResult = null;
				if (!string.IsNullOrEmpty(barCode))
				{
					checkResult = wfLogic.CheckBusinessLogic(barCode, condition);
					resultData.Add("Result", checkResult);
				}
				else
				{
					resultData.Add("ResultMessage", "无法验证当前条码，重新扫描");
				}
				result = Request.CreateResponse<Dictionary<string, dynamic>>(HttpStatusCode.OK, resultData);
				return result;
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex);
			}
		}

		[HttpPost]
		public HttpResponseMessage PostWorkSet(dynamic content)
		{
			HttpResponseMessage result = null;
			try
			{
				string sessionKey = Convert.ToString(content.SessionKey);
				HttpSessionState session = HttpContext.Current.Application[sessionKey] as HttpSessionState;
				Dictionary<string, dynamic> resultData = new Dictionary<string, dynamic>();

				if (session != null)
				{
					CnasHCSWorkflowInterface wfLogic = WFHelper.Instance.GetWFLogic(session);
					UserBase loginUser = session["UserInfo"] as UserBase;
					SortedList scanCodes = JsonHelper.GetJsonObject<SortedList>(content.ScanCodes.ToString());
					string pdCode = BarCodeHelper.GetBarCodeByType("BCV", scanCodes);
					DataTable accessProcedure = null;
					DataTable procedureParameters = null;
					CnasRemotCall remoteCall = new CnasRemotCall();
					if (HttpContext.Current.Session != null && !string.IsNullOrEmpty(pdCode))
					{
						accessProcedure = session["AccessProcedure"] as DataTable;
						if (accessProcedure == null)
						{
							SortedList filter = new SortedList();
							filter.Add(1, loginUser.UserID);
							string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-user-procedure-sec001", filter);
							accessProcedure = remoteCall.RemotInterface.SelectData("HCS-user-procedure-sec001", filter);
						}

						procedureParameters = session["ProcedureParameters"] as DataTable;
						if (procedureParameters == null)
						{
							SortedList filter = new SortedList();
							filter.Add(1, pdCode.Substring(9, 4));
							string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-pdparametervalue-sec003", filter);
							procedureParameters = remoteCall.RemotInterface.SelectData("HCS-pdparametervalue-sec003", filter);
						}
					}
					SortedList slCheck = new SortedList();
					slCheck.Add("pd_code", "");
					slCheck.Add("pd_barcode", "");
					slCheck.Add("pd_name", "");
					slCheck.Add("pd_par1", "");
					slCheck.Add("pd_par2", "");
					slCheck.Add("pd_scan", "");
					if (accessProcedure != null)
					{
						DataRow[] procedure = accessProcedure.Select(string.Format("pd_bcode='{0}'", pdCode));
						if (procedure.Length > 0)
						{
							if (!(procedure[0]["pd_code"] is DBNull))
								slCheck["pd_code"] = procedure[0]["pd_code"].ToString();
							if (!(procedure[0]["pd_bcode"] is DBNull))
								slCheck["pd_barcode"] = procedure[0]["pd_bcode"].ToString();
							if (!(procedure[0]["pd_name"] is DBNull))
								slCheck["pd_name"] = procedure[0]["pd_name"].ToString();
							if (!(procedure[0]["pd_scan"] is DBNull))
							{
								string scanParam = procedure[0]["pd_scan"].ToString();
								if (!string.IsNullOrEmpty(scanParam))
								{
									SortedList scans = new SortedList();
									string[] scanParams = scanParam.Split(';');
									foreach (string item in scanParams)
									{
										if (item.Length > 3 && !scans.ContainsKey(item.Substring(0, 3)))
										{
											scans.Add(item.Substring(0, 3), int.Parse(item.Substring(3)));
										}
									}
									slCheck["pd_scan"] = scans;
								}
							}
						}
					}

					SortedList parameter01 = new SortedList();
					SortedList parameter02 = new SortedList();
					slCheck["pd_par1"] = parameter01;
					slCheck["pd_par2"] = parameter02;
					if (procedureParameters != null)
					{
						foreach (DataRow dr in procedureParameters.Rows)
						{
							string parameterName = dr["par_name"].ToString();
							string parameterType = dr["par_type"].ToString();
							string parameterDescription = dr["par_description"].ToString();
							if (parameterType == "2")
							{
								parameter02.Add(parameterName, parameterDescription);
							}
							else
							{
								parameter02.Add(parameterName, parameterDescription);
							}
						}
					}

					SortedList submit = new SortedList();
					SortedList params01 = new SortedList();
					SortedList params02 = new SortedList();
					SortedList params03 = new SortedList();
					if (content.Parameter01 != null)
						params01 = JsonHelper.GetJsonObject<SortedList>(content.Parameter01.ToString());
					if (content.Parameter02 != null)
						params02 = JsonHelper.GetJsonObject<SortedList>(content.Parameter02.ToString());
					if (content.Parameter03 != null)
						params03 = JsonHelper.GetJsonObject<SortedList>(content.Parameter03.ToString());
					string userId = Convert.ToString(content.UserId);
					submit.Add("Par1_info", params01);
					submit.Add("Par2_info", params02);
					submit.Add("Par3_Dialog", params03);
					submit.Add("SL_check", slCheck);
					submit.Add("sub_barcode", scanCodes);
					submit.Add("user_id", userId);

					SortedList postResult = wfLogic.GetWorkflowParametersValue(1001, 1001, submit, null, null);
					resultData.Add("Result", postResult);
					result = Request.CreateResponse<Dictionary<string, dynamic>>(HttpStatusCode.OK, resultData);

				}
				else
				{
					SortedList postResult = new SortedList();
					postResult.Add("Message", "登录超时，请重新登录");
					result = Request.CreateResponse<Dictionary<string, dynamic>>(HttpStatusCode.GatewayTimeout, resultData);
				}
				
				return result;
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex);
			}

		}
    }
}
