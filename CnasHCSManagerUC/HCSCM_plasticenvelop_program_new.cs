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
    public partial class HCSCM_plasticenvelop_program_new : TemplateForm
    {
        private string Strselectid = "";
        private string Strselectname = "";
        private SortedList sl_type = new SortedList();
        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();
        public HCSCM_plasticenvelop_program_new(SortedList SLdata, DataRow[] arrayDR)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = styStemName + "--添加塑封机程序";
            foreach (DataRow dr in arrayDR)
            {

                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());

            }

            if (SLdata != null)//在窗体上显示信息
            {
                this.Text = styStemName + "--修改塑封程序";

                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_name.Text = SLdata["pr_name"].ToString();
                this.tb_barcode.Text = SLdata["bar_code"].ToString();
                this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["p_type"].ToString())) + ":" + SLdata["p_type"].ToString();
                this.tb_run_time.Text = SLdata["run_time"].ToString();
                this.tb_run_temp.Text = SLdata["run_temp"].ToString();
                this.tb_run_speed.Text = SLdata["run_speed"].ToString();
                this.tb_run_stress.Text = SLdata["run_stress"].ToString();
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();

            }
        }
        DataTable getdt = new DataTable();
        private void but_ok_Click(object sender, EventArgs e)
        {
            #region  输入判断条件
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "塑封" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_run_time.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillruntime", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_run_temp.Text == "")
            {
                tb_run_temp.Text = "NULL";
            }


            if (tb_run_stress.Text == "")
            {
                tb_run_stress.Text = "NULL";
            }


            if (this.tb_run_speed.Text.Trim() == "")
            {
                tb_run_speed.Text = "NULL";
            }
            #endregion
            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-program-sec001", null);//49
                if (Strselectid == "")//增加
                {
                    #region 判断名字是否存在

                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["pr_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp.Add(3, tb_run_time.Text.Trim());
                    sltmp.Add(4, cb_type.Text.Substring(0, 1));
                    sltmp.Add(5, tb_run_temp.Text.Trim());
                    sltmp.Add(6, tb_run_stress.Text.Trim());
                    sltmp.Add(7, tb_run_speed.Text.Trim());
                    sltmp.Add(8, tb_remarks.Text.Trim());
                    sltmp01.Add(1, sltmp);

                    //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-washing-program-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-program-add001", sltmp01, null);


                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                if (getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["pr_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                    sltmp01.Add(2, tb_remarks.Text.Trim());
                    sltmp01.Add(3, tb_run_time.Text.Trim());
                    sltmp01.Add(4, cb_type.Text.Substring(0, 1));
                    sltmp01.Add(5, tb_run_temp.Text.Trim());
                    sltmp01.Add(6, tb_run_stress.Text.Trim());
                    sltmp01.Add(7, tb_run_speed.Text.Trim());
                    sltmp01.Add(8, Strselectid);
                    sltmp.Add(1, sltmp01);


                    //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-plasticenvelop-program-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-program-up001", sltmp, null);

                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tb_run_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
        private void tb_run_temp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
        private void tb_run_speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
        private void tb_run_stress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_run_time_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }


    }
}
