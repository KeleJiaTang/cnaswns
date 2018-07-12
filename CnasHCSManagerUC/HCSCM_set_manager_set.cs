using Cnas.wns.CnasBaseClassClient;
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
    public partial class HCSCM_set_manager_set : Form
    {
        SortedList Sl_type_01 = new SortedList();
        SortedList Sl_type_02 = new SortedList();
        public HCSCM_set_manager_set()
        {
            InitializeComponent();
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--器械包管理";
            //表格栏底色
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataRow[] arrayDR = null;//用于传输数据
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
           getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                arrayDR = getdt.Select();
                this.cb_customer.Items.Add("----所有----");
                Sl_type_02.Add("0", "----所有----");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_02.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                cb_customer.Text = "----所有----";
            }
            Loaddata(null);
        }
        private void Loaddata(string cu_barcode)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = null;
            if (cu_barcode == null)
            {
               // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec003", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec003", sttemp01);
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
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[getdt.Rows[i]["cost_center"].ToString()].ToString();                
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_position"] != null) dgv_01.Rows[i].Cells["ca_position"].Value = getdt.Rows[i]["ca_position"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                //    if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = getdt.Rows[i]["customer_code"].ToString();
                    if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = Sl_type_02[getdt.Rows[i]["customer_code"].ToString()].ToString();
                }

            }
            dgv_01.Rows[0].Selected = true;
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_set_manager_set_new hcsm = new HCSCM_set_manager_set_new();
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("customer_code", dgv_01.SelectedRows[0].Cells["customer_code"].Value);//值是barcode

                
                slindata.Add("cost_center", dgv_01.SelectedRows[0].Cells["cost_center"].Value);
              

                slindata.Add("ca_position", dgv_01.SelectedRows[0].Cells["ca_position"].Value);

            }
            catch
            {
                MessageBox.Show("请选择要修改的厂商。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HCSCM_set_manager_set_edit hcsm = new HCSCM_set_manager_set_edit(slindata);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(null);
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除名字为： " + dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() + " 的实体包吗？", "删除实体包", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，删除实体包成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata(null);
            }
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            DataRow[] arrayDR = null;
            if (e.KeyValue == 13)
            {
                dgv_01.Rows.Clear();
                string strsecdata = tb_sname.Text.Trim();

                string str_usertp = Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
               // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);

                if (str_usertp == "0")//查询所有客户的基本包
                {
                    arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' ");
                }
                else
                {
                   arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( ca_name like '%" + strsecdata + "%' )");//根据客户查询包

                }

                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[dr["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_position"] != null) dgv_01.Rows[i].Cells["ca_position"].Value = dr["ca_position"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                    i++;
                }

                dgv_01.Rows[0].Selected = true;
            } 
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_list_Click(object sender, EventArgs e)
        {

        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR = null;
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();

            string str_usertp = Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);

            if (str_usertp == "0")//查询所有客户的基本包
            {
                arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' ");
            }
            else
            {
                arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( ca_name like '%" + strsecdata + "%' )");//根据客户查询包

            }

            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[dr["cost_center"].ToString()].ToString();
                if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                if (getdt.Rows[i]["ca_position"] != null) dgv_01.Rows[i].Cells["ca_position"].Value = dr["ca_position"].ToString();
                if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                i++;
            }

            dgv_01.Rows[0].Selected = true;
        }
    }
}
