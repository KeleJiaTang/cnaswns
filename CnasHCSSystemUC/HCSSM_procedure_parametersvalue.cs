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
    public partial class HCSSM_procedure_parametersvalue : TemplateForm
    {
        private DataTable dtvalueall = new DataTable();
        private DataTable dtvalueselect = new DataTable();

        private string PD_codedata = "", Par_code = "", Par_priority="";
        public HCSSM_procedure_parametersvalue(string str_pdcode, string str_parcode,string str_par_priority, string str_par_name,string str_info)
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--流程参数值配置";
            this.Text = this.Text + "  ->" + str_par_name + "--" + str_info;
            PD_codedata = str_pdcode;
            Par_code = str_parcode;
            Par_priority = str_par_priority;
            Loaddata();
        }

        private void Loaddata()
        {
            #region 获取所有参数值
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Par_code);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            dtvalueall = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec01", sttemp01);
            if (dtvalueall == null)
            {
                MessageBox.Show("对不起，该参数还没有配置相关值，请尽快配置。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, PD_codedata);
            sttemp02.Add(2, Par_code);
            dtvalueselect = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec02", sttemp02);
            if (dtvalueselect == null)
            {
                for (int i = 0; i < dtvalueall.Rows.Count; i++)
                {
                    string str_par_id = "", str_v_value = "", str_v_name = "", str_v_barcode = "", str_v_type = "";
                    if (dtvalueall.Rows[i]["par_id"] != null) str_par_id = dtvalueall.Rows[i]["par_id"].ToString();
                    if (dtvalueall.Rows[i]["v_value"] != null) str_v_value = dtvalueall.Rows[i]["v_value"].ToString();
                    if (dtvalueall.Rows[i]["v_name"] != null) str_v_name = dtvalueall.Rows[i]["v_name"].ToString();
                    if (dtvalueall.Rows[i]["v_barcode"] != null) str_v_barcode = dtvalueall.Rows[i]["v_barcode"].ToString();
                    if (dtvalueall.Rows[i]["v_type"] != null) str_v_type = dtvalueall.Rows[i]["v_type"].ToString();

                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.SetValues(false, str_par_id, str_v_value, str_v_name, str_v_barcode, str_v_type);
                    dgv_01.Rows.Add(drtemp01);
                }
            }else
            {             

                for (int i = 0; i < dtvalueall.Rows.Count; i++)
                {
                    string str_par_id = "", str_v_value = "", str_v_name = "", str_v_barcode = "", str_v_type = "";
                    if (dtvalueall.Rows[i]["par_id"] != null) str_par_id = dtvalueall.Rows[i]["par_id"].ToString();
                    if (dtvalueall.Rows[i]["v_value"] != null) str_v_value = dtvalueall.Rows[i]["v_value"].ToString();
                    if (dtvalueall.Rows[i]["v_name"] != null) str_v_name = dtvalueall.Rows[i]["v_name"].ToString();
                    if (dtvalueall.Rows[i]["v_barcode"] != null) str_v_barcode = dtvalueall.Rows[i]["v_barcode"].ToString();
                    if (dtvalueall.Rows[i]["v_type"] != null) str_v_type = dtvalueall.Rows[i]["v_type"].ToString();

                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    DataRow[] arrayDR01 = dtvalueselect.Select("v_value='" + str_v_value + "'");
                    if (arrayDR01.Length>0)
                    {
                        drtemp01.SetValues(true, str_par_id, str_v_value, str_v_name, str_v_barcode, str_v_type);
                        DataGridViewRow drtemp02 = new DataGridViewRow();
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp02.SetValues(str_par_id, str_v_value, str_v_name, str_v_barcode, str_v_type, arrayDR01[0]["next_code"].ToString());
                        dgv_02.Rows.Add(drtemp02);

                    }else
                    {
                        drtemp01.SetValues(false, str_par_id, str_v_value, str_v_name, str_v_barcode, str_v_type);
                    }                    
                    dgv_01.Rows.Add(drtemp01);
                }
            }
            
            #endregion

        }

        private void but_01_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count == 0)
            {
                SortedList sltmp1 = new SortedList();
                SortedList sltmp00 = new SortedList();
                sltmp00.Add(1, PD_codedata);//pd_code
                sltmp00.Add(2, Par_code);//par_code
                sltmp1.Add(1, sltmp00);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparametervalue-del02", sltmp1, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，配置流程参数成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("对不起，配置流程参数失败，可能是数据库不可用复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            else
            {
                SortedList sltmp1 = new SortedList();
                SortedList sltmp00 = new SortedList();
                sltmp00.Add(1, PD_codedata);//pd_code
                sltmp00.Add(2, Par_code);//par_code
                sltmp1.Add(1, sltmp00);
                SortedList sltmp2 = new SortedList();
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    if (dgv_02.Rows[i].Cells["next_code02"].Value == null || dgv_02.Rows[i].Cells["next_code02"].Value.ToString() == "")
                    {
                        MessageBox.Show("对不起，请设置下一步代码！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, PD_codedata);//pd_code
                    sltmp01.Add(2, Par_code);//par_code
                    sltmp01.Add(3, dgv_02.Rows[i].Cells["v_value02"].Value.ToString());//v_value
                    sltmp01.Add(4, Par_priority);//par_priority
                    sltmp01.Add(5, dgv_02.Rows[i].Cells["next_code02"].Value.ToString());//next_code
                    sltmp01.Add(6, 1);//code_type
                    sltmp2.Add(i, sltmp01);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recstr = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-pdparametervalue-add02", sltmp1, sltmp2);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparametervalue-add02", sltmp1, sltmp2);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，配置参数值成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("对不起，配置参数值失败，可能是数据库不可用复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;
                if (((bool)dgv_01.Rows[i].Cells[0].Value) == false)
                {
                    //选中时
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());

                    drtemp01.SetValues(dgv_01.Rows[i].Cells["par_code01"].Value, dgv_01.Rows[i].Cells["v_value01"].Value, dgv_01.Rows[i].Cells["v_name01"].Value,
                        dgv_01.Rows[i].Cells["v_barcode01"].Value, dgv_01.Rows[i].Cells["v_type01"].Value, "");
                    dgv_02.Rows.Add(drtemp01);
                    dgv_01.Rows[i].Cells[0].Value = true;
                    dgv_02.Sort(dgv_02.Columns["v_value02"], ListSortDirection.Ascending);

                }
                else
                {
                    //取消选中
                    dgv_01.Rows[i].Cells[0].Value = false;
                    var var01 = dgv_01.Rows[i].Cells["v_value01"].Value;
                    for (int j = 0; j < dgv_02.Rows.Count; j++)
                    {
                        if (var01 == dgv_02.Rows[j].Cells["v_value02"].Value)
                        {
                            dgv_02.Rows.RemoveAt(j);
                        }
                    }

                }
            }
        }
    }
}
