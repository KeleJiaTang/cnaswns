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


namespace Cnas.wns.CnasHCSReport
{
    public partial class ChartForm1 : Form
    {

        DateTime currentYear;




        public ChartForm1()
        {
            InitializeComponent();
            
            //string front = cb_onlyyear.Text.Trim() + "/01/01 00:00:00";//年初
            

            //string back = cb_onlyyear.Text.Trim() + "/12/31 23:59:59";//年尾
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cb_year.Items.Add(i);
                cb_onlyyear.Items.Add(i);
                comboBox1.Items.Add(i);
            }
        }
       
        private void but_select_Click(object sender, EventArgs e)
        {
            if (this.cb_onlyyear.SelectedItem == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            currentYear = new DateTime(int.Parse(cb_onlyyear.Text.Trim()), 1, 1, 0, 0, 0);

            #region 无菌包内器 械缺失发生 件数
            sttemp01.Clear();
            sttemp01.Add(1, 9);
            sttemp01.Add(2, currentYear);
            sttemp01.Add(3, currentYear.AddYears(1).AddSeconds(-1));
            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {

                //如果有值，则计算这一年发生的平均数量
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    //如果选择的年份没有过完者计算前几个月的数量
                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                    {
                        //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        c1RadialGauge2.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1)));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        c1RadialGauge2.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12));//保留小数后两位
                    }

                }
                else
                {
                    c1RadialGauge2.Value = 0;
                }
            }
            #endregion

            #region 无菌包内器 械功能不全 总件数
            sttemp01.Clear();
            sttemp01.Add(1, 10);
            sttemp01.Add(2, currentYear);
            sttemp01.Add(3, currentYear.AddYears(1).AddSeconds(-1));
            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {

                //如果有值，则计算这一年发生的平均数量
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    //如果选择的年份没有过完者计算前几个月的数量
                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                    {
                        // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        c1RadialGauge1.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1)));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        c1RadialGauge1.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12));//保留小数后两位
                    }

                }
                else
                {
                    c1RadialGauge1.Value = 0;
                }
               
            }
            #endregion

            #region 无菌包内 器械种类错 误发生件数
            sttemp01.Clear();
            sttemp01.Add(1, 11);
            sttemp01.Add(2, currentYear);
            sttemp01.Add(3, currentYear.AddYears(1).AddSeconds(-1));
            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {

                //如果有值，则计算这一年发生的平均数量
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    //如果选择的年份没有过完者计算前几个月的数量
                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                    {
                        //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        c1RadialGauge3.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1)));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        c1RadialGauge3.Value = double.Parse(String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12));//保留小数后两位
                    }

                }
                else
                {
                    c1RadialGauge3.Value = 0;
                }
               
            }
            #endregion
        }

        private void cb_onlyyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_get_Click(object sender, EventArgs e)
        {
            currentYear = new DateTime(int.Parse(cb_onlyyear.Text.Trim()), 1, 1, 0, 0, 0);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = null;
            DataTable getdt02 = null;
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, 6);
            sltmp.Add(2, currentYear);
            sltmp.Add(3, currentYear.AddYears(1).AddSeconds(-1));

            // string ii = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sltmp);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sltmp);
            SortedList slttmp = new SortedList();
            SortedList slttmp01 = new SortedList();


            slttmp.Add(2, currentYear);
            slttmp.Add(1, currentYear.AddYears(1).AddSeconds(-1));

            string WE = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_work_set_unwashing_sec001", slttmp);
            getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS_work_set_unwashing_sec001", slttmp);
            if (getdt != null && getdt02 != null)
            {
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    if (getdt02.Rows[0]["count(*)"].ToString() != "" && getdt02.Rows[0]["count(*)"].ToString() != "0")
                    {
                        decimal unnum = Convert.ToDecimal(getdt.Rows[0]["SUM(num)"]);
                        decimal num = Convert.ToDecimal(getdt02.Rows[0]["count(*)"]);
                        c1RadialGauge4.Value = (double)(unnum / num);
                    }
                }
                else
                {

                    c1RadialGauge4.Value = 0;
                }

            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请选择季度。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            int month = int.Parse(comboBox2.Text.Trim()) * 3 - 2;//当前季度的月份3n-2
            int days = DateTime.DaysInMonth(int.Parse(comboBox1.Text.Trim()), month + 3);//季度最后月份的天数
            string front = comboBox1.Text.Trim() + "/" + month + "/01 00:00:00";//季初
            string back = comboBox1.Text.Trim() + "/" + (month + 3) + "/" + days + " 23:59:59";//季尾
            #region 每季消毒物品不合格率
            sttemp01.Add(1, 7);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            DataTable getdtsum = getdt;
            sttemp01.Clear();
            sttemp01.Add(1, front);
            sttemp01.Add(2, back);
            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-work-set-unwashing-sec003", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-work-set-unwashing-sec003", sttemp01);

            if (getdt != null && getdtsum != null)
            {
                //double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）
                if (getdtsum.Rows[0]["SUM(num)"].ToString() != "")
                {
                    if (getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString() != "" && getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString() != "0")
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        c1RadialGauge5.Value =double.Parse( String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString()) ));//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("这段时间内流程没有对这类包有操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    c1RadialGauge5.Value=0;
                }
            }
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            for (int i = 1; i <= 4; i++)
            {

                comboBox2.Items.Add(i);
            }
        }

        private void but_Click(object sender, EventArgs e)
        {
            if (this.cb_year.SelectedItem == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_month.SelectedItem == null)
            {
                MessageBox.Show("请选择月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int days = DateTime.DaysInMonth(int.Parse(cb_year.Text.Trim()), int.Parse(cb_month.Text.Trim()));//月份的天数
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            string front = cb_year.Text.Trim() + "/" + cb_month.Text.Trim() + "/01 00:00:00";//月初
            string back = cb_year.Text.Trim() + "/" + cb_month.Text.Trim() + "/" + days + " 23:59:59";//月尾
            #region 每月灭菌包装不合格率
            sttemp01.Add(1, 8);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            DataTable getdtsum = getdt;
            sttemp01.Clear();
            sttemp01.Add(1, front);
            sttemp01.Add(2, back);
            //  text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-work-set-unwashing-sec002", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-work-set-unwashing-sec002", sttemp01);

            if (getdt != null && getdtsum != null)
            {
                //double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）
                if (getdtsum.Rows[0]["SUM(num)"].ToString() != "")
                {
                    if (getdt.Rows[0]["count(*)"].ToString() != "" && getdt.Rows[0]["count(*)"].ToString() != "0")
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        c1RadialGauge6.Value =double.Parse( String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["count(*)"].ToString())));//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("数据异常，请联系管理员（分母为0）。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    c1RadialGauge6.Value=0;
                }

            }
            #endregion
        }

        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_month.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {

                cb_month.Items.Add(i);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }


    