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
    public partial class HCSCM_set_manager_material_new : TemplateForm
    {
        private string Strselectid = "";
        private string Strselectname = "";
        public HCSCM_set_manager_material_new(SortedList SLdata)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建包装材料";
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改包装材料";
                Strselectid = SLdata["id"].ToString();
                Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                this.tb_expiration_day.Text = SLdata["expiration_day"].ToString();

            }
        }
        private DataTable getdt = new DataTable();
        private void but_ok_Click(object sender, EventArgs e)
        {
            if (this.tb_name.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname",EnumPromptMessage.warning,new string[]{"包装材料"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_expiration_day.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("expiration",EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-setmaterial-type-sec001", sttemp01);//49
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
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition",EnumPromptMessage.warning,new string[]{"包装材料"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }

                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                    sltmp01.Add(2, tb_expiration_day.Text.Trim());



                    sltmp.Add(1, sltmp01);

                    // string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-setmaterial-type-add001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-setmaterial-type-add001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful",EnumPromptMessage.warning,new string[]{"包装材料"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "包装材料" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp01.Add(2, tb_expiration_day.Text.Trim());

                    sltmp01.Add(3, Strselectid);
                    sltmp.Add(1, sltmp01);

                    //string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-setmaterial-type-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-setmaterial-type-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "包装材料" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error,new string[]{ex.Message}), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_expiration_day_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        
        
    }
}
