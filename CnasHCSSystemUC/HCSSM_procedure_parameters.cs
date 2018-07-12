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
    public partial class HCSSM_procedure_parameters : TemplateForm
    {
        private DataTable dtpdall = new DataTable();
        private DataTable dtparall = new DataTable();
        private DataTable dtselect = new DataTable();
        private string PD_CodeData = "";
        private int Select_ID = 0;

        public HCSSM_procedure_parameters(DataTable indtall)
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--流程参数管理";
            dtpdall = indtall;

            #region 获取所有流程
            if (dtpdall != null)
            {
                for (int i = 0; i < dtpdall.Rows.Count; i++)
                {
                    string str_id = "", str_name = "";
                    if (dtpdall.Rows[i]["pd_code"] != null) str_id = dtpdall.Rows[i]["pd_code"].ToString();
                    if (dtpdall.Rows[i]["pd_name"] != null) str_name = dtpdall.Rows[i]["pd_name"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名称                  
                    drtemp01.SetValues(str_id, str_name);
                    dgv_01.Rows.Add(drtemp01);
                }
            }
            #endregion

            re_loadpar();
        }


        private void re_loadpar()
        {
            #region 获取所有流程参数
            dgv_02.Rows.Clear();
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.SystemID);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            dtparall = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec01", sttemp02);
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
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//DataGridViewComboBoxColumn
                    drtemp01.SetValues(false, str_id, str_parcode, str_par_name, str_par_def_value, str_par_type, str_par_description);
                    dgv_02.Rows.Add(drtemp01);
                }
            }
            #endregion
        }


        private void re_loadmanualpar(string in_pdcode)
        {
            #region 获取所有手动参数
            dgv_04.Rows.Clear();
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, in_pdcode);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt_tmp01 = reCnasRemotCall.RemotInterface.SelectData("HCS-proceduremanual-sec01", sttemp02);
            if (dt_tmp01 != null)
            {
                for (int i = 0; i < dt_tmp01.Rows.Count; i++)
                {
                    string str_id = "", str_name = "", str_code = "", str_type = "";
                    if (dt_tmp01.Rows[i]["manual_id"] != null) str_id = dt_tmp01.Rows[i]["manual_id"].ToString();
                    if (dt_tmp01.Rows[i]["manual_name"] != null) str_name = dt_tmp01.Rows[i]["manual_name"].ToString();
                    if (dt_tmp01.Rows[i]["next_code"] != null) str_code = dt_tmp01.Rows[i]["next_code"].ToString();
                    if (dt_tmp01.Rows[i]["manual_type"] != null) str_type = dt_tmp01.Rows[i]["manual_type"].ToString();

                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.SetValues(str_id, str_name, str_code, str_type);
                    dgv_04.Rows.Add(drtemp01);
                }
            }
            #endregion


        }

        private void dgv_02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;
                if (((bool)dgv_02.Rows[i].Cells[0].Value) == false)
                {
                    //选中时
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.SetValues(dgv_02.Rows[i].Cells["id02"].Value, dgv_02.Rows[i].Cells["par_code02"].Value, dgv_02.Rows[i].Cells["par_name02"].Value,
                        dgv_02.Rows[i].Cells["par_def_value02"].Value, dgv_02.Rows[i].Cells["par_type02"].Value, dgv_02.Rows[i].Cells["par_description02"].Value, "");
                    dgv_03.Rows.Add(drtemp01);
                    dgv_02.Rows[i].Cells[0].Value = true;
                    dgv_03.Sort(dgv_03.Columns["par_priority03"], ListSortDirection.Ascending);

                }
                else
                {
                    //取消选中
                    dgv_02.Rows[i].Cells[0].Value = false;
                    var var01 = dgv_02.Rows[i].Cells["id02"].Value;
                    for (int j = 0; j < dgv_03.Rows.Count; j++)
                    {
                        if (var01 == dgv_03.Rows[j].Cells["id03"].Value)
                        {
                            dgv_03.Rows.RemoveAt(j);
                        }
                    }

                }
            }
        }

        private void dgv_01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Select_ID = e.RowIndex;
                reloadparameter(Select_ID);
                re_loadmanualpar(dgv_01.Rows[Select_ID].Cells[0].Value.ToString());
            }
        }

        private void reloadparameter(int id)
        {
            dgv_03.Rows.Clear();
            //PD_Code = dgv_01.CurrentRow.Cells[0].Value.ToString();
            PD_CodeData = dgv_01.Rows[id].Cells[0].Value.ToString();
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, PD_CodeData);
            sttemp02.Add(2, 9);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec02", sttemp02);
            if (dt01 == null)
            {
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    dgv_02.Rows[i].Cells[0].Value = false;
                }
            }
            else
            {
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    string str_parcode = dgv_02.Rows[i].Cells["par_code02"].Value.ToString();
                    DataRow[] arrayDR01 = dt01.Select("par_code='" + str_parcode + "'");
                    if (arrayDR01.Length > 0)
                    {
                        DataGridViewRow drtemp01 = new DataGridViewRow();
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.SetValues(dgv_02.Rows[i].Cells["id02"].Value, dgv_02.Rows[i].Cells["par_code02"].Value, dgv_02.Rows[i].Cells["par_name02"].Value,
                            dgv_02.Rows[i].Cells["par_def_value02"].Value, dgv_02.Rows[i].Cells["par_type02"].Value, dgv_02.Rows[i].Cells["par_description02"].Value, arrayDR01[0]["par_priority"].ToString());
                        dgv_03.Rows.Add(drtemp01);

                        dgv_02.Rows[i].Cells[0].Value = true;
                    }
                    else
                    {
                        dgv_02.Rows[i].Cells[0].Value = false;
                    }
                }
            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if (dgv_03.Rows.Count == 0)
            {
                SortedList sltmp1 = new SortedList();
                SortedList sltmp00 = new SortedList();
                sltmp00.Add(1, PD_CodeData);//PD_Code
                sltmp1.Add(1, sltmp00);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparametervalue-del01", sltmp1, null);
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
                sltmp00.Add(1, PD_CodeData);//PD_Code
                sltmp1.Add(1, sltmp00);
                SortedList sltmp2 = new SortedList();
                for (int i = 0; i < dgv_03.Rows.Count; i++)
                {
                    if (dgv_03.Rows[i].Cells["par_priority03"].Value == null || dgv_03.Rows[i].Cells["par_priority03"].Value.ToString() == "")
                    {
                        MessageBox.Show("对不起，请设置参数优先级！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, PD_CodeData);//PD_Code
                    sltmp01.Add(2, dgv_03.Rows[i].Cells["par_code03"].Value);//par_code
                    //sltmp01.Add(3, dgv_03.Rows[i].Cells["par_def_value03"].Value);//v_value
                    sltmp01.Add(3, 0);//v_value
                    sltmp01.Add(4, dgv_03.Rows[i].Cells["par_priority03"].Value);//par_priority
                    sltmp01.Add(5, 0);//next_code
                    sltmp01.Add(6, 9);//code_type
                    sltmp2.Add(i, sltmp01);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparametervalue-add01", sltmp1, sltmp2);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，配置流程参数成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("对不起，配置流程参数失败，可能是数据库不可用复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_03_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgv_03.Rows[e.RowIndex].Cells["par_priority03"].Value == null || dgv_03.Rows[e.RowIndex].Cells["par_priority03"].Value.ToString() == "")
                {
                    MessageBox.Show("对不起，请设置参数优先级！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string str_parcode = dgv_03.Rows[e.RowIndex].Cells["par_code03"].Value.ToString();
                string str_par_name = dgv_03.Rows[e.RowIndex].Cells["par_name03"].Value.ToString();
                string str_info = dgv_03.Rows[e.RowIndex].Cells["par_description03"].Value.ToString();
                string str_par_priority = dgv_03.Rows[e.RowIndex].Cells["par_priority03"].Value.ToString();
                if (str_parcode == "") return;
                HCSSM_procedure_parametersvalue HCSSM_procedure_parametersvalue01 = new HCSSM_procedure_parametersvalue(PD_CodeData, str_parcode, str_par_priority, str_par_name, str_info);
                HCSSM_procedure_parametersvalue01.ShowDialog();
                reloadparameter(Select_ID);

            }
            
        }

        private void dgv_03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgv_03.Sort(dgv_03.Columns["par_priority03"], ListSortDirection.Ascending);
            }
        }

        private void create_par_Click(object sender, EventArgs e)
        {
            //调用参数增加界面
            HCSSM_procedure_parametersmanager HCSSM_procedure_parametersmanager01 = new HCSSM_procedure_parametersmanager();
            HCSSM_procedure_parametersmanager01.ShowDialog();
            re_loadpar();
            reloadparameter(Select_ID);
        }

        private void del_par_Click(object sender, EventArgs e)
        {
            MessageBox.Show("对不起，功能未开放！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //检查参数是否可以删除，检查流程是否使用，检查是不是有参数值已经使用

            //检查通过删除参数
        }

        private void manager_value_Click(object sender, EventArgs e)
        {
            //管理参数的值
            HCSSM_procedure_parametersvaluemanager HCSSM_procedure_parametersvaluemanager01 = new HCSSM_procedure_parametersvaluemanager(dtparall);
            HCSSM_procedure_parametersvaluemanager01.ShowDialog();
        }

        private void tsm_add_Click(object sender, EventArgs e)
        {
            this.dgv_04.RowCount++;
        }

        private void tsm_del_Click(object sender, EventArgs e)
        {
            dgv_04.Rows.RemoveAt(dgv_04.CurrentRow.Index);
        }

        private void but_02_Click(object sender, EventArgs e)
        {
            if(dgv_04.RowCount==0)
            {
                SortedList sltmp1 = new SortedList();
                SortedList sltmp00 = new SortedList();
                sltmp00.Add(1, PD_CodeData);//PD_Code
                sltmp1.Add(1, sltmp00);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-proceduremanual-del01", sltmp1, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，配置手动参数成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("对不起，配置手动参数失败，可能是数据库不可用复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;

            }else
            {
                SortedList sltmp1 = new SortedList();
                SortedList sltmp00 = new SortedList();
                sltmp00.Add(1, PD_CodeData);//PD_Code
                sltmp1.Add(1, sltmp00);
                SortedList sltmp2 = new SortedList();
                for (int i = 0; i < dgv_04.Rows.Count; i++)
                {
                    if (dgv_04.Rows[i].Cells[0].Value == null || dgv_04.Rows[i].Cells[0].Value.ToString() == "" || dgv_04.Rows[i].Cells[1].Value == null || dgv_04.Rows[i].Cells[1].Value.ToString() == "" || dgv_04.Rows[i].Cells[2].Value == null || dgv_04.Rows[i].Cells[2].Value.ToString() == "" || dgv_04.Rows[i].Cells[3].Value == null || dgv_04.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        MessageBox.Show("对不起，参数所有值不能为空！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string str_id = dgv_04.Rows[i].Cells["manual_id"].Value.ToString();
                    string str_type = dgv_04.Rows[i].Cells["manual_type"].Value.ToString();

                    if(isNumberic(str_id)==false || isNumberic(str_type)==false)
                    {
                        MessageBox.Show("对不起，编号和类型必须为数值型！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //pd_code,manual_id,manual_name,next_code,manual_type
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, PD_CodeData);//PD_Code
                    sltmp01.Add(2, dgv_04.Rows[i].Cells["manual_id"].Value.ToString());//manual_id
                    sltmp01.Add(3, dgv_04.Rows[i].Cells["manual_name"].Value.ToString());//manual_name
                    sltmp01.Add(4, dgv_04.Rows[i].Cells["next_code"].Value.ToString());//next_code
                    sltmp01.Add(5, dgv_04.Rows[i].Cells["manual_type"].Value.ToString());//manual_type
                    sltmp2.Add(i, sltmp01);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-proceduremanual-up01", sltmp1, sltmp2);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，配置手动参数成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("对不起，配置手动参数失败，可能是数据重复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool isNumberic(string message)
        {
            try
            {
                int result = Convert.ToInt32(message);
                return true;
            }catch
            {
                return false;
            }
        }
    }
}
