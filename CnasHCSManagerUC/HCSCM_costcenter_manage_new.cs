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
    public partial class HCSCM_costcenter_manage_new : TemplateForm
    {
        SortedList sl_type = new SortedList();
        private string Strselectid = "";//接收选择这一行的id
        private string Strselectname = "";
        public string type = "";
        public HCSCM_costcenter_manage_new(DataTable getdt, SortedList SLdata)
        {
            InitializeComponent();
			cb_type.Enabled = true;
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            //this.Font = new Font(this.Font.FontFamily, 11);
            //设置窗体图标
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建成本中心";
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                        //cb_type.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                        sl_type.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                    cb_type.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());

                }
            }
            if (SLdata != null)
            {
                Strselectid = SLdata["id"].ToString();
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改成本中心";

                this.tb_barcode.Text = SLdata["bar_code"].ToString();
                Strselectname = this.tb_name.Text = SLdata["ca_name"].ToString();
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
                this.tb_number.Text = SLdata["custmer_cnumber"].ToString();
                this.cb_type.Text = SLdata["cu_id"].ToString();
				cb_type.Enabled = false;
            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            
            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_name.Text.Trim() == "")
            {
                //CnasMessagebox.ShowCueMessage(null, PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning, new string[] { "成本中心" }));
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (Strselectid == "")//insert data
                {
                    #region 判断名字是否存在
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    SortedList sttemp01 = new SortedList();
                    sttemp01.Add(1, sl_type.GetKey(sl_type.IndexOfValue(cb_type.Text.Trim())).ToString());//客户id
                    sttemp01.Add(2, CnasBaseData.SystemID);
                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec050", sttemp01);//500
                    if (getdt != null)
                    {
                        DataRow[] getdt_01 = getdt.Select();
                        foreach (DataRow dr in getdt_01)
                        {
                            if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                    sltmp01.Add(2, tb_barcode.Text.Trim());
                    int index = sl_type.IndexOfValue(cb_type.Text.Trim());//获取值所在的索引
                    type = sl_type.GetKey(index).ToString();//根据索引取键
                    sltmp01.Add(3, type);
                    sltmp01.Add(4, tb_remarks.Text.Trim());
                    sltmp01.Add(5, tb_number.Text.Trim());
                    sltmp01.Add(6, CnasBaseData.SystemID);

                    sltmp.Add(1, sltmp01);
                    //  string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-costcenter-add001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-costcenter-add001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                {
                    #region 判断名字是否存在
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    if (this.tb_name.Text.Trim() != Strselectname)
                    {
                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, sl_type.GetKey(sl_type.IndexOfValue(cb_type.Text.Trim())).ToString());//客户id
                        sttemp01.Add(2, CnasBaseData.SystemID);
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec050", sttemp01);//500
                        if (getdt != null)
                        {
                            DataRow[] getdt_01 = getdt.Select();
                            foreach (DataRow dr in getdt_01)
                            {


                                if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, tb_name.Text.Trim());
                    int index = sl_type.IndexOfValue(cb_type.Text.Trim());//获取值所在的索引
                    type = sl_type.GetKey(index).ToString();//根据索引取键
                    sltmp01.Add(2, type);
                    sltmp01.Add(3, tb_remarks.Text.Trim());
                    sltmp01.Add(4, tb_number.Text.Trim());
                    sltmp01.Add(5, Strselectid);
                    sltmp.Add(1, sltmp01);


                    //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-costcenter-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-costcenter-up001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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




    }
}
