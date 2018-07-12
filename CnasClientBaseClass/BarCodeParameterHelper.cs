using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cnas.wns.CnasBaseClassClient
{
	public class BarCodeParameterHelper
	{
		public void GetParameters(string xml, string barCode, SortedList parametersUI)
		{
			SortedList parameters = new SortedList();
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(xml);
				string parameterList = string.Empty;
				string parameterName = string.Empty; 
				string parameterValue = string.Empty;
				if (!parametersUI.ContainsKey("P014"))
					parametersUI.Add("P014", barCode);
				XmlNodeList BarcodeAddDataXML = xmlDoc.SelectNodes("/Data/BarcodeAddData/BarcodeAdd");
				for (int i = 0; i < BarcodeAddDataXML.Count; i++)
				{
					parameterName = BarcodeAddDataXML[i]["Name"].InnerXml;
					if (!parametersUI.ContainsKey(parameterName))
					{
						string labelValue = GetParameterLabelValue(barCode, parameterName);
						if (string.IsNullOrEmpty(labelValue))
							parameterList += string.Format("{0},", parameterName);
						else
							parametersUI.Add(parameterName, labelValue);
					}
				}

				GetParameterFormDB(barCode, parameterList, ref parametersUI);

			}
			catch (Exception)
			{
			}
		}



		private SortedList GetParameterFormDB(string barCode, string parameterList, ref SortedList parametersList)
		{
			SortedList parameters = new SortedList();
			try
			{
				if (!string.IsNullOrEmpty(parameterList))
				{
					string[] parames = parameterList.Split(',');

					CnasRemotCall remoteCall = new CnasRemotCall();
					SortedList condition = new SortedList();

					condition.Add("parameters", parameterList);
					condition.Add("barcodeP", barCode);
					DataSet data = remoteCall.RemotInterface.ExecuteProcedure("Proc_GetBarCodeParameters", condition);

					if (data != null)
					{
						foreach (string param in parames)
						{
							if (!string.IsNullOrEmpty(param))
							{
								DataTable dataTable = null;
								foreach (DataTable table in data.Tables)
								{
									if (table.Columns.Contains(string.Format("{0}Value", param)))
									{
										dataTable = table;
										break;
									}
								}

								if (dataTable != null)
								{
									string value = GetParameterValue(param, dataTable);
									if (!string.IsNullOrEmpty(value))
									{
										parameters.Add(param, value);
										if (!parametersList.ContainsKey(param))
											parametersList.Add(param, value);
									}
								}
							}
						}
					}
				}

				return parameters;
			}
			catch (Exception)
			{
				return parameters;
			}
		}

		private string GetParameterValue(string param, DataTable dataTable)
		{
			string result = null;
			if (!string.IsNullOrEmpty(param) && dataTable != null && dataTable.Rows.Count > 0)
			{
				switch (param)
				{
					case "P013":
					case "P015":
					case "P016":
					case "P017":
					case "P018":
					case "P019":
					case "P020":
					case "P022":
					case "P023":
					case "P024":
					case "P026":
						{
							result = Convert.ToString(dataTable.Rows[0][string.Format("{0}Value", param)]);
						}
						break;
					case "P021":
						{
							int index = 1;
							int rowCount = 3;
							Dictionary<int, string> instrumentCount = new Dictionary<int, string>();
							int maxLength = 0;

							foreach (DataRow row in dataTable.Rows)
							{
								string instrumentInfo = string.Format("{0} *{1}  ", Convert.ToString(row["ca_name"]), Convert.ToString(row["number"]));
								int stringLength = System.Text.Encoding.Default.GetBytes(instrumentInfo).Length;
								if (maxLength < stringLength)
									maxLength = stringLength;
							}

							foreach (DataRow row in dataTable.Rows)
							{
								int number = Convert.ToInt32(row["number"]);
								string name = Convert.ToString(row["ca_name"]);
								string instrumentInfo = string.Format("{0} *{1}", name, number);
								int stringLength = System.Text.Encoding.Default.GetBytes(instrumentInfo).Length;
								instrumentInfo = instrumentInfo + "".PadRight(maxLength - stringLength, ' ');

								result += instrumentInfo;
								if (index % rowCount == 0)
									result += "\r\n";
								index++;
							}
						}
						break;
					default:
						break;
				}
			}
			return result;
		}

		private string GetParameterLabelValue(string barCode, string param)
		{
			string result = null;
			switch (param)
			{
				case "P001":
					if (barCode.StartsWith("BCB"))
						result = "用 户 名:";
					else if (barCode.StartsWith("BCC") || barCode.StartsWith("BCU"))
						result = "器械包名:";
					else if (barCode.StartsWith("BCD"))
						result = "运输车名:";
					else if (barCode.StartsWith("BCP"))
						result = "程 序 名:";
					else if (barCode.StartsWith("BCS"))
						result = "存储点名:";
					else if (barCode.StartsWith("BCV"))
						result = "流程编码:";
					else if (barCode.StartsWith("BCW"))
						result = "清洗机名:";
					else if (barCode.StartsWith("BCX"))
						result = "控制条码:";
					else if (barCode.StartsWith("BCZ"))
						result = "灭菌器名:";
					break;
				case "P002":
					result = "条 码:";
					break;
				case "P003":
					result = "客户名称:";
					break;
				case "P004":
					result = "科 室:";
					break;
				case "P005":
					result = "生产日期:";
					break;
				case "P006":
					result = "失效日期:";
					break;
				case "P007":
					result = "包装员名:";
					break;
				case "P008":
					result = "审核员名:";
					break;
				case "P009":
					result = "包装列表:";
					break;
				case "P010":
					result = "包 类 型:";
					break;
				case "P011":
					result = "分 包:";
					break;
				case "P012":
					result = "包优先值:";
					break;
				default:
					break;
			}
			return result;
		}

	}
}
