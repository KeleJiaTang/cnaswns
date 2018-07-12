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
using System.Collections.Generic;
using System.Linq;

namespace Cnas.wns.CnasHCSSystemUC
{
	public partial class HCSSM_usergroup_location : TemplateForm
	{
		DataTable getdt = null;
		DataTable DTlocation = null;
		DataTable DTremove= null;
		DataTable locationed = null;
		SortedList sl_customer = new SortedList();
		SortedList Sl_location = new SortedList();
		SortedList userid = new SortedList();
		SortedList usergroup = null;
		SortedList Sl_locationbarcode = new SortedList();
		private SortedList sl_01data = new SortedList();
		private SortedList customerID = new SortedList();
		bool existsadd;
		bool existsupdate;
		bool existsadd01;
		public HCSSM_usergroup_location(SortedList userGroup)
		{
			InitializeComponent();
			this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
			this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
			this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
			this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
			this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
			//this.Font = new Font(this.Font.FontFamily, 11);
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--配置使用地点";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			usergroup = userGroup;
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			string qw = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec001", null);
			DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
			if (DTlocation != null)
			{
				int ii = DTlocation.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
					{
						Sl_location.Add(DTlocation.Rows[i]["id"].ToString().Trim(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
						Sl_locationbarcode.Add(DTlocation.Rows[i]["id"].ToString().Trim(), DTlocation.Rows[i]["u_barcode"].ToString().Trim());
					}
				}
			}

			getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec001", sttemp01);
			if (getdt != null)
			{
				int ii = getdt.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString() != null)
						cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString());
					sl_customer.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
				}
				cb_customer.Text = cb_customer.Items[0].Text;
			}

			userid.Add(1, userGroup["groupid"].ToString());
			string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-usergroup-location-sec002", userid);
			DTremove = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup-location-sec002", userid);
			locationed = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup-location-sec001", userid);
			if (locationed != null)
			{
				int aa = locationed.Rows.Count;
				if (aa <= 0) return;
				dgv_02.RowCount = aa;
				for (int i = 0; i < aa; i++)
				{
					if (locationed.Columns.Contains("location_id") && !string.IsNullOrEmpty(locationed.Rows[i]["location_id"].ToString())) dgv_02.Rows[i].Cells["id2"].Value = locationed.Rows[i]["location_id"].ToString();
					if (locationed.Columns.Contains("location_id") && !string.IsNullOrEmpty(locationed.Rows[i]["location_id"].ToString())) dgv_02.Rows[i].Cells["barcode2"].Value = Sl_locationbarcode[locationed.Rows[i]["location_id"].ToString()].ToString();
					if (locationed.Columns.Contains("location_id") && !string.IsNullOrEmpty(locationed.Rows[i]["location_id"].ToString())) dgv_02.Rows[i].Cells["location2"].Value = Sl_location[locationed.Rows[i]["location_id"].ToString()].ToString();
				}
				if(aa>0)
				{
					dgv_02.CurrentRow = dgv_02.Rows[0];
				}
				cb_customer.Text = sl_customer[locationed.Rows[0]["customer_id"].ToString()].ToString();
				cb_customer_TextChanged(null, null);
			}
			enable();
		}

		private void cb_customer_TextChanged(object sender, EventArgs e)
		{
			dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			customerID.Clear();
			sl_01data.Clear();
			customerID.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));
			DataTable LocationData = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec0010", customerID);
			if (LocationData != null)
			{
				
				for (int i = 0; i < LocationData.Rows.Count; i++)
				{
					string str_id = "", str_name = "", str_barcode = "";
					if (LocationData.Columns.Contains("id") && LocationData.Rows[i]["id"] != null) str_id = LocationData.Rows[i]["id"].ToString();
					if (LocationData.Columns.Contains("u_uname") && LocationData.Rows[i]["u_uname"] != null) str_name = LocationData.Rows[i]["u_uname"].ToString();
					if (LocationData.Columns.Contains("u_barcode") && LocationData.Rows[i]["u_barcode"] != null) str_barcode = LocationData.Rows[i]["u_barcode"].ToString();
					GridViewRowInfo drtemp01 = null;
						drtemp01 = dgv_01.Rows.AddNew();
					if (drtemp01 != null)
					{
						drtemp01.Cells[0].Value = false;
						drtemp01.Cells[1].Value = str_id;
						drtemp01.Cells[2].Value = str_barcode;
						drtemp01.Cells[3].Value = str_name;
					}

					drtemp01.Tag = LocationData.Rows[i];
					
				}
				if (dgv_01.RowCount > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
				for (int y = 0; y < this.dgv_02.Rows.Count; y++)
				{
					string barcode = this.dgv_02.Rows[y].Cells["barcode2"].Value.ToString();
					for (int j = 0; j < dgv_01.Rows.Count; j++)
					{
						if (dgv_01.Rows[j].Cells["barcode"].Value.ToString()==barcode)
						{
							dgv_01.Rows.Remove(dgv_01.Rows[j]);
						}
					}
				}
			}
		}

		private void enable()
		{
			if (dgv_02.Rows.Count > 0)
			{
				cb_customer.Enabled = false;
			}
			else
			{
				cb_customer.Enabled = true;
			}
		}
		private void but_addall_Click(object sender, EventArgs e)
		{
			CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
			enable();
		}

		private void but_addone_Click(object sender, EventArgs e)
		{
			CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
			enable();
		}

		private void but_reone_Click(object sender, EventArgs e)
		{
			CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
			enable();
		}

		private void but_reall_Click(object sender, EventArgs e)
		{
			CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
			enable();
		}

		private void but_save_Click(object sender, EventArgs e)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			if (dgv_02.Rows.Count == 0)
			{
				if (locationed != null)
				{
					SortedList delLocation = new SortedList();
					SortedList delLocation01 = new SortedList();
					delLocation.Add(1, usergroup["groupid"].ToString());
					delLocation01.Add(1, delLocation);
					int reint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup-location-del001", delLocation01, null);
					if (reint > -1)
					{
						MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "群组配置使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						return;
					}
				}
			}
			else
			{
				SortedList AddData = new SortedList();
				SortedList AddData_01 = new SortedList();
				SortedList AddData01 = new SortedList();
				SortedList AddData02 = new SortedList();
				AddData.Add(1, usergroup["groupid"].ToString());
				for (int i = 0; i < dgv_02.Rows.Count; i++)
				{
					SortedList AddLocation = new SortedList();
					AddLocation.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())));
					AddLocation.Add(2, dgv_02.Rows[i].Cells["id2"].Value.ToString());
					AddLocation.Add(3, usergroup["groupid"].ToString());
					AddLocation.Add(4, CnasBaseData.UserID);
					AddData01.Add(i + 1, AddLocation);
				}
				AddData_01.Add(1, AddData);
				AddData02.Add(1, AddData_01);
				AddData02.Add(2, AddData01);



                //Cnas.wns.CnasBaseClassServer.CnasServerMethods csm = new CnasBaseClassServer.CnasServerMethods();
                string ii = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-usergroup-location-add001", AddData02);

                
				string pp = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-usergroup-location-add001", AddData02);



				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-usergroup-location-add001", AddData02);
				if (recint > -1)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "群组配置使用地点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
					return;
				}
			}
		}
	}
}
