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
	public partial class HCSSM_order_new_order_detail : MetroForm
	{
		/// <summary>
		/// 供应商信息
		/// </summary>
		private int o_vid=0;
		/// <summary>
		/// 病人id
		/// </summary>
		private int o_pid=0;
		/// <summary>
		/// 区域ID 
		/// </summary>
		public string App_ID=string.Empty;
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
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;
		/// <summary>
		/// 保存执行结果
		/// </summary>
		public int SaveResult;
		/// <summary>
		/// 模式 1预览  2查看订单详情 3接收订单
		/// </summary>
		public int Mode;
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
		/// 创建时间
		/// </summary>
		public DateTime DataForCre;
		/// <summary>
		/// 创建人
		/// </summary>
		public string UserName;
		/// <summary>
		/// 批次号
		/// </summary>
		private string _batch;

		private bool _isUpdateBinding = true;
		/// <summary>
		/// 是否可以打印标签
		/// </summary>
		public bool IsCanPack = true;
		/// <summary>
		/// 临时编码
		/// </summary>
		public string BatchNum=string.Empty;
		/// <summary>
		/// 添加类型
		/// </summary>
		private Dictionary<string, string> _dicInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 添加子类型
		/// </summary>
		private Dictionary<string, string> _dicChildInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 预览初始化
		/// </summary>
		/// <param name="grid">订单内容</param>
		public HCSSM_order_new_order_detail(DataGridView grid)
		{
			InitializeComponent();
			if(grid.Rows!=null&&grid.Rows.Count>0)
			{
				//Dictionary<string, string> dic = GetSetInstrumentTypeItem();
				for(int i=0;i<grid.Rows.Count;i++)
				{
					int index = dgv_Instrument.Rows.Add();
					dgv_Instrument.Rows[index].Cells["id"].Value = grid.Rows[i].Cells["id"].Value;
					dgv_Instrument.Rows[index].Cells["ca_name"].Value = grid.Rows[i].Cells["ca_name"].Value;
					dgv_Instrument.Rows[index].Cells["num"].Value = grid.Rows[i].Cells["num"].Value;
					dgv_Instrument.Rows[index].Cells["send_count"].Value = 0;
					dgv_Instrument.Rows[index].Cells["remark"].Value = grid.Rows[i].Cells["remark"].Value;
					dgv_Instrument.Rows[index].Cells["codeType"].Value = grid.Rows[i].Cells["codeType"].Value;//instrument_typeName
					dgv_Instrument.Rows[index].Cells["c_codeType"].Value = grid.Rows[i].Cells["c_codeType"].Value;
					dgv_Instrument.Rows[index].Cells["codeTypeName"].Value = grid.Rows[i].Cells["instrument_typeName"].Value;//instrument_typeName
				}
			}
			bindingCodeLbl.Visible = false;
			bindingCodeTxt.Visible = false;
		}
		/// <summary>
		/// 初始化窗体
		/// </summary>
		public HCSSM_order_new_order_detail()
		{
			InitializeComponent();
		}

		public BarCodeHook ScanBarHook = null;
		private string _deconNotVisiableInstrument = string.Empty;

		/// <summary>
		/// 详情初始化
		/// </summary>
		/// <param name="orderNum">订单编号</param>
		/// <param name="batch">批次号(Guid)</param>
		public HCSSM_order_new_order_detail(string orderNum,string batch, bool isBindingMode = false)
		{
			this.OrderNum = orderNum;
			_batch = batch;
			InitializeComponent();
			bindingCodeTxt.Visible = isBindingMode;
			bindingCodeLbl.Visible = isBindingMode;
			if (isBindingMode)
			{
				ScanBarHook = new BarCodeHook();
				ScanBarHook.Start(false);
				ScanBarHook.BarCodeEvent += OnScanBarCodeEvent;
				bindingCodeTxt.Focus();
			}
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		private void OnScanBarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			if (matchBarCode.Length == 13)
			{
				bindingCodeTxt.Text = matchBarCode;
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
		/// 加载窗体事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_new_order_detail_Load(object sender, EventArgs e)
		{
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
			DataRow[] config = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code ='DeconNotVisiableInstrument'");
			if (config != null && config.Length > 0)
			{
				_deconNotVisiableInstrument = Convert.ToString(config[0]["value_code"]);
			}

			if(Mode==2||Mode==3)
			{
				SetDicData();
				if (Mode == 3)
				{
					dgv_Instrument.Columns["send_count"].Visible = false;
					this.Text = "订单处理";
					btnSave.Visible = true;
				}
				else
				{
					btnSave.Visible = false;
				}
				//查询 orderNum, batch对应的数据
				LoadData(OrderNum, _batch);
			}
			else if (Mode == 1)
			{
				btnSave.Visible = false;
				txtOrderState.Text = "未处理";
				DataForCre = DateTime.Now;
			}
			SetDetailData();
			DisplayNumByDgv();
		}

		/// <summary>
		/// 设置其余属性字段
		/// </summary>
		private void SetDetailData()
		{
			txtOrderType.Text = OrderType;
			txtOrderNum.Text = OrderNum;
			txtOrderName.Text = OrderName;
			txtOrderPerson.Text = UserName;
			txtCreTime.Text = DataForCre.ToString("yyyy-MM-dd HH:mm");
			txtCustmoer.Text = CustomerName;
			txtLocation.Text = LocationStr;
		}
		

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		private void LoadData(string orderNum,string batch)
		{
			SortedList condition = new SortedList();
			condition.Add(1,orderNum);
			condition.Add(2, batch);
			condition.Add(3, orderNum);
			condition.Add(4, batch);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec002", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec002", condition);
			if(data!=null&&data.Rows.Count>0)
			{
				DataRow tempRow = data.Rows[0];
				int.TryParse(Convert.ToString(tempRow["o_pid"]),out o_pid);
				int.TryParse( Convert.ToString(tempRow["o_vinfoid"]),out o_vid);
				UserName = Convert.ToString(tempRow["user_name"]);
				string tempCreTime = Convert.ToString(tempRow["cre_date"]);
				CustomerName = Convert.ToString(tempRow["cu_name"]);
				LocationStr = Convert.ToString(tempRow["u_uname"]);
				OrderName = Convert.ToString(tempRow["ca_name"]);
				bindingCodeTxt.Text = Convert.ToString(tempRow["mapping_code"]);
				_isUpdateBinding = !string.IsNullOrEmpty(bindingCodeTxt.Text);
				string tempOrderType = orderNum.Length > 5 ? orderNum.Substring(0, 5) : orderNum;
				OrderType =OrderHelper.InitDgvDataOrderType(_orderTypedic,tempOrderType);//订单类型
				bool isFlag = false;
				if(!DateTime.TryParse(tempCreTime,out DataForCre))
				{
					DataForCre = DateTime.Now;
				}
				for (int i = 0; i < data.Rows.Count; i++)
				{
					string type = Convert.ToString(data.Rows[i]["base_ca_type"]);
					if (((!_deconNotVisiableInstrument.Contains(string.Format("{0},",type))) && Mode ==3) || Mode != 3)
					{
						int index = dgv_Instrument.Rows.Add();
						dgv_Instrument.Rows[index].Cells["id"].Value = data.Rows[i]["id"];
						dgv_Instrument.Rows[index].Cells["ca_name"].Value = data.Rows[i]["base_ca_name"];
						dgv_Instrument.Rows[index].Cells["instrument_code"].Value = data.Rows[i]["instrument_code"];
						string instrument_count = Convert.ToString(data.Rows[i]["instrument_count"]);
						string send_count = Convert.ToString(data.Rows[i]["send_count"]);
						dgv_Instrument.Rows[index].Cells["num"].Value = instrument_count;
						dgv_Instrument.Rows[index].Cells["send_count"].Value = send_count;
						dgv_Instrument.Rows[index].Cells["remark"].Value = data.Rows[i]["remark"];
						dgv_Instrument.Rows[index].Cells["codeType"].Value = data.Rows[i]["codeType"];//instrument_typeName
						dgv_Instrument.Rows[index].Cells["c_codeType"].Value = data.Rows[i]["base_ca_type"];
						dgv_Instrument.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(Convert.ToString(data.Rows[i]["codeType"]), Convert.ToString(data.Rows[i]["base_ca_type"]), _dicInstrumentType, _dicChildInstrumentType);
						if (!instrument_count.Equals(send_count))
						{
							isFlag = true;
						}
					}
					
				}
				if(isFlag)
				{
					txtOrderState.Text = "未完成";
				}
				else
				{
					txtOrderState.Text = "已处理";
				}
			}
		}

		private string ValidationData()
		{
			string result = string.Empty;
			if (Mode == 3 && bindingCodeTxt.Visible)
			{
				string bindingCode = bindingCodeTxt.Text.TrimStart(' ').TrimEnd(' ');
				if (string.IsNullOrEmpty(bindingCode))
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("NotAddBindingCode", EnumPromptMessage.warning);
				else if (!bindingCode.StartsWith("BCQ"))
				{
					result = PromptMessageXmlHelper.Instance.GetPromptMessage("NotMatchBindingCode", EnumPromptMessage.warning);
				}
			}

			return result;
		}

		/// <summary>
		/// 保存(只修改器械数量以及备注)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSave_Click(object sender, EventArgs e)
		{
			//保存(只修改器械数量以及备注)(2020接收包)
			if(Mode==3)
			{
				string validateResult = ValidationData();
				if (!string.IsNullOrEmpty(validateResult))
				{
					MessageBox.Show(validateResult, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if(dgv_Instrument.Rows.Count>0)
				{
					SortedList condition = new SortedList();
					SortedList parameters = new SortedList();
					parameters.Add(1, condition);
					for(int i=0;i<dgv_Instrument.Rows.Count;i++)
					{
						SortedList paramList = new SortedList();
						DataGridViewRow row = dgv_Instrument.Rows[i];
						string id = Convert.ToString(row.Cells["id"].Value);
						string instrument_count = Convert.ToString(row.Cells["num"].Value);
						string remark = Convert.ToString(row.Cells["remark"].Value);
						string codeType = Convert.ToString(row.Cells["codeType"].Value);
						paramList.Add(1, instrument_count);
						paramList.Add(2, remark);
						paramList.Add(3, id);
						paramList.Add(4, codeType);
						condition.Add(i+1, paramList);
					}
					if (!string.IsNullOrEmpty(bindingCodeTxt.Text.TrimStart(' ').TrimEnd(' ')))
					{
						SortedList setBinding = new SortedList();
						SortedList param02 = new SortedList();
						param02.Add(1, setBinding);
						if (_isUpdateBinding)
						{
							setBinding.Add(1, bindingCodeTxt.Text);
							setBinding.Add(2, OrderNum);
							setBinding.Add(3, _batch);
							parameters.Add(3, param02);
						}
						else
						{
							setBinding.Add(1, OrderNum);
							setBinding.Add(2, _batch);
							setBinding.Add(3, bindingCodeTxt.Text);
							setBinding.Add(4, OrderNum.StartsWith("BCC3O") ? "0":"8");
							parameters.Add(2, param02);
						}

					}
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					string sqlTest = reCnasRemotCall.RemotInterface.CheckUPDataList("hcs_work_specialset_info-up003", parameters);
					SaveResult = reCnasRemotCall.RemotInterface.UPDataList("hcs_work_specialset_info-up003", parameters);
					if(SaveResult>0)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						Close();
					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "订单处理" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			if (ScanBarHook != null)
				ScanBarHook.Stop();
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnViewImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderview32", EnumImageType.PNG);
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderImage32", EnumImageType.PNG);
			btnPatient.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPatient32", EnumImageType.PNG);
		}

		/// <summary>
		/// 
		/// </summary>
		private void SetDicData()
		{
			_dicInstrumentType = OrderHelper.GetSetInstrumentTypeItem(string.Empty,false);
			_dicChildInstrumentType = OrderHelper.GetInstrumentChildTypeItem();
		}

		/// <summary>
		/// dgv双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_Instrument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (dgv_Instrument.CurrentRow != null)
				{
					OnShowImageAndPack(dgv_Instrument.CurrentRow);
				}
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
				HCSSM_order_setdetail imageDetail = new HCSSM_order_setdetail(int_code_type, base_id,OrderNum);
				imageDetail.PdData = _pdData;
				imageDetail.Pdparameters = _pdParameters;
				imageDetail.WorkflowServer = _workflowServer;
				imageDetail.App_ID = App_ID;
				imageDetail.ShowDialog();
				if (ScanBarHook != null)  ScanBarHook.Start(false);
			}
			catch
			{

			}
		}

		/// <summary>
		/// 查看图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewImage_Click(object sender, EventArgs e)
		{
			if(dgv_Instrument.SelectedRows.Count>0)
			{
				OnShowImageAndPack(dgv_Instrument.SelectedRows[0]);
			}
		}

		/// <summary>
		/// 订单编号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImage_Click(object sender, EventArgs e)
		{
			string batchCode = string.Empty;
			int showImageType = 2;
			if(Mode==1)
			{
				batchCode = BatchNum;
			}
			if(Mode!=1)
			{
				batchCode = _batch;
				showImageType = 3;
			}
			HCSSM_order_image_add showImage = new HCSSM_order_image_add(showImageType, batchCode, OrderNum);
			showImage.ShowDialog();
		}

		/// <summary>
		/// 控制显示
		/// </summary>
		private void DisplayNumByDgv()
		{
			bool instrumentIsView = false;
			bool setIsView = false;
			int set_int = 0;
			int instrument_int = 0;
			if (dgv_Instrument.Rows.Count > 0)
			{
				for (int i = 0; i < dgv_Instrument.Rows.Count; i++)
				{
					int num_int;
					DataGridViewRow row = dgv_Instrument.Rows[i];
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
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPatient_Click(object sender, EventArgs e)
		{
			bool isExitVender = o_vid<=0;
			bool isExitPatient = o_pid <=0;
			if(isExitPatient&&isExitVender)
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
	}
}
