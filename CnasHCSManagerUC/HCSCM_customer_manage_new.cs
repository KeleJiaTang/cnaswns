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
    public partial class HCSCM_customer_manage_new : TemplateForm
    {
       private string Strselectid="";
       private string Strselectname = "";
       SortedList sl_type = new SortedList();

       public HCSCM_customer_manage_new(SortedList SLdata, DataRow[] arrayDR)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //设置窗体图标
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建客户";
            foreach (DataRow dr in arrayDR)
            {
                //根据编号找厂商
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());
            }
            if(SLdata!=null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改客户";
                Strselectid = SLdata["id"].ToString();
                Strselectname= this.tb_name.Text = SLdata["cu_name"].ToString();
                this.tb_barcode.Text=SLdata["bar_code"].ToString();
                this.tb_address.Text = SLdata["cu_address"].ToString();
                this.tb_contacts.Text = SLdata["c_contacts"].ToString();
                this.tb_telephone.Text = SLdata["c_telephone"].ToString();
                this.tb_mail.Text = SLdata["c_mail"].ToString();
               
                if(SLdata["ca_type"]!=null)  this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["ca_type"].ToString())).ToString() + "：" + SLdata["ca_type"].ToString();
          
                
            }

        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if(this.tb_name.Text.Trim()=="")
            {

                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname",EnumPromptMessage.warning,new string[]{"客户"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_type.Text == null)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "医院" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(tb_telephone.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_telephone.Text))
                {
                    MessageBox.Show("联系电话输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                //如果用户输入的值不为邮箱，则提示用户
                if (!CnasUtilityTools.IsEmail(tb_mail.Text))
                {
                    MessageBox.Show("电子邮箱输入的格式不正确，请输入正确格式，如：123@qq.com。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if(tb_mail.Text.Trim()==null)
            {
                tb_mail.Text = "";
            }
            if (tb_telephone.Text.Trim() == null)
            {
                tb_mail.Text = "";
            }
            if (tb_contacts.Text.Trim() == null)
            {
                tb_mail.Text = "";
            }


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec001", sttemp01);

            try
            {

                if (Strselectid == "")//insert data
                {
                    #region 判断名字是否存在
                    //39
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["cu_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "医院" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                    sltmp01.Add(2, tb_barcode.Text.Trim());
                    sltmp01.Add(3, tb_address.Text.Trim());
                    sltmp01.Add(4, cb_type.Text.Trim().Substring(0, 1));
                    sltmp01.Add(5, tb_contacts.Text.Trim());
                    sltmp01.Add(6, tb_telephone.Text.Trim());
                    sltmp01.Add(7, tb_mail.Text.Trim());
                    sltmp01.Add(8, CnasBaseData.SystemID);

                    sltmp.Add(1, sltmp01);

                    //string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-customer-add001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-customer-add001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "客户" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                if (getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["cu_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] {"医院"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp01.Add(2, tb_address.Text.Trim());
                    sltmp01.Add(3, cb_type.Text.Trim().Substring(0, 1));
                    sltmp01.Add(4, tb_contacts.Text.Trim());
                    sltmp01.Add(5, tb_telephone.Text.Trim());
                    sltmp01.Add(6, tb_mail.Text.Trim());
                    sltmp01.Add(7, Strselectid);
                    sltmp.Add(1, sltmp01);
                    //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-customer-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-customer-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "客户" }),"提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
