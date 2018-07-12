using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSManagerUC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_set_message_manager : UserControl
    {
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
		/// <summary>
		/// 服务端
		/// </summary>
		private CnasRemotCall _remoteClient = null;
		/// <summary>
		/// 窗口数据
		/// </summary>
		public SortedList ViewData
		{
			get
			{
				if (_viewData == null)
					_viewData = new SortedList();
				return _viewData;
			}
			set
			{
				if (value != _viewData)
					_viewData = value;
			}
		}
		/// <summary>
		/// 窗口数据
		/// </summary>
		private SortedList _viewData = new SortedList();
		/// <summary>
		/// 用户扫码
		/// </summary>
        public string User_bCode { get { return _user_bCode; } set { if (value != _user_bCode) _user_bCode = value; } }
        /// <summary>
        /// 用户扫码
        /// </summary>
        private string _user_bCode;

        /// <summary>
        /// HCSSM_set_message_manager初始化
        /// </summary>
        public HCSSM_set_message_manager()
        {
            InitializeComponent();
			InitalizeControlData();
			InitializeButtonImage();
        }
		/// <summary>
		/// HCSSM_set_message_manager初始化
		/// </summary>
		public HCSSM_set_message_manager(string userCode)
		{
			this.User_bCode = userCode;
			InitializeComponent();
			InitalizeControlData();
			InitializeButtonImage();
		}

		private void InitializeButtonImage()
		{
			btnEdit.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mModify32", EnumImageType.PNG);
			btnEnabled.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mStopWarning32", EnumImageType.PNG);
			btnDel.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			btnPri.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch16", EnumImageType.PNG);
		}

        /// <summary>
        /// 初始化窗口控件 -- 在Load事件中加载
        /// </summary>
        public void InitalizeControlData()
        {
            //SetFormTitle();
            SetComboboxesItems();
            Loaddata();
            //BarCodeHolder.BarCodeEvent += BarCodeHolder_BarCodeEvent;
            //base.InitalizeControl();
        }

        /// <summary>
        /// 选择行发生改变时要处理的事项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgv_01_SelectionChanged(object sender, EventArgs e)
        {
            btnEnabled.Enabled = dgv_01.SelectedRows != null;
            if(dgv_01.SelectedRows!=null && dgv_01.SelectedRows.Count > 0 
				&& dgv_01.SelectedRows[0].Cells["state"] != null)
            {
                 string stateTemp = dgv_01.SelectedRows[0].Cells["state"].Value == null ? "" : dgv_01.SelectedRows[0].Cells["state"].Value.ToString();
                 if (stateTemp.Equals("1"))
                 {
                     btnEnabled.Text = "禁用提醒";
                 }
                 else if (stateTemp.Equals("2"))
                 {
                     btnEnabled.Text = "启用提醒";
                 }
            }
        }

        /// <summary>
        /// 禁用，启用btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEnabled_Click(object sender, EventArgs e)
        {
            Button btn=sender as Button;
			if (btn != null && dgv_01.SelectedRows != null)
            {
                if (btn.Text == "禁用提醒")
                {
                    // todo it 2=state
                    try
                    {
                        if (MessageBox.Show("确定禁用包名为： " + dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() + " 的提醒？", "禁用包的提醒信息", MessageBoxButtons.YesNo) == DialogResult.No) return;

                        SortedList sltmp = new SortedList();
                        SortedList sltmp01 = new SortedList();
                        sltmp01.Add(1, 2);
						if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
						{
							UserBase userInfo = ViewData["UserInfo"] as UserBase;
							sltmp01.Add(2, userInfo.UserID);
						}
						else
						{
							sltmp01.Add(2, CnasBaseData.UserBaseInfo.UserID);
						}
                        sltmp01.Add(3, dgv_01.SelectedRows[0].Cells["id"].Value);


                        sltmp.Add(1, sltmp01);
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-message-info-show-up001", sltmp, null);
                        if (recint > -1)
                        {
                            MessageBox.Show("恭喜你，禁用包的提醒成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loaddata();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("请选择有效行数据进行禁止操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (btn.Text == "启用提醒")
                {
                    // todo it 1=state
                    try
                    {
                        if (MessageBox.Show("确定启用包名为： " + dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() + " 的提醒？", "启用包的提醒信息", MessageBoxButtons.YesNo) == DialogResult.No) return;

                        SortedList sltmp = new SortedList();
                        SortedList sltmp01 = new SortedList();
                        sltmp01.Add(1, 1);
						if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
						{
							UserBase userInfo = ViewData["UserInfo"] as UserBase;
							sltmp01.Add(2, userInfo.UserID);
						}
						else
						{
							sltmp01.Add(2, CnasBaseData.UserBaseInfo.UserID);
						}
                        sltmp01.Add(3, dgv_01.SelectedRows[0].Cells["id"].Value);
                        sltmp.Add(1, sltmp01);
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-message-info-show-up001", sltmp, null);
                        if (recint > -1)
                        {
                            MessageBox.Show("恭喜你，启用包的提醒成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loaddata();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("请选择有效行数据进行启动操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 响应编辑操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_Click(object sender, EventArgs e)
        {
            //数据准备
			try
			{
				if (dgv_01.CurrentRow != null && dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0)
				{
					HCSSM_set_message_new modifiedDialog = new HCSSM_set_message_new(2, dgv_01.SelectedRows[0].Cells["write_procedure"].Value.ToString());
					modifiedDialog.PackageBarCode = dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString();
					modifiedDialog.UserBarCode = User_bCode;
					modifiedDialog.MessageId = int.Parse(dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
					modifiedDialog.ShowDialog();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "器械包信息" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        /// <summary>
        /// 响应删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除包名为： " + dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() + " 包的提醒信息？", "删除包的提醒信息", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, 9);
				if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
				{
					UserBase userInfo = ViewData["UserInfo"] as UserBase;
					sltmp01.Add(2, userInfo.UserID);
				}
				else
				{
					sltmp01.Add(2, CnasBaseData.UserBaseInfo.UserID);
				}
                sltmp01.Add(3, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-message-info-show-up001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，删除包的提醒信息成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loaddata();
                }
            }
            catch
            {
                MessageBox.Show("请选择有效行数据进行删除操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 响应查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            //nothings
            Loaddata();
        }

        /// <summary>
        /// 用户编码
        /// </summary>
        /// <param name="cu_barcode"></param>
        private void Loaddata()
        {
            if(userCodeBar.Text.Trim()!=""&&userCodeBar.Text.Trim()!=User_bCode)
            {
                User_bCode = userCodeBar.Text.Trim();
            }
            else
            {
                userCodeBar.Text = User_bCode;
            }
            //获取 selectItem
            Dictionary<string, string> dicMessageType = GetComboBoxItem(messageTypeCbx);
            Dictionary<string, string> dicMessageLevel = GetComboBoxItem(MessageLevelCbx);
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList condition = new SortedList();
            DataTable getdt = null;
            SetCondition(condition);
			string testSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-message-info-show-sec002", condition);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-message-info-show-sec002", condition);
            if (getdt != null)
            {
				foreach (DataRow item in getdt.Rows)
				{
					int rowIndex = dgv_01.Rows.Add();
					if (getdt.Columns.Contains("id") && item["id"] != null) dgv_01.Rows[rowIndex].Cells["id"].Value = item["id"].ToString();//编码
					if (getdt.Columns.Contains("bar_code") && item["bar_code"] != null) dgv_01.Rows[rowIndex].Cells["bar_code"].Value = item["bar_code"].ToString();//条形码
					if (getdt.Columns.Contains("ca_name") && item["ca_name"] != null) dgv_01.Rows[rowIndex].Cells["ca_name"].Value = item["ca_name"].ToString();//包
					if (getdt.Columns.Contains("subject") && item["subject"] != null) dgv_01.Rows[rowIndex].Cells["subject"].Value = item["subject"].ToString();//主题
					if (getdt.Columns.Contains("description") && item["description"] != null) dgv_01.Rows[rowIndex].Cells["description"].Value = item["description"].ToString();//备注
					if (getdt.Columns.Contains("message_type") && item["message_type"] != null) dgv_01.Rows[rowIndex].Cells["message_type"].Value = GetEnumValue(dicMessageType, item["message_type"].ToString());//消息类型暂未作转化
					if (getdt.Columns.Contains("message_priorty") && item["message_priorty"] != null)
					{
						dgv_01.Rows[rowIndex].Cells["message_priorty"].Style.BackColor = GetCellStyle(GetCellType(item["message_priorty"].ToString())); 
						dgv_01.Rows[rowIndex].Cells["message_priorty"].Value = GetEnumValue(dicMessageLevel, item["message_priorty"].ToString());//消息优先级别
					}
					if (getdt.Columns.Contains("start_date") && item["start_date"] != null) dgv_01.Rows[rowIndex].Cells["start_date"].Value = item["start_date"];//提醒开始时间
					if (getdt.Columns.Contains("end_date") && item["end_date"] != null) dgv_01.Rows[rowIndex].Cells["end_date"].Value = item["end_date"];//提醒结束时间
					if (getdt.Columns.Contains("note_procedure") && item["note_procedure"] != null) dgv_01.Rows[rowIndex].Cells["note_procedure"].Value = GetNoteProduce(item["note_procedure"].ToString());//流程节点
					if (getdt.Columns.Contains("cre_date") && item["cre_date"] != null) dgv_01.Rows[rowIndex].Cells["cre_date"].Value = item["cre_date"];//创建时间
					if (getdt.Columns.Contains("mod_date") && item["mod_date"] != null) dgv_01.Rows[rowIndex].Cells["mod_date"].Value = item["mod_date"];//修改时间
					if (getdt.Columns.Contains("write_procedure") && item["write_procedure"] != null) dgv_01.Rows[rowIndex].Cells["write_procedure"].Value = item["write_procedure"].ToString();//修改时间
					if (getdt.Columns.Contains("state") && item["state"] != null) dgv_01.Rows[rowIndex].Cells["state"].Value = item["state"].ToString();
				}
            }
        }   

        /// <summary>
        /// 返回cell值  Type
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetCellType(string str)
        {
            int i = 0;
            if (str == "3")
                i = 1;
            else if (str == "2")
                i = 2;
            return i;
        }

        /// <summary>
        /// 根据响应的type返回类型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Color GetCellStyle(int i)
        {
            Color style=Color.White;
            switch(i)
            {
                case 1: { style = Color.Red; return style; } 
                case 2: { style = Color.Green; return style; }
                default: { return style; }
            }
        }
    
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="condition"></param>
        private void SetCondition(SortedList condition)
        {
            string messageTypeValue = GetComboBoxSelectValue(messageTypeCbx,1);
            string messageLevelValue = GetComboBoxSelectValue(MessageLevelCbx, 1);
            string hstcodeValue = barcodeTxt.Text.Trim();
            string messageSubjectValue = messageSubjectTxt.Text.Trim();
			string filter = string.Empty;

			string customerIds = string.Empty;
			foreach (DataRow customer in CnasBaseData.UserAccessCustomer.Rows)
			{
				string customerid = Convert.ToString(customer["id"]);
				customerIds += string.Format("{0},",customerid);
			}
			customerIds = customerIds.TrimEnd(',');
			customerIds = customerIds.Replace(",", "','");
			condition.Add(1, customerIds);

            if(hstcodeValue!="")
            {
				filter += string.Format(" and se.bar_code like '%{0}%' ", hstcodeValue);
            }
            if(messageLevelValue!=""&&messageLevelValue!="0")
            {
				filter += string.Format(" and me.message_priorty like '%{0}%' ", messageLevelValue);
            }
            if(messageTypeValue!=""&&messageTypeValue!="0")
            {
				filter += string.Format(" and me.message_type like '%{0}%' ", messageTypeValue);
            }
            if(messageSubjectValue!="")
            {
				filter += string.Format(" and me.subject like '%{0}%' ", messageSubjectValue);
            }
			condition.Add(2, filter);
        }

        /// <summary>
        /// 设置ComboBox的选项
        /// </summary>
        private void SetComboboxesItems()
        {
            DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS_message_type' or type_code = 'HCS_message_priorty_type'");
            string messageTypeValue = GetComboBoxSelectValue(messageTypeCbx, 1);
            string messageLevelValue = GetComboBoxSelectValue(MessageLevelCbx, 1);
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
                            targetBox = MessageLevelCbx;
                        }
                        KeyValuePair<string, string> comboboxItem = new KeyValuePair<string, string>(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
                        targetBox.Items.Add(comboboxItem);
                        targetBox.SelectedIndex = 0;
                    }
                }
                //设置选中项
                GetComboboxSelectIndex(messageTypeCbx, messageTypeValue);
				GetComboboxSelectIndex(MessageLevelCbx, messageLevelValue);
            }
        }

        /// <summary>
        /// 根据值造出combobox的selectIndex
        /// </summary>
        /// <param name="box">Combobox</param>
        /// <param name="value">值</param>
        /// <returns>selectIndex</returns>
        private void  GetComboboxSelectIndex(ComboBox box, string value)
        {
            if (box != null)
             {
                box.Items.Insert(0, new KeyValuePair<string, string> ("0","--所有--"));
                if (value != "")
                {
                    box.SelectedValue = value;
                }
                else
                {
                    box.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 返回selectBox的选中值或者text
        /// </summary>
        /// <param name="box">selectBox</param>
        /// <param name="type">1-selectvalue-2-selectText</param>
        /// <returns></returns>
        private string GetComboBoxSelectValue(ComboBox box, int type)
        {
            if (box.SelectedItem != null)
            {
                KeyValuePair<string, string> tempSelected = (KeyValuePair<string, string>)box.SelectedItem;
                if (type == 1)
                {
                    return tempSelected.Key;
                }
                else if (type == 2)
                {
                    return tempSelected.Value;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Item的 项值
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        private Dictionary<string,string> GetComboBoxItem(ComboBox box)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if(box!=null&&box.Items!=null)
            {
                foreach (var item in box.Items)
                {
                    KeyValuePair<string, string> boxItem = (KeyValuePair<string, string>)item;
                    if(!dic.ContainsKey(boxItem.Key))
                    {
                        dic.Add(boxItem.Key, boxItem.Value);
                    }
                }
            }
            return dic;
        }

        /// <summary>
        /// 获取所得到的枚举值
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetEnumValue(Dictionary<string,string> dic ,string key)
        {
            foreach(var item in dic)
            {
                if(item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return string.Empty;
        }

		/// <summary>
		/// 根据用户条形码查询用户
		/// </summary>
		/// <param name="userBarCode">用户条形码</param>
		private void GetUserByBarCode(string userBarCode)
		{
			UserBase userInfo = UserBaseHelper.GetUserByBarCode(userBarCode);
			if (!ViewData.ContainsKey("UserInfo"))
				ViewData.Add("UserInfo", userInfo);
			else
				ViewData["UserInfo"] = userInfo;
		}

        /// <summary>
        /// 获取提醒节点信息
        /// </summary>
        /// <param name="noteProduce"></param>
        /// <returns></returns>
        private string GetNoteProduce(string noteProduce)
        {
            string[] tempStr = noteProduce.TrimEnd(',').Split(',');
            string[] toStr;
            if (tempStr.Count() != 0)
            {
                toStr = new string[tempStr.Count()];
            }
            else
            {
                toStr = new string[1];
            }
            int j = 0;
			var tempDatas = GetProcedures();
            if (tempDatas != null)
            {
                foreach (var temp in tempStr)
                {
                    if (temp != "")
                    {
                        for (int i = 0; i < tempDatas.Count; i++)
                        {
                            var tempDic = tempDatas.GetByIndex(i);
                            Dictionary<string, string> dic = tempDic as Dictionary<string, string>;
                            if (dic != null)
                            {
                                bool isEqualId = false;
                                string tempOldStr = string.Empty;
                                foreach (var item in dic)
                                {
                                    if (item.Key.Equals("id") && item.Value.Equals(temp))
                                    {
                                        isEqualId = true;
                                    }
                                    if (item.Key.Equals("pd_description"))
                                    {
                                        tempOldStr = item.Value;
                                    }
                                }
                                if (isEqualId && !string.IsNullOrEmpty(tempOldStr))
                                {
                                    toStr[j] = tempOldStr;
                                    j++;
                                }
                            }
                        }
                    }
                }
            }
            return string.Join(",", toStr);
		}

		private SortedList GetProcedures()
		{
			CnasRemotCall RemoteClient = new CnasRemotCall();
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
		/// 打印
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPri_Click(object sender, EventArgs e)
		{
			DataGridView dataGrid = dgv_01;
			if (dataGrid != null&&dataGrid.Rows.Count>0)
			{
				//DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and value_code like '%{0},%'", PdCode));
				DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and key_code = 'defaultTemplate'"));
				if (data != null&&data.Length>0)
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

		private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			btnEdit_Click(null, null);
		}

    }
}
