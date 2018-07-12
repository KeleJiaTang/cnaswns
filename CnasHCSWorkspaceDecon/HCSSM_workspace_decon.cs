using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBaseInterface;
using System.Reflection;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasWorkflowUILibrary;
using log4net;


/*
注意事项：
 * 1、全部数据输入检验在：HCSSM_scanbarcode
 * 2、全部数据传入CnasHCSWorkflowInterface，然后得出下一步流程，或者处理错误结果。
*/


namespace Cnas.wns.CnasHCSWorkspaceDecon
{
	public partial class HCSSM_workspace_decon : MetroForm
	{
		public ILog Logger = null;
		private DataTable dtpdpart = new DataTable();//HCS-pdparameter-sec04 当前流程的参数集合
		private DataTable dtapppd = new DataTable();//当前工作台的流程
		private DataTable dtpartvalue = new DataTable();//所有参数的值集合
		private DataTable dtallorder = new DataTable();//当前工作台的所有包

		private SortedList sl_allpd = new SortedList();

		private string App_ID = "1010", App_pd = "";

		private BarCodeHook _scannerHook = null;

		CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;

		public HCSSM_workspace_decon(string inappid, string formName)
			: this(inappid)
		{
			this.Text = formName;
		}

		public HCSSM_workspace_decon(string inappid)
		{
			Logger = LogManager.GetLogger("CnasWNSClient");
			App_ID = inappid;
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			loadclass();

            //HCS-pdbasepar-sec02：获取当前工作台下所有流程的参数
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList temp05list = new SortedList();
			temp05list.Add(1, CnasBaseData.SystemID);
			dtpdpart = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec05", temp05list);
			//dtpdpart = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec04", null);
            dtpartvalue = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec03", null);
			mtb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString();
            //HCS-apppd-sec001
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, App_ID);
            dtapppd = reCnasRemotCall.RemotInterface.SelectData("HCS-apppd-sec002", sttemp02);
            if(dtapppd !=null)
            {
                for(int i=0;i<dtapppd.Rows.Count;i++)
                {
                    App_pd = App_pd + ",'" + dtapppd.Rows[i]["pd_code"].ToString() + "'";
                    //App_pd = App_pd + "," + dtapppd.Rows[i]["pd_code"].ToString() ;
                    sl_allpd.Add(dtapppd.Rows[i]["pd_code"].ToString(), dtapppd.Rows[i]["pd_name"].ToString());
                }
                App_pd = App_pd.Substring(1);
            }
            load_workorder("0");
            
        }

