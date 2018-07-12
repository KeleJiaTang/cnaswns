using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_manager : MetroForm
	{
		/// <summary>
		/// 所有的流程
		/// </summary>
		private SortedList sl_allpd = new SortedList();
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
		/// 用于表示它是第一次
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 当前区域id
		/// </summary>
		private string _inappid=string.Empty;
		/// <summary>
		/// 初始化
		/// </summary>
		public HCSSM_order_manager()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inappid"></param>
		public HCSSM_order_manager(string inappid)
			: this()
		{
			_inappid = inappid;
		}


		/// <summary>
		/// dic字典绑定数据
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
					if(cbb.Items.Count>1)
					{
						cbb.Enabled = true;
					}
				}
			}
		}

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
		/// <param name="item"></param>
		private void LoadData()
		{
			string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
			string bccOrBcu = txtOrderCode.Text.Trim();
			string getCustValue = GetSelectComBoBox(cbbCust, 1);
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
			string getHandleState = GetSelectComBoBox(cbbOrderState, 1);//状态
			orderGrid.Rows.Clear();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			string otherStr = string.Empty;
			//custmoer
			bool isAllCust = getCustValue == "0" || string.IsNullOrEmpty(getCustValue);
			bool isAllLocation = string.IsNullOrEmpty(getLocationVAlue) || getLocationVAlue.Equals("0");
			bool isAllOrderState = string.IsNullOrEmpty(getHandleState);
			if (!isAllOrderState)
			{
				otherStr += "and handle_state ='" + getHandleState + "'";
			}
			//custmoer
			if (_inappid == "1050")
			{
				//custmoer
				if (isAllCust)//使用区则所配的医院barcode
				{
					string customerArrange = OrderHelper.GetDicToArrangeStr(_customerDic);
					otherStr += " and hcs_customer.bar_code in ('" + customerArrange + "') ";//需要改 是一个范围
					//此处未过滤locationid 暂未改
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						Dictionary<string, string> dic = OrderHelper.GetAllHandleLocation(getCustValue, _inappid == "1050", true, true);//该处可成为私有变量放在界面初始化
						string locationArrange = OrderHelper.GetDicToArrangeStr(dic);
						otherStr += " and orderIdSet.location_id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
				}
				//custmoer
				if (!isAllCust)
				{
					otherStr += " and hcs_customer.bar_code='" + getCustValue + "' ";
					//location
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						string locationArrange = OrderHelper.GetDicToArrangeStr(_locationDic);
						otherStr += " and orderIdSet.location_id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
					//location
					if (!isAllLocation)
					{
						otherStr += " and orderIdSet.location_id='" + getLocationVAlue + "' ";
					}
				}
			}
			else
			{
				//custmoer
				if (!isAllCust)
				{
					otherStr += " and hcs_customer.bar_code='" + getCustValue + "' ";
				}
				//location
				if (!isAllLocation)
				{
					otherStr += " and orderIdSet.location_id='" + getLocationVAlue + "' ";
				}
			}
			//ordertype
			if (!string.IsNullOrEmpty(getOrderValue) && !getOrderValue.Equals("0"))
			{
				otherStr += " and  LEFT(orderSet.set_code,5)='" + getOrderValue.Trim()+ "' ";
			}
			//OrderCode
			string orderStr = string.Empty;
			if (!string.IsNullOrEmpty(bccOrBcu))
			{
				orderStr += " and set_code like '%" + bccOrBcu + "%'";
			}

			if (!string.IsNullOrEmpty(orderNameTxt.Text))
				otherStr += string.Format(" and orderIdSet.ca_name like '%{0}%'", orderNameTxt.Text);

			condition.Add(1, creEndTime.Value);
			condition.Add(2, creStartTime.Value);
			condition.Add(3, orderStr);
			condition.Add(4, otherStr);
			string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec021", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec021", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					DataRow row = data.Rows[i];
					int index = orderGrid.Rows.Add();
					string wf_code_str = Convert.ToString(row["wf_code"]);
					string[] arr_wf_code = wf_code_str.Split(',');
					string show_wf_code = string.Empty;
					foreach (string item in arr_wf_code)
					{
						if (!string.IsNullOrEmpty(item) && sl_allpd != null && sl_allpd.ContainsKey(item))
						{
							show_wf_code += item + "：" + Convert.ToString(sl_allpd[item]) + ",";
						}
					}
					if (show_wf_code.Length > 0)
					{
						show_wf_code = show_wf_code.Substring(0, show_wf_code.Length - ",".Length);
					}
					orderGrid.Rows[index].Cells["wf_code_back"].Value = wf_code_str;
					orderGrid.Rows[index].Cells["wf_code"].Value = show_wf_code;
					string tempSet_Code = Convert.ToString(row["set_code"]);
					orderGrid.Rows[index].Cells["batch"].Value = Convert.ToString(row["batch"]);
					orderGrid.Rows[index].Cells["cu_name"].Value = Convert.ToString(row["cu_name"]);
					orderGrid.Rows[index].Cells["u_uname"].Value = Convert.ToString(row["u_uname"]);
					orderGrid.Rows[index].Cells["order_type"].Value = tempSet_Code.Length > 4 ? OrderHelper.InitDgvDataOrderType(_orderTypedic, tempSet_Code.Substring(0, 5)) : OrderHelper.InitDgvDataOrderType(_orderTypedic, tempSet_Code);
					orderGrid.Rows[index].Cells["set_code"].Value = Convert.ToString(row["set_code"]);
					orderGrid.Rows[index].Cells["ca_name"].Value = Convert.ToString(row["ca_name"]);
					orderGrid.Rows[index].Cells["handle_state"].Value =OrderHelper.GetHandleStateType(Convert.ToString(row["handle_state"]));
					orderGrid.Rows[index].Cells["user_name"].Value = Convert.ToString(row["user_name"]);
					orderGrid.Rows[index].Cells["cre_date"].Value = row["cre_date"];
				}
				orderGrid.ClearSelection();
			}

		}

		/// <summary>
		/// 获取combox数据
		/// </summary>
		private void InitComboxData()
		{
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			creStartTime.Value = today;
			creEndTime.Value = today.AddDays(1).AddMilliseconds(-1);
			sl_allpd = OrderHelper.GetAllPdCodeName(CnasBaseData.SystemID);
			InitCustomerItem();
			SetComLocationItem();
			SetOrderTypeItem();
			SetComOrderStateItem();
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
			cbbLocation.Items.Clear();
			string customer_barcode = GetSelectComBoBox(cbbCust, 1);
			if(!string.IsNullOrEmpty(customer_barcode))
			{
				_locationDic = OrderHelper.GetAllHandleLocation(customer_barcode,_inappid=="1050");
				DicBindCbb(cbbLocation, _locationDic);
			}
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
		/// 订单处理状态
		/// </summary>
		private void SetComOrderStateItem()
		{
			Dictionary<string, string> dic = OrderHelper.GetAllHandleState();
			DicBindCbb(cbbOrderState, dic);
		}

		/// <summary>
		/// 设置下拉选项值
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="key_value"></param>
		/// <param name="isEnable">是否禁止</param>
		private void DoSetCbbSelectedValueItem(MetroComboBox cbb,string key_value,bool isEnable=true)
		{
			if (cbb == null || cbb.Items.Count == 0)
				return;
			bool isFind = false ;
			foreach (KeyValuePair<string, string> item in cbb.Items)
			{
				if (!isFind && item.Key == key_value)
				{
					int index = cbb.Items.IndexOf(item);
					cbb.SelectedIndex = index;
					break;
				}
			}
			if (!isFind)
				cbb.SelectedIndex = 0;
			cbb.Enabled = isEnable;
		}

		/// <summary>
		/// 查看订单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnViewOrder_Click(object sender, EventArgs e)
		{
			if (orderGrid.Rows.Count > 0 && orderGrid.SelectedRows.Count > 0)
			{
				DataGridViewRow row = orderGrid.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				string str_handleState = Convert.ToString(row.Cells["handle_state"].Value);
				bool isCanPack = str_handleState != OrderHelper.GetHandleStateType("1");
				HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
				detail.WorkflowServer = _workflowServer;
				detail.PdData = _pdData;
				detail.Pdparameters = _pdParameters;
				detail.App_ID = _inappid;
				detail.IsCanPack = isCanPack;
				detail.Mode = 2;
				detail.ShowDialog();
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 加载窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_manager_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			try
			{
				InitComboxData();
			}
			catch
			{

			}
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			_isFirst = false;
		}

		/// <summary>
		/// 打印订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnPrint_Click(object sender, EventArgs e)
		{
			if (orderGrid.Rows.Count > 0 && orderGrid.SelectedRows.Count > 0)
			{
				DataGridViewRow row = orderGrid.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Order'");
				if (arrayDR02.Length > 0)
				{
					string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
					OrderHelper.OrderPrint(orderNum, batch, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
			if (orderGrid.Rows != null && orderGrid.Rows.Count > 0)
			{
				if (orderType.Equals("所有"))
				{
					foreach (DataGridViewRow item in orderGrid.Rows)
					{
						item.Visible = true;
					}
				}
				else
				{
					foreach (DataGridViewRow item in orderGrid.Rows)
					{
						string tempCodeType = Convert.ToString(item.Cells["order_type"].Value).Trim();
						if (tempCodeType.Equals(orderType))
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
		/// 查看发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnViewSend_Click(object sender, EventArgs e)
		{
			if (orderGrid.Rows.Count > 0 && orderGrid.SelectedRows.Count > 0)
			{
				DataGridViewRow row = orderGrid.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCSSM_order_all_send allsend = new HCSSM_order_all_send(orderNum, batch);
				allsend.ShowDialog();
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
		/// 双击查看订单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ondgv_OrderDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >=0)
			{
				if (orderGrid.Rows.Count > 0)
				{
					DataGridViewRow row = orderGrid.CurrentRow;
					string orderNum = Convert.ToString(row.Cells["set_code"].Value);
					string batch = Convert.ToString(row.Cells["batch"].Value);
					string str_handleState = Convert.ToString(row.Cells["handle_state"].Value);
					bool isCanPack = str_handleState != OrderHelper.GetHandleStateType("1");
					HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
					detail.WorkflowServer = _workflowServer;
					detail.PdData = _pdData;
					detail.Pdparameters = _pdParameters;
					detail.App_ID = _inappid;
					detail.Mode = 2;
					detail.IsCanPack = isCanPack;
					detail.ShowDialog();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void txtOrderCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				LoadData();
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnViewOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderview32", EnumImageType.PNG);
			btnPrint.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnViewSend.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendorderv32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbOrderState_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				LoadData();
			}
		}
	}
}
