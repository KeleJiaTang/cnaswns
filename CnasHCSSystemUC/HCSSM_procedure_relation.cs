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
    public partial class HCSSM_procedure_relation : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();
        private DataTable dtpdpar = new DataTable();
        private SortedList sl_02data = new SortedList();
        private SortedList sl_01data = new SortedList();
        private string str_prid = "";

        private SortedList sl_PCdata = new SortedList();

        public HCSSM_procedure_relation(string str_inid, string str_inname, string str_incode, DataTable indtall)
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--流程关系管理";
            str_prid = str_inid;
            dtall = indtall;
            this.Text = this.Text + "  ->" + str_incode+"--"+str_inname;

            DataRow[] arrayDRsec01 = dtall.Select("id=" + str_inid);
            if(arrayDRsec01[0]["pd_scan"] != null) tb_02.Text = arrayDRsec01[0]["pd_scan"].ToString();

            #region 获取已经配置好流程数据            
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, str_inid);
            dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure_relation-sec001", sttemp01);
            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_code = "", str_name = "", str_priority = "0", str_condition = "";
                    if (dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
                    if (dtall.Rows[i]["pd_code"] != null) str_code = dtall.Rows[i]["pd_code"].ToString();
                    if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名称                    
                    
                    if (dtselect == null)
                    {
                        drtemp01.SetValues(false, str_id, str_code, str_name);
                        dgv_01.Rows.Add(drtemp01);
                        sl_01data.Add(str_id, str_name);
                    }
                    else
                    {
                        DataRow[] arrayDRsec = dtselect.Select("next_pid=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            if (arrayDRsec[0]["pr_priority"] != null) str_priority = arrayDRsec[0]["pr_priority"].ToString();
                            if (arrayDRsec[0]["pr_condition"] != null) str_condition = arrayDRsec[0]["pr_condition"].ToString();
                            drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                            drtemp01.SetValues(false, str_id, str_code, str_name, str_priority, str_condition);

                            //drtemp01.SetValues(false, str_id, str_code, str_name);
                            dgv_02.Rows.Add(drtemp01);
                            sl_02data.Add(str_id, str_name);
                        }
                        else
                        {
                            drtemp01.SetValues(false, str_id, str_code, str_name);
                            dgv_01.Rows.Add(drtemp01);
                            sl_01data.Add(str_id, str_name);
                        }
                    }
                }
            }
            #endregion
            load_pdpar();
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)
            {
                //SortedList sol_select = new SortedList();
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {
                    if (bool.Parse(dgv_01.Rows[i].Cells["isselected"].Value.ToString()) == false) continue;
                    string str_id = "", str_code = "", str_name = "", str_priority = "0",str_condition = "";
                    if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
                    if (dgv_01.Rows[i].Cells["pd_code"] != null) str_code = dgv_01.Rows[i].Cells["pd_code"].Value.ToString();
                    if (dgv_01.Rows[i].Cells["pd_name"] != null) str_name = dgv_01.Rows[i].Cells["pd_name"].Value.ToString();
                      
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    if (dtselect != null)
                    {
                        DataRow[] arrayDRsec = dtselect.Select("next_pid=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            if (arrayDRsec[0]["pr_priority"] != null) str_priority = arrayDRsec[0]["pr_priority"].ToString();
                            if (arrayDRsec[0]["pr_condition"] != null) str_condition = arrayDRsec[0]["pr_condition"].ToString();

                        }
                    }
                    drtemp01.SetValues(false, str_id, str_code, str_name, str_priority, str_condition);
                    dgv_02.Rows.Add(drtemp01);
                    sl_02data.Add(str_id, str_name);
                }

                dgv_01.Rows.Clear();
                sl_01data.Clear();

                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_code = "", str_name = "";
                    if (dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
                    if (dtall.Rows[i]["pd_code"] != null) str_code = dtall.Rows[i]["pd_code"].ToString();
                    if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.SetValues(false, str_id, str_code, str_name);
                    if (sl_02data.IndexOfKey(str_id) < 0)
                    {
                        dgv_01.Rows.Add(drtemp01);
                        sl_01data.Add(str_id, str_name);
                    }
                }
            }
        }

        private void but_reone_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                //添加dgv_01数据
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    if (bool.Parse(dgv_02.Rows[i].Cells["isselected2"].Value.ToString()) == false) continue;
                    string str_id = "", str_code = "", str_name = "";
                    if (dgv_02.Rows[i].Cells["id2"] != null) str_id = dgv_02.Rows[i].Cells["id2"].Value.ToString();
                    if (dgv_02.Rows[i].Cells["pd_code2"] != null) str_code = dgv_02.Rows[i].Cells["pd_code2"].Value.ToString();
                    if (dgv_02.Rows[i].Cells["pd_name2"] != null) str_name = dgv_02.Rows[i].Cells["pd_name2"].Value.ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.SetValues(false, str_id, str_code, str_name);
                    dgv_01.Rows.Add(drtemp01);
                    sl_01data.Add(str_id, str_name);
                }

                dgv_02.Rows.Clear();
                sl_02data.Clear();

                //刷新dgv_02数据
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_code = "", str_name = "", str_priority = "0", str_condition = "";
                    if (dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
                    if (dtall.Rows[i]["pd_code"] != null) str_code = dtall.Rows[i]["pd_code"].ToString();
                    if (dtall.Rows[i]["pd_name"] != null) str_name = dtall.Rows[i]["pd_name"].ToString();
                    DataGridViewRow drtemp01 = new DataGridViewRow();
                    drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                    if (dtselect != null)
                    {
                        DataRow[] arrayDRsec = dtselect.Select("next_pid=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            if (arrayDRsec[0]["pr_priority"] != null) str_priority = arrayDRsec[0]["pr_priority"].ToString();
                            if (arrayDRsec[0]["pr_condition"] != null) str_condition = arrayDRsec[0]["pr_condition"].ToString();

                        }
                    }
                    drtemp01.SetValues(false, str_id, str_code, str_name, str_priority, str_condition);
                    if (sl_01data.IndexOfKey(str_id) < 0)
                    {
                        dgv_02.Rows.Add(drtemp01);
                        sl_02data.Add(str_id, str_name);
                    }
                }
            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, str_prid);
                sltmp_01.Add(2, str_prid);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, str_prid);
                    sltmp_02.Add(2, dgv_02.Rows[i].Cells["id2"].Value);
                    sltmp_02.Add(3, dgv_02.Rows[i].Cells["pr_priority"].Value);
                    sltmp_02.Add(4, dgv_02.Rows[i].Cells["pr_condition"].Value);

                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-procedure_relation-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-procedure_relation-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程关系配置成功。");
                    this.Close();
                }
            }
            else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, str_prid);
                sltmp_01.Add(2, str_prid);
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

        private void cb_old_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)
            {
                if (cb_old.Checked == true)
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = false;
                    }
                }
            }
        }

        private void cb_new_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                if (cb_new.Checked == true)
                {
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        dgv_02.Rows[i].Cells["isselected2"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        dgv_02.Rows[i].Cells["isselected2"].Value = false;
                    }
                }
            }
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
                    strindata = strindata.Replace("#1", "#$"+strarrpar[1]+"$#");
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

        private void cb_par_SelectedValueChanged(object sender, EventArgs e)
        {
            string strkey_code = cb_par.Text.Trim();
            string[] strarr = strkey_code.Split('：');
            if(strarr.Length>1)
            {
                strkey_code = strarr[1];
                cb_value.Items.Clear();
            }
            else
            {
                return;
            }
            if(dtpdpar==null)
            {
                MessageBox.Show("对不起！参数值为空，先去设置好。");
                return;
            }
            DataRow[] arrayDR = dtpdpar.Select("par_name='" + strkey_code + "'");
            foreach (DataRow dr in arrayDR)
            {
                string strother_code = dr["v_value"].ToString().Trim();
                string strdescription = dr["v_name"].ToString().Trim();
                cb_value.Items.Add(strother_code + "：" + strdescription);                
            }
        }

        private void but_savcon_Click(object sender, EventArgs e)
        {
            if(dgv_02.CurrentRow.Index>-1)
            {
                dgv_02.CurrentRow.Cells["pr_condition"].Value = rtb_condition.Text.Trim();
            }
        }

        private void dgv_02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgv_02.Rows[e.RowIndex].Cells["pr_condition"].Value != null)
            {
                rtb_condition.Text = dgv_02.Rows[e.RowIndex].Cells["pr_condition"].Value.ToString();
            }
        }

        private void but_test_Click(object sender, EventArgs e)
        {
            //#$set_type$# = 1 and  CompareStr("#$washing_type$#","1")>0
            string str_condition = rtb_condition.Text.Trim(), str_newcondition = "";
            if (str_condition.Length == 0) return;

            string[] strarr01 = str_condition.Split(new string[] { "#$" }, StringSplitOptions.None);
            for(int i=0;i<strarr01.Length;i++)
            {
                if(strarr01[i].IndexOf("$#",0)>-1)
                {
                    string[] strarr02 = strarr01[i].Split(new string[] { "$#" }, StringSplitOptions.None);
                    str_newcondition = str_newcondition + "1" + strarr02[1];
                }else
                {
                    str_newcondition = str_newcondition + strarr01[i];
                }
            }

            int int_rec = CnasClientMethods.GetCondition(0, str_newcondition);
            if(int_rec<3)
            {
                but_savcon_Click(null,null);
            }else
            {
                MessageBox.Show("对不起！条件格式不正确，请仔细检查。");
            }
        }




        private void load_pdpar()
        {
            
            dgv_04.Rows.Clear();
            dgv_05.Rows.Clear();
            cb_par.Items.Clear();
            //sl_PCdata.Clear();
            string strappid = str_prid;
            SortedList sttemp02 = new SortedList();
            //sttemp02.Add(1, strappid);
            sttemp02.Add(1, CnasBaseData.SystemID);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdbasepar-sec01", sttemp02);

            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strappid);
            DataTable dt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdpar-sec01", sttemp01);            
            if (dt01 != null)
            {
                string secid = "";
                for (int i = 0; i < dt01.Rows.Count; i++)
                {
                    secid = dt01.Rows[i]["id"].ToString();
                    dgv_04.RowCount++;
                    //int ii = dgv_04.RowCount - 1;
                    dgv_04.Rows[i].Cells[0].Value = false;
                    if (dt01.Rows[i]["id"] != null) dgv_04.Rows[i].Cells["id04"].Value = dt01.Rows[i]["id"].ToString();
                    if (dt01.Rows[i]["pd_id"] != null) dgv_04.Rows[i].Cells["pd_id04"].Value = dt01.Rows[i]["pd_id"].ToString();
                    if (dt01.Rows[i]["par_code"] != null) dgv_04.Rows[i].Cells["par_code04"].Value = dt01.Rows[i]["par_code"].ToString();
                    if (dt01.Rows[i]["par_name"] != null) dgv_04.Rows[i].Cells["par_name04"].Value = dt01.Rows[i]["par_name"].ToString();
                    if (dt01.Rows[i]["par_def_value"] != null) dgv_04.Rows[i].Cells["par_def_value04"].Value = dt01.Rows[i]["par_def_value"].ToString();
                    if (dt01.Rows[i]["par_type"] != null) dgv_04.Rows[i].Cells["par_type04"].Value = dt01.Rows[i]["par_type"].ToString();
                    if (dt01.Rows[i]["par_description"] != null) dgv_04.Rows[i].Cells["par_description04"].Value = dt01.Rows[i]["par_description"].ToString();
                    if (dt02 != null)
                    {
                        DataRow[] arrayDR01 = dt02.Select("par_id=" + secid);
                        if (arrayDR01.Length > 0)
                        {
                            dgv_04.Rows[i].Cells["isselected4"].Value = true;
                            dgv_05.RowCount++;
                            int ii = dgv_05.RowCount - 1;
                            if (dt01.Rows[i]["id"] != null) dgv_05.Rows[ii].Cells["id05"].Value = dt01.Rows[i]["id"].ToString();
                            if (dt01.Rows[i]["pd_id"] != null) dgv_05.Rows[ii].Cells["pd_id05"].Value = dt01.Rows[i]["pd_id"].ToString();
                            if (dt01.Rows[i]["par_code"] != null) dgv_05.Rows[ii].Cells["par_code05"].Value = dt01.Rows[i]["par_code"].ToString();
                            if (dt01.Rows[i]["par_name"] != null) dgv_05.Rows[ii].Cells["par_name05"].Value = dt01.Rows[i]["par_name"].ToString();
                            if (dt01.Rows[i]["par_def_value"] != null) dgv_05.Rows[ii].Cells["par_def_value05"].Value = dt01.Rows[i]["par_def_value"].ToString();
                            if (dt01.Rows[i]["par_type"] != null) dgv_05.Rows[ii].Cells["par_type05"].Value = dt01.Rows[i]["par_type"].ToString();
                            if (dt01.Rows[i]["par_description"] != null) dgv_05.Rows[ii].Cells["par_description05"].Value = dt01.Rows[i]["par_description"].ToString();
                            if (arrayDR01[0]["par_priority"] != null)
                            {
                                dgv_05.Rows[ii].Cells["par_priority05"].Value = arrayDR01[0]["par_priority"].ToString();
                            }
                            else
                            {
                                dgv_05.Rows[ii].Cells["par_priority05"].Value = "";
                            }
                            string strkey_code = dt01.Rows[i]["par_name"].ToString();
                            string strvalue_code = dt01.Rows[i]["par_description"].ToString();
                            //sl_PCdata.Add(strkey_code, strvalue_code);
                            cb_par.Items.Add(strvalue_code + "：" + strkey_code);

                        }
                    }
                }
            }

            if (dgv_05.RowCount > 0) tb_26.Text = dgv_05.Rows[0].Cells["id05"].Value.ToString();            
            this.loadparvalue();
            but_01.Enabled = true;
        }

        private void but_01_Click(object sender, EventArgs e)
        {
            string strappid = str_prid;
            if (dgv_05.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, strappid);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_05.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, strappid);
                    sltmp_02.Add(2, dgv_05.Rows[i].Cells["id05"].Value.ToString());
                    if (dgv_05.Rows[i].Cells["par_priority05"].Value == null || dgv_05.Rows[i].Cells["par_priority05"].Value == "")
                    {
                        MessageBox.Show("对不起，流程参数优先级不能为空，请按照规则编排。");
                        return;
                    }
                    sltmp_02.Add(3, dgv_05.Rows[i].Cells["par_priority05"].Value.ToString());
                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-pdpar-add01", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程参数配置成功。");
                    but_01.Enabled = false;
                }
            }
            else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, strappid);
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdpar-del01", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程参数配置成功。");
                    but_01.Enabled = false;
                    //this.Close();
                }
            }
        }

        private void dgv_04_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;
                if (((bool)dgv_04.Rows[i].Cells[0].Value) == false)
                {
                    //选中时
                    dgv_04.Rows[i].Cells[0].Value = true;
                    dgv_05.RowCount++;
                    int ii = dgv_05.RowCount - 1;
                    dgv_05.Rows[ii].Cells["id05"].Value = dgv_04.Rows[i].Cells["id04"].Value;
                    dgv_05.Rows[ii].Cells["pd_id05"].Value = dgv_04.Rows[i].Cells["pd_id04"].Value;
                    dgv_05.Rows[ii].Cells["par_code05"].Value = dgv_04.Rows[i].Cells["par_code04"].Value;
                    dgv_05.Rows[ii].Cells["par_name05"].Value = dgv_04.Rows[i].Cells["par_name04"].Value;
                    dgv_05.Rows[ii].Cells["par_def_value05"].Value = dgv_04.Rows[i].Cells["par_def_value04"].Value;
                    dgv_05.Rows[ii].Cells["par_type05"].Value = dgv_04.Rows[i].Cells["par_type04"].Value;
                    dgv_05.Rows[ii].Cells["par_description05"].Value = dgv_04.Rows[i].Cells["par_description04"].Value;
                    dgv_05.Rows[ii].Cells["par_priority05"].Value = "";
                    dgv_05.Sort(dgv_05.Columns["par_priority05"], ListSortDirection.Ascending);

                }
                else
                {
                    //取消选中
                    dgv_04.Rows[i].Cells[0].Value = false;
                    string var01 = dgv_04.Rows[i].Cells["id04"].Value.ToString();
                    for (int j = 0; j < dgv_05.Rows.Count; j++)
                    {
                        if (var01 == dgv_05.Rows[j].Cells["id05"].Value.ToString())
                        {
                            dgv_05.Rows.RemoveAt(j);
                        }
                    }

                }
                but_01.Enabled = true;
            }
        }

        private void but_02_Click(object sender, EventArgs e)
        {
            
            SortedList sltmp01 = new SortedList();
            SortedList sltmp_01 = new SortedList();
            sltmp_01.Add(1, tb_02.Text.Trim());
            sltmp_01.Add(2, str_prid);
            sltmp01.Add(1, sltmp_01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-apppd-add001", sltmp01, sltmp02);
            int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-procedure-up001", sltmp01, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，流程条码规则配置成功。");
            //    tabc_01.SelectedIndex = 0;
            //    SortedList sttemp02 = new SortedList();
            //    sttemp02.Add(1, CnasBaseData.SystemID);
            //    dtall = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sttemp02);
            }
        }

        private void but_21_Click(object sender, EventArgs e)
        {
            if (tb_21.Text.Trim() == "" || tb_22.Text.Trim() == "" || tb_24.Text.Trim() == "" || tb_26.Text.Trim() == "" || cb_23.Text == "")
            {
                MessageBox.Show("对不起，请填写正确信息！！！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, tb_26.Text.Trim());
            sltmp01.Add(2, tb_21.Text.Trim());
            sltmp01.Add(3, tb_22.Text.Trim());
            string strbarcode = "BCXP" + tb_partype.Text ;
            sltmp01.Add(4, strbarcode);
            sltmp01.Add(5, tb_25.Text + "00" + tb_21.Text.Trim());
            sltmp01.Add(6, tb_24.Text.Trim());
            sltmp01.Add(7, cb_23.Text.Substring(0, 1));
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdbaseparvalue-add01", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，增加参数值成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_21.Text = "";
                tb_22.Text = "";
                tb_24.Text = "";
                cb_23.Text = "";
                loadparvalue();
            }
            else
            {
                MessageBox.Show("对不起，增加参数值失败，可能是编码重复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void but_05_Click(object sender, EventArgs e)
        {
            if (tb_11.Text.Trim() == "" || tb_12.Text.Trim() == "" || tb_13.Text.Trim() == "" || tb_14.Text.Trim() == "" || cb_par02.Text == "")
            {
                MessageBox.Show("对不起，请填写正确信息！！！！");
                return;
            }           
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(0, tb_11.Text.Trim());
            sltmp01.Add(1, tb_11.Text.Trim());
            sltmp01.Add(2, tb_12.Text.Trim());
            sltmp01.Add(3, tb_13.Text.Trim());
            sltmp01.Add(4, cb_par02.Text.Substring(0, 1));
            sltmp01.Add(5, tb_14.Text.Trim());
            sltmp01.Add(6, CnasBaseData.SystemID);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdbasepar-add01", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，增加流程参数成功。");
                tb_11.Text = "";
                tb_12.Text = "";
                tb_13.Text = "";
                tb_14.Text = "";
                cb_par02.Text = "";
                load_pdpar();
            }
            else
            {
                MessageBox.Show("对不起，增加流程参数失败，可能是编码重复。");
            }
        }

        private void but_22_Click(object sender, EventArgs e)
        {
            if (dgv_06.CurrentRow == null) return;
            string str_pid = dgv_06.CurrentRow.Cells["par_id06"].Value.ToString();
            string str_value = dgv_06.CurrentRow.Cells["v_value06"].Value.ToString();

            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, str_pid);
            sltmp01.Add(2, str_value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdbaseparvalue-del01", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，删除参数值成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_21.Text = "";
                tb_22.Text = "";
                tb_24.Text = "";
                cb_23.Text = "";
                loadparvalue();
            }
            else
            {
                MessageBox.Show("对不起，删除参数值失败，可能是编码重复。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadparvalue()
        {
            dgv_06.Rows.Clear();
            //HCS-appbaseparvalue-sec01
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, tb_26.Text);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-pdbaseparvalue-sec01", sttemp02);
            if (dt01 != null)
            {
                for (int i = 0; i < dt01.Rows.Count; i++)
                {
                    dgv_06.RowCount++;
                    if (dt01.Rows[i]["par_id"] != null) dgv_06.Rows[i].Cells["par_id06"].Value = dt01.Rows[i]["par_id"].ToString();
                    if (dt01.Rows[i]["v_value"] != null) dgv_06.Rows[i].Cells["v_value06"].Value = dt01.Rows[i]["v_value"].ToString();
                    if (dt01.Rows[i]["v_name"] != null) dgv_06.Rows[i].Cells["v_name06"].Value = dt01.Rows[i]["v_name"].ToString();
                    if (dt01.Rows[i]["v_barcode"] != null) dgv_06.Rows[i].Cells["v_barcode06"].Value = dt01.Rows[i]["v_barcode"].ToString();
                    if (dt01.Rows[i]["v_type"] != null) dgv_06.Rows[i].Cells["v_type06"].Value = dt01.Rows[i]["v_type"].ToString();
                    if (dt01.Rows[i]["next_code"] != null) dgv_06.Rows[i].Cells["next_code06"].Value = dt01.Rows[i]["next_code"].ToString();
                }
            }


            #region 初始化条件选择
            SortedList sttemp05 = new SortedList();
            sttemp05.Add(1, str_prid);
            sttemp05.Add(2, CnasBaseData.SystemID);
            dtpdpar = reCnasRemotCall.RemotInterface.SelectData("HCS-pdbaseparvalue-sec02", sttemp05);            
            #endregion
        }

        private void dgv_05_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tb_26.Text = dgv_05.Rows[e.RowIndex].Cells["id05"].Value.ToString();
                tb_25.Text = dgv_05.Rows[e.RowIndex].Cells["par_code05"].Value.ToString();
                tb_partype.Text = dgv_05.Rows[e.RowIndex].Cells["par_type05"].Value.ToString();
                tabc_02.SelectedIndex = 0;
                //加载参数值
                loadparvalue();
            }
        }

    }
}
