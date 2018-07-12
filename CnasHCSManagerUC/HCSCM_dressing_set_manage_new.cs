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
    public partial class HCSCM_dressing_set_manage_new : Form
    {
        private SortedList sl_customer = new SortedList();//id与值
        private SortedList sl_customer_01 = new SortedList();//barcode与值
        private SortedList sl_costcenter = new SortedList();
        private SortedList sl_str = new SortedList();
        private SortedList sl_material = new SortedList();
        private string Length = "0";
        private string Weidth = "0";
        private string Hight = "0";
        private string Stu = "0.000";
        private string Selectid = "";
        private string Selectname = "";
        public HCSCM_dressing_set_manage_new(DataTable getdt01,DataTable getdt02,SortedList SLdata)
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建敷料包";
            // Selectname = tb_name.Text = SLdata["ca_name"].ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //成本中心
            if (getdt01 != null)
            {
                int ii = getdt01.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt01.Rows[i]["ca_name"] != null)
                        cb_cost_center.Items.Add(getdt01.Rows[i]["ca_name"].ToString().Trim());
                }
            }
            //客户
            if (getdt02 != null)
            {
                int ii = getdt02.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt02.Rows[i]["id"].ToString().Trim() != null && getdt02.Rows[i]["bar_code"].ToString() != null && getdt02.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_customer.Add(getdt02.Rows[i]["id"].ToString(), getdt02.Rows[i]["cu_name"].ToString().Trim());
                        sl_customer_01.Add(getdt02.Rows[i]["bar_code"].ToString(), getdt02.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt02.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                //灭菌程序
                DataTable getdt04 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
                if (getdt04 != null)
                {
                    sl_str.Add("0", "无灭菌程序");
                    this.cb_str.Items.Add("无灭菌程序");
                    int aa = getdt04.Rows.Count;
                    if (aa <= 0) return;
                    for (int i = 0; i < aa; i++)
                    {
                        if (getdt04.Rows[i]["id"].ToString() != null && getdt04.Rows[i]["pr_name"].ToString().Trim() != null)
                        {
                            sl_str.Add(getdt04.Rows[i]["id"].ToString(), getdt04.Rows[i]["pr_name"].ToString().Trim());
                            cb_str.Items.Add(getdt04.Rows[i]["pr_name"].ToString().Trim());
                        }
                    }
                    //打包材料
                    DataTable getdt05 = reCnasRemotCall.RemotInterface.SelectData("hcs-setmaterial-type-sec002", null);
                    if (getdt05 != null)
                    {
                        int bb = getdt05.Rows.Count;
                        if (bb <= 0) return;
                        for (int i = 0; i < bb; i++)
                        {
                            if (getdt05.Rows[i]["id"].ToString() != null && getdt05.Rows[i]["ca_name"].ToString().Trim() != null)
                            {
                                sl_material.Add(getdt05.Rows[i]["id"].ToString(), getdt05.Rows[i]["ca_name"].ToString().Trim());
                                cb_material.Items.Add(getdt05.Rows[i]["ca_name"].ToString().Trim());
                            }
                        }
                        if (SLdata != null)
                        {
                            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改敷料包";
                            Selectid = SLdata["id"].ToString();
                            tb_barcode.Text = SLdata["bar_code"].ToString();
                            Selectname = tb_name.Text = SLdata["ca_name"].ToString();
                            tb_price.Text = SLdata["handle_price"].ToString();
                            tb_remarks.Text = SLdata["ca_material"].ToString();
                            tb_size.Text = SLdata["ca_size"].ToString();
                            tb_weight.Text = SLdata["ca_weight"].ToString();
                            cb_customer.Text = sl_customer_01[SLdata["customer_code"].ToString()].ToString();
                            cb_cost_center.Text = SLdata["cost_center"].ToString();
                            cb_material.Text = sl_material[SLdata["ca_material"].ToString()].ToString();
                            cb_str.Text = SLdata["sterilizer_type"].ToString();
                            string str = tb_size.Text;
                            string[] sArray = str.Split('x');
                            tb_stu.Text = Calculation_stu(sArray[0], sArray[1], sArray[2]) + "STU";
                            Length = sArray[0].ToString();
                            Weidth = sArray[1].ToString();
                            Hight = sArray[2].ToString();
                            tb_remarks.Text = SLdata["ca_remarks"].ToString();
                        }
                    }
                }
            }
        }

        #region STU的计算方法
        private string Calculation_stu(string L, string W, string H)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            double sum = 1;
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_size'");//包的大小
            foreach (DataRow dr in arrayDR)
            {

                sum *= Convert.ToDouble(dr["value_code"].ToString());
            }
            Stu = Math.Round(Convert.ToDouble(H) * Convert.ToDouble(L) * Convert.ToDouble(W) / sum, 4).ToString();
            return Stu;
        }
        #endregion
        #region 包的长宽高
        private void but_input_Click(object sender, EventArgs e)//输入包的长宽高
        {
            HCSCM_set_size hcsm = new HCSCM_set_size(Length, Weidth, Hight, Stu);
            hcsm.ShowDialog();
            Length = hcsm.Length;
            Weidth = hcsm.Weidth;
            Hight = hcsm.Hight;
            Stu = hcsm.Stu;
            tb_size.Text = Length + "x" + Weidth + "x" + Hight;
            tb_stu.Text = Stu + "  STU";
        }
        #endregion

        #region 成本中心与客户的关系
        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            sl_costcenter.Clear();
            string str = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.SelectedItem)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_costcenter.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
        }
