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
    public partial class HCSCM_department_manage_new : TemplateForm
    {
        private string Strselectid = "";
        private string Strselectname = "";
        private string Customerid = "";
        public HCSCM_department_manage_new(SortedList SLdata, SortedList SLedit)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            //设置窗体图标
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建部门";
            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            Customerid = SLdata["id"].ToString();
            this.tb_customer.Text = SLdata["ca_name"].ToString();
            if (SLedit != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改部门";
                Strselectid = SLedit["id"].ToString();
                Strselectname = this.tb_name.Text = SLedit["ca_name"].ToString();
                if (SLedit["ca_remarks"] != null)
                    this.tb_remarks.Text = SLedit["ca_remarks"].ToString();


            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (this.tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Customerid);
            //sttemp01.Add(2, CnasBaseData.SystemID);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-department-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sttemp01);//173
            try
            {
                if (Strselectid == "")//insert data
                {
                    #region 判断名字是否存在

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
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());

                    sltmp01.Add(2, tb_remarks.Text.Trim());
                    sltmp01.Add(3, Customerid);

                    sltmp.Add(1, sltmp01);

                    // string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-department-add001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-department-add001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else//update date
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
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp01.Add(3, Strselectid);
                    sltmp.Add(1, sltmp01);
                    //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    //string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-customer-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-department-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { "部门" }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
