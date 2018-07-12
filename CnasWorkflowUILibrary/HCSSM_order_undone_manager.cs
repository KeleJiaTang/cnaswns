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

	public partial class HCSSM_order_undone_manager : MetroForm
	{
		/// <summary>
		/// 使用地点
		/// </summary>
		private Dictionary<string, string> _locationDic;
		/// <summary>
		/// 客户名称
		/// </summary>
		private Dictionary<string, string> _customerDic;
		/// <summary>
		/// 工单
		/// </summary>
		private CnasHCSWorkflowInterface _cnasHCSWorkflowInterface01;
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
		private string _inappid;
		/// <summary>
		/// 初始化
		/// </summary>
		public HCSSM_order_undone_manager()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inappid"></param>
		public HCSSM_order_undone_manager(string inappid, CnasHCSWorkflowInterface cnasHCSWorkflowInterface01)
			: this()
		{
			_inappid = inappid;
			_cnasHCSWorkflowInterface01 = cnasHCSWorkflowInterface01;
		}

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSearch_Click(object sender, EventArgs e)
		{
			string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
			string bccOrBcu = txtOrderCode.Text.Trim();
			string getCustValue = GetSelectComBoBox(cbbCust, 1);
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
			LoadData(getOrderValue, getCustValue, bccOrBcu, getLocationVAlue);
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="getOrderValue"></param>
		/// <param name="getCustValue"></param>
		/// <param name="bccOrBcu">订单编号</param>
		/// <param name="getLocationVAlue"></param>
		private void LoadData(string getOrderValue, string getCustValue, string bccOrBcu, string getLocationVAlue)
		{
			dgv_OrderDetail.Rows.Clear();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string orderStr = string.Empty;
			string otherStr = string.Empty;
			string workSetTempwf_code = CnasBaseDataHelper.Wf_SingleValue("HCS-procedure-data", "Order_without_entity_wf");
			//custmoer
			bool isAllCust = getCustValue == "0" || string.IsNullOrEmpty(getCustValue);
			bool isAllLocation = string.IsNullOrEmpty(getLocationVAlue) || getLocationVAlue.Equals("0");
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
				otherStr += " and  LEFT(orderSet.set_code,5)='" + getOrderValue.Trim() + "' ";
			}
			//orderCode
			if (!string.IsNullOrEmpty(bccOrBcu))
			{
				orderStr += " and set_code like '%" + bccOrBcu + "%'";
			}
			DateTime creStartValue = creStartTime.Value;
			DateTime creEndValue = creEndTime.Value;
			if (_isFirst)
			{
				creStartValue = new DateTime(1900, 1, 1);
				creEndValue = DateTime.Now;
			}
			SortedList condition = new SortedList();
			condition.Add(1, creEndValue);
			condition.Add(2, creStartValue);
			condition.Add(3, orderStr);
			condition.Add(4, workSetTempwf_code);
			condition.Add(5, otherStr);
#if DEBUG
			string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec022", condition);
#endif
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec022", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					DataRow row = data.Rows[i];
					int index = dgv_OrderDetail.Rows.Add();
					string tempSet_Code = Convert.ToString(row["set_code"]);
					dgv_OrderDetail.Rows[index].Cells["batch"].Value = Convert.ToString(row["batch"]);
					dgv_OrderDetail.Rows[index].Cells["cu_name"].Value = Convert.ToString(row["cu_name"]);
					dgv_OrderDetail.Rows[index].Cells["u_uname"].Value = Convert.ToString(row["u_uname"]);
					dgv_OrderDetail.Rows[index].Cells["order_type"].Value = tempSet_Code.Length > 4 ? InitDgvDataOrderType(tempSet_Code.Substring(0, 5)) : InitDgvDataOrderType(tempSet_Code);
					dgv_OrderDetail.Rows[index].Cells["set_code"].Value = Convert.ToString(row["set_code"]);
					dgv_OrderDetail.Rows[index].Cells["ca_name"].Value = Convert.ToString(row["ca_name"]);
					dgv_OrderDetail.Rows[index].Cells["handle_state"].Value = OrderHelper.GetHandleStateType(Convert.ToString(row["handle_state"]));
					dgv_OrderDetail.Rows[index].Cells["user_name"].Value = Convert.ToString(row["user_name"]);
					dgv_OrderDetail.Rows[index].Cells["cre_date"].Value = row["cre_date"];
				}
				dgv_OrderDetail.ClearSelection();
			}

		}

		/// <summary>
		/// 初始化dgv 订单类型
		/// </summary>
		/// <param name="orderType"></param>
		/// <returns></returns>
		private string InitDgvDataOrderType(string orderType)
		{
			if (_orderTypedic != null && _orderTypedic.Count > 0)
			{
				if (_orderTypedic.ContainsKey(orderType))
				{
					return _orderTypedic[orderType].ToString();
				}
				return orderType;
			}
			return orderType;
		}

		/// <summary>
		/// 获取combox数据
		/// </summary>
		private void InitComboxData()
		{
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			creStartTime.Value = today;
			creEndTime.Value = today.AddDays(1).AddMilliseconds(-1);
			InitCustomerItem();
			SetComLocationItem();
			SetOrderTypeItem();
			string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
			string bccOrBcu = txtOrderCode.Text.Trim();
			string getCustValue = GetSelectComBoBox(cbbCust, 1);
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
			LoadData(getOrderValue, getCustValue, bccOrBcu, getLocationVAlue);
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
			if (cbb.SelectedItem != null)
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
			if (!string.IsNullOrEmpty(customer_barcode))
			{
				_locationDic = OrderHelper.GetAllHandleLocation(customer_barcode, _inappid == "1050");
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
		/// 查看订单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewOrder_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
				detail.Mode = 2;
				detail.ShowDialog();
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 处理订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnHandleOrder_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				if (_inappid == "1030")
				{
					try
					{
						HCSSM_order_new_order_handle handle = new HCSSM_order_new_order_handle(orderNum, batch, _inappid, _cnasHCSWorkflowInterface01);
						handle.ShowDialog();
						if (handle.DialogResult == DialogResult.OK)
						{
							OnbtnSearch_Click(null, null);
						}
					}
					catch (Exception ex)
					{

					}
				}
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
			InitComboxData();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			//1010 去污区,1030灭菌存储区，1020 打包区
			string[] listpdid = { "1010", "1030", "1020" };
			if ((!_inappid.Equals("1030")) && CnasBaseData.UserBaseInfo.UserType != 9)
			{
				btnHandleOrder.Visible = false;
			}
			else
			{
				btnHandleOrder.Visible = true;
			}
			_isFirst = false;
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
			if (dgv_OrderDetail.Rows != null && dgv_OrderDetail.Rows.Count > 0)
			{
				if (orderType.Equals("所有"))
				{
					foreach (DataGridViewRow item in dgv_OrderDetail.Rows)
					{
						item.Visible = true;
					}
				}
				else
				{
					foreach (DataGridViewRow item in dgv_OrderDetail.Rows)
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
		private void btnViewSend_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
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
				string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
				string bccOrBcu = txtOrderCode.Text.Trim();
				string getCustValue = GetSelectComBoBox(cbbCust, 1);
				string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
				LoadData(getOrderValue, getCustValue, bccOrBcu, getLocationVAlue);
			}
		}



		/// <summary>
		/// 处理订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ondgv_OrderDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.CurrentRow;
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				if (_inappid == "1030")
				{
					try
					{
						HCSSM_order_new_order_handle handle = new HCSSM_order_new_order_handle(orderNum, batch, _inappid, _cnasHCSWorkflowInterface01);
						handle.ShowDialog();
						if (handle.DialogResult == DialogResult.OK)
						{
							OnbtnSearch_Click(null, null);
						}
					}
					catch (Exception ex)
					{

					}
				}
				else
				{
					HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
					detail.Mode = 2;
					detail.ShowDialog();
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 订单查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearchOrder_Click(object sender, EventArgs e)
		{
			HCSSM_order_manager allOrderManager = new HCSSM_order_manager(_inappid);
			allOrderManager.ShowDialog();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtOrderCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				//do search
				string getOrderValue = GetSelectComBoBox(cbbOrderType, 1).Trim();
				string bccOrBcu = txtOrderCode.Text.Trim();
				string getCustValue = GetSelectComBoBox(cbbCust, 1);
				string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
				LoadData(getOrderValue, getCustValue, bccOrBcu, getLocationVAlue);
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
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
	}
}
