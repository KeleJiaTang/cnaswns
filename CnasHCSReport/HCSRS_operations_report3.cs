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
using Telerik.WinControls.UI;


namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_operations_report3 : UserControl
    {
        public HCSRS_operations_report3()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            //给下拉控件赋值，年份，从2000年开始添加
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cb_year.Items.Add(i);
                cb_onlyyear.Items.Add(i);
                comboBox1.Items.Add(i);
            }
            //季度
            for (int j = 4; j >= 1; j--)
            {
                comboBox2.Items.Add(j);
            }
            //月份
            for (int k = 12; k >= 1; k--)
            {
                cb_month.Items.Add(k);
            }
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
        private void but_Click(object sender, EventArgs e)
        {
            SortedList monthIndicator = new SortedList();
            if (this.cb_year.Text == "")
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_month.Text == "")
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
            //string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.comboBox2.Text == "")
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
            if (this.cb_onlyyear.Text == "")
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果没满一年则做提示
            if (cb_onlyyear.Text == DateTime.Now.Year.ToString())
            {

                MessageBox.Show("注意：因未满一年，只统计现有月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            int yearInt = int.Parse(cb_onlyyear.Text);

            CnasRemotCall CRnorm = new CnasRemotCall();
            SortedList norm = new SortedList();//集合用于1,2,3,5输出与比较
            norm.Clear();
            SortedList norm_1 = new SortedList();//集合用于9到18项输出与比较
            norm_1.Clear();
            SortedList SLnorm = new SortedList();
            SLnorm.Add("norm", "0");
            SLnorm.Add("firstTime", new DateTime(yearInt, 1, 1));
            SLnorm.Add("lastTime", new DateTime(yearInt, 12, 31));
            DataSet DSnorm = new DataSet();
            DSnorm = CRnorm.RemotInterface.ExecuteProcedure("average_index", SLnorm);
            if (DSnorm != null)
            {
                #region 指标项数据
                DateTime dataNow = DateTime.Now;
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
                            norm.Add("每月平均处理器械件数", int.Parse(DSnorm.Tables[0].Rows[0]["count(*)"].ToString()) / dataNow.Month);
                            norm.Add("每月平均处理敷料的件数", int.Parse(DSnorm.Tables[1].Rows[0]["count(*)"].ToString()) / dataNow.Month);
                            norm.Add("每月平均处理外来器械的件数", int.Parse(DSnorm.Tables[2].Rows[0]["count(*)"].ToString()) / dataNow.Month);
                            norm.Add("每月平均使用灭菌器次数", int.Parse(DSnorm.Tables[3].Rows[0]["count(*)"].ToString()) / dataNow.Month);

                            #region 9到18项指标
                            int sum_wetbag = 0;
                            int sum_Sfailure = 0;
                            string str_wetbag = "";
                            string str_Sfailure = "";

                            for (int i = 0; i < DSnorm.Tables[4].Rows.Count; i++)
                            {
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 209)//无菌包内器械功能不全发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械缺失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 210)//每月平均无菌包内器械缺失发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械功能不全发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 103)//每月平均无菌包内器械种类错误发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械种类错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 204)//每月平均无菌包标识不正确发生件数
                                {
                                    norm_1.Add("每月平均无菌包标识不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 205)//每月平均灭菌包灭菌方式选择不正确发生件数
                                {
                                    norm_1.Add("每月平均灭菌包灭菌方式选择不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 206)//每月平均包内化学指标卡不合格件数
                                {
                                    norm_1.Add("每月平均包内化学指标卡不合格件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 102)//每月平均回收器械丢失发生件数
                                {
                                    norm_1.Add("每月平均回收器械丢失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 203)//每月平均无菌物品发放错误发生件数
                                {
                                    norm_1.Add("每月平均无菌物品发放错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / dataNow.Month);
                                    continue;
                                }

                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 207 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 208)//每月平均湿包发生件数,累加
                                {
                                    sum_wetbag += int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString());
                                    str_wetbag = "每月平均湿包发生件数";
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 301 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 302 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 303)//每月平均灭菌失败事件发生数,累加
                                {
                                    sum_Sfailure += int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString());
                                    str_Sfailure = "每月平均灭菌失败事件发生数";
                                    continue;
                                }

                            }
                            if (str_wetbag != "")
                            {
                                norm_1.Add(str_wetbag, sum_wetbag / 12);

                            }
                            if (str_Sfailure != "")
                            {
                                norm_1.Add(str_Sfailure, sum_Sfailure / 12);
                            }


                            #endregion


                        }
                        else
                        {
                            norm.Add("每月平均处理器械件数", int.Parse(DSnorm.Tables[0].Rows[0]["count(*)"].ToString()) / (dataNow.Month - 1));
                            norm.Add("每月平均处理敷料的件数", int.Parse(DSnorm.Tables[1].Rows[0]["count(*)"].ToString()) / (dataNow.Month - 1));
                            norm.Add("每月平均处理外来器械的件数", int.Parse(DSnorm.Tables[2].Rows[0]["count(*)"].ToString()) / (dataNow.Month - 1));
                            norm.Add("每月平均使用灭菌器次数", int.Parse(DSnorm.Tables[3].Rows[0]["count(*)"].ToString()) / (dataNow.Month - 1));

                            #region 9到18项指标
                            int sum_wetbag = 0;
                            int sum_Sfailure = 0;
                            string str_wetbag = "";
                            string str_Sfailure = "";

                            for (int i = 0; i < DSnorm.Tables[4].Rows.Count; i++)
                            {
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 209)//无菌包内器械功能不全发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械缺失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 210)//每月平均无菌包内器械缺失发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械功能不全发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 103)//每月平均无菌包内器械种类错误发生件数
                                {
                                    norm_1.Add("每月平均无菌包内器械种类错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 204)//每月平均无菌包标识不正确发生件数
                                {
                                    norm_1.Add("每月平均无菌包标识不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 205)//每月平均灭菌包灭菌方式选择不正确发生件数
                                {
                                    norm_1.Add("每月平均灭菌包灭菌方式选择不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 206)//每月平均包内化学指标卡不合格件数
                                {
                                    norm_1.Add("每月平均包内化学指标卡不合格件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 102)//每月平均回收器械丢失发生件数
                                {
                                    norm_1.Add("每月平均回收器械丢失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 203)//每月平均无菌物品发放错误发生件数
                                {
                                    norm_1.Add("每月平均无菌物品发放错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString()) / (dataNow.Month - 1));
                                    continue;
                                }

                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 207 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 208)//每月平均湿包发生件数,累加
                                {
                                    sum_wetbag += int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString());
                                    str_wetbag = "每月平均湿包发生件数";
                                    continue;
                                }
                                if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 301 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 302 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 303)//每月平均灭菌失败事件发生数,累加
                                {
                                    sum_Sfailure += int.Parse(DSnorm.Tables[4].Rows[i]["SUM(num)"].ToString());
                                    str_Sfailure = "每月平均灭菌失败事件发生数";
                                    continue;
                                }

                            }
                            if (str_wetbag != "")
                            {
                                norm_1.Add(str_wetbag, sum_wetbag / 12);

                            }
                            if (str_Sfailure != "")
                            {
                                norm_1.Add(str_Sfailure, sum_Sfailure / 12);
                            }



                            #endregion

                        }
                    }
                }
                else
                {
                    norm.Add("每月平均处理器械件数", int.Parse(DSnorm.Tables[0].Rows[0]["count(*)"].ToString()) / 12);
                    norm.Add("每月平均处理敷料的件数", int.Parse(DSnorm.Tables[1].Rows[0]["count(*)"].ToString()) / 12);
                    norm.Add("每月平均处理外来器械的件数", int.Parse(DSnorm.Tables[2].Rows[0]["count(*)"].ToString()) / 12);
                    norm.Add("每月平均使用灭菌器次数", int.Parse(DSnorm.Tables[3].Rows[0]["count(*)"].ToString()) / 12);

                    #region 9到18项指标
                    int sum_wetbag = 0;
                    int sum_Sfailure = 0;
                    string str_wetbag = "";
                    string str_Sfailure = "";

                    for (int i = 0; i < DSnorm.Tables[4].Rows.Count; i++)
                    {
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 209)//无菌包内器械功能不全发生件数
                        {
                            norm_1.Add("每月平均无菌包内器械缺失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 210)//每月平均无菌包内器械缺失发生件数
                        {
                            norm_1.Add("每月平均无菌包内器械功能不全发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 103)//每月平均无菌包内器械种类错误发生件数
                        {
                            norm_1.Add("每月平均无菌包内器械种类错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 204)//每月平均无菌包标识不正确发生件数
                        {
                            norm_1.Add("每月平均无菌包标识不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 205)//每月平均灭菌包灭菌方式选择不正确发生件数
                        {
                            norm_1.Add("每月平均灭菌包灭菌方式选择不正确发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 206)//每月平均包内化学指标卡不合格件数
                        {
                            norm_1.Add("每月平均包内化学指标卡不合格件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 102)//每月平均回收器械丢失发生件数
                        {
                            norm_1.Add("每月平均回收器械丢失发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 203)//每月平均无菌物品发放错误发生件数
                        {
                            norm_1.Add("每月平均无菌物品发放错误发生件数", int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString()) / 12);
                            continue;
                        }

                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 207 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 208)//每月平均湿包发生件数,累加
                        {
                            sum_wetbag += int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString());
                            str_wetbag = "每月平均湿包发生件数";
                            continue;
                        }
                        if (int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 301 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 302 || int.Parse(DSnorm.Tables[4].Rows[i]["type"].ToString()) == 303)//每月平均灭菌失败事件发生数,累加
                        {
                            sum_Sfailure += int.Parse(DSnorm.Tables[4].Rows[i]["count(*)"].ToString());
                            str_Sfailure = "每月平均灭菌失败事件发生数";
                            continue;
                        }

                    }
                    if (str_wetbag != "")
                    {
                        norm_1.Add(str_wetbag, sum_wetbag / 12);

                    }
                    if (str_Sfailure != "")
                    {
                        norm_1.Add(str_Sfailure, sum_Sfailure / 12);
                    }




                    #endregion

                }
                #endregion

            }



            #region 排序1,2,3,5项并显示
            this.radChartView2.Series.Clear();
            DataSet set = new DataSet();
            DataTable windowsXPTable = new DataTable("WindowsXP");
            set.Tables.Add(windowsXPTable);
            foreach (DataTable table in set.Tables)
            {
                table.Columns.Add("Month");
                table.Columns.Add("Usage", typeof(double));
            }

            SortedList sort = new SortedList();
            sort.Clear();
            string strkey = "";
            double value = 0.0;

            while (norm.Count > 0)
            {
                value = double.Parse(norm.GetByIndex(0).ToString());
                strkey = norm.GetKey(0).ToString();
                for (int j = 1; j < norm.Count; j++)
                {

                    if (value < double.Parse(norm.GetByIndex(j).ToString()))
                    {
                        strkey = norm.GetKey(j).ToString();
                        value = double.Parse(norm.GetByIndex(j).ToString());
                    }

                }
                switch (norm.Count)//显示
                {

                    case 4:
                        windowsXPTable.Rows.Add("1", value);//显示的内容   
                        lb_1.Text = "1:" + strkey;
                        break;
                    case 3:
                        windowsXPTable.Rows.Add("2", value);//显示的内容   
                        lb_2.Text = "2:" + strkey;
                        break;
                    case 2:
                        windowsXPTable.Rows.Add("3", value);//显示的内容   
                        lb_3.Text = "3:" + strkey;
                        break;
                    case 1:
                        windowsXPTable.Rows.Add("4", value);//显示的内容   
                        lb_4.Text = "4:" + strkey;
                        break;




                }
                norm.Remove(strkey);
            }
            this.radChartView2.DataSource = set;
            BarSeries windowsXPSeries = new BarSeries("Usage", "Month");
            windowsXPSeries.ShowLabels = true;
            windowsXPSeries.DataMember = "WindowsXP";
            windowsXPSeries.LegendTitle = "Windows XP";
            windowsXPSeries.BackColor = Color.Red;
            this.radChartView2.Series.AddRange(windowsXPSeries);
            #endregion

            #region 排序9到18项并显示
            this.radChartView1.Series.Clear();
            DataSet set1 = new DataSet();
            DataTable windowsXPTable1 = new DataTable("WindowsXP1");
            set1.Tables.Add(windowsXPTable1);
            foreach (DataTable table1 in set1.Tables)
            {
                table1.Columns.Add("Month1");
                table1.Columns.Add("Usage1", typeof(double));
            }

            SortedList sort1 = new SortedList();
            sort1.Clear();
            string strkey1 = "";
            double value1 = 0.0;

            while (norm_1.Count > 0)
            {
                value1 = double.Parse(norm_1.GetByIndex(0).ToString());
                strkey1 = norm_1.GetKey(0).ToString();
                for (int j = 1; j < norm_1.Count; j++)
                {

                    if (value1 < double.Parse(norm_1.GetByIndex(j).ToString()))
                    {
                        strkey1 = norm_1.GetKey(j).ToString();
                        value1 = double.Parse(norm_1.GetByIndex(j).ToString());
                    }

                }
                switch (norm_1.Count)//显示
                {
                    case 10:
                        windowsXPTable1.Rows.Add("A", value1);//显示的内容  
                        lb_A.Text = "A:" + strkey1;
                        break;
                    case 9:
                        windowsXPTable1.Rows.Add("B", value1);//显示的内容   
                        lb_B.Text = "B:" + strkey1;
                        break;
                    case 8:
                        windowsXPTable1.Rows.Add("C", value1);//显示的内容  
                        lb_C.Text = "C:" + strkey1;
                        break;
                    case 7:
                        windowsXPTable1.Rows.Add("D", value1);//显示的内容   
                        lb_D.Text = "D:" + strkey1;
                        break;
                    case 6:
                        windowsXPTable1.Rows.Add("E", value1);//显示的内容   
                        lb_E.Text = "E:" + strkey1;
                        break;
                    case 5:
                        windowsXPTable1.Rows.Add("F", value1);//显示的内容 
                        lb_F.Text = "F:" + strkey1;
                        break;
                    case 4:
                        windowsXPTable1.Rows.Add("G", value1);//显示的内容 
                        lb_G.Text = "G:" + strkey1;
                        break;
                    case 3:
                        windowsXPTable1.Rows.Add("H", value1);//显示的内容   
                        lb_H.Text = "H:" + strkey1;
                        break;
                    case 2:
                        windowsXPTable1.Rows.Add("I", value1);//显示的内容   
                        lb_I.Text = "I:" + strkey1;
                        break;
                    case 1:
                        windowsXPTable1.Rows.Add("J", value1);//显示的内容   
                        lb_J.Text = "J:" + strkey1;
                        break;
                }
                norm_1.Remove(strkey1);
            }
            this.radChartView1.DataSource = set1;
            BarSeries windowsXPSeries1 = new BarSeries("Usage1", "Month1");
            windowsXPSeries1.ShowLabels = true;
            windowsXPSeries1.DataMember = "WindowsXP1";
            windowsXPSeries1.LegendTitle = "Windows XP1";
            windowsXPSeries1.BackColor = Color.Red;
            this.radChartView1.Series.AddRange(windowsXPSeries1);
            #endregion

        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            HCSRS_DisposeInstrument DisIns = new HCSRS_DisposeInstrument();
            DisIns.ShowInTaskbar = false;
            DisIns.ShowDialog();
        }

        private void radMenuItem20_Click_1(object sender, EventArgs e)
        {
            HCSRS_unsterilizer US = new HCSRS_unsterilizer();
            US.ShowInTaskbar = false;
            US.ShowDialog();
        }

        private void radMenuItem19_Click(object sender, EventArgs e)
        {
            HCSRS_washingno TT = new HCSRS_washingno();
            TT.ShowInTaskbar=false;
            TT.ShowDialog();
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("204", "当月无菌包标识不正确发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
        }

        private void radMenuItem13_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("103", "当月无菌包内器械种类错误发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
        }

        private void radMenuItem16_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("102", "当月回收器械丢失发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
            
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            HCSRS_DisposeDressing DisDre = new HCSRS_DisposeDressing();
            DisDre.ShowInTaskbar = false;
            DisDre.ShowDialog();
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            //OutsideInstrument OI = new OutsideInstrument();
            //OI.ShowDialog();
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            HCSRS_sterilizermelt StrMelt = new HCSRS_sterilizermelt();
            StrMelt.ShowInTaskbar = false;
            StrMelt.ShowDialog();
        }

        private void radMenuItem18_Click(object sender, EventArgs e)
        {
            HCSRS_DisinfectFail DF = new HCSRS_DisinfectFail();
            DF.ShowInTaskbar = false;
            DF.ShowDialog();
        }

        private void radMenuItem21_Click(object sender, EventArgs e)
        {
            HCSRS_SecondSend SS = new HCSRS_SecondSend();
            SS.ShowInTaskbar = false;
            SS.ShowDialog();
        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("209", "当月无菌包内器械缺失发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
           
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("203", "每月无菌物品发放错误发生数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
           
        }

        private void radMenuItem12_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("210", "当月无菌包内器械功能不全发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
            
        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("207", "当月湿包发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
           
        }

        private void radMenuItem15_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("206", "当月包内化学指标卡不合格件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
            
        }

        private void radMenuItem17_Click(object sender, EventArgs e)
        {
           
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("301", "当月灭菌失败事件发生数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog();
            
        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            HCSRS_HistogramForm show_HistogramForm = new HCSRS_HistogramForm("205", "当月灭菌包灭菌方式选择不正确发生件数");
            show_HistogramForm.ShowInTaskbar = false;
            show_HistogramForm.ShowDialog(); 
           
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //HistogramForm aa = new HistogramForm();
            //aa.ShowDialog();
        }
    }
}
