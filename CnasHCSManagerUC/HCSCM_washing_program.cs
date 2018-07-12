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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_washing_program : TemplateForm
    {
        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();
        private SortedList sl_type01 = new SortedList();
        //读取清洗类型
        DataRow[] arrayDR = null;

        private SortedList sl_SalesType = new SortedList();
        public HCSCM_washing_program()
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

            this.Text = styStemName + "--清洗程序";

            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_washing_type'");//清洗类型
            foreach (DataRow dr in arrayDR)
            {
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }

            GetWashingPrograms();
        }

        private void GetWashingPrograms()
        {
            int selectedIndex = 0;
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0)
                selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);

            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-washing-program-sec001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-program-sec001", null);
            if (getdt != null && getdt.Rows != null && getdt.Rows.Count > 0)
            {
                foreach (DataRow item in getdt.Rows)
                {
                    GridViewRowInfo dgvRow = dgv_01.Rows.AddNew();
                    if (getdt.Columns.Contains("id") && item["id"] != null) dgvRow.Cells["id"].Value = item["id"].ToString();
                    if (getdt.Columns.Contains("pr_name") && item["pr_name"] != null) dgvRow.Cells["pr_name"].Value = item["pr_name"].ToString();
                    if (getdt.Columns.Contains("bar_code") && item["bar_code"] != null) dgvRow.Cells["bar_code"].Value = item["bar_code"].ToString();
                    if (getdt.Columns.Contains("ca_remarks") && item["ca_remarks"] != null) dgvRow.Cells["ca_remarks"].Value = item["ca_remarks"].ToString();
                    if (getdt.Columns.Contains("p_type") && item["p_type"] != null && sl_type01.ContainsKey(item["p_type"].ToString()))
                        dgvRow.Cells["p_type"].Value = sl_type01[item["p_type"].ToString()].ToString();
                    if (getdt.Columns.Contains("run_time") && item["run_time"] != null) dgvRow.Cells["p_time"].Value = item["run_time"].ToString();
                }

                if (dgv_01.Rows.Count > selectedIndex)
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "清洗程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (dgv_01.CurrentRow != null && dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0)
                {
                    int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    SortedList slindata = new SortedList();
                    slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                    slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                    slindata.Add("pr_name", dgv_01.SelectedRows[0].Cells["pr_name"].Value);
                    slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                    slindata.Add("p_type", dgv_01.SelectedRows[0].Cells["p_type"].Value);
                    slindata.Add("p_time", dgv_01.SelectedRows[0].Cells["p_time"].Value);

                    HCSCM_washing_program_new hcsm = new HCSCM_washing_program_new(slindata, arrayDR);
                    // 获取一个值，指是否在Windows任务栏中显示窗体。
                    hcsm.ShowInTaskbar = false;
                    hcsm.ShowDialog();
                    GetWashingPrograms();
                    if (dgv_01.Rows.Count > 0)
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                    }
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "清洗程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "清洗程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (dgv_01.CurrentRow != null && dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0
                    && dgv_01.SelectedRows[0].Cells["id"].Value != null
                    && dgv_01.SelectedRows[0].Cells["pr_name"].Value != null)
                {
                    string existedMapping = string.Empty;
                    CnasRemotCall remoteCall = new CnasRemotCall();

                    #region 判断清洗程序是否被清洗流程占用

                    DataTable getdt = remoteCall.RemotInterface.SelectData("HCS-washing-deviceprogram-sec002", null);//99
                    if (getdt != null && getdt.Rows.Count > 0)
                    {
                        if (getdt.Columns.Contains("p_id"))
                        {
                            DataRow[] exitedBinding = getdt.Select(string.Format("p_id='{0}'", dgv_01.SelectedRows[0].Cells["id"].Value));
                            if (exitedBinding.Length > 0)
                                existedMapping += "清洗机，";
                        }
                    }
                    #endregion
                    #region 判断清洗程序是否被基本包占用
                    SortedList sttemp01 = new SortedList();
                    sttemp01.Add(1, CnasBaseData.SystemID);
                    getdt = remoteCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//106
                    if (getdt != null && getdt.Rows.Count > 0)
                    {
                        if (getdt.Columns.Contains("washing_type"))
                        {
                            DataRow[] exitedBinding = getdt.Select(string.Format("washing_type='{0}'", dgv_01.SelectedRows[0].Cells["id"].Value));
                            if (exitedBinding.Length > 0)
							{
								string type = getdt.Columns.Contains("order_package") && !(exitedBinding[0]["order_package"] is DBNull) && exitedBinding[0]["order_package"].ToString() == "0" ?
									"基本包，" : "订单包，";
								existedMapping += type;
							}
                               
                        }
                    }
                    #endregion
                    #region 清洗程序是否被器械模块占用
                    DataTable getdt01 = remoteCall.RemotInterface.SelectData("HCS-instrument-base-sec003", null);//器械模块
                    if (getdt != null)
                    {
                        if (getdt.Columns.Contains("washing_type"))
                        {
                            DataRow[] exitedBinding = getdt.Select(string.Format("washing_type='{0}'", dgv_01.SelectedRows[0].Cells["id"].Value));
                            if (exitedBinding.Length > 0)
                                existedMapping += "器械模块，";
                        }
                    }
                    #endregion

                    if (!string.IsNullOrEmpty(existedMapping))
                    {
                        existedMapping = existedMapping.Substring(0, existedMapping.Length - 1);
                        MessageBox.Show(string.Format("{0}占用该清洗程序，如要删除该清洗程序，请先解除与以上的关联。", existedMapping), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["pr_name"].Value.ToString(), "清洗程序" }), "删除清洗程序", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                    sltmp.Add(1, sltmp01);
                    int recint = remoteCall.RemotInterface.UPData(1, "HCS-washing-program-del001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "清洗程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "清洗程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_washing_program_new hcsm = new HCSCM_washing_program_new(null, arrayDR);
            // 获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetWashingPrograms();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void OnDataGridDoubleClick(object sender, GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }
    }
}
