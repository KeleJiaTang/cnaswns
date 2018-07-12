using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_entityset_manager_bindingRfid : TemplateForm
    {
        public bool IsShow = false;
        /// <summary>
        /// rfid获取
        /// </summary>
		private RFIDInterface rfidCode = null;
        /// <summary>
        /// 有效的rfid
        /// </summary>
        private Dictionary<string, string> _uRfid = new Dictionary<string, string>();
        /// <summary>
        /// 新增有用的rfid
        /// </summary>
        private Dictionary<string, string> _new_uRfid = new Dictionary<string, string>();
        /// <summary>
        /// 新增的rfid
        /// </summary>
        private Dictionary<string, string> _newRfid = new Dictionary<string, string>();
        /// <summary>
        /// 重复的RFID
        /// </summary>
        List<string> repeatRFID = new List<string>();

        DataTable repeatData = new DataTable();
        /// <summary>
        /// 实体包id
        /// </summary>
        string set_id = "";
        /// <summary>
        /// 手术器械id
        /// </summary>
        string instruments_id = "";
        /// <summary>
        /// 实体包条码
        /// </summary>
        string set_code = "";
        public SortedList Data { get; set; }

       //bool linkState

		/// <summary>
		/// 初始化类
		/// </summary>
		/// <returns></returns>
		private RFIDInterface Loadclass()
		{
			object result = null;
			Type typeofControl = null;
			Assembly tempAssembly;
			string temp_class_name = OrderHelper.GetValueCode("HCS-used-RFID-class-type", "ForUse");
			if(string.IsNullOrEmpty(temp_class_name))
			{
				return null;
			}
			tempAssembly = Assembly.LoadFrom("CnasRFIDManager.dll");
			string class_name = string.Format("Cnas.wns.CnasRFIDManager.{0}",temp_class_name);
			typeofControl = tempAssembly.GetType(class_name);
			if(typeofControl==null)
			{ return null; }
			result = Activator.CreateInstance(typeofControl);
			if (result == null) { return null; }
			return (RFIDInterface)result;
		}  

        public HCSCM_entityset_manager_bindingRfid(SortedList SLdata)
        {
            InitializeComponent();
            #region buttont图片加载
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.but_binding.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "reBind", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "removeBinding", EnumImageType.PNG);
            this.but_feelingEmpty.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "empty", EnumImageType.PNG);
            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--绑定RFID";
            //赋值并显示信息
            tb_setName.Text = SLdata["器械名称"].ToString();
            tb_iNumber.Text = SLdata["器械数量"].ToString();

            set_id = SLdata["实体包id"].ToString();
            instruments_id = SLdata["器械编号"].ToString();
            set_code = SLdata["实体包条码"].ToString();
			rfidCode = Loadclass();
			if (rfidCode != null)
			{
				rfidCode.GetNoneAddData += AddInstrumentData;
				rfidCode.Connecttion();
			}
            try
            {
                if (rfidCode==null||!rfidCode.IsStartScan)//判断有没有连接上RFID机器
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("reconnectRfid", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsShow = false;
                }
                else
                {
                    IsShow = true;
                    selBindingRFID();
                    //连接RFID
                    repeatData = LoadRepeatRfidTable();
                    repeatRFID = LoadRepeatRfid();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("reconnectRfid", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        /// <summary>
        /// 加载这个包，这把器械绑定关系表
        /// </summary>
        private DataTable LoadRepeatRfidTable()
        {
            //List<string> result = new List<string>();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            //string TEXT = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-rfid-mapping-sec001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-rfid-mapping-sec001", null);
            //if (getdt != null)
            //{
            //    for (int i = 0; i < getdt.Rows.Count; i++)
            //    {
            //        result.Add(getdt.Rows[i]["rfid"].ToString());
            //    }

            //}

            return getdt;
        }

        /// <summary>
        /// 加载已经有所有绑定关系的rfid
        /// </summary>
        private List<string> LoadRepeatRfid()
        {
            List<string> result = new List<string>();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            //string TEXT = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-rfid-mapping-sec001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-rfid-mapping-sec001", null);
            if (getdt != null)
            {
                for (int i = 0; i < getdt.Rows.Count; i++)
                {
                    result.Add(getdt.Rows[i]["rfid"].ToString());
                }

            }

            return result;
        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSCM_entityset_manager_bindingRfid_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 初始化新增的rfid
        /// </summary>
        /// <param name="dic"></param>
        private void InitNewRfidDataDic(Dictionary<string, string> dic)
        {
            if (dic != null && _uRfid != null)
            {
                List<string> keys = dic.Keys.ToList();
                for (int i = 0; i < keys.Count; i++)
                {
                    if (!_uRfid.ContainsKey(keys[i]) && !_newRfid.ContainsKey(keys[i]))
                    {
                        _newRfid.Add(keys[i], string.Empty);
                    }
                }
            }
        }
        /// <summary>
        /// 加载赋值已经绑定的数量
        /// </summary>
        /// <returns></returns>
        private void selBindingRFID()
        {
            string bindingNum = "";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, set_id);
            sltmp01.Add(2, instruments_id);
            //string TEXT = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-rfid-mapping-sec002", sltmp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-rfid-mapping-sec002", sltmp01);
            if (getdt != null)
                bindingNum = getdt.Rows[0]["sum"].ToString();
            tb_rNumber.Text = bindingNum;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dic"></param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		private void AddInstrumentData(Dictionary<string, string> dic, RFIDCommand cmd = RFIDCommand.Datas)
        {
			if (cmd != RFIDCommand.Datas) return;
            if (dic != null && dic.Count > 0 && IsShow)
            {
                this.BeginInvoke(new Action(() =>
                {

                    InitNewRfidDataDic(dic);

                    foreach (string key in _newRfid.Keys)
                    {
                        int repeat = 0;
                        for (int i = 0; i < dgv_01.RowCount; i++)
                        {
                            if (key == dgv_01.Rows[i].Cells["RFID"].Value.ToString())
                            {
                                repeat++;
                            }
                        }
                        if (repeat == 0)//判断是否重复，大于0代表重复
                        {
                            bool Isrepeat = true;
                            GridViewRowInfo row = dgv_01.Rows.AddNew();
                            row.Cells["id"].Value = dgv_01.RowCount;
                            row.Cells["RFID"].Value = key;
                            if (!_uRfid.ContainsKey(key)) _uRfid.Add(key, string.Empty);
                            if (repeatData != null)
                            {
                                DataRow[] secData = repeatData.Select("set_id=" + set_id);
                                for (int i = 0; i < secData.Length; i++)
                                {
                                    if (key == secData[i]["RFID"].ToString())
                                    {
                                        if (secData[i]["instrument_id"].ToString() == instruments_id)
                                        {
                                            row.Cells["repeat"].Value = "已与本包本器械做绑定";
                                            row.Cells["ca_type"].Value = 1;
                                            Isrepeat = false;
                                            break;
                                        }
                                        else
                                        {
                                            row.Cells["repeat"].Value = "已与本包其他器械做绑定";
                                            row.Cells["ca_type"].Value = 2;
                                            row.Cells["repeat"].Style.ForeColor = Color.Red;
                                            Isrepeat = false;
                                            break;

                                        }
                                    }
                                    else
                                    {
                                        Isrepeat = true;
                                    }
                                }
                                if (Isrepeat)
                                {
                                    bool isReapt = repeatRFID.Contains(key);//判断这个RFID是否绑定过了
                                    if (isReapt == true)
                                    {
                                        row.Cells["repeat"].Value = "已被其他包绑定";
                                        row.Cells["ca_type"].Value = 3;
                                        row.Cells["repeat"].Style.ForeColor = Color.Red;
                                    }
                                    else
                                    {
                                        row.Cells["repeat"].Value = "未绑定";
                                        row.Cells["ca_type"].Value = 4;
                                    }
                                }
                            }
                            else
                            {
                                row.Cells["repeat"].Value = "未绑定";
                                row.Cells["ca_type"].Value = 4;
                            }
                        }
                    }
                    _newRfid = new Dictionary<string, string>();
                    rfidCode.SetTagToZero();
                }));

            }
            //}
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_save_Click(object sender, EventArgs e)
        {

            int bindOneselfNum = 0;
            for (int i = 0; i < dgv_01.Rows.Count; i++)
            {
                if (dgv_01.Rows[i].Cells["ca_type"].Value.ToString() == "1")
                {
                    bindOneselfNum++;
                }
            }
            //判断绑定数量,排除自身已经绑定的器械
            if (dgv_01.RowCount > int.Parse(tb_iNumber.Text) - int.Parse(tb_rNumber.Text) + bindOneselfNum)
            {

                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("saveTooMuch", EnumPromptMessage.warning, new string[] { "RFID" }), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    rfidCode.DicAddData(_uRfid, 2);
                    _uRfid.Clear();
                    dgv_01.Rows.Clear();
                    return;
                }
                return;
            }
            for (int i = 0; i < dgv_01.RowCount; i++)
            {
                if (dgv_01.Rows[i].Cells["ca_type"].Value.ToString() == "3" || dgv_01.Rows[i].Cells["ca_type"].Value.ToString() == "2")
                {
                    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("alreadyEexist", EnumPromptMessage.warning, new string[] { "RFID" }), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        rfidCode.DicAddData(_uRfid, 2);
                        _uRfid.Clear();
                        dgv_01.Rows.Clear();
                        return;
                    }
                    return;
                }
            }
            CnasRemotCall remoteClient = new CnasRemotCall();
            SortedList condition = new SortedList();
            for (int i = 0; i < dgv_01.Rows.Count; i++)
            {
                if (dgv_01.Rows[i].Cells["ca_type"].Value.ToString() == "1")
                {
                    continue;
                }

                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, set_id);
                sltmp01.Add(2, set_code);
                sltmp01.Add(3, dgv_01.Rows[i].Cells["RFID"].Value.ToString());
                sltmp01.Add(4, CnasBaseData.UserID);
                sltmp01.Add(5, instruments_id);
                condition.Add(i + 1, sltmp01);
                //  string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-rfid-mapping-add001", sltmp, null);
                //int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-rfid-mapping-add001", sltmp, null);
                //if (recint > -1)
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "RFID" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    this.Close();
                //}
            }
            if (condition.Count > 0)
            {
                //string testSql = remoteClient.RemotInterface.CheckUPDataList("HCS-set-rfid-mapping-add001", condition);
                int result = remoteClient.RemotInterface.UPDataList("HCS-set-rfid-mapping-add001", condition);
                if (result > 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "RFID" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            //selBindingRFID();
            //repeatData = LoadRepeatRfidTable();
            //repeatRFID = LoadRepeatRfid();

        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0 || dgv_01.Rows.Count == 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "RFID的关联关系" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_01.SelectedRows.Count > 0)
            {
                this.BeginInvoke(new Action(() =>
                {
                    GridViewRowInfo row = dgv_01.SelectedRows[0];
                    Dictionary<string, string> dicSource = new Dictionary<string, string>();
                    string key = Convert.ToString(row.Cells["RFID"].Value);
                    dicSource.Add(key, string.Empty);
                    rfidCode.DicAddData(dicSource, 2);
                    if (_uRfid.ContainsKey(key)) _uRfid.Remove(key);

                    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { key, "RFID绑定关系" }), "删除关联关系", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    // int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, key);
                    sltmp.Add(1, sltmp01);
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    // string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-rfid-mapping-del001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-rfid-mapping-del001", sltmp, null);

                    dgv_01.Rows.Remove(row);
                    selBindingRFID();
                    repeatData = LoadRepeatRfidTable();
                    repeatRFID = LoadRepeatRfid();
                }));
            }

        }
        /// <summary>
        /// 重新绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_binding_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("delAllRfid", EnumPromptMessage.warning), "删除关联关系", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, set_id);
                sltmp01.Add(2, instruments_id);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-rfid-mapping-del002", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-rfid-mapping-del002", sltmp, null);




                rfidCode.DicAddData(_uRfid, 2);
                _uRfid.Clear();
                dgv_01.Rows.Clear();
                selBindingRFID();
                repeatData = LoadRepeatRfidTable();
                repeatRFID = LoadRepeatRfid();
            }));

        }

        private void HCSCM_entityset_manager_bindingRfid_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rfidCode != null)
            {
				rfidCode.DisConnecttion();
            }
        }

        private void but_feelingEmpty_Click(object sender, EventArgs e)
        {
            rfidCode.DicAddData(_uRfid, 2);
            _uRfid.Clear();
            dgv_01.Rows.Clear();
        }

        private void but_reconnect_Click(object sender, EventArgs e)
        {
			MessageBox.Show("该功能还未开放。");
			return;
        }
    }
}
