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

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_operational_costs : UserControl
    {
        private SortedList sl_type = new SortedList();
        private SortedList sl_user = new SortedList();
        public HCSRS_operational_costs()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            //this.Font = new Font(this.Font.FontFamily, 11);
            tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
          


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            //获取用户表数据
            DataTable User = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sltmp);
            if (User != null)
            {
                int kk = User.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (User.Rows[i]["id"].ToString() != null && User.Rows[i]["user_name"].ToString() != null)
                    {
                        sl_user.Add(User.Rows[i]["id"].ToString(), User.Rows[i]["user_name"].ToString());
                    }
                }
            }
            //获取运营成本类型
              DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-operationalcosts-type'");
            foreach (DataRow dr in typeDR)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                //cb_type.Items.Add(dr["key_code"].ToString().Trim()+":"+dr["value_code"].ToString().Trim());
            }
            int index = 0;
            //给年份的下拉列表赋值
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
            cb_year.Text = DateTime.Now.Year.ToString();//初始化时显示当前年份
            cb_month.Text = DateTime.Now.Month.ToString().Trim();//初始化时显示当前月份
            Loaddataall();
        }
        /// <summary>
        /// 根据年月筛选出数据
        /// </summary>
        public void Loaddata()
        {
            tb_aa.Visible = true;
            tb_money.Visible = true;
            tb_sum.Visible = true;
            lb_aa.Visible = true;
            lb_money.Visible = true;
            lb_sum.Visible = true;
            DataTable getdt = null;
            int a = 0;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
          
                slttmp.Add(1, cb_year.Text.Trim());
                slttmp.Add(2, cb_month.Text.Trim());
                string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-operatingcost-sec001", slttmp);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-operatingcost-sec001", slttmp);
                tb_money.Clear();
                tb_money.Text = "0";
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii > 0) 
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("operation_type") && !string.IsNullOrEmpty(getdt.Rows[i]["operation_type"].ToString())) dgv_01.Rows[i].Cells["typeCol"].Value = sl_type[getdt.Rows[i]["operation_type"].ToString()].ToString();
                    if (getdt.Columns.Contains("operation_num") && !string.IsNullOrEmpty(getdt.Rows[i]["operation_num"].ToString())) dgv_01.Rows[i].Cells["moneyCol"].Value = int.Parse(getdt.Rows[i]["operation_num"].ToString()).ToString("C");
                    if (getdt.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_date"] .ToString())) dgv_01.Rows[i].Cells["cre_dateCol"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("up_date") && !string.IsNullOrEmpty(getdt.Rows[i]["up_date"] .ToString())) dgv_01.Rows[i].Cells["up_dateCol"].Value = getdt.Rows[i]["up_date"].ToString();
                    if (getdt.Columns.Contains("cre_user") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_user"].ToString())) dgv_01.Rows[i].Cells["cre_userCol"].Value = sl_user[getdt.Rows[i]["cre_user"].ToString()].ToString();
                    if (getdt.Columns.Contains("up_user") && !string.IsNullOrEmpty(getdt.Rows[i]["up_user"].ToString())) dgv_01.Rows[i].Cells["up_userCol"].Value = getdt.Rows[i]["up_user"].ToString() == "" ? "" : sl_user[getdt.Rows[i]["up_user"].ToString()].ToString();
                    if (getdt.Columns.Contains("remark") && !string.IsNullOrEmpty(getdt.Rows[i]["remark"].ToString())) dgv_01.Rows[i].Cells["remarkCol"].Value = getdt.Rows[i]["remark"].ToString();
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["idCol"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("entering_date") && !string.IsNullOrEmpty(getdt.Rows[i]["entering_date"].ToString())) dgv_01.Rows[i].Cells["timeCol"].Value = Convert.ToDateTime(getdt.Rows[i]["entering_date"]).ToString("yyyy-MM");
                    a += int.Parse(getdt.Rows[i]["operation_num"].ToString());

                }
                tb_money.Text = a.ToString("C");
				if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
                }
            
            slttmp.Clear();
            slttmp.Add(1, cb_year.Text.Trim());
            slttmp.Add(2, cb_month.Text.Trim()); 
            slttmp.Add(3, cb_year.Text.Trim());
            slttmp.Add(4, cb_month.Text.Trim());
            slttmp.Add(5, cb_year.Text.Trim());
            slttmp.Add(6, cb_month.Text.Trim());
            DataTable instrument = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec027", slttmp);
            tb_sum.Clear();

            if(instrument!=null)
            {
                tb_sum.Text = instrument.Rows[0]["SUM(sum)"].ToString() == null ? "0" : instrument.Rows[0]["SUM(sum)"].ToString();
            }
            tb_aa.Clear();
            if(tb_sum.Text=="0")
            {
                tb_aa.Text = "0";
            }
            else
			{
				if (tb_money.Text.Substring(1) != "")
				{

					double aa = double.Parse(tb_money.Text.Substring(1)) / double.Parse(tb_sum.Text);
					tb_aa.Text = Math.Round(aa, 2).ToString("C");
				}
				
            }
            }
        
       /// <summary>
       /// 刷新DGV数据
       /// </summary>
        public void Loaddataall()
        {
            tb_aa.Visible = false;
            tb_money.Visible = false;
            tb_sum.Visible = false;
            lb_aa.Visible = false;
            lb_money.Visible = false;
            lb_sum.Visible = false;
            DataTable getdt = null;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
           
            string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-operatingcost-sec002", null);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-operatingcost-sec002", null);

            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii > 0)
                    dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("operation_type") && !string.IsNullOrEmpty(getdt.Rows[i]["operation_type"].ToString())) dgv_01.Rows[i].Cells["typeCol"].Value = sl_type[getdt.Rows[i]["operation_type"].ToString()].ToString();
                    if (getdt.Columns.Contains("operation_num") && !string.IsNullOrEmpty(getdt.Rows[i]["operation_num"].ToString())) dgv_01.Rows[i].Cells["moneyCol"].Value = int.Parse(getdt.Rows[i]["operation_num"].ToString()).ToString("C");
                    if (getdt.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_dateCol"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("up_date") && !string.IsNullOrEmpty(getdt.Rows[i]["up_date"].ToString())) dgv_01.Rows[i].Cells["up_dateCol"].Value = getdt.Rows[i]["up_date"].ToString();
                    if (getdt.Columns.Contains("cre_user") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_user"].ToString())) dgv_01.Rows[i].Cells["cre_userCol"].Value = sl_user[getdt.Rows[i]["cre_user"].ToString()].ToString();
                    if (getdt.Columns.Contains("up_user") && !string.IsNullOrEmpty(getdt.Rows[i]["up_user"].ToString())) dgv_01.Rows[i].Cells["up_userCol"].Value = getdt.Rows[i]["up_user"].ToString() == "" ? "" : sl_user[getdt.Rows[i]["up_user"].ToString()].ToString();
                    if (getdt.Columns.Contains("remark") && !string.IsNullOrEmpty(getdt.Rows[i]["remark"].ToString())) dgv_01.Rows[i].Cells["remarkCol"].Value = getdt.Rows[i]["remark"].ToString();
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["idCol"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("entering_date") && !string.IsNullOrEmpty(getdt.Rows[i]["entering_date"].ToString())) dgv_01.Rows[i].Cells["timeCol"].Value = Convert.ToDateTime(getdt.Rows[i]["entering_date"]).ToString("yyyy-MM");
                }
				if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
                }
            }
        
    
        /// <summary>
        /// 导出列表触发事件
        /// </summary>
        private void but_import_Click(object sender, EventArgs e)
        {
            //ExcelHelper.ImprotDataToExcel(this.dgv_01, "");
        }
        /// <summary>
        /// 打印列表触发事件
        /// </summary>
        private void but_list_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();

           // PrintHelper.Instance.Print_DataGridView(this.dgv_01, pringxml);
        }
        private void but_new_Click_1(object sender, EventArgs e)
        {
            HCSRS_operational_costs_new HCRS = new HCSRS_operational_costs_new(null);
            HCRS.ShowDialog();
            Loaddata();
        }

        private void but_update_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "运营成本" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SortedList slttep = new SortedList();
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            string strmoney = dgv_01.SelectedRows[0].Cells["moneyCol"].Value.ToString();
            slttep.Add("id", dgv_01.SelectedRows[0].Cells["idCol"].Value);
            slttep.Add("type", dgv_01.SelectedRows[0].Cells["typeCol"].Value);
            slttep.Add("money",double.Parse(strmoney.Substring(1)));
            slttep.Add("time", dgv_01.SelectedRows[0].Cells["timeCol"].Value);
            slttep.Add("remark", dgv_01.SelectedRows[0].Cells["remarkCol"].Value);

            HCSRS_operational_costs_new HCRS = new HCSRS_operational_costs_new(slttep);
            HCRS.ShowDialog();
			Loaddata();
			if (dgv_01.Rows.Count > selectedIndex)
			{
				dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
			}
        }

        private void cb_month_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Loaddata();
        }

        private void cb_year_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Loaddata();
        }

        private void but_selall_Click(object sender, EventArgs e)
        {
            Loaddataall();
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "运营成本");
        }

        private void MasterTemplate_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

		private void dgv_01_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			but_update_Click(null, null);
		}
    }
}
