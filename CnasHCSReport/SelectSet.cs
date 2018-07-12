using CnasUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;

namespace Cnas.wns.CnasHCSReport
{
    public partial class SelectSet : TemplateForm
    {
        private DataRow[] arrayDR = null;//用于传输数据
        public SortedList sl_customer = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_mater = new SortedList();
        public SortedList sl_complete = new SortedList();
        public SortedList sets = new SortedList();
        public SelectSet()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            //表格栏底色
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
           arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_complexity'");//清洗难度等级
            foreach (DataRow dr in arrayDR)
            {
                sl_complete.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            DataTable Customer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (Customer != null)
            {
                this.cb_customer.Items.Add("----所有----");
                sl_customer.Add("0", "----所有----");
                int kk = Customer.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Customer.Rows[i]["bar_code"].ToString() != null && Customer.Rows[i]["cu_name"].ToString() != null)
                    {
                        sl_customer.Add(Customer.Rows[i]["bar_code"].ToString(), Customer.Rows[i]["cu_name"].ToString());
                        cb_customer.Items.Add(Customer.Rows[i]["cu_name"].ToString());
                    }
                }
                cb_customer.Text = "----所有----";
            }
            DataTable Costcenter = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (Costcenter != null)
            {
                int kk = Costcenter.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Costcenter.Rows[i]["bar_code"].ToString() != null && Costcenter.Rows[i]["ca_name"].ToString() != null)
                    {
                        sl_costcenter.Add(Costcenter.Rows[i]["bar_code"].ToString(), Costcenter.Rows[i]["ca_name"].ToString());
                    }
                }
            }

            DataTable Mater = reCnasRemotCall.RemotInterface.SelectData("hcs-setmaterial-type-sec002", null);
            if (Mater != null)
            {
                int kk = Mater.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Mater.Rows[i]["id"].ToString() != null && Mater.Rows[i]["ca_name"].ToString() != null)
                    {
                        sl_mater.Add(Mater.Rows[i]["id"].ToString(), Mater.Rows[i]["ca_name"].ToString());
                    }
                }
            }
            loaddata(null);
        }

        /// <summary>
        /// 加载实体包数据
        /// </summary>
        /// <param name="cu_barcode"></param>
        public void loaddata(string cu_barcode)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable DtSet = null;
            //SortedList sltmp = new SortedList();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            if (cu_barcode == null)
            {
                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
                DtSet = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                DtSet = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec003", sttemp01);
            }
            dgv_01.Rows.Clear();
            if(DtSet!=null&&DtSet.Rows.Count>0)
            {
                
                for(int i=0;i<DtSet.Rows.Count;i++)
                {
                    int dgvIndex = dgv_01.Rows.Add();
                    if (DtSet.Rows[i]["bar_code"] != null) dgv_01.Rows[dgvIndex].Cells["s_barcode"].Value = DtSet.Rows[i]["bar_code"].ToString();
                    if (DtSet.Rows[i]["ca_name"] != null) dgv_01.Rows[dgvIndex].Cells["s_name"].Value = DtSet.Rows[i]["ca_name"].ToString();
                    if (DtSet.Rows[i]["cost_center"] != null) dgv_01.Rows[dgvIndex].Cells["s_costcenter"].Value =sl_costcenter[ DtSet.Rows[i]["cost_center"].ToString()].ToString();
                    if (DtSet.Rows[i]["customer_code"] != null) dgv_01.Rows[dgvIndex].Cells["s_customer"].Value =sl_customer[ DtSet.Rows[i]["customer_code"].ToString()].ToString();
                    if (DtSet.Rows[i]["ca_material"] != null) dgv_01.Rows[dgvIndex].Cells["s_pack"].Value = sl_mater[DtSet.Rows[i]["ca_material"].ToString()].ToString();
                    if (DtSet.Rows[i]["ca_complexity"] != null) dgv_01.Rows[dgvIndex].Cells["s_risk"].Value = sl_complete[DtSet.Rows[i]["ca_complexity"].ToString()].ToString();
                    if (DtSet.Rows[i]["run_times"] != null) dgv_01.Rows[dgvIndex].Cells["s_runcycle"].Value = DtSet.Rows[i]["run_times"].ToString();
                }
            }

        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_customer.Text==null)
            {
                loaddata(null);
            }
            else
            {
                loaddata(sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                sets.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                sets.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                sets.Add("s_customer", dgv_01.SelectedRows[0].Cells["s_customer"].Value.ToString());
                sets.Add("s_costcenter", dgv_01.SelectedRows[0].Cells["s_costcenter"].Value.ToString());
                sets.Add("s_risk", dgv_01.SelectedRows[0].Cells["s_risk"].Value.ToString());
                sets.Add("s_pack", dgv_01.SelectedRows[0].Cells["s_pack"].Value.ToString());
                this.Close();
            }
        }

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                sets.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                sets.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                sets.Add("s_customer", dgv_01.SelectedRows[0].Cells["s_customer"].Value.ToString());
                sets.Add("s_costcenter", dgv_01.SelectedRows[0].Cells["s_costcenter"].Value.ToString());
                sets.Add("s_risk", dgv_01.SelectedRows[0].Cells["s_risk"].Value.ToString());
                sets.Add("s_pack", dgv_01.SelectedRows[0].Cells["s_pack"].Value.ToString());
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR = null;
            dgv_01.Rows.Clear();
            string strsecdata = tb_select.Text.Trim().ToUpper();

            string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
            if (str_usertp == "0")//查询所有客户的基本包
            {
                arrayDR = getdt.Select("ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%' ");
            }
            else
            {
                arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%')");//根据客户查询包

            }
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = dr["bar_code"].ToString();
                if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = dr["ca_name"].ToString();
                if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter[dr["cost_center"].ToString()].ToString();
                if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[dr["customer_code"].ToString()].ToString();
                if (getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["s_pack"].Value = sl_mater[dr["ca_material"].ToString()].ToString();
                if (getdt.Rows[i]["ca_complexity"] != null) dgv_01.Rows[i].Cells["s_risk"].Value = sl_complete[dr["ca_complexity"].ToString()].ToString();
                if (getdt.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["s_runcycle"].Value = dr["run_times"].ToString();
                //if (getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (dr["in_cycle"].ToString() == "9") ? "否" : "是";
                i++;
            }
        }
      
    }
}
