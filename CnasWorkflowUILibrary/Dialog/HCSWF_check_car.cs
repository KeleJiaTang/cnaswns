using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSManagerUC;
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
	public partial class HCSWF_check_car : BaseForm
	{
		public HCSWF_check_car()
		{
			InitializeComponent();
		}

		public HCSWF_check_car(string pdCode,SortedList scanBarCodelist) 
			: base(pdCode)
		{
			ScanBarCodes = scanBarCodelist;
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public override void InitializeButtonImage()
		{
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			btnPri.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			//searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();

			RefreshDataGrid();
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void RefreshDataGrid()
		{
			SortedList condition = new SortedList();
			condition.Add(1, PdCode);
			condition.Add(2, "0");

			string setBarCodes = BarCodeHelper.GetBarCodeByType("BCD", ScanBarCodes);
			if (string.IsNullOrEmpty(setBarCodes)) return;
			setBarCodes = setBarCodes.Replace(",", "','");
			if (!setBarCodes.Contains("','"))
			{
				SortedList paraCondition = new SortedList();
				paraCondition.Add(1, 1);
				paraCondition.Add(2, setBarCodes);
				paraCondition.Add(3, CnasBaseData.SystemID);
				string testParaSql = RemoteClient.RemotInterface.CheckSelectData("HCS-transport-device-sec003", paraCondition);
				DataTable dataPara = RemoteClient.RemotInterface.SelectData("HCS-transport-device-sec003", paraCondition);
				if(dataPara!=null&&dataPara.Rows.Count>0)
				{
					carNameTxt.Text =Convert.ToString(dataPara.Rows[0]["ca_name"]);
				}
			}
			condition.Add(3, setBarCodes);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec005", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec005", condition);

			if (data != null)
			{
				foreach (DataRow item in data.Rows)
				{
					DataConverter.ConvertSetData(setDataGrid, item);
				}
				setNumTxt.Text = setDataGrid.RowCount.ToString();
			}
		}

		/// <summary>
		/// 打印
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPri_Click(object sender, EventArgs e)
		{
			DataGridView dataGrid = setDataGrid;
			if (dataGrid != null)
			{
				DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and value_code like '%{0},%'", PdCode));
				data = data != null && data.Length > 0 ? data : CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and key_code = 'defaultTemplate'"));
				if (data != null && data.Length > 0)
				{
					string pringxml = data[0]["other_code"].ToString().Trim();
					PrintHelper.Instance.Print_DataGridView(dataGrid, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
