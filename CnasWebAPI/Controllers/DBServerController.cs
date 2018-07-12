using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasWebAPI;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cnas.wns.CnasWebAPI.Controllers
{
    public class DBServerController : ApiController
    {
		[HttpPost]
		public HttpResponseMessage GetData(dynamic content)
		{
			HttpResponseMessage result = null;
			ILog logger = LogManager.GetLogger("CnasWebAPI");

			logger.Info(content);
			try
			{
				if (content == null)
				{
					return null;
				}
				DataTable data = null;
				SortedList condition = JsonHelper.GetJsonObject<SortedList>(content.Condition.ToString());
				string sql = Convert.ToString(content.Connection);
				Dictionary<string, dynamic> resultData = new Dictionary<string, dynamic>();
				if (!string.IsNullOrEmpty(sql) && condition != null)
				{
					CnasRemotCall remoteCall = new CnasRemotCall();
					string testSql = remoteCall.RemotInterface.CheckSelectData(sql, condition);
					data = remoteCall.RemotInterface.SelectData(sql, condition);
					resultData.Add("Result", data);
					result = Request.CreateResponse(HttpStatusCode.OK, resultData);
				}
				else
				{
					resultData.Add("ResultMessage", "查询不到信息");
					result = Request.CreateResponse(HttpStatusCode.OK, resultData);
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
