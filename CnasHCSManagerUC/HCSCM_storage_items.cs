using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;


namespace Cnas.wns.CnasHCSManagerUC
{
	public partial class HCSCM_storage_items : TemplateForm
	{
		DataTable DataInstrument = new DataTable();
		SortedList sl_ins = new SortedList();
		SortedList sl_data01 = new SortedList();
		SortedList sl_data02 = new SortedList();
		SortedList sl_02data = new SortedList();
		SortedList sltep = null;
        private List<GridViewRowInfo> _allRow = new List<GridViewRowInfo>();
		private string storageid = "";
		public HCSCM_storage_items(SortedList slttp)
		{
			InitializeComponent();
			sltep = slttp;
			this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
			this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
			this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
			this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
			this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
			//设置窗体图标
			this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			//this.Font = new Font(this.Font.FontFamily, 11);
			this.Text = ConfigurationManager.AppSettings["SystemName"] + "--配置器械";
			tb_storage.Text = slttp["s_name"].ToString();
			storageid = slttp["id"].ToString();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList slttmp = new SortedList();
			slttmp.Add(1, slttp["s_customer"].ToString());

			DataInstrument = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-instrument-sec001", slttmp);
            //if (DataInstrument != null)
            //{
            //    for (int i = 0; i < DataInstrument.Rows.Count; i++)
            //    {
            //        string ins_id = "", ins_name = "", storage_id = string.Empty;
            //        if (DataInstrument.Columns.Contains("id") && DataInstrument.Rows[i]["id"] != null) ins_id = DataInstrument.Rows[i]["id"].ToString();
            //        //if (DataInstrument.Rows[i]["storage_id"] != null) storage_id = DataInstrument.Rows[i]["storage_id"].ToString();
            //        if (DataInstrument.Columns.Contains("base_name") && DataInstrument.Rows[i]["base_name"] != null) ins_name = DataInstrument.Rows[i]["base_name"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();

            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, ins_id, ins_name);
            //        if (DataInstrument.Rows[i]["storage_id"] != null && DataInstrument.Rows[i]["storage_id"].ToString() == storageid.ToString())
            //        {
            //            dgv_02.Rows.Add(drtemp01);
            //            sl_02data.Add(ins_id, ins_name);
            //        }
            //        else
            //        {
            //            dgv_01.Rows.Add(drtemp01);
            //            sl_data01.Add(ins_id, ins_name);
            //        }
            //        _allRow.Add(drtemp01);
            //    }
            //}
            if (DataInstrument != null)
            {
                for (int i = 0; i < DataInstrument.Rows.Count; i++)
                {
                    string str_id = "", str_app_name = "";
                    if (DataInstrument.Columns.Contains("id") && DataInstrument.Rows[i]["id"] != null) str_id = DataInstrument.Rows[i]["id"].ToString();
                    if (DataInstrument.Columns.Contains("base_name") && DataInstrument.Rows[i]["base_name"] != null) str_app_name = DataInstrument.Rows[i]["base_name"].ToString();

                    GridViewRowInfo drtemp01 = null;
                    //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id                     
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    //drtemp01.SetValues(false, str_id, str_app_name);
                    if (DataInstrument.Rows[i]["storage_id"] != null && DataInstrument.Rows[i]["storage_id"].ToString() == storageid.ToString())
                    {
                        drtemp01 = dgv_02.Rows.AddNew();
                        sl_02data.Add(str_id, str_app_name);

                    }
                    else
                    {
                      
                            drtemp01 = dgv_01.Rows.AddNew();
                            sl_data01.Add(str_id, str_app_name);
                        
                    }
                    if (drtemp01 != null)
                    {
                        drtemp01.Cells[0].Value = str_id;
                        drtemp01.Cells[1].Value = str_app_name;
                    }
                    _allRow.Add(drtemp01);
                    drtemp01.Tag = DataInstrument.Rows[i];
                }
            }
		}
        private void but_addall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
        }

        private void but_reone_Click(object sender, EventArgs e)
        {

            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
        }

        private void but_reall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
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
				//string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-storage-instrument-add001", sltmp02, null);
				int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-storage-instrument-add001", sltmp02, null);

				SortedList sltmp03 = new SortedList();
				for (int a = 0; a < dgv_01.Rows.Count; a++)
				{
					SortedList sltmp_03 = new SortedList();
					sltmp_03.Add(1, "NULL");
					sltmp_03.Add(2, dgv_01.Rows[a].Cells["id"].Value);

					sltmp03.Add(a + 1, sltmp_03);
				}

				//string recsql01 = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-storage-instrument-add001", sltmp03, null);
				int recint01 = reCnasRemotCall.RemotInterface.UPData(3, "HCS-storage-instrument-add001", sltmp03, null);

				if (recint > -1 && recint01 > -1)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "分配器械到存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("没有移动器械到存储点。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void bt_sel_Click(object sender, EventArgs e)
		{
			SelData();
		}

		private void tb_instrument_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				SelData();
				//dgv_01.Rows.Clear();

				//foreach (GridViewRowInfo item in _allRow)
				//{


				//	if (!dgv_01.Rows.Contains(item) && !dgv_02.Rows.Contains(item) && item.Cells[1].Value.ToString().Contains(tb_instrument.Text.Trim()))
				//	{
				//		dgv_01.Rows.Add(item);
				//	}
				//}
			}
		}


		private void SelData()
		{
			dgv_01.Rows.Clear();
			string strsecdata = tb_instrument.Text.Trim();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			//sttemp01.Add(1, CnasBaseData.SystemID);
			sttemp01.Add(1, sltep["s_customer"].ToString());
			//string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-instrument-sec001", sttemp01);
			if (getdt == null) return;
			List<DataRow> arrayDR = getdt.Select(" base_name like '%" + strsecdata + "%' ").ToList();

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
				if (getdt.Columns.Contains("base_name") && getdt.Rows[i]["base_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["base_name"].ToString();
				i++;
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
        
 