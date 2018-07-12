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
	public partial class HCSWF_person_set : ControlViewBase
	{
		public HCSWF_person_set()
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			HasManualHandle = true;
			RefreshDataGrid();
			personTxt.Focus();
		}

		public override string HandleScanBarCode(string barCode)
		{
			if (HasManualHandle)
			{
				HasManualHandle = false;
				personTxt.Text = barCode;
				userNameTxt.Focus();
				return "病人信息添加成功。";
			}
			else
			{
				userNameTxt.Focus();
				return base.HandleScanBarCode(barCode);
			}
		}

		/// <summary>
		/// 包的信息
		/// </summary>
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
			AppendTempBCCSet();
		}

		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result = base.SetViewParameters();
			string personStr = personTxt.Text.Trim();
			OutputParameters = OutputParameters ?? new SortedList();
			SortedList personParams = new SortedList();
			personParams.Add("person_barcode", personStr);
			OutputParameters.Add("personParams", personParams);
			return result;
		}

		public override string ValidateData()
		{
			IsCfmCloseDialog = 1;
			string personStr = personTxt.Text.Trim();
			if (string.IsNullOrEmpty(personStr))
			{
				IsCfmCloseDialog = 2;
				return string.Format("必须填写病人信息");
			}
			return string.Empty;
		}

		private void OnPersonClick(object sender, EventArgs e)
		{
			HasManualHandle = true;
		}
		private DateTime _firstTime = DateTime.Now;
		private bool _canKeyDown = true;

		private void OnKeyUpEvent(object sender, KeyEventArgs e)
		{
			TimeSpan ts = DateTime.Now.Subtract(_firstTime);
			TextBox textBox = sender as TextBox;
			if (e.KeyData == Keys.Enter && _canKeyDown)
			{
				if (textBox != null)
				{
					Label messageLbl = CnasUtilityTools.FindControl<Label>(this.ParentForm, "resultLbl");
					HasManualHandle = false;
					userNameTxt.Focus();
					messageLbl.Text = "病人信息添加成功。";
				}
			}

			_firstTime = DateTime.Now;

			if (ts.Milliseconds < 20)
			{
				personTxt.Text = "";
				_canKeyDown = false;
			}
			else
			{
				_canKeyDown = true;
			}

		}


	}
}
