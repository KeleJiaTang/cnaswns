using CnasUI;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_wasbatch_set : TemplateForm
    {
        public SortedList sl_washer = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList setbarcode = new SortedList();
        public SortedList sl_customer = new SortedList();
        public SortedList sl_storage = new SortedList();
        public SortedList sl_location = new SortedList();
		DataTable Sterilizer = null;
        public HCSRS_wasbatch_set(SortedList washer,bool isselect)//isselect为true时是清洗机，isselect为false时为灭菌器
        {
            InitializeComponent();
			if (isselect == true)
			{
				this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--清洗过的包";
				lb_batch.Text = "清洗批次：";
				lb_device.Text = "清洗机：";
			}
			else if (isselect == false)
			{
				this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--灭菌过的包";
				lb_batch.Text = "灭菌批次：";
				lb_device.Text = "灭菌器：";
			}

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			
			if(isselect==true)
              Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-device-sec001", sltmp);
			else if(isselect==false)
		      Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-device-sec001", sltmp);
				
            if (Sterilizer != null)
            {
                int ii = Sterilizer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Sterilizer.Rows[i]["ca_name"].ToString() != null && Sterilizer.Rows[i]["bar_code"].ToString() != null)
                    {
                        sl_washer.Add(Sterilizer.Rows[i]["bar_code"].ToString(), Sterilizer.Rows[i]["ca_name"].ToString());
                    }
                }
            }
            tb_batch.Text = washer["s_batch"]==null?string.Empty:washer["s_batch"].ToString();
			tb_name.Text = washer["s_name"] == null ? string.Empty : washer["s_name"].ToString();
			tb_barcode.Text = washer["s_name"] == null ? string.Empty:sl_washer.GetKey(sl_washer.IndexOfValue(washer["s_name"].ToString())).ToString();
            DataTable Customer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (Customer != null)
            {
                int kk = Customer.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Customer.Rows[i]["bar_code"].ToString() != null && Customer.Rows[i]["cu_name"].ToString() != null)
                    {
                        sl_customer.Add(Customer.Rows[i]["bar_code"].ToString(), Customer.Rows[i]["cu_name"].ToString());
                    }
                }
            }

            DataTable Storage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            if (Storage != null)
            {
                int kk = Storage.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Storage.Rows[i]["id"].ToString() != null && Storage.Rows[i]["s_name"].ToString() != null)
                    {
                        sl_storage.Add(Storage.Rows[i]["id"].ToString(), Storage.Rows[i]["s_name"].ToString());
                    }
                }
            }

            DataTable Location = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001",null);
            if (Location != null)
            {
                int kk = Location.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Location.Rows[i]["id"].ToString() != null && Location.Rows[i]["u_uname"].ToString() != null)
                    {
                        sl_location.Add(Location.Rows[i]["id"].ToString(), Location.Rows[i]["u_uname"].ToString());
                    }
                }
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
            LoadSet(washer);
        }
        public void LoadSet(SortedList washer)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList Wasbatch = new SortedList();
			Wasbatch.Add(2,washer.ContainsKey("s_batch") && washer["s_batch"] == null ? string.Empty : washer["s_batch"].ToString());
			Wasbatch.Add(1, washer.ContainsKey("s_name") && washer["s_name"] == null ? string.Empty : sl_washer.GetKey(sl_washer.IndexOfValue(washer["s_name"].ToString())));

            string ff = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec028", Wasbatch);
            DataTable DataSet = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec028", Wasbatch);
            if (DataSet != null && DataSet.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Rows.Count; i++)
                {
                    int dgvIndex = dgv_01.Rows.AddNew().Index;
                    if (DataSet.Columns.Contains("set_code") && !string.IsNullOrEmpty(DataSet.Rows[i]["set_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_barcode"].Value = DataSet.Rows[i]["set_code"].ToString();
                    if (DataSet.Columns.Contains("set_name") && !string.IsNullOrEmpty(DataSet.Rows[i]["set_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_set"].Value = DataSet.Rows[i]["set_name"];
                    if (DataSet.Columns.Contains("storage_id") && !string.IsNullOrEmpty(DataSet.Rows[i]["storage_id"] .ToString())) dgv_01.Rows[dgvIndex].Cells["s_storage1"].Value = sl_storage[DataSet.Rows[i]["storage_id"].ToString()];
                    if (DataSet.Columns.Contains("location_id") && !string.IsNullOrEmpty(DataSet.Rows[i]["location_id"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_location"].Value = sl_location[DataSet.Rows[i]["location_id"].ToString()];
                    if (DataSet.Columns.Contains("storage_id_02") && !string.IsNullOrEmpty(DataSet.Rows[i]["storage_id_02"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[DataSet.Rows[i]["storage_id_02"].ToString()];
                    if (DataSet.Columns.Contains("cost_center") && !string.IsNullOrEmpty(DataSet.Rows[i]["cost_center"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[DataSet.Rows[i]["cost_center"].ToString()];
					if (DataSet.Columns.Contains("customer_code") && !string.IsNullOrEmpty(DataSet.Rows[i]["customer_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[DataSet.Rows[i]["customer_code"].ToString()];
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
        }
    }
}

