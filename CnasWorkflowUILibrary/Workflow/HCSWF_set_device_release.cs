using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class
		HCSWF_set_device_release : ControlViewBase
	{
		/// <summary>
		/// (释放)1-是2-否
		/// </summary>
		public int ConfirmMode;
		/// <summary>
		/// 是否释放的包条形码
		/// </summary>
		//public SortedList BarCodeList;
		/// <summary>
		/// 用户编码
		/// </summary>
		private string _UserCode;
		/// <summary>
		/// 机器码
		/// </summary>
		private string _MachineCode;

		private string _machineId;
		/// <summary>
		/// 1-清洗2-灭菌
		/// </summary>
		private int pdCodeType;

		/// <summary>
		/// winform初始化
		/// </summary>
		public HCSWF_set_device_release()
		{
			InitializeComponent();
			HasManualHandle = false;
		}
		/// <summary>
		/// winform初始化
		/// </summary>
		/// <param name="codeList">用户编码-流程码-机器码</param>
		public HCSWF_set_device_release(SortedList codeList)
			: base(codeList)
		{
			InitializeComponent();
			HasManualHandle = false;
		}
		/// <summary>
		/// 解析传进来的codeList
		/// </summary>
		/// <param name="codeList"></param>
		private void GetInitData(SortedList codeList)
		{
			for (int i = 0; i < codeList.Count; i++)
			{
				string a = GetValueStr(codeList.GetKey(i));
				if (a.Contains("BCB"))
				{
					this._UserCode = a;
				}
				else if (a.Contains("BCZ"))
				{
					this._MachineCode = a;
				}
				else if (a.Contains("BCW"))
				{
					this._MachineCode = a;
				}
			}
			HasManualHandle = false;
		}
		/// <summary>
		/// 初始化窗口控件 -- 在Load事件中加载
		/// </summary>
		public override void InitalizeControl()
		{
			base.InitalizeControl();
			GetInitData(ScanBarCodes);
			LoadDataForm();
		} 

		/// <summary>
		/// 返回 0未知1清洗2灭菌
		/// </summary>
		/// <returns></returns>
		private int GetReleaseMachineType()
		{
			string washingMachineCode = BarCodeHelper.GetBarCodeByType("BCW", ScanBarCodes);
			string sterilizerMachineCode = BarCodeHelper.GetBarCodeByType("BCZ", ScanBarCodes);

			if ((!string.IsNullOrEmpty(washingMachineCode) && !string.IsNullOrEmpty(sterilizerMachineCode)) ||
				(string.IsNullOrEmpty(washingMachineCode) && string.IsNullOrEmpty(sterilizerMachineCode)))
				return 0;
			if (!string.IsNullOrEmpty(washingMachineCode))
				return 2;
			if (!string.IsNullOrEmpty(sterilizerMachineCode))
				return 1;

			return 0;
		}


		/// <summary>
		/// 将obj的值转化为string
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		private string GetValueStr(object obj)
		{
			if (obj == null)
				return string.Empty;
			return obj.ToString();
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadDataForm()
		{
			setDataGrid.Rows.Clear();

			pdCodeType = GetReleaseMachineType();
			if (pdCodeType == 0)
			{
				MessageBox.Show("内部流程码错误!");
				return;
			}
			if (!string.IsNullOrEmpty(PdCode) && !string.IsNullOrEmpty(_UserCode) && !string.IsNullOrEmpty(_MachineCode))
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList condition = new SortedList();
				string tempDescription = string.Empty;
				DataTable machineInfo = null;//这里查询机器码相关信息
				condition.Add(1, _MachineCode);
				condition.Add(2, CnasBaseData.SystemID);
				int deviceProgramLastTimes = 10;
				//清洗
				if (pdCodeType == 2)
				{
					string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_work_set_freeinfo_show_sec002", condition);
					machineInfo = reCnasRemotCall.RemotInterface.SelectData("HCS_work_set_freeinfo_show_sec002", condition);
				}
				//灭菌
				else if (pdCodeType == 1)
				{
					string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_work_set_freeinfo_show_sec003", condition);
					machineInfo = reCnasRemotCall.RemotInterface.SelectData("HCS_work_set_freeinfo_show_sec003", condition);
				}
				if (machineInfo != null)
				{
					//getdt不知道会不会出现多个Row
					if (machineInfo.Rows != null && machineInfo.Rows.Count > 0)
					{
						txtBatch.Text = GetValueStr(machineInfo.Rows[0]["dev_runtimes"]);
						machineTxt.Text = GetValueStr(machineInfo.Rows[0]["dev_name"]);
						txtProgram.Text = GetValueStr(machineInfo.Rows[0]["pr_name"]);
						int.TryParse(GetValueStr(machineInfo.Rows[0]["pro_runtimes"]), out deviceProgramLastTimes);
						if (machineInfo.Rows[0]["start_time"] != null)
						{
							txtBatchStartDate.Value = DateTime.Parse(machineInfo.Rows[0]["start_time"].ToString());
							txtBatchEndDate.Value = txtBatchStartDate.Value.AddMinutes(deviceProgramLastTimes);
							txtCreateDate.Value = txtBatchStartDate.Value;
						}
						if (machineInfo.Columns.Contains("dev_id") && !(machineInfo.Rows[0]["dev_id"] is DBNull))
						{
							_machineId = machineInfo.Rows[0]["dev_id"].ToString();
							machineTxt.Tag = _machineId;
						}
					}
				}

				//查询datagrid的数据
				condition = new SortedList();
				DataTable data = null;
				condition.Add(1, PdCode);
				condition.Add(2, "0");
				condition.Add(3, _MachineCode);
				setNumTxt.Text = "0";
				data = reCnasRemotCall.RemotInterface.SelectData("HCS-work-set-sec005", condition);
				if (data != null)
				{
					DateTime createDate = DateTime.Now;
					foreach (DataRow item in data.Rows)
					{
						DataConverter.ConvertSetData(setDataGrid, item);
					}

					setDataGrid.Rows[0].Selected = true;
				}
				AppendTempBCCSet();
				setNumTxt.Text = setDataGrid.RowCount.ToString();
			}
		}

		public override void AppendTempBCCSet()
		{
			SortedList condition = new SortedList();
			condition.Add(1, PdCode);
			condition.Add(2, "0");
			condition.Add(3, _MachineCode);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-workset-tempBCC-sec002", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-workset-tempBCC-sec002", condition);
			if (data != null)
			{
				foreach (DataRow item in data.Rows)
				{
					int rowIndex = -1;
					string bccCode = Convert.ToString(item["bar_code"]);
					if (item.Table.Columns.Contains("bar_code") && item["bar_code"] != null && (BarCodeHelper.IsTempSet(item["bar_code"].ToString()) || BarCodeHelper.IsOrderSet(item["bar_code"].ToString())))
						rowIndex = DataConverter.ConvertSetData(setDataGrid, item);
					if (BarCodeHelper.IsOrderSet(bccCode) && item.Table.Columns.Contains("order_type") && setDataGrid.Columns.Contains("setTypeCol") && rowIndex >= 0)
						setDataGrid.Rows[rowIndex].Cells["setTypeCol"].Value = item["order_type"];
				}
			}
		}

		public void AddMachineCheck()
		{
			if (!string.IsNullOrEmpty(_machineId))
			{
				this.Invoke(new Action(() => {
					SortedList data = new SortedList();
					data.Add("dev_name", machineTxt.Text);
					data.Add("pro_name", txtProgram.Text);
					data.Add("batch_num", txtBatch.Text);
					data.Add("object_id", _machineId);
					data.Add("bar_code", _MachineCode);
					HCSWF_device_result_add dialog = new HCSWF_device_result_add(data, pdCodeType);
					dialog.OperationUser = this.UserInfo;
					dialog.ShowDialog();
				}));

			}
		}

		public void AddSetCheck()
		{
			if (setDataGrid.CurrentRow != null && setDataGrid.CurrentRow.Tag is DataRow)
			{
				this.Invoke(new Action(() => {
					DataRow rowData = setDataGrid.CurrentRow.Tag as DataRow;
					SortedList data = new SortedList();
					data.Add("dev_name", machineTxt.Text);
					data.Add("pro_name", txtProgram.Text);
					data.Add("batch_num", txtBatch.Text);
					data.Add("object_id", (rowData["id"] is DBNull) ? string.Empty : rowData["id"].ToString());
					data.Add("bar_code", (rowData["bar_code"] is DBNull) ? string.Empty : rowData["bar_code"].ToString());
					data.Add("set_name", (rowData["ca_name"] is DBNull) ? string.Empty : rowData["ca_name"].ToString());
					data.Add("set_priorty", (rowData["pa_priorty"] is DBNull) ? string.Empty : rowData["pa_priorty"].ToString());
					HCSWF_device_result_add dialog = new HCSWF_device_result_add(data, 3);
					dialog.OperationUser = this.UserInfo;
					dialog.ShowDialog();
				}));
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public override string ValidateData()
		{
			IsCfmCloseDialog = 1;
			if(txtBatchEndDate.Value>DateTime.Now)
			{
				MessageBox.Show("当前时间不能小于批次结束时间！");
				IsCfmCloseDialog = 2;
			}
			return string.Empty;
		}

		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = base.SetViewParameters();
			result["ShowParameterUI"] = yesReleaseBtn.IsChecked ? "false" : "true";
			if (yesReleaseBtn.IsChecked)
			{
				SortedList parameter02 = Sl_check["pd_par2"] as SortedList;
				if (parameter02 != null)
				{
					for (int i = 0; i < parameter02.Count; i++)
					{
						string key = parameter02.GetKey(i).ToString();
						if (key.Contains("_result"))
							parameter02[key] = 1;
					}
				}
			}

			if (setDataGrid.Rows.Count > 0)
			{
				//BD test does not need to show items.
				if (setDataGrid.Columns.Contains("setBarCodeCol") &&
					setDataGrid.Rows[0].Cells["setBarCodeCol"].Value != null &&
					setDataGrid.Rows[0].Cells["setBarCodeCol"].Value.Equals(BarCodeHelper.BDTestSetCode))
				{
					result["ShowParameterUI"] = "false";
					SortedList confirmUserParams = new SortedList();
					//是否需要确认包的人编码和信息
					confirmUserParams.Add("BDTestResult", yesReleaseBtn.IsChecked.ToString());
					if (OutputParameters.ContainsKey("BDTestResult"))
					{
						OutputParameters["BDTestResult"] = confirmUserParams;
					}
					else
					{
						OutputParameters.Add("BDTestResult", confirmUserParams);
					}
				}
			}
			return result;
		}
	}
}
