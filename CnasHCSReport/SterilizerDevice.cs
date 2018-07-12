using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
    public partial class SterilizerDevice : TemplateForm
    {
        public SortedList Sterilizer = new SortedList();
        public SterilizerDevice()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            //表格栏底色
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //DGV表格首行字段居中对齐
            dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loaddata();
        }

        public void loaddata()
        {
             CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            slttmp.Add(1,CnasBaseData.SystemID);
            //string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec004", sl_type);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-sterilizer-device-sec001", slttmp);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    //if (getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type01[getdt.Rows[i]["s_type"].ToString()].ToString();
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["ca_name"].ToString();

                }
            }
            
        }
       
        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                Sterilizer.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                Sterilizer.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                this.Close();
            }
        }

        private void SterilizerDevice_Load(object sender, EventArgs e)
        {

        }

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                Sterilizer.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                Sterilizer.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                this.Close();
            }
        }
    }
}
