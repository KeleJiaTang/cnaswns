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
    public partial class HCSCM_instrument_type_manage_new : TemplateForm
    {
        SortedList sl_type_customer = new SortedList();
        SortedList sl_type_customer_01 = new SortedList();
        SortedList sl_type_vender = new SortedList();
        SortedList sl_type_sales = new SortedList();
        SortedList sl_type_costcenter = new SortedList();
        SortedList sl_type_complexity = new SortedList();
        SortedList sl_type_was = new SortedList();
        SortedList sl_type_str = new SortedList();
        SortedList sl_type = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        public HCSCM_instrument_type_manage_new(SortedList SLdata, DataRow[] arrayDR, DataTable getdt01, DataTable getdt02, DataTable getdt03, DataTable getdt04)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建器械模板";
            //Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            if (getdt04 != null)
            {
                int ii = getdt04.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt04.Rows[i]["id"].ToString() != null && getdt04.Rows[i]["bar_code"].ToString() != null && getdt04.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_type_customer.Add(getdt04.Rows[i]["id"].ToString(), getdt04.Rows[i]["cu_name"].ToString().Trim());
                        sl_type_customer_01.Add(getdt04.Rows[i]["bar_code"].ToString(), getdt04.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt04.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }

            //清洗难度
            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_complexity'");
            foreach (DataRow dr in arrayDR)
            {

                sl_type_complexity.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_complexity.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            //清洗程序

            if (getdt01 != null)
            {
                sl_type_was.Add("0", "无清洗程序");
                this.cb_washing.Items.Add("无清洗程序");
                int ii = getdt01.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt01.Rows[i]["id"].ToString() != null && getdt01.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_was.Add(getdt01.Rows[i]["id"].ToString(), getdt01.Rows[i]["pr_name"].ToString().Trim());
                        cb_washing.Items.Add(getdt01.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }
            //灭菌程序                  
            if (getdt02 != null)
            {
                sl_type_str.Add("0", "无灭菌程序");
                this.cb_sterilizer.Items.Add("无灭菌程序");
                int aa = getdt02.Rows.Count;
                if (aa <= 0) return;
                for (int i = 0; i < aa; i++)
                {
                    if (getdt02.Rows[i]["id"].ToString() != null && getdt02.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_str.Add(getdt02.Rows[i]["id"].ToString(), getdt02.Rows[i]["pr_name"].ToString().Trim());
                        cb_sterilizer.Items.Add(getdt02.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }

            //器械类型
            DataRow[] typeDR01 = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            foreach (DataRow dr in typeDR01)
            {

                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            DataTable getdt05 = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            //生产商
            DataRow[] vender = getdt05.Select("vender_type=1 or vender_type=3");
            foreach (DataRow dr in vender)
            {
                sl_type_vender.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                cb_vender.Items.Add(dr["v_name"].ToString().Trim());
            }
            //销售商
            DataRow[] sales = getdt05.Select("vender_type=2 or vender_type=3");
            foreach (DataRow dr in sales)
            {
                sl_type_sales.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                cb_sales.Items.Add(dr["v_name"].ToString().Trim());
            }

            //在窗体上显示信息
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改器械模板";
                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                this.cb_customer.Text = SLdata["ca_customer"].ToString();
              //  this.cb_cost_center.Text = SLdata["cost_center"].ToString();
                if (SLdata["ca_complexity"] != null)
                    this.cb_complexity.Text = sl_type_complexity.GetKey(sl_type_complexity.IndexOfValue(SLdata["ca_complexity"].ToString())).ToString() + ":" + SLdata["ca_complexity"].ToString();
                this.cb_vender.Text = sl_type_vender[SLdata["ca_vender"].ToString()].ToString();
                this.cb_sales.Text = sl_type_sales[SLdata["sales_id"].ToString()].ToString();
                ////如果选择的不是辅料或一次性物品
                //if (SLdata["ca_type"].ToString() != "辅料" && SLdata["ca_type"].ToString() != "敷料")
                //{
                if (SLdata["sterilizer_program"].ToString() != "")
                {

                    this.cb_sterilizer.Text = sl_type_str[SLdata["sterilizer_program"].ToString()].ToString();
                }
                if (SLdata["washing_program"].ToString() != "")
                {
                    this.cb_washing.Text = sl_type_was[SLdata["washing_program"].ToString()].ToString();
                }


                //}

                if (SLdata["bargain_price"] == null)
                {
                    this.tb_bargain_price.Text = "0";
                }
                else
                {
                    this.tb_bargain_price.Text = SLdata["bargain_price"].ToString();
                }

                if (SLdata["ca_brand"] == null)
                {
                    this.tb_brand.Text = "";
                }
                else
                {
                    this.tb_brand.Text = SLdata["ca_brand"].ToString();
                }
                if (SLdata["ca_times"] == null)
                {
                    this.tb_times.Text = "";
                }
                else
                {
                    this.tb_times.Text = SLdata["ca_times"].ToString();
                }
                this.tb_price.Text = SLdata["ca_price"].ToString();//.Substring(1, SLdata["ca_price"].ToString().Length - 1);

                if (SLdata["ca_weight"] == null)
                {
                    this.tb_weight.Text = "";
                }
                else
                {
                    this.tb_weight.Text = SLdata["ca_weight"].ToString();

                }

                if (SLdata["ca_size"] == null)
                {
                    this.tb_size.Text = "";
                }
                else
                {
                    this.tb_size.Text = SLdata["ca_size"].ToString();
                }

                this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["ca_type"].ToString())).ToString() + ":" + SLdata["ca_type"].ToString();

            }
        }
        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //关闭
        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataTable getdt = new DataTable();
        //确定按钮触发事件
        private void but_ok_Click_1(object sender, EventArgs e)
        {

            #region 验证
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_type.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_vender.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillvender", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_sales.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillsales", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_customer.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (this.cb_cost_center.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (this.cb_complexity.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filldifficulty", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (tb_price.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillprice", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果选择的不是辅料或一次性物品
            if (cb_type.Text.Trim() != "2:辅料" && cb_type.Text.Trim() != "3:敷料")
            {

                //if (!string.IsNullOrEmpty(tb_weight.Text))
                //{
                //    //如果用户输入的值不为正整数，则提示用户
                //    if (!CnasUtilityTools.IsNumeric(tb_weight.Text))
                //    {
                //        MessageBox.Show("重量输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //if (!string.IsNullOrEmpty(tb_times.Text))
                //{
                //    //如果用户输入的值不为正整数，则提示用户
                //    if (!CnasUtilityTools.IsNumeric(tb_times.Text))
                //    {
                //        MessageBox.Show("可用次数输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}

                //if (!string.IsNullOrEmpty(tb_size.Text))
                //{
                //    //如果用户输入的值不为正整数，则提示用户
                //    if (!CnasUtilityTools.IsNumeric(tb_size.Text))
                //    {
                //        MessageBox.Show("器械长度输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //if (this.tb_brand.Text.Trim() == "")
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillbrand", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //if (this.cb_washing.Text == null)
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillwastype", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //if (this.cb_sterilizer.Text == null)
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillstrtype", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

            }


            if (tb_size.Text.Trim() == "")
            {
                tb_size.Text = "";
            }
            #endregion
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);
            sttmp02.Add(2, sl_type_customer_01.GetKey(sl_type_customer_01.IndexOfValue(cb_customer.Text.Trim())));
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec002", sttmp02);//124
            try
            {
                if (Strselectid == "")
                {
                    #region 判断名称是否重复
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                            if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());

                  //  sltmp.Add(2, sl_type_costcenter.GetKey(sl_type_costcenter.IndexOfValue(cb_cost_center.Text.Trim())));
                    sltmp.Add(3, sl_type_customer_01.GetKey(sl_type_customer_01.IndexOfValue(cb_customer.Text.Trim())));//顾客
                    //如果选择的不是辅料或敷料
                    if (cb_type.Text.Trim() != "2:辅料" && cb_type.Text.Trim() != "3:敷料" && this.cb_sterilizer.Text != "")
                    {
                        sltmp.Add(4, sl_type_str.GetKey(sl_type_str.IndexOfValue(cb_sterilizer.Text.Trim())).ToString());

                    }
                    else
                    {
                        sltmp.Add(4, "NULL");
                    }
                    //如果清洗难度为空，则传入SQL为NULL
                    if (this.cb_complexity.Text != "")
                    {
                        sltmp.Add(5, cb_complexity.Text.Trim().Substring(0, 1));
                    }
                    else
                    {
                        sltmp.Add(5, "NULL");
                    }
                    sltmp.Add(6, sl_type_vender.GetKey(sl_type_vender.IndexOfValue(cb_vender.Text.Trim())).ToString());
                    //如果选择的不是辅料或一次性物品
                    if (cb_type.Text.Trim() != "2:辅料" && cb_type.Text.Trim() != "3:敷料" && this.cb_washing.Text != "")
                    {
                        sltmp.Add(7, sl_type_was.GetKey(sl_type_was.IndexOfValue(cb_washing.Text.Trim())));
                    }
                    else
                    {
                        sltmp.Add(7, "NULL");
                    }

                    sltmp.Add(8, tb_brand.Text.Trim());
                    sltmp.Add(9, tb_price.Text.Trim());
                    if (tb_times.Text.Trim() == "")
                    {
                        sltmp.Add(10, "NULL");
                    }
                    else
                    {
                        sltmp.Add(10, tb_times.Text.Trim());
                    }

                    if (tb_weight.Text.Trim() == "")
                    {

                        sltmp.Add(11, "NULL");
                    }
                    else
                    {
                        sltmp.Add(11, tb_weight.Text.Trim());
                    }


                    sltmp.Add(12, tb_size.Text.Trim());
                    sltmp.Add(13, cb_type.Text.Trim().Substring(0, 2));
                    sltmp.Add(14, sl_type_sales.GetKey(sl_type_sales.IndexOfValue(cb_sales.Text.Trim())).ToString());
                    sltmp.Add(15, CnasBaseData.SystemID);

                    if (tb_bargain_price.Text.Trim() == "")
                    {

                        sltmp.Add(16, "0");
                    }
                    else
                    {
                        sltmp.Add(16, tb_bargain_price.Text.Trim());
                    }

                    sltmp01.Add(1, sltmp);
                    //string hgg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-base-add01", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-base-add01", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show("恭喜你，增加成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    #region 判断名称是否重复
                    if (this.tb_name.Text != Strselectname)
                    {
                        if (getdt != null)
                        {
                            int ii = getdt.Rows.Count;
                            if (ii <= 0) return;
                            for (int i = 0; i < ii; i++)
                                if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                        }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                  //  sltmp01.Add(2, sl_type_costcenter.GetKey(sl_type_costcenter.IndexOfValue(cb_cost_center.Text.Trim())));
                    sltmp01.Add(3, sl_type_customer_01.GetKey(sl_type_customer_01.IndexOfValue(cb_customer.Text.Trim())));
                    if (this.cb_complexity.Text != "")
                    {
                        sltmp01.Add(4, cb_complexity.Text.Trim().Substring(0, 1));
                    }
                    else
                    {
                        sltmp01.Add(4, "NULL");
                    }

                    //如果选择的不是辅料或一次性物品
                    if (cb_type.Text.Trim() != "2:辅料" && cb_type.Text.Trim() != "3:敷料" && this.cb_sterilizer.Text != "")
                    {
                        sltmp01.Add(5, sl_type_str.GetKey(sl_type_str.IndexOfValue(cb_sterilizer.Text.Trim())));
                    }
                    else
                    {
                        sltmp01.Add(5, "NULL");
                    }

                    sltmp01.Add(6, sl_type_vender.GetKey(sl_type_vender.IndexOfValue(cb_vender.Text.Trim())));
                    //如果选择的不是辅料或一次性物品
                    if (cb_type.Text.Trim() != "2:辅料" && cb_type.Text.Trim() != "3:敷料" && this.cb_washing.Text != "")
                    {
                        sltmp01.Add(7, sl_type_was.GetKey(sl_type_was.IndexOfValue(cb_washing.Text.Trim())));
                    }
                    else
                    {
                        sltmp01.Add(7, "NULL");
                    }

                    sltmp01.Add(8, tb_brand.Text.Trim());
                    sltmp01.Add(9, tb_price.Text.Trim());
                    if (tb_times.Text.Trim() == "")
                    {
                        sltmp01.Add(10, "NULL");
                    }
                    else
                    {
                        sltmp01.Add(10, tb_times.Text.Trim());
                    }
                    if (tb_weight.Text.Trim() == "")
                    {

                        sltmp01.Add(11, "NULL");
                    }
                    else
                    {
                        sltmp01.Add(11, tb_weight.Text.Trim());
                    }

                    sltmp01.Add(12, tb_size.Text.Trim());
                    sltmp01.Add(13, cb_type.Text.Trim().Substring(0, 2));
                    sltmp01.Add(14, sl_type_sales.GetKey(sl_type_sales.IndexOfValue(cb_sales.Text.Trim())));
                    if (tb_bargain_price.Text.Trim() == "")
                    {

                        sltmp01.Add(15, "0");
                    }
                    else
                    {
                        sltmp01.Add(15, tb_bargain_price.Text.Trim());
                    }
                    sltmp01.Add(16, Strselectid);


                    sltmp.Add(1, sltmp01);

                    //  string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-base-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-base-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_weight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_times_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            //this.cb_cost_center.Items.Clear();
            //sl_type_costcenter.Clear();
            //string str = sl_type_customer.GetKey(sl_type_customer.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            //SortedList sl_barcode = new SortedList();
            //sl_barcode.Add(1, str);
            //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            ////string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
            //DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            //if (getdt != null)
            //{
            //    int ii = getdt.Rows.Count;
            //    if (ii <= 0) return;
            //    for (int i = 0; i < ii; i++)
            //    {
            //        if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
            //        {
            //            sl_type_costcenter.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
            //            cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
            //        }
            //    }
            //}
        }

        private void cb_type_TextChanged(object sender, EventArgs e)
        {
            //如果选择的是辅料或一次性物品则有些数据可以不填
            if (cb_type.Text.Trim() == "2:辅料" || cb_type.Text.Trim() == "3:敷料")
            {
                tb_brand.Enabled = false;//品牌，不可用
                tb_times.Enabled = false;//可用次数，不可用
                cb_washing.Enabled = false;//清洗程序，不可用
                cb_sterilizer.Enabled = false;//灭菌程序，不可用
                tb_weight.Enabled = false;//重量不可用
                tb_size.Enabled = false;//尺寸不可用
                cb_complexity.Enabled = false;
                ////不需要的红点
                //lb_brand.Enabled = false;
                //lb_washing.Enabled = false;
                //lb_sterilizer.Enabled = false;
                //label.Enabled = false;
            }
            else
            {

                tb_brand.Enabled = true;//品牌，正常使用
                tb_times.Enabled = true;//可用次数，正常使用
                cb_washing.Enabled = true;//清洗程序，正常使用
                cb_sterilizer.Enabled = true;//灭菌程序，正常使用
                tb_weight.Enabled = true;//重量正常使用
                tb_size.Enabled = true;//尺寸正常使用
                cb_complexity.Enabled = true;
                ////正常使用的红点
                //lb_brand.Enabled = true;
                //lb_washing.Enabled = true;
                //lb_sterilizer.Enabled = true;
                //label.Enabled = true;
            }
        }

		private void label8_Click(object sender, EventArgs e)
		{

		}
    }
}




