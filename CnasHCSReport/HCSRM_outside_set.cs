using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;

namespace Cnas.wns.CnasHCSReport
{
	public partial class HCSRM_outside_set : UserControl
	{
		public HCSRM_outside_set()
		{
			InitializeComponent();
			this.but_instrument.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "lookinstrument", EnumImageType.PNG);
			this.but_set.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "lookset", EnumImageType.PNG);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//获取客户表的数据
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
			if (getdt != null)
			{
				foreach (DataRow item in getdt.Rows)
				{
					if (item["id"].ToString() != null && item["cu_name"].ToString().Trim() != null && item["bar_code"].ToString().Trim() != null)
					{
						RadListDataItem cbxItem = new RadListDataItem(item["cu_name"].ToString().Trim(), CnasUtilityTools.ConcatTwoString(item["id"].ToString().Trim(), item["bar_code"].ToString().Trim()));
						cb_customer.Items.Add(cbxItem);
					}
				}
				cb_customer.SelectedIndex = 0;
				cb_customer_TextChanged(null, null);
			}
		}

		private void cb_customer_TextChanged(object sender, EventArgs e)
		{
			dgv_01.Rows.Clear();
			this.cb_location.Items.Clear();
			string value = cb_customer.SelectedItem != null && cb_customer.SelectedItem.Value != null ? cb_customer.SelectedItem.Value.ToString() : string.Empty;
			if (!string.IsNullOrEmpty(value))
			{
				string[] ids = value.Split(':');
				if (ids.Length >= 2)
				{
					SortedList sl_barcode = new SortedList();
					sl_barcode.Add(1, ids[0]);
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();

					DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec002", sl_barcode);//获取属于该客户的成本中心
					if (getdt != null)
					{
						foreach (DataRow item in getdt.Rows)
						{
							if (item["id"].ToString() != null && item["u_uname"].ToString().Trim() != null)
							{
								RadListDataItem cbxItem = new RadListDataItem(item["u_uname"].ToString().Trim(), item["id"].ToString().Trim());
								cb_location.Items.Add(cbxItem);
							}
						}
						cb_location.SelectedIndex = 0;
					}
				}
			}
			GetData();
		}
		private void GetData()
		{
			dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
			string customerValue = cb_customer.SelectedItem != null && cb_customer.SelectedItem.Value != null ? cb_customer.SelectedItem.Value.ToString() : string.Empty;
			string locationValue = cb_location.SelectedItem != null && cb_location.SelectedItem.Value != null ? cb_location.SelectedItem.Value.ToString() : string.Empty;
		

			if (!string.IsNullOrEmpty(customerValue) && !string.IsNullOrEmpty(locationValue))
			{
				
				string[] ids = customerValue.Split(':');
				if (ids.Length >= 2)
				{
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					SortedList slttmp = new SortedList();
					slttmp.Add(2, locationValue);
					slttmp.Add(1, ids[1]);
					
					string qq = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-work-set-sec010", slttmp);
					DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-work-set-sec010", slttmp);
					if (getdt01 != null)
					{

						int ii = getdt01.Rows.Count;
						if (ii <= 0) return;
						dgv_01.RowCount = ii;

						for (int i = 0; i < ii; i++)
						{
							if (getdt01.Columns.Contains("set_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["set_code"].ToString())) dgv_01.Rows[i].Cells["bar_code"].Value = getdt01.Rows[i]["set_code"].ToString();
							if (getdt01.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["name"].Value = getdt01.Rows[i]["ca_name"].ToString();
							if (getdt01.Columns.Contains("cu_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["cu_name"].ToString())) dgv_01.Rows[i].Cells["customer"].Value = getdt01.Rows[i]["cu_name"].ToString(); ;
							if (getdt01.Columns.Contains("ca_name1") && !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name1"].ToString())) dgv_01.Rows[i].Cells["costcenter"].Value = getdt01.Rows[i]["ca_name1"].ToString();
							if (getdt01.Columns.Contains("u_uname") && !string.IsNullOrEmpty(getdt01.Rows[i]["u_uname"].ToString())) dgv_01.Rows[i].Cells["location"].Value = getdt01.Rows[i]["u_uname"].ToString();
							if (getdt01.Columns.Contains("mod_date1") && !string.IsNullOrEmpty(getdt01.Rows[i]["mod_date1"].ToString())) dgv_01.Rows[i].Cells["sterilizerdate"].Value = getdt01.Rows[i]["mod_date1"].ToString();
							if (getdt01.Columns.Contains("user_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_name"].ToString())) dgv_01.Rows[i].Cells["sterilizeruser"].Value = getdt01.Rows[i]["user_name"].ToString();
							if (getdt01.Columns.Contains("user_name1") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_name1"].ToString())) dgv_01.Rows[i].Cells["washinguser"].Value = getdt01.Rows[i]["user_name1"].ToString();
							if (getdt01.Columns.Contains("mod_date2") && !string.IsNullOrEmpty(getdt01.Rows[i]["mod_date2"].ToString())) dgv_01.Rows[i].Cells["washingdate"].Value = getdt01.Rows[i]["mod_date2"].ToString();
							if (getdt01.Columns.Contains("batch") && !string.IsNullOrEmpty(getdt01.Rows[i]["batch"].ToString())) dgv_01.Rows[i].Cells["batch"].Value = getdt01.Rows[i]["batch"].ToString();
						}
						if(ii>0)
						{
							dgv_01.CurrentRow = dgv_01.Rows[0];
						}
					}
				}
			}
		}

		private void cb_location_TextChanged(object sender, EventArgs e)
		{
			GetData();
		}

		private void but_set_Click(object sender, EventArgs e)
		{
			SortedList SetData = new SortedList();
			if(dgv_01.SelectedRows.Count>0)
			{
				SetData.Add("barcode", dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString());
				SetData.Add("name", dgv_01.SelectedRows[0].Cells["name"].Value.ToString());
				SetData.Add("batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
			}
			else
			{
				MessageBox.Show("请选择包。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			HCSRS_outsideset_patient HCSRS = new HCSRS_outsideset_patient(SetData);
			HCSRS.ShowDialog();
		}

		private void but_instrument_Click(object sender, EventArgs e)
		{
			SortedList SetData = new SortedList();
			if (dgv_01.SelectedRows.Count > 0)
			{
				SetData.Add("barcode", dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString());
				SetData.Add("name", dgv_01.SelectedRows[0].Cells["name"].Value.ToString());
				SetData.Add("batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
			}
			else
			{
				MessageBox.Show("请选择包。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			HCSRS_outsideset_instrument HCSRS = new HCSRS_outsideset_instrument(SetData);
			HCSRS.ShowDialog();
		}
	}
}
