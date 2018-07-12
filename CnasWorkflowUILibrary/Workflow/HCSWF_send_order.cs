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
using System.Windows.Controls;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_send_order : ControlViewBase
	{
		private Dictionary<int, DataRow> _instrumentIds = new Dictionary<int, DataRow>();
		private Dictionary<string, List<DataRow>> _workSpecialSet = new Dictionary<string, List<DataRow>>();

		public HCSWF_send_order()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();

			costNameCbx.Items.Add(new KeyValuePair<string, string>("0", "---所 有---"));
			costNameCbx.SelectedIndex = 0;

			DataRow[] cssdCostCenterConfig = CnasBaseData.SystemBaseData.Select("type_code='HCS-CSSD-costcenter'");
			string costCenter = string.Empty;
			if (cssdCostCenterConfig != null)
			{
				foreach (DataRow item in cssdCostCenterConfig)
				{
					if (item["key_code"] != null && item["value_code"] != null)
						costCenter += string.Format("'{0}',", item["value_code"].ToString());
				}

				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, costCenter.Trim(','));
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-costcenter-sec004", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-costcenter-sec004", condition);
				if (data != null)
				{
					foreach (DataRow item in data.Rows)
					{
						if (item["bar_code"] != null && item["ca_name"] != null)
							costNameCbx.Items.Add(new KeyValuePair<string, string>(item["bar_code"].ToString(), item["ca_name"].ToString()));
					}
				}
			}

			RefreshSetGrid();
			SetPackageInfo();
		}


		public void RefreshSetGrid()
		{
			SortedList condition = new SortedList();
			condition.Add(1, PdCode);
			condition.Add(2, "0");

			string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", ScanBarCodes);
			setBarCodes = setBarCodes.Replace(",", "','");
			condition.Add(3, setBarCodes);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec003", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec003", condition);

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
				bool isBCCSSet = BarCodeHelper.IsSpecialSet(setBarCodeTxt.Text); ;

				saveBtn.Visible = isBCCSSet ? true : false;
				confirmInNumLbl.Visible = isBCCSSet ? true : false;
				searchPanel.Visible = isBCCSSet ? true : false;
				instrumentSearchGrid.Visible = isBCCSSet ? true : false;
				moveBtnsPanel.Visible = isBCCSSet ? true : false; ;
				searchBtn.Visible = isBCCSSet ? true : false;
				instrumentGrid.Columns["instrumentCostCNameCol"].ReadOnly = isBCCSSet ?  false : true;

				if (isBCCSSet) //订单界面
				{
					if (data["cost_center"] != null && data["cost_center_name"] != null
						&& costNameCbx.Items != null && costNameCbx.Items.Count > 0)
					{
						KeyValuePair<string, string> lastCostCenter = (KeyValuePair<string, string>)costNameCbx.Items[costNameCbx.Items.Count-1];
						if (lastCostCenter.Key != data["cost_center"].ToString())
						{
							costNameCbx.Items.Remove(costNameCbx.Items.Count - 1);
							costNameCbx.Items.Add(new KeyValuePair<string, string>(data["cost_center"].ToString(), data["cost_center_name"].ToString()));
						}
					}
				}

				RefreshInstrumentGrid();

				if (isBCCSSet)
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
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec001", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-instrument-info-sec001", condition);
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
				costCenter = ((KeyValuePair<string, string>)costNameCbx.SelectedItem).Key;
			}

			if (setInfoPanel.Tag != null && setInfoPanel.Tag is DataRow)
			{
				DataRow setData = setDataGrid.SelectedRows[0].Tag as DataRow;
				if (setData["cost_center"] != null)
					costCenter += string.Format("'{0}',", setData["cost_center"].ToString());
			}
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, costCenter.TrimEnd(','));
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-base-sec008", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-instrument-base-sec008", condition);
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
					//if (data["instrument_num"] != null) dataGrid.Rows[rowIndex].Cells["insNumCol"].Value = data["instrument_num"];
					if (rowData["costc_name"] != null) dataGrid.Rows[rowIndex].Cells["inCostCNameCol"].Value = rowData["costc_name"];
					//if (data["ca_price"] != null) dataGrid.Rows[rowIndex].Cells["inPriceCol"].Value = data["ca_price"];
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
			SetPackageInfo();
		}

		public void AddSets()
		{
			HCSWF_set_choose chooseDialog = new HCSWF_set_choose(PdCode);
			chooseDialog.ShowDialog();
			if (chooseDialog.SelectItems != null)
			{
				bool isExist = false;
				setDataGrid.ClearSelection();
				for (int i = 0; i < chooseDialog.SelectItems.Count; i++)
				{
					DataRow item = chooseDialog.SelectItems[i] as DataRow;

					foreach (DataGridViewRow row in setDataGrid.Rows)
					{
						if (row.Cells["setBarCodeCol"] != null && row.Cells["setBarCodeCol"].Value != null &&
							item["bar_code"] != null && row.Cells["setBarCodeCol"].Value.ToString() == item["bar_code"].ToString())
						{
							isExist = true;
							row.Selected = isExist;
							break;
						}
					}
					if (!isExist)
					{
						int rowIndex = setDataGrid.Rows.Add();
						setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value = item["bar_code"];
						if (item["id"] != null) setDataGrid.Rows[rowIndex].Cells["setIdCol"].Value = item["id"];
						if (item["ca_name"] != null) setDataGrid.Rows[rowIndex].Cells["setNameCol"].Value = item["ca_name"];
						if (item["pa_type"] != null) setDataGrid.Rows[rowIndex].Cells["setTypeCol"].Value = item["pa_type"];
						if (item["pa_priorty"] != null) setDataGrid.Rows[rowIndex].Cells["setPriortyCol"].Value = item["pa_priorty"];
						if (item["wa_pr_Name"] != null) setDataGrid.Rows[rowIndex].Cells["washingPCol"].Value = item["wa_pr_Name"];
						if (item["st_pr_Name"] != null) setDataGrid.Rows[rowIndex].Cells["sterilizerPCol"].Value = item["st_pr_Name"];
						if (item["cost_center_name"] != null) setDataGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["cost_center_name"];
						setDataGrid.Rows[rowIndex].Tag = item;
					}
				}
			}
		}

		public void DeleteSelection()
		{
			if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count > 0)
			{
				if (setDataGrid.SelectedRows.Count == setDataGrid.Rows.Count)
				{
					MessageBox.Show("请确保订单中含有器械包", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
					return;
				}

				string warnmingMessage = "请确认是否把一下器械包移出该订单？\r\n";
				foreach (DataGridViewRow item in setDataGrid.SelectedRows)
				{
					if (item.Cells["setNameCol"] != null)
						warnmingMessage += item.Cells["setNameCol"].Value + "\r\n";
				}
				if (MessageBox.Show(warnmingMessage, "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
				{
					for (int i = 0; i < setDataGrid.SelectedRows.Count; i++)
					{
						if (setDataGrid.SelectedRows[i].Cells["setBarCodeCol"] != null)
						{
							string setBarCode = setDataGrid.SelectedRows[i].Cells["setBarCodeCol"].Value.ToString();
							for (int j = 0; j < ScanBarCodes.Count; j++)
							{
								if (setBarCode == ScanBarCodes.GetKey(j).ToString())
								{
									ScanBarCodes.RemoveAt(j);
									j--;
								}
							}
							setDataGrid.Rows.Remove(setDataGrid.SelectedRows[i]);

						}
					}
				}
				setDataGrid.Rows[0].Selected = true;
			}
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			 List<DataRow> inSpecialList = new List<DataRow>();
			foreach (DataGridViewRow item in instrumentGrid.Rows)
			{
				if(item.Tag != null && item.Tag is DataRow)
					inSpecialList.Add(item.Tag as DataRow);
			}
			if (_workSpecialSet.ContainsKey(setBarCodeTxt.Text))
				_workSpecialSet[setBarCodeTxt.Text] = inSpecialList;
			else
				_workSpecialSet.Add(setBarCodeTxt.Text, inSpecialList);
		}

		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = base.SetViewParameters();
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
					workSpecialInfo.Add(5, PdCode);
					workSpecialInfo.Add(6, "1");
					workSpecialInfo.Add(7, "");
					workSetInfos.Add(index, workSpecialInfo);
					index++;
				}
			}

			OutputParameters.Add("workspecialList", workSetInfos);
			return result;
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

	}
}
