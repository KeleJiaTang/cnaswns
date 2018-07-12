using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
    public partial class RadForm1 : Form
    {

        public RadForm1()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
        }



        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadForm1_Load(object sender, EventArgs e)
        {

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            SortedList sttemp01 = new SortedList();


            //设定一个年份
            int yearValue = 2016;

            DateTime dataNow = DateTime.Now;

            //如果年份等于当前年份则需要处理
            if (yearValue == dataNow.Year)
            {
                //如果年份相等，则判断月份
                if (dataNow.Year == yearValue)
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
            sttemp01.Add(2, yearValue);

            //处理器械总件数(除以月数的平均数)
            //string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-report-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec001", sttemp01);
            c1RadialGauge2.Value = Convert.ToDouble(getdt.Rows[0][0]);


            //处理敷料的总件数(除以月数的平均数)
            DataTable getdt1 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec002", sttemp01);
            c1RadialGauge1.Value = Convert.ToDouble(getdt1.Rows[0][0]);


            //处理外来器械的总件数(除以月数的平均数)
            DataTable getdt2 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec003", sttemp01);
            c1RadialGauge3.Value = Convert.ToDouble(getdt2.Rows[0][0]);


            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, sttemp01[1]);
            sttemp02.Add(2, sttemp01[1]);


            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-sterilizer-report-sec001", sttemp01);

            //手术器械包次日下送发生率(按月统计)
            DataTable getdt3 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec004", sttemp02);
            //乘以100，表示计算百分比
            c1RadialGauge4.Value = Convert.ToDouble(getdt3.Rows[0][0].ToString() == "" ? 0 : getdt3.Rows[0][0]) * 100; 
            
            


            //处理外来器械的总件数(除以月数的平均数)
            DataTable getdt4 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-report-sec001", sttemp01);
            c1RadialGauge5.Value = Convert.ToDouble(getdt4.Rows[0][0]); 





        }






    }
}
