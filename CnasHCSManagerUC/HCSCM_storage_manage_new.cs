using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_storage_manage_new : TemplateForm
    {
        SortedList sl_type = new SortedList();
        SortedList sl_uselocation = new SortedList();
        SortedList sl_customer = new SortedList();
        SortedList sl_costcenter = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        DataTable DTlocation = new DataTable();
        DataTable DTcustomer = new DataTable();
        DataTable DTcostcenter = new DataTable();
        public HCSCM_storage_manage_new(SortedList SLdata)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新建存储点";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] type = CnasBaseData.SystemBaseData.Select("type_code='HCS-storage-type'");
            foreach (DataRow dr in type)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_uselocation.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                        cb_location.Items.Add(DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
            DTcustomer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (DTcustomer != null)
            {
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["id"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_customer.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改存储点";
                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_name.Text = SLdata["s_name"].ToString();
                this.tb_barcode.Text = SLdata["s_barcode"].ToString();
                this.cb_customer.Text = sl_customer[SLdata["s_customer"].ToString()].ToString();
                this.cb_costcenter.Text = sl_costcenter[SLdata["s_costcenter"].ToString()].ToString();
                this.cb_location.Text = sl_uselocation[SLdata["s_uselocation"].ToString()].ToString();
                this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["s_type"].ToString())).ToString() + ":" + SLdata["s_type"].ToString();
                cb_type.Enabled = false;
                this.tb_basket.Text = SLdata["s_basket"].ToString();
                this.tb_room.Text = SLdata["s_room"].ToString();
                this.tb_cabinet.Text = SLdata["s_cabinet"].ToString();
                this.tb_remarks.Text = SLdata["s_remarks"].ToString();

            }


        }
        DataTable getdt = new DataTable();
        private void but_ok_Click(object sender, EventArgs e)
        {
            #region 验证
            if (cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_location.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filllocation", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_customer.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_costcenter.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec002", sttemp01);//227

            if (Strselectid == "")
            {
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                        if (getdt.Rows[i]["s_name"].ToString().Trim() != null)
                        {
                            if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["s_name"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                }
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, tb_barcode.Text.Trim());
                sltmp.Add(2, tb_name.Text.Trim());
                sltmp.Add(3, cb_type.Text.Trim().Substring(0, 1));
                sltmp.Add(4, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
                sltmp.Add(5, sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_costcenter.Text.Trim())).ToString());
                sltmp.Add(6, tb_room.Text.Trim());
                sltmp.Add(7, tb_basket.Text.Trim());
                sltmp.Add(8, tb_cabinet.Text.Trim());
                sltmp.Add(9, sl_uselocation.GetKey(sl_uselocation.IndexOfValue(cb_location.Text.Trim())).ToString());
                sltmp.Add(10, tb_remarks.Text.Trim());
                sltmp.Add(11, 1);
                sltmp01.Add(1, sltmp);
                //string rff = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-storage-add001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-storage-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }


            }
            else
            {
                if (this.tb_name.Text != Strselectname)
                {
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                            if (getdt.Rows[i]["s_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["s_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                    }
                }
                SortedList sttmp = new SortedList();
                SortedList sttmp01 = new SortedList();
                sttmp.Add(1, tb_barcode.Text.Trim());
                sttmp.Add(2, tb_name.Text.Trim());
                sttmp.Add(3, cb_type.Text.Trim().Substring(0, 1));
                sttmp.Add(4, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
                sttmp.Add(5, sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_costcenter.Text.Trim())).ToString());
                sttmp.Add(6, tb_room.Text.Trim());
                sttmp.Add(7, tb_basket.Text.Trim());
                sttmp.Add(8, tb_cabinet.Text.Trim());
                sttmp.Add(9, sl_uselocation.GetKey(sl_uselocation.IndexOfValue(cb_location.Text.Trim())).ToString());
                sttmp.Add(10, tb_remarks.Text.Trim());
                sttmp.Add(11, Strselectid);
                sttmp01.Add(1, sttmp);
                //string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-storage-up001", sttmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-storage-up001", sttmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_cabinet_Click(object sender, EventArgs e)
        {

        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_costcenter.Items.Clear();
            sl_costcenter.Clear();
            string str = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_costcenter.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        cb_costcenter.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
        }
    }
}
