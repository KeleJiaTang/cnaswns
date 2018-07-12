using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSSystemUC
{
	public partial class HCSSM_app : UserControl
	{
		private DataTable dtappall = new DataTable();
		private SortedList slappparent = new SortedList();

		public HCSSM_app()
		{
			InitializeComponent();
			#region button图标
			this.but_moduleActivation.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "moduleActivation", EnumImageType.PNG);
			this.but_parameterSetting.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "parameterSetting", EnumImageType.PNG);
			this.but_processParameter.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "processParameter", EnumImageType.PNG);
			this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
			this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
			#endregion
			//this.Font = new Font(this.Font.FontFamily, 11);
			//表格栏底色
			//dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
			//dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
			////dgv表格各字段居中
			//this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-app-sec001", sttemp01);
			dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec001", sttemp01);
			if (dtappall != null)
			{
				cb_app.Items.Add("全部功能模块");
				DataRow[] arrayDR = dtappall.Select("app_type=0");
				foreach (DataRow dr in arrayDR)
				{
					slappparent.Add(dr["app_name"].ToString().Trim(), dr["app_code"].ToString().Trim());
					cb_app.Items.Add(dr["app_name"].ToString().Trim());

				}
				cb_app.Text = "全部功能模块";
			}
			cb_app_SelectedIndexChanged(null, null);
			if (dgv_01.RowCount > 0)
			{
				dgv_01.Rows[0].IsSelected = true;
			}
		}

		private void LoadData()
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-app-sec001", sttemp01);
			dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec001", sttemp01);

		}

		private void cb_app_SelectedValueChanged(object sender, EventArgs e)
		{
			dgv_01.Rows.Clear();
			if (cb_app.Text == "全部功能模块")
			{
				DataRow[] arrayDR = dtappall.Select("app_type=1");
				int ii = arrayDR.Length;
				if (ii <= 0) return;
				dgv_01.RowCount = ii;
				int i = 0;
				foreach (DataRow dr in arrayDR)
				{
					if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
					if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
					if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
					if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
					if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
					i++;
				}

			}
			else
			{
				DataRow[] arrayDR = dtappall.Select("app_parent='" + slappparent[cb_app.Text].ToString() + "'");
				int ii = arrayDR.Length;
				if (ii <= 0) return;
				dgv_01.RowCount = ii;
				int i = 0;
				foreach (DataRow dr in arrayDR)
				{
					if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
					if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
					if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
					if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
					if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
					i++;
				}

			}
			if (dgv_01.RowCount > 0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}

		private void tb_search_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void but_activate_Click(object sender, EventArgs e)
		{
		}

		private void but_par_Click(object sender, EventArgs e)
		{
			HCSSM_app_bpm HCSSM_app_bpm01 = new HCSSM_app_bpm();
			//获取一个值，指是否在Windows任务栏中显示窗体。
			HCSSM_app_bpm01.ShowInTaskbar = false;
			HCSSM_app_bpm01.ShowDialog();
		}
		private void but_import_Click(object sender, EventArgs e)
		{

		}

		private void but_wf_Click(object sender, EventArgs e)
		{

		}

		private void but_new_Click(object sender, EventArgs e)
		{
			HCSSM_app_activate hctmp = new HCSSM_app_activate(slappparent, dtappall);
			//获取一个值，指是否在Windows任务栏中显示窗体。
			hctmp.ShowInTaskbar = false;
			hctmp.ShowDialog();
			if (CnasBaseData.If_LoadData == 1)
			{
				LoadData();
				CnasBaseData.If_LoadData = 0;
			}
		}

		private void radButton1_Click(object sender, EventArgs e)
		{

			HCSSM_app_bpm HCSSM_app_bpm01 = new HCSSM_app_bpm();
			//获取一个值，指是否在Windows任务栏中显示窗体。
			HCSSM_app_bpm01.ShowInTaskbar = false;
			HCSSM_app_bpm01.ShowDialog();
		}

		private void cb_app_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
		{

			//dgv_01.Rows[0].Selected = true;
		}

		private void tb_search_KeyDown_1(object sender, KeyEventArgs e)
		{

			if (e.KeyValue == 13)
			{
				string strsecdata = tb_search.Text.Trim();
				dgv_01.Rows.Clear();
				if (cb_app.Text == "全部功能模块")
				{
					DataRow[] arrayDR = dtappall.Select("app_type=1 and ( app_name like '%" + strsecdata + "%' or app_code like '%" + strsecdata + "%')");
					int ii = arrayDR.Length;
					if (ii <= 0) return;
					dgv_01.RowCount = ii;
					int i = 0;
					foreach (DataRow dr in arrayDR)
					{
						if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
						if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
						if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
						if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
						if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
						i++;
					}
				}
				else
				{
					//DataRow[] arrayDR = dtappall.Select("app_parent='" + slappparent[cb_app.Text].ToString() + "'");
					string sql = string.Format("app_parent='{0}' and ( app_name like '%{1}%' or app_code like '%{2}%')", slappparent[cb_app.Text].ToString(), strsecdata, strsecdata);
					DataRow[] arrayDR = dtappall.Select(sql);

					int ii = arrayDR.Length;
					if (ii <= 0) return;
					dgv_01.RowCount = ii;
					int i = 0;
					foreach (DataRow dr in arrayDR)
					{
						if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
						if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
						if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
						if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
						if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
						i++;
					}
				}
				if (dgv_01.RowCount > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
			}
		}

		private void radButton3_Click(object sender, EventArgs e)
		{
			ExcelHelper.ImprotDataToExcel(this.dgv_01, "系统模块");
		}

		private void radButton4_Click(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='system'");
			string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
			RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


			RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
		}

		private void dgv_01_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
		{
			GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
			if (cell != null)
			{
				cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
			}
		}

		private void cb_app_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
		{
			dgv_01.Rows.Clear();
			if (cb_app.Text == "全部功能模块")
			{
				DataRow[] arrayDR = dtappall.Select("app_type=1");
				int ii = arrayDR.Length;
				if (ii <= 0) return;
				dgv_01.RowCount = ii;
				int i = 0;
				foreach (DataRow dr in arrayDR)
				{
					if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
					if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
					if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
					if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
					if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
					i++;
				}

			}
			else
			{
				DataRow[] arrayDR = dtappall.Select("app_parent='" + slappparent[cb_app.Text].ToString() + "'");
				int ii = arrayDR.Length;
				if (ii <= 0) return;
				dgv_01.RowCount = ii;
				int i = 0;
				foreach (DataRow dr in arrayDR)
				{
					if (dtappall.Columns.Contains("id") && dr["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
					if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) dgv_01.Rows[i].Cells["app_name"].Value = dr["app_name"].ToString();
					if (dtappall.Columns.Contains("app_parent") && dr["app_parent"] != null) dgv_01.Rows[i].Cells["app_parent"].Value = dr["app_parent"].ToString();
					if (dtappall.Columns.Contains("app_code") && dr["app_code"] != null) dgv_01.Rows[i].Cells["app_code"].Value = dr["app_code"].ToString();
					if (dtappall.Columns.Contains("app_description") && dr["app_description"] != null) dgv_01.Rows[i].Cells["app_description"].Value = dr["app_description"].ToString();
					i++;
				}
			}
			if(dgv_01.RowCount>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}

		private void but_processParameter_Click(object sender, EventArgs e)
		{

		}
	}
}
