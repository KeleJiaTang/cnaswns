using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text;
using System.Xml;
using System.Drawing.Printing;
using Cnas.wns.CnasBaseClassClient;
using Telerik.WinControls.UI;
using System.Runtime.InteropServices;

namespace Cnas.wns.CnasBaseClassClient
{
	public class RadPrintHelper
	{
		[DllImport("winspool.drv")]
		public static extern bool SetDefaultPrinter(String Name); //调用win api将指定名称的打印机设置为默认打印机

		//private static RadPrintHelper _helper = null;
		//public static RadPrintHelper Instance
		//{
		//    get
		//    {
		//        if (_helper == null)
		//            _helper = new PrintHelper();
		//        return _helper;
		//    }
		//}


		private StringFormat StrFormat;  // Holds content of a TextBox Cell to write by DrawString   
		private StringFormat StrFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage   
		private Button CellButton;       // Holds the Contents of Button Cell
		private CheckBox CellCheckBox;   // Holds the Contents of CheckBox Cell 
		private ComboBox CellComboBox;   // Holds the Contents of ComboBox Cell
		private int TotalWidth;          // Summation of Columns widths
		private int RowPos;              // Position of currently printing row 
		private bool NewPage;            // Indicates if a new page reached
		private int PageNo;              // Number of pages to print
		private ArrayList ColumnLefts = new ArrayList();  // Left Coordinate of Columns
		private Dictionary<string, int> ColumnWidths = new Dictionary<string, int>(); // Width of Columns
		private ArrayList ColumnTypes = new ArrayList();  // DataType of Columns
		private int CellHeight;          // Height of DataGrid Cell
		private int RowsPerPage;         // Number of Rows per Page
		private System.Drawing.Printing.PrintDocument printDoc =
				new System.Drawing.Printing.PrintDocument();  // PrintDocumnet Object used for printing

		private string PrintTitle = "";  // Header of pages
		private string PrintContent = "";
		private Telerik.WinControls.UI.RadGridView dgv;        // Holds DataGridView Object to print its contents
		private List<string> SelectedColumns = new List<string>();   // The Columns Selected by user to print.
		private List<string> AvailableColumns = new List<string>();  // All Columns avaiable in DataGrid 
		private bool PrintAllRows = true;   // True = print all rows,  False = print selected rows    
		private bool FitToPageWidth = true; // True = Fits selected columns to page width ,  False = Print columns as showed    
		private int HeaderHeight = 0;
		private Brush FontColor = Brushes.Black;
		private Brush ConFontColor = Brushes.Black;
		private Font TitleFont = new Font("新宋体", 10, FontStyle.Bold);
		private Font ConFont = new Font("新宋体", 10, FontStyle.Regular);
		private Font DgvFont = new Font("宋体", 9);
		private string barCodeValue = ""; //条码
		private string[] printContentValue = null; //条码
		private PrintDialog _printDialog = null;
		private AdoptPrinter _adopter = null;
		private PrintPreviewDialog _printPreviewDialog = null;


		public RadPrintHelper()
		{
			_printDialog = new PrintDialog();
			_adopter = new AdoptPrinter(_printDialog);
		}

		public void Print_DataGridView(Telerik.WinControls.UI.RadGridView dgv1)
		{
			Print_DataGridView(dgv1, null, null, null);
		}

		public void Print_DataGridView(Telerik.WinControls.UI.RadGridView dgv_01, string inXML)
		{
			Print_DataGridView(dgv_01, inXML,null,null);
		}

