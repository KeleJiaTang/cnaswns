using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasBaseInterface;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_specialset_pack : MetroForm
	{
		/// <summary>
		/// 打包类型： 0: 普通包，1:订单包， 2: 外来器械包。
		/// </summary>
		private int _packageType = 0;
		/// <summary>
		/// 扫描枪
		/// </summary>
		public BarCodeHook _barCodeHook = new BarCodeHook();
		/// <summary>
		/// 打包需要核对的序列
		/// </summary>
		private SortedList _checkList = new SortedList();
		/// <summary>
		/// 是否生成
		/// </summary>
		private bool _isGenerated=false;
		/// <summary>
		/// 是否提交
		/// </summary>
		private bool _isCommited=false;
		/// <summary>
		/// 是否提交到下一个流程
		/// </summary>
		private bool _isCommitedNext = false;
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime _createDate = DateTime.Now;
		/// <summary>
		/// 有效期限
		/// </summary>
		private int _expirationTime = 7;
		/// <summary>
		/// 是否聚焦打包人
		/// </summary>
		private bool _isPackuserTxtFocused = true;
		/// <summary>
		/// 打包名称
		/// </summary>
		private string _packSetName;
		/// <summary>
		/// 批次号
		/// </summary>
		private string _batch;
		/// <summary>
		/// 订单号
		/// </summary>
		private string _orderNum;
		/// <summary>
		/// 流程核算
		/// </summary>
		private CnasHCSWorkflowInterface _workflowServer = null;
		/// <summary>
		/// 流程值
		/// </summary>
		private DataTable _pdData=null;
		/// <summary>
		/// 流程参数
		/// </summary>
		private DataTable _pdparameters = null;
		/// <summary>
		/// 数据访问接口
		/// </summary>
		private CnasRemotCall remoteClient = new CnasRemotCall();

		/// <summary>
		/// 扫入码
		/// </summary>
		public SortedList ScanBarCodes=new SortedList();
		/// <summary>
		/// 输出参数
		/// </summary>
		public SortedList OutputParameters = new SortedList();
		/// <summary>
		/// 流程号
		/// </summary>
		public string PdCode=string.Empty;


		public string AppId { get; set; }


		public HCSSM_order_specialset_pack(CnasHCSWorkflowInterface workFlowServer, DataTable pdData, DataTable pdparameters, string orderNum, string batch, string packSetName = "", int packageType = 0)
		{
			_workflowServer = workFlowServer;
			_pdData = pdData;
			_pdparameters = pdparameters;
			_orderNum = orderNum;
			_batch = batch;
			_packSetName = packSetName;
			_packageType = packageType;
			InitializeComponent();
			isSplitLbl.Visible = _packageType == 1;
			isSplitCbx.Visible = _packageType == 1;
		}

		/// <summary>
		/// 扫码响应事件
		/// </summary>
		/// <param name="barCode"></param>
		void _barCodeHook_BarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			if (matchBarCode.Length == 13 && matchBarCode.Substring(0, 2) == "BC")
			{
				HandleScanBarCode(matchBarCode);
			}
		}

		/// <summary>
		/// 处理扫描码
		/// </summary>
		/// <param name="barCode"></param>
		/// <returns></returns>
		private string HandleScanBarCode(string barCode)
		{
			string result = PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning);
			if (barCode.StartsWith("BCB"))
			{
				UserBase userInfo = UserBaseHelper.GetUserByBarCode(barCode);
				if (_isPackuserTxtFocused)
				{
					if (ScanBarCodes.ContainsValue("BCB"))
					{
						int index = ScanBarCodes.IndexOfValue("BCB");
						ScanBarCodes.RemoveAt(index);
					}
					ScanBarCodes.Add(barCode, "BCB");
					packUserTxt.Text = userInfo.UserName;
					packUserTxt.Tag = userInfo.UserID;
					_isPackuserTxtFocused = false;
					cfmUserTxt.Focus();
				}
				else
				{
					cfmUserTxt.Text = userInfo.UserName;
					cfmUserTxt.Tag = userInfo.UserID;
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
				}
			}
			return result;
		}

		private DateTime _firstTime = DateTime.Now;
		private bool _canKeyDown = true;

		/// <summary>
		/// 相应keyDown事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserEnterKeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyData == Keys.Enter)
			//{
			//	MetroTextBox textBox = sender as MetroTextBox;
			//	if (textBox != null)
			//	{
			//		UserBase user = null;
			//		if (textBox.Text.StartsWith("BCB") || string.IsNullOrEmpty(textBox.Text))
			//			return;
			//		else
			//			user = UserBaseHelper.UserInfoByUserName(textBox.Text);
			//		if (user == null)
			//		{
			//			textBox.Text = string.Empty;
			//			MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning),
			//				"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//		}
			//
			//		else
			//		{
			//			if (textBox.Name == "packUserTxt")
			//			{
			//				packUserTxt.Tag = user.UserID;
			//			}
			//			else
			//			{
			//				cfmUserTxt.Tag = user.UserID;
			//			}
			//		}
			//
			//	}
			//}

			MetroTextBox textBox = sender as MetroTextBox;
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			UserBase user = null;

			if (e.KeyData == Keys.Enter && _canKeyDown)
			{
				if (textBox != null)
				{
					if (textBox.Text.StartsWith("BCB") && textBox.Text.Length >= 13)
					{
						user = UserBaseHelper.GetUserByBarCode(textBox.Text);
					}
					else
					{
						user = UserBaseHelper.UserInfoByUserName(textBox.Text);
					}

					if (user != null)
					{
						if (textBox.Name == "packUserTxt")
						{
							//_packUser = user;
							if (ScanBarCodes.ContainsValue("BCB"))
							{
								int index = ScanBarCodes.IndexOfValue("BCB");
							ScanBarCodes.RemoveAt(index);
							}
							ScanBarCodes.Add(user.Userbcode, "BCB");
							//messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("packUserOk", EnumPromptMessage.warning);
						}
						else
						{
							//_confirmUser = user;
							//messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
						}

						textBox.Text = user.UserName;
						textBox.Tag = user.UserID;
					}
					else
					{
						//messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning);
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

		}


		public void InitializeIsSplitCbxCbx()
		{
			isSplitCbx.Items.Clear();
			DataRow[] packTypes = CnasBaseData.SystemBaseData.Select("type_code='HCS-Split-pack-type'");
			if (packTypes != null && packTypes.Length > 0)
			{
				foreach (DataRow item in packTypes)
				{
					string key = Convert.ToString(item["key_code"]);
					string value = Convert.ToString(item["value_code"]);
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					isSplitCbx.Items.Add(cbxItem);
				}
				isSplitCbx.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 包装类型
		/// </summary>
		public void InitializePackageTypeCbx()
		{
			DataRow[] packTypes = CnasBaseData.SystemBaseData.Select("type_code='HCS-temp-pack-type'");
			if (packTypes != null && packTypes.Length > 0)
			{
				foreach (DataRow item in packTypes)
				{
					string key = Convert.ToString(item["key_code"]);
					string value = Convert.ToString(item["value_code"]);
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					packTypeCbx.Items.Add(cbxItem);
				}
				packTypeCbx.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 验证数据是否完整
		/// </summary>
		/// <returns></returns>
		public string ValidateData()
		{
			string result = string.Empty;
			if (string.IsNullOrEmpty(packUserTxt.Text) || packUserTxt.Tag == null)
			{
				result = PromptMessageXmlHelper.Instance.GetPromptMessage("fillpackUser", EnumPromptMessage.warning);
				MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}
			if (string.IsNullOrEmpty(cfmUserTxt.Text) || cfmUserTxt.Tag == null)
			{
				result = PromptMessageXmlHelper.Instance.GetPromptMessage("fillcfmUser", EnumPromptMessage.warning);
				MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}
			if (string.IsNullOrEmpty(genNumTxt.Text) || !CnasUtilityTools.IsNumeric(genNumTxt.Text))
			{
				result = PromptMessageXmlHelper.Instance.GetPromptMessage("genNumvalid", EnumPromptMessage.warning);
				MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}
			return result;
		}

		/// <summary>
		/// 生成事件
		/// </summary>
		private void OnGenerateBtnClick()
		{
			try
			{
				if (_isGenerated && !_isCommited)
				{
					if (_packageType == 2)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("OrderHasBCCT", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					if (MessageBox.Show("标签条码已经生成，但未提交，之前生成的标签条码将丢弃。确定是否再次生成新条码？", "信息提示", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						return;
					}
				}
				if (!string.IsNullOrEmpty(ValidateData()))
					return;
				int number = 0;
				int.TryParse(genNumTxt.Text, out number);
				if (number <= 0)
					return;
				//string bcuType = "BCU0R";
				//string bccType = "BCC1T";
				KeyValuePair<string, string> isSplitCbxSelection = (KeyValuePair<string, string>)isSplitCbx.SelectedItem;
				KeyValuePair<string, string> packTypeCbxSelection = (KeyValuePair<string, string>)packTypeCbx.SelectedItem;
				string bcuType = string.Format("BCU{0}", _packageType.ToString());
				if ((_packageType == 2 && number > 1) || (_packageType == 1 && isSplitCbxSelection.Key == "2"))
				{
					bcuType = string.Format("{0}{1}",bcuType, "R");
				}
				else
				{
					bcuType = string.Format("{0}{1}", bcuType, "T");
				}
				string bccType = string.Format("BCC{0}T", packTypeCbxSelection.Key);
				int bccNumber = remoteClient.RemotInterface.GetSerialNumber(number, bccType);
				int bcuNumber = remoteClient.RemotInterface.GetSerialNumber(number, bcuType);
				string batchNum = remoteClient.RemotInterface.Get_SerialNumber(_packageType == 1 && isSplitCbxSelection.Key =="2" ? 2 : 1);
				if (_packageType == 2)
				{
					batchNum = _batch;
				}
				SortedList sqlParameters = new SortedList();
				int tempBccNum = bccNumber - number + 1;
				for (int i = 0; i < number; i++)
				{
					string bccCode = bccType.PadRight(13 - tempBccNum.ToString().Length, '0') + tempBccNum.ToString();
					string setName = genNameTxt.Text.TrimStart(' ').TrimEnd(' ');
					//string setName = string.Format("{0}<{1}>", genNameTxt.Text.TrimStart(' ').TrimEnd(' '), tempBccNum);
					SortedList item = new SortedList();
					item.Add(1, batchNum);
					item.Add(2, CnasBaseData.SystemID);
					item.Add(3, txtLocationName.Tag);//locationid
					item.Add(4, _expirationTime);
					item.Add(5, bccCode);
					item.Add(6, setName);
					//item.Add(7, bccCode);
					sqlParameters.Add(i, item);
					tempBccNum++;
				}
				string testSQL = remoteClient.RemotInterface.CheckUPDataList("HCS-bcct-add001", sqlParameters);
				int result = remoteClient.RemotInterface.UPDataList("HCS-bcct-add001", sqlParameters);
				if (result > 0)
				{
					SortedList condition = new SortedList();
					condition.Add(1, batchNum);
					string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-bcct-sec001", condition);
					DataTable data = remoteClient.RemotInterface.SelectData("HCS-bcct-sec001", condition);
					if (data != null && data.Rows.Count > 0)
					{
						int tempBcuNum = bcuNumber - number + 1;
						DateTime createDate = DateTime.Now;
						int expireDate = 7;
						foreach (DataRow item in data.Rows)
						{
							string expireDates = "7";
							int index = dataGrid.Rows.Add();
							if (data.Columns.Contains("id") && item["id"] != null) dataGrid.Rows[index].Cells["idCol"].Value = item["id"];
							if (data.Columns.Contains("bar_code") && item["bar_code"] != null) dataGrid.Rows[index].Cells["tempCodeCol"].Value = item["bar_code"];
							if (data.Columns.Contains("ca_name") && item["ca_name"] != null) dataGrid.Rows[index].Cells["setNameCol"].Value = item["ca_name"];
							if (data.Columns.Contains("ca_expiration") && item["ca_expiration"] != null) expireDates = Convert.ToString(item["ca_expiration"]);
							int.TryParse(expireDates, out expireDate);
							dataGrid.Rows[index].Cells["useLocationCol"].Value = txtLocationName.Text;//locationName
							dataGrid.Rows[index].Cells["pbCodeCol"].Value = bcuType.PadRight(13 - tempBcuNum.ToString().Length, '0') + tempBcuNum.ToString();
							dataGrid.Rows[index].Cells["creDateCol"].Value = createDate;
							dataGrid.Rows[index].Cells["expireDateCol"].Value = createDate.AddDays(expireDate);
							dataGrid.Rows[index].Cells["batchCol"].Value = batchNum;
							tempBcuNum++;
						}
						_isGenerated = true;
						_isCommited = false;
					}
				}
			}
			catch (Exception)
			{
			}
			OnCommitButtonClick();
			OnPrintButtonClick();
		}

		/// <summary>
		/// 生成事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void generateBtn_Click(object sender, EventArgs e)
		{
			cfmUserTxt.Focus();
			OnGenerateBtnClick();
		}

		/// <summary>
		/// 提交流程
		/// </summary>
		/// <returns></returns>
		private bool CommitData()
		{
			bool result = false;
			try
			{
				if (dataGrid.RowCount > 0)
				{
					SortedList sqlParameter = new SortedList();
					SortedList workSets = new SortedList();
					SortedList workSetInfos = new SortedList();
					sqlParameter.Add(1, workSets);
					sqlParameter.Add(2, workSetInfos);
					DateTime creDate = DateTime.Now;
					string batchNum = string.Empty;
					foreach (DataGridViewRow row in dataGrid.Rows)
					{
						batchNum = Convert.ToString(row.Cells["batchCol"].Value);
						string bccCode = Convert.ToString(row.Cells["tempCodeCol"].Value);
						string bcuCode = Convert.ToString(row.Cells["pbCodeCol"].Value);
						SortedList workSet = new SortedList();
						SortedList workSetInfo = new SortedList();
						workSet.Add(1, row.Cells["idCol"].Value);
						workSet.Add(2, row.Cells["tempCodeCol"].Value);
						workSet.Add(3, row.Cells["setNameCol"].Value);
						workSet.Add(4, PdCode);
						workSet.Add(5, packUserTxt.Tag != null ? packUserTxt.Tag : 0);
						workSet.Add(6, row.Cells["batchCol"].Value);
						workSet.Add(7, creDate.ToString("yyyy-MM-dd"));
						workSet.Add(8, "");
						workSet.Add(9, "");
						workSet.Add(10, row.Cells["pbCodeCol"].Value);
						workSet.Add(11, cfmUserTxt.Tag != null ? cfmUserTxt.Tag : 0);
						workSets.Add(workSets.Count + 1, workSet);

						workSetInfo.Add(1, row.Cells["batchCol"].Value);
						workSetInfo.Add(2, "BCU");
						workSetInfo.Add(3, CnasUtilityTools.ConcatTwoString(bcuCode, bccCode));
						workSetInfo.Add(4, 3);
						workSetInfo.Add(5, packUserTxt.Tag != null ? packUserTxt.Tag : 0);
						workSetInfo.Add(6, "");
						workSetInfos.Add(workSetInfos.Count + 1, workSetInfo);
					}
					SortedList dealCounts = new SortedList();
					sqlParameter.Add(3, dealCounts);
					//if (_packageType==2)
					//{
					//	SortedList dealCount = new SortedList();
					//	dealCounts.Add(dealCounts.Count + 1, dealCount);
					//	dealCount.Add(1, batchNum);
					//	dealCount.Add(2, AppId);
					//	dealCount.Add(3, packUserTxt.Tag != null ? packUserTxt.Tag : 0);
					//	dealCount.Add(4, CnasBaseData.SystemID);
					//	dealCount.Add(5, batchNum);
					//}

					string testSQL = remoteClient.RemotInterface.CheckUPDataList("HCS-workset-add008", sqlParameter);
					int rect = remoteClient.RemotInterface.UPDataList("HCS-workset-add008", sqlParameter);
					if (rect > 0)
					{
						for (int i = 0; i < ScanBarCodes.Count; i++)
						{
							if (ScanBarCodes.GetKey(i).ToString().StartsWith("BCU"))
							{
								ScanBarCodes.RemoveAt(i);
								i--;
							}
						}
						foreach (DataGridViewRow row in dataGrid.Rows)
						{
							string bccCode = row.Cells["tempCodeCol"].Value != null ? row.Cells["tempCodeCol"].Value.ToString() : string.Empty;
							string bcuCode = row.Cells["pbCodeCol"].Value != null ? row.Cells["pbCodeCol"].Value.ToString() : string.Empty;
							string key = CnasUtilityTools.ConcatTwoString(bcuCode, bccCode);
							if (!ScanBarCodes.ContainsKey(key))
								ScanBarCodes.Add(key, "BCU");
						}
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
		/// <summary>
		/// push下一步流程
		/// </summary>
		/// <returns></returns>
		private SortedList PushToNextWF()
		{
			SortedList result = new SortedList();
			try
			{
				SortedList cfmUser = new SortedList();
				cfmUser.Add("confirmUserId", cfmUserTxt.Tag != null ? cfmUserTxt.Tag : 0);
				if (OutputParameters.ContainsKey("confirmUserParams"))
				{
					OutputParameters["confirmUserParams"] = cfmUser;
				}
				else
				{
					OutputParameters.Add("confirmUserParams", cfmUser);
				}
				SortedList submit = new SortedList();
				submit.Add("SL_check", _checkList);
				submit.Add("sub_barcode", ScanBarCodes);
				submit.Add("user_id", packUserTxt.Tag != null ? packUserTxt.Tag : 0);
				submit.Add("Par2_info", new SortedList());
				submit.Add("Par3_Dialog", OutputParameters);
				result = _workflowServer.GetWorkflowParametersValue(1001, 1001, submit, null, null);
			}
			catch (Exception)
			{
				result["rec_result"] = "1";
				result["rec_data02"] = "创建标签条码成功，提交下一步流程失败";
			}
			return result;
		}

		/// <summary>
		/// 提交push流程
		/// </summary>
		private void OnCommitButtonClick()
		{
			if (_isGenerated)
			{
				try
				{
					if (!_isCommited)
					{
						_isCommited = CommitData();
						_isCommitedNext = false;
						if (!_isCommited)
						{
							MessageBox.Show("提交创建标签条码流程失败。", "信息提示");
						}
					}
					if (!_isCommitedNext)
					{
						SortedList result = PushToNextWF();
						if (result["rec_result"].ToString() != "0")
						{
							_isCommitedNext = true;
							MessageBox.Show("创建标签条码成功，无法提交下一步流程。", "信息提示");
						}
					}
				}
				catch (Exception)
				{
					MessageBox.Show("提交失败， 请联系管理员。", "信息提示");
				}
			}
			else
			{
				MessageBox.Show("标签条码未生成，请先生成标签条码。", "信息提示");
			}
		}

		/// <summary>
		/// 依据datagrid打印
		/// </summary>
		private void OnPrintButtonClick()
		{
			if (!string.IsNullOrEmpty(ValidateData())) return;
			if (dataGrid.RowCount <= 0)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("nothavedata", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCU'");
			string strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
			try
			{
				foreach (DataGridViewRow item in dataGrid.Rows)
				{
					SortedList parameters = new SortedList();
					string bcuCode = item.Cells["pbCodeCol"].Value != null ? item.Cells["pbCodeCol"].Value.ToString() : string.Empty;
					parameters.Add("BarcodeValue", bcuCode);
					parameters.Add("P014", bcuCode);
					parameters.Add("P017", _createDate.ToString("yyyy-MM-dd"));
					parameters.Add("P018", _createDate.AddDays(_expirationTime).ToString("yyyy-MM-dd"));
					parameters.Add("P019", packUserTxt.Text.Trim());
					parameters.Add("P020", cfmUserTxt.Text.Trim());
					parameters.Add("P013", Convert.ToString(item.Cells["setNameCol"].Value.ToString()));
					parameters.Add("P016", Convert.ToString(item.Cells["useLocationCol"].Value.ToString()));
					string printResult = BarCodeHelper.PrintBarCode(bcuCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
					{
						MessageBox.Show(printResult,"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 打印事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void printBtn_Click(object sender, EventArgs e)
		{
			OnPrintButtonClick();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			OnCloseBtn();
		}
		/// <summary>
		/// 关闭窗口
		/// </summary>
		private void OnCloseBtn()
		{
			Close();
		}

		/// <summary>
		/// 初始化按钮图片
		/// </summary>
		public void InitializeButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			generateBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mGenerate32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// load事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_specialset_pack_Load(object sender, EventArgs e)
		{
			InitializePackageTypeCbx();
			InitializeButtonImage();
			InitializeMaterialCbx();
			InitializeIsSplitCbxCbx();
			packUserTxt.Focus();
			LoadData();
			_barCodeHook.BarCodeEvent += _barCodeHook_BarCodeEvent;
			_barCodeHook.Start(false);
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadData()
		{
			try
			{
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, _orderNum);
				DataTable data = remoteClient.RemotInterface.SelectData("HCS-orderid-manager-sec005", condition);
				if(data!=null&&data.Rows.Count>0)
				{
					DataRow row=data.Rows[0];
					txtCustomerName.Text = Convert.ToString(row["cu_name"]);
					txtCustomerName.Tag = Convert.ToString(row["customer_barcode"]);
					txtLocationName.Text = Convert.ToString(row["u_uname"]);
					txtLocationName.Tag = Convert.ToString(row["location_id"]);
				}
				else
				{
					throw new Exception("初始化失败!");
				}
				genNameTxt.Text = _packSetName;
				genNumTxt.Text = "1";
				ScanBarCodes.Add("BCV0000003020", "BCV");
				GenerateCheckList();
				if(_packageType==2)
				{
					//如果是院外器械出院订单则load 在hcs_work_set的数据
					dataGrid.Rows.Clear();
					SortedList gridcondition = new SortedList();
					gridcondition.Add(1, _batch);
					gridcondition.Add(2, CnasBaseData.SystemID);
					string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-bcct-data-sec001", gridcondition);
					DataTable dataGridTable = remoteClient.RemotInterface.SelectData("HCS-bcct-data-sec001", gridcondition);
					if (dataGridTable != null)
					{
						foreach (DataRow row in dataGridTable.Rows)
						{
							int index = dataGrid.Rows.Add();
							int expireDates = 7;
							DateTime createDate = DateTime.Now;
							if (dataGridTable.Columns.Contains("id") && row["id"] != null) dataGrid.Rows[index].Cells["idCol"].Value = row["id"];
							if (dataGridTable.Columns.Contains("bar_code") && row["bar_code"] != null) dataGrid.Rows[index].Cells["tempCodeCol"].Value = row["bar_code"];
							if (dataGridTable.Columns.Contains("ca_name") && row["ca_name"] != null) dataGrid.Rows[index].Cells["setNameCol"].Value = row["ca_name"];
							if (dataGridTable.Columns.Contains("sequenceid")) dataGrid.Rows[index].Cells["batchCol"].Value = row["sequenceid"];

							dataGrid.Rows[index].Cells["useLocationCol"].Value = txtLocationName.Text.Trim() ;
							if (dataGridTable.Columns.Contains("cre_date"))
							{
								createDate = Convert.ToDateTime(row["cre_date"]);
								dataGrid.Rows[index].Cells["creDateCol"].Value = createDate;
								if (dataGridTable.Columns.Contains("ca_expiration"))
								{
									expireDates = Convert.ToInt32(row["ca_expiration"]);
									dataGrid.Rows[index].Cells["expireDateCol"].Value = createDate.AddDays(expireDates);
								}
							}
							if (dataGridTable.Columns.Contains("BCU_code")) dataGrid.Rows[index].Cells["pbCodeCol"].Value = row["BCU_code"];
						}

						genNumTxt.Text = dataGrid.RowCount.ToString();
						genNumTxt.Enabled = false;
						_isGenerated = true;
					}
					else
					{
						genNumTxt.Enabled = true;
						genNumTxt.Text = "1";
						_isGenerated = false;
						_isCommited = false;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// 停止stopbarcodehook
		/// </summary>
		private void StopBarcodeHook()
		{
			if(_barCodeHook!=null)
			{
				_barCodeHook.Stop();
			}
		}

		/// <summary>
		/// 窗口关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_specialset_pack_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopBarcodeHook();
		}

		/// <summary>
		/// 初始化相应信息
		/// </summary>
		public void  GenerateCheckList()
		{
			string pdCode = string.Empty;
			string pdBarCode = BarCodeHelper.GetBarCodeByType("BCV", ScanBarCodes);
			SortedList sl_check = new SortedList();
			SortedList parameters01 = new SortedList();
			SortedList parameters02 = new SortedList();
			if (!string.IsNullOrEmpty(pdBarCode) && pdBarCode.Length >= 13)
			{
				PdCode = pdBarCode.Substring(9, 4);
				SortedList condition = new SortedList();
				condition.Add(1, PdCode);
				//string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-procedure-sec003", condition);
				DataTable data = remoteClient.RemotInterface.SelectData("HCS-procedure-sec003", condition);
				string scanParam = string.Empty;
				if (data != null && data.Rows.Count == 1)
				{
					if (data.Rows[0]["pd_code"] != null) pdCode = data.Rows[0]["pd_code"].ToString();
					if (data.Rows[0]["pd_scan"] != null) scanParam = data.Rows[0]["pd_scan"].ToString();
					if (!string.IsNullOrEmpty(scanParam))
					{
						string[] scanParams = scanParam.Split(';');
						SortedList values = new SortedList();
						foreach (string item in scanParams)
						{
							if (item.Length > 3 && !values.ContainsKey(item.Substring(0, 3)))
							{
								values.Add(item.Substring(0, 3), int.Parse(item.Substring(3)));
							}
						}
						sl_check["pd_scan"] = values;
						sl_check["pd_code"] = data.Rows[0]["pd_code"].ToString();//流程代码
						sl_check["pd_name"] = data.Rows[0]["pd_name"];//流程名字
						sl_check["pd_barcode"] = pdBarCode;//流程编码
					}
				}
				else
				{
					MessageBox.Show("初始化流程数据失败。", "信息提示");
				}
				sl_check["pd_par1"] = parameters01;//所有流程参数为1的集合
				sl_check["pd_par2"] = parameters02;//所有流程参数为2的集合
				if (_pdparameters != null && _pdparameters.Columns.Contains("pd_code"))
				{
					DataRow[] pdParameters = _pdparameters.Select("pd_code=" + PdCode);
					foreach (DataRow dr in pdParameters)
					{
						string parameterName = dr["par_name"].ToString();
						string parameterType = dr["par_type"].ToString();
						string parameterDescription = dr["par_description"].ToString();
						if (parameterType == "2")
						{
							parameters01.Add(parameterName, parameterDescription);
						}
						else
						{
							parameters01.Add(parameterName, parameterDescription);
						}
					}
				}
			}
			_checkList = sl_check;
		}

		/// <summary>
		/// keyDown事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void packUserTxt_KeyDown(object sender, KeyEventArgs e)
		{
			OnUserEnterKeyDown(sender, e);
		}


		/// <summary>
		/// 初始化包装下框
		/// </summary>
		public void InitializeMaterialCbx()
		{
			materialCbx.Items.Clear();
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			//string sqlTest = remoteClient.RemotInterface.CheckSelectData("HCS-setmaterial-type-sec001", condition);
			DataTable data = remoteClient.RemotInterface.SelectData("HCS-setmaterial-type-sec001", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					string id = item["id"].ToString();
					string name = item["ca_name"].ToString();
					string exipireDate = item["expiration_day"].ToString();
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(CnasUtilityTools.ConcatTwoString(id, exipireDate), name);
					materialCbx.Items.Add(cbxItem);
				}
				materialCbx.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 包装材料更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void materialCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetExpireDateTxt();
		}

		private void SetExpireDateTxt()
		{
			if (materialCbx.SelectedItem != null && materialCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)materialCbx.SelectedItem;
				string[] info = selectedItem.Key.Split(':');
				if (info.Length > 1)
				{
					expireDateTxt.Text = info[1];
					int.TryParse(info[1], out _expirationTime);
				}
			}
		}

		private void packUserTxt_Click(object sender, EventArgs e)
		{
			_isPackuserTxtFocused = true;
		}

		private void OnSizeChanged(object sender, EventArgs e)
		{
			if (isSplitCbx.Visible)
				isSplitCbx.Size = materialCbx.Size;
		}

	}
}
