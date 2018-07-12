using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public static class DataConverter
	{
		public static int ConvertSetData(DataGridView setDataGrid, DataRow rowData)
		{
			int rowIndex = -1;
			if (rowData != null)
			{
				rowIndex = setDataGrid.Rows.Add();
				if (rowData.Table.Columns.Contains("id") && setDataGrid.Columns.Contains("setIdCol")) setDataGrid.Rows[rowIndex].Cells["setIdCol"].Value = rowData["id"];
				if (rowData.Table.Columns.Contains("bar_code") && setDataGrid.Columns.Contains("setBarCodeCol")) setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value = rowData["bar_code"];
				if (rowData.Table.Columns.Contains("ca_name") && setDataGrid.Columns.Contains("setNameCol")) setDataGrid.Rows[rowIndex].Cells["setNameCol"].Value = rowData["ca_name"];
				if (rowData.Table.Columns.Contains("pa_type") && setDataGrid.Columns.Contains("setTypeCol")) setDataGrid.Rows[rowIndex].Cells["setTypeCol"].Value = rowData["pa_type"];
				if (rowData.Table.Columns.Contains("pa_priorty") && setDataGrid.Columns.Contains("setPriortyCol")) setDataGrid.Rows[rowIndex].Cells["setPriortyCol"].Value = rowData["pa_priorty"];
				if (rowData.Table.Columns.Contains("wa_pr_Name") && setDataGrid.Columns.Contains("washingPCol")) setDataGrid.Rows[rowIndex].Cells["washingPCol"].Value = rowData["wa_pr_Name"];
				if (rowData.Table.Columns.Contains("st_pr_Name") && setDataGrid.Columns.Contains("sterilizerPCol")) setDataGrid.Rows[rowIndex].Cells["sterilizerPCol"].Value = rowData["st_pr_Name"];
				if (rowData.Table.Columns.Contains("cost_center_name") && setDataGrid.Columns.Contains("costCNameCol")) setDataGrid.Rows[rowIndex].Cells["costCNameCol"].Value = rowData["cost_center_name"];
				if (rowData.Table.Columns.Contains("location_name") && setDataGrid.Columns.Contains("setUseLoCol")) setDataGrid.Rows[rowIndex].Cells["setUseLoCol"].Value = rowData["location_name"];
				if (rowData.Table.Columns.Contains("base_set_id") && setDataGrid.Columns.Contains("base_id")) setDataGrid.Rows[rowIndex].Cells["base_id"].Value = rowData["base_set_id"];
				setDataGrid.Rows[rowIndex].Tag = rowData;
			}
			return rowIndex;
		}

		public static int GenerateInstrumentRow(DataGridView instrumentGrid, DataRow item)
		{
			int rowIndex = -1;
			if (item != null)
			{
				rowIndex = instrumentGrid.Rows.Add();
				if (instrumentGrid.Columns.Contains("inIdCol") && item.Table.Columns.Contains("id")) instrumentGrid.Rows[rowIndex].Cells["inIdCol"].Value = item["id"];
				if (instrumentGrid.Columns.Contains("inNameCol") && item.Table.Columns.Contains("ca_name")) instrumentGrid.Rows[rowIndex].Cells["inNameCol"].Value = item["ca_name"];
				if (instrumentGrid.Columns.Contains("inTypeCol") && item.Table.Columns.Contains("instrument_type")) instrumentGrid.Rows[rowIndex].Cells["inTypeCol"].Value = item["instrument_type"];
				if (instrumentGrid.Columns.Contains("inNumCol") && item.Table.Columns.Contains("instrument_num")) instrumentGrid.Rows[rowIndex].Cells["inNumCol"].Value = item["instrument_num"];
				if (instrumentGrid.Columns.Contains("costCNameCol") && item.Table.Columns.Contains("costc_name")) instrumentGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["costc_name"];
				if (instrumentGrid.Columns.Contains("inPriceCol") && item.Table.Columns.Contains("ca_price")) instrumentGrid.Rows[rowIndex].Cells["inPriceCol"].Value = item["ca_price"];
				if (instrumentGrid.Columns.Contains("inRemarkCol") && item.Table.Columns.Contains("wsin_remark")) instrumentGrid.Rows[rowIndex].Cells["inRemarkCol"].Value = item["wsin_remark"];
				instrumentGrid.Rows[rowIndex].Tag = item;
			}

			return rowIndex;
		}
	}
}
