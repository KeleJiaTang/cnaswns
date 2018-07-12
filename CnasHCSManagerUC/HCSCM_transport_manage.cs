using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_transport_manage : UserControl
    {
        private SortedList sl_ProducerType = new SortedList();
        private SortedList sl_ProducerType2 = new SortedList();
        private SortedList sl_CarType = new SortedList();
        DataTable getdt = new DataTable();
        /// <summary>
        /// 条码打印BarCodeXML数据
        /// </summary>
        private string strbarcodexml = "";

        public HCSCM_transport_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            //获取车类型
            DataRow[] ctypeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_transport_type'");
            if (ctypeDR.Length > 0)
            {
                foreach (DataRow dr in ctypeDR)
                {
                    sl_CarType.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                }
            }


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取生产厂家
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            if (getdt != null)
            {
                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    sl_ProducerType.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());

                }

                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_ProducerType2.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());

                }

            }

            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCD'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();

        }
        /// <summary>
        /// 用于读取数据库数据
        /// </summary>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-transport-device-sec001", sttemp01);//
            if (getdt != null && getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
					if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
					if (getdt.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
					if (getdt.Columns.Contains("max_times") && !string.IsNullOrEmpty(getdt.Rows[i]["max_times"].ToString())) dgv_01.Rows[i].Cells["max_times"].Value = getdt.Rows[i]["max_times"].ToString();
					if (getdt.Columns.Contains("run_times") && !string.IsNullOrEmpty(getdt.Rows[i]["run_times"].ToString())) dgv_01.Rows[i].Cells["run_time"].Value = getdt.Rows[i]["run_times"].ToString();
					if (getdt.Columns.Contains("ca_type") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_type"].ToString())) dgv_01.Rows[i].Cells["ca_type"].Value = sl_CarType[getdt.Rows[i]["ca_type"].ToString()].ToString();
					if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString())) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
					if (getdt.Columns.Contains("ca_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_remarks"].ToString())) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
					if (getdt.Columns.Contains("ca_vendor") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_vendor"].ToString())) dgv_01.Rows[i].Cells["ca_vender"].Value = sl_ProducerType[getdt.Rows[i]["ca_vendor"].ToString()].ToString();
					if (getdt.Columns.Contains("sales_id") && !string.IsNullOrEmpty(getdt.Rows[i]["sales_id"].ToString())) dgv_01.Rows[i].Cells["sales_id"].Value = sl_ProducerType2[getdt.Rows[i]["sales_id"].ToString()].ToString();
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        private void but_new_Click_1(object sender, EventArgs e)
        {
            nud_max_times hcsm = new nud_max_times(null, getdt);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }
        /// <summary>
        /// 修改按钮触发事件
        /// </summary>
        private void but_edit_Click(object sender, EventArgs e)
        {
            string change = string.Format(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning), "修改的", "运输工具");
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
				slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["id"].Value);
				slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_name"].Value);
				slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["bar_code"].Value);
				slindata.Add("max_times", dgv_01.SelectedRows[0].Cells["max_times"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["max_times"].Value);
				slindata.Add("ca_type", dgv_01.SelectedRows[0].Cells["ca_type"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_type"].Value);
				slindata.Add("ca_vender", dgv_01.SelectedRows[0].Cells["ca_vender"].Value == null 
					? string.Empty : sl_ProducerType.GetKey(sl_ProducerType.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_vender"].Value)));
				slindata.Add("sales_id", dgv_01.SelectedRows[0].Cells["sales_id"].Value == null 
					? string.Empty : sl_ProducerType2.GetKey(sl_ProducerType2.IndexOfValue(dgv_01.SelectedRows[0].Cells["sales_id"].Value)));
				slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                nud_max_times hcsm = new nud_max_times(slindata, getdt);
                hcsm.ShowDialog();
                Loaddata();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "运输工具" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 删除按钮触发事件
        /// </summary>
        private void but_remove_Click(object sender, EventArgs e)
        {

            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "运输工具" }), ConfigurationManager.AppSettings["SystemName"].ToString() + "--删除运输工具", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-transport-device-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-transport-device-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "运输工具" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                    if (dgv_01.Rows.Count > 0)
                    {
                        if (selectedIndex == 0)//删除后判断是否为0
                        {
                            dgv_01.CurrentRow = dgv_01.Rows[0];
                        }
                        else
                        {
                            dgv_01.CurrentRow = dgv_01.Rows[selectedIndex - 1];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除的", "运输工具" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void but_print_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.CurrentRow == null)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["bar_code"].Value != null ?
					dgv_01.CurrentRow.Cells["bar_code"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
					dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("P013", codeName);

					string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='transport'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
    }
}

