using Cnas.wns.CnasBaseClassClient;
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
	public partial class HCSSM_send_order_manager : MetroForm
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
		/// 区域id
		/// </summary>
		public string App_ID=string.Empty;
		/// <summary>
		/// 用于表示它是第一次
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 窗体初始化事件
		/// </summary>
		public HCSSM_send_order_manager()
		{
			InitializeComponent();
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			creStartTime.Value = today;
			creEndTime.Value = today.AddDays(1).AddMilliseconds(-1);
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
		/// 仅仅设置客户名称
		/// </summary>
		private void InitCustomerItem()
		{
			_customerDic = OrderHelper.GetAllHandleCustomer();
			DicBindCbb(cbbCust, _customerDic);
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
				_locationDic = OrderHelper.GetAllHandleLocation(customer_barcode, App_ID == "1050");
				DicBindCbb(cbbLocation, _locationDic);
			}
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
		/// 查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSearch_Click(object sender, EventArgs e)
		{
			DoLoadData();
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void DoLoadData()
		{
			string send_order = txtSendOrder.Text.Trim();
			string orderNum = txtOrderNum.Text.Trim();
			string bccCode = txtBccCode.Text.Trim();
			DateTime startTime = creStartTime.Value;
			DateTime endTime = creEndTime.Value;
			string getCustValue = GetSelectComBoBox(cbbCust, 1);
			string getLocationVAlue = GetSelectComBoBox(cbbLocation, 1);
			LoadDgvData(startTime, endTime, send_order, orderNum, bccCode, getCustValue, getLocationVAlue);
		}

		/// <summary>
		/// 查看发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnView_Click(object sender, EventArgs e)
		{
			if(dgv_send_order.Rows.Count>0&&dgv_send_order.SelectedRows.Count==1)
			{
				DataGridViewRow row = dgv_send_order.SelectedRows[0];
				string send_order = Convert.ToString(row.Cells["send_code"].Value);
				string send_batch = Convert.ToString(row.Cells["send_batch"].Value);
				HCSSM_send_order_detail detail = new HCSSM_send_order_detail(send_order, send_batch);
				detail.ShowDialog();
			}
		}

		/// <summary>
		/// 获取名称类型
		/// </summary>
		/// <param name="fullName"></param>
		/// <param name="splitStr"></param>
		/// <returns></returns>
		private string GetTypeName(string fullName, string splitStr)
		{
			int index_of = fullName.IndexOf(splitStr);
			if (index_of > -1)
			{
				return fullName.Substring(0, index_of);
			}
			return fullName;
		}

		/// <summary>
		/// 打印发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnPrint_Click(object sender, EventArgs e)
		{
			if (dgv_send_order.Rows.Count > 0 && dgv_send_order.SelectedRows.Count == 1)
			{
				string tempSendOrder = Convert.ToString(dgv_send_order.SelectedRows[0].Cells["send_code"].Value);
				string tempSendBatch = Convert.ToString(dgv_send_order.SelectedRows[0].Cells["send_batch"].Value);

				//打印datagrid
				DataGridView dgv_send_orderDetail = new DataGridView();
				dgv_send_orderDetail.AllowUserToAddRows = false;
				//序号so_id 客户名称 so_cu_name 科室so_u_uname 品名 so_set_name 数量 so_num 时间 so_cre_date 备注 so_remark
				DataGridViewTextBoxColumn so_id = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn so_ca_name = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn so_num = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn so_remark = new DataGridViewTextBoxColumn();
				dgv_send_orderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
						so_id,
						so_ca_name,
						so_num,
						so_remark,
						});
				// 
				// 序号so_id 
				// 
				so_id.HeaderText = "序号";
				so_id.Name = "so_id";
				// 器械名称so_ca_name
				// 
				so_ca_name.HeaderText = "品名";
				so_ca_name.Name = "so_ca_name";
				// 
				// 数量o_num
				// 
				so_num.HeaderText = "数量";
				so_num.Name = "so_num";
				// 
				//  备注o_remark 
				// 
				so_remark.HeaderText = "备注";
				so_remark.Name = "so_remark";
				//dgv_send_orderDetail
				Dictionary<string, int> dicSendOrder = new Dictionary<string, int>();
				Dictionary<string, int> dicNoLabelSendOrder = new Dictionary<string, int>();
				string CustomerName, LocationStr;
				CustomerName = LocationStr = string.Empty;
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList condition = new SortedList();
				condition.Add(1, tempSendOrder);
				condition.Add(2, tempSendBatch);
				//string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-sendinfo-sec002", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sendinfo-sec002", condition);
				if (data != null && data.Rows.Count > 0)
				{
					CustomerName = Convert.ToString(data.Rows[0]["cu_name"]);
					LocationStr = Convert.ToString(data.Rows[0]["u_uname"]);
					for (int i = 0; i < data.Rows.Count; i++)
					{
						DataRow row = data.Rows[i];
						string send_type = Convert.ToString(row["send_type"]);
						string bcu_code = Convert.ToString(row["bcu_code"]);
						string bcc_code = Convert.ToString(row["bcc_code"]);
						string ca_name = Convert.ToString(row["ca_name"]);
						if(send_type.Equals("1"))
						{
							int int_send_num;
							string send_num=Convert.ToString(row["send_num"]);
							int.TryParse(send_num,out int_send_num);
							if (!dicNoLabelSendOrder.ContainsKey(ca_name))
								dicNoLabelSendOrder.Add(ca_name, int_send_num);
							else
								dicNoLabelSendOrder[ca_name] += int_send_num;

						}
						if (send_type.Equals("2"))
						{
							string tempName = GetTypeName(ca_name, "<");
							if (dicSendOrder.ContainsKey(tempName))
								dicSendOrder[tempName] += 1;
							else
								dicSendOrder.Add(tempName, 1);
						}
					}
				}
				DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Invoice'");
				if (arrayDR02.Length > 0)
				{
					string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
					if (dicSendOrder.Count > 0)
					{
						foreach (KeyValuePair<string, int> item in dicSendOrder)
						{
							int index = dgv_send_orderDetail.Rows.Add();
							dgv_send_orderDetail.Rows[index].Cells["so_id"].Value = index + 1;
							dgv_send_orderDetail.Rows[index].Cells["so_ca_name"].Value = item.Key;
							dgv_send_orderDetail.Rows[index].Cells["so_num"].Value = item.Value;
							dgv_send_orderDetail.Rows[index].Cells["so_remark"].Value = string.Empty;
						}
					}
					if (dicNoLabelSendOrder.Count > 0)
					{
						foreach (KeyValuePair<string, int> item in dicNoLabelSendOrder)
						{
							int index = dgv_send_orderDetail.Rows.Add();
							dgv_send_orderDetail.Rows[index].Cells["so_id"].Value = index + 1;
							dgv_send_orderDetail.Rows[index].Cells["so_ca_name"].Value = item.Key;
							dgv_send_orderDetail.Rows[index].Cells["so_num"].Value = item.Value;
							dgv_send_orderDetail.Rows[index].Cells["so_remark"].Value = string.Empty;
						}
					}
					PrintHelper.Instance.Print_DataGridView(dgv_send_orderDetail, pringxml, tempSendOrder,new string[]{CustomerName,LocationStr});
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// 初始化datagridview
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="type"></param>
		private void InitSend_order(DataGridView grid,int type)
		{
			if (type == 1)
			{
				DataGridViewTextBoxColumn b_id = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn b_bar_code = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn t_b_bar_code = new DataGridViewTextBoxColumn();
				grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				b_id,
				b_bar_code,
				t_b_bar_code});
				// 
				// b_id
				// 
				b_id.HeaderText = " 序号";
				b_id.Name = "bid";
				b_id.ReadOnly = true;
				// 
				// b_bar_code
				// 
				b_bar_code.HeaderText = "条码";
				b_bar_code.Name = "b_bar_code";
				b_bar_code.ReadOnly = true;
				// 
				// t_b_bar_code
				// 
				t_b_bar_code.HeaderText = "T条形码";
				t_b_bar_code.Name = "t_b_bar_code";
				t_b_bar_code.ReadOnly = true;
				t_b_bar_code.Visible = false;
			}
			else if(type==2)
			{
				DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn u_bar_code = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn ca_name = new DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn bar_code = new DataGridViewTextBoxColumn();
				grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				id,
				u_bar_code,
				ca_name,
				bar_code});
				// id
				// 
				id.HeaderText = "序号";
				id.Name = "id";
				id.ReadOnly = true;
				// 
				// u_bar_code
				// 
				u_bar_code.HeaderText = "条码";
				u_bar_code.Name = "u_bar_code";
				u_bar_code.ReadOnly = true;
				// 
				// ca_name
				// 
				ca_name.HeaderText = "器械包名称";
				ca_name.Name = "ca_name";
				ca_name.ReadOnly = true;
				// 
				// bar_code
				// 
				bar_code.HeaderText = "bcc码";
				bar_code.Name = "bar_code";
				bar_code.ReadOnly = true;
				bar_code.Visible = false;
				// 
			}

		}
		/// <summary>
		/// 加载grid数据
		/// </summary>
		private void LoadDgvData(DateTime startTime, DateTime endTime, string send_order, string orderNum, string bccCode, string getCustValue, string getLocationVAlue)
		{
			dgv_send_order.Rows.Clear();
			SortedList condition = new SortedList();
			string tempCondition=string.Empty;
			condition.Add(1, startTime);
			condition.Add(2, endTime);
			if(!string.IsNullOrEmpty(send_order))
			{
				tempCondition += " and send_code like '%"+send_order+"%'";
			}
			if(!string.IsNullOrEmpty(orderNum))
			{
				tempCondition += " and order_code like '%"+orderNum+"%'";
			}
			if(!string.IsNullOrEmpty(bccCode))
			{
				tempCondition += "and ( bcu_code like '%"+bccCode+"%' or bcc_code like '%"+bccCode+"%')";
			}
			condition.Add(3,tempCondition);
			string custCondition = string.Empty;
			//custmoer
			//custmoer
			bool isAllCust = getCustValue == "0" || string.IsNullOrEmpty(getCustValue);
			bool isAllLocation = string.IsNullOrEmpty(getLocationVAlue) || getLocationVAlue.Equals("0");
			//custmoer
			if (App_ID == "1050")
			{
				//custmoer
				if (isAllCust)//使用区则所配的医院barcode
				{
					string customerArrange = OrderHelper.GetDicToArrangeStr(_customerDic);
					custCondition += " and cus.bar_code in ('" + customerArrange + "') ";//需要改 是一个范围
					//此处未过滤locationid 暂未改
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						Dictionary<string, string> dic = OrderHelper.GetAllHandleLocation(getCustValue, App_ID == "1050", true, true);//该处可成为私有变量放在界面初始化
						string locationArrange = OrderHelper.GetDicToArrangeStr(dic);
						custCondition += " and loc.id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
				}
				//custmoer
				if (!isAllCust)
				{
					custCondition += " and cus.bar_code='" + getCustValue + "' ";
					//location
					if (isAllLocation)//使用区所匹配的使用地点id
					{
						string locationArrange = OrderHelper.GetDicToArrangeStr(_locationDic);
						custCondition += " and loc.id in ('" + locationArrange + "') ";//需要改 是一个范围
					}
					//location
					if (!isAllLocation)
					{
						custCondition += " and loc.id='" + getLocationVAlue + "' ";
					}
				}
			}
			else
			{
				//custmoer
				if (!isAllCust)
				{
					custCondition += " and cus.bar_code='" + getCustValue + "' ";
				}
				//location
				if (!isAllLocation)
				{
					custCondition += " and loc.id='" + getLocationVAlue + "' ";
				}
			}

			if (!string.IsNullOrEmpty(orderNameTxt.Text))
				custCondition += string.Format(" and orderId.ca_name like '%{0}%'", orderNameTxt.Text);

			condition.Add(4, custCondition);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
#if DEBUG
			string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-sendinfo-sec005", condition);
#endif
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sendinfo-sec005", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					//u_uname cu_name set_Count
					DataRow tempRow = data.Rows[i];
					int index = dgv_send_order.Rows.Add();
					dgv_send_order.Rows[index].Cells["orderCodeCol"].Value = tempRow["bar_code"];
					dgv_send_order.Rows[index].Cells["orderNameCol"].Value = tempRow["ca_name"];
					dgv_send_order.Rows[index].Cells["fillCol"].Value = tempRow["fill_count"];
					dgv_send_order.Rows[index].Cells["send_code"].Value = tempRow["send_code"];
					dgv_send_order.Rows[index].Cells["cre_date"].Value = tempRow["cre_date"];
					dgv_send_order.Rows[index].Cells["send_batch"].Value = tempRow["send_batch"];
					dgv_send_order.Rows[index].Cells["cu_name"].Value = tempRow["cu_name"];
					dgv_send_order.Rows[index].Cells["u_uname"].Value = tempRow["u_uname"];
					dgv_send_order.Rows[index].Cells["set_Count"].Value = tempRow["set_Count"];
				}
			}
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_send_order_manager_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			InitCustomerItem();
			SetComLocationItem();
			DoLoadData();
			_isFirst = false;
		}

		/// <summary>
		/// 双击查看发货单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_send_order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			if (dgv_send_order.Rows.Count > 0)
			{
				DataGridViewRow row = dgv_send_order.CurrentRow;
				string send_order = Convert.ToString(row.Cells["send_code"].Value);
				string send_batch = Convert.ToString(row.Cells["send_batch"].Value);
				HCSSM_send_order_detail detail = new HCSSM_send_order_detail(send_order, send_batch);
				detail.ShowDialog();
			}
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSendOrder_KeyDown(object sender, KeyEventArgs e)
		{
			KeyEnter(e);
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtOrderNum_KeyDown(object sender, KeyEventArgs e)
		{
			KeyEnter(e);
		}

		/// <summary>
		/// enterEvent
		/// </summary>
		private void KeyEnter(KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				DoLoadData();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBccCode_KeyDown(object sender, KeyEventArgs e)
		{
			KeyEnter(e);
		}


		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnPrint.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnView.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendorderv32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 使用地点更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbLocation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				DoLoadData();
			}
		}

		/// <summary>
		/// 客户名称更改
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

	}
}
