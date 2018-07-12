using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_order_new : UserControl
	{
		public UserBase UserInfo { get; set; }
		private Dictionary<int, DataRow> _instrumentIds = new Dictionary<int, DataRow>();
		private Dictionary<string, List<DataRow>> _workSpecialSet = new Dictionary<string, List<DataRow>>();
		private CnasRemotCall _remoteClient = new CnasRemotCall();
		string _cssdCostCenterConfig = string.Empty;
		public HCSWF_order_new()
		{
			InitializeComponent();
			InitalizeControl();
		}

		public void InitalizeControl()
		{
			//base.InitalizeControl();

			InitalizeCostCNameCbx();
			InitalizeUseLocationCbx();
			InitializeProcedureCbx();
			RefreshSetGrid();
			SetPackageInfo();
		}

		private void InitalizeUseLocationCbx()
		{
			locationsCbx.Items.Add(new KeyValuePair<string, string>("0", "---所 有---"));
			locationsCbx.SelectedIndex = 0;
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.UserBaseInfo.LocationId);
			DataTable data = _remoteClient.RemotInterface.SelectData("HCS-use-location-sec005", condition);
			if (data != null && data.Rows.Count == 1)
			{
				if (data.Rows[0]["u_locationtype"] != null && data.Rows[0]["u_locationtype"].ToString() == "5")
				{
					if (data.Rows[0]["id"] != null && data.Rows[0]["u_uname"] != null)
						locationsCbx.Items.Add(new KeyValuePair<string, string>(data.Rows[0]["id"].ToString(), data.Rows[0]["u_uname"].ToString()));
				}
				else
				{
					condition.Clear();
					string sql = data.Rows[0]["u_customer"] is DBNull ? "HCS-use-location-sec001" : "HCS-use-location-sec005";
					condition.Add(1, data.Rows[0]["u_customer"]);
					string test = _remoteClient.RemotInterface.CheckSelectData(sql, condition);
					DataTable locationData = _remoteClient.RemotInterface.SelectData(sql, condition);
					if (locationData != null)
					{
						foreach (DataRow item in data.Rows)
						{
							if (item["id"] != null && item["u_uname"] != null)
								locationsCbx.Items.Add(new KeyValuePair<string, string>(item["id"].ToString(), item["u_uname"].ToString()));
						}
					}
				}
			}
		}

		private void InitalizeCostCNameCbx()
		{
			costNameCbx.Items.Add(new KeyValuePair<string, string>("0", "---所 有---"));
			costNameCbx.SelectedIndex = 0;

			DataRow[] cssdCostCenterConfig = CnasBaseData.SystemBaseData.Select("type_code='HCS-CSSD-costcenter'");
			
			if (cssdCostCenterConfig != null)
			{
				_cssdCostCenterConfig = string.Empty;
				foreach (DataRow item in cssdCostCenterConfig)
				{
					if (item["key_code"] != null && item["value_code"] != null)
						_cssdCostCenterConfig += string.Format("'{0}',", item["value_code"].ToString());
				}

				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, _cssdCostCenterConfig.Trim(','));
				string testSql = _remoteClient.RemotInterface.CheckSelectData("HCS-costcenter-sec004", condition);
				DataTable data = _remoteClient.RemotInterface.SelectData("HCS-costcenter-sec004", condition);
				if (data != null)
				{
					foreach (DataRow item in data.Rows)
					{
						if (item["bar_code"] != null && item["ca_name"] != null)
							costNameCbx.Items.Add(new KeyValuePair<string, string>(item["bar_code"].ToString(), item["ca_name"].ToString()));
					}
				}
			}
		}

		public void InitializeProcedureCbx()
		{
			DataRow[] accessSetWFConfig = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Access_special_set_wf'");
			if (accessSetWFConfig != null)
			{
				foreach (DataRow data in accessSetWFConfig)
				{
					string[] accessSetWF = data["value_code"].ToString().Split(',');
					foreach (string item in accessSetWF)
					{
						Dictionary<string, string> wfData = ProcedureData.Instance.GetProcedureData(item);
						if (wfData != null && wfData.ContainsKey("pd_code") && wfData.ContainsKey("pd_description"))
						{
							workFlowCbx.Items.Add(new KeyValuePair<string, string>(wfData["pd_code"].ToString(), wfData["pd_description"].ToString()));
						}
					}
					workFlowCbx.SelectedIndex = 0;
					break;
				}
				
			}
		}

		public void RefreshSetGrid()
		{
			setDataGrid.Rows.Clear();
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);

			string useLocations = string.Empty;
			if (costNameCbx.SelectedIndex == 0)
			{
				foreach (var item in locationsCbx.Items)
				{
					KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
					useLocations += string.Format("'{0}',", cbxData.Key);
				}
				useLocations = useLocations.TrimEnd(',');
			}
			else
			{
				useLocations = ((KeyValuePair<string, string>)locationsCbx.SelectedItem).Key;
			}
			condition.Add(2, useLocations);
			condition.Add(3, "9");
			string testSql = _remoteClient.RemotInterface.CheckSelectData("HCS-work-order-set-sec001", condition);
			DataTable data = _remoteClient.RemotInterface.SelectData("HCS-work-order-set-sec001", condition);

			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					DataConverter.ConvertSetData(setDataGrid, item);
				}
			}
		}

		private void SetPackageInfo()
		{
			if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count > 0
				&& setDataGrid.SelectedRows[0].Tag is DataRow)
			{
				DataRow data = setDataGrid.SelectedRows[0].Tag as DataRow;
				setInfoPanel.Tag = data;
				if (data["ca_name"] != null) setNameTxt.Text = data["ca_name"].ToString();
				if (data["bar_code"] != null) setBarCodeTxt.Text = data["bar_code"].ToString();
				if (data["pa_priorty"] != null) setPriortyTxt.Text = data["pa_priorty"].ToString();
				if (data["cost_center_name"] != null) costCNameTxt.Text = data["cost_center_name"].ToString();
				if (data["location_name"] != null) setLocationTxt.Text = data["location_name"].ToString();
				//bool isBCCSSet = BarCodeHelper.IsSpecialSet(setBarCodeTxt.Text); ;
				//
				//saveBtn.Visible = isBCCSSet ? true : false;
				//confirmInNumLbl.Visible = isBCCSSet ? true : false;
				//searchPanel.Visible = isBCCSSet ? true : false;
				//instrumentSearchGrid.Visible = isBCCSSet ? true : false;
				//moveBtnsPanel.Visible = isBCCSSet ? true : false; ;
				//searchBtn.Visible = isBCCSSet ? true : false;
				//instrumentGrid.Columns["instrumentCostCNameCol"].ReadOnly = isBCCSSet ?  false : true;
				//
				//if (isBCCSSet) //订单界面
				//{
					if (data["cost_center"] != null && data["cost_center_name"] != null
						&& costNameCbx.Items != null && costNameCbx.Items.Count > 0)
					{
						KeyValuePair<string, string> lastCostCenter = (KeyValuePair<string, string>)costNameCbx.Items[costNameCbx.Items.Count-1];
						if (lastCostCenter.Key != data["cost_center"].ToString())
						{
							if (!_cssdCostCenterConfig.Contains(((KeyValuePair<string, string>)costNameCbx.Items[costNameCbx.Items.Count - 1]).Key))
								costNameCbx.Items.RemoveAt(costNameCbx.Items.Count - 1);
							costNameCbx.Items.Add(new KeyValuePair<string, string>(data["cost_center"].ToString(), data["cost_center_name"].ToString()));
						}
					}
				//}

				RefreshInstrumentGrid();

				//if (isBCCSSet)
					RefreshInstrumentSearchGrid();
			}
		}

		public void RefreshInstrumentGrid()
		{
			instrumentGrid.Rows.Clear();
			if (_workSpecialSet.ContainsKey(setBarCodeTxt.Text))
			{
				foreach (DataRow item in _workSpecialSet[setBarCodeTxt.Text])
				{
					int instrumentId = 0;
					if (item["id"] != null)
					{
						int.TryParse(item["id"].ToString(), out instrumentId);
						if (!_instrumentIds.ContainsKey(instrumentId))
							_instrumentIds.Add(instrumentId, item);
					}
					GeneratorInstrumentRow(instrumentGrid, item);
				}
			}
			else
			{
				bool isBCCS = BarCodeHelper.IsSpecialSet(setBarCodeTxt.Text);
				//string sql = isBCCS ? "HCS-instrument-info-sec002" : "HCS-instrument-info-sec001";
				string packingSetBaseId = string.Empty;
				if (setInfoPanel.Tag != null && setInfoPanel.Tag is DataRow)
				{
					DataRow setData = setDataGrid.SelectedRows[0].Tag as DataRow;
					if (setData["base_set_id"] != null)
						packingSetBaseId = setData["base_set_id"].ToString();
				}
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, packingSetBaseId);
				string testSql = _remoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec001", condition);
				DataTable data = _remoteClient.RemotInterface.SelectData("HCS-instrument-info-sec001", condition);
				if (data != null && data.Rows.Count > 0)
				{
					List<DataRow> inSpecialList = new List<DataRow>();
					foreach (DataRow item in data.Rows)
					{
						int instrumentId = 0;
						if (item["id"] != null)
						{
							int.TryParse(item["id"].ToString(), out instrumentId);
							if (!_instrumentIds.ContainsKey(instrumentId))
								_instrumentIds.Add(instrumentId, item);
						}
						GeneratorInstrumentRow(instrumentGrid, item);
						inSpecialList.Add(item);
					}
					if (isBCCS)
						_workSpecialSet.Add(setBarCodeTxt.Text, inSpecialList);
				}
			}
			
		}

		private void RefreshInstrumentSearchGrid()
		{
			ClearInstrumentSearchGrid();

			string costCenter = string.Empty;
			if (costNameCbx.SelectedIndex == 0)
			{
				foreach (var item in costNameCbx.Items)
				{
					KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
					costCenter += string.Format("'{0}',", cbxData.Key);
				}
			}
			else
			{
				costCenter = string.Format("'{0}'", ((KeyValuePair<string, string>)costNameCbx.SelectedItem).Key);
			}

			//if (setInfoPanel.Tag != null && setInfoPanel.Tag is DataRow)
			//{
			//	DataRow setData = setDataGrid.SelectedRows[0].Tag as DataRow;
			//	if (setData["cost_center"] != null)
			//		costCenter += string.Format("'{0}',", setData["cost_center"].ToString());
			//}
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, costCenter.TrimEnd(','));
			string testSql = _remoteClient.RemotInterface.CheckSelectData("HCS-instrument-base-sec008", condition);
			DataTable data = _remoteClient.RemotInterface.SelectData("HCS-instrument-base-sec008", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					if ((string.IsNullOrEmpty(inNameTxt.Text) || (item["ca_name"] != null && item["ca_name"].ToString().Contains(inNameTxt.Text))))
					{
						int instrumentId = 0;
						if (item["id"] != null)
						{
							int.TryParse(item["id"].ToString(), out instrumentId);
							if (!_instrumentIds.ContainsKey(instrumentId))
							{
								_instrumentIds.Add(instrumentId, item);
								GeneratorInstrumentRow(instrumentSearchGrid, item);
							}
						}
					}
				}
			}
		}

		private void ClearInstrumentSearchGrid()
		{
			foreach (DataGridViewRow item in instrumentSearchGrid.Rows)
			{
				int instrumentId = 0;
				DataRow itemData = item.Tag as DataRow;
				if (itemData["id"] != null)
				{
					int.TryParse(itemData["id"].ToString(), out instrumentId);
					if (_instrumentIds.ContainsKey(instrumentId))
					{
						_instrumentIds.Remove(instrumentId);
					}
				}
			}
			instrumentSearchGrid.Rows.Clear();
		}

		private void GeneratorInstrumentRow(DataGridView dataGrid, DataRow rowData)
		{
			if (rowData != null)
			{
				int rowIndex = dataGrid.Rows.Add();
				if (dataGrid.Name == "instrumentSearchGrid")
				{
					if (rowData["id"] != null) dataGrid.Rows[rowIndex].Cells["idCol"].Value = rowData["id"];
					if (rowData["ca_name"] != null) dataGrid.Rows[rowIndex].Cells["inNameCol"].Value = rowData["ca_name"];
					if (rowData["instrument_type"] != null) dataGrid.Rows[rowIndex].Cells["inTypeCol"].Value = rowData["instrument_type"];
					if (rowData["costc_name"] != null) dataGrid.Rows[rowIndex].Cells["inCostCNameCol"].Value = rowData["costc_name"];
				}
				else if (dataGrid.Name == "instrumentGrid")
				{
					if (rowData["id"] != null) dataGrid.Rows[rowIndex].Cells["inIdCol"].Value = rowData["id"];
					if (rowData["ca_name"] != null) dataGrid.Rows[rowIndex].Cells["instrumentNameCol"].Value = rowData["ca_name"];
					if (rowData["instrument_type"] != null) dataGrid.Rows[rowIndex].Cells["instrumentTypeCol"].Value = rowData["instrument_type"];
					if (rowData["instrument_num"] != null) dataGrid.Rows[rowIndex].Cells["instrumentNumCol"].Value = rowData["instrument_num"];
					if (rowData["costc_name"] != null) dataGrid.Rows[rowIndex].Cells["instrumentCostCNameCol"].Value = rowData["costc_name"];
					if (rowData["ca_price"] != null) dataGrid.Rows[rowIndex].Cells["instrumentPriceCol"].Value = rowData["ca_price"];
				}
				dataGrid.Rows[rowIndex].Tag = rowData;
			}

		}

		private void MoveData(bool onlyMoveSelect, bool leftToRight)
		{
			DataGridView sourceGrid = leftToRight ? instrumentSearchGrid : instrumentGrid;
			DataGridView targetGrid = leftToRight ? instrumentGrid : instrumentSearchGrid;

			IList sourceCollection = null;
			if (onlyMoveSelect)
				sourceCollection = sourceGrid.SelectedRows;
			else
				sourceCollection = sourceGrid.Rows;

			for (int i = 0; i < sourceCollection.Count; i++)
			{
				DataGridViewRow row = sourceCollection[i] as DataGridViewRow;
				DataRow data = row.Tag as DataRow;
				if (data != null)
				{
					sourceGrid.Rows.Remove(row);
					GeneratorInstrumentRow(targetGrid, data);
					if (!onlyMoveSelect)
						i--;
				}
			}
		}

		private void OnSearchBtnClick(object sender, EventArgs e)
		{
			RefreshInstrumentSearchGrid();
		}

		private void moveRightAllBtn_Click(object sender, EventArgs e)
		{
			MoveData(false, true);
		}

		private void moveRightBtn_Click(object sender, EventArgs e)
		{
			MoveData(true, true);
		}

		private void moveLeftBtn_Click(object sender, EventArgs e)
		{
			MoveData(true, false);
		}

		private void moveLeftAllBtn_Click(object sender, EventArgs e)
		{
			MoveData(false, false);
		}

		private void OnRowSelectionChanged(object sender, EventArgs e)
		{
			_instrumentIds.Clear();
			instrumentSearchGrid.Rows.Clear();
			costNameCbx.SelectedIndex = 0;
			SetPackageInfo();
		}


		private void saveBtn_Click(object sender, EventArgs e)
		{
			//
			// List<DataRow> inSpecialList = new List<DataRow>();
			//foreach (DataGridViewRow item in instrumentGrid.Rows)
			//{
			//	if(item.Tag != null && item.Tag is DataRow)
			//		inSpecialList.Add(item.Tag as DataRow);
			//}
			//if (_workSpecialSet.ContainsKey(setBarCodeTxt.Text))
			//	_workSpecialSet[setBarCodeTxt.Text] = inSpecialList;
			//else
			//	_workSpecialSet.Add(setBarCodeTxt.Text, inSpecialList);
			if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1
				&& setDataGrid.SelectedRows[0].Tag is DataRow)
			{
				DataRow rowData = setDataGrid.SelectedRows[0].Tag as DataRow;
				SortedList input01 = new SortedList();
				SortedList input02 = new SortedList();
				SortedList sqlParam = new SortedList();
				SortedList input = new SortedList();
				sqlParam.Add(1, input);
				sqlParam.Add(2, input02);
				string set_id = rowData["id"].ToString();
				string wf_code = ((KeyValuePair<string, string>)workFlowCbx.SelectedItem).Key;
				int index = 1;
				input01.Add(1, set_id);
				input01.Add(2, set_id);
				input01.Add(3, wf_code);
				input01.Add(4, set_id);
				input01.Add(5, setBarCodeTxt.Text);
				input01.Add(6, setNameTxt.Text);
				input01.Add(7, wf_code);
				input01.Add(8, CnasBaseData.UserID);
				input01.Add(9, "");
				input.Add(1, input01);
				foreach(DataGridViewRow item in instrumentGrid.Rows)
				{
					SortedList workSpecialSet = new SortedList();
					workSpecialSet.Add(1, set_id);
					workSpecialSet.Add(2, wf_code);
					workSpecialSet.Add(3, setBarCodeTxt.Text);
					workSpecialSet.Add(4, item.Cells["inIdCol"].Value != null ? item.Cells["inIdCol"].Value.ToString() : "");
					workSpecialSet.Add(5, item.Cells["instrumentNumCol"].Value != null ? item.Cells["instrumentNumCol"].Value.ToString() : "");
					workSpecialSet.Add(6, wf_code);
					workSpecialSet.Add(7, item.Cells["instrumentRemarkCol"].Value != null ? item.Cells["instrumentRemarkCol"].Value.ToString() : "");
					input02.Add(index, workSpecialSet);
					index++;
				}

				string sqlTest = _remoteClient.RemotInterface.CheckUPDataList("HCS-workset-add003", sqlParam);
				int result = _remoteClient.RemotInterface.UPDataList("HCS-workset-add003", sqlParam);

				if (result > 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[]{"订单"}), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.ParentForm != null)
						this.RefreshSetGrid();
				}
				else
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public void SetViewParameters()
		{
			//base.SetViewParameters();
			SortedList workSetInfos = new SortedList();
			int index = 1;
			foreach (var item in _workSpecialSet)
			{
				DataRow setData = null;
				foreach (DataGridViewRow setRow in setDataGrid.Rows)
				{
					DataRow rowData = setRow.Tag as DataRow;
					if (rowData["bar_code"] != null && rowData["bar_code"].ToString() == item.Key)
					{
						setData = rowData;
						break;
					}
				}

				foreach (DataRow data in item.Value)
				{
					SortedList workSpecialInfo = new SortedList();
					workSpecialInfo.Add(0, "0");
					workSpecialInfo.Add(1, setData["ws_id"]);
					workSpecialInfo.Add(2, item.Key.ToString());
					workSpecialInfo.Add(3, data["id"].ToString());
					//workSpecialInfo.Add("workspecial_id", 0);
					workSpecialInfo.Add(4, data["instrument_num"].ToString());
					//workSpecialInfo.Add(5, PdCode);
					workSpecialInfo.Add(6, "1");
					workSpecialInfo.Add(7, "");
					workSetInfos.Add(index, workSpecialInfo);
					index++;
				}
			}

			//OutputParameters.Add("workspecialList", workSetInfos);
		}

		private void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = instrumentGrid.Rows[e.RowIndex];
			DataRow rowData = row.Tag as DataRow;
			if (rowData != null && rowData["instrument_num"] != null)
			{
				rowData["instrument_num"] = instrumentGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			}
		}

		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			if (this.ParentForm != null)
			{
				ParentForm.Close();
			}
		} 

		private void setSearchBtn_Click(object sender, EventArgs e)
		{
			RefreshSetGrid();
		}

	}
}
