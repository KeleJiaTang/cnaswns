using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_send_orderList_manager : UserControl
	{
		private bool _isLoad = false;
		public string AppId { get; set; }
		public HCSWF_send_orderList_manager()
		{
			InitializeComponent();
			InitializeButtonImage();
		}

		private void InitializeButtonImage()
		{
			previewBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOrderview32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
		}

		public void InitializeCustomerCbx()
		{
			customerCbx.Items.Clear();
			customerCbx.Items.Add(new KeyValuePair<string, string>("0", "所有"));

			if (CnasBaseData.UserAccessCustomer != null && CnasBaseData.UserAccessCustomer.Rows.Count > 0)
			{
				foreach (DataRow item in CnasBaseData.UserAccessCustomer.Rows)
				{
					string key = item["id"].ToString();
					string value = item["cu_name"].ToString();
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					customerCbx.Items.Add(cbxItem);
					if (CnasBaseData.UserBaseInfo != null && CnasBaseData.UserBaseInfo.CustomerId.ToString() == key)
					{
						int index = customerCbx.Items.IndexOf(cbxItem);
						customerCbx.SelectedIndex = index;
					}
				}
			}
		}

		private void InitializeUseLocationCbx()
		{
			uselocationCbx.Items.Clear();
			uselocationCbx.Items.Add(new KeyValuePair<string, string>("0", "所有"));
			SortedList condition = new SortedList();
			CnasRemotCall remoteCall = new CnasRemotCall();
			if (customerCbx.SelectedIndex > 0 && customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
			{
				condition.Add(1, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
			}
			else
			{
				string customerIds = string.Empty;
				foreach (var item in customerCbx.Items)
				{
					KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
					customerIds += string.Format("'{0}',", cbxData.Key);
				}
				customerIds = customerIds.TrimEnd(',');
				condition.Add(1, customerIds);
			}
			string sql = "HCS-use-location-sec002";
			if (AppId == "1050")
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
					uselocationCbx.Items.Add(cbxItem);
				}

				if (data.Rows.Count == 1)
				{
					uselocationCbx.Items.RemoveAt(0);
					uselocationCbx.Enabled = false;
				}
				uselocationCbx.SelectedIndex = 0;
			}
		}

		public void GetOderHistories()
		{
			orderGrid.Rows.Clear();
			SortedList condition = new SortedList();

			if (uselocationCbx.SelectedIndex > 0 && uselocationCbx.SelectedItem != null && uselocationCbx.SelectedItem is KeyValuePair<string, string>)
			{
				condition.Add(1, ((KeyValuePair<string, string>)uselocationCbx.SelectedItem).Key);
			}
			else
			{
				string costCenter = string.Empty;
				foreach (var item in uselocationCbx.Items)
				{
					KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
					costCenter += string.Format("'{0}',", cbxData.Key);
				}
				costCenter = costCenter.TrimEnd(',');
				condition.Add(1, costCenter);
			}
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			condition.Add(2, (startDatePicker.Value != null ? startDatePicker.Value.ToString() : today.ToString()));
			condition.Add(3, (endDatePicker.Value != null ? endDatePicker.Value.ToString() : today.AddDays(1).AddMilliseconds(-1).ToString()));
			CnasRemotCall remoteCall = new CnasRemotCall();

			string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-sendorder_manager-sec001", condition);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-sendorder_manager-sec001", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					int rowIndex = orderGrid.Rows.Add();
					if (data.Columns.Contains("cu_name")) orderGrid.Rows[rowIndex].Cells["customerCol"].Value = item["cu_name"];
					if (data.Columns.Contains("ul_name")) orderGrid.Rows[rowIndex].Cells["useLocationCol"].Value = item["ul_name"];
					if (data.Columns.Contains("send_date")) orderGrid.Rows[rowIndex].Cells["sendTimeCol"].Value = item["send_date"];
					if (data.Columns.Contains("set_num")) orderGrid.Rows[rowIndex].Cells["setNumCol"].Value = item["set_num"];
					if (data.Columns.Contains("batchNum")) orderGrid.Rows[rowIndex].Cells["batchNumCol"].Value = item["batchNum"];
					if (data.Columns.Contains("dev_name")) orderGrid.Rows[rowIndex].Cells["carNameCol"].Value = item["dev_name"];
				}
			}
		}	

		private void OnControlLoaded(object sender, EventArgs e)
		{
			_isLoad = true;
			InitializeCustomerCbx();
			InitializeUseLocationCbx();
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			startDatePicker.Value = today;
			endDatePicker.Value = today.AddDays(1).AddMilliseconds(-1);
			if (CnasBaseData.UserBaseInfo != null)
			{
				customerCbx.Enabled = CnasBaseData.UserBaseInfo.UserType == 9;
			}
			_isLoad = false;
		}

		private void OnCustomerSelectionChanged(object sender, EventArgs e)
		{
			InitializeUseLocationCbx();
		}

		private void OnUseLocationSelectionChanged(object sender, EventArgs e)
		{
			GetOderHistories();
		}

		private void OnPreviewBtnClick(object sender, EventArgs e)
		{
			if (orderGrid.CurrentRow!= null)
			{
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("customerName", orderGrid.CurrentRow.Cells["customerCol"].Value != null ? orderGrid.CurrentRow.Cells["customerCol"].Value.ToString() : string.Empty);
				data.Add("locationName", orderGrid.CurrentRow.Cells["useLocationCol"].Value != null ? orderGrid.CurrentRow.Cells["useLocationCol"].Value.ToString() : string.Empty);
				data.Add("carName", orderGrid.CurrentRow.Cells["carNameCol"].Value != null ? orderGrid.CurrentRow.Cells["carNameCol"].Value.ToString() : string.Empty);
				data.Add("BatchNum", orderGrid.CurrentRow.Cells["batchNumCol"].Value != null ? orderGrid.CurrentRow.Cells["batchNumCol"].Value.ToString() : string.Empty);
				HCSWF_check_send_setlist sendOrderDetail = new HCSWF_check_send_setlist(data);
				sendOrderDetail.ShowDialog();
			}
		}

		private void OnPrintClick(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
			string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
			PrintHelper RadPrintHelper = new PrintHelper();
			RadPrintHelper.Print_DataGridView(orderGrid, pringxml);
		}

		private void OnSearchBtnClick(object sender, EventArgs e)
		{
			GetOderHistories();
		}

		private void OnDateTimePikcerChanged(object sender, EventArgs e)
		{
			if (!_isLoad)
				GetOderHistories();
		}

		private void OnKeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				GetOderHistories();
			}
		}

		private void OnOrderGridDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			OnPreviewBtnClick(null, null);
		}
 
	}
}
