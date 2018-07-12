using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using CnasUI;
namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_location_manage_new : TemplateForm
    {
        SortedList sl_place = new SortedList();//使用地点类型
        SortedList sl_customer = new SortedList();//客户
        SortedList sl_costcenter = new SortedList();//成本中心
        private string Selectid = "";//存ID，用于修改
        string Strselectname="";//存名称，用于修改时判断名称是否更改过。


        public HCSCM_location_manage_new(DataTable DTcostcenter, DataTable DTcustomer, SortedList SLdate)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建使用地点";
          
            if (DTcustomer != null)
            {
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["id"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null && DTcustomer.Rows[i]["bar_code"].ToString().Trim() != null)
                    {
                        sl_customer.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            //返回使用地点类型数据
            DataRow[] uselocation = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach(DataRow dr in uselocation)
            {
                sl_place.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                cb_type.Items.Add(dr["key_code"].ToString().Trim()+":"+ dr["value_code"].ToString().Trim());
            }
            if(SLdate!=null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改使用地点";
                Selectid = SLdate["id"].ToString();
                tb_barcode.Text = SLdate["bar_code"].ToString();
               Strselectname= tb_name.Text = SLdate["u_uname"].ToString().Trim();
                cb_type.Text = sl_place.GetKey(sl_place.IndexOfValue(SLdate["u_locationtype"].ToString())).ToString() + ":" + SLdate["u_locationtype"].ToString();
                cb_customer.Text =SLdate["u_customer"].ToString();
                cb_customer_SelectedIndexChanged(cb_customer, null);
                cb_costcenter.Text = SLdate["u_costcenter"].ToString();
                tb_remarks.Text = SLdate["u_remarks"].ToString().Trim();

            }            
        }
 
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   /// <summary>
   /// “新建”按钮触发事件
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
        private void but_ok_Click(object sender, EventArgs e)
        {
            if(tb_name.Text.Trim()=="")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname",EnumPromptMessage.warning,new string[]{"使用地点"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(cb_type.Text.Trim()=="")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_customer.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_costcenter.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            if (Selectid == "")
            {
                #region 判断名字是否相同
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));//
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec003", sttemp01);//248
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (tb_name.Text.Trim().ToString() == dr["u_uname"].ToString().Trim())
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                #endregion
                SortedList sttmp = new SortedList();
                SortedList sttmp01 = new SortedList();
                sttmp.Add(1, tb_barcode.Text.Trim());
                sttmp.Add(2, tb_name.Text.Trim());
                sttmp.Add(3, cb_type.Text.Trim().Substring(0, 1));
                sttmp.Add(4, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));
                sttmp.Add(5, sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_costcenter.Text.Trim())));
                sttmp.Add(6, 1);
                sttmp.Add(7, tb_remarks.Text.Trim());
                sttmp01.Add(1, sttmp);
                
                //string dd = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-use-location-add001", sttmp01, null);
                //增加使用地点数据
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-use-location-add001", sttmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }

            //修改
            else
            {
                #region 判断名称是否相同
                 CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    if (this.tb_name.Text.Trim() != Strselectname)
                    {
                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec003", sttemp01);//49
                        if (getdt != null)
                        {
                            int ii = getdt.Rows.Count;
                            if (ii <= 0) return;
                            for (int i = 0; i < ii; i++)
                            {
                                if (getdt.Rows[i]["u_uname"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["u_uname"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sltmp.Add(2, cb_type.Text.Trim().Substring(0, 1));
                    sltmp.Add(3, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));
				    sltmp.Add(4, sl_costcenter.ContainsValue(cb_costcenter.Text.Trim())? sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_costcenter.Text.Trim())):null);
                    sltmp.Add(5, tb_remarks.Text.Trim());
                    sltmp.Add(6, Selectid);
                    sltmp01.Add(1, sltmp);
                    
                //string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-use-location-up001", sltmp01, null);
                //保存修改后的数据
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-use-location-up001", sltmp01, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        

        

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            

        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_costcenter.Items.Clear();
            sl_costcenter.Clear();
            // string text = cb_customer.SelectedItem.Text;
            //获取客户ID，即cu_id
            string str = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text)).ToString();
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //根据客户ID返回对应客户的成本中心数据
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_costcenter.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());

                        this.cb_costcenter.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
        }
    }
}
