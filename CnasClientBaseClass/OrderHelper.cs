using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseClassClient
{
	/// <summary>
	/// 订单帮助类
	/// </summary>
	public class OrderHelper
	{
		/// <summary>
		/// 是否 电话号码
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsPhone(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return false;
			}
			System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex("(\\(\\d{3,4}\\)|\\d{3,4}-|\\s)?\\d{7,14}");
			return reg1.IsMatch(str);
		}

		/// <summary>
		/// 订单上传图片类型
		/// </summary>
		/// <returns></returns>
		public static int GetUploadType()
		{
			return (int)EUploadType.Order;
		}

		/// <summary>
		/// 订单上传文件夹
		/// </summary>
		/// <returns></returns>
		public static string GetUploadFold()
		{
			return CnasUtilityTools.GetFolderName(EUploadType.Order);
		}

		/// <summary>
		/// 打印订单详情
		/// </summary>
		/// <param name="orderNum">订单号</param>
		/// <param name="batch">订单批次</param>
		/// <param name="printType">打印模板</param>
		public static void OrderPrint(string orderNum,string batch,string printXml)
		{
			//订单详情
			string customerName, locationName, orderName, instrumentCount, setCount, patientInfo;
			DataGridView dgv_orderDetail = StructureOrderDetailDgv(orderNum, batch, out customerName, out locationName, out orderName, out setCount, out instrumentCount, out patientInfo);

			string thingCount = string.Empty;
			if (BarCodeHelper.IsOrderOutSet(orderNum))
			{
				thingCount = string.Format("物品数量：{0}件", instrumentCount);
				orderName = string.Format("外来器械包名：{0}", orderName);
			}
			else
			{
				thingCount = string.Format("器械包数量： {0}个   物品数量：{1}件", setCount, instrumentCount);
				orderName = string.Format("订单名称： {0}", orderName);
			}

			PrintHelper.Instance.Print_DataGridView(dgv_orderDetail, printXml, orderNum, new string[] { customerName, locationName, orderName, thingCount, patientInfo});
		}

		/// <summary>
		/// 获取所有添加器械类型
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetSetInstrumentTypeItem(string orderType, bool isAddAll = true)
		{
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-create-order-template-type'");
			Dictionary<string, string> dic = new Dictionary<string, string>();
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string key_code = Convert.ToString(array[i]["key_code"]);
					string value_code = Convert.ToString(array[i]["value_code"]);
					if (!dic.ContainsKey(key_code))
					{
						if (orderType.Equals("BCC4O") && value_code.Equals("器械包"))
						{
							continue;
						}
						else
							dic.Add(key_code, value_code);
					}
				}
			}
			return dic;
		}

		/// <summary>
		/// 获取不带器械类型的类型
		/// </summary>
		/// <returns></returns>
		public static List<string> GetNoLabelInstrumentTypeItem()
		{
			List<string> dic = new List<string>();
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-nolabel-instrument-type' and key_code='nolabel'");
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string value_code = Convert.ToString(array[i]["value_code"]);
					string[] value_array = value_code.Split(',');
					foreach (string item in value_array)
					{
						if (!dic.Contains(item) && !string.IsNullOrEmpty(item))
						{
							dic.Add(item);
						}
					}
				}
			}
			return dic;
		}

		/// <summary>
		/// 获取不带器械类型的类型
		/// </summary>
		/// <returns></returns>
		public static  Dictionary<string, string> GetNoLabelInstrumentChildTypeItem()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-nolabel-instrument-type' and key_code='nolabel'");
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string value_code = Convert.ToString(array[i]["value_code"]);
					string[] value_array = value_code.Split(',');
					foreach (string item in value_array)
					{
						if (!dic.ContainsKey(item) && !string.IsNullOrEmpty(item))
						{
							dic.Add(item, string.Empty);
						}
					}
				}
			}
			return dic;
		}

		/// <summary>
		/// 需要处理的器械子类范围
		/// </summary>
		/// <returns></returns>
		public static string GetInstrumentChildTypeRange()
		{
			string instrumentRange = "0";
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-packset-dealinstrument-type'");
			if (array != null && array.Length > 0)
			{
				instrumentRange = string.Empty;
				string tempStr = Convert.ToString(array[0]["value_code"]);
				string[] str = tempStr.Split(',');
				for (int i = 0; i < str.Length; i++)
				{
					if (!string.IsNullOrEmpty(str[i]))
					{
						instrumentRange += "'" + str[i] + "',";

					}
				}
				if (string.IsNullOrEmpty(instrumentRange) || instrumentRange.Equals("''"))
				{
					instrumentRange = "0";
				}
			}
			if (instrumentRange.Length > 1)
			{
				instrumentRange = instrumentRange.Substring(0, instrumentRange.Length - ",".Length);
			}
			return instrumentRange;
		}

		/// <summary>
		/// 获取器械子类
		/// </summary>
		/// <returns></returns>
		public static  Dictionary<string, string> GetInstrumentChildTypeItem(bool isAddAll = true)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			if(isAddAll)
				dic.Add(string.Empty, "所有");
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string key_code = Convert.ToString(array[i]["key_code"]);
					string value_code = Convert.ToString(array[i]["value_code"]);
					if (!dic.ContainsKey(key_code))
					{
						dic.Add(key_code, value_code);
					}
				}
			}
			return dic;
		}
		
		/// <summary>
		/// 根据对应枚举值呈现名称
		/// </summary>
		/// <param name="type">器械类型</param>
		/// <param name="c_type">器械子类型</param>
		/// <param name="instrumentType">器械类型字典</param>
		/// <param name="childInstrumentType">器械子类型字典</param>
		/// <returns></returns>
		public static string GetEnumInstrumentTypeName(string type, string c_type,Dictionary<string,string> instrumentType,Dictionary<string,string> childInstrumentType)
		{
			if (type=="2")
			{
				if (instrumentType != null && instrumentType.Count > 0)
				{
					if (instrumentType.ContainsKey(type))
						return instrumentType[type];
					return type;
				}
				return type;
			}
			if(type=="1")
			{
				if (childInstrumentType != null && childInstrumentType.Count > 0)
				{
					if (childInstrumentType.ContainsKey(c_type))
					{
						return childInstrumentType[c_type];
					}
				}
				if (instrumentType != null && instrumentType.Count > 0)
				{
					if (instrumentType.ContainsKey(type))
						return instrumentType[type];
				}
				return c_type;
			}
			return string.Empty;
		}

		/// <summary>
		/// 构造订单详情dgv
		/// </summary>
		/// <param name="orderNum">订单号</param>
		/// <param name="batch">批次号</param>
		/// <param name="customerName">客户名称</param>
		/// <param name="locationName">使用地点</param>
		/// <returns></returns>
		private static DataGridView StructureOrderDetailDgv(string orderNum, string batch, out string customerName, out string locationName, out string setName, out string setCount, out string instrumentCount, out string patientInfo)
		{
			customerName = string.Empty;
			locationName = string.Empty;
			setName = string.Empty;
			patientInfo = string.Empty;
			DataGridView dgv_orderDetail = new DataGridView();
			dgv_orderDetail.AllowUserToAddRows = false;
			DataGridViewTextBoxColumn o_id = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_ca_name = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_codeType = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_num = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_remark = new DataGridViewTextBoxColumn();
			dgv_orderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
					o_id,
					o_ca_name,
					o_codeType,
					o_num,
					o_remark,
					});
			// 
			// 序号o_id 
			// 
			o_id.HeaderText = " 序号";
			o_id.Name = "o_id";
			// 
			// 器械名称o_ca_name
			// 
			o_ca_name.HeaderText = "品名";
			o_ca_name.Name = "o_ca_name";
			// 
			// 类型 o_codeType
			// 
			o_codeType.HeaderText = "类型";
			o_codeType.Name = "o_codeType";
			// 
			// 数量o_num
			// 
			o_num.HeaderText = "数量";
			o_num.Name = "o_num";
			// 
			//  备注o_remark 
			// 
			o_remark.HeaderText = "备注";
			o_remark.Name = "o_remark";

			int setNum = 0;
			int instrumentNum = 0;
			if (!string.IsNullOrEmpty(orderNum) && !string.IsNullOrEmpty(batch))
			{
				SortedList condition = new SortedList();
				condition.Add(1, orderNum);
				condition.Add(2, batch);
				condition.Add(3, orderNum);
				condition.Add(4, batch);
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec002", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec002", condition);
				if (data != null && data.Rows.Count > 0)
				{
					customerName =Convert.ToString(data.Rows[0]["cu_name"]);
					locationName = Convert.ToString(data.Rows[0]["u_uname"]);
					setName = Convert.ToString(data.Rows[0]["ca_name"]);
					Dictionary<string, string> dicInstrument = GetSetInstrumentTypeItem(string.Empty);
					Dictionary<string, string> dicChildInstrument = GetInstrumentChildTypeItem();

					for (int i = 0; i < data.Rows.Count; i++)
					{
						int index = dgv_orderDetail.Rows.Add();
						string str_codeType = Convert.ToString(data.Rows[i]["codeType"]);
						string str_c_codeType = Convert.ToString(data.Rows[i]["base_ca_type"]);
						dgv_orderDetail.Rows[index].Cells["o_id"].Value = index + 1;
						dgv_orderDetail.Rows[index].Cells["o_ca_name"].Value = data.Rows[i]["base_ca_name"];//base_ca_name
						dgv_orderDetail.Rows[index].Cells["o_codeType"].Value = GetEnumInstrumentTypeName(str_codeType,str_c_codeType,dicInstrument,dicChildInstrument);
						dgv_orderDetail.Rows[index].Cells["o_num"].Value = Convert.ToString(data.Rows[i]["instrument_count"]);
						dgv_orderDetail.Rows[index].Cells["o_remark"].Value = data.Rows[i]["remark"];
						int number = 0;
						int.TryParse(Convert.ToString(data.Rows[i]["instrument_count"]), out number);
						if (str_codeType == "2")
						{
							setNum += number;
						}
						else{
							 instrumentNum += number;
						}
					}
				}

				if (BarCodeHelper.IsOrderOutSet(orderNum))
				{
					condition.Clear();
					condition.Add(1, orderNum);
					condition.Add(2, batch);
					string personSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_person_info_sec001", condition);
					DataTable personData = reCnasRemotCall.RemotInterface.SelectData("HCS_person_info_sec001", condition);
					if (personData != null && personData.Rows.Count > 0)
					{
						patientInfo = string.Format("病人姓名：{0}  住 院 号：{1}", Convert.ToString(personData.Rows[0]["p_name"]), Convert.ToString(personData.Rows[0]["p_Number"]));
					}
				}
			}

			setCount = setNum.ToString();
			instrumentCount = instrumentNum.ToString();
			return dgv_orderDetail;
		}

		/// <summary>
		/// 构造签收单DataGridView的结构
		/// </summary>
		/// <returns></returns>
		public static DataGridView StructureForBackOrder()
		{
			DataGridView dgv_orderDetail = new DataGridView();
			dgv_orderDetail.AllowUserToAddRows = false;
			DataGridViewTextBoxColumn o_id = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_cu_name = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_u_uname = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_ca_name = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_codeType = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_num = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn o_remark = new DataGridViewTextBoxColumn();
			dgv_orderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
					o_id,
					//o_cu_name,
					//o_u_uname,
					o_ca_name,
					o_codeType,
					o_num,
					o_remark,
					});
			// 
			// 序号o_id 
			// 
			o_id.HeaderText = " 序号";
			o_id.Name = "o_id";
			// 
			// 客户名称 o_cu_name
			// 
			o_cu_name.HeaderText = "客户名称";
			o_cu_name.Name = "o_cu_name";
			// 
			// 科室o_u_uname
			// 
			o_u_uname.HeaderText = "科室";
			o_u_uname.Name = "o_u_uname";
			// 
			// 器械名称o_ca_name
			// 
			o_ca_name.HeaderText = "品名";
			o_ca_name.Name = "o_ca_name";
			// 
			// 类型 o_codeType
			// 
			o_codeType.HeaderText = "类型";
			o_codeType.Name = "o_codeType";
			// 
			// 数量o_num
			// 
			o_num.HeaderText = "数量";
			o_num.Name = "o_num";
			// 
			//  备注o_remark 
			// 
			o_remark.HeaderText = "备注";
			o_remark.Name = "o_remark";
			return dgv_orderDetail;
		}

		
		/// <summary>
		/// 生成有数据的DataGridView
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		/// <param name="customerName"></param>
		/// <param name="locationName"></param>
		/// <returns></returns>
		private static DataGridView StructureDataForBackOrder(string orderNum, string batch, out string customerName, out string locationName, out string patientInfo)
		{
			DataGridView forback = StructureForBackOrder();
			customerName = string.Empty;
			locationName = string.Empty;
			patientInfo = string.Empty;
			if (!string.IsNullOrEmpty(orderNum) && !string.IsNullOrEmpty(batch))
			{
				SortedList condition = new SortedList();
				condition.Add(1, orderNum);
				condition.Add(2, batch);
				condition.Add(3, orderNum);
				condition.Add(4, batch);
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec002", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec002", condition);
				if (data != null && data.Rows.Count > 0)
				{
					customerName = Convert.ToString(data.Rows[0]["cu_name"]);
					locationName = Convert.ToString(data.Rows[0]["u_uname"]);
					Dictionary<string, string> dicInstrument = GetSetInstrumentTypeItem(string.Empty);
					Dictionary<string, string> dicChildInstrument = GetInstrumentChildTypeItem();
					for (int i = 0; i < data.Rows.Count; i++)
					{
						int index = forback.Rows.Add();
						string str_codeType = Convert.ToString(data.Rows[i]["codeType"]);
						string str_c_codeType = Convert.ToString(data.Rows[i]["base_ca_type"]);
						forback.Rows[index].Cells["o_id"].Value = forback.RowCount;
						//forback.Rows[index].Cells["o_cu_name"].Value = customerName;
						//forback.Rows[index].Cells["o_u_uname"].Value = locationName;
						forback.Rows[index].Cells["o_ca_name"].Value = data.Rows[i]["base_ca_name"];//base_ca_name
						forback.Rows[index].Cells["o_codeType"].Value = GetEnumInstrumentTypeName(str_codeType, str_c_codeType, dicInstrument, dicChildInstrument);
						forback.Rows[index].Cells["o_num"].Value = data.Rows[i]["instrument_count"];
						forback.Rows[index].Cells["o_remark"].Value = data.Rows[i]["remark"];
					}
				}

				if (BarCodeHelper.IsOrderOutSet(orderNum))
				{
					condition.Clear();
					condition.Add(1, orderNum);
					condition.Add(2, batch);
					string personSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_person_info_sec001", condition);
					DataTable personData = reCnasRemotCall.RemotInterface.SelectData("HCS_person_info_sec001", condition);
					if (personData != null && personData.Rows.Count > 0)
					{
						patientInfo = string.Format("病人姓名：{0}  住 院 号：{1}", Convert.ToString(personData.Rows[0]["p_name"]), Convert.ToString(personData.Rows[0]["p_Number"]));
					}
				}
			}


			return forback;
		}

		/// <summary>
		/// 打印签收单详情
		/// </summary>
		/// <param name="orderNum">订单号</param>
		/// <param name="batch">订单批次</param>
		/// <param name="printType">打印模板</param>
		public static void BackOrderPrint(string orderNum, string batch, string printXml)
		{
			string customerName, locationName, patientInfo;
			DataGridView grid = StructureDataForBackOrder(orderNum, batch, out customerName, out locationName, out patientInfo);
			PrintHelper.Instance.Print_DataGridView(grid, printXml, orderNum, new string[]{ customerName, locationName, patientInfo });
		}

		/// <summary>
		/// 所有临时种类
		/// </summary>
		/// <returns></returns>
		public static List<string> GetBcuPackForOrder()
		{
			List<string> bcuList = new List<string>() {"BCU", "BCU0T", "BCU1T", "BCU2T", "BCU3T", "BCU4T", "BCU0R", "BCU1R", "BCU2R" };//目前只5类
			return bcuList;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns></returns>
		public static string GetDescribeString(int type)
		{
			switch(type)
			{
				case 1: return string.Format("只能扫BCU0T,BCU1T,BCU2T,BCU3T,BCU4T,BCU1R,BCU2R中的一种");//扫临时包
				case 2: return string.Format("不能扫BCU0T,BCU1T,BCU2T,BCU3T,BCU4T,BCU1R,BCU2R中的一种");//扫标准包
				case 3: return string.Format("该订单不能绑定其它的包");//该订单不能绑定其它的包
				case 4: return string.Format("请绑定所有由该订单打包的包");//该订单不能绑定其它的包
				case 5: return string.Format("没有找到由该订单打包的包");//没有找到由该订单打包的包
				default: return string.Empty;
			}
		}

		/// <summary>
		/// 获取所有的流程
		/// </summary>
		/// <param name="systemId"></param>
		/// <returns></returns>
		public static SortedList GetAllPdCodeName(string systemId)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sl_allpd = new SortedList();
			SortedList pdCondition = new SortedList();
			pdCondition.Add(1, systemId);
			DataTable dtapppd = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", pdCondition);
			if (dtapppd != null)
			{
				for (int i = 0; i < dtapppd.Rows.Count; i++)
				{
					string tempPdCode = Convert.ToString(dtapppd.Rows[i]["pd_code"]);
					if (!sl_allpd.ContainsKey(tempPdCode))
						sl_allpd.Add(tempPdCode, Convert.ToString(dtapppd.Rows[i]["pd_name"]));
				}
			}
			return sl_allpd;
		}

		/// <summary>
		/// 所有处理状体
		/// </summary>
		/// <param name="isAddAll"></param>
		/// <returns></returns>
		public static Dictionary<string,string> GetAllHandleState(bool isAddAll=true)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			if (isAddAll) dic.Add("", "所有");
			dic.Add("0", "未完成");
			dic.Add("1", "已完成");
			return dic;
		}

		/// <summary>
		/// 获取处理状态枚举值
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetHandleStateType(string type)
		{
			if (type.Equals("0"))
			{
				return "未完成";
			}
			else if (type.Equals("1"))
			{
				return "已完成";
			}
			return string.Empty;
		}

		/// <summary>
		/// 获取所有订单类型
		/// </summary>
		/// <param name="isAddAll">是否添加所有</param>
		/// <returns></returns>
		public static Dictionary<string,string> GetOrderTypeItem(bool isAddAll=true)
		{
			Dictionary<string, string> orderTypedic = new Dictionary<string, string>();
			if(isAddAll)
				orderTypedic.Add("0", "所有");
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note'");
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string value_code = Convert.ToString(array[i]["value_code"]);
					string other_code = Convert.ToString(array[i]["other_code"]);
					if (!orderTypedic.ContainsKey(other_code))
					{
						orderTypedic.Add(other_code, value_code);
					}
				}
			}
			return orderTypedic;
		}

		/// <summary>
		/// 所有可处理的客户名称
		/// </summary>
		/// <param name="isAddAll"></param>
		/// <returns></returns>
		public static Dictionary<string,string> GetAllHandleCustomer(bool isAddAll=true)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			DataTable table = CnasBaseData.UserAccessCustomer; 
			if (table != null && table.Rows.Count > 0)
			{
				if(table.Rows.Count>1&&!dic.ContainsKey("0")&&isAddAll) dic.Add("0", "所有");
				for (int i = 0; i < table.Rows.Count; i++)
				{
					DataRow row = table.Rows[i];
					string tempBarCode = Convert.ToString(row["bar_code"]);
					string tempBarCode_Name = Convert.ToString(row["cu_name"]);
					if (!dic.ContainsKey(tempBarCode))
						dic.Add(tempBarCode, tempBarCode_Name);
				}
			}
			return dic;
		}

		/// <summary>
		/// 所有可处理的成本中心(暂未做)
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetAllHandleCostCenter(string getCustomerValue,bool isUseArea=false)
		{
			string str_sql = isUseArea ? "" : "";
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//客户名称、成本中心、使用地点的关联表
			SortedList condition = new SortedList();
			condition.Add(1, getCustomerValue);
			DataTable table = reCnasRemotCall.RemotInterface.SelectData(str_sql, condition);
			Dictionary<string, string> dic = new Dictionary<string, string>();
			if (table != null && table.Rows.Count > 0)
			{
				if (table.Rows.Count > 1)
					dic.Add("0", "所有");
				for (int i = 0; i < table.Rows.Count; i++)
				{
					string tempCostBar_code = Convert.ToString(table.Rows[i]["cost_bar_code"]);
					string tempCostBar_code_Name = Convert.ToString(table.Rows[i]["ca_name"]);
					if (!dic.ContainsKey(tempCostBar_code))
						dic.Add(tempCostBar_code, tempCostBar_code_Name);
				}
			}
			
			return dic;
		}

		/// <summary>
		/// 所有可处理的使用地点
		/// </summary>
		/// <param name="getCustomerValue">客户编码</param>
		/// <param name="isUseArea">是否是使用区</param>
		/// <param name="isAddAll">是否需要所有</param>
		/// <param name="NeedAllLocationId">当客户编码为所有时是否需要所有locationId</param>
		/// <returns></returns>
		public static Dictionary<string, string> GetAllHandleLocation(string getCustomerValue, bool isUseArea = false, bool isAddAll = true,bool NeedAllLocationId=false)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			bool isAllCust=getCustomerValue=="0"||string.IsNullOrEmpty(getCustomerValue);
			if(isAllCust&&isAddAll)
			{
				dic.Add("0", "所有");
			}
			SortedList condition = new SortedList();
			string str_sql = string.Empty;
			if (!NeedAllLocationId)
			{
				str_sql = "HCS-use-location-sec012";
				if (isUseArea) { 
					str_sql =  "HCS-use-location-sec013";
					condition.Add(1, CnasBaseData.UserBaseInfo.UserID);
					condition.Add(2, getCustomerValue); 
				}
				if (!isUseArea) {
					str_sql = "HCS-use-location-sec012";
					condition.Add(1, getCustomerValue); 
				}
			}
			if (isAllCust && NeedAllLocationId)
			{
				str_sql = "HCS-use-location-sec014";
				condition.Add(1, CnasBaseData.UserBaseInfo.UserID);
			}
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//客户名称、成本中心、使用地点的关联表
			//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData(str_sql, condition);
			DataTable table = reCnasRemotCall.RemotInterface.SelectData(str_sql, condition);
			if (table != null && table.Rows.Count > 0)
			{
				if (table.Rows.Count > 1 && !dic.ContainsKey("0")&&isAddAll)
					dic.Add("0", "所有");
				if(table.Rows.Count==1&&dic.ContainsKey("0"))
					dic.Remove("0");
				for (int i = 0; i < table.Rows.Count; i++)
				{
					string tempBar_code = Convert.ToString(table.Rows[i]["u_barcode"]);//使用地点条码
					string LocationName = Convert.ToString(table.Rows[i]["u_uname"]);//使用地点名称
					string str_id = Convert.ToString(table.Rows[i]["id"]);//使用地点id
					if (!dic.ContainsKey(str_id))
						dic.Add(str_id, LocationName);
						//dic.Add(str_id, CnasUtilityTools.ConcatTwoString(LocationName, tempBar_code));
				}
			}
			
			return dic;
		}

		/// <summary>
		/// 获取value_code
		/// </summary>
		/// <param name="typeCode"></param>
		/// <param name="keyCode"></param>
		/// <returns></returns>
		public static  string GetValueCode(string typeCode, string keyCode)
		{
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='" + typeCode + "' and key_code='" + keyCode + "'");
			if (array != null && array.Length > 0)
			{
				return Convert.ToString(array[0]["value_code"]).TrimEnd(',');
			}
			return string.Empty;
		}

		/// <summary>
		/// 订单类型转换呈现
		/// </summary>
		/// <param name="orderType"></param>
		/// <returns></returns>
		public static string InitDgvDataOrderType(Dictionary<string,string> dic,string orderType)
		{
			if (dic != null && dic.Count > 0)
			{
				if (dic.ContainsKey(orderType))
				{
					return dic[orderType];
				}
				return orderType;
			}
			return orderType;
		}


		/// <summary>
		/// 将dic的key值拼接成一个范围值(用于sql查询)
		/// </summary>
		/// <param name="dic"></param>
		/// <returns></returns>
		public static string GetDicToArrangeStr(Dictionary<string,string> dic)
		{
			if(dic!=null&&dic.Count>0)
			{
				string temp_Str = string.Empty;
				foreach(KeyValuePair<string,string> item in dic)
				{
					if(item.Key!="0")
						temp_Str += item.Key+ "','";
				}
				if(!string.IsNullOrEmpty(temp_Str))
				{
					temp_Str = temp_Str.Substring(0, temp_Str.Length - "','".Length);
				}
				return temp_Str;
			}
			return string.Empty;
		}

		/// <summary>
		/// 获取使用地点对应的信息
		/// </summary>
		/// <param name="locatinonId">使用地点id</param>
		/// <returns></returns>
		public static DataTable GetTableByLocationId(string locatinonId)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//获取当前使用者的对应的客户中心,科室
			SortedList condition = new SortedList();
			condition.Add(1, locatinonId);
			condition.Add(2, CnasBaseData.SystemID);
			condition.Add(3, CnasBaseData.SystemID);
			try
			{
				return reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec007", condition);
			}
			catch
			{
				return null;
			}
		}
	}
}
