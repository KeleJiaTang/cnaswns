using Cnas.wns.CnasBarcodeLib;
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

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_plasticenvelop_program : TemplateForm
    {

        private SortedList sl_type01 = new SortedList();
        private DataRow[] arrayDR = null;//用于传输数据
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();


        public HCSCM_plasticenvelop_program()
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            #region 按钮图片加载


            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text =styStemName+  "--塑封机程序管理";
           
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCP'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();

            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-plasticenvelop-type'");//塑封类型
            foreach (DataRow dr in arrayDR)
            {
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            loaddata();
        }
        
        private void loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
           // string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-plasticenvelop-program-sec001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-program-sec001", null);
            if(getdt!=null &&getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if(getdt.Columns.Contains("id") && getdt.Rows[i]["id"]!=null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
					if (getdt.Columns.Contains("pr_name") && getdt.Rows[i]["pr_name"] != null) dgv_01.Rows[i].Cells["pr_name"].Value = getdt.Rows[i]["pr_name"].ToString();
					if (getdt.Columns.Contains("p_type") && getdt.Rows[i]["p_type"] != null) dgv_01.Rows[i].Cells["p_type"].Value = sl_type01[getdt.Rows[i]["p_type"].ToString()].ToString();
					if (getdt.Columns.Contains("run_time") && getdt.Rows[i]["run_time"] != null) dgv_01.Rows[i].Cells["run_time"].Value = getdt.Rows[i]["run_time"].ToString();
					if (getdt.Columns.Contains("run_temp") && getdt.Rows[i]["run_temp"] != null) dgv_01.Rows[i].Cells["run_temp"].Value = getdt.Rows[i]["run_temp"].ToString();
					if (getdt.Columns.Contains("run_speed") && getdt.Rows[i]["run_speed"] != null) dgv_01.Rows[i].Cells["run_speed"].Value = getdt.Rows[i]["run_speed"].ToString();
					if (getdt.Columns.Contains("run_stress") && getdt.Rows[i]["run_stress"] != null) dgv_01.Rows[i].Cells["run_stress"].Value = getdt.Rows[i]["run_stress"].ToString();
					if (getdt.Columns.Contains("ca_remarks") && getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_plasticenvelop_program_new hcsm = new HCSCM_plasticenvelop_program_new(null,arrayDR);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("pr_name", dgv_01.SelectedRows[0].Cells["pr_name"].Value);
                slindata.Add("p_type", dgv_01.SelectedRows[0].Cells["p_type"].Value);
                slindata.Add("run_time", dgv_01.SelectedRows[0].Cells["run_time"].Value);
                slindata.Add("run_temp", dgv_01.SelectedRows[0].Cells["run_temp"].Value);
                slindata.Add("run_speed", dgv_01.SelectedRows[0].Cells["run_speed"].Value);
                slindata.Add("run_stress", dgv_01.SelectedRows[0].Cells["run_stress"].Value);
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);

                HCSCM_plasticenvelop_program_new hcsm = new HCSCM_plasticenvelop_program_new(slindata,arrayDR);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                loaddata();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "塑封程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                #region 判断塑封程序是否被塑封流程占用
               
                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-plasticenvelop-deviceprogram-sec002", null);//99
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for(int i=0;i<ii;i++)
                    {
                        if(getdt.Rows[i]["p_id"].ToString()!=null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["p_id"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation",EnumPromptMessage.warning,new string[]{"塑封程序","塑封流程","塑封流程"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                if (MessageBox.Show("确定删除名字为： " + dgv_01.SelectedRows[0].Cells["pr_name"].Value.ToString() + " 的塑封程序吗？", styStemName + "--删除塑封程序", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-plasticenvelop-program-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-program-del001", sltmp, null);

                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful",EnumPromptMessage.warning,new string[]{"塑封程序"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                return;
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
				string codeName = dgv_01.CurrentRow.Cells["pr_name"].Value != null ?
					dgv_01.CurrentRow.Cells["pr_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("Value", codeName);

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

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
     
    

       
}
