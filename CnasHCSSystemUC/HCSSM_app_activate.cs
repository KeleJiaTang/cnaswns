using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System.Configuration;
namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_app_activate : TemplateForm
    {
        private DataTable dtappall = new DataTable();
        private SortedList slappparent = new SortedList();
        public HCSSM_app_activate(SortedList slindata, DataTable dtindate)
        {   
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            //表格栏底色
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //表格栏底色
            dgv_02.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_02.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_02.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_02.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--功能激活管理";
            dtappall = dtindate;
            slappparent = slindata;
            for (int i = 0; i < slindata.Count; i++)
            {
                cb_app.Items.Add(slindata.GetKey(i).ToString());
                cb_app.Text = "全部功能模块";
            }
            
        }

        private void cb_app_SelectedValueChanged(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
            dgv_02.Rows.Clear();
            if (cb_app.Text == "全部功能模块")
            {
                DataRow[] arrayDR = dtappall.Select("app_type=1");
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                //dgv_01.RowCount = ii;
                //int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    string str_id="", str_app_name="", str_app_briefcode="";
                    if (dr["id"] != null) str_id = dr["id"].ToString();
                    if (dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
                    if (dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
                     DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.SetValues(false, str_id,str_app_briefcode,str_app_name);  
                    if (dr["state"] != null && dr["state"].ToString() == "0")
                    {
                        dgv_01.Rows.Add(drtemp01);
                     }else
                    {
                        dgv_02.Rows.Add(drtemp01);
                    }  
                }
            }
            else
            {
                DataRow[] arrayDR = dtappall.Select("app_parent='" + slappparent[cb_app.Text].ToString() + "'");
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                //dgv_01.RowCount = ii;
                //int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    string str_id = "", str_app_name = "", str_app_briefcode = "";
                    if (dr["id"] != null) str_id = dr["id"].ToString();
                    if (dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
                    if (dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
                    if (dr["state"] != null && dr["state"].ToString() == "0")
                    {
                        dgv_01.Rows.Add(drtemp01);
                    }
                    else
                    {
                        dgv_02.Rows.Add(drtemp01);
                    }
                }
            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            CnasBaseData.If_LoadData = 1;
        }

        private void cb_app_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            //if (dgv_01.Rows.Count > 0)
            //{
            //    //SortedList sol_select = new SortedList();
            //    for (int i = 0; i < dgv_01.Rows.Count; i++)
            //    {
            //        if (bool.Parse(dgv_01.Rows[i].Cells["isselected"].Value.ToString()) == false) continue;
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["user_name"] != null) str_app_name = dgv_01.Rows[i].Cells["user_name"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["user_nick"] != null) str_app_briefcode = dgv_01.Rows[i].Cells["user_nick"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_name, str_app_briefcode);
            //        dgv_02.Rows.Add(drtemp01);
            //        sl_02data.Add(str_id, str_app_name);
            //    }

            //    dgv_01.Rows.Clear();
            //    sl_01data.Clear();

            //    for (int i = 0; i < dtall.Rows.Count; i++)
            //    {
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
            //        if (dtall.Rows[i]["user_name"] != null) str_app_name = dtall.Rows[i]["user_name"].ToString();
            //        if (dtall.Rows[i]["user_nick"] != null) str_app_briefcode = dtall.Rows[i]["user_nick"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_name, str_app_briefcode);
            //        if (sl_02data.IndexOfKey(str_id) < 0)
            //        {
            //            dgv_01.Rows.Add(drtemp01);
            //            sl_01data.Add(str_id, str_app_name);
            //        }
            //    }
            //}
        }

        private void but_reone_Click(object sender, EventArgs e)
        {

        }

        private void but_addall_Click(object sender, EventArgs e)
        {

        }
    }
}
