
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseClassClient
{
	public class AdoptPrinter
	{
		[DllImport("winspool.drv")]
		public static extern bool SetDefaultPrinter(string Name); //调用win api将指定名称的打印机设置为默认打印机

		public PrintDialog PrintDialog { get; set; }
		private string _defaultPrinterName;
		public int PrintDPI { get; set; }
		private DialogResult _printerDialogResult = DialogResult.OK;
		public DialogResult PrinterDialogResult
		{
			get
			{
				return _printerDialogResult;
			}
			set
			{
				if (value != _printerDialogResult)
					_printerDialogResult = value;
			}
		}

		private CnasRemotCall _remotCall = new CnasRemotCall();

		public AdoptPrinter(PrintDialog printDialog)
		{
			PrintDialog = printDialog;
			_defaultPrinterName = PrintDialog.PrinterSettings.PrinterName;
			PrintDPI = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.X;
		}

		public void GetPrintSetting(string computeName, int printerType = 0)
		{
			bool isExisted = false;
			SortedList chongfu = new SortedList();
			chongfu.Add(1, computeName);
			chongfu.Add(2, printerType);// type
			string printName = string.Empty;
			string ss = _remotCall.RemotInterface.CheckSelectData("HCS-printer-sec002", chongfu);
			DataTable getdt = _remotCall.RemotInterface.SelectData("HCS-printer-sec002", chongfu);

			if (getdt == null || getdt.Rows.Count == 0)
			{
				if (IsAdoptPrinter(PrintDialog, printerType == 1))
				{
					printName = UpdatePrinterSetting(computeName, PrintDialog.PrinterSettings.PrinterName, printerType);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("printlist", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					PrinterDialogResult = PrintDialog.ShowDialog();
					if (PrinterDialogResult == DialogResult.OK)
					{
						SetDefaultPrinter(PrintDialog.PrinterSettings.PrinterName);
						//SetPrinterSettings(PrintDialog, PrintDialog.PrinterSettings.PrinterName);
						GetPrintSetting(computeName, printerType);
					}
				}
			}
			else
			{
				foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
				{
					if (getdt.Columns.Contains("print_name") && getdt.Rows[0]["print_name"].ToString() == item)
					{
						isExisted = true;
						SetDefaultPrinter(item);
						printName = item;
						break;
					}
				}

				if (!isExisted || !IsAdoptPrinter(PrintDialog, printerType == 1))
				{
					PrinterDialogResult = PrintDialog.ShowDialog();
					if (PrinterDialogResult == DialogResult.OK)
					{
						SetDefaultPrinter(PrintDialog.PrinterSettings.PrinterName);
						if (IsAdoptPrinter(PrintDialog, printerType == 1))
						{
							printName = UpdatePrinterSetting(computeName, PrintDialog.PrinterSettings.PrinterName, printerType, true);
						}
						else
						{
							MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("printlist", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							GetPrintSetting(computeName, printerType);
						}
					}
				}
			}
			SetDefaultPrinter(printName);
		}

		private string UpdatePrinterSetting(string computeName, string printerName, int printerType, bool isUpdate =false)
		{
			string savedPrinterName = printerName;
			SortedList sttmp = new SortedList();
			SortedList item = new SortedList();
			SortedList sqlParameters = new SortedList();
			//sttmp.Add(1, computeName);
			//sttmp.Add(2, printerType);
			item.Add(1, printerName);
			item.Add(2, computeName);
			item.Add(3, printerType);
			sttmp.Add(1, item);
			sqlParameters.Add((isUpdate ? 1 :2), sttmp);
			string yy = _remotCall.RemotInterface.CheckUPDataList("HCS-printer-add001", sqlParameters);
			int incint = _remotCall.RemotInterface.UPDataList("HCS-printer-add001", sqlParameters);
			return savedPrinterName;
		}



		/// <summary>
		/// 判断打印机纸张是否符合
		/// </summary>
		/// <param name="printSettings">默认打印机</param>
		/// <returns></returns>
		private bool IsAdoptPrinter(PrintDialog printerDialog, bool isDpiCompare = false)
		{
			bool result = false;
			if (isDpiCompare)
			{
				result = printerDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.X >= PrintDPI;
			}
			else
			{

				if (printerDialog.PrinterSettings != null && printerDialog.PrinterSettings.DefaultPageSettings != null && printerDialog.PrinterSettings.DefaultPageSettings.PaperSize != null)
				{
					result = printerDialog.PrinterSettings.DefaultPageSettings.PaperSize.Width >= printerDialog.PrinterSettings.DefaultPageSettings.Margins.Left * 2
												   && printerDialog.PrinterSettings.DefaultPageSettings.PaperSize.Height >= printerDialog.PrinterSettings.DefaultPageSettings.Margins.Top * 2;
				}
			}

			return result;
		}

		public void SetBackToSystemDefaultPrint()
		{
			if (!string.IsNullOrEmpty(_defaultPrinterName))
				SetDefaultPrinter(_defaultPrinterName);
		}
	}
}
