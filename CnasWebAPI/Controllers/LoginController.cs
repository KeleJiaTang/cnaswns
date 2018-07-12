using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Web;
using Cnas.wns.CnasWorkflowArithmetic;

namespace CnasWebAPI.Controllers
{
    public class LoginController : ApiController
    {
		[HttpGet]
		public HttpResponseMessage Login(string userName, string password)
		{
			try
			{
				CnasRemotCall remoteCall = new CnasRemotCall();
				SortedList filter = new SortedList();
				filter.Add(1, userName);
				filter.Add(2, password);

				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-userdata-sec004", filter);
				DataTable userInfo = remoteCall.RemotInterface.SelectData("HCS-userdata-sec004", filter);
				
 				if (userInfo != null && userInfo.Rows.Count > 0)
				{
					
					CnasBaseData.UserName = userName;
					if (userInfo.Columns.Contains("si_id") && !(userInfo.Rows[0]["si_id"] is DBNull))
					{
						CnasBaseData.SystemID = Convert.ToString(userInfo.Rows[0]["si_id"]);
						HttpContext.Current.Session["SystemID"] = Convert.ToString(userInfo.Rows[0]["si_id"]);
					}
					if (userInfo.Columns.Contains("id") && !(userInfo.Rows[0]["id"] is DBNull))
					{
						CnasBaseData.UserID = Convert.ToString(userInfo.Rows[0]["id"]);
						HttpContext.Current.Session["UserId"] = CnasBaseData.UserID;
						
					}
					string sessionKey =string.Format("{0}:{1}", CnasBaseData.UserID.ToString(), "CnasUserInfo");
					HttpContext.Current.Application[sessionKey] = HttpContext.Current.Session;
					if (userInfo.Columns.Contains("user_bcode"))
					{
						CnasBaseData.UserBaseInfo = UserBaseHelper.GetUserByBarCode(Convert.ToString(userInfo.Rows[0]["user_bcode"]));
						HttpContext.Current.Session["UserInfo"] = CnasBaseData.UserBaseInfo;
					}
					filter.Clear();
					filter.Add(1, HttpContext.Current.Session["UserId"]);
					testSql = remoteCall.RemotInterface.CheckSelectData("HCS-user-procedure-sec001", filter);
					DataTable accessProcedure= remoteCall.RemotInterface.SelectData("HCS-user-procedure-sec001", filter);
					DataTable userDetail = remoteCall.RemotInterface.SelectData("HCS-user-sec005", filter);
					Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
					result.Add("AccessWF", accessProcedure);
					result.Add("UserInfo", userDetail);
					result.Add("SessionKey", sessionKey);
					
					HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
					HttpContext.Current.Session["AccessProcedure"] = accessProcedure;
					HttpContext.Current.Session["WorkflowArithmetic"] = new WorkflowArithmeticClass();
					SortedList condition = new SortedList();
					condition.Add(1, HttpContext.Current.Session["SystemID"]);
					CnasBaseData.SystemInfoData = remoteCall.RemotInterface.SelectData("HCS-systeminfo-sec001", condition);
					return response;
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, new HttpError("查询不到用户"));
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex);
			}
			
		}
    }
}
