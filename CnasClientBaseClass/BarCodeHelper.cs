using Cnas.wns.CnasBarcodeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cnas.wns.CnasBaseClassClient
{
	/// <summary>
	/// 条形码辅助类
	/// </summary>
	public class BarCodeHelper
	{
		public const string BDTestSetCode = "BCC0T00000000";
		public const string BDTestBCUCode = "BCU0T00000000";

		/// <summary>
		/// 条形码规则
		/// </summary>
		private static string barCodePattern = "[A-Za-z0-9]{13}";

		public static bool IsSpecialSet(string setBarCode)
		{
			return setBarCode.StartsWith("BCC0S") ? true : false;
		}

		public static bool IsOrderSet(string setBarCode)
		{
			return !string.IsNullOrEmpty(setBarCode) && (setBarCode.StartsWith("BCC1O") || setBarCode.StartsWith("BCC2O") || setBarCode.StartsWith("BCC3O") || setBarCode.StartsWith("BCC4O")) ? true : false;
		}

		public static bool IsTempSet(string setBarCode)
		{
			return !string.IsNullOrEmpty(setBarCode) && setBarCode.StartsWith("BCC") && setBarCode.Substring(4,1).Equals("T");
		}

		public static bool IsSplitSet(string bcuCode)
		{
			return !string.IsNullOrEmpty(bcuCode) && bcuCode.StartsWith("BCU") && bcuCode.Substring(4, 1).Equals("R");
		}

		public static bool IsOrderOutSet(string setBarCode)
		{
			return setBarCode.StartsWith("BCC4O");
		}

		public static bool IsOutOrderBCU(string bcuCode)
		{
			bool result = false;
			if (!string.IsNullOrEmpty(bcuCode))
				result = bcuCode.StartsWith("BCU") && bcuCode.Substring(3, 1).Equals("2");
			return result;
		}

		public static bool IsTempBCU(string bcuCode)
		{
			bool result = false;
			if (!string.IsNullOrEmpty(bcuCode))
			{
				result = bcuCode.StartsWith("BCU") && (bcuCode.Substring(4, 1).Equals("T") || bcuCode.Substring(4, 1).Equals("R"));
			}
				
			return result;
		}

		/// <summary>
		/// 根据扫描结果获取提取条形码
		/// </summary>
		/// <param name="scanBarCode">扫描码</param>
		/// <returns>条形码</returns>
		public static string GetMatchBarCode(string scanBarCode, bool isSystemBarCode = true)
		{
			string barCode = string.Empty;
			if (isSystemBarCode)
			{
				string code = string.Empty;
				foreach(char key in scanBarCode)
				{
					code += ConvertToNum(key);
				}
				Match matchs = Regex.Match(code, barCodePattern);
				barCode = matchs.Success ? matchs.Value.ToUpper() : barCode;
			}
			else
			{
				barCode = scanBarCode;
			}

			return barCode;
		}

		public static char ConvertToNum(char orginalKey)
		{
			char result = orginalKey;
			switch (orginalKey)
			{
				case '!':		 //!
					result = '1';
					break;
				case '@':		 //@
					result = '2';
					break;
				case '#':		 //#
					result = '3';
					break;
				case '$':		//$
					result = '4';
					break;
				case '%':		//%
					result = '5';
					break;
				case '^':		//^
					result = '6';
					break;
				case '&':		//&
					result = '7';
					break;
				case '*':		//*
					result = '8';
					break;
				case '(':		//(
					result = '9';
					break;
				case ')':	   //）
					result = '0';
					break;
				default:
					break;
			}
			return result;
		}

		public static string GetBarCodeByType(string type,SortedList param)
		{
			string result = string.Empty;

			if (param != null)
			{
				for (int i = 0; i < param.Count; i++)
				{
					if (param.GetKey(i).ToString().StartsWith(type)
						|| param.GetKey(i).ToString().Contains(string.Format(":{0}",type)))
					{
						if (param.GetKey(i).ToString().Contains(":"))
						{
							string[] barCodes = param.GetKey(i).ToString().Split(':');
							foreach (string barCode in barCodes)
							{
								if (barCode.StartsWith(type))
									result += string.Format("{0},", barCode.ToString());
							}
						}
						else
						{
							result += string.Format("{0},", param.GetKey(i).ToString());
						}
					}
				}
				if (!string.IsNullOrEmpty(result))
					result = result.TrimEnd(',');
			}

			return result;
		}

		public static string GetBarCodeByType(string type, Dictionary<string, string> param)
		{
			string result = string.Empty;

			if (param != null)
			{
				for (int i = 0; i < param.Count; i++)
				{
					KeyValuePair<string, string> item = param.ElementAt(i);
					if (item.Key.StartsWith(type)
						|| item.Key.Contains(string.Format(":{0}", type)))
					{
						if (item.Key.Contains(":"))
						{
							string[] barCodes = item.Key.Split(':');
							foreach (string barCode in barCodes)
							{
								if (barCode.StartsWith(type))
									result += string.Format("{0},", barCode.ToString());
							}
						}
						else
						{
							result += string.Format("{0},", item.Key.ToString());
						}
					}
				}
				if (!string.IsNullOrEmpty(result))
					result = result.TrimEnd(',');
			}

			return result;
		} 

		public static string GetBarCodeTypeName(string barCodeType)
		{
			string barCodeName = string.Empty;
			try
			{
				DataRow[] codeTypeData = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS_barcode_type' and key_code='{0}'", barCodeType));
				if (codeTypeData.Length > 0 && codeTypeData[0]["value_code"] != null)
				{
					barCodeName = codeTypeData[0]["value_code"].ToString();
				}
				else if (barCodeType == "XXX")
				{
					barCodeName = "病人条码";
				}

			}
			catch (Exception)
			{
			}
			return barCodeName;
		}

		public static Image GetBarcodeImage(string inVarcode, string inname, int width, int height)
		{
			return GetBarcodeImage(inVarcode, inname, Color.Black, Color.White, width, height);
		}

		public static Image GetBarcodeImage(string inVarcode, string inname, Color fontColor, Color backgroundColor, int width, int height)
		{
			Barcode barCode = new Barcode();
			barCode.ChangeRawData = inname;
			barCode.IncludeLabel = true;
			barCode.Alignment = AlignmentPositions.CENTER;
			barCode.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
			barCode.LabelPosition = LabelPositions.TOPCENTER;
			return barCode.Encode(TYPE.CODE128, inVarcode, fontColor, backgroundColor, width, height);
		}

		/// <summary>
		///  获取条形码图片
		/// </summary>
		/// <param name="inVarcode">条形码</param>
		/// <param name="inname">条形码内部名称</param>
		/// <returns>条形码图片</returns>
		public static Image GetBarcodeImage(string inVarcode, string inname)
		{
			Barcode barCode = new Barcode();
			barCode.ChangeRawData = inname;
			barCode.IncludeLabel = true;
			barCode.Alignment = AlignmentPositions.CENTER;
			barCode.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
			barCode.LabelPosition = LabelPositions.TOPCENTER;
			return barCode.Encode(TYPE.CODE128, inVarcode, Color.Black, Color.White, 180, 90);
		}

		public static string PrintBarCode(string barCode, SortedList parameters)
		{
			string codeType = GetCodeType(barCode);
			return PrintBarCode(barCode, codeType, parameters);
		}

		private static string GetCodeType(string barCode)
		{
			string codeType = "";
			if (!string.IsNullOrEmpty(barCode))
			{
				if (barCode.StartsWith("BCU"))
				{
					if (IsTempBCU(barCode))
					{
						if (IsOutOrderBCU(barCode))
						{
							codeType = barCode.Substring(0, 3) + "T";
						}
						else
							codeType = barCode.Substring(0, 3);
					}
					else
						codeType = barCode.Substring(0, 3);
				}
				else
				{
					codeType = barCode.Substring(0, 3);
				}
			}
			return codeType;
		}

		public static string PrintBarCode(string barCode, string codeType, SortedList parameters)
		{
			string result = string.Empty;
			DataRow[] printTemplate = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS_barcode_type' and key_code='{0}'", codeType));
			if (printTemplate.Length > 0 && printTemplate[0]["other_code"]!= null)
			{
				string template = printTemplate[0]["other_code"].ToString().Trim();
				if (!string.IsNullOrEmpty(template))
				{
					if (!parameters.ContainsKey("BarcodeValue"))
						parameters.Add("BarcodeValue", barCode);
					BarCodeParameterHelper helper = new BarCodeParameterHelper();
					helper.GetParameters(template, barCode, parameters);

					Barcode_print barCodePrinter = new Barcode_print(template, parameters);
					AdoptPrinter adopter = new AdoptPrinter(barCodePrinter.PrintDialog);
					adopter.PrintDPI = barCodePrinter.DesignFormData01.DPI;
					adopter.GetPrintSetting(CnasBaseData.MacAddress, 1);
					if (adopter.PrinterDialogResult == System.Windows.Forms.DialogResult.OK)
					{
						barCodePrinter.ShowDialog();
						adopter.SetBackToSystemDefaultPrint();
					}
				}
				else
				{
					result = "对不起！没有设置好条码的打印模版，请联系管理员";
				}
			}
			else
			{
				result = "对不起！没有设置好条码的打印模版，请联系管理员";
			}
			return result;
		}
	}
}
