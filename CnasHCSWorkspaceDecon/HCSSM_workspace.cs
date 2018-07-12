using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasHCSSystemUC;
using Cnas.wns.CnasWorkflowUILibrary;
using Cnas.wns.CnasWorkflowUILibrary.Dialog;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


/*
注意事项：
 * 1、全部数据输入检验在：HCSSM_scanbarcode
 * 2、全部数据传入CnasHCSWorkflowInterface，然后得出下一步流程，或者处理错误结果。
*/
namespace Cnas.wns.CnasHCSWorkspaceDecon
{
    public partial class HCSSM_workspace : UserControl
    {
		public ILog Logger = null;
        private DataTable dtpdpart = new DataTable();//HCS-pdparameter-sec04 当前流程的参数集合
        private DataTable dtapppd = new DataTable();//当前工作台的流程
        private DataTable dtpartvalue = new DataTable();//所有参数的值集合
        private DataTable dtallorder = new DataTable();//当前工作台的所有包

        private string App_ID = "1010";
		public string App_pd="";

		public BarCodeHook ScannerHook = null;
		private int _systemChekUrgentTime = 5;

        CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;

		public HCSSM_workspace(string inappid, string formName) : this(inappid)
		{
			this.Text = formName;
		}

		public HCSSM_workspace(string inappid)
        {
			Logger = LogManager.GetLogger("CnasWNSClient");
			LoadConfigSetting();

            App_ID = inappid;
			InitializeComponent();
			HCSSM_system_config_manager configDialog = new HCSSM_system_config_manager();
			configDialog.AppID = this.App_ID;
			configDialog.IsManagerConfigable = false;
			this.tabp_03.Controls.Add(configDialog);
			configDialog.Dock = DockStyle.Fill;
			InitializeButtonImage();
			DoDisplayOrder();
            loadclass();

            //HCS-pdbasepar-sec02：获取当前工作台下所有流程的参数
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            dtpdpart = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec04", null);
            dtpartvalue = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec03", null);
			mtb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString();
			InitializeCustomerCbx();
            //HCS-apppd-sec001
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, App_ID);
            dtapppd = reCnasRemotCall.RemotInterface.SelectData("HCS-apppd-sec002", sttemp02);
            if(dtapppd !=null)
            {
                for(int i=0;i<dtapppd.Rows.Count;i++)
                {
                    App_pd = App_pd + ",'" + dtapppd.Rows[i]["pd_code"].ToString() + "'";
                }
                App_pd = App_pd.Substring(1);
            }
			SetComCostCenterItem();
			SetWorkSetCbxItem();
            GetWorkSets(true);
			ScannerHook = new BarCodeHook();
			ScannerHook.BarCodeEvent += OnWorkSpaceScaned;
			ScannerHook.Start(false);
			SetMonitorEnable(false); 
			Thread thread = new Thread(BackgroundWork);
			thread.IsBackground = true;
			thread.Start();
        }

		private void LoadConfigSetting()
		{
			DataRow[] config = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code ='SystemChekUrgentTime'");
			if (config.Length > 0 && config[0]["value_code"] != null)
			{
				int.TryParse(Convert.ToString(config[0]["value_code"]), out _systemChekUrgentTime);
				if (_systemChekUrgentTime <= 0)
					_systemChekUrgentTime = 5;
			}
		}

		private void InitializeButtonImage()
		{
			mett_01.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mScanCode40", EnumImageType.PNG);
			mett_02.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSetSearch40", EnumImageType.PNG);
			specialPackBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSetSpPack40", EnumImageType.PNG);
			//creatOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "ordermanager", EnumImageType.PNG);
			//sendOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "orderma", EnumImageType.PNG);
			metBcc3OBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mbcc3oManage40", EnumImageType.PNG);
			refreshBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRefresh16", EnumImageType.PNG);
			searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch16", EnumImageType.PNG);

			creatOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderAdd40", EnumImageType.PNG);
			dealOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDoOrder40", EnumImageType.PNG);
			sendOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendOrder40", EnumImageType.PNG);
			searchOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderSearch40", EnumImageType.PNG);

			setManagerBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSetManager40", EnumImageType.PNG);
			setQualityBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "setQuality40", EnumImageType.PNG);
			sendOrderListBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendOrder40", EnumImageType.PNG);

