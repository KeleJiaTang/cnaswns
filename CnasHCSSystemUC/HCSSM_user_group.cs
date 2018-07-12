using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;


namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_user_group: UserControl
    {
        private SortedList sl_gptype = new SortedList();
        public HCSSM_user_group()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
			this.radButton5.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "personnel", EnumImageType.PNG);
			this.but_location.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Location", EnumImageType.PNG);
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach (DataRow dr in arrayDR)
            {
                sl_gptype.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());                
            }
            LoadData();
            if (dgv_01.RowCount > 0)
            {
                dgv_01.Rows[0].IsSelected = true;
            }
            
        }

        private void but_new_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadData()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup-sec001", sttemp01);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
					if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("group_name") && !string.IsNullOrEmpty(getdt.Rows[i]["group_name"].ToString())) dgv_01.Rows[i].Cells["group_name"].Value = getdt.Rows[i]["group_name"].ToString();
					if (getdt.Columns.Contains("group_type") && !string.IsNullOrEmpty(getdt.Rows[i]["group_type"].ToString()))
                    { 
                        string strgroup_type=getdt.Rows[i]["group_type"].ToString().Trim();
                        dgv_01.Rows[i].Cells["group_type"].Value = strgroup_type;
                        dgv_01.Rows[i].Cells["group_typename"].Value = sl_gptype[strgroup_type].ToString();
                    
                    }
					if (getdt.Columns.Contains("group_bcode") && !string.IsNullOrEmpty(getdt.Rows[i]["group_bcode"].ToString())) dgv_01.Rows[i].Cells["group_bcode"].Value = getdt.Rows[i]["group_bcode"].ToString();
					if (getdt.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
					if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString())) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
					if (getdt.Columns.Contains("group_description") && !string.IsNullOrEmpty(getdt.Rows[i]["group_description"].ToString())) dgv_01.Rows[i].Cells["group_description"].Value = getdt.Rows[i]["group_description"].ToString();
                }
                if (ii > 0)
                {

                }
            }
			dgv_01.CurrentRow = dgv_01.Rows[0];
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
             SortedList slindata = new SortedList();
			 int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
            slindata.Add("group_name", dgv_01.SelectedRows[0].Cells["group_name"].Value);
            slindata.Add("group_typename", dgv_01.SelectedRows[0].Cells["group_typename"].Value);
            slindata.Add("group_description", dgv_01.SelectedRows[0].Cells["group_description"].Value);
            HCSSM_user_group_new hcsm = new HCSSM_user_group_new(slindata);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (CnasBaseData.If_LoadData == 1)
            {
                LoadData();
                CnasBaseData.If_LoadData = 0;
            }
			if (dgv_01.Rows.Count > selectedIndex)
			{
				dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
			}
            
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
           
        }

        private void but_authority_Click(object sender, EventArgs e)
        {
        }

        private void but_user_Click(object sender, EventArgs e)
        {
        }

        private void but_export_Click(object sender, EventArgs e)
        {
            
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='usergroup'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            //PrintHelper.Instance.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            HCSSM_user_group_new hcsm = new HCSSM_user_group_new(null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (CnasBaseData.If_LoadData == 1)
            {
                LoadData();
                CnasBaseData.If_LoadData = 0;
            }
        }

        private void but_edit_Click_1(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一行数据。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList slindata = new SortedList();
            slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
            slindata.Add("group_name", dgv_01.SelectedRows[0].Cells["group_name"].Value);
            slindata.Add("group_typename", dgv_01.SelectedRows[0].Cells["group_typename"].Value);
            slindata.Add("group_description", dgv_01.SelectedRows[0].Cells["group_description"].Value);
            HCSSM_user_group_new hcsm = new HCSSM_user_group_new(slindata);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (CnasBaseData.If_LoadData == 1)
            {
                LoadData();
                CnasBaseData.If_LoadData = 0;
            }          
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一行数据。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定删除编号为： " + dgv_01.SelectedRows[0].Cells["id"].Value.ToString() + " 的群组吗？", "删除群组", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp01.Add(2, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，删除群组成功。");
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

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "用户列表");
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='usergroup'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(dgv_01, pringxml);
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if(dgv_01.SelectedRows.Count==0)
            {
                MessageBox.Show("请选择一行数据。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            string str_group_name = dgv_01.SelectedRows[0].Cells["group_name"].Value.ToString();
            string str_group_typename = dgv_01.SelectedRows[0].Cells["group_typename"].Value.ToString();
            HCSSM_user_group_app hctmp = new HCSSM_user_group_app(str_id, str_group_name, str_group_typename);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hctmp.ShowInTaskbar = false;
            hctmp.ShowDialog();
            if (CnasBaseData.If_LoadData == 1)
            {
                LoadData();
                CnasBaseData.If_LoadData = 0;
            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一行数据。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
                string str_group_name = dgv_01.SelectedRows[0].Cells["group_name"].Value.ToString();
                string str_group_typename = dgv_01.SelectedRows[0].Cells["group_typename"].Value.ToString();
                HCSSM_user_group_user hctmp = new HCSSM_user_group_user(str_id, str_group_name, str_group_typename);
                hctmp.ShowDialog();
                if (CnasBaseData.If_LoadData == 1)
                {
                    LoadData();
                    CnasBaseData.If_LoadData = 0;
                }
            }
            catch
            {
                MessageBox.Show("请选择用户群组", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }

        private void dgv_01_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}

		private void but_location_Click(object sender, EventArgs e)
		{
			SortedList userGroup = new SortedList();
			if(dgv_01.SelectedRows.Count>0)
			{
				userGroup.Add("groupname", dgv_01.SelectedRows[0].Cells["group_name"].Value.ToString());
				userGroup.Add("groupid", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
			}else
			{
				MessageBox.Show("请选择群组。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			HCSSM_usergroup_location HCSSM = new HCSSM_usergroup_location(userGroup);
			HCSSM.ShowDialog();
		}
    }
}
