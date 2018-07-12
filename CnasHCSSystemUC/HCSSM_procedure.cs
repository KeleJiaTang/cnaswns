using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_procedure : UserControl
    {
        private DataTable dtallpd = new DataTable();
        private SortedList slwptyp = new SortedList();
        private string strbarcodexml = "";

        public HCSSM_procedure()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_barcode.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_list.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_app.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "appProcess", EnumImageType.PNG);
            this.but_relation.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "relatedProgram", EnumImageType.PNG);
            this.but_par.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "processParameter", EnumImageType.PNG);

            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //string aa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-procedure-sec001", sttemp01);
            dtallpd = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sttemp01);
            if (dtallpd == null)
            {
                MessageBox.Show("对不起！没有流程数据，请联系管理员");
            }


            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach (DataRow dr in arrayDR)
            {
                slwptyp.Add(dr["value_code"].ToString().Trim(),dr["key_code"].ToString().Trim());
                cb_app.Items.Add(dr["value_code"].ToString().Trim());
                cb_app.Text = "全部流程";
            }

            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCV'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
            cb_app_SelectedIndexChanged(null, null);
        }
        private void but_relation_Click(object sender, EventArgs e)
        {
            //if (dgv_01.CurrentRow == null) return;
            //string str_id = dgv_01.CurrentRow.Cells["id"].Value.ToString();
            //string str_name = dgv_01.CurrentRow.Cells["pd_name"].Value.ToString();
            //string str_code = dgv_01.CurrentRow.Cells["pd_code"].Value.ToString();
            //HCSSM_procedure_relation hctmp = new HCSSM_procedure_relation(str_id, str_name,str_code, this.dtallpd);
            //hctmp.ShowDialog();
            //SortedList sttemp02 = new SortedList();
            //sttemp02.Add(1, CnasBaseData.SystemID);
            //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //dtallpd = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sttemp02);

       
        }
        private void but_app_Click_1(object sender, EventArgs e)
        {

            HCSSM_app_bpm HCSSM_app_bpm01 = new HCSSM_app_bpm();
            //获取一个值，指是否在Windows任务栏中显示窗体。
            HCSSM_app_bpm01.ShowInTaskbar = false;
            HCSSM_app_bpm01.ShowDialog();
        }

        private void but_relation_Click_1(object sender, EventArgs e)
        {

            HCSSM_procedure_relationship HCSSM_procedure_relationship01 = new HCSSM_procedure_relationship(dtallpd);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            HCSSM_procedure_relationship01.ShowInTaskbar = false;
            HCSSM_procedure_relationship01.ShowDialog();
        }

        private void but_par_Click_1(object sender, EventArgs e)
        {

            HCSSM_procedure_parameters HCSSM_procedure_parameters01 = new HCSSM_procedure_parameters(dtallpd);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            HCSSM_procedure_parameters01.ShowInTaskbar = false;
            HCSSM_procedure_parameters01.ShowDialog();
        }

        private void but_import_Click_1(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "流程管理");
        }

        private void but_barcode_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.CurrentRow == null)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["pd_bcode"].Value != null ?
					dgv_01.CurrentRow.Cells["pd_bcode"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["pd_name"].Value != null ?
					dgv_01.CurrentRow.Cells["pd_name"].Value.ToString() : string.Empty;

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

        private void but_list_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='procedure'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void cb_app_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_01.Rows.Clear();
            if (cb_app.Text == "全部流程")
            {
                DataRow[] arrayDR = dtallpd.Select("pd_type>=0");
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (dtallpd.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    //if (dr["pd_code"] != null) dgv_01.Rows[i].Cells["pd_code"].Value = dr["pd_code"].ToString();
					if (dtallpd.Columns.Contains("pd_name") && dr["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
					if (dtallpd.Columns.Contains("pd_bcode") && dr["pd_bcode"] != null) dgv_01.Rows[i].Cells["pd_bcode"].Value = dr["pd_bcode"].ToString();
					if (dtallpd.Columns.Contains("pd_description") && dr["pd_description"] != null) dgv_01.Rows[i].Cells["pd_description"].Value = dr["pd_description"].ToString();
                    i++;
                }
            }
            else
            {
                DataRow[] arrayDR = dtallpd.Select("pd_type=" + slwptyp[cb_app.Text].ToString());
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
					if (dtallpd.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    //if (dr["pd_code"] != null) dgv_01.Rows[i].Cells["pd_code"].Value = dr["pd_code"].ToString();
					if (dtallpd.Columns.Contains("pd_name") && dr["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
					if (dtallpd.Columns.Contains("pd_bcode") && dr["pd_bcode"] != null) dgv_01.Rows[i].Cells["pd_bcode"].Value = dr["pd_bcode"].ToString();
					if (dtallpd.Columns.Contains("pd_description") && dr["pd_description"] != null) dgv_01.Rows[i].Cells["pd_description"].Value = dr["pd_description"].ToString();
                    i++;
                }
			} dgv_01.CurrentRow = dgv_01.Rows[0];

        }

        private void radTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string strsecdata = tb_search.Text.Trim();
                dgv_01.Rows.Clear();
                if (cb_app.Text == "全部流程")
                {
                    DataRow[] arrayDR = dtallpd.Select("pd_name like '%" + strsecdata + "%' or pd_bcode like '%" + strsecdata + "%'");
                    int ii = arrayDR.Length;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    int i = 0;
                    foreach (DataRow dr in arrayDR)
                    {
						if (dtallpd.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                        //if (dr["pd_code"] != null) dgv_01.Rows[i].Cells["pd_code"].Value = dr["pd_code"].ToString();
						if (dtallpd.Columns.Contains("pd_name") && dr["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
						if (dtallpd.Columns.Contains("pd_bcode") && dr["pd_bcode"] != null) dgv_01.Rows[i].Cells["pd_bcode"].Value = dr["pd_bcode"].ToString();
						if (dtallpd.Columns.Contains("pd_description") && dr["pd_description"] != null) dgv_01.Rows[i].Cells["pd_description"].Value = dr["pd_description"].ToString();
                        i++;
                    }
                }
                else
                {
                    //DataRow[] arrayDR = dtappall.Select("app_parent='" + slappparent[cb_app.Text].ToString() + "'");
                    DataRow[] arrayDR = dtallpd.Select("pd_type='" + slwptyp[cb_app.Text].ToString() + "' and ( pd_name like '%" + strsecdata + "%' or pd_bcode like '%" + strsecdata + "%')");
                    int ii = arrayDR.Length;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    int i = 0;
                    foreach (DataRow dr in arrayDR)
                    {
						if (dtallpd.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                        //if (dr["pd_code"] != null) dgv_01.Rows[i].Cells["pd_code"].Value = dr["pd_code"].ToString();
						if (dtallpd.Columns.Contains("pd_name") && dr["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
						if (dtallpd.Columns.Contains("pd_bcode") && dr["pd_bcode"] != null) dgv_01.Rows[i].Cells["pd_bcode"].Value = dr["pd_bcode"].ToString();
						if (dtallpd.Columns.Contains("pd_description") && dr["pd_description"] != null) dgv_01.Rows[i].Cells["pd_description"].Value = dr["pd_description"].ToString();
                        i++;
                    }
                }
				if (dgv_01.RowCount > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            } 
        }

        private void dgv_01_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }
    }
}
