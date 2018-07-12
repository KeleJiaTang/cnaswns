using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using CnasUI;



namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_sterilizer_device_new : TemplateForm
    {
        SortedList sl_VenderType = new SortedList();
        SortedList sl_SalesType = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        public HCSCM_sterilizer_device_new(SortedList SLdata, DataTable getdt)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建灭菌器";
            this.dtp_bd.Value = Convert.ToDateTime("08:00:00");
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);//查询厂商
            if (getdt != null)
            {
                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    cb_type.Items.Add(dr["v_name"].ToString().Trim());
                    sl_VenderType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                }
                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    cb_sales.Items.Add(dr["v_name"].ToString().Trim());
                    sl_SalesType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                }

                //修改时在窗体上显示信息
                if (SLdata != null)
                {
                    this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改灭菌器";
                    Strselectid = SLdata["id"].ToString();
                    Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                    this.tb_model.Text = SLdata["ca_model"].ToString();
                    this.tb_barcode.Text = SLdata["bar_code"].ToString();
                    this.tb_price.Text = SLdata["price"].ToString();//.Substring(1, SLdata["price"].ToString().Length - 1);
                    this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
                    this.cb_type.Text = sl_VenderType[SLdata["ca_vender"].ToString()].ToString();
                    this.cb_sales.Text = sl_SalesType[SLdata["sales_id"].ToString()].ToString();
                    this.dtp_bd.Text = SLdata["bd_test_time"].ToString();
                    if (SLdata["if_bdtest"].ToString() == "需要")
                    {
                        rb_bd_yes.Checked = true;
                    }
                    else
                    {
                        rb_bd_no.Checked = true;
                    }
                    this.tb_stu.Text = SLdata["std_stu"].ToString();
                    this.tb_minstu.Text = SLdata["min_stu"].ToString();
                    this.tb_maxstu.Text = SLdata["max_stu"].ToString();
                }
            }
        }
        DataTable getdt = new DataTable();
        //新建按钮触发事件
        private void but_OK_Click_1(object sender, EventArgs e)
        {
            #region 验证
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillvender", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_sales.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillsales", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_model.Text.Trim() == "")
            {
                tb_model.Text = "";
            }
            if (tb_stu.Text.Trim() == "")
            {
                MessageBox.Show("请填写机器的标准容积。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_minstu.Text.Trim() == "")
            {
                tb_minstu.Text = "NULL";
            }
            if (tb_maxstu.Text.Trim() == "")
            {
                tb_maxstu.Text = "NULL";
            }
            if (tb_price.Text.Trim() == "")
            {
                tb_price.Text = "NULL";
            }
            if (tb_minstu.Text != "NULL" && tb_maxstu.Text != "NULL")
            {
                if (int.Parse(tb_maxstu.Text) < int.Parse(tb_minstu.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillvolume", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-device-sec001", sttmp02);//49


            try
            {
                if (Strselectid == "")//增加
                {
                    #region 判断新增时灭菌器名字是否相同
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii > 0)
                        {
                            for (int i = 0; i < ii; i++)
                            {
                                if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }


                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());
                    sltmp.Add(2, tb_barcode.Text.Trim());
                    sltmp.Add(3, tb_model.Text.Trim());
                    sltmp.Add(4, sl_VenderType.GetKey(sl_VenderType.IndexOfValue(cb_type.Text.Trim())));

                    sltmp.Add(5, tb_remarks.Text.Trim());
                    if (tb_price.Text != "")
                    {
                        sltmp.Add(6, tb_price.Text.Trim());
                    }
                    else
                    {
                        sltmp.Add(6, "NULL");
                    }
                    
                    sltmp.Add(7, dtp_bd.Value.TimeOfDay);
                    sltmp.Add(8, tb_stu.Text.Trim());
                    if (rb_bd_yes.Checked)
                    {
                        sltmp.Add(9, 1);
                    }
                    else
                    {
                        sltmp.Add(9, 0);
                    }
                    sltmp.Add(10, tb_minstu.Text.Trim());
                    sltmp.Add(11, CnasBaseData.SystemID);
                    sltmp.Add(12, tb_maxstu.Text.Trim());
                    sltmp.Add(13, sl_SalesType.GetKey(sl_SalesType.IndexOfValue(cb_sales.Text.Trim())));
                    sltmp01.Add(1, sltmp);
                    //string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-sterilizer-device-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-device-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }

                else//修改
                {
                    #region 判断灭菌器名字是否相同

                    if (tb_name.Text.Trim() != Strselectname)
                    {
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
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }



                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());
                    sltmp.Add(2, tb_model.Text.Trim());
                    sltmp.Add(3, sl_VenderType.GetKey(sl_VenderType.IndexOfValue(cb_type.Text.Trim())));
                    sltmp.Add(4, tb_remarks.Text.Trim());
                    if (tb_price.Text!="")
                    {
                        sltmp.Add(5, tb_price.Text.Trim());
                    }
                    else
                    {
                        sltmp.Add(5, "NULL");
                    }
                    
                    sltmp.Add(6, dtp_bd.Value.TimeOfDay);
                    sltmp.Add(7, tb_stu.Text.Trim());
                    sltmp.Add(8, tb_minstu.Text.Trim());
                    sltmp.Add(9, tb_maxstu.Text.Trim());
                    if (rb_bd_yes.Checked)
                    {
                        sltmp.Add(10, 1);
                    }
                    else
                    {
                        sltmp.Add(10, 0);
                    }
                    sltmp.Add(11, sl_SalesType.GetKey(sl_SalesType.IndexOfValue(cb_sales.Text.Trim())));
                    sltmp.Add(12, Strselectid);
                    sltmp01.Add(1, sltmp);

                     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-sterilizer-device-up001", sltmp01, null);
                   // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-sterilizer-device-up001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-device-up001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }






            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }





        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void rb_bd_yes_CheckedChanged(object sender, EventArgs e)
        {
            lb_bd.Visible = true;
            dtp_bd.Visible = true;
        }

        private void rb_bd_no_CheckedChanged(object sender, EventArgs e)
        {
            lb_bd.Visible = false;
            dtp_bd.Visible = false;
        }

        private void lb_bd_Click(object sender, EventArgs e)
        {

        }

        private void tb_minstu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_maxstu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (tb_price.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(tb_price.Text, out oldf);
                    b2 = float.TryParse(tb_price.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }

                }

            }
        }

        private void tb_stu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


