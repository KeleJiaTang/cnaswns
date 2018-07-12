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
	public partial class HCSWF_set_choose : BaseForm
	{
		public SortedList SelectItems = new SortedList();

		public HCSWF_set_choose(string pdCode)
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

			SetPriortyCbxValue();
			RefreshDataGrid(GetSetInfos());
		}

		private void SetPriortyCbxValue()
		{
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_priority_type'");
			if (data != null && data.Length > 0)
			{
				string selectPriorty = string.Empty;
				foreach (DataRow item in data)
				{
					if (item["type_code"] != null)
					{
						KeyValuePair<string, string> comboboxItem = new KeyValuePair<string, string>(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
						setPriortyCbx.Items.Add(comboboxItem);
					}
				}
				KeyValuePair<string, string> defaultItem = new KeyValuePair<string, string>("0", "--所有--");
				setPriortyCbx.Items.Insert(0, defaultItem);
				setPriortyCbx.SelectedIndex = 0;
			}
		}

		private DataTable GetSetInfos()
		{
			SortedList condition = new SortedList();
			condition.Add(1, PdCode);
			condition.Add(2, "0");
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec002", condition);
			return data;
		}

		private void RefreshDataGrid(DataTable data)
		{
			if (data != null)
			{
				foreach (DataRow item in data.Rows)
				{
					if ((string.IsNullOrEmpty(setNameTxt.Text) || (item["ca_name"] != null && item["ca_name"].ToString().Contains(setNameTxt.Text)))
						&& (string.IsNullOrEmpty(setbarCodeTxt.Text) || (item["bar_code"] != null && item["bar_code"].ToString().Contains(setbarCodeTxt.Text)))
						&& (setPriortyCbx.SelectedIndex <= 0 || (item["pa_priorty"] != null && item["pa_priorty"].ToString() == ((KeyValuePair<string, string>)setPriortyCbx.SelectedItem).Value)))
					{
						DataConverter.ConvertSetData(setDataGrid, item);
					}
				}
			}
		}

		private void OnConfirmBtnClick(object sender, EventArgs e)
		{
			SelectItems.Clear();
			if (setDataGrid.SelectedRows != null)
			{
				for (int i = 0; i < setDataGrid.SelectedRows.Count; i++)
				{
					SelectItems.Add(i, setDataGrid.SelectedRows[i].Tag);
				}
			}
			Close();
		}

		private void searchBtn_Click(object sender, EventArgs e)
		{
			setDataGrid.Rows.Clear();
			RefreshDataGrid(GetSetInfos());
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
