using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_specialset_add : TemplateForm
    {
        public SortedList sl_spe = new SortedList();
        public SortedList sl_customerid = new SortedList();
        public SortedList sl_customer = new SortedList();
        public SortedList sl_location = new SortedList();
		public SortedList sl_costcenterbar = new SortedList();


		private string Strselectid = "";
		private string Strselectname = "";
        public HCSCM_specialset_add(SortedList sltmp)
        {
            InitializeComponent();
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--添加订单器械模板";
            CnasRemotCall reCnasRemotCall=new CnasRemotCall();
            DataTable DTcustomer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (DTcustomer != null)
            {
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["bar_code"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_customerid.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        sl_customer.Add(DTcustomer.Rows[i]["bar_code"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            this.Font = new Font(this.Font.FontFamily, 11);
            if(sltmp!=null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改订单器械模板";
                Strselectid = sltmp["id"].ToString();
				Strselectname=tb_name.Text = sltmp["name"].ToString();
                cb_customer.Text = sltmp["customer"].ToString();
                cb_customer_SelectedIndexChanged(cb_customer, null);
                cb_location.Text = sltmp["location"].ToString();
            }
        }

        private void HCSCM_specialset_add_Load(object sender, EventArgs e)
        {

        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            #region 验证
            if (tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_customer.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "客户" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_location.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			try
			{
			#endregion

				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList sttName = new SortedList();
				sttName.Add(1, CnasBaseData.SystemID);
				sttName.Add(2, cb_customer.Text);
				DataTable CustomerName = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sec002", sttName);





				SortedList sttemp = new SortedList();
				sttemp.Add(1, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.Trim())));
				DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec010", sttemp);//49
				sl_costcenterbar.Clear();
				if (getdt != null)
				{
					int ii = getdt.Rows.Count;
					if (ii <= 0) return;
					for (int i = 0; i < ii; i++)
					{
						if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
						{
							sl_costcenterbar.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
						}
					}
				}
				if (Strselectid == "")
				{
					if (CustomerName != null)
					{
						for (int i = 0; i < CustomerName.Rows.Count; i++)
						{
							if (CustomerName.Rows[i]["name"].ToString() == tb_name.Text.Trim())
							{
								MessageBox.Show("该医院已存在该订单模板。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
					}
					SortedList sltmp = new SortedList();
					SortedList sltmp01 = new SortedList();
					sltmp.Add(1, tb_name.Text.Trim());//名字
					sltmp.Add(2, CnasBaseData.UserBaseInfo.UserName);
					sltmp.Add(3, CnasBaseData.SystemID);
					sltmp.Add(4, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.ToString().ToString())));
					sltmp.Add(5, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.ToString().ToString())));
					sltmp.Add(6, getdt.Rows[0]["bar_code"].ToString());

					sltmp01.Add(1, sltmp);

					int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-specialset-add001", sltmp01, null);

					if (recint > -1)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						SortedList slttp = new SortedList();
						slttp.Add(1, CnasBaseData.SystemID);
						slttp.Add(2, cb_customer.Text.Trim());
						DataTable Specialset = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sec002", slttp);
						if (Specialset != null && Specialset.Rows.Count > 0)
						{
							for (int i = 0; i < Specialset.Rows.Count; i++)
							{
								sl_spe.Add(Specialset.Rows[i]["id"].ToString(), Specialset.Rows[i]["name"].ToString());
							}
						}
						SortedList slttmp = new SortedList();
						slttmp.Add("id", sl_spe.GetKey((int)sl_spe.IndexOfValue(tb_name.Text)).ToString());
						slttmp.Add("name", tb_name.Text);
						slttmp.Add("customer", sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.ToString())));
						slttmp.Add("customerid", sl_customerid.GetKey(sl_customerid.IndexOfValue(cb_customer.Text.ToString())));
						slttmp.Add("costcentername", getdt.Rows[0]["bar_code"].ToString());
						slttmp.Add("costcenter", sl_costcenterbar[getdt.Rows[0]["bar_code"].ToString()].ToString());

						HCSCM_specialset_item_add hcsm = new HCSCM_specialset_item_add(slttmp, true);
						hcsm.ShowDialog();
					}
				}
				else
				{
					if (tb_name.Text != Strselectname)
					{
						if (CustomerName != null)
						{
							for (int i = 0; i < CustomerName.Rows.Count; i++)
							{
								if (CustomerName.Rows[i]["name"].ToString() == tb_name.Text.Trim())
								{
									MessageBox.Show("该医院已存在该订单模板。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
									return;
								}
							}
						}
					}
					SortedList slltp = new SortedList();
					SortedList slltp01 = new SortedList();
					slltp.Add(1, tb_name.Text);
					slltp.Add(2, CnasBaseData.UserBaseInfo.UserName);

					slltp.Add(3, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.ToString().ToString())));
					slltp.Add(4, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.ToString().ToString())));
					slltp.Add(5, getdt.Rows[0]["bar_code"].ToString());
					slltp.Add(6, Strselectid);
					slltp01.Add(1, slltp);
					int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-specialset-up001", slltp01, null);
					}
			}
			catch(Exception ex)
			{

			}
					
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
		}

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_location.Items.Clear();
            sl_location.Clear();
            string str = sl_customerid.GetKey(sl_customerid.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_location.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["u_uname"].ToString().Trim());
                        this.cb_location.Items.Add(getdt.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
        }
    }
}
