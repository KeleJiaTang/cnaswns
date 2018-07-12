using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasBaseInterface;

using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasWorkflowUILibrary;
using log4net;
using Telerik.WinControls.UI;
using Cnas.wns.CnasWorkflowArithmetic;
using Cnas.wns.CnasMetroFramework.Controls;
using System.Reflection;
using CRD.Common;

namespace Cnas.wns.CnasHCSWorkspaceDecon
{
    public partial class HCSSM_scan_barcode : MetroForm
    {
		private ILog Logger = null;
        /// <summary>
        /// 提交给算法参数集合
        /// </summary>
        private SortedList SL_Submit = new SortedList();
        /// <summary>
        /// 当前已经扫描上的条码
        /// </summary>
        private SortedList SL_barcode = new SortedList();//当前已经扫描上的条码

        /// <summary>
        /// 当前区域工作台程序允许流程list
        /// </summary>
        private SortedList SL_AppPD = new SortedList();//当前区域工作台程序允许流程list

        private DataTable dtpdpart, dtapppd;

        private DataTable dtpartvalue = new DataTable();//所有参数的值集合

		/// <summary>
		/// 用于更新rfid
		/// </summary>
		private SortedList UpRfidData = new SortedList();

        /// <summary>
        /// 流程参数类型为1的参数
        /// </summary>
        private SortedList SL_parametertmp01 = new SortedList();//流程参数类型为1的参数
        /// <summary>
        /// 流程参数类型为2的参数
        /// </summary>
        private SortedList SL_parametertmp02 = new SortedList();//流程参数类型为2的参数
        /// <summary>
        /// 参数类型2选择时候留下的备注信息
        /// </summary>
        private SortedList SL_parametersinfo = new SortedList();//参数类型2选择时候留下的备注信息
        /// <summary>
        /// 存储当前流程信息，用于判断流程扫描条码先后允许顺序
        /// </summary>
        private SortedList SL_check = new SortedList();//存储当前流程信息，用于判断流程扫描条码先后允许顺序
        /// <summary>
        /// 将流程扫描允许条件放入集合SL_checkbarcode
        /// </summary>
        private SortedList SL_checkbarcode = new SortedList();//将流程扫描允许条件放入集合SL_checkbarcode

        private CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;

		private SortedList configDialogParames = new SortedList();

		private UserBase _userInfo = null;

		private BarCodeHook _scannerHook = null;

		private List<string> _bCURRelations = new List<string>();

		public bool IsInternalError = false;
		private bool _isOneTimeScan = true;
		private bool isOpenRfidDialog = false;

		private List<Image> _images = new List<Image>() { ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "defaultBgHor") };

		private List<Dictionary<string, string>> Operations { get; set; }  

