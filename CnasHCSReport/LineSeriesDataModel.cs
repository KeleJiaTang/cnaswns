using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
    public class LineSeriesDataModel
    {
        private IEnumerable<LineAreaSeriesData> s1;
        //private IEnumerable<LineAreaSeriesData> s2;
        //private IEnumerable<LineAreaSeriesData> s3;
        //private IEnumerable<LineAreaSeriesData> s4;
        //private IEnumerable<LineAreaSeriesData> s5;
        //private IEnumerable<LineAreaSeriesData> s6;
        //private IEnumerable<LineAreaSeriesData> s7;
        //private IEnumerable<LineAreaSeriesData> s8;
        //private IEnumerable<LineAreaSeriesData> s9;
        //private IEnumerable<LineAreaSeriesData> s10;
        //private IEnumerable<LineAreaSeriesData> s11;
        //private IEnumerable<LineAreaSeriesData> s12;
          CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            double washingValue = 0;
            SortedList sttemp01 = new SortedList();
            DataTable getdt = null;
            //int month = int.Parse(comboBox2.Text.Trim()) * 3 - 2;//当前季度的月份3n-2
            //int days = DateTime.DaysInMonth(int.Parse(comboBox1.Text.Trim()), month + 3);//季度最后月份的天数
            //string front = comboBox1.Text.Trim() + "/" + month + "/01 00:00:00";//季初
            //string back = comboBox1.Text.Trim() + "/" + (month + 2) + "/" + days + " 23:59:59";//季尾
            //string JJJ = "";
            #region 每季消毒物品不合格率
            
        public IEnumerable<LineAreaSeriesData> S1
        {
            get
            {
                if (this.s1 == null)
                {
                   
                    this.s1 = new List<LineAreaSeriesData>() {
                        new LineAreaSeriesData(MonthAverage("1","3"), "第一季"),
                        new LineAreaSeriesData(MonthAverage("4","6"), "第二季"),
                        new LineAreaSeriesData(MonthAverage("7","9"), "第三季"),
                        new LineAreaSeriesData(MonthAverage("10","12"), "第四季"),
                        //new LineAreaSeriesData(150, "Sep"),
                        //new LineAreaSeriesData(200, "Oct"),
                        //new LineAreaSeriesData(160, "Nov"),
                        //new LineAreaSeriesData(150, "Dec"),
                        //new LineAreaSeriesData(100, "Jan")
                    };
                }

                return this.s1;
            }
        }
         private double MonthAverage( string start,string last)
        {
            sttemp01.Clear();
            sttemp01.Add(1, 7);
            sttemp01.Add(2, DateTime.Now.Year + "/" + start + "/01 00:00:00");
            sttemp01.Add(3, DateTime.Now.Year + "/" + last + "/01 00:00:00");
            string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-statistics-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-statistics-sec001", sttemp01);
            DataTable getdtsum = getdt;
            sttemp01.Clear();
            sttemp01.Add(1,DateTime.Now.Year + "/" + start + "/01 00:00:00");
            sttemp01.Add(2, DateTime.Now.Year + "/" + last + "/01 00:00:00");
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
                       return washingValue = double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["Count(DISTINCT(sins.id))"].ToString())));
                       // JJJ = washingValue.ToString("P");//保留小数后两位
                    }
                    //else
                    //{
                    //    MessageBox.Show("这段时间内流程没有对这类包有操作。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    //}
                }
                else
                {
                   return washingValue = 0;
                }
            }
            return 0;
        }
        public IEnumerable<LineAreaSeriesData> GetData(int index)
        {
            if (index == 0)
            {
                return this.S1;
            }
            return null;
        }

        public string GetLegendText(int index)
        {
            switch (index)
            {
                case 0:
                    return "每季消毒物品不合格率";
                
                default:
                    return "Missing product ID";
            }
        }
    }
}
            #endregion