using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Telerik.QuickStart;
using System.Drawing.Imaging;

namespace Cnas.wns.CnasHCSReport
{
    public partial class ColumnTable : Form
    {
        double Value = 0;
       
        public ColumnTable()
        {
            InitializeComponent();

            comboBox3.Text = DateTime.Now.Year.ToString();
            cb_month.Text = DateTime.Now.Month.ToString();

          
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                comboBox3.Items.Add(i);
              
            }
           
            for (int k = 12; k >= 1; k--)
            {
                cb_month.Items.Add(k);
            }
            but_ok_Click(null, null);

        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            

            this.radChartView2.ShowLegend = true;
            this.radChartView2.ChartElement.LegendElement.LegendTitle = "Expenses";
            this.radChartView2.ShowTitle = true;
            this.radChartView2.Title = "每季消毒物品不合格率";

            List<ImageFormat> formats = new List<ImageFormat>()
            {
                ImageFormat.Bmp,
                ImageFormat.Gif,
                ImageFormat.Jpeg,
                ImageFormat.Png,
                ImageFormat.Tiff,
            };
            this.LoadData();
        }

        private void LoadData()
        {
            LineSeries lineSeries;
            LineSeriesDataModel model = new LineSeriesDataModel();
            for (int i = 0; i < 1; i++)
            {
                lineSeries = new LineSeries();
                lineSeries.CategoryMember = "Month";
                lineSeries.ValueMember = "Expense";
                lineSeries.LegendTitle = model.GetLegendText(i);
                lineSeries.DataSource = model.GetData(i);
                lineSeries.PointSize = new SizeF(3f, 3f);
                this.radChartView2.Series.Add(lineSeries);
            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            // dgv_month.Rows.Clear();
            SortedList monthIndicator = new SortedList();
            if (this.comboBox3.Text == null)
            {
                MessageBox.Show("请选择年份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_month.Text == null)
            {
                MessageBox.Show("请选择月份。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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


                        Value = double.Parse(String.Format("{0:F}", double.Parse(getdtsum.Rows[0]["SUM(num)"].ToString()) / double.Parse(getdt.Rows[0]["count(*)"].ToString())));//保留小数后两位


                    }
                    else
                    {
                        MessageBox.Show("数据异常，请联系管理员（分母为0）。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    Value = 0;
                }
            #endregion
                #region 清洗不合格率

                double Value01 = 0;
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
                            Value01 =double.Parse (String.Format("{0:F}",(unnum / num) * 100));

                        }
                    }
                    else
                    {

                        Value01 = 0;
                    }

                #endregion
                    #region 手术器械包次日下送发生率
                    double Value02 = 0;
                    SortedList sttemp02 = new SortedList();
                    SortedList sttemp03 = new SortedList();
                    sttemp02.Add(1, cb_month.Text);
                    sttemp02.Add(2, comboBox3.Text);
                    sttemp02.Add(3, cb_month.Text);
                    sttemp02.Add(4, comboBox3.Text);



                    //手术器械包次日下送发生率(按月统计)
                    DataTable getdt3 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-report-sec004", sttemp02);
                    //乘以100，表示计算百分比
                    Value02 = Convert.ToDouble(getdt3.Rows[0][0].ToString() == "" ? 0 : getdt3.Rows[0][0]) * 100;
                    #endregion

                    DataSet set = new DataSet();
                    DataTable windowsXPTable = new DataTable("WindowsXP");
                    set.Tables.Clear();
                    windowsXPTable.Rows.Clear();
                    radChartView1.Series.Clear();
                    set.Tables.Add(windowsXPTable);
                    foreach (DataTable table in set.Tables)
                    {
                        table.Columns.Add("Month");
                        table.Columns.Add("Usage", typeof(double));
                    }
                    windowsXPTable.Rows.Add("清洗不及格率", Value01);
                    windowsXPTable.Rows.Add("灭菌密封不及格率", Value);
                    windowsXPTable.Rows.Add("手术器械包次日下送发生率", Value02);

                    this.radChartView1.DataSource = set;
                    BarSeries windowsXPSeries = new BarSeries("Usage", "Month");
                    windowsXPSeries.DataMember = "WindowsXP";
                    windowsXPSeries.LegendTitle = "Windows XP";
                    windowsXPSeries.ShowLabels = true;
                    this.radChartView1.Series.AddRange(windowsXPSeries);

                }

            }
        }

    }
}




