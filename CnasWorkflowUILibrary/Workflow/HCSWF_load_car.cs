using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Controls;
using Cnas.wns.CnasBaseClassClient;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_load_car : ControlViewBase
	{
		public HCSWF_load_car()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			if (UserInfo == null)
				UserInfo = UserBaseHelper.GetUserByBarCode(BarCodeHelper.GetBarCodeByType("BCB", ScanBarCodes))
					?? CnasBaseData.UserBaseInfo;
			userNameTxt.Text = UserInfo.UserName;
			SetCarName();
			RefreshWorkSets();
		}

		private void RefreshWorkSets()
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
			AppendTempBCCSet();
			setNumTxt.Text = setDataGrid.RowCount.ToString();
		}

		public void SetCarName()
		{
			SortedList condition = new SortedList();
			condition.Add(1, BarCodeHelper.GetBarCodeByType("BCD", ScanBarCodes));
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-transprot-device-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-transprot-device-sec001", condition);
			if (data != null)
			{
				foreach (DataRow row in data.Rows)
				{
					Dictionary<string, string> car = new Dictionary<string, string>();
					if (row["ca_name"] != null)
						carNameTxt.Text = row["ca_name"].ToString();
					break;
				}
			}
		}

	}
}
