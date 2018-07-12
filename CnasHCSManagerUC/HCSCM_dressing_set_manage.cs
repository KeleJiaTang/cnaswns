using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_dressing_set_manage : UserControl
    {
        DataTable getdt02 = new DataTable();//customer
        DataTable getdt01 = new DataTable();//costcenter
        DataTable getdt03 = new DataTable();//sterilizer

        private SortedList sl_material = new SortedList();
        private SortedList sl_str = new SortedList();
        private SortedList sl_customer = new SortedList();
        private SortedList sl_costcenter = new SortedList();
        private SortedList sl_type = new SortedList();

        public HCSCM_dressing_set_manage()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec003", null);
            getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt01 != null)
            {
                int ii = getdt01.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt01.Rows[i]["bar_code"] != null && getdt01.Rows[i]["ca_name"] != null)
                    {
                        sl_costcenter.Add(getdt01.Rows[i]["bar_code"].ToString(), getdt01.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            getdt03 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
            if (getdt03 != null)
            {
                sl_str.Add("0", "无灭菌程序");
                int ii = getdt03.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt03.Rows[i]["id"].ToString() != null && getdt03.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_str.Add(getdt03.Rows[i]["id"].ToString(), getdt03.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }
            //顾客
            getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt02 != null)
            {

                this.cb_customer.Items.Add("----所有----");
                sl_customer.Add("0", "----所有----");
                int ii = getdt02.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt02.Rows[i]["bar_code"].ToString() != null && getdt02.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_customer.Add(getdt02.Rows[i]["bar_code"].ToString(), getdt02.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt02.Rows[i]["cu_name"].ToString().Trim());
                    }
                }

                cb_customer.Text = "----所有----";
            }

            Loaddata(null);
            //表格栏底色
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        DataTable getdt = new DataTable();
        /// <summary>
        /// 读取数据库数据
        /// </summary>
        private void Loaddata(string cu_barcode)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);

            if (cu_barcode == null)
            {
                //String ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-dressing-set-sec001", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec001", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                //String ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-dressing-set-sec002", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec002", sttemp01);
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
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = sl_costcenter[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["ca_customer"].Value = getdt.Rows[i]["customer_code"].ToString();//值是bar_code               
                    if (getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = getdt.Rows[i]["ca_weight"].ToString();
                    if (getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = getdt.Rows[i]["ca_size"].ToString();
                    if (getdt.Rows[i]["handle_price"] != null) dgv_01.Rows[i].Cells["ca_price"].Value = getdt.Rows[i]["handle_price"].ToString();
                    if (getdt.Rows[i]["sterilizer_type"] != null) dgv_01.Rows[i].Cells["sterilizer_type"].Value =sl_str[ getdt.Rows[i]["sterilizer_type"].ToString()].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["ca_material"].Value = getdt.Rows[i]["ca_material"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                }
            }
        }
        //“新建”按钮触发事件
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_dressing_set_manage_new hcsm = new HCSCM_dressing_set_manage_new(getdt01, getdt02, null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(null);
        }
        private DataRow[] arrayDR = null;
        #region 查询功能
        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyValue == 13)
            {
                
              dgv_01.Rows.Clear();
                string strsecdata = tb_sname.Text.Trim();
                string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec001", sttemp01);
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
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                    if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["ca_customer"].Value = dr["customer_code"].ToString();//值是bar_code
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = sl_costcenter[dr["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["ca_material"].Value = dr["ca_material"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                    if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = dr["ca_remarks"].ToString();
                    if (getdt.Rows[i]["handle_price"] != null) dgv_01.Rows[i].Cells["ca_price"].Value = dr["handle_price"].ToString();
                    if (getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = dr["ca_size"].ToString();
                    if (getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = dr["ca_weight"].ToString();
                    if (getdt.Rows[i]["sterilizer_type"] != null) dgv_01.Rows[i].Cells["sterilizer_type"].Value = dr["sterilizer_type"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                    i++;
                }
            }
        }
        #endregion
        /// <summary>
        /// “修改”控件触发事件
        /// </summary>
        private void but_edit_Click(object sender, EventArgs e)
        {
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("customer_code", dgv_01.SelectedRows[0].Cells["ca_customer"].Value);//值是barcode
                slindata.Add("cost_center", dgv_01.SelectedRows[0].Cells["cost_center"].Value);
                slindata.Add("ca_weight", dgv_01.SelectedRows[0].Cells["ca_weight"].Value);
                slindata.Add("ca_size", dgv_01.SelectedRows[0].Cells["ca_size"].Value);
                slindata.Add("handle_price", dgv_01.SelectedRows[0].Cells["ca_price"].Value);
                slindata.Add("sterilizer_type", dgv_01.SelectedRows[0].Cells["sterilizer_type"].Value);//值是灭菌程序id
                slindata.Add("ca_material", dgv_01.SelectedRows[0].Cells["ca_material"].Value);//值是包装材料id
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
            }
            catch
            {
                MessageBox.Show("请选择要修改的敷料包。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HCSCM_dressing_set_manage_new hcsm = new HCSCM_dressing_set_manage_new(getdt01, getdt02, slindata);
            hcsm.ShowDialog();
            Loaddata(null);
        }
        /// <summary>
        /// “删除”按钮触发事件
        /// </summary>
        private void but_remove_Click(object sender, EventArgs e)
        {
            #region 敷料包是否被衣物管理占用
            CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
            //string gg = reCnasRemotCall_01.RemotInterface.CheckSelectData("HCS-dressing-info-sec002", null);
            DataTable getdt01 = reCnasRemotCall_01.RemotInterface.SelectData("HCS-dressing-info-sec002", null);
            if (getdt01 != null)
            {
                int ii = getdt01.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt01.Rows[i]["dre_id"].ToString() != null)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt01.Rows[i]["dre_id"].ToString().Trim())
                        {
                            MessageBox.Show("敷料包已被衣物管理占用，如要删除，请先解除与衣物管理的关联。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            #endregion
            if (MessageBox.Show("确定删除名字为： " + dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() + " 的敷料包吗？", ConfigurationManager.AppSettings["SystemName"] + "--删除敷料包", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-set-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，删除敷料包成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata(null);
            }
        }
        //敷料包详情按钮的触发事件（传包ID和名称过去）
        private void but_details_Click(object sender, EventArgs e)
        {
            SortedList slselect = new SortedList();
            slselect.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
            slselect.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
            HCSCM_dressing_info_manage hcsm = new HCSCM_dressing_info_manage(slselect);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(null);

        }
        //客户的触发事件
        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec001", sttemp01);
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
                if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["ca_customer"].Value = dr["customer_code"].ToString();//值是bar_code
                if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = sl_costcenter[dr["cost_center"].ToString()].ToString();
                if (getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["ca_material"].Value = dr["ca_material"].ToString();
                if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = dr["ca_remarks"].ToString();
                if (getdt.Rows[i]["handle_price"] != null) dgv_01.Rows[i].Cells["ca_price"].Value = dr["handle_price"].ToString();
                if (getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = dr["ca_size"].ToString();
                if (getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = dr["ca_weight"].ToString();
                if (getdt.Rows[i]["sterilizer_type"] != null) dgv_01.Rows[i].Cells["sterilizer_type"].Value = dr["sterilizer_type"].ToString();
                if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                i++;
            }
            
            //dgv_01.Rows[0].Selected = true;
        }
    }
}