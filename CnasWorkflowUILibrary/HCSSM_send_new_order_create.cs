using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseClassServer;
using Cnas.wns.CnasBaseInterface;
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
	public partial class HCSSM_send_new_order_create : MetroForm
	{
		/// <summary>
		/// 表示按下回车键是否可以响应事件
		/// </summary>
		private bool _canKeyDown = false;
		/// <summary>
		/// 记录上一次时间
		/// </summary>
		private DateTime _firstTime = DateTime.Now;
		/// <summary>
		/// 关闭母窗口选择 1 是  2否
		/// </summary>
		public int IsCfmCloseDialog = 2;
		/// <summary>
		/// 工单
		/// </summary>
		private CnasHCSWorkflowInterface _cnasHCSWorkflowInterface01;
		/// <summary>
		/// 订单完成时
		/// </summary>
		public SortedList OrderCount;
		/// <summary>
		/// 用户id
		/// </summary>
		public int Userid;
		/// <summary>
		/// 要修改的器械数量
		/// </summary>
		public SortedList InstrumentCount=new SortedList();
		/// <summary>
		/// 钩子
		/// </summary>
		private BarCodeHook _sendbarCodeHolder = new BarCodeHook();
		/// <summary>
		/// 客户名称
		/// </summary>
		public string CustomerName;
		/// <summary>
		/// 科室
		/// </summary>
		public string LocationStr;
		/// <summary>
		/// 发货单号
		/// </summary>
		public string SendOrderNum;
		/// <summary>
		/// 订单号
		/// </summary>
		public string OrderNum;
		/// <summary>
		/// 订单批次号
		/// </summary>
		public string Batch;
		/// <summary>
		/// 发货单对应的批次号;
		/// </summary>
		public string Otherbatch;
		/// <summary>
		/// 1 生成发货单的时候 2查看发货单
		/// </summary>
		public int Modle;
		/// <summary>
		/// 可扫码铁牌(BCC)的流程点(暂只考虑一个)
		/// </summary>
		private Dictionary<string, string> _dic;
		/// <summary>
		/// 添加类型
		/// </summary>
		private Dictionary<string, string> _dicInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 添加子类型
		/// </summary>
		private Dictionary<string, string> _dicChildInstrumentType = new Dictionary<string, string>();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="grid"></param>
		public HCSSM_send_new_order_create(SortedList orderList, CnasHCSWorkflowInterface cnasHCSWorkflowInterface01)
		{
			InitializeComponent();
			SetDicData();
			_cnasHCSWorkflowInterface01 = cnasHCSWorkflowInterface01;
			SendOrderNum = GetSendOrderNum();
			if (orderList!=null&&orderList.Count>0)
			{
				for (int i = 0; i < orderList.Count; i++)
				{
					object rowObj = orderList.GetByIndex(i);
					if (rowObj != null && rowObj is SortedList)
					{
						SortedList tempRow = (SortedList)rowObj;
						if (tempRow.Count == 8)
						{
							int index = dgv_orderBcu.Rows.Add();
							string codeType = Convert.ToString(tempRow[1]);
							string c_codeType = Convert.ToString(tempRow[2]);
							dgv_orderBcu.Rows[index].Cells["bid"].Value = index+1;
							dgv_orderBcu.Rows[index].Cells["codeType"].Value = codeType;
							dgv_orderBcu.Rows[index].Cells["c_codeType"].Value = c_codeType;
							dgv_orderBcu.Rows[index].Cells["t_b_bar_code"].Value = tempRow[3];
							dgv_orderBcu.Rows[index].Cells["b_bar_code"].Value = tempRow[4];
							dgv_orderBcu.Rows[index].Cells["b_ca_name"].Value = tempRow[5];
							dgv_orderBcu.Rows[index].Cells["send_count"].Value = tempRow[6];
							dgv_orderBcu.Rows[index].Cells["b_remark"].Value = tempRow[7];
							dgv_orderBcu.Rows[index].Cells["instrument_code"].Value = tempRow[8];
							dgv_orderBcu.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(codeType,c_codeType,_dicInstrumentType,_dicChildInstrumentType);//类型名称
						}
					}
				}
			}
			StartBarCodeHook();
		}

		/// <summary>
		/// 初始化类型值
		/// </summary>
		private void SetDicData()
		{
			_dicInstrumentType =OrderHelper.GetSetInstrumentTypeItem(string.Empty,false);
			_dicChildInstrumentType = OrderHelper.GetInstrumentChildTypeItem();
		}

		/// <summary>
		/// 查看送货单详情
		/// </summary>
		/// <param name="send_order"></param>
		/// <param name="send_batch"></param>
		public HCSSM_send_new_order_create(string send_order,string send_batch)
		{
			InitializeComponent();
			SendOrderNum = send_order;
			Otherbatch = send_batch;
			SetDicData();
			//StartBarCodeHook();
		}

		/// <summary>
		/// 设置其余属性字段
		/// </summary>
		private void SetDetailData()
		{
			txtSendOrderNum.Text = SendOrderNum;
			txtOrderNum.Text = OrderNum;
			txtCustmoer.Text = CustomerName;
			txtLocation.Text = LocationStr;
		}
		

		/// <summary>
		/// 获取名称类型
		/// </summary>
		/// <param name="fullName"></param>
		/// <param name="splitStr"></param>
		/// <returns></returns>
		private string GetTypeName(string fullName,string splitStr)
		{
			int index_of = fullName.IndexOf(splitStr);
			if(index_of>-1)
			{
				return fullName.Substring(0, index_of);
			}
			return fullName;
		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnbtnCloseSend_Click(object sender, EventArgs e)
		{
			IsCfmCloseDialog = 2;
			Close();
		}

		/// <summary>
		/// 启动钩子 
		/// </summary>
		private void StartBarCodeHook()
		{
			if (_sendbarCodeHolder != null)
			{
				_sendbarCodeHolder.Start(false);
				_sendbarCodeHolder.BarCodeEvent +=_sendbarCodeHolder_BarCodeEvent;
			}
			//this.Focus();
		}
		/// <summary>
		/// 扫码枪相应事件
		/// </summary>
		/// <param name="barCode"></param>
		void _sendbarCodeHolder_BarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			_canKeyDown = false;
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			HandleBarCode(matchBarCode);
		}

		/// <summary>
		/// 处理条码
		/// </summary>
		/// <param name="matchBarCode"></param>
		/// <returns></returns>
		private void HandleBarCode(string matchBarCode)
		{
			if (Modle == 1)
			{
				metBcuCode.Text = "";
				metBcuCode.Text = matchBarCode;
				if (_dic != null && _dic.Count > 1)
				{
					List<string> bcuList = OrderHelper.GetBcuPackForOrder();
					string index4 = matchBarCode.Length > 4 ? matchBarCode.Substring(0, 5) : matchBarCode;
					if (bcuList.Contains(index4))
					{
						resultLbl.Text = OrderHelper.GetDescribeString(2);
					}
					else
					{
						SortedList tempResult = _cnasHCSWorkflowInterface01.CheckBusinessLogic(matchBarCode, _dic);
						int bResult = -1;
						int.TryParse(Convert.ToString(tempResult["result_Code"]), out bResult);
						string bcc_barCode = Convert.ToString(tempResult["barCode"]);
						string bcc_barCodeObjectName = Convert.ToString(tempResult["barCodeObjectName"]);
						string resultStr = Convert.ToString(tempResult["result_Message"]);
						if (bResult == 0)
						{
							if (!_dic.ContainsKey(bcc_barCodeObjectName))
							{
								_dic.Add(bcc_barCodeObjectName, bcc_barCodeObjectName.Length > 3 ? bcc_barCodeObjectName.Substring(0, 3) : bcc_barCodeObjectName);
							}
							//grid数据添加
							AddDgv_BcuData(matchBarCode, bcc_barCode, bcc_barCodeObjectName);
						}
						resultLbl.Text = resultStr;
					}
				}
				else
				{
					resultLbl.Text = "内部码错误";
				}
			}
		}

		/// <summary>
		/// 停止钩子
		/// </summary>
		private void StopBarCodeHook()
		{
			if (_sendbarCodeHolder != null)
			{
				_sendbarCodeHolder.Stop();
			}
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_send_new_order_create_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			if(Modle==2)
			{
				LoadDataSendOrder(SendOrderNum, Otherbatch);
				btnSaveSend.Visible = false;
				dgv_bccDetail.ReadOnly = true;
				dgv_orderBcu.ReadOnly = true;
			}
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Send_order_allow_BCC_wf'");
			if (array != null && array.Length > 0)
			{
				//临时流程存储点
				string _wf_code = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
				_dic = new Dictionary<string, string>();
				string user_bar_code = string.Empty;
				if (CnasBaseData.UserBaseInfo != null)
					user_bar_code = CnasBaseData.UserBaseInfo.Userbcode;
				_dic.Add(user_bar_code, user_bar_code.Length > 2 ? user_bar_code.Substring(0, 3) : user_bar_code);
				string padding_wf_code = "BCV" + _wf_code.PadLeft(10, '0');
				_dic.Add(padding_wf_code, "BCV");
			}
			SetDetailData();
		}

		/// <summary>
		/// 提交
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnbtnSaveSend_Click(object sender, EventArgs e)
		{
			DataRow[] array =CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Accept_order_wf'");
			if (array != null && array.Length == 1)
			{
				string wf_code = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
				//打印datagrid
				DataGridView dgv_send_order = new DataGridView();
				dgv_send_order.AllowUserToAddRows = false;
				//dgv_send_order
				Dictionary<string, int> dicBcuSendOrder = new Dictionary<string, int>();
				Dictionary<string, int> dicNoBcuSendOrder = new Dictionary<string, int>();
				//HCS-send-order-type
				SortedList result = new SortedList();
				SortedList sendOrder = new SortedList();
				SortedList work_setUp = new SortedList();
				SortedList work_setIns = new SortedList();
				SortedList work_set_info = new SortedList();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria =reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				int m = 0, n = 0;//n 记录sendorder
				for (int i = 0; i < dgv_orderBcu.Rows.Count; i++)
				{
					SortedList part_order = new SortedList();
					DataGridViewRow row = dgv_orderBcu.Rows[i];
					string tempCodeType = Convert.ToString(row.Cells["codeType"].Value);
					string temp_C_CodeType = Convert.ToString(row.Cells["c_codeType"].Value);
					string bcu_bccCode =Convert.ToString(row.Cells["t_b_bar_code"].Value);
					string tempSend_Count = Convert.ToString(row.Cells["send_count"].Value);
					string[] codeArray = bcu_bccCode.Split(':');
					string bcuCode = Convert.ToString(Convert.ToString(row.Cells["b_bar_code"].Value));
					//器械包名称
					string ca_name = Convert.ToString(Convert.ToString(row.Cells["b_ca_name"].Value)).Trim();
					string instrument_code = Convert.ToString(row.Cells["instrument_code"].Value);
					if (!string.IsNullOrEmpty(bcu_bccCode))
					{
						string tempName = GetTypeName(ca_name, "<");
						if (dicBcuSendOrder.ContainsKey(tempName))
							dicBcuSendOrder[tempName] += 1;
						else
							dicBcuSendOrder.Add(tempName, 1);
						string bccCode = codeArray.Length == 2 ? codeArray[1] : codeArray[0];
						SortedList part_work_set_info = new SortedList();
						part_work_set_info.Add(1, str_Seria);
						part_work_set_info.Add(2, bcu_bccCode.Length > 3 ? bcu_bccCode.Substring(0, 3) : bcu_bccCode);
						part_work_set_info.Add(3, bcu_bccCode);
						part_work_set_info.Add(4, 3);
						part_work_set_info.Add(5, Userid);
						part_work_set_info.Add(6, "");
						work_set_info.Add(m + 1, part_work_set_info);
						SortedList part_work_Up = new SortedList();
						part_work_Up.Add(1, Userid);
						part_work_Up.Add(2, SendOrderNum);
						part_work_Up.Add(3, Batch);
						part_work_Up.Add(4, bccCode);
						work_setUp.Add(work_setUp.Count +1, part_work_Up);
						m++;
						SortedList par_sendOrder = new SortedList();
						par_sendOrder.Add(1, SendOrderNum);//sendNum
						par_sendOrder.Add(2, Otherbatch);//sendBatch
						par_sendOrder.Add(3, tempCodeType);//sendType
						par_sendOrder.Add(4, temp_C_CodeType);//c_sendType
						par_sendOrder.Add(5, OrderNum);//orderNum
						par_sendOrder.Add(6, string.Empty);//orderName
						par_sendOrder.Add(7, Batch);//orderBatch
						par_sendOrder.Add(8, bccCode);//bcc
						par_sendOrder.Add(9, bcuCode);//bcu
						par_sendOrder.Add(10, ca_name);//name
						par_sendOrder.Add(11, 1);//num
						par_sendOrder.Add(12, string.Empty);//wf_code
						par_sendOrder.Add(13, CnasBaseData.UserBaseInfo.UserID);//cre_userid
						par_sendOrder.Add(14, instrument_code);
						sendOrder.Add(n + 1, par_sendOrder);
						n++;
					}
					else
					{
						int int_send_count;
						int.TryParse(tempSend_Count, out int_send_count);
						SortedList par_sendOrder = new SortedList();
						par_sendOrder.Add(1, SendOrderNum);//sendNum
						par_sendOrder.Add(2, Otherbatch);//sendBatch
						par_sendOrder.Add(3, tempCodeType);//sendType
						par_sendOrder.Add(4, temp_C_CodeType);//c_sendType
						par_sendOrder.Add(5, OrderNum);//orderNum
						par_sendOrder.Add(6, string.Empty);//orderName
						par_sendOrder.Add(7, Batch);//orderBatch
						par_sendOrder.Add(8, string.Empty);//bcc
						par_sendOrder.Add(9, string.Empty);//bcu
						par_sendOrder.Add(10, ca_name);//name
						par_sendOrder.Add(11, int_send_count);//num
						par_sendOrder.Add(12, string.Empty);//wf_code
						par_sendOrder.Add(13, CnasBaseData.UserBaseInfo.UserID);//cre_userid
						par_sendOrder.Add(14, instrument_code);
						sendOrder.Add(n + 1, par_sendOrder);
						if (dicNoBcuSendOrder.ContainsKey(ca_name))
							dicNoBcuSendOrder[ca_name] += int_send_count;
						else
							dicNoBcuSendOrder.Add(ca_name, int_send_count);
						n++;
					}
				}
				int j = 1;
				for (int i = 0; i < dgv_bccDetail.Rows.Count; i++)
				{
					string bcu_bccCode = Convert.ToString(Convert.ToString(dgv_bccDetail.Rows[i].Cells["bar_code"].Value));
					string bcuCode = Convert.ToString(Convert.ToString(dgv_bccDetail.Rows[i].Cells["u_bar_code"].Value));
					//器械包名称
					string ca_name = Convert.ToString(Convert.ToString(dgv_bccDetail.Rows[i].Cells["ca_name"].Value)).Trim();
					string tempName = GetTypeName(ca_name, "<");
					if (dicBcuSendOrder.ContainsKey(tempName))
						dicBcuSendOrder[tempName] += 1;
					else
						dicBcuSendOrder.Add(tempName, 1);
					string[] codeArray = bcu_bccCode.Split(':');
					string bccCode = codeArray.Length == 2 ? codeArray[1] : codeArray[0];
					j++;
					SortedList part_work_set_info =new SortedList();
					part_work_set_info.Add(1, str_Seria);
					part_work_set_info.Add(2, bcu_bccCode.Length > 3 ? bcu_bccCode.Substring(0, 3) : bcu_bccCode);
					part_work_set_info.Add(3, bcu_bccCode);
					part_work_set_info.Add(4, 3);
					part_work_set_info.Add(5, Userid);
					part_work_set_info.Add(6, "");
					work_set_info.Add(m + 1, part_work_set_info);
					SortedList part_work_Up = new SortedList();
					part_work_Up.Add(1, Userid);
					part_work_Up.Add(2, SendOrderNum);
					part_work_Up.Add(3, Batch);
					part_work_Up.Add(4, bccCode);
					work_setUp.Add(m + 1, part_work_Up);
					m++;
					SortedList par_sendOrder = new SortedList();
					par_sendOrder.Add(1, SendOrderNum);//sendNum
					par_sendOrder.Add(2, Otherbatch);//sendBatch
					par_sendOrder.Add(3, 2);//sendType
					par_sendOrder.Add(4, 21);//c_sendType
					par_sendOrder.Add(5, OrderNum);//orderNum
					par_sendOrder.Add(6, string.Empty);//orderName
					par_sendOrder.Add(7, Batch);//orderBatch
					par_sendOrder.Add(8, bccCode);//bcc
					par_sendOrder.Add(9, bcuCode);//bcu
					par_sendOrder.Add(10, ca_name);//name
					par_sendOrder.Add(11, 1);//num
					par_sendOrder.Add(12, string.Empty);//wf_code
					par_sendOrder.Add(13, CnasBaseData.UserBaseInfo.UserID);//cre_userid
					par_sendOrder.Add(14, string.Empty);
					sendOrder.Add(n + 1, par_sendOrder);
					n++;
				}
				SortedList part_workIns = new SortedList();
				part_workIns.Add(1, wf_code);
				part_workIns.Add(2, str_Seria);
				part_workIns.Add(3, SendOrderNum);
				part_workIns.Add(4, Batch);
				work_setIns.Add(1, part_workIns);
				result.Add(1, sendOrder);
				result.Add(2, work_setUp);
				result.Add(3, work_setIns);
				result.Add(4, InstrumentCount);
				result.Add(5, work_set_info);
				if(OrderCount!=null&&OrderCount.Count>0&&OrderCount.Count==2)
				{
					SortedList newOrderCount = new SortedList();
					newOrderCount.Add(1, OrderCount);
					result.Add(6, newOrderCount);
				}
				//string testSql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add014", result);
				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add014", result);
				if (recint > 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "生成发货单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Invoice'");
					if (arrayDR02.Length > 0)
					{
						//序号so_id  品名 so_set_name 数量 so_num 时间 so_cre_date 备注 so_remark
						DataGridViewTextBoxColumn so_id = new DataGridViewTextBoxColumn();
						DataGridViewTextBoxColumn so_ca_name = new DataGridViewTextBoxColumn();
						DataGridViewTextBoxColumn so_num = new DataGridViewTextBoxColumn();
						DataGridViewTextBoxColumn so_cre_date = new DataGridViewTextBoxColumn();
						DataGridViewTextBoxColumn so_remark = new DataGridViewTextBoxColumn();
						dgv_send_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
						// 
						// 器械名称so_ca_name
						// 
						so_ca_name.HeaderText ="品名";
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
						string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
						if(dicBcuSendOrder.Count>0)
						{
							foreach(KeyValuePair<string,int> item in dicBcuSendOrder)
							{
								int index = dgv_send_order.Rows.Add();
								dgv_send_order.Rows[index].Cells["so_id"].Value = index + 1;
								dgv_send_order.Rows[index].Cells["so_ca_name"].Value = item.Key;
								dgv_send_order.Rows[index].Cells["so_num"].Value = item.Value;
								dgv_send_order.Rows[index].Cells["so_remark"].Value = string.Empty;
							}
						}
						if(dicNoBcuSendOrder.Count>0)
						{
							foreach (KeyValuePair<string, int> item in dicNoBcuSendOrder)
							{
								int index = dgv_send_order.Rows.Add();
								dgv_send_order.Rows[index].Cells["so_id"].Value = index + 1;
								dgv_send_order.Rows[index].Cells["so_ca_name"].Value = item.Key;
								dgv_send_order.Rows[index].Cells["so_num"].Value = item.Value;
								dgv_send_order.Rows[index].Cells["so_remark"].Value = string.Empty;
							}
						}
						PrintHelper.Instance.Print_DataGridView(dgv_send_order, pringxml, SendOrderNum,new string []{txtCustmoer.Text.Trim(),txtLocation.Text.Trim()});
					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					IsCfmCloseDialog = 1;
					Close();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "生成发货单" }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					IsCfmCloseDialog = 2;
				}
			}
		}

		/// <summary>
		/// 添加bcc码
		/// </summary>
		/// <param name="bcu"></param>
		/// <param name="bcc"></param>
		/// <param name="ca_name"></param>
		private void AddDgv_BcuData(string bcu, string bcc,string ca_name)
		{
			if (!string.IsNullOrEmpty(bcu) && !string.IsNullOrEmpty(bcc))
			{
				int index = dgv_bccDetail.Rows.Add();
				dgv_bccDetail.Rows[index].Cells["id"].Value = index + 1;
				dgv_bccDetail.Rows[index].Cells["u_bar_code"].Value = bcu;
				dgv_bccDetail.Rows[index].Cells["bar_code"].Value = bcc;
				dgv_bccDetail.Rows[index].Cells["ca_name"].Value = ca_name;
			}
		}

		/// <summary>
		/// 搜索框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void metBcuCode_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter&&_canKeyDown)
			{
				string  bcuCode=metBcuCode.Text.Trim();
				HandleBarCode(bcuCode);
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
		/// 生成发货单号
		/// </summary>
		/// <returns></returns>
		private string GetSendOrderNum()
		{
			string tempNumber = string.Empty;
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			int bccNumber = reCnasRemotCall.RemotInterface.GetSerialNumber(1, "BCO");
			if(bccNumber<=0)
			{
				tempNumber = "1";
			}
			else
			{
				tempNumber = bccNumber.ToString();
			}
			string number = "BCO" + tempNumber.PadLeft(10, '0');
			return number;
		}

		/// <summary>
		/// 加载订单详细内容
		/// </summary>
		/// <param name="send_order"></param>
		/// <param name="send_batch"></param>
		private void LoadDataSendOrder(string send_order,string send_batch)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			bool isFlag = true;
			condition.Add(1, send_order);
			condition.Add(2, send_batch);
			//string strSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-sendinfo-sec002", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sendinfo-sec002", condition);
			if(data!=null&&data.Rows.Count>0)
			{
				for(int i=0;i<data.Rows.Count;i++)
				{
					DataRow row = data.Rows[i];
					string send_type = Convert.ToString(row["send_type"]);//类型
					string bcu_code = Convert.ToString(row["bcu_code"]);//bcu
					string bcc_code = Convert.ToString(row["bcc_code"]);//bcc
					string ca_name = Convert.ToString(row["ca_name"]);//品名
					string c_send_type = Convert.ToString(row["c_send_type"]);//子类型
					string num = Convert.ToString(row["send_num"]);//数量
					if (isFlag)
					{
						OrderNum = Convert.ToString(row["order_code"]);
						CustomerName = Convert.ToString(row["cu_name"]);
						LocationStr = Convert.ToString(row["u_uname"]);
						isFlag = false;
					}
					if (send_type.Equals("1") || (send_type.Equals("2") && c_send_type.Equals("22")))
					{
						AddDgv_OrderBcuData(send_type, c_send_type, bcc_code, bcu_code, ca_name, num);
					}
					if(send_type.Equals("2")&&c_send_type.Equals("21"))
					{
						AddDgv_BcuData(bcu_code, bcc_code, ca_name);
					}
				}
			}
		}

		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="send_type"></param>
		/// <param name="c_send_type"></param>
		/// <param name="bccCode"></param>
		/// <param name="bcuCode"></param>
		/// <param name="bca_name"></param>
		/// <param name="num"></param>
		private void AddDgv_OrderBcuData(string send_type,string c_send_type,string bccCode,string bcuCode,string bca_name,string num)
		{
			int index = dgv_orderBcu.Rows.Add();
			dgv_orderBcu.Rows[index].Cells["bid"].Value = index + 1;
			dgv_orderBcu.Rows[index].Cells["codeType"].Value = send_type;
			dgv_orderBcu.Rows[index].Cells["c_codeType"].Value = c_send_type;
			dgv_orderBcu.Rows[index].Cells["t_b_bar_code"].Value = bccCode;
			dgv_orderBcu.Rows[index].Cells["b_bar_code"].Value = bcuCode;
			dgv_orderBcu.Rows[index].Cells["b_ca_name"].Value = bca_name;
			dgv_orderBcu.Rows[index].Cells["send_count"].Value = num;
			dgv_orderBcu.Rows[index].Cells["b_remark"].Value = string.Empty;
			dgv_orderBcu.Rows[index].Cells["codeTypeName"].Value = OrderHelper.GetEnumInstrumentTypeName(send_type, c_send_type,_dicInstrumentType,_dicChildInstrumentType);//类型名称
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnSaveSend.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			btnCloseSend.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 将小写字母转变为大写字母
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

	}
}
