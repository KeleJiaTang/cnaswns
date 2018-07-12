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
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_dressing_new : Form
    {
        private string Strselectid = "";
        private string Instrument_id = "";
        private string Strselectname = "";
        private SortedList sl_type = new SortedList();
        public HCSCM_dressing_new(SortedList SLdata, string dre_id, string dre)
        {
            InitializeComponent();

           // this.Font = new Font(this.Font.FontFamily, 11);

            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新建敷料衣物";
            Instrument_id = dre_id;
            tb_dre.Text = HCSCM_dressing_info_manage.txt;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_dressing_info'");
            foreach (DataRow dr in typeDR)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            //修改时显示已有数据
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改敷料衣物";
                Strselectid = SLdata["id"].ToString();
                tb_dre.Text = dre;
                Strselectname = this.tb_name.Text = SLdata["dre_name"].ToString();
                this.tb_count.Text = SLdata["dre_count"].ToString();
                this.cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(SLdata["dre_type"].ToString())).ToString() + ":" + SLdata["dre_type"].ToString();
                this.tb_remarks.Text = SLdata["ca_remarks"].ToString();
            }



        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            #region 验证
            if (tb_name.Text.Trim()=="")
            {
                MessageBox.Show("请输入衣物名称。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_type.Text.Trim()=="")
            {
                MessageBox.Show("请选择衣类型。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            //如果数量不为null，则表示需要验证输入的值是否正确
            if (!string.IsNullOrEmpty(tb_count .Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_count.Text))
                {
                   MessageBox.Show("衣物数量输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (tb_count.Text.Trim() == "")
            {
                tb_count.Text = "NULL";
            }
            #endregion
            try 
            { 
            if (Strselectid == "")//增加
            {
                #region 判断名字是否重复
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sltmp02 = new SortedList();
                sltmp02.Add(1, Instrument_id);

                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-info-sec001", sltmp02);//49
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["dre_name"].ToString().Trim() != null)
                        {
                            if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["dre_name"].ToString().Trim())
                            {
                                MessageBox.Show("敷料衣物名称已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion 
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, Instrument_id);
                sltmp.Add(2, tb_name.Text.Trim());
                sltmp.Add(3, tb_count.Text.Trim());
                sltmp.Add(4, cb_type.Text.Trim().Substring(0, 1));
                sltmp.Add(5, tb_remarks.Text.Trim());
                sltmp01.Add(1, sltmp);

                string ggg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-dressing-info-add001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-info-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，增加成功。","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }

            else
            {
                #region 判断名字是否已经存在
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                if (tb_name.Text.Trim() != Strselectname)
                {

                    DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-info-sec002", null);
                    if (getdt01 != null)
                    {
                        int aa = getdt01.Rows.Count;
                        if (aa <= 0) return;
                        for (int i = 0; i < aa; i++)
                        {
                            if (getdt01.Rows[i]["dre_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt01.Rows[i]["dre_name"].ToString().Trim())
                                {
                                    MessageBox.Show("敷料衣物名称已存在。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }
                #endregion 
                SortedList sttmp01 = new SortedList();
                SortedList sttmp = new SortedList();
                sttmp01.Add(1, tb_name.Text.Trim());
                sttmp01.Add(2, tb_count.Text.Trim());
                sttmp01.Add(3, cb_type.Text.Trim().Substring(0, 1));
                sttmp01.Add(4, tb_remarks.Text.Trim());
                sttmp01.Add(5, Strselectid);
                sttmp.Add(1, sttmp01);
                string dg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-dressing-info-up001", sttmp, null);
                int recent = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-info-up001", sttmp, null);
                if (recent > -1)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
        }
    }


        
