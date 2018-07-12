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
    public partial class HCSRS_sterilizer_ascend : UserControl
    {
        public SortedList sl_sterilizer = new SortedList();
        public SortedList sl_program = new SortedList();
		public SortedList sterilizer_batch = new SortedList();
		public SortedList sl_user = new SortedList();
        public SortedList sterilizer = null;
      
        public HCSRS_sterilizer_ascend()
        {
            InitializeComponent();
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_sterilizer.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "sterilizer", EnumImageType.PNG);
			this.but_lookset.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "packageSel", EnumImageType.PNG);

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            //string ff = reCnasRemotCall.RemotInterface.SelectData("HCS_sterilizer_device_sec001", sltmp);
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
        }
		/// <summary>
		/// 加载灭菌器批次数据
		/// </summary>
        public void LoadData()
        {
            if (sterilizer.Count == 0) return;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
			slttmp.Add(1, sterilizer["s_barcode"].ToString());
            string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec010", slttmp);
            DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec010", slttmp);
            dgv_01.Rows.Clear();
			_dataGridAllRows.Clear();
            if (getdt01 != null )
            {
               
                for (int i = 0; i < getdt01.Rows.Count; i++)
                {
                    int dgvIndex = dgv_01.Rows.AddNew().Index;
                    if (getdt01.Columns.Contains("container_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["container_code"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_name"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
					if (getdt01.Columns.Contains("info_data") && !string.IsNullOrEmpty(getdt01.Rows[i]["info_data"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_program"].Value = sl_program[getdt01.Rows[i]["info_data"].ToString()];
					if (getdt01.Columns.Contains("user_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_id"].ToString())) dgv_01.Rows[dgvIndex].Cells["user"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];
                    if (getdt01.Columns.Contains("device_runtimes") && !string.IsNullOrEmpty(getdt01.Rows[i]["device_runtimes"].ToString())) dgv_01.Rows[dgvIndex].Cells["batch"].Value = getdt01.Rows[i]["device_runtimes"];
					if (getdt01.Columns.Contains("load_user") && !string.IsNullOrEmpty(getdt01.Rows[i]["load_user"].ToString())) dgv_01.Rows[dgvIndex].Cells["user2"].Value = sl_user[getdt01.Rows[i]["load_user"].ToString()];
					if (getdt01.Rows[i]["v_name"].ToString()==string.Empty)
					{
						dgv_01.Rows[dgvIndex].Cells["result"].Value = "合格";
					}
					if (getdt01.Columns.Contains("v_name") && !string.IsNullOrEmpty(getdt01.Rows[i]["v_name"].ToString())) dgv_01.Rows[dgvIndex].Cells["result"].Value = getdt01.Rows[i]["v_name"];
					if (getdt01.Columns.Contains("remark1") && !string.IsNullOrEmpty(getdt01.Rows[i]["remark1"].ToString())) dgv_01.Rows[dgvIndex].Cells["remark"].Value = getdt01.Rows[i]["remark1"];
					if (getdt01.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt01.Rows[i]["cre_date"].ToString())) dgv_01.Rows[dgvIndex].Cells["s_time"].Value = getdt01.Rows[i]["cre_date"];
					
                    _dataGridAllRows.Add(dgv_01.Rows[dgvIndex]);
                }
				if(dgv_01.RowCount>0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
				OnSelectedValueChanged(null, null);
			}
        }

        private List<GridViewRowInfo> _dataGridAllRows = new List<GridViewRowInfo>();
        /// <summary>
        /// 选择时间事件
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
				DateTime p = !string.IsNullOrEmpty(dt_end.Text) ? dt_end.Value.AddDays(1) : DateTime.Now;
				DateTime endDate = new DateTime(p.Year, p.Month, p.Day).AddDays(1).AddMilliseconds(-1);
				string endtime = endDate.ToString("yyyy/MM/dd hh:mm:ss");
				dgv_01.Rows.Clear();
				foreach (GridViewRowInfo item in _dataGridAllRows)
				{
					DateTime cellValue = DateTime.Parse(item.Cells["s_time"].Value.ToString());

					if (DateTime.Compare(dt_start.Value, cellValue) < 0 && DateTime.Compare(endDate, cellValue) > 0)
					{
						dgv_01.Rows.Add(item);
					}
				}
			}
			if (dgv_01.RowCount > 0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
        }
		
		/// <summary>
		/// 选择灭菌器查询该灭菌器批次
		/// </summary>
        private void radButton1_Click(object sender, EventArgs e)
        {
			
			
            HCSRS_SterilizerDevice SD = new HCSRS_SterilizerDevice();
            SD.ShowDialog();
            sterilizer = SD.Sterilizer;
			dt_end.Value = new DateTime();
			dt_start.Value = new DateTime();
            LoadData();
			
        }
		/// <summary>
		/// 根据灭菌批次来查询器械包（暂时隐藏）
		/// </summary>
        private void radButton2_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show("你好，没有灭菌批次选择。请先选择灭菌批次。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sterilizer_batch.Clear();
                if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
                {
                    sterilizer_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
                    sterilizer_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
                }
                HCSRS_FindSet FS = new HCSRS_FindSet(sterilizer_batch);
                FS.ShowDialog();
            }
        }
		/// <summary>
		/// 打印事件
		/// </summary>
        private void radButton3_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
        }

		/// <summary>
		/// 导出列表事件
		/// </summary>
        private void but_list_Click_1(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "灭菌器批次");
        }

		/// <summary>
		/// 双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			radButton2_Click(null, null);
		}
		SortedList washing_batch = new SortedList();
		private void radButton1_Click_1(object sender, EventArgs e)
		{

			if (dgv_01.Rows.Count == 0 && dgv_01.Rows.Count == 0)
			{
				MessageBox.Show("你好，没有灭菌批次选择。请先选择灭菌批次。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			washing_batch.Clear();
			if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
			{
				washing_batch.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
				washing_batch.Add("s_batch", dgv_01.SelectedRows[0].Cells["batch"].Value.ToString());
			}
			bool isselect = false;
			HCSRS_wasbatch_set HCSRS = new HCSRS_wasbatch_set(washing_batch,isselect);
			HCSRS.ShowDialog();
		}

		private void dgv_01_CellDoubleClick_1(object sender, GridViewCellEventArgs e)
		{
			radButton1_Click_1(null, null);
		}
    }
}
