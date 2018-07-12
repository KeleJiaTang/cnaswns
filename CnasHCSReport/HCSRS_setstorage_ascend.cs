using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_setstorage_ascend : UserControl
    {
        private SortedList sl_location = new SortedList();

        public HCSRS_setstorage_ascend()
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();



            DataTable DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_location.Add(DTlocation.Rows[i]["id"].ToString().Trim(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
        }

        private void but_select_Click_1(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            string SqlWhere = string.Format("(s_room like '%{0}%' and s_basket like '%{1}%' and s_cabinet like '%{2}%')", tb_room.Text, tb_lan.Text, tb_gui.Text);
            //slttmp.Add(1, tb_room.Text);
            //slttmp.Add(2, tb_gui.Text);
            //slttmp.Add(3, tb_lan.Text);
            slttmp.Add(1, SqlWhere);
            // string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec0010", slttmp);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec0010", slttmp);
            dgv_02.Rows.Clear();
            if (getdt != null)
            {

                for (int i = 0; i < getdt.Rows.Count; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != "")
                    {
                        int dgvIndex = dgv_02.Rows.AddNew().Index;
                        if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_set"].Value = getdt.Rows[i]["ca_name"];
                        if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_barcode"].Value = getdt.Rows[i]["bar_code"];
                        if (getdt.Columns.Contains("s_name") && !string.IsNullOrEmpty(getdt.Rows[i]["s_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_stor"].Value = getdt.Rows[i]["s_name"];
                        if (getdt.Columns.Contains("s_room") && !string.IsNullOrEmpty(getdt.Rows[i]["s_room"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_room"].Value = getdt.Rows[i]["s_room"];
                        if (getdt.Columns.Contains("s_basket") && !string.IsNullOrEmpty(getdt.Rows[i]["s_basket"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_lan"].Value = getdt.Rows[i]["s_basket"];
                        if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time"].Value = getdt.Rows[i]["mod_date"];
                        if (getdt.Columns.Contains("ca_expiration") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_expiration"].ToString())) dgv_02.Rows[dgvIndex].Cells["baozhi"].Value = getdt.Rows[i]["ca_expiration"];
                        if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString()))
                        {
                            string a = getdt.Rows[i]["mod_date"].ToString();
                            DateTime time1 = DateTime.Parse(a);
                            TimeSpan time2 = DateTime.Now.Subtract(time1);
                            int tianshu = time2.Days;
                            if (tianshu < int.Parse(getdt.Rows[i]["ca_expiration"].ToString())) dgv_02.Rows[dgvIndex].Cells["out"].Value = int.Parse(getdt.Rows[i]["ca_expiration"].ToString()) - tianshu;
                            else
                                dgv_02.Rows[dgvIndex].Cells["out"].Value = "已过期";
                        }
                        if (getdt.Columns.Contains("s_cabinet") && !string.IsNullOrEmpty(getdt.Rows[i]["s_cabinet"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_gui"].Value = getdt.Rows[i]["s_cabinet"];
                        if (getdt.Columns.Contains("location_id") && !string.IsNullOrEmpty(getdt.Rows[i]["location_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_location"].Value = sl_location[getdt.Rows[i]["location_id"].ToString()].ToString();
                    }
                }
                if (dgv_02.RowCount > 0)
                {
                    dgv_02.CurrentRow = dgv_02.Rows[0];
                }
            }
            tb_num.Text = dgv_02.Rows.Count.ToString();

        }

        private void dgv_02_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            GridHeaderCellElement cell = e.CellElement as GridHeaderCellElement;
            if (cell != null)
            {
                cell.Font = new Font(new FontFamily("Segoe UI"), 11f);
            }
        }

        private void NameGetData()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            slttmp.Add(1, tb_name.Text);

            //string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec012", slttmp);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec012", slttmp);
            dgv_02.Rows.Clear();
            tb_num.Clear();
            if (getdt != null)
            {

                for (int i = 0; i < getdt.Rows.Count; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != "")
                    {
                        int dgvIndex = dgv_02.Rows.AddNew().Index;
                        if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_set"].Value = getdt.Rows[i]["ca_name"];
                        if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_barcode"].Value = getdt.Rows[i]["bar_code"];
                        if (getdt.Columns.Contains("s_name") && !string.IsNullOrEmpty(getdt.Rows[i]["s_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_stor"].Value = getdt.Rows[i]["s_name"];
                        if (getdt.Columns.Contains("s_room") && !string.IsNullOrEmpty(getdt.Rows[i]["s_room"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_room"].Value = getdt.Rows[i]["s_room"];
                        if (getdt.Columns.Contains("s_basket") && !string.IsNullOrEmpty(getdt.Rows[i]["s_basket"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_lan"].Value = getdt.Rows[i]["s_basket"];
                        if (getdt.Columns.Contains("s_cabinet") && !string.IsNullOrEmpty(getdt.Rows[i]["s_cabinet"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_gui"].Value = getdt.Rows[i]["s_cabinet"];
                        if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time"].Value = getdt.Rows[i]["mod_date"];
                        if (getdt.Columns.Contains("ca_expiration") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_expiration"].ToString())) dgv_02.Rows[dgvIndex].Cells["baozhi"].Value = getdt.Rows[i]["ca_expiration"];
                        if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString()))
                        {
                            string a = getdt.Rows[i]["mod_date"].ToString();
                            DateTime time1 = DateTime.Parse(a);
                            TimeSpan time2 = DateTime.Now.Subtract(time1);
                            int lastDays = time2.Days;
                            if (lastDays < int.Parse(getdt.Rows[i]["ca_expiration"].ToString())) dgv_02.Rows[dgvIndex].Cells["out"].Value = int.Parse(getdt.Rows[i]["ca_expiration"].ToString()) - lastDays;
                            else
                                dgv_02.Rows[dgvIndex].Cells["out"].Value = "已过期";
                        }
                        if (getdt.Columns.Contains("location_id") && !string.IsNullOrEmpty(getdt.Rows[i]["location_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_location"].Value = sl_location[getdt.Rows[i]["location_id"].ToString()].ToString();
                    }
                }
                if (dgv_02.RowCount > 0)
                {
                    dgv_02.CurrentRow = dgv_02.Rows[0];
                }
            }
            tb_num.Text = dgv_02.Rows.Count.ToString();

        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            NameGetData();
        }

        private void tb_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NameGetData();
            }
        }


    }
}
