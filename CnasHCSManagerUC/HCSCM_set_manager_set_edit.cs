using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_manager_set_edit : TemplateForm
    {
        private string Strselectid = "";//接收选择这一行的id
        private string Strselectname = "";
        private SortedList storage = null;
        DataTable DTstorage = new DataTable();
        SortedList Sl_storage = new SortedList();
        SortedList Sl_location = new SortedList();
        SortedList Sl_type_01 = new SortedList();//存储成本中心
        SortedList Sl_type_02 = new SortedList();//存储所属顾客
        SortedList Sl_type_02_01 = new SortedList();//存储所属顾客id
        bool if_check = false;//判断是否改变了院内外控件
        public HCSCM_set_manager_set_edit(SortedList SLdata)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改实体包";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_02.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        Sl_type_02_01.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        this.cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }

            }
            DTstorage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            Sl_storage.Add("0", "");
            if (DTstorage != null)
            {
                int ii = DTstorage.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTstorage.Rows[i]["id"].ToString() != null && DTstorage.Rows[i]["s_name"].ToString().Trim() != null)
                    {
                        Sl_storage.Add(DTstorage.Rows[i]["id"].ToString().Trim(), DTstorage.Rows[i]["s_name"].ToString().Trim());

                    }
                }
            }
            if (SLdata["ca_priority"].ToString() == "1")//如果实体包继承的基本包紧急程度为1时则显示加急按钮
            {
                cb_if_urgent.Visible = true;
                if (SLdata["urgent"].ToString() == "1")//如果单次加急字段值为1时，加急功能打勾
                {
                    cb_if_urgent.Checked = true;
                }
                else
                {
                    cb_if_urgent.Checked = false;
                }

            }
            else
            {
                cb_if_urgent.Visible = false;
            }


            Strselectid = SLdata["id"].ToString();
            this.tb_barcode.Text = SLdata["bar_code"].ToString();
            Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
            this.tb_point.Text = SLdata["storage_id"].ToString();

            this.cb_customer.Text = SLdata["customer_code"].ToString();
            this.cb_cost_center.Text = SLdata["cost_center"].ToString();
            this.cb_location.Text = SLdata["location_id"].ToString();
            if (SLdata["rfid_retrospect"].ToString() == "1")//是否须要RFID追溯
            {
                this.cb_RFID.Checked = true;
            }
            else
            {
                this.cb_RFID.Checked = false;
            }

            if (tb_barcode.Text.Substring(0, 5) == "BCC0S" || tb_barcode.Text.Substring(0, 5) == "BCC3S")//判断是否是无定单包特殊包
            {
                cb_ifhospital.Visible = true;//显示控件
                if (tb_barcode.Text.Substring(0, 5) == "BCC0S")
                {
                    cb_ifhospital.Checked = true;
                }
                else
                {
                    cb_ifhospital.Checked = false;
                }
                if_check = this.cb_ifhospital.Checked;
            }


        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            #region 判断名字是否存在

            if (this.tb_name.Text.Trim() != Strselectname)
            {
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text.Trim())).ToString());
                sttemp01.Add(2, CnasBaseData.SystemID);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec050", sttemp01);//504
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                        {
                            if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetiton", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

            }
            #endregion
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_customer.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_cost_center.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_location.Text == "请选择" || this.cb_location.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filllocation", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_point.Text.Trim() == "")
            {
                tb_point.Text = "";
            }
            if (if_check != this.cb_ifhospital.Checked)//判断控件是否改变了
            {
                if (tb_barcode.Text.Substring(0, 5) == "BCC0S" || tb_barcode.Text.Substring(0, 5) == "BCC3S")//判断是否是无定单包特殊包
                {
                    #region 判断特殊包是否在流程中存在
                    SortedList sttemp = new SortedList();
                    sttemp.Add(1, this.tb_barcode.Text);
                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec022", sttemp);
                    if (getdt != null)
                    {
                        MessageBox.Show("您选择的特殊实体包已经在流程运作过，不允许修改院内外类型", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion
                }
            }
            try
            {
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, tb_name.Text.Trim());
                sltmp01.Add(2, Sl_type_01.GetKey(Sl_type_01.IndexOfValue(cb_cost_center.Text.Trim())).ToString());
                sltmp01.Add(3, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text.Trim())).ToString());
                sltmp01.Add(4, Sl_storage.GetKey(Sl_storage.IndexOfValue(this.tb_point.Text.Trim())).ToString());

                sltmp01.Add(5, Sl_location.GetKey(Sl_location.IndexOfValue(this.cb_location.Text.Trim())).ToString());

                sltmp01.Add(6, CnasBaseData.SystemID);
                if (cb_if_urgent.Checked == true)//如果单次加急选中则给数据库赋值为1，否则为0
                {
                    sltmp01.Add(7, 1);
                }
                else
                {
                    sltmp01.Add(7, 0);
                }
                if (tb_barcode.Text.Substring(0, 5) == "BCC0S" || tb_barcode.Text.Substring(0, 5) == "BCC3S")//判断是否是无定单包特殊包
                {
                    if (this.cb_ifhospital.Checked == true)
                    {
                        sltmp01.Add(8, "BCC0S" + tb_barcode.Text.Substring(5, tb_barcode.Text.Length - 5));
                    }
                    else
                    {
                        sltmp01.Add(8, "BCC3S" + tb_barcode.Text.Substring(5, tb_barcode.Text.Length - 5));
                    }
                }
                else
                {
                    sltmp01.Add(8, tb_barcode.Text);
                }
                if (this.cb_RFID.Checked == true)
                {
                    sltmp01.Add(9, 1);
                }
                else
                {
                    sltmp01.Add(9, 0);
                }
                sltmp01.Add(10, Strselectid);
                sltmp.Add(1, sltmp01);


                string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-up001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-up001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }



        }
        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_point_Click(object sender, EventArgs e)
        {
            HCSCM_set_storage hcsm = new HCSCM_set_storage();
            hcsm.ShowDialog();
            storage = hcsm.StoragePlace;
            if (storage != null && storage.ContainsKey("s_name"))
            {
                tb_point.Text = storage["s_name"].ToString();
            }
        }

        private void but_rea_Click(object sender, EventArgs e)
        {
            tb_point.Text = "";
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            Sl_type_01.Clear();
            string str = Sl_type_02_01.GetKey(Sl_type_02_01.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        this.cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            this.cb_location.Items.Clear();
            Sl_location.Clear();

            SortedList sl_uselocation = new SortedList();
            sl_uselocation.Add(1, str);

            DataTable Location = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec003", sl_uselocation);//使用地点
            if (Location != null)
            {
                this.cb_location.Items.Add("请选择");

                int ii = Location.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Location.Rows[i]["id"].ToString() != null && Location.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        Sl_location.Add(Location.Rows[i]["id"].ToString().Trim(), Location.Rows[i]["u_uname"].ToString().Trim());
                        this.cb_location.Items.Add(Location.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
        }




    }
}
