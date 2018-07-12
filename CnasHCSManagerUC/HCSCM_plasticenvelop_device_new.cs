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
    public partial class HCSCM_plasticenvelop_device_new : TemplateForm
    {
        SortedList sl_SalesType = new SortedList();
        SortedList sl_VenderType = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        public HCSCM_plasticenvelop_device_new(SortedList SLdata, DataTable getdt)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            //定义窗口标题
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--添加新塑封机";

            this.dt_bd_test.Value = Convert.ToDateTime("08:00:00");
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);//查询厂商
            if (getdt != null)
            {

                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    sl_VenderType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                    cb_type.Items.Add(dr["v_name"].ToString().Trim());
                }
                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_SalesType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                    cb_sales.Items.Add(dr["v_name"].ToString().Trim());
                }
            }
            if (SLdata != null)//在窗体上显示信息
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改塑封机";
                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                this.tb_model.Text = SLdata["ca_model"].ToString();
                this.tb_barcode.Text = SLdata["bar_code"].ToString();
                this.tb_price.Text = SLdata["price"].ToString();//.Substring(1, SLdata["price"].ToString().Length - 1);
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();

                this.cb_type.Text = sl_VenderType[SLdata["ca_vender"].ToString()].ToString();
                this.cb_sales.Text = sl_SalesType[SLdata["sales_id"].ToString()].ToString();
                this.dt_bd_test.Text = SLdata["bd_test_time"].ToString();
                if (SLdata["if_bdtest"].ToString() == "需要")
                {
                    rb_want.Checked = true;
                }
                else
                {
                    rb_unwanted.Checked = true;
                }
            }
        }
        private DataTable getdt = new DataTable();
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ok_Click(object sender, EventArgs e)
        {
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "塑封机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ////如果价格不为null，则表示需要验证输入的值是否正确
            //if (!string.IsNullOrEmpty(tb_price.Text))
            //{
            //    //如果用户输入的值不为正整数，则提示用户
            //    if (!CnasUtilityTools.IsNumeric(tb_price.Text))
            //    {
            //        MessageBox.Show("塑封机价格输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-device-sec001", sttemp01);//49
                if (Strselectid == "")//增加
                {

                    #region 判断名字是否存在

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
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "塑封机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp.Add(5, sl_SalesType.GetKey(sl_SalesType.IndexOfValue(cb_sales.Text.Trim())));
                    sltmp.Add(6, tb_remarks.Text.Trim());
                    if (tb_price.Text != "")
                    {
                        sltmp.Add(7, tb_price.Text.Trim());
                    }
                    else
                    {
                        sltmp.Add(7, "0");
                    }
                   
                    sltmp.Add(8, CnasBaseData.SystemID);
                    sltmp.Add(9, dt_bd_test.Value.TimeOfDay);
                    if (this.rb_want.Checked)
                    {
                        sltmp.Add(10, 1);
                    }
                    else
                    {
                        sltmp.Add(10, 0);
                    }

                    sltmp01.Add(1, sltmp);

                    // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-plasticenvelop-device-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-device-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "塑封机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }



                else
                {
                    #region 判断名字是否存在

                    if (this.tb_name.Text.Trim() != Strselectname)
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
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "塑封机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp.Add(5, tb_price.Text.Trim());
                    sltmp.Add(6, dt_bd_test.Text.Trim());

                    if (this.rb_want.Checked)
                    {
                        sltmp.Add(7, 1);
                    }
                    else
                    {
                        sltmp.Add(7, 0);
                    }
                    sltmp.Add(8, sl_SalesType.GetKey(sl_SalesType.IndexOfValue(cb_sales.Text.Trim())));
                    sltmp.Add(9, Strselectid);

                    sltmp01.Add(1, sltmp);


                    string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-plasticenvelop-device-up001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-device-up001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "塑封机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_unwanted_CheckedChanged(object sender, EventArgs e)
        {
            dt_bd_test.Visible = false;
            lb_info_time.Visible = false;
        }

        private void rb_want_CheckedChanged(object sender, EventArgs e)
        {
            dt_bd_test.Visible = true;
            lb_info_time.Visible = true;
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
    }
}
