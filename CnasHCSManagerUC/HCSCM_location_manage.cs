using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Configuration;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_location_manage : UserControl
    {
        private SortedList sl_type = new SortedList();//使用地点类型
        private SortedList sl_customer = new SortedList();//客户
        private SortedList sl_costcenter = new SortedList();//成本中心
        DataTable DTcustomer = new DataTable();
        DataTable DTcostcenter = new DataTable();
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
        public HCSCM_location_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_export.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            //返回使用地点类型，用于给集合赋值
            DataRow[] uselocation = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach (DataRow dr in uselocation)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            //成本中心
            DTcostcenter = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (DTcostcenter != null)
            {
                int ii = DTcostcenter.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcostcenter.Rows[i]["id"].ToString() != null && DTcostcenter.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_costcenter.Add(DTcostcenter.Rows[i]["id"].ToString(), DTcostcenter.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            //客户
            DTcustomer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (DTcustomer != null)
            {
                this.cb_customer.Items.Add("----所有----");
                sl_customer.Add("0", "----所有----");
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["id"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null)
                    {

                        sl_customer.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                cb_customer.Text = "----所有----";
            }
            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
            ////表格栏底色
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            ////DGV表格首行字段居中对齐
            //dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCE'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
        }


        /// <summary>
        /// 刷新DGV表格数据
        /// </summary>
        /// <param name="u_customer"> 客户ID</param>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            dgv_01.ClearSelection();
            string strName = tb_select.Text.Trim();
            string strCustomer = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text)).ToString();
            string selectSql = string.Format("(u_uname like '%{0}%')", strName);
            if (strCustomer != "0")
                selectSql += string.Format(" and u_customer='{0}'", strCustomer);

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();

            sttemp01.Add(1, selectSql);
            //根据客户ID返回该客户的使用地点
            string showSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec020", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec020", sttemp01);

            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("u_barcode") && !string.IsNullOrEmpty(getdt.Rows[i]["u_barcode"].ToString())) dgv_01.Rows[i].Cells["u_barcode"].Value = getdt.Rows[i]["u_barcode"].ToString();
                    if (getdt.Columns.Contains("u_uname") && !string.IsNullOrEmpty(getdt.Rows[i]["u_uname"].ToString())) dgv_01.Rows[i].Cells["u_uname"].Value = getdt.Rows[i]["u_uname"].ToString();
                    if (getdt.Columns.Contains("u_customer") && !string.IsNullOrEmpty(getdt.Rows[i]["u_customer"].ToString())) dgv_01.Rows[i].Cells["u_customer"].Value = sl_customer[getdt.Rows[i]["u_customer"].ToString()].ToString();
                    if (getdt.Columns.Contains("u_locationtype") && !string.IsNullOrEmpty(getdt.Rows[i]["u_locationtype"].ToString())) dgv_01.Rows[i].Cells["u_locationtype"].Value = sl_type[getdt.Rows[i]["u_locationtype"].ToString()].ToString();
                    if (getdt.Columns.Contains("u_costcenter") && !string.IsNullOrEmpty(getdt.Rows[i]["u_costcenter"].ToString())) dgv_01.Rows[i].Cells["u_costcenter"].Value = sl_costcenter[getdt.Rows[i]["u_costcenter"].ToString()].ToString();
                    if (getdt.Columns.Contains("u_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["u_remarks"].ToString())) dgv_01.Rows[i].Cells["u_remarks"].Value = getdt.Rows[i]["u_remarks"].ToString();
                }
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        //private void GetData()
        //{
        //    dgv_01.Rows.Clear();
        //    dgv_01.ClearSelection();
        //    string strsecdata = tb_select.Text.Trim().ToUpper();

        //    string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
        //    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        //    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);


        //    if (str_usertp == "0")//查询所有客户的基本包
        //    {
        //        arrayDR = getdt.Select(" u_uname like '%" + strsecdata + "%' or u_barcode like '%" + strsecdata + "%'");
        //    }
        //    else
        //    {
        //        arrayDR = getdt.Select("u_customer=" + "'" + str_usertp + "'" + " and ( u_uname like '%" + strsecdata + "%' or u_barcode like '%" + strsecdata + "%' )");//根据客户查询包
        //    }
        //    int ii = arrayDR.Length;
        //    if (ii <= 0) return;
        //    dgv_01.RowCount = ii;
        //    int i = 0;
        //    foreach (DataRow dr in arrayDR)
        //    {
        //        if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
        //        if (getdt.Columns.Contains("u_barcode") && !string.IsNullOrEmpty(getdt.Rows[i]["u_barcode"].ToString())) dgv_01.Rows[i].Cells["u_barcode"].Value = dr["u_barcode"].ToString();
        //        if (getdt.Columns.Contains("u_uname") && !string.IsNullOrEmpty(getdt.Rows[i]["u_uname"].ToString())) dgv_01.Rows[i].Cells["u_uname"].Value = dr["u_uname"].ToString();
        //        if (getdt.Columns.Contains("u_customer") && !string.IsNullOrEmpty(getdt.Rows[i]["u_customer"].ToString())) dgv_01.Rows[i].Cells["u_customer"].Value = sl_customer[dr["u_customer"].ToString()].ToString();
        //        if (getdt.Columns.Contains("u_locationtype") && !string.IsNullOrEmpty(getdt.Rows[i]["u_locationtype"].ToString())) dgv_01.Rows[i].Cells["u_locationtype"].Value = sl_type[dr["u_locationtype"].ToString()].ToString();
        //        if (getdt.Columns.Contains("u_costcenter") && !string.IsNullOrEmpty(getdt.Rows[i]["u_costcenter"].ToString())) dgv_01.Rows[i].Cells["u_costcenter"].Value = sl_costcenter[dr["u_costcenter"].ToString()].ToString();
        //        if (getdt.Columns.Contains("u_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["u_remarks"].ToString())) dgv_01.Rows[i].Cells["u_remarks"].Value = dr["u_remarks"].ToString();
        //        i++;
        //    }
        //    if (dgv_01.Rows.Count > 0)
        //    {
        //        dgv_01.CurrentRow = dgv_01.Rows[0];
        //    }
        //}

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_location_manage_new hcsm = new HCSCM_location_manage_new(DTcostcenter, DTcustomer, null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["u_barcode"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_barcode"].Value);
                slindata.Add("u_uname", dgv_01.SelectedRows[0].Cells["u_uname"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_uname"].Value);
                slindata.Add("u_barcode", dgv_01.SelectedRows[0].Cells["u_barcode"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_barcode"].Value);
                slindata.Add("u_customer", dgv_01.SelectedRows[0].Cells["u_customer"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_customer"].Value);
                slindata.Add("u_costcenter", dgv_01.SelectedRows[0].Cells["u_costcenter"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_costcenter"].Value);
                slindata.Add("u_locationtype", dgv_01.SelectedRows[0].Cells["u_locationtype"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_locationtype"].Value);
                slindata.Add("u_remarks", dgv_01.SelectedRows[0].Cells["u_remarks"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["u_remarks"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HCSCM_location_manage_new hcsm = new HCSCM_location_manage_new(DTcostcenter, DTcustomer, slindata);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
           
               
                    Loaddata();
           
            if (dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                string remove = "";
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["s_uselocation"].ToString().Trim())
                        {
                            remove = "该使用地点已被存储点，";
                            break;
                        }
                    }
                }
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;

                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["location_id"].ToString().Trim())
                        {
                            remove = remove + "实体包占用，如要删除，请先解除与以上的关联。";
                            MessageBox.Show(remove);
                            return;
                        }
                    }
                }


                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["u_uname"].Value.ToString(), "使用地点" }), ConfigurationManager.AppSettings["SystemName"] + "--删除使用地点", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasremotCall = new CnasRemotCall();
                //根据使用地点ID删除数据
                int recint = reCnasremotCall.RemotInterface.UPData(1, "HCS-use-location-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Loaddata(null);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        DataRow[] arrayDR = null;
        private void tb_select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Loaddata();
            }
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            Loaddata();
        }



        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "使用地点");
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_01.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //获得当前选择行数据
                string barCode = dgv_01.CurrentRow.Cells["u_barcode"].Value != null ?
                    dgv_01.CurrentRow.Cells["u_barcode"].Value.ToString() : string.Empty;
                string codeName = dgv_01.CurrentRow.Cells["u_uname"].Value != null ?
                    dgv_01.CurrentRow.Cells["u_uname"].Value.ToString() : string.Empty;

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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='uselocation'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            //  PrintHelper.Instance.Print_DataGridView(this.dgv_01, pringxml);
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
                Loaddata();
        
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Loaddata();
        }




    }
}


