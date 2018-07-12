using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Controls;
using Cnas.wns.CnasMetroFramework.Forms;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_set_search_manager : UserControl
	{
		private ILog _logger = null;

		/// <summary>
		/// 订单类型
		/// </summary>
		private Dictionary<string, string> _orderTypedic;
		/// <summary>
		/// 数据访问接口
		/// </summary>
		private CnasRemotCall reCnasRemotCall=new CnasRemotCall();
		/// <summary>
		/// 所有的流程
		/// </summary>
		private SortedList sl_allpd = new SortedList();

		/// <summary>
		/// 客户名称及成本中心
		/// </summary>
		private DataTable _dtCostCenter = new DataTable();
		/// <summary>
		/// 客户名称以及使用地点
		/// </summary>
		private DataTable _dtLocation = new DataTable();
		/// <summary>
		/// 工单类型
		/// </summary>
		private Dictionary<string,string> _ordertypeDic=new  Dictionary<string,string>();

		/// <summary>
		/// 普通包是否已经加载
		/// </summary>
		private bool _isLoadBase = false;

		/// <summary>
		/// 临时包是否已经加载
		/// </summary>
		private bool _isLoadTemp = false;

		/// <summary>
		/// 是否第一次
		/// </summary>
		private bool _isFirst = true;

		/// <summary>
		/// 区域id
		/// </summary>
		private string _appID=string.Empty;

		private string _unDisplayCurrentStorageWF = string.Empty;

		/// <summary>
		/// 窗体初始化
		/// </summary>
		public HCSSM_set_search_manager(string app_ID)
		{
			_logger = LogManager.GetLogger("CnasWNSClient");
			
			this._appID = app_ID;
			InitializeComponent();
			InitializeButtonImage();
		}

		private void SetViewState()
		{
			if (CnasBaseData.SystemVersion < 2)
			{
				mainTab.TabPages.Remove(tabPage2);
				mainTab.TabPages.Remove(tabPage3);
			}
			else if (CnasBaseData.SystemVersion < 3)
			{
				mainTab.TabPages.Remove(tabPage3);
			}
		}

		/// <summary>
		/// 切换到基本包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void baseSet_Click(object sender, EventArgs e)
		{
			if(!_isLoadBase)
			{
				GetBaseDgvTable();
			}
		}

		/// <summary>
		/// 切换到临时包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tempSet_Click(object sender, EventArgs e)
		{
			if(!_isLoadTemp)
			{
				GetTempDgvTable();
			}
		}

		public void InitializeCustomerCbx(MetroComboBox comBox)
		{
			comBox.Items.Clear();
			comBox.Items.Add(new KeyValuePair<string, string>("0", "所有"));
		
			if (CnasBaseData.UserAccessCustomer != null && CnasBaseData.UserAccessCustomer.Rows.Count > 0)
			{
				foreach (DataRow item in CnasBaseData.UserAccessCustomer.Rows)
				{
					string key = item["id"].ToString();
					string value = item["cu_name"].ToString();
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					comBox.Items.Add(cbxItem);
					if (CnasBaseData.UserBaseInfo != null && CnasBaseData.UserBaseInfo.CustomerId.ToString() == key)
					{
						int index = comBox.Items.IndexOf(cbxItem);
						comBox.SelectedIndex = index;
					}
				}
			}
		}

		private void InitializeUseLocationCbx(MetroComboBox customerCombox, MetroComboBox useLocationCombox)
		{
			useLocationCombox.Items.Clear();
			useLocationCombox.Items.Add(new KeyValuePair<string, string>("0", "所有"));
			SortedList condition = new SortedList();
			CnasRemotCall remoteCall = new CnasRemotCall();
			if (customerCombox.SelectedIndex > 0 && customerCombox.SelectedItem != null && customerCombox.SelectedItem is KeyValuePair<string, string>)
			{
				condition.Add(1, ((KeyValuePair<string, string>)customerCombox.SelectedItem).Key);
			}
			else
			{
				string customerIds = string.Empty;
				foreach (var item in customerCombox.Items)
				{
					KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
					customerIds += string.Format("'{0}',", cbxData.Key);
				}
				customerIds = customerIds.TrimEnd(',');
				condition.Add(1, customerIds);
			}
			string sql = "HCS-use-location-sec002";
			if (_appID == "1050")
			{
				sql = "HCS-use-location-sec011";
				condition.Add(2, CnasBaseData.UserBaseInfo.UserID);
			}

			string sqlTest = remoteCall.RemotInterface.CheckSelectData(sql, condition);
			DataTable data = remoteCall.RemotInterface.SelectData(sql, condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					string key = item["id"].ToString();
					string value = item["u_uname"].ToString();
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					useLocationCombox.Items.Add(cbxItem);
				}
				useLocationCombox.SelectedIndex = 0;
				useLocationCombox.Enabled = data.Rows.Count != 1 || customerCombox.SelectedIndex != 0;
			}
		}

		/// <summary>
		/// 窗体加载数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_set_search_manager_Load(object sender, EventArgs e)
		{
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			creStartTime.Value = today;
			creEndTime.Value = today.AddDays(1).AddMilliseconds(-1);
			sl_allpd = OrderHelper.GetAllPdCodeName(CnasBaseData.SystemID);

			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='UnDisplayStorage_id_02_wf'");
			if (array != null && array.Length > 0)
			{
				_unDisplayCurrentStorageWF = Convert.ToString(array[0]["value_code"]);
			}

			if (mainTab.SelectedIndex == 2)
				InitializeCustomerCbx(customerCbx);
			else if (mainTab.SelectedIndex == 1)
				InitializeCustomerCbx(customerOrderCbx);

			//InitializeUseLocationCbx(customerCbx, uselocationCbx);
			//InitializeUseLocationCbx(customerOrderCbx, cbbLocationCbx);

			SetOrderTypeItem();
			SetWorkSetCbxItem();//工单类型

			OnTabSelectionChanged(null, null);
			_isFirst = false;
			SetViewState();
		}

		/// <summary>
		/// 获取相应值
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private string GetSelectComBoBox(MetroComboBox cbb, int type)
		{
			if (cbb.SelectedItem != null && cbb.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbb.SelectedItem;
				if (type == 1)
				{
					return item.Key;
				}
				else if (type == 2)
				{
					return item.Value;
				}
				return string.Empty;
			}
			return string.Empty;
		}

		/// <summary>
		/// 初始化按钮图片背景
		/// </summary>
		private void InitializeButtonImage()
		{
			refreshBaseBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRefresh32", EnumImageType.PNG);
			searchBaseBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			refreshTempBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRefresh32", EnumImageType.PNG);
			searchTempBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnBaseIsExpiration.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPassTime32", EnumImageType.PNG);
			btnIsOver.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOvertime32", EnumImageType.PNG);
			btnTempIsexpiration.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPassTime32", EnumImageType.PNG);
			btnBaseClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnTempClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnViewOrder.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderview32", EnumImageType.PNG);
			btnPrint.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnViewSend.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSendorderv32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 获取工单类型
		/// </summary>
		private void SetWorkSetCbxItem()
		{
			DataRow[] workSetTypes = CnasBaseData.SystemBaseData.Select("type_code='HCS-workset-status-type'");
			if (workSetTypes != null && workSetTypes.Count() > 0)
			{
				_ordertypeDic = new Dictionary<string, string>();
				_ordertypeDic.Add("-1", "所有");
				foreach (DataRow item in workSetTypes)
				{
					string status = Convert.ToString(item["key_code"]);
					string statusDescription = Convert.ToString(item["value_code"]);
					if (!_ordertypeDic.ContainsKey(status) && int.Parse(status) < 5)
						_ordertypeDic.Add(status, statusDescription);
				}
			}
		}

		/// <summary>
		/// 获取BaseDgv的数据
		/// </summary>
		private void GetBaseDgvTable(int typeBtn = 0)
		{
			SortedList condition = GererateSearchCondition(0, typeBtn);
			string aaaBase = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec032", condition);
			DataTable dtallorderBase = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec032", condition);
			SetBaseDgvItems(dtallorderBase,typeBtn);
		}

		/// <summary>
		/// 获取临时dgv数据
		/// </summary>
		private void GetTempDgvTable(int typeBtn = 0)
		{
			SortedList condition = GererateSearchCondition(1, typeBtn);
			string aaaTemp = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec043", condition);
			DataTable dtallorderTemp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec043", condition);
			SetTempDgvItems(dtallorderTemp,typeBtn);
		}

		/// <summary>
		/// 获取查询条件
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private SortedList GererateSearchCondition(int type,int typeBtn=0)
		{
			SortedList condition = new SortedList();
			string wf_code_pk = "3020";
			string whereSql = string.Empty;
			if (type == 0)
			{
				if (customerCbx.SelectedIndex > 0 && customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
				{
					whereSql += string.Format(" and cus.id='{0}' ", ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
				}

				if (uselocationCbx.SelectedIndex > 0 && uselocationCbx.SelectedItem != null && uselocationCbx.SelectedItem is KeyValuePair<string, string>)
				{
					whereSql += string.Format(" and pa.location_id='{0}' ", ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key);
				}

				if (!string.IsNullOrEmpty(txtBaseBccCode.Text.Trim()))
				{
					whereSql += " and (pa.bar_code like '%" + txtBaseBccCode.Text.Trim() + "%' or ws.BCU_code like '%" + txtBaseBccCode.Text.Trim() + "%')";
				}
				if (!string.IsNullOrEmpty(txtBaseBccName.Text.Trim()))
				{
					whereSql += string.Format(" and pa.ca_name like '%{0}%'", txtBaseBccName.Text.Trim());
				}
				string baseSql = string.Empty;
				if(typeBtn==1)
				{
					baseSql += "where isexpiration=1";
				}
				else if(typeBtn==2)
				{
					baseSql += "where isover=1";
				}
				string overTimeStr = "0";
				DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code='SetInCSSDTime'");
				if(array.Length>0)
				{
					overTimeStr = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
				}
				DataRow[] array_wf = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Cre_BCU_wf'");
				if (array_wf.Length > 0)
				{
					string tempwf_code = Convert.ToString(array_wf[0]["value_code"]).TrimEnd(',');
					string[] array_wf_code = tempwf_code.Split(',');
					if(array_wf_code.Length>1)
						wf_code_pk = array_wf_code[1];
				}
				condition.Add(1, wf_code_pk);//打包节点
				condition.Add(2, wf_code_pk);//打包节点
				condition.Add(3, wf_code_pk);//打包节点
				condition.Add(4, overTimeStr);//超时时间
				condition.Add(5, wf_code_pk);//打包节点
				condition.Add(6, whereSql);
				condition.Add(7, baseSql);
			}
			if (type == 1)
			{
				if (!string.IsNullOrEmpty(txtTempBccCode.Text.Trim()))
				{
					whereSql += " and ws.BCU_code like '%" + txtTempBccCode.Text.Trim() + "%'";
				}
				if (!string.IsNullOrEmpty(txtTempBccName.Text.Trim()))
				{
					whereSql += string.Format(" and ws.set_name like '%{0}%'", txtTempBccName.Text.Trim());
				}
				string tempSql = string.Empty;
				if(typeBtn==1)
				{
					tempSql = "where isexpiration=1";
				}
				string expirationTimeStr = "0";//过期时间
				DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-expirationtime-type' and key_code='tempSet'");
				if (array.Length > 0)
				{
					expirationTimeStr = Convert.ToString(array[0]["value_code"]).TrimEnd(',');
				}
				DataRow[] array_wf = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data' and key_code='Cre_BCU_wf'");
				if (array_wf.Length > 0)
				{
					string tempwf_code = Convert.ToString(array_wf[0]["value_code"]).TrimEnd(',');
					string[] array_wf_code = tempwf_code.Split(',');
					wf_code_pk = array_wf_code[0];
				}
				condition.Add(1, wf_code_pk);//打包节点
				condition.Add(2, whereSql);
				condition.Add(3, tempSql);
			}
			if(type==2)
			{
				string set_code = txtOrderCode.Text.Trim();
 				//ordertype
				if (cbbOrderType.SelectedIndex > 0 && cbbOrderType.SelectedItem != null && cbbOrderType.SelectedItem is KeyValuePair<string, string>)
				{
					whereSql += string.Format(" and  LEFT(orderSet.set_code,5) ='{0}' ", ((KeyValuePair<string, string>)cbbOrderType.SelectedItem).Key);
				}
				
				//custmoer
				if (customerOrderCbx.SelectedIndex > 0 && customerOrderCbx.SelectedItem != null && customerOrderCbx.SelectedItem is KeyValuePair<string, string>)
				{
					whereSql += string.Format(" and hcs_customer.id='{0}' ", ((KeyValuePair<string, string>)customerOrderCbx.SelectedItem).Key);
				}

				//location
				if (cbbLocationCbx.SelectedIndex > 0 && cbbLocationCbx.SelectedItem != null && cbbLocationCbx.SelectedItem is KeyValuePair<string, string>)
				{
					whereSql += string.Format(" and orderIdSet.location_id='{0}' ", ((KeyValuePair<string, string>)cbbLocationCbx.SelectedItem).Key);
				}

				//OrderCode
				if (!string.IsNullOrEmpty(set_code))
				{
					whereSql += " and orderSet.set_code like '%" + set_code + "%'";
				}
				condition.Add(1,creStartTime.Value);
				condition.Add(2, creEndTime.Value);
				condition.Add(3, whereSql);
			}
			return condition;
		}

		/// <summary>
		/// 填充Basedgv
		/// </summary>
		/// <param name="table"></param>
		private void SetBaseDgvItems(DataTable table,int typeBtn=0)
		{
			dgv_base.Rows.Clear();
			if (table == null || table.Rows.Count == 0)
				return;

			foreach (DataRow item in table.Rows)
			{
				int index = dgv_base.Rows.Add();
				dgv_base.Rows[index].Cells["id"].Value = item["id"];
				dgv_base.Rows[index].Cells["set_code"].Value = item["set_code"];
				dgv_base.Rows[index].Cells["wf_code"].Value = string.Format("{0}：{1}", item["wf_code"], item["pd_name"]);
				string strwfcode = Convert.ToString(item["wf_code"]);
				dgv_base.Rows[index].Cells["wf_code_back"].Value = item["wf_code"];
				dgv_base.Rows[index].Cells["fir_sname"].Value = item["fir_sname"];
				if(!_unDisplayCurrentStorageWF.Contains(strwfcode))
				{
					dgv_base.Rows[index].Cells["sec_sname"].Value = item["sec_sname"];
				}
				dgv_base.Rows[index].Cells["ca_name"].Value = item["ca_name"];
				dgv_base.Rows[index].Cells["run_times"].Value = item["run_times"];
				dgv_base.Rows[index].Cells["status"].Value = item["ws_status"];
				dgv_base.Rows[index].Cells["setPriortyCol"].Value = item["pa_priorty"];
				if (Convert.ToString(item["urgent"]) == "1")
				{
					dgv_base.Rows[index].Cells["setPriortyCol"].Value = "手动加急";
					//dgv_base.Rows[index].Cells["sebPriortyCol"].Value = "4";
				}
				else
				{
					dgv_base.Rows[index].Cells["sebPriortyCol"].Value = Convert.ToString(item["pa_priorty"]);
				}
				dgv_base.Rows[index].Cells["cre_date"].Value = item["ws_cre_date"];
				dgv_base.Rows[index].Cells["remark"].Value = item["remark"];
				dgv_base.Rows[index].Cells["cu_name"].Value = item["cus_name"];
				dgv_base.Rows[index].Cells["cost_ca_name"].Value = item["cost_center_name"];
				dgv_base.Rows[index].Cells["setUseLoCol"].Value = item["location_name"];
				dgv_base.Rows[index].Cells["BCU_code"].Value = item["BCU_code"];
				
				dgv_base.Rows[index].Cells["isexpiration"].Value = item["isexpiration"];
				if (Convert.ToString(item["isexpiration"]) == "1")
				{
					dgv_base.Rows[index].Cells["isexpirationCol"].Value = "过期";
					dgv_base.Rows[index].Cells["isexpirationCol"].Style.ForeColor = Color.Red;
				}
				
				dgv_base.Rows[index].Cells["tempDate"].Value = item["tempDate"];
				dgv_base.Rows[index].Cells["tempEndDate"].Value = item["tempEndDate"];
				
				dgv_base.Rows[index].Cells["isover"].Value = item["isover"];
				if (Convert.ToString(item["isover"]) == "1" )
				{
					dgv_base.Rows[index].Cells["isoverCol"].Value = "超时";
					dgv_base.Rows[index].Cells["isoverCol"].Style.ForeColor = Color.Red;
				}
				dgv_base.Rows[index].Cells["start_cssd"].Value = item["start_cssd"];
				dgv_base.Rows[index].Cells["end_cssd"].Value = item["end_cssd"];
			}
		}

		/// <summary>
		/// 填充Tempdgv
		/// </summary>
		/// <param name="table"></param>
		private void SetTempDgvItems(DataTable table,int typeBtn=0)
		{
			dgv_temp.Rows.Clear();
			if (table == null || table.Rows.Count == 0)
				return;
			foreach (DataRow item in table.Rows)
			{
				int index = dgv_temp.Rows.Add();
				if (item["id"] != null) dgv_temp.Rows[index].Cells["tid"].Value = item["id"];
				if (item["BCU_code"] != null) dgv_temp.Rows[index].Cells["tset_code"].Value = item["BCU_code"];
				if (item["wf_code"] != null)
				{
					string strwfcode = item["wf_code"].ToString();
					dgv_temp.Rows[index].Cells["twf_code"].Value = strwfcode + "：" + Convert.ToString(sl_allpd[strwfcode]);
					dgv_temp.Rows[index].Cells["twf_code_back"].Value = strwfcode;
				}
				if (item["set_name"] != null) dgv_temp.Rows[index].Cells["tca_name"].Value = item["set_name"];
				if (item["cre_date"] != null) dgv_temp.Rows[index].Cells["tcre_date"].Value = item["cre_date"];
				if (item["remark"] != null) dgv_temp.Rows[index].Cells["tremark"].Value = item["remark"];
				dgv_temp.Rows[index].Cells["tisexpiration"].Value = Convert.ToString(item["isexpiration"]);
				if (Convert.ToString(item["isexpiration"]) == "1")
				{
					dgv_temp.Rows[index].Cells["tisexpirationCol"].Value = "过期";
					dgv_temp.Rows[index].Cells["tisexpirationCol"].Style.ForeColor = Color.Red;
				}

				dgv_temp.Rows[index].Cells["ttempDate"].Value = item["tempDate"];
				dgv_temp.Rows[index].Cells["ttempEndDate"].Value = item["tempEndDate"];
			}
		}
		
		/// <summary>
		/// 搜索临时包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void searchTempBtn_Click(object sender, EventArgs e)
		{
			GetTempDgvTable();
		}

		/// <summary>
		/// 搜索普通包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void searchBaseBtn_Click(object sender, EventArgs e)
		{
			GetBaseDgvTable();
		}

		/// <summary>
		/// 刷新临时包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void refreshTempBtn_Click(object sender, EventArgs e)
		{
			GetTempDgvTable();
		}

		/// <summary>
		/// 刷新基本包
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void refreshBaseBtn_Click(object sender, EventArgs e)
		{
			GetBaseDgvTable();
		}

		/// <summary>
		/// 客户名称更改引起成本中心更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mcb_customer_SelectedValueChanged(object sender, EventArgs e)
		{
			InitializeUseLocationCbx(customerCbx, uselocationCbx);
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBaseBccCode_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				GetBaseDgvTable();
			}
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBaseBccName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				GetBaseDgvTable();
			}
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtTempBccCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				GetTempDgvTable();
			}
		}

		/// <summary>
		/// enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtTempBccName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				GetTempDgvTable();
			}
		}

		/// <summary>
		/// 超时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBaseBtnIsOverClick(object sender, EventArgs e)
		{
			GetBaseDgvTable(2);
		}

		/// <summary>
		/// 过期
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBaseBtnIsExpirationClick(object sender, EventArgs e)
		{
			GetBaseDgvTable(1);
		}

		/// <summary>
		/// 临时包 过期
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTempBtnIsExpirationClick(object sender, EventArgs e)
		{
			GetTempDgvTable(1);
		}

		private void dgv_base_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			if (dgv_base.CurrentRow != null)
			{
				DataGridViewRow row = dgv_base.CurrentRow;
				string bcc_code = Convert.ToString(row.Cells["set_code"].Value);
				SortedList condition = new SortedList();
				condition.Add(bcc_code, bcc_code);
				HCSWF_set_detail_new newdetail = new HCSWF_set_detail_new(condition);
				newdetail.ShowDialog();
			}
		}

		/// <summary>
		/// 关闭所在窗口
		/// </summary>
		private void OnCloseForm()
		{
			Form parentForm = this.FindForm();
			parentForm.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBaseClose_Click(object sender, EventArgs e)
		{
			OnCloseForm();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTempClose_Click(object sender, EventArgs e)
		{
			OnCloseForm();
		}

		/// <summary>
		/// 器械包详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStrip_baseSetBtn_Click(object sender, EventArgs e)
		{
			if (dgv_base.CurrentRow != null)
			{
				DataGridViewRow row = dgv_base.CurrentRow;
				string bcc_code = Convert.ToString(row.Cells["set_code"].Value);
				SortedList condition = new SortedList();
				condition.Add(bcc_code, bcc_code);
				HCSWF_set_detail_new newdetail = new HCSWF_set_detail_new(condition);
				newdetail.ShowDialog();
			}
		}

		/// <summary>
		/// 生物监测结果
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStrip_BiologyBtn_Click(object sender, EventArgs e)
		{
			//
			string bcu_code = string.Empty;
			if (mainTab.SelectedIndex==2 && dgv_base.CurrentRow != null)
			{
				DataGridViewRow row = dgv_base.CurrentRow;
				bcu_code = Convert.ToString(row.Cells["BCU_code"].Value);
				
			}
			if (mainTab.SelectedIndex == 0 && dgv_temp.CurrentRow != null)
			{
				DataGridViewRow row = dgv_temp.CurrentRow;
				bcu_code = Convert.ToString(row.Cells["tset_code"].Value);
			}
			HCSSM_set_release_result releasedetail = new HCSSM_set_release_result(bcu_code);
			releasedetail.ShowDialog();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbCust_SelectedIndexChanged(object sender, EventArgs e)
		{
			InitializeUseLocationCbx(customerOrderCbx, cbbLocationCbx);
		}

		/// <summary>
		/// 设置要添加的订单类型
		/// </summary>
		private void SetOrderTypeItem()
		{
			if (_orderTypedic == null || (_orderTypedic != null && _orderTypedic.Count == 0))
			{
				_orderTypedic = new Dictionary<string, string>();
				//HCS-delivery-note
				DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note'");
				_orderTypedic.Add("0", "--所有--");
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
			BindingSource bs = new BindingSource();
			bs.DataSource = _orderTypedic;
			cbbOrderType.DataSource = bs;
			cbbOrderType.DisplayMember = "Value";
			cbbOrderType.ValueMember = "Key";
			cbbOrderType.SelectedIndex = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtOrderCode_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				GetOrderDgvTable();
			}
		}

		/// <summary>
		/// 查询订单
		/// </summary>
		private void GetOrderDgvTable()
		{
			SortedList condition = GererateSearchCondition(2);
			string aaaOrder = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec044", condition);
			DataTable dtallorderDetail = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec044", condition);
			SetOrderDgvItems(dtallorderDetail);
		}

		/// <summary>
		/// 设置订单dgv
		/// </summary>
		/// <param name="table"></param>
		private void SetOrderDgvItems(DataTable table)
		{
			dgv_OrderDetail.Rows.Clear();
			if (table != null && table.Rows.Count > 0)
			{
				for (int i = 0; i < table.Rows.Count; i++)
				{
					DataRow row = table.Rows[i];
					int index = dgv_OrderDetail.Rows.Add();
					string tempSet_Code = Convert.ToString(row["set_code"]);
					string wf_code_str = Convert.ToString(row["wf_code"]);
					string[] arr_wf_code = wf_code_str.Split(',');
					string show_wf_code = string.Empty;
					foreach(string item in arr_wf_code)
					{
						if(!string.IsNullOrEmpty(item)&&sl_allpd!=null&&sl_allpd.ContainsKey(item))
						{
							show_wf_code+=item + "：" + Convert.ToString(sl_allpd[item])+",";
						}
					}
					if(show_wf_code.Length>0)
					{
						show_wf_code=show_wf_code.Substring(0, show_wf_code.Length - ",".Length);
					}
					dgv_OrderDetail.Rows[index].Cells["batch"].Value = Convert.ToString(row["batch"]);
					dgv_OrderDetail.Rows[index].Cells["ocu_name"].Value = Convert.ToString(row["cu_name"]);
					dgv_OrderDetail.Rows[index].Cells["u_uname"].Value = Convert.ToString(row["u_uname"]);
					dgv_OrderDetail.Rows[index].Cells["order_type"].Value = tempSet_Code.Length > 4 ? InitDgvDataOrderType(tempSet_Code.Substring(0, 5)) : InitDgvDataOrderType(tempSet_Code);
					dgv_OrderDetail.Rows[index].Cells["oset_code"].Value = Convert.ToString(row["set_code"]);
					dgv_OrderDetail.Rows[index].Cells["oca_name"].Value = Convert.ToString(row["ca_name"]);
					dgv_OrderDetail.Rows[index].Cells["user_name"].Value = Convert.ToString(row["user_name"]);
					dgv_OrderDetail.Rows[index].Cells["ocre_date"].Value = Convert.ToString(row["cre_date"]);
					dgv_OrderDetail.Rows[index].Cells["owf_code"].Value = show_wf_code;
					dgv_OrderDetail.Rows[index].Cells["owf_code_back"].Value = wf_code_str;
				}
			}
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
		/// 根据订单内容显示数据
		/// </summary>
		/// <param name="orderType"></param>
		private void SetDgvBycbbOrderType(string orderType)
		{
			if (dgv_OrderDetail.Rows != null && dgv_OrderDetail.Rows.Count > 0)
			{
				if (orderType.Equals("--所有--"))
				{
					foreach (DataGridViewRow item in dgv_OrderDetail.Rows)
					{
						item.Visible = true;
					}
				}
				else
				{
					foreach (DataGridViewRow item in dgv_OrderDetail.Rows)
					{
						string tempCodeType = Convert.ToString(item.Cells["order_type"].Value).Trim();
						if (tempCodeType.Equals(orderType))
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

		/// <summary>
		/// 订单类型处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbOrderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			string getOrderTypeName = GetSelectComBoBox(cbbOrderType, 2).Trim();
			SetDgvBycbbOrderType(getOrderTypeName);
		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			OnCloseForm();
		}

		/// <summary>
		/// 订单查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			GetOrderDgvTable();
		}

		/// <summary>
		/// 查看订单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewOrder_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0&&dgv_OrderDetail.SelectedRows.Count>0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["oset_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
				detail.Mode = 2;
				detail.ShowDialog();
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 打印订单详情
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (dgv_OrderDetail.Rows.Count > 0 && dgv_OrderDetail.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_OrderDetail.SelectedRows[0];
				string orderNum = Convert.ToString(row.Cells["oset_code"].Value);
				string batch = Convert.ToString(row.Cells["batch"].Value);
				DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Order'");
				if (arrayDR02.Length > 0)
				{
					string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
					OrderHelper.OrderPrint(orderNum, batch, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillorderitem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_OrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex>=0)
			{
				if (dgv_OrderDetail.CurrentRow!=null)
				{
					DataGridViewRow row = dgv_OrderDetail.CurrentRow;
					string orderNum = Convert.ToString(row.Cells["oset_code"].Value);
					string batch = Convert.ToString(row.Cells["batch"].Value);
					HCSSM_order_new_order_detail detail = new HCSSM_order_new_order_detail(orderNum, batch);
					detail.Mode = 2;
					detail.ShowDialog();
				}
			}
		}

		private void OnReleaseResultBtnClick(object sender, EventArgs e)
		{
			try
			{
				SortedList condition = new SortedList();
				//condition.Add(1, "12");
				if (mainTab.SelectedIndex == 2)
				{
					if (dgv_base.SelectedRows != null && dgv_base.SelectedRows.Count > 0)
					{
						condition.Add(1, Convert.ToString(dgv_base.SelectedRows[0].Cells["BCU_code"].Value));
					}
				}
				else if (mainTab.SelectedIndex == 0)
				{
					if (dgv_temp.SelectedRows != null && dgv_temp.SelectedRows.Count > 0)
					{
						condition.Add(1, Convert.ToString(dgv_temp.SelectedRows[0].Cells["tset_code"].Value));
					}
				}
				CnasRemotCall remoteCall = new CnasRemotCall();
				#if DEBUG
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-release-data-sec001", condition);
				#endif

				DataTable data = remoteCall.RemotInterface.SelectData("HCS-release-data-sec001", condition);
				if (data!= null && data.Rows.Count > 0)
				{
					SortedList releaseData = new SortedList();
					releaseData.Add("dev_name", Convert.ToString(data.Rows[0]["dev_name"]));
					releaseData.Add("batch_num", Convert.ToString(data.Rows[0]["device_runtimes"]));
					releaseData.Add("object_id", Convert.ToString(data.Rows[0]["dev_id"]));
					releaseData.Add("bar_code", Convert.ToString(data.Rows[0]["container_code"]));
					releaseData.Add("release_type", "12");
					//releaseData.Add("result", (data.Rows[0]["release_result"] is DBNull) ? string.Empty : Convert.ToString(data.Rows[0]["release_result"]));
					HCSWF_device_result_add dialog = new HCSWF_device_result_add(releaseData, 1);
					//dialog.IsInsertResult = true;
					dialog.OperationUser = CnasBaseData.UserBaseInfo;
					dialog.ShowDialog();
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("NotFountReleaseInfo", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnContextMenuOpening(object sender, CancelEventArgs e)
		{
			if (mainTab.SelectedIndex ==2)
			{
				printSetCodeBtn.Visible = true;
				if (dgv_base.SelectedRows != null && dgv_base.SelectedRows.Count > 0)
				{
					printPBCodeBtn.Visible = dgv_base.SelectedRows[0].Cells["BCU_code"].Value != null
						&& !string.IsNullOrEmpty(dgv_base.SelectedRows[0].Cells["BCU_code"].Value.ToString());
					biologyNewBtn.Visible = dgv_base.SelectedRows[0].Cells["BCU_code"].Value != null
						&& !string.IsNullOrEmpty(dgv_base.SelectedRows[0].Cells["BCU_code"].Value.ToString()) && (_appID == "1020" || _appID == "1030");
				}
			}
			else if (mainTab.SelectedIndex == 0)
			{
				printSetCodeBtn.Visible = false;
				if (dgv_temp.SelectedRows != null && dgv_temp.SelectedRows.Count > 0)
				{
					printPBCodeBtn.Visible = dgv_temp.SelectedRows[0].Cells["tset_code"].Value != null
						&& !string.IsNullOrEmpty(dgv_temp.SelectedRows[0].Cells["tset_code"].Value.ToString());
					biologyNewBtn.Visible = dgv_temp.SelectedRows[0].Cells["tset_code"].Value != null
						&& !string.IsNullOrEmpty(dgv_temp.SelectedRows[0].Cells["tset_code"].Value.ToString()) && (_appID == "1020" || _appID == "1030");
				}
			}
			biologyInfoBtn.Visible = _appID == "1050";
		}

		private void OnTabSelectionChanged(object sender, EventArgs e)
		{
			switch (mainTab.SelectedIndex)
			{
				
				case 0:
					GetTempDgvTable();
					break;
				case 1:
					{
						if (customerOrderCbx.Items.Count <= 0)
							InitializeCustomerCbx(customerOrderCbx);
						GetOrderDgvTable();
					}
					break;
				case 2:
					{
						if (customerCbx.Items.Count <= 0)
							InitializeCustomerCbx(customerCbx);
						GetBaseDgvTable();
					}
					break;
				default:
					break;
			}
		}

		private void printSetCodeBtn_Click(object sender, EventArgs e)
		{
			if (dgv_base.SelectedRows != null && dgv_base.SelectedRows.Count > 0)
			{
				string barCode = Convert.ToString(dgv_base.SelectedRows[0].Cells["set_code"].Value);
				string setName = Convert.ToString(dgv_base.SelectedRows[0].Cells["ca_name"].Value);
				SortedList parameter = new SortedList();
				parameter.Add("P013", setName);
				if (!string.IsNullOrEmpty(barCode))
					BarCodeHelper.PrintBarCode(barCode, parameter);
			}
		}

		private void printPBCodeBtn_Click(object sender, EventArgs e)
		{
			if (mainTab.SelectedIndex == 0)
			{
				if (dgv_temp.SelectedRows != null && dgv_temp.SelectedRows.Count > 0)
				{
					string barCode = Convert.ToString(dgv_temp.SelectedRows[0].Cells["tset_code"].Value);
					string setName = Convert.ToString(dgv_temp.SelectedRows[0].Cells["tca_name"].Value);
					SortedList parameter = new SortedList();
					parameter.Add("P013", setName);
					if (!string.IsNullOrEmpty(barCode))
						BarCodeHelper.PrintBarCode(barCode, parameter);
				}
			}
			else if (mainTab.SelectedIndex == 2)
			{
				if (dgv_base.SelectedRows != null && dgv_base.SelectedRows.Count > 0)
				{
					string barCode = Convert.ToString(dgv_base.SelectedRows[0].Cells["BCU_code"].Value);
					string setName = Convert.ToString(dgv_base.SelectedRows[0].Cells["ca_name"].Value);
					SortedList parameter = new SortedList();
					parameter.Add("P013", setName);
					if (!string.IsNullOrEmpty(barCode))
						BarCodeHelper.PrintBarCode(barCode, parameter);
				}
			}
		}

	}
}