		void OnWorkSpaceScaned(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			if (matchBarCode.StartsWith("BCB"))
			{
				searchdata(matchBarCode);
			}
			else if (matchBarCode.StartsWith("BCC"))
			{
				//定位到指定包
				foreach (DataGridViewRow item in dgv_01.Rows)
				{
					if (item.Cells["set_code"] != null
							&& item.Cells["set_code"].Value.ToString() == matchBarCode)
					{
						item.Selected = true;
						//rexxie需要考虑是否直接弹出手动处理
						tsm_hand_Click(null, null);
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


		private void load_workorder(string ordertype)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, App_pd);
			string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec001", sttemp01);
			dtallorder = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec001", sttemp01);
			dgv_01.Rows.Clear();
			if (dtallorder == null) return;
			dgv_01.RowCount = dtallorder.Rows.Count;
			for (int i = 0; i < dtallorder.Rows.Count; i++)
			{
				if (dtallorder.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dtallorder.Rows[i]["id"].ToString();
				if (dtallorder.Rows[i]["set_code"] != null) dgv_01.Rows[i].Cells["set_code"].Value = dtallorder.Rows[i]["set_code"].ToString();
				if (dtallorder.Rows[i]["wf_code"] != null)
				{

					string strwfcode = dtallorder.Rows[i]["wf_code"].ToString();
					dgv_01.Rows[i].Cells["wf_code"].Value = strwfcode + "：" + sl_allpd[strwfcode].ToString();
					dgv_01.Rows[i].Cells["wf_code_back"].Value = strwfcode;
				}
				if (dtallorder.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dtallorder.Rows[i]["ca_name"].ToString();
				if (dtallorder.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["run_times"].Value = dtallorder.Rows[i]["run_times"].ToString();
				if (dtallorder.Rows[i]["status"] != null) dgv_01.Rows[i].Cells["status"].Value = dtallorder.Rows[i]["status"].ToString();
				if (dtallorder.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dtallorder.Rows[i]["cre_date"].ToString();
				if (dtallorder.Rows[i]["remark"] != null) dgv_01.Rows[i].Cells["remark"].Value = dtallorder.Rows[i]["remark"].ToString();
			}
			messageShower.RunWorkerAsync();
		}



		private void cmt_main_UserMonitoButtonSelect(object sender, EventArgs e, string infodata)
		{

		}

		private void mett_01_Click(object sender, EventArgs e)
		{
			searchdata(CnasBaseData.UserBaseInfo.Userbcode);
		}
		private void searchdata(string indata)
		{
			//Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, indata, "信息提示");
			if (indata.StartsWith("BCB"))
			{
				UserBase userInfo = UserBaseHelper.GetUserByBarCode(indata);
				if (userInfo != null)
				{
					_scannerHook.Stop();
					HCSSM_scan_barcode HCSSM_scanbarcode01 = new HCSSM_scan_barcode(CnasHCSWorkflowInterface01, userInfo, dtpdpart, dtapppd, dtpartvalue);
					if (!HCSSM_scanbarcode01.IsInternalError)
					{
						HCSSM_scanbarcode01.ShowDialog();
						_scannerHook.Start(false);
						load_workorder("");
					}
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.GetPromptMessage("nouser", EnumPromptMessage.error, new string[] { indata }), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void HCSSM_workspace_decon_FormClosed(object sender, FormClosedEventArgs e)
		{
			_scannerHook.Stop();
			Application.Exit();
		}

		private void tsm_print_Click(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCC'");
			string strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
			if (dgv_01.CurrentRow == null) return;
			string str_code = dgv_01.CurrentRow.Cells["set_code"].Value.ToString();
			string str_name = dgv_01.CurrentRow.Cells["ca_name"].Value.ToString();
			if (strbarcodexml == "")
			{
				Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起！没有设置好流程条形码模版，请联系管理员！！！", "信息提示");
				return;
			}
			SortedList sltmp = new SortedList();
			sltmp.Add("BarcodeValue", str_code);
			sltmp.Add("Value", str_name);
			Barcode_print Barcode_print01 = new Barcode_print(strbarcodexml, sltmp);
			Barcode_print01.ShowDialog();
		}

		private void tsm_hand_Click(object sender, EventArgs e)
		{
			if (dgv_01.CurrentRow != null)
			{
				string str_pdcode = dgv_01.CurrentRow.Cells["wf_code_back"].Value.ToString();
				HCSSM_procedure_manual HCSSM_procedure_manual01 = new HCSSM_procedure_manual(str_pdcode, dgv_01.CurrentRow.Cells["set_code"].Value.ToString(), CnasHCSWorkflowInterface01);
				if (HCSSM_procedure_manual01.Rec_data > -1)
				{
					HCSSM_procedure_manual01.ShowDialog();

					if (HCSSM_procedure_manual01.Rec_data == 0)
					{
						load_workorder("");
					}
				}
				else
				{
					Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "流程【" + str_pdcode + "】没有任何手动处理配置，请联系管理员！！！", "信息提示");
					HCSSM_procedure_manual01.Dispose();
				}
			}
			else
			{
				Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起！请先选择要处理的包！！！", "信息提示");
			}

		}

		private void OnShowMessageDialog(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!string.IsNullOrEmpty(App_pd))
			{
				if (dgv_01.Rows != null && dgv_01.Rows.Count > 0)
				{
					SortedList barCodeList = new SortedList();
					int j = 1;
					for (int i = 0; i < dgv_01.Rows.Count; i++)
					{
						if (dtallorder.Rows[i]["set_code"] != null)
						{
							string barCode = dtallorder.Rows[i]["set_code"].ToString();
							barCodeList.Add(j, barCode);
							j++;
						}
					}
					HCSSM_set_message_newshow showMessage = new HCSSM_set_message_newshow("2020");
					showMessage.BarCodeList = barCodeList;
					showMessage.UserId = CnasBaseData.UserID;
					showMessage.PdConfigStr = App_pd;
					showMessage.ShowDialog();
				}
			}
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
			HCSSM_statistics_manager statisticsManager = new HCSSM_statistics_manager();
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
				if (!string.IsNullOrEmpty(pd_code) && Int32.TryParse(pd_code, out pd_codeInt) && pd_codeInt > 3020)
				{
					if (mcm_right.Items.ContainsKey("tsm_bcuprint"))
						mcm_right.Items["tsm_bcuprint"].Visible = true;
				}
				else
				{
					if (mcm_right.Items.ContainsKey("tsm_bcuprint"))
						mcm_right.Items["tsm_bcuprint"].Visible = false;
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
			if (dgv_01.CurrentRow != null)
			{
				DataGridViewRow row = dgv_01.CurrentRow;
				string bcc_code = Convert.ToString(row.Cells["set_code"].Value);
				if (!string.IsNullOrEmpty(bcc_code))
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
						string confirmName = Convert.ToString(data.Rows[0]["confirmName"]); ;
						string userName = Convert.ToString(data.Rows[0]["userName"]); ;
						sl_par01.Add(1, "审核员：");
						sl_par01.Add(2, confirmName);
						sl_par01.Add(3, "打包员：");
						sl_par01.Add(4, userName);
						sl_par01.Add(5, "生产条码");
						sl_par01.Add(6, BCUCode);
						SortedList sl_rec = CnasHCSWorkflowInterface01.Get_BarCode_PrintData(BCUCode, sl_par01, null);
						if (sl_rec == null)
						{
							MessageBox.Show(this, "对不起！没有设置好条形码模版，请联系管理员！！！", "信息提示");
						}
						else
						{
							Barcode_print Barcode_print01 = new Barcode_print(sl_rec["xml"].ToString(), (SortedList)sl_rec["data"]);
							Barcode_print01.ShowDialog();
						}
					}
					else
					{
						Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "获取BCU生产码失败", "信息提示");
					}
				}
			}
		}
	}
}
