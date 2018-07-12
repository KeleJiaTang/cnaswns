using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using log4net;
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
	public partial class HCSSM_order_forback_detail : MetroForm
	{
		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;
		/// <summary>
		/// 保存执行结果
		/// </summary>
		public int SaveResult;
		/// <summary>
		/// 客户名称
		/// </summary>
		private string _CustomerName;
		/// <summary>
		/// 科室
		/// </summary>
		private string _LocationStr;
		/// <summary>
		/// 订单类型
		/// </summary>
		private string _OrderType;
		/// <summary>
		/// 订单编号
		/// </summary>
		private string _OrderNum;
		/// <summary>
		/// 订单名称
		/// </summary>
		private string _OrderName;
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime _DataForCre;
		/// <summary>
		/// 创建人
		/// </summary>
		private string _UserName;
		/// <summary>
		/// 批次号
		/// </summary>
		private string _batch;
		/// <summary>
		/// 出院时写入hcs_work_set_info的info_name
		/// </summary>
		private string _info_name;

		/// <summary>
		/// 初始化窗体
		/// </summary>
		/// <param name="orderNum">订单号</param>
		/// <param name="batch">批次号</param>
		/// <param name="info_name">出院时写入hcs_work_set_info的info_name</param>
		public HCSSM_order_forback_detail(string orderNum, string batch, string info_name)
		{
			_OrderNum = orderNum;
			_batch = batch;
			_info_name = info_name;
			InitializeComponent();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 加载窗体事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_new_order_detail_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			_orderTypedic = OrderHelper.GetOrderTypeItem(false);
			LoadData();
		}

		/// <summary>
		/// 设置其余属性字段
		/// </summary>
		private void SetDetailData()
		{
			txtOrderType.Text = _OrderType;
			txtOrderNum.Text = _OrderNum;
			txtOrderName.Text = _OrderName;
			txtOrderPerson.Text = _UserName;
			txtCreTime.Text = _DataForCre.ToString("yyyy年MM月dd日 HH:mm");
			txtCustmoer.Text = _CustomerName;
			txtLocation.Text = _LocationStr;
		}


		private void LoadData()
		{
			dgv_Instrument.Rows.Clear();
			string wf_code = OrderHelper.GetValueCode("HCS-procedure-data", "Order_out_wf");
			SortedList condition = new SortedList();
			condition.Add(1, _OrderNum);
			condition.Add(2, _batch);
			condition.Add(3, _OrderNum);
			condition.Add(4, _batch);
			condition.Add(5, wf_code);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec017", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec017", condition);
			SetDgvByDataTable(data);

		}

		/// <summary>
		/// 绑定table
		/// </summary>
		/// <param name="table"></param>
		private void SetDgvByDataTable(DataTable data)
		{
			if (data != null && data.Rows.Count > 0)
			{
				Dictionary<string, string> dicInstrument = OrderHelper.GetSetInstrumentTypeItem(string.Empty);
				Dictionary<string, string> dicChildInstrument = OrderHelper.GetInstrumentChildTypeItem();
				DataRow tempRow = data.Rows[0];
				_UserName = Convert.ToString(tempRow["user_name"]);
				string tempCreTime = Convert.ToString(tempRow["cre_date"]);
				_CustomerName = Convert.ToString(tempRow["cu_name"]);
				_LocationStr = Convert.ToString(tempRow["u_uname"]);
				_OrderName = Convert.ToString(tempRow["ca_name"]);
				_OrderType = _OrderNum.Length > 5 ? OrderHelper.InitDgvDataOrderType(_orderTypedic, _OrderNum.Substring(0, 5)) : OrderHelper.InitDgvDataOrderType(_orderTypedic, _OrderNum);//订单类型
				if (!DateTime.TryParse(tempCreTime, out _DataForCre))
				{
					_DataForCre = DateTime.Now;
				}
				for (int i = 0; i < data.Rows.Count; i++)
				{
					int index = dgv_Instrument.Rows.Add();
					string codeType = Convert.ToString(data.Rows[i]["codeType"]);
					string c_codeType = Convert.ToString(data.Rows[i]["base_ca_type"]);
					dgv_Instrument.Rows[index].Cells["idCol"].Value = dgv_Instrument.RowCount;
					dgv_Instrument.Rows[index].Cells["id"].Value = data.Rows[i]["id"];
					dgv_Instrument.Rows[index].Cells["ca_name"].Value = data.Rows[i]["base_ca_name"];
					string instrument_count = Convert.ToString(data.Rows[i]["instrument_count"]);
					dgv_Instrument.Rows[index].Cells["num"].Value = instrument_count;
					dgv_Instrument.Rows[index].Cells["send_count"].Value = instrument_count;
					dgv_Instrument.Rows[index].Cells["remark"].Value = data.Rows[i]["remark"];
					dgv_Instrument.Rows[index].Cells["codeType"].Value = data.Rows[i]["codeType"];//instrument_typeName
					dgv_Instrument.Rows[index].Cells["c_codeType"].Value = data.Rows[i]["base_ca_type"];
					dgv_Instrument.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(codeType, c_codeType, dicInstrument, dicChildInstrument);
				}
				SetDetailData();
			}
			else
			{
				MessageBox.Show("没有找到该订单出院信息!");
				Close();
			}
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSave_Click(object sender, EventArgs e)
		{
			if (dgv_Instrument.Rows.Count > 0)
			{
				SortedList condition = new SortedList();
				SortedList specaiset = new SortedList();
				SortedList orderWorkset = new SortedList();
				SortedList bcuWorkset = new SortedList();
				SortedList orderSendInfo = new SortedList();
				SortedList orderWorksetInfo = new SortedList();
				for (int i = 0; i < dgv_Instrument.Rows.Count; i++)
				{
					SortedList paramList = new SortedList();
					DataGridViewRow row = dgv_Instrument.Rows[i];
					string id = Convert.ToString(row.Cells["id"].Value);
					string send_count = Convert.ToString(row.Cells["send_count"].Value);
					string remark = Convert.ToString(row.Cells["remark"].Value);
					string codeType = Convert.ToString(row.Cells["codeType"].Value);
					paramList.Add(1, send_count);
					paramList.Add(2, remark);
					paramList.Add(3, id);
					paramList.Add(4, codeType);
					specaiset.Add(i + 1, paramList);
				}
				SortedList tempPart = new SortedList();
				tempPart.Add(1, _OrderNum);
				orderWorkset.Add(1, tempPart);
				tempPart = new SortedList();
				tempPart.Add(1, _batch);
				bcuWorkset.Add(1, tempPart);
				orderSendInfo.Add(1, tempPart);
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				tempPart = new SortedList();
				tempPart.Add(1, str_Seria);
				tempPart.Add(2, _info_name);
				tempPart.Add(3, _OrderNum);
				tempPart.Add(4, 3);
				tempPart.Add(5, CnasBaseData.UserID);
				orderWorksetInfo.Add(1, tempPart);
				condition.Add(1, specaiset);
				condition.Add(2, orderWorkset);
				condition.Add(3, bcuWorkset);
				condition.Add(4, orderSendInfo);
				condition.Add(5, orderWorksetInfo);
				string testUpData = reCnasRemotCall.RemotInterface.CheckUPDataList("hcs_work_specialset_info-up007", condition);
				SaveResult = reCnasRemotCall.RemotInterface.UPDataList("hcs_work_specialset_info-up007", condition);
				if (SaveResult > 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					PrintData();
					Close();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		/// <summary>
		/// 打印签收单
		/// </summary>
		private void PrintData()
		{
			string pringxml = string.Empty;
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='OrderForBack'");
			if (arrayDR02.Length > 0)
			{
				pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
			}
			if (!string.IsNullOrEmpty(pringxml))
			{
				DataGridView dgv_orderDetail = OrderHelper.StructureForBackOrder();
				if (dgv_Instrument.Rows.Count > 0)
				{
					for (int i = 0; i < dgv_Instrument.Rows.Count; i++)
					{
						int index = dgv_orderDetail.Rows.Add();
						dgv_orderDetail.Rows[index].Cells["o_id"].Value = dgv_orderDetail.RowCount;
						//dgv_orderDetail.Rows[index].Cells["o_cu_name"].Value = _CustomerName;
						//dgv_orderDetail.Rows[index].Cells["o_u_uname"].Value = _LocationStr;
						dgv_orderDetail.Rows[index].Cells["o_ca_name"].Value = dgv_Instrument.Rows[i].Cells["ca_name"].Value;//base_ca_name
						dgv_orderDetail.Rows[index].Cells["o_codeType"].Value = dgv_Instrument.Rows[i].Cells["codeTypeName"].Value;///GetEnumInstrumentTypeName(dic, Convert.ToString(dgv_Instrument.Rows[i].Cells["codeType"].Value));
						dgv_orderDetail.Rows[index].Cells["o_num"].Value = dgv_Instrument.Rows[i].Cells["send_count"].Value;
						dgv_orderDetail.Rows[index].Cells["o_remark"].Value = dgv_Instrument.Rows[i].Cells["remark"].Value;
					}
				}

				string patientInfo = string.Empty;
				if (BarCodeHelper.IsOrderOutSet(txtOrderNum.Text))
				{
					SortedList condition = new SortedList();
					condition.Clear();
					condition.Add(1, txtOrderNum.Text);
					condition.Add(2, _batch);
					CnasRemotCall remoteCall = new CnasRemotCall();
					string personSQL = remoteCall.RemotInterface.CheckSelectData("HCS_person_info_sec001", condition);
					DataTable personData = remoteCall.RemotInterface.SelectData("HCS_person_info_sec001", condition);
					if (personData != null && personData.Rows.Count > 0)
					{
						patientInfo = string.Format("病人姓名：{0}  住 院 号：{1}", Convert.ToString(personData.Rows[0]["p_name"]), Convert.ToString(personData.Rows[0]["p_Number"]));
					}
				}
				PrintHelper.Instance.Print_DataGridView(dgv_orderDetail, pringxml, _OrderNum, 
					new string[] {
						   txtCustmoer.Text, txtLocation.Text, patientInfo 
				});
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
		}
	}
}
