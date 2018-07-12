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
    public partial class DisinfectFail : TemplateForm
    {
        public DisinfectFail()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            cb_year.Text = DateTime.Now.Year.ToString();//初始化时显示当前时间
            //根据哪月判断第几季度
            if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
            {
                cb_month.Text = "1";
            }
            if (DateTime.Now.Month == 4 || DateTime.Now.Month == 5 || DateTime.Now.Month == 6)
            {
                cb_month.Text = "2";
            }
            if (DateTime.Now.Month == 7 || DateTime.Now.Month == 8 || DateTime.Now.Month == 9)
            {
                cb_month.Text = "3";
            }
            if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
            {
                cb_month.Text = "4";
            }
            //给季度的下拉列表赋值
            for (int j = 4; j >= 1; j--)
            {
                cb_month.Items.Add(j);
            }
            //给年份的下拉列表赋值
            for (int i = 2000; i < DateTime.Now.Year + 1; i++)
            {
                cb_year.Items.Add(i);
            }

            rBut_ok_Click(null, null);
        }

        

        private void RefreshDataGrid(DataTable table)
        {
            int total = 0;
            if (table != null)
            {
                int index = 0;
                monthData.Rows.Clear();

                foreach (DataRow row in table.Rows)
                {
                    string calMonth = row["calMonth"].ToString();
                    string year = calMonth.Substring(0, 4);

                    bool isExist = false;
                    foreach (GridViewRowInfo dataRow in monthData.Rows)
                    {
                        if (dataRow.Cells["yearCol"] != null && dataRow.Cells["yearCol"].Value != null
                            && dataRow.Cells["yearCol"].Value.ToString() == year)
                            isExist = true;

                    }
                    if (!isExist)
                    {
                        total = 0;
                        index = monthData.Rows.AddNew().Index;
                        monthData.Rows[index].Cells["yearCol"].Value = year;
                    }
                    string month = calMonth.Replace(year, "");
                    string monthColName = string.Format("month{0}Col", month);
                    if (monthData.Columns.Contains(monthColName) && row["child_count"] != null)
                    {
                        monthData.Rows[index].Cells[monthColName].Value = row["child_count"];
                        int childCount = 0;
                        int.TryParse(row["child_count"].ToString(), out childCount);
                        total += childCount;
                        monthData.Rows[index].Cells["Sum"].Value = total;
                    }
                    for (int i = 0; i < monthData.ColumnCount; i++)
                    {
                        if (monthData.Rows[index].Cells[i].Value == null ||
                           string.IsNullOrEmpty(monthData.Rows[index].Cells[i].Value.ToString()))
                        {
                            monthData.Rows[index].Cells[i].Value = 0;

                        }
                    }
                }
            }

        }


       
        private string GetQueartLbl(string month)
        {
            string queartDescription = "第一季度";
            switch (month)
            {
                case "1":
                case "01":
                    queartDescription = "第一季度";
                    break;
                case "2":
                case "02":
                    queartDescription = "第二季度";
                    break;
                case "3":
                    queartDescription = "第三季度";
                    break;
                case "4":
                    queartDescription = "第四季度";
                    break;
               
                default:
                    break;
            }

            return queartDescription;
        }

        private void rBut_ok_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();
            DataTable windowsXPTable = new DataTable("WindowsXP");//新建一个柱型来显示数据
            DataTable windows7Table = new DataTable("Windows7");//新建一个柱型来显示数据
            set.Tables.Clear();//清除一个柱型的数据
            windowsXPTable.Rows.Clear();//清除柱型数据
            windows7Table.Rows.Clear();//清除柱型数据
            radChartView1.Series.Clear();//清除数据柱型图数据
            set.Tables.Add(windowsXPTable);//给柱型添加数据
            set.Tables.Add(windows7Table);//给柱型添加数据
            foreach (DataTable table in set.Tables)//循环给每条柱型添加数据
            {
                table.Columns.Add("Month");//表示柱型下面的数据
                table.Columns.Add("Usage", typeof(double));//给每条柱型添加数值
                // table.Columns.Add("Usage1", typeof(double));
            }

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int yearInt = int.Parse(cb_year.Text);//讲年份转化成int类型

            SortedList bb = new SortedList();// 给存储过程传值的集合
            bb.Add("firstTime", new DateTime(yearInt - 1, 1, 1));//时间
            bb.Add("errortype", "10");//指标类型
            DataSet result = reCnasRemotCall.RemotInterface.ExecuteProcedure("disinfect_fail", bb);//根据时间，类型查询返回所需要的数据

            if (result != null && result.Tables != null && result.Tables.Count > 0)
            {
                int selectYearTotal = 0;
                int beforeYearTotal = 0;
                DataTable table = result.Tables[0];
                DataTable table01 = result.Tables[1];
                for (int i = 0; i < 2; i++)//用于判断是哪一年的
                {
                    int calYear = i == 0 ? yearInt : yearInt - 1;
                    //j表示哪一月
                    for (int j = 1; j < 5; j++)
                    {
                        string calQueart = calYear.ToString() + " " + j.ToString();
                        DataRow rowData = null;

                        if (table01.Rows != null)
                        {
                            foreach (DataRow row in table01.Rows)
                            {

                                if (row["calQueart"] != null && row["calQueart"].ToString() == calQueart)
                                {
                                    rowData = row;
                                    break;
                                }

                            }
                        }


                        if (rowData == null)
                        {
                            //if (calYear.ToString() == cb_year.Text && j.ToString() == cb_month.Text)
                            //    c1RG7.Value = 0;

                            if (i == 0)
                            {
                                windowsXPTable.Rows.Add(GetQueartLbl(j.ToString()), 0);
                            }
                            else
                            {
                                windows7Table.Rows.Add(GetQueartLbl(j.ToString()), 0);
                            }
                        }
                        else
                        {
                            double calResult = rowData["result"] is DBNull ? 0 : Convert.ToDouble(rowData["result"]);
                            if (calYear.ToString() == cb_year.Text && j.ToString() == cb_month.Text)
                                c1RG7.Value = calResult;
                            if (i == 0)
                            {
                                windowsXPTable.Rows.Add(GetQueartLbl(j.ToString()), calResult);
                                selectYearTotal += rowData["child_count"] is DBNull ? 0 : int.Parse(rowData["child_count"].ToString());
                            }
                            else
                            {
                                beforeYearTotal += rowData["child_count"] is DBNull ? 0 : int.Parse(rowData["child_count"].ToString());
                                windows7Table.Rows.Add(GetQueartLbl(j.ToString()), calResult);
                            }
                        }

                    }
                    RefreshDataGrid(table);
                }

                currentYearTxt.Text = selectYearTotal.ToString();
                lastyeartet.Text = beforeYearTotal.ToString();
                radLabel3.Text = beforeYearTotal == selectYearTotal ? "平稳" : (beforeYearTotal > selectYearTotal) ? "下降" : "上升";

            }

            this.radChartView1.DataSource = set;
            BarSeries windowsXPSeries = new BarSeries("Usage", "Month");
            windowsXPSeries.DataMember = "WindowsXP";
            windowsXPSeries.LegendTitle = "Windows XP";
            BarSeries windows7Series = new BarSeries("Usage", "Month");
            windows7Series.DataMember = "Windows7";
            windows7Series.LegendTitle = "Windows 7";
            windowsXPSeries.ShowLabels = true;
            windows7Series.ShowLabels = true;
            this.radChartView1.Series.AddRange(windowsXPSeries, windows7Series);
        }

        private void rBut_print_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;    //横向打印
                CaptureScreen();
                this.printDocument1.Print();
            }
        }
        //实现C 打印窗体  
        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(
           this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle destRect = new Rectangle(0, 0, 1150, 770);
            e.Graphics.DrawImage(memoryImage, destRect, 0, 0, memoryImage.Width, memoryImage.Height, System.Drawing.GraphicsUnit.Pixel); //.Pixel像素
        }
    }
}