#endregion
        private DataTable getdt = new DataTable();
        /// <summary>
        /// "确定"按钮触发事件
        /// </summary>       
        private void but_ok_Click_1(object sender, EventArgs e)
        {
            #region 验证
            if (tb_name.Text.Trim()=="")
            {
                MessageBox.Show("请输入敷料包名称。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            if (cb_material.Text.Trim()=="")
            {
                MessageBox.Show("请选择包装材料。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_customer.Text.Trim()=="")
            {
                MessageBox.Show("请选择客户。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_size.Text.Trim() == "")
            {
                tb_size.Text = "";
            }           
            if (cb_cost_center.Text.Trim()=="")
            {
                MessageBox.Show("请选择成本中心。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(cb_str.Text .Trim()=="")
            {
                MessageBox.Show("请选择灭菌程序。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(tb_weight.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_weight.Text))
                {
                    MessageBox.Show("重量输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(tb_price.Text))
            {
                //如果用户输入的值不为正整数，则提示用户
                if (!CnasUtilityTools.IsNumeric(tb_price.Text))
                {
                    MessageBox.Show("衣物数量输入的格式不正确，请输入正整数。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (tb_stu.Text.Trim() == "")
            {
                tb_stu.Text = "0";
            }
            if (tb_price.Text.Trim() == "")
            {
                tb_price.Text = "NULL";
            }
            if (tb_weight.Text.Trim() == "")
            {
                tb_weight.Text = "NULL";
            }
            #endregion

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec001", sttmp02);
            try
            {

            if (Selectid == "")
            {
                #region 判断名字是否重复
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                        {
                            if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                            {
                                MessageBox.Show("敷料包名称已存在。","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, tb_name.Text.Trim());//名字
                sltmp.Add(2, tb_barcode.Text.Trim());//条码
                sltmp.Add(3, sl_material.GetKey(sl_material.IndexOfValue(cb_material.Text.Trim())));//打包材料
                sltmp.Add(4, tb_price.Text.Trim());//价格
                sltmp.Add(6, sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_cost_center.Text.Trim())));//成本中心
                sltmp.Add(5, sl_customer_01.GetKey(sl_customer_01.IndexOfValue(cb_customer.Text.Trim())));//顾客
                sltmp.Add(7, tb_weight.Text.Trim());//重量
                sltmp.Add(8, sl_str.GetKey(sl_str.IndexOfValue(cb_str.Text.Trim())));//灭菌类型
                sltmp.Add(9, tb_size.Text.Trim());//大小
                sltmp.Add(10, tb_remarks.Text.Trim());//备注
                sltmp.Add(11, CnasBaseData.SystemID);
                sltmp01.Add(1, sltmp);
                string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-dressing-set-add001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-set-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，增加成功。","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                #region 判断名字是否重复
                if (tb_name.Text.Trim() != Selectname)
                {



                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                        {
                            if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                            {
                                if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show("敷料包名称已存在。","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }
                #endregion

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, tb_name.Text.Trim());//名字
                sltmp.Add(2, sl_material.GetKey(sl_material.IndexOfValue(cb_material.Text.Trim())));//打包材料
                sltmp.Add(3, tb_price.Text.Trim());//价格
                sltmp.Add(5, sl_costcenter.GetKey(sl_costcenter.IndexOfValue(cb_cost_center.Text.Trim())));//成本中心
                sltmp.Add(4, sl_customer_01.GetKey(sl_customer_01.IndexOfValue(cb_customer.Text.Trim())));//顾客
                sltmp.Add(6, tb_weight.Text.Trim());//重量
                sltmp.Add(7, sl_str.GetKey(sl_str.IndexOfValue(cb_str.Text.Trim())));//灭菌类型
                sltmp.Add(8, tb_size.Text.Trim());//大小
                sltmp.Add(9, tb_remarks.Text.Trim());//备注
                sltmp.Add(10, Selectid);
                sltmp01.Add(1, sltmp);
                //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-dressing-set-up001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-set-up001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，修改成功。","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tb_stu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}