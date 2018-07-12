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

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_storage_set : ControlViewBase
	{
		public HCSWF_storage_set()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			SetLocationName();
			RefreshDataGrid();
		}

		private void SetLocationName()
		{
			SortedList condition = new SortedList();
			condition.Add(1, BarCodeHelper.GetBarCodeByType("BCS", ScanBarCodes));
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-storage-sec005", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-storage-sec005", condition);
			if (data != null)
			{
				foreach (DataRow row in data.Rows)
				{
					Dictionary<string, string> car = new Dictionary<string, string>();
					if (row["s_name"] != null)
						areaTxt.Text = row["s_name"].ToString();
					break;
				}
			}
		}

		private void RefreshDataGrid()
		{
			setDataGrid.Rows.Clear();
			SortedList condition = new SortedList();
			condition.Add(1, PdCode);
			condition.Add(2, "0");

			string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", ScanBarCodes);
			setBarCodes = setBarCodes.Replace(",", "','");
			condition.Add(3, setBarCodes);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec003", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec003", condition);

			if (data != null)
			{
				foreach (DataRow item in data.Rows)
				{
					DataConverter.ConvertSetData(setDataGrid, item);
				}
			}
		}

	}
}