        /// <summary>
        /// 初始化类构造函数
        /// </summary>
        /// <param name="indata">算法类</param>
        /// <param name="userbarcode">用户条码</param>
        /// <param name="dtpdpartin">所有参数集合</param>
        /// <param name="dtapppddata">当前工作台流程集合</param>
		public HCSSM_scan_barcode(CnasHCSWorkflowInterface indata, UserBase userInfo, DataTable dtpdpartdata, DataTable dtapppddata, DataTable dtpartvaluedata)
        {
            InitializeComponent();

			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			Logger = LogManager.GetLogger("CnasWNSClient");
			Logger.Info("log test");
            if (dtpdpartdata == null || dtapppddata == null)
            {
				if (dtpdpartdata == null)
				{
					dtpdpartdata = new DataTable();
					if (!dtpdpartdata.Columns.Contains("pd_code"))
					{
						dtpdpartdata.Columns.Add("pd_code", typeof(string));
					}
				}
				else
				{
					IsInternalError = true;
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("nopdParameters", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Dispose();
					return;
				}
            }
            dtpartvalue = dtpartvaluedata;
			_userInfo = userInfo ?? new UserBase();
			//_scanUserInfo = (new DBServer()).GetUserByBarCode(userbarcode);
            for (int i = 0; i < dtapppddata.Rows.Count;i++ )
            {
                string str_pdname="",str_pdbcode="";
                if(dtapppddata.Rows[i]["pd_bcode"] != null) str_pdbcode = dtapppddata.Rows[i]["pd_bcode"].ToString();
                if(dtapppddata.Rows[i]["pd_name"] != null) str_pdname = dtapppddata.Rows[i]["pd_name"].ToString();
                SL_AppPD.Add(str_pdbcode,str_pdname);                
            }
            if (SL_AppPD.Count>0) AutoImage(SL_AppPD);

            BCXP900000002.BackgroundImage = BarCodeHelper.GetBarcodeImage("BCXP900000002", "退出扫码");
			BCXP900000001.BackgroundImage = BarCodeHelper.GetBarcodeImage("BCXP900000001", "确认操作");

            dtpdpart = dtpdpartdata;
            dtapppd = dtapppddata;

            CnasHCSWorkflowInterface01 = indata;
			SL_barcode.Add(userInfo.Userbcode, "BCB");
			_scanBarCodes.Add(userInfo.Userbcode, "BCB");
			addtodgv(userInfo.Userbcode, userInfo.UserName, userInfo.UserID.ToString());

            //检查参数：用来存储判断参数
            SL_check.Add("pd_code", "");
            SL_check.Add("pd_name", "");
            SL_check.Add("pd_barcode", "");
            SL_check.Add("pd_scan", "");
            SL_check.Add("pd_par1", "");
            SL_check.Add("pd_par2", "");

			IsInternalError = false;

			_scannerHook = new BarCodeHook();
			_scannerHook.BarCodeEvent += OnScanFormScaned;
			_scannerHook.Start(false);

			//pic_data.Images = _images;
        }

		void OnScanFormScaned(BarCodeHook.BarCodes barCode)
		{
			_canKeyDown = false;
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			Logger.Info(string.Format("scan code:{0}", matchBarCode));

			if (matchBarCode.Length == 13 && matchBarCode.Substring(0, 2) == "BC")
			{
				string resultString = setbarcode(matchBarCode);
				mlab_info.Text = resultString;
				//mlab_info.Text = string.IsNullOrEmpty(resultString) ? matchBarCode : resultString;
				barCodeTxt.Text = matchBarCode;
			}
			Logger.Info(string.Format("OnScanFormScaned  CanKeyDown: {0}", _canKeyDown));
		}

		private void BCX_Click(object sender, EventArgs e)
		{
			//参数类三种：1、系统参数；2、人机交互参数；3、其他参数；9、界面固定控制按钮
			string str_name = ((PictureBox)sender).Name;
			string strrec = setbarcode(str_name);
			mlab_info.Text = strrec;
		}

		private DateTime _firstTime = DateTime.Now;
		private bool _canKeyDown = false;

		private void OnBarCodeKeyDown(object sender, KeyEventArgs e)
		{
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			if (e.KeyData == Keys.Enter && _canKeyDown)
			{
				string matchBarCode = BarCodeHelper.GetMatchBarCode(barCodeTxt.Text);
				Logger.Info(string.Format("scan code:{0}", barCodeTxt.Text));
				string resultString = setbarcode(barCodeTxt.Text);
				mlab_info.Text = resultString;
				//mlab_info.Text = string.IsNullOrEmpty(resultString) ? matchBarCode : resultString;
			}
			_firstTime = DateTime.Now;

			Logger.Info(string.Format("OnBarCodeKeyDown  TimeSpan:{0} , KeyData :{1} , CanKeyDown: {2}", ts.Milliseconds, e.KeyData, _canKeyDown));

			if (ts.Milliseconds < 20)
			{
				barCodeTxt.Text = "";
				_canKeyDown = false;
			}
			else
			{
				_canKeyDown = true;
			}
		}

        private void AutoImage(SortedList indata)
        {
            wfPanel.Controls.Clear();
            int int_Y = 15;
            for(int i=0;i<indata.Count;i++)
            {
                if (i > 6) return; //最多允许排列6个按钮；
                PictureBox pic_tmp = new PictureBox();
                pic_tmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                pic_tmp.Location = new System.Drawing.Point(1, int_Y);
                //this.pic_02.Location = new System.Drawing.Point(2, 20);
                pic_tmp.Name = indata.GetKey(i).ToString();
                pic_tmp.Size = new System.Drawing.Size(180, 80);
                pic_tmp.TabStop = false;
                pic_tmp.BackgroundImage = BarCodeHelper.GetBarcodeImage(indata.GetKey(i).ToString(), indata.GetByIndex(i).ToString());
                pic_tmp.Click += new System.EventHandler(this.BCX_Click);
				wfPanel.Controls.Add(pic_tmp);
                int_Y = int_Y + 90;
            }

        }

        private string setbarcode(string indata)
        {
			if (string.IsNullOrEmpty(indata) || indata.Length < 5)
				return "输入错误，请重新扫描。";
            string str_bcx = indata.Substring(0, 5);
            if (str_bcx == "BCXP9")
            {
                if (indata == "BCXP900000001")
                {
					SL_barcode.Clear();
					foreach (var item in _scanBarCodes)
					{
						SL_barcode.Add(item.Key, item.Value);
					}
					SL_checkbarcode.Clear();
					foreach (var item in _scanParams)
					{
						SL_checkbarcode.Add(item.Key, item.Value);
					}
					SL_check["pd_scan"] = SL_checkbarcode;//流程允许扫描代码
                    //确定开始提交（扫描万所有用户、流程、包等等）
					string str_pdcode = SL_check["pd_code"].ToString();
					//检查所有条码是否已经扫描完成
					string submitMessage = string.Empty;
					//string subMessage = string.Empty;
					if (str_pdcode == "" || submitok(ref submitMessage) < 0)
					{
						submitMessage = string.IsNullOrEmpty(submitMessage) ? "请先选择流程,或者扫描完所有条码后提交" : submitMessage;
						return submitMessage;
					}


					this.BeginInvoke(new Action(() =>
					{
						#region 首先判断是否有人机交互参数需要选择，如果有需要调用HCSSM_parameters_select  

						HCSWF_dialog_container form = new HCSWF_dialog_container(SL_barcode, SL_check, CnasHCSWorkflowInterface01, Convert.ToString(SL_check["pd_code"]), SL_parametertmp02, dtpartvalue, SL_parametersinfo);
						if (form.DialogResultStatus == 1)
						{
							if (!form.ViewData.ContainsKey("UserInfo"))
								form.ViewData.Add("UserInfo", _userInfo);
							_scannerHook.Stop();
							form.ShowDialog();
							_scannerHook.Start(false);
							if (form.DialogResultStatus == 3)
							{
								this.Close();
							}
							else if (form.DialogResultStatus == 2)
							{
								if (form.OutputParameters != null && form.OutputParameters.Count > 0)
									configDialogParames = form.OutputParameters;
								SL_barcode = form.ScanBarCodes;
								if (configDialogParames != null && configDialogParames.ContainsKey("pd_par2"))
								{
									SL_parametertmp02 = (SortedList)configDialogParames["pd_par2"];
									SL_check["pd_par2"] = SL_parametertmp02;
								}
								if (configDialogParames != null && configDialogParames.ContainsKey("Par2_info"))
								{
									SL_parametersinfo = (SortedList)configDialogParames["Par2_info"];
								}
							}
							else
							{
								submitMessage = "取消提交";
							}

							if (form.OutputParameters != null && form.OutputParameters.ContainsKey("DialogGridParamters"))
							{
								SortedList bccCodeList = (SortedList)form.OutputParameters["DialogGridParamters"];
								if (bccCodeList != null && bccCodeList.Count > 0)
								{
									DrawGridBccData(dgv_01, bccCodeList);
								}
							}
						}
						else
						{
							//开始人机交互参数选择界面
							if (SL_parametertmp02.Count > 0 && SL_parametersinfo.Count == 0)
							{
								HCSWF_parameters_select HCSSM_parameters_select01 = new HCSWF_parameters_select(SL_check["pd_code"].ToString(), SL_parametertmp02, dtpartvalue);
								HCSSM_parameters_select01.ShowDialog();
								//获取parameter_02参数的交互值
								if (HCSSM_parameters_select01.Int_rec < 0)
								{
									submitMessage = "取消提交";
								}
								else
								{
									SL_parametertmp02 = HCSSM_parameters_select01.SL_returnparametersvalue;
									SL_parametersinfo = HCSSM_parameters_select01.SL_returnparametersinfo;
								}

								SL_check["pd_par2"] = SL_parametertmp02;
							}
						}

						#endregion

						#region 开始提交给下一步流程
						if (string.IsNullOrEmpty(submitMessage))
						{
							submitwf();
						}
						else
							mlab_info.Text = submitMessage;

						#endregion
					}));

					return submitMessage;


                }
                else if (indata == "BCXP900000002")
                {
                    this.Close();
                }
            }
            else if (str_bcx == "BCXP2")
            {
                //处理人机交互选择

            }
            else if (str_bcx == "BCXP1")
            {
                //系统参数，好像不用处理
            }
            else
			{
				string businessResult = "";
				try
				{
					Dictionary<string, string> result = DoBusinessLogic(indata, ref _scanBarCodes, ref _scanParams);
					if (result["result_code"] == "5")
					{
						foreach (DataGridViewRow item in dgv_01.Rows)
						{
							if (item.Cells["barcode"].Value.ToString().Contains(indata))
							{
								item.Selected = true;
								break;
							}
						}
					}
					mlab_current.Text = result["result_nextcode"];
					if (!string.IsNullOrEmpty(result["BCURRelation"]) && !_bCURRelations.Contains(result["BCURRelation"]))
					{
						_bCURRelations.Add(result["BCURRelation"]);
					}
					if (Boolean.Parse(result["result_isAddDgv"]))
					{
						string messageForBox = result["MessageBox_Message"];
						int messageOperation = 1;
						if (!string.IsNullOrEmpty(messageForBox) && int.TryParse(result["Message_Operation"], out messageOperation))
						{
							if (MessageBox.Show(messageForBox, "信息提示", (messageOperation== 1 ? MessageBoxButtons.OK : MessageBoxButtons.OKCancel), MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
							{
								return string.Format("{0} --用户取消", messageForBox);
							}
						}
						if (Boolean.Parse(result["isModifyOrder"]) && result["barCode"].Contains("BCC"))
						{
							string bccCode = result["barCode"].Substring(result["barCode"].IndexOf("BCC"), 13);
							if (BarCodeHelper.IsSpecialSet(bccCode))
							{
								_scannerHook.Stop();
								HCSWF_set_instrument_modify modifyDialog = new HCSWF_set_instrument_modify(bccCode);
								modifyDialog.ShowDialog();
								_scannerHook.Start(false);
							}
							else if (BarCodeHelper.IsOrderSet(bccCode))
							{
								bool isBindingMode = BarCodeHelper.IsOrderOutSet(bccCode);
								_scannerHook.Stop();
								HCSSM_order_new_order_detail modifyDialog = new HCSSM_order_new_order_detail(bccCode, result["WorkSetBatch"], isBindingMode);
								this.Invoke(new Action(() =>
									{
										modifyDialog.Mode = 3;
										modifyDialog.ShowDialog();
									}));
								_scannerHook.Start(false);
								if (modifyDialog.SaveResult <= 0)
								{
									if (_scanBarCodes.ContainsKey(result["barCode"]))
										_scanBarCodes.Remove(result["barCode"]);
									return "订单确认取消";
								}
							}
						}

						if (result["barCode"].Contains("BCC"))
						{
							string bccCode = result["barCode"].Substring(result["barCode"].IndexOf("BCC"), 13);
							this.Invoke(new Action(() => {
								HCSSM_set_message_show setMessageDialog = new HCSSM_set_message_show();
								setMessageDialog.SetBarCode = bccCode;
								string pdBarCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
								if (pdBarCode.Length > 12)
								{
									int messageCount = setMessageDialog.GetMessageList(pdBarCode.Substring(9, 4));
									if (messageCount > 0)
									{
										_scannerHook.Stop();
										setMessageDialog.ShowDialog();
										_scannerHook.Start(false);
									}
								}
							}));
						}

						if (Boolean.Parse(result["IsShowRFIDDialog"]))
						{
							if (isOpenRfidDialog)
							{
								this.Invoke(new Action(() => {
									if (_isOneTimeScan)
									{
										_scannerHook.Stop();
										_isOneTimeScan = false;
										HCSWF_instrument_RFID_search rfidDialog = new HCSWF_instrument_RFID_search(result["barCode"]);
										rfidDialog.userId = _userInfo.UserID;
										string temp_pdCode = "2020";
										IEnumerable<KeyValuePair<string, string>> re_pdCode = _scanBarCodes.Where(p => p.Value == "BCV");
										if (re_pdCode.Count() > 0)
										{
											string str_pd = re_pdCode.First().Key;
											if (str_pd.Length > 4)
												temp_pdCode = str_pd.Substring(str_pd.Length - 4, 4);
										}
										rfidDialog.PdCode = temp_pdCode;
										rfidDialog.ShowDialog();
										if (UpRfidData.ContainsKey(rfidDialog._bccCode))
											UpRfidData.Add(rfidDialog._bccCode, rfidDialog.UpDataConditon);
										else
											UpRfidData[rfidDialog._bccCode] = rfidDialog.UpDataConditon;
										if (rfidDialog.IsClosed)
											_isOneTimeScan = true;

										_scannerHook.Start(false);
									}
								}));
							}
						}

						string barCodeName = !string.IsNullOrEmpty(result["barCodeObjectName"]) ? result["barCodeObjectName"] : result["barCode"];
						addtodgv(result["barCode"], barCodeName, result["barCodeObjectName"], result["WorkSetBatch"]);
					}
					
					businessResult = result["result_message"];
				}
				catch (Exception ex)
				{
					Logger.Error("扫描错误：",ex);
				}

				return businessResult;
            }
            return "";
        }
		private Dictionary<string, int> _scanParams = new Dictionary<string, int>();
		private Dictionary<string, string> _scanBarCodes = new Dictionary<string, string>();

		private Dictionary<string, dynamic> CheckBarCodeCount(string barCode, Dictionary<string, string> scanCodes, Dictionary<string, int> values)
		{
			Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
			result.Add("result_code", 0);
			result.Add("result_message", string.Empty);
			string barCodeType = barCode.Substring(0, 3);
			int number = 0;
			bool isContained = false;
			foreach (KeyValuePair<string,string> item in scanCodes)
			{
				if (item.Value == barCodeType || item.Value.Equals("XXX"))
					number++;
				if (item.Key.Contains(barCode)
					|| (item.Value == barCodeType && scanCodes.Count == 1 && barCodeType.Equals("BCB")))
					isContained = true;
			}

			if (isContained)
			{
				result["result_code"] = 5;  //该条码已经存在
				result["result_message"] = "该条码已经扫描";
			}
			else
			{
				if (values != null && values.Count > 0)
				{
					scanCodes = scanCodes ?? new Dictionary<string, string>();
					int requestNum = values.ContainsKey(barCodeType) ? values[barCodeType] : values.ContainsKey("XXX") ? values["XXX"] : 0;
					string current = GetNextCode(scanCodes.ElementAt(scanCodes.Count - 1).Value, values);
					if (current.Contains(barCodeType) || current.Contains("XXX"))
					{
						if (requestNum == 0)
						{
							result["result_code"] = 2;  // 输入参数为0， 即该流程可以不输入该参数，也可以输入该参数
							result["result_message"] = "输入参数为0， 即该流程可以不输入该参数，也可以输入该参数";
						}
						else if (requestNum == 99)
						{
							result["result_message"] = "输入参数无限制，请继续扫描该参数或者下一参数";
						}
						else
						{
							if (number == requestNum)
							{
								result["result_code"] = 3;  //条件已经满足，请扫描下一个编码。
								result["result_message"] = "输入参数个数已经满足，请扫描下一个参数";
							}
						}
					}
					else
					{
						result["result_code"] = 4; //扫描编码不符合  不可以添加到ScanCode中
						result["result_message"] = "扫描编码不符合";
					}
				}
				else
				{
					if (number == 0)
					{
						result["result_code"] = 1;  // 无法知道流程参数的关系
						result["result_message"] = "无法知道流程参数的关系";
					}
				}
			}

			return result;
		}

		private string GetNextCode(string barCodeType, Dictionary<string, int> values)
		{
			//Todo enhance mult number config.
			int currentCodeIndex = -1;
			string nextCodeType = string.Empty;
			int index = 0;
			if (values != null && values.Count > 0)
			{
				foreach (KeyValuePair<string, int> item in values)
				{
					if ((item.Key == barCodeType || item.Key == "XXX") && currentCodeIndex ==-1)
						currentCodeIndex = index;
					if (index >= currentCodeIndex && currentCodeIndex != -1)
					{
						if (index == currentCodeIndex)
						{
							if (item.Value > 1)
								nextCodeType += string.Format("{0},", item.Key);
						}
						else
						{
							nextCodeType += string.Format("{0},", item.Key);
							if (item.Value != 0 && item.Value != 99)
								break;
						}
					}
					index++;
				}
			}
			else
			{
				nextCodeType = "BCV";
			}

			return nextCodeType;
		}

		private Dictionary<string, string> DoBusinessLogic(string barCode, ref Dictionary<string, string> scanCodes, ref Dictionary<string, int> values)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			result.Add("result_code", "1");  // "扫码编码是否符合规则：1，符合；2，不符合"
			result.Add("result_message", string.Empty);
			result.Add("result_nextcode", string.Empty);
			result.Add("result_isAddDgv", "false");
			result.Add("isModifyOrder", "false");
			result.Add("barCode", string.Empty);
			result.Add("barCodeObjectName", string.Empty);
			result.Add("barCodeObjectId", string.Empty);
			result.Add("IsShowRFIDDialog", "false");
			result.Add("WorkSetBatch", string.Empty);
			result.Add("Message_Type", "Information");
			result.Add("Message_Operation", "1");  //1 只有确定按钮，确定后直接根据错误类型运行 //2 确定和取消都有，根据用户选择运行
			result.Add("MessageBox_Message", string.Empty);
			result.Add("BCURRelation", string.Empty);
			scanCodes = scanCodes ?? new Dictionary<string, string>();
			values = values ?? new Dictionary<string, int>();
			string barCodeType = barCode.Substring(0, 3);
			int bResult = -1;
			Dictionary<string, dynamic> checkCountResult = CheckBarCodeCount(barCode, scanCodes, values);
			int resultInt = checkCountResult["result_code"];
			if (resultInt < 3)
			{
				SortedList checkBResult = CnasHCSWorkflowInterface01.CheckBusinessLogic(barCode, scanCodes);
				result["isModifyOrder"] = Boolean.Parse(checkBResult["IsModifyOrder"].ToString()) ? "true" : "false";
				bResult = int.Parse(checkBResult["result_Code"].ToString());
				result["barCode"] = checkBResult["barCode"].ToString();
				result["barCodeObjectName"] = checkBResult["barCodeObjectName"].ToString();
				result["barCodeObjectId"] = checkBResult["barCodeObjectId"].ToString();
				result["WorkSetBatch"] = checkBResult["WorkSetBatch"].ToString();
				result["IsShowRFIDDialog"] = checkBResult["IsShowRFIDDialog"].ToString();
				result["Message_Type"] = checkBResult["Message_Type"].ToString();
				result["Message_Operation"] = checkBResult["Message_Operation"].ToString();
				result["MessageBox_Message"] = checkBResult["MessageBox_Message"].ToString();
				result["BCURRelation"] = checkBResult["BCURRelation"].ToString();
				if (bResult == 0)
				{
					string currentNeed = GetNextCode(scanCodes.ElementAt(scanCodes.Count - 1).Value, values);
					scanCodes.Add(result["barCode"], currentNeed.Substring(0, 3));
					if (barCodeType.Equals("BCV"))
					{
						#region implement BCV code.

						DataRow[] workFlowInfo = dtapppd.Select(string.Format("pd_bcode='{0}'", barCode));
						if (workFlowInfo.Length == 0)
						{
							result["result_code"] = "0";
							bResult = 101;
							result["result_message"] = "扫描的流程不属于该区域";
							if (scanCodes.ContainsKey(barCode))
								scanCodes.Remove(barCode);
						}
						else
						{
							if (scanCodes.ContainsValue(barCodeType))
							{
								string scanParam = string.Empty;
								string pdCode = string.Empty;
								if (workFlowInfo[0]["pd_name"] != null) result["barCodeObjectName"] = workFlowInfo[0]["pd_name"].ToString();
								if (workFlowInfo[0]["pd_code"] != null) pdCode = workFlowInfo[0]["pd_code"].ToString();
								if (workFlowInfo[0]["pd_scan"] != null) scanParam = workFlowInfo[0]["pd_scan"].ToString();
								if (!string.IsNullOrEmpty(scanParam))
								{
									result["result_isAddDgv"] = "true";
									string[] scanParams = scanParam.Split(';');
									foreach (string item in scanParams)
									{
										if (item.Length > 3 && !values.ContainsKey(item.Substring(0, 3)))
										{
											_scanParams.Add(item.Substring(0, 3), int.Parse(item.Substring(3)));
										}
									}
									SL_check["pd_code"] = workFlowInfo[0]["pd_code"].ToString();//流程代码
									SL_check["pd_name"] = result["barCodeObjectName"];//流程名字
									SL_check["pd_barcode"] = barCode;//流程编码
								}
								SL_check["pd_par1"] = SL_parametertmp01;//所有流程参数为1的集合
								SL_check["pd_par2"] = SL_parametertmp02;//所有流程参数为2的集合

								SL_parametertmp01.Clear();
								SL_parametertmp02.Clear();
								DataRow[] pdParameters = dtpdpart.Select("pd_code=" + pdCode);
								foreach (DataRow dr in pdParameters)
								{
									string parameterName = dr["par_name"].ToString();
									string parameterType = dr["par_type"].ToString();
									string parameterDescription = dr["par_description"].ToString();
									if (parameterType == "2")
									{
										SL_parametertmp02.Add(parameterName, parameterDescription);
									}
									else
									{
										SL_parametertmp01.Add(parameterName, parameterDescription);
									}
								}
								if (values == null || values.Count == 0)
								{
									result["result_code"] = "1";
									result["result_message"] = "该流程没有配置扫描参数，请联系管理员";
								}
								else
								{
									result["result_message"] = "扫描条码成功。";
								}
							}
						}

						#endregion
					}
					else
					{
						result["result_isAddDgv"] = "true";
						result["result_message"] = !string.IsNullOrEmpty(checkBResult["result_Message"].ToString()) ? checkBResult["result_Message"].ToString() : "扫描条码成功。";
					}
				}
				else
				{
					result["result_message"] = checkBResult["result_Message"].ToString();
				}
			}
			else if (resultInt == 5)
			{
				result["result_code"] = "5";
				result["result_message"] = checkCountResult["result_message"];
			}
			else
			{
				result["result_message"] = checkCountResult["result_message"];
			}
			string lastScanType = scanCodes.ElementAt(scanCodes.Count - 1).Value;
			string current = GetNextCode(lastScanType, values);
			if (!string.IsNullOrEmpty(current))
			{
				if (current.Contains(barCodeType) && resultInt < 3 && bResult == 0)
					result["result_nextcode"] = "扫描参数完成";
				else
				{

					result["result_nextcode"] = string.Format("请扫描：{0}", GetNextNames(current));
				}
					
			}
			else
			{
				result["result_nextcode"] = "扫描参数完成";
			}

			return result;
		}

		private string GetNextNames(string nextCode)
		{
			string[] nexts = nextCode.Split(',');
			string nextNames = string.Empty;
			foreach (string item in nexts)
			{
				string name = BarCodeHelper.GetBarCodeTypeName(item);
				if (!string.IsNullOrEmpty(name))
					nextNames += string.Format("{0}、", name);
			}
			nextNames = nextNames.Substring(0, nextNames.Length - 1);
			return nextNames;
		}

		private void DrawGridBccData(DataGridView grid, SortedList bccCodeList)
		{
			if (bccCodeList != null && bccCodeList.Count > 0)
			{
				for (int i = 0; i < bccCodeList.Count; i++)
				{
					string key = Convert.ToString(bccCodeList.GetKey(i));
					DataRow data = bccCodeList.GetByIndex(i) as DataRow;
					if (data != null)
					{
						string objectId = string.Empty, objectName = string.Empty, batch = string.Empty;
						if (data.Table.Columns.Contains("id")) objectId = Convert.ToString(data["id"]);
						if (data.Table.Columns.Contains("batch")) batch = Convert.ToString(data["batch"]);
						if (data.Table.Columns.Contains("ca_name")) objectName = Convert.ToString(data["ca_name"]);
						if (!_scanBarCodes.ContainsKey(key))
						{
							_scanBarCodes.Add(key, key.Substring(0, 3));
							addtodgv(key, objectName, objectId, batch);
						}
					}
					
				}
			}
		}

        /// <summary>
        /// 判断是否具备提交条件（所有要求条码都具备）
        /// </summary>
        /// <returns></returns>
        private int submitok(ref string resultMessage)
        {
            //string strscan = SL_check["pd_scan"].ToString();
            if (SL_checkbarcode.Count > 0 && dgv_01.RowCount > 0)
            {
                for (int i = 0; i < SL_checkbarcode.Count; i++)
                {
                    string str_tmp = SL_checkbarcode.GetKey(i).ToString();
					string str_count = SL_checkbarcode.GetByIndex(i).ToString();
					
                    int int_tag = 0;
					if (str_count.Equals("0"))
					{
						int_tag = 1;
					}
					else
					{
						for (int j = 0; j < dgv_01.RowCount; j++)
						{
							string str_tmo01 = dgv_01.Rows[j].Cells["barcode"].Value.ToString().Substring(0, 3);
							if (str_tmp == str_tmo01) int_tag = 1;
						}
					}

					if (str_tmp == "BCU" && _bCURRelations.Count > 0)
					{
						foreach (string relation in _bCURRelations)
						{
							string[] bCURCodes = relation.Split(',');
							foreach (string needBCUR in bCURCodes)
							{
								string scanBCUR = _scanBarCodes.Keys.FirstOrDefault(p => p.StartsWith(needBCUR));
								if (string.IsNullOrEmpty(scanBCUR))
								{
									int_tag = 0;
									resultMessage = "拆分包未扫描完成。请检查";
									break;
								}
							}
						}
					}

                    if (int_tag == 0) return -1;
                }
            }
            else
            {
                return -1;
            }
            return 1;
        }
       
        /// <summary>
        /// 显示包、车列表信息
        /// </summary>
        /// <param name="in_BCCdata"></param>
        private void showBCCdata(string in_BCCdata)
        {
            dgv_02.DataSource = null;
			if (!string.IsNullOrEmpty(in_BCCdata))
			{
				#region 显示手术包:器械清单、包清单
				string str_bcx = in_BCCdata.Substring(0, 3);

				#region 处理替代条码

				if (str_bcx == "BCU" && in_BCCdata.Length > 15)
				{
					//处理BUC拼装字符串中，找出BCC
					in_BCCdata = in_BCCdata.Substring(14);
					str_bcx = in_BCCdata.Substring(0, 3);
				}
				#endregion
				if (str_bcx == "BCC" && !BarCodeHelper.IsTempSet(in_BCCdata))
				{
					//rexxie需要开发显示每把实体器械。               

					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					SortedList sttemp01 = new SortedList();
					string instrumentSql = BarCodeHelper.IsSpecialSet(in_BCCdata)?
						"HCS-workset-showlist-sec003" : "HCS-workset-showlist-sec002";
					if (BarCodeHelper.IsOrderSet(in_BCCdata))
					{
						string batchNum =dgv_01.SelectedRows != null &&dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0].Tag != null 
										? dgv_01.SelectedRows[0].Tag.ToString() : string.Empty;
						if (string.IsNullOrEmpty(batchNum))
							return;
						instrumentSql = "HCS-workset-showlist-sec004";
						sttemp01.Add(1, in_BCCdata);
						sttemp01.Add(2, batchNum);
						//sttemp01.Add(3, in_BCCdata);
						//sttemp01.Add(4, batchNum);
					}
					else
					{
						sttemp01.Add(1, in_BCCdata);
					}
					string testSql = reCnasRemotCall.RemotInterface.CheckSelectData(instrumentSql, sttemp01);
					DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData(instrumentSql, sttemp01);
					dgv_02.DataSource = dtworktmp;
					if (dgv_02.Columns.Contains("数量"))
					{
						int total = 0;
						foreach (DataGridViewRow row in dgv_02.Rows)
						{
							int num = 0;
							if (row.Cells["数量"].Value != null && int.TryParse(row.Cells["数量"].Value.ToString(), out num))
								total += num;
						}
						if (total > 0)
							dgv_02.Columns["数量"].HeaderText += string.Format(" (总数量: {0})", total);
					}
				}
				else if (str_bcx == "BCD" || str_bcx == "BCW" || str_bcx == "BCZ" || str_bcx == "BCO")
				{
					string pdBarCode = _scanBarCodes.Keys.FirstOrDefault(p => p.StartsWith("BCV"));
					if (!string.IsNullOrEmpty(pdBarCode) && pdBarCode.Length == 13)
					{
						CnasRemotCall reCnasRemotCall = new CnasRemotCall();
						SortedList sttemp01 = new SortedList();
						sttemp01.Add(1, pdBarCode.Substring(9,4));
						sttemp01.Add(2, in_BCCdata);
						sttemp01.Add(3, 0);
						string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-showlist-sec001", sttemp01);
						
						DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-showlist-sec001", sttemp01);
						dgv_02.DataSource = dtworktmp;
					}
				}
				//else
				//{
				//	CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				//	DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-empty-sec001", null);
				//	if (dtworktmp!= null)
				//	{
				//		dtworktmp.Rows.Clear();
				//		dgv_02.DataSource = dtworktmp;
				//	}
				//	
				//}

				#endregion
			}

			#region 显示手术包图片

			SetPicData(in_BCCdata);

			#endregion
        }

        private string addtodgv(string objectBarCode,string objectName, string objectId, string batch="")
        {
            int rowIndex = dgv_01.Rows.Add();
			dgv_01.Rows[rowIndex].Cells["id"].Value = dgv_01.RowCount;
			dgv_01.Rows[rowIndex].Cells["barcode"].Value = objectBarCode;
			dgv_01.Rows[rowIndex].Cells["name"].Value = objectName;
			dgv_01.Rows[rowIndex].Cells["objectId"].Value = objectId;
			dgv_01.Rows[rowIndex].Tag = batch;
			dgv_01.Rows[rowIndex].Selected = true;
			//if (isShow)
				//showbarcode();
			//SetPicData(inbcdata);
            return "扫码成功";  
        }

		public void SetPicData(string setbarCode)
		{
			List<Image> images = new List<Image>();
			if (!string.IsNullOrEmpty(setbarCode) && setbarCode.StartsWith("BCC") && !BarCodeHelper.IsTempSet(setbarCode))
			{

				SortedList sortedList = new SortedList();
				sortedList.Add(1, setbarCode);
				sortedList.Add(2, "1");
				CnasRemotCall remoteClient = new CnasRemotCall();
				string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-image-sec002", sortedList);
				DataTable dtImageList = remoteClient.RemotInterface.SelectData("HCS-image-sec002", sortedList);
				if (dtImageList != null && dtImageList.Rows != null && dtImageList.Rows.Count > 0)
				{
					Image image = null;
					foreach (DataRow item in dtImageList.Rows)
					{
						string fileName = "";
						image = null;
						if (item["data_url"] != null) fileName = item["data_url"].ToString();
						if (!string.IsNullOrEmpty(fileName))
						{
							ImageCache imageCache = new ImageCache();
							image = imageCache.GetImageByFolderNameFileName("set/", fileName);
							if (image != null)
								images.Add(image);
						}
					}
				}
				else
				{
					images = _images;
				}
			}
			else
			{
				images = _images;
			}
			pic_data.Images = images;

		} 

        private void submitwf()
        {
            SL_Submit.Clear();
            SL_Submit.Add("SL_check", SL_check);
            SL_Submit.Add("sub_barcode", SL_barcode);
			SL_Submit.Add("user_id", _userInfo != null ? _userInfo.UserID.ToString() : "1"); 
			SL_Submit.Add("Par2_info", SL_parametersinfo);
			SL_Submit.Add("Par3_Dialog", configDialogParames);

            SortedList sl_rec009= CnasHCSWorkflowInterface01.GetWorkflowParametersValue(1001,1001,SL_Submit, null, null);
            int intrec01 = int.Parse(sl_rec009["rec_result"].ToString());
            if (intrec01 == 0)
            {
				DoUpRFIDData(SL_barcode);
                this.Close();
            }else
            {
                string strrec = "";
                if (sl_rec009["rec_data01"] != null) strrec = sl_rec009["rec_data01"].ToString();
                if (sl_rec009["rec_data02"] != null) strrec = strrec+sl_rec009["rec_data02"].ToString();

                mlab_info.Text = intrec01.ToString() + "-" + strrec;
            }
        }

        private void showbarcode()
        {
            if (SL_checkbarcode != null && SL_checkbarcode.Count > 0 && SL_barcode.Count>0)
            {
                string str_ok = "", str_tobe = "";
                for (int i = 0; i < SL_checkbarcode.Count; i++)
                {
                    string str_code01 = SL_checkbarcode.GetKey(i).ToString();
                    int int_log = -1;
                    for (int j = 0; j < SL_barcode.Count; j++)
                    {
                        string str_code02 = SL_barcode.GetKey(j).ToString().Trim();
                        str_code02 = str_code02.Substring(0, 3);
                        if(str_code01==str_code02)
                        {
                            int_log=0;
                            break;
                        }
                    }

                    if(int_log==0)
                    {
                        str_ok = str_ok + str_code01 + ";";
                    }else
                    {
                        str_tobe = str_tobe + str_code01 + ";";
                    }
                }

                mlab_current.Text = str_ok;
            }
        }

		private void OnRowSelectionChanged(object sender, EventArgs e)
		{
			DataGridView dataGrid = sender as DataGridView;
			if (dataGrid != null && dataGrid.SelectedRows != null && dataGrid.SelectedRows.Count > 0)
			{
				string barCode = Convert.ToString(dataGrid.SelectedRows[0].Cells["barcode"].Value);
				if (!string.IsNullOrEmpty(barCode))
				{
					showBCCdata(barCode);
				}
			}

			SetContextMenu();
		}

		private void SetContextMenu()
		{
			try
			{
				if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 &&
					dgv_01.Columns.Contains("barcode"))
				{
					InitConfigMenu(dgv_01ContextMenu);
					string barCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();

					dgv_01ContextMenu.Items["manualHandleBtn"].Visible = barCode.StartsWith("BCC") || barCode.StartsWith("BCU");
					foreach (ToolStripMenuItem item in dgv_01ContextMenu.Items)
					{
						if (item.Tag != null && item.Tag is Dictionary<string, string>)
						{
							Dictionary<string, string> operation = item.Tag as Dictionary<string, string>;
							string opObjectType = operation.FirstOrDefault(p => p.Key == "op_objectType").Value;
							string barCodeType = null;
							if (!string.IsNullOrEmpty(barCode) && barCode.Length > 12)
							{
								if (BarCodeHelper.IsOrderSet(barCode))
								{
									barCodeType = barCode.Substring(0, 5);
								}
								else
								{
									barCodeType = barCode.Substring(0,3);
								}
							}
							if (string.IsNullOrEmpty(opObjectType) || opObjectType.Contains(string.Format("{0},", barCodeType)))
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
			catch (Exception)
			{
			}
		}

		private void OnScanBarCodeFormClosed(object sender, FormClosedEventArgs e)
		{
			_scannerHook.Stop();
		}

		private void OnHandTsmClick(object sender, EventArgs e)
		{
			if (dgv_01 != null && dgv_01.SelectedRows != null &&
				dgv_01.Columns.Contains("barcode"))
			{
				string barCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
				string bccCode = string.Empty;
				if (barCode.Contains("BCC"))
				{
					bccCode = barCode.Substring(barCode.IndexOf("BCC"), 13);
					KeyValuePair<string, string> pdItem = _scanBarCodes.First(item => item.Value == "BCV");
					string pdCode = pdItem.Key.Substring(9, 4);
					WorkflowArithmeticClass wfLogic = CnasHCSWorkflowInterface01 as WorkflowArithmeticClass;
					if (!BarCodeHelper.IsTempSet(bccCode) || (wfLogic!= null && wfLogic.NoTempManual_wf.Contains(pdCode + ",")))
					{
						if (pdItem.Key.Length > 12)
						{
							HCSWF_procedure_manual menuSelectDialog = new HCSWF_procedure_manual(pdCode, bccCode, CnasHCSWorkflowInterface01);
							if (menuSelectDialog.Rec_data > -1)
							{
								menuSelectDialog.ShowDialog();
								if (menuSelectDialog.Rec_data == 0)
								{
									dgv_01.Rows.Remove(dgv_01.SelectedRows[0]);
									_scanBarCodes.Remove(barCode);
								}
							}
							else
							{
								MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("nomanualwf", EnumPromptMessage.warning, new string[] { pdItem.Key.Substring(9, 4) }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
								menuSelectDialog.Close();
							}
						}
					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notTempManualWF", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("secdealset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void InitConfigMenu(MetroContextMenu contextMenu)
		{
			try
			{
				if (Operations == null)
				{
					string bcvCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
					if (!string.IsNullOrEmpty(bcvCode) && bcvCode.Length==13)
						Operations = ProcedureData.Instance.GetPdOperations(bcvCode.Substring(9,4));
				}
				if (Operations != null)
				{
					foreach (Dictionary<string, string> item in Operations)
					{
						string name = item.FirstOrDefault(p => p.Key == "id").Value;
						string text = item.FirstOrDefault(p => p.Key == "op_name").Value;
						string isContextmenu = item.FirstOrDefault(p => p.Key == "is_contextmenu").Value;
						if (!contextMenu.Items.ContainsKey(name) && isContextmenu.Equals("1"))
						{
							ToolStripMenuItem menu = new ToolStripMenuItem() { Name = name, Text = text, Tag =item  };
							menu.Click += OnConfigProcedureOperationClick;
							contextMenu.Items.Add(menu);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnConfigProcedureOperationClick(object sender, EventArgs e)
		{
			ToolStripMenuItem menuBtn = sender as ToolStripMenuItem;
			if (menuBtn != null && menuBtn.Tag != null && menuBtn.Tag is Dictionary<string, string>)
			{
				Dictionary<string, string> operation = menuBtn.Tag as Dictionary<string, string>;
				string functionName = operation.FirstOrDefault(p => p.Key == "function_name").Value;
				try
				{
					if (!string.IsNullOrEmpty(functionName))
					{
						MethodInfo methodInfo = GetType().GetMethod(functionName);
						if (methodInfo != null)
							methodInfo.Invoke(this, null);
					}
				}
				catch (Exception)
				{
				}
				barCodeTxt.Focus();
				if (dgv_01.SelectedRows!= null && dgv_01.SelectedRows.Count > 0)
				{
					string barCode = Convert.ToString(dgv_01.SelectedRows[0].Cells["barcode"].Value);
					if (barCode.Length >= 13)
					{
						barCodeTxt.Text = barCode.Substring(0,13);
					}
				}
			}
		}


		private void OnShowSetDetails(object sender, EventArgs e)
		{
			if (dgv_01.SelectedRows != null &&
				  dgv_01.Columns.Contains("barcode"))
			{
				string barCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
				string batchNum = dgv_01.SelectedRows[0].Tag != null ? dgv_01.SelectedRows[0].Tag.ToString() : string.Empty;
				if (barCode.Contains("BCC"))
				{
					string bccCode = barCode.Substring(barCode.IndexOf("BCC"), 13);
					if (!BarCodeHelper.IsOrderSet(bccCode) && !BarCodeHelper.IsSpecialSet(bccCode))
					{
						SortedList parameters = new SortedList();
						parameters.Add(bccCode, bccCode.Substring(0,3));
						foreach (KeyValuePair<string,string> item in _scanBarCodes)
						{
							if (item.Value == "BCB"|| item.Value=="BCV")
								parameters.Add(item.Key, item.Value);
						}

						HCSWF_set_detail modifyDialog = new HCSWF_set_detail(parameters);
						modifyDialog.ShowDialog();
					}
				}
			}
		}

		private void OnBarCodeTbxKeyPress(object sender, KeyPressEventArgs e)
		{
			if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
			{
				e.KeyChar = (char)((int)e.KeyChar - 32);
			}
		}

		/// <summary>
		/// 插入rfid log
		/// </summary>
		private void DoUpRFIDData(SortedList bccCondition)
		{
			try
			{
				if (UpRfidData != null && UpRfidData.Count > 0 && bccCondition != null&&bccCondition.Count>0)
				{
					foreach (object item in bccCondition.Keys)
					{
						string code = Convert.ToString(item);
						int bccIndex = code.IndexOf("BCC");
						int bcuIndex = code.IndexOf("BCU");
						if(bccIndex>-1)
						{
							string bccCode = code.Substring(bccIndex, 13);
							object tempObj = UpRfidData[bccCode];
							if (tempObj != null && tempObj is SortedList)
							{
								SortedList outCondition = (SortedList)tempObj;
								if (outCondition.Count == 2)
								{
									string temp_sql = Convert.ToString(outCondition[1]);
									object contionObj = outCondition[2];
									if (!string.IsNullOrEmpty(temp_sql) && contionObj is SortedList)
									{
										SortedList condition = (SortedList)contionObj;
										if (condition != null && condition.Count > 0)
										{
											if (bcuIndex > -1)
											{
												string bcuCode = code.Substring(bcuIndex, 13);
												for (int j = 1; j < condition.Count + 1; j++)
												{
													object par_contionObj = condition[j];
													if (par_contionObj != null && par_contionObj is SortedList)
													{
														SortedList par_condition = (SortedList)par_contionObj;
														if (par_condition != null && par_condition.Count == 8)
														{
															par_condition[8] = bcuCode;
														}
													}
												}
											}
											CnasRemotCall remoteClient = new CnasRemotCall();
											string testSql = remoteClient.RemotInterface.CheckUPDataList(temp_sql, condition);
											int result = remoteClient.RemotInterface.UPDataList(temp_sql, condition);
										}
									}
								}
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				Logger.Info(ex.StackTrace);
			}
		}

		private void OnFormSizeChanged(object sender, EventArgs e)
		{
			pic_data.CalcualteSize();
			barCodeTxt.Focus();
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code='IsShowRFIDDialog'");
			if (array != null && array.Length > 0)
			{
				if (Convert.ToString(array[0]["value_code"]).Equals("1"))
				{
					isOpenRfidDialog = true;
				}
			}

			pic_data.CalcualteSize();
		}

		#region contextMenu

		public void AddSetMessage()
		{
			if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count == 1)
			{
				if (dgv_01.Columns.Contains("barcode"))
				{
					string setBarCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
					if (setBarCode.Contains("BCC"))
					{
						string bccCode = setBarCode.Substring(setBarCode.IndexOf("BCC"), 13);
						string bcvCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
						if (!string.IsNullOrEmpty(bcvCode) && bcvCode.Length == 13)
						{
							HCSSM_set_message_new setMessageDialog = new HCSSM_set_message_new(1, bcvCode.Substring(9, 4));
							setMessageDialog.PackageBarCode = bccCode;
							setMessageDialog.ViewData = setMessageDialog.ViewData ?? new SortedList();
							if (setMessageDialog.ViewData.Contains("UserInfo"))
								setMessageDialog.ViewData["UserInfo"] = _userInfo;
							else
								setMessageDialog.ViewData.Add("UserInfo", _userInfo);
							setMessageDialog.ShowDialog();
						}
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public void ShowSetPackDetail()
		{
			if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count == 1)
			{
				if (dgv_01.Columns.Contains("barcode") &&
					dgv_01.SelectedRows[0].Cells["barcode"] != null)
				{
					string code = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
					string bccCode = code.Contains("BCC") ? code.Substring(code.IndexOf("BCC"), 13) : string.Empty;
					if (code.Length > 3 && !string.IsNullOrEmpty(bccCode) && !BarCodeHelper.IsOrderSet(bccCode))
					{
						SortedList condition = new SortedList();
						condition.Add(BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes), "BCV");
						condition.Add(bccCode, bccCode.Substring(0, 3));
						HCSWF_set_detail detail = new HCSWF_set_detail(condition);
						detail.ShowDialog();
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public void AddQuaniltyData()
		{
			string bcvCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
			if (!string.IsNullOrEmpty(bcvCode) && bcvCode.Length == 13)
			{
				SortedList setBarCodes = new SortedList();
				string areaNum = "2";
				string pdCode = bcvCode.Substring(9, 4);
				
				Dictionary<string, string> procedureInfo = ProcedureData.Instance.GetProcedureData(pdCode);

				if (procedureInfo != null && procedureInfo.Count > 0)
				{
					if (procedureInfo.ContainsKey("pd_Type"))
					{
						areaNum = procedureInfo["pd_Type"];
					}
				}
				Dictionary<string, string> data = new Dictionary<string, string>();
				HCSSM_statistics_quality_new qualityDialog = new HCSSM_statistics_quality_new();
				foreach (DataGridViewRow row in dgv_01.Rows)
				{
					string barCode = row.Cells["barcode"].Value.ToString();
					if (barCode.StartsWith("BCZ"))
					{
						data.Add("DevName", row.Cells["name"].Value.ToString());
						data.Add("DevId", row.Cells["objectId"].Value.ToString());
						qualityDialog.ErrorType = 2;
					}
					else if (barCode.StartsWith("BCW"))
					{
						data.Add("DevName", row.Cells["name"].Value.ToString());
						data.Add("DevId", row.Cells["objectId"].Value.ToString());
						qualityDialog.ErrorType = 1;
					}
					else if (barCode.StartsWith("BCC"))
					{
						if (row.Selected)
						{
							data.Add("SetName", row.Cells["name"].Value.ToString());
							data.Add("SetCode", barCode);
							data.Add("SetId", row.Cells["objectId"].Value.ToString());
						}
					}
				}
				qualityDialog.Data = data;
				qualityDialog.Area = areaNum;
				qualityDialog.ShowDialog();
			}
		}

		public void ModifyOrder()
		{
			if (dgv_01.SelectedRows != null &&
				 dgv_01.Columns.Contains("barcode"))
			{
				string barCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
				string batchNum = dgv_01.SelectedRows[0].Tag != null ? dgv_01.SelectedRows[0].Tag.ToString() : string.Empty;
				if (barCode.Contains("BCC") && !string.IsNullOrEmpty(batchNum))
				{
					string bccCode = barCode.Substring(barCode.IndexOf("BCC"), 13);
					if (BarCodeHelper.IsOrderSet(bccCode))
					{
						HCSSM_order_new_order_detail modifyDialog = new HCSSM_order_new_order_detail(bccCode, batchNum, BarCodeHelper.IsOrderOutSet(bccCode));
						modifyDialog.Mode = 3;
						modifyDialog.ShowDialog();
						showBCCdata(bccCode);
					}
				}
			}
		}

		public void ModifySpecialSetInstruments()
		{
			if (dgv_01.SelectedRows != null &&
				 dgv_01.Columns.Contains("barcode"))
			{
				string barCode = dgv_01.SelectedRows[0].Cells["barcode"].Value.ToString();
				if (barCode.Contains("BCC"))
				{
					string bccCode = barCode.Substring(barCode.IndexOf("BCC"), 13);
					if ((BarCodeHelper.IsSpecialSet(bccCode)))
					{
						HCSWF_set_instrument_modify modifyDialog = new HCSWF_set_instrument_modify(bccCode);
						modifyDialog.ShowDialog();
						showBCCdata(bccCode);
					}
				}
			}
		}

		public void AddOrders()
		{
			string bcvCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
			
			if (!string.IsNullOrEmpty(bcvCode) && bcvCode.Length == 13)
			{
				string pdCode = bcvCode.Substring(9, 4);
				//string bcpCode = BarCodeHelper.GetBarCodeByType("BCP", _scanBarCodes);
				//WorkflowArithmeticClass wfLogic = CnasHCSWorkflowInterface01 as WorkflowArithmeticClass;
				//
				//
				//
				//if (string.IsNullOrEmpty(bcpCode)&& wfLogic != null && wfLogic.Add_washing_count.Contains(string.Format("{0},", pdCode)))
				//{
				//	MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("scanbcp", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//	return;
				//}
				HCSWF_order_choose orderChoose = new HCSWF_order_choose(pdCode);
				orderChoose.ShowDialog();
				if (orderChoose.SelectItems != null)
				{
					for (int i = 0; i < orderChoose.SelectItems.Count; i++)
					{
						DataRow item = orderChoose.SelectItems[i] as DataRow;
						bool isExist = false;
						foreach (DataGridViewRow row in dgv_01.Rows)
						{
							if (row.Cells["barcode"].Value != null && item["bar_code"] != null
								&& row.Cells["barcode"].Value.ToString() == item["bar_code"].ToString())
							{
								isExist = true;
								break;
							}
						}
						if (!isExist)
						{
							string barCode = item["bar_code"].ToString();
							setbarcode(barCode);
							//Dictionary<string, dynamic> checkCountResult = CheckBarCodeCount(barCode, _scanBarCodes, _scanParams);
							//int resultInt = checkCountResult["result_code"];
							//
							//if (resultInt <=3 )
							//{
							//	addtodgv(barCode, item["ca_name"].ToString(), item["id"].ToString(), item["batch"].ToString());
							//	if (!_scanBarCodes.ContainsKey(barCode))
							//	{
							//		_scanBarCodes.Add(barCode, barCode.Substring(0, 3));
							//	}
							//}
						}
					}
					dgv_01.ClearSelection();
					dgv_01.Rows[dgv_01.RowCount - 1].Selected = true;
				}
			}
		}

		#endregion

		private void OnScanCodeFormLoaded(object sender, EventArgs e)
		{
			Win32.ReleaseCapture();
			Win32.SendMessage(this.Handle, 274, Win32.SC_MAXIMIZE, 0);
		}

	}
}
