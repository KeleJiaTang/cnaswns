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

namespace Cnas.wns.CnasHCSReporManagerUC
{
    public partial class HCSRM_security_event_report_new : TemplateForm
    {
        private string Strselectid = "";//选择的那一行数据的ID
        public HCSRM_security_event_report_new(SortedList SLdata)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //设置窗体图标
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建安全报告";
            tb_tracking_Time.Value = DateTime.Now;
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改安全报告";
                Strselectid = SLdata["id"].ToString();
                this.tb_existing_Problems.Text = SLdata["existing_Problems"].ToString();
                this.tb_reason.Text = SLdata["Reason"].ToString();
                this.tb_improvement_Measures.Text = SLdata["improvement_Measures"].ToString();
                this.tb_charge_Person.Text = SLdata["charge_Person"].ToString();
                this.tb_report_Person.Text = SLdata["report_Person"].ToString();
                this.tb_audit_Person.Text = SLdata["audit_Person"].ToString();
                this.tb_result_Tracking.Text = SLdata["result_Tracking"].ToString();
                this.tb_tracking_Time.Text = SLdata["tracking_Time"].ToString();
                this.tb_tracker.Text = SLdata["tracker"].ToString();
                this.tb_remarks.Text = SLdata["remarks"].ToString();
            }

        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ok_Click(object sender, EventArgs e)
        {
            if (tb_existing_Problems.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("pleaseFillIn", EnumPromptMessage.warning, new string[] { "存在问题" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (tb_charge_Person.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("pleaseFillIn", EnumPromptMessage.warning, new string[] { "负责人" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (tb_report_Person.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("pleaseFillIn", EnumPromptMessage.warning, new string[] { "报告人" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (tb_audit_Person.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("pleaseFillIn", EnumPromptMessage.warning, new string[] { "审核人" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (tb_tracker.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("pleaseFillIn", EnumPromptMessage.warning, new string[] { "追踪者" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}


            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                if (Strselectid == "")//insert data
                {
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_existing_Problems.Text.Trim());
                    sltmp01.Add(2, tb_reason.Text.Trim());
                    sltmp01.Add(3, tb_improvement_Measures.Text.Trim());
                    sltmp01.Add(4, tb_charge_Person.Text.Trim());
                    sltmp01.Add(5, tb_report_Person.Text.Trim());
                    sltmp01.Add(6, tb_audit_Person.Text.Trim());
                    sltmp01.Add(7, tb_result_Tracking.Text.Trim());
                    if (tb_tracking_Time.Text.Trim() != "")
                    {
                        sltmp01.Add(8, tb_tracking_Time.Value);
                    }
                    else
                    {
                        sltmp01.Add(8, "NULL");
                    }

                    sltmp01.Add(9, tb_tracker.Text.Trim());
                    sltmp01.Add(10, tb_remarks.Text.Trim());
                    sltmp01.Add(11, CnasBaseData.SystemID);
                    sltmp.Add(1, sltmp01);

                    string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-safetyTimeReport-add001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-safetyTimeReport-add001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "安全报告" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }

                }
                else
                {
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_existing_Problems.Text.Trim());
                    sltmp01.Add(2, tb_reason.Text.Trim());
                    sltmp01.Add(3, tb_improvement_Measures.Text.Trim());
                    sltmp01.Add(4, tb_charge_Person.Text.Trim());
                    sltmp01.Add(5, tb_report_Person.Text.Trim());
                    sltmp01.Add(6, tb_audit_Person.Text.Trim());
                    sltmp01.Add(7, tb_result_Tracking.Text.Trim());
                    if (tb_tracking_Time.Text.Trim() != "")
                    {
                        sltmp01.Add(8, tb_tracking_Time.Value);
                    }
                    else
                    {
                        sltmp01.Add(8, "NULL");
                    }

                    sltmp01.Add(9, tb_tracker.Text.Trim());
                    sltmp01.Add(10, tb_remarks.Text.Trim());
                    sltmp01.Add(11, Strselectid);
                    sltmp.Add(1, sltmp01);
                    //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-safetyTimeReport-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-safetyTimeReport-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "安全报告" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_tracking_Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

    }
}
