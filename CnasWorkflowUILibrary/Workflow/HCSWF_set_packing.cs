using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasHCSManagerUC;
using System.Configuration;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasWorkflowArithmetic;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_set_packing : ControlViewBase
	{
		private int _packingSetBaseId = 0;
		private UserBase _confirmUser = null;
		private bool _isPrintedBCU = false;
		private string _bcuCode = string.Empty;
		private string _setId = string.Empty;
		private string _defaluePackInstrumentType = string.Empty;
		private DateTime _createDate = DateTime.Now;
		private int _expirationTime = 7;
		private bool _isNeedCheckAll = true;
		public HCSWF_set_packing()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			//base.InitalizeControl();
			DataRow[] data = CnasBaseData.SystemBaseData.Select("key_code='CheckedSetInstrument' and type_code='HCS-system-settings'");
			if (data.Length > 0)
			{
				_isNeedCheckAll = data[0]["value_code"].ToString().Equals("1");
			}
			instrumentGrid.Columns["isPackagedCol"].Visible = _isNeedCheckAll;
			if (!_isNeedCheckAll)
			{
				txtConfirmName.Focus();
				//txtConfirmCode.Focus();
			}

			DataRow[] defaultType = CnasBaseData.SystemBaseData.Select("key_code ='DefaultPackInstrmentType' and type_Code ='HCS-system-settings'");
			if (defaultType.Length > 0 && defaultType[0]["value_code"] != null)
				_defaluePackInstrumentType = defaultType[0]["value_code"].ToString();
			string bcbCodes = BarCodeHelper.GetBarCodeByType("BCB", ScanBarCodes);
			string[] bcbCodeItems = bcbCodes.Split(',');
			if (bcbCodeItems.Length > 0)
			{
				UserInfo = UserBaseHelper.GetUserByBarCode(bcbCodeItems[0])
					?? CnasBaseData.UserBaseInfo;
				//userBarCodeTxt.Text = UserInfo.Userbcode;
				userNameTxt.Text = UserInfo.UserName;
				if (bcbCodeItems.Length > 1)
				{
					_confirmUser = UserBaseHelper.GetUserByBarCode(bcbCodeItems[1]);
					if (_confirmUser != null)
					{
						//userBarCodeTxt.Text = UserInfo.Userbcode;
						userNameTxt.Text = UserInfo.UserName;
					}
				}
			}

			InitalizeSetInfo();
			RefreshDataGrid();
		}

		private DateTime _firstTime = DateTime.Now;
		private bool _canKeyDown = false;

		public override string HandleScanBarCode(string barCode)
		{
			string result = string.Empty;
			if (barCode.StartsWith("BCB"))
			{
				UserBase user = UserBaseHelper.GetUserByBarCode(barCode);
				if (user != null && user.UserID > 0)
				{
					_confirmUser = user;
					txtConfirmName.Text = _confirmUser.UserName;
					txtConfirmName.Tag = user.UserID;

					//HasManualHandle = false;
					_createDate = DateTime.Now;
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
				}
				else
				{
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning);
				}
			}
			else if (barCode.StartsWith("BCC"))
			{
				if (ScanBarCodes.ContainsValue("BCC"))
				{
					result = "已存在要打包的器械包";
				}
				
			}
			if (txtConfirmName.Focused)
			{
				txtConfirmName.Text = _confirmUser != null ? _confirmUser.UserName : string.Empty;
			}
			return result;
		}

		private void OnCfmUserKeyDown(object sender, KeyEventArgs e)
		{
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			TextBox textBox = sender as TextBox;
			if (e.KeyData == Keys.Enter && _canKeyDown)
			{
				if (textBox != null)
				{
					Label messageLbl = CnasUtilityTools.FindControl<Label>(this.ParentForm, "resultLbl");
					UserBase user = null;
					if (textBox.Text.StartsWith("BCB") || string.IsNullOrEmpty(textBox.Text))
						return;
					else
						user = UserBaseHelper.UserInfoByUserName(textBox.Text);
					if (user != null && user.UserID > 0)
					{
						if (messageLbl != null)
							messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning);
						//MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning),
						//"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						_confirmUser = user;
						textBox.Text = user.UserName;
						textBox.Tag = user.UserID;
						if (messageLbl != null)
							messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
					}
				}
			}

			_firstTime = DateTime.Now;

			if (ts.Milliseconds < 20)
			{
				_canKeyDown = false;
			}
			else
			{
				_canKeyDown = true;
			}

			if (txtConfirmName.Focused)
			{
				txtConfirmName.Text = _confirmUser != null ? _confirmUser.UserName : string.Empty;
			}
		}

		private void RefreshDataGrid()
		{
			bool isBCCS = BarCodeHelper.IsSpecialSet(Convert.ToString(setNameTxt.Tag));
			string sql =isBCCS ?"HCS-instrument-info-sec002" : "HCS-instrument-info-sec001";
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, isBCCS ? Convert.ToString(setNameTxt.Tag) : _packingSetBaseId.ToString());
			string testSql = RemoteClient.RemotInterface.CheckSelectData(sql, condition);
			DataTable data = RemoteClient.RemotInterface.SelectData(sql, condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					int rowIndex = instrumentGrid.Rows.Add();
					if (item["id"] != null) instrumentGrid.Rows[rowIndex].Cells["idCol"].Value = item["id"];
					if (item["ca_name"] != null) instrumentGrid.Rows[rowIndex].Cells["inNameCol"].Value = item["ca_name"];
					if (item["instrument_type"] != null) instrumentGrid.Rows[rowIndex].Cells["inTypeCol"].Value = item["instrument_type"];
					if (item["instrument_num"] != null) instrumentGrid.Rows[rowIndex].Cells["inNumCol"].Value = item["instrument_num"];
					if (item["costc_name"] != null) instrumentGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["costc_name"];
					if (item["ca_price"] != null) instrumentGrid.Rows[rowIndex].Cells["inPriceCol"].Value = item["ca_price"];

					instrumentGrid.Rows[rowIndex].Cells["isPackagedCol"].Value = (item["ca_type"] != null 
						&& _defaluePackInstrumentType.Contains(item["ca_type"].ToString()))? true : false;
				}
				if (_isNeedCheckAll)
				{
					instrumentGrid.ClearSelection();
					instrumentGrid.Rows[0].Selected = true;
					instrumentGrid.Rows[0 + 1].Cells["isPackagedCol"].Selected = true;
					if (instrumentGrid.Columns["isPackagedCol"].Visible)
						instrumentGrid.CurrentCell = instrumentGrid.Rows[0].Cells["isPackagedCol"];
					instrumentGrid.Focus();
					instrumentGrid.BeginEdit(false);
				}
			}
		}

		private void InitalizeSetInfo()
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
				for (int i = 0; i < data.Rows.Count; i++)
				{
					if (data.Rows[i]["bar_code"] != null)
					{
						
						if (data.Rows[i]["ca_name"] != null) setNameTxt.Text = Convert.ToString(data.Rows[i]["ca_name"]);
						setNameTxt.Tag = data.Rows[i]["bar_code"];
						//if (data.Rows[i]["pa_type"] != null) setTypeTxt.Text = data.Rows[i]["pa_type"].ToString();
						//if (data.Rows[i]["pa_priorty"] != null) setPriortyTxt.Text = data.Rows[i]["pa_priorty"].ToString();
						//if (data.Rows[i]["st_pr_Name"] != null) setSterilizerTxt.Text = data.Rows[i]["st_pr_Name"].ToString();
						//if (data.Rows[i]["wa_pr_Name"] != null) setWashingTxt.Text = data.Rows[i]["wa_pr_Name"].ToString();
						if (data.Rows[i]["location_name"] != null) useLocationTxt.Text = data.Rows[i]["location_name"].ToString();
						if (data.Rows[i]["base_set_id"] != null) int.TryParse(data.Rows[i]["base_set_id"].ToString(), out _packingSetBaseId);
						if (data.Rows[i]["id"] != null) _setId = Convert.ToString(data.Rows[i]["id"]);
						if (data.Rows[i]["expiration_time"] != null)
							int.TryParse(data.Rows[i]["expiration_time"].ToString(), out _expirationTime); 
						break;
					}
				}
			}

			useLocationLbl.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			//setBarCodeTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			setLbl.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			setNameTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			//setTypeTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			//setPriortyTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			//setSterilizerTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			//setWashingTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
			useLocationTxt.Visible = string.IsNullOrEmpty(setBarCodes) ? false : true;
		}

		public override string ValidateData()
		{
			IsCfmCloseDialog = 1;
			if (_confirmUser == null)
			{
				IsCfmCloseDialog = 2;
				return PromptMessageXmlHelper.Instance.GetPromptMessage("fillcfmUser", EnumPromptMessage.warning);
			}
			if (_isNeedCheckAll)
			{
				int checkCount = 0;
				string unCheckInstrument = "请打包一下器械： \r\n";
				foreach (DataGridViewRow item in instrumentGrid.Rows)
				{
					if (item.Cells["isPackagedCol"] != null && item.Cells["isPackagedCol"].EditedFormattedValue.ToString().Equals("True"))
					{
						checkCount++;
					}
					else
					{
						if (item.Cells["inNameCol"] != null && item.Cells["inNameCol"].Value != null)
						{
							unCheckInstrument += string.Format("\t{0}\t\r\n", item.Cells["inNameCol"].Value);
						}
					}
				}
				if (checkCount == instrumentGrid.RowCount)
					return string.Empty;
				else
				{
					IsCfmCloseDialog = 2;
					return unCheckInstrument;
				}
			}
			else
				return string.Empty;
		}

		public void ShowSetPackingImages()
		{
			SortedList sortedList = new SortedList();

			//设置一个类型，表明这次上传图片的类型是：包
			sortedList.Add("type", "1");
			sortedList.Add("pack_id", _packingSetBaseId.ToString());

			//HCSCM_set_manage_image HCSCM_set_manage_image = new HCSCM_set_manage_image(sortedList);
			//获取一个值，指是否在Windows任务栏中显示窗体。
			//HCSCM_set_manage_image.ShowInTaskbar = false;
			//HCSCM_set_manage_image.ShowDialog();
		}

		public void PrintBCUCode()
		{
			if (WorkflowServer != null)
			{
				SortedList parameters = new SortedList();
				if (string.IsNullOrEmpty(_bcuCode))
				{
					_bcuCode = WorkflowServer.Get_BCU_Code(PdCode, Convert.ToString(setNameTxt.Tag));
				}
				DateTime createDate = DateTime.Now;

				parameters.Add("BarcodeValue", _bcuCode);
				parameters.Add("P014", _bcuCode);
				parameters.Add("P017", _createDate.ToString("yyyy-MM-dd"));
				parameters.Add("P018", _createDate.AddDays(_expirationTime).ToString("yyyy-MM-dd"));
				parameters.Add("P019", userNameTxt.Text.Trim());
				parameters.Add("P020", txtConfirmName.Text.Trim());
				parameters.Add("P013", Convert.ToString(setNameTxt.Text));
				parameters.Add("P016", Convert.ToString(useLocationTxt.Text));
				string printResult = BarCodeHelper.PrintBarCode(_bcuCode, parameters);
				if (!string.IsNullOrEmpty(printResult))
					MessageBox.Show(printResult, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
					_isPrintedBCU = true;

				string key = CnasUtilityTools.ConcatTwoString(_bcuCode, Convert.ToString(setNameTxt.Tag));
				if (ScanBarCodes.ContainsKey(Convert.ToString(setNameTxt.Tag)))
					ScanBarCodes.Remove(Convert.ToString(setNameTxt.Tag));
				if (!ScanBarCodes.ContainsKey(key))
					ScanBarCodes.Add(key, "BCU");
			}
		}

		/// <summary>
		/// 设置回传参数
		/// </summary>
		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = base.SetViewParameters();

			OutputParameters = OutputParameters ?? new SortedList();
			if(_confirmUser!=null)
			{
					SortedList confirmUserParams = new SortedList();
					//是否需要确认包的人编码和信息
					confirmUserParams.Add("confirmUserId", _confirmUser.UserID);
					if (OutputParameters.ContainsKey("confirmUserParams"))
					{
						OutputParameters["confirmUserParams"] = confirmUserParams;
					}
					else
					{
						OutputParameters.Add("confirmUserParams", confirmUserParams);
					}

			}
			if (!_isPrintedBCU)
				PrintBCUCode();

			return result;
		}

		/// <summary>
		/// 查看包的闲情
		/// </summary>
		public override void ShowSetPackDetail()
		{
			string code = Convert.ToString(setNameTxt.Tag);
			if (code.Length > 3)
			{
				SortedList condition = new SortedList();
				condition.Add(BarCodeHelper.GetBarCodeByType("BCV", ScanBarCodes), "BCV");
				condition.Add(code, code.Substring(0, 3));
				HCSWF_set_detail detail = new HCSWF_set_detail(condition);
				detail.ShowDialog();
			}
		}

		/// <summary>
		/// 添加不合格信息
		/// </summary>
		public override void AddQuaniltyData()
		{
			string code = Convert.ToString(setNameTxt.Tag);
			if (code.Length > 3)
			{
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
				setBarCodes.Add(1, code);
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("SetName", setNameTxt.Text);
				data.Add("SetCode", Convert.ToString(setNameTxt.Tag));
				data.Add("SetId", _setId);
				HCSSM_statistics_quality_new qualityDialog = new HCSSM_statistics_quality_new();
				qualityDialog.Area = areaNum;
				qualityDialog.ErrorType = 0;
				qualityDialog.Data = data;
				//qualityDialog.BarCodeList = setBarCodes;
				qualityDialog.ShowDialog();
			}
		}

		/// <summary>
		/// 添加包的信息
		/// </summary>
		public override void AddSetMessage()
		{
			string code = Convert.ToString(setNameTxt.Tag);
			if (code.Length > 3)
			{
				HCSSM_set_message_new setMessageDialog = new HCSSM_set_message_new(1, PdCode);
				setMessageDialog.PackageBarCode = code;
				setMessageDialog.ViewData = setMessageDialog.ViewData ?? new SortedList();
				if (setMessageDialog.ViewData.Contains("UserInfo"))
					setMessageDialog.ViewData["UserInfo"] = UserInfo;
				else
					setMessageDialog.ViewData.Add("UserInfo", UserInfo);
				setMessageDialog.Show();
			}
		}

		private void OnIntrumentGridKeyDown(object sender, KeyEventArgs e)
		{
			if (_isNeedCheckAll && instrumentGrid.CurrentRow != null &&(e.KeyData == Keys.Space || e.KeyData == Keys.Enter))
			{
				//bool isChecked = bool.Parse(selectedRow.Cells["isPackagedCol"].Value.ToString());
				//selectedRow.Cells["isPackagedCol"].Value = true;
				int index = instrumentGrid.Rows.IndexOf(instrumentGrid.CurrentRow);
				instrumentGrid.CurrentRow.Cells["isPackagedCol"].Value = true;
				//if (!isChecked)
				//{
			
					if (index + 1 < instrumentGrid.Rows.Count)
					{
					//	instrumentGrid.Rows[0].Selected = true;
					//	instrumentGrid.Rows[0].Cells["isPackagedCol"].Selected = true;
					//	instrumentGrid.CurrentCell = instrumentGrid.Rows[0].Cells["isPackagedCol"];
					//}
					//else
					//{
						instrumentGrid.ClearSelection();
						instrumentGrid.Rows[index + 1].Selected = true;
						instrumentGrid.Rows[index + 1].Cells["isPackagedCol"].Selected = true;
						if (instrumentGrid.Columns["isPackagedCol"].Visible)
							instrumentGrid.CurrentCell = instrumentGrid.Rows[index + 1].Cells["isPackagedCol"];
					}
					else
					{
						txtConfirmName.Focus();
						//instrumentGrid.Rows[0].Selected = true;
						//instrumentGrid.Rows[0].Cells["isPackagedCol"].Selected = true;
						//instrumentGrid.CurrentCell = instrumentGrid.Rows[0].Cells["isPackagedCol"];
					}
				//}
				e.Handled = true;
			}

		}



	}
}
