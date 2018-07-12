using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasWorkflowArithmetic;
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
	public partial class HCSWF_dialog_container : BaseForm
	{
		private const string _okBarCode = "BCXP910000001";
		private const string _closeBarCode = "BCXP910000002";
		private SortedList _sl_Check = new SortedList();
		private SortedList _outputParameters = new SortedList();
		private int _dialogResultStatus = 0;
		private string _pdcode;
		private SortedList _sL_parametertmp02=new SortedList();
		private DataTable _dtpartvalue=new DataTable();
		private SortedList _sL_parametersinfo = new SortedList();

		private SortedList _outputParametersAdd = new SortedList();
		private ControlViewBase _workFlowView = null;
		public List<Dictionary<string, string>> Operations { get; set; }

		/// <summary>
		/// 用于设置cfm关闭状态
		/// </summary>
		/// 1--关闭窗口或确认窗口失败。
		/// 2--确认窗口成功。
		/// 3--窗口中没有要处理的workset。 (关闭HCSSM_scan_barcode窗口.)
		public int DialogResultStatus
		{
			get
			{
				return _dialogResultStatus;
			}
			set
			{
				if (value != _dialogResultStatus)
					_dialogResultStatus = value;
			}
		}

		public SortedList OutputParameters
		{
			get
			{
				return _outputParameters;
			}
			set
			{
				if (value != _outputParameters)
					_outputParameters = value;
			}
		}
		public HCSWF_dialog_container()
		{
			InitializeComponent();
		}


		public HCSWF_dialog_container(SortedList scanCodes)
			: this(scanCodes, null, null,"",null,null,null)
		{
		}

		public HCSWF_dialog_container(SortedList scanCodes, SortedList sl_Check, CnasHCSWorkflowInterface workflowServer, string pd_code, SortedList sL_parametertmp02, DataTable dtpartvalue, SortedList sL_parametersinfo)
			: base(scanCodes)
		
		{
			_sl_Check = sl_Check;
			_sL_parametertmp02 = sL_parametertmp02;
			_pdcode = pd_code;
			_sL_parametersinfo = sL_parametersinfo;
			_dtpartvalue = dtpartvalue;
			Logger = Logger?? LogManager.GetLogger("CnasWNSClient");

			InitializeComponent();
			ControlViewBase viewBase = WorkFlowDialogGenerator.Instance.GeneratorWFDialog(PdCode);

			if (viewBase != null)
			{
				_workFlowView = viewBase;
				DialogResultStatus = viewBase.IsShown ? 1 : 0;
				_workFlowView.Sl_check = this._sl_Check;
				_workFlowView.Dock = DockStyle.Fill;
				infoPanel.Controls.Add(viewBase);
				infoPanel.SetRow(viewBase, 0);
				_workFlowView.PdCode = PdCode;
				_workFlowView.ScanBarCodes = ScanBarCodes;
				_workFlowView.WorkflowServer = workflowServer as WorkflowArithmeticClass;
				if (ViewData.ContainsKey("UserInfo") && ViewData["UserInfo"] is UserBase)
					viewBase.UserInfo = ViewData["UserInfo"] as UserBase;
				else
				{
					UserBase userInfo = UserBaseHelper.GetUserByBarCode(BarCodeHelper.GetBarCodeByType("BCB", ScanBarCodes));
					if (userInfo != null)
					{
						ViewData.Add("UserInfo", userInfo);
						viewBase.UserInfo = userInfo;
					}
					else
					{
						Logger.Error(string.Format("Can not get user info. User barCode:{0}", BarCodeHelper.GetBarCodeByType("BCB", ScanBarCodes)));
					}
				}
				MinimumSize = new Size((int)(_workFlowView.Width + mainPanel.ColumnStyles[1].Width + 100),
					viewBase.Height + 180);
			}
			else
			{
				DialogResultStatus = 0;
			}
			confirmBtn.Height = buttonGroup.ItemHeight - 3;
			buttonPanel.Height = confirmBtn.Margin.Top + confirmBtn.Margin.Bottom + confirmBtn.Height * 2 +
						  cancelBtn.Margin.Top + cancelBtn.Margin.Bottom;
			cancelBtn.Height = confirmBtn.Height;
			confirmBtn.BackgroundImage = BarCodeHelper.GetBarcodeImage(_okBarCode, "确  认", confirmBtn.Width, confirmBtn.Height);
			cancelBtn.BackgroundImage = BarCodeHelper.GetBarcodeImage(_closeBarCode, "关  闭", cancelBtn.Width, cancelBtn.Height);
			
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			Dictionary<string, string> procedureInfo = ProcedureData.Instance.GetProcedureData(PdCode);
			if (procedureInfo != null && procedureInfo.Count > 0)
			{
				if (procedureInfo.ContainsKey("pd_name"))
					this.Text = procedureInfo["pd_name"];
				if (procedureInfo.ContainsKey("pd_description"))
					infoGroup.Text = procedureInfo["pd_description"];
			}
			if (Operations == null)
			{
				Operations = ProcedureData.Instance.GetPdOperations(PdCode);
			}
			foreach (Dictionary<string, string> item in Operations)
			{
				buttonGroup.Items.Add(item);
			}
			SetContextMenuForDataGrid();
			BarCodeHolder.BarCodeEvent += OnBarCodeEvent;
		}  

		public void SetContextMenuForDataGrid()
		{
			if (_workFlowView != null)
			{
				DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(_workFlowView, "setDataGrid");
				if (setDataGrid != null)
				{
					setDataGrid.ContextMenuStrip = setDataGridContextMenu;
				}
			}
		}

		void OnBarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			resultLbl.Text = HandleBarCode(matchBarCode);
		}

		private string HandleBarCode(string matchBarCode)
		{
			if (_workFlowView != null && (_workFlowView.HasManualHandle
				|| (matchBarCode.StartsWith("BCB") || matchBarCode.StartsWith("BCC")
				|| matchBarCode.StartsWith("BCU"))))
				return _workFlowView.HandleScanBarCode(matchBarCode);
			else if (matchBarCode == _okBarCode)
			{
				_validationResullt = string.Empty;
				OnConfirmBtnClick(null, null);
				_validationResullt = string.IsNullOrEmpty(_validationResullt) ? PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning) : _validationResullt;
				return _validationResullt;
			}
			else if (matchBarCode == _closeBarCode)
			{
				OnCancelBtnClick(null, null);
				return PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning);
			}
			else if (matchBarCode.StartsWith("BCX"))
			{
				if (buttonGroup != null)
				{
					bool isFind = false;
					Dictionary<string, string> operation = null;
					foreach (var item in buttonGroup.Items)
					{
						operation = item as Dictionary<string, string>;
						if (operation != null && operation.ContainsKey("op_barCode") &&
							operation["op_barCode"] == matchBarCode && operation.ContainsKey("function_name"))
						{
							isFind = true;
							break;
						}
					}
					if (isFind && _canTriggerNext)
					{
						_canTriggerNext = false;
						this.Invoke(new Action(() => {
							BarCodeHolder.Stop();
							if (_workFlowView != null)
							{
								MethodInfo methodInfo = _workFlowView.GetType().GetMethod(operation["function_name"]);
								if (methodInfo != null)
								{
									methodInfo.Invoke(_workFlowView, null);
								}
							}
							BarCodeHolder.Start(false);
							_canTriggerNext = true;
						}));
					}
				}
				return PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning);
			}
			return PromptMessageXmlHelper.Instance.GetPromptMessage("scanpass", EnumPromptMessage.warning);
		}
		private bool _canTriggerNext = true;

		public void GetOptions(string pdCode)
		{
			SortedList condition = new SortedList();
			condition.Add(1, pdCode);
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-ca-operation-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-ca-operation-sec001", condition);
			if (data != null)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					DataRow row = data.Rows[i] as DataRow;
					Dictionary<string, string> operation = new Dictionary<string, string>();
					if (row["id"] != null) operation.Add("id", row["id"].ToString());
					if (row["op_name"] != null) operation.Add("op_name", row["op_name"].ToString());
					if (row["op_brietcode"] != null) operation.Add("op_brietcode", row["op_brietcode"].ToString());
					if (row["function_name"] != null) operation.Add("function_name", row["function_name"].ToString());
					if (row["state"] != null) operation.Add("state", row["state"].ToString());
					if (row["op_ico"] != null) operation.Add("op_ico", row["op_ico"].ToString());
					if (row["sort_id"] != null) operation.Add("sort_id", row["sort_id"].ToString());
					if (row["op_barCode"] != null) operation.Add("op_barCode", row["op_barCode"].ToString());

					buttonGroup.Items.Add(operation);
				}
			}
		}

		private void OnButtonGroupMouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				ListBox buttonGroup = sender as ListBox;
				if (buttonGroup != null)
				{
					int index = buttonGroup.IndexFromPoint(e.X, e.Y);
					buttonGroup.SelectedIndex = index;
					if ( buttonGroup.SelectedIndex >= 0)
					{
						Dictionary<string, string> operation = buttonGroup.Items[buttonGroup.SelectedIndex] as Dictionary<string, string>;

						if (_workFlowView != null && operation != null)
						{
							MethodInfo methodInfo = _workFlowView.GetType().GetMethod(operation["function_name"]);
							if (methodInfo != null)
								methodInfo.Invoke(_workFlowView, null);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("OnButtonGroupMouseClick", ex.Message);
			}
		}

		private void OnButtonGroupDrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox buttonGroup = sender as ListBox;
			if (buttonGroup != null && buttonGroup.Items != null)
			{
				if (buttonGroup.Items.Count > 0)
				{
					Dictionary<string, string> item = buttonGroup.Items[e.Index] as Dictionary<string, string>;
					if (item != null)
					{
						Rectangle bound = e.Bounds;

						Rectangle imageBound = new Rectangle(bound.X + buttonGroup.Margin.Horizontal-1,
													  e.Bounds.Y,
													  buttonGroup.Width, buttonGroup.ItemHeight-3);

						//if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
						//{
						//	e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
						//}
						//else
						//{
						//	e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
						//}
						e.Graphics.FillRectangle(Brushes.White, e.Bounds);
						e.Graphics.DrawLine(Pens.DarkGray, bound.X, bound.Y, bound.X + bound.Width, bound.Y);
						//Rectangle titleBounds = new Rectangle(bound.X + buttonGroup.Margin.Horizontal,
												//  e.Bounds.Y + buttonGroup.Margin.Top,
												//  e.Bounds.Width - buttonGroup.Margin.Right - buttonGroup.Margin.Horizontal,
												//  (int)e.Font.GetHeight() + 2);

						if (item.ContainsKey("op_barCode") && item.ContainsKey("op_name"))
						{
							Image itemImage = BarCodeHelper.GetBarcodeImage(item["op_barCode"], item["op_name"], imageBound.Width, imageBound.Height);
							e.Graphics.DrawImage(itemImage, imageBound);
							//e.Graphics.DrawString(item["op_name"], e.Font, Brushes.Black, titleBounds);
						}
						else if (item.ContainsKey("op_ico"))
						{

						}

						e.DrawFocusRectangle();
					}
				}
			}
		}

		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			DialogResultStatus = 1;
			Close();
		}
		private string _validationResullt = string.Empty;

		private void OnConfirmBtnClick(object sender, EventArgs e)
		
		{
			if (_workFlowView != null)
			{
				string validationResult = _workFlowView.ValidateData();
				if (!string.IsNullOrEmpty(validationResult))
				{
					_validationResullt = validationResult;
					//MessageBox.Show(validationResult, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				if (_workFlowView.IsCfmCloseDialog == 2)
					return;
				Dictionary<string, string> parameterResult = _workFlowView.SetViewParameters();
				ScanBarCodes = _workFlowView.ScanBarCodes;
				OutputParameters = _workFlowView.OutputParameters;

				//GetDialogGridParameters();

				DialogResultStatus = 2;
				if (_sL_parametertmp02.Count > 0 && _sL_parametersinfo.Count == 0 && 
					parameterResult.ContainsKey("ShowParameterUI") && Boolean.Parse(parameterResult["ShowParameterUI"]))
				{
					BarCodeHolder.Stop();
					HCSWF_parameters_select HCSWF_parameters_select01 = new HCSWF_parameters_select(_pdcode, _sL_parametertmp02, _dtpartvalue);
					if (HCSWF_parameters_select01.DialogResultStatus < 3)
					{
						HCSWF_parameters_select01.ShowDialog();
						DialogResultStatus = HCSWF_parameters_select01.DialogResultStatus;
						BarCodeHolder.Start(false);
						//获取parameter_02参数的交互值
						if (HCSWF_parameters_select01.Int_rec > -1)
						{
							_sL_parametertmp02 = HCSWF_parameters_select01.SL_returnparametersvalue;
							_sL_parametersinfo = HCSWF_parameters_select01.SL_returnparametersinfo;

							if (OutputParameters != null && !OutputParameters.ContainsKey("pd_par2"))
							{
								OutputParameters.Add("pd_par2", _sL_parametertmp02);
							}
							if (OutputParameters != null && !OutputParameters.ContainsKey("Par2_info"))
							{
								OutputParameters.Add("Par2_info", _sL_parametersinfo);
							}
							Close();
						}
					}
					else
					{
						Close();
					}
				}
				else
				{
					this.Close();
				}

			}
			else
			{
				DialogResultStatus = 2;
				Close();
			}
		}

		private void GetDialogGridParameters()
		{
			if (_workFlowView != null)
			{
				DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(_workFlowView, "setDataGrid") as DataGridView;
				if (setDataGrid != null && setDataGrid.Rows.Count > 0 && setDataGrid.Columns.Contains("setBarCodeCol")
					&& _workFlowView.WorkflowServer != null && !CnasUtilityTools.IsContains(_workFlowView.WorkflowServer.Unload_container_wf, PdCode))
				{
					SortedList bccCodeList = new SortedList();
					for (int i = 0; i < setDataGrid.Rows.Count; i++)
					{
						DataGridViewRow dataRow = setDataGrid.Rows[i];
						DataRow item = dataRow.Tag as DataRow;
						string bccbarCode = Convert.ToString(dataRow.Cells["setBarCodeCol"].Value);
						string bccSetName = Convert.ToString(dataRow.Cells["setNameCol"].Value);
						string bcuCode = item.Table.Columns.Contains("BCU_Code") ? Convert.ToString(item["BCU_Code"]) : string.Empty;
						string key = string.IsNullOrEmpty(bcuCode) ? bccbarCode : CnasUtilityTools.ConcatTwoString(bcuCode,bccbarCode);
						if (!string.IsNullOrEmpty(key))
						{
							if (!bccCodeList.ContainsKey(key))
								bccCodeList.Add(key, dataRow.Tag);
						}
					}
					if (bccCodeList != null && bccCodeList.Count > 0)
					{
						if (OutputParameters.ContainsKey("DialogGridParamters"))
							OutputParameters["DialogGridParamters"] = bccCodeList;
						else
							OutputParameters.Add("DialogGridParamters", bccCodeList);
					}
				}
			}
		}

		private void OnHandTsmClick(object sender, EventArgs e)
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(_workFlowView, "setDataGrid");
			if (setDataGrid != null && setDataGrid.CurrentRow != null &&
				setDataGrid.Columns.Contains("setBarCodeCol"))
			{
				HCSWF_procedure_manual menuSelectDialog = new HCSWF_procedure_manual(PdCode, setDataGrid.CurrentRow.Cells["setBarCodeCol"].Value.ToString(), _workFlowView.WorkflowServer);
				if (menuSelectDialog.Rec_data > -1)
				{
					menuSelectDialog.ShowDialog();

					if (menuSelectDialog.Rec_data == 0)
					{
						_workFlowView.InitalizeControl();  //ReloadWorkSetData.
						if (setDataGrid.RowCount == 0)
						{
							DialogResultStatus = 3;
							Close();
						}
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("nomanualwf", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					menuSelectDialog.Close();
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("secdealset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		private void onPrintSetBarCode(object sender, EventArgs e)
		
		{
			DataGridView setDataGrid = CnasUtilityTools.FindControl<DataGridView>(_workFlowView, "setDataGrid");
			if (setDataGrid != null && setDataGrid.CurrentRow != null &&
				setDataGrid.Columns.Contains("setBarCodeCol") && setDataGrid.Columns.Contains("setNameCol"))
			{
				DataRow[] barCodeTemplate = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCC'");
				string templateValue = barCodeTemplate[0]["other_code"].ToString().Trim();

				if (templateValue == "")
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				SortedList sltmp = new SortedList();
				sltmp.Add("BarcodeValue", setDataGrid.CurrentRow.Cells["setBarCodeCol"].Value.ToString());
				sltmp.Add("set_name", setDataGrid.CurrentRow.Cells["setNameCol"].Value.ToString());
				Barcode_print Barcode_print01 = new Barcode_print(templateValue, sltmp);
				Barcode_print01.ShowDialog();
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectprintset", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void OnSizeChanged(object sender, EventArgs e)
		{
			infoGroup.Focus();
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			GetDialogGridParameters();
		}
	}
}
