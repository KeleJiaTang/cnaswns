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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_set_recall : UserControl
    {
        public SortedList sl_sterilizer = new SortedList();//
        public SortedList sl_program = new SortedList();
        public SortedList sterilizer_batch = new SortedList();
        public SortedList sterilizer = null;
        public HCSRS_set_recall()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_set.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "packageSel", EnumImageType.PNG);
            this.but_sterilizer.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "sterilizer", EnumImageType.PNG);

          //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            //string ff = reCnasRemotCall.RemotInterface.SelectData("HCS_sterilizer_device_sec001", sltmp);
            DataTable Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-device-sec001", sltmp);
            if (Sterilizer != null)
            {
                int ii = Sterilizer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Sterilizer.Rows[i]["ca_name"].ToString() != null && Sterilizer.Rows[i]["bar_code"].ToString() != null)
                    {
                        sl_sterilizer.Add(Sterilizer.Rows[i]["bar_code"].ToString(), Sterilizer.Rows[i]["ca_name"].ToString());
                    }
                }
            }

            DataTable Program = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
            if (Program != null)
            {
                int kk = Program.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Program.Rows[i]["bar_code"].ToString() != null && Program.Rows[i]["pr_name"].ToString() != null)
                    {
                        sl_program.Add(Program.Rows[i]["bar_code"].ToString(), Program.Rows[i]["pr_name"].ToString());
                    }
                }
            }
        }

        public void LoadData()
        {
            if (sterilizer.Count == 0) return;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            slttmp.Add(1, sterilizer["s_barcode"].ToString());
            string dd = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec010", slttmp);
            DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec010", slttmp);
            dgv_01.Rows.Clear();
            if (getdt01 != null)
            {
                _dataGridAllRows.Clear();
                for (int i = 0; i < getdt01.Rows.Count; i++) 
                {
                    int dgvIndex = dgv_01.Rows.AddNew().Index;
                    if (getdt01.Columns.Contains("container_code") && getdt01.Rows[i]["container_code"] != null) dgv_01.Rows[dgvIndex].Cells["s_name"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
                    if (getdt01.Columns.Contains("info_data") && getdt01.Rows[i]["info_data"] != null) dgv_01.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
                    if (getdt01.Columns.Contains("device_runtimes") && getdt01.Rows[i]["device_runtimes"] != null) dgv_01.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
                    if (getdt01.Columns.Contains("cre_date") && getdt01.Rows[i]["cre_date"] != null) dgv_01.Rows[dgvIndex].Cells["s_time"].Value = getdt01.Rows[i]["cre_date"];
                    _dataGridAllRows.Add(dgv_01.Rows[dgvIndex]);
                }
            }
                //dgv_01.Rows[0].IsSelected = true;


                List<DateTime> lst = new List<DateTime>();//所有批次时间转为数组。
                DataGridView dv = new DataGridView();
                //给数组每个元素赋值
                foreach (GridViewRowInfo dr in dgv_01.Rows)
                {
                    lst.Add(DateTime.Parse(dr.Cells["s_time"].Value.ToString()));
                }
                DateTime temp;
                //以升序排列批次时间
                for (int i = 0; i < lst.Count; i++)
                {
                    for (int j = i + 1; j < lst.Count; j++)
                    {
                        if (lst[j] < lst[i])
                        {
                            temp = lst[j];
                            lst[j] = lst[i];
                            lst[i] = temp;
                        }
                    }
                }
                if (lst.Count <= 0) return;
                dt_start.Value = lst[0].Date;//给查询开始时间赋最小值
                dt_end.Value = lst[lst.Count - 1].AddDays(1);//给查询结束时间赋最大值
            }
        

        private List<GridViewRowInfo> _dataGridAllRows = new List<GridViewRowInfo>();
        private void but_set_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show("你好，没有灭菌批次选择。请先选择灭菌批次。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sterilizer_batch.Clear();
                if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
                {
                    sterilizer_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
                    sterilizer_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
                }
                HCSRS_FindSet FS = new HCSRS_FindSet(sterilizer_batch);
                FS.ShowDialog();
            }
        }

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            if (dt_end.Value < dt_start.Value && !string.IsNullOrEmpty(dt_start.Text)
                && !string.IsNullOrEmpty(dt_end.Text))
            {
                RadDateTimePicker currentPicker = sender as RadDateTimePicker;
                if (currentPicker != null)
                {
                    if (currentPicker.Name == "dt_start")
                    {
                        MessageBox.Show("你好，你设置的开始时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("你好。你设置的结束时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                DateTime d = dt_start.Value;
                string starttime = d.ToString("yyyy/MM/dd hh:mm:ss");
                DateTime p = dt_end.Value;
                string endtime = d.ToString("yyyy/MM/dd hh:mm:ss");
                dgv_01.Rows.Clear();
                foreach (GridViewRowInfo item in _dataGridAllRows)
                {
                    DateTime cellValue = DateTime.Parse(item.Cells["s_time"].Value.ToString());

                    if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(dt_end.Value, cellValue) > 0)
                    {
                        dgv_01.Rows.Add(item);
                    }
                }
            }
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();

            //PrintHelper.Instance.Print_DataGridView(this.dgv_01, pringxml);
        }
        private void radButton3_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "灭菌器批次");
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            HCSRS_SterilizerDevice SD = new HCSRS_SterilizerDevice();
            SD.ShowDialog();

            sterilizer = SD.Sterilizer;
            LoadData();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show("你好，没有灭菌批次选择。请先选择灭菌批次。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sterilizer_batch.Clear();
                if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
                {
                    sterilizer_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
                    sterilizer_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
                }
                HCSRS_FindSet FS = new HCSRS_FindSet(sterilizer_batch);
                FS.ShowDialog();
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

        private void radButton4_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }
    }
}
