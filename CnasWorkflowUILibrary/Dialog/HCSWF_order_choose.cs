using Cnas.wns.CnasBaseClassClient;
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
	public partial class HCSWF_order_choose : BaseForm
	{
		public SortedList SelectItems = new SortedList();

		public HCSWF_order_choose(string pdCode)
			:base(pdCode)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public override void InitializeButtonImage()
		{
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch16", EnumImageType.PNG);
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			InitalizeOrderType();
			RefreshDataGrid();
		}

		private void InitalizeOrderType()
		{
			KeyValuePair<string, string> defaultItem = new KeyValuePair<string, string>("0", "--所有--");
			orderTypeCbx.Items.Add(defaultItem);
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note'");
			if (data != null && data.Length > 0)
			{
				string selectPriorty = string.Empty;
				foreach (DataRow item in data)
				{
					if (item["type_code"] != null)
					{
						KeyValuePair<string, string> comboboxItem = new KeyValuePair<string, string>(item["other_code"].ToString().Trim(), item["value_code"].ToString().Trim());
						orderTypeCbx.Items.Add(comboboxItem);
					}
				}
				
				orderTypeCbx.SelectedIndex = 0;
			}
		}

		private void RefreshDataGrid()
		{
			try
			{
				orderDataGrid.Rows.Clear();
				string filter = string.Empty;
				if (orderTypeCbx.SelectedIndex != 0 && orderTypeCbx.SelectedItem != null && orderTypeCbx.SelectedItem is KeyValuePair<string, string>)
				{
					filter += string.Format(" and LEFT(ws.set_code,5) = '{0}' ", ((KeyValuePair<string, string>)orderTypeCbx.SelectedItem).Key);
				}
				if (!string.IsNullOrEmpty(orderCodeTxt.Text))
				{
					filter += string.Format(" and ws.set_code like '%{0}%' ", orderCodeTxt.Text);
				}
				if (!string.IsNullOrEmpty(orderNameTxt.Text))
				{
					filter += string.Format(" and ws.set_name like '%{0}%' ", orderNameTxt.Text);
				}
				SortedList condition = new SortedList();
				condition.Add(1, PdCode);
				condition.Add(2, "0");
				condition.Add(3, filter);
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-order-work-set-sec001", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-order-work-set-sec001", condition);

				if (data != null)
				{
					foreach (DataRow item in data.Rows)
					{
						int rowIndex = orderDataGrid.Rows.Add();
						if (data.Columns.Contains("id"))
							orderDataGrid.Rows[rowIndex].Cells["idCol"].Value = item["id"];
						if (data.Columns.Contains("bar_code"))
							orderDataGrid.Rows[rowIndex].Cells["orderCodeCol"].Value = item["bar_code"];
						if (data.Columns.Contains("ca_name"))
							orderDataGrid.Rows[rowIndex].Cells["orderNameCol"].Value = item["ca_name"];
						if (data.Columns.Contains("order_type"))
							orderDataGrid.Rows[rowIndex].Cells["orderTypeCol"].Value = item["order_type"];
						if (data.Columns.Contains("customer_name"))
							orderDataGrid.Rows[rowIndex].Cells["customerCol"].Value = item["customer_name"];
						if (data.Columns.Contains("location_name"))
							orderDataGrid.Rows[rowIndex].Cells["useLocationCol"].Value = item["location_name"];
						if (data.Columns.Contains("cre_date"))
							orderDataGrid.Rows[rowIndex].Cells["credateCol"].Value = item["cre_date"];
						orderDataGrid.Rows[rowIndex].Tag = item;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnConfirmBtnClick(object sender, EventArgs e)
		{
			SelectItems.Clear();
			if (orderDataGrid.SelectedRows != null)
			{
				for (int i = 0; i < orderDataGrid.SelectedRows.Count; i++)
				{
					SelectItems.Add(i, orderDataGrid.SelectedRows[i].Tag);
				}
			}
			Close();
		}

		private void searchBtn_Click(object sender, EventArgs e)
		{
			RefreshDataGrid();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			OnConfirmBtnClick(null, null);
		}

	}
}
