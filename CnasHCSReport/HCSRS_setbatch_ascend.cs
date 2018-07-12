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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_setbatch_ascend : UserControl
    {
        public SortedList sl_customer = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_sterilizer = new SortedList();
        public SortedList sl_program = new SortedList();
        public SortedList sl_location = new SortedList();
        public SortedList sl_storage = new SortedList();
        public SortedList sterilizer_batch = new SortedList();
        public bool isSet = true;
        public SortedList setdata = new SortedList();
        public HCSRS_setbatch_ascend()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_set.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "set", EnumImageType.PNG);
            this.but_tempset.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "temporarySet", EnumImageType.PNG);
            this.but_recall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "recallset", EnumImageType.PNG);
            this.but_use.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "userset", EnumImageType.PNG);

            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            DataTable DTstorage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            if (DTstorage != null)
            {
                int ii = DTstorage.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTstorage.Rows[i]["id"].ToString() != null && DTstorage.Rows[i]["s_name"].ToString().Trim() != null)
                    {
                        sl_storage.Add(DTstorage.Rows[i]["id"].ToString().Trim(), DTstorage.Rows[i]["s_name"].ToString().Trim());
                    }
                }
            }

            string s = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec001", null);

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
            DataTable Program = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
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
            Loaddate();
		}
        private List<GridViewRowInfo> _dataGridAllRows = new List<GridViewRowInfo>();



        /// <summary>
        /// 选择时间触发事件
        /// </summary>
        private void OnSelectedValueChanged(object sender, EventArgs e)
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
				DateTime p = !string.IsNullOrEmpty(dt_end.Text) ? dt_end.Value : DateTime.Now;
				DateTime endDate = new DateTime(p.Year, p.Month, p.Day).AddDays(1).AddMilliseconds(-1);
				string endtime = endDate.ToString("yyyy/MM/dd hh:mm:ss");
				dgv_01.Rows.Clear();
				string kong = "0001/1/1 0:00:00";
				foreach (GridViewRowInfo item in _dataGridAllRows)
				{
					DateTime cellValue =item.Cells["time_end"].Value==null? DateTime.Parse(kong): DateTime.Parse(item.Cells["time_end"].Value.ToString());

					if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(endDate, cellValue) > 0)
					{
						dgv_01.Rows.Add(item);
					}
				}
			}
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
			
			dt_end.Value = new DateTime();
			dt_start.Value = new DateTime();
			dgv_01.Rows.Clear();
            isSet = true;
            setdata.Clear();
            HCSRS_SelectSet SS = new HCSRS_SelectSet();
            SS.ShowDialog();
            setdata = SS.sets;
            Loaddate();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
			dt_end.Value = new DateTime();
			dt_start.Value = new DateTime();
			dgv_01.Rows.Clear();
            isSet = false;
            setdata.Clear();
            HCSRS_SelectTemporary ST = new HCSRS_SelectTemporary();
            ST.ShowDialog();
            setdata = ST.sets;
            Loaddate();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();

            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "器械包灭菌批次");
        }

        private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
			but_recall_Click(null, null);
        }


		public void Loaddate()
		{

			if (setdata == null) return;
			if (setdata.Count == 0) return;
			string sql = string.Empty;
			if (isSet)
			{
				sql = "HCS-workset-sec013";
			}
			else
			{
				sql = "HCS-workset-sec021";
			}
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList slttmp = new SortedList();
			slttmp.Add(1, setdata["s_barcode"].ToString());

			string gg = reCnasRemotCall.RemotInterface.CheckSelectData(sql, slttmp);
			DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData(sql, slttmp);
			dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
			if (getdt01 != null)
			{
				_dataGridAllRows.Clear();
				for (int i = 0; i < getdt01.Rows.Count; i++)
				{
					int dgvIndex = dgv_01.Rows.AddNew().Index;
					if (getdt01.Columns.Contains("container_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["container_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["sterilizer"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
					if (getdt01.Columns.Contains("bar_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["bar_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_setbar"].Value = getdt01.Rows[i]["bar_code"].ToString();
					if (getdt01.Columns.Contains("BCU_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["BCU_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_bcu"].Value = getdt01.Rows[i]["BCU_code"].ToString();
					if (getdt01.Columns.Contains("ca_name") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["ca_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_set"].Value = getdt01.Rows[i]["ca_name"].ToString();
					if (getdt01.Columns.Contains("customer_code") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["customer_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[getdt01.Rows[i]["customer_code"].ToString()];
					if (getdt01.Columns.Contains("cost_center") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["cost_center"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[getdt01.Rows[i]["cost_center"].ToString()];
					if ( getdt01.Columns.Contains("location_id") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["location_id"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_location"].Value = sl_location[getdt01.Rows[i]["location_id"].ToString()];
					if (getdt01.Columns.Contains("storage_id") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[getdt01.Rows[i]["storage_id"].ToString()];
					if (getdt01.Columns.Contains("storage_id_02") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id_02"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_storage01"].Value = sl_storage[getdt01.Rows[i]["storage_id_02"].ToString()];
					if (getdt01.Columns.Contains("info_data") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["info_data"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
					if (getdt01.Columns.Contains("device_runtimes") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["device_runtimes"].ToString())) dgv_01.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
					if (getdt01.Columns.Contains("cre_date") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["cre_date"].ToString())) dgv_01.Rows[dgvIndex].Cells["time_start"].Value = getdt01.Rows[i]["cre_date"];
					if (getdt01.Columns.Contains("mod_date1") &&  !string.IsNullOrEmpty(getdt01.Rows[i]["mod_date1"].ToString())) dgv_01.Rows[dgvIndex].Cells["time_end"].Value = getdt01.Rows[i]["mod_date1"];
					if (getdt01.Columns.Contains("run_times") && !string.IsNullOrEmpty(getdt01.Rows[i]["run_times"].ToString())) dgv_01.Rows[dgvIndex].Cells["cycles"].Value = getdt01.Rows[i]["run_times"];
					
					if (getdt01.Columns.Contains("status") && !string.IsNullOrEmpty(getdt01.Rows[i]["status"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_status"].Value = getdt01.Rows[i]["status"].ToString() == "4" ? "被召回" : "使用中";
					_dataGridAllRows.Add(dgv_01.Rows[dgvIndex]);
				}
				OnSelectedValueChanged(null, null);
				if (dgv_01.Rows.Count > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
			}
		}

        private void radTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
					GetData();
			}
        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            sterilizer_batch.Clear();
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                sterilizer_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["sterilizer"].Value);
                sterilizer_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
            }
            HCSRS_setpatient HCRS = new HCSRS_setpatient(sterilizer_batch);
            HCRS.ShowDialog();
        }

        private void but_recall_Click(object sender, EventArgs e)
        {
            sterilizer_batch.Clear();
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                sterilizer_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["sterilizer"].Value);
                sterilizer_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
            }
            HCSRS_FindSet HCRS = new HCSRS_FindSet(sterilizer_batch);
            HCRS.ShowDialog();
        }

		private void but_sel_Click(object sender, EventArgs e)
		{
			GetData();
		}



		private void GetData()
		{
			string hh = null;
			DataTable BCUData = null;
			dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
			if (dgv_01.RowCount > 0)
			{
				dt_end.Value = new DateTime();
				dt_start.Value = new DateTime();
			}
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList bcuValue = new SortedList();
				
			if (tb_bcu.Text != string.Empty && tb_patient.Text == string.Empty)
				{
					bcuValue.Add(1, tb_bcu.Text.Trim());
					bcuValue.Add(2, tb_bcu.Text.Trim());
					//hh = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec023", bcuValue);
					BCUData = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec023", bcuValue);
				}
				if (tb_bcu.Text == string.Empty && tb_patient.Text == string.Empty)
				{
					bcuValue.Add(1, tb_bcu.Text.Trim());
					bcuValue.Add(2, tb_bcu.Text.Trim());
					//hh = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec023", bcuValue);
					BCUData = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec023", bcuValue);
				}
				if (tb_bcu.Text == string.Empty && tb_patient.Text != string.Empty)
				{
					bcuValue.Add(1, tb_patient.Text.Trim());
					//hh = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec040", bcuValue);
					BCUData = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec040", bcuValue);
				}
				if (tb_bcu.Text != string.Empty && tb_patient.Text != string.Empty)
				{
					bcuValue.Add(1, tb_patient.Text.Trim());
					bcuValue.Add(2, tb_bcu.Text.Trim());
					//hh = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec041", bcuValue);
					BCUData = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec041", bcuValue);
				}
                if (BCUData != null && BCUData.Rows.Count > 0)
                {
					_dataGridAllRows.Clear();
                    for (int i = 0; i < BCUData.Rows.Count; i++)
                    {
                        int dgvIndex = dgv_01.Rows.AddNew().Index;

                        if (BCUData.Columns.Contains("set_code") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["set_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_setbar"].Value = BCUData.Rows[i]["set_code"];
                        if (BCUData.Columns.Contains("set_name") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["set_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_set"].Value = BCUData.Rows[i]["set_name"];
                        if (BCUData.Columns.Contains("BCU_code") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["BCU_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_bcu"].Value = BCUData.Rows[i]["BCU_code"];
                        if (BCUData.Columns.Contains("cost_center") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["cost_center"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[BCUData.Rows[i]["cost_center"].ToString()];
                        if (BCUData.Columns.Contains("info_data") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["info_data"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_program"].Value = sl_program[BCUData.Rows[i]["info_data"].ToString()];
                        if (BCUData.Columns.Contains("container_code") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["container_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["sterilizer"].Value = sl_sterilizer[BCUData.Rows[i]["container_code"].ToString()];
                        if (BCUData.Columns.Contains("customer_code") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["customer_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[BCUData.Rows[i]["customer_code"].ToString()];
                        if (BCUData.Columns.Contains("location_id") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["location_id"].ToString())) dgv_01.Rows[i].Cells["s_location"].Value = sl_location[BCUData.Rows[i]["location_id"].ToString()];
                        if (BCUData.Columns.Contains("storage_id") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["storage_id"].ToString())) dgv_01.Rows[i].Cells["s_storage"].Value = sl_storage[BCUData.Rows[i]["storage_id"].ToString()];
                        if (BCUData.Columns.Contains("storage_id_02") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["storage_id_02"].ToString())) dgv_01.Rows[i].Cells["s_storage01"].Value = sl_storage[BCUData.Rows[i]["storage_id_02"].ToString()];
                        if (BCUData.Columns.Contains("info_data") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["info_data"].ToString())) dgv_01.Rows[i].Cells["s_program"].Value = sl_program[BCUData.Rows[i]["info_data"].ToString()];
                        if (BCUData.Columns.Contains("device_runtimes") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["device_runtimes"].ToString())) dgv_01.Rows[i].Cells["batch"].Value = BCUData.Rows[i]["device_runtimes"];
                        if (BCUData.Columns.Contains("cre_date") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["time_start"].Value = BCUData.Rows[i]["cre_date"];
                        if (BCUData.Columns.Contains("mod_date") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["mod_date"].ToString())) dgv_01.Rows[i].Cells["time_end"].Value = BCUData.Rows[i]["mod_date"];
                        if (BCUData.Columns.Contains("run_times") &&  !string.IsNullOrEmpty(BCUData.Rows[i]["run_times"].ToString())) dgv_01.Rows[i].Cells["cycles"].Value = BCUData.Rows[i]["run_times"];
						if (BCUData.Columns.Contains("patient") && !string.IsNullOrEmpty(BCUData.Rows[i]["patient"].ToString())) dgv_01.Rows[dgvIndex].Cells["patient"].Value = BCUData.Rows[i]["patient"];
						if (BCUData.Columns.Contains("status") && !string.IsNullOrEmpty(BCUData.Rows[i]["status"].ToString())) dgv_01.Rows[i].Cells["s_status"].Value = BCUData.Rows[i]["status"].ToString() == "4" ? "被召回" : "使用中";
						_dataGridAllRows.Add(dgv_01.Rows[dgvIndex]);
                    }
				OnSelectedValueChanged(null, null);
					if (dgv_01.Rows.Count > 0)
					{
						dgv_01.CurrentRow = dgv_01.Rows[0];
					}
                }
            }

		private void tb_patient_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				GetData();
			}
		}

		}
    }


