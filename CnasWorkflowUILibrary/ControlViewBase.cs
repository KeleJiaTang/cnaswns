using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasWorkflowArithmetic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Cnas.wns.CnasHCSManagerUC;
using log4net;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class ControlViewBase : UserControl
	{
		public bool HasManualHandle = false;
		/// <summary>
		/// 关闭窗口选择 1 是  2否
		/// </summary>
		public int IsCfmCloseDialog = 1;
		/// <summary>
		/// Logger
		/// </summary>
		public ILog Logger = null;
		/// <summary>
		/// 服务端
		/// </summary>
		private CnasRemotCall _remoteClient = null;
		private SortedList _scanBarCodes = new SortedList();
		private string _pdCode = string.Empty;
		private SortedList _viewOutputParameters = new SortedList();
		public bool IsShown = true;
		public SortedList Sl_check = new SortedList();
		public WorkflowArithmeticClass WorkflowServer;
		public UserBase UserInfo = null;
		public string PdCode
		{
			get
			{
				return _pdCode;
			}
			set
			{
				if (value != _pdCode)
					_pdCode = value;
			}
		}

		/// <summary>
		/// 服务端
		/// </summary>
		public CnasRemotCall RemoteClient
		{
			get
			{
				if (_remoteClient == null)
					_remoteClient = new CnasRemotCall();
				return _remoteClient;
			}
		}

		public SortedList ScanBarCodes
		{
			get
			{
				if (_scanBarCodes == null)
					_scanBarCodes = new SortedList();
				return _scanBarCodes;
			}
			set
			{
				if (value != _scanBarCodes)
					_scanBarCodes = value;
			}
		}

		public SortedList OutputParameters
		{
			get
			{
				if (_viewOutputParameters == null)
					_viewOutputParameters = new SortedList();
				return _viewOutputParameters;
			}
			set
			{
				if (value != _viewOutputParameters)
					_viewOutputParameters = value;
			}
		}

		public ControlViewBase()
		{
			InitializeComponent();
		}

		public ControlViewBase(SortedList scanCodes)
			: this()
		{
			if (scanCodes != null)
				_scanBarCodes = scanCodes;
		}

		private void OnControlViewBaseLoad(object sender, EventArgs e)
		{
			InitalizeControl();
		}

		public virtual void InitalizeControl()
		{
			TextBox userNameTxt = CnasUtilityTools.FindControl<TextBox>(this, "userNameTxt");
			if (userNameTxt != null)
			{
				if (UserInfo == null && UserInfo.UserID == 0)
					UserInfo = UserBaseHelper.GetUserByBarCode(BarCodeHelper.GetBarCodeByType("BCB", ScanBarCodes))
						?? CnasBaseData.UserBaseInfo;
				//userBarCodeTxt.Text = UserInfo.Userbcode;
				userNameTxt.Text = UserInfo.UserName;
			}
		}

		public virtual void AppendTempBCCSet()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				string tempBCCs = string.Empty;
				for (int i = 0; i < ScanBarCodes.Count; i++)
				{
					string key = ScanBarCodes.GetKey(i).ToString();
					if (key.Contains(":BCC") || key.StartsWith("BCC"))
					{
						string bccCode = key.Substring(key.IndexOf("BCC"), 13);
						if (BarCodeHelper.IsOrderSet(bccCode) || BarCodeHelper.IsTempSet(bccCode))
						{
							tempBCCs += string.Format("{0},", bccCode);
						}
					}
				}
				if (!string.IsNullOrEmpty(tempBCCs))
				{
					tempBCCs = tempBCCs.TrimEnd(',');
					SortedList condition = new SortedList();
					tempBCCs = tempBCCs.Replace(",", "','");
					condition.Add(1, PdCode);
					condition.Add(2, "0");
					condition.Add(3, tempBCCs);
					string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-workset-tempBCC-sec001", condition);
					DataTable data = RemoteClient.RemotInterface.SelectData("HCS-workset-tempBCC-sec001", condition);
					if (data != null)
					{
						foreach (DataRow item in data.Rows)
						{
							int rowIndex = -1;
							string bccCode = Convert.ToString(item["bar_code"]);
							if (item.Table.Columns.Contains("bar_code") && item["bar_code"] != null)
								rowIndex = DataConverter.ConvertSetData(setDataGrid, item);
							if (BarCodeHelper.IsOrderSet(bccCode) && item.Table.Columns.Contains("order_type") && setDataGrid.Columns.Contains("setTypeCol") && rowIndex >= 0)
								setDataGrid.Rows[rowIndex].Cells["setTypeCol"].Value = item["order_type"];

						}
					}
				}
			}
		}

		public virtual Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			result.Add("ShowParameterUI", "true");
			return result;
		}

		public virtual string ValidateData()
		{
			return string.Empty;
		}

		public virtual string HandleScanBarCode(string barCode)
		{
			HasManualHandle = false;

			if (barCode.StartsWith("BCC") || barCode.StartsWith("BCU"))
			{
				DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid") as DataGridView;
				if (setDataGrid != null && setDataGrid.Rows.Count > 0 && setDataGrid.Columns.Contains("setBarCodeCol"))
				{
					bool isExit = false;
					if (barCode.StartsWith("BCC") || barCode.StartsWith("BCU"))
					{
						string bccCode = barCode;
						string keyCode = barCode;
						if (barCode.StartsWith("BCU"))
						{
							SortedList sttemp01 = new SortedList();
							sttemp01.Add(1, barCode);
							string testBcuSql = RemoteClient.RemotInterface.CheckSelectData("HCS-workset-sec004", sttemp01);
							DataTable dataBcu = RemoteClient.RemotInterface.SelectData("HCS-workset-sec004", sttemp01);
							if (dataBcu == null || (dataBcu != null && dataBcu.Rows.Count == 0))
							{
								return "找不到该标签条码对应的器械包。";
							}
							else
							{
								bccCode = Convert.ToString(dataBcu.Rows[0]["set_code"]);
								keyCode = CnasUtilityTools.ConcatTwoString(barCode, bccCode);
							}
						}
						setDataGrid.ClearSelection();
						for (int i = 0; i < setDataGrid.Rows.Count; i++)
						{
							string tempBar_Code = Convert.ToString(setDataGrid.Rows[i].Cells["setBarCodeCol"].Value);
							if (tempBar_Code.Equals(bccCode))
							{
								setDataGrid.Rows[i].Selected = true;
								isExit = true;
								return "该条码已经存在，帮助你找到";
							}
						}
						if (!isExit)
						{
							SortedList condition = new SortedList();
							condition.Add(1, PdCode);
							condition.Add(2, "0");
							condition.Add(3, bccCode);
							string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec003", condition);
							DataTable dataBcc = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec003", condition);
							if (dataBcc != null && dataBcc.Rows.Count == 1)
							{
								DataConverter.ConvertSetData(setDataGrid, dataBcc.Rows[0]);
								setDataGrid.Rows[setDataGrid.Rows.Count - 1].Selected = true;
								ScanBarCodes.Add(keyCode, keyCode.Substring(0, 3));
								//if (_outputParametersAdd != null && !_outputParametersAdd.ContainsKey(bccCode))
								//{
								//	_outputParametersAdd.Add(bccCode, barCode);
								//}
							}
							else
							{
								return "条码错误，请联系管理员";
							}
						}
					}
					TextBox setNumTxt = CnasUtilityTools.FindControl<TextBox>(this, "setNumTxt");
					if (setNumTxt != null)
						setNumTxt.Text = setDataGrid.RowCount.ToString();
				}
				return PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.error);
			}

			return PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning);
		}

		public virtual void AddSetMessage()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1)
				{
					if (setDataGrid.Columns.Contains("setBarCodeCol"))
					{
						string setBarCode = setDataGrid.SelectedRows[0].Cells["setBarCodeCol"].Value.ToString();
						HCSSM_set_message_new setMessageDialog = new HCSSM_set_message_new(1, PdCode);
						setMessageDialog.PackageBarCode = setBarCode;
						setMessageDialog.ViewData = setMessageDialog.ViewData ?? new SortedList();

						if (setMessageDialog.ViewData.Contains("UserInfo"))
							setMessageDialog.ViewData["UserInfo"] = UserInfo;
						else
							setMessageDialog.ViewData.Add("UserInfo", UserInfo);
						setMessageDialog.Show();
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void AddOrders()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				HCSWF_order_choose orderChoose = new HCSWF_order_choose(PdCode);
				orderChoose.ShowDialog();
				if (orderChoose.SelectItems != null)
				{
					setDataGrid.ClearSelection();
					for (int i = 0; i < orderChoose.SelectItems.Count; i++)
					{
						DataRow item = orderChoose.SelectItems[i] as DataRow;
						bool isExist = false;
						foreach (DataGridViewRow row in setDataGrid.Rows)
						{
							if (row.Cells["setBarCodeCol"].Value != null && item["bar_code"] != null
								&& row.Cells["setBarCodeCol"].Value.ToString() == item["bar_code"].ToString())
							{
								isExist = true;
								row.Selected = isExist;
								break;
							}
						}
						if (!isExist)
						{
							int rowIndex = setDataGrid.Rows.Add();
							if (item.Table.Columns.Contains("id") && setDataGrid.Columns.Contains("setIdCol")) setDataGrid.Rows[rowIndex].Cells["setIdCol"].Value = item["id"];
							if (item.Table.Columns.Contains("bar_code") && setDataGrid.Columns.Contains("setBarCodeCol")) setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value = item["bar_code"];
							if (item.Table.Columns.Contains("ca_name") && setDataGrid.Columns.Contains("setNameCol")) setDataGrid.Rows[rowIndex].Cells["setNameCol"].Value = item["ca_name"];
							if (item.Table.Columns.Contains("order_type") && setDataGrid.Columns.Contains("setTypeCol")) setDataGrid.Rows[rowIndex].Cells["setTypeCol"].Value = item["order_type"];
							if (item.Table.Columns.Contains("pa_priorty") && setDataGrid.Columns.Contains("setPriortyCol")) setDataGrid.Rows[rowIndex].Cells["setPriortyCol"].Value = item["pa_priorty"];
							if (item.Table.Columns.Contains("location_name") && setDataGrid.Columns.Contains("setUseLoCol")) setDataGrid.Rows[rowIndex].Cells["setUseLoCol"].Value = item["location_name"];
							setDataGrid.Rows[rowIndex].Tag = item;
							setDataGrid.Rows[rowIndex].Selected = true;
							string bccCode = setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value.ToString();
							string bcuCode = string.Empty;
							if (item.Table.Columns.Contains("bcuCode") && !(item["bcuCode"] is DBNull))
							{
								bcuCode = item["bcuCode"].ToString();
							}
							string key = string.IsNullOrEmpty(bcuCode) ? bccCode : CnasUtilityTools.ConcatTwoString(bcuCode, bccCode);
							if (!ScanBarCodes.ContainsKey(key))
								ScanBarCodes.Add(key, key.Substring(0, 3));
						}
					}

					TextBox setNumTxt = CnasUtilityTools.FindControl<TextBox>(this, "setNumTxt");
					if (setNumTxt != null)
						setNumTxt.Text = setDataGrid.RowCount.ToString();
				}
			}
		}

		public virtual void AddSets()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				HCSWF_set_choose chooseDialog = new HCSWF_set_choose(PdCode);
				chooseDialog.ShowDialog();
				if (chooseDialog.SelectItems != null)
				{
					setDataGrid.ClearSelection();
					for (int i = 0; i < chooseDialog.SelectItems.Count; i++)
					{
						DataRow item = chooseDialog.SelectItems[i] as DataRow;
						bool isExist = false;

						foreach (DataGridViewRow row in setDataGrid.Rows)
						{
							if (setDataGrid.Columns.Contains("setBarCodeCol") && row.Cells["setBarCodeCol"] != null
								&& row.Cells["setBarCodeCol"].Value != null && item["bar_code"] != null
								&& row.Cells["setBarCodeCol"].Value.ToString() == item["bar_code"].ToString())
							{
								isExist = true;
								row.Selected = isExist;
								break;
							}
						}
						if (!isExist)
						{
							int rowIndex = DataConverter.ConvertSetData(setDataGrid, item);
							setDataGrid.Rows[rowIndex].Selected = true;
							string bccCode = setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value.ToString();
							string bcuCode = string.Empty;
							if (item.Table.Columns.Contains("bcuCode") && !(item["bcuCode"] is DBNull))
							{
								bcuCode = item["bcuCode"].ToString();
							}
							string key = string.IsNullOrEmpty(bcuCode) ? bccCode : CnasUtilityTools.ConcatTwoString(bcuCode, bccCode);
							if (!ScanBarCodes.ContainsKey(key))
								ScanBarCodes.Add(key, key.Substring(0, 3));
						}
					}
					TextBox setNumTxt = CnasUtilityTools.FindControl<TextBox>(this, "setNumTxt");
					if (setNumTxt != null)
						setNumTxt.Text = setDataGrid.RowCount.ToString();
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void DeleteSets()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count > 0)
				{
					if (setDataGrid.SelectedRows.Count == setDataGrid.Rows.Count)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("setgridhasdata", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
						return;
					}

					string warnmingMessage = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmsetremove", EnumPromptMessage.warning);
					List<string> removedBarCode = new List<string>();

					foreach (DataGridViewRow item in setDataGrid.SelectedRows)
					{
						if (setDataGrid.Columns.Contains("setNameCol") && item.Cells["setNameCol"] != null)
							warnmingMessage += string.Format("\r\n名称：  {0}", item.Cells["setNameCol"].Value);
						if (item.Cells["setBarCodeCol"].Value != null)
							removedBarCode.Add(item.Cells["setBarCodeCol"].Value.ToString());
					}
					if (MessageBox.Show(warnmingMessage, "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
					{
						int selectedCount = setDataGrid.SelectedRows.Count;

						foreach (DataGridViewRow item in setDataGrid.SelectedRows)
						{
							string setBarCode = item.Cells["setBarCodeCol"].Value.ToString();
							if (removedBarCode.Contains(setBarCode))
							{
								for (int j = 0; j < ScanBarCodes.Count; j++)
								{
									if (ScanBarCodes.GetKey(j).ToString().Contains(setBarCode))
									{
										ScanBarCodes.RemoveAt(j);
										j--;
									}
								}
								setDataGrid.Rows.Remove(item);
							}
						}
					}
					TextBox setNumTxt = CnasUtilityTools.FindControl<TextBox>(this, "setNumTxt");
					if (setNumTxt != null)
						setNumTxt.Text = setDataGrid.RowCount.ToString();
				}
				else
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void ModifySpecialSetInstruments()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1)
				{
					if (setDataGrid.Columns.Contains("setBarCodeCol"))
					{
						string setBarCode = setDataGrid.SelectedRows[0].Cells["setBarCodeCol"].Value.ToString();
						bool isBCCSSet = BarCodeHelper.IsSpecialSet(setBarCode);
						if (isBCCSSet)
						{
							HCSWF_set_instrument_modify modifyDialog = new HCSWF_set_instrument_modify(setBarCode);
							modifyDialog.ShowDialog();
						}
						else
							MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectspecialset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectspecialset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void AddQuaniltyData()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			SortedList setBarCodes = new SortedList();
			string areaNum = "2";
			Dictionary<string, string> procedureInfo = ProcedureData.Instance.GetProcedureData(PdCode);
			if (procedureInfo != null && procedureInfo.Count > 0)
			{
				if (procedureInfo.ContainsKey("pd_Type"))
				{
					areaNum = procedureInfo["pd_Type"];
				}
			}
			try
			{
				if (setDataGrid != null && setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count > 0 && setDataGrid.SelectedRows[0].Tag is DataRow)
				{
					TextBox machinTxt = CnasUtilityTools.FindControl<TextBox>(this, "machineTxt");

					DataRow rowData = setDataGrid.SelectedRows[0].Tag as DataRow;

					Dictionary<string, string> data = new Dictionary<string, string>();
					data.Add("SetName", rowData.Table.Columns.Contains("ca_name") ? Convert.ToString(rowData["ca_name"]) : string.Empty);
					data.Add("SetCode", rowData.Table.Columns.Contains("bar_code") ? Convert.ToString(rowData["bar_code"]) : string.Empty);
					data.Add("SetId", rowData.Table.Columns.Contains("id") ? Convert.ToString(rowData["id"]) : string.Empty);
					data.Add("DevId", machinTxt != null ? Convert.ToString(machinTxt.Tag) : string.Empty);
					data.Add("DevName", machinTxt != null ? machinTxt.Text : string.Empty);
					HCSSM_statistics_quality_new qualityDialog = new HCSSM_statistics_quality_new();
					qualityDialog.Area = areaNum;
					if (WorkflowServer.Unload_container_wf.Contains(string.Format("{0},", PdCode)))
					{
						qualityDialog.ErrorType = WorkflowServer.Release_sterilizer_wf.Contains(string.Format("{0},", PdCode)) ? 2 : 1;
					}

					qualityDialog.Data = data;
					qualityDialog.ShowDialog();
				}

			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// 查看包的详情
		/// </summary>
		public virtual void ShowSetPackDetail()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1)
				{
					if (setDataGrid.Columns.Contains("setBarCodeCol") &&
						setDataGrid.SelectedRows[0].Cells["setBarCodeCol"] != null)
					{
						string code = setDataGrid.SelectedRows[0].Cells["setBarCodeCol"].Value.ToString();
						if (code.Length > 3)
						{
							SortedList condition = new SortedList();
							condition.Add(BarCodeHelper.GetBarCodeByType("BCV", ScanBarCodes), "BCV");
							condition.Add(code, code.Substring(0, 3));
							HCSWF_set_detail detail = new HCSWF_set_detail(condition);
							detail.ShowDialog();
						}
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void ReleaseSpecialSet()
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(this, "setDataGrid");
			if (setDataGrid != null)
			{
				if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1)
				{
					if (setDataGrid.SelectedRows[0].Tag is DataRow)
					{
						DataRow rowData = setDataGrid.SelectedRows[0].Tag as DataRow;
						string setBarCode = rowData["bar_code"].ToString();
						bool isBCCSSet = BarCodeHelper.IsSpecialSet(setBarCode);
						if (isBCCSSet)
						{
							string message = PromptMessageXmlHelper.Instance.GetPromptMessage("recyleset", EnumPromptMessage.warning, new string[] { setBarCode, rowData["ca_name"].ToString() });
							SortedList condition = new SortedList();
							condition.Add(1, CnasBaseData.SystemID);
							condition.Add(2, setBarCode);
							string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec002", condition);
							DataTable data = RemoteClient.RemotInterface.SelectData("HCS-instrument-info-sec002", condition);
							SortedList deleteData = new SortedList();
							SortedList sqlParam = new SortedList();
							SortedList input = new SortedList();
							SortedList input01 = new SortedList();
							input.Add(1, input01);
							sqlParam.Add(1, input);
							sqlParam.Add(2, deleteData);
							input01.Add(1, rowData["id"]);
							input01.Add(2, rowData["id"]);
							input01.Add(3, PdCode);
							if (data != null && data.Rows.Count > 0)
							{
								int index = 1;
								foreach (DataRow item in data.Rows)
								{
									SortedList deleteItem = new SortedList();
									deleteData.Add(index, deleteItem);
									index++;
									if (item["ca_name"] != null && item["instrument_num"] != null)
									{
										message += string.Format("\r\n\t\t器械名称: {0},\t器械数量：{1}.", item["ca_name"].ToString(), item["instrument_num"].ToString());
									}
									deleteItem.Add(1, rowData["ws_id"] != null ? rowData["ws_id"].ToString() : "");
									deleteItem.Add(2, "9");
									deleteItem.Add(3, item["wsin_id"]);
								}
							}

							if (MessageBox.Show(message, "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
							{
								string testDeleteSql = RemoteClient.RemotInterface.CheckUPDataList("HCS-work-specialset-info-up002", sqlParam);
								int result = RemoteClient.RemotInterface.UPDataList("HCS-work-specialset-info-up002", sqlParam);
								if (result <= -1)
								{

									MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("failRecycleset", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
								else
								{
									InitalizeControl();
									if (setDataGrid.RowCount == 0)
									{
										if (setDataGrid.RowCount == 0)
										{
											if (this.ParentForm is HCSWF_dialog_container)
												(ParentForm as HCSWF_dialog_container).DialogResultStatus = 3;
											ParentForm.Close();
										}
									}
								}
							}
						}
						else
							MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectspecialset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void PrintContent()
		{
			DataGridView dataGrid = CnasUtilityTools.FindControl<DataGridView>(this);
			if (dataGrid != null)
			{
				DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and value_code like '%{0},%'", PdCode));
				data = data != null && data.Length > 0 ? data : CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and key_code = 'defaultTemplate'"));
				if (data != null && data.Length > 0)
				{
					string pringxml = data[0]["other_code"].ToString().Trim();
					PrintHelper.Instance.Print_DataGridView(dataGrid, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
