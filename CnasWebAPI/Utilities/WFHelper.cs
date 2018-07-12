using Cnas.wns.CnasWorkflowArithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.SessionState;

namespace Cnas.wns.CnasWebAPI
{
    public class WFHelper
    {
		private static WFHelper _instance;
		public static WFHelper Instance
		{
			get
			{
				if (_instance == null)
					_instance = new WFHelper();
				return _instance;
			}
		}

		public WorkflowArithmeticClass GetWFLogic(HttpSessionState session)
		{
			WorkflowArithmeticClass wfLogic = null;
			if (session != null)
				wfLogic = session["WorkflowArithmetic"] as WorkflowArithmeticClass;
			if (wfLogic == null)
			{
				wfLogic = new WorkflowArithmeticClass();
				session["WorkflowArithmetic"] = wfLogic;
			}

			return wfLogic;
		}

    }
}
