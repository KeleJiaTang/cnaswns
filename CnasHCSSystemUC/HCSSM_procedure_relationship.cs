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
    public partial class HCSSM_procedure_relationship : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();

        private DataTable dtparvalueall = new DataTable();
        private string PD_codeData = "";
        //private DataTable dtpdpar = new DataTable();
        private SortedList sl_02data = new SortedList();
        private SortedList sl_01data = new SortedList();

		/// <summary>
		/// 已经配置的选项
		/// </summary>
		private DataTable dtpartvalueconfig = new DataTable();

        public HCSSM_procedure_relationship(DataTable indtall)
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--流程关系配置";
            dtall = indtall;

            #region 获取所有流程            
            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_name = "";
                    if (dtall.Rows[i]["pd_code"] != null) str_id = dtall.Rows[i]["pd_code"].ToString();                    
                    if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名称                  
                    drtemp01.SetValues(str_id,  str_name);
                    dgv_01.Rows.Add(drtemp01); 
                }
            }
            #endregion

            #region 获取所有参数的值

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();            
            dtparvalueall = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec03", null);     
            #endregion
            //load_pdpar();
        }

        private void select_pd(string inpdid)
        {
            dgv_02.Rows.Clear();
            dgv_03.Rows.Clear();
            #region 获取流程允许扫描码
            DataRow[] arrayDRsecpd = dtall.Select("pd_code=" + inpdid);
            tb_pdscan.Text = arrayDRsecpd[0]["pd_scan"].ToString();
            #endregion
            PD_codeData = inpdid;  

            #region 获取已经配置好流程数据
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, inpdid);
            dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure_relation-sec001", sttemp01);
            if (dtall != null)
            {
                if (dtselect == null)
                {

                    for (int i = 0; i < dtall.Rows.Count; i++)
                    {
                        string str_id = "", str_name = "";
                        if (dtall.Rows[i]["pd_code"] != null) str_id = dtall.Rows[i]["pd_code"].ToString();
                        if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                        DataGridViewRow drtemp01 = new DataGridViewRow();
                        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名称                   
                        drtemp01.SetValues(false, str_id, str_name);
                        dgv_02.Rows.Add(drtemp01);
                    }
                     
                }else
                {
                    for (int i = 0; i < dtall.Rows.Count; i++)
                    {
                        string str_id = "", str_name = "", str_priority = "0", str_condition = "";
                        if (dtall.Rows[i]["pd_code"] != null) str_id = dtall.Rows[i]["pd_code"].ToString();
                        if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                        DataRow[] arrayDRsec = dtselect.Select("next_pdcode=" + str_id);

                        DataGridViewRow drtemp01 = new DataGridViewRow();
                        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名称    
                        if (arrayDRsec.Length == 0)
                        {
                            drtemp01.SetValues(false, str_id, str_name);
                        }else
                        {
                            drtemp01.SetValues(true, str_id, str_name);
                            if (arrayDRsec[0]["pr_priority"] != null) str_priority = arrayDRsec[0]["pr_priority"].ToString();
                            if (arrayDRsec[0]["pr_condition"] != null) str_condition = arrayDRsec[0]["pr_condition"].ToString();
                            DataGridViewRow drtemp02 = new DataGridViewRow();
                            drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp02.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp02.SetValues(str_id, str_name, str_priority, str_condition);
                            dgv_03.Rows.Add(drtemp02);
                        }
                        dgv_02.Rows.Add(drtemp01);
                    }
                    dgv_03.Sort(dgv_03.Columns["pr_priority"], ListSortDirection.Ascending);
                }

            }
			SortedList sttemp02 = new SortedList();
			sttemp02.Add(1, inpdid);
			//string testConfigSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-pdparametervalue-sec04", sttemp01);
			dtpartvalueconfig = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec04", sttemp02);
            #endregion


            #region 获取允许配置的参数

            cb_par.Items.Clear();
            cb_value.Items.Clear();
            SortedList sttemp05 = new SortedList();
            sttemp05.Add(1, inpdid);
            sttemp05.Add(2, 9);
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec03", sttemp05);
            if (dt01 != null)
            {
                for (int i = 0; i < dt01.Rows.Count; i++)
                {
                    string strpar_code = dt01.Rows[i]["par_code"].ToString();
                    string strkey_code = dt01.Rows[i]["par_name"].ToString();
                    string strvalue_code = dt01.Rows[i]["par_description"].ToString();
                    cb_par.Items.Add(strvalue_code + "：" + strkey_code + "：" + strpar_code);
                }
            }

            #endregion
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if (PD_codeData == "")
            {
                MessageBox.Show("对不起，请先选择一个流程。");
                return;
            }
            string str_pdscan = tb_pdscan.Text;
            if (dgv_03.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, str_pdscan);
                sltmp_01.Add(2, PD_codeData);
                sltmp_01.Add(3, PD_codeData);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_03.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, PD_codeData);
                    sltmp_02.Add(2, dgv_03.Rows[i].Cells["pd_code03"].Value);
                    sltmp_02.Add(3, dgv_03.Rows[i].Cells["pr_priority"].Value);
                    sltmp_02.Add(4, dgv_03.Rows[i].Cells["pr_condition"].Value);

                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-procedure_relation-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-procedure_relation-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程关系配置成功。");
                    //this.Close();
                }
            }
            else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, str_pdscan);
                sltmp_01.Add(2, PD_codeData);
                sltmp_01.Add(3, PD_codeData);
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-procedure_relation-del001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程关系配置成功。");
                    this.Close();
                }
            }
        }

        private void but_test_Click(object sender, EventArgs e)
        {
            //#$set_type$# = 1 and  CompareStr("#$washing_type$#","1")>0
            string str_condition = rtb_condition.Text.Trim(), str_newcondition = "";
            if (str_condition.Length == 0) return;

            string[] strarr01 = str_condition.Split(new string[] { "#$" }, StringSplitOptions.None);
            for (int i = 0; i < strarr01.Length; i++)
            {
                if (strarr01[i].IndexOf("$#", 0) > -1)
                {
                    string[] strarr02 = strarr01[i].Split(new string[] { "$#" }, StringSplitOptions.None);
                    str_newcondition = str_newcondition + "1" + strarr02[1];
                }
                else
                {
                    str_newcondition = str_newcondition + strarr01[i];
                }
            }

            int int_rec = CnasClientMethods.GetCondition(0, str_newcondition);
            if (int_rec < 3)
            {
                but_savcon_Click(null, null);
            }
            else
            {
                MessageBox.Show("对不起！条件格式不正确，请仔细检查。");
            }
        }

        private void but_savcon_Click(object sender, EventArgs e)
        {
            if (dgv_03.CurrentRow.Index > -1)
            {
                dgv_03.CurrentRow.Cells["pr_condition"].Value = rtb_condition.Text.Trim();
            }
        }

        private void dgv_01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string strpdid = dgv_01.Rows[e.RowIndex].Cells["pd_code"].Value.ToString();                
                select_pd(strpdid);
            }
        }

        private void dgv_02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;                
                if (((bool)dgv_02.Rows[i].Cells[0].Value) == false)
                {
                    //选中时
                    dgv_02.Rows[i].Cells[0].Value = true;
                    dgv_03.RowCount++;
                    int ii = dgv_03.RowCount - 1;
                    dgv_03.Rows[ii].Cells["pd_code03"].Value = dgv_02.Rows[i].Cells["pd_code02"].Value;
                    dgv_03.Rows[ii].Cells["pd_name03"].Value = dgv_02.Rows[i].Cells["pd_name02"].Value;
                    dgv_03.Rows[ii].Cells["pr_priority"].Value = "";
                    dgv_03.Rows[ii].Cells["pr_condition"].Value = "";
                    dgv_03.Sort(dgv_03.Columns["pr_priority"], ListSortDirection.Ascending);

                }
                else
                {
                    //取消选中
                    dgv_02.Rows[i].Cells[0].Value = false;
                    string var01 = dgv_02.Rows[i].Cells["pd_code02"].Value.ToString();
                    for (int j = 0; j < dgv_03.Rows.Count; j++)
                    {
                        if (var01 == dgv_03.Rows[j].Cells["pd_code03"].Value.ToString())
                        {
                            dgv_03.Rows.RemoveAt(j);
                        }
                    }
                }
            }
        }

        private void dgv_03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rtb_condition.Text = dgv_03.Rows[e.RowIndex].Cells["pr_condition"].Value.ToString();
                dgv_03.Sort(dgv_03.Columns["pr_priority"], ListSortDirection.Ascending);
            }
        }

        private void cb_par_SelectedValueChanged(object sender, EventArgs e)
        {
            string strpar_code = cb_par.Text.Trim();
            string[] strarr = strpar_code.Split('：');
            if (strarr.Length > 1)
            {
                strpar_code = strarr[2];
                cb_value.Items.Clear();
            }
            else
            {
                return;
            }
            if (dtparvalueall == null)
            {
                MessageBox.Show("对不起！参数值为空，先去设置好。");
                return;
            }
            DataRow[] arrayDR = dtparvalueall.Select("par_code=" + strpar_code);
            foreach (DataRow dr in arrayDR)
            {
                string strother_code = Convert.ToString(dr["v_value"]).Trim();
                string strdescription = Convert.ToString(dr["v_name"]).Trim();
				if (dtpartvalueconfig != null && dtpartvalueconfig.Rows.Count > 0 && IsExitParcodeValue(strpar_code, strother_code))
				{
					cb_value.Items.Add(strother_code + "：" + strdescription);
				}
            }
        }

		/// <summary>
		/// 验证是否已经配置该选项
		/// </summary>
		/// <param name="par_code"></param>
		/// <param name="v_value"></param>
		/// <returns></returns>
		private bool IsExitParcodeValue(string par_code, string v_value)
		{
			for (int i = 0; i < dtpartvalueconfig.Rows.Count; i++)
			{
				string tempParCode = Convert.ToString(dtpartvalueconfig.Rows[i]["par_code"]);
				string tempValue = Convert.ToString(dtpartvalueconfig.Rows[i]["v_value"]);
				if (tempParCode.Equals(par_code) && tempValue.Equals(v_value))
				{
					return true;
				}
			}
			return false;
		}
        private void but_insert01_Click(object sender, EventArgs e)
        {
            if (cb_par.Text.Length > 0 && cb_iftype.Text.Length > 0 && cb_value.Text.Length > 0)
            {
                string[] strarrpar = this.cb_par.Text.Split('：');
                string[] strarrvalue = this.cb_value.Text.Split('：');
                string strindata = "";
                if (cb_iftype.Text.IndexOf("CompareStr") > 0)
                {
                    strindata = cb_iftype.Text;
                    strindata = strindata.Replace("#1", "#$" + strarrpar[1] + "$#");
                    strindata = strindata.Replace("#2", strarrvalue[0]);
                }
                else
                {
                    strindata = "#$" + strarrpar[1] + "$#" + cb_iftype.Text + strarrvalue[0];
                }
                Insert_rtb(strindata);
            }
        }

        private void Insert_rtb(string inserted)
        {
            if (rtb_condition.SelectionLength > 0)
            {
                //如果有选中的内容，则将光标移动到被选中内容之后
                rtb_condition.SelectionStart = rtb_condition.SelectionStart + rtb_condition.SelectionLength;
            }
            rtb_condition.SelectedText = inserted;
        }

        private void but_insert02_Click(object sender, EventArgs e)
        {
            if (cb_unite.Text.Length > 0) Insert_rtb(cb_unite.Text);
        }
    }
}
