using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using Cnas.wns.CnasBarcodeLib;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_sterilizer_program : TemplateForm
    {
        private DataRow[] arrayDR = null;
        private SortedList sl_type01 = new SortedList();
        /// <summary>
        /// 条码打印BarCodeXML数据
        /// </summary>
        private string strbarcodexml = "";
        private SortedList sl_SalesType = new SortedList();
        public HCSCM_sterilizer_program()
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
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCP'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_sterilizer_type'");
            foreach (DataRow dr in arrayDR)
            {
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            Loaddata();
        }
        /// <summary>
        /// 读取数据库数据
        /// </summary>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-sterilizer-program-sec001", null);
            if (getdt != null && getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["pr_name"] != null) dgv_01.Rows[i].Cells["pr_name"].Value = getdt.Rows[i]["pr_name"].ToString();
                    if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["p_type"] != null) dgv_01.Rows[i].Cells["p_type"].Value = sl_type01[getdt.Rows[i]["p_type"].ToString()].ToString();
                    if (getdt.Rows[i]["run_time"] != null) dgv_01.Rows[i].Cells["run_time"].Value = getdt.Rows[i]["run_time"].ToString();
                    if (getdt.Rows[i]["upper_level"] != null) dgv_01.Rows[i].Cells["upper_level"].Value = getdt.Rows[i]["upper_level"].ToString();
                    if (getdt.Rows[i]["lower_level"] != null) dgv_01.Rows[i].Cells["lower_level"].Value = getdt.Rows[i]["lower_level"].ToString();
                    
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        //新建
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_sterilizer_program_new hcsm = new HCSCM_sterilizer_program_new(null, arrayDR);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "灭菌程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("pr_name", dgv_01.SelectedRows[0].Cells["pr_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("run_time", dgv_01.SelectedRows[0].Cells["run_time"].Value);
                slindata.Add("upper_level", dgv_01.SelectedRows[0].Cells["upper_level"].Value);
                slindata.Add("lower_level", dgv_01.SelectedRows[0].Cells["lower_level"].Value);
                slindata.Add("p_type", dgv_01.SelectedRows[0].Cells["p_type"].Value);
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);

                HCSCM_sterilizer_program_new hcsm = new HCSCM_sterilizer_program_new(slindata, arrayDR);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "灭菌程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                string remove="";
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList slttmp = new SortedList();
                slttmp.Add(1, CnasBaseData.SystemID);
                #region 判断灭菌程序是否被灭菌器占用
                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-sterilizer-deviceprogram-sec003", null);//灭菌流程
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["p_id"].ToString().Trim())
                        {
                            remove = "灭菌程序被灭菌器，";
                            break;
                        }
                    }
                }
                #endregion
                #region 判断灭菌程序是否被器械模板占用
                 getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-base-sec003", null);//器械模块
                if (getdt != null)
                {
                    DataRow[] getdt_02 = getdt.Select();
                    foreach (DataRow dr in getdt_02)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["sterilizer_program"].ToString().Trim())
                        {
                            remove = remove + "器械模板，";
                            break;
                        }
                    }
                }
                #endregion    
                #region 判断灭菌程序是否被基本包占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-base-sec001",slttmp);//器械模块
                if (getdt != null)
                {
                    DataRow[] getdt_02 = getdt.Select();
                    foreach (DataRow dr in getdt_02)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["sterilizer_type"].ToString().Trim())
                        {
                            remove = remove + "基本包";
                            break;
                        }
                    }
                }
                #endregion
                if (remove != "")
                {
                    MessageBox.Show(remove + "占用，如要删除，请先解除与以上的关联。");
                    return;
                }
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete",EnumPromptMessage.warning,new string[]{ dgv_01.SelectedRows[0].Cells["pr_name"].Value.ToString(),"灭菌程序"}), ConfigurationManager.AppSettings["SystemName"] + "--删除灭菌程序", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-sterilizer-program-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-sterilizer-program-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful",EnumPromptMessage.warning,new string[]{"灭菌程序"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void HCSCM_sterilizer_program_Load(object sender, EventArgs e)
        {

        }

        private void but_Cancel_Click_1(object sender, EventArgs e)
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

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}


