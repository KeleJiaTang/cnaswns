using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	/// <summary>
	/// 器械包备注信息窗口
	/// </summary>
	public partial class HCSSM_set_message_new : BaseForm
	{
		/// <summary>
		/// 窗口打开模式 -- 1=添加， 2=修改， 其余=查看
		/// </summary>
		private int _openMode = 0;
		private string _noteProcedures = string.Empty;

		/// <summary>
		/// 窗口打开模式 -- 1=添加， 2=修改， 其余=查看
		/// </summary>
		public int OpenMode
		{
			get
			{
				return _openMode;
			}
			set
			{
				if (value != _openMode)
					_openMode = value;
			}
		}

		/// <summary>
		/// 器械包条码
		/// </summary>
		public string PackageBarCode { get; set; }

		/// <summary>
		/// 使用者的信息条
		/// </summary>
		public string UserBarCode { get; set; }

		public int MessageId { get; set; }

		/// <summary>
		/// 器械包备注信息窗口
		/// </summary>
		/// <param name="parent">该窗口的父窗口</param>
		private HCSSM_set_message_new(BaseForm parent)
			: base(parent)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public override void InitializeButtonImage()
		{
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
		}

		/// <summary>
		/// 器械包备注信息窗口
		/// </summary>
		/// <param name="pdCode">窗口所在流程编号</param>
		private HCSSM_set_message_new(string pdCode)
			: base(pdCode)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		/// <summary>
		/// 器械包备注信息窗口
		/// </summary>
		/// <param name="openMode">窗口打开模式</param>
		/// <param name="parent">该窗口的父窗口</param>
		public HCSSM_set_message_new(int openMode, BaseForm parent)
			: this(parent)
		{
			this._openMode = openMode;
		}

		/// <summary>
		/// 器械包备注信息窗口
		/// </summary>
		/// <param name="openMode">窗口打开方式</param>
		/// <param name="pdCode">窗口所在流程编号</param>
		public HCSSM_set_message_new(int openMode, string pdCode)
			: this(pdCode)
		{
			this._openMode = openMode;
		}

		/// <summary>
		/// 器械包备注信息窗口
		/// </summary>
		public HCSSM_set_message_new()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		/// <summary>
		/// 初始化窗口控件 -- 在Load事件中加载
		/// </summary>
		public override void InitalizeControl()
		{
			base.InitalizeControl();
			SetFormTitle();
			SetComboboxesItems();

			InitalizePackageInfo();
			InitalizeUserInfo();
			InitalizeMessageInfo();

			bool canWrite = (_openMode == 1 || _openMode == 2);
			subjectTxt.ReadOnly = canWrite ? false : true;
			descriptionTxt.ReadOnly = canWrite ? false : true;

			messageTypeCbx.Enabled = canWrite ? true : false;
			priortyCbx.Enabled = canWrite ? true : false;
			startDatePak.Enabled = canWrite ? true : false;
			endDatePak.Enabled = canWrite ? true : false;
            messageTypeCbx.SelectedIndexChanged += messageTypeCbx_SelectedIndexChanged;

			BarCodeHolder.BarCodeEvent += BarCodeHolder_BarCodeEvent;

		}

		private void BarCodeHolder_BarCodeEvent(BarCodeHook.BarCodes barCode)
		
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);

			if (matchBarCode.StartsWith("BCB"))
			{
				//userNameTxt.Focus();
				GetUserByBarCode(matchBarCode);
				InitalizeUserInfo();
			}
		}

        /// <summary>
        /// 设置提醒节点都选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void messageTypeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox com = sender as ComboBox;
            if (com != null)
            {
                try
                {
                    KeyValuePair<string, string> item = (KeyValuePair<string, string>)com.SelectedItem;
                    if(item.Key.Equals("2"))
                    {
                        for(int i=0;i<locationPanel.Controls.Count;i++)
                        {
                            if (locationPanel.Controls[i].GetType() == typeof(CheckBox))
                            {
                                CheckBox cbx = locationPanel.Controls[i] as CheckBox;
                                if(cbx!=null)
                                {
                                    cbx.Checked = true;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

		/// <summary>
		/// 加载界面数据
		/// </summary>
		public override void LoadData()
		{
			if (!string.IsNullOrEmpty(PackageBarCode) && !ViewData.ContainsKey("PackageInfo"))
			{
				SortedList condition = new SortedList();
				condition.Add(1, PackageBarCode);

				DBServer server = new DBServer();
				Dictionary<string, string> packageInfo = server.GetPackageByBarCode(PackageBarCode);
				ViewData.Add("PackageInfo", packageInfo);
			}

			if (!string.IsNullOrEmpty(UserBarCode))
				GetUserByBarCode(UserBarCode);

			if (MessageId != 0)
				GetMessageInfoById(MessageId);
		}

		/// <summary>
		/// 初始化用户的控件
		/// </summary>
		private void InitalizeUserInfo()
		{
			if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
			{
				UserBase userInfo = ViewData["UserInfo"] as UserBase;
				//userNameTxt.Text = userInfo.UserName;
			}
			//else
				//userNameTxt.Text = CnasBaseData.UserBaseInfo.UserName;
		}

		/// <summary>
		/// 初始化器械包的控件
		/// </summary>
		private void InitalizePackageInfo()
		{
			if (ViewData.ContainsKey("PackageInfo") && ViewData["PackageInfo"] != null)
			{
				Dictionary<string, string> packageInfo = ViewData["PackageInfo"] as Dictionary<string, string>;
 
				if (packageInfo.ContainsKey("bar_code")) paBarCodeTxt.Text = packageInfo["bar_code"];
				if (packageInfo.ContainsKey("ca_name")) paNameTxt.Text = packageInfo["ca_name"];
			}
			else
			{
				MessageBox.Show("无法初始化器械包信息。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 根据信息Id查询器械包备注信息
		/// </summary>
		private void GetMessageInfoById(int messageId)
		{
			SortedList condition = new SortedList();
			condition.Add(1, messageId);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-procedure-info-config-sec003", condition);
			if (data != null)
			{
				Dictionary<string, string> messageInfo = new Dictionary<string, string>();
				if (data.Rows != null && data.Rows.Count > 0)
				{
					DataRow row = data.Rows[0] as DataRow;
					if (row["id"] != null) messageInfo.Add("id", row["id"].ToString());
					if (row["set_id"] != null) messageInfo.Add("set_id", row["set_id"].ToString());
					if (row["subject"] != null) messageInfo.Add("subject", row["subject"].ToString());
					if (row["message_type"] != null) messageInfo.Add("message_type", row["message_type"].ToString());
					if (row["message_priorty"] != null) messageInfo.Add("message_priorty", row["message_priorty"].ToString());
					if (row["note_procedure"] != null) messageInfo.Add("note_procedure", row["note_procedure"].ToString());
					if (row["start_date"] != null) messageInfo.Add("start_date", row["start_date"].ToString());
					if (row["end_date"] != null) messageInfo.Add("end_date", row["end_date"].ToString());
					if (row["description"] != null) messageInfo.Add("description", row["description"].ToString());
					if (row["state"] != null) messageInfo.Add("state", row["state"].ToString());
					if (row["cre_user"] != null) messageInfo.Add("cre_user", row["cre_user"].ToString());
					if (row["cre_date"] != null) messageInfo.Add("cre_date", row["cre_date"].ToString());
					if (row["mod_user"] != null) messageInfo.Add("mod_user", row["mod_user"].ToString());
					if (row["mod_date"] != null) messageInfo.Add("mod_date", row["mod_date"].ToString());
					if (row["version"] != null) messageInfo.Add("version", row["version"].ToString());
					if (row["write_procedure"] != null) messageInfo.Add("write_procedure", row["write_procedure"].ToString());
				}

				if (ViewData.ContainsKey("MessageInfo"))
				{
					ViewData["MessageInfo"] = messageInfo;
				}
				else
				{
					ViewData.Add("MessageInfo", messageInfo);
				}
			}
		}

		/// <summary>
		/// 初始化器械包备注信息
		/// </summary>
		private void InitalizeMessageInfo()
		{
			string writeProcedure = PdCode;
			if (ViewData.ContainsKey("MessageInfo"))
			{
				Dictionary<string, string> messageInfo = ViewData["MessageInfo"] as Dictionary<string, string>;
				if (messageInfo.ContainsKey("subject")) subjectTxt.Text = messageInfo["subject"];
				if (messageInfo.ContainsKey("message_type")) messageTypeCbx.SelectedIndex =GetComboboxSelectIndex(messageTypeCbx,messageInfo["message_type"]);
				if (messageInfo.ContainsKey("message_priorty")) priortyCbx.SelectedIndex = GetComboboxSelectIndex(priortyCbx, messageInfo["message_priorty"]); ;
				if (messageInfo.ContainsKey("note_procedure")) _noteProcedures = messageInfo["note_procedure"];
				if (messageInfo.ContainsKey("start_date")) startDatePak.Text = messageInfo["start_date"];
				endDatePak.Text = messageInfo.ContainsKey("end_date") && !string.IsNullOrEmpty(messageInfo["end_date"]) ? messageInfo["end_date"] : string.Empty;
				endDatePak.Checked = messageInfo.ContainsKey("end_date") && !string.IsNullOrEmpty(messageInfo["end_date"]) ? true : false;
				if (messageInfo.ContainsKey("description")) descriptionTxt.Text = messageInfo["description"];
				if (messageInfo.ContainsKey("write_procedure") && PdCode != messageInfo["write_procedure"]) writeProcedure = messageInfo["write_procedure"];
			}
			else if (OpenMode != 1)
			{
				MessageBox.Show("无法初始化器械包备注信息。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			SetLocationChoice(GetConfigList(writeProcedure));
		}

		/// <summary>
		/// 根据用户条形码查询用户
		/// </summary>
		/// <param name="userBarCode">用户条形码</param>
		public void GetUserByBarCode(string userBarCode)
		{
			UserBase userInfo = UserBaseHelper.GetUserByBarCode(userBarCode);
			if (!ViewData.ContainsKey("UserInfo"))
				ViewData.Add("UserInfo", userInfo);
			else
				ViewData["UserInfo"] = userInfo; 
		}

		/// <summary>
		/// 验证窗口的输入是否合法， 如果不合法，返回不合法信息；如果合法，空信息。
		/// </summary>
		/// <returns>验证结果</returns>
		private string ValidationData()
		{
			string validateResult = string.Empty;

			if (string.IsNullOrEmpty(subjectTxt.Text))
			{
				validateResult = "请输入信息主题";
			}
			else if (endDatePak.Checked && startDatePak.Value >= endDatePak.Value)
			{
				validateResult = "请确认开始时间大于结束时间";
			}
			else 
			{
                int j = 0, cj = 0;
				_noteProcedures = string.Empty;
				foreach (var control in locationPanel.Controls)
				{
					CheckBox locationCbx = control as CheckBox;
					if (locationCbx != null)
					{
                        j++;
                        if (locationCbx.Checked)
                        {
                            cj++;
                            _noteProcedures += string.Format("{0},", locationCbx.Name);
                        }
					}
				}
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)messageTypeCbx.SelectedItem;
                if (item.Key.Equals("2")&&j!=cj)
                {
                    validateResult = "请选择所有信息提醒地点";
                }
				if (string.IsNullOrEmpty(_noteProcedures))
					validateResult = "请选择信息提醒地点";
			}

			return validateResult;
		}

		/// <summary>
		/// 获取所有的流程信息
		/// </summary>
		/// <returns>流程信息列表</returns>
		private SortedList GetAllProcedures()
		{
			SortedList procedures = new SortedList();
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-procedure-sec002", null);
			if (data != null)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					Dictionary<string, string> item = new Dictionary<string, string>();
					DataRow row = data.Rows[i] as DataRow;
					if (row["id"] != null) item.Add("id", row["id"].ToString());
					if (row["pd_code"] != null) item.Add("pd_code", row["pd_code"].ToString());
					if (row["pd_bcode"] != null) item.Add("pd_bcode", row["pd_bcode"].ToString());
					if (row["pd_name"] != null) item.Add("pd_name", row["pd_name"].ToString());
					if (row["pd_scan"] != null) item.Add("pd_scan", row["pd_scan"].ToString());
					if (row["pd_description"] != null) item.Add("pd_description", row["pd_description"].ToString());
					if (row["pd_Type"] != null) item.Add("pd_Type", row["pd_Type"].ToString());
					if (row["state"] != null) item.Add("state", row["state"].ToString());
					if (row["split_count"] != null) item.Add("split_count", row["split_count"].ToString());
					if (row["cyc_location"] != null) item.Add("cyc_location", row["cyc_location"].ToString());
					if (row["si_id"] != null) item.Add("si_id", row["si_id"].ToString());
					procedures.Add(i, item);
				}
			}

			return procedures; 
		}

		/// <summary>
		/// 根据流程号获取配置信息
		/// </summary>
		/// <param name="pdCode">procedure code</param>
		/// <returns>config in table ca-procedure-info-config</returns>
		private SortedList GetConfigList(string pdCode)
		{
			SortedList result = new SortedList();
			SortedList condition = new SortedList();
			condition.Add(1, pdCode);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-procedure-info-config-sec001", condition);
			if (data != null)
			{
				string defaultPdCode = string.Empty;
				string choicePdCode = string.Empty;
				for (int i = 0; i < data.Rows.Count; i++)
				{
					if (data.Rows[i]["default_pd_code"] != null) defaultPdCode += ("," + data.Rows[i]["default_pd_code"].ToString());
					if (data.Rows[i]["choos_pd_code"] != null) choicePdCode = ("," + data.Rows[i]["choos_pd_code"].ToString());
				}
				result.Add("default_pd_code", defaultPdCode);
				result.Add("choos_pd_code", choicePdCode);
			}

			return result;
			
		}

		/// <summary>
		/// 设置窗口的题目
		/// </summary>
		private void SetFormTitle()
		{
			if (OpenMode == 1)
			{
				this.Text = "添加器械包备注信息";
			}
			else if(OpenMode ==2)
			{
				this.Text = "修改器械包备注信息";
			}
			else
			{
				this.Text = "查看器械包备注信息";
			}
		}

		/// <summary>
		/// 设置ComboBox的选项
		/// </summary>
		private void SetComboboxesItems()
		{
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS_message_type' or type_code = 'HCS_message_priorty_type'");
			if (data != null && data.Length > 0)
			{
				string selectPriorty = string.Empty;
				foreach (DataRow item in data)
				{
					if (item["type_code"] != null)
					{
						ComboBox targetBox = null;
						if (item["type_code"].ToString() == "HCS_message_type")
						{
							targetBox = messageTypeCbx;
						}
						else if (item["type_code"].ToString() == "HCS_message_priorty_type")
						{
							targetBox = priortyCbx;
						}

						KeyValuePair<string, string> comboboxItem = new KeyValuePair<string, string>(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
						targetBox.Items.Add(comboboxItem);
						targetBox.SelectedIndex = 0;
					}
				}
			}
		}

		/// <summary>
		/// 设置提醒点
		/// </summary>
		/// <param name="config">the config in table ca_procedure_info_config</param>
		private void SetLocationChoice(SortedList config)
		{
			if (config != null)
			{
				List<string> selectedLocation = null;
				_noteProcedures = ((OpenMode == 1) && config["default_pd_code"] != null) ? config["default_pd_code"].ToString() : _noteProcedures;
				selectedLocation = _noteProcedures.Split(',').ToList();

				if (config["choos_pd_code"] != null)
				{
					string[] locations = config["choos_pd_code"].ToString().Split(',');
					if (locations.Length > 0)
					{
						int checkHeight = 0;
						Padding checkMargin = new Padding(0,0,0,0);
						int locationItem = 0;

						foreach (string location in locations)
						{
							string pdDescription = ProcedureData.Instance.GetProcedureDesciption(location);
							if (!string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(pdDescription))
							{
								CheckBox locationCkb = new CheckBox();
								locationCkb.Checked = selectedLocation != null &&
								selectedLocation.Count > 0 && selectedLocation.Contains(location);
								locationCkb.Name = location;
								locationCkb.Text = pdDescription;
								locationCkb.Enabled = (_openMode == 1 || _openMode == 2) ? true : false;
								locationPanel.Controls.Add(locationCkb);
								checkMargin = locationCkb.Margin;
								checkHeight = locationCkb.Height;
								locationCkb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
								locationPanel.SetRow(locationCkb, locationItem);
								locationPanel.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.AutoSize));
								locationItem++;
							}
						}
						locationPanel.Height = (checkHeight + checkMargin.Top + checkMargin.Bottom) * locationItem;
					}
				}
				else
				{
					locationPanel.Height = 28;
				}
			}
		}

		/// <summary>
		/// 根据流程编号获取Checkbox的内容
		/// </summary>
		/// <param name="pdCode">procedure code</param>
		/// <returns>checkbox text</returns>
		private string GetCheckBoxText(string pdCode)
		{
			string result = string.Empty;

			for (int i = 0; i < ProcedureData.Instance.Procedures.Count; i++)
			{
				Dictionary<string, string> procedure = ProcedureData.Instance.Procedures[i] as Dictionary<string, string>;
				if (procedure.ContainsKey("pd_code") && procedure.ContainsKey("pd_description")
					&& pdCode == procedure["pd_code"])
				{
					result = procedure["pd_description"];
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Confirm button event
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event</param>
		private void confirmBtn_Click(object sender, EventArgs e)
		{
			if (_openMode == 1 || _openMode == 2)
			{
				string validateResult = ValidationData();
				if (string.IsNullOrEmpty(validateResult))
				{
					SortedList sqlParam = new SortedList();
					SortedList itemList = new SortedList();
					sqlParam.Add(1, itemList);
					string sqlCommand = string.Empty;
					itemList.Add(1, subjectTxt.Text.TrimStart().TrimEnd());
					itemList.Add(2, Convert.ToInt16(((KeyValuePair<string, string>)messageTypeCbx.SelectedItem).Key));
					itemList.Add(3, Convert.ToInt16(((KeyValuePair<string, string>)priortyCbx.SelectedItem).Key));
					itemList.Add(4, _noteProcedures);
					itemList.Add(5, startDatePak.Value);
					itemList.Add(6, endDatePak.Checked ? 1 : 0);
					itemList.Add(7, endDatePak.Text);
					itemList.Add(8, descriptionTxt.Text);
					itemList.Add(9, 1); // state // CreateDate
					

					if (ViewData.ContainsKey("PackageInfo"))
					{
						Dictionary<string, string> packageInfo = ViewData["PackageInfo"] as Dictionary<string, string>;
						if (packageInfo.ContainsKey("id")) itemList.Add(10, Convert.ToInt16(packageInfo["id"]));
					}
					else
					{
						itemList.Add(10, 1);
					}

					if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
					{
						UserBase userInfo = ViewData["UserInfo"] as UserBase;
						itemList.Add(11, userInfo.UserID);
					}
					else
					{
						itemList.Add(11, CnasBaseData.UserBaseInfo.UserID);
					}

					if (_openMode == 1)
					{
						sqlCommand = "HCS-procedure-info-config-add001";
                        itemList.Add(12, PdCode); //write_procedure
						itemList.Add(13, paBarCodeTxt.Text);
					}
					else if (_openMode == 2)
					{
						sqlCommand = "HCS-procedure-info-config-up001";
						if (ViewData.ContainsKey("MessageInfo"))
						{
							Dictionary<string, string> messageInfo = ViewData["MessageInfo"] as Dictionary<string, string>;
							itemList.Add(12, messageInfo.ContainsKey("id") ? Convert.ToInt16(messageInfo["id"]) : 1);
						}
						else
						{
							itemList.Add(12, 0);
						}
					}
					try
					{
						if (!string.IsNullOrEmpty(sqlCommand))
						{
							string testSql = RemoteClient.RemotInterface.CheckUPData(1, sqlCommand, sqlParam, null);
							int result = RemoteClient.RemotInterface.UPData(1, sqlCommand, sqlParam, null);
							if (result > -1)
							{
								MessageBox.Show(string.Format("恭喜你，{0}成功。", this.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
								this.Close();
							}
							else
							{
								MessageBox.Show("保存失败，请验证你所输入的内容。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("出现未知错误：" + ex.Message + ",请联系管理员。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show(validateResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				this.Close();
			}
		}

		/// <summary>
		/// Cancel button event
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event</param>
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 根据值造出combobox的selectIndex
		/// </summary>
		/// <param name="box">Combobox</param>
		/// <param name="value">值</param>
		/// <returns>selectIndex</returns>
		private int GetComboboxSelectIndex(ComboBox box, string value)
		{
			int index = 0;
			if (box != null && box.Items != null && !string.IsNullOrEmpty(value))
			{
				foreach (var item in box.Items)
				{
					KeyValuePair<string, string> boxItem = (KeyValuePair<string, string>)item;

					if ( boxItem.Key == value)
						index = box.Items.IndexOf(item);
				}
			}
			return index;
		}

	}

}
