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
    public partial class HCSRS_OutsideInstruments : TemplateForm
    {
        public HCSRS_OutsideInstruments()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            cb_year.Text = DateTime.Now.Year.ToString();
            //cb_month.Text = DateTime.Now.Month.ToString();
			for (int i = DateTime.Now.Year; i > 2000; i--)
            {
                cb_year.Items.Add(i);
            }
            rBut_ok_Click(null, null);
        }

       
        private void rBut_ok_Click(object sender, EventArgs e)
        {
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
            }

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int yearInt = int.Parse(cb_year.Text);

            SortedList bb = new SortedList();
            bb.Add("fisrtTime", new DateTime(yearInt - 1, 1, 1));
            DataSet result = reCnasRemotCall.RemotInterface.ExecuteProcedure("dispose_outside", bb);

            if (result != null && result.Tables != null && result.Tables.Count > 0)
            {
                int selectYearTotal = 0;
                int beforeYearTotal = 0;
                double Total = 0;
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
                                if (row["calmon"] != null && row["calmon"].ToString() == calMonth)
                                {
                                    rowData = row;
                                    break;
                                }
                            }
                        }


                        if (rowData == null)
                        {
                            if (i == 0)
                            {
                                windowsXPTable.Rows.Add(GetMonthLbl(j.ToString()), 0);
                            }
                            else
                            {
                                windows7Table.Rows.Add(GetMonthLbl(j.ToString()), 0);
                            }
                        }
                        if (rowData!= null)
                        {
                            double calResult = rowData["total"] is DBNull ? 0 : Convert.ToDouble(rowData["total"]);
                            if (calYear.ToString() == cb_year.Text )
                                Total+=calResult;
                                c1RG.Value =double.Parse(String.Format("{0:F}", Total/12));
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
        private void RefreshDataGrid(DataTable table)
        {
            int Total=0;
            if (table != null)
            {
                int index = 0;
                monthData.Rows.Clear();

                foreach (DataRow row in table.Rows)
                {
                    string calMonth = row["calmon"].ToString();
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
                        Total = 0;
                        index = monthData.Rows.AddNew().Index;
                        monthData.Rows[index].Cells["yearCol"].Value = year;
                        
                    }
                    string month = calMonth.Replace(year, "");
                    string monthColName = string.Format("month{0}Col", month);
                    if (monthData.Columns.Contains(monthColName) && row["total"] != null)
                    {
                        monthData.Rows[index].Cells[monthColName].Value = row["total"];
                        int childCount = 0;
                        int.TryParse(row["total"].ToString(), out childCount);
                        Total += childCount;
                        monthData.Rows[index].Cells["Sum"].Value = Total;
                    }
                        
                    for (int i = 0; i < monthData.ColumnCount; i++)
                        if (monthData.Rows[index].Cells[i].Value == null)
                            monthData.Rows[index].Cells[i].Value = 0;
                }
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

             private void rBut_print_Click_1(object sender, EventArgs e)
             {
                 if (this.printDialog1.ShowDialog() == DialogResult.OK)
                 {
                     printDocument1.DefaultPageSettings.Landscape = true;    //横向打印
                     CaptureScreen();
                     this.printDocument1.Print();
                 }
             }
    }
}

      