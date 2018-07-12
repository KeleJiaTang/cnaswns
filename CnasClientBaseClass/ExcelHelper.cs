using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data.OleDb;
using System.Data;
using Telerik.WinControls.UI;


namespace Cnas.wns.CnasBaseClassClient
{
    public class ExcelHelper
    {


        #region 导出数据到 Excel

        /// <summary>
        ///导出数据为Excel
        /// </summary>
        /// <param name="dataGridViewSource">需要导出的数据</param>
        /// <param name="saveFileName">导出文件的名称</param>
        /// <returns></returns>
        public static string ImprotDataToExcel(DataGridView dataGridViewSource, string saveFileName)
        {
            //string DownLoadPath = System.IO.Directory.GetCurrentDirectory() + "\\template\\模版.xlsx";
          
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel文件 (*.xlsx)|*.xlsx|(*.xls)|*.xls";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            //获取时分秒 
            string exportDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            //名称后面自动加入时分秒
            saveFileDialog1.FileName += saveFileName + exportDate + ".xlsx";
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            // 如果点击了取消，则退出方法
            if (dialogResult == DialogResult.Cancel)
            {
                return "";
            }

            //try
            //{
            //    // 根据模版生成一个空白的Excel文件
            //    //System.IO.File.Copy(DownLoadPath, saveFileDialog1.FileName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("复制Excel文件出错" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            try
            {
                //SpreadsheetDocument.Create(saveFileDialog1.FileName,DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook,true);
                //SpreadsheetDocument.Open(saveFileDialog1.FileName, true)
                using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Create(saveFileDialog1.FileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook, true))
                {

                    #region 新建一个WorkSheet
                    //WorkSheet的名称
                    string sheetName = saveFileName;
                    // create the workbook  
                    spreadSheet.AddWorkbookPart();
                    spreadSheet.WorkbookPart.Workbook = new Workbook();     // create the worksheet  
                    spreadSheet.WorkbookPart.AddNewPart<WorksheetPart>();
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet = new Worksheet();
                    SharedStringTablePart m_SharedStringTablePart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();

                    // create sheet data  
                    SheetData m_SheetData = new SheetData();
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.AppendChild(m_SheetData);

                    // create row  
                    //spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().AppendChild(new Row());
                    //// create cell with data  
                    //spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new Cell() { CellValue = new CellValue("100") });

                    //Add Data
                    Row row1 = new Row() { RowIndex = 1 };

                    Cell cell1 = new Cell() { CellReference = "A1" };
                    int index = InsertSharedStringItem("Sun", m_SharedStringTablePart);
                    cell1.CellValue = new CellValue(index.ToString());
                    cell1.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                    row1.Append(cell1);
                    m_SheetData.Append(row1);

                    // save worksheet  
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.Save();

                    // create the worksheet to workbook relation  
                    spreadSheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                    spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet()
                    {
                        Id = spreadSheet.WorkbookPart.GetIdOfPart(spreadSheet.WorkbookPart.WorksheetParts.First()),
                        SheetId = 1,
                        Name = sheetName
                    });

                    spreadSheet.WorkbookPart.Workbook.Save();
                    #endregion

                    var sheetData = spreadSheet.GetFirstSheetData();
                    //设置单元格样式等于第一条样式
                    //OpenXmlHelper.CellStyleIndex = 1;

                    char OneColumn = Convert.ToChar('A');//第一列都是从A开始的

                    // 去除列表中隐藏的列
                    DataGridView newDataSouce = dataGridViewSource;
                    for (int i = dataGridViewSource.Columns.Count - 1; i >= 0; i--)
                    {
                        if (!dataGridViewSource.Columns[i].Visible)
                        {
                            //删除重复的项
                            newDataSouce.Columns.Remove(dataGridViewSource.Columns[i]);
                        }
                    }

                    //不存在模板时就补充字段名称
                    for (var i = 0; i < newDataSouce.Columns.Count; i++)
                    {
                        if (newDataSouce.Columns[i].Visible)
                        {
                            OneColumn = Convert.ToChar('A' + i);
                            //填写列的名称（暂时还是数据库中的英文）
                            sheetData.SetCellValue(OneColumn.ToString() + 1, newDataSouce.Columns[i].HeaderText);
                        }
                    }
                    if (dataGridViewSource.Rows.Count > 0)
                    {
                        for (var j = 0; j < newDataSouce.Rows.Count; j++)
                        {
                            OneColumn = Convert.ToChar('A');

                            for (var k = 0; k < newDataSouce.Columns.Count; k++)
                            {
                                if (!newDataSouce.Rows[j].Cells[k].Visible) continue;

                                OneColumn = Convert.ToChar('A' + k);
                                //一个个填写值
                                sheetData.SetCellValue(OneColumn.ToString() + (j + 2), newDataSouce.Rows[j].Cells[k].EditedFormattedValue);

                            }
                        }
                    }
                    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Excel文件出错" + ex.Message);
            }
            return "";

        }




