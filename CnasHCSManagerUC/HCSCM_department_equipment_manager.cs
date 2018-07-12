using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using Telerik.WinControls.UI;
using System.Collections;
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_department_equipment_manager : UserControl
    {
        public HCSCM_department_equipment_manager()
        {
            InitializeComponent();
            LoadFromEvent();
            LoadButtonImage();
        }
        /// <summary>
        ///加载button图片
        /// </summary>
        private void LoadButtonImage()
        {
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Register", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_putcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            this.btn_theLibrary.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OutGoing", EnumImageType.PNG);
            this.bnt_manualCount.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "ManualCount", EnumImageType.PNG);
            this.btn_Selrecord.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Journal", EnumImageType.PNG);
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void LoadFromEvent()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //器械类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            this.cb_type.Items.Add("----所有----");

            foreach (DataRow dr in typeDR)
            {
                cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }
            cb_type.Text = "----所有----";

            //成本中心
            DataTable getdt03 = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (getdt03 != null)
            {
                this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
                int ii = getdt03.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt03.Rows[i]["id"].ToString() != null && getdt03.Rows[i]["ca_name"].ToString().Trim() != null)
                    {

                        cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt03.Rows[i]["ca_name"].ToString().Trim(), Value = getdt03.Rows[i]["id"].ToString() });
                    }
                }
                cb_cost_center.Text = "----所有----";
            }

            //顾客
            DataTable getdt04 = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt04 != null)
            {
                this.cb_customer.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });

                int ii = getdt04.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt04.Rows[i]["id"].ToString() != null && getdt04.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        cb_customer.Items.Add(new RadListDataItem() { Text = getdt04.Rows[i]["cu_name"].ToString().Trim(), Value = getdt04.Rows[i]["id"].ToString() });
                    }
                }
                cb_customer.SelectedIndex = 0;
            }


        }
        /// <summary>
        /// 加载DGV数据
        /// </summary>
        private void LoadData()
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            string str_usertp = this.cb_customer.Text;
            string str_cc_id = this.cb_cost_center.Text;
            string str_type = this.cb_type.Text;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //    string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("hcs-instrument-costcenter-detail-sel001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-instrument-costcenter-detail-sel001", null);
            if (getdt == null) return;
            string selectSql = string.Format("( in_name like '%{0}%' and current_count<>0)", strsecdata);
            if (str_usertp != "----所有----")
                selectSql += string.Format(" and in_customer='{0}'", str_usertp);
            if (str_cc_id != "----所有----")
                selectSql += string.Format(" and in_costcenter='{0}'", str_cc_id);
            if (str_type != "----所有----")
                selectSql += string.Format(" and in_type='{0}'", str_type);
            //selectSql += " order by id";
            DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();


            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;

            foreach (DataRow dr in arrayDR)
            {
                if (!string.IsNullOrEmpty(dr["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (!string.IsNullOrEmpty(dr["in_name"].ToString())) dgv_01.Rows[i].Cells["in_name"].Value = dr["in_name"].ToString();
                if (!string.IsNullOrEmpty(dr["instrument_base_id"].ToString())) dgv_01.Rows[i].Cells["base_id"].Value = dr["instrument_base_id"].ToString();
                if (!string.IsNullOrEmpty(dr["in_customer"].ToString())) dgv_01.Rows[i].Cells["in_customer"].Value = dr["in_customer"].ToString();
                if (!string.IsNullOrEmpty(dr["in_costcenter"].ToString())) dgv_01.Rows[i].Cells["in_costcenter"].Value = dr["in_costcenter"].ToString();
                if (!string.IsNullOrEmpty(dr["in_costcenterID"].ToString())) dgv_01.Rows[i].Cells["in_costcenterID"].Value = dr["in_costcenterID"].ToString();
                if (!string.IsNullOrEmpty(dr["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                if (!string.IsNullOrEmpty(dr["mod_date"].ToString())) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                if (!string.IsNullOrEmpty(dr["total_count"].ToString())) dgv_01.Rows[i].Cells["total_count"].Value = dr["total_count"].ToString();
                if (!string.IsNullOrEmpty(dr["current_count"].ToString())) dgv_01.Rows[i].Cells["current_count"].Value = dr["current_count"].ToString();
                if (!string.IsNullOrEmpty(dr["check_count"].ToString())) dgv_01.Rows[i].Cells["check_count"].Value = dr["check_count"].ToString();
                if (!string.IsNullOrEmpty(dr["set_count"].ToString())) dgv_01.Rows[i].Cells["set_count"].Value = dr["set_count"].ToString();
                if (!string.IsNullOrEmpty(dr["in_customerID"].ToString())) dgv_01.Rows[i].Cells["in_customerID"].Value = dr["in_customerID"].ToString();
                i++;
            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void OnSelectChangeEven(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.cb_cost_center.Items.Clear();

            this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });

            DataTable getdt = null;
            string str = cb_customer.SelectedItem.Value.ToString();//获取键，即cu_id条码
            SortedList sl_barcode = new SortedList();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            if (str != "0")
            {

                sl_barcode.Add(1, str);
                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            }
            else
            {
                sl_barcode.Add(1, CnasBaseData.SystemID);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec001", sl_barcode);//成本中心

            }
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        this.cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["bar_code"].ToString().Trim() });
                    }
                }
            }
            cb_cost_center.SelectedIndex = 0;
        }

        private void OnSelectCostcenterChange(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadData();
        }

        private void OnSelectTypeChengeEvEnt(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// 点击事件,导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_putcycle_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "部门器械");
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='instrument'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_department_equipment_manager_new hcscm = new HCSCM_department_equipment_manager_new(true);
            hcscm.ShowDialog();
            LoadData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_edit_Click(object sender, EventArgs e)
        {
            int type = 0;
            if (dgv_01.CurrentRow.Cells["set_count"].Value.ToString() != "0")
            {
                type = 1;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            HCSCM_department_equipment_manager_edit hcscm = new HCSCM_department_equipment_manager_edit(int.Parse(dgv_01.SelectedRows[0].Cells["id"].Value.ToString()), dgv_01.SelectedRows[0].Cells["in_customer"].Value.ToString(), type, dgv_01.SelectedRows[0].Cells["total_count"].Value.ToString(), dgv_01.SelectedRows[0].Cells["current_count"].Value.ToString(), int.Parse(dgv_01.SelectedRows[0].Cells["base_id"].Value.ToString()));
            hcscm.ShowDialog();
            LoadData();
            if (dgv_01.Rows.Count > 0 && dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (dgv_01.CurrentRow.Cells["set_count"].Value.ToString() != "0")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("setOccupy", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "器械库存数据" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["in_name"].Value.ToString(), "器械库存" }), ConfigurationManager.AppSettings["SystemName"] + "--删除灭菌器", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                // string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-costcenter-detail-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-costcenter-detail-del001", sltmp, null);

                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "器械库存数据" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_theLibrary_Click(object sender, EventArgs e)
        {
            #region 出入库旧数据
            //int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            //SortedList slindata = new SortedList();
            //try
            //{
            //    slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
            //    slindata.Add("in_name", dgv_01.SelectedRows[0].Cells["in_name"].Value);
            //    slindata.Add("base_id", dgv_01.SelectedRows[0].Cells["base_id"].Value);
            //    slindata.Add("in_customer", dgv_01.SelectedRows[0].Cells["in_customer"].Value);
            //    slindata.Add("in_costcenter", dgv_01.SelectedRows[0].Cells["in_costcenter"].Value);
            //    slindata.Add("in_costcenterID", dgv_01.SelectedRows[0].Cells["in_costcenterID"].Value);
            //    slindata.Add("cre_date", dgv_01.SelectedRows[0].Cells["cre_date"].Value);
            //    slindata.Add("mod_date", dgv_01.SelectedRows[0].Cells["mod_date"].Value);
            //    slindata.Add("total_count", dgv_01.SelectedRows[0].Cells["total_count"].Value);
            //    slindata.Add("current_count", dgv_01.SelectedRows[0].Cells["current_count"].Value);
            //    slindata.Add("set_count", dgv_01.SelectedRows[0].Cells["set_count"].Value);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //HCSCM_department_equipment_manager_output hcscm = new HCSCM_department_equipment_manager_output(slindata, 1);
            //hcscm.ShowDialog();
            //LoadData();
            //if (dgv_01.Rows.Count > selectedIndex)
            //{
            //    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];

            //}
            #endregion

            //HCSCM_department_equipment_manager_new hcscm = new HCSCM_department_equipment_manager_new(false);
            HCSCM_department_equipment_manager_issue hcscm = new HCSCM_department_equipment_manager_issue(null);
            hcscm.ShowDialog();
            LoadData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }

        }

        private void dgv_01_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_01_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            //if (dgv_01.CurrentRow.Cells["total_count"].Value.ToString() == dgv_01.CurrentRow.Cells["current_count"].Value.ToString() && dgv_01.CurrentRow.Cells["set_count"].Value.ToString() == "0")
            //{
            //    but_edit.Enabled = true;
            //    but_remove.Enabled = true;
            //}
            //else
            //{
            //    but_edit.Enabled = false;
            //    but_remove.Enabled = false;
            //}
        }

        private void bnt_manualCount_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("in_name", dgv_01.SelectedRows[0].Cells["in_name"].Value);
                slindata.Add("base_id", dgv_01.SelectedRows[0].Cells["base_id"].Value);
                slindata.Add("in_customer", dgv_01.SelectedRows[0].Cells["in_customer"].Value);
                slindata.Add("in_costcenter", dgv_01.SelectedRows[0].Cells["in_costcenter"].Value);
                slindata.Add("in_costcenterID", dgv_01.SelectedRows[0].Cells["in_costcenterID"].Value);
                slindata.Add("cre_date", dgv_01.SelectedRows[0].Cells["cre_date"].Value);
                slindata.Add("mod_date", dgv_01.SelectedRows[0].Cells["mod_date"].Value);
                slindata.Add("total_count", dgv_01.SelectedRows[0].Cells["total_count"].Value);
                slindata.Add("current_count", dgv_01.SelectedRows[0].Cells["current_count"].Value);
                slindata.Add("set_count", dgv_01.SelectedRows[0].Cells["set_count"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HCSCM_department_equipment_manager_output hcscm = new HCSCM_department_equipment_manager_output(slindata, 2);
            hcscm.ShowDialog();
            LoadData();
            if (dgv_01.Rows.Count > 0 && dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];

            }
        }

        private void btn_Record_Click_1(object sender, EventArgs e)
        {
            HCSCM_department_equipment_manager_record hcscm = new HCSCM_department_equipment_manager_record();
            hcscm.ShowDialog();
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadData();
            }
        }

        private void btn_Selrecord_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "查看的", "物品" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgv_01.SelectedRows[0].Cells["in_name"].Value.ToString();
            dgv_01.SelectedRows[0].Cells["base_id"].Value.ToString();
            HCSCM_department_equipment_manager_Selrecord hcscm = new HCSCM_department_equipment_manager_Selrecord(dgv_01.SelectedRows[0].Cells["base_id"].Value.ToString(), dgv_01.SelectedRows[0].Cells["in_costcenterID"].Value.ToString());
            hcscm.ShowDialog();
        }

        private void dgv_01_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows[0].Cells["current_count"].Value.ToString() == "0")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("ReSelection", EnumPromptMessage.warning, new string[] { }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            HCSCM_department_equipment_manager_issue hcscm = new HCSCM_department_equipment_manager_issue(dgv_01.CurrentRow);
            hcscm.ShowDialog();
            LoadData();
            if (dgv_01.Rows.Count > 0 && dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }




    }
}
