using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Text.RegularExpressions;
using System.Configuration;



namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_sterilizer_device_program_new : Form
    {
        SortedList sl_SterilizerType = new SortedList();
        SortedList sl_ProgramType = new SortedList();
        private string Strselectid = "";
        private string Strselectname = "";
        private string Sterilizer_id = "";
        private string program_name = "";
        public HCSCM_sterilizer_device_program_new(SortedList SLdata, DataRow[] arrayDR, string str_id,DataTable getdt)
        {
            InitializeComponent();
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建灭菌流程";
            Sterilizer_id = str_id;
            foreach (DataRow dr in arrayDR)
            {
                sl_SterilizerType.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
             CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            
            if (getdt != null)//清洗程序
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_ProgramType.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["pr_name"].ToString().Trim());
                        cb_program.Items.Add(getdt.Rows[i]["pr_name"].ToString().Trim());

                    }
            }
            if (SLdata != null)//在窗体上显示信息
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改灭菌流程";
                Strselectid = SLdata["id"].ToString();
                Strselectname= this.tb_name.Text = SLdata["dp_name"].ToString();
                this.tb_barcode.Text = SLdata["bar_code"].ToString();
                this.tb_run_time.Text = SLdata["run_time"].ToString();
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
                this.tb_run_time.Text = SLdata["run_time"].ToString();
                this.cb_program.Text = SLdata["p_id"].ToString();
                program_name = SLdata["p_id"].ToString();
                this.cb_type.Text = sl_SterilizerType.GetKey(sl_SterilizerType.IndexOfValue(SLdata["p_type"].ToString())) + ":" + SLdata["p_type"].ToString();
            }
            }
       
        DataTable getdt = new DataTable();
        private void but_ok_Click_1(object sender, EventArgs e)
        {
            #region 验证
            if (this.tb_name.Text.Trim() == "")
            {
                MessageBox.Show("请填写灭菌流程名称。","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (this.cb_program.Text.Trim () == "")
            {
                MessageBox.Show("请选择灭菌程序。","提示信息",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(tb_run_time.Text.Trim()=="")
            {
                MessageBox.Show("请填写运行时间。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_type.SelectedItem == null)
            {
                MessageBox.Show("请选择灭菌类型。","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            //如果运行时间不为null，则表示需要验证输入的值是否正确
            if (!string.IsNullOrEmpty(tb_run_time.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_run_time.Text))
                {
                    MessageBox.Show("运行时间输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
           
            #endregion
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Sterilizer_id);
            //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-sterilizer-deviceprogram-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-deviceprogram-sec001", sttemp01);
            try
            {
                            
            if (Strselectid == "")//增加
            {
                #region 判断这台灭菌器的灭菌程序是否重复
               
                
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["p_id"].ToString() != null)
                        {
                            if (sl_ProgramType.GetKey(sl_ProgramType.IndexOfValue(cb_program.Text.Trim())).ToString() == getdt.Rows[i]["p_id"].ToString().Trim())
                            {
                                MessageBox.Show("灭菌程序已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                #endregion
                #region 判断流程名字是否重复
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii < 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["dp_name"].ToString() != null)
                        {
                            if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["dp_name"].ToString().Trim())
                            {
                                MessageBox.Show("流程名称已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, sl_ProgramType.GetKey(sl_ProgramType.IndexOfValue(cb_program.Text.Trim())).ToString());
                sltmp.Add(2, tb_barcode.Text.Trim());
                sltmp.Add(3, tb_name.Text.Trim());
                sltmp.Add(4, cb_type.Text.Trim().Substring(0, 1));
                sltmp.Add(5, tb_run_time.Text.Trim());
                sltmp.Add(6, tb_remarks.Text.Trim());
                sltmp.Add(7, Sterilizer_id);
                sltmp01.Add(1, sltmp);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-deviceprogram-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，增加成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
               
                if (cb_program.Text.Trim() != program_name)//如果灭菌程序被改变执行
                {
                   
                    #region 判断这台灭菌器的灭菌程序是否重复
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt.Rows[i]["p_id"].ToString() != null)
                            {
                                if (sl_ProgramType.GetKey(sl_ProgramType.IndexOfValue(cb_program.Text.Trim())).ToString() == getdt.Rows[i]["p_id"].ToString().Trim())
                                {
                                    MessageBox.Show("灭菌程序已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }
                    #endregion

                    #region 判断流程名字是否存在
                    if (this.tb_name.Text.Trim() != Strselectname)
                    {
                        if (getdt != null)
                        {
                            int ii = getdt.Rows.Count;
                            if (ii <=0) return;
                            for (int i = 0; i < ii; i++)
                            {
                                if (getdt.Rows[i]["dp_name"].ToString() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["dp_name"].ToString().Trim())
                                    {
                                        MessageBox.Show("流程名称已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                
                #endregion
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, tb_name.Text.Trim());
                sltmp01.Add(2, sl_ProgramType.GetKey(sl_ProgramType.IndexOfValue(cb_program.Text.Trim())));
                sltmp01.Add(3, cb_type.Text.Trim().Substring(0, 1));
                sltmp01.Add(4, tb_run_time.Text.Trim());
                sltmp01.Add(5, tb_remarks.Text.Trim());
                sltmp01.Add(6, Strselectid);
                sltmp.Add(1, sltmp01);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-deviceprogram-up001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，修改成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现未知错误：" + ex.Message + ",请联系管理员。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }      
    }
    }

