using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace Cnas.wns.CnasHCSReporManagerUC
{
	public partial class HCSRM_equipment_service_new : TemplateForm
	{
		private string IsUpdata = "";
		DataRow[] arrayDR = null;
		SortedList SL_type = new SortedList();
		SortedList SL_name = new SortedList();
		public HCSRM_equipment_service_new(SortedList UpDataService)
		{
			InitializeComponent();
			this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--设备维修记录";
			but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
			but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
			arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-equipment-service-type'");
			foreach (DataRow dr in arrayDR)
			{
				SL_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
				this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
			}
			if(UpDataService==null)
			cb_type.Text="1：清洗机";
			if(UpDataService!=null)
			{
				
					
				IsUpdata = UpDataService["id"].ToString();
				if (UpDataService["type"] !=null)
					cb_type.Text = UpDataService["type"].ToString() + "：" + SL_type[UpDataService["type"]].ToString();
				else
					cb_type.Text = string.Empty;
				cb_type_TextChanged(null, null);
				if (UpDataService["type"].ToString()=="4")
				tb_name.Text = UpDataService["equipment_name"].ToString();
				else
			    cb_name.Text = UpDataService["equipment_name"].ToString();
				tb_problem.Text = UpDataService["existing_problem"].ToString();
				tb_solution.Text = UpDataService["cssd_solution"].ToString();
				tb_report.Text = UpDataService["reporter"].ToString();
				tb_service.Text = UpDataService["service_condition"].ToString();
				tb_serviceman.Text = UpDataService["service_penple"].ToString();
				tb_remarks.Text = UpDataService["remark"].ToString();
				tb_accessories.Text = UpDataService["change_accessories"].ToString();
				tb_accepted.Text = UpDataService["auditor"].ToString();
				
			}
		}
		
		private void but_ok_Click(object sender, EventArgs e)
		{
			if (tb_name.Visible == true)
			{
				if (tb_name.Text.Trim() == "")
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "设备" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if(cb_name.Visible==true)
			{
				if (cb_name.Text.Trim() == "")
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "设备" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if(tb_report.Text.Trim()=="")
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "报告人" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string Name = null;
			int nameType = 0;
			if (cb_name.Visible == true)
			{
				Name = cb_name.Text;
				nameType = SL_name.IndexOfValue(cb_name.Text);
			}
			else if (tb_name.Visible == true)
			{
				Name = tb_name.Text;
				nameType=0;
			}
			if(IsUpdata=="")
			{
				SortedList AddData = new SortedList();
				SortedList AddData01 = new SortedList();
				AddData.Add(1,Name);
				AddData.Add(2,tb_problem.Text.Trim());
				AddData.Add(3,tb_solution.Text.Trim());
				AddData.Add(4,tb_report.Text.Trim());
				AddData.Add(5,tb_accepted.Text.Trim());
				AddData.Add(6,tb_serviceman.Text.Trim());
				AddData.Add(7,tb_service.Text.Trim());
				AddData.Add(8,tb_accessories.Text.Trim());
				AddData.Add(9, tb_remarks.Text.Trim());
				AddData.Add(10, cb_type.Text.Substring(0,1));
				AddData.Add(11, nameType);
				AddData01.Add(1,AddData);
				int AddService = reCnasRemotCall.RemotInterface.UPData(1,"HCS-equipment-service-add001", AddData01,null);
				if(AddService>-1)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "设备维修记录" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Close();
				}
			}
			else
			{
				SortedList UpData = new SortedList();
				SortedList UpData01 = new SortedList();
				UpData.Add(1, Name);
				UpData.Add(2, tb_problem.Text.Trim());
				UpData.Add(3, tb_solution.Text.Trim());
				UpData.Add(4, tb_report.Text.Trim());
				UpData.Add(5, tb_accepted.Text.Trim());
				UpData.Add(6, tb_serviceman.Text.Trim());
				UpData.Add(7, tb_service.Text.Trim());
				UpData.Add(8, tb_accessories.Text.Trim());
				UpData.Add(9, tb_remarks.Text.Trim());
				UpData.Add(10, cb_type.Text.Substring(0, 1));
				UpData.Add(11, nameType);
				UpData.Add(12, IsUpdata);
				
				UpData01.Add(1,UpData);
				string ss = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-equipmen-service-up001", UpData01, null);
				int UpDataService = reCnasRemotCall.RemotInterface.UPData(1, "HCS-equipmen-service-up001", UpData01, null);
				if(UpDataService>-1)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "设备维修记录" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}

			}
		}

		private void but_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cb_type_TextChanged(object sender, EventArgs e)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList slttmp = new SortedList();
			slttmp.Add(1, CnasBaseData.SystemID);
			if (cb_type.Text != string.Empty)
			{
				int DeviceType = int.Parse(cb_type.Text.Substring(0, 1));
				if (DeviceType == 1 || DeviceType == 2 || DeviceType == 3)
				{
					lb_name.Visible = false;
					lb_cbname.Visible = true;
					tb_name.Visible = false;
					cb_name.Visible = true;
					lb_2.Visible = false;
					lb_1.Visible = true;
					cb_name.Items.Clear();
					SL_name.Clear();
					if (DeviceType == 1)
					{
						//string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec004", sl_type);
						DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-washing-device-sec001", slttmp);
						if (getdt != null && getdt.Rows.Count > 0)
						{
							for (int i = 0; i < getdt.Rows.Count; i++)
							{
								SL_name.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString());
								cb_name.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
							}
						}
					}
					else if (DeviceType == 2)
					{
						//string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec004", sl_type);
						DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-sterilizer-device-sec001", slttmp);
						if (getdt != null && getdt.Rows.Count > 0)
						{
							for (int i = 0; i < getdt.Rows.Count; i++)
							{
								SL_name.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString());
								cb_name.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
							}
						}
					}
					else if (DeviceType == 3)
					{

						//string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec004", sl_type);
						DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-device-sec001", slttmp);
						if (getdt != null && getdt.Rows.Count > 0)
						{
							for (int i = 0; i < getdt.Rows.Count; i++)
							{
								SL_name.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString());
								cb_name.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
							}
						}
					}
				}
				else if (DeviceType == 4)
				{
					lb_cbname.Visible = false;
					lb_name.Visible = true;
					cb_name.Visible = false;
					tb_name.Visible = true;
					lb_1.Visible = false;
					lb_2.Visible = true;
				}
			}
		}
	}
}
