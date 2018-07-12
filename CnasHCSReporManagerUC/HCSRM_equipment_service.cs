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
using Telerik.WinControls.UI;
using System.Configuration;

namespace Cnas.wns.CnasHCSReporManagerUC
{
	public partial class HCSRM_equipment_service : UserControl
	{
		DataRow[] arrayDR = null;
		SortedList sl_type = new SortedList();
		public HCSRM_equipment_service()
		{
			InitializeComponent();
			but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
			but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
			but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
			but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
			but_import1.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
			arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-equipment-service-type'");
			foreach (DataRow dr in arrayDR)
			{
				sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
			}
			GetData();
		}
		private void GetData()
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList SelectDataIndex = new SortedList();
			SelectDataIndex.Add(1, CnasBaseData.SystemID);
			string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-equipmen-service-sec001", SelectDataIndex);
			DataTable GetTable = reCnasRemotCall.RemotInterface.SelectData("HCS-equipmen-service-sec001", SelectDataIndex);
			dgv_01.Rows.Clear();
			if(GetTable!=null && GetTable.Rows.Count>0)
			{
				int ii = GetTable.Rows.Count;
				for(int i=0;i<ii;i++)
				{
					GridViewRowInfo row = dgv_01.Rows.AddNew();
					if (GetTable.Columns.Contains("remark") && GetTable.Rows[i]["remark"] != null) dgv_01.Rows[i].Cells["remark"].Value = GetTable.Rows[i]["remark"];
					if (GetTable.Columns.Contains("equipment_name") && GetTable.Rows[i]["equipment_name"] != null) dgv_01.Rows[i].Cells["equipment_name"].Value = GetTable.Rows[i]["equipment_name"];
					if (GetTable.Columns.Contains("existing_problem") && GetTable.Rows[i]["existing_problem"] != null) dgv_01.Rows[i].Cells["existing_problem"].Value = GetTable.Rows[i]["existing_problem"];
					if (GetTable.Columns.Contains("cssd_solution") && GetTable.Rows[i]["cssd_solution"] != null) dgv_01.Rows[i].Cells["cssd_solution"].Value = GetTable.Rows[i]["cssd_solution"];
					if (GetTable.Columns.Contains("reporter") && GetTable.Rows[i]["reporter"] != null) dgv_01.Rows[i].Cells["reporter"].Value = GetTable.Rows[i]["reporter"];
					if (GetTable.Columns.Contains("auditor") && GetTable.Rows[i]["auditor"] != null) dgv_01.Rows[i].Cells["auditor"].Value = GetTable.Rows[i]["auditor"];
					if (GetTable.Columns.Contains("service_penple") && GetTable.Rows[i]["service_penple"] != null) dgv_01.Rows[i].Cells["service_penple"].Value = GetTable.Rows[i]["service_penple"];
					if (GetTable.Columns.Contains("cre_datetime") && GetTable.Rows[i]["cre_datetime"] != null) dgv_01.Rows[i].Cells["cre_datetime"].Value = GetTable.Rows[i]["cre_datetime"];
					if (GetTable.Columns.Contains("mod_datetime") && GetTable.Rows[i]["mod_datetime"] != null) dgv_01.Rows[i].Cells["mod_datetime"].Value = GetTable.Rows[i]["mod_datetime"];
					if (GetTable.Columns.Contains("change_accessories") && GetTable.Rows[i]["change_accessories"] != null) dgv_01.Rows[i].Cells["change_accessories"].Value = GetTable.Rows[i]["change_accessories"];
					if (GetTable.Columns.Contains("service_condition") && GetTable.Rows[i]["service_condition"] != null) dgv_01.Rows[i].Cells["service_condition"].Value = GetTable.Rows[i]["service_condition"];
					if (GetTable.Columns.Contains("id") && GetTable.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = GetTable.Rows[i]["id"];
					if (GetTable.Columns.Contains("device_type") && GetTable.Rows[i]["device_type"] != null) dgv_01.Rows[i].Cells["type"].Value = GetTable.Rows[i]["device_type"];
				}
			}
			if(dgv_01.Rows.Count>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}
		private void but_new_Click(object sender, EventArgs e)
		{
			HCSRM_equipment_service_new HCRM = new HCSRM_equipment_service_new(null);
			HCRM.ShowInTaskbar = false;
			HCRM.ShowDialog();
			GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
		}

		private void but_edit_Click(object sender, EventArgs e)
		{
			if(dgv_01.Rows.Count==0||dgv_01.SelectedRows.Count==0)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "设备维修记录" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
			SortedList UpDataService = new SortedList();
			UpDataService.Add("remark", dgv_01.SelectedRows[0].Cells["remark"].Value);
			UpDataService.Add("equipment_name", dgv_01.SelectedRows[0].Cells["equipment_name"].Value);
			UpDataService.Add("existing_problem", dgv_01.SelectedRows[0].Cells["existing_problem"].Value);
			UpDataService.Add("cssd_solution", dgv_01.SelectedRows[0].Cells["cssd_solution"].Value);
			UpDataService.Add("reporter", dgv_01.SelectedRows[0].Cells["reporter"].Value);
			UpDataService.Add("auditor", dgv_01.SelectedRows[0].Cells["auditor"].Value);
			UpDataService.Add("service_penple", dgv_01.SelectedRows[0].Cells["service_penple"].Value);
			UpDataService.Add("change_accessories", dgv_01.SelectedRows[0].Cells["change_accessories"].Value);
			UpDataService.Add("service_condition", dgv_01.SelectedRows[0].Cells["service_condition"].Value);
			UpDataService.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
			UpDataService.Add("type", dgv_01.SelectedRows[0].Cells["type"].Value);
			HCSRM_equipment_service_new HCRM = new HCSRM_equipment_service_new(UpDataService);
			HCRM.ShowInTaskbar = false;
			HCRM.ShowDialog();
			GetData();
			if (dgv_01.Rows.Count > 0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
			}
		}

		private void but_remove_Click(object sender, EventArgs e)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			if (this.dgv_01.SelectedRows.Count <= 0||dgv_01.Rows.Count==0)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "设备维修记录" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["equipment_name"].Value.ToString(), "灭菌器" }), ConfigurationManager.AppSettings["SystemName"] + "--删除灭菌器", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList DeleteData = new SortedList();
			SortedList DeleteData1 = new SortedList();
			DeleteData.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
			DeleteData1.Add(1, DeleteData);
			string  Deletetest = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-equipmen-service-del001", DeleteData1, null);
			int Delete = reCnasRemotCall.RemotInterface.UPData(1, "HCS-equipmen-service-del001", DeleteData1, null);
			if(Delete>-1)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "设备维修记录" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				GetData();
                dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                if (dgv_01.Rows.Count > 0)
                {
                    if (selectedIndex == 0)//删除后判断是否为0
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                    else
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex - 1];
                    }
                    
                }
			}
		}

		private void but_print_Click(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
			string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
			RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


			RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
		}

		private void but_import_Click(object sender, EventArgs e)
		{
			
		}

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}

		private void but_import1_Click(object sender, EventArgs e)
		{
			ExcelHelper.ImprotDataToExcel(this.dgv_01, "设备维修记录");
		}
	}
}
