using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Forms;
using CRD.Common;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_new_order_handle : MetroForm
	{
		/// <summary>
		/// bcc4o打包生成的bcu
		/// </summary>
		//private DataTable _Bcu0R = null;

		/// <summary>
		/// 表示按下回车键是否可以响应事件
		/// </summary>
		private bool _canKeyDown = false;
		/// <summary>
		/// 记录上一次时间
		/// </summary>
		private DateTime _firstTime = DateTime.Now;
		/// <summary>
		/// bcu构造参数
		/// </summary>
		private Dictionary<string, string> _dataDic = new Dictionary<string, string>();
		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;
		/// <summary>
		/// 订单id
		/// </summary>
		private string _orderId;
		/// <summary>
		/// 工单
		/// </summary>
		private CnasHCSWorkflowInterface _cnasHCSWorkflowInterface01;

		/// <summary>
		/// 钩子
		/// </summary>
		private BarCodeHook _barCodeHolder = new BarCodeHook();
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
		/// <summary>
		/// 当前区域id
		/// </summary>
		private string _inappid;
		private string _locationBarCode = "";

		private string _acceptDealWF = "";
		private string _tempStorageWF = "";

		private string _sendOrderNum = "";


		/// <summary>
		/// 添加类型
		/// </summary>
		private Dictionary<string, string> _dicInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 添加子类型
		/// </summary>
		private Dictionary<string, string> _dicChildInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 没有标签
		/// </summary>
		private List<string> _dicNoLabel = new List<string>();


		private Dictionary<string, int> _manaulCount = new Dictionary<string, int>();
		private Dictionary<string, int> _scanCount = new Dictionary<string, int>();
		private Dictionary<string, int> _outOrderBCUs = new Dictionary<string, int>();


		/// <summary>
		/// 订单处理
		/// </summary>
		public HCSSM_order_new_order_handle()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// 订单处理
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		/// <param name="inappid"></param>
		public HCSSM_order_new_order_handle(string orderNum, string batch, string inappid, CnasHCSWorkflowInterface cnasHCSWorkflowInterface01)
			: this(orderNum, batch)
		{
			_inappid = inappid;
			_cnasHCSWorkflowInterface01 = cnasHCSWorkflowInterface01;
		}
		/// <summary>
		/// 订单处理
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		public HCSSM_order_new_order_handle(string orderNum, string batch)
		{
			this.OrderNum = orderNum;
			_batch = batch;
			InitializeComponent();
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
			txtCustomer.Text = CustomerName;
			txtLocation.Text = LocationStr;
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="orderNum"></param>
		/// <param name="batch"></param>
		private void LoadData(string orderNum, string batch)
		{
			if (!string.IsNullOrEmpty(orderNum) && !string.IsNullOrEmpty(batch))
			{
				string tempOrderType = orderNum.Length > 5 ? orderNum.Substring(0, 5) : orderNum;
				_orderTypedic = OrderHelper.GetOrderTypeItem(false);
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				if (BarCodeHelper.IsOrderOutSet(orderNum))
				{
					SortedList bcuOrCondition = new SortedList();
					bcuOrCondition.Add(1, batch);
					bcuOrCondition.Add(2, CnasBaseData.SystemID);
					string testBcuSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-bcct-data-sec001", bcuOrCondition);
					DataTable outOrderBcu = reCnasRemotCall.RemotInterface.SelectData("HCS-bcct-data-sec001", bcuOrCondition);
					if (outOrderBcu != null)
					{
						foreach (DataRow item in outOrderBcu.Rows)
						{
							string bcuCode = Convert.ToString(item["BCU_code"]);
							string bccCode = Convert.ToString(item["bar_code"]);
							if (!_outOrderBCUs.ContainsKey(bcuCode))
							{
								_outOrderBCUs.Add(bcuCode, 0);
							}
						}
					}
				}
				SortedList condition = new SortedList();
				condition.Add(1, orderNum);
				condition.Add(2, batch);
				condition.Add(3, orderNum);
				condition.Add(4, batch);
				string testDataSql = reCnasRemotCall.RemotInterface.CheckSelectData("hcs_work_specialset_info-sec002", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("hcs_work_specialset_info-sec002", condition);
				if (data != null && data.Rows.Count > 0)
				{
					DataRow tempRow = data.Rows[0];
					_orderId = Convert.ToString(tempRow["orderId"]);
					UserName = Convert.ToString(tempRow["user_name"]);
					string tempCreTime = Convert.ToString(tempRow["cre_date"]);
					CustomerName = Convert.ToString(tempRow["cu_name"]);
					LocationStr = Convert.ToString(tempRow["u_uname"]);
					OrderName = Convert.ToString(tempRow["ca_name"]);
					_locationBarCode = Convert.ToString(tempRow["u_barcode"]);
					OrderType = OrderHelper.InitDgvDataOrderType(_orderTypedic,tempOrderType);
					bool isFlag = false;
					if (!DateTime.TryParse(tempCreTime, out DataForCre))
					{
						DataForCre = DateTime.Now;
					}
					for (int i = 0; i < data.Rows.Count; i++)
					{
						int index = dgv_Instrument.Rows.Add();
						string c_codeType = Convert.ToString( data.Rows[i]["base_ca_type"]);
						if (_dicNoLabel.Contains(c_codeType))
						{
							dgv_Instrument.Rows[index].DefaultCellStyle.BackColor = Color.Green;
							dgv_Instrument.Rows[index].Cells["for_label"].Value = "无标签";
						}
						else
						{
							dgv_Instrument.Rows[index].Cells["for_label"].Value = "有标签";
						}
						dgv_Instrument.Rows[index].Cells["id"].Value = data.Rows[i]["id"];
						dgv_Instrument.Rows[index].Cells["ca_name"].Value = data.Rows[i]["base_ca_name"];
						dgv_Instrument.Rows[index].Cells["num_send_count"].Value = string.Format("{0}/{1}", data.Rows[i]["send_count"], data.Rows[i]["instrument_count"]);
						dgv_Instrument.Rows[index].Cells["send_count_now"].Value = 0;
						string instrument_count = Convert.ToString(data.Rows[i]["instrument_count"]);
						string send_count = Convert.ToString(data.Rows[i]["send_count"]);
						dgv_Instrument.Rows[index].Cells["num"].Value = instrument_count;
						dgv_Instrument.Rows[index].Cells["send_count"].Value = send_count;
						dgv_Instrument.Rows[index].Cells["remark"].Value = data.Rows[i]["remark"];
						dgv_Instrument.Rows[index].Cells["codeType"].Value = data.Rows[i]["codeType"];//instrument_typeName
						dgv_Instrument.Rows[index].Cells["c_codeType"].Value =c_codeType;
						dgv_Instrument.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(Convert.ToString(data.Rows[i]["codeType"]),c_codeType,_dicInstrumentType,_dicChildInstrumentType);
						dgv_Instrument.Rows[index].Cells["instrument_code"].Value = data.Rows[i]["instrument_code"];


                        // add - 周盛祥  16-11-17
                        // 此处判断用户是否设置了自动还物，如果设置了，则显示相应字段
                        //order_restitution_type




						if (!instrument_count.Equals(send_count))
						{
							isFlag = true;
						}

					}
					if (isFlag)
					{
						txtOrderState.Text = "未完成";
					}
					else
					{
						txtOrderState.Text = "已处理";
					}
				}
			}
		}

		/// <summary>
		/// 窗体初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_new_order_handle_Load(object sender, EventArgs e)
		{
			InitializeConfig();
			SetDicData();
			InitButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			LoadData(OrderNum, _batch);
			SetDetailData();
			InitSetDataDic();
			StartBarCodeHook();
			metBcuCode.Focus();

			Win32.ReleaseCapture();
			Win32.SendMessage(this.Handle, 274, Win32.SC_MAXIMIZE, 0);
		}

		/// <summary>
		/// 启动钩子 
		/// </summary>
		private void StartBarCodeHook()
		{
			if (_barCodeHolder != null)
			{
				_barCodeHolder.Start(false);
				_barCodeHolder.BarCodeEvent += _barCodeHolder_BarCodeEvent;
			}
			//this.Focus();
		}
		/// <summary>
		/// 扫码枪相应事件
		/// </summary>
		/// <param name="barCode"></param>
		void _barCodeHolder_BarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			_canKeyDown = false;
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode).Trim();
			if (!string.IsNullOrEmpty(matchBarCode))
			{
				string result = HandleBarCode(matchBarCode);
				resultLbl.Text = result;
				resultLbl.Visible = !string.IsNullOrEmpty(resultLbl.Text);
			}
		}

		/// <summary>
		/// 初始化设置dataDic
		/// </summary>
		private void InitSetDataDic()
		{
			if(_dataDic!=null&&_dataDic.Count==0)
			{
				_dataDic = new Dictionary<string, string>();
				DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Temp_storage_wf'");
				if (array != null && array.Length > 0)
				{
					//临时流程存储点
					string _wf_codeStr = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
					string[] wf_codeArray = _wf_codeStr.Split(',');
					string tempCode = wf_codeArray[0];
					string user_bar_code = string.Empty;
					if (CnasBaseData.UserBaseInfo != null)
						user_bar_code = CnasBaseData.UserBaseInfo.Userbcode;
					_dataDic.Add(user_bar_code, user_bar_code.Length > 2 ? user_bar_code.Substring(0, 3) : user_bar_code);
					string padding_wf_code = "BCV" + tempCode.PadLeft(10, '0');
					_dataDic.Add(padding_wf_code, "BCV");
					_dataDic.Add(_locationBarCode, "BCE");
				}
			}
		}

		/// <summary>
		/// 处理条码
		/// </summary>
		/// <param name="matchBarCode"></param>
		/// <returns></returns>
		private string HandleBarCode(string matchBarCode)
		{
			string result = string.Empty;
			if(!string.IsNullOrEmpty(matchBarCode))
			{
				if(_dataDic.Count>1)
				{
					List<string> bcuList = OrderHelper.GetBcuPackForOrder();
					string index4 = string.Empty;
					if (BarCodeHelper.IsTempBCU(matchBarCode))
					{
						index4= matchBarCode.Substring(0,5);
					}
					else
					{
						index4= matchBarCode.Substring(0,3);
					}
					KeyValuePair<string, int> bcuItem = new KeyValuePair<string, int>();
					
					if (bcuList.Contains(index4))
					{
						if (BarCodeHelper.IsOrderOutSet(txtOrderNum.Text))
						{
							if (BarCodeHelper.IsTempBCU(matchBarCode))
							{
								if (_outOrderBCUs.Count == 0)
								{
									result = OrderHelper.GetDescribeString(5);
									return result;
								}
								else
								{
									bcuItem = _outOrderBCUs.FirstOrDefault(p => p.Key == matchBarCode);
									if (bcuItem.Key == null)
									{
										result = OrderHelper.GetDescribeString(3);
										return result;
									}
								}
							}
						}
						else
						{
							if (BarCodeHelper.IsOutOrderBCU(matchBarCode))
							{
								result = "此订单不能发送外来器械包。";
								return result;
							}
						}
						SortedList tempResult = _cnasHCSWorkflowInterface01.CheckBusinessLogic(matchBarCode, _dataDic);
						int bResult = -1;
						int.TryParse(Convert.ToString(tempResult["result_Code"]), out bResult);
						string bcct_barCode = Convert.ToString(tempResult["barCode"]);
						string bcct_barCodeObjectName = Convert.ToString(tempResult["barCodeObjectName"]);
						result = Convert.ToString(tempResult["result_Message"]);
						string messageForBox = Convert.ToString(tempResult["MessageBox_Message"]);
						int messageOperation = 1;

						if (bResult == 0)
						{
							if (!string.IsNullOrEmpty(messageForBox) && int.TryParse(Convert.ToString(tempResult["Message_Operation"]), out messageOperation))
							{
								
								if (MessageBox.Show(messageForBox, "信息提示", (messageOperation == 1 ? MessageBoxButtons.OK : MessageBoxButtons.OKCancel), MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
								{
									result = string.Format("{0} --用户取消", messageForBox);
									return result;
								}
								else
								{
									result = string.Empty;
								}
							}

							if (BarCodeHelper.IsOrderOutSet(OrderNum) && string.IsNullOrEmpty(result) && BarCodeHelper.IsOutOrderBCU(matchBarCode))
							{
								foreach (DataGridViewRow row in dgv_Instrument.Rows)
								{
									row.Cells["send_count_now"].Value = row.Cells["num"].Value;
								}
							}

							if (!_dataDic.ContainsKey(bcct_barCode))
							{
								_dataDic.Add(bcct_barCode, bcct_barCode.Length > 3 ? bcct_barCode.Substring(0, 3) : bcct_barCode);
							}

							if (!string.IsNullOrEmpty(bcct_barCode) && bcct_barCode.Contains("BCC"))
								bcct_barCode = bcct_barCode.Substring(bcct_barCode.IndexOf("BCC"));

							AddDgv_BcuData(matchBarCode, bcct_barCode, bcct_barCodeObjectName);//grid数据添加
							if (BarCodeHelper.IsOrderOutSet(OrderNum) && BarCodeHelper.IsOutOrderBCU(matchBarCode)
								&& bcuItem.Key == matchBarCode)
							{
								_outOrderBCUs[matchBarCode] = 1;
							}
						}
					}
					else
					{
						result = OrderHelper.GetDescribeString(1);
					}
				}
			}
			else
			{
				result = "内部码错误";
			}
			

			return result;
		}

		/// <summary>
		/// 停止钩子
		/// </summary>
		private void StopBarCodeHook()
		{
			if (_barCodeHolder != null)
			{
				_barCodeHolder.Stop();
			}
		}

		/// <summary>
		/// 窗口关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_new_order_handle_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopBarCodeHook();
		}

		private string GetSendOrderNum()
		{
			string number = string.Empty;
			if (string.IsNullOrEmpty(_sendOrderNum))
			{
				string tempNumber = string.Empty;
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				int bccNumber = reCnasRemotCall.RemotInterface.GetSerialNumber(1, "BCO");
				if (bccNumber <= 0)
				{
					tempNumber = "1";
				}
				else
				{
					tempNumber = bccNumber.ToString();
				}
				number = "BCO" + tempNumber.PadLeft(10, '0');
			}
			else
			{
				number = _sendOrderNum;
			}

			return number;
		}

		private SortedList GenerateSQLParameter(ref string message)
		{
			SortedList sqlParameter = new SortedList();
			SortedList sendOrderInfos = new SortedList();
			SortedList updateWorkSets = new SortedList();
			SortedList insertWorkSets = new SortedList();
			SortedList updateWorkSpecialsetInfos = new SortedList();
			SortedList insertWorkSetInfos = new SortedList();
			SortedList updateOrders = new SortedList();

			sqlParameter.Add(1, sendOrderInfos);
			sqlParameter.Add(2, updateWorkSets);
			sqlParameter.Add(3, insertWorkSets);
			sqlParameter.Add(4, updateWorkSpecialsetInfos);
			sqlParameter.Add(5, insertWorkSetInfos);
			sqlParameter.Add(6, updateOrders);

			CnasRemotCall remoteCall = new CnasRemotCall();
			_sendOrderNum = GetSendOrderNum();
			string infoSerial = remoteCall.RemotInterface.Get_SerialNumber(1);
			string sendBatch = remoteCall.RemotInterface.Get_SerialNumber(2);
			int doneCount = 0, totalSendNum = 0;
			foreach (DataGridViewRow row in dgv_Instrument.Rows)
			{
				string sendType = Convert.ToString(row.Cells["codeType"].Value); //codeType 
				string subSendType = Convert.ToString(row.Cells["c_codeType"].Value);
				string instrumentName = Convert.ToString(row.Cells["ca_name"].Value);
				string instrumentCode = Convert.ToString(row.Cells["instrument_code"].Value);
				string id = Convert.ToString(row.Cells["id"].Value);
				int sendNum = 0;
				int.TryParse(Convert.ToString(row.Cells["send_count_now"].Value), out sendNum);
				int sentNum = 0;
				int.TryParse(Convert.ToString(row.Cells["send_count"].Value), out sentNum);
				int totalNum = 0;
				int.TryParse(Convert.ToString(row.Cells["num"].Value), out totalNum);
				totalSendNum += sendNum;

				if (totalNum >= sendNum + sentNum)
				{
					if (sendNum + sentNum == totalNum)
						doneCount++;
				}
				else
				{
					message = string.Format("{0}发放的数量:不能超过{1}", instrumentName, totalNum - sentNum);
					return sqlParameter;
				}

				SortedList updateWorkSpecialsetInfo = GetUpdateWorkSpecialsetInfo((sendNum + sentNum).ToString(), id, sendType);
				updateWorkSpecialsetInfos.Add(updateWorkSpecialsetInfos.Count + 1, updateWorkSpecialsetInfo);

				if (sendNum > 0)
				{
					SortedList sendOrderInfo = GetInsertSendOrderInfoList(_sendOrderNum, sendBatch, sendType, subSendType, "", "", instrumentName, sendNum.ToString(), _acceptDealWF, instrumentCode);
					sendOrderInfos.Add(sendOrderInfos.Count + 1, sendOrderInfo);
				}
			}

			if (totalSendNum <= 0)
			{
				message=string.Format("此次数量必须超过0");
				return sqlParameter;
			}

			if (doneCount == dgv_Instrument.RowCount)
			{
				SortedList UpOrderStatus = new SortedList();
				UpOrderStatus.Add(1, _tempStorageWF);
				UpOrderStatus.Add(2, txtOrderNum.Text);
				UpOrderStatus.Add(3, txtOrderNum.Text);
				updateOrders.Add(updateOrders.Count + 1, UpOrderStatus);
			}

			foreach (DataGridViewRow row in dgv_BcuData.Rows)
			{
				string bccCode = Convert.ToString(Convert.ToString(row.Cells["t_b_bar_code"].Value));
				string bcuCode = Convert.ToString(Convert.ToString(row.Cells["b_bar_code"].Value));
				string setName = Convert.ToString(Convert.ToString(row.Cells["b_ca_name"].Value)).Trim();
				string subSendType = Convert.ToString(Convert.ToString(row.Cells["setTypeCol"].Value));
				string sendType = subSendType.Substring(0, 1);
				SortedList sendOrderInfo = GetInsertSendOrderInfoList(_sendOrderNum, sendBatch, sendType, subSendType, bccCode, bcuCode, setName, "1", _acceptDealWF, "");
				sendOrderInfos.Add(sendOrderInfos.Count + 1, sendOrderInfo);

				SortedList updateWorkSet = GetUpdateWorkSet(_sendOrderNum, _batch, infoSerial, bccCode);
				updateWorkSets.Add(updateWorkSets.Count + 1, updateWorkSet);
				SortedList insertWorkSet = GetInsertWorkSet(_acceptDealWF, "", _sendOrderNum, _batch, bccCode);
				insertWorkSets.Add(insertWorkSets.Count + 1, insertWorkSet);

				SortedList insertWorkSetInfo = GetInsertWorkSetInfo(infoSerial, bcuCode.Substring(0, 3), CnasUtilityTools.ConcatTwoString(bcuCode, bccCode), "3", "");
				insertWorkSetInfos.Add(insertWorkSetInfos.Count + 1, insertWorkSetInfo);
			}

			SortedList insertWorkSetInfoBCO = GetInsertWorkSetInfo(infoSerial, _sendOrderNum.Substring(0, 3), _sendOrderNum, "3", "");
			insertWorkSetInfos.Add(insertWorkSetInfos.Count + 1, insertWorkSetInfoBCO);

			return sqlParameter;
		}

		private SortedList GetInsertSendOrderInfoList(string bcoCode, string sendBatch, string sendType, string subSendType, string bccCode, string bcuCode, string setName, string sendNum, string wfCode, string instrumentCount)
		{
			SortedList sendOrderInfo = new SortedList();
			sendOrderInfo.Add(1, bcoCode);  //send_code
			sendOrderInfo.Add(2, sendBatch);   //send_batch
			sendOrderInfo.Add(3, sendType);  //send_type
			sendOrderInfo.Add(4, subSendType);  //c_send_type
			sendOrderInfo.Add(5, txtOrderNum.Text);  //order_code
			sendOrderInfo.Add(6, txtOrderName.Text);  //order_name
			sendOrderInfo.Add(7, _batch);  //order_batch
			sendOrderInfo.Add(8, bccCode);  //bcc_code
			sendOrderInfo.Add(9, bcuCode);  // bcu_code
			sendOrderInfo.Add(10, setName); //ca_name
			sendOrderInfo.Add(11, sendNum);  //send_num
			sendOrderInfo.Add(12, wfCode);  //wf_code
			sendOrderInfo.Add(13, CnasBaseData.UserBaseInfo.UserID);  //cre_userid 
			sendOrderInfo.Add(14, instrumentCount); //instrument_code

			return sendOrderInfo;
		}

		private SortedList GetUpdateWorkSpecialsetInfo(string sendNum, string id, string codeType)
		{
			SortedList workSpecialsetInfo = new SortedList();
			workSpecialsetInfo.Add(1, sendNum);  //send_count
			workSpecialsetInfo.Add(2, _batch);   //batch
			workSpecialsetInfo.Add(3, txtOrderNum.Text);  //set_code
			workSpecialsetInfo.Add(4, id);  //id
			workSpecialsetInfo.Add(5, codeType);  //codeType
			return workSpecialsetInfo;
		}

		private SortedList GetInsertWorkSet(string wfCode, string remark, string containerCode, string batch, string bccCode)
		{
			SortedList insertWorkSet = new SortedList();
			insertWorkSet.Add(1, wfCode);  //send_count
			insertWorkSet.Add(2, CnasBaseData.UserBaseInfo.UserID);   //userId
			insertWorkSet.Add(3, remark);  //remark
			insertWorkSet.Add(4, containerCode);  //containerCode
			insertWorkSet.Add(5, batch);  //batch
			insertWorkSet.Add(6, bccCode);  //bccCode
			return insertWorkSet;
		}

		private SortedList GetUpdateWorkSet(string containerCode, string batch, string infoSerial, string setCode)
		{
			SortedList updateWorkSet = new SortedList();
			updateWorkSet.Add(1, CnasBaseData.UserBaseInfo.UserID);  //userId
			updateWorkSet.Add(2, containerCode);   //containerCode
			updateWorkSet.Add(3, batch);  //batch
			updateWorkSet.Add(4, infoSerial);  //infoSerial
			updateWorkSet.Add(5, setCode);  //setCode
			return updateWorkSet;
		}

		private SortedList GetInsertWorkSetInfo(string infoSerial, string infoName, string infoData, string infoType, string remark)
		{
			SortedList insertWorkSetInfo = new SortedList();
			insertWorkSetInfo.Add(1, infoSerial);  //info_serial
			insertWorkSetInfo.Add(2, infoName);   //info_name
			insertWorkSetInfo.Add(3, infoData);  //info_data
			insertWorkSetInfo.Add(4, infoType);  //info_Type
			insertWorkSetInfo.Add(5, CnasBaseData.UserBaseInfo.UserID);  //userId
			insertWorkSetInfo.Add(6, remark);  //remark
			return insertWorkSetInfo;
		}

		public void GetPreviewSendThingDataBaseLeft()
		{
			sendInfoPreview.Rows.Clear();
			_scanCount.Clear();
			_manaulCount.Clear();
			Dictionary<string, DataGridViewRow> instrumentInfo = new Dictionary<string, DataGridViewRow>();

			foreach (DataGridViewRow row in dgv_Instrument.Rows)
			{
				string instrumentName = Convert.ToString(row.Cells["ca_name"].Value);
				int sendNum = 0;
				int.TryParse(Convert.ToString(row.Cells["send_count_now"].Value), out sendNum);
				string subSendType = Convert.ToString(row.Cells["c_codeType"].Value);
				if (_manaulCount.ContainsKey(instrumentName))
				{
					_manaulCount[instrumentName] += sendNum;
				}
				else
				{
					_manaulCount.Add(instrumentName, sendNum);

					if (sendNum > 0 && !BarCodeHelper.IsOrderOutSet(txtOrderNum.Text))
					{
						int rowIndex = sendInfoPreview.Rows.Add();
						sendInfoPreview.Rows[rowIndex].Cells["thingIdCol"].Value = sendInfoPreview.RowCount + 1;
						sendInfoPreview.Rows[rowIndex].Cells["thingNameCol"].Value = instrumentName;
						sendInfoPreview.Rows[rowIndex].Cells["thingNumCol"].Value = _manaulCount[instrumentName];
					}
				}
			}

			foreach (DataGridViewRow row in dgv_BcuData.Rows)
			{
				string setFullName = Convert.ToString(Convert.ToString(row.Cells["b_ca_name"].Value)).Trim();
				string setName = ParseThingName(setFullName, "<");
				if (_scanCount.ContainsKey(setName))
				{
					_scanCount[setName]++;
					if (instrumentInfo.ContainsKey(setName))
						instrumentInfo[setName].Cells["thingNumCol"].Value = _scanCount[setName];
				}
				else
				{
					_scanCount.Add(setName, 1);
					if (!_manaulCount.ContainsKey(setName))
					{
						int rowIndex = sendInfoPreview.Rows.Add();
						sendInfoPreview.Rows[rowIndex].Cells["thingIdCol"].Value = sendInfoPreview.RowCount + 1;
						sendInfoPreview.Rows[rowIndex].Cells["thingNameCol"].Value = setName;
						sendInfoPreview.Rows[rowIndex].Cells["thingNumCol"].Value = _scanCount[setName];
						if (!instrumentInfo.ContainsKey(setName))
							instrumentInfo.Add(setName, sendInfoPreview.Rows[rowIndex]);
					}
					
				}
			}
		}

		public void GetPreviewSendThingData(bool isLeft = true)
		{
			if (isLeft)
				GetPreviewSendThingDataBaseLeft();
			else
				GetPreviewSendThingDataBaseRight();
		}

		public void GetPreviewSendThingDataBaseRight()
		{
			string message = string.Empty;
			sendInfoPreview.Rows.Clear();
			_scanCount.Clear();
			_manaulCount.Clear();
			Dictionary<string, DataGridViewRow> instrumentInfo = new Dictionary<string, DataGridViewRow>();

			foreach (DataGridViewRow row in dgv_BcuData.Rows)
			{
				string setFullName = Convert.ToString(Convert.ToString(row.Cells["b_ca_name"].Value)).Trim();
				string setName = ParseThingName(setFullName, "<");
				if (_scanCount.ContainsKey(setName))
				{
					_scanCount[setName]++;
					if (instrumentInfo.ContainsKey(setName))
						instrumentInfo[setName].Cells["thingNumCol"].Value = _scanCount[setName];
				}
				else
				{
					_scanCount.Add(setName, 1);
					int rowIndex = sendInfoPreview.Rows.Add();
					sendInfoPreview.Rows[rowIndex].Cells["thingIdCol"].Value = sendInfoPreview.RowCount + 1;
					sendInfoPreview.Rows[rowIndex].Cells["thingNameCol"].Value = setName;
					sendInfoPreview.Rows[rowIndex].Cells["thingNumCol"].Value = _scanCount[setName];
					if (!instrumentInfo.ContainsKey(setName))
						instrumentInfo.Add(setName, sendInfoPreview.Rows[rowIndex]);
				}

			}

			foreach (DataGridViewRow row in dgv_Instrument.Rows)
			{
				string instrumentName = Convert.ToString(row.Cells["ca_name"].Value);
				int sendNum = 0;
				int.TryParse(Convert.ToString(row.Cells["send_count_now"].Value), out sendNum);
				string subSendType = Convert.ToString(row.Cells["c_codeType"].Value);
				if (_manaulCount.ContainsKey(instrumentName))
				{
					_manaulCount[instrumentName] += sendNum;
				}
				else
				{
					_manaulCount.Add(instrumentName, sendNum);

					if (!_scanCount.ContainsKey(instrumentName) && sendNum > 0 &&
						(!BarCodeHelper.IsOrderOutSet(txtOrderNum.Text) || _dicNoLabel.Contains(subSendType)))
					{
						int rowIndex = sendInfoPreview.Rows.Add();
						sendInfoPreview.Rows[rowIndex].Cells["thingIdCol"].Value = sendInfoPreview.RowCount + 1;
						sendInfoPreview.Rows[rowIndex].Cells["thingNameCol"].Value = instrumentName;
						sendInfoPreview.Rows[rowIndex].Cells["thingNumCol"].Value = _manaulCount[instrumentName];
					}
				}
			}
		}

		private string GetDifferentInfo()
		{
			string message = string.Empty;
			string differentCount = string.Empty;
			foreach (KeyValuePair<string, int> item in _scanCount)
			{
				KeyValuePair<string, int> sameNameItem = _manaulCount.FirstOrDefault(p => p.Key == item.Key);
				if (sameNameItem.Key != null && sameNameItem.Value != item.Value)
				{
					differentCount += string.Format("\r\n扫描包的数量与填写数量不符： {0}， 扫描数量：{1}， 填写数量{2}", item.Key, item.Value, sameNameItem.Value);
				}
			}

			if (!string.IsNullOrEmpty(differentCount))
				message = string.Format("发放数量不符，请确认：{0}", differentCount);
			return message;
		}



		/// <summary>
		/// 添加BCCT条码
		/// </summary>
		private void AddDgv_BcuData(string bcu,string bcct,string bccName)
		{
			if(!string.IsNullOrEmpty(bcu)&&!string.IsNullOrEmpty(bcct))
			{
				bool isAdd = true;
				for(int i=0;i<dgv_BcuData.Rows.Count;i++)
				{
					string b_bar_code = Convert.ToString(dgv_BcuData.Rows[i].Cells["b_bar_code"].Value);
					if(b_bar_code.Equals(bcu))
					{
						isAdd = false;
						dgv_BcuData.Rows[i].Selected = true;
						resultLbl.Text = "该条码已经找到";
					}
				}
				if (isAdd)
				{
					int index = dgv_BcuData.Rows.Add();
					dgv_BcuData.Rows[index].Cells["bid"].Value = index + 1;
					dgv_BcuData.Rows[index].Cells["b_bar_code"].Value = bcu;
					dgv_BcuData.Rows[index].Cells["t_b_bar_code"].Value = bcct;
					dgv_BcuData.Rows[index].Cells["b_ca_name"].Value = bccName;
					int type = BarCodeHelper.IsTempBCU(bcu) ? 22 : 21;  //21是含有BCC的标准包。 22是
					dgv_BcuData.Rows[index].Cells["setTypeCol"].Value = type;
				}
			}
		}
		/// <summary>
		/// 按下enter键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void metBcuCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter&&_canKeyDown)
			{
				string bcuCode = metBcuCode.Text.Trim();
				string result = HandleBarCode(bcuCode);
				resultLbl.Text = result;
				resultLbl.Visible = !string.IsNullOrEmpty(resultLbl.Text);
			}
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			if (ts.Milliseconds < 20)
			{
				metBcuCode.Text = "";
			}
			else
			{
				_canKeyDown = true;
			}
			_firstTime = DateTime.Now;
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendorderBuild32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
		}	

		/// <summary>
		/// 
		/// </summary>
		private void SetDicData()
		{
			_dicNoLabel = OrderHelper.GetNoLabelInstrumentTypeItem();
			_dicInstrumentType =OrderHelper.GetSetInstrumentTypeItem(string.Empty,false);
			_dicChildInstrumentType = OrderHelper.GetInstrumentChildTypeItem();
		}

		/// <summary>
		/// 把小写字母转变为大写
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void metBcuCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
			{
				e.KeyChar = (char)((int)e.KeyChar - 32);
			}
		}

		private void OnTabControlSelectionChanged(object sender, EventArgs e)
		{
			if (mainTab.SelectedIndex == 1)
				GetPreviewSendThingData();
		}

		private string ParseThingName(string fullName, string splitter)
		{
			string name = string.Empty;
			if (!string.IsNullOrEmpty(fullName))
			{
				int splitterIndex = fullName.IndexOf(splitter);
				if (splitterIndex > 0)
					name = fullName.Substring(0, splitterIndex);
				else
					name = fullName;
			}

			return name;
		}

		private void InitializeConfig()
		{
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Accept_order_wf'");
			if (array != null && array.Length == 1)
			{
				_acceptDealWF = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
			}

			DataRow[] tempStorageData = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Temp_storage_wf'");
			if (tempStorageData != null && tempStorageData.Length == 1)
			{
				_tempStorageWF = Convert.ToString(tempStorageData[0]["value_code"]).TrimEnd(',');
			}
		}

		/// <summary>
		/// 生成发货单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (BarCodeHelper.IsOrderOutSet(txtOrderNum.Text))
				{
					if (_outOrderBCUs.Count <= 0)
					{
						MessageBox.Show(string.Format("{0}", OrderHelper.GetDescribeString(5))); return;
					}
					else
					{
						KeyValuePair<string, int> notScanItem = _outOrderBCUs.FirstOrDefault(p => p.Value == 0);
						if (notScanItem.Key != null)
						{
							MessageBox.Show(string.Format("{0}", OrderHelper.GetDescribeString(4))); return;
						}
					}
				}

				GetPreviewSendThingData();
				string message = GetDifferentInfo();

				if (!string.IsNullOrEmpty(message) && MessageBox.Show(message, "信息提示", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
				else
				{
					message = string.Empty;
				}

				SortedList sqlParameters = GenerateSQLParameter(ref message);
				if (!string.IsNullOrEmpty(message))
				{
					MessageBox.Show(message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSQL = remoteCall.RemotInterface.CheckUPDataList("HCS-workset-add014", sqlParameters);
				int result = remoteCall.RemotInterface.UPDataList("HCS-workset-add014", sqlParameters);
				if (result > 0)
				{
					DataRow[] isPrintCreateSendData = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code='IsPrintCreateSend'");
					if (isPrintCreateSendData != null && isPrintCreateSendData.Length == 1)
					{
						string isPrintCreateSend = Convert.ToString(isPrintCreateSendData[0]["value_code"]);

						if (isPrintCreateSend == "1")
						{
							OnPrintBtnClick(null, null);
						}
					}

					this.DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show("提交失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{

			}
		}

		/// <summary>
		/// 打印按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPrintBtnClick(object sender, EventArgs e)
		{
			mainTab.SelectedIndex = 1;

			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Invoice'");
			_sendOrderNum = GetSendOrderNum();
			if (arrayDR02.Length > 0)
			{
				string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
				PrintHelper.Instance.Print_DataGridView(sendInfoPreview, pringxml, _sendOrderNum, new string[] { txtCustomer.Text.Trim(), txtLocation.Text.Trim() });
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
	}
}
