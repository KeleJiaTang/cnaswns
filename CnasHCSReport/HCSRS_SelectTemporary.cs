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

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_SelectTemporary : TemplateForm
    {
        private SortedList sl_customer = new SortedList();
        private SortedList sl_costcenter = new SortedList();
        public SortedList sets = new SortedList();
        public HCSRS_SelectTemporary()
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--选择临时包";           

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

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
            loaddata(null);
			dgv_01.CurrentRow = dgv_01.Rows[0];

        }
        public void loaddata(string cu_barcode)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable DtSet = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec020", null);
            dgv_01.Rows.Clear();
            if (DtSet != null && DtSet.Rows.Count > 0)
            {
                dgv_01.RowCount = DtSet.Rows.Count;
                for (int i = 0; i < DtSet.Rows.Count; i++)
                {
                    if (DtSet.Columns.Contains("set_code") && !string.IsNullOrEmpty(DtSet.Rows[i]["set_code"].ToString())) dgv_01.Rows[i].Cells["s_barcode"].Value = DtSet.Rows[i]["set_code"].ToString();
                    if (DtSet.Columns.Contains("set_name") && !string.IsNullOrEmpty(DtSet.Rows[i]["set_name"].ToString())) dgv_01.Rows[i].Cells["s_name"].Value = DtSet.Rows[i]["set_name"].ToString();
                }
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
                sets.Add("s_risk", string.Empty);
                sets.Add("s_pack", string.Empty);
                this.Close();
            }
        }

        private void dgv_01_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                sets.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                sets.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                sets.Add("s_risk", string.Empty);
                sets.Add("s_pack", string.Empty);
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_select_Click(null, null);
		}
    }
}