			btnOrderPack.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDoOrder40", EnumImageType.PNG);
		}

		private void DoDisplayOrder()
		{
			dealOrder.Visible = CnasBaseData.SystemVersion > 1 && App_ID == "1030";
			creatOrder.Visible = CnasBaseData.SystemVersion > 1 && (App_ID == "1050" || App_ID == "1010");
			sendOrder.Visible = CnasBaseData.SystemVersion > 1 && (App_ID == "1030" || App_ID == "1050");
			specialPackBtn.Visible = App_ID == "1020";
			metBcc3OBtn.Visible = CnasBaseData.SystemVersion > 1 && (App_ID == "1020" || App_ID == "1050");
			btnOrderPack.Visible = CnasBaseData.SystemVersion > 1 && App_ID == "1020";
			searchOrder.Visible = CnasBaseData.SystemVersion > 1;
		}

		/// <summary>
		/// 更改状态
		/// </summary>
		private void BackgroundWork()
		{
			while(true)
			{
				System.Threading.Tasks.Task.Factory.StartNew(() =>
				{
					//系统根据器械包保有量来自动加急器械包。
					if (CnasHCSWorkflowInterface01 != null)
					{
						CnasHCSWorkflowInterface01.UpUrgent(true);
					}
				});

				System.Threading.Tasks.Task.Factory.StartNew(() =>
				{
					//系统自动提示各区需要处理的订单
					_StartSearchUndone = true;
					SetTiTleText();
				});

				Thread.Sleep(_systemChekUrgentTime*60*1000);
			}
		}

		public void SetMonitorEnable(bool isEnable)
		{
			priortyBtn.N1_number.Enabled = isEnable;
			priortyBtn.N2_number.Enabled = isEnable;
			priortyBtn.N3_number.Enabled = isEnable;
			priortyBtn.N4_number.Enabled = isEnable;
			priortyBtn.N5_number.Enabled = isEnable;
			priortyBtn.N1_info.Enabled = isEnable;
			priortyBtn.N2_info.Enabled = isEnable;
			priortyBtn.N3_info.Enabled = isEnable;
			priortyBtn.N4_info.Enabled = isEnable;
			priortyBtn.N5_info.Enabled = isEnable;
		}

		void OnWorkSpaceScaned(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			
			setBarCodeTxt.Text = string.Empty;
			if (matchBarCode.StartsWith("BCB"))
			{
				UserBase userInfo = UserBaseHelper.GetUserByBarCode(matchBarCode);
				searchdata(userInfo);
			}

			else if (matchBarCode.StartsWith("BCC"))
			{
				//定位到指定包
				dgv_01.ClearSelection();
				setBarCodeTxt.Text = matchBarCode;
				foreach (DataGridViewRow item in dgv_01.Rows)
				{
					if (item.Cells["set_code"] != null
							&& item.Cells["set_code"].Value.ToString() == matchBarCode)
					{
						item.Selected = true;
						//rexxie需要考虑是否直接弹出手动处理
						//tsm_hand_Click(null, null);
						break;
					}
				}
			}
		}

        private void loadclass()
        {
            object result = null;
            Type typeofControl = null;
            Assembly tempAssembly;
            tempAssembly = Assembly.LoadFrom("CnasWorkflowArithmetic.dll");
            typeofControl = tempAssembly.GetType("Cnas.wns.CnasWorkflowArithmetic.WorkflowArithmeticClass");
            result = Activator.CreateInstance(typeofControl);
            CnasHCSWorkflowInterface01 = (CnasHCSWorkflowInterface)result;
        }  

		private void GetWorkSets(bool isReloadMessage = false)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList condition = new SortedList();
            condition.Add(1, App_pd);
			condition.Add(2, CnasBaseData.SystemID);
			string whereSql = GererateSearchCondition();
			condition.Add(3, whereSql);
            string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec008", condition);
            dtallorder = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec008", condition);
            dgv_01.Rows.Clear();
            if (dtallorder==null) return;
			int manualNum = 0;
			int priorty1Num = 0;
			int priorty2Num = 0;
			int priorty3Num = 0;
			foreach (DataRow item in dtallorder.Rows)
			{
				int rowIndex = dgv_01.Rows.Add();
				if (item["id"] != null) dgv_01.Rows[rowIndex].Cells["id"].Value = item["id"].ToString();
				if (item["set_code"] != null) dgv_01.Rows[rowIndex].Cells["set_code"].Value = item["set_code"].ToString();
				if (item["BCU_code"] != null) dgv_01.Rows[rowIndex].Cells["bcuCode"].Value = item["BCU_code"].ToString();
				if (item["wf_code"] != null)
                {
					string strwfcode = item["wf_code"].ToString();
					dgv_01.Rows[rowIndex].Cells["wf_code"].Value = strwfcode + "：" + item["pd_name"];
					dgv_01.Rows[rowIndex].Cells["wf_code_back"].Value = strwfcode;
                }
				if (item["ca_name"] != null) dgv_01.Rows[rowIndex].Cells["ca_name"].Value = item["ca_name"].ToString();
				if (item["run_times"] != null) dgv_01.Rows[rowIndex].Cells["run_times"].Value = item["run_times"];
				if (item["ws_status"] != null) dgv_01.Rows[rowIndex].Cells["status"].Value = item["ws_status"];

				if (item["pa_priorty"] != null) dgv_01.Rows[rowIndex].Cells["setPriortyCol"].Value = item["pa_priorty"].ToString();
				if (Convert.ToString(item["urgent"]) == "1")
				{
					manualNum++;
					dgv_01.Rows[rowIndex].Cells["setPriortyCol"].Value = "手动加急";
					dgv_01.Rows[rowIndex].DefaultCellStyle.BackColor = priortyBtn.N1_number.BackColor;
					dgv_01.Rows[rowIndex].DefaultCellStyle.ForeColor = priortyBtn.N1_number.ForeColor;
					dgv_01.Rows[rowIndex].Cells["sebPriortyCol"].Value = "4";
				}
				else
				{
					if (item["ca_priority"] != null)
					{
						if (item["ca_priority"].ToString() == "1")
						{
							priorty3Num++;
						}
						else if (item["ca_priority"].ToString() == "2")
						{
							priorty2Num++;
							//ChangeRowStyle(row, priortyBtn.N2_number.BackColor, Color.White);
							dgv_01.Rows[rowIndex].DefaultCellStyle.BackColor = priortyBtn.N2_number.BackColor;
						}
						else if (item["ca_priority"].ToString() == "3")
						{
							//ChangeRowStyle(row, priortyBtn.N1_number.BackColor, Color.White);
							dgv_01.Rows[rowIndex].DefaultCellStyle.BackColor = priortyBtn.N1_number.BackColor;
							dgv_01.Rows[rowIndex].DefaultCellStyle.ForeColor = priortyBtn.N1_number.ForeColor;
							priorty1Num++;
						}
					}
					dgv_01.Rows[rowIndex].Cells["sebPriortyCol"].Value = item["ca_priority"].ToString();
				}

				if (!(item["ws_cre_date"] is DBNull))
				{
					dgv_01.Rows[rowIndex].Cells["cre_date"].Value = item["ws_cre_date"];
				}

				if (item["remark"] != null) dgv_01.Rows[rowIndex].Cells["remark"].Value = item["remark"].ToString();
				if (item["cus_name"] != null) dgv_01.Rows[rowIndex].Cells["cu_name"].Value = item["cus_name"].ToString();
				if (item["cost_center_name"] != null) dgv_01.Rows[rowIndex].Cells["cost_ca_name"].Value = item["cost_center_name"].ToString();
				if (item["location_name"] != null) dgv_01.Rows[rowIndex].Cells["setUseLoCol"].Value = item["location_name"].ToString();
			}

			priortyBtn.N1_number.Text = priorty1Num.ToString();
			priortyBtn.N2_number.Text = priorty2Num.ToString();
			priortyBtn.N3_number.Text = priorty3Num.ToString();
			priortyBtn.N4_number.Text = manualNum.ToString();
			priortyBtn.N5_number.Text = dgv_01.RowCount.ToString();
			//if (isReloadMessage && !messageShower.IsBusy)
				//messageShower.RunWorkerAsync();
        }

		private string GererateSearchCondition()
		{
			string whereSql = string.Empty;
			if (!mcb_ordertype.SelectedValue.Equals("-1"))
			{
				whereSql += string.Format(" and ws.status='{0}'", mcb_ordertype.SelectedValue);
			}
			else
			{
				string values = string.Empty;
				foreach (KeyValuePair<string, string> item in mcb_ordertype.Items)
				{
					values += string.Format("'{0}',", item.Key);
				}
				values = values.TrimEnd(',');
				whereSql += string.Format(" and ws.status in ({0}) ", values);
			}

			if ((mcb_customer.SelectedValue != null && !mcb_customer.SelectedValue.Equals("0")) || mcb_customer.SelectedValue == null)
			{
				whereSql += string.Format(" and pa.customer_code='{0}'", (mcb_customer.SelectedValue ?? "0"));

				if (!mcb_cost.SelectedValue.Equals("0"))
				{
					whereSql += " and pa.cost_center='" + mcb_cost.SelectedValue + "'";
				}
			}
			if (!string.IsNullOrEmpty(setBarCodeTxt.Text.Trim()))
			{
				whereSql += " and pa.bar_code like '%" + setBarCodeTxt.Text.Trim() + "%'";
			}
			if (!string.IsNullOrEmpty(setNameTxt.Text.Trim()))
			{
				whereSql += string.Format(" and pa.ca_name like '%{0}%'", setNameTxt.Text.Trim());
			}
			return whereSql;
		}

		/// <summary>
		/// 仅仅设置客户名称
		/// </summary>
		/// <param name="table"></param>
		private void InitializeCustomerCbx()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			if (mcb_customer.Items.Count > 0)
			{
				mcb_customer.DataSource = null;
				mcb_customer.Items.Clear();
			}
			
			string barCode = string.Empty;
			string barCode_name = string.Empty;
			if (CnasBaseData.UserAccessCustomer != null && CnasBaseData.UserAccessCustomer.Rows.Count > 0)
			{
				if (CnasBaseData.UserAccessCustomer.Rows.Count > 1)
				{
					dic.Add("0", "所有");
				}
				for (int i = 0; i < CnasBaseData.UserAccessCustomer.Rows.Count; i++)
				{
					DataRow row = CnasBaseData.UserAccessCustomer.Rows[i];
					string tempBarCode = Convert.ToString(row["bar_code"]);
					string tempBarCode_Name = Convert.ToString(row["cu_name"]);
					if(!tempBarCode.Equals(barCode)&&!tempBarCode_Name.Equals(barCode_name))
					{
						barCode = tempBarCode;
						barCode_name = tempBarCode_Name;
						if(!dic.ContainsKey(barCode))
							dic.Add(tempBarCode,tempBarCode_Name);
					}
				}
			}

			if (dic.Count > 0)
			{
				BindingSource bs = new BindingSource();
				bs.DataSource = dic;
				mcb_customer.DataSource = bs;
				foreach (KeyValuePair<string, string> item in mcb_customer.Items)
				{
					if (item.Key == CnasBaseData.UserBaseInfo.CustomerCode)
					{
						int index = mcb_customer.Items.IndexOf(item);
						mcb_customer.SelectedIndex = index;
						break;
					}
				}
				mcb_customer.SelectedIndex = mcb_customer.SelectedIndex > -1 ? mcb_customer.SelectedIndex : 0;
			}
			mcb_customer.Enabled = dic.Count > 1;
		}

        private void mett_01_Click(object sender, EventArgs e)
        {
			searchdata(CnasBaseData.UserBaseInfo);
			setBarCodeTxt.Focus();
        }
        private void searchdata(UserBase userInfo)
        {
			try
			{
				if (userInfo != null)//indata.StartsWith("BCB"))
				{
					//UserBase userInfo = UserBaseHelper.GetUserByBarCode(indata);
					if (userInfo.UserID > 0)
					{
						this.BeginInvoke(new Action(() =>
						{
							HCSSM_scan_barcode scanCodeDialog = new HCSSM_scan_barcode(CnasHCSWorkflowInterface01, userInfo, dtpdpart, dtapppd, dtpartvalue);
							if (!scanCodeDialog.IsInternalError)
							{
								ScannerHook.Stop();
								scanCodeDialog.ShowDialog();
								ScannerHook.Start(false);
								GetWorkSets();
							}
						}));
					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("nouser", EnumPromptMessage.warning, new string[] { userInfo.Userbcode }),
							"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
			}
        }

        private void HCSSM_workspace_decon_FormClosed(object sender, FormClosedEventArgs e)
        {
			ScannerHook.Stop();
            Application.Exit();
        }

        private void tsm_print_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.CurrentRow == null)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["set_code"].Value != null ?
					dgv_01.CurrentRow.Cells["set_code"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
					dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("P013", codeName);

					string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void tsm_hand_Click(object sender, EventArgs e)
        {
            if(dgv_01.CurrentRow !=null)
            {
                string str_pdcode = dgv_01.CurrentRow.Cells["wf_code_back"].Value.ToString();
				string bccCode = Convert.ToString(dgv_01.CurrentRow.Cells["set_code"].Value);
				string bcuCode = Convert.ToString(dgv_01.CurrentRow.Cells["bcuCode"].Value);
				string setCode = string.IsNullOrEmpty(bcuCode) ? bccCode : CnasUtilityTools.ConcatTwoString(bcuCode, bccCode);

				HCSSM_procedure_manual HCSSM_procedure_manual01 = new HCSSM_procedure_manual(str_pdcode, setCode, CnasHCSWorkflowInterface01);
                if (HCSSM_procedure_manual01.Rec_data > -1)
                {
                    HCSSM_procedure_manual01.ShowDialog();

                    if (HCSSM_procedure_manual01.Rec_data == 0)
                    {
                        GetWorkSets();
                    }
                }else
                {
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notconfigmanWf", EnumPromptMessage.warning, new string[] { str_pdcode }), 
						"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HCSSM_procedure_manual01.Dispose();
                }
            }else
            {
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("secdealset", EnumPromptMessage.warning), 
					"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		private void OnShowMessageDialog(object sender, RunWorkerCompletedEventArgs e)
		{
			//if (!string.IsNullOrEmpty(App_pd))
			//{
			//	HCSSM_set_message_newshow showMessage = new HCSSM_set_message_newshow(App_pd);
			//	showMessage.UserId = CnasBaseData.UserID;
			//	showMessage.GenerateListBoxItem();
			//	if (showMessage.HasSetMessage)
			//		showMessage.ShowDialog();
			//	else
			//		showMessage.Dispose();
			//}
		}

		/// <summary>
		/// 显示包的管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void metroTile1_Click(object sender, EventArgs e)
		{
			CnasRemotCall RemoteClient = new CnasRemotCall();
			string userid = CnasBaseData.UserID;
			SortedList condition = new SortedList();
			condition.Add(1, userid);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-userdata-sec002", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-userdata-sec002", condition);
			if (data != null && data.Rows.Count > 0)
			{
				tableLayoutPanel1.Controls.Clear();
				UserControl child = new HCSSM_set_message_manager(data.Rows[0]["user_bcode"].ToString());
				child.Dock = System.Windows.Forms.DockStyle.Fill;
				tableLayoutPanel1.Controls.Add(child);
				child.Show();
			}
		}

		/// <summary>
		/// 质量管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void met02statistics_manager_Click(object sender, EventArgs e)
		{
			tableLayoutPanel1.Controls.Clear();
			HCSSM_statistics_manager statisticsManager = new HCSSM_statistics_manager(App_ID);
			statisticsManager.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Controls.Add(statisticsManager);
			statisticsManager.Show();
		}

		/// <summary>
		/// 显示BCU打印菜单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mcm_right_Opening(object sender, CancelEventArgs e)
		{
			if (dgv_01.CurrentRow != null)
			{
				//wf_code_back
				DataGridViewRow row = dgv_01.CurrentRow;
				string pd_code = Convert.ToString(row.Cells["wf_code_back"].Value);
				int pd_codeInt = 0;

				if (mcm_right.Items.ContainsKey("tsm_bcuprint"))
					mcm_right.Items["tsm_bcuprint"].Visible = (!string.IsNullOrEmpty(pd_code) && Int32.TryParse(pd_code, out pd_codeInt) 
						&& pd_codeInt > 3020) ? true : false;

				int priortyType = -1;
				int.TryParse(row.Cells["sebPriortyCol"].Value.ToString(), out priortyType);
				if (mcm_right.Items.ContainsKey("tsm_urgent"))
				{
					mcm_right.Items["tsm_urgent"].Visible = priortyType == 1 || priortyType == 4 ? true : false;
					mcm_right.Items["tsm_urgent"].Text = priortyType == 1 ? "加急器械包" : "取消加急器械包";
				}
			}
		}
		/// <summary>
		/// 打印BCU生产条码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsm_bcuprint_Click(object sender, EventArgs e)
		{
			if(dgv_01.CurrentRow!=null)
			{
				DataGridViewRow row = dgv_01.CurrentRow;
				string bcc_code = Convert.ToString(row.Cells["set_code"].Value);
				if(!string.IsNullOrEmpty(bcc_code))
				{
					CnasRemotCall RemoteClient = new CnasRemotCall();
					SortedList condition = new SortedList();
					condition.Add(1, bcc_code);
					string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec006", condition);
					DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec006", condition);
					if (data != null && data.Rows.Count > 0)
					{
						SortedList sl_par01 = new SortedList();
						string BCUCode = Convert.ToString(data.Rows[0]["BCU_code"]);
						string confirmName = Convert.ToString(data.Rows[0]["confirmName"]);
						string userName = Convert.ToString(data.Rows[0]["userName"]);
						DateTime createDate = DateTime.Now;
						DateTime.TryParse(data.Rows[0]["generateDate"].ToString(), out createDate);
						int expireDuration = 7;
						int.TryParse(data.Rows[0]["expiration"].ToString(), out expireDuration);
						sl_par01.Add("BarcodeValue", BCUCode);
						sl_par01.Add("P014", BCUCode);
						sl_par01.Add("P017", createDate.ToString("yyyy-MM-dd"));
						sl_par01.Add("P018", createDate.AddDays(expireDuration).ToString("yyyy-MM-dd"));
						sl_par01.Add("P019", userName);
						sl_par01.Add("P020", confirmName);
						sl_par01.Add("P013", Convert.ToString(data.Rows[0]["set_name"]));
						sl_par01.Add("P016", Convert.ToString(data.Rows[0]["locationName"]));
						string printResult = BarCodeHelper.PrintBarCode(BCUCode, sl_par01);
						if (!string.IsNullOrEmpty(printResult))
							MessageBox.Show(printResult, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

					}
					else
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindBCU", EnumPromptMessage.warning), 
							"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		/// <summary>
		/// 客户名称更改事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mcb_customer_SelectedValueChanged(object sender, EventArgs e)
		{
			SetComCostCenterItem();
		}

		private void SetWorkSetCbxItem()
		{
			mcb_ordertype.Items.Clear();
			DataRow[] workSetTypes = CnasBaseData.SystemBaseData.Select("type_code='HCS-workset-status-type'");
			if (workSetTypes != null && workSetTypes.Count() > 0)
			{
				Dictionary<string, string> dic = new Dictionary<string, string>();
				dic.Add("-1", "所有");
				foreach (DataRow item in workSetTypes)
				{
					string status = Convert.ToString(item["key_code"]);
					string statusDescription = Convert.ToString(item["value_code"]);
					if (!dic.ContainsKey(status) && int.Parse(status) < 5)
						dic.Add(status, statusDescription);
				}
				BindingSource bs = new BindingSource();
				bs.DataSource = dic;
				mcb_ordertype.DataSource = bs;
				if (mcb_ordertype.Items.Count > 1)
					mcb_ordertype.SelectedIndex = 1;
				else
					mcb_ordertype.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 客户编码更改
		/// </summary>
		/// <param name="custbarcode"></param>
		private void SetComCostCenterItem()
		{
			try
			{
				mcb_cost.DataSource = null;
				mcb_cost.Items.Clear();
				string getCustomerValue = Convert.ToString(mcb_customer.SelectedValue);
				Dictionary<string, string> dic = new Dictionary<string, string>();
				dic.Add("0", "所有");
				string sql = "HCS-costcenter-sec006";
				SortedList condtion = new SortedList();
				condtion.Add(1, string.IsNullOrEmpty(getCustomerValue) ? "0" : getCustomerValue);
				if (App_ID == "1050")
				{
					condtion.Add(2, CnasBaseData.UserBaseInfo.UserID);
					sql = "HCS-costcenter-sec005";
				}
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData(sql, condtion);
				DataTable data = remoteCall.RemotInterface.SelectData(sql, condtion);
				if (data != null)
				{
					foreach (DataRow row in data.Rows)
					{
						string barCode = Convert.ToString(row["bar_code"]);
						string name = Convert.ToString(row["ca_name"]);
						if (!dic.ContainsKey(barCode) && !string.IsNullOrEmpty(name))
							dic.Add(barCode, name);
					}

				}

				BindingSource bs = new BindingSource();
				bs.DataSource = dic;
				mcb_cost.DataSource = bs;
				mcb_cost.DisplayMember = "Value";
				mcb_cost.ValueMember = "Key";
				mcb_cost.SelectedIndex = 0;
			}
			catch (Exception)
			{
			}

		}

		/// <summary>
		/// 搜索功能
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void searchBtn_Click(object sender, EventArgs e)
		{
			GetWorkSets(false);
		}

		private void refreshBtn_Click(object sender, EventArgs e)
		{
			if (mcb_ordertype.Items.Count > 1)
				mcb_ordertype.SelectedIndex = 1;
			else
				mcb_ordertype.SelectedIndex = 0;
			if (mcb_cost.Items.Count > 0)
				mcb_cost.SelectedIndex = 0;
			if (mcb_customer.Items.Count > 0)
				mcb_customer.SelectedIndex = 0;
			setBarCodeTxt.Text = string.Empty;
			setNameTxt.Text = string.Empty;
			GetWorkSets();
		}

		private void OnUrgentClick(object sender, EventArgs e)
		{
			if (dgv_01.SelectedRows != null)
			{
				CnasRemotCall RemoteClient = new CnasRemotCall();
				SortedList input = new SortedList();
				int index = 1;
				foreach (DataGridViewRow row in dgv_01.SelectedRows)
				{
					int priortyType = -1;
					int.TryParse(row.Cells["sebPriortyCol"].Value.ToString(), out priortyType);
					SortedList parameters = new SortedList();
					parameters.Add(1, (priortyType == 4 ? 0 : 1));
					parameters.Add(2, row.Cells["set_code"].Value);
					input.Add(index, parameters);
					index++;
				}
				if (input.Count > 0)
				{
					try
					{
						string testSql = RemoteClient.RemotInterface.CheckUPData(1, "HCS-set-up002", input, null);
						int result = RemoteClient.RemotInterface.UPData(1, "HCS-set-up002", input, null);
						if (result > 0)
							GetWorkSets();
					}
					catch (Exception ex)
					{
						Logger.Error("Error happen in UrgentClick:", ex);
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("urgentset", EnumPromptMessage.error), 
							"信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void OnSearchOrderClick(object sender,EventArgs e)
		{
			ScannerHook.Stop();
			HCSSM_order_manager searchOrder = new HCSSM_order_manager(App_ID);
			searchOrder.WorkflowServer = CnasHCSWorkflowInterface01;
			searchOrder.PdData = dtapppd;
			searchOrder.Pdparameters = dtpdpart;
			searchOrder.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}

		private void OnCreatOrderClick(object sender,EventArgs e)
		{
			ScannerHook.Stop();
			HCSSM_order_new_order createOrder = new HCSSM_order_new_order(App_ID);
			createOrder.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}

		private void OnSpecialBtnButtonClick(object sender, EventArgs e)
		{
			this.Invoke(new Action(() =>
			{
				ScannerHook.Stop();
				HCSWF_specialset_pack packing = new HCSWF_specialset_pack(CnasHCSWorkflowInterface01, dtapppd, dtpdpart, this.App_ID);
				packing.ShowDialog();
				ScannerHook.Start(false);
				setBarCodeTxt.Focus();
			}));
		}

		private void OnOrderManagerClick(object sender, EventArgs e)
		{
			ScannerHook.Stop();
			HCSSM_order_undone_manager orderManager = new HCSSM_order_undone_manager(App_ID,CnasHCSWorkflowInterface01);
			//ScannerHook.Stop();
			orderManager.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}

		private void OnSendOrderClick(object sender, EventArgs e)
		{
			ScannerHook.Stop();
			HCSSM_send_order_manager sendorder = new HCSSM_send_order_manager();
			sendorder.App_ID = App_ID;
			//ScannerHook.Stop();
			sendorder.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}

		private void metBcc3OBtn_Click(object sender, EventArgs e)
		{
			ScannerHook.Stop();
			HCSSM_order_forback_manager mforback = new HCSSM_order_forback_manager(App_ID);
			mforback.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}

		private void OnSendOrderListClick(object sender, EventArgs e)
		{
			tableLayoutPanel1.Controls.Clear();
			HCSWF_send_orderList_manager child = new HCSWF_send_orderList_manager();
			child.AppId = this.App_ID;
			child.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Controls.Add(child);
			child.Show();
			setBarCodeTxt.Focus();
		}


		/// <summary>
		/// 包查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mett_02_Click(object sender, EventArgs e)
		{
			try
			{
				ScannerHook.Stop();
				HCSSM_set_search_manager_show searchSet = new HCSSM_set_search_manager_show(App_ID);
				searchSet.ShowDialog();
				ScannerHook.Start(false);
				setBarCodeTxt.Focus();
			}
			catch (Exception)
			{
			}
		}

		private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				GetWorkSets();
			}
		}

		private bool _StartSearchUndone = true;

		private void SetTiTleText()
		{
			try
			{
				//注释为半个小时执行一次
				//while (true)
				//{
					if (_StartSearchUndone)
					{
						_StartSearchUndone = false;
						if (App_ID.Equals("1020") || App_ID.Equals("1030"))//打包区
						{
							string txtSearchOrder = string.Empty;
							string sql = App_ID.Equals("1020") ? "hcs_work_specialset_info-sec007" : "hcs_work_specialset_info-sec010";
							CnasRemotCall RemoteClient = new CnasRemotCall();
							string testSql = RemoteClient.RemotInterface.CheckSelectData(sql, null);
							DataTable table = RemoteClient.RemotInterface.SelectData(sql, null);
							if (table != null && table.Rows.Count > 0)
							{
								string str_set_Count = Convert.ToString(table.Rows[0]["set_count"]).Trim();
								if (str_set_Count.Equals("0"))
								{
									txtSearchOrder = string.Format("订单处理");
								}
								else
								{
									txtSearchOrder = string.Format("订单处理({0}待处理)", str_set_Count);
								}
							}
							else
							{
								txtSearchOrder = string.Format("订单处理");
							}
							this.Invoke(new Action(() =>
							{
								if (App_ID.Equals("1020"))
								{
									btnOrderPack.Text = txtSearchOrder;
								}
								else
								{
									dealOrder.Text = txtSearchOrder;
								}

								_StartSearchUndone = true;
							}));
						}
					}
				//}
			}
			catch
			{

			}
		}

		private void OnUrgentSelectClick(object sender, EventArgs e)
		{
            HCSWF_urgent_set hcsm = new HCSWF_urgent_set();
            hcsm.ShowDialog();
            GetWorkSets();
		}

		/// <summary>
		/// 订单处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOrderPack_Click(object sender, EventArgs e)
		{
			ScannerHook.Stop();
			HCS_packset_all_dealinstrument searchOrder = new HCS_packset_all_dealinstrument();
			searchOrder.WorkflowServer = CnasHCSWorkflowInterface01;
			searchOrder.PdData = dtapppd;
			searchOrder.Pdparameters = dtpdpart;
			searchOrder.ShowDialog();
			ScannerHook.Start(false);
			setBarCodeTxt.Focus();
		}
    }
}
