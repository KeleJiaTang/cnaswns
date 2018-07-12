using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_user : UserControl
    {
        private SortedList sl_usertype = new SortedList();
        private SortedList sl_location = new SortedList();
        private SortedList sl_customer = new SortedList();//客户集合
        private SortedList sl_department = new SortedList();//部门集合
        DataTable DTlocation = null;
        private string strbarcodexml = "";

		public HCSSM_user()
		{
			InitializeComponent();
			this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
			this.but_barcode.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
			this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
			this.but_userg.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "groupPermissions", EnumImageType.PNG);
			#region 获取用户类型
			DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_user_type'");
			foreach (DataRow dr in arrayDR)
			{
				sl_usertype.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
				cb_usertype.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());
			}
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
			if (DTlocation != null)
			{
				int ii = DTlocation.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
					{
						sl_location.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
					}
				}
			}
			#endregion

			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec002", null);//部门
			if (getdt != null)
			{
				int ii = getdt.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
					{
						sl_department.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
					}
				}
				getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
				if (getdt != null)
				{
					int aa = getdt.Rows.Count;
					if (aa <= 0) return;
					for (int i = 0; i < aa; i++)
					{
						if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
						{
							sl_customer.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
						}
					}
				}
			}

			if (cb_usertype.Items.Count > 0)
			{
				cb_usertype.SelectedIndex = 0;
			}
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCB'");
			strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
		}	

        private void cs_select_UserRadioButtonSelect(object sender, EventArgs e, string infodata)
        {
            MessageBox.Show(infodata);
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
			if (dgv_01.CurrentRow == null)
			{
				MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("确定删除用户： " + dgv_01.SelectedRows[0].Cells["user_name"].Value.ToString() + " 的用户吗？", "删除用户", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-userdata-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，删除用户成功。");

                dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                if (dgv_01.Rows.Count > 0)
                {
                    if (selectedIndex == 0)//删除后判断是否为0
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                    else
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex - 1];
                    }
                }
            }
        }

        private void but_update_Click(object sender, EventArgs e)
        {
			if (dgv_01.CurrentRow != null && dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0)
            {
				int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList slindata = new SortedList();
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slindata.Add("user_name", dgv_01.SelectedRows[0].Cells["user_name"].Value);
                slindata.Add("user_bcode", dgv_01.SelectedRows[0].Cells["user_bcode"].Value);
                slindata.Add("user_eid", dgv_01.SelectedRows[0].Cells["user_eid"].Value);
                slindata.Add("user_nick", dgv_01.SelectedRows[0].Cells["user_nick"].Value);
                slindata.Add("user_type", dgv_01.SelectedRows[0].Cells["user_type"].Value);
                slindata.Add("location_id", sl_location.GetKey(sl_location.IndexOfValue(dgv_01.SelectedRows[0].Cells["location_id"].Value)));
                slindata.Add("customer_id", dgv_01.SelectedRows[0].Cells["customer_id"].Value);
                slindata.Add("department_id", dgv_01.SelectedRows[0].Cells["department_id"].Value);
                slindata.Add("sex", dgv_01.SelectedRows[0].Cells["sex"].Value);
				slindata.Add("age", dgv_01.SelectedRows[0].Cells["age"].Value);
				slindata.Add("pic", dgv_01.SelectedRows[0].Cells["user_img"].Value);
                HCSSM_user_new hcsm = new HCSSM_user_new(slindata, sl_usertype);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改用户";
                hcsm.ShowDialog();
				GetData();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}

            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void but_new_Click_1(object sender, EventArgs e)
        {
            HCSSM_user_new hcsm = new HCSSM_user_new(null, sl_usertype);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();

			GetData();
        }

        private void but_barcode_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.CurrentRow == null)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["user_bcode"].Value != null ?
					dgv_01.CurrentRow.Cells["user_bcode"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["user_name"].Value != null ?
					dgv_01.CurrentRow.Cells["user_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("P013", codeName);

					string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void radButton3_Click_1(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='user'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "用户管理");
        }

        private void but_userg_Click(object sender, EventArgs e)
        {
            try
            {
                //获取你选中数据表这一行的ID，储存在str_id上。
                string str_id = dgv_01.CurrentRow.Cells["id"].Value.ToString();
                string str_user_name = dgv_01.CurrentRow.Cells["user_name"].Value.ToString();
                HCSSM_usergroup hctmp = new HCSSM_usergroup(str_id, str_user_name);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hctmp.ShowInTaskbar = false;
                hctmp.ShowDialog();
                if (CnasBaseData.If_LoadData == 1)
                {
                    GetData();
                    CnasBaseData.If_LoadData = 0;
                }
            }
            catch
            {
                MessageBox.Show("请选择用户。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cb_usertype_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
			GetData();
        }

        private void dgv_01_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }
		private void GetData()
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			DataTable dtUsers = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);
			dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
			if (dtUsers == null || dtUsers.Rows.Count == 0) return;
			string strsecdata = tb_name.Text.Trim();
			string str_usertp = cb_usertype.Text.Substring(0, 1);
			DataRow[] arrayDR = null;
			if (str_usertp == "0")
			{
				 arrayDR = dtUsers.Select("user_type>0  and ( user_name like '%" + strsecdata + "%' or user_nick like '%" + strsecdata + "%')");
			}
			else
			{
				 arrayDR = dtUsers.Select("user_type=" + str_usertp + " and ( user_name like '%" + strsecdata + "%' or user_nick like '%" + strsecdata + "%')");
			}
			int ii = arrayDR.Length;
			if (ii <= 0) return;
			foreach (DataRow dr in arrayDR)
			{
				GridViewRowInfo row = dgv_01.Rows.AddNew();
				if (dtUsers.Columns.Contains("id") && !string.IsNullOrEmpty(dr["id"].ToString())) row.Cells["id"].Value = dr["id"].ToString();
				if (dtUsers.Columns.Contains("user_name") && !string.IsNullOrEmpty(dr["user_name"].ToString())) row.Cells["user_name"].Value = dr["user_name"].ToString();
				if (dtUsers.Columns.Contains("user_bcode") && !string.IsNullOrEmpty(dr["user_bcode"].ToString())) row.Cells["user_bcode"].Value = dr["user_bcode"].ToString();
				if (dtUsers.Columns.Contains("user_eid") && !string.IsNullOrEmpty(dr["user_eid"].ToString())) row.Cells["user_eid"].Value = dr["user_eid"].ToString();
				if (dtUsers.Columns.Contains("user_nick") && !string.IsNullOrEmpty(dr["user_nick"].ToString())) row.Cells["user_nick"].Value = dr["user_nick"].ToString();
				if (dtUsers.Columns.Contains("sex") && !string.IsNullOrEmpty(dr["sex"].ToString())) row.Cells["sex"].Value = dr["sex"].ToString();
				if (dtUsers.Columns.Contains("age") && !string.IsNullOrEmpty(dr["age"].ToString())) row.Cells["age"].Value = dr["age"].ToString();
				if (dtUsers.Columns.Contains("cre_date") && !string.IsNullOrEmpty(dr["cre_date"].ToString())) row.Cells["cre_date"].Value = dr["cre_date"].ToString();
				if (dtUsers.Columns.Contains("mod_date") && !string.IsNullOrEmpty(dr["mod_date"].ToString())) row.Cells["mod_date"].Value = dr["mod_date"].ToString();
				if (dtUsers.Columns.Contains("user_img") && !string.IsNullOrEmpty(dr["user_img"].ToString())) row.Cells["user_img"].Value = dr["user_img"].ToString();
				if (dtUsers.Columns.Contains("location_id") && !string.IsNullOrEmpty(dr["location_id"].ToString())) row.Cells["location_id"].Value = sl_location[dr["location_id"].ToString()].ToString();
				if (dtUsers.Columns.Contains("customer_id") && !string.IsNullOrEmpty(dr["customer_id"].ToString())) row.Cells["customer_id"].Value = sl_customer[dr["customer_id"].ToString()].ToString();
				if (dtUsers.Columns.Contains("location_id") && !string.IsNullOrEmpty(dr["location_id"].ToString())) row.Cells["department_id"].Value = sl_department[dr["department_id"].ToString()].ToString();
				if (dtUsers.Columns.Contains("user_type") && !string.IsNullOrEmpty(dr["user_type"].ToString()))
				{
					row.Cells["user_type"].Value = dr["user_type"].ToString();
					row.Cells["user_typename"].Value = sl_usertype[dr["user_type"].ToString()].ToString();
				}
			}

			if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}

        private void tb_name_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
				GetData();
            } 
        }

		private void OnGridDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

        private void OnGridDoubleClick(object sender, GridViewCellEventArgs e)
        {
            but_update_Click(null, null);
        }

		private void radButton1_Click(object sender, EventArgs e)
		{
			GetData();
		}

    }
}
