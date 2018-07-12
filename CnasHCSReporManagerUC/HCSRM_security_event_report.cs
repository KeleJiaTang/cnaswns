using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using System.Configuration;
using Cnas.wns.CnasHCSManagerUC;

namespace Cnas.wns.CnasHCSReporManagerUC
{
    public partial class HCSRM_security_event_report : UserControl
    {
        public HCSRM_security_event_report()
        {
            InitializeComponent();

            #region 按钮图片加载
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_dis_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "pictureView", EnumImageType.PNG);
            this.but_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Photo", EnumImageType.PNG);
            this.but_imput.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "photoImport", EnumImageType.PNG);
            this.but_export.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            #endregion
            //设定按字体来缩放控件  
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //加载数据
            Loaddata();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-safetyTimeReport-sec001", sttemp01);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("existing_Problems") && getdt.Rows[i]["existing_Problems"] != null) dgv_01.Rows[i].Cells["existing_Problems"].Value = getdt.Rows[i]["existing_Problems"].ToString();
                    if (getdt.Columns.Contains("Reason") && getdt.Rows[i]["Reason"] != null) dgv_01.Rows[i].Cells["Reason"].Value = getdt.Rows[i]["Reason"].ToString();
                    if (getdt.Columns.Contains("improvement_Measures") && getdt.Rows[i]["improvement_Measures"] != null) dgv_01.Rows[i].Cells["improvement_Measures"].Value = getdt.Rows[i]["improvement_Measures"].ToString();
                    if (getdt.Columns.Contains("charge_Person") && getdt.Rows[i]["charge_Person"] != null) dgv_01.Rows[i].Cells["charge_Person"].Value = getdt.Rows[i]["charge_Person"].ToString();
                    if (getdt.Columns.Contains("report_Person") && getdt.Rows[i]["report_Person"] != null) dgv_01.Rows[i].Cells["report_Person"].Value = getdt.Rows[i]["report_Person"].ToString();
                    if (getdt.Columns.Contains("audit_Person") && getdt.Rows[i]["audit_Person"] != null) dgv_01.Rows[i].Cells["audit_Person"].Value = getdt.Rows[i]["audit_Person"].ToString();
                    if (getdt.Columns.Contains("result_Tracking") && getdt.Rows[i]["result_Tracking"] != null) dgv_01.Rows[i].Cells["result_Tracking"].Value = getdt.Rows[i]["result_Tracking"].ToString();
                    if (getdt.Columns.Contains("tracking_Time") && getdt.Rows[i]["tracking_Time"] != null) dgv_01.Rows[i].Cells["tracking_Time"].Value = getdt.Rows[i]["tracking_Time"].ToString();
                    if (getdt.Columns.Contains("tracker") && getdt.Rows[i]["tracker"] != null) dgv_01.Rows[i].Cells["tracker"].Value = getdt.Rows[i]["tracker"].ToString();
                    if (getdt.Columns.Contains("remarks") && getdt.Rows[i]["remarks"] != null) dgv_01.Rows[i].Cells["remarks"].Value = getdt.Rows[i]["remarks"].ToString();
                    if (getdt.Columns.Contains("cre_time") && getdt.Rows[i]["cre_time"] != null) dgv_01.Rows[i].Cells["cre_time"].Value = getdt.Rows[i]["cre_time"].ToString();
                    if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }

            }
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSRM_security_event_report_new hcsm = new HCSRM_security_event_report_new(null);
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
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count() <= 0)
            {
                if (this.dgv_01.SelectedRows.Count <= 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "报告内容" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            SortedList slindata = new SortedList();
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("existing_Problems", dgv_01.SelectedRows[0].Cells["existing_Problems"].Value);
                slindata.Add("Reason", dgv_01.SelectedRows[0].Cells["Reason"].Value);
                slindata.Add("improvement_Measures", dgv_01.SelectedRows[0].Cells["improvement_Measures"].Value);
                slindata.Add("charge_Person", dgv_01.SelectedRows[0].Cells["charge_Person"].Value);
                slindata.Add("report_Person", dgv_01.SelectedRows[0].Cells["report_Person"].Value);
                slindata.Add("result_Tracking", dgv_01.SelectedRows[0].Cells["result_Tracking"].Value);
                slindata.Add("tracking_Time", dgv_01.SelectedRows[0].Cells["tracking_Time"].Value);
                slindata.Add("tracker", dgv_01.SelectedRows[0].Cells["tracker"].Value);
                slindata.Add("remarks", dgv_01.SelectedRows[0].Cells["remarks"].Value);
                slindata.Add("audit_Person", dgv_01.SelectedRows[0].Cells["audit_Person"].Value);
                HCSRM_security_event_report_new hcsm = new HCSRM_security_event_report_new(slindata);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "安全报告" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete2", EnumPromptMessage.warning), ConfigurationManager.AppSettings["SystemName"] + "--删除器械模块", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasremotCall = new CnasRemotCall();
                int recint = reCnasremotCall.RemotInterface.UPData(1, "hcs-safetyTimeReport-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "安全报告" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_media_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList sortedList = new SortedList();

                //设置一个类型"xxx/"
                sortedList.Add("type", "3");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", "");

                HCSCM_set_image HCSCM_pack_image = new HCSCM_set_image(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_pack_image.ShowInTaskbar = false;
                HCSCM_pack_image.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 照片查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_dis_media_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "查看", "安全报告" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：包
                sortedList.Add("type", "3");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", "");

                HCSCM_set_manage_image HCSCM_set_manage_image = new HCSCM_set_manage_image(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_set_manage_image.ShowInTaskbar = false;
                HCSCM_set_manage_image.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 照片导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_imput_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：包
                sortedList.Add("type", "3");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", "");

                HCSCM_set_image_batch HCSCM_set_image_batch = new HCSCM_set_image_batch(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_set_image_batch.ShowInTaskbar = false;
                HCSCM_set_image_batch.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_export_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "安全事件报告");
        }
        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='safetyTimeReport'");
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