		public void Print_DataGridView(Telerik.WinControls.UI.RadGridView dgv_01, string inXML, string barCode, string[] concent)
		{
			_adopter.GetPrintSetting(CnasBaseData.MacAddress);
			barCodeValue = "";
			if (concent == null)
			{
				concent = printContentValue;
			}

			try
			{
				if (dgv_01.Rows.Count == 0)
				{
					MessageBox.Show("没有需要打印的数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (_adopter.PrinterDialogResult != DialogResult.OK)
					return;
				// Getting DataGridView object to print
				dgv = dgv_01;

				// Getting all Coulmns Names in the DataGridView
				AvailableColumns.Clear();

				foreach (GridViewColumn c in dgv.Columns)
				{
					if (!c.IsVisible) continue;
					AvailableColumns.Add(c.HeaderText);
				}

				// Showing the PrintOption Form
				//PrintOptions dlg = new PrintOptions(AvailableColumns, titleList);

				#region  获取XML

				XmlDocument xmldoc = new XmlDocument();
				xmldoc.LoadXml(inXML);
				XmlElement printTitleValueXML = xmldoc["PrintData"]["Title"]["value"];
				XmlElement printTitleSizeXML = xmldoc["PrintData"]["Attribute"]["titlesize"];
				XmlElement printTitleColorXML = xmldoc["PrintData"]["Attribute"]["titlecolor"];
				XmlElement printTitleStyleXML = xmldoc["PrintData"]["Attribute"]["titlestyle"];
				XmlElement printTitleFontXML = xmldoc["PrintData"]["Attribute"]["titlefont"];
				XmlElement printconSizeXML = xmldoc["PrintData"]["Attribute"]["consize"];
				XmlElement printconColorXML = xmldoc["PrintData"]["Attribute"]["concolor"];
				XmlElement printconStyleXML = xmldoc["PrintData"]["Attribute"]["constyle"];
				XmlElement printconFontXML = xmldoc["PrintData"]["Attribute"]["confont"];
				XmlElement printdgvSizeXML = xmldoc["PrintData"]["DataGrid"]["dgvfontSize"];
				XmlElement printdgvFontXML = xmldoc["PrintData"]["DataGrid"]["dgvfont"];
				XmlElement printdgvStyleXML = xmldoc["PrintData"]["DataGrid"]["dgvfontstyle"];


				XmlElement printContentDescriptionXML = xmldoc["PrintData"]["Content"]["description"];
				XmlElement printContentKeyXML = xmldoc["PrintData"]["Content"]["key"];
				XmlElement printContentValueXML = xmldoc["PrintData"]["Content"]["value"];

				string printTitleValue = printTitleValueXML != null ? printTitleValueXML.InnerXml : string.Empty;//标题
				string printTitleSize = printTitleSizeXML != null ? printTitleSizeXML.InnerXml : "10";//标题字体大小
				string printTitleColor = printTitleColorXML != null ? printTitleColorXML.InnerXml : Color.Black.ToString();//标题字体颜色
				string printTitleStyle = printTitleStyleXML != null ? printTitleStyleXML.InnerXml : FontStyle.Regular.ToString();//标题字体风格               
				string printTitleFont = printTitleFontXML != null ? printTitleFontXML.InnerXml : "新宋体";//标题字体

				string printconSize = printconSizeXML != null ? printconSizeXML.InnerXml : "9";//内容字体大小
				string printconColor = printconColorXML != null ? printconColorXML.InnerXml : Color.Black.ToString();//内容字体颜色
				string printconStyle = printconStyleXML != null ? printconStyleXML.InnerXml : FontStyle.Regular.ToString();//内容字体风格               
				string printconFont = printconFontXML != null ? printconFontXML.InnerXml : string.Empty; //内容字体

				string printdgvSize = printdgvSizeXML != null ? printdgvSizeXML.InnerXml : "9";//Dgv字体大小
				string printdgvFont = printdgvFontXML != null ? printdgvFontXML.InnerXml : "新宋体";//Dgv字体
				string printdgvStyle = printdgvStyleXML != null ? printdgvStyleXML.InnerXml : FontStyle.Regular.ToString();//Dgv字体风格

				string printContentDescription = printContentDescriptionXML.InnerXml;//列表的基本信息
				string[] printContentKey = printContentKeyXML.InnerXml.Split(',');//列表的键
				printContentValue = printContentValueXML.InnerXml.Split(',');//列表的值
				#endregion


				for (int i = 0; i < printContentKey.Length; i++)
				{
					if(concent==null)
					{
						printContentDescription = printContentDescription.Replace(printContentKey[i], printContentValue[i]);
					}
					if(concent!=null)
					if (concent.Length > 0) //如果有自定义传入参数值，则显示参数值
					{
						if (i > concent.Length - 1)
						{
							printContentDescription = printContentDescription.Replace(printContentKey[i], printContentValue[i]);
						}
						else
							printContentDescription = printContentDescription.Replace(printContentKey[i], concent[i]);

					}
					else
						printContentDescription = printContentDescription.Replace(printContentKey[i], printContentValue[i]);
				
				}

				#region 字体属性
				//标题字体属性
				FontColor = new SolidBrush(Color.FromName(printTitleColor));
				string titlefont = "新宋体";
				if (!string.IsNullOrEmpty(null))
					titlefont = "新宋体";
				else
				{
					titlefont = printTitleFont;
				}
				float titlesize = 20;
				float.TryParse(printTitleSize, out titlesize);
				if (titlesize == 0)
				{
					titlesize = 20;
				}
				FontStyle titleStyle = FontStyle.Bold;
				Enum.TryParse(printTitleStyle, out titleStyle);
				TitleFont = new Font(titlefont, titlesize, titleStyle);

				ConFontColor = new SolidBrush(Color.FromName(printconColor));
				//内容字体属性
				string confont = "新宋体";
				if (!string.IsNullOrEmpty(null))
					confont = "新宋体";
				else
				{
					confont = printconFont;
				}
				FontStyle contentFontStyle = FontStyle.Regular;
				Enum.TryParse(printconStyle, out contentFontStyle);
				float consize = 12;
				float.TryParse(printconSize, out consize);
				if (consize == 0)
				{
					consize = 12;
				}
				ConFont = new Font(confont, consize, contentFontStyle);


				//dgv字体属性
				string dgvfont = "新宋体";
				if (!string.IsNullOrEmpty(null))
					dgvfont = "宋体";
				else
				{
					dgvfont = printdgvFont;
				}
				FontStyle dgvFontStyle = FontStyle.Regular;
				Enum.TryParse(printdgvStyle, out dgvFontStyle);
				float dgvsize = 9;
				float.TryParse(printdgvSize, out dgvsize);
				if (dgvsize == 0)
				{
					dgvsize = 9;
				}
				DgvFont = new Font(dgvfont, dgvsize, dgvFontStyle);
				#endregion
				PrintTitle = printTitleValue;//标题的值

				// 判断用户是否有传入 barCode 
				if (!string.IsNullOrEmpty(barCode))
				{
					barCodeValue = barCode;
				}

				PrintContent = printContentDescription;//内容的值
				PrintAllRows = true;//所有行
				FitToPageWidth = true;//页宽
				SelectedColumns = AvailableColumns;//打印的列

				RowsPerPage = 0;

				_printPreviewDialog = new PrintPreviewDialog();
				_printPreviewDialog.Document = printDoc;//获取预览文档
				printDoc.PrinterSettings = _printDialog.PrinterSettings;

				// 展现每一页打印内容
				printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
				printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
				_printPreviewDialog.FormClosed += OnPrintPreviewDialogClosed;

				if (_printPreviewDialog.ShowDialog() != DialogResult.OK)
				{
					printDoc.BeginPrint -= new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
					printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
					return;
				}

				//开始打印
				printDoc.Print();
				printDoc.BeginPrint -= new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
				printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
				printDoc.EndPrint += printDoc_EndPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{

			}
		}

		void OnPrintPreviewDialogClosed(object sender, FormClosedEventArgs e)
		{
			if (_adopter != null)
				_adopter.SetBackToSystemDefaultPrint();
		}

		void printDoc_EndPrint(object sender, PrintEventArgs e)
		{
			if (_printPreviewDialog != null)
				_printPreviewDialog.Close();
		}



		private void PrintDoc_BeginPrint(object sender,
					System.Drawing.Printing.PrintEventArgs e)
		{
			try
			{
				//格式化每个单元格内容的打印方式
				StrFormat = new StringFormat();
				StrFormat.Alignment = StringAlignment.Center;
				StrFormat.LineAlignment = StringAlignment.Center;
				StrFormat.Trimming = StringTrimming.None;

				// Formatting the Content of Combo Cells to print
				StrFormatComboBox = new StringFormat();
				StrFormatComboBox.LineAlignment = StringAlignment.Center;
				StrFormatComboBox.FormatFlags = StringFormatFlags.DirectionVertical;
				StrFormatComboBox.Trimming = StringTrimming.None;

				ColumnLefts.Clear();
				ColumnWidths.Clear();
				ColumnTypes.Clear();
				CellHeight = 0;//dgv单元格的高度
				RowsPerPage = 0;//行数

				//各种列的类型
				CellButton = new Button();
				CellCheckBox = new CheckBox();
				CellComboBox = new ComboBox();

				// 计算总列的宽度
				TotalWidth = 0;
				foreach (GridViewColumn GridCol in dgv.Columns)//GridCol表示每列
				{
					if (!GridCol.IsVisible) continue;
					if (!SelectedColumns.Contains(GridCol.HeaderText)) continue;
					TotalWidth += GridCol.Width;
				}
				PageNo = 1;//页码
				NewPage = true;//显示最新页
				RowPos = 0;//定位当前行
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void PrintDoc_PrintPage(object sender,
					System.Drawing.Printing.PrintPageEventArgs e)
		{
			//if(e.PageBounds.Width!=827||e.PageBounds.Height!=1169)
			//{
			//    MessageBox.Show("打印纸张不合适,请设置打印机打印纸张的大小。");
			//    return;
			//
			//}
			int tmpWidth, i;

			int tmpTop = e.MarginBounds.Top;
			int tmpLeft = e.MarginBounds.Left;

			try
			{
				double pageWidth = e.PageBounds.Width - e.MarginBounds.Left * 2;
				if (pageWidth < 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("printlist", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					_printPreviewDialog.Close();
					return;
				}
				// Before starting first page, it saves Width & Height of Headers and CoulmnType
				if (PageNo == 1)
				{
					foreach (GridViewColumn GridCol in dgv.Columns)
					{
						if (!GridCol.IsVisible)
						{
							ColumnWidths.Add(GridCol.Name, 0);
							continue;
						}
						// Skip if the current column not selected
						if (!SelectedColumns.Contains(GridCol.HeaderText)) continue;

						// Detemining whether the columns are fitted to page or not.
						if (FitToPageWidth)
						{
							;
							if (pageWidth < TotalWidth)
							{
								tmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
									   (double)TotalWidth * (double)pageWidth)));
							}
							else
							{
								tmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
									   (double)TotalWidth * (double)TotalWidth *
									   ((double)e.MarginBounds.Width / (double)TotalWidth))));
							}
						}
						else
						{
							if (pageWidth < TotalWidth)
							{
								tmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
									   (double)TotalWidth * (double)pageWidth)));
							}
							else
							{
								tmpWidth = GridCol.Width;
							}
						}
						HeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
									this.dgv.Font, tmpWidth).Height) + 20;

