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
using System.Configuration;
using Cnas.wns.CnasBarcodeLib;
using Telerik.WinControls.UI;
using log4net;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_washing_device : UserControl
    {
        private SortedList sl_type01 = new SortedList();
        private SortedList sl_sales = new SortedList();
        private DataTable getdt = new DataTable();

        //private ILog _logger = null;


        public HCSCM_washing_device()
        {
            InitializeComponent();
            //_logger = LogManager.GetLogger("CnasWNSClient");
            //_logger.Info("");
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_was_procedure.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "relatedProgram", EnumImageType.PNG);
            this.but_was_program.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "program", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion
            ////设置窗体图标
            //this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Button", "new.png");
            //this.Font = new Font(this.Font.FontFamily, 11);

            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + " --> " + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);//查询厂商
            if (getdt != null)
            {
                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    sl_type01.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());

                }
                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_sales.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                }
            }
            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }


        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-device-sec001", sttemp01);
            if (getdt != null && getdt.Rows != null)
            {
                try
                {
                    foreach (DataRow item in getdt.Rows)
                    {
                        GridViewRowInfo row = dgv_01.Rows.AddNew();
                        if (getdt.Columns.Contains("id") && item["id"] != null) row.Cells["id"].Value = item["id"].ToString();
                        if (getdt.Columns.Contains("bar_code") && item["bar_code"] != null) row.Cells["bar_code"].Value = item["bar_code"].ToString();
                        if (getdt.Columns.Contains("ca_name") && item["ca_name"] != null) row.Cells["ca_name"].Value = item["ca_name"].ToString();
                        if (getdt.Columns.Contains("ca_model") && item["ca_model"] != null) row.Cells["ca_model"].Value = item["ca_model"].ToString();
                        if (getdt.Columns.Contains("run_times") && item["run_times"] != null) row.Cells["run_times"].Value = item["run_times"].ToString();
                        if (getdt.Columns.Contains("cre_date") && item["cre_date"] != null) row.Cells["cre_date"].Value = item["cre_date"].ToString();
                        if (getdt.Columns.Contains("mod_date") && item["mod_date"] != null) row.Cells["mod_date"].Value = item["mod_date"].ToString();
                        if (getdt.Columns.Contains("price") && item["price"] != null) row.Cells["price"].Value = double.Parse(item["price"].ToString()).ToString("C");
                        if (getdt.Columns.Contains("ca_remarks") && item["ca_remarks"] != null) row.Cells["ca_remarks"].Value = item["ca_remarks"].ToString();
                        if (getdt.Columns.Contains("bd_test_time") && item["bd_test_time"] != null) row.Cells["bd_test_time"].Value = item["bd_test_time"].ToString();
                        if (getdt.Columns.Contains("if_bdtest") && item["if_bdtest"] != null) row.Cells["if_bdtest"].Value = (item["if_bdtest"].ToString() == "1") ? "需要" : "不需要";
                        if (getdt.Columns.Contains("ca_vender") && item["ca_vender"] != null) row.Cells["ca_vender"].Value = Convert.ToString(sl_type01[Convert.ToString(item["ca_vender"])]);
                        if (getdt.Columns.Contains("sales_id") && item["sales_id"] != null) row.Cells["sales_id"].Value = sl_sales[item["sales_id"].ToString()].ToString();
                        if (getdt.Columns.Contains("if_swingarm") && item["if_swingarm"] != null) row.Cells["if_swingarm"].Value = item["if_swingarm"].ToString();
                    }
                    if (dgv_01.Rows.Count > 0)
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                }
                catch (Exception ex)
                {
                    //_logger.Info(ex.Message);
                }
				
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_washing_device_new hcsm = new HCSCM_washing_device_new(null, getdt);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "清洗机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList slindata = new SortedList();
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("ca_model", dgv_01.SelectedRows[0].Cells["ca_model"].Value);
                slindata.Add("ca_vender", sl_type01.GetKey(sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_vender"].Value)));
                slindata.Add("sales_id", sl_sales.GetKey(sl_sales.IndexOfValue(dgv_01.SelectedRows[0].Cells["sales_id"].Value)));
               
                slindata.Add("price", double.Parse(dgv_01.SelectedRows[0].Cells["price"].Value.ToString().Substring(1)));

                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                slindata.Add("if_bdtest", dgv_01.SelectedRows[0].Cells["if_bdtest"].Value);
                slindata.Add("bd_test_time", dgv_01.SelectedRows[0].Cells["bd_test_time"].Value);
                slindata.Add("if_swingarm", dgv_01.SelectedRows[0].Cells["if_swingarm"].Value);

                HCSCM_washing_device_new hcsm = new HCSCM_washing_device_new(slindata, getdt);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                Loaddata();
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "清洗机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(dgv_01.SelectedRows.Count>0)
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                #region 判断清洗机器是否被灭菌流程占用
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-deviceprogram-sec002", null);//99
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["dev_id"].ToString() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["dev_id"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation", EnumPromptMessage.warning, new string[] { "清洗机", "清洗流程", "清洗流程" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "灭菌器" }), ConfigurationManager.AppSettings["SystemName"] + "--删除灭菌器", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                // string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-washing-device-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-washing-device-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "清洗机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void but_was_program_Click(object sender, EventArgs e)
        {

            HCSCM_washing_program hcsm = new HCSCM_washing_program();
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }

        private void but_was_procedure_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "关联", "清洗机" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList slselect = new SortedList();
            try
            {
                if (dgv_01.SelectedRows[0].Cells["bar_code"].Value != null || dgv_01.SelectedRows[0].Cells["ca_name"].Value != null || dgv_01.SelectedRows[0].Cells["id"].Value != null)
                {
                    slselect.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);

                    slselect.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);

                    slselect.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                }

                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillprogram", EnumPromptMessage.warning, new string[] { "清洗机" }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HCSCM_washing_device_procedure hcsm = new HCSCM_washing_device_procedure(slselect);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }

        /// <summary>
        /// 打印清洗机条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintList_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='washer'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}




    }
}
