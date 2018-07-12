using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasWorkflowUILibrary
{
    public class ProcedureData
    {
        private static ProcedureData _instance = null;
		private SortedList _data;

        public static ProcedureData Instance
        {  
			get
			{
				if (_instance == null)
					_instance = new ProcedureData();
				return _instance;  
			}
        }

        public SortedList Procedures { get { return _data; } }

		private ProcedureData()
		{
			// _Datas  Value
			_data = GetProcedures();
		}

        private SortedList GetProcedures()
        {
            CnasRemotCall RemoteClient=new CnasRemotCall();
            SortedList procedures = new SortedList();
            DataTable data = RemoteClient.RemotInterface.SelectData("HCS-procedure-sec002", null);
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    DataRow row = data.Rows[i] as DataRow;
                    if (row["id"] != null) item.Add("id", row["id"].ToString());
                    if (row["pd_code"] != null) item.Add("pd_code", row["pd_code"].ToString());
                    if (row["pd_bcode"] != null) item.Add("pd_bcode", row["pd_bcode"].ToString());
                    if (row["pd_name"] != null) item.Add("pd_name", row["pd_name"].ToString());
                    if (row["pd_scan"] != null) item.Add("pd_scan", row["pd_scan"].ToString());
                    if (row["pd_description"] != null) item.Add("pd_description", row["pd_description"].ToString());
                    if (row["pd_Type"] != null) item.Add("pd_Type", row["pd_Type"].ToString());
                    if (row["state"] != null) item.Add("state", row["state"].ToString());
                    if (row["split_count"] != null) item.Add("split_count", row["split_count"].ToString());
                    if (row["cyc_location"] != null) item.Add("cyc_location", row["cyc_location"].ToString());
                    if (row["si_id"] != null) item.Add("si_id", row["si_id"].ToString());
                    procedures.Add(i, item);
                }
            }
            return procedures;
        }

		public string GetProcedureDesciption(string pdCode)
		{
			string description = string.Empty;

			if (_data != null && _data.Count > 0)
			{
				for (int i = 0; i < _data.Count; i++)
				{
					Dictionary<string, string> procedure = _data[i] as Dictionary<string, string>;
					if (procedure != null && procedure.ContainsKey("pd_code")
						&& procedure["pd_code"].ToString() == pdCode && procedure.ContainsKey("pd_description"))
					{
						description = procedure["pd_description"].ToString();
						break;
					}
				}
			}

			return description;
		}

		public Dictionary<string, string> GetProcedureData(string pdCode)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			if (_data != null && _data.Count > 0)
			{
				for (int i = 0; i < _data.Count; i++)
				{
					Dictionary<string, string> procedure = _data[i] as Dictionary<string, string>;
					if (procedure != null && procedure.ContainsKey("pd_code")
						&& procedure["pd_code"].ToString() == pdCode)
					{
						result = procedure;
						break;
					}
				}
			}

			return result;
		}


		public List<Dictionary<string, string>> GetPdOperations(string pdCode)
		{
			List<Dictionary<string, string>> operations = new List<Dictionary<string, string>>();
			CnasRemotCall RemoteClient = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, pdCode);
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-ca-operation-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-ca-operation-sec001", condition);
			if (data != null)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					DataRow row = data.Rows[i] as DataRow;
					Dictionary<string, string> operation = new Dictionary<string, string>();
					if (row["id"] != null) operation.Add("id", row["id"].ToString());
					if (row["op_name"] != null) operation.Add("op_name", row["op_name"].ToString());
					if (row["op_brietcode"] != null) operation.Add("op_brietcode", row["op_brietcode"].ToString());
					if (row["function_name"] != null) operation.Add("function_name", row["function_name"].ToString());
					if (row["state"] != null) operation.Add("state", row["state"].ToString());
					if (row["op_ico"] != null) operation.Add("op_ico", row["op_ico"].ToString());
					if (row["sort_id"] != null) operation.Add("sort_id", row["sort_id"].ToString());
					if (row["op_barCode"] != null) operation.Add("op_barCode", row["op_barCode"].ToString());
					if (row["is_contextmenu"] != null) operation.Add("is_contextmenu", row["is_contextmenu"].ToString());
					if (row["op_objectType"] != null) operation.Add("op_objectType", row["op_objectType"].ToString());
					operations.Add(operation);
					//buttonGroup.Items.Add(operation);
				}
			}

			return operations;
		}
    }
}
