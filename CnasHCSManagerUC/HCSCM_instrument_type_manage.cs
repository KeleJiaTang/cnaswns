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
using System.Configuration;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_instrument_type_manage : UserControl
    {
        DataTable getdt01 = new DataTable();
        DataTable getdt02 = new DataTable();
        DataTable getdt03 = new DataTable();
        DataTable getdt04 = new DataTable();
        private SortedList sl_vender = new SortedList();
        private SortedList sl_sales = new SortedList();
        private SortedList sl_type01 = new SortedList();
        private SortedList sl_type_str = new SortedList();
        private SortedList sl_type_complexity = new SortedList();
        private SortedList sl_type = new SortedList();
        private SortedList sl_type_was = new SortedList();
        private SortedList sl_type_customer = new SortedList();
        private SortedList sl_type_customer_id = new SortedList();
        private SortedList sl_type_costcenter = new SortedList();
        private DataRow[] arrayDR = null;
        //private string slselect = "";
        public HCSCM_instrument_type_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_dis_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "pictureView", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_putcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            this.but_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Photo", EnumImageType.PNG);
            this.but_imput.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "photoImport", EnumImageType.PNG);

            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            this.but_imput.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "photoImport", EnumImageType.PNG);
            this.but_addItem.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "addItem", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            //清洗难度
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] ctypeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_complexity'");
            foreach (DataRow dr in ctypeDR)
            {
                sl_type_complexity.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            //器械类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            this.cb_type.Items.Add("----所有----");
            sl_type.Add("0", "----所有----");
            foreach (DataRow dr in typeDR)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }
            cb_type.Text = "----所有----";
            //清洗程序
            getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-program-sec001", null);
            if (getdt01 != null)
            {
                sl_type_was.Add("0", "无清洗程序");
                int ii = getdt01.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt01.Rows[i]["id"].ToString() != null && getdt01.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_was.Add(getdt01.Rows[i]["id"].ToString(), getdt01.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }
            //灭菌程序
            getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);
            if (getdt02 != null)
            {
                sl_type_str.Add("0", "无灭菌程序");
                int ii = getdt02.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt02.Rows[i]["id"].ToString() != null && getdt02.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_str.Add(getdt02.Rows[i]["id"].ToString(), getdt02.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }
            //成本中心
            getdt03 = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (getdt03 != null)
            {
                this.cb_cost_center.Items.Add("----所有----");
                sl_type_costcenter.Add("0", "----所有----");
                int ii = getdt03.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt03.Rows[i]["bar_code"].ToString() != null && getdt03.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_type_costcenter.Add(getdt03.Rows[i]["bar_code"].ToString(), getdt03.Rows[i]["ca_name"].ToString().Trim());
                        cb_cost_center.Items.Add(getdt03.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
                cb_cost_center.Text = "----所有----";


            }
            DataTable getdt05 = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            if (getdt05 != null)
            {
                //生产商
                DataRow[] vender = getdt05.Select("vender_type=1 or vender_type=3");
                foreach (DataRow dr in vender)
                {
                    sl_vender.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());

                }
                //销售商
                DataRow[] sales = getdt05.Select("vender_type=2 or vender_type=3");
                foreach (DataRow dr in sales)
                {
                    sl_sales.Add(dr["id"].ToString().Trim(), dr["v_name"].ToString().Trim());
                }
            }

            //顾客
            getdt04 = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt04 != null)
            {
                //this.cb_customer.Items.Add("----所有----");
                this.cb_customer.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
            //    sl_type_customer.Add("0", "----所有----");
                sl_type_customer_id.Add("0", "----所有----");
                int ii = getdt04.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt04.Rows[i]["bar_code"].ToString() != null && getdt04.Rows[i]["cu_name"].ToString().Trim() != null)
                    {

                        sl_type_customer_id.Add(getdt04.Rows[i]["id"].ToString(), getdt04.Rows[i]["cu_name"].ToString().Trim());
                        //sl_type_customer.Add(getdt04.Rows[i]["bar_code"].ToString(), getdt04.Rows[i]["cu_name"].ToString().Trim());
                       // cb_customer.Items.Add(getdt04.Rows[i]["cu_name"].ToString().Trim());
                        this.cb_customer.Items.Add(new RadListDataItem() { Text = getdt04.Rows[i]["cu_name"].ToString().Trim(), Value = getdt04.Rows[i]["bar_code"].ToString() });
                    }
                }
                cb_customer.SelectedIndex = 0;
                //cb_customer.Text = "----所有----";
            }

            GetData();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
            ////表格栏底色
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            ////DGV表格首行字段居中对齐
            //dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        /// <summary>
        /// 用于读取数据库数据
        /// </summary>
        private void Loaddata(string cu_barcode, string type)
        {
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = null;
            //不同的条件查出不同的器械
            if (cu_barcode == null && type == null)
            {
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);//搜索全部基本包
            }
            else if (cu_barcode != null && type == null)
            {
                sttemp01.Add(2, cu_barcode);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec002", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec002", sttemp01);
            }
            else if (cu_barcode == null && type != null)
            {
                sttemp01.Add(2, type);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec006", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec006", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                sttemp01.Add(3, type);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec007", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec007", sttemp01);
            }
            if (getdt != null && getdt.Rows.Count > 0)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                   // if (getdt.Columns.Contains("ca_customer") && getdt.Rows[i]["ca_customer"] != null) dgv_01.Rows[i].Cells["ca_customer"].Value = sl_type_customer[getdt.Rows[i]["ca_customer"].ToString()].ToString();
                    if (getdt.Columns.Contains("ca_type") && getdt.Rows[i]["ca_type"] != null) dgv_01.Rows[i].Cells["ca_type"].Value = sl_type[getdt.Rows[i]["ca_type"].ToString()].ToString();
                    //  if (getdt.Rows[i]["ca_brand"] != null) dgv_01.Rows[i].Cells["ca_brand"].Value = getdt.Rows[i]["ca_brand"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["ca_brand"].ToString())) dgv_01.Rows[i].Cells["ca_brand"].Value = getdt.Rows[i]["ca_brand"].ToString();
                    if (getdt.Columns.Contains("ca_price") && getdt.Rows[i]["ca_price"] != null) dgv_01.Rows[i].Cells["ca_price"].Value = double.Parse(getdt.Rows[i]["ca_price"].ToString()).ToString("C");
                    if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = sl_type_costcenter[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Columns.Contains("ca_times") && getdt.Rows[i]["ca_times"] != null) dgv_01.Rows[i].Cells["ca_times"].Value = getdt.Rows[i]["ca_times"].ToString();
                    if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("ca_type") && getdt.Rows[i]["ca_type"] != null) dgv_01.Rows[i].Cells["ca_type"].Value = sl_type[getdt.Rows[i]["ca_type"].ToString()].ToString();
                    if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Columns.Contains("ca_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_remarks"].ToString())) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["ca_complexity"].ToString())) dgv_01.Rows[i].Cells["ca_complexity"].Value = sl_type_complexity[getdt.Rows[i]["ca_complexity"].ToString()].ToString();
                    if (getdt.Columns.Contains("ca_vender") && getdt.Rows[i]["ca_vender"] != null) dgv_01.Rows[i].Cells["ca_vender"].Value = sl_vender[getdt.Rows[i]["ca_vender"].ToString()].ToString();
                    if (getdt.Columns.Contains("sales_id") && getdt.Rows[i]["sales_id"] != null) dgv_01.Rows[i].Cells["sales_id"].Value = sl_sales[getdt.Rows[i]["sales_id"].ToString()].ToString();
                    ////如果是辅料或一次性器械则不取内容
                    //if (getdt.Rows[i]["ca_type"].ToString() != "2" && getdt.Rows[i]["ca_type"].ToString() != "3")
                    //{
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["washing_program"].ToString())) dgv_01.Rows[i].Cells["washing_program"].Value = sl_type_was[getdt.Rows[i]["washing_program"].ToString()].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["sterilizer_program"].ToString())) dgv_01.Rows[i].Cells["sterilizer_program"].Value = sl_type_str[getdt.Rows[i]["sterilizer_program"].ToString()].ToString();
                    //}
                    //else
                    //{
                    //    if (!string.IsNullOrEmpty(getdt.Rows[i]["washing_program"].ToString())) dgv_01.Rows[i].Cells["washing_program"].Value = "";
                    //    if (!string.IsNullOrEmpty(getdt.Rows[i]["sterilizer_program"].ToString())) dgv_01.Rows[i].Cells["sterilizer_program"].Value = "";
                    //}

                    if (getdt.Columns.Contains("ca_weight") && getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = getdt.Rows[i]["ca_weight"].ToString();
                    if (getdt.Columns.Contains("ca_size") && getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = getdt.Rows[i]["ca_size"].ToString();
                    if (getdt.Columns.Contains("bargain_price") && getdt.Rows[i]["bargain_price"] != null) dgv_01.Rows[i].Cells["bargain_price"].Value = getdt.Rows[i]["bargain_price"].ToString();


                }
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }

        }
        //新建
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_instrument_type_manage_new hcsm = new HCSCM_instrument_type_manage_new(null, arrayDR, getdt01, getdt02, getdt03, getdt04);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("ca_type", dgv_01.SelectedRows[0].Cells["ca_type"].Value);
                slindata.Add("ca_complexity", dgv_01.SelectedRows[0].Cells["ca_complexity"].Value);
                ////如果是辅料或敷料则不取内容
                //if (dgv_01.SelectedRows[0].Cells["ca_type"].Value.ToString() != "辅料" && dgv_01.SelectedRows[0].Cells["ca_type"].Value.ToString() != "敷料")
                //{
                if (dgv_01.SelectedRows[0].Cells["washing_program"].Value != null && dgv_01.SelectedRows[0].Cells["washing_program"].Value != "")//判断清洗程序是否有值，有值则添加，否则赋“”
                {
                    slindata.Add("washing_program", sl_type_was.GetKey(sl_type_was.IndexOfValue(dgv_01.SelectedRows[0].Cells["washing_program"].Value)));
                }
                else
                {
                    slindata.Add("washing_program", "");
                }

                if (dgv_01.SelectedRows[0].Cells["sterilizer_program"].Value != null && dgv_01.SelectedRows[0].Cells["sterilizer_program"].Value != "")//判断灭菌程序是否有值，有值则添加，否则赋“”
                {
                    slindata.Add("sterilizer_program", sl_type_str.GetKey(sl_type_str.IndexOfValue(dgv_01.SelectedRows[0].Cells["sterilizer_program"].Value)));
                }
                else
                {
                    slindata.Add("sterilizer_program", "");
                }

                //}
                //else
                //{
                //    slindata.Add("washing_program", "");
                //    slindata.Add("sterilizer_program", "");
                //}

                slindata.Add("ca_weight", dgv_01.SelectedRows[0].Cells["ca_weight"].Value);
                slindata.Add("ca_size", dgv_01.SelectedRows[0].Cells["ca_size"].Value);
                slindata.Add("ca_times", dgv_01.SelectedRows[0].Cells["ca_times"].Value);
                slindata.Add("ca_vender", sl_vender.GetKey(sl_vender.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_vender"].Value)));
                slindata.Add("sales_id", sl_sales.GetKey(sl_sales.IndexOfValue(dgv_01.SelectedRows[0].Cells["sales_id"].Value)));
                slindata.Add("ca_customer", dgv_01.SelectedRows[0].Cells["cu_name"].Value);
                //slindata.Add("cost_center", dgv_01.SelectedRows[0].Cells["cost_center"].Value);
                slindata.Add("ca_price", double.Parse(dgv_01.SelectedRows[0].Cells["ca_price"].Value.ToString().Substring(1)));
                slindata.Add("ca_brand", dgv_01.SelectedRows[0].Cells["ca_brand"].Value);
                slindata.Add("bargain_price", dgv_01.SelectedRows[0].Cells["bargain_price"].Value);
                HCSCM_instrument_type_manage_new hcsm = new HCSCM_instrument_type_manage_new(slindata, arrayDR, getdt01, getdt02, getdt03, getdt04);
                hcsm.ShowDialog();
                GetData();
                if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //删除
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                string remove = "器械模板被";
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                #region 判断器械模板是否被实体器械占用
                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-sec002", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ins_id"].ToString() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ins_id"].ToString().Trim())
                            {
                                remove = "实体器械，";
                                break;

                            }
                        }
                    }
                }

                #endregion

                #region 判断器械模板是否被基本包关联
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-instrument-sec001", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {

                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["instrument_id"].ToString().Trim())
                        {
                            remove = remove + "基本包器械";
                            break;
                        }
                    }

                }

                #endregion

                #region 判断模板是否被库存占用

                getdt = reCnasRemotCall_01.RemotInterface.SelectData("hcs-instrument-costcenter-detail-sel001", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {

                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["instrument_base_id"].ToString().Trim())
                        {
                            remove = remove + "库存器械";
                            break;
                        }
                    }

                }

                #endregion

                if (remove != "器械模板被")
                {
                    MessageBox.Show(remove + "占用，如要删除，请先解除与以上的关联。");
                    return;
                }
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "器械模板" }), ConfigurationManager.AppSettings["SystemName"] + "--删除器械模块", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasremotCall = new CnasRemotCall();
                int recint = reCnasremotCall.RemotInterface.UPData(1, "HCS-instrument-base-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //添加器械（传器械模版参数过去）
        private void but_add_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "添加实体器械的", "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_01.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList slselect = new SortedList();
                slselect.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slselect.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                HCSCM_instrument_manage hcsm = new HCSCM_instrument_manage(slselect);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                GetData();
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void GetData()
        {
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            string strsecdata = tb_sname.Text.Trim();

            string str_usertp = cb_customer.SelectedItem.Value.ToString() ;
            string str_cc_id = sl_type_costcenter.GetKey(sl_type_costcenter.IndexOfValue(this.cb_cost_center.Text)).ToString();
            string str_type = sl_type.GetKey(sl_type.IndexOfValue(this.cb_type.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            // string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);
            if (getdt == null) return;
            string selectSql = string.Format("( ca_name like '%{0}%')", strsecdata);
            if (str_usertp != "0")
                selectSql += string.Format(" and ca_customer='{0}'", str_usertp);
            if (str_cc_id != "0")
                selectSql += string.Format(" and cost_center='{0}'", str_cc_id);
            if (str_type != "0")
                selectSql += string.Format(" and ca_type='{0}'", str_type);
            //selectSql += " order by id";
            arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();


            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (!string.IsNullOrEmpty(dr["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_customer"].ToString())) dgv_01.Rows[i].Cells["ca_customer"].Value = dr["ca_customer"].ToString();
                if (!string.IsNullOrEmpty(dr["cu_name"].ToString())) dgv_01.Rows[i].Cells["cu_name"].Value = dr["cu_name"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_type"].ToString())) dgv_01.Rows[i].Cells["ca_type"].Value = sl_type[dr["ca_type"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["ca_brand"].ToString())) dgv_01.Rows[i].Cells["ca_brand"].Value = dr["ca_brand"].ToString();
                //   if (getdt.Rows[i]["ca_brand"] != null) dgv_01.Rows[i].Cells["ca_brand"].Value = dr["ca_brand"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_price"].ToString())) dgv_01.Rows[i].Cells["ca_price"].Value = double.Parse(dr["ca_price"].ToString()).ToString("C");
                //if (!string.IsNullOrEmpty(dr["cost_center"].ToString())) dgv_01.Rows[i].Cells["cost_center"].Value = sl_type_costcenter[dr["cost_center"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["ca_times"].ToString())) dgv_01.Rows[i].Cells["ca_times"].Value = dr["ca_times"].ToString();
                if (!string.IsNullOrEmpty(dr["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_type"].ToString())) dgv_01.Rows[i].Cells["ca_type"].Value = sl_type[dr["ca_type"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["mod_date"].ToString())) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_remarks"].ToString())) dgv_01.Rows[i].Cells["ca_remarks"].Value = dr["ca_remarks"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_complexity"].ToString())) dgv_01.Rows[i].Cells["ca_complexity"].Value = sl_type_complexity[dr["ca_complexity"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["ca_vender"].ToString())) dgv_01.Rows[i].Cells["ca_vender"].Value = sl_vender[dr["ca_vender"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["sales_id"].ToString())) dgv_01.Rows[i].Cells["sales_id"].Value = sl_sales[dr["sales_id"].ToString()].ToString();
                //如果是辅料或一次性器械则不取内容
                //string a = getdt.Rows[i]["ca_type"].ToString();
                //if (dr["ca_type"].ToString() != "2" && dr["ca_type"].ToString() != "3")
                //{
                if (!string.IsNullOrEmpty(dr["washing_program"].ToString())) dgv_01.Rows[i].Cells["washing_program"].Value = sl_type_was[dr["washing_program"].ToString()].ToString();
                if (!string.IsNullOrEmpty(dr["sterilizer_program"].ToString())) dgv_01.Rows[i].Cells["sterilizer_program"].Value = Convert.ToString(sl_type_str[dr["sterilizer_program"].ToString()]);
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(dr["washing_program"].ToString())) dgv_01.Rows[i].Cells["washing_program"].Value = "";
                //    if (!string.IsNullOrEmpty(dr["sterilizer_program"].ToString())) dgv_01.Rows[i].Cells["sterilizer_program"].Value = "";
                //}
                if (getdt.Rows[i]["washing_program"] != null) dgv_01.Rows[i].Cells["washing_program"].Value = sl_type_was[dr["washing_program"].ToString()];
                if (getdt.Rows[i]["sterilizer_program"] != null) dgv_01.Rows[i].Cells["sterilizer_program"].Value = sl_type_str[dr["sterilizer_program"].ToString()];
                if (!string.IsNullOrEmpty(dr["ca_weight"].ToString())) dgv_01.Rows[i].Cells["ca_weight"].Value = dr["ca_weight"].ToString();
                if (!string.IsNullOrEmpty(dr["ca_size"].ToString())) dgv_01.Rows[i].Cells["ca_size"].Value = dr["ca_size"].ToString();
                if (!string.IsNullOrEmpty(dr["bargain_price"].ToString())) dgv_01.Rows[i].Cells["bargain_price"].Value = dr["bargain_price"].ToString();
                i++;
            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                GetData();
            }
        }



        private void but_sel_Click(object sender, EventArgs e)
        {
            GetData();
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "手术器械");
        }


        /// <summary>
        /// 添加照片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_media_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：器械
                sortedList.Add("type", "2");
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "查看", "器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：器械
                sortedList.Add("type", "2");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", "");

                HCSCM_set_manage_image HCSCM_set_manage_image = new HCSCM_set_manage_image(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_set_manage_image.ShowInTaskbar = false;
                HCSCM_set_manage_image.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void but_imput_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：包
                sortedList.Add("type", "2");
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

        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='instrument'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;


        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void but_import_click(object sender, eventargs e)
        //{
        //    excelhelper.improtdatatoexcel(this.dgv_01, "手术器械");
        //}


        //private void tb_sname_textchanged_1(object sender, eventargs e)
        //{
        //}












        private void dgv_01_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void but_import_Click_2(object sender, EventArgs e)
        {
            //int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            HCSCM_instrument_type_import hcsm = new HCSCM_instrument_type_import();
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }





        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetData();
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetData();
        }

       

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void OnSelectedIndexChnaged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            sl_type_costcenter.Clear();
            this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
            sl_type_costcenter.Add("0", "----所有----");
            DataTable getdt = null;
            string str = sl_type_customer_id.GetKey(sl_type_customer_id.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id条码
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
                        sl_type_costcenter.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());

                        this.cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["bar_code"].ToString().Trim() });
                    }
                }
            }
            cb_cost_center.SelectedIndex = 0;
            //cb_cost_center.Text = "----所有----";
          //  GetData();

        }









    }
}






