using Cnas.wns.CnasBaseClassClient;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public class WorkFlowDialogGenerator
	{
		//private static string _workflowDialogConfig = ConfigurationManager.AppSettings["WorkflowDialogConfig"].ToString(); 
		private static WorkFlowDialogGenerator _instance;
		//private XmlDocument _configDoc = new XmlDocument();
		public ILog Logger = null;

		public static WorkFlowDialogGenerator Instance
		{
			get
			{
				if (_instance == null)
					_instance = new WorkFlowDialogGenerator();
				return _instance;
			}
		}

		public WorkFlowDialogGenerator()
		{
			//_configDoc.Load(_workflowDialogConfig);
			Logger = LogManager.GetLogger("CnasWNSClient");
		}

		public ControlViewBase GeneratorWFDialog(string pdCode)
		{
			ControlViewBase viewBase = null;
			try
			{
				SortedList condition = new SortedList();
				//condition.Add(1, CnasBaseData.SystemID);
				condition.Add(1, pdCode);
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-procedure-dialog-sec001", condition);
				DataTable data = remoteCall.RemotInterface.SelectData("HCS-procedure-dialog-sec001", condition);
				if (data != null && data.Rows.Count > 0 && data.Columns.Contains("assembly")
					&& data.Columns.Contains("fullName") && data.Columns.Contains("isLoad"))
				{
					string assemblyName = data.Rows[0]["assembly"].ToString();
					string fullName = data.Rows[0]["fullName"].ToString();
					viewBase = Assembly.Load(assemblyName).CreateInstance(fullName) as ControlViewBase;
					viewBase.IsShown = data.Rows[0]["isLoad"].ToString() == "1";
					//Boolean.TryParse(data.Rows[0]["isLoad"].ToString(), out viewBase.IsShown);
				}
				else
				{
					Logger.Info(string.Format("Dialog does not set for the Workflow. Wf_code:{0}.", pdCode));
				}
			}
			catch (Exception ex)
			{
				Logger.Error(string.Format("Generate form exception errorMessage: {0}.", ex.Message));
			}
			return viewBase;
		}

	}
}
