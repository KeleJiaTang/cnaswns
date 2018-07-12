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
    public partial class HCSRS_performance_appraisal : UserControl
    {
        private string user_id = "";
        // DataTable dtsel = null;//用于查询赛选
        public HCSRS_performance_appraisal()
        {
            InitializeComponent();
            this.but_excul.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_people.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "personnel", EnumImageType.PNG);
            this.but_dep.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "department", EnumImageType.PNG);
            //this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);

            // this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dt_end.Value = DateTime.Now;
        }

        private void but_sel_Click(object sender, EventArgs e)
        {

            Getdata();
        }

        private void Getdata()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, user_id);
            sttemp01.Add(2, dt_start.Value);
            sttemp01.Add(3, dt_end.Value);
            DataTable dtUsers = reCnasRemotCall.RemotInterface.SelectData("HCS-user-set-sec001", sttemp01);
            if (dtUsers != null && dtUsers.Rows.Count > 0)
            {
                DataRow[] arrayDR = null;
                dgv_01.Rows.Clear();
                // string strsecdata = tb_sname.Text.Trim().ToUpper();
                arrayDR = dtUsers.Select();
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (dtUsers.Columns.Contains("set_code") && dtUsers.Rows[i]["set_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["set_code"].ToString();
                    if (dtUsers.Columns.Contains("set_name") && dtUsers.Rows[i]["set_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["set_name"].ToString();
                    if (dtUsers.Columns.Contains("pd_name") && dtUsers.Rows[i]["pd_name"] != null) dgv_01.Rows[i].Cells["wf_code"].Value = dr["pd_name"].ToString();
                    if (dtUsers.Columns.Contains("cre_date") && dtUsers.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                    if (dtUsers.Columns.Contains("mod_date") && dtUsers.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["end_date"].Value = dr["mod_date"].ToString();
                    i++;
                }
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }

            SortedList SLkey_value = new SortedList();
            SLkey_value.Add("first_time", dt_start.Value);
            SLkey_value.Add("end_time", dt_end.Value);
            SLkey_value.Add("userid", user_id);
            DataSet DSnorm = new DataSet();
            DSnorm = reCnasRemotCall.RemotInterface.ExecuteProcedure("performance_appraisal", SLkey_value);
            if (DSnorm.Tables[0] != null && DSnorm.Tables[0].Rows.Count > 0)
            {
                DataRow[] arrayDR = null;
                dgv_02.Rows.Clear();

                arrayDR = DSnorm.Tables[0].Select();
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_02.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (DSnorm.Tables[0].Columns.Contains("num") && DSnorm.Tables[0].Rows[i]["num"] != null) dgv_02.Rows[i].Cells["num"].Value = dr["num"].ToString();
                    if (DSnorm.Tables[0].Columns.Contains("user_id") && DSnorm.Tables[0].Rows[i]["user_id"] != null) dgv_02.Rows[i].Cells["user"].Value = dr["user_id"].ToString();
                    if (DSnorm.Tables[0].Columns.Contains("wf_code") && DSnorm.Tables[0].Rows[i]["wf_code"] != null) dgv_02.Rows[i].Cells["wf_code"].Value = dr["wf_code"].ToString();
                    if (DSnorm.Tables[0].Columns.Contains("isconfirm") && DSnorm.Tables[0].Rows[i]["isconfirm"] != null) dgv_02.Rows[i].Cells["isconfirm"].Value = dr["isconfirm"].ToString();
                    if (DSnorm.Tables[0].Columns.Contains("pd_name") && DSnorm.Tables[0].Rows[i]["pd_name"] != null) dgv_02.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
                    i++;
                }

            }
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Getdata();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            HCSRS_performance_appraisal_select hcsm = new HCSRS_performance_appraisal_select();
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            //获得信息后，加载
            if (hcsm.sl_userinfo.Count > 0)
            {
                tb_nick.Text = hcsm.sl_userinfo["user_nick"].ToString();
                tb_code.Text = hcsm.sl_userinfo["user_bcode"].ToString();
                tb_name.Text = hcsm.sl_userinfo["user_name"].ToString();
                tb_user_type.Text = hcsm.sl_userinfo["user_typename"].ToString();
                user_id = hcsm.sl_userinfo["id"].ToString();
                if (hcsm.sl_userinfo["user_eid"].ToString() == "")
                {
                    tb_number.Text = "空";
                }
                else
                {
                    tb_number.Text = hcsm.sl_userinfo["user_eid"].ToString();
                }
            }
            dgv_02.Rows.Clear();
            dgv_01.Rows.Clear();
             but_ok_Click_1(null, null);
        }

        private void but_ok_Click_1(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, user_id);
            sttemp01.Add(2, dt_start.Value);
            sttemp01.Add(3, dt_end.Value);
            try
            {
                // string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-user-set-sec001", sttemp01);
                DataTable dtUsers = reCnasRemotCall.RemotInterface.SelectData("HCS-user-set-sec001", sttemp01);

                if (dtUsers != null && dtUsers.Rows.Count > 0)
                {
                    int ii = dtUsers.Rows.Count;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dtUsers.Columns.Contains("set_code") && dtUsers.Rows[i]["set_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dtUsers.Rows[i]["set_code"].ToString();
                        if (dtUsers.Columns.Contains("set_name") && dtUsers.Rows[i]["set_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dtUsers.Rows[i]["set_name"].ToString();
                        if (dtUsers.Columns.Contains("pd_name") && dtUsers.Rows[i]["pd_name"] != null) dgv_01.Rows[i].Cells["wf_code"].Value = dtUsers.Rows[i]["pd_name"].ToString();
                        if (dtUsers.Columns.Contains("cre_date") && dtUsers.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dtUsers.Rows[i]["cre_date"].ToString();
                        if (dtUsers.Columns.Contains("mod_date") && dtUsers.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["end_date"].Value = dtUsers.Rows[i]["mod_date"].ToString();
                    }
                    tb_inum.Text = dtUsers.Rows.Count.ToString();
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
                SortedList SLkey_value = new SortedList();
                SLkey_value.Add("first_time", dt_start.Value);
                SLkey_value.Add("end_time", dt_end.Value);
                SLkey_value.Add("userid", user_id);
                DataSet DSnorm = new DataSet();
                DSnorm = reCnasRemotCall.RemotInterface.ExecuteProcedure("performance_appraisal", SLkey_value);
                if (DSnorm == null) return;
                if (DSnorm.Tables[0] != null && DSnorm.Tables[0].Rows.Count > 0)
                {
                    DataRow[] arrayDR = null;
                    dgv_02.Rows.Clear();

                    arrayDR = DSnorm.Tables[0].Select();
                    int ii = arrayDR.Length;
                    if (ii <= 0) return;
                    dgv_02.RowCount = ii;
                    int i = 0;
                    foreach (DataRow dr in arrayDR)
                    {
                        if (DSnorm.Tables[0].Columns.Contains("num") && DSnorm.Tables[0].Rows[i]["num"] != null) dgv_02.Rows[i].Cells["num"].Value = dr["num"].ToString();
                        if (DSnorm.Tables[0].Columns.Contains("user_id") && DSnorm.Tables[0].Rows[i]["user_id"] != null) dgv_02.Rows[i].Cells["user"].Value = dr["user_id"].ToString();
                        if (DSnorm.Tables[0].Columns.Contains("wf_code") && DSnorm.Tables[0].Rows[i]["wf_code"] != null) dgv_02.Rows[i].Cells["wf_code"].Value = dr["wf_code"].ToString();
                        if (DSnorm.Tables[0].Columns.Contains("isconfirm") && DSnorm.Tables[0].Rows[i]["isconfirm"] != null) dgv_02.Rows[i].Cells["isconfirm"].Value = dr["isconfirm"].ToString();
                        if (DSnorm.Tables[0].Columns.Contains("pd_name") && DSnorm.Tables[0].Rows[i]["pd_name"] != null) dgv_02.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_dep_Click(object sender, EventArgs e)
        {
            HCSRS_performance_appraisal_department hcsrs = new HCSRS_performance_appraisal_department();
            hcsrs.ShowDialog();
        }

        private void MasterTemplate_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            if (zhu.SelectedIndex == 1)
            {
                RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            }
            else
            {
                RadPrintHelper.Print_DataGridView(this.dgv_02, pringxml);
            }


        }

        private void but_excul_Click(object sender, EventArgs e)
        {
            if (zhu.SelectedIndex == 1)
            {
                ExcelHelper.ImprotDataToExcel(this.dgv_01, "绩效考核");
            }
            else
            {
                ExcelHelper.ImprotDataToExcel(this.dgv_02, "绩效考核");
            }


        }
        /// <summary>
        /// 时间限制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dt_start_ValueChanged(object sender, EventArgs e)
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
                    DateTime cellValue = DateTime.Parse(item.Cells[0].Value.ToString());

                    if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(dt_end.Value, cellValue) > 0)
                    {
                        dgv_01.Rows.Add(item);
                    }
                }
            }
        }
        private List<GridViewRowInfo> _dataGridAllRows = new List<GridViewRowInfo>();
        /// <summary>
        /// 时间限制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dt_end_ValueChanged(object sender, EventArgs e)
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
                    DateTime cellValue = DateTime.Parse(item.Cells[0].Value.ToString());

                    if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(dt_end.Value, cellValue) > 0)
                    {
                        dgv_01.Rows.Add(item);
                    }
                }
            }
        }
    }
}
