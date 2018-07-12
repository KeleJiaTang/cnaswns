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
	public partial class HCSWF_set_device_load : ControlViewBase
	{
		/// <summary>
		/// 上一个批次
		/// </summary>
		private int _runtimes;
		/// <summary>
		/// 机器类型
		/// </summary>
		private int _MachineType;

		/// <summary>
		/// 机器码
		/// </summary>
		private string _MachineCode;

		/// <summary>
		/// 有效的包条形码
		/// </summary>
		public SortedList BarcodeList;
		/// <summary>
		/// winform初始化
		/// </summary>
		public HCSWF_set_device_load()
		{
			InitializeComponent();
			HasManualHandle = false;
		}
		/// <summary>
		/// winform初始化 BaseForm
		/// </summary>
		/// <param name="codeList"></param>
		public HCSWF_set_device_load(SortedList codeList):base(codeList)
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

				if (a.Contains("BCZ") || a.Contains("BCW"))
				{
					this._MachineCode = a;
				}
			}

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
		/// 初始化窗口控件 -- 在Load事件中加载
		/// </summary>
		public override void InitalizeControl()
		{
			base.InitalizeControl();
			GetInitData(ScanBarCodes);
			InitalizeMachine();
			RefreshDataGrid();
		}

		public void InitalizeMachine()
		{
			string deviceSql = string.Empty;
			if (WorkflowServer != null && WorkflowServer.Add_washing_count.Contains(PdCode))
			{
				deviceSql = "HCS-washing-program-sec003";
				_MachineType = 1;
			}
			else if (WorkflowServer != null && WorkflowServer.Add_setandsterilizer_count.Contains(PdCode))
			{
				deviceSql = "HCS-sterilizer-program-sec003";
				_MachineType = 2;
			}

			SortedList condition = new SortedList();
			condition.Add(1, _MachineCode);
			condition.Add(2, CnasBaseData.SystemID);
			condition.Add(3, BarCodeHelper.GetBarCodeByType("BCP", ScanBarCodes));
			//1 清洗  2 装载灭菌

			DataTable getMachinedt = RemoteClient.RemotInterface.SelectData(deviceSql, condition);

			//getdt不知道会不会出现多个Row
			if (getMachinedt != null && getMachinedt.Rows.Count > 0)
			{
				machineTxt.Text = GetValueStr(getMachinedt.Rows[0]["dev_name"]);
				txtProgramName.Text = GetValueStr(getMachinedt.Rows[0]["pr_name"]);

				int.TryParse(GetValueStr(getMachinedt.Rows[0]["dev_runtimes"]), out _runtimes);
				condition.Clear();
				condition.Add(1, PdCode);
				condition.Add(2, _MachineCode);
				condition.Add(3, 0);
				string testSQL = string.Empty;
				try
				{
					testSQL = RemoteClient.RemotInterface.CheckSelectData("HCS-machine-release-sec001", condition);

					DataTable data = RemoteClient.RemotInterface.SelectData("HCS-machine-release-sec001", condition);
					if (data != null && data.Rows.Count > 0)
					{
						btnChange.Enabled = false;
					}
					else
					{
						_runtimes = _runtimes + 1;
					}
					
					txtBatch.Text = _runtimes.ToString();
				}
				catch(Exception ex)
				{
					Logger.Error("Error on HCS-workset-sec003:", ex);
				}
			}
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void RefreshDataGrid()
		{
			setDataGrid.Rows.Clear();
			if(string.IsNullOrEmpty(PdCode)||string.IsNullOrEmpty(_MachineCode))
			{
				return;
			}
			else
			{
				//dgv_01 数据
				SortedList condition = new SortedList();
				condition.Add(1, PdCode);
				condition.Add(2, "0");

				string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", ScanBarCodes);
				setBarCodes = setBarCodes.Replace(",", "','");
				condition.Add(3, setBarCodes);
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec003", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec003", condition);
				if(data!=null&&data.Rows.Count>0)
				{
					for (int i = 0; i < data.Rows.Count; i++)
					{
						DataConverter.ConvertSetData(setDataGrid, data.Rows[i]);
					}
				}
				AppendTempBCCSet();
				setNumTxt.Text = setDataGrid.RowCount.ToString();
			}
		}

		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = base.SetViewParameters();

			OutputParameters = OutputParameters ?? new SortedList();
			SortedList deviceParams = new SortedList();
			deviceParams.Add("device_runtimes", txtBatch.Text);
			deviceParams.Add("device_barcode", _MachineCode);
			OutputParameters.Add("deviceParams", deviceParams);

			return result;
		}

		public override string ValidateData()
		{
			IsCfmCloseDialog = 1;
			string tempBatch = txtBatch.Text.Trim();
			int tempBatchNum=0;
			bool isNum=int.TryParse(tempBatch, out tempBatchNum);
			if (isNum)
			{
				if (tempBatchNum < _runtimes)
				{
					MessageBox.Show(string.Format("修改的批次不能比当前批次-{0}小!", _runtimes), "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					IsCfmCloseDialog = 2;
				}
			}
			else
			{
				MessageBox.Show("修改的批次只能是数字! \r\n", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				IsCfmCloseDialog = 2;
			}
			if (IsCfmCloseDialog == 1)
			{
				string strProgramName = txtProgramName.Text.Trim();
				string machineStr = string.Format("机 器:{0}  程序：{1} \r\n", machineTxt.Text.Trim(), strProgramName);
				string packageProgramStr = string.Empty;
				if (setDataGrid.Rows.Count > 0)
				{
					for (int i = 0; i < setDataGrid.Rows.Count; i++)
					{
						DataGridViewRow row = setDataGrid.Rows[i];
						string tempStr = GetValueStr(row.Cells["washingPCol"].Value);
						if (_MachineType == 2) tempStr = GetValueStr(row.Cells["sterilizerPCol"].Value);
						if (!string.IsNullOrEmpty(tempStr) && !tempStr.Trim().Equals(strProgramName))
						{
							packageProgramStr += string.Format("器械包:{0}  程序：{1} \r\n", GetValueStr(row.Cells["setNameCol"].Value), tempStr);
						}
					}
				}
				if (!string.IsNullOrEmpty(packageProgramStr))
				{
					DialogResult result = MessageBox.Show(machineStr + packageProgramStr,_MachineType==1?"清洗程序不一致":"灭菌程序不一致", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					//if (result == DialogResult.Cancel) IsCfmCloseDialog = 2;
				}
			}
			return string.Empty;
		}

		private void txtBatch_TextChanged(object sender, EventArgs e)
		{
			int inputRun = _runtimes;
			if (int.TryParse(txtBatch.Text, out inputRun))
			{
				txtBatch.ForeColor = _runtimes > inputRun ? Color.Red : Color.DarkSeaGreen;
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidbatchnum", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				txtBatch.Text = _runtimes.ToString();
			}
		}

		private void OnTxtBatchKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				//txtBatch.Enabled = false;
				txtBatch.ReadOnly = true;
				setDataGrid.Focus();
			}
		}

		/// <summary>
		/// 更改批次 记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChangce_Click(object sender, EventArgs e)
		{
			txtBatch.ReadOnly = false;
			txtBatch.Focus();
		}
	}
}
