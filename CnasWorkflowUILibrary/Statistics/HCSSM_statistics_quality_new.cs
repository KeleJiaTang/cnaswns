using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Controls;
using System.Collections;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_statistics_quality_new : MetroForm
	{
		private int _errorType = 0;

		public Dictionary<string, string> Data { get; set; }
		public string Area { get; set; }

		public int ErrorType
		{
			get
			{
				return _errorType;
			}
			set
			{
				if (value != _errorType)
					_errorType = value;
			}
		}

		public UserBase User { get; set; }

		public HCSSM_statistics_quality_new()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			InitializeButtonImage();
		}

		public void InitializeButtonImage()
		{
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);


			btnMoveIRight.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRight32", EnumImageType.PNG);
			btnMoveILeft.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mLeft32", EnumImageType.PNG);
		}

		public Dictionary<string, string> InitializeReason(string problemType)
		{
			Dictionary<string, string> reasonSource = new Dictionary<string, string>();

			DataRow[] reasons = CnasBaseData.SystemBaseData.Select("type_code = 'HCS-quality-detection-type'");
			DataRow[] areaReasons = CnasBaseData.SystemBaseData.Select(string.Format("type_code = 'HCS-qualitydetection-area' and key_code = '{0}'", Area));
			if (areaReasons.Length > 0 && reasons.Length > 0)
			{
				string areaReasonData = areaReasons[0]["value_code"].ToString();
				foreach (DataRow row in reasons)
				{
					string key = row["key_code"].ToString();
					if (!string.IsNullOrEmpty(key) && areaReasonData.Contains(string.Format("{0},", key)) 
						&& key.StartsWith(problemType) && !reasonSource.ContainsKey(key))
					{
						string value = row["value_code"].ToString();
						reasonSource.Add(key, value);
					}
				}
			}

			return reasonSource;
		}

		private void InitializeTypeCbx()
		{
			try
			{
				DataRow[] types = CnasBaseData.SystemBaseData.Select("type_code = 'HCS-detection-type'");
				DataRow[] areaReasons = CnasBaseData.SystemBaseData.Select(string.Format("type_code = 'HCS-qualitydetection-area' and key_code = '{0}'", Area));
				List<string> areaReasonList = new List<string>();
				if (areaReasons.Length > 0)
				{
					string areaReasonData = areaReasons[0]["value_code"].ToString();
					areaReasonList = areaReasonData.Split(',').ToList();
				}
				if (types.Length > 0)
				{
					foreach (DataRow row in types)
					{
						string key = row["key_code"].ToString();
						string value = row["value_code"].ToString();
						KeyValuePair<string, string> item = new KeyValuePair<string, string>(key, value);
						string reason = areaReasonList.Find(p => p.StartsWith(key));
						if (!string.IsNullOrEmpty(reason) &&
							(key == "1" || key=="2" || (key == "3" && ErrorType == 1) || (key == "4" && ErrorType == 2)))
							typeCbx.Items.Add(item);
					}
					typeCbx.SelectedIndex = 0;
				}
			}
			catch (Exception)
			{
			}
		}

		private void InitializeAreaCbx()
		{
			try
			{
				DataRow[] types = CnasBaseData.SystemBaseData.Select("type_code = 'HCS_workapace_type'");
				if (types.Length > 0)
				{
					int index = 0;
					foreach (DataRow row in types)
					{
						string key = row["key_code"].ToString();
						string value = row["value_code"].ToString();
						KeyValuePair<string, string> item = new KeyValuePair<string, string>(key, value);
						areaCbx.Items.Add(item);
						if (Area == key)
							areaCbx.SelectedIndex = index;

						index++;
					}
				}
				if (!string.IsNullOrEmpty(Area))
					areaCbx.Enabled = false;
			}
			catch (Exception)
			{
			}
		}

		private void OnAreaTypeSelectionChanged(object sender, EventArgs e)
		{
			MetroComboBox areaType = sender as MetroComboBox;
			if (areaType != null && areaType.SelectedItem != null && areaType.SelectedItem is KeyValuePair<string, string>)
			{
				Area = ((KeyValuePair<string, string>)areaType.SelectedItem).Key;
			}
		}

		private void OnTypeSelectionChanged(object sender, EventArgs e)
		{
			MetroComboBox typeBox = sender as MetroComboBox;
			SetReasonModel(typeBox);
		}

		private void SetReasonModel(MetroComboBox typeBox)
		{
			if (typeBox != null && typeBox.SelectedItem != null && typeBox.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selectionItem = ((KeyValuePair<string, string>)typeBox.SelectedItem);
				bool isInstrumentMode = selectionItem.Key == "1";
				instrumentPanel.Visible = isInstrumentMode;
				instrumentGbx.Visible = isInstrumentMode;
				remarkTxt.Visible = !isInstrumentMode;
				remarkLbl.Visible = !isInstrumentMode;
				reasonCbx.Visible = !isInstrumentMode;
				reasonLbl.Visible = !isInstrumentMode;
				//countTxt.Visible = !isInstrumentMode;
				//countLbl.Visible = !isInstrumentMode;
				nameLbl.Visible = !isInstrumentMode;
				nameTxt.Visible = !isInstrumentMode;

				if (selectionItem.Key == "2")
				{
					//useLocationPanel.Visible = true;
					nameLbl.Text = "器  械  包";
					if (Data != null)
					{
						if (Data.ContainsKey("SetName"))
							nameTxt.Text = Data["SetName"];
						//if (Data.ContainsKey("UseLocation"))
							//nameTxt.Text = Data["UseLocation"];
					}
				}
				else
				{
					if (selectionItem.Key == "3")
					{
						nameLbl.Text = "清  洗  机";
						if (Data != null && Data.ContainsKey("DevName"))
							nameTxt.Text = Data["DevName"];
					}
					else
					{
						nameLbl.Text = "灭  菌  器";
						if (Data != null && Data.ContainsKey("DevName"))
							nameTxt.Text = Data["DevName"];
					}
					
				}

				Dictionary<string, string> items = InitializeReason(selectionItem.Key);
				if (isInstrumentMode)
				{
					//BindingSource bs = new BindingSource();
					//bs.DataSource = ;
					DataGridViewComboBoxColumn cmbox = instrumentGrid.Columns["inReasonCol"] as DataGridViewComboBoxColumn;
					if (cmbox != null)
					{
						cmbox.Items.Clear();
						foreach (var item in items)
						{
							cmbox.Items.Add(item);
						}
						
						cmbox.DisplayMember = "Value";
						cmbox.ValueMember = "Key";
					}
					RefreshInstrumentSearchGrid();
				}
				else
				{
					ResizeRemarkTxt();

					reasonCbx.Items.Clear();
					foreach (var item in items)
					{
						reasonCbx.Items.Add(item);
					}
					reasonCbx.DisplayMember = "Value";
					reasonCbx.ValueMember = "Key";
					if (reasonCbx.Items.Count > 0)
					reasonCbx.SelectedIndex = 0;
				}
			}
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{
			InitializeAreaCbx();
			InitializeTypeCbx();
			SetReasonModel(typeCbx);
		}

		public void RefreshInstrumentSearchGrid()
		{
			try
			{
				CnasRemotCall remoteClient = new CnasRemotCall();
				DataTable instrumentData = null;
				if (Data.ContainsKey("SetCode") && !BarCodeHelper.IsTempSet(Data["SetCode"]))
				{
					string setCode = Data["SetCode"];
					if (!string.IsNullOrEmpty(setCode))
					{
						bool isBCCS = BarCodeHelper.IsSpecialSet(setCode);
						string sql = "HCS-instrument-info-sec007";
						SortedList condition = new SortedList();
						condition.Add(1, CnasBaseData.SystemID);//CnasBaseData.SystemID
						condition.Add(2, setCode);
						if (BarCodeHelper.IsSpecialSet(setCode))
						{
							sql = "HCS-instrument-info-sec002";
						}
						else if (BarCodeHelper.IsOrderSet(setCode))
						{
							sql = "HCS-instrument-info-sec008";
						}

						string testSql = remoteClient.RemotInterface.CheckSelectData(sql, condition);
						instrumentData = remoteClient.RemotInterface.SelectData(sql, condition);
					}
				}
				else
				{
					SortedList condition = new SortedList();
					condition.Add(1, CnasBaseData.UserBaseInfo.LocationId);
					condition.Add(2, CnasBaseData.SystemID);
					string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec006", condition);
					instrumentData = remoteClient.RemotInterface.SelectData("HCS-instrument-info-sec006", condition);
				}

				if (instrumentData != null)
				{
					DataRow[] data = instrumentData.Select(string.Format("ca_name like '%{0}%'", instrumentNameTxt.Text));
					if (data.Length > 0)
					{
						inSearchGrid.Rows.Clear();
						foreach (DataRow row in data)
						{
							int rowIndex = inSearchGrid.Rows.Add();
							if (row["id"] != null) inSearchGrid.Rows[rowIndex].Cells["idCol"].Value = Convert.ToString(row["id"]);
							if (row["ca_name"] != null) inSearchGrid.Rows[rowIndex].Cells["nameCol"].Value = Convert.ToString(row["ca_name"]);
							//if (row["costc_name"] != null) inSearchGrid.Rows[rowIndex].Cells["costCenterCol"].Value = Convert.ToString(row["costc_name"]);
						}
					}
				}
			}
			catch (Exception)
			{
			}

		}

		private void btnMoveIRight_Click(object sender, EventArgs e)
		{
			try
			{
				if (inSearchGrid.SelectedRows.Count == 1)
				{
					DataGridViewRow row = null;
					DataGridViewComboBoxColumn cmbox = instrumentGrid.Columns["inReasonCol"] as DataGridViewComboBoxColumn;
					string instrumentId = inSearchGrid.SelectedRows[0].Cells["idCol"].Value.ToString();
					if (cmbox.Items != null && cmbox.Items[0] is KeyValuePair<string, string>)
					{
						KeyValuePair<string, string> cmboxDefaultItem = (KeyValuePair<string, string>)cmbox.Items[0];
						foreach (DataGridViewRow item in instrumentGrid.Rows)
						{
							if (instrumentId == item.Cells["inIdCol"].Value.ToString() && item.Cells["inReasonCol"].Value.Equals(cmboxDefaultItem.Key))
							{
								row = item;
								break;
							}
						}
					}

					if (row == null)
					{
						int rowIndex = instrumentGrid.Rows.Add();
						row = instrumentGrid.Rows[rowIndex];
						row.Cells["inIdCol"].Value = inSearchGrid.SelectedRows[0].Cells["idCol"].Value;
						row.Cells["inNameCol"].Value = inSearchGrid.SelectedRows[0].Cells["nameCol"].Value;
						row.Cells["inCostCenterCol"].Value = inSearchGrid.SelectedRows[0].Cells["costCenterCol"].Value;
						instrumentGrid.ClearSelection();
						row.Selected = true;
						row.Cells["inCountCol"].Value = "1";
						row.Cells["inRemarkCol"].Value = string.Empty;
						
						if (cmbox.Items != null && cmbox.Items[0] is KeyValuePair<string, string>)
						{
							KeyValuePair<string, string> item = (KeyValuePair<string, string>)cmbox.Items[0];
							row.Cells["inReasonCol"].Value = item.Key;
						}
					}
					else
					{
						DataGridViewRow countedRow = null;
						if (!row.Selected)
						{
							if (instrumentGrid.SelectedRows.Count > 0 && instrumentGrid.SelectedRows[0].Cells["inIdCol"].Value.Equals(instrumentId))
							{
								countedRow = instrumentGrid.SelectedRows[0];
							}
						}
						else
						{
							countedRow = row;
						}
						if (countedRow != null)
						{
							int count = 0;
							if (countedRow.Cells["inCountCol"].Value != null)
								int.TryParse(countedRow.Cells["inCountCol"].Value.ToString(), out count);
							countedRow.Cells["inCountCol"].Value = count + 1;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void btnMoveILeft_Click(object sender, EventArgs e)
		{
			try
			{
				if (instrumentGrid.SelectedRows.Count == 1)
				{
					int count = 0;
					if (instrumentGrid.SelectedRows[0].Cells["inCountCol"].Value != null)
						int.TryParse(instrumentGrid.SelectedRows[0].Cells["inCountCol"].Value.ToString(), out count);
					if (count <= 1)
						instrumentGrid.Rows.Remove(instrumentGrid.SelectedRows[0]);
					else
					{
						instrumentGrid.SelectedRows[0].Cells["inCountCol"].Value = count - 1;
					}
				}
			}
			catch (Exception)
			{
			}

		}

		private void confirmBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (typeCbx.SelectedItem != null && typeCbx.SelectedItem is KeyValuePair<string, string>)
				{
					KeyValuePair<string, string> typeSelected = (KeyValuePair<string, string>)typeCbx.SelectedItem;
					SortedList sqlParameter = new SortedList();
					if (typeSelected.Key.Equals("1"))
					{
						if (instrumentGrid.Rows.Count > 0)
						{
							foreach (DataGridViewRow item in instrumentGrid.Rows)
							{
								SortedList parameters = new SortedList();
								int count = 0;
								bool isNum = int.TryParse(Convert.ToString(item.Cells["inCountCol"].Value), out count);
								parameters.Add(1, item.Cells["inReasonCol"].Value);
								parameters.Add(2, count);
								parameters.Add(3, item.Cells["inIdCol"].Value);
								parameters.Add(4, typeSelected.Key);
								parameters.Add(5, Area);
								parameters.Add(6, item.Cells["inRemarkCol"].Value);
								sqlParameter.Add(sqlParameter.Count + 1, parameters);
								if (!isNum)
								{
									MessageBox.Show("数量：请填写数字");
									return;
								}
							}
						}
					}
					else
					{
						SortedList parameters = new SortedList();
						parameters.Add(1, ((KeyValuePair<string, string>)reasonCbx.SelectedItem).Key);
						parameters.Add(2, 1);
						if (typeSelected.Key.Equals("2"))
						{
							parameters.Add(3, Data.ContainsKey("SetId") ? Data["SetId"] : "0");
						}
						else
						{
							parameters.Add(3, Data.ContainsKey("DevId") ? Data["DevId"] : "0");
						}
						parameters.Add(4, typeSelected.Key);
						parameters.Add(5, Area);
						parameters.Add(6, remarkTxt.Text);
						sqlParameter.Add(sqlParameter.Count + 1, parameters);
					}
					if (sqlParameter.Count > 0)
					{
						CnasRemotCall remoteCall = new CnasRemotCall();
						string testSQl = remoteCall.RemotInterface.CheckUPDataList("HCS-qualitydetection-area-add001", sqlParameter);
						int updateCount = remoteCall.RemotInterface.UPDataList("HCS-qualitydetection-area-add001", sqlParameter);
						if (updateCount > 0)
							this.Close();
					}
				}
			}
			catch (Exception)
			{
			}

		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			RefreshInstrumentSearchGrid();
		}

		private void OnKeyPressEvent(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void OnFormSizeChanged(object sender, EventArgs e)
		{
			ResizeRemarkTxt();

		}

		private void ResizeRemarkTxt()
		{
			if (remarkTxt.Visible)
			{
				remarkTxt.Width = lastRowPanel.Width - remarkLbl.Size.Width - remarkLbl.Margin.Left - remarkLbl.Margin.Right - remarkTxt.Margin.Left - remarkTxt.Margin.Right;
			}
		}

	}
}
