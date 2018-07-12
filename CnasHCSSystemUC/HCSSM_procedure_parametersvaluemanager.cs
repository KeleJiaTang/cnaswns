using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Text.RegularExpressions;
using CnasUI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_procedure_parametersvaluemanager : TemplateForm
    {
        private string Parcode = "", ParID = "", Partype="";
        private int IntSelect = 0;
        public HCSSM_procedure_parametersvaluemanager(DataTable dtparall)
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--参数值管理";
            #region 获取所有参数
            
            if (dtparall != null)
            {
                for (int i = 0; i < dtparall.Rows.Count; i++)
                {
                    string str_id = "", str_parcode = "", str_par_name = "", str_par_def_value = "", str_par_type = "", str_par_description = "";
                    if (dtparall.Rows[i]["id"] != null) str_id = dtparall.Rows[i]["id"].ToString();
                    if (dtparall.Rows[i]["par_code"] != null) str_parcode = dtparall.Rows[i]["par_code"].ToString();
                    if (dtparall.Rows[i]["par_name"] != null) str_par_name = dtparall.Rows[i]["par_name"].ToString();
                    if (dtparall.Rows[i]["par_def_value"] != null) str_par_def_value = dtparall.Rows[i]["par_def_value"].ToString();
                    if (dtparall.Rows[i]["par_type"] != null) str_par_type = dtparall.Rows[i]["par_type"].ToString();
                    if (dtparall.Rows[i]["par_description"] != null) str_par_description = dtparall.Rows[i]["par_description"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//DataGridViewComboBoxColumn
                    drtemp01.SetValues(str_id, str_parcode, str_par_name, str_par_def_value, str_par_type, str_par_description);
                    dgv_02.Rows.Add(drtemp01);
                }
            }
            #endregion
        }


        private void re_loadparvalue(int indata)
        {
            Parcode = dgv_02.Rows[indata].Cells["par_code02"].Value.ToString();
            ParID = dgv_02.Rows[indata].Cells["id02"].Value.ToString();
            Partype = dgv_02.Rows[indata].Cells["par_type02"].Value.ToString();
            dgv_01.Rows.Clear();
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, Parcode);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec01", sttemp02);
            if (dt01==null)
            {
                MessageBox.Show("对不起，该参数还没有设置任何值，请尽快配置！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dt01.Rows.Count; i++)
            {
                string str_par_id = "", str_par_code = "", str_v_value = "", str_v_name = "", str_v_barcode = "", str_v_type = "";
                if (dt01.Rows[i]["par_id"] != null) str_par_id = dt01.Rows[i]["par_id"].ToString();
                if (dt01.Rows[i]["par_code"] != null) str_par_code = dt01.Rows[i]["par_code"].ToString();
                if (dt01.Rows[i]["v_value"] != null) str_v_value = dt01.Rows[i]["v_value"].ToString();
                if (dt01.Rows[i]["v_name"] != null) str_v_name = dt01.Rows[i]["v_name"].ToString();
                if (dt01.Rows[i]["v_barcode"] != null) str_v_barcode = dt01.Rows[i]["v_barcode"].ToString();
                if (dt01.Rows[i]["v_type"] != null) str_v_type = dt01.Rows[i]["v_type"].ToString();
                DataGridViewRow drtemp01 = new DataGridViewRow();
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//DataGridViewComboBoxColumn
                drtemp01.SetValues(str_par_id, str_par_code, str_v_value, str_v_name, str_v_barcode, str_v_type);
                dgv_01.Rows.Add(drtemp01);

            }

        }

        private void dgv_02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                IntSelect = e.RowIndex;
                re_loadparvalue(IntSelect);               

            }
        }

        private void but_21_Click(object sender, EventArgs e)
        {
            if (tb_21.Text.Trim() == "" || tb_22.Text.Trim() == "" || cb_23.Text == "" || Parcode == "" || ParID == "" || Partype=="")
            {
                MessageBox.Show("对不起，请填写正确信息！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //par_id,par_code,v_value,v_name,v_barcode,v_type
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, ParID);
            sltmp01.Add(2, Parcode);
            sltmp01.Add(3, tb_21.Text.Trim());
            sltmp01.Add(4, tb_22.Text.Trim());
            string strbarcode = "BCXP20000000" + Partype;
            sltmp01.Add(5, strbarcode);
            sltmp01.Add(6, cb_23.Text.Substring(0, 1));
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparametervalue-add03", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，增加参数值成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_21.Text = "";
                tb_22.Text = "";
                cb_23.Text = "";
                re_loadparvalue(IntSelect);
            }
            else
            {
                MessageBox.Show("对不起，增加参数值失败，可能是参数值重复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tb_21.Text = dgv_01.Rows[e.RowIndex].Cells["v_value01"].Value.ToString();
                tb_22.Text = dgv_01.Rows[e.RowIndex].Cells["v_name01"].Value.ToString();
                tb_25.Text = dgv_01.Rows[e.RowIndex].Cells["v_barcode01"].Value.ToString();
                string str_v_type01 = dgv_01.Rows[e.RowIndex].Cells["v_type01"].Value.ToString();
                for (int i = 0; i < cb_23.Items.Count; i++)
                {
                    if (cb_23.Items[i].ToString().Substring(0, 1) == str_v_type01)
                        cb_23.SelectedIndex = i;
                }
            }
        }

        private void but_22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("对不起，功能未开放。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void but_23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("对不起，功能未开放。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
