using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Text.RegularExpressions;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_specialset_packing : ControlViewBase
	{
		private string _dealOrderWF = string.Empty;
		private string _selectOrderName = string.Empty;
		private bool _isGenerated = false;
		private bool _isCommited = false;
		private bool _isCommitedNext = false;
		public DataTable PdData = null;
		public DataTable Pdparameters = null;
		private SortedList _checkList = new SortedList();
		private DateTime _createDate = DateTime.Now;
		private int _expirationTime = 7;
		private string _sterilizerPackType = string.Empty;
		private UserBase _packUser = null;
		private UserBase _confirmUser = null;

		public string AppId { get; set; }

		public HCSWF_specialset_packing()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			DataRow[] orderDillPlace = CnasBaseData.SystemBaseData.Select("key_code = 'Order_without_entity_wf' and type_code ='HCS-procedure-data'");
			if (orderDillPlace.Length > 0 && orderDillPlace[0]["value_code"] != null)
				_dealOrderWF = orderDillPlace[0]["value_code"].ToString();
			
			DataRow[] sterilizerPackType = CnasBaseData.SystemBaseData.Select("key_code = 'SterilizerPackType' and type_code ='HCS-system-settings'");
			if (sterilizerPackType.Length > 0 && sterilizerPackType[0]["value_code"] != null)
				_sterilizerPackType = sterilizerPackType[0]["value_code"].ToString();
			base.InitalizeControl();
			packUserTxt.Focus();
			//InitalizeOrderCbx();
			InitializeButtonImage();
			
			InitializeCustomerCbx();
			InitializeUseLocationCbx();
			//SetViewState();
			InitializePackTypeCbx();
			InitializeMaterialCbx();
			InitializeIsSplitCbxCbx();
			InitializePackageTypeCbx();
			InitializeGenNum();
		}

		public void InitializeButtonImage()
		{
			generateBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mGenerate32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			submitBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
		}

		public void InitializeCustomerCbx()
		{
			customerCbx.Items.Clear();
			if (CnasBaseData.UserAccessCustomer != null && CnasBaseData.UserAccessCustomer.Rows.Count > 0)
			{
				for (int i = 0; i < CnasBaseData.UserAccessCustomer.Rows.Count; i++)
				{
					DataRow row = CnasBaseData.UserAccessCustomer.Rows[i];
					string key = Convert.ToString(row["id"]);
					string value = Convert.ToString(row["cu_name"]);

					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					customerCbx.Items.Add(cbxItem);
					if (CnasBaseData.UserBaseInfo != null && CnasBaseData.UserBaseInfo.CustomerId.ToString() == key)
					{
						int index = customerCbx.Items.IndexOf(cbxItem);
						customerCbx.SelectedIndex = index;
					}
				}
			}
		}

		public void InitializeMaterialCbx()
		{
			materialCbx.Items.Clear();
			CnasRemotCall remoteCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-setmaterial-type-sec001", condition);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-setmaterial-type-sec001", condition);
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

		public void InitializePackageTypeCbx()
		{
			packageTypeCbx.Items.Clear();
			DataRow[] packTypes = CnasBaseData.SystemBaseData.Select("type_code='HCS-package-type'");
			if (packTypes != null && packTypes.Length > 0)
			{
				foreach (DataRow item in packTypes)
				{
					string key = Convert.ToString(item["key_code"]);
					string value = Convert.ToString(item["value_code"]);
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					packageTypeCbx.Items.Add(cbxItem);
				}
				packageTypeCbx.SelectedIndex = 0;
			}
		}

		public void InitializePackTypeCbx()
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

		private void InitializeUseLocationCbx()
		{
			uselocationCbx.Items.Clear();
			KeyValuePair<string, string> defaultItem = new KeyValuePair<string, string>("0", "--所有--");
			uselocationCbx.Items.Add(defaultItem);
			SortedList condition = new SortedList();

			CnasRemotCall remoteCall = new CnasRemotCall();
			if (customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
			{
				condition.Add(1, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
			}
			else
			{
				condition.Add(1, "0");
			}

			string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-use-location-sec002", condition);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-use-location-sec002", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					string key = item["id"].ToString();
					string value = item["u_uname"].ToString();
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					uselocationCbx.Items.Add(cbxItem);
				}
			}
			uselocationCbx.SelectedIndex = 0;
		}

		private void InitalizeOrderCbx()
		{
			try
			{
				orderCbx.Items.Clear();
				SortedList condition = new SortedList();
				string wf = string.IsNullOrEmpty(_dealOrderWF) ? PdCode : _dealOrderWF + PdCode;
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, "0");
				condition.Add(3, wf.Replace(",", "','"));
				if (customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
				{
					condition.Add(4, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
				}
				string filter = string.Empty;
				if (uselocationCbx.SelectedIndex != 0 && uselocationCbx.SelectedItem is KeyValuePair<string, string>)
				{
					string key = ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key;
					filter += string.Format(" and se.location_id={0} ", key);
				}
				condition.Add(5, filter);
				string testSQL = RemoteClient.RemotInterface.CheckSelectData("HCS-package-order-sec001", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-package-order-sec001", condition);
				if (data != null && data.Rows.Count > 0)
				{
					foreach (DataRow item in data.Rows)
					{
						if (data.Columns.Contains("batch") && data.Columns.Contains("set_code") && data.Columns.Contains("set_name"))
						{
							string batch = Convert.ToString(item["batch"]);
							string key = Convert.ToString(item["set_code"]);
							string name = Convert.ToString(item["set_name"]);
							string location = Convert.ToString(item["location_id"]);

							KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(CnasUtilityTools.ConcatTwoString(batch, location), CnasUtilityTools.ConcatTwoString(key, name));
							orderCbx.Items.Add(cbxItem);
						}
					}
					if (orderCbx.Items.Count > 0)
						orderCbx.SelectedIndex = 0;
				}
				else
				{
					orderCbx.SelectedIndex = -1;
					dataGrid.Rows.Clear();
				}
			}
			catch (Exception)
			{

			}
		}

		private void SetViewState()
		{
			if (packageTypeCbx.SelectedItem != null && packageTypeCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selection = (KeyValuePair<string, string>)packageTypeCbx.SelectedItem;
				
				if (selection.Key == "2")
				{
					orderCodeLbl.Visible = true;
					orderCbx.Visible = true;
					genNameLbl.Visible = false;
					genNameTxt.Visible = false;
					InitalizeOrderCbx();
				}
				else
				{
					orderCodeLbl.Visible = false;
					orderCbx.Visible = false;
					genNameLbl.Visible = true;
					genNameTxt.Visible = true;
				}
			}
			
			//genNameLbl.Visible = batchBCU.Checked;
			//genNameTxt.Visible = batchBCU.Checked;
			//if (batchBCUR.Checked)
			//	InitalizeOrderCbx();
		}

		private void OnRadioChanged(object sender, EventArgs e)
		{
			RadioButton button = sender as RadioButton;
			if (button.Name == "batchBCU")
			{
				genNameLbl.Visible = button.Checked;
				genNameTxt.Visible = button.Checked;
			}
			else if (button.Name == "batchBCUR")
			{
				orderCodeLbl.Visible = button.Checked;
				orderCbx.Visible = button.Checked;
				if (button.Checked)
				{
					InitalizeOrderCbx();
				}
			}
		}

		private void OnGeneratorButtonClick(object sender, EventArgs e)
		{
			cfmUserTxt.Focus();
			try
			{
				if (_isGenerated)
				{
					if (packageTypeCbx.SelectedItem != null && ((KeyValuePair<string, string>)packageTypeCbx.SelectedItem).Key == "2")
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("OrderHasBCCT", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					//if (MessageBox.Show("标签条码已经生成，但未提交，之前生成的标签条码将丢弃。确定是否再次生成新条码？", "信息提示", MessageBoxButtons.YesNo) == DialogResult.No)
					//{
					//	return;
					//}
				}
				if (!string.IsNullOrEmpty(ValidateData()))
					return;
				int number = 0;
				KeyValuePair<string, string> packageTypeSelection = (KeyValuePair<string, string>)packageTypeCbx.SelectedItem;
				KeyValuePair<string, string> packTypeCbxSelection = (KeyValuePair<string, string>)packTypeCbx.SelectedItem;
				KeyValuePair<string, string> isSplitCbxSelection = (KeyValuePair<string, string>)isSplitCbx.SelectedItem;
				string bcuType = string.Format("BCU{0}{1}", packageTypeSelection.Key, (isSplitCbxSelection.Key == "1" ? "T" : "R"));
				string bccType = string.Format("BCC{0}T", packTypeCbxSelection.Key);
				//if (packTypeCbx.SelectedItem != null && packTypeCbx.SelectedItem is KeyValuePair<string, string>)
				//{
				//	string type = ((KeyValuePair<string, string>)packTypeCbx.SelectedItem).Key;
				//	if (!batchBCUR.Checked)
				//		bcuType = string.Format("BCU{0}T", type);
				//	bccType = string.Format("BCC{0}T", type);
				//}

				int.TryParse(genNumTxt.Text, out number);
				if (number <= 0) 
					return;
				int bccNumber = RemoteClient.RemotInterface.GetSerialNumber(number, bccType);
				int bcuNumber = RemoteClient.RemotInterface.GetSerialNumber(number, bcuType);
				string batchNum = string.Empty;
				KeyValuePair<string, string> locationItem = ((KeyValuePair<string, string>)uselocationCbx.SelectedItem);
				if (packageTypeSelection.Key == "2")
				{
					if (orderCbx.SelectedItem != null && orderCbx.SelectedItem is KeyValuePair<string, string>)
					{
						string key = ((KeyValuePair<string, string>)orderCbx.SelectedItem).Key;
						string[] keys = 	key.Split(':');
						batchNum = keys[0];
						foreach (KeyValuePair<string, string> item in uselocationCbx.Items)
						{
							if (keys.Length > 1 && item.Key == keys[1])
							{
								locationItem = item;
								break;
							}
						}
					}
				}
				else
				{
					int batchType = 1;
					int.TryParse(isSplitCbxSelection.Key, out batchType);
					batchNum = RemoteClient.RemotInterface.Get_SerialNumber(batchType);
				}
				SortedList sqlParameters = new SortedList();
				int tempBccNum = bccNumber - number + 1;
				string tempSetName = packageTypeSelection.Key == "2" ? _selectOrderName : genNameTxt.Text.TrimStart(' ').TrimEnd(' ');
				for (int i = 0; i < number; i++)
				{
					string bccCode = bccType.PadRight(13 - tempBccNum.ToString().Length, '0') + tempBccNum.ToString();
					string setName = tempSetName;
					//string setName = string.Format("{0}<{1}>", tempSetName, tempBccNum);
					SortedList item = new SortedList();
					item.Add(1, batchNum);
					item.Add(2, CnasBaseData.SystemID);
					item.Add(3, ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key);
					item.Add(4, expireDateTxt.Text);
					item.Add(5, bccCode);
					item.Add(6, setName);
					//item.Add(7, bccCode);
					sqlParameters.Add(i, item);
					tempBccNum++;
				}
				string testSQL = RemoteClient.RemotInterface.CheckUPDataList("HCS-bcct-add001", sqlParameters);
				int result = RemoteClient.RemotInterface.UPDataList("HCS-bcct-add001", sqlParameters);

				if (result > 0)
				{
					SortedList condition = new SortedList();
					condition.Add(1, batchNum);
					string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-bcct-sec001", condition);
					DataTable data = RemoteClient.RemotInterface.SelectData("HCS-bcct-sec001", condition);
					if (data != null && data.Rows.Count > 0)
					{
						dataGrid.Rows.Clear();
						int tempBcuNum = bcuNumber - number + 1;
						DateTime createDate = DateTime.Now;
						int expireDate = 7;
						foreach (DataRow item in data.Rows)
						{
							//string bcuCode = batchBCUR.Checked ? "BCU0R" : "BCU0T";
							string expireDates = "7";
							int index = dataGrid.Rows.Add();
							if (data.Columns.Contains("id") && item["id"] != null) dataGrid.Rows[index].Cells["idCol"].Value = item["id"];
							if (data.Columns.Contains("bar_code") && item["bar_code"] != null) dataGrid.Rows[index].Cells["tempCodeCol"].Value = item["bar_code"];
							if (data.Columns.Contains("ca_name") && item["ca_name"] != null) dataGrid.Rows[index].Cells["setNameCol"].Value = item["ca_name"];
							if (data.Columns.Contains("ca_expiration") && item["ca_expiration"] != null) expireDates = Convert.ToString(item["ca_expiration"]);
							int.TryParse(expireDates, out expireDate);
							dataGrid.Rows[index].Cells["useLocationCol"].Value = locationItem.Value;
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
			OnCommitButtonClick(sender, e);
			OnPrintButtonClick(sender, e);
		}

		private void OnCommitButtonClick(object sender, EventArgs e)
		{
			//cfmUserTxt.Focus();
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
				result = WorkflowServer.GetWorkflowParametersValue(1001, 1001, submit, null, null);
			}
			catch (Exception)
			{
				result["rec_result"] = "1";
				result["rec_data02"] = "创建标签条码成功，提交下一步流程失败";
			}
			return result;
		}

		public SortedList GenerateCheckList()
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
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-procedure-sec003", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-procedure-sec003", condition);
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

				if (Pdparameters != null && Pdparameters.Columns.Contains("pd_code"))
				{
					DataRow[] pdParameters = Pdparameters.Select("pd_code=" + PdCode);
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
			return sl_check;
		}

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
					foreach (DataGridViewRow row in dataGrid.Rows)
					{
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
						workSet.Add(7, row.Cells["creDateCol"].Value);
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
					if (packageTypeCbx.SelectedItem != null && ((KeyValuePair<string, string>)packageTypeCbx.SelectedItem).Key == "2")
					{
						if (orderCbx.SelectedItem != null && orderCbx.SelectedItem is KeyValuePair<string, string>)
						{
							string key = ((KeyValuePair<string, string>)orderCbx.SelectedItem).Key;
							string[] keys = key.Split(':');
							string batchNum = keys[0];
							SortedList dealCount = new SortedList();
							dealCounts.Add(dealCounts.Count + 1, dealCount);
							dealCount.Add(1, batchNum);
							dealCount.Add(2, AppId);
							dealCount.Add(3, packUserTxt.Tag != null ? packUserTxt.Tag : 0);
							dealCount.Add(4, CnasBaseData.SystemID);
							dealCount.Add(5, batchNum);
						}
					}
					string testSQL = RemoteClient.RemotInterface.CheckUPDataList("HCS-workset-add008", sqlParameter);
					int rect = RemoteClient.RemotInterface.UPDataList("HCS-workset-add008", sqlParameter);
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

		private void OnPrintButtonClick(object sender, EventArgs e)
		{
			//cfmUserTxt.Focus();
			//if (!string.IsNullOrEmpty(ValidateData())) return;
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
						MessageBox.Show(printResult,
									"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		public override string ValidateData()
		{
			string result = string.Empty;
			if (isSplitCbx.SelectedItem != null && isSplitCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> isSplitCbxSelection = (KeyValuePair<string, string>)isSplitCbx.SelectedItem;
				if (isSplitCbxSelection.Key == "2")
				{
					if (genNumTxt.Text == "1")
					{
						result = PromptMessageXmlHelper.Instance.GetPromptMessage("SplitSetMoreThenOne", EnumPromptMessage.warning);
						MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return result;
					}
				}
			}
			if (packageTypeCbx.SelectedItem != null && packageTypeCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> packageTypeCbxSelection = (KeyValuePair<string, string>)packageTypeCbx.SelectedItem;
				if (packageTypeCbxSelection.Key != "2")
				{
					if (uselocationCbx.SelectedItem == null || ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key == "0")
					{
						result = PromptMessageXmlHelper.Instance.GetPromptMessage("fillUseLocation", EnumPromptMessage.warning);
						MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return result;
					}
				}
			}
			//if (batchBCU.Checked && (uselocationCbx.SelectedItem == null || ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key == "0"))
			//{
			//	result = PromptMessageXmlHelper.Instance.GetPromptMessage("fillUseLocation", EnumPromptMessage.warning);
			//	MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return result;
			//}
			//else if (batchBCUR.Checked && orderCbx.SelectedItem == null)
			//{
			//	MessageBox.Show("请选择订单", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return "请选择订单";
			//}

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

			// Add number validation
			//if (dataGrid.RowCount <=0)
			//{
			//	result = PromptMessageXmlHelper.Instance.GetPromptMessage("nothavedata", EnumPromptMessage.warning);
			//	MessageBox.Show(result, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return result;
			//}
			return result;
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			if (ParentForm != null)
				ParentForm.Close();
		}

		private void OnDataGridDeleteClick(object sender, EventArgs e)
		{
			if (dataGrid.SelectedRows != null)
			{
				foreach (DataGridViewRow item in dataGrid.SelectedRows)
				{
					if (dataGrid.Rows.Contains(item))
						dataGrid.Rows.Remove(item);
				}
			}
		}

		private void OnDataGridContextMenuOpening(object sender, CancelEventArgs e)
		{
			if (dataGrid.SelectedRows == null || dataGrid.SelectedRows.Count == 0)
			{
				e.Cancel = true;
				return;
			}
		}

		private bool _packUserFocused = true;
		public override string HandleScanBarCode(string barCode)
		{
			string result = base.HandleScanBarCode(barCode);
			if (barCode.StartsWith("BCB"))
			{
				UserBase userInfo = UserBaseHelper.GetUserByBarCode(barCode);

				if (userInfo != null && userInfo.UserID > 0)
				{
					if (_packUserFocused)
					{
						if (ScanBarCodes.ContainsValue("BCB"))
						{
							int index = ScanBarCodes.IndexOfValue("BCB");
							ScanBarCodes.RemoveAt(index);
						}
						ScanBarCodes.Add(barCode, "BCB");
						_packUser = userInfo;
						packUserTxt.Text = _packUser.UserName;
						packUserTxt.Tag = userInfo.UserID;
						_packUserFocused = false;
						cfmUserTxt.Focus();
						result = PromptMessageXmlHelper.Instance.GetPromptMessage("packUserOk", EnumPromptMessage.warning);
					}
					else
					{
						_confirmUser = userInfo;
						cfmUserTxt.Text = userInfo.UserName;
						cfmUserTxt.Tag = userInfo.UserID;
						result = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
					}
				}
				else
				{
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning);
				}
			}
			else
			{
				if (_packUserFocused)
				{
					packUserTxt.Text = _packUser != null ? _packUser.UserName : string.Empty;
				}
				else
				{
					cfmUserTxt.Text = _confirmUser != null ? _confirmUser.UserName : string.Empty;
				}
				result = PromptMessageXmlHelper.Instance.GetPromptMessage("InvalidUserCode", EnumPromptMessage.warning);
			}
			messageLbl.Text = result;

			return result;
		}

		private DateTime _firstTime = DateTime.Now;
		private bool _canKeyDown = false;

		private void OnUserEnterKeyDown(object sender, KeyEventArgs e)
		{
			MetroTextBox textBox = sender as MetroTextBox;
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			UserBase user = null;

			if (e.KeyData == Keys.Enter && _canKeyDown)
			{
				if (textBox != null)
				{
					if (textBox.Text.StartsWith("BCB") && textBox.Text.Length >=13)
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
							_packUser = user;
							if (ScanBarCodes.ContainsValue("BCB"))
							{
								int index = ScanBarCodes.IndexOfValue("BCB");
								ScanBarCodes.RemoveAt(index);
							}
							ScanBarCodes.Add(user.Userbcode, "BCB");
							messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("packUserOk", EnumPromptMessage.warning);
						}
						else
						{
							_confirmUser = user;
							messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("cfmUserOk", EnumPromptMessage.warning);
						}

						textBox.Text = user.UserName;
						textBox.Tag = user.UserID;
					}
					else
					{
						messageLbl.Text = PromptMessageXmlHelper.Instance.GetPromptMessage("notfindUser", EnumPromptMessage.warning);
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

		private void OnPackUserTxtClick(object sender, EventArgs e)
		{
			_packUserFocused = true;
		}

		private void OnOrderCbxSelectionChanged(object sender, EventArgs e)
		{
			if (orderCbx.SelectedItem != null && orderCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selectedOrder = (KeyValuePair<string, string>)orderCbx.SelectedItem;

				string[] fields = selectedOrder.Value.Split(':');
				if (fields.Length > 1)
				{
					_selectOrderName = fields[1];
				}
				RefreshDataGrid(selectedOrder.Key);
			}
		}

		private void RefreshDataGrid(string selectOrderKey)
		{
			try
			{
				dataGrid.Rows.Clear();
				string[] fields = selectOrderKey.Split(':');
				SortedList condition = new SortedList();
				condition.Add(1, fields[0]);
				condition.Add(2, CnasBaseData.SystemID);
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-bcct-data-sec001", condition);
				DataTable data = remoteCall.RemotInterface.SelectData("HCS-bcct-data-sec001", condition);
				if (data != null)
				{
					string location = string.Empty;
					foreach (KeyValuePair<string, string> item in uselocationCbx.Items)
					{
						if (item.Key == fields[1])
						 {
							 location = item.Value;
							 break;
						 }
					}

					foreach (DataRow row in data.Rows)
					{
						int index = dataGrid.Rows.Add();
						int expireDates = 7;
						DateTime createDate = DateTime.Now;
						if (data.Columns.Contains("id") && row["id"] != null) dataGrid.Rows[index].Cells["idCol"].Value = row["id"];
						if (data.Columns.Contains("bar_code") && row["bar_code"] != null) dataGrid.Rows[index].Cells["tempCodeCol"].Value = row["bar_code"];
						if (data.Columns.Contains("ca_name") && row["ca_name"] != null) dataGrid.Rows[index].Cells["setNameCol"].Value = row["ca_name"];  
						if (data.Columns.Contains("sequenceid")) dataGrid.Rows[index].Cells["batchCol"].Value = row["sequenceid"];

						dataGrid.Rows[index].Cells["useLocationCol"].Value = location;
						if (data.Columns.Contains("cre_date"))
						{
							createDate = Convert.ToDateTime(row["cre_date"]);
							dataGrid.Rows[index].Cells["creDateCol"].Value = createDate;
							if (data.Columns.Contains("ca_expiration"))
							{
								expireDates = Convert.ToInt32(row["ca_expiration"]);
								dataGrid.Rows[index].Cells["expireDateCol"].Value = createDate.AddDays(expireDates);
							}
						}
						if (data.Columns.Contains("BCU_code")) dataGrid.Rows[index].Cells["pbCodeCol"].Value = row["BCU_code"];
					}

					if (dataGrid.RowCount > 0)
					{
						packUserTxt.Text = Convert.ToString(data.Rows[0]["packUserName"]);
						cfmUserTxt.Text = Convert.ToString(data.Rows[0]["cfmUserName"]);
						packUserTxt.Tag = Convert.ToString(data.Rows[0]["user_id"]);
						cfmUserTxt.Tag = Convert.ToString(data.Rows[0]["cfm_userid"]);
					}

					genNumTxt.Text = dataGrid.RowCount.ToString();
					genNumTxt.ReadOnly = true;
					_isGenerated = true;
				}
				else
				{
					InitializeGenNum();
					
					_isGenerated = false;
					_isCommited = false;
				}
			}
			catch (Exception)
			{
			}
			

		}

		private void InitializeGenNum()
		{
			if (isSplitCbx.SelectedItem == null || packageTypeCbx.SelectedItem == null)
				return;
			dataGrid.Rows.Clear();
			KeyValuePair<string, string> isSplitCbxSelection = (KeyValuePair<string, string>)isSplitCbx.SelectedItem;
			KeyValuePair<string, string> packageTypeCbxSelection = (KeyValuePair<string, string>)packageTypeCbx.SelectedItem;
			if (isSplitCbxSelection.Key == "1")
			{
				
				genNumTxt.Text = "1";
				genNumTxt.ReadOnly = packageTypeCbxSelection.Key == "2";
			}
			else
			{
				genNumTxt.ReadOnly = false;
				genNumTxt.Text = "2";
			}
		}

		private void SetLocationCbx(string key)
		{
			for (int i = 0; i < uselocationCbx.Items.Count; i++)
			{
				if (uselocationCbx.Items[i] is KeyValuePair<string, string>)
				{
					KeyValuePair<string, string> item = (KeyValuePair<string, string>)uselocationCbx.Items[i];
					if (item.Key == key)
					{
						uselocationCbx.SelectedIndex = i;
						break;
					}
				}
			}
		}



		private void OnCustomerCbxSelectionChanged(object sender, EventArgs e)
		{
			InitializeUseLocationCbx();
		}

		private void OnMaterialCbxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (materialCbx.SelectedItem != null && materialCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)materialCbx.SelectedItem;
				string[] info = selectedItem.Key.Split(':');
				if (info.Length > 1)
				{
					expireDateTxt.Text = info[1];
				}
			}
		}

		private void OnUseLocationChanged(object sender, EventArgs e)
		{
			if (batchBCUR.Checked)
			{
				InitalizeOrderCbx();
			}
		}

		private void OnPackageTypeSelectioChanged(object sender, EventArgs e)
		{
			SetViewState();
			InitializeGenNum();
		}

		private void OnSelectionSplitSetSelectionChanged(object sender, EventArgs e)
		{
			if (isSplitCbx.SelectedItem != null && isSplitCbx.SelectedItem is KeyValuePair<string, string>
				&& packageTypeCbx.Items.Count > 0 && packageTypeCbx.Items[0] is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> selection = (KeyValuePair<string, string>)isSplitCbx.SelectedItem;
				KeyValuePair<string, string> packageTypeFistItem = (KeyValuePair<string, string>)packageTypeCbx.Items[0];

				if (selection.Key == "1")
				{
					genNumLbl.Text = "生成数量：";
					InitializePackageTypeCbx();
					//if (packageTypeFistItem.Key == "1")
					//{
					//	packageTypeCbx.Items.Remove(packageTypeFistItem);
					//}
				}
				else
				{
					genNumLbl.Text = "子包数量：";
					if (packageTypeFistItem.Key == "0")
					{
						packageTypeCbx.Items.Remove(packageTypeFistItem);
						packageTypeCbx.SelectedIndex = 0;
					}
				}
			}

			InitializeGenNum();
		}
	}
}