        /// <summary>
        ///导出数据为Excel
        /// </summary>
        /// <param name="dataGridViewSource">需要导出的数据</param>
        /// <param name="saveFileName">导出文件的名称</param>
        /// <returns></returns>
        public static string ImprotDataToExcel(RadGridView dataGridViewSource, string saveFileName)
        {
            //string DownLoadPath = System.IO.Directory.GetCurrentDirectory() + "\\template\\模版.xlsx";
            if (dataGridViewSource.Rows.Count == 0)
            {
                MessageBox.Show("该表数据为空！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel文件 (*.xlsx)|*.xlsx|(*.xls)|*.xls";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            //获取时分秒 
            string exportDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            //名称后面自动加入时分秒
            saveFileDialog1.FileName += saveFileName + exportDate + ".xlsx";
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            // 如果点击了取消，则退出方法
            if (dialogResult == DialogResult.Cancel)
            {
                return "";
            }

            //try
            //{
            //    // 根据模版生成一个空白的Excel文件
            //    //System.IO.File.Copy(DownLoadPath, saveFileDialog1.FileName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("复制Excel文件出错" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            try
            {
                //SpreadsheetDocument.Create(saveFileDialog1.FileName,DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook,true);
                //SpreadsheetDocument.Open(saveFileDialog1.FileName, true)
                using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Create(saveFileDialog1.FileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook, true))
                {

                    #region 新建一个WorkSheet
                    //WorkSheet的名称
                    string sheetName = saveFileName;
                    // create the workbook  
                    spreadSheet.AddWorkbookPart();
                    spreadSheet.WorkbookPart.Workbook = new Workbook();     // create the worksheet  
                    spreadSheet.WorkbookPart.AddNewPart<WorksheetPart>();
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet = new Worksheet();
                    SharedStringTablePart m_SharedStringTablePart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();

                    // create sheet data  
                    SheetData m_SheetData = new SheetData();
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.AppendChild(m_SheetData);

                    // create row  
                    //spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().AppendChild(new Row());
                    //// create cell with data  
                    //spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new Cell() { CellValue = new CellValue("100") });

                    //Add Data
                    Row row1 = new Row() { RowIndex = 1 };

                    Cell cell1 = new Cell() { CellReference = "A1" };
                    int index = InsertSharedStringItem("Sun", m_SharedStringTablePart);
                    cell1.CellValue = new CellValue(index.ToString());
                    cell1.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                    row1.Append(cell1);
                    m_SheetData.Append(row1);

                    // save worksheet  
                    spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.Save();

                    // create the worksheet to workbook relation  
                    spreadSheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                    spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet()
                    {
                        Id = spreadSheet.WorkbookPart.GetIdOfPart(spreadSheet.WorkbookPart.WorksheetParts.First()),
                        SheetId = 1,
                        Name = sheetName
                    });

                    spreadSheet.WorkbookPart.Workbook.Save();
                    #endregion

                    var sheetData = spreadSheet.GetFirstSheetData();
                    //设置单元格样式等于第一条样式
                    //OpenXmlHelper.CellStyleIndex = 1;

                    char OneColumn = Convert.ToChar('A');//第一列都是从A开始的

                    // 去除列表中隐藏的列
                    RadGridView newDataSouce = dataGridViewSource;
                    for (int i = dataGridViewSource.Columns.Count - 1; i >= 0; i--)
                    {
                        if (!dataGridViewSource.Columns[i].IsVisible)
                        {
                            //删除重复的项
                            newDataSouce.Columns.Remove(dataGridViewSource.Columns[i]);
                        }
                    }

                    //不存在模板时就补充字段名称
                    for (var i = 0; i < newDataSouce.Columns.Count; i++)
                    {
                        if (newDataSouce.Columns[i].IsVisible)
                        {
                            OneColumn = Convert.ToChar('A' + i);
                            //填写列的名称（暂时还是数据库中的英文）
                            sheetData.SetCellValue(OneColumn.ToString() + 1, newDataSouce.Columns[i].HeaderText);
                        }
                    }
                    if (dataGridViewSource.Rows.Count > 0)
                    {
                        for (var j = 0; j < newDataSouce.Rows.Count; j++)
                        {
                            OneColumn = Convert.ToChar('A');

                            for (var k = 0; k < newDataSouce.Columns.Count; k++)
                            {
                                //if (!newDataSouce.Rows[j].Cells[k].Visible) continue;

                                OneColumn = Convert.ToChar('A' + k);
                                //一个个填写值
                                sheetData.SetCellValue(OneColumn.ToString() + (j + 2), newDataSouce.Rows[j].Cells[k].Value);

                            }
                        }
                    }
                    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Excel文件出错" + ex.Message);
            }
            return "";

        }








        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
                shareStringPart.SharedStringTable.Count = 1;
                shareStringPart.SharedStringTable.UniqueCount = 1;
            }

            int i = 0;
            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }
                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }





        #endregion


        #region 从Excel导入数据

        /// <summary>
        /// 根据传入的 Excel 的绝对路径返回 DataTable
        /// </summary>
        /// <param name="columns">需要查询Excel的列，需要传入多个用逗号隔开，查询全部传入 * </param>
        /// <param name="filePath">Excel绝对路径</param>
        public static DataTable ExcelToDataTable(string columns, string filePath)
        {
            System.Data.DataTable dtSource = null;
            const string cmdText = "Provider=Microsoft.Ace.OleDb.12.0;Data Source={0};Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(string.Format(cmdText, filePath));

            if (conn.State == System.Data.ConnectionState.Broken || conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            System.Data.DataTable schemaTable = new DataTable();
            schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //获取excel的第二个sheet名称
            string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString().Trim();

            //查询sheet中的数据
            string strsql = "select " + columns + " from [" + sheetName + "]";

            OleDbDataAdapter da = new OleDbDataAdapter(strsql, conn);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "SourceData");
            dtSource = ds.Tables[0];

            da.Dispose();
            conn.Dispose();
            conn.Close();

            return dtSource;

        }

        #endregion

    }

}
