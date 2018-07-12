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
    public partial class HCSCM_department_equipment_manager_Selrecord : TemplateForm
    {
        string selID = "";
        string selCC = "";
        bool switchKey = false;
        public HCSCM_department_equipment_manager_Selrecord(string itemID, string itemCC)
        {
            InitializeComponent();
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--日志";
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            DateTime createDate = DateTime.Now;
            createDate = new DateTime(createDate.Year, createDate.Month, createDate.Day);
            startTimePicker.Value = createDate;
            createDate = new DateTime(createDate.Year, createDate.Month, createDate.Day);
            endTimePicker.Value = createDate.AddDays(1).AddMilliseconds(-1);
            selID = itemID;
            selCC = itemCC;
            LoadData();
            switchKey = true;
        }
        private void LoadData()
        {
            dgv_01.Rows.Clear();


            string selectSql = string.Format("itemID='{0}' and itemCCID='{1}'", selID, selCC);

            //if (rb_storage.Checked == true)
            //{
            //    selectSql += string.Format(" and act_type='{0}'", 1);
            //}
            //else
            //{
            //    selectSql += string.Format(" and act_type='{0}'", 2);
            //}
            if (startTimePicker.Text != "" && endTimePicker.Text != "")
            {
                selectSql += string.Format(" and cre_date>='{0}' and cre_date<='{1}'", startTimePicker.Value, endTimePicker.Value);
            }
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, selectSql);
            //selectSql += " order by id";
            //DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
              string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_instrument-in-out-log-sel001", sttemp01);
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
                if (!string.IsNullOrEmpty(getdt.Rows[i]["act_type"].ToString()))
                {
                    if (getdt.Rows[i]["act_type"].ToString() == "1")
                    {
                        dgv_01.Rows[i].Cells["act_type"].Value = "入库";
                    }
                    else if (getdt.Rows[i]["act_type"].ToString() == "2")
                    {
                        dgv_01.Rows[i].Cells["act_type"].Value = "出库";
                    }
                    else
                    {
                        dgv_01.Rows[i].Cells["act_type"].Value = "修改";
                    }

                }

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

        private void rb_storage_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
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

        private void endTimePicker_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
