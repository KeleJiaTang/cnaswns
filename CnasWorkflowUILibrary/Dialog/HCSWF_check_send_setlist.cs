using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
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
	public partial class HCSWF_check_send_setlist : MetroForm
	{
		private Dictionary<string, string> _viewData;
		private string _pdCode = string.Empty;

		public Dictionary<string, string> ViewData 
		{
			get
			{
				if (_viewData == null)
					_viewData = new Dictionary<string, string>();
				return _viewData;
			}
			set
			{
				if (_viewData != value)
					_viewData = value;
			}
		}

		public HCSWF_check_send_setlist()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public void InitializeButtonImage()
		{
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
		}

		public HCSWF_check_send_setlist(Dictionary<string, string> data)
		{
			InitializeComponent();
			ViewData = data;
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{
			InitializeButtonImage();
			if (ViewData != null)
			{
				if (ViewData.ContainsKey("customerName")) customerTxt.Text = ViewData["customerName"];
				if (ViewData.ContainsKey("locationName")) useLocationTxt.Text = ViewData["locationName"];
				if (ViewData.ContainsKey("carName")) carNameTxt.Text = ViewData["carName"];
			}
			GetSetList();
			setNumTxt.Text = setDataGrid.Rows.Count.ToString();
		}

		public void GetSetList()
		{
			SortedList condition = new SortedList();
			condition.Add(1, ViewData != null && ViewData.ContainsKey("BatchNum") ? ViewData["BatchNum"] : string.Empty);
			condition.Add(2, CnasBaseData.SystemID);
			CnasRemotCall remoteCall = new CnasRemotCall();
			string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-sendorder-detail-sec001", condition);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-sendorder-detail-sec001", condition);
			if (data != null)
			{
				foreach (DataRow item in data.Rows)
				{
					int rowIndex = setDataGrid.Rows.Add();
					if (data.Columns.Contains("set_code")) setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value = item["set_code"];
					if (data.Columns.Contains("set_name")) setDataGrid.Rows[rowIndex].Cells["setNameCol"].Value = item["set_name"];
					if (data.Columns.Contains("location_name")) setDataGrid.Rows[rowIndex].Cells["setUseLoCol"].Value = item["location_name"];
					if (data.Columns.Contains("send_time")) setDataGrid.Rows[rowIndex].Cells["sendTimeCol"].Value = item["send_time"];
					if (data.Columns.Contains("remark")) setDataGrid.Rows[rowIndex].Cells["remarkCol"].Value = item["remark"];
					if (data.Columns.Contains("wf_code")) _pdCode = item["wf_code"] as string;
				}
			}
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnPrintBtnClick(object sender, EventArgs e)
		{
			if (setDataGrid.Rows.Count > 0)
			{
				DataRow[] data = new DataRow[0];
				if (!string.IsNullOrEmpty(_pdCode))
				{
					data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and value_code like '%{0},%'", _pdCode));
				}
				data = data != null && data.Length > 0 ? data : CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and key_code = 'defaultTemplate'"));
				if (data != null && data.Length > 0)
				{
					string pringxml = data[0]["other_code"].ToString().Trim();
					PrintHelper.Instance.Print_DataGridView(setDataGrid, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintData", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

	}
}
