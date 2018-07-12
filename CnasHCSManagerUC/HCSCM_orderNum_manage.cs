using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using Cnas.wns.CnasBarcodeLib;
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_orderNum_manage : UserControl
    {
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
        SortedList Sl_location = new SortedList();//存储成本中心
        SortedList Sl_customer = new SortedList();//存储客户
        DataTable dtsel = null;//dgv的内容  
        public HCSCM_orderNum_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printCode.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_printList.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);

            #endregion
            // this.dgv_01.SelectionChanged += new System.EventHandler(this.dgv_01_SelectionChanged_1);
            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            //this.Font = new Font(this.Font.FontFamily, 11);
            //表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCT'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);//location

            DataTable Customer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (Customer != null)
            {
                this.cb_customer.Items.Add("----所有----");
                Sl_customer.Add("0", "----所有----");
                int kk = Customer.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Customer.Rows[i]["bar_code"].ToString() != null && Customer.Rows[i]["cu_name"].ToString() != null)
                    {
                        Sl_customer.Add(Customer.Rows[i]["bar_code"].ToString(), Customer.Rows[i]["cu_name"].ToString());
                        cb_customer.Items.Add(Customer.Rows[i]["cu_name"].ToString());
                    }
                }
                cb_customer.Text = "----所有----";
            }
            Loaddata(null);
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }
        private void Loaddata(string cu_barcode)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = null;
            if (cu_barcode == null)
            {
               // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-orderid-manager-sec001", sttemp01);
                dtsel = getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-orderid-manager-sec001", sttemp01);

            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-orderid-manager-sec003", sttemp01);
                dtsel = getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-orderid-manager-sec003", sttemp01);
            }


            if (getdt != null)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();//值是bar_code
                    if (getdt.Columns.Contains("ca_name1") && getdt.Rows[i]["ca_name1"] != null)
                    {
                        dgv_01.Rows[i].Cells["costbar_codename"].Value = getdt.Rows[i]["ca_name1"].ToString();
                        dgv_01.Rows[i].Cells["costbar_code"].Value = getdt.Rows[i]["costbar_code"].ToString();
                    }
                    if (getdt.Columns.Contains("u_uname") && getdt.Rows[i]["u_uname"] != null)
                    {
                        dgv_01.Rows[i].Cells["location_name"].Value = getdt.Rows[i]["u_uname"].ToString();
                        dgv_01.Rows[i].Cells["location_id"].Value = getdt.Rows[i]["location_id"].ToString();
                    }
                    if (getdt.Columns.Contains("cu_name") && getdt.Rows[i]["cu_name"] != null)
                    {
                        dgv_01.Rows[i].Cells["customer_barcode"].Value = getdt.Rows[i]["customer_barcode"].ToString();
                        dgv_01.Rows[i].Cells["customer_barcodename"].Value = getdt.Rows[i]["cu_name"].ToString();
                    }

                    if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("remark") && getdt.Rows[i]["remark"] != null) dgv_01.Rows[i].Cells["remark"].Value = getdt.Rows[i]["remark"].ToString();

                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
            }
        }
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_orderNum_manage_new hcscm = new HCSCM_orderNum_manage_new(null);
            hcscm.ShowDialog();
            Loaddata(null);
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            SortedList slindata = new SortedList();
            //if (dgv_01.SelectedRows.Count > 0)
            //{

            //    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "基本包" }), "删除基本包", MessageBoxButtons.YesNo) == DialogResult.No) return;

            //    SortedList sltmp = new SortedList();
            //    SortedList sltmp01 = new SortedList();
            //    sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            //    sltmp01.Add(2, dgv_01.SelectedRows[0].Cells["id"].Value);
            //    sltmp.Add(1, sltmp01);
            //    string a = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-del001", sltmp, null);
            //    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-base-del001", sltmp, null);
            //    if (recint > -1)
            //    {
            //        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Loaddata(null);
            //    }
            //}
            //else
            //{

            //}
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "订单号");
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_01.CurrentRow == null)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //获得当前选择行数据
                string barCode = dgv_01.CurrentRow.Cells["bar_code"].Value != null ?
                    dgv_01.CurrentRow.Cells["bar_code"].Value.ToString() : string.Empty;
                string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
                    dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

                if (!string.IsNullOrEmpty(barCode))
                {
                    SortedList parameters = new SortedList();
                    parameters.Add("BarcodeValue", barCode);
                    parameters.Add("Value", codeName);

                    string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
                    if (!string.IsNullOrEmpty(printResult))
                        MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(Sl_customer.GetKey(Sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void GetData()
        {

            if (dtsel != null && dtsel.Rows.Count > 0)
            {
                DataRow[] arrayDR = null;
                dgv_01.Rows.Clear();
                string strsecdata = tb_select.Text.Trim().ToUpper();
				try
				{
                    arrayDR = dtsel.Select("ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%' or u_uname like '%" + strsecdata + "%' ");
				}
				catch
				{
					MessageBox.Show("输入的信息有误，请重新输入。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {

                    if (dtsel.Columns.Contains("id") && dtsel.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    if (dtsel.Columns.Contains("ca_name") && dtsel.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                    if (dtsel.Columns.Contains("bar_code") && dtsel.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();//值是bar_code
                    if (dtsel.Columns.Contains("ca_name1") && dtsel.Rows[i]["ca_name1"] != null)
                    {
                        dgv_01.Rows[i].Cells["costbar_codename"].Value = dr["ca_name1"].ToString();
                        dgv_01.Rows[i].Cells["costbar_code"].Value = dr["costbar_code"].ToString();
                    }
                    if (dtsel.Columns.Contains("u_uname") && dtsel.Rows[i]["u_uname"] != null)
                    {
                        dgv_01.Rows[i].Cells["location_name"].Value = dr["u_uname"].ToString();
                        dgv_01.Rows[i].Cells["location_id"].Value = dr["location_id"].ToString();
                    }
                    if (dtsel.Columns.Contains("cu_name") && dtsel.Rows[i]["cu_name"] != null)
                    {
                        dgv_01.Rows[i].Cells["customer_barcode"].Value = dr["customer_barcode"].ToString();
                        dgv_01.Rows[i].Cells["customer_barcodename"].Value = dr["cu_name"].ToString();
                    }

                    if (dtsel.Columns.Contains("cre_date") && dtsel.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                    if (dtsel.Columns.Contains("remark") && dtsel.Rows[i]["remark"] != null) dgv_01.Rows[i].Cells["remark"].Value = dr["remark"].ToString();
                    i++;



                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
            }
        }
        private void but_select_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void tb_select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                GetData();
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList slindata = new SortedList();
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("costbar_codename", dgv_01.SelectedRows[0].Cells["costbar_codename"].Value);//值是barcode
                slindata.Add("location_name", dgv_01.SelectedRows[0].Cells["location_name"].Value);
                slindata.Add("customer_barcodename", dgv_01.SelectedRows[0].Cells["customer_barcodename"].Value);
                slindata.Add("cre_date", dgv_01.SelectedRows[0].Cells["cre_date"].Value);
                slindata.Add("remark", dgv_01.SelectedRows[0].Cells["remark"].Value);

                HCSCM_orderNum_manage_new hcsm = new HCSCM_orderNum_manage_new(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
				if (tb_select.Text == string.Empty)
				{
					if (cb_customer.Text == "----所有----")
					{
						Loaddata(null);
					}
					else
					{
						Loaddata(Sl_customer.GetKey(Sl_customer.IndexOfValue(cb_customer.Text.ToString())).ToString());
					}
				}
				else
				{
					GetData();
				}
                if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void but_remove_Click_1(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "订单号" }), ConfigurationManager.AppSettings["SystemName"] + "--删除器械模块", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasremotCall = new CnasRemotCall();
            int recint = reCnasremotCall.RemotInterface.UPData(1, "HCS-orderid-manager-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "订单号" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                if (dgv_01.Rows.Count > 0)
                {
                    if (selectedIndex == 0)//删除后判断是否为0
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                    else
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex - 1];
                    }
                }
                //Loaddata(null);
            }
        }


        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(Sl_customer.GetKey(Sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void dgv_01_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                if (dgv_01.SelectedRows[0].Cells["bar_code"].Value == null) return;
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec022", sttemp01);
                if (getdt == null || getdt.Rows.Count <= 0)
                {
                    but_edit.Enabled = true;
                    but_remove.Enabled = true;
                }
                else
                {
                    but_edit.Enabled = false;
                    but_remove.Enabled = false;
                }
            }
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (but_edit.Enabled == true)
            {
                but_edit_Click(null, null);
            }
        }


    }
}
