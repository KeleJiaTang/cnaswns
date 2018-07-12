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
    public partial class HCSRS_setpatient : TemplateForm
    {
        SortedList sl_sterilizer = new SortedList();
        public HCSRS_setpatient(SortedList sterilizer_batch)
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--已使用包信息";     
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);

            DataTable Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-device-sec001", sltmp);
            if (Sterilizer != null)
            {
                int ii = Sterilizer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Sterilizer.Rows[i]["ca_name"].ToString() != null && Sterilizer.Rows[i]["bar_code"].ToString() != null)
                    {
                        sl_sterilizer.Add(Sterilizer.Rows[i]["bar_code"].ToString(), Sterilizer.Rows[i]["ca_name"].ToString());
                    }
                }
            }
            if (sterilizer_batch.Count == 0) return;
            tb_barcode.Text =sterilizer_batch["s_name"]==null?string.Empty: sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())).ToString();
            tb_sterilizer.Text =sterilizer_batch["s_name"]==null?string.Empty: sterilizer_batch["s_name"].ToString();
            tb_num.Text = sterilizer_batch["s_batch"].ToString();

            SortedList slttmp = new SortedList();
			slttmp.Add(1, sterilizer_batch["s_name"] == null ? null : sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())));
			
			slttmp.Add(2, sterilizer_batch["s_batch"].ToString());
			string er = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec024", slttmp);
            DataTable peopledata = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec024", slttmp);
            if(peopledata!=null&&peopledata.Rows.Count >0)
            {
                for(int i=0;i<peopledata.Rows.Count;i++)
                {
                    int dgvIndex = dgv_01.Rows.AddNew().Index;
                    //dgv_02.Rows[i].Cells["s_select"].Value = false;
                    if (peopledata.Columns.Contains("set_name")&&!string.IsNullOrEmpty(peopledata.Rows[i]["set_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["name"].Value = peopledata.Rows[i]["set_name"];
                    if (peopledata.Columns.Contains("set_code") && !string.IsNullOrEmpty(peopledata.Rows[i]["set_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["barcode"].Value = peopledata.Rows[i]["set_code"];
					if (peopledata.Columns.Contains("info_data") && !string.IsNullOrEmpty(peopledata.Rows[i]["info_data"].ToString())) dgv_01.Rows[dgvIndex].Cells["people"].Value = peopledata.Rows[i]["info_data"];
                }
					dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