						// Save width & height of headres and ColumnType
						ColumnLefts.Add(tmpLeft);
						ColumnWidths.Add(GridCol.Name, tmpWidth);
						ColumnTypes.Add(GridCol.GetType());
						tmpLeft += tmpWidth;
					}
				}

				// Printing Current Page, Row by Row
				while (RowPos <= dgv.Rows.Count - 1)
				{
					GridViewRowInfo GridRow = dgv.Rows[RowPos];
					if ((!PrintAllRows && !GridRow.IsSelected))
					{
						RowPos++;
						continue;
					}
					// CellHeight = GridRow.Height;

					if (tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
					{
						DrawFooter(e, RowsPerPage);
						NewPage = true;
						PageNo++;
						e.HasMorePages = true;
						return;
					}
					else
					{
						Font font = new Font(dgv.Font,
									FontStyle.Bold);
						if (NewPage)
						{
							// Draw Header
							//这里开始渲染标题
							SizeF titleSize = e.Graphics.MeasureString(PrintTitle, TitleFont, e.MarginBounds.Width);
							e.Graphics.DrawString(PrintTitle, TitleFont,
								   FontColor, (int)((pageWidth + e.MarginBounds.Left * 2 - titleSize.Width) / 2), e.MarginBounds.Top -
							titleSize.Height);


							// 用于记录BarCode有传入的情况下，记录高度
							int barCodeHeight = 0;

							if (!string.IsNullOrEmpty(barCodeValue))
							{
								//渲染出BarCode在界面上
								Image barImage = BarCodeHelper.GetBarcodeImage(barCodeValue, barCodeValue, 300, 100);
								e.Graphics.DrawImage(barImage, (int)((pageWidth + e.MarginBounds.Left * 2 - barImage.Width) / 2), e.MarginBounds.Top -
							titleSize.Height + 50, 300, 100);
								barCodeHeight = barImage.Height;
							}

							String s = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
							SizeF timeSize = e.Graphics.MeasureString(s, new Font(dgv.Font,
									FontStyle.Bold), e.MarginBounds.Width);

							tmpTop = e.MarginBounds.Top;
							if (PageNo == 1)
							{

								int topH = 0;
								if (!string.IsNullOrEmpty(barCodeValue))
								{
									topH = barCodeHeight;
								}

								//显示内容部分
								if (!string.IsNullOrEmpty(PrintContent))
								{
									SizeF contentSize = e.Graphics.MeasureString(PrintContent, ConFont, e.MarginBounds.Width);
									e.Graphics.DrawString(PrintContent, ConFont,
									ConFontColor, e.MarginBounds.Left - 18, e.MarginBounds.Top + barCodeHeight);
									tmpTop = (int)(e.MarginBounds.Top + contentSize.Height) + barCodeHeight;


									//显示时间
									e.Graphics.DrawString(s, font,
										Brushes.Red, (int)(pageWidth + e.MarginBounds.Left * 2 - e.MarginBounds.Left - timeSize.Width - 10),
										(e.MarginBounds.Top + e.Graphics.MeasureString(PrintTitle, font, e.MarginBounds.Width).Height
										+ e.Graphics.MeasureString(PrintContent, font, e.MarginBounds.Width).Height) + topH);
								}
								else
								{
									e.Graphics.DrawString(s, font,
									  Brushes.Red, e.MarginBounds.Left + (e.MarginBounds.Width -
									  e.Graphics.MeasureString(s, new Font(dgv.Font,
									  FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
									  e.Graphics.MeasureString(PrintTitle, font, e.MarginBounds.Width).Height + topH);
									tmpTop = e.MarginBounds.Top + barCodeHeight;
								}

							}

							if (PageNo != 1)
							{
								e.Graphics.DrawString(s, font,
									  Brushes.Red, e.MarginBounds.Left + (e.MarginBounds.Width -
									  e.Graphics.MeasureString(s, new Font(dgv.Font,
									  FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
									  e.Graphics.MeasureString(PrintTitle, font, e.MarginBounds.Width).Height);

								tmpTop = e.MarginBounds.Top + barCodeHeight;
							}

							// Draw Columns
							i = 0;
							foreach (GridViewColumn GridCol in dgv.Columns)
							{
								if (!GridCol.IsVisible) continue;
								if (!SelectedColumns.Contains(GridCol.HeaderText))
									continue;

								e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
									new Rectangle((int)ColumnLefts[i], tmpTop,
									(int)ColumnWidths[GridCol.Name], HeaderHeight));

								e.Graphics.DrawRectangle(Pens.Black,
									new Rectangle((int)ColumnLefts[i], tmpTop,
									(int)ColumnWidths[GridCol.Name], HeaderHeight));

								e.Graphics.DrawString(GridCol.HeaderText, DgvFont,
									new SolidBrush(Color.Black),
									new RectangleF((int)ColumnLefts[i], tmpTop,
									(int)ColumnWidths[GridCol.Name], HeaderHeight), StrFormat);
								i++;
							}
							NewPage = false;
							tmpTop += HeaderHeight;

						}

						// Draw Columns Contents
						i = 0;
						foreach (GridViewCellInfo Cel in GridRow.Cells)
						{
							if (!Cel.ColumnInfo.IsVisible) continue;
							if (!SelectedColumns.Contains(Cel.ColumnInfo.HeaderText))
								continue;

							int j = 0;
							foreach (GridViewCellInfo cel in GridRow.Cells)
							{
								SizeF maxSize = new SizeF((int)ColumnWidths[cel.ColumnInfo.Name], CellHeight);

								string celValue = cel.Value != null ? cel.Value.ToString() : "";
								SizeF celSize = e.Graphics.MeasureString(celValue, DgvFont, e.MarginBounds.Width);

								double celHeight = celSize.Height * Math.Ceiling((double)(celSize.Width / maxSize.Width));
								if (maxSize.Height < Math.Ceiling(celHeight) && !double.IsInfinity(celHeight))
								{
									maxSize = new SizeF(maxSize.Width, (float)Math.Ceiling(celHeight));
									CellHeight = (int)maxSize.Height + 10;
								}

								j++;
							}
							string cellValue = Cel.Value != null ? Cel.Value.ToString() : "";
							// For the TextBox Column
							if (((Type)ColumnTypes[i]).Name == "GridViewTextBoxColumn" ||
								((Type)ColumnTypes[i]).Name == "GridViewLinkColumn")
							{
								e.Graphics.DrawString(cellValue, DgvFont,
										new SolidBrush(Color.Black),
										new RectangleF((int)ColumnLefts[i], (float)tmpTop,
										(int)ColumnWidths[Cel.ColumnInfo.Name], (int)CellHeight), StrFormat);
							}
							// For the Button Column
							else if (((Type)ColumnTypes[i]).Name == "GridViewButtonColumn")
							{
								CellButton.Text = cellValue;
								CellButton.Size = new Size((int)ColumnWidths[Cel.ColumnInfo.Name], (int)CellHeight);
								Bitmap bmp = new Bitmap(CellButton.Width, CellButton.Height);
								CellButton.DrawToBitmap(bmp, new Rectangle(0, 0,
										bmp.Width, bmp.Height));
								e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
							}
							// For the CheckBox Column
							else if (((Type)ColumnTypes[i]).Name == "GridViewCheckBoxColumn")
							{
								CellCheckBox.Size = new Size(14, 14);
								CellCheckBox.Checked = (bool)Boolean.Parse(cellValue);
								Bitmap bmp = new Bitmap((int)ColumnWidths[Cel.ColumnInfo.Name], CellHeight);
								Graphics tmpGraphics = Graphics.FromImage(bmp);
								tmpGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0,
										bmp.Width, bmp.Height));
								CellCheckBox.DrawToBitmap(bmp,
										new Rectangle((int)((bmp.Width - CellCheckBox.Width) / 2),
										(int)((bmp.Height - CellCheckBox.Height) / 2),
										CellCheckBox.Width, CellCheckBox.Height));
								e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
							}
							// For the ComboBox Column
							else if (((Type)ColumnTypes[i]).Name == "GridViewComboBoxColumn")
							{
								CellComboBox.Size = new Size((int)ColumnWidths[Cel.ColumnInfo.Name], (int)CellHeight);
								Bitmap bmp = new Bitmap(CellComboBox.Width, (int)CellHeight);
								CellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0,
										bmp.Width, bmp.Height));
								e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
								e.Graphics.DrawString(cellValue, TitleFont,
										new SolidBrush(Color.Black),
										new RectangleF((int)ColumnLefts[i] + 1, tmpTop, (int)ColumnWidths[Cel.ColumnInfo.Name]
										- 16, CellHeight), StrFormatComboBox);
							}
							// For the Image Column
							else if (((Type)ColumnTypes[i]).Name == "GridViewImageColumn")
							{
								Rectangle CelSize = new Rectangle((int)ColumnLefts[i],
										tmpTop, (int)ColumnWidths[Cel.ColumnInfo.Name], CellHeight);
								Size ImgSize = ((Image)(Cel.Value)).Size;
								e.Graphics.DrawImage((Image)Cel.Value,
										new Rectangle((int)ColumnLefts[i] + (int)((CelSize.Width - ImgSize.Width) / 2),
										tmpTop + (int)((CelSize.Height - ImgSize.Height) / 2),
										((Image)(Cel.Value)).Width, ((Image)(Cel.Value)).Height));

							}
							// For the Decimal
							else if (((Type)ColumnTypes[i]).Name == "GridViewDecimalColumn")
							{
								e.Graphics.DrawString(cellValue, DgvFont,
										new SolidBrush(Color.Black),
										new RectangleF((int)ColumnLefts[i], (float)tmpTop,
										(int)ColumnWidths[Cel.ColumnInfo.Name], (int)CellHeight), StrFormat);
							}

							// Drawing Cells Borders 
							e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)ColumnLefts[i],
									tmpTop, (int)ColumnWidths[Cel.ColumnInfo.Name], (int)CellHeight));

							i++;
						}
						tmpTop += CellHeight;
					}

					RowPos++;
					// For the first page it calculates Rows per Page
					if (PageNo == 1)
					{
						RowsPerPage++;
					}
				}

				if (RowsPerPage == 0) return;

				// Write Footer (Page Number)
				DrawFooter(e, RowsPerPage);

				e.HasMorePages = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e,
					int RowsPerPage)
		{
			double cnt = 0;

			// Detemining rows number to print
			if (PrintAllRows)
			{
				//if (dgv.Rows[dgv.Rows.Count - 1].IsNewRow)
				//    cnt = dgv.Rows.Count - 2; // When the DataGridView doesn't allow adding rows
				//else
				cnt = dgv.Rows.Count - 1; // When the DataGridView allows adding rows

			}
			else
				cnt = dgv.SelectedRows.Count;

			// Writing the Page Number on the Bottom of Page
			string PageNum = " 第 " + PageNo.ToString()
						   + " 页，共 " + Math.Ceiling((double)(cnt / RowsPerPage)).ToString()
						   + " 页";

			e.Graphics.DrawString(PageNum, dgv.Font, Brushes.Black,
				e.MarginBounds.Left + (e.MarginBounds.Width -
				e.Graphics.MeasureString(PageNum, dgv.Font,
				e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top +
				e.MarginBounds.Height + 31);
		}

	}
}
