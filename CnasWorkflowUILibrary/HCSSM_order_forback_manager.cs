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

	public partial class HCSSM_order_forback_manager : MetroForm
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
		/// 所有的流程
		/// </summary>
		private SortedList sl_allpd = new SortedList();
		/// <summary>
		/// 用于表示它是第一次
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 当前区域id
		/// </summary>
		private string _inappid = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inappid"></param>
		public HCSSM_order_forback_manager(string inappid)
		{
			_inappid = inappid;
			InitializeComponent();
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
		private void LoadData()
		{
			dgv_OrderDetail.Rows.Clear();
			string orderCode = txtOrderCode.Text.Trim();//条码
			string getCustValue = GetSelectComBoBox(cbbCust, 1);//客户编码
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);//使用地点id
			string getTempCode = txtTempCode.Text.Trim();//铁牌
			string getHandleState = GetSelectComBoBox(cbbOrderState, 1);//状态
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string orderStr = string.Empty;
			string otherStr = string.Empty;
			string workSetTempwf_code = OrderHelper.GetValueCode("HCS-procedure-data", "Order_out_wf");
			bool isAllOrderState =string.IsNullOrEmpty(getHandleState);
			if(!isAllOrderState)
			{
				otherStr += "and handle_state ='" + getHandleState + "'";
			}
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
			//orderCode
			if (!string.IsNullOrEmpty(orderCode))
			{
				orderStr += " and set_code like '%" + orderCode + "%'";
			}
			if(!string.IsNullOrEmpty(getTempCode))
			{
				if(getTempCode.Length==13)
				{
					otherStr += "and orderSet.set_code in ( SELECT set_code from (SELECT set_code from hcs_set_mapping where tem_code='"+getTempCode+"' ORDER BY cre_date desc LIMIT 0,1)t)";
				}
				if(getTempCode.Length!=13)
				{
					otherStr += "and orderSet.set_code in ( SELECT set_code from hcs_set_mapping where tem_code like '%"+getTempCode+"%')";
				}
			}
			DateTime creStartValue = creStartTime.Value;
			DateTime creEndValue = creEndTime.Value;
			if (_isFirst)
			{
				creStartValue = new DateTime(1900, 1, 1);
				creEndValue = DateTime.Now;
			}
			if (!string.IsNullOrEmpty(orderNameTxt.Text))
				otherStr += string.Format(" and orderIdSet.ca_name like '%{0}%'", orderNameTxt.Text);
			SortedList condition = new SortedList();
			condition.Add(1, creEndValue);
			condition.Add(2, creStartValue);
			condition.Add(3, orderStr);
			condition.Add(4, workSetTempwf_code);
			condition.Add(5, otherStr);
			string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec016", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec016", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					DataRow row = data.Rows[i];
					int index = dgv_OrderDetail.Rows.Add();
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
					string tempSet_Code = Convert.ToString(row["set_code"]);
					dgv_OrderDetail.Rows[index].Cells["batch"].Value = Convert.ToString(row["batch"]);
					dgv_OrderDetail.Rows[index].Cells["cu_name"].Value = Convert.ToString(row["cu_name"]);
					dgv_OrderDetail.Rows[index].Cells["u_uname"].Value = Convert.ToString(row["u_uname"]);
					//dgv_OrderDetail.Rows[index].Cells["order_type"].Value = tempSet_Code.Length > 4 ? InitDgvDataOrderType(tempSet_Code.Substring(0, 5)) : InitDgvDataOrderType(tempSet_Code);
					dgv_OrderDetail.Rows[index].Cells["set_code"].Value = Convert.ToString(row["set_code"]);
					dgv_OrderDetail.Rows[index].Cells["ca_name"].Value = Convert.ToString(row["ca_name"]);
					dgv_OrderDetail.Rows[index].Cells["handle_state"].Value = OrderHelper.GetHandleStateType(Convert.ToString(row["handle_state"]));
					dgv_OrderDetail.Rows[index].Cells["user_name"].Value = Convert.ToString(row["user_name"]);
					dgv_OrderDetail.Rows[index].Cells["cre_date"].Value = Convert.ToString(row["cre_date"]);
					dgv_OrderDetail.Rows[index].Cells["wf_code_back"].Value = wf_code_str;
					dgv_OrderDetail.Rows[index].Cells["wf_code"].Value = show_wf_code;
					dgv_OrderDetail.Rows[index].Cells["isToPackOut"].Value = Convert.ToString(row["isToPackOut"]);
				}
				dgv_OrderDetail.ClearSelection();
				dgv_OrderDetail.ContextMenuStrip = dgv_Do;
			}
			if (data == null || data.Rows.Count == 0)
			{
				dgv_OrderDetail.ContextMenuStrip = null;
			}

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
					if (cbb.Items.Count > 1)
					{
						cbb.Enabled = true;
					}
				}
			}
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void InitComboxData()
		{
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			creStartTime.Value = today;
			creEndTime.Value = today.AddDays(1).AddMilliseconds(-1);
			InitCustomerItem();
			SetComLocationItem();
			SetComOrderStateItem();
			sl_allpd = OrderHelper.GetAllPdCodeName(CnasBaseData.SystemID);
			LoadData();
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
		/// 仅仅设置客户名称
		/// </summary>
		private void InitCustomerItem()
		{
			_customerDic = OrderHelper.GetAllHandleCustomer();
			DicBindCbb(cbbCust, _customerDic);
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
		/// 打印签收单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				string pringxml = string.Empty;
				DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='OrderForBack'");
				if (arrayDR02.Length > 0)
				{
					pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
				}
				if (!string.IsNullOrEmpty(pringxml))
				{
					DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
					string orderNum = Convert.ToString(row.Cells["set_code"].Value);
					string batch = Convert.ToString(row.Cells["batch"].Value);
					OrderHelper.BackOrderPrint(orderNum, batch, pringxml);
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
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbLocation_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				//do search
				LoadData();
			}
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
				LoadData();
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			//btnHandleOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDoOrder32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			//btnPrintForBack.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
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
		/// 右键打开事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_Do_Opening(object sender, CancelEventArgs e)
		{
			if (dgv_OrderDetail.CurrentRow != null)
			{
				string str_Handle = Convert.ToString(dgv_OrderDetail.CurrentRow.Cells["handle_state"].Value);
				bool isHandled=str_Handle == OrderHelper.GetHandleStateType("1");
				if (isHandled)
				{
					printBackOrder.Visible = true;
				}
				else
				{
					printBackOrder.Visible = false;
				}
				if (_inappid == "1050")
				{
					useArea_Out.Visible = true;
					toPackArea_Out.Visible = !isHandled;
					packArea_Out.Visible = false;
				}
				if (_inappid == "1020")
				{
					packArea_Out.Visible = true;
					useArea_Out.Visible = false;
					toPackArea_Out.Visible = false;
				}
			}
		}

		/// <summary>
		/// 使用区-出院
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void useArea_Out_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.CurrentRow != null)
			{
				DataGridViewRow row = dgv_OrderDetail.CurrentRow;
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCSSM_order_forback_detail forBack = new HCSSM_order_forback_detail(orderNum, batch, "useArea_Out");
				forBack.ShowDialog();
				LoadData();
			}
		}

		/// <summary>
		/// 转到打包区出院
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toPackArea_Out_Click(object sender, EventArgs e)
		{
			//info_name  toPackArea_Out
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.CurrentRow != null)
			{
				DataGridViewRow row = dgv_OrderDetail.CurrentRow;
				string str_isToPackOut = Convert.ToString(row.Cells["isToPackOut"].Value);
				if(str_isToPackOut=="1")
				{
					MessageBox.Show("对不起，该订单已转到清洗了，不能再转了");
					return;
				}
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				string orderName = Convert.ToString(row.Cells["ca_name"].Value);
				SortedList condition = new SortedList();
				SortedList orderWorkset = new SortedList();
				SortedList bcuWorkset = new SortedList();
				SortedList orderSendInfo = new SortedList();
				SortedList orderWorksetInfo = new SortedList();
				SortedList inOrderWorkset = new SortedList();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				string workSetTempwf_code = OrderHelper.GetValueCode("HCS-procedure-data", "Order_out_wf");//3015
				string wf_code = OrderHelper.GetValueCode("HCS-procedure-data", "Add_washing_count");//2030;
				SortedList par_orderWorkset = new SortedList();
				par_orderWorkset.Add(1, workSetTempwf_code);
				par_orderWorkset.Add(2, orderNum);
				orderWorkset.Add(1, par_orderWorkset);
				SortedList par_bcuWorkset = new SortedList();
				par_bcuWorkset.Add(1, orderNum);
				bcuWorkset.Add(1, par_bcuWorkset);
				SortedList par_orderSendInfo = new SortedList();
				par_orderSendInfo.Add(1, orderNum);
				orderSendInfo.Add(1, par_orderSendInfo);
				SortedList par_orderWorksetInfo = new SortedList();
				par_orderWorksetInfo.Add(1, str_Seria);
				par_orderWorksetInfo.Add(2, "toPackArea_Out");
				par_orderWorksetInfo.Add(3, orderNum);
				par_orderWorksetInfo.Add(4, 3);
				par_orderWorksetInfo.Add(5, CnasBaseData.UserID);
				orderWorksetInfo.Add(1, par_orderWorksetInfo);
				SortedList par_inOrderWorkset = new SortedList();
				par_inOrderWorkset.Add(1, orderNum);
				par_inOrderWorkset.Add(2, orderNum);
				par_inOrderWorkset.Add(3, orderName);
				par_inOrderWorkset.Add(4, wf_code);
				par_inOrderWorkset.Add(5, CnasBaseData.UserID);
				par_inOrderWorkset.Add(6, str_Seria);
				par_inOrderWorkset.Add(7, string.Empty);//container_code
				par_inOrderWorkset.Add(8, string.Empty);//BCU_code
				par_inOrderWorkset.Add(9, 0);//status
				par_inOrderWorkset.Add(10, "再次清洗");//remark
				par_inOrderWorkset.Add(11, 0);
				par_inOrderWorkset.Add(12, batch);
				inOrderWorkset.Add(1, par_inOrderWorkset);
				condition.Add(1, orderWorkset);
				condition.Add(2, bcuWorkset);
				condition.Add(3, orderSendInfo);
				condition.Add(4, orderWorksetInfo);
				condition.Add(5, inOrderWorkset);
				string testUpData = reCnasRemotCall.RemotInterface.CheckUPDataList("hcs_work_specialset_info-up008", condition);
				int saveResult = reCnasRemotCall.RemotInterface.UPDataList("hcs_work_specialset_info-up008", condition);
				if (saveResult > 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				LoadData();
			}
		}

		/// <summary>
		/// 打包区-出院
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void packArea_Out_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.CurrentRow != null)
			{
				DataGridViewRow row = dgv_OrderDetail.CurrentRow;
				string orderNum = Convert.ToString(row.Cells["set_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCSSM_order_forback_detail forBack = new HCSSM_order_forback_detail(orderNum, batch, "packArea_Out");
				forBack.ShowDialog();
				LoadData();
			}
		}


		/// <summary>
		/// 打印-签收单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void printBackOrder_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.CurrentRow != null)
			{
				string pringxml = string.Empty;
				DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='OrderForBack'");
				if (arrayDR02.Length > 0)
				{
					pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
				}
				if (!string.IsNullOrEmpty(pringxml))
				{
					DataGridViewRow row = dgv_OrderDetail.CurrentRow;
					string orderNum = Convert.ToString(row.Cells["set_code"].Value);
					string batch = Convert.ToString(row.Cells["batch"].Value);
					OrderHelper.BackOrderPrint(orderNum, batch, pringxml);
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
		/// 输入铁牌按回车键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtTempCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				LoadData();
			}
		}

		private void cbbOrderState_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(!_isFirst)
			{
				LoadData();
			}
		}
	}
}
