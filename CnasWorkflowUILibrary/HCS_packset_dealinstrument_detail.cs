using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
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
	public partial class HCS_packset_dealinstrument_detail : MetroForm
	{
		/// <summary>
		/// 供应商信息
		/// </summary>
		private int o_vid = 0;
		/// <summary>
		/// 病人id
		/// </summary>
		private int o_pid = 0;
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
		/// 订单号
		/// </summary>
		private string _orderNum;
		/// <summary>
		/// 订单批次号
		/// </summary>
		private string _batch;

		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic=new Dictionary<string,string>();

		/// <summary>
		/// 添加类型
		/// </summary>
		private Dictionary<string, string> _dicInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 添加子类型
		/// </summary>
		private Dictionary<string, string> _dicChildInstrumentType = new Dictionary<string, string>();

		/// <summary>
		/// 区域Id
		/// </summary>
		public string App_id;

		/// <summary>
		/// 处理过的器械
		/// </summary>
		public SortedList OrderNumChangeList=null;
		/// <summary>
		/// 初始化win
		/// </summary>
		/// <param name="orderNum">订单编号</param>
		/// <param name="batch">订单批次号</param>
		public HCS_packset_dealinstrument_detail(string orderNum,string batch)
		{
			InitializeComponent();
			this._orderNum = orderNum;
			//dgv_Instrument.Columns["now_deal_count"].Visible = !BarCodeHelper.IsOrderOutSet(orderNum);
			this._batch = batch;
		}

		/// <summary>
		/// 窗体加载中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCS_packset_dealinstrument_detail_Load(object sender, EventArgs e)
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			InitButtonImage();
			SetDicData();
			LoadData();
		}


		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderImage32", EnumImageType.PNG);
			btnViewImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderview32", EnumImageType.PNG);
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnPrintBcu.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnPatient.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPatient32", EnumImageType.PNG);
			statisisInfoBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPassTime32", EnumImageType.PNG);
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadData()
		{
			dgv_Instrument.Rows.Clear();
			string tempRange =OrderHelper.GetInstrumentChildTypeRange();
			SortedList condition = new SortedList();
			condition.Add(1,_orderNum);
			condition.Add(2, _batch);
			condition.Add(3, _orderNum);
			condition.Add(4, _batch);
			condition.Add(5, tempRange);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec018", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec018", condition);
			if (data != null && data.Rows.Count > 0)
			{
				txtOrderNum.Text = _orderNum;
				
				DateTime lDataForCre;
				DataRow tempRow = data.Rows[0];
				int.TryParse(Convert.ToString(tempRow["o_pid"]), out o_pid);
				int.TryParse(Convert.ToString(tempRow["o_vinfoid"]), out o_vid);
				txtOrderPerson.Text = Convert.ToString(tempRow["user_name"]);
				string tempCreTime = Convert.ToString(tempRow["cre_date"]);
				txtCustmoer.Text = Convert.ToString(tempRow["cu_name"]);
				txtLocation.Text = Convert.ToString(tempRow["u_uname"]);
				txtOrderName.Text = Convert.ToString(tempRow["ca_name"]);
				txtOrderNum.Tag = Convert.ToString(tempRow["orderId"]);
				string tempOrderNum=_orderNum.Length > 5 ?_orderNum.Substring(0, 5):_orderNum;
				txtOrderType.Text = OrderHelper.InitDgvDataOrderType(_orderTypedic,tempOrderNum);//订单类型
				if (!DateTime.TryParse(tempCreTime, out lDataForCre))
				{
					lDataForCre = DateTime.Now;
				}
				txtCreTime.Text = lDataForCre.ToString("yyyy年MM月dd日 HH:mm");
				for (int i = 0; i < data.Rows.Count; i++)
				{
					int index = dgv_Instrument.Rows.Add();
					//instrument_code
					dgv_Instrument.Rows[index].Cells["instrument_code"].Value = data.Rows[i]["instrument_code"];
					dgv_Instrument.Rows[index].Cells["id"].Value = data.Rows[i]["id"];
					dgv_Instrument.Rows[index].Cells["ca_name"].Value = data.Rows[i]["base_ca_name"];
					string instrument_count = Convert.ToString(data.Rows[i]["instrument_count"]);
					string deal_count = Convert.ToString(data.Rows[i]["deal_count"]);
					dgv_Instrument.Rows[index].Cells["num"].Value = instrument_count;
					dgv_Instrument.Rows[index].Cells["deal_count"].Value = deal_count;
					dgv_Instrument.Rows[index].Cells["remark"].Value = data.Rows[i]["remark"];
					dgv_Instrument.Rows[index].Cells["codeType"].Value = data.Rows[i]["codeType"];//instrument_typeName
					dgv_Instrument.Rows[index].Cells["c_codeType"].Value = data.Rows[i]["base_ca_type"];
					dgv_Instrument.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(Convert.ToString(data.Rows[i]["codeType"]), Convert.ToString(data.Rows[i]["base_ca_type"]),_dicInstrumentType,_dicChildInstrumentType);
					dgv_Instrument.Rows[index].Cells["now_deal_count"].Value = 0;
				}
			}
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
		/// 保存(只修改器械数量以及备注)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSave_Click(object sender, EventArgs e)
		{
			SortedList condition = new SortedList();
			SortedList par1_condition = new SortedList();//更新hcs_work_specialset_info
			SortedList par2_condition = new SortedList();//更新hcs_work_specialset_dealinfo
			OrderNumChangeList = new SortedList();
			int j = 0;
			for(int i=0;i<dgv_Instrument.Rows.Count;i++)
			{
				DataGridViewRow row = dgv_Instrument.Rows[i];
				string now_deal_count = Convert.ToString(row.Cells["now_deal_count"].Value).Trim();
				string id = Convert.ToString(row.Cells["instrument_code"].Value);
				string instrument_count = Convert.ToString(row.Cells["num"].Value);
				string deal_count = Convert.ToString(row.Cells["deal_count"].Value);
				string remark = Convert.ToString(row.Cells["remark"].Value);
				string codeType = Convert.ToString(row.Cells["codeType"].Value);
				string c_codeType = Convert.ToString(row.Cells["c_codeType"].Value);
				string tempName = Convert.ToString(row.Cells["ca_name"].Value);
				SortedList par_par1_condition = new SortedList();
				SortedList par_par2_condition = new SortedList();
				int int_now_deal_count,int_deal_count;
				int int_num;
				bool isInt=int.TryParse(now_deal_count,out int_now_deal_count);
				int.TryParse(deal_count,out int_deal_count);
				int.TryParse(instrument_count, out int_num);
				if(!isInt)
				{
					MessageBox.Show(string.Format("此次{1}处理的数量:必须为数值,不能为{0}", now_deal_count, tempName));
					return;
				}
				if(isInt&&int_num<int_deal_count+int_now_deal_count)
				{
					MessageBox.Show(string.Format("此次{1}处理的数量不能超过{0}", instrument_count, tempName));
					return;
				}
				if (isInt&&int_now_deal_count>0)
				{
					par_par1_condition.Add(1, int_now_deal_count + int_deal_count);
					par_par1_condition.Add(2, remark);
					par_par1_condition.Add(3, _orderNum);
					par_par1_condition.Add(4, _batch);
					par_par1_condition.Add(5, codeType);
					par_par1_condition.Add(6, id);
					par1_condition.Add(j + 1, par_par1_condition);
					par_par2_condition.Add(1, _orderNum);
					par_par2_condition.Add(2, _batch);
					par_par2_condition.Add(3, codeType);
					par_par2_condition.Add(4, id);
					par_par2_condition.Add(5, now_deal_count);
					par_par2_condition.Add(6, App_id);
					par_par2_condition.Add(7, remark);
					par_par2_condition.Add(8, CnasBaseData.SystemID);
					par_par2_condition.Add(9, CnasBaseData.UserID);
					par2_condition.Add(j + 1, par_par2_condition);
					//OrderNumChangeList
					SortedList par_orderNumChangeList = new SortedList();
					par_orderNumChangeList.Add(1, _orderNum);
					par_orderNumChangeList.Add(2, _batch);
					par_orderNumChangeList.Add(3, c_codeType);
					par_orderNumChangeList.Add(4, id);
					par_orderNumChangeList.Add(5, instrument_count);
					par_orderNumChangeList.Add(6, int_now_deal_count + int_deal_count);
					par_orderNumChangeList.Add(7, codeType);
					par_orderNumChangeList.Add(8, int_now_deal_count);
					OrderNumChangeList.Add(j + 1, par_orderNumChangeList);
					j++;
				}
			}
			if ((par1_condition.Count == 0 || par2_condition.Count == 0) && !BarCodeHelper.IsOrderOutSet(_orderNum))
			{
				MessageBox.Show(string.Format("还没有填写数量!"));
				return;
			}
			condition.Add(1, par1_condition);
			condition.Add(2, par2_condition);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string testSql = reCnasRemotCall.RemotInterface.CheckUPDataList("hcs_work_specialset_info-up005", condition);
			int result = reCnasRemotCall.RemotInterface.UPDataList("hcs_work_specialset_info-up005", condition);
			if(result>0)
			{
				Close();
			}
			else
			{
				OrderNumChangeList = new SortedList();
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		private void SetDicData()
		{
			_dicInstrumentType = OrderHelper.GetSetInstrumentTypeItem(string.Empty,false);
			_dicChildInstrumentType = OrderHelper.GetInstrumentChildTypeItem();
			_orderTypedic = OrderHelper.GetOrderTypeItem();
		}


		/// <summary>
		/// 打印标签响应事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrintBcu_Click(object sender, EventArgs e)
		{
			string index5 = _orderNum.Length > 5 ? _orderNum.Substring(0, 5) : _orderNum;
			string tempName = txtOrderName.Text.Trim();
			int packageType =index5 == "BCC4O" ? 2: 0;
			if (dgv_Instrument.Rows.Count > 0 && dgv_Instrument.SelectedRows.Count > 0 && packageType !=2 )
			{
				tempName = Convert.ToString(dgv_Instrument.SelectedRows[0].Cells["ca_name"].Value);
				if (Convert.ToString(dgv_Instrument.SelectedRows[0].Cells["codeType"].Value) == "2")
					packageType = 1;
			}
			HCSSM_order_specialset_pack packOrderSet = new HCSSM_order_specialset_pack(_workflowServer, _pdData, _pdParameters, _orderNum, _batch, tempName, packageType);
			packOrderSet.AppId = this.App_id;
			packOrderSet.ShowDialog();
			
			if (BarCodeHelper.IsOrderOutSet(txtOrderNum.Text))
			{
				LoadData();
				foreach (DataGridViewRow row in dgv_Instrument.Rows)
				{
					row.Cells["now_deal_count"].Value = row.Cells["num"].Value;
				}
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPatient_Click(object sender, EventArgs e)
		{
			bool isExitVender = o_vid <= 0;
			bool isExitPatient = o_pid <= 0;
			if (isExitPatient && isExitVender)
			{
				MessageBox.Show("不存在病人信息!");
				return;
			}
			HCSSM_order_person showP = new HCSSM_order_person();
			showP.ModleType = 2;
			showP.Patient_Id = o_pid;
			showP.Venderinfo_id = o_vid;
			showP.ShowDialog();
		}

		/// <summary>
		/// 图片详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewImage_Click(object sender, EventArgs e)
		{
			if (dgv_Instrument.SelectedRows.Count > 0)
			{
				OnShowImageAndPack(dgv_Instrument.SelectedRows[0]);
			}
		}


		/// <summary>
		/// 查看事件
		/// </summary>
		private void OnShowImageAndPack(DataGridViewRow row)
		{
			try
			{
				int int_code_type;
				string code_type = Convert.ToString(row.Cells["codeType"].Value);
				int.TryParse(code_type, out  int_code_type);
				string base_id = Convert.ToString(row.Cells["instrument_code"].Value);
				HCSSM_order_setdetail imageDetail = new HCSSM_order_setdetail(int_code_type, base_id, _orderNum);
				imageDetail.PdData = _pdData;
				imageDetail.Pdparameters = _pdParameters;
				imageDetail.WorkflowServer = _workflowServer;
				imageDetail.App_ID = App_id;
				imageDetail.ShowDialog();
			}
			catch (Exception ex)
			{

			}
		}

		/// <summary>
		/// 订单图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImage_Click(object sender, EventArgs e)
		{
			HCSSM_order_image_add showImage = new HCSSM_order_image_add(3,_batch,_orderNum);
			showImage.ShowDialog();
		}

		/// <summary>
		/// 双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_Instrument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			if(dgv_Instrument.CurrentCell != null)
			{
				if (dgv_Instrument.CurrentCell.OwningColumn.ReadOnly)
				{
					if (dgv_Instrument.CurrentRow != null)
					{
						OnShowImageAndPack(dgv_Instrument.CurrentRow);
					}
				}
			}
		}

		private void statisisInfoBtn_Click(object sender, EventArgs e)
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			HCSSM_statistics_quality_new qualityDialog = new HCSSM_statistics_quality_new();
			data.Add("SetName", txtOrderName.Text);
			data.Add("SetCode", txtOrderNum.Text);
			data.Add("SetId", Convert.ToString(txtOrderNum.Tag));
			qualityDialog.Data = data;
			qualityDialog.Area = "3";
			qualityDialog.ShowDialog();
		}

	}
}
