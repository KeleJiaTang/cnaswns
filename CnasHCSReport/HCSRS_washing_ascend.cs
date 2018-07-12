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
using System.Globalization;
using System.Threading;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_washing_ascend : UserControl
    {
        public SortedList washing_batch = new SortedList();
        public SortedList sl_sterilizer = new SortedList();
        public SortedList sl_program = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_storage = new SortedList();
        public SortedList sl_location = new SortedList();
		public SortedList sl_customer = new SortedList();
		public SortedList sl_user = new SortedList();
        public SortedList sterilizer = null;
		DateTime cellValue = new DateTime();
        public HCSRS_washing_ascend()
        {
            
            InitializeComponent();
            but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            but_printlist .Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            but_set.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "set", EnumImageType.PNG);
            but_lookset.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "packageSel", EnumImageType.PNG);
            but_washer.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "washinger", EnumImageType.PNG);
            //dgv_02.Parent = splitContainer1;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            //string ff = reCnasRemotCall.RemotInterface.SelectData("HCS_sterilizer_device_sec001", sltmp);
            DataTable Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-device-sec001", sltmp);
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

			DataTable User = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sltmp);
			if (User != null)
			{
				int kk = User.Rows.Count;
				if (kk <= 0) return;
				for (int i = 0; i < kk; i++)
				{
					if (User.Rows[i]["id"].ToString() != null && User.Rows[i]["user_name"].ToString() != null)
					{
						sl_user.Add(User.Rows[i]["id"].ToString(), User.Rows[i]["user_name"].ToString());
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

            DataTable Location = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
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

            DataTable Program = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-program-sec001", null);
            if (Program != null)
            {
                int kk = Program.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Program.Rows[i]["bar_code"].ToString() != null && Program.Rows[i]["pr_name"].ToString() != null)
                    {
                        sl_program.Add(Program.Rows[i]["bar_code"].ToString(), Program.Rows[i]["pr_name"].ToString());
                    }
                }
            }
        }
        public void LoadData()
        {
            tb_set.Clear();
            dgv_01.Visible = true;
            dgv_02.Visible = false;
            if (sterilizer.Count == 0) return;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            slttmp.Add(1, sterilizer["s_barcode"].ToString());
			string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec0030", slttmp);
			DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec0030", slttmp);
            dgv_01.Rows.Clear();
            if (getdt01 != null)
            {
                 _dataGridAllRows.Clear();
                for (int i = 0; i < getdt01.Rows.Count; i++)
                {
                    int dgvIndex = dgv_01.Rows.AddNew().Index;
                    if (getdt01.Columns.Contains("container_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["container_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_name"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
					if (getdt01.Columns.Contains("info_data") && !string.IsNullOrEmpty(getdt01.Rows[i]["info_data"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
					if (getdt01.Columns.Contains("user_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_id"].ToString())) dgv_01.Rows[dgvIndex].Cells["user"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];
                    if (getdt01.Columns.Contains("device_runtimes") && !string.IsNullOrEmpty(getdt01.Rows[i]["device_runtimes"].ToString())) dgv_01.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
                    if (getdt01.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt01.Rows[i]["cre_date"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_time"].Value = getdt01.Rows[i]["cre_date"];
					if (getdt01.Columns.Contains("load_user") && !string.IsNullOrEmpty(getdt01.Rows[i]["load_user"].ToString())) dgv_01.Rows[dgvIndex].Cells["user2"].Value = sl_user[getdt01.Rows[i]["load_user"].ToString()];
					if (getdt01.Rows[i]["v_name"].ToString() == string.Empty)
					{
						dgv_01.Rows[dgvIndex].Cells["result"].Value = "合格";
					}
					if (getdt01.Columns.Contains("v_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["v_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["result"].Value = getdt01.Rows[i]["v_name"];
					if (getdt01.Columns.Contains("remark1") && !string.IsNullOrEmpty(getdt01.Rows[i]["remark1"].ToString())) dgv_01.Rows[dgvIndex].Cells["remark"].Value = getdt01.Rows[i]["remark1"];
                     _dataGridAllRows.Add(dgv_01.Rows[dgvIndex]);
                }
				if (dgv_01.Rows.Count > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
				OnSelectedValueChanged(null, null);
            }
        }
        public void LoadDgv02()
        {
            dgv_01.Visible = false;
            dgv_02.Visible = true;
            tb_set.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
             SortedList slttmp = new SortedList();
             slttmp.Add(1, washing_batch.ContainsKey("s_barcode") ? washing_batch["s_barcode"].ToString() : string.Empty);

            string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec031", slttmp);
            DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec031", slttmp);
            dgv_02.Rows.Clear();
            if (getdt01 != null)
            {
                _dataGridAllRows.Clear();
                for (int i = 0; i < getdt01.Rows.Count; i++)
                {
                    int dgvIndex = dgv_02.Rows.AddNew().Index;
                    if (getdt01.Columns.Contains("container_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["container_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["sterilizer"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
                    if (getdt01.Columns.Contains("bar_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["bar_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_setbar"].Value = getdt01.Rows[i]["bar_code"].ToString();
                    if (getdt01.Columns.Contains("BCU_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["BCU_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_bcu"].Value = getdt01.Rows[i]["BCU_code"].ToString();
                    if (getdt01.Columns.Contains("ca_name") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_set"].Value = getdt01.Rows[i]["ca_name"].ToString();
					if (getdt01.Columns.Contains("user_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["user"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];
                    if (getdt01.Columns.Contains("customer_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["customer_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[getdt01.Rows[i]["customer_code"].ToString()];
                    if (getdt01.Columns.Contains("cost_center") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["cost_center"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[getdt01.Rows[i]["cost_center"].ToString()];
                    if (getdt01.Columns.Contains("location_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["location_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_location"].Value = sl_location[getdt01.Rows[i]["location_id"].ToString()];
                    if (getdt01.Columns.Contains("storage_id") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[getdt01.Rows[i]["storage_id"].ToString()];
                    if (getdt01.Columns.Contains("storage_id_02") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id_02"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_storage01"].Value = sl_storage[getdt01.Rows[i]["storage_id_02"].ToString()];
                    if (getdt01.Columns.Contains("info_data") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["info_data"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
                    if (getdt01.Columns.Contains("device_runtimes") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["device_runtimes"].ToString())) dgv_02.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
                    if (getdt01.Columns.Contains("cre_date") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["cre_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time_start"].Value = getdt01.Rows[i]["cre_date"];
                    if (getdt01.Columns.Contains("mod_date") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["mod_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time_end"].Value = getdt01.Rows[i]["mod_date"];
                    if (getdt01.Columns.Contains("run_times") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["run_times"].ToString())) dgv_02.Rows[dgvIndex].Cells["cycles"].Value = getdt01.Rows[i]["run_times"];
					if (getdt01.Columns.Contains("status") && !string.IsNullOrEmpty(getdt01.Rows[i]["status"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_status"].Value = getdt01.Rows[i]["status"].ToString() == "4" ? "被召回" : "使用中";
                    _dataGridAllRows.Add(dgv_02.Rows[dgvIndex]);
                }
				if (dgv_02.Rows.Count > 0)
				{
					dgv_02.CurrentRow = dgv_02.Rows[0];
				}
				OnSelectedValueChanged(null, null);
        }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            HCSRS_SelectSet HCSRS = new HCSRS_SelectSet();
            HCSRS.ShowDialog();
            
                washing_batch = HCSRS.sets;
                dgv_02.Rows.Clear();
                if (washing_batch.Count!=0)
                {
                LoadDgv02();
            }
            dgv_01.Rows.Clear();
            //dgv_02.Rows.Clear();
        }

        private void but_washer_Click(object sender, EventArgs e)
        {
            HCSRS_select_washerdevice HCSRS = new HCSRS_select_washerdevice();
            HCSRS.ShowDialog();
            sterilizer = HCSRS.washing;
			dt_end.Value = new DateTime();
			dt_start.Value = new DateTime();
            LoadData();
            dgv_02.Rows.Clear();
        }

        private void but_lookset_Click(object sender, EventArgs e)
        {
			int selectedIndex = 0;
			int selectedIndex2 = 0;
            if (dgv_01.Rows.Count == 0 && dgv_02.Rows.Count == 0)
            {
                MessageBox.Show("你好，没有清洗批次选择。请先选择灭菌批次。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dgv_01.Visible == true)
                {
                    washing_batch.Clear();
                    if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
                    {
                        washing_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
                        washing_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
                    }
					selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                }
                else if(dgv_02.Visible==true)
                {
                    washing_batch.Clear();
                    if (dgv_02.SelectedRows != null && dgv_02.SelectedRows.Count > 0 && dgv_02.SelectedRows[0] != null)
                    {
                        washing_batch.Add("s_name", dgv_02.SelectedRows[0].Cells["sterilizer"].Value);
                        washing_batch.Add("s_batch", dgv_02.SelectedRows[0].Cells["batch"].Value.ToString());
                    }
					selectedIndex2 = dgv_02.Rows.IndexOf(dgv_02.SelectedRows[0]);
                }

				bool isselect = true;
                HCSRS_wasbatch_set FS = new HCSRS_wasbatch_set(washing_batch,isselect);
                FS.ShowDialog();
                washing_batch = FS.setbarcode;
				dt_end.Value = new DateTime();
				dt_start.Value = new DateTime();
				if (dgv_01.Visible == true)
				{
					LoadData();
					dgv_02.Rows.Clear();
					if (dgv_01.Rows.Count > selectedIndex)
					{
						dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
					}
				}
				

            }
        }

        private void tb_set_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
				SelData();
            }
        }

		private void SelData()
		{
			dgv_01.Visible = false;
			dgv_02.Visible = true;

			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList slttmp = new SortedList();
			slttmp.Add(1, tb_set.Text.Trim());

			string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec031", slttmp);
			
			DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec031", slttmp);
			dgv_02.Rows.Clear();
			_dataGridAllRows.Clear();
			if (getdt01 != null)
			{
				
				for (int i = 0; i < getdt01.Rows.Count; i++)
				{
					int dgvIndex = dgv_02.Rows.AddNew().Index;
					if (getdt01.Columns.Contains("container_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["container_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["sterilizer"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
					if (getdt01.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["bar_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_setbar"].Value = getdt01.Rows[i]["bar_code"].ToString();
					if (getdt01.Columns.Contains("BCU_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["BCU_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_bcu"].Value = getdt01.Rows[i]["BCU_code"].ToString();
					if (getdt01.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_set"].Value = getdt01.Rows[i]["ca_name"].ToString();
					if (getdt01.Columns.Contains("customer_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["customer_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[getdt01.Rows[i]["customer_code"].ToString()];
					if (getdt01.Columns.Contains("cost_center") && !string.IsNullOrEmpty(getdt01.Rows[i]["cost_center"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[getdt01.Rows[i]["cost_center"].ToString()];
					// if (getdt01.Columns.Contains("location_id") && getdt01.Rows[i]["location_id"] != null) dgv_02.Rows[dgvIndex].Cells["s_location"].Value = sl_location[getdt01.Rows[i]["location_id"].ToString()];
					if (getdt01.Columns.Contains("storage_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[getdt01.Rows[i]["storage_id"].ToString()];
					if (getdt01.Columns.Contains("storage_id_02") && !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id_02"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_storage01"].Value = sl_storage[getdt01.Rows[i]["storage_id_02"].ToString()];
					if (getdt01.Columns.Contains("info_data") && !string.IsNullOrEmpty(getdt01.Rows[i]["info_data"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
					if (getdt01.Columns.Contains("device_runtimes") && !string.IsNullOrEmpty(getdt01.Rows[i]["device_runtimes"].ToString())) dgv_02.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
					if (getdt01.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt01.Rows[i]["cre_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time_start"].Value = getdt01.Rows[i]["cre_date"];
					if (getdt01.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt01.Rows[i]["mod_date"].ToString())) dgv_02.Rows[dgvIndex].Cells["time_end"].Value = getdt01.Rows[i]["mod_date"];
					if (getdt01.Columns.Contains("run_times") && !string.IsNullOrEmpty(getdt01.Rows[i]["run_times"].ToString())) dgv_02.Rows[dgvIndex].Cells["cycles"].Value = getdt01.Rows[i]["run_times"];
					if (getdt01.Columns.Contains("status") && !string.IsNullOrEmpty(getdt01.Rows[i]["status"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_status"].Value = getdt01.Rows[i]["status"].ToString() == "4" ? "被召回" : "使用中";
					if (getdt01.Columns.Contains("user_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["user"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];

					
					_dataGridAllRows.Add(dgv_02.Rows[dgvIndex]);
				}
			}
			dt_end.Value = new DateTime();
			dt_start.Value = new DateTime();
			if (dgv_02.RowCount > 0)
			{
				dgv_02.CurrentRow = dgv_02.Rows[0];
			}
			OnSelectedValueChanged(null, null);
		}

		private void dgv_01_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			but_lookset_Click(null, null);
		}

		private void dgv_02_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_lookset_Click(null, null);
		}

		private void but_printlist_Click(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
			string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
			RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


			RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
			RadPrintHelper.Print_DataGridView(this.dgv_02, pringxml);
		}

		private void but_import_Click(object sender, EventArgs e)
		{
			if(dgv_01.Rows.Count>0)
			ExcelHelper.ImprotDataToExcel(this.dgv_01, "清洗机清洗批次");
			if (dgv_02.Rows.Count > 0)
			ExcelHelper.ImprotDataToExcel(this.dgv_02, "器械包清洗批次");
			if(dgv_01.Rows.Count==0&&dgv_01.Rows.Count==0)
			{
				MessageBox.Show("没有数据导出。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
		}

		private void radButton1_Click_1(object sender, EventArgs e)
		{
			SelData();
		}
		private List<GridViewRowInfo> _dataGridAllRows = new List<GridViewRowInfo>();
		private void OnSelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(dt_start.Text) && !string.IsNullOrEmpty(dt_end.Text))
				{
					MessageBox.Show("请先选择开始时间。");
					return;
				}

				if (!string.IsNullOrEmpty(dt_end.Text) && !string.IsNullOrEmpty(dt_start.Text) && dt_end.Value < dt_start.Value)
				{
					RadDateTimePicker currentPicker = sender as RadDateTimePicker;
					if (currentPicker != null)
					{
						if (currentPicker.Name == "dt_start")
						{
							MessageBox.Show("你好，你设置的开始时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;

						}
						else
						{
							MessageBox.Show("你好。你设置的结束时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
				}
				else
				{
					DateTime d = dt_start.Value;
					string starttime = d.ToString("yyyy/MM/dd hh:mm:ss");
					DateTime p = !string.IsNullOrEmpty(dt_end.Text) ? dt_end.Value.AddDays(1) : DateTime.Now;
					DateTime endDate = new DateTime(p.Year, p.Month, p.Day).AddDays(1).AddMilliseconds(-1);
					string endtime = endDate.ToString("yyyy/MM/dd hh:mm:ss");
					dgv_01.Rows.Clear();
					dgv_02.Rows.Clear();
					foreach (GridViewRowInfo item in _dataGridAllRows)
					{
						if (dgv_01.Visible == true)
							cellValue = DateTime.Parse(item.Cells["s_time"].Value.ToString());
						else if (dgv_02.Visible == true)
							cellValue = DateTime.Parse(item.Cells["time_end"].Value.ToString());

						if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(endDate, cellValue) > 0)
						{
							if (dgv_01.Visible == true)
								dgv_01.Rows.Add(item);
							else if (dgv_02.Visible == true)
								dgv_02.Rows.Add(item);
						}
					}
				}
				if (dgv_01.RowCount > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
			}
			catch(Exception ex)
			{

			}
		}
    }
}
