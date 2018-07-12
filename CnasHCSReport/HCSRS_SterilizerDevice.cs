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
    public partial class HCSRS_SterilizerDevice : TemplateForm
    {
        public SortedList Sterilizer = new SortedList();
        public HCSRS_SterilizerDevice()
        {
            InitializeComponent();
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--选择灭菌器";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
			this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.Font = new Font(this.Font.FontFamily, 11);
            loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
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
					if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["ca_name"].ToString();

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

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                Sterilizer.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                Sterilizer.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value.ToString());
                this.Close();
            }
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_select_Click(null, null);
		}
    }
}
