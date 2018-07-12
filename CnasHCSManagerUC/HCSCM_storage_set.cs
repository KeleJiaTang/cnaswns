using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_storage_set : TemplateForm
    {
        DataTable Dataset = new DataTable();
        SortedList sl_data01 = new SortedList();
        SortedList sl_data02 = new SortedList();
        SortedList sl_02data = new SortedList();
		private SortedList sltep = null;
        private string storageid = "";
		private List<GridViewRowInfo> _allRow = new List<GridViewRowInfo>();
        public HCSCM_storage_set(SortedList sltmp)
        {
            InitializeComponent();
			sltep = sltmp;
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            tb_storage.Text = sltmp["s_name"].ToString();
            storageid = sltmp["id"].ToString();
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--配置实体包";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttp = new SortedList();
            slttp.Add(1, CnasBaseData.SystemID);
            slttp.Add(2, sltmp["s_customer"].ToString());
            Dataset = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec025", slttp);
            if (Dataset != null)
            {
                for (int i = 0; i < Dataset.Rows.Count; i++)
                {
                    string s_id = "", s_name = "";
                    if (Dataset.Columns.Contains("id") && Dataset.Rows[i]["id"] != null) s_id = Dataset.Rows[i]["id"].ToString();
					if (Dataset.Columns.Contains("ca_name") && Dataset.Rows[i]["ca_name"] != null) s_name = Dataset.Rows[i]["ca_name"].ToString();
					GridViewRowInfo drtemp01 = null;

					//drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
					//drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
					//drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    //drtemp01.SetValues(false, s_id, s_name);
                    if (Dataset.Rows[i]["storage_id"] != null && Dataset.Rows[i]["storage_id"].ToString() == storageid.ToString())
                    {
						drtemp01 = dgv_02.Rows.AddNew();
						sl_02data.Add(s_id, s_name);
                    }
                    else
                    {
						drtemp01 = dgv_01.Rows.AddNew();
						sl_data01.Add(s_id, s_name);
                    }
					if (drtemp01 != null)
					{
						drtemp01.Cells[0].Value = s_id;
						drtemp01.Cells[1].Value = s_name;
					}
					_allRow.Add(drtemp01);
					drtemp01.Tag = Dataset.Rows[i];
                }
            }
        }


        private void but_addall_Click(object sender, EventArgs e)
        {
			CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
			//if (dgv_01.Rows.Count > 0)
			//{
			//	for (int i = 0; i < dgv_01.Rows.Count; i++)
			//	{
			//		string str_id = "", str_group_name = "";
			//		if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
			//		if (dgv_01.Rows[i].Cells["ca_name"] != null) str_group_name = dgv_01.Rows[i].Cells["ca_name"].Value.ToString();

			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name);
			//		dgv_02.Rows.Add(drtemp01);
			//		sl_data02.Add(str_id, str_group_name);
			//	}
			//	dgv_01.Rows.Clear();//把所有dgv_01行清空
			//	sl_data01.Clear();//把sl_01data清空
			//}
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
			CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
			//if (dgv_01.Rows.Count > 0)
			//{
			//	//SortedList sol_select = new SortedList();
			//	for (int i = 0; i < dgv_01.Rows.Count; i++)
			//	{
			//		//if (bool.Parse(dgv_01.Rows[i].Cells["isselected"].Value.ToString()) == null) continue;
			//		if (dgv_01.Rows[i].Cells["isselected"].Value == null) continue;
			//		string str_id = "", str_group_name = "";
			//		if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
			//		if (dgv_01.Rows[i].Cells["ca_name"] != null) str_group_name = dgv_01.Rows[i].Cells["ca_name"].Value.ToString();
			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name);
			//		dgv_02.Rows.Add(drtemp01);
			//		sl_data02.Add(str_id, str_group_name);
			//	}

			//	dgv_01.Rows.Clear();
			//	sl_data01.Clear();

			//	for (int i = 0; i < Dataset.Rows.Count; i++)
			//	{
			//		string str_id = "", str_group_name = "";
			//		if (Dataset.Columns.Contains("id") && Dataset.Rows[i]["id"] != null) str_id = Dataset.Rows[i]["id"].ToString();
			//		if (Dataset.Columns.Contains("ca_name") && Dataset.Rows[i]["ca_name"] != null) str_group_name = Dataset.Rows[i]["ca_name"].ToString();
			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name);
			//		if (sl_data02.IndexOfKey(str_id) < 0)
			//		{
			//			dgv_01.Rows.Add(drtemp01);
			//			sl_data01.Add(str_id, str_group_name);
			//		}
			//	}
			//}
        }


        private void but_reall_Click(object sender, EventArgs e)
        {
			CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
			//if (dgv_02.Rows.Count > 0)
			//{
			//	for (int i = 0; i < dgv_02.Rows.Count; i++)
			//	{
			//		string str_id = "", str_group_name = "";
			//		if (dgv_02.Rows[i].Cells["id2"] != null) str_id = dgv_02.Rows[i].Cells["id2"].Value.ToString();
			//		if (dgv_02.Rows[i].Cells["ca_name2"] != null) str_group_name = dgv_02.Rows[i].Cells["ca_name2"].Value.ToString();

			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name);
			//		dgv_01.Rows.Add(drtemp01);
			//		sl_data01.Add(str_id, str_group_name);
			//	}
			//	dgv_02.Rows.Clear();//把所有dgv_01行清空
			//	sl_data02.Clear();//把sl_01data清空
			//}
        }

        private void but_reone_Click(object sender, EventArgs e)
        {
			CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
			//if (dgv_02.Rows.Count > 0)
			//{
			//	//添加dgv_01数据
			//	for (int i = 0; i < dgv_02.Rows.Count; i++)
			//	{
			//		if (bool.Parse(dgv_02.Rows[i].Cells["isselected2"].Value.ToString()) == false) continue;
			//		string str_id = "", str_group_name = "";
			//		if (dgv_02.Rows[i].Cells["id2"] != null) str_id = dgv_02.Rows[i].Cells["id2"].Value.ToString();
			//		if (dgv_02.Rows[i].Cells["ca_name2"] != null) str_group_name = dgv_02.Rows[i].Cells["ca_name2"].Value.ToString();
			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name);
			//		dgv_01.Rows.Add(drtemp01);
			//		sl_data01.Add(str_id, str_group_name);
			//	}

			//	dgv_02.Rows.Clear();
			//	sl_data02.Clear();

			//	//刷新dgv_02数据
			//	for (int i = 0; i < Dataset.Rows.Count; i++)
			//	{
			//		string str_id = "", str_group_name = "", str_group_type = "";
			//		if (Dataset.Columns.Contains("id") && Dataset.Rows[i]["id"] != null) str_id = Dataset.Rows[i]["id"].ToString();
			//		if (Dataset.Columns.Contains("ca_name") && Dataset.Rows[i]["ca_name"] != null) str_group_name = Dataset.Rows[i]["ca_name"].ToString();
			//		DataGridViewRow drtemp01 = new DataGridViewRow();
			//		drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
			//		drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
			//		drtemp01.SetValues(false, str_id, str_group_name, str_group_type);
			//		if (sl_data01.IndexOfKey(str_id) < 0)
			//		{
			//			dgv_02.Rows.Add(drtemp01);
			//			sl_data02.Add(str_id, str_group_name);
			//		}
			//	}
			//}
        }

        private void but_save_Click(object sender, EventArgs e)
        {
		
				if (dgv_02.Rows.Count > 0 || dgv_01.Rows.Count > 0)
				{

					SortedList sltmp02 = new SortedList();
					for (int i = 0; i < dgv_02.Rows.Count; i++)
					{

						SortedList sltmp_02 = new SortedList();
						sltmp_02.Add(2, dgv_02.Rows[i].Cells["id2"].Value);
						sltmp_02.Add(1, storageid);
						sltmp02.Add(i + 1, sltmp_02);
					}
					CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-storage-set-add001", sltmp02, null);
					int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-storage-set-add001", sltmp02, null);
					SortedList sltmp03 = new SortedList();
					for (int a = 0; a < dgv_01.Rows.Count; a++)
					{
						SortedList sltmp_03 = new SortedList();
						sltmp_03.Add(1, 0);
						sltmp_03.Add(2, dgv_01.Rows[a].Cells["id"].Value);

						sltmp03.Add(a + 1, sltmp_03);
					}

					string recsql01 = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-storage-set-add001", sltmp03, null);
					int recint01 = reCnasRemotCall.RemotInterface.UPData(3, "HCS-storage-set-add001", sltmp03, null);

					if (recint > -1 && recint01 > -1)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "分配实体包到存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						}
				
	}
}
        private void bt_sel_Click(object sender, EventArgs e)
        {
			//dgv_01.Rows.Clear();

			//foreach (GridViewRowInfo item in _allRow)
			//{
				
			//		if (item != null)
			//		{
			//			if (!dgv_01.Rows.Contains(item) && !dgv_02.Rows.Contains(item) && item.Cells[1].Value.ToString().Contains(tb_set.Text.Trim()))
			//			{
			//				dgv_01.Rows.Add(item);
			//			}
			//		}
				
			//}

			SelData();

        }

		private void SelData()
		{
			dgv_01.Rows.Clear();
			string strsecdata = tb_set.Text.Trim();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			sttemp01.Add(2, sltep["s_customer"].ToString());
			//string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec025", sttemp01);
			List<DataRow> arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' ").ToList();

			for (int y = 0; y < this.dgv_02.Rows.Count; y++)
			{
				string id = this.dgv_02.Rows[y].Cells["id2"].Value.ToString();
				for (int j = 0; j < arrayDR.Count; j++)
				{
					if (arrayDR[j]["id"].ToString().Equals(id))
					{
						arrayDR.Remove(arrayDR[j]);
					}
				}
			}
			int ii = arrayDR.Count;
			if (ii <= 0) return;
			dgv_01.RowCount = ii;
			int i = 0;
			foreach (DataRow dr in arrayDR)
			{
				if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
				if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
				i++;
			}
		}

        private void tb_set_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyValue == 13)
			{
				SelData();
			}
        }

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_addone_Click(null, null);
		}

		private void dgv_02_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_reone_Click(null, null);
		}
    }
}
