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
using Cnas.wns.CnasBaseClassClient;
using System.Text.RegularExpressions;
using CnasUI;


namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class nud_max_times : TemplateForm
    {
        SortedList sl_CarType = new SortedList();
        SortedList sl_ProducerType = new SortedList();
        SortedList sl_ProducerType2 = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="SLdata"></param>
        /// <param name="arrayDR"></param>
        public nud_max_times(SortedList SLdata, DataTable getdt)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
           
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--添加运输工具";
            //Strselectname = tb_name.Text = SLdata["ca_name"].ToString();
            //获取车类型
            DataRow[] ctypeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_transport_type'");
            foreach (DataRow dr in ctypeDR)
            {
                sl_CarType.Add(dr["value_code"].ToString().Trim(), dr["key_code"].ToString().Trim());
                this.cb_ctype.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取生产厂家
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            if (getdt != null)
            {
                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    sl_ProducerType.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                    this.cb_type.Items.Add(dr["v_name"].ToString().Trim());
                }
                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_ProducerType2.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                    this.cb_sales.Items.Add(dr["v_name"].ToString().Trim());
                }
                
            
                //修改时显示数据
                if (SLdata != null)
                {
                    this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改运输工具";
                    Strselectid = SLdata["id"].ToString();
                    Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                    this.tb_max_times.Text = SLdata["max_times"].ToString();
                    this.cb_ctype.Text = sl_CarType[SLdata["ca_type"].ToString()].ToString() + "：" + SLdata["ca_type"].ToString();
                    this.tb_barcode.Text = SLdata["bar_code"].ToString();
                    this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
                    this.cb_type.Text = sl_ProducerType[SLdata["ca_vender"].ToString()].ToString();
                    this.cb_sales.Text = sl_ProducerType2[SLdata["sales_id"].ToString()].ToString();
                }
            }
        }
       /// <summary>
       /// 新建按钮触发事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
 
        private void but_ok_Click_1(object sender, EventArgs e)
        {
            #region 输入时做验证
            if(tb_name.Text.Trim()=="")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning,new string[]{"运输工具"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillvender",EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_sales.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillsales", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_ctype.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning,new string[]{"运输工具"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_max_times.Text.Trim() == "")
            {
                tb_max_times.Text = "NULL";
            }
           
            #endregion
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-transport-device-sec001", sttmp02);
            try
            {
            if (Strselectid == "")//增加
            {
                #region 判断新增车名称是否相同
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
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[]{"运输工具"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, tb_name.Text.Trim());
                sltmp.Add(2, tb_barcode.Text.Trim());
                sltmp.Add(3, tb_max_times.Text.Trim());
                sltmp.Add(4, cb_ctype.Text.Trim().Substring(0, 1));
                sltmp.Add(5, sl_ProducerType.GetKey(sl_ProducerType.IndexOfValue(cb_type.Text.Trim())));
                sltmp.Add(6, tb_remarks.Text.Trim());
                sltmp.Add(7, sl_ProducerType2.GetKey(sl_ProducerType2.IndexOfValue(cb_sales.Text.Trim())));
                sltmp.Add(8, CnasBaseData.SystemID);
                sltmp01.Add(1, sltmp);
                //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-transport-device-add001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-transport-device-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful",EnumPromptMessage.warning,new string[]{"运输工具"}),"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                #region 判断车名称是否相同

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
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[]{"运输工具"}),"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                sltmp.Add(2, cb_ctype.Text.Trim().Substring(0, 1));
                sltmp.Add(3, tb_max_times.Text.Trim());
                sltmp.Add(4, sl_ProducerType.GetKey(sl_ProducerType.IndexOfValue(cb_type.Text.Trim())));
                sltmp.Add(5, sl_ProducerType2.GetKey(sl_ProducerType2.IndexOfValue(cb_sales.Text.Trim())));
                sltmp.Add(6, tb_remarks.Text.Trim());
                sltmp.Add(7, Strselectid);
                sltmp01.Add(1, sltmp);
                //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-transport-device-up001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-transport-device-up001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning,new string[]{"运输工具"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
       
        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 限制tb_max_times控件只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_max_times_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }          
        }


    }
}

     



    

       
