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
using CnasUI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_app_bpm : TemplateForm
    {
        private DataTable dtappall = new DataTable();
        private DataTable dtallpd = new DataTable();
        private SortedList slappparent = new SortedList();
        private int inttp = 0;

        public HCSSM_app_bpm()
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--流程配置";
        }

        private void HCSSM_app_bpm_Load(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec003", sttemp01);
            if (dtappall != null)
            {
                for(int i=0;i<dtappall.Rows.Count;i++)
                {
                    //slappparent.Add(dr["app_name"].ToString().Trim(), dr["app_code"].ToString().Trim());
                    cb_app.Items.Add(dtappall.Rows[i]["id"].ToString().Trim()+"："+dtappall.Rows[i]["app_name"].ToString().Trim());
                }
            }

            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.SystemID);
            dtallpd = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sttemp02);
            if (dtallpd == null)
            {
                MessageBox.Show("对不起！没有流程数据，请联系管理员");    
            }
        }

        private void cb_app_SelectedValueChanged(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
            if (dtallpd != null && dtallpd.Rows.Count != 0)
            {
                dgv_01.RowCount = dtallpd.Rows.Count;
                for (int i = 0; i < dtallpd.Rows.Count; i++)
                {
                    dgv_01.Rows[i].Cells["isselected"].Value = false;
                    //if (dtallpd.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dtallpd.Rows[i]["id"].ToString();
                    if (dtallpd.Rows[i]["pd_code"] != null) dgv_01.Rows[i].Cells["pd_code"].Value = dtallpd.Rows[i]["pd_code"].ToString();
                    if (dtallpd.Rows[i]["pd_name"] != null) dgv_01.Rows[i].Cells["pd_name"].Value = dtallpd.Rows[i]["pd_name"].ToString();
                    if (dtallpd.Rows[i]["pd_scan"] != null) dgv_01.Rows[i].Cells["pd_scan"].Value = dtallpd.Rows[i]["pd_scan"].ToString();
                }
            } 

            dgv_02.Rows.Clear();
            string[] strdata = cb_app.Text.Split('：');
            string strappid = strdata[0];
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, strappid);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-apppd-sec001", sttemp02);
            if (dt01 != null)
            {                
                for (int j = 0; j < dgv_01.Rows.Count; j++)
                {
                    string listid = "", secid = "";
                    listid = dgv_01.Rows[j].Cells["pd_code"].Value.ToString();

					if (dt01.Columns.Contains("pd_code"))
					{
						DataRow[] arrayDR = dt01.Select("pd_code='" + listid + "'");
						if (arrayDR.Length > 0)
						{
							dgv_01.Rows[j].Cells["isselected"].Value = true;
							dgv_02.RowCount++;
							int ii = dgv_02.RowCount - 1;
							//dgv_02.Rows[ii].Cells["id02"].Value = dgv_01.Rows[j].Cells["id"].Value;
							dgv_02.Rows[ii].Cells["pd_code02"].Value = dgv_01.Rows[j].Cells["pd_code"].Value;
							dgv_02.Rows[ii].Cells["pd_name02"].Value = dgv_01.Rows[j].Cells["pd_name"].Value;
							dgv_02.Rows[ii].Cells["pd_scan02"].Value = dgv_01.Rows[j].Cells["pd_scan"].Value;
						}
					}
                }
            }
        }

        

        private void but_01_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定修改： " + cb_app.Text + " 的相关流程吗？这样会导致全部参数数据清除！！！", "删除流程", MessageBoxButtons.YesNo) == DialogResult.No) return;
            string[] strdata = cb_app.Text.Split('：');
            string strappid = strdata[0];
            if (dgv_02.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, strappid);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, strappid);
                    sltmp_02.Add(2, dgv_02.Rows[i].Cells["pd_code02"].Value);
                    //sltmp_02.Add(3, dgv_02.Rows[i].Cells["id02"].Value);
                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-apppd-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-apppd-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，APP流程配置成功。");
                    this.Close();
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
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-apppd-del001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，APP流程配置成功。");
                    this.but_01.Enabled = false;
                    //this.Close();
                }
            }


        }

        private void chb_wf_CheckedChanged(object sender, EventArgs e)
        {            
            if(chb_wf.Checked)
            {
                dgv_01.Rows.Clear();
                dgv_02.Rows.Clear();
                but_01.Enabled = true;
                if (dtallpd != null && dtallpd.Rows.Count != 0)
                {
                    dgv_01.RowCount = dtallpd.Rows.Count;
                    dgv_02.RowCount = dtallpd.Rows.Count;
                    for (int i = 0; i < dtallpd.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = true;
                        //if (dtallpd.Rows[i]["id"] != null)
                        //{
                        //    dgv_01.Rows[i].Cells["id"].Value = dtallpd.Rows[i]["id"].ToString();
                        //    dgv_02.Rows[i].Cells["id02"].Value = dgv_01.Rows[i].Cells["id"].Value;
                        //}
                        if (dtallpd.Rows[i]["pd_code"] != null)
                        {
                            dgv_01.Rows[i].Cells["pd_code"].Value = dtallpd.Rows[i]["pd_code"].ToString();
                            dgv_02.Rows[i].Cells["pd_code02"].Value = dgv_01.Rows[i].Cells["pd_code"].Value;
                        }
                        if (dtallpd.Rows[i]["pd_name"] != null)
                        {
                            dgv_01.Rows[i].Cells["pd_name"].Value = dtallpd.Rows[i]["pd_name"].ToString();
                            dgv_02.Rows[i].Cells["pd_name02"].Value = dgv_01.Rows[i].Cells["pd_name"].Value;
                        }
                        if (dtallpd.Rows[i]["pd_scan"] != null)
                        {
                            dgv_01.Rows[i].Cells["pd_scan"].Value = dtallpd.Rows[i]["pd_scan"].ToString();
                            dgv_02.Rows[i].Cells["pd_scan02"].Value = dgv_01.Rows[i].Cells["pd_scan"].Value;
                        }
                    }
                    
                }


            }else
            {                
                dgv_02.Rows.Clear();
                but_01.Enabled = true;
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {
                    dgv_01.Rows[i].Cells["isselected"].Value = false;
                    
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
                    dgv_01.Rows[i].Cells[0].Value = true;
                    dgv_02.RowCount++;
                    int ii = dgv_02.RowCount - 1;
                    //dgv_02.Rows[ii].Cells["id02"].Value = dgv_01.Rows[i].Cells["id"].Value;
                    dgv_02.Rows[ii].Cells["pd_code02"].Value = dgv_01.Rows[i].Cells["pd_code"].Value;
                    dgv_02.Rows[ii].Cells["pd_name02"].Value = dgv_01.Rows[i].Cells["pd_name"].Value;
                    dgv_02.Rows[ii].Cells["pd_scan02"].Value = dgv_01.Rows[i].Cells["pd_scan"].Value;
                    dgv_02.Sort(dgv_02.Columns[1], ListSortDirection.Ascending);
                    

                }
                else
                {
                    //取消选中
                    dgv_01.Rows[i].Cells[0].Value = false;
                    var var01 = dgv_01.Rows[i].Cells["pd_code"].Value;
                    for (int j = 0; j < dgv_02.Rows.Count; j++)
                    {
                        if (var01 == dgv_02.Rows[j].Cells["pd_code02"].Value)
                        {
                            dgv_02.Rows.RemoveAt(j);
                        }
                    }

                }
                but_01.Enabled = true;
            }
        }

        private void dgv_02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgv_03.Rows.Clear();
                #region 获取已经配置好流程数据
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                string strprcid = dgv_02.Rows[e.RowIndex].Cells["pd_code02"].Value.ToString();
                DataRow[] arrayDR01 = dtallpd.Select("pd_code=" + strprcid);
                if (arrayDR01 != null && arrayDR01[0]["pd_scan"] != null) tb_02.Text = arrayDR01[0]["pd_scan"].ToString(); 
                sttemp01.Add(1, strprcid);
                DataTable dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure_relation-sec001", sttemp01);
                if (dtselect != null)
                {
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        string str_id = "",  str_name = "", str_priority = "0", str_condition = "";
                        if (dtselect.Rows[i]["next_pdcode"] != null) str_id = dtselect.Rows[i]["next_pdcode"].ToString();
                        if (dtselect.Rows[i]["pr_priority"] != null) str_priority = dtselect.Rows[i]["pr_priority"].ToString();
                        if (dtselect.Rows[i]["pr_condition"] != null) str_condition = dtselect.Rows[i]["pr_condition"].ToString();                        
                        DataRow[] arrayDRsec = dtallpd.Select("id=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            //if (arrayDRsec[0]["pd_code"] != null) str_code = arrayDRsec[0]["pd_code"].ToString();
                            if (arrayDRsec[0]["pd_name"] != null) str_name = arrayDRsec[0]["pd_name"].ToString(); 
                            //if (arrayDRsec[0]["pd_scan"] != null) tb_02.Text = arrayDRsec[0]["pd_scan"].ToString();                            
                        }
                        DataGridViewRow drtemp01 = new DataGridViewRow();
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());   
                        drtemp01.Cells.Add(new DataGridViewTextBoxCell());
                        drtemp01.SetValues(str_id, str_name, str_priority, str_condition);
                        dgv_03.Rows.Add(drtemp01);
                    }
                }
                #endregion
            }

        }

        private void dgv_03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgv_03.Rows[e.RowIndex].Cells["pr_condition"].Value != null) tb_01.Text = dgv_03.Rows[e.RowIndex].Cells["pr_condition"].Value.ToString();
            }
        }

        private void but_02_Click(object sender, EventArgs e)
        {
            //dgv_02
            if (dgv_02.CurrentRow.Index>-1)
            {
                string strpid = dgv_02.CurrentRow.Cells["pd_code02"].Value.ToString();
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, tb_02.Text.Trim());
                sltmp_01.Add(2, strpid);
                sltmp01.Add(1, sltmp_01);                
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-apppd-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-procedure-up001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，流程条码参数配置成功。");
                    tabc_01.SelectedIndex = 0;
                    SortedList sttemp02 = new SortedList();
                    sttemp02.Add(1, CnasBaseData.SystemID);
                    dtallpd = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sttemp02);
                }
            }
        }

    

  

        private void tb_21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
             {
                 e.Handled = true;
             }
        }


 
    }
}
