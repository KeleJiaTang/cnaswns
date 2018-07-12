using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_sterilizer_program_new : TemplateForm
    {
        SortedList sl_type = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        public HCSCM_sterilizer_program_new(SortedList SLdata, DataRow[] arrayDR)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);

            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建灭菌程序";
            Strselectname = tb_program.Text;
            foreach (DataRow dr in arrayDR)
            {

                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());

            }
            if (SLdata != null)//在窗体上显示信息
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改灭菌程序";
                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_program.Text = SLdata["pr_name"].ToString();
                this.tb_barcode.Text = SLdata["bar_code"].ToString();
                this.tb_run_time.Text = SLdata["run_time"].ToString();
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
                this.tb_upper_level.Text = SLdata["upper_level"].ToString();
                this.tb_lower_level.Text = SLdata["lower_level"].ToString();
                this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["p_type"].ToString())) + ":" + SLdata["p_type"].ToString();
            }
        }
        private void but_OK_Click_1(object sender, EventArgs e)
        {
            if (this.tb_program.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname",EnumPromptMessage.warning,new string[]{"灭菌程序"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "灭菌" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_run_time.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillruntime", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(this.tb_upper_level.Text.Trim()=="")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillhightemperature",EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(tb_upper_level.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_upper_level.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat", EnumPromptMessage.warning,new string[]{"温度上限","123整数"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.tb_lower_level.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filllowtemperature", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(tb_lower_level.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_lower_level.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat", EnumPromptMessage.warning, new string[] { "温度下限", "123整数" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if(int.Parse(tb_lower_level.Text)>int.Parse(tb_upper_level.Text))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("tempestimation", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (Strselectid == "")//增加
                {
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_program.Text.Trim());
                    sltmp.Add(2, tb_barcode.Text.Trim());
                    sltmp.Add(3, cb_type.Text.Substring(0, 1));
                    sltmp.Add(4, tb_run_time.Text.Trim());

                    sltmp.Add(5, tb_remarks.Text.Trim());
                    sltmp.Add(6, tb_upper_level.Text.Trim());
                    sltmp.Add(7, tb_lower_level.Text.Trim());
                    sltmp01.Add(1, sltmp);
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    #region 判断名字是否存在


                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec002", null);//49
                    if (getdt != null)
                    {
                        DataRow[] getdt_01 = getdt.Select();
                        foreach (DataRow dr in getdt_01)
                        {


                            if (tb_program.Text.Trim().ToString() == dr["pr_name"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "灭菌程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }


                        }
                    }
                    #endregion


                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-program-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful",EnumPromptMessage.warning,new string[]{"灭菌程序"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    #region 判断程序名字是否重复
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    if (tb_program.Text.Trim() != Strselectname)
                    {

                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
                        if (getdt != null)
                        {
                            DataRow[] getdt_01 = getdt.Select();
                            foreach (DataRow dr in getdt_01)
                            {
                                if (tb_program.Text.Trim().ToString() == dr["pr_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "灭菌程序" }),"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }



                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_program.Text.Trim());
                    sltmp01.Add(2, tb_upper_level.Text.Trim());
                    sltmp01.Add(3, tb_lower_level.Text.Trim());

                    sltmp01.Add(4, cb_type.Text.Substring(0, 1));
                    sltmp01.Add(5, tb_run_time.Text.Trim());
                    sltmp01.Add(6, tb_remarks.Text.Trim());
                    sltmp01.Add(7, Strselectid);
                    sltmp.Add(1, sltmp01);
                    string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-sterilizer-program-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-program-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "灭菌程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror",EnumPromptMessage.error,new string[]{ex.Message}), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HCSCM_sterilizer_program_new_Load(object sender, EventArgs e)
        {

        }

        private void lb_program_Click(object sender, EventArgs e)
        {

        }

        private void tb_run_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_upper_level_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_lower_level_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
    }
}
