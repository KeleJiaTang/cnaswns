using Cnas.wns.CnasBaseClassClient;
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
	public partial class HCSSM_order_all_send : MetroForm
	{

		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;
		/// <summary>
		/// 客户名称
		/// </summary>
		public string CustomerName;
		/// <summary>
		/// 科室
		/// </summary>
		public string LocationStr;
		/// <summary>
		/// 订单类型
		/// </summary>
		public string OrderType;
		/// <summary>
		/// 订单编号
		/// </summary>
		public string OrderNum;
		/// <summary>
		/// 订单名称
		/// </summary>
		public string OrderName;
		/// <summary>
		/// 批次号
		/// </summary>
		private string _batch;
		/// <summary>
		/// 发货单数据
		/// </summary>
		private DataTable _table=new DataTable();
		/// <summary>
		/// 表示是否第一次加载
		/// </summary>
		private bool _isFirst = true;

		/// <summary>
		/// 界面出事化
		/// </summary>
		public HCSSM_order_all_send()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 根据订单号初始化界面
		/// </summary>
		/// <param name="OrderNum"></param>
		public HCSSM_order_all_send(string orderNum):this()
		{
			OrderNum = orderNum;
		}

		/// <summary>
		/// 根据订单号，批次号初始化界面
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		public HCSSM_order_all_send(string orderNum,string batch):this()
		{
			OrderNum = orderNum;
			_batch=batch;
		}

		/// <summary>
		/// 记载数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_all_send_Load(object sender, EventArgs e)
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			InitButtonImage();
			if (_orderTypedic == null || (_orderTypedic != null && _orderTypedic.Count == 0))
			{
				_orderTypedic = new Dictionary<string, string>();
				//HCS-delivery-note
				DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note'");
				if (array != null && array.Length > 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						string value_code = Convert.ToString(array[i]["value_code"]);
						string other_code = Convert.ToString(array[i]["other_code"]);
						if (!_orderTypedic.ContainsKey(other_code))
						{
							_orderTypedic.Add(other_code, value_code);
						}
					}
				}
			}
			LoadData(OrderNum);
			SetDetailData();
			_isFirst = false;
		}

		/// <summary>
		/// 设置其余属性字段
		/// </summary>
		private void SetDetailData()
		{
			txtOrderType.Text = OrderType;
			txtOrderNum.Text = OrderNum;
			txtOrderName.Text = OrderName;
			txtCustmoer.Text = CustomerName;
			txtLocation.Text = LocationStr;
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
		/// 加载数据
		/// </summary>
		/// <param name="orderNum"></param>
		private void LoadData(string orderNum)
		{
			if (!string.IsNullOrEmpty(orderNum))
			{
				SortedList condition = new SortedList();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				condition.Add(1, orderNum);
				condition.Add(2, orderNum);
				string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-sendinfo-sec003", condition);
				_table = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sendinfo-sec003", condition);
				dgv_send_order.Rows.Clear();
				if (_table != null && _table.Rows.Count > 0)
				{
					Dictionary<string, string> creDateDic = new Dictionary<string, string>();
					creDateDic.Add("--所有--", "--所有--");
					DataRow tempRow = _table.Rows[0];
					CustomerName = Convert.ToString(tempRow["cu_name"]);
					LocationStr = Convert.ToString(tempRow["u_uname"]);
					OrderName = Convert.ToString(tempRow["ca_name"]);
					OrderType = orderNum.Length > 5 ? InitDgvDataOrderType(orderNum.Substring(0, 5)) : InitDgvDataOrderType(orderNum);//订单类型
					for (int i = 0; i < _table.Rows.Count; i++)
					{
						string tempCeateDate = Convert.ToString(tempRow["cre_date"]);
						string tempbatch = Convert.ToString(tempRow["send_batch"]);
						if (!string.IsNullOrEmpty(tempCeateDate) && !string.IsNullOrEmpty(tempbatch))
						{
							if (!creDateDic.ContainsKey(tempbatch))
							{
								creDateDic.Add(tempbatch, tempCeateDate);
							}
							if (creDateDic.Count > 0)
							{
								BindingSource bs = new BindingSource();
								bs.DataSource = creDateDic;
								cbbCreDate.DataSource = bs;
								cbbCreDate.ValueMember = "Key";
								cbbCreDate.DisplayMember = "Value";
								cbbCreDate.SelectedIndex = 0;
								cbbBatchCode.DataSource = bs;
								cbbBatchCode.DisplayMember = "Key";
								cbbBatchCode.ValueMember = "Key";
								cbbBatchCode.SelectedValue = creDateDic.First().Key;
							}
						}
					}
				}
				if (cbbCreDate.SelectedItem != null)
				{
					KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbbCreDate.SelectedItem;
					string getCreDateValue = item.Value;
					string getBatchValue = Convert.ToString(cbbBatchCode.SelectedValue);
					SetDgvData(getCreDateValue, getBatchValue);
				}
			}
		}

		/// <summary>
		/// 加载dgv数据
		/// </summary>
		/// <param name="creDate"></param>
		/// <param name="batch"></param>
		private void SetDgvData(string creDate,string batch)
		{
			dgv_send_order.Rows.Clear();
			if(_table!=null&&_table.Rows.Count>0)
			{
				string tempSql = "cre_date='" + creDate + "' and batch='" + batch + "'";
				if (string.IsNullOrEmpty(batch) || batch.Equals("--所有--") || creDate.Equals("--所有--"))
				{
					tempSql=" 1=1 ";
				}
				DataRow[] arrayRow = _table.Select(tempSql);
				for (int i = 0; i < arrayRow.Length; i++)
				{
					
					DataRow tempRow = arrayRow[i];
					string send_code = Convert.ToString(tempRow["send_code"]);
					if (!string.IsNullOrEmpty(send_code))
					{
						int index = dgv_send_order.Rows.Add();
						dgv_send_order.Rows[index].Cells["send_code"].Value = tempRow["send_code"];
						dgv_send_order.Rows[index].Cells["cre_date"].Value = tempRow["cre_date"];
						dgv_send_order.Rows[index].Cells["setCountCol"].Value = tempRow["set_Count"];
						dgv_send_order.Rows[index].Cells["fillCountCol"].Value = tempRow["fill_count"];
						dgv_send_order.Rows[index].Cells["send_batch"].Value = tempRow["send_batch"];
					}
				}
			}
		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 打印发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnPrintSend_Click(object sender, EventArgs e)
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
						if (send_type.Equals("1"))
						{
							int int_send_num;
							string send_num = Convert.ToString(row["send_num"]);
							int.TryParse(send_num, out int_send_num);
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
					PrintHelper.Instance.Print_DataGridView(dgv_send_orderDetail, pringxml, tempSendOrder, new string[] { CustomerName, LocationStr });
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
		/// 选择 创建时间
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbCreDate_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				if (cbbCreDate.SelectedItem != null)
				{
					KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbbCreDate.SelectedItem;
					string getCreDateValue = item.Value;
					string getBatchValue = Convert.ToString(cbbBatchCode.SelectedValue);
					SetDgvData(getCreDateValue, getBatchValue);
				}
			}
		}

		/// <summary>
		/// 查看发货单号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnView_Click(object sender, EventArgs e)
		{
			if (dgv_send_order.Rows.Count > 0 && dgv_send_order.SelectedRows.Count>0)
			{
				DataGridViewRow row = dgv_send_order.SelectedRows[0];
				string send_order = Convert.ToString(row.Cells["send_code"].Value);
				string send_batch = Convert.ToString(row.Cells["send_batch"].Value);
				HCSSM_send_order_detail detail = new HCSSM_send_order_detail(send_order, send_batch);
				detail.ShowDialog();
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 查看发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ondgv_send_order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (dgv_send_order.Rows.Count > 0)
				{
					DataGridViewRow row = dgv_send_order.CurrentRow;
					string send_order = Convert.ToString(row.Cells["send_code"].Value);
					string send_batch = Convert.ToString(row.Cells["send_batch"].Value);
					HCSSM_send_order_detail detail = new HCSSM_send_order_detail(send_order, send_batch);
					detail.ShowDialog();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnPrintSend.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnView.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendorderView32", EnumImageType.PNG);
		}
	}
}
