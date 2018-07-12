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

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_performance_appraisal_department : TemplateForm
    {
        private SortedList sl_customer = new SortedList();//客户集合
        private SortedList sl_department = new SortedList();//部门集合
        public HCSRS_performance_appraisal_department()
        {
            InitializeComponent();
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            but_list.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
                
            this.Text= ConfigurationManager.AppSettings["SystemName"].ToString() + "--部门绩效考核";
            //表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//部门
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
                    {
                        sl_customer.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            dt_end.Value = DateTime.Now;
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cb_department.SelectedItem == null)
                {
                    MessageBox.Show("请选择部门", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgv_01.Rows.Clear();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //SortedList sttemp01 = new SortedList();
                //sttemp01.Add(1, sl_department.GetKey(sl_department.IndexOfValue(cb_department.Text.Trim())));
                //sttemp01.Add(2, dt_start.Value);
                //sttemp01.Add(3, dt_end.Value);
                ////string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-departm-sec001", sttemp01);
                //DataTable dtUsers = reCnasRemotCall.RemotInterface.SelectData("HCS-set-departm-sec001", sttemp01);
                //if (dtUsers != null)
                //{
                //    int ii = dtUsers.Rows.Count;
                //    if (ii <= 0) return;
                //    dgv_01.RowCount = ii;
                //    for (int i = 0; i < ii; i++)
                //    {
                //        if (dtUsers.Columns.Contains("pd_name") && dtUsers.Rows[i]["pd_name"] != null) dgv_01.Rows[i].Cells["wf_code"].Value = dtUsers.Rows[i]["pd_name"].ToString();
                //        if (dtUsers.Columns.Contains("count(*)") && dtUsers.Rows[i]["count(*)"] != null) dgv_01.Rows[i].Cells["number"].Value = dtUsers.Rows[i]["count(*)"].ToString();
                //    }
                //    dgv_01.CurrentRow = dgv_01.Rows[0];
                //}
                SortedList SLkey_value = new SortedList();
                SLkey_value.Add("first_time", dt_start.Value);
                SLkey_value.Add("end_time", dt_end.Value);
                SLkey_value.Add("userid", sl_department.GetKey(sl_department.IndexOfValue(cb_department.Text.Trim())));
                DataSet DSnorm = new DataSet();
                DSnorm = reCnasRemotCall.RemotInterface.ExecuteProcedure("performance_appraisal", SLkey_value);
                if (DSnorm.Tables[1] != null && DSnorm.Tables[1].Rows.Count > 0)
                {
                    DataRow[] arrayDR = null;
                    dgv_01.Rows.Clear();

                    arrayDR = DSnorm.Tables[1].Select();
                    int ii = arrayDR.Length;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    int i = 0;
                    foreach (DataRow dr in arrayDR)
                    {
                        if (DSnorm.Tables[1].Columns.Contains("ca_sum") && DSnorm.Tables[1].Rows[i]["ca_sum"] != null) dgv_01.Rows[i].Cells["num"].Value = dr["ca_sum"].ToString();
                        if (DSnorm.Tables[1].Columns.Contains("user_id") && DSnorm.Tables[1].Rows[i]["user_id"] != null) dgv_01.Rows[i].Cells["user"].Value = dr["user_id"].ToString();
                        if (DSnorm.Tables[1].Columns.Contains("wf_code") && DSnorm.Tables[1].Rows[i]["wf_code"] != null) dgv_01.Rows[i].Cells["wf_code"].Value = dr["wf_code"].ToString();
                        if (DSnorm.Tables[1].Columns.Contains("isconfirm") && DSnorm.Tables[1].Rows[i]["isconfirm"] != null) dgv_01.Rows[i].Cells["isconfirm"].Value = dr["isconfirm"].ToString();
                        if (DSnorm.Tables[1].Columns.Contains("pd_name") && DSnorm.Tables[1].Rows[i]["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dr["pd_name"].ToString();
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_list_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='evaluation'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim(); 
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void cb_department_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.cb_department.Items.Clear();
            sl_department.Clear();
            string str = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sl_barcode);//部门
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_department.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        this.cb_department.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
        }
    }
}
