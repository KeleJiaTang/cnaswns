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
    public partial class HCSCM_orderNum_manage_new : TemplateForm
    {
        SortedList Sl_customer = new SortedList();
        SortedList Sl_customer_id = new SortedList();
        SortedList Sl_location = new SortedList();
        private DataRow[] arrayDR_id = null;//用于传输数据
        string barcodeBcc01 = "";
        string barcodeBcc02 = "";
        string barcodeBcc03 = "";
        string barcodeBcc04 = "";
        string Strselectid = "";//单号id
        string Strselectname = "";//单号名称
        string Strselectbarcode = "";//单号五位后条码
        int maxId = 0;//最大id
        public HCSCM_orderNum_manage_new(SortedList SortedList)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新建订单号";
            //获取院内送货单的信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note' and key_code='Hospital'");
            if (arrayDR02.Length > 0)//判断是否有值
            {
                rb_BCCO1.Text = arrayDR02[0]["value_code"].ToString().Trim();
                rb_BCCO2.Text = arrayDR02[1]["value_code"].ToString().Trim();
                rb_BCCO3.Text = arrayDR02[2]["value_code"].ToString().Trim();
                rb_BCCO4.Text = arrayDR02[3]["value_code"].ToString().Trim();
                barcodeBcc01 = arrayDR02[0]["other_code"].ToString().Trim();
                barcodeBcc02 = arrayDR02[1]["other_code"].ToString().Trim();
                barcodeBcc03 = arrayDR02[2]["other_code"].ToString().Trim();
                barcodeBcc04 = arrayDR02[3]["other_code"].ToString().Trim();

            }

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
                    {
                        Sl_customer_id.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        Sl_customer.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }

            //string check = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec006", null);
            DataTable getdtSelId = reCnasRemotCall.RemotInterface.SelectData("HCS-orderid-manager-sel010", null);
            if (getdt != null)
            {
                arrayDR_id = getdtSelId.Select();

                if (arrayDR_id[0]["max(id)"].ToString() != null)
                {
                    string a = arrayDR_id[0]["max(id)"].ToString();
                    if (a == "")
                    {
                        a = "0";
                        maxId = int.Parse(a) + 1;

                    }
                    else
                    {
                        maxId = int.Parse(a) + 1;

                    }
                }
            }

            if (SortedList != null)
            {

                Strselectbarcode = SortedList["bar_code"].ToString().Substring(5, 8);
                Strselectid = SortedList["id"].ToString();
                Strselectname = tb_name.Text = SortedList["ca_name"].ToString();
                cb_customer.Text = SortedList["customer_barcodename"].ToString();
                cb_location.Text = SortedList["location_name"].ToString();
                tb_remarks.Text = SortedList["remark"].ToString();
                if (SortedList["bar_code"].ToString().Substring(0, 5) == barcodeBcc01)
                {
                    rb_BCCO1.Checked = true;
                }
                else if (SortedList["bar_code"].ToString().Substring(0, 5) == barcodeBcc02)
                {
                    rb_BCCO2.Checked = true;
                }
                else if (SortedList["bar_code"].ToString().Substring(0, 5) == barcodeBcc03)
                {
                    rb_BCCO3.Checked = true;
                }
                else
                {
                    rb_BCCO4.Checked = true;
                }


            }

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            //if (this.tb_name.Text.Trim() == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (this.cb_customer.Text.Trim() == "")
            {
                MessageBox.Show("请选择客户", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_location.Text == "")
            {
                MessageBox.Show("请选择使用地点", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Strselectid == "")
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                SortedList sttemp = new SortedList();


                #region 取使用地点的成本中心

                sttemp.Add(1, Sl_location.GetKey(Sl_location.IndexOfValue(cb_location.Text.Trim())));
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec010", sttemp);//49
                #endregion
                if (getdt != null)
                {
                    //getdt.Rows[0]["u_costcenter"].ToString();



                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(2, getdt.Rows[0]["bar_code"].ToString());//成本中心
                    sltmp.Add(3, Sl_location.GetKey(Sl_location.IndexOfValue(cb_location.Text.Trim())));//使用地点
                    sltmp.Add(4, Sl_customer.GetKey(Sl_customer.IndexOfValue(cb_customer.Text.Trim())));//顾客
                    sltmp.Add(5, CnasBaseData.UserID);
                    sltmp.Add(6, CnasBaseData.SystemID);
                    sltmp.Add(7, tb_remarks.Text.Trim());//备注
                    if (rb_BCCO1.Checked == true)
                    {
                        sltmp.Add(8, barcodeBcc01.Trim());//条码
                        this.tb_name.Text = cb_location.Text + barcodeBcc01.Trim() + maxId;
                    }
                    else if (rb_BCCO2.Checked == true)
                    {
                        sltmp.Add(8, barcodeBcc02.Trim());//条码
                        this.tb_name.Text = cb_location.Text + barcodeBcc02.Trim() + maxId;

                    }
                    else if (rb_BCCO3.Checked == true)
                    {
                        sltmp.Add(8, barcodeBcc03.Trim());//条码
                        this.tb_name.Text = cb_location.Text + barcodeBcc03.Trim() + maxId;
                    }
                    else
                    {
                        sltmp.Add(8, barcodeBcc04.Trim());//条码
                        this.tb_name.Text = cb_location.Text + barcodeBcc04.Trim() + maxId;
                    }
                    sltmp.Add(1, tb_name.Text.Trim());
                    #region 判断名字是否存在

                    sttemp01.Add(1, CnasBaseData.SystemID);
                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-orderid-manager-sec001", sttemp01);//49
                    if (getdt != null)
                    {
                        DataRow[] getdt_01 = getdt.Select();
                        foreach (DataRow dr in getdt_01)
                        {


                            if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    #endregion
                    sltmp01.Add(1, sltmp);
                    string a = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-orderid-manager-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-orderid-manager-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("对不起，系统增加出错，请联系管理员。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            else
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp = new SortedList();
                DataTable getdt = null;

                #region 取使用地点的成本中心

                sttemp.Add(1, Sl_location.GetKey(Sl_location.IndexOfValue(cb_location.Text.Trim())));
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec010", sttemp);//49
                #endregion

                if (getdt != null)
                {
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();

                    if (rb_BCCO1.Checked == true)
                    {
                        sltmp.Add(2, barcodeBcc01.Trim() + Strselectbarcode);//条码
                    }
                    else if (rb_BCCO2.Checked == true)
                    {
                        sltmp.Add(2, barcodeBcc02.Trim() + Strselectbarcode);//条码

                    }
                    else if (rb_BCCO3.Checked == true)
                    {
                        sltmp.Add(2, barcodeBcc03.Trim() + Strselectbarcode);//条码
                    }
                    else
                    {
                        sltmp.Add(2, barcodeBcc04.Trim() + Strselectbarcode);//条码
                    }
                    sltmp.Add(3, getdt.Rows[0]["bar_code"].ToString());//成本中心
                    sltmp.Add(4, Sl_location.GetKey(Sl_location.IndexOfValue(cb_location.Text.Trim())));//使用地点
                    sltmp.Add(5, Sl_customer.GetKey(Sl_customer.IndexOfValue(cb_customer.Text.Trim())));//顾客
                    sltmp.Add(6, tb_remarks.Text.Trim());//备注
                    sltmp.Add(7, Strselectid);//id
                    sltmp.Add(1, tb_name.Text.Trim());//名字
                    if (this.tb_name.Text.Trim() != Strselectname)
                    {
                        #region 判断名字是否存在

                        SortedList sttemp01 = new SortedList();

                        sttemp01.Add(1, CnasBaseData.SystemID);
                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-orderid-manager-sec001", sttemp01);//49
                        if (getdt != null)
                        {
                            DataRow[] getdt_01 = getdt.Select();
                            foreach (DataRow dr in getdt_01)
                            {


                                if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        #endregion
                    }
                    sltmp01.Add(1, sltmp);
                    //string a = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-orderid-manager-up001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-orderid-manager-up001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("对不起，系统修改出错，请联系管理员。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }



        }


        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_location.Items.Clear();
            Sl_location.Clear();
            string str = Sl_customer_id.GetKey(Sl_customer_id.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        Sl_location.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["u_uname"].ToString().Trim());
                        this.cb_location.Items.Add(getdt.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
        }
    }
}
