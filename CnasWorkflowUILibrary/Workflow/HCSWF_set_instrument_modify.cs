using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
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
	public partial class HCSWF_set_instrument_modify : BaseForm
	{
		private string _setBarCode = string.Empty;
		public DataRow SetData = null;

		public HCSWF_set_instrument_modify(string setBarCode)
		{
			InitializeComponent();
			
			_setBarCode = setBarCode;
			this.FormClosed += OnFormClosed;
		}

		public override void InitializeButtonImage()
		{
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			if (!_isInitalizeSpeSet && SetData != null)
			{
				SortedList input02 = new SortedList();
				SortedList sqlParam = new SortedList();
				SortedList input = new SortedList();
				sqlParam.Add(1, input);
				sqlParam.Add(2, input02);
				int index = 1;
				//Todo rui add the guid;
				//Guid guid = new Guid();
				foreach (DataGridViewRow item in instrumentGrid.Rows)
				{
					SortedList workSpecialSet = new SortedList();
					workSpecialSet.Add(1, SetData["id"].ToString());
					workSpecialSet.Add(2, SetData["wswf_code"].ToString());
					workSpecialSet.Add(3, setBarCodeTxt.Text);
					workSpecialSet.Add(4, item.Cells["inIdCol"].Value != null ? item.Cells["inIdCol"].Value.ToString() : "");
					workSpecialSet.Add(5, item.Cells["inNumCol"].Value != null ? item.Cells["inNumCol"].Value.ToString() : "");
					workSpecialSet.Add(6, SetData["wswf_code"].ToString());
					workSpecialSet.Add(7, item.Cells["inRemarkCol"].Value != null ? item.Cells["inRemarkCol"].Value.ToString() : "");
					input02.Add(index, workSpecialSet);
					index++;
				}

				string sqlTest = RemoteClient.RemotInterface.CheckUPDataList("HCS-workset-add003", sqlParam);
				int result = RemoteClient.RemotInterface.UPDataList("HCS-workset-add003", sqlParam);

				if (result >= 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private bool _isInitalizeSpeSet = true;

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			if (string.IsNullOrEmpty(_setBarCode) && SetData == null)
				MessageBox.Show("初始化器械包信息失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				setBarCodeTxt.Text = _setBarCode;
				if (SetData == null)
				{
					SortedList condition = new SortedList();
					condition.Add(1, "0");
					condition.Add(2, _setBarCode);
					string sql = string.Empty;
					if (BarCodeHelper.IsOrderSet(_setBarCode))
					{
						sql = "HCS-orderid-manager-sec004";
						//setPriortyTxt.Visible = false;
						//setSterilizerTxt.Visible = false;
						//setWashingTxt.Visible = false;
						//setTypeTxt.Visible = false;
					}
					else
					{
						sql = "HCS-work-set-sec004";
					}
					string testSql = RemoteClient.RemotInterface.CheckSelectData(sql, condition);
					DataTable data = RemoteClient.RemotInterface.SelectData(sql, condition);
					if (data != null && data.Rows.Count > 0)
					{
						for (int i = 0; i < data.Rows.Count; i++)
						{
							if (data.Rows[i]["bar_code"] != null && data.Rows[i]["bar_code"].ToString() == _setBarCode)
							{
								SetData = data.Rows[i];
								break;
							}
						}
					}
				}

				if (SetData != null)
				{
					if (SetData.Table.Columns.Contains("ca_name") && SetData["ca_name"] != null) setNameTxt.Text = SetData["ca_name"].ToString();
					//if (SetData.Table.Columns.Contains("pa_type") && SetData["pa_type"] != null) setTypeTxt.Text = SetData["pa_type"].ToString();
					//if (SetData.Table.Columns.Contains("pa_priorty") && SetData["pa_priorty"] != null) setPriortyTxt.Text = SetData["pa_priorty"].ToString();
					//if (SetData.Table.Columns.Contains("st_pr_Name") && SetData["st_pr_Name"] != null) setSterilizerTxt.Text = SetData["st_pr_Name"].ToString();
					//if (SetData.Table.Columns.Contains("wa_pr_Name") && SetData["wa_pr_Name"] != null) setWashingTxt.Text = SetData["wa_pr_Name"].ToString();
					//if (SetData.Table.Columns.Contains("location_name") && SetData["location_name"] != null) userLocationTxt.Text = SetData["location_name"].ToString();
					RefreshDataGrid();
				}
			}
		}

		private void RefreshDataGrid()
		{
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, _setBarCode);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec002", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-instrument-info-sec002", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					DataConverter.GenerateInstrumentRow(instrumentGrid,item);
				}
			}
			else
			{
				_isInitalizeSpeSet = false;
				condition[2] = SetData != null ? SetData["base_set_id"] : 0;
				testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec001", condition);
				data = RemoteClient.RemotInterface.SelectData("HCS-instrument-info-sec001", condition);
				if (data != null && data.Rows.Count > 0)
				{
					foreach (DataRow item in data.Rows)
					{
						DataConverter.GenerateInstrumentRow(instrumentGrid, item);
					}
				}
			}
		}

		private void OnSaveBtnClick(object sender, EventArgs e)
		{
			if (_isInitalizeSpeSet)
			{
				SortedList saveData = new SortedList();
				for (int i = 0; i < instrumentGrid.Rows.Count; i++)
				{
					DataGridViewRow row = instrumentGrid.Rows[i];
					DataRow rowData = row.Tag as DataRow;

					if (rowData != null)
					{
						SortedList saveItem = new SortedList();
						saveItem.Add(1, row.Cells["inNumCol"].Value != null ? row.Cells["inNumCol"].Value.ToString() : "");
						saveItem.Add(2, row.Cells["inRemarkCol"].Value != null ? row.Cells["inRemarkCol"].Value.ToString() : "");
						saveItem.Add(3, "1");
						saveItem.Add(4, rowData["wsin_id"]);
						saveData.Add(i, saveItem);
					}
				}

				string testSql = RemoteClient.RemotInterface.CheckUPDataList("HCS-work-specialset-info-up001", saveData);
				int result = RemoteClient.RemotInterface.UPDataList("HCS-work-specialset-info-up001", saveData);
				if (result > -1)
				{
					Close();
				}
				else
				{
					MessageBox.Show("保存特殊器械包器械配置失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
				Close();
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
