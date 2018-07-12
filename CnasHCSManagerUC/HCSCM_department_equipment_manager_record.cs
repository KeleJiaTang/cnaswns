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
    public partial class HCSCM_department_equipment_manager_record : TemplateForm
    {
        bool switchKey = false;
        public HCSCM_department_equipment_manager_record()
        {
            InitializeComponent();
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--日志";
            DateTime createDate = DateTime.Now;
            createDate = new DateTime(createDate.Year, createDate.Month, createDate.Day);
            startTimePicker.Value = createDate;
            createDate = new DateTime(createDate.Year, createDate.Month, createDate.Day);
            endTimePicker.Value = createDate.AddDays(1).AddMilliseconds(-1);
            LoadFromEvent();
            switchKey = true;
        }
        /// <summary>
        /// 加载DGV数据
        /// </summary>
        private void LoadData()
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            string str_usertp = this.cb_customer.Text;
            string str_cc_id = this.cb_cost_center.Text;
            string str_type = this.cb_type.Text;

            string selectSql = string.Format("( in_name like '%{0}%')", strsecdata);
            if (str_usertp != "----所有----")
                selectSql += string.Format(" and cu_name='{0}'", str_usertp);
            if (str_cc_id != "----所有----")
                selectSql += string.Format(" and ca_name='{0}'", str_cc_id);
            if (str_type != "----所有----")
                selectSql += string.Format(" and value_code='{0}'", str_type);
            if (rb_storage.Checked == true)
            {
                selectSql += string.Format(" and act_type='{0}'", 1);
            }
            else
            {
                selectSql += string.Format(" and act_type='{0}'", 2);
            }
            if (startTimePicker.Text != "" && endTimePicker.Text != "")
            {
                selectSql += string.Format(" and cre_date>='{0}' and cre_date<='{1}'", startTimePicker.Value, endTimePicker.Value);
            }
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, selectSql);
            //selectSql += " order by id";
            //DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            // string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_instrument-in-out-log-sel001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS_instrument-in-out-log-sel001", sttemp01);
            if (getdt == null) return;
            int ii = getdt.Rows.Count;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;

            for (int i = 0; i < ii; i++)
            {
                if (!string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["in_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["in_name"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["cu_name"].ToString())) dgv_01.Rows[i].Cells["cu_name"].Value = getdt.Rows[i]["cu_name"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["cc_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["value_code"].ToString())) dgv_01.Rows[i].Cells["value_code"].Value = getdt.Rows[i]["value_code"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["act_type"].ToString())) dgv_01.Rows[i].Cells["act_type"].Value = (getdt.Rows[i]["act_type"].ToString() == "1") ? "入库" : "出库";
                if (!string.IsNullOrEmpty(getdt.Rows[i]["act_count"].ToString())) dgv_01.Rows[i].Cells["act_count"].Value = getdt.Rows[i]["act_count"].ToString();
                if (!string.IsNullOrEmpty(getdt.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
            }

            //foreach (DataRow dr in arrayDR)
            //{
            //    if (!string.IsNullOrEmpty(dr["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
            //    if (!string.IsNullOrEmpty(dr["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
            //    if (!string.IsNullOrEmpty(dr["cu_name"].ToString())) dgv_01.Rows[i].Cells["cu_name"].Value = dr["cu_name"].ToString();
            //    if (!string.IsNullOrEmpty(dr["cc_name"].ToString())) dgv_01.Rows[i].Cells["cc_name"].Value = dr["cc_name"].ToString();
            //    if (!string.IsNullOrEmpty(dr["value_code"].ToString())) dgv_01.Rows[i].Cells["value_code"].Value = dr["value_code"].ToString();
            //    if (!string.IsNullOrEmpty(dr["act_type"].ToString())) dgv_01.Rows[i].Cells["act_type"].Value = (dr["act_type"].ToString() == "1") ? "入库" : "出库";
            //    if (!string.IsNullOrEmpty(dr["act_count"].ToString())) dgv_01.Rows[i].Cells["act_count"].Value = dr["act_count"].ToString();
            //    if (!string.IsNullOrEmpty(dr["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
            //    i++;
            //}
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void LoadFromEvent()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //器械类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            this.cb_type.Items.Add("----所有----");

            foreach (DataRow dr in typeDR)
            {
                cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }
            cb_type.Text = "----所有----";

            //成本中心
            DataTable getdt03 = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (getdt03 != null)
            {
                this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
                int ii = getdt03.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt03.Rows[i]["id"].ToString() != null && getdt03.Rows[i]["ca_name"].ToString().Trim() != null)
                    {

                        cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt03.Rows[i]["ca_name"].ToString().Trim(), Value = getdt03.Rows[i]["id"].ToString() });
                    }
                }
                cb_cost_center.Text = "----所有----";
            }

            //顾客
            DataTable getdt04 = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt04 != null)
            {
                this.cb_customer.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });

                int ii = getdt04.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt04.Rows[i]["id"].ToString() != null && getdt04.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        cb_customer.Items.Add(new RadListDataItem() { Text = getdt04.Rows[i]["cu_name"].ToString().Trim(), Value = getdt04.Rows[i]["id"].ToString() });
                    }
                }
                cb_customer.SelectedIndex = 0;
            }
            // LoadData();
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            this.cb_cost_center.Items.Clear();

            this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });

            DataTable getdt = null;
            string str = cb_customer.SelectedItem.Value.ToString();//获取键，即cu_id条码
            SortedList sl_barcode = new SortedList();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            if (str != "0")
            {

                sl_barcode.Add(1, str);
                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            }
            else
            {
                sl_barcode.Add(1, CnasBaseData.SystemID);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec001", sl_barcode);//成本中心

            }
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        this.cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["bar_code"].ToString().Trim() });
                    }
                }
            }
            cb_cost_center.SelectedIndex = 0;
        }

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadData();
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadData();
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rb_storage_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadData();
            }
        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (switchKey)
            {
                LoadData();
            }

        }

        private void endTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (switchKey)
            {
                LoadData();
            }
        }


    }
}
