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
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_performance_appraisal_select : TemplateForm
    {
        private SortedList sl_usertype = new SortedList();
        public SortedList sl_userinfo = new SortedList();
        public HCSRS_performance_appraisal_select()
        {
            InitializeComponent();
            this.but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
			this.closeBtn.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--用户列表";
           
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_user_type'");
            foreach (DataRow dr in arrayDR)
            {
                sl_usertype.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            Loaddata();
        }
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-userdata-sec002", sttemp01);
            DataTable dtUsers = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);
            if (dtUsers != null)
            {
                int ii = dtUsers.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {

                    if (dtUsers.Columns.Contains("id") && dtUsers.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dtUsers.Rows[i]["id"].ToString();
					if (dtUsers.Columns.Contains("user_name") && dtUsers.Rows[i]["user_name"] != null) dgv_01.Rows[i].Cells["user_name"].Value = dtUsers.Rows[i]["user_name"].ToString();
					if (dtUsers.Columns.Contains("user_bcode") && dtUsers.Rows[i]["user_bcode"] != null) dgv_01.Rows[i].Cells["user_bcode"].Value = dtUsers.Rows[i]["user_bcode"].ToString();
					if (dtUsers.Columns.Contains("user_eid") && dtUsers.Rows[i]["user_eid"] != null) dgv_01.Rows[i].Cells["user_eid"].Value = dtUsers.Rows[i]["user_eid"].ToString();
					if (dtUsers.Columns.Contains("user_nick") && dtUsers.Rows[i]["user_nick"] != null) dgv_01.Rows[i].Cells["user_nick"].Value = dtUsers.Rows[i]["user_nick"].ToString();


					if (dtUsers.Columns.Contains("user_type") && dtUsers.Rows[i]["user_type"] != null)
                    {
                        dgv_01.Rows[i].Cells["user_type"].Value = dtUsers.Rows[i]["user_type"].ToString();
                        dgv_01.Rows[i].Cells["user_typename"].Value = sl_usertype[dtUsers.Rows[i]["user_type"].ToString()].ToString();
                    }
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
            
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count < 0)
            {
                MessageBox.Show("请选择你要查询的员工", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sl_userinfo.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                sl_userinfo.Add("user_name", dgv_01.SelectedRows[0].Cells["user_name"].Value);
                sl_userinfo.Add("user_bcode", dgv_01.SelectedRows[0].Cells["user_bcode"].Value);
                sl_userinfo.Add("user_eid", dgv_01.SelectedRows[0].Cells["user_eid"].Value);
                sl_userinfo.Add("user_nick", dgv_01.SelectedRows[0].Cells["user_nick"].Value);
                sl_userinfo.Add("user_typename", dgv_01.SelectedRows[0].Cells["user_typename"].Value);
                this.Close();
            }
        }

		private void GetData()
		{
			dgv_01.Rows.Clear();
			string strsecdata = tb_sname.Text.Trim().ToUpper();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			//       string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-userdata-sec002", sttemp01);
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);
			DataRow[] arrayDR = getdt.Select("user_nick like '%" + strsecdata + "%' or user_bcode like '%" + strsecdata + "%'");//根据客户查询包
			int ii = arrayDR.Length;
			if (ii <= 0) return;
			dgv_01.RowCount = ii;
			int i = 0;
			foreach (DataRow dr in arrayDR)
			{
				if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
				if (getdt.Columns.Contains("user_name") && getdt.Rows[i]["user_name"] != null) dgv_01.Rows[i].Cells["user_name"].Value = dr["user_name"].ToString();
				if (getdt.Columns.Contains("user_name") && getdt.Rows[i]["user_bcode"] != null) dgv_01.Rows[i].Cells["user_bcode"].Value = dr["user_bcode"].ToString();
				if (getdt.Columns.Contains("user_eid") && getdt.Rows[i]["user_eid"] != null) dgv_01.Rows[i].Cells["user_eid"].Value = dr["user_eid"].ToString();
				if (getdt.Columns.Contains("user_nick") && getdt.Rows[i]["user_nick"] != null) dgv_01.Rows[i].Cells["user_nick"].Value = dr["user_nick"].ToString();
				if (getdt.Columns.Contains("user_type") && getdt.Rows[i]["user_type"] != null)
				{
					dgv_01.Rows[i].Cells["user_type"].Value = dr["user_type"].ToString();
					dgv_01.Rows[i].Cells["user_typename"].Value = sl_usertype[dr["user_type"].ToString()].ToString();
				}
				i++;
			}
			if (dgv_01.RowCount > 0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}
        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)//Enter键
            {
				GetData();
            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
			GetData();
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_select_Click(null, null);
		}

		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
    }
}
