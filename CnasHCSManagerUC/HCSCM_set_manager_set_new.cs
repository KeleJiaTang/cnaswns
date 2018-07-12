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

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_manager_set_new : TemplateForm
    {
        SortedList Sl_type_01 = new SortedList();
        SortedList Sl_type_02 = new SortedList();
        SortedList Sl_type_03 = new SortedList();
        public HCSCM_set_manager_set_new()
        {
            InitializeComponent();
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Choice", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--选择基本包";
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataRow[] arrayDR = null;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                this.cb_customer.Items.Add("----所有----");
                Sl_type_01.Add("0", "----所有----");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }



            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_type'");//包的类型
            this.cb_type.Items.Add("----所有----");
            Sl_type_02.Add("0", "----所有----");
            foreach (DataRow dr in arrayDR)
            {
                Sl_type_02.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }

            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_03.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            cb_customer.Text = "----所有----";
            cb_type.Text = "----所有----";
            Loaddata(null, null);
        }
        private void Loaddata(string cu_barcode, string settype)
        {

            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = null;
            if (cu_barcode == null && settype == null)
            {
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//搜索全部基本包
            }
            else if (cu_barcode != null && settype == null)
            {
                sttemp01.Add(2, cu_barcode);
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec002", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec002", sttemp01);
            }
            else if (cu_barcode == null && settype != null)
            {
                sttemp01.Add(2, settype);
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec004", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec004", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                sttemp01.Add(3, settype);
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec005", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec005", sttemp01);
            }


            if (getdt != null)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();

                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = getdt.Rows[i]["rfid_retrospect"].ToString();
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_03[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = getdt.Rows[i]["ca_priority"].ToString().ToString();
                }

            }
			if(dgv_01.Rows.Count>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                DataRow[] arrayDR = null;
                dgv_01.Rows.Clear();
                string strsecdata = tb_sname.Text.Trim().ToUpper();

                string str_usertp = Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                //    string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec001", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);


                if (str_usertp == "0")//查询所有客户的基本包
                {
                    arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%'");
                }
                else
                {
                    arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%' )");//根据客户查询包
                }
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();

                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                    if (getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = dr["rfid_retrospect"].ToString();
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_03[dr["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = dr["ca_priority"].ToString().ToString();
                    i++;
                }

                dgv_01.Rows[0].IsSelected = true;
            }
        }

        private void but_select_Click(object sender, EventArgs e)
        {

            string selectname = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            string srtId = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            string srtCode = dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString();
            string complexity = dgv_01.SelectedRows[0].Cells["ca_priority"].Value.ToString();
            string Rfid = dgv_01.SelectedRows[0].Cells["rfid_retrospect"].Value.ToString();
            HCSCM_set_manager_set_select hcsm = new HCSCM_set_manager_set_select(srtId, selectname, srtCode, complexity, Rfid);

            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false; ;
            hcsm.ShowDialog();
            this.Close();
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR = null;
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim().ToUpper();

            string str_usertp = Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //    string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);


            if (str_usertp == "0")//查询所有客户的基本包
            {
                arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%'");
            }
            else
            {
                arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%' )");//根据客户查询包
            }
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();

                if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();

                if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_03[dr["cost_center"].ToString()].ToString();
                if (getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = dr["ca_priority"].ToString().ToString();
                i++;
            }
			if(dgv_01.Rows.Count>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            if (this.cb_customer.Text == "----所有----" && this.cb_type.Text == "----所有----")
            {
                Loaddata(null, null);
            }
            else if (this.cb_customer.Text != "----所有----" && this.cb_customer.Text != "" && this.cb_type.Text == "----所有----")
            {
                Loaddata(Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString(), null);
            }
            else if (this.cb_customer.Text == "----所有----" && this.cb_type.Text != "----所有----" && this.cb_type.Text != "")
            {
                Loaddata(null, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_type.Text)).ToString());
            }
            else if (this.cb_customer.Text != "----所有----" && this.cb_customer.Text != "" && this.cb_type.Text != "----所有----" && this.cb_type.Text != "")
            {
                Loaddata(Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString(), Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_type.Text)).ToString());
            }
            else
            {
                // MessageBox.Show("出现未知错误,请联系管理员。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void cb_type_TextChanged(object sender, EventArgs e)
        {
            if (this.cb_customer.Text == "----所有----" && this.cb_type.Text == "----所有----")
            {
                Loaddata(null, null);
            }
            else if (this.cb_customer.Text != "----所有----" && this.cb_customer.Text != "" && this.cb_type.Text == "----所有----")
            {
                Loaddata(Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString(), null);
            }
            else if (this.cb_customer.Text == "----所有----" && this.cb_type.Text != "----所有----" && this.cb_type.Text != "")
            {
                Loaddata(null, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_type.Text)).ToString());
            }
            else if (this.cb_customer.Text != "----所有----" && this.cb_customer.Text != "" && this.cb_type.Text != "----所有----" && this.cb_type.Text != "")
            {
                Loaddata(Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_customer.Text)).ToString(), Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_type.Text)).ToString());
            }
            else
            {
                // MessageBox.Show("出现未知错误,请联系管理员。", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_select_Click(null, null);
		}
    }
}
