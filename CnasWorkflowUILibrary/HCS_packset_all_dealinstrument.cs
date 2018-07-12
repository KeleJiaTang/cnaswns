using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasBaseInterface;
using CRD.Common;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCS_packset_all_dealinstrument : MetroForm
	{

		/// <summary>
		/// 流程核算
		/// </summary>
		private CnasHCSWorkflowInterface _workflowServer = null;
		/// <summary>
		/// 流程
		/// </summary>
		private DataTable _pdData = null;
		/// <summary>
		/// 流程参数
		/// </summary>
		private DataTable _pdParameters = null;
		/// <summary>
		/// 流程
		/// </summary>
		public DataTable PdData
		{
			get
			{
				return _pdData;
			}
			set
			{
				if (value != _pdData)
					_pdData = value;
			}
		}
		/// <summary>
		/// 流程参数
		/// </summary>
		public DataTable Pdparameters
		{
			get
			{
				return _pdParameters;
			}
			set
			{
				if (value != _pdParameters)
					_pdParameters = value;
			}
		}
		/// <summary>
		/// 流程核算
		/// </summary>
		public CnasHCSWorkflowInterface WorkflowServer
		{
			get
			{
				return _workflowServer;
			}
			set
			{
				if (value != _workflowServer)
					_workflowServer = value;
			}
		}

		/// <summary>
		/// 用于表示它是第一次
		/// </summary>
		private bool _isFirst = true;

		/// <summary>
		/// 初始化
		/// </summary>
		public HCS_packset_all_dealinstrument()
		{
			InitializeComponent();
			InitButtonImage();
		}

		/// <summary>
		/// 使用地点
		/// </summary>
		private Dictionary<string, string> _locationDic;
		/// <summary>
		/// 客户名称
		/// </summary>
		private Dictionary<string, string> _customerDic;

		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;

		/// <summary>
		/// 器械子类型
		/// </summary>
		private Dictionary<string, string> _instrumentType;
		
		/// <summary>
		/// 当前区域id
		/// </summary>
		public string App_id="1020";

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSearch_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadData()
		{
			string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
			string bccOrBcu = txtOrderCode.Text.Trim();
			string getCustValue = GetSelectComBoBox(cbbCust, 1);
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
			dgv_OrderDetail.Rows.Clear();
			dgv_count.Rows.Clear();
			string instrumentRange = "0";
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-packset-dealinstrument-type'");
			if (array != null && array.Length > 0)
			{
				instrumentRange = string.Empty;
				string tempStr = Convert.ToString(array[0]["value_code"]);
				string[] str = tempStr.Split(',');
				for (int i = 0; i < str.Length; i++)
				{
					if (i == str.Length - 1)
					{
						instrumentRange += "'" + str[i] + "'";
					}
					else
					{
						instrumentRange += "'" + str[i] + "',";
					}
					if(!string.IsNullOrEmpty(str[i]))
					{
						int index_count = dgv_count.Rows.Add();
						dgv_count.Rows[index_count].Cells["TypeName"].Value = GetEnumInstrumentTypeName(_instrumentType,str[i]);
						dgv_count.Rows[index_count].Cells["Type_Enum"].Value = 1;
						dgv_count.Rows[index_count].Cells["c_Type_Enum"].Value = str[i];
						dgv_count.Rows[index_count].Cells["needType_count"].Value = 0;
					}
				}
				if (string.IsNullOrEmpty(instrumentRange) || instrumentRange.Equals("''"))
				{
					instrumentRange = "0";
				}
			}
			int indexAdd = dgv_count.Rows.Add();
			dgv_count.Rows[indexAdd].Cells["TypeName"].Value = "器械包";
			dgv_count.Rows[indexAdd].Cells["Type_Enum"].Value = 2;
			dgv_count.Rows[indexAdd].Cells["c_Type_Enum"].Value = string.Empty;
			dgv_count.Rows[indexAdd].Cells["needType_count"].Value = 0;
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			string orderStr = string.Empty;
			//custmoer
			bool isAllCust = getCustValue == "0" || string.IsNullOrEmpty(getCustValue);
			bool isAllLocation = string.IsNullOrEmpty(getLocationVAlue) || getLocationVAlue.Equals("0");
			//custmoer
			if (App_id == "1050")
			{
				//custmoer
				if (isAllCust)//使用区则所配的医院barcode
				{
					string customerArrange = OrderHelper.GetDicToArrangeStr(_customerDic);
					orderStr += " and hcs_customer.bar_code in ('" + customerArrange + "') ";//需要改 是一个范围
					//此处未过滤locationid 暂未改
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						Dictionary<string, string> dic = OrderHelper.GetAllHandleLocation(getCustValue, App_id == "1050", true, true);//该处可成为私有变量放在界面初始化
						string locationArrange = OrderHelper.GetDicToArrangeStr(dic);
						orderStr += " and orderIdSet.location_id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
				}
				//custmoer
				if (!isAllCust)
				{
					orderStr += " and hcs_customer.bar_code='" + getCustValue + "' ";
					//location
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						string locationArrange = OrderHelper.GetDicToArrangeStr(_locationDic);
						orderStr += " and orderIdSet.location_id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
					//location
					if (!isAllLocation)
					{
						orderStr += " and orderIdSet.location_id='" + getLocationVAlue + "' ";
					}
				}
			}
			else
			{
				//custmoer
				if (!isAllCust)
				{
					orderStr += " and hcs_customer.bar_code='" + getCustValue + "' ";
				}
				//location
				if (!isAllLocation)
				{
					orderStr += " and orderIdSet.location_id='" + getLocationVAlue + "' ";
				}
			}
			//ordertype
			if (!string.IsNullOrEmpty(getOrderValue) && !getOrderValue.Equals("0"))
			{
				orderStr += " and  LEFT(orderSet.set_code,5)='" + getOrderValue.Trim() + "' ";
			}
			//OrderCode
			if (!string.IsNullOrEmpty(bccOrBcu))
			{
				orderStr += " and set_code like '%" + bccOrBcu + "%'";
			}
			DateTime creStartValue = creStartTime.Value;
			DateTime creEndValue = creEndTime.Value;
			if (_isFirst)
			{
				creStartValue = DateTime.MinValue;
				creEndValue = DateTime.Now;
			}
			condition.Add(1, creEndValue);
			condition.Add(2, creStartValue);
			condition.Add(3, creEndValue);
			condition.Add(4, creStartValue);
			condition.Add(5, instrumentRange);
			condition.Add(6, orderStr);
			string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec019", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec019", condition);
			if(data!=null&&data.Rows.Count>0)
			{
				for(int i=0;i<data.Rows.Count;i++)
				{
					DataRow row = data.Rows[i];
					string tempSet_Code = Convert.ToString(row["set_code"]);
					string tempBatch = Convert.ToString(row["batch"]);
					string tempC_Code_Type = Convert.ToString(row["base_ca_type"]);
					string tempCode_Type = Convert.ToString(row["codeType"]);
					string tempNum = Convert.ToString(row["instrument_count"]);
					string tempDeal_count = Convert.ToString(row["deal_count"]);
					bool isFlag = CheckInDgvOrderItem(tempSet_Code, tempBatch, tempCode_Type, tempC_Code_Type, tempNum, tempDeal_count);
					if (isFlag)
					{
						int index = dgv_OrderDetail.Rows.Add();
						dgv_OrderDetail.Rows[index].Cells["batch"].Value = tempBatch;
						dgv_OrderDetail.Rows[index].Cells["cu_name"].Value = Convert.ToString(row["cu_name"]);
						dgv_OrderDetail.Rows[index].Cells["u_uname"].Value = Convert.ToString(row["u_uname"]);
						string tempOrderType = tempSet_Code.Length > 4 ?tempSet_Code.Substring(0, 5):tempSet_Code;
						dgv_OrderDetail.Rows[index].Cells["order_type"].Value =OrderHelper.InitDgvDataOrderType(_orderTypedic,tempOrderType);
						dgv_OrderDetail.Rows[index].Cells["set_code"].Value = tempSet_Code;
						dgv_OrderDetail.Rows[index].Cells["ca_name"].Value = Convert.ToString(row["ca_name"]);
						dgv_OrderDetail.Rows[index].Cells["handle_state"].Value = "未完成";
						dgv_OrderDetail.Rows[index].Cells["user_name"].Value = Convert.ToString(row["user_name"]);
						dgv_OrderDetail.Rows[index].Cells["cre_date"].Value = row["cre_date"];
					}
				}
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderNum">订单编号</param>
		/// <param name="batch">订单批次号</param>
		/// <param name="codeType">类型</param>
		/// <param name="c_codeType">子类型</param>
		/// <param name="num">所需总数量</param>
		/// <param name="send_count">已发出数量</param>
		/// <returns></returns>
		private bool CheckInDgvOrderItem(string orderNum,string batch,string codeType,string c_codeType,string num,string send_count)
		{
			bool flag = true;
			if(dgv_OrderDetail.Rows.Count>0)
			{
				for(int i=0;i<dgv_OrderDetail.Rows.Count;i++)
				{
					string str_orderNum = Convert.ToString(dgv_OrderDetail.Rows[i].Cells["set_code"].Value);
					string str_batch = Convert.ToString(dgv_OrderDetail.Rows[i].Cells["batch"].Value);
					if (orderNum == str_orderNum&&str_batch==batch)
					{
						flag = false;
						break;
					}
				}
			}
			if(dgv_count.Rows.Count>0)
			{
				for(int i=0;i<dgv_count.Rows.Count;i++)
				{
					string str_Type_Enum=Convert.ToString(dgv_count.Rows[i].Cells["Type_Enum"].Value);
					string str_c_Type_Enum = Convert.ToString(dgv_count.Rows[i].Cells["c_Type_Enum"].Value);
					string str_needType_count=Convert.ToString(dgv_count.Rows[i].Cells["needType_count"].Value);
					if (str_Type_Enum == codeType&&str_c_Type_Enum==c_codeType)
					{
						int int_needType_count, int_num, int_send_count;
						int.TryParse(str_needType_count, out int_needType_count);
						int.TryParse(num, out int_num);
						int.TryParse(send_count, out int_send_count);
						dgv_count.Rows[i].Cells["needType_count"].Value = int_needType_count - int_send_count+int_num;
					}
						
				}
			}
			return flag;
		}

		/// <summary>
		/// 获取combox数据
		/// </summary>
		private void InitComboxData()
		{
			_instrumentType=OrderHelper.GetInstrumentChildTypeItem();
			creStartTime.Value = DateTime.Now.AddDays(-7);
			SetOrderTypeItem();
			InitCustomerItem();
			SetComLocationItem();
			LoadData();
		}

		/// <summary>
		/// 仅仅设置客户名称
		/// </summary>
		private void InitCustomerItem()
		{
			_customerDic = OrderHelper.GetAllHandleCustomer();
			DicBindCbb(cbbCust, _customerDic);
		}

		/// <summary>
		/// 设置要添加的订单类型
		/// </summary>
		private void SetOrderTypeItem()
		{
			_orderTypedic = OrderHelper.GetOrderTypeItem();
			DicBindCbb(cbbOrderType, _orderTypedic);
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="dic"></param>
		private void DicBindCbb(MetroComboBox cbb, Dictionary<string, string> dic)
		{
			if (cbb.Items.Count > 0) cbb.Items.Clear();
			if (dic != null && dic.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in dic)
				{
					cbb.Items.Add(item);
				}
				if (cbb.Items.Count > 0)
				{
					cbb.SelectedIndex = 0;
					if (cbb.Items.Count == 1)
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
		/// 获取相应值
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private string GetSelectComBoBox(MetroComboBox cbb, int type)
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
		/// 客户编码更改设置对应的科室
		/// </summary>
		/// <param name="custbarcode"></param>
		private void SetComLocationItem()
		{
			string getCustomerValue = GetSelectComBoBox(cbbCust, 1);
			_locationDic = OrderHelper.GetAllHandleLocation(getCustomerValue);
			DicBindCbb(cbbLocation, _locationDic);
		}

		/// <summary>
		/// 客户名称更改设置对应的科室
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbCust_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				SetComLocationItem();
			}
		}

		/// <summary>
		/// 获取枚举值对应的名称
		/// </summary>
		/// <param name="dic"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private string GetEnumInstrumentTypeName(Dictionary<string, string> dic, string type)
		{
			if (dic != null && dic.Count > 0)
			{
				if (dic.ContainsKey(type))
					return dic[type];
				return type;
			}
			return type;
		}

		/// <summary>
		/// 订单类型更改事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbOrderType_SelectedValueChanged(object sender, EventArgs e)
		{
			string getOrderTypeName = GetSelectComBoBox(cbbOrderType, 2).Trim();
			SetDgvBycbbOrderType(getOrderTypeName);
		}

		/// <summary>
		/// 根据订单内容显示数据
		/// </summary>
		/// <param name="orderType"></param>
		private void SetDgvBycbbOrderType(string orderType)
		{
			if(dgv_OrderDetail.Rows!=null&&dgv_OrderDetail.Rows.Count>0)
			{
				if (orderType.Equals("所有"))
				{
					foreach(DataGridViewRow item in dgv_OrderDetail.Rows)
					{
						item.Visible = true;
					}
				}
				else
				{
					foreach (DataGridViewRow item in dgv_OrderDetail.Rows)
					{
						string tempCodeType = Convert.ToString(item.Cells["order_type"].Value).Trim();
						if(tempCodeType.Equals(orderType))
						{
							item.Visible = true;
						}
						else
						{
							item.Visible = false;
						}
					}
				}
			}
		}

		/// <summary>
		/// 处理订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnHandleOrder_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count>0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCS_packset_dealinstrument_detail detail = new HCS_packset_dealinstrument_detail(orderNum, batch);
				detail.Pdparameters = this.Pdparameters;
				detail.WorkflowServer = this.WorkflowServer;
				detail.PdData = this.PdData;
				detail.App_id = "1020";
				detail.ShowDialog();
				DealDialogParam(detail.OrderNumChangeList);
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbLocation_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				LoadData();
			}
		}

		/// <summary>
		/// 双击处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ondgv_OrderDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			CellDoubleClickDoOnDgv();
		}

		private void txtOrderCode_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				LoadData();
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnHandleOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDoOrder32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 处理dialog返回的参数值
		/// </summary>
		/// <param name="condition"></param>
		private void DealDialogParam(SortedList condition)
		{
			string str_temp_orderNum = string.Empty;
			string str_temp_batch = string.Empty;
			if(condition!=null&&condition.Count>0)
			{
				
				bool isRemove = true;
				for(int i=0;i<condition.Count;i++)
				{
					object par_condition_obj = condition.GetByIndex(i);
					if(par_condition_obj!=null&&par_condition_obj is SortedList)
					{
						SortedList par_condition = (SortedList)par_condition_obj;
						if(par_condition.Count==8)
						{
							string codeType=string.Empty;
							string c_codeType=string.Empty;
							string num = string.Empty;
							string send_count = string.Empty;
							string now_send_count = string.Empty;
							if (par_condition.ContainsKey(1))
								str_temp_orderNum = Convert.ToString(par_condition[1]);
							if (par_condition.ContainsKey(2))
								str_temp_batch = Convert.ToString(par_condition[2]);
							if (par_condition.ContainsKey(3))
								c_codeType = Convert.ToString(par_condition[3]);
							if (par_condition.ContainsKey(7))
								codeType = Convert.ToString(par_condition[7]);
							if (par_condition.ContainsKey(5))
								num = Convert.ToString(par_condition[5]);
							if (par_condition.ContainsKey(6))
								send_count = Convert.ToString(par_condition[6]);
							if (par_condition.ContainsKey(8))
								now_send_count = Convert.ToString(par_condition[8]);
							if (!string.IsNullOrEmpty(codeType) && !string.IsNullOrEmpty(now_send_count))
							{
								for (int j = 0; j < dgv_count.Rows.Count; j++)
								{
									string str_codeType = Convert.ToString(dgv_count.Rows[j].Cells["Type_Enum"].Value);
									string str_c_codeType = Convert.ToString(dgv_count.Rows[j].Cells["c_Type_Enum"].Value);
									string str_needType_count = Convert.ToString(dgv_count.Rows[j].Cells["needType_count"].Value);
									if(str_codeType==codeType&&str_c_codeType==c_codeType)
									{
										int int_needType_count;
										int int_now_send_count;
										int.TryParse(str_needType_count, out int_needType_count);
										int.TryParse(now_send_count, out int_now_send_count);
										dgv_count.Rows[j].Cells["needType_count"].Value = int_needType_count - int_now_send_count;
									}
								}
							}
							if (num != send_count)
							{
								isRemove = false;
							}
						}
					}
				}
				if(isRemove&&!string.IsNullOrEmpty(str_temp_orderNum)&&!string.IsNullOrEmpty(str_temp_batch))
				{
					int count_n = dgv_OrderDetail.Rows.Count;
					for(int i=0;i<count_n;i++)
					{
						if(i<dgv_OrderDetail.Rows.Count)
						{
							DataGridViewRow row = dgv_OrderDetail.Rows[i];
							string temp_set_code = Convert.ToString(row.Cells["set_code"].Value);
							string temp_batch = Convert.ToString(row.Cells["batch"].Value);
							if(temp_set_code==str_temp_orderNum&&temp_batch==str_temp_batch)
							{
								dgv_OrderDetail.Rows.Remove(row);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 双击单元格事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_OrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
				CellDoubleClickDoOnDgv();
		}

		/// <summary>
		/// dgv双击事件
		/// </summary>
		private void CellDoubleClickDoOnDgv()
		{
			if (dgv_OrderDetail.Rows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.CurrentRow;
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCS_packset_dealinstrument_detail detail = new HCS_packset_dealinstrument_detail(orderNum, batch);
				detail.Pdparameters = this.Pdparameters;
				detail.WorkflowServer = this.WorkflowServer;
				detail.PdData = this.PdData;
				detail.App_id = "1020";
				detail.ShowDialog();
				DealDialogParam(detail.OrderNumChangeList);
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCS_packset_all_dealinstrument_Load(object sender, EventArgs e)
		{
			try
			{
				Win32.ReleaseCapture();
				Win32.SendMessage(this.Handle, 274, Win32.SC_MAXIMIZE, 0);

				InitComboxData();
				_isFirst = false;
			}
			catch
			{

			}

		}
	}
}
