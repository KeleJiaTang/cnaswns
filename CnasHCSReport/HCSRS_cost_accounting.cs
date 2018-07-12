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
using Telerik.WinControls.UI;
using System.Threading;
using System.Globalization;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_cost_accounting : UserControl
    {
        //private SortedList sl_customer = new SortedList();//存储barcode,客户
        //private SortedList sl_customer01 = new SortedList();//存储id,客户
        private SortedList sl_costcenter = new SortedList();//存储barcode，成本中心
        public HCSRS_cost_accounting()
        {
            InitializeComponent();

            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            ////DGV表格首行字段居中对齐
            //dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取客户表的数据
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt != null)
            {
                foreach (DataRow item in getdt.Rows)
                {
                    if (item["id"].ToString() != null && item["cu_name"].ToString().Trim() != null && item["bar_code"].ToString().Trim() != null)
                    {
                        RadListDataItem cbxItem = new RadListDataItem(item["cu_name"].ToString().Trim(), CnasUtilityTools.ConcatTwoString(item["id"].ToString().Trim(), item["bar_code"].ToString().Trim()));
                        cb_customer.Items.Add(cbxItem);
                    }
                    cb_customer.SelectedIndex = 0;
                }
            }
            //cb_customer.Text = getdt.Rows[0]["cu_name"].ToString().Trim();
            //给年份的下拉列表赋值
            int index = 0;
            for (int i = 2000; i < DateTime.Now.Year + 1; i++)
            {
                RadListDataItem cbxItem = new RadListDataItem(i.ToString(), i.ToString());

                cb_year.Items.Add(cbxItem);
                if (i == DateTime.Now.Year)
                    cb_year.SelectedIndex = index;
                index++;
            }
            //给月份的下拉列表赋值
            for (int i = 1; i < 13; i++)
            {
                RadListDataItem cbxItem = new RadListDataItem(i.ToString(), i.ToString());
                cb_month.Items.Add(cbxItem);
                if (i == DateTime.Now.Month)
                    cb_month.SelectedIndex = i - 1;
            }


        }
        /// <summary>
        /// “查询”触发事件
        /// </summary>

        private void but_sel_Click(object sender, EventArgs e)
        {
            GetData();
            dgv_01.Rows[0].IsSelected = true;
            dgv_02.Rows[0].IsSelected = true;
        }
        /// <summary>
        /// 根据条件获取数据
        /// </summary>
        private void GetData()
        {
            tb_sum.Text = string.Empty;
            tb_num01.Text = string.Empty;
            tb_num02.Text = string.Empty;
            string customerValue = cb_customer.SelectedItem != null && cb_customer.SelectedItem.Value != null ? cb_customer.SelectedItem.Value.ToString() : string.Empty;
            string costcenterValue = cb_costcenter.SelectedItem != null && cb_costcenter.SelectedItem.Value != null ? cb_costcenter.SelectedItem.Value.ToString() : string.Empty;
            string yearValue = cb_year.SelectedItem != null && cb_year.SelectedItem.Value != null ? cb_year.SelectedItem.Value.ToString() : string.Empty;
            string monthValue = cb_month.SelectedItem != null && cb_month.SelectedItem.Value != null ? cb_month.SelectedItem.Value.ToString() : string.Empty;
            dgv_01.Rows.Clear();
            dgv_01.ClearSelection();

            dgv_02.Rows.Clear();
            dgv_02.ClearSelection();
            if (!string.IsNullOrEmpty(customerValue) && !string.IsNullOrEmpty(costcenterValue)
                && !string.IsNullOrEmpty(yearValue) && !string.IsNullOrEmpty(monthValue))
            {

                string[] ids = customerValue.Split(':');
                if (ids.Length >= 2)
                {
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    SortedList slttmp = new SortedList();
                    slttmp.Add(1, costcenterValue);
                    slttmp.Add(2, ids[1]);
                    slttmp.Add(3, cb_year.Text.ToString());
                    slttmp.Add(4, cb_month.Text.ToString());
                    double a = 0;
                    double b = 0;
                    string qq = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec016", slttmp);
                    DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec016", slttmp);
                    if (getdt01 != null)
                    {

                        int ii = getdt01.Rows.Count;
                        if (ii <= 0) return;
                        dgv_01.RowCount = ii;

                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt01.Columns.Contains("set_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["set_code"].ToString())) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt01.Rows[i]["set_code"].ToString();
                            if (getdt01.Columns.Contains("set_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["set_name"].ToString())) dgv_01.Rows[i].Cells["s_name"].Value = getdt01.Rows[i]["set_name"].ToString();
                            if (getdt01.Columns.Contains("price") && !string.IsNullOrEmpty(getdt01.Rows[i]["price"].ToString())) dgv_01.Rows[i].Cells["s_money"].Value = double.Parse(getdt01.Rows[i]["price"].ToString()).ToString("C"); ;
                            if (getdt01.Columns.Contains("send_count") && !string.IsNullOrEmpty(getdt01.Rows[i]["send_count"].ToString())) dgv_01.Rows[i].Cells["s_times"].Value = getdt01.Rows[i]["send_count"].ToString();
                            if (getdt01.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = getdt01.Rows[i]["ca_name"].ToString();
                            string setCount = Convert.ToString(getdt01.Rows[i]["send_count"]);
                            string price = Convert.ToString(getdt01.Rows[i]["price"]);
                            double setCountNum = 0;
                            double.TryParse(setCount, out setCountNum);
                            double pricetNum = 0;
                            double.TryParse(price, out pricetNum);
                            b += setCountNum * pricetNum;
                        }
                        tb_num02.Text = b.ToString("C");

                    }
                    if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                    string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec015", slttmp);
                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec015", slttmp);
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        dgv_02.RowCount = ii;

                        for (int i = 0; i < ii; i++)
                        {
                            //int rowIndwx = dgv_02.Rows.AddNew().Index;
                            if (getdt.Columns.Contains("set_code") && !string.IsNullOrEmpty(getdt.Rows[i]["set_code"].ToString())) dgv_02.Rows[i].Cells["s_barcode01"].Value = getdt.Rows[i]["set_code"].ToString();
                            if (getdt.Columns.Contains("set_name") && !string.IsNullOrEmpty(getdt.Rows[i]["set_name"].ToString())) dgv_02.Rows[i].Cells["s_name01"].Value = getdt.Rows[i]["set_name"].ToString();
                            if (getdt.Columns.Contains("handle_price") && !string.IsNullOrEmpty(getdt.Rows[i]["handle_price"].ToString())) dgv_02.Rows[i].Cells["s_price01"].Value = double.Parse(getdt.Rows[i]["handle_price"].ToString()).ToString("C");
                            if (getdt.Columns.Contains("count(0)") && !string.IsNullOrEmpty(getdt.Rows[i]["count(0)"].ToString())) dgv_02.Rows[i].Cells["s_num01"].Value = getdt.Rows[i]["count(0)"].ToString();
                            string setCount = Convert.ToString(getdt.Rows[i]["count(0)"]);
                            string price = Convert.ToString(getdt.Rows[i]["handle_price"]);
                            double setCountNum = 0;
                            double.TryParse(setCount, out setCountNum);
                            double pricetNum = 0;
                            double.TryParse(price, out pricetNum);
                            a += setCountNum * pricetNum;
                        }

                        tb_num01.Text = a.ToString("C");
                    }
                    tb_sum.Text = (a + b).ToString("C");
                    if (dgv_02.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
                    {
                        dgv_02.CurrentRow = dgv_02.Rows[0];
                    }
                }
            }
        }
        /// <summary>
        /// "成本中心"触发事件
        /// </summary>
        private void but_import_Click(object sender, EventArgs e)
        {
            // ExcelHelper.ImprotDataToExcel(this.dgv_01, "cssd处理成本");

        }

        private void but_list_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            RadPrintHelper.Print_DataGridView(this.dgv_02, pringxml);
            // PrintHelper.Instance.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void GetCostCenterItems()
        {
            this.cb_costcenter.Items.Clear();
            string value = cb_customer.SelectedItem != null && cb_customer.SelectedItem.Value != null ? cb_customer.SelectedItem.Value.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                string[] ids = value.Split(':');
                if (ids.Length >= 2)
                {
                    SortedList sl_barcode = new SortedList();
                    sl_barcode.Add(1, ids[0]);
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();

                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//获取属于该客户的成本中心
                    if (getdt != null)
                    {
                        foreach (DataRow item in getdt.Rows)
                        {
                            if (item["bar_code"].ToString() != null && item["ca_name"].ToString().Trim() != null)
                            {
                                RadListDataItem cbxItem = new RadListDataItem(item["ca_name"].ToString().Trim(), item["bar_code"].ToString().Trim());
                                cb_costcenter.Items.Add(cbxItem);
                            }
                        }
                        cb_costcenter.SelectedIndex = 0;
                    }
                }
            }
        }

        /// <summary>
        ///  "客户"触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCustomerChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetCostCenterItems();
        }

        private void OnComboxChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetData();
        }

        private void but_sel_Click_1(object sender, EventArgs e)
        {
            GetData();
            if (dgv_01.Rows.Count == 0) return;
            dgv_01.Rows[0].IsSelected = true;
            if (dgv_02.Rows.Count == 0) return;
            dgv_02.Rows[0].IsSelected = true;
        }

        private void dgv_02_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

        private void dgv_01_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='DisposeCost'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            if (dgv_01.RowCount <= 0 && dgv_02.RowCount <= 0)
            {
                MessageBox.Show("没有数据打印。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_01.RowCount > 0)
                RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml, null, new string[] { cb_costcenter.Text, cb_customer.Text, cb_year.Text + "年" + cb_month.Text + "月" });
            if (dgv_02.RowCount > 0)
                RadPrintHelper.Print_DataGridView(this.dgv_02, pringxml, null, new string[] { cb_costcenter.Text, cb_customer.Text, cb_year.Text + "年" + cb_month.Text + "月" });

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (dgv_01.RowCount <= 0 && dgv_02.RowCount <= 0)
            {
                MessageBox.Show("没有数据导出。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dgv_01.Rows.Count > 0)
            {
                ExcelHelper.ImprotDataToExcel(this.dgv_01, "临时包");
            }
            else if (dgv_02.Rows.Count > 0)
            {
                ExcelHelper.ImprotDataToExcel(this.dgv_02, "普通包");
            }
        }
    }
}
