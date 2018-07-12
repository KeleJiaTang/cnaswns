using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class norm : TemplateForm
    {
        string N_type = "";

        public norm(string norm_type, string norm_name)
        {
            InitializeComponent();
            N_type = norm_type;
            this.Text = norm_name.Substring(2);
            lb_name.Text = norm_name;
            cb_year.Text = DateTime.Now.Year.ToString();

            for (int i = 2000; i < DateTime.Now.Year + 1; i++)
            {
                cb_year.Items.Add(i);
            }
            //Initialize("303","2016");
            button1_Click_1(null, null);
        }

        public void Initialize(string type, string strtime)
        {
            //Todo 根据类型去找storeproce
            int time = int.Parse(strtime);
            CnasRemotCall norm = new CnasRemotCall();
            SortedList SLnorm = new SortedList();
            SLnorm.Add("time", new DateTime(time - 2, 1, 1));
            SLnorm.Add("norm", type);
            DataSet DSnorm = new DataSet();

            DSnorm = norm.RemotInterface.ExecuteProcedure("total_average", SLnorm);
            if (DSnorm != null)
            {

            }
        }
        private string GetMonthLbl(string month)
        {
            string monthDescription = "一月";
            switch (month)
            {
                case "1":
                case "01":
                    monthDescription = "一月";
                    break;
                case "2":
                case "02":
                    monthDescription = "二月";
                    break;
                case "3":
                    monthDescription = "三月";
                    break;
                case "4":
                    monthDescription = "四月";
                    break;
                case "5":
                    monthDescription = "五月";
                    break;
                case "6":
                    monthDescription = "六月";
                    break;
                case "7":
                    monthDescription = "七月";
                    break;
                case "8":
                    monthDescription = "八月";
                    break;
                case "9":
                    monthDescription = "九月";
                    break;
                case "10":
                    monthDescription = "十月";
                    break;
                case "11":
                    monthDescription = "十一月";
                    break;
                case "12":
                    monthDescription = "十二月";
                    break;
                default:
                    break;
            }

            return monthDescription;
        }

        private void RefreshDataGrid(DataTable table)
        {
            int Total = 0;
            if (table != null)
            {
                int index = 0;
                monthData.Rows.Clear();

                foreach (DataRow row in table.Rows)
                {
                    string calMonth = row["calMonth"].ToString();
                    string year = calMonth.Substring(0, 4);

                    bool isExist = false;
                    foreach (DataGridViewRow dataRow in monthData.Rows)
                    {
                        if (dataRow.Cells["yearCol"] != null && dataRow.Cells["yearCol"].Value != null
                            && dataRow.Cells["yearCol"].Value.ToString() == year)
                            isExist = true;

                    }
                    if (!isExist)
                    {

                        index = monthData.Rows.Add();
                        monthData.Rows[index].Cells["yearCol"].Value = year;

                    }
                    string month = calMonth.Replace(year, "");
                    string monthColName = string.Format("month{0}Col", month);
                    if (monthData.Columns.Contains(monthColName) && row["total"] != null)
                        monthData.Rows[index].Cells[monthColName].Value = row["total"];
                    for (int i = 0; i < monthData.ColumnCount; i++)
                        if (monthData.Rows[index].Cells[i].Value == null)
                            monthData.Rows[index].Cells[i].Value = 0;
                }
                for (int j = 1; j < monthData.ColumnCount - 1; j++)
                {
                    Total += int.Parse(monthData.Rows[index].Cells[j].Value.ToString());

                }
                monthData.Rows[index].Cells["Sum1"].Value = Total;
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            //c1RG6.Value = 0;
            DataSet set = new DataSet();
            DataTable windowsXPTable = new DataTable("WindowsXP");
            DataTable windows7Table = new DataTable("Windows7");
            set.Tables.Clear();
            windowsXPTable.Rows.Clear();
            windows7Table.Rows.Clear();
            radChartView1.Series.Clear();
            set.Tables.Add(windowsXPTable);
            set.Tables.Add(windows7Table);
            foreach (DataTable table in set.Tables)
            {
                table.Columns.Add("Month");
                table.Columns.Add("Usage", typeof(double));
                // table.Columns.Add("Usage1", typeof(double));
            }

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int yearInt = int.Parse(cb_year.Text);

            SortedList bb = new SortedList();
            DataSet result = null;
            bb.Add("time", new DateTime(yearInt - 1, 1, 1));
            if (N_type == "207")//湿包项
            {
                bb.Add("norm1", "208");
                bb.Add("norm", N_type);
                result = reCnasRemotCall.RemotInterface.ExecuteProcedure("total_average1", bb);
            }
            else if (N_type == "301")//灭菌失败项
            {

                bb.Add("norm1", "302");
                bb.Add("norm2", "303");
                bb.Add("norm", N_type);
                result = reCnasRemotCall.RemotInterface.ExecuteProcedure("total_average2", bb);
            }
            else
            {

                bb.Add("norm", N_type);
                result = reCnasRemotCall.RemotInterface.ExecuteProcedure("total_average", bb);
            }


            if (result != null && result.Tables != null && result.Tables.Count > 0)
            {
                int selectYearTotal = 0;
                int beforeYearTotal = 0;
                DataTable table = result.Tables[0];
                for (int i = 0; i < 2; i++)
                {

                    int calYear = i == 0 ? yearInt : yearInt - 1;
                    for (int j = 1; j < 13; j++)
                    {
                        string calMonth = calYear.ToString() + j.ToString().PadLeft(2, '0');
                        DataRow rowData = null;
                        if (table.Rows != null)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                if (row["calMonth"] != null && row["calMonth"].ToString() == calMonth)
                                {
                                    rowData = row;
                                    break;
                                }
                            }
                        }


                        if (rowData == null)
                        {
                            if (calYear.ToString() == cb_year.Text && j.ToString() == DateTime.Now.Month.ToString())
                                c1RG.Value = 0;
                            if (i == 0)
                            {
                                windowsXPTable.Rows.Add(GetMonthLbl(j.ToString()), 0);
                            }
                            else
                            {
                                windows7Table.Rows.Add(GetMonthLbl(j.ToString()), 0);
                            }
                        }
                        else
                        {
                            double calResult = rowData["total"] is DBNull ? 0 : Convert.ToDouble(rowData["total"]);
                            if (calYear.ToString() == cb_year.Text && j.ToString() == DateTime.Now.Month.ToString())
                                c1RG.Value = calResult;
                            if (i == 0)
                            {
                                windowsXPTable.Rows.Add(GetMonthLbl(j.ToString()), calResult);
                                selectYearTotal += rowData["total"] is DBNull ? 0 : int.Parse(rowData["total"].ToString());
                            }
                            else
                            {
                                beforeYearTotal += rowData["total"] is DBNull ? 0 : int.Parse(rowData["total"].ToString());
                                windows7Table.Rows.Add(GetMonthLbl(j.ToString()), calResult);
                            }
                        }
                    }
                    RefreshDataGrid(table);
                }
                currentYearTxt.Text = selectYearTotal.ToString();
                lastyeartet.Text = beforeYearTotal.ToString();
                radLabel3.Text = beforeYearTotal == selectYearTotal ? "平稳" : (beforeYearTotal > selectYearTotal) ? "下降" : "上升";
                //Todo 给总数赋值
            }


            this.radChartView1.DataSource = set;
            BarSeries windowsXPSeries = new BarSeries("Usage", "Month");
            windowsXPSeries.DataMember = "WindowsXP";
            windowsXPSeries.LegendTitle = "Windows XP";
            BarSeries windows7Series = new BarSeries("Usage", "Month");
            windows7Series.DataMember = "Windows7";
            windows7Series.LegendTitle = "Windows 7";
            windowsXPSeries.ShowLabels = true;
            this.radChartView1.Series.AddRange(windowsXPSeries, windows7Series);
        }

    }
}
