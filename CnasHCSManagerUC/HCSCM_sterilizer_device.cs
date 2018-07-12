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



namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_sterilizer_device : UserControl
    {
        DataTable getdt = new DataTable();
        private SortedList sl_VenderType = new SortedList();

        /// <summary>
        /// 条码打印BarCodeXML数据
        /// </summary>
        private string strbarcodexml = "";
        private SortedList sl_SalesType = new SortedList();
        
        public HCSCM_sterilizer_device()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_ste_program.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "program", EnumImageType.PNG);
            this.but_ste_deviceprogram.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "relatedProgram", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //生产厂家
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            if (getdt != null)
            {
                DataRow[] vender = getdt.Select("vender_type=1 or vender_type=3");
                foreach(DataRow dr in vender)
                {
                    sl_VenderType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                }
                DataRow[] sales = getdt.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_SalesType.Add(dr["id"].ToString(), dr["v_name"].ToString().Trim());
                }
                

                Loaddata();
                if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
                {
                    dgv_01.Rows[0].IsSelected = true;
                }
            }
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCZ'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();


        }
        /// <summary>
        /// 读取数据
        /// </summary>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            string sterilizer = reCnasRemotCall.RemotInterface.CheckSelectData("hcs-sterilizer-device-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-sterilizer-device-sec001", sttemp01);
            if (getdt != null &&getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {

                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Rows[i]["ca_model"] != null) dgv_01.Rows[i].Cells["ca_model"].Value = getdt.Rows[i]["ca_model"].ToString();
                    if (getdt.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["run_times"].Value = getdt.Rows[i]["run_times"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Columns.Contains("price") &&getdt.Rows[i]["price"] != null &&  !string.IsNullOrEmpty(getdt.Rows[i]["price"].ToString())) dgv_01.Rows[i].Cells["price"].Value = Convert.ToDouble(getdt.Rows[i]["price"].ToString()).ToString("C");
                    if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                    if (getdt.Rows[i]["ca_vender"] != null)
                    {
                        if (!string.IsNullOrEmpty(getdt.Rows[i]["ca_vender"].ToString()))
                            dgv_01.Rows[i].Cells["ca_vender"].Value = sl_VenderType[getdt.Rows[i]["ca_vender"].ToString()].ToString();
                    }
                    if (getdt.Rows[i]["sales_id"] != null) dgv_01.Rows[i].Cells["sales_id"].Value = sl_SalesType[getdt.Rows[i]["sales_id"].ToString()].ToString();
                    if (getdt.Rows[i]["bd_test_time"] != null) dgv_01.Rows[i].Cells["bd_test_time"].Value = getdt.Rows[i]["bd_test_time"].ToString();
                    if (getdt.Rows[i]["if_bdtest"] != null) dgv_01.Rows[i].Cells["if_bdtest"].Value = (getdt.Rows[i]["if_bdtest"].ToString() == "1") ? "需要" : "不需要";
                    if (getdt.Rows[i]["std_stu"] != null) dgv_01.Rows[i].Cells["std_stu"].Value = getdt.Rows[i]["std_stu"].ToString();
                    if (getdt.Rows[i]["min_stu"] != null) dgv_01.Rows[i].Cells["min_stu"].Value = getdt.Rows[i]["min_stu"].ToString();
                    if (getdt.Rows[i]["max_stu"] != null) dgv_01.Rows[i].Cells["max_stu"].Value = getdt.Rows[i]["max_stu"].ToString();

                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_sterilizer_device_new hcsm = new HCSCM_sterilizer_device_new(null, getdt);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }
        //修改
        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("ca_model", dgv_01.SelectedRows[0].Cells["ca_model"].Value);
                slindata.Add("ca_vender", sl_VenderType.GetKey(sl_VenderType.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_vender"].Value)));
                slindata.Add("sales_id", sl_SalesType.GetKey(sl_SalesType.IndexOfValue(dgv_01.SelectedRows[0].Cells["sales_id"].Value)));
                if (dgv_01.SelectedRows[0].Cells["price"].Value!=null)
                {
                    slindata.Add("price", double.Parse(dgv_01.SelectedRows[0].Cells["price"].Value.ToString().Substring(1)));
                }
                else
                {
                    slindata.Add("price", "");
                }
                
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                slindata.Add("bd_test_time", dgv_01.SelectedRows[0].Cells["bd_test_time"].Value);
                slindata.Add("if_bdtest", dgv_01.SelectedRows[0].Cells["if_bdtest"].Value);
                slindata.Add("std_stu", dgv_01.SelectedRows[0].Cells["std_stu"].Value);
                 slindata.Add("min_stu", dgv_01.SelectedRows[0].Cells["min_stu"].Value);
                slindata.Add("max_stu", dgv_01.SelectedRows[0].Cells["max_stu"].Value);

                HCSCM_sterilizer_device_new hcsm = new HCSCM_sterilizer_device_new(slindata, getdt);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                Loaddata();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        //删除
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                #region 判断灭菌器是否被灭菌流程占用
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-deviceprogram-sec003", null);//99
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
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation", EnumPromptMessage.warning, new string[] { "灭菌器", "灭菌流程", "灭菌流程" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-device-del001", sltmp, null);

                
                if (recint > -1) 
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful",EnumPromptMessage.warning,new string[]{"灭菌器"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
        //灭菌程序
        private void but_ste_program_Click_1(object sender, EventArgs e)
        {  
            HCSCM_sterilizer_program hcsm = new HCSCM_sterilizer_program();
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }
        //灭菌流程
        private void but_ste_deviceprogram_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "关联", "灭菌器" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList slselect = new SortedList();
            try
            {
                if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() != "" && dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString() != "" && dgv_01.SelectedRows[0].Cells["id"].Value != null)
                {
                    slselect.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                    slselect.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                    slselect.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillprogram",EnumPromptMessage.warning,new string[]{"灭菌器"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HCSCM_sterilizer_device_program hcsm = new HCSCM_sterilizer_device_program(slselect);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }



        /// <summary>
        /// 打印塑封机条码
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='sterilizer'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}

          

      

       