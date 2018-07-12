using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_operations_report1 : UserControl
    {
        public HCSRS_operations_report1()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            cb_year.Text = DateTime.Now.Year.ToString();
            cb_month.Text = DateTime.Now.Month.ToString();
            cb_onlyyear.Text = DateTime.Now.Year.ToString();
            comboBox1.Text = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
            {
                comboBox2.Text = "1";
            }
            if (DateTime.Now.Month == 4 || DateTime.Now.Month == 5 || DateTime.Now.Month == 6)
            {
                comboBox2.Text = "2";
            }
            if (DateTime.Now.Month == 7 || DateTime.Now.Month == 8 || DateTime.Now.Month == 9)
            {
                comboBox2.Text = "3";
            }
            if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
            {
                comboBox2.Text = "4";
            }
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cb_year.Items.Add(i);
                cb_onlyyear.Items.Add(i);
                comboBox1.Items.Add(i);
            }
            for (int j = 4; j >= 1; j--)
            {
                comboBox2.Items.Add(j);
            }
            for (int k = 12; k >= 1; k--)
            {
                cb_month.Items.Add(k);
            }
            but_Click_1(null,null);
            button_Click_1(null,null);
            but_selectY_Click(null, null);
        }


        private void but_ok_Click(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            #region 湿包发生率
            sttemp01.Add(1, 16);
            sttemp01.Add(2, dtp_front.Value);
            sttemp01.Add(3, dtp_back.Value);
            //  string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                    tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days * 100) + "%";//保留小数后两位
                }
                else
                {
                    tb_wetset.Text = "0%";
                }

            }
            #endregion

            #region 包内化学指示卡不合格发生率
            sttemp01.Clear();
            sttemp01.Add(1, 17);
            sttemp01.Add(2, dtp_front.Value);
            sttemp01.Add(3, dtp_back.Value);
            //  string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）*100%
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                    tb_Indicator.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days * 100) + "%";//保留小数后两位
                }
                else
                {
                    tb_Indicator.Text = "0%";
                }

            }
            #endregion

            #region 器械丢失发生率
            sttemp01.Clear();
            sttemp01.Add(1, 18);
            sttemp01.Add(2, dtp_front.Value);
            sttemp01.Add(3, dtp_back.Value);
            //  string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）*100%
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                    tb_lost.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days * 100) + "%";//保留小数后两位
                }
                else
                {
                    tb_lost.Text = "0%";
                }

            }
            #endregion

            #region 无菌包发放错误发生率
            sttemp01.Clear();
            sttemp01.Add(1, 19);
            sttemp01.Add(2, dtp_front.Value);
            sttemp01.Add(3, dtp_back.Value);
            //  string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）*100%
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                    tb_grant.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days * 100) + "%";//保留小数后两位
                }
                else
                {
                    tb_grant.Text = "0%";
                }

            }
            #endregion

            #region 灭菌失败发生率
            sttemp01.Clear();
            sttemp01.Add(1, 20);
            sttemp01.Add(2, dtp_front.Value);
            sttemp01.Add(3, dtp_back.Value);
            //  string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                double days = ExecDateDiff(dtp_front.Value, dtp_back.Value);//相差天数
                //如果有值，则计算这几天发生的平均数量（发生数/天数）*100%
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                    tb_fail.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days * 100) + "%";//保留小数后两位
                }
                else
                {
                    tb_fail.Text = "0%";
                }

            }
            #endregion
        }
        /// <summary>
        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static double ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //转为天数
            return ts3.Days;
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
                        textBox13.Text = String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["count(*)"].ToString()) * 100) + "%";//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("数据异常，请联系管理员（分母为0）。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    textBox13.Text = "0%";
                }

            }
            #endregion
        }

        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
        /// <summary>
        /// 计算月平均数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string front = cb_onlyyear.Text.Trim() + "/01/01 00:00:00";//年初
            string back = cb_onlyyear.Text.Trim() + "/12/31 23:59:59";//年尾

            #region 无菌包内器 械缺失发生 件数
            sttemp01.Clear();
            sttemp01.Add(1, 9);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox1.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    textBox1.Text = "0";
                }

            }
            #endregion

            #region 无菌包内器 械功能不全 总件数
            sttemp01.Clear();
            sttemp01.Add(1, 10);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox2.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    textBox2.Text = "0";
                }


            }
            #endregion

            #region 无菌包内 器械种类错 误发生件数
            sttemp01.Clear();
            sttemp01.Add(1, 11);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox3.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    textBox3.Text = "0";
                }

            }
            #endregion

            #region 无菌包标 识不正确发 生件数
            sttemp01.Clear();
            sttemp01.Add(1, 12);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox4.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox4.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    textBox4.Text = "0";
                }

            }
            #endregion



            #region 湿包发生 数
            sttemp01.Clear();
            sttemp01.Add(1, 14);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox6.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox6.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    textBox6.Text = "0";
                }

            }
            #endregion

            #region 包内化学 指标卡不合 格报告数
            sttemp01.Clear();
            sttemp01.Add(1, 15);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox7.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox7.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }
                }
                else
                {
                    textBox7.Text = "0";
                }
            }
            #endregion

            #region 回收器械 丢失发生件 数
            sttemp01.Clear();
            sttemp01.Add(1, 16);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox8.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox8.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }
                }
                else
                {
                    textBox8.Text = "0";
                }
            }
            #endregion

            #region 无菌物品 发放错误发 生数
            sttemp01.Clear();
            sttemp01.Add(1, 17);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox9.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox9.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }
                }
                else
                {
                    textBox9.Text = "0";
                }
            }
            #endregion

            #region 灭菌失败 事件发生数
            sttemp01.Clear();
            sttemp01.Add(1, 18);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
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
                        MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox10.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        textBox10.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }
                }
                else
                {
                    textBox10.Text = "0";
                }
            }
            #endregion
        }

        /// <summary>
        /// 月份的平均指标
        /// </summary>
        /// <param name="strnum">指标号</param>
        /// <returns>平均结果</returns>
        private string MonthAverage(string strnum, string year)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;

            string front = year + "/01/01 00:00:00";//年初
            string back = year + "/12/31 23:59:59";//年尾

            #region 求指标的月平均数
            sttemp01.Clear();
            sttemp01.Add(1, strnum);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
            // string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {

                //如果有值，则计算这一年发生的平均数量
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    //如果选择的年份没有过完者计算前几个月的数量
                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                    {
                        DateTime dataNow = DateTime.Now;
                        //获取当月的最后一天
                        int LastDay = dataNow.AddMonths(1).AddDays(-dataNow.AddMonths(1).Day).Day;
                        //如果日已经达到最后一天，则传入当前月份，否则传入当前月份减一
                        if (dataNow.Day == LastDay)
                        {
                            return String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month));//保留小数后两位

                        }
                        else
                        {
                            return String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位

                        }

                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        return String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    return "0";
                }


            }
            return "";
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 消毒不合格率，季度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        textBox12.Text = String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString()) * 100) + "%";//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("这段时间内流程没有对这类包有操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    textBox12.Text = "0%";
                }

            }


            #endregion
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        public decimal aa = 0;
        private void but_get_Click(object sender, EventArgs e)
        {

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = null;
            DataTable getdt02 = null;
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, 6);
            sltmp.Add(2, dtp_start.Value);
            sltmp.Add(3, dtp_end.Value);

            // string ii = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sltmp);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sltmp);
            SortedList slttmp = new SortedList();
            SortedList slttmp01 = new SortedList();


            slttmp.Add(2, dtp_start.Value);
            slttmp.Add(1, dtp_end.Value);

            string WE = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_work_set_unwashing_sec001", slttmp);
            getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS_work_set_unwashing_sec001", slttmp);
            if (getdt != null && getdt02 != null)
            {
                decimal unnum = Convert.ToDecimal(getdt.Rows[0]["SUM(num)"]);
                decimal num = Convert.ToDecimal(getdt02.Rows[0]["count(*)"]);
                aa = (unnum / num);
                tb_fin.Text = aa.ToString("P");
            }
            else
            {

                tb_fin.Text = "0%";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ChartForm1 CF = new ChartForm1();
            //CF.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            //数组存储12到18项指标的结果
           
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //RadForm1 redform = new RadForm1();
            //redform.ShowDialog();
        }

       

      

       private SortedList _indicator = new SortedList();


        private void but_Click_1(object sender, EventArgs e)
        {
            SortedList monthIndicator = new SortedList();
            if (this.cb_year.Text == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_month.Text== null)
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


                        c1RG8.Value = double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["count(*)"].ToString())));//保留小数后两位
                       
                    
                    }
                    else
                    {
                        MessageBox.Show("数据异常，请联系管理员（分母为0）。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    c1RG8.Value = 0;
                }
                
            }
         
            #endregion

            #region 清洗不合格率

            
            DataTable getdt02 = null;
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, 6);
            sltmp.Add(2, front);
            sltmp.Add(3, back);

            // string ii = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sltmp);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sltmp);
            SortedList slttmp = new SortedList();
            SortedList slttmp01 = new SortedList();

            sltmp.Clear();
            slttmp.Add(1, front);
            slttmp.Add(2, back);

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
                        c1RG6.Value = (double)(unnum / num);
                        
                    }
                }
                else
                {

                    c1RG6.Value = 0;
                }
                
            }
      
            #endregion

            #region 次日下发率

            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, cb_month.Text);
            sttemp02.Add(2, cb_year.Text);
            sttemp02.Add(3, cb_month.Text);
            sttemp02.Add(4, cb_year.Text);

          

            //手术器械包次日下送发生率(按月统计)
            DataTable getdt3 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec004", sttemp02);
            //乘以100，表示计算百分比
            c1RG4.Value = Convert.ToDouble(getdt3.Rows[0][0].ToString() == "" ? 0 : getdt3.Rows[0][0]) * 100;

        
            #endregion
          
        }



        private SortedList _indicator02 = new SortedList();

        private void button_Click_1(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.comboBox2.Text == null)
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
                        c1RG7.Value = double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString())));//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("这段时间内流程没有对这类包有操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    c1RG7.Value = 0;
                }
            }
            #endregion
         
        }

        private void but_selectY_Click(object sender, EventArgs e)
        {
            //判断是否输入年份
            if (this.cb_onlyyear.Text == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果没满一年则做提示
            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
            {

                //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            c1RG9.Value = double.Parse(MonthAverage("9", cb_onlyyear.Text));
            c1RG10.Value = double.Parse(MonthAverage("10", cb_onlyyear.Text));
            c1RG11.Value = double.Parse(MonthAverage("11", cb_onlyyear.Text));
            c1RG12.Value = double.Parse(MonthAverage("12", cb_onlyyear.Text));
            c1RG13.Value = double.Parse(MonthAverage("13", cb_onlyyear.Text));
            c1RG14.Value = double.Parse(MonthAverage("14", cb_onlyyear.Text));
            c1RG15.Value = double.Parse(MonthAverage("15", cb_onlyyear.Text));
            c1RG16.Value = double.Parse(MonthAverage("16", cb_onlyyear.Text));
            c1RG17.Value = double.Parse(MonthAverage("17", cb_onlyyear.Text));
            c1RG18.Value = double.Parse(MonthAverage("18", cb_onlyyear.Text));

            
            #region 第1,2,3,5项指标
            DateTime dataNow = DateTime.Now;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            SortedList sttemp01 = new SortedList();
            //如果年份等于当前年份则需要处理
            if (cb_onlyyear.Text == dataNow.Year.ToString())
            {
                //如果年份相等，则判断月份
                if (dataNow.Year.ToString() == cb_onlyyear.Text)
                {
                    //获取当月的最后一天
                    int LastDay = dataNow.AddMonths(1).AddDays(-dataNow.AddMonths(1).Day).Day;
                    //如果日已经达到最后一天，则传入当前月份，否则传入当前月份减一
                    if (dataNow.Day == LastDay)
                    {
                        sttemp01.Add(1, dataNow.Month);
                    }
                    else
                    {
                        sttemp01.Add(1, dataNow.Month - 1);
                    }
                }
            }
            else
            {
                sttemp01.Add(1, 12);
            }
            sttemp01.Add(2, int.Parse(cb_onlyyear.Text));

            //处理器械总件数(除以月数的平均数)
            //string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-report-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec001", sttemp01);
            c1RG1.Value = Convert.ToDouble(getdt.Rows[0][0]);


            //处理敷料的总件数(除以月数的平均数)
            DataTable getdt1 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec002", sttemp01);
            c1RG2.Value = Convert.ToDouble(getdt1.Rows[0][0]);


            //处理外来器械的总件数(除以月数的平均数)
            DataTable getdt2 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec003", sttemp01);
            c1RG3.Value = Convert.ToDouble(getdt2.Rows[0][0]);
            //处理外来器械的总件数(除以月数的平均数)
            DataTable getdt4 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-report-sec001", sttemp01);
            c1RG5.Value = Convert.ToDouble(getdt4.Rows[0][0]);  
            #endregion





        }

        private void but_table_Click(object sender, EventArgs e)
        {
            HCSRS_reportTable RT = new HCSRS_reportTable();
            RT.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void gb_top_Enter(object sender, EventArgs e)
        {

        }

        private void c1Gauge1_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge4_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge3_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cb_month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lb_top_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void but_ok_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tb_wetset_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_fail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void but_get_Click_1(object sender, EventArgs e)
        {

        }

        private void lb_6_Click(object sender, EventArgs e)
        {

        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb_fin_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tb_Indicator_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_lost_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void tb_lost_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_grant_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_front_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_back_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void c1Gauge18_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge13_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge17_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge19_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge10_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge11_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge15_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge14_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge12_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge9_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge5_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge6_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge7_Click(object sender, EventArgs e)
        {

        }

        private void c1Gauge8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void cb_onlyyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void but_HistogramY_Click(object sender, EventArgs e)
        {
            //HistogramForm hcsm = new HistogramForm();
            //hcsm.ShowDialog();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //HistogramForm aa = new HistogramForm();
            //aa.ShowDialog();
        }
    }
}
