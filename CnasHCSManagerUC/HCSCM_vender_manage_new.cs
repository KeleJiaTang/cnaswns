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
    public partial class HCSCM_vender_manage_new : TemplateForm
    {
        SortedList sl_type = new SortedList();
        SortedList sl_type01 = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        public string type02 = "";  
        public HCSCM_vender_manage_new(SortedList SLdata)
        { 
            
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Font = new Font(this.Font.FontFamily, 11);
			chb_insvender.Enabled = true;
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建供应商";
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_vender_type'");
            foreach (DataRow dr in arrayDR)
            {
                //根据厂商找编号
                sl_type.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim(), dr["key_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());
                //根据编号找厂商
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());
            }
            if(SLdata!=null)//在窗体上显示信息
            {
                cb_type.Enabled = false;//不允许修改类型
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改供应商";
                Strselectid = SLdata["id"].ToString();
                Strselectname=this.tb_name.Text = SLdata["v_name"].ToString();
                this.tb_contact.Text = SLdata["contact_name"].ToString();
                this.cb_type.Text = sl_type01[SLdata["vender_type"].ToString()].ToString();
                this.tb_address.Text = SLdata["v_address"].ToString();
                this.tb_tele.Text = SLdata["v_telephone"].ToString();
                this.tb_postcode.Text = SLdata["v_postcode"].ToString();
                this.tb_email.Text = SLdata["v_email"].ToString();
                this.tb_website.Text = SLdata["v_website"].ToString();
				if( SLdata["insvender"].ToString()=="0")
				{
					chb_insvender.Checked = false;
				}
				else
				{
					chb_insvender.Checked = true;
				}
            }
                

            
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname",EnumPromptMessage.warning,new string[]{"供应商"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果价格不为null，则表示需要验证输入的值是否正确
            if (!string.IsNullOrEmpty(tb_tele.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_tele.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat",EnumPromptMessage.warning,new string[]{"电话","130****1234"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(tb_postcode.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_postcode.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat", EnumPromptMessage.warning, new string[] { "邮政编号", "520000" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            if (!string.IsNullOrEmpty(tb_email.Text))
            {
                //如果用户输入的值不为邮箱，则提示用户
                if (!CnasUtilityTools.IsEmail(tb_email.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat", EnumPromptMessage.warning, new string[] { "邮箱", "123@cnasis.com" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(tb_website.Text))
            {
                //如果用户输入的值不为网址，则提示用户
                if (!CnasUtilityTools.IsWeb(tb_website.Text))
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("inputformat",EnumPromptMessage.warning,new string[]{"网址","http://www.baidu.com"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);//31
                if (Strselectid == "")//增加
                {
                    #region 判断名字是否存在

                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt.Rows[i]["v_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["v_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition",EnumPromptMessage.warning,new string[]{"供应商"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());
                    sltmp.Add(2, tb_contact.Text.Trim());
                    sltmp.Add(3, tb_address.Text.Trim());
                    sltmp.Add(4, sl_type[cb_type.Text.Trim()].ToString());

                    sltmp.Add(5, tb_tele.Text.Trim());

                    sltmp.Add(6, tb_postcode.Text.Trim());
                    sltmp.Add(7, tb_email.Text.Trim());
                    sltmp.Add(8, tb_website.Text.Trim());
					sltmp.Add(9, "");				
					if(chb_insvender.Checked==true)
					{
						sltmp.Add(10, "1");
					}
					else
					{
						sltmp.Add(10, "0");
					}
                    sltmp01.Add(1, sltmp);
                    type02 = sl_type[cb_type.Text.Trim()].ToString();


                    //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-vender-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-vender-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else//修改
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
                                if (getdt.Rows[i]["v_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["v_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp01.Add(2, tb_contact.Text.Trim());
                    sltmp01.Add(3, tb_address.Text.Trim());
                    sltmp01.Add(4, cb_type.Text.Substring(0, 1));
                    sltmp01.Add(5, tb_tele.Text.Trim());
                    sltmp01.Add(6, tb_postcode.Text.Trim());
                    sltmp01.Add(7, tb_email.Text.Trim());
                    sltmp01.Add(8, tb_website.Text.Trim());

					
					if(chb_insvender.Checked==true)
					{
						sltmp01.Add(9, "1");
					}else
					{
						sltmp01.Add(9, "0");
					}
					sltmp01.Add(10, Strselectid);
                    sltmp.Add(1, sltmp01);
                    type02 = sl_type[cb_type.Text.Trim()].ToString();
                    CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                    //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-vender-up001", sltmp, null);
                    int recint = reCnasRemotCall_01.RemotInterface.UPData(1, "HCS-vender-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful",EnumPromptMessage.warning,new string[]{"供应商"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
