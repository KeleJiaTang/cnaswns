using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_reportTable : Form
    {
        public HCSRS_reportTable()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            comboBox3.Text = DateTime.Now.Year.ToString();
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
                comboBox3.Items.Add(i);
                cb_onlyyear.Items.Add(i);
                comboBox1.Items.Add(i);
            }
            for (int j = 4; j >= 1;j-- )
            {
                comboBox2.Items.Add(j);
            }
            for (int k = 12; k >= 1;k--)
            {
                cb_month.Items.Add(k);
            }

                button1_Click(null, null);
            button2_Click(null, null);
            but_ok_Click(null, null);
        }

        private SortedList _indicatorList = new SortedList();

        public HCSRS_reportTable(SortedList indicatorList)
            : this()
        {
            _indicatorList = indicatorList;


        }




        private void but_ok_Click(object sender, EventArgs e)
        {
            dgv_month.Rows.Clear();
            SortedList monthIndicator = new SortedList();
            if (this.comboBox3.Text== null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_month.Text == null)
            {
                MessageBox.Show("请选择月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Value = null;
            SortedList indicator1 = new SortedList();
            SortedList indicator2 = new SortedList();
            SortedList indicator3 = new SortedList();
            monthIndicator.Add(0, indicator1);
            monthIndicator.Add(1, indicator2);
            monthIndicator.Add(2, indicator3);
            int days = DateTime.DaysInMonth(int.Parse(comboBox3.Text.Trim()), int.Parse(cb_month.Text.Trim()));//月份的天数
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            string front = comboBox3.Text.Trim() + "/" + cb_month.Text.Trim() + "/01 00:00:00";//月初
            string back = comboBox3.Text.Trim() + "/" + cb_month.Text.Trim() + "/" + days + " 23:59:59";//月尾
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


                        Value = (double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["count(*)"].ToString())))).ToString("P");//保留小数后两位


                    }
                    else
                    {
                        MessageBox.Show("数据异常，请联系管理员（分母为0）。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    Value = "0%";
                }

            }
            indicator1.Add("rate", Value);
            indicator1.Add("name", "每月灭菌包装不合格率");
            indicator1.Add("num", double.Parse(getdt.Rows[0]["count(*)"].ToString()));
            #endregion

            #region 清洗不合格率

            string Value01 = null;
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
                        double unnum = Convert.ToDouble(getdt.Rows[0]["SUM(num)"]);
                        double num = Convert.ToDouble(getdt02.Rows[0]["count(*)"]);
                        Value01 = String.Format("{0:F}", (unnum / num) * 100)+"%";

                    }
                }
                else
                {

                    Value01 = "0%";
                }

            }
            indicator2.Add("rate", Value01);
            indicator2.Add("name", "清洗不及格率");
            indicator2.Add("num", Convert.ToDecimal(getdt02.Rows[0]["count(*)"]));

            #endregion

            #region 次日下发率
            double Value02 = 0;
            SortedList sttemp02 = new SortedList();
            SortedList sttemp03 = new SortedList();
            sttemp02.Add(1, cb_month.Text);
            sttemp02.Add(2, cb_year.Text);
            sttemp02.Add(3, cb_month.Text);
            sttemp02.Add(4, cb_year.Text);



            //手术器械包次日下送发生率(按月统计)
            DataTable getdt3 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec004", sttemp02);
            //乘以100，表示计算百分比
            Value02 = Convert.ToDouble(getdt3.Rows[0][0].ToString() == "" ? 0 : getdt3.Rows[0][0]) * 100;
            sttemp03.Add(1, cb_month.Text);
            sttemp03.Add(2, cb_year.Text);
            DataTable getdt4 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec005", sttemp03);
            double  num001=Convert.ToDouble(getdt4.Rows[0][0]);

            indicator3.Add("rate", Value02);
            indicator3.Add("name", "次日下发率");
            indicator3.Add("num", num001);
            //indicator3.Add("num",getdt3.Rows[0][0]*)
            if (_indicatorList.ContainsKey("MonthIndicator"))
                _indicatorList["MonthIndicator"] = monthIndicator;
            else
                _indicatorList.Add("MonthIndicator", monthIndicator);

            #endregion
            if (_indicatorList.ContainsKey("MonthIndicator"))
            {
                SortedList mnthIndicator = _indicatorList["MonthIndicator"] as SortedList;
                for (int i = 0; i < mnthIndicator.Count; i++)
                {
                    SortedList indicator = mnthIndicator[i] as SortedList;
                    if (indicator != null)
                    {

                        int rowIndex = dgv_month.Rows.Add();
                        if (indicator.ContainsKey("name")) dgv_month.Rows[rowIndex].Cells["name01"].Value = indicator["name"];
                        if (indicator.ContainsKey("rate")) dgv_month.Rows[rowIndex].Cells["ratio01"].Value = indicator["rate"];
                        if (indicator.ContainsKey("num")) dgv_month.Rows[rowIndex].Cells["num01"].Value = indicator["num"];

                    }

                }
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_quarter.Rows.Clear();
            SortedList monthIndicator = new SortedList();
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
            SortedList indicator1 = new SortedList();

            monthIndicator.Add(0, indicator1);

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            double washingValue = 0;
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            int month = int.Parse(comboBox2.Text.Trim()) * 3 - 2;//当前季度的月份3n-2
            int days = DateTime.DaysInMonth(int.Parse(comboBox1.Text.Trim()), month + 3);//季度最后月份的天数
            string front = comboBox1.Text.Trim() + "/" + month + "/01 00:00:00";//季初
            string back = comboBox1.Text.Trim() + "/" + (month + 3) + "/" + days + " 23:59:59";//季尾
            string JJJ = "";
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
                        washingValue = double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString())));
                       JJJ = washingValue.ToString("P");//保留小数后两位
                    }
                    else
                    {
                        MessageBox.Show("这段时间内流程没有对这类包有操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    washingValue = 0;
                }
            }
            indicator1.Add("rate", JJJ);
            indicator1.Add("name", "每季消毒物品不合格率");
            indicator1.Add("num", double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString()));
            if (_indicatorList.ContainsKey("MonthIndicator"))
                _indicatorList["MonthIndicator"] = monthIndicator;
            else
                _indicatorList.Add("MonthIndicator", monthIndicator);

            #endregion
            if (_indicatorList.ContainsKey("MonthIndicator"))
            {
                SortedList mnthIndicator = _indicatorList["MonthIndicator"] as SortedList;
                for (int i = 0; i < mnthIndicator.Count; i++)
                {
                    SortedList indicator = mnthIndicator[i] as SortedList;
                    if (indicator != null)
                    {

                        int rowIndex = dgv_quarter.Rows.Add();
                        if (indicator.ContainsKey("name")) dgv_quarter.Rows[rowIndex].Cells["name02"].Value = indicator["name"];
                        if (indicator.ContainsKey("rate")) dgv_quarter.Rows[rowIndex].Cells["ratio02"].Value = indicator["rate"];
                        if (indicator.ContainsKey("num")) dgv_quarter.Rows[rowIndex].Cells["num02"].Value = indicator["num"];

                    }

                }
            }

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_year.Rows.Clear();
            if (this.cb_onlyyear.Text == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList monthIndicator = new SortedList();
            SortedList indicator1 = new SortedList();
            SortedList indicator2 = new SortedList();
            SortedList indicator3 = new SortedList();
            SortedList indicator4 = new SortedList();
            SortedList indicator5 = new SortedList();
            SortedList indicator6 = new SortedList();
            SortedList indicator7 = new SortedList();
            SortedList indicator8 = new SortedList();
            SortedList indicator9 = new SortedList();
            SortedList indicator10 = new SortedList();
            SortedList indicator11 = new SortedList();
            SortedList indicator12 = new SortedList();
            SortedList indicator13 = new SortedList();
            SortedList indicator14 = new SortedList();
            monthIndicator.Add(0, indicator1);
            monthIndicator.Add(1, indicator2);
            monthIndicator.Add(2, indicator3);
            monthIndicator.Add(3, indicator4);
            monthIndicator.Add(4, indicator5);
            monthIndicator.Add(5, indicator6);
            monthIndicator.Add(6, indicator7);
            monthIndicator.Add(7, indicator8);
            monthIndicator.Add(8, indicator9);
            monthIndicator.Add(9, indicator10);
            monthIndicator.Add(10, indicator11);
            monthIndicator.Add(11, indicator12);
            monthIndicator.Add(12, indicator13);
            monthIndicator.Add(13, indicator14);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            string Text = null;
            string Text01 = null;
            string index = null;
            string num = null;
            SortedList sttemp01 = new SortedList();
            SortedList sttemp02 = new SortedList();
            DataTable getdt = null;
            string front = cb_onlyyear.Text.Trim() + "/01/01 00:00:00";//年初
            string back = cb_onlyyear.Text.Trim() + "/12/31 23:59:59";//年尾
            string front_1 = (int.Parse(cb_onlyyear.Text.Trim()) - 1) + "/01/01 00:00:00";//年初
            string back_1 = (int.Parse(cb_onlyyear.Text.Trim()) - 1) + "/12/31 23:59:59";//年尾
            #region 无菌包内器 械缺失发生 件数
            sttemp01.Clear();
            sttemp01.Add(1, 9);
            sttemp01.Add(2, front);
            sttemp01.Add(3, back);
            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            if (getdt != null)
            {
                num = getdt.Rows[0]["SUM(num)"].ToString();
                //如果有值，则计算这一年发生的平均数量
                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                {
                    //如果选择的年份没有过完者计算前几个月的数量
                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                    {
                       // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                    }
                    else
                    {
                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                    }

                }
                else
                {
                    Text = "0";
                }
                sttemp02.Add(1, 9);
                sttemp02.Add(2, front_1);
                sttemp02.Add(3, back_1);
                text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                if (getdt != null)
                {
                    if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                    {
                        //如果选择的年份没有过完者计算前几个月的数量
                        if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                        {
                            //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                        }
                        else
                        {
                            // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                            Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                        }

                    }
                    else
                    {
                        Text01 = "0";
                    }
                }
                index = CompareValue(Text, Text01);

            #endregion
                indicator1.Add("rate", Text);
                indicator1.Add("name", "无菌包内器械缺失发生件数");
                indicator1.Add("num", num);
                indicator1.Add("rate01", Text01);
                indicator1.Add("index", index);
                #region 无菌包内器 械功能不全 总件数
                sttemp01.Clear();
                sttemp01.Add(1, 10);
                sttemp01.Add(2, front);
                sttemp01.Add(3, back);
                text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                if (getdt != null)
                {
                    num = getdt.Rows[0]["SUM(num)"].ToString();
                    //如果有值，则计算这一年发生的平均数量
                    if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                    {
                        //如果选择的年份没有过完者计算前几个月的数量
                        if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                        {
                            //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                        }
                        else
                        {
                            // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                            Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                        }
                    }
                    else
                    {
                        Text = "0";
                    }
                    sttemp02.Clear();
                    sttemp02.Add(1, 10);
                    sttemp02.Add(2, front_1);
                    sttemp02.Add(3, back_1);
                    text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp02);
                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                    if (getdt != null)
                    {
                        //如果有值，则计算这一年发生的平均数量
                        if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                        {
                            //如果选择的年份没有过完者计算前几个月的数量
                            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                            {
                                //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                            }
                            else
                            {
                                // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                            }
                        }
                        else
                        {
                            Text01 = "0";
                        }
                    }
                    index = CompareValue(Text, Text01);
                #endregion
                    indicator2.Add("rate", Text);
                    indicator2.Add("name", "无菌包内器械功能不全总件数");
                    indicator2.Add("num", num);
                    indicator2.Add("rate01", Text01);
                    indicator2.Add("index", index);
                    #region 无菌包内 器械种类错 误发生件数
                    sttemp01.Clear();
                    sttemp01.Add(1, 11);
                    sttemp01.Add(2, front);
                    sttemp01.Add(3, back);
                    text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                    if (getdt != null)
                    {
                        num = getdt.Rows[0]["SUM(num)"].ToString();
                        //如果有值，则计算这一年发生的平均数量
                        if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                        {
                            //如果选择的年份没有过完者计算前几个月的数量
                            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                            {
                                //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                            }
                            else
                            {
                                // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                            }
                        }
                        else
                        {
                            Text = "0";
                        }
                        sttemp02.Clear();
                        sttemp02.Add(1, 11);
                        sttemp02.Add(2, front_1);
                        sttemp02.Add(3, back_1);
                        text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                        if (getdt != null)
                        {

                            //如果有值，则计算这一年发生的平均数量
                            if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                            {
                                //如果选择的年份没有过完者计算前几个月的数量
                                if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                {
                                    //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                }
                                else
                                {
                                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                }
                            }
                            else
                            {
                                Text01 = "0";
                            }
                        }
                        index = CompareValue(Text, Text01);
                    #endregion
                        indicator3.Add("rate", Text);
                        indicator3.Add("name", "无菌包内器械种类错误发生件数");
                        indicator3.Add("num", num);
                        indicator3.Add("rate01", Text01);
                        indicator3.Add("index", index);
                        #region 无菌包标 识不正确发 生件数
                        sttemp01.Clear();
                        sttemp01.Add(1, 12);
                        sttemp01.Add(2, front);
                        sttemp01.Add(3, back);
                        text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                        if (getdt != null)
                        {
                            num = getdt.Rows[0]["SUM(num)"].ToString();
                            //如果有值，则计算这一年发生的平均数量
                            if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                            {
                                //如果选择的年份没有过完者计算前几个月的数量
                                if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                {
                                    //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                }
                                else
                                {
                                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                    Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                }
                            }
                            else
                            {
                                Text = "0";
                            }
                            sttemp02.Clear();
                            sttemp02.Add(1, 12);
                            sttemp02.Add(2, front_1);
                            sttemp02.Add(3, back_1);
                            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                            if (getdt != null)
                            {
                                //如果有值，则计算这一年发生的平均数量
                                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                {
                                    //如果选择的年份没有过完者计算前几个月的数量
                                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                    {
                                        //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                    }
                                    else
                                    {
                                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                    }
                                }
                                else
                                {
                                    Text01 = "0";
                                }
                            }
                            index = CompareValue(Text, Text01);
                        #endregion
                            indicator4.Add("rate", Text);
                            indicator4.Add("name", "无菌包标识不正确发生件数");
                            indicator4.Add("num", num);
                            indicator4.Add("rate01", Text01);
                            indicator4.Add("index", index);
                            #region 湿包发生 数
                            sttemp01.Clear();
                            sttemp01.Add(1, 14);
                            sttemp01.Add(2, front);
                            sttemp01.Add(3, back);
                            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                            num = getdt.Rows[0]["SUM(num)"].ToString();
                            if (getdt != null)
                            {

                                //如果有值，则计算这一年发生的平均数量
                                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                {
                                    //如果选择的年份没有过完者计算前几个月的数量
                                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                    {
                                        //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                    }
                                    else
                                    {
                                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                    }
                                }
                                else
                                {
                                    Text = "0";
                                }
                                sttemp02.Clear();
                                sttemp02.Add(1, 14);
                                sttemp02.Add(2, front_1);
                                sttemp02.Add(3, back_1);
                                text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                if (getdt != null)
                                {
                                    //如果有值，则计算这一年发生的平均数量
                                    if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                    {
                                        //如果选择的年份没有过完者计算前几个月的数量
                                        if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                        {
                                            //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                        }
                                        else
                                        {
                                            // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                            Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                        }
                                    }
                                    else
                                    {
                                        Text01 = "0";
                                    }
                                }
                              index = CompareValue(Text, Text01);
                                
                            #endregion
                                indicator5.Add("rate", Text);
                                indicator5.Add("name", "湿包发生数");
                                indicator5.Add("num", num);
                                indicator5.Add("rate01", Text01);
                                indicator5.Add("index", index);
                                #region 包内化学 指标卡不合 格报告数
                                sttemp01.Clear();
                                sttemp01.Add(1, 15);
                                sttemp01.Add(2, front);
                                sttemp01.Add(3, back);
                                text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                                num = getdt.Rows[0]["SUM(num)"].ToString();
                                if (getdt != null)
                                {

                                    //如果有值，则计算这一年发生的平均数量
                                    if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                    {
                                        //如果选择的年份没有过完者计算前几个月的数量
                                        if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                        {
                                            //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                        }
                                        else
                                        {
                                            // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                            Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                        }
                                    }
                                    else
                                    {
                                        Text = "0";
                                    }
                                    sttemp02.Clear();
                                    sttemp02.Add(1, 15);
                                    sttemp02.Add(2, front_1);
                                    sttemp02.Add(3, back_1);
                                    text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                    if (getdt != null)
                                    {

                                        //如果有值，则计算这一年发生的平均数量
                                        if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                        {
                                            //如果选择的年份没有过完者计算前几个月的数量
                                            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                            {
                                                //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                            }
                                            else
                                            {
                                                // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                            }
                                        }
                                        else
                                        {
                                            Text01 = "0";
                                        }
                                    }
                                    index = CompareValue(Text, Text01);
                                #endregion
                                    indicator6.Add("rate", Text);
                                    indicator6.Add("name", "包内化学指标卡不合格报告数");
                                    indicator6.Add("num", num);
                                    indicator6.Add("rate01", Text01);
                                    indicator6.Add("index", index);


                                    #region 回收器械 丢失发生件 数
                                    sttemp01.Clear();
                                    sttemp01.Add(1, 16);
                                    sttemp01.Add(2, front);
                                    sttemp01.Add(3, back);
                                    text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                                    num = getdt.Rows[0]["SUM(num)"].ToString();
                                    if (getdt != null)
                                    {

                                        //如果有值，则计算这一年发生的平均数量
                                        if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                        {
                                            //如果选择的年份没有过完者计算前几个月的数量
                                            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                            {
                                                //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                            }
                                            else
                                            {
                                                // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                            }
                                        }
                                        else
                                        {
                                            Text = "0";
                                        }
                                        sttemp02.Clear();
                                        sttemp02.Add(1, 16);
                                        sttemp02.Add(2, front_1);
                                        sttemp02.Add(3, back_1);
                                        text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                        if (getdt != null)
                                        {

                                            //如果有值，则计算这一年发生的平均数量
                                            if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                            {
                                                //如果选择的年份没有过完者计算前几个月的数量
                                                if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                                {
                                                    //MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                }
                                                else
                                                {
                                                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                }
                                            }
                                            else
                                            {
                                                Text01 = "0";
                                            }
                                        }
                                        index = CompareValue(Text, Text01);
                                    #endregion
                                        indicator7.Add("rate", Text);
                                        indicator7.Add("name", "回收器械丢失发生件数");
                                        indicator7.Add("num", num);
                                        indicator7.Add("rate01", Text01);
                                        indicator7.Add("index", index);
                                    }


                                    #region 无菌物品 发放错误发 生数
                                    sttemp01.Clear();
                                    sttemp01.Add(1, 17);
                                    sttemp01.Add(2, front);
                                    sttemp01.Add(3, back);
                                    text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                                    num = getdt.Rows[0]["SUM(num)"].ToString();
                                    if (getdt != null)
                                    {

                                        //如果有值，则计算这一年发生的平均数量
                                        if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                        {
                                            //如果选择的年份没有过完者计算前几个月的数量
                                            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                            {
                                                // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                            }
                                            else
                                            {
                                                // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                            }
                                        }
                                        else
                                        {
                                            Text = "0";
                                        }
                                        sttemp02.Clear();
                                        sttemp02.Add(1, 17);
                                        sttemp02.Add(2, front_1);
                                        sttemp02.Add(3, back_1);
                                        text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                        if (getdt != null)
                                        {

                                            //如果有值，则计算这一年发生的平均数量
                                            if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                            {
                                                //如果选择的年份没有过完者计算前几个月的数量
                                                if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                                {
                                                    // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                }
                                                else
                                                {
                                                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                    Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                }
                                            }
                                            else
                                            {
                                                Text01 = "0";
                                            }
                                        }
                                        index = CompareValue(Text, Text01);
                                    #endregion
                                        indicator8.Add("rate", Text);
                                        indicator8.Add("name", "无菌物品发放错误发生数");
                                        indicator8.Add("num", num);
                                        indicator8.Add("rate01", Text01);
                                        indicator8.Add("index", index);

                                        #region 灭菌失败 事件发生数
                                        sttemp01.Clear();
                                        sttemp01.Add(1, 18);
                                        sttemp01.Add(2, front);
                                        sttemp01.Add(3, back);
                                        text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
                                        num = getdt.Rows[0]["SUM(num)"].ToString();
                                        if (getdt != null)
                                        {

                                            //如果有值，则计算这一年发生的平均数量
                                            if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                            {
                                                //如果选择的年份没有过完者计算前几个月的数量
                                                if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                                {
                                                    // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                }
                                                else
                                                {
                                                    // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                    Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                }
                                            }
                                            else
                                            {
                                                Text = "0";
                                            }
                                            sttemp02.Clear();
                                            sttemp02.Add(1, 18);
                                            sttemp02.Add(2, front_1);
                                            sttemp02.Add(3, back_1);
                                            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                            if (getdt != null)
                                            {

                                                //如果有值，则计算这一年发生的平均数量
                                                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                                {
                                                    //如果选择的年份没有过完者计算前几个月的数量
                                                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                                    {
                                                        // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                    }
                                                    else
                                                    {
                                                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                    }
                                                }
                                                else
                                                {
                                                    Text01 = "0";
                                                }
                                            }
                                            index = CompareValue(Text, Text01);
                                        #endregion
                                            indicator9.Add("rate", Text);
                                            indicator9.Add("name", "灭菌失败事件发生数");
                                            indicator9.Add("num", num);
                                            indicator9.Add("rate01", Text01);
                                            indicator9.Add("index", index);
                                            #region 无菌包方式不正确发 生件数
                                            sttemp01.Clear();
                                            sttemp01.Add(1, 13);
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
                                                       // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                    }
                                                    else
                                                    {
                                                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                        Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                    }

                                                }
                                                else
                                                {
                                                    
                                                    Text = "0";
                                                }
                                                  sttemp02.Clear();
                                            sttemp02.Add(1, 13);
                                            sttemp02.Add(2, front_1);
                                            sttemp02.Add(3, back_1);
                                            text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
                                            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp02);
                                            if (getdt != null)
                                            {

                                                //如果有值，则计算这一年发生的平均数量
                                                if (getdt.Rows[0]["SUM(num)"].ToString() != "")
                                                {
                                                    //如果选择的年份没有过完者计算前几个月的数量
                                                    if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
                                                    {
                                                        // MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / (DateTime.Now.Month - 1));//保留小数后两位
                                                    }
                                                    else
                                                    {
                                                        // tb_wetset.Text = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / days);
                                                        Text01 = String.Format("{0:F}", double.Parse(getdt.Rows[0]["SUM(num)"].ToString()) / 12);//保留小数后两位
                                                    }
                                                }
                                                else
                                                {
                                                    Text01 = "0";
                                                }
                                            }
                                            index = CompareValue(Text, Text01);
                                        #endregion
                                            indicator14.Add("rate", Text);
                                            indicator14.Add("name", "无菌包方式不正确发 生件数");
                                            indicator14.Add("num", num);
                                            indicator14.Add("rate01", Text01);
                                            indicator14.Add("index", index);
                                            }
                                           



                                            DateTime dataNow = DateTime.Now;
                                            int month=0;
                                            sttemp01.Clear();
                                            sttemp02.Clear();
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
                                                        month=dataNow.Month;
                                                        sttemp02.Add(1,dataNow.Month);
                                                    }
                                                    else
                                                    {
                                                        sttemp01.Add(1, dataNow.Month-1);
                                                        month=dataNow.Month-1;
                                                        sttemp02.Add(1,dataNow.Month-1);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                sttemp01.Add(1, 12);
                                                month=12;
                                                sttemp02.Add(1, 12);
                                            }
                                            sttemp01.Add(2, int.Parse(cb_onlyyear.Text));
                                            sttemp02.Add(2,int.Parse(cb_onlyyear.Text)-1);
                                            #region  处理器械总件数(除以月数的平均数)
                                            string fv = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-report-sec001", sttemp01);
                                           DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec001", sttemp01);
                                           DataTable getdt01_1 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec001", sttemp02);
                                           Text = Convert.ToDouble(getdt01.Rows[0][0]).ToString();
                                           Text01 = Convert.ToDouble(getdt01_1.Rows[0][0]).ToString();
                                            num =(Convert.ToDouble(getdt01.Rows[0][0]) * month).ToString();
                                            if (double.Parse(Text) > double.Parse(Text01))
                                            {
                                                index = "上升";
                                            }
                                            else if (double.Parse(Text) == double.Parse(Text01))
                                            {
                                                index = "不变";
                                            }
                                            else
                                            {
                                                index = "下降";
                                            }
                                            #endregion
                                            indicator10.Add("rate", Text);
                                            indicator10.Add("name", "平均每月处理器械总件数");
                                            indicator10.Add("num", num);
                                            indicator10.Add("rate01", Text01);
                                            indicator10.Add("index", index);



                                            #region  处理敷料的总件数(除以月数的平均数)
                                            string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-report-sec002", sttemp01);
                                            DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec002", sttemp01);
                                            DataTable getdt02_1 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec002", sttemp02);
                                            Text = Convert.ToDouble(getdt02.Rows[0][0]).ToString();
                                            Text01 = Convert.ToDouble(getdt02_1.Rows[0][0]).ToString();
                                            num = (Convert.ToDouble(getdt02.Rows[0][0]) * month).ToString();
                                            if (double.Parse(Text) > double.Parse(Text01))
                                            {
                                                index = "上升";
                                            }
                                            else if (double.Parse(Text) == double.Parse(Text01))
                                            {
                                                index = "不变";
                                            }
                                            else
                                            {
                                                index = "下降";
                                            }
                                            #endregion 
                                            indicator13.Add("rate", Text);
                                            indicator13.Add("name", "平均每月处理敷料总件数");
                                            indicator13.Add("num", num);
                                            indicator13.Add("rate01", Text01);
                                            indicator13.Add("index", index);

                                            #region  处理外来器械的总件数(除以月数的平均数)
                                            DataTable getdt03 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec003", sttemp01);
                                            DataTable getdt03_1 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec003", sttemp02);
                                            Text = Convert.ToDouble(getdt03.Rows[0][0]).ToString();
                                            Text01 = Convert.ToDouble(getdt03_1.Rows[0][0]).ToString();
                                            num = (Convert.ToDouble(getdt03.Rows[0][0]) * month).ToString();
                                            if (double.Parse(Text) > double.Parse(Text01))
                                            {
                                                index = "上升";
                                            }
                                            else if (double.Parse(Text) == double.Parse(Text01))
                                            {
                                                index = "不变";
                                            }
                                            else
                                            {
                                                index = "下降";
                                            }
                                            #endregion
                                            indicator11.Add("rate", Text);
                                            indicator11.Add("name", "平均每月处理外来器械总件数");
                                            indicator11.Add("num", num);
                                            indicator11.Add("rate01", Text01);
                                            indicator11.Add("index", index);
                                            //c1RG3.Value = Convert.ToDouble(getdt2.Rows[0][0]);
                                            #region 平均每月灭菌炉次
                                            DataTable getdt04 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-report-sec001", sttemp01);
                                            DataTable getdt04_1 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-report-sec001", sttemp02);
                                            Text = Convert.ToDouble(getdt04.Rows[0][0]).ToString();
                                            Text01 = Convert.ToDouble(getdt04_1.Rows[0][0]).ToString();
                                            num = (Convert.ToDouble(getdt04.Rows[0][0]) * month).ToString();
                                            index = CompareValue(Text, Text01);
                                            #endregion
                                            indicator12.Add("rate", Text);
                                            indicator12.Add("name", "平均每月灭菌炉次");
                                            indicator12.Add("num", num);
                                            indicator12.Add("rate01", Text01);
                                            indicator12.Add("index", index);
                                            //c1RG5.Value = Convert.ToDouble(getdt4.Rows[0][0]); 


                                            if (_indicatorList.ContainsKey("MonthIndicator"))
                                                _indicatorList["MonthIndicator"] = monthIndicator;
                                            else
                                                _indicatorList.Add("MonthIndicator", monthIndicator);

                                            if (_indicatorList.ContainsKey("MonthIndicator"))
                                            {
                                                SortedList mnthIndicator = _indicatorList["MonthIndicator"] as SortedList;
                                                for (int i = 0; i < mnthIndicator.Count; i++)
                                                {
                                                    SortedList indicator = mnthIndicator[i] as SortedList;
                                                    if (indicator != null)
                                                    {

                                                        int rowIndex = dgv_year.Rows.Add();
                                                        if (indicator.ContainsKey("name")) dgv_year.Rows[rowIndex].Cells["name03"].Value = indicator["name"];
                                                        if (indicator.ContainsKey("rate")) dgv_year.Rows[rowIndex].Cells["monthnum03"].Value = indicator["rate"];
                                                        if (indicator.ContainsKey("num")) dgv_year.Rows[rowIndex].Cells["num03"].Value = indicator["num"];
                                                        if (indicator.ContainsKey("rate01")) dgv_year.Rows[rowIndex].Cells["year03"].Value = indicator["rate01"];
                                                        if (indicator.ContainsKey("index")) dgv_year.Rows[rowIndex].Cells["index03"].Value = indicator["index"];


                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string CompareValue(string currentYear, string lastYear)
        {
            string index = "下降";
            if (double.Parse(currentYear) > double.Parse(lastYear))
            {
                index = "上升";
            }
            else if (double.Parse(currentYear) == double.Parse(lastYear))
            {
                index = "不变";
            }
            return index;
        }
      
    }
}



    

