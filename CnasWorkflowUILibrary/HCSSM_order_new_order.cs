using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasMetroFramework.Forms;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	
	public partial class HCSSM_order_new_order : MetroForm
	{
		//public ILog Logger = LogManager.GetLogger("CnasWNSClient");

		/// <summary>
		/// 供应商信息id
		/// </summary>
		private int vinfoid = 0;
		/// <summary>
		/// 病人id
		/// </summary>
		private int pid=0;
		/// <summary>
		/// 区域id
		/// </summary>
		private string _inappid;
		/// <summary>
		/// 表示是否第一次加载
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 器械
		/// </summary>
		private DataTable _dtInstrument = new DataTable();
		/// <summary>
		/// 订单模板
		/// </summary>
		private DataTable _dtInstrumentMould = new DataTable();
		/// <summary>
		/// 订单包
		/// </summary>
		private DataTable _dtBaseSet = new DataTable();
		/// <summary>
		/// 添加类型
		/// </summary>
		private Dictionary<string, string> _dicInstrumentType=new Dictionary<string,string>();
		/// <summary>
		/// 添加子类型
		/// </summary>
		private Dictionary<string, string> _dicChildInstrumentType=new Dictionary<string,string>();
		/// <summary>
		/// 使用地点名称
		/// </summary>
		private string _locationName = string.Empty;
		/// <summary>
		/// 使用地点id
		/// </summary>
		private string _location_id = string.Empty;
		/// <summary>
		/// 成本中心编码
		/// </summary>
		private string _costbar_code = string.Empty;
		/// <summary>
		/// 客户编码
		/// </summary>
		private string _customer_barcode = string.Empty;
		/// <summary>
		///  订单号
		/// </summary>
		private string _orderNum = string.Empty;
		/// <summary>
		/// 订单类型
		/// </summary>
		private string _orderType = string.Empty;
		/// <summary>
		/// 序列号
		/// </summary>
		private string _tempNumber = string.Empty;
		/// <summary>
		/// 切换时产生加入旧的guid
		/// </summary>
		private Dictionary<string, string> oldFile_Guid = new Dictionary<string, string>();
		/// <summary>
		/// 
		/// </summary>
		private Guid nowGuid=Guid.NewGuid();
		private string _batch = string.Empty;

		/// <summary>
		/// 添加图片确认时队列
		/// </summary>
		private Dictionary<string, string> nowFile_Guid = new Dictionary<string, string>();

		/// <summary>
		/// 临时存储客户编码
		/// </summary>
		private string _custbar_code = string.Empty;
		/// <summary>
		/// 物品类型
		/// </summary>
		private string _tempInstrumentType = string.Empty;
		/// <summary>
		/// 物品类型
		/// </summary>
		private string _temp_c_InstrumentType = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public HCSSM_order_new_order()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 带区域初始化
		/// </summary>
		/// <param name="inappid"></param>
		public HCSSM_order_new_order(string inappid):this()
		{
			_inappid = inappid;
		}
		/// <summary>
		/// 获取combox数据
		/// </summary>
		private void InitComboxData()
		{
			SetComCustomerItem();
			SetComLocationItem();
			SetOrderTypeItem();
			string getOrderType = GetSelectComBoBox(cbbOrderType, 1);
			SetInstrumentTypeItem(getOrderType);
			SetChildInstrumentTypeItem();
		}

		/// <summary>
		/// 每次更改类型更改文件记录
		/// </summary>
		private void ChangeFileGuid()
		{
			nowGuid = Guid.NewGuid();
			if(nowFile_Guid!=null&&nowFile_Guid.Count>0&&oldFile_Guid!=null)
			{
				foreach(KeyValuePair<string,string> item in nowFile_Guid)
				{
					if(!oldFile_Guid.ContainsKey(item.Key))
					{
						oldFile_Guid.Add(item.Key, item.Value);
					}
				}
			}
			nowFile_Guid = new Dictionary<string, string>();
		}

		/// <summary>
		/// 绑定器械子类
		/// </summary>
		private void SetChildInstrumentTypeItem()
		{
			_dicChildInstrumentType = OrderHelper.GetInstrumentChildTypeItem();
			DicBindCbb(cbbAddType, _dicChildInstrumentType);
		}

		/// <summary>
		/// 设置要添加的器械类型
		/// </summary>
		private void SetInstrumentTypeItem(string orderType)
		{
			if (cbbIntrumentType.Items.Count > 0) cbbIntrumentType.Items.Clear();
			_dicInstrumentType = OrderHelper.GetSetInstrumentTypeItem(orderType);
			DicBindCbb(cbbIntrumentType, _dicInstrumentType);
		}

		/// <summary>
		/// 设置要添加的订单类型
		/// </summary>
		private void SetOrderTypeItem()
		{
			Dictionary<string,string> orderTypedic = OrderHelper.GetOrderTypeItem(false);
			DicBindCbb(cbbOrderType,orderTypedic);
		}

		/// <summary>
		/// 器械
		/// </summary>
		/// <param name="orderType"></param>
		/// <param name="c_type"></param>
		private void LoadData_dtInstrument(string orderType,string c_type)
		{
			cbbAddType.Enabled = true;
			dgv_Instrument.MultiSelect = true;
			if (_dtInstrument == null || (_dtInstrument != null && _dtInstrument.Rows.Count == 0))
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, 1);//状态
				//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-info-sec003", condition);
				_dtInstrument = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-info-sec003", condition);
			}
			SetDgvInstrument(_dtInstrument, 1, orderType, c_type);
		}

		/// <summary>
		/// 订单包
		/// </summary>
		/// <param name="orderType"></param>
		private void LoadData_dtBaseSet(string orderType)
		{
			cbbAddType.Enabled = false;
			dgv_Instrument.MultiSelect = true;
			if (_dtBaseSet == null || (_dtBaseSet != null && _dtBaseSet.Rows.Count == 0))
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, 1);//状态
				condition.Add(3, 1); //订单基本包
				//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs-set-base-sec016", condition);
				_dtBaseSet = reCnasRemotCall.RemotInterface.SelectData("hcs-set-base-sec016", condition);
			}
			SetDgvInstrument(_dtBaseSet, 2, orderType);
		}

		/// <summary>
		/// 模板
		/// </summary>
		/// <param name="orderType"></param>
		private void LoadData_dtInstrumentMould(string orderType)
		{
			cbbAddType.Enabled = false;
			dgv_Instrument.MultiSelect = false;
			dgv_order.Rows.Clear(); DisplayNumByDgv();
			if (_dtInstrumentMould == null || (_dtInstrumentMould != null && _dtInstrumentMould.Rows.Count == 0))
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.SystemID);
				condition.Add(2, 1);//状态
				string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-tem-instrument-info-sec001", condition);
				_dtInstrumentMould = reCnasRemotCall.RemotInterface.SelectData("HCS-tem-instrument-info-sec001", condition);
			}
			SetDgvInstrument(_dtInstrumentMould, 3, orderType);
		}

		/// <summary>
		/// 加载器械、基本包、模板列表
		/// </summary>
		/// <param name="type"></param>
		private void LoadData(string type,string orderType,string c_type="")
		{
			switch(type)
			{
				case "1":LoadData_dtInstrument(orderType, c_type);break;
				case "2": LoadData_dtBaseSet(orderType);break;
				case "3": LoadData_dtInstrumentMould(orderType); break;
				default: break;
			}
		}

		/// <summary>
		/// 设置器械、基本包、模板
		/// </summary>
		/// <param name="table"></param>
		/// <param name="type"></param>
		private void SetDgvInstrument(DataTable table,int type,string orderType,string c_type="")
		{
			//客户名称
			string getCustomerValue = GetSelectComBoBox(cbbCust, 1);
			string getlocationId = GetSelectComBoBox(cbbLocationType, 1);
			string locationCostCenter = string.Empty;
			//CSSD 成本中心
			string cssdBar_code = string.Empty;
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-CSSD-costcenter'");
			if(array!=null&&array.Length>0)
			{
				cssdBar_code = Convert.ToString(array[0]["value_code"]);
				cssdBar_code ="'"+ cssdBar_code.Replace(",", "','");
				if (cssdBar_code.Length > 3)
				{
					cssdBar_code = cssdBar_code.Substring(0, cssdBar_code.Length - ",'".Length);
				}
				else
				{
					cssdBar_code = "''";
				}
			}
			if (table != null && table.Rows.Count > 0)
			{
				switch(type)
				{
					case 1:
						{
							if (_custbar_code == getCustomerValue && _tempInstrumentType == type.ToString() && _temp_c_InstrumentType == c_type)
							{ return; }
							if (_tempInstrumentType != type.ToString() || _temp_c_InstrumentType != c_type)
							{
								dgv_Instrument.Rows.Clear();
							}
							_temp_c_InstrumentType = c_type;
							_tempInstrumentType = type.ToString();
							if(_custbar_code!=getCustomerValue)
							{
								_custbar_code = getCustomerValue;
							}
							SetDgv_dtInstrument(table, getCustomerValue, 1, c_type);
							break;
						}
					case 2:
						{
							_tempInstrumentType = type.ToString();
							dgv_Instrument.Rows.Clear();
							DataTable data = OrderHelper.GetTableByLocationId(getlocationId);
							if (data != null && data.Rows.Count > 0)
							{
								locationCostCenter = Convert.ToString(data.Rows[0]["cost_bar_code"]);
							}
							SetDgv_dtBaseSet(table, getCustomerValue, locationCostCenter, cssdBar_code, type, c_type);
							break;
						}
					case 3:
						{
							_tempInstrumentType = type.ToString();
							dgv_Instrument.Rows.Clear();
							DataTable data = OrderHelper.GetTableByLocationId(getlocationId);
							if (data != null && data.Rows.Count > 0)
							{
								locationCostCenter = Convert.ToString(data.Rows[0]["cost_bar_code"]);
							}
							SetDgv_dtInstrumentMould(table, getCustomerValue, locationCostCenter, cssdBar_code, orderType, 3, c_type);
							break;
						}
					default: break;
				}
			}
			else
			{
				dgv_Instrument.Rows.Clear();
			}
		}

		/// <summary>
		/// 模板-add
		/// </summary>
		/// <param name="table"></param>
		/// <param name="getCustomerValue"></param>
		/// <param name="locationCostCenter"></param>
		/// <param name="cssdBar_code"></param>
		/// <param name="orderType"></param>
		/// <param name="type"></param>
		/// <param name="c_type"></param>
		private void SetDgv_dtInstrumentMould(DataTable table, string getCustomerValue,string locationCostCenter,string cssdBar_code, string orderType, int type, string c_type)
		{
			dgv_Instrument.Columns["cost_ca_name"].Visible = true;
			if (table != null && table.Rows.Count > 0)
			{
				string tempId = string.Empty;
				string tempName = string.Empty;
				string idRange = "(";
				if (orderType.Equals("BCC4O")||orderType.Equals("BCC3O"))//BCC3O暂未去除
				{
					DataRow[] setArrayRow = table.Select("type=2");
					if (setArrayRow != null && setArrayRow.Length > 0)
					{
						for (int i = 0; i < setArrayRow.Length; i++)
						{
							if (i < setArrayRow.Length - 1)
								idRange += string.Format("'{0}',", Convert.ToString(setArrayRow[i]["id"]).Trim());
							else
								idRange += string.Format("'{0}'", Convert.ToString(setArrayRow[i]["id"]).Trim());
						}
					}
				}
				idRange += ")";
				string tempconSql = "id not in " + idRange + "and ( ( customer_barcode='" + getCustomerValue + "' and cost_center in ('" + locationCostCenter + "') ) or cost_center in (" + cssdBar_code + "))";
				if (idRange.Equals("()"))
				{
					tempconSql = "( ( customer_barcode='" + getCustomerValue + "' and cost_center in ('" + locationCostCenter + "') ) or cost_center in (" + cssdBar_code + "))";
				}
				DataRow[] arrayRow = table.Select(tempconSql);
				if (arrayRow != null && arrayRow.Length > 0)
				{
					for (int i = 0; i < arrayRow.Length; i++)
					{
						DataRow row = arrayRow[i];
						string tempRowId = Convert.ToString(row["id"]);
						string tempRowName = Convert.ToString(row["name"]);
						if (tempId != tempRowId && tempName != tempRowName)
						{
							tempId = tempRowId;
							tempName = tempRowName;
							int index = dgv_Instrument.Rows.Add();
							dgv_Instrument.Rows[index].Cells["bid"].Value = tempRowId;
							dgv_Instrument.Rows[index].Cells["bca_name"].Value = tempRowName;
							dgv_Instrument.Rows[index].Cells["c_instrument_type"].Value = Convert.ToString(row["ca_type"]);
							dgv_Instrument.Rows[index].Cells["instrument_type"].Value = type;
							dgv_Instrument.Rows[index].Cells["cost_ca_name"].Value = row["cost_ca_name"];
							dgv_Instrument.Rows[index].Cells["instrument_type_name"].Value = OrderHelper.GetEnumInstrumentTypeName(type.ToString(), string.Empty, _dicInstrumentType, _dicChildInstrumentType);
						}
					}
					dgv_Instrument.ClearSelection();
				}
			}
		}

		/// <summary>
		/// 订单包-add
		/// </summary>
		/// <param name="table"></param>
		/// <param name="getCustomerValue"></param>
		/// <param name="locationCostCenter"></param>
		/// <param name="type"></param>
		/// <param name="c_type"></param>
		private void SetDgv_dtBaseSet(DataTable table, string getCustomerValue,string locationCostCenter,string cssdBar_code, int type, string c_type)
		{
			dgv_Instrument.Columns["cost_ca_name"].Visible = true;
			string tempSql = "( ( customer_code='" + getCustomerValue + "' and cost_center in ('" + locationCostCenter + "') ) or cost_center in (" + cssdBar_code + "))";
			DataRow[] arrayRow = table.Select(tempSql);
			if (arrayRow != null && arrayRow.Length > 0)
			{
				for (int i = 0; i < arrayRow.Length; i++)
				{
					DataRow row = arrayRow[i];
					int index = dgv_Instrument.Rows.Add();
					dgv_Instrument.Rows[index].Cells["bid"].Value = Convert.ToString(row["id"]);
					dgv_Instrument.Rows[index].Cells["bca_name"].Value = Convert.ToString(row["ca_name"]);
					//dgv_Instrument.Rows[index].Cells["c_instrument_type"].Value = string.Empty;
					dgv_Instrument.Rows[index].Cells["instrument_type"].Value = type;
					dgv_Instrument.Rows[index].Cells["cost_ca_name"].Value = row["cost_ca_name"];
					dgv_Instrument.Rows[index].Cells["instrument_type_name"].Value = OrderHelper.GetEnumInstrumentTypeName(type.ToString(), string.Empty, _dicInstrumentType, _dicChildInstrumentType);
					//GetEnumInstrumentTypeName(type, c_type);
				}
			}
		}

		/// <summary>
		/// 器械-add
		/// </summary>
		/// <param name="table"></param>
		/// <param name="getCustomerValue"></param>
		/// <param name="type"></param>
		/// <param name="c_type"></param>
		private void SetDgv_dtInstrument(DataTable table, string getCustomerValue, int type, string c_type)
		{
			//string tempSql = "( ( ca_customer='" + getCustomerValue + "' and cost_center in ('" + locationCostCenter + "') ) or cost_center in (" + cssdBar_code + "))";
			string tempSql = "ca_customer='" + getCustomerValue + "'";
			if (!string.IsNullOrEmpty(c_type))
			{
				tempSql = "ca_type='" + c_type + "' and " + tempSql;
			}
			DataRow[] arrayRow = table.Select(tempSql);
			dgv_Instrument.Columns["cost_ca_name"].Visible = false;
			if (arrayRow != null && arrayRow.Length > 0)
			{
				for (int i = 0; i < arrayRow.Length; i++)
				{
					DataRow row = arrayRow[i];
					int index = dgv_Instrument.Rows.Add();
					dgv_Instrument.Rows[index].Cells["bid"].Value = Convert.ToString(row["id"]);
					dgv_Instrument.Rows[index].Cells["bca_name"].Value = Convert.ToString(row["ca_name"]);
					dgv_Instrument.Rows[index].Cells["c_instrument_type"].Value = Convert.ToString(row["ca_type"]);
					dgv_Instrument.Rows[index].Cells["instrument_type"].Value = type;
					dgv_Instrument.Rows[index].Cells["cost_ca_name"].Value = row["cost_ca_name"];
					dgv_Instrument.Rows[index].Cells["instrument_type_name"].Value = OrderHelper.GetEnumInstrumentTypeName(type.ToString(), Convert.ToString(row["ca_type"]), _dicInstrumentType, _dicChildInstrumentType);
				}
			}
		}

		/// <summary>
		/// 仅仅设置客户名称
		/// </summary>
		private void SetComCustomerItem()
		{
			Dictionary<string, string> dic = OrderHelper.GetAllHandleCustomer(false);
			DicBindCbb(cbbCust, dic);
		}

		/// <summary>
		/// 客户编码更改设置对应的科室
		/// </summary>
		/// <param name="custbarcode"></param>
		private void SetComLocationItem()
		{
			cbbLocationType.Items.Clear();
			string customer_barcode = GetSelectComBoBox(cbbCust, 1);
			if (!string.IsNullOrEmpty(customer_barcode))
			{
				Dictionary<string,string> locationDic = OrderHelper.GetAllHandleLocation(customer_barcode, _inappid == "1050",false);
				DicBindCbb(cbbLocationType, locationDic);
			}
		}

		/// <summary>
		/// 客户中心更改引发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbCust_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				SetComLocationItem();
			}
		}

		/// <summary>
		/// 选择类型更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbIntrumentType_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				if (cbbIntrumentType.Items != null && cbbIntrumentType.Items.Count > 0 && cbbIntrumentType.SelectedItem != null)
				{
					KeyValuePair<string, string> obj = (KeyValuePair<string, string>)cbbIntrumentType.SelectedItem;
					string instrumentType = obj.Key;
					string getOrderType = GetSelectComBoBox(cbbOrderType, 1);
					string c_instrumentType = GetSelectComBoBox(cbbAddType, 1);
					LoadData(instrumentType, getOrderType, c_instrumentType);
				}
			}
		}

		/// <summary>
		/// 生成订单号
		/// </summary>
		/// <returns></returns>
		private bool GetOrderNum()
		{
			if(cbbOrderType.SelectedItem!=null&&cbbOrderType.SelectedItem is KeyValuePair<string,string>)
			{
				string orderType_Name = string.Empty;
				string cust_Name = GetSelectComBoBox(cbbCust, 2);
				_customer_barcode = GetSelectComBoBox(cbbCust, 1);
				_location_id = GetSelectComBoBox(cbbLocationType, 1);
				if (string.IsNullOrEmpty(_location_id))
				{
					MessageBox.Show("对不起,没有可选科室无法生成订单");
					return false;
				}
				if (!string.IsNullOrEmpty(_location_id))
				{
					DataTable data = OrderHelper.GetTableByLocationId(_location_id);
					if (data != null && data.Rows.Count > 0)
					{
						_costbar_code = Convert.ToString(data.Rows[0]["cost_bar_code"]);
						_locationName = Convert.ToString(data.Rows[0]["u_uname"]);
					}
				}
				bool isNeedNewNumber = false;
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbbOrderType.SelectedItem;
				string tempOrderType = item.Key;
				bool isOutOrder = tempOrderType == "BCC4O";
				if (isOutOrder&&string.IsNullOrEmpty(txtOrderName.Text.Trim()))
				{
					MessageBox.Show("对不起,订单名称不能为空");//暂未在hcs_dialog_message里添加这些信息等后续完善
					return false;
				}
				orderType_Name = item.Value;
				_orderType = tempOrderType;
				if(string.IsNullOrEmpty(_orderNum))
				{
					isNeedNewNumber = true;
				}
				if(!string.IsNullOrEmpty(_orderNum))
				{
					string temp_type = _orderNum.Length > 5 ? _orderNum.Substring(0, 5) : _orderNum;
					if(temp_type!=_orderType)
					{
						isNeedNewNumber = true;
					}
				}
				if (isNeedNewNumber)
				{
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					int bccNumber = reCnasRemotCall.RemotInterface.GetSerialNumber(1, tempOrderType);
					if (bccNumber <= 0)
					{
						_tempNumber = "1";
					}
					else
					{
						_tempNumber = bccNumber.ToString();
					}
					string number = tempOrderType + _tempNumber.PadLeft(8, '0');
					_orderNum = number;
					if (!isOutOrder && string.IsNullOrEmpty(txtOrderName.Text.Trim()))
						txtOrderName.Text = orderType_Name + "-" + _tempNumber;
				}
				return true;
			}
			MessageBox.Show("对不起,没有订单类型");
			//_orderName = cust_Name + (string.IsNullOrEmpty(_location_id) ? "" : "-" + _locationName) + (string.IsNullOrEmpty(orderType_Name) ? "" : "-" + orderType_Name) + "-" + _tempNumber;
			return false;
		}

		/// <summary>
		/// 提交订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSave_Click(object sender, EventArgs e)
		{
			if(!GetOrderNum())
			{
				return ;
			}
			if (!string.IsNullOrEmpty(_orderNum))
			{
				if (string.IsNullOrEmpty(_orderNum))
				{
					//没有有效的订单号
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillselectordername", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (_orderNum.Length > 5 && dgv_order.Rows != null && dgv_order.Rows.Count > 0)
				{
					string batch = Guid.NewGuid().ToString();
					_batch = batch;//批次
					string wf_code = CnasBaseDataHelper.Wf_SingleValue("HCS-procedure-data", "Modify_order_wf");
					if (_orderType.Equals("BCC2O"))
					{
						wf_code = CnasBaseDataHelper.Wf_SingleValue("HCS-procedure-data", "Order_without_entity_wf");
					}
					SortedList input01 = new SortedList();
					SortedList input02 = new SortedList();
					SortedList up_barcode = new SortedList();
					SortedList de_barcode = new SortedList();
					string item_value_arr = string.Empty;
					foreach(string item_value in nowFile_Guid.Values)
					{
						item_value_arr += item_value + "','";
					}
					if(!string.IsNullOrEmpty(item_value_arr))
					{
						item_value_arr = item_value_arr.Substring(0, item_value_arr.Length - "','".Length);
						SortedList par_up_barcode = new SortedList();
						par_up_barcode.Add(1, _orderNum);//up ordernum
						par_up_barcode.Add(2, 1);//state
						par_up_barcode.Add(3, OrderHelper.GetUploadType());//type
						par_up_barcode.Add(4, item_value_arr);//guid_barcode
						par_up_barcode.Add(5, _orderNum);//up ordernum
						up_barcode.Add(1, par_up_barcode);
					}
					int i_files = 0;
					foreach(KeyValuePair<string,string> item in oldFile_Guid)
					{
						if (!string.IsNullOrEmpty(item.Key))
						{
							ImageCache imageCache = new ImageCache();
							imageCache.DeleteImageCache(OrderHelper.GetUploadFold(), item.Key);
							SortedList par_de_barcode = new SortedList();
							par_de_barcode.Add(1, OrderHelper.GetUploadType());//type
							par_de_barcode.Add(2, item.Key);//data_url
							de_barcode.Add(i_files + 1, par_de_barcode);
							i_files++;
						}
					}
					SortedList sqlParam = new SortedList();
					int index = 1;
					SortedList par_input01 = new SortedList();
					par_input01.Add(1, txtOrderName.Text.Trim());
					par_input01.Add(2, _orderNum);
					par_input01.Add(3, _customer_barcode);
					par_input01.Add(4, _costbar_code);
					par_input01.Add(5, _location_id);
					par_input01.Add(6, CnasBaseData.SystemID);
					par_input01.Add(7, CnasBaseData.UserID);
					par_input01.Add(8, 1);//in_cycle
					par_input01.Add(9, _orderNum);
					par_input01.Add(10, _orderNum);
					par_input01.Add(11, txtOrderName.Text.Trim());
					par_input01.Add(12, wf_code);
					par_input01.Add(13, CnasBaseData.UserID);
					par_input01.Add(14, "");
					par_input01.Add(15, batch);
					input01.Add(1, par_input01);
					foreach (DataGridViewRow item in dgv_order.Rows)
					{
						SortedList workSpecialSet = new SortedList();
						workSpecialSet.Add(1, _orderNum);
						workSpecialSet.Add(2, wf_code);
						workSpecialSet.Add(3, batch);
						workSpecialSet.Add(4, _orderNum);
						workSpecialSet.Add(5, Convert.ToString(item.Cells["id"].Value));
						workSpecialSet.Add(6, Convert.ToString(item.Cells["num"].Value));
						workSpecialSet.Add(7, wf_code);
						workSpecialSet.Add(8, Convert.ToString(item.Cells["remark"].Value));
						workSpecialSet.Add(9, CnasBaseData.UserBaseInfo.UserID);
						workSpecialSet.Add(10, batch);
						workSpecialSet.Add(11, Convert.ToString(item.Cells["codeType"].Value));
						int c_codeType;
						int.TryParse(Convert.ToString(item.Cells["c_codeType"].Value), out c_codeType);
						workSpecialSet.Add(12, c_codeType);
						workSpecialSet.Add(13, pid);
						workSpecialSet.Add(14, vinfoid);
						workSpecialSet.Add(15, _orderType);
						input02.Add(index, workSpecialSet);
						index++;
					}
					sqlParam.Add(1, input01);
					sqlParam.Add(2, up_barcode);//把batch更改为订单号
					sqlParam.Add(3, de_barcode);//删除记录前还得删除文件
					sqlParam.Add(4, input02);
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					//string sqlTest = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add015", sqlParam);
					int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add015", sqlParam);
					//int result = 1;
					if (result > 0)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

						DataRow[] isPrintCreateOrderData = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code='IsPrintCreateOrder'");
						if (isPrintCreateOrderData != null && isPrintCreateOrderData.Length == 1)
						{
							string isPrintCreateOrder = Convert.ToString(isPrintCreateOrderData[0]["value_code"]);

							if (isPrintCreateOrder == "1")
							{
								string getCustomerName = GetSelectComBoBox(cbbCust, 2);
								LoadPrintData(_orderNum, getCustomerName, _locationName, dgv_order);
							}
						}
						Close();
					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitemadd", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillselectordername", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
		}

		/// <summary>
		/// 打印订单详情
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="grid"></param>
		private void LoadPrintData(string orderNum,string custmerName,string locationName, DataGridView grid)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Order'");
			if (arrayDR02.Length > 0)
			{
				string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
				//          
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
				if (!string.IsNullOrEmpty(orderNum) && grid.Rows.Count>0)
				{
					for (int i = 0; i < grid.Rows.Count; i++)
					{
						int index = dgv_orderDetail.Rows.Add();
						dgv_orderDetail.Rows[index].Cells["o_id"].Value = index+1;
						dgv_orderDetail.Rows[index].Cells["o_ca_name"].Value = grid.Rows[i].Cells["ca_name"].Value;//base_ca_name
						dgv_orderDetail.Rows[index].Cells["o_codeType"].Value = grid.Rows[i].Cells["instrument_typeName"].Value;///GetEnumInstrumentTypeName(dic, Convert.ToString(grid.Rows[i].Cells["codeType"].Value));
						dgv_orderDetail.Rows[index].Cells["o_num"].Value = grid.Rows[i].Cells["num"].Value;
						dgv_orderDetail.Rows[index].Cells["o_remark"].Value = grid.Rows[i].Cells["remark"].Value;
					}
				}
				string thingCount = string.Empty;
				string orderName = string.Empty;
				string patientInfo = string.Empty;
				if (BarCodeHelper.IsOrderOutSet(orderNum))
				{
					thingCount = string.Format("物品数量：{0}件", txt_InstrumentNum.Text);
					orderName =  string.Format("外来器械包名：{0}", txtOrderName.Text);
					SortedList condition = new SortedList();
					condition.Clear();
					condition.Add(1, orderNum);
					condition.Add(2, _batch);
					CnasRemotCall remoteCall = new CnasRemotCall();
					string personSQL = remoteCall.RemotInterface.CheckSelectData("HCS_person_info_sec001", condition);
					DataTable personData = remoteCall.RemotInterface.SelectData("HCS_person_info_sec001", condition);
					if (personData != null && personData.Rows.Count > 0)
					{
						patientInfo = string.Format("病人姓名：{0}  住 院 号：{1}", Convert.ToString(personData.Rows[0]["p_name"]), Convert.ToString(personData.Rows[0]["p_Number"]));
					}
				}
				else
				{
					thingCount = string.Format("器械包数量： {0}个   物品数量：{1}件", txt_setNum.Text, txt_InstrumentNum.Text);
					orderName =  string.Format("订单名称： {0}", txtOrderName.Text);
				}

				PrintHelper.Instance.Print_DataGridView(dgv_orderDetail, pringxml, orderNum, new string[] { custmerName, locationName, orderName, thingCount, patientInfo });
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 订单该器械减1
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInstrumentRight_Click(object sender, EventArgs e)
		{
			OnbtnInstrumentRight_Click();
		}

		/// <summary>
		/// 订单该器械减1
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnInstrumentRight_Click()
		{
			if(dgv_order.Rows.Count>0&&dgv_order.SelectedRows.Count>0)
			{
				for (int i = dgv_order.SelectedRows.Count-1; i >=0; i--)
				{
					DataGridViewRow row = dgv_order.SelectedRows[i];
					string str_Count = Convert.ToString(row.Cells["num"].Value);
					string tempType = Convert.ToString(row.Cells["codeType"].Value);
					int num;
					Int32.TryParse(str_Count, out num);
					if (num > 1)
					{
						row.Cells["num"].Value = num - 1;
					}
					else
					{
						dgv_order.Rows.Remove(row);
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillinstrument", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 该订单 加一个模板或者加一个器械
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInstrumentLeft_Click(object sender, EventArgs e) { OnbtnInstrumentLeft_Click(); }

		/// <summary>
		/// 该订单 加一个模板或者加一个器械
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnInstrumentLeft_Click()
		{
			#region 旧版添加器械
			if (dgv_Instrument.Rows.Count > 0 && dgv_Instrument.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_Instrument.SelectedRows[0];
				string instrument_type = Convert.ToString(row.Cells["instrument_type"].Value).Trim();
				if (instrument_type.Equals("1"))
				{
					for (int i = 0; i < dgv_Instrument.SelectedRows.Count; i++)
					{
						row = dgv_Instrument.SelectedRows[i];
						string id = Convert.ToString(row.Cells["bid"].Value).Trim();
						string instrumentName = Convert.ToString(row.Cells["bca_name"].Value).Trim();
						string c_type = Convert.ToString(row.Cells["c_instrument_type"].Value);
						AddDgv_OrderItem(id, instrumentName, "1","1",c_type);
					}
				}
				else if(instrument_type.Equals("2"))
				{
					for (int i = 0; i < dgv_Instrument.SelectedRows.Count; i++)
					{
						row = dgv_Instrument.SelectedRows[i];
						string id = Convert.ToString(row.Cells["bid"].Value).Trim();
						string instrumentName = Convert.ToString(row.Cells["bca_name"].Value).Trim();
						AddDgv_OrderItem(id, instrumentName, "1", "2");
					}
				}
				else if (instrument_type.Equals("3"))
				{
					for (int i = 0; i < dgv_Instrument.SelectedRows.Count; i++)
					{
						row = dgv_Instrument.SelectedRows[i];
						string mouldId = Convert.ToString(row.Cells["bid"].Value).Trim();
						string c_type = Convert.ToString(row.Cells["c_instrument_type"].Value);
						if (!string.IsNullOrEmpty(mouldId))
						{
							DataRow[] rows = _dtInstrumentMould.Select("id=" + mouldId);
							if (rows != null && rows.Length > 0)
							{
								foreach (DataRow rowItem in rows)
								{
									string id = Convert.ToString(rowItem["instrument_id"]).Trim();
									string instrumentName = Convert.ToString(rowItem["ca_name"]).Trim();
									string num = Convert.ToString(rowItem["num"]).Trim();
									string type = Convert.ToString(rowItem["type"]).Trim();
									AddDgv_OrderItem(id, instrumentName, num,type,c_type);
								}
							}
						}
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filladdinstrument", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 
			#endregion
		}

		/// <summary>
		/// 添加订单项
		/// </summary>
		private void AddDgv_OrderItem(string id,string instrumentName,string num,string type,string c_type="")
		{
			if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(instrumentName))
			{
				int numInt;
				Int32.TryParse(num, out numInt);
				if (dgv_order.Rows != null && dgv_order.Rows.Count > 0)
				{
					bool isExits = false;
					for (int i = 0; i < dgv_order.Rows.Count; i++)
					{
						string tempid = Convert.ToString(dgv_order.Rows[i].Cells["id"].Value);
						string tempName = Convert.ToString(dgv_order.Rows[i].Cells["ca_name"].Value);
						string tempNum = Convert.ToString(dgv_order.Rows[i].Cells["num"].Value);
						string tempType = Convert.ToString(dgv_order.Rows[i].Cells["codeType"].Value);
						string tempC_Type = Convert.ToString(dgv_order.Rows[i].Cells["c_codeType"].Value);
						if (id == tempid && instrumentName == tempName&&type==tempType&&c_type==tempC_Type)
						{
							isExits = true;
							int tempNumInt;
							Int32.TryParse(tempNum, out tempNumInt);
							dgv_order.Rows[i].Cells["num"].Value = tempNumInt + numInt;
						}
					}
					if (!isExits)
					{
						int index = dgv_order.Rows.Add();
						dgv_order.Rows[index].Cells["id"].Value = id;
						dgv_order.Rows[index].Cells["ca_name"].Value = instrumentName;
						dgv_order.Rows[index].Cells["num"].Value = numInt;
						dgv_order.Rows[index].Cells["codeType"].Value = type;
						dgv_order.Rows[index].Cells["c_codeType"].Value = c_type;
						dgv_order.Rows[index].Cells["instrument_typeName"].Value = OrderHelper.GetEnumInstrumentTypeName(type,c_type,_dicInstrumentType,_dicChildInstrumentType);
					}
				}
				else
				{
					int index = dgv_order.Rows.Add();
					dgv_order.Rows[index].Cells["id"].Value = id;
					dgv_order.Rows[index].Cells["ca_name"].Value = instrumentName;
					dgv_order.Rows[index].Cells["num"].Value = numInt;
					dgv_order.Rows[index].Cells["codeType"].Value = type;
					dgv_order.Rows[index].Cells["c_codeType"].Value = c_type;
					dgv_order.Rows[index].Cells["instrument_typeName"].Value = OrderHelper.GetEnumInstrumentTypeName(type, c_type,_dicInstrumentType,_dicChildInstrumentType);
				}
			}
		}


		/// <summary>
		/// 预览
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnViewDetail_Click(object sender, EventArgs e)
		{
			if (!GetOrderNum()) return;
			HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(dgv_order);
			detail.OrderType = GetSelectComBoBox(cbbOrderType, 2);
			detail.OrderNum = _orderNum;
			detail.CustomerName = GetSelectComBoBox(cbbCust, 2);
			detail.LocationStr = _locationName;
			detail.UserName = CnasBaseData.UserBaseInfo.UserName;
			detail.OrderName = txtOrderName.Text.Trim() ;
			detail.Mode = 1;
			detail.BatchNum = nowGuid.ToString();
			detail.ShowDialog();
		}

		/// <summary>
		/// 获取cbb选中项相应值
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="type">1selectValue2selectText</param>
		/// <returns></returns>
		private string GetSelectComBoBox(MetroComboBox cbb,int type)
		{
			if (cbb.SelectedItem != null&&cbb.SelectedItem is KeyValuePair<string,string>)
			{
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbb.SelectedItem;
				if (type == 1)
				{
					return item.Key;
				}
				else if (type == 2)
				{
					return item.Value;
				}
				return string.Empty;
			}
			return string.Empty;
		}

		/// <summary>
		/// dic字典绑定数据
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="dic"></param>
		private void DicBindCbb(MetroComboBox cbb,Dictionary<string,string> dic)
		{
			if (dic != null&&dic.Count>0)
			{
				foreach(KeyValuePair<string,string> item in dic)
				{
					cbb.Items.Add(item);
				}
				if(cbb.Items.Count>0)
				{
					cbb.SelectedIndex=0;
					if(cbb.Items.Count==1)
					{
						cbb.Enabled = false;
					}
					if (cbb.Items.Count > 1)
					{
						cbb.Enabled = true;
					}
				}
			}
		}

		/// <summary>
		/// 订单类型更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbOrderType_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				txtOrderName.Text = string.Empty;
				dgv_order.Rows.Clear();
				string getCustomerValue = GetSelectComBoBox(cbbCust, 1);
				DataRowView locationRow = cbbLocationType.SelectedItem as DataRowView;
				string tempLocationValue = locationRow == null ? "" : Convert.ToString(locationRow["id"]).Trim();
				string getOrderType = GetSelectComBoBox(cbbOrderType, 1);
				//配置对应的添加类型
				SetInstrumentTypeItem(getOrderType);
			}
		}


		/// <summary>
		/// 关闭窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnClose_Click(object sender, EventArgs e)
		{
			DeleteImageFile();
			Close();
		}

		/// <summary>
		/// 关闭按钮触发删除文件操作
		/// </summary>
		private void DeleteImageFile()
		{
			foreach(KeyValuePair<string,string> item in nowFile_Guid)
			{
				if (!string.IsNullOrEmpty(item.Key))
				{
					ImageCache imageCache = new ImageCache();
					imageCache.DeleteImageCache(OrderHelper.GetUploadFold(), item.Key);
					SortedList sqlParameters = new SortedList();
					SortedList imageItem = new SortedList();
					sqlParameters.Add(1, imageItem);
					imageItem.Add(1, OrderHelper.GetUploadType());//type
					imageItem.Add(2, item.Key);//data_url
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					//string testSql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS_image_delete003", sqlParameters);
					int result = reCnasRemotCall.RemotInterface.UPDataList("HCS_image_delete003", sqlParameters);
				}
			}
		}

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_new_order_Load(object sender, EventArgs e)
		{
			//Stopwatch test = new Stopwatch();
			//test.Start();
			InitButtonImage();
			try
			{
				InitComboxData();
				//test.Stop();
				//Logger.Info(string.Format("InitComboxData Done：{0}--{1}", test.ElapsedMilliseconds, test.Elapsed));
				//test.Start();
			}
			catch
			{
			}
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			_isFirst = false;
			cbbIntrumentType_SelectedValueChanged(null, null);
			//test.Stop();
			//Logger.Info(string.Format("HCSSM_order_new_order_Load：{0}--{1}", test.ElapsedMilliseconds, test.Elapsed));
		}

		/// <summary>
		/// 搜索当前类型的品名
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSetName_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				string tempSet_name = txtSetName.Text.Trim();
				if(!string.IsNullOrEmpty(tempSet_name))
				{
					for(int i=0;i<dgv_Instrument.Rows.Count;i++)
					{
						DataGridViewRow row = dgv_Instrument.Rows[i];
						string tempBca_name = Convert.ToString(row.Cells["bca_name"].Value);
						string tempCost_center = Convert.ToString(row.Cells["cost_ca_name"].Value);
						string tempType = Convert.ToString(row.Cells["instrument_type_name"].Value);
						if(!tempBca_name.Contains(tempSet_name)&&!tempCost_center.Contains(tempSet_name)&&!tempType.Contains(tempSet_name))
						{
							row.Visible = false;
						}
						else
						{
							row.Visible = true;
						}
					}
				}
				else
				{
					foreach(DataGridViewRow row  in dgv_Instrument.Rows)
					{
						row.Visible = true;
					}
				}
			}
		}

		/// <summary>
		/// 单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_Instrument_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgv_Instrument.Rows.Count > 0)
			{
				DataGridViewRow row = dgv_Instrument.CurrentRow;
				string instrument_type = Convert.ToString(row.Cells["instrument_type"].Value).Trim();
				if (instrument_type.Equals("3"))
				{
					txtOrderName.Text = Convert.ToString(row.Cells["bca_name"].Value).Trim();
					dgv_order.Rows.Clear();
					string mouldId = Convert.ToString(row.Cells["bid"].Value).Trim();
					if (!string.IsNullOrEmpty(mouldId))
					{
						DataRow[] rows = _dtInstrumentMould.Select("id=" + mouldId);
						if (rows != null && rows.Length > 0)
						{
							foreach (DataRow rowItem in rows)
							{
								string id = Convert.ToString(rowItem["instrument_id"]).Trim();
								string instrumentName = Convert.ToString(rowItem["ca_name"]).Trim();
								string num = Convert.ToString(rowItem["num"]).Trim();
								string type = Convert.ToString(rowItem["type"]).Trim();
								string tempC_Type = Convert.ToString(row.Cells["c_instrument_type"].Value).Trim();
								AddDgv_OrderItem(id, instrumentName, num,type,tempC_Type);
							}
						}
					}
				}
				else
				{
					return;
				}
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			//mPatient32.png
			btnPatient.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPatient32", EnumImageType.PNG);
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			btnViewDetail.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPriview32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnInstrumentLeft.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRight32-2", EnumImageType.PNG);
			btnInstrumentRight.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mLeft32-2", EnumImageType.PNG);
			btnImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderImage32", EnumImageType.PNG);
		}

		/// <summary>
		/// 选择器械种类
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbAddType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(!_isFirst)
			{
				if (cbbIntrumentType.SelectedItem != null&&cbbAddType.SelectedItem!=null)
				{
					string instrumentType = GetSelectComBoBox(cbbIntrumentType, 1);
					string getOrderType = GetSelectComBoBox(cbbOrderType, 1);
					string c_instrumentType = GetSelectComBoBox(cbbAddType, 1);
					LoadData(instrumentType, getOrderType,c_instrumentType);
				}	
			}
		}

		/// <summary>
		/// 录入病人信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPatient_Click(object sender, EventArgs e)
		{
			OnbtnPatient();
		}

		/// <summary>
		/// 录入病人信息
		/// </summary>
		private void OnbtnPatient()
		{
			HCSSM_order_person dialog = new HCSSM_order_person();
			dialog.ShowDialog();
			SortedList condition = dialog.PatientList;
			if(condition!=null&&condition.Count>0)
			{
				string str_pName = string.Empty;
				if (condition.ContainsKey("p_Number"))
					str_pName += string.Format("  住院号:{0}", condition["p_Number"]);
				if (condition.ContainsKey("p_Name"))
					str_pName += string.Format("  名字:{0}", condition["p_Name"]);
				if (condition.ContainsKey("p_Sex"))
					str_pName += string.Format("  性别:{0}", Convert.ToString(condition["p_Sex"])=="1"?"男":"女");
				if (condition.ContainsKey("p_Age"))
					str_pName += string.Format("  年龄:{0}", condition["p_Age"]);
				if (condition.ContainsKey("p_Operation"))
					txt_pOperation.Text = Convert.ToString(condition["p_Operation"]);
				txt_pName.Text = str_pName;
				pid = dialog.Patient_Id;
				vinfoid = dialog.Venderinfo_id;
			}
		}

		/// <summary>
		/// 科室发生改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbLocationType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				if (cbbIntrumentType.Items != null && cbbIntrumentType.Items.Count > 0 && cbbIntrumentType.SelectedItem != null)
				{
					KeyValuePair<string, string> obj = (KeyValuePair<string, string>)cbbIntrumentType.SelectedItem;
					string instrumentType = obj.Key;
					string getOrderType = GetSelectComBoBox(cbbOrderType, 1);
					string c_instrumentType = GetSelectComBoBox(cbbAddType, 1);
					LoadData(instrumentType, getOrderType, c_instrumentType);
				}
			}
		}

		/// <summary>
		/// 图片点击事件
		/// </summary>
		private void OnbtnImageClick()
		{
			HCSSM_order_image_add addImage = new HCSSM_order_image_add(1,nowGuid.ToString(),_orderNum);
			addImage.ShowDialog();
			if(nowFile_Guid!=null&&addImage.SaveFiles!=null&&addImage.SaveFiles.Count>0)
			{
				foreach(KeyValuePair<string,string> item in addImage.SaveFiles)
				{
					if (!nowFile_Guid.ContainsKey(item.Key))
					{
						nowFile_Guid.Add(item.Key, item.Value);
					}
				}
			}
			//后续事件
		}

		/// <summary>
		/// 图片点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImage_Click(object sender, EventArgs e)
		{
			OnbtnImageClick();
		}

		/// <summary>
		/// 编辑前呈现
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_order_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (this.dgv_order.CurrentCell!=null&&this.dgv_order.CurrentCell.OwningColumn.Name == "num")
			{
				e.Control.KeyPress -= new KeyPressEventHandler(TextBoxDec_KeyPress);
				e.Control.KeyPress += new KeyPressEventHandler(TextBoxDec_KeyPress);
			}
		}

		/// <summary>
		/// 只能输入数字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBoxDec_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) ) { e.Handled = true; } 
		}

		/// <summary>
		/// 提交刚输入的键值
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_order_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgv_order.IsCurrentCellDirty)
			{
				dgv_order.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		/// <summary>
		/// cell更改事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_order_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell=dgv_order.CurrentCell;
			if (cell != null)
			{
				if (Convert.ToString(cell.Value) == "0")
				{
					dgv_order.Rows.RemoveAt(cell.RowIndex);
				}
				DisplayNumByDgv();
			}
		}

		/// <summary>
		/// 控制显示
		/// </summary>
		private void  DisplayNumByDgv()
		{
			bool instrumentIsView = false;
			bool setIsView = false;
			int set_int = 0;
			int instrument_int = 0;
			if (dgv_order.Rows.Count > 0)
			{
				for (int i = 0; i < dgv_order.Rows.Count; i++)
				{
					int num_int;
					DataGridViewRow row = dgv_order.Rows[i];
					string codeType = Convert.ToString(row.Cells["codeType"].Value);
					string tempNum = Convert.ToString(row.Cells["num"].Value);
					Int32.TryParse(tempNum, out num_int);
					switch (codeType)
					{
						case "1": { instrument_int += num_int; break; }
						case "2": { set_int += num_int; break; }
						default: break;
					}
				}
				if (set_int > 0) { setIsView = true; }
				if (instrument_int > 0) { instrumentIsView = true; }
			}
			txt_InstrumentNum.Text = instrument_int.ToString();
			txt_setNum.Text = set_int.ToString();
			lb_instrumentNum.Visible = instrumentIsView;
			txt_InstrumentNum.Visible = instrumentIsView;
			lb_SetNum.Visible = setIsView;
			txt_setNum.Visible = setIsView;
			
		}

		/// <summary>
		/// 添加row事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_order_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			DisplayNumByDgv();
		}

		/// <summary>
		/// 移除row事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_order_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			DisplayNumByDgv();
		}
	}
}
