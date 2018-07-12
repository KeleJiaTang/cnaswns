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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_department_equipment_manager_new : TemplateForm
    {
        /// <summary>
        /// 多个存储点开关
        /// </summary>
        bool ifMoreStroage = false;
        int indexKey = 0;//第一key值，避免重复
        //int stockValue = 0;//实体库存量
        SortedList conditionUp = new SortedList();
        SortedList conditionNew = new SortedList();
        SortedList conditionStorage = new SortedList();
        SortedList conditionStorageNew = new SortedList();
        SortedList conditionStorageInput = new SortedList();
        SortedList conditionAll = new SortedList();

        //  DataTable initialDataDgv02 = new DataTable();

        SortedList SlStorageId = new SortedList();//存储对应的器械ID和数量

        DataTable getDtStroageItem = null;
        DataRow[] arrayDRStroage = null;
        string storageId = "";
        string outputSpecialKey = "";//没保存前右移出库问题，如果左移还原，保存时会清楚对应的入库数据

        bool IfStorage = true;

        bool _loadFromStar = false;

        int _itemNum = 0;//点击修改器械数量时用到

        public HCSCM_department_equipment_manager_new(bool Storage)
        {
            InitializeComponent();
            IfStorage = Storage;
            #region 加载图片
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--登记部门器械";
            #endregion
            //显示出库时需要的字段
            if (!IfStorage)
            {
                lb_type.Visible = false;
                lb_storage.Visible = false;
                cb_type.Visible = false;
                cb_storage.Visible = false;
                radlb_sel.Visible = false;
                tb_sname.Visible = false;
                but_sel.Visible = false;
                dgv_01.Columns[4].IsVisible = true;
                dgv_02.Columns[3].IsVisible = false;
                dgv_02.Columns[4].IsVisible = true;
            }
            else
            {
                dgv_01.Columns[2].Width = 250;
            }


        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFromEnent(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        cb_customer.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["cu_name"].ToString().Trim(), Value = getdt.Rows[i]["id"].ToString() });
                    }
                }
                cb_customer.SelectedIndex = 0;
            }
            // LoadDataDgv01();
            //器械类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            this.cb_type.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
            //  sl_type.Add("0", "----所有----");
            foreach (DataRow dr in typeDR)
            {

                //  sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());

                cb_type.Items.Add(new RadListDataItem() { Text = dr["value_code"].ToString().Trim(), Value = dr["key_code"].ToString().Trim() });
                //cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }

            // cb_type.Text = "----所有----";
            cb_type.SelectedIndex = 0;

            _loadFromStar = true;
            if (IfStorage)
            {
                LoadDataDgv01();
            }

            LoadDataDgv02();
        }
        private void LoadDataDgv01()
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            string str_cuid = this.cb_customer.SelectedItem.Value.ToString();
            string str_type = this.cb_type.SelectedItem.Value.ToString();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);
            if (getdt == null) return;
            string selectSql = string.Format("( ca_name like '%{0}%')", strsecdata);
            if (str_cuid != "0")
                selectSql += string.Format(" and ca_customerID='{0}'", str_cuid);
            if (str_type != "0")
                selectSql += string.Format(" and ca_type='{0}'", str_type);
            //selectSql += " order by id";
            DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                i++;
            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void LoadDataDgv02()
        {
            _tempData.Clear();
            // initialDataDgv02.Rows.Clear();
            SlStorageId.Clear();
            dgv_02.Rows.Clear();
            string str_usertp = this.cb_customer.Text;
            string str_cc_id = this.cb_cost_center.Text;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            // string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("hcs-instrument-costcenter-detail-sel001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-instrument-costcenter-detail-sel001", null);
            getDtStroageItem = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-data-sel003", null);
            if (getdt == null) return;
            string selectSql = "";
            if (!IfStorage)
                selectSql = "current_count<>0";
            if (str_usertp != "----所有----")
                if (!IfStorage)
                {
                    selectSql += string.Format(" and in_customer='{0}'", str_usertp);
                }
                else
                {
                    selectSql += string.Format("  in_customer='{0}'", str_usertp);
                }
            if (str_cc_id != "----所有----")
                selectSql += string.Format(" and in_costcenter='{0}'", str_cc_id);
            //selectSql += " order by id";
            DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();

            int ii = arrayDR.Length;
            if (ii <= 0) return;
            if (!IfStorage)
            {
                dgv_02.RowCount = ii;
            }

            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (!IfStorage)
                {
                    if (!string.IsNullOrEmpty(dr["id"].ToString()))
                    {
                        storageId = "";
                        dgv_02.Rows[i].Cells["id2"].Value = dr["id"].ToString();
                        if (getDtStroageItem != null)
                        {
                            arrayDRStroage = getDtStroageItem.Select("entity_id=" + dr["id"].ToString());
                            foreach (DataRow drStroage in arrayDRStroage)
                            {
                                storageId = storageId + drStroage["storage_id"].ToString() + ",";
                            }
                        }
                    }
                    if (storageId != "") dgv_02.Rows[i].Cells["storage_id"].Value = storageId;
                    if (!string.IsNullOrEmpty(dr["instrument_base_id"].ToString())) dgv_02.Rows[i].Cells["id"].Value = dr["instrument_base_id"].ToString();
                    if (!string.IsNullOrEmpty(dr["in_name"].ToString())) dgv_02.Rows[i].Cells["ca_name"].Value = dr["in_name"].ToString();
                    if (!string.IsNullOrEmpty(dr["total_count"].ToString())) dgv_02.Rows[i].Cells["number"].Value = dr["total_count"].ToString();
                    if (!string.IsNullOrEmpty(dr["current_count"].ToString())) dgv_02.Rows[i].Cells["current_count"].Value = dr["current_count"].ToString();
                }


                _tempData.Add(dr["instrument_base_id"].ToString(), dr);

                SlStorageId.Add(dr["instrument_base_id"].ToString(), storageId);
                i++;
            }
            // initialDataDgv02 = (DataTable)dgv_02.DataSource;
            //获取dgv_02表的数据


            if (dgv_02.Rows.Count > 0)
            {
                dgv_02.CurrentRow = dgv_02.Rows[0];
            }
        }


        private void tb_set_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void OnselectChangeEvent(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_02.Rows.Clear();
            this.cb_cost_center.Items.Clear();
            DataTable getdt = null;
            string str = cb_customer.SelectedItem.Value.ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            sl_barcode.Add(1, str);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        this.cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["id"].ToString().Trim() });
                    }
                }
                cb_cost_center.SelectedIndex = 0;
            }

            this.cb_storage.Items.Clear();
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec050", sl_barcode);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec050", sl_barcode);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["s_name"].ToString().Trim() != null)
                    {
                        this.cb_storage.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["s_name"].ToString().Trim(), Value = getdt.Rows[i]["id"].ToString().Trim() });
                    }
                }
            }
            if (IfStorage && _loadFromStar)
            {
                LoadDataDgv01();
            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            if (IfStorage && _loadFromStar)
            {
                LoadDataDgv01();
            }
        }

        /// <summary>
        /// 向右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_addone_Click(object sender, EventArgs e)
        {
            if (IfStorage)
            {
                #region 入库操作
                IList<GridViewRowInfo> sourceCollection = null;
                sourceCollection = dgv_01.SelectedRows;
                if (sourceCollection != null)
                {
                    int count = sourceCollection.Count;
                    for (int i = 0; i < count; i++)
                    {
                        bool ifNewRows = true;
                        GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                        for (int k = 0; k < dgv_02.RowCount; k++)
                        {
                            try
                            {
                                int.Parse(dgv_02.Rows[k].Cells["current_count"].Value.ToString());
                            }
                            catch
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.Rows[i].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (row.Cells["id"].Value.ToString() == dgv_02.Rows[k].Cells["id"].Value.ToString())
                            {
                                dgv_02.Rows[k].Cells["number"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["number"].Value.ToString());
                                dgv_02.Rows[k].Cells["current_count"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["current_count"].Value.ToString());
                                ifNewRows = false;
                            }
                        }
                        if (ifNewRows)
                        {
                            GridViewRowInfo newRow = dgv_02.Rows.AddNew();
                            if (_tempData.ContainsKey(row.Cells["id"].Value.ToString()))
                            {
                                //dgv_02.Rows.Add(_tempData[row.Cells["id"].Value.ToString()]);
                                //DataRow data = _tempData[row.Cells["id"].Value.ToString()];
                                newRow.Cells[0].Value = _tempData[row.Cells["id"].Value.ToString()]["instrument_base_id"].ToString();
                                newRow.Cells[1].Value = _tempData[row.Cells["id"].Value.ToString()]["id"].ToString();
                                newRow.Cells[2].Value = _tempData[row.Cells["id"].Value.ToString()]["in_name"].ToString();
                                newRow.Cells[3].Value = tb_number.Text;
                                newRow.Cells[4].Value = int.Parse(tb_number.Text);
                                if (!string.IsNullOrEmpty(_tempData[row.Cells["id"].Value.ToString()]["id"].ToString()))
                                {
                                    storageId = "";

                                    if (getDtStroageItem != null)
                                    {
                                        arrayDRStroage = getDtStroageItem.Select("entity_id=" + _tempData[row.Cells["id"].Value.ToString()]["id"].ToString());
                                        foreach (DataRow drStroage in arrayDRStroage)
                                        {
                                            storageId = storageId + drStroage["storage_id"].ToString() + ",";
                                        }
                                    }
                                }
                                if (storageId != "")
                                    newRow.Cells[5].Value = storageId;
                            }
                            else
                            {
                                newRow.Cells[0].Value = row.Cells[0].Value;
                                newRow.Cells[1].Value = row.Cells[1].Value;
                                newRow.Cells[2].Value = row.Cells[2].Value;
                                newRow.Cells[3].Value = tb_number.Text;
                                newRow.Cells[4].Value = tb_number.Text;
                            }
                        }
                    }
                }
                #endregion

            }
            else
            {
                #region 出库操作

                dynamic sourceCollection = (from item in dgv_01.SelectedRows select item).ToList();
                if (sourceCollection != null)
                {
                    //List<GridViewRowInfo> aa = sourceCollection.ToList();
                    int count = sourceCollection.Count;

                    for (int i = 0; i < count; i++)
                    {
                        GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                        try
                        {
                            int.Parse(row.Cells["current_count"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { "选中移动项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        row.Cells["current_count"].Value = int.Parse(row.Cells["current_count"].Value.ToString()) - int.Parse(tb_number.Text);
                        if (int.Parse(row.Cells["current_count"].Value.ToString()) <= 0)
                        {
                            //if (_tempData.ContainsKey(row.Cells["id"].Value.ToString()))
                            //{
                            //    indexKey++;
                            //    SaveItemUp("0", row.Cells["current_count"].Value.ToString(), row.Cells["id"].Value.ToString(), indexKey);//修改库存
                            //    SaveInput(row.Cells["id"].Value.ToString(), "2", _tempData[row.Cells["id"].Value.ToString()]["total_count"].ToString(), indexKey, true);
                            //}

                            // theRightData(row);
                            theLeftData(row);
                            int index = dgv_01.Rows.IndexOf(row);
                            dgv_01.Rows.Remove(row);//
                            //count--;
                            //i--;
                        }
                        else
                        {
                            theLeftData(row);
                        }
                    }
                }

                #endregion
            }

        }

        private void theLeftData(GridViewRowInfo row)
        {
            bool ifNewRows = true;
            for (int k = 0; k < dgv_02.RowCount; k++)
            {
                try
                {
                    int.Parse(dgv_02.Rows[k].Cells["current_count"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.Rows[k].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (row.Cells["id"].Value.ToString() == dgv_02.Rows[k].Cells["id"].Value.ToString())
                {
                    if (int.Parse(row.Cells[4].Value.ToString()) >= 0)
                    {
                        dgv_02.Rows[k].Cells["current_count"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["current_count"].Value.ToString());
                    }
                    else
                    {
                        dgv_02.Rows[k].Cells["current_count"].Value = int.Parse(row.Cells[4].Value.ToString()) + int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["current_count"].Value.ToString());
                    }


                    ifNewRows = false;
                }
            }
            if (ifNewRows)//判断是否需要新填一行数据
            {
                GridViewRowInfo newRow = dgv_02.Rows.AddNew();
                newRow.Cells[0].Value = row.Cells[0].Value;
                newRow.Cells[1].Value = row.Cells[1].Value;
                newRow.Cells[2].Value = row.Cells[2].Value;
                newRow.Cells[3].Value = row.Cells[3].Value;
                newRow.Cells[5].Value = row.Cells[5].Value;
                if (int.Parse(row.Cells[4].Value.ToString()) >= 0)
                {
                    newRow.Cells[4].Value = tb_number.Text;
                }
                else
                {
                    newRow.Cells[4].Value = int.Parse(row.Cells[4].Value.ToString()) + int.Parse(tb_number.Text);
                }

            }
        }

        private Dictionary<string, DataRow> _tempData = new Dictionary<string, DataRow>();

        /// <summary>
        /// 向左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_reone_Click(object sender, EventArgs e)
        {
            //IList<GridViewRowInfo> sourceCollection = null;
            try
            {
                dynamic sourceCollection = (from item in dgv_02.SelectedRows select item).ToList();
                if (sourceCollection != null)
                {
                    int count = sourceCollection.Count;
                    for (int i = 0; i < count; i++)
                    {
                        GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                        try
                        {
                            int.Parse(row.Cells["current_count"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { "选中移动项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        row.Cells["number"].Value = int.Parse(row.Cells["number"].Value.ToString());
                        row.Cells["current_count"].Value = int.Parse(row.Cells["current_count"].Value.ToString()) - int.Parse(tb_number.Text);
                        if (int.Parse(row.Cells["current_count"].Value.ToString()) <= 0)
                        {
                            if (!IfStorage)
                            {
                                theRightData(row);
                            }
                            int index = dgv_02.Rows.IndexOf(row);
                            dgv_02.Rows.Remove(row);
                        }
                        else
                        {
                            if (!IfStorage)
                            {
                                theRightData(row);
                            }
                            if (!row.IsSelected)
                                row.IsSelected = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void theRightData(GridViewRowInfo row)
        {
            bool ifNewRows = true;
            for (int k = 0; k < dgv_01.RowCount; k++)
            {
                try
                {
                    int.Parse(row.Cells["current_count"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { row.Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (row.Cells["id"].Value.ToString() == dgv_01.Rows[k].Cells["id"].Value.ToString())
                {
                    if (int.Parse(row.Cells[4].Value.ToString()) >= 0)
                    {
                        dgv_01.Rows[k].Cells["current_count"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_01.Rows[k].Cells["current_count"].Value.ToString());
                    }
                    else
                    {
                        dgv_01.Rows[k].Cells["current_count"].Value = int.Parse(row.Cells[4].Value.ToString()) + int.Parse(tb_number.Text) + int.Parse(dgv_01.Rows[k].Cells["current_count"].Value.ToString());
                    }
                    ifNewRows = false;
                }
            }
            if (ifNewRows)//判断是否需要新填一行数据
            {
                GridViewRowInfo newRow = dgv_01.Rows.AddNew();
                newRow.Cells[0].Value = row.Cells[0].Value;
                newRow.Cells[1].Value = row.Cells[1].Value;
                newRow.Cells[2].Value = row.Cells[2].Value;
                newRow.Cells[3].Value = row.Cells[3].Value;
                newRow.Cells[5].Value = row.Cells[5].Value;
                if (int.Parse(row.Cells[4].Value.ToString()) >= 0)
                {
                    newRow.Cells[4].Value = tb_number.Text;
                }
                else
                {
                    newRow.Cells[4].Value = int.Parse(row.Cells[4].Value.ToString()) + int.Parse(tb_number.Text);
                }
            }
        }

        private Dictionary<string, GridViewRowInfo> _tempDataSave = new Dictionary<string, GridViewRowInfo>();

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_save_Click(object sender, EventArgs e)
        {
            #region 注释掉以前的内容
            //if (outputSpecialKey != "")
            //{
            //    string[] key = outputSpecialKey.Split(',');
            //    for (int i = 0; i < key.Length; i++)
            //    {
            //        if (key[i] != "")
            //        {
            //            conditionStorageInput.Remove(int.Parse(key[i]));
            //        }
            //    }

            //}
            //if (this.cb_cost_center.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (ifMoreStroage)
            //{
            //    for (int i = 0; i < dgv_02.RowCount; i++)
            //    {
            //        if (dgv_02.Rows[i].Cells["id2"].Value != null && dgv_02.Rows[i].Cells["storage_id"].Value != null)
            //        {
            //            if (dgv_02.Rows[i].Cells["storage_id"].Value.ToString() != cb_storage.Text)
            //            {
            //                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("NotMoreStroage", EnumPromptMessage.warning, new string[] { dgv_02.Rows[i].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //        if (dgv_02.Rows[i].Cells["id2"].Value != null)
            //        {
            //            //验证数量少于原来的
            //        }

            //    }
            //}
            //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //for (int i = 0; i < dgv_02.RowCount; i++)
            //{
            //    indexKey++;
            //    try
            //    {
            //        int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString().ToString());
            //    }
            //    catch
            //    {
            //        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.Rows[i].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    if (dgv_02.Rows[i].Cells["id2"].Value != null)
            //    {
            //        int starNum = int.Parse(SlStorageId[dgv_02.Rows[i].Cells["id"].Value.ToString()].ToString());
            //        int differenceNum = int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString().ToString()) - starNum;
            //        SaveItemUp(dgv_02.Rows[i].Cells["number"].Value.ToString(), dgv_02.Rows[i].Cells["current_count"].Value.ToString(), dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
            //        if (differenceNum != 0)
            //        {
            //            #region 是否建立器械与存储点的关联关系
            //            if (dgv_02.Rows[i].Cells["storage_id"].Value != null)
            //            {
            //                if (cb_storage.Text != "")
            //                {
            //                    bool ifNewStroage = true;
            //                    string[] id = dgv_02.Rows[i].Cells["storage_id"].Value.ToString().Split(',');
            //                    for (int j = 0; j < id.Length; j++)
            //                    {
            //                        if (id[j] == cb_storage.SelectedItem.Value.ToString())
            //                        {
            //                            ifNewStroage = false;
            //                            break;
            //                        }
            //                    }
            //                    if (ifNewStroage)
            //                    {
            //                        SaveStorageInsert(0, dgv_02.Rows[i].Cells["id2"].Value.ToString(), indexKey);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                SaveStorageInsert(0, dgv_02.Rows[i].Cells["id2"].Value.ToString(), indexKey);
            //            }
            //            #endregion
            //            //判断是出库还是入库
            //            if (differenceNum < 0)
            //            {
            //                SaveInput(dgv_02.Rows[i].Cells["id"].Value.ToString(), "2", (-differenceNum).ToString(), indexKey, false);
            //            }
            //            else
            //            {
            //                SaveInput(dgv_02.Rows[i].Cells["id"].Value.ToString(), "1", differenceNum.ToString(), indexKey, false);
            //            }

            //        }


            //        //updata
            //    }
            //    else
            //    {
            //        SaveItemInsert(dgv_02.Rows[i].Cells["id"].Value.ToString(), dgv_02.Rows[i].Cells["number"].Value.ToString(), indexKey);
            //        SaveInput(dgv_02.Rows[i].Cells["id"].Value.ToString(), "1", dgv_02.Rows[i].Cells["number"].Value.ToString(), indexKey, false);
            //        SaveStorageInsertNew(0, dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
            //        //insert
            //    }

            //}
            //if (conditionUp.Count > 0 || conditionNew.Count > 0 || conditionStorage.Count > 0)
            //{
            //    conditionAll.Add(1, conditionUp);
            //    conditionAll.Add(2, conditionNew);
            //    conditionAll.Add(3, conditionStorage);
            //    conditionAll.Add(4, conditionStorageNew);
            //    conditionAll.Add(5, conditionStorageInput);
            //    string tes = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-in-out-log-all001", conditionAll);
            //    int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-in-out-log-all001", conditionAll);

            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();

            //}
            #endregion
            if (IfStorage)
            {
                #region 入库保存动作
                for (int i = 0; i < dgv_02.RowCount; i++)
                {
                    indexKey++;
                    if (_tempData.ContainsKey(dgv_02.Rows[i].Cells["id"].Value.ToString()))//判断是否已经存在
                    {
                        //存在则修改
                        int totalCount = int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()) + int.Parse(_tempData[dgv_02.Rows[i].Cells["id"].Value.ToString()]["total_count"].ToString());
                        int currentCount = int.Parse(dgv_02.Rows[i].Cells["current_count"].Value.ToString()) + int.Parse(_tempData[dgv_02.Rows[i].Cells["id"].Value.ToString()]["current_count"].ToString());
                        SaveItemUp(totalCount.ToString(), currentCount.ToString(), dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);

                        //判断存在的数据中是否有新添加关联关系的存储点
                        bool ifNewStroage = true;
                        if (arrayDRStroage != null)
                        {
                            arrayDRStroage = getDtStroageItem.Select("entity_id=" + _tempData[dgv_02.Rows[i].Cells["id"].Value.ToString()]["id"].ToString());
                            if (getDtStroageItem != null && cb_storage.Text != "")
                            {
                                foreach (DataRow drStroage in arrayDRStroage)
                                {
                                    if (drStroage["storage_id"].ToString() == cb_storage.SelectedItem.Value.ToString())
                                    {
                                        ifNewStroage = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (ifNewStroage)
                        {
                            SaveStorageInsert(0, _tempData[dgv_02.Rows[i].Cells["id"].Value.ToString()]["id"].ToString(), indexKey);
                        }
                    }
                    else
                    {
                        //不存在则新增加
                        SaveItemInsert(dgv_02.Rows[i].Cells["id"].Value.ToString(), dgv_02.Rows[i].Cells["number"].Value.ToString(), indexKey);

                        //如果选择了存储点则关联存储点
                        SaveStorageInsertNew(0, dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
                    }
                    //添加日志入库的信息
                    SaveInput(dgv_02.Rows[i].Cells["id"].Value.ToString(), "1", dgv_02.Rows[i].Cells["number"].Value.ToString(), indexKey, false);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                if (conditionUp.Count > 0 || conditionNew.Count > 0 || conditionStorage.Count > 0 || conditionStorageNew.Count > 0 || conditionStorageInput.Count > 0)
                {
                    conditionAll.Clear();
                    conditionAll.Add(1, conditionUp);
                    conditionAll.Add(2, conditionNew);
                    conditionAll.Add(3, conditionStorage);
                    conditionAll.Add(4, conditionStorageNew);
                    conditionAll.Add(5, conditionStorageInput);
                     string tes = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-in-out-log-all001", conditionAll);
                    int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-in-out-log-all001", conditionAll);

                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataDgv02();
                    conditionUp.Clear();
                    conditionNew.Clear();
                    conditionStorage.Clear();
                    conditionStorageNew.Clear();
                    conditionStorageInput.Clear();
                }
                #endregion
            }
            else
            {
                #region 出库保存动作
                if (dgv_01.RowCount == 0)
                {
                    return;
                }
                //先判断表一是否有数据
                _tempDataSave.Clear();
                for (int j = 0; j < dgv_02.RowCount; j++)
                {
                    _tempDataSave.Add(dgv_02.Rows[j].Cells["id"].Value.ToString(), dgv_02.Rows[j]);
                }

                for (int i = 0; i < dgv_01.RowCount; i++)
                {
                    indexKey++;
                    //出库保存，添加日志
                    // SaveItemUp(dgv_01.Rows[i].Cells["number"].Value.ToString(), "0", dgv_01.Rows[i].Cells["id"].Value.ToString(), indexKey);
                    SaveInput(dgv_01.Rows[i].Cells["id"].Value.ToString(), "2", dgv_01.Rows[i].Cells["current_count"].Value.ToString(), indexKey, false);
                    if (_tempDataSave.ContainsKey(dgv_01.Rows[i].Cells["id"].Value.ToString()))//表2存在则修改
                    {

                        SaveItemUp(dgv_01.Rows[i].Cells["number"].Value.ToString(), _tempDataSave[dgv_01.Rows[i].Cells["id"].Value.ToString()].Cells["current_count"].Value.ToString(), dgv_01.Rows[i].Cells["id"].Value.ToString(), indexKey);
                    }
                    else
                    {
                        SaveItemUp(dgv_01.Rows[i].Cells["number"].Value.ToString(), "0", dgv_01.Rows[i].Cells["id"].Value.ToString(), indexKey);
                    }

                }
                #region 旧代码
                //string alreadyOperateID = "";//记录已操作过得数据
                //for (int i = 0; i < dgv_01.RowCount; i++)
                //{
                //    for (int j = 0; j < dgv_02.RowCount; j++)
                //    {
                //        if (dgv_01.Rows[i].Cells["id"].Value == dgv_02.Rows[j].Cells["id"].Value)
                //        {
                //            indexKey++;
                //            //如果表1的数据==表2，出库保存，添加日志，并记录已经操作的数据
                //            alreadyOperateID = dgv_01.Rows[i].Cells["id"].Value.ToString() + ",";
                //            SaveItemUp(dgv_02.Rows[j].Cells["number"].Value.ToString(), dgv_02.Rows[j].Cells["current_count"].Value.ToString(), dgv_02.Rows[j].Cells["id"].Value.ToString(), indexKey);
                //            SaveInput(dgv_01.Rows[i].Cells["id"].Value.ToString(), "2", dgv_01.Rows[i].Cells["current_count"].Value.ToString(), indexKey, false);
                //            break;
                //        }
                //    }
                //}

                //for (int k = 0; k < dgv_01.RowCount; k++)
                //{
                //    string[] ID = alreadyOperateID.Split(',');
                //    for (int i = 0; i < ID.Length; i++)
                //    {
                //        if (ID[i] != "" && dgv_01.Rows[k].Cells["id"].Value.ToString() != ID[i])//筛选出未操作过得数据
                //        {
                //            indexKey++;
                //            //出库保存，添加日志
                //            SaveItemUp(dgv_01.Rows[k].Cells["number"].Value.ToString(), "0", dgv_01.Rows[k].Cells["id"].Value.ToString(), indexKey);
                //            SaveInput(dgv_01.Rows[k].Cells["id"].Value.ToString(), "2", dgv_01.Rows[k].Cells["current_count"].Value.ToString(), indexKey, false);
                //            break;
                //        }
                //    }
                //    if (dgv_02.Rows.Count == 0)
                //    {
                //        indexKey++;
                //        SaveItemUp(dgv_01.Rows[k].Cells["number"].Value.ToString(), "0", dgv_01.Rows[k].Cells["id"].Value.ToString(), indexKey);
                //        SaveInput(dgv_01.Rows[k].Cells["id"].Value.ToString(), "2", dgv_01.Rows[k].Cells["current_count"].Value.ToString(), indexKey, false);
                //    }
                //}
                #endregion

                //交互数据库
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                if (conditionUp.Count > 0 || conditionNew.Count > 0 || conditionStorage.Count > 0 || conditionStorageNew.Count > 0 || conditionStorageInput.Count > 0)
                {
                    conditionAll.Add(1, conditionUp);
                    conditionAll.Add(2, conditionNew);
                    conditionAll.Add(3, conditionStorage);
                    conditionAll.Add(4, conditionStorageNew);
                    conditionAll.Add(5, conditionStorageInput);
                    string tes = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-in-out-log-all001", conditionAll);
                    int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-in-out-log-all001", conditionAll);

                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                #endregion
            }
        }

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_loadFromStar)
            {
                LoadDataDgv02();
            }
        }
        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="total"></param>
        /// <param name="current"></param>
        /// <param name="itemId"></param>
        /// <param name="index"></param>
        private void SaveItemUp(string total, string current, string itemId, int index)
        {
            
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, total);
            sltmp01.Add(2, current);
            sltmp01.Add(3, CnasBaseData.UserID);
            sltmp01.Add(4, itemId);
            sltmp01.Add(5, cb_cost_center.SelectedItem.Value);
            conditionUp.Add(index + 1, sltmp01);

        }
        /// <summary>
        /// 增加库存数据
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="num"></param>
        /// <param name="index"></param>
        private void SaveItemInsert(string itemId, string num, int index)
        {
            
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, itemId);
            sltmp.Add(2, cb_cost_center.SelectedItem.Value);
            sltmp.Add(3, num);
            sltmp.Add(4, num);
            sltmp.Add(5, CnasBaseData.UserID);
            conditionNew.Add(index + 1, sltmp);
        }
        /// <summary>
        /// 增加存储点与库存的关联关系
        /// </summary>
        /// <param name="itemNum"></param>
        /// <param name="stroageId"></param>
        /// <param name="index"></param>
        private void SaveStorageInsert(int itemNum, string stroageId, int index)
        {
            if (cb_storage.Text != "")
            {
               
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttmpStorage = new SortedList();
                sttmpStorage.Add(1, stroageId);
                sttmpStorage.Add(2, cb_storage.SelectedItem.Value.ToString());
                conditionStorage.Add(index + 1, sttmpStorage);
            }
        }

        private void SaveStorageInsertNew(int itemNum, string itemId, int index)
        {
            if (cb_storage.Text != "")
            {
                
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttmpStorage = new SortedList();
                sttmpStorage.Add(1, itemId);
                sttmpStorage.Add(2, cb_storage.SelectedItem.Value.ToString());
                conditionStorageNew.Add(index + 1, sttmpStorage);
            }
        }

        /// <summary>
        /// 出入库
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="actType"></param>
        /// <param name="count"></param>
        /// <param name="index"></param>
        private void SaveInput(string itemId, string actType, string count, int index, bool type)
        {
            
            int key = index + 1;
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, itemId);
            sltmp.Add(2, cb_cost_center.SelectedItem.Value);
            sltmp.Add(3, actType);
            sltmp.Add(4, count);
            sltmp.Add(5, CnasBaseData.UserID);
            conditionStorageInput.Add(key, sltmp);
            if (type)
            {
                outputSpecialKey = key + ",";
            }
        }

        private void addRows(RadGridView dgv_02, RadGridView dgv_01)
        {
            GridViewRowInfo newRow = dgv_01.Rows.AddNew();
            if (_tempData.ContainsKey(dgv_02.CurrentRow.Cells["id"].Value.ToString()))
            {

                //dgv_02.Rows.Add(_tempData[row.Cells["id"].Value.ToString()]);
                //DataRow data = _tempData[row.Cells["id"].Value.ToString()];
                newRow.Cells[0].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["instrument_base_id"].ToString();
                newRow.Cells[1].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["id"].ToString();
                newRow.Cells[2].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["in_name"].ToString();
                newRow.Cells[3].Value = int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["total_count"].ToString());
                newRow.Cells[4].Value = int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["current_count"].ToString());
                if (!string.IsNullOrEmpty(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["id"].ToString()))
                {
                    storageId = "";
                    if (getDtStroageItem != null)
                    {
                        arrayDRStroage = getDtStroageItem.Select("entity_id=" + _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["id"].ToString());
                        foreach (DataRow drStroage in arrayDRStroage)
                        {
                            storageId = storageId + drStroage["storage_id"].ToString() + ",";
                        }
                    }
                }
                if (storageId != "")
                    newRow.Cells[5].Value = storageId;
            }

            dgv_02.Rows.Remove(dgv_02.CurrentRow);
        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"[0-9]+");
        }

        private void ManualModification(RadGridView dgv_02, RadGridView dgv_01)
        {
            if (dgv_02.CurrentRow.Cells["current_count"].Value != null && !CnasUtilityTools.IsNumeric(dgv_02.CurrentRow.Cells["current_count"].Value.ToString()))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.CurrentRow.Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_02.CurrentRow.Cells["current_count"].Value = _itemNum;
                return;
            }
            if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
            {
                string value = Convert.ToString(dgv_02.CurrentCell.Value);
                if (value == "0" || string.IsNullOrEmpty(value))
                {
                    //输入为空或者0时
                    if (IfStorage)
                    {
                        dgv_02.Rows.Remove(dgv_02.CurrentRow);
                    }
                    else
                    {
                        //移出表2数据，并把表二原本数据搬到表1上
                        if (dgv_01.RowCount == 0)
                        {
                            addRows(dgv_02, dgv_01);
                        }
                        else
                        {
                            int a = 0;//用于验证是否给表1添加新一行数据
                            int CurrentNum = 0;
                            for (int k = 0; k < dgv_01.RowCount; k++)
                            {
                                try
                                {
                                    CurrentNum = int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString());
                                }
                                catch
                                {
                                    CurrentNum = 0;
                                    //MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.CurrentRow.Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //return;
                                }
                                if (dgv_02.CurrentRow.Cells["id"].Value.ToString() == dgv_01.Rows[k].Cells["id"].Value.ToString())
                                {
                                    dgv_01.Rows[k].Cells["current_count"].Value = _itemNum - CurrentNum + int.Parse(dgv_01.Rows[k].Cells["current_count"].Value.ToString());
                                    dgv_02.Rows.Remove(dgv_02.CurrentRow);
                                }
                                else
                                {
                                    a++;
                                }
                            }
                            if (a == dgv_01.RowCount)//相等则说明没有相同的
                            {
                                addRows(dgv_02, dgv_01);
                            }
                        }
                    }
                }
                else
                {
                    if (int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString()) < 0 || int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString()) > _itemNum)
                    {
                        dgv_02.CurrentRow.Cells["current_count"].Value = _itemNum;
                        return;
                    }

                    int CurrentNum = 0;
                    try
                    {
                        CurrentNum = int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString());
                    }
                    catch
                    {
                        CurrentNum = 0;
                    }
                    //输入的不是0或空值时
                    if (!IfStorage)//对出库做操作
                    {
                        bool ifNewRows = true;

                        for (int k = 0; k < dgv_01.RowCount; k++)
                        {
                            if (dgv_02.CurrentRow.Cells["id"].Value.ToString() == dgv_01.Rows[k].Cells["id"].Value.ToString())
                            {
                                dgv_01.Rows[k].Cells["current_count"].Value = _itemNum - CurrentNum + int.Parse(dgv_01.Rows[k].Cells["current_count"].Value.ToString());
                                ifNewRows = false;
                            }
                        }
                        if (ifNewRows)//判断是否需要新填一行数据
                        {
                            if (_itemNum - CurrentNum != 0)
                            {
                                GridViewRowInfo newRow = dgv_01.Rows.AddNew();
                                newRow.Cells[0].Value = dgv_02.CurrentRow.Cells[0].Value;
                                newRow.Cells[1].Value = dgv_02.CurrentRow.Cells[1].Value;
                                newRow.Cells[2].Value = dgv_02.CurrentRow.Cells[2].Value;
                                newRow.Cells[3].Value = dgv_02.CurrentRow.Cells[3].Value;
                                newRow.Cells[5].Value = dgv_02.CurrentRow.Cells[5].Value;
                                newRow.Cells[4].Value = _itemNum - CurrentNum;
                            }
                        }
                    }
                }
            }
        }



        private void dgv_02_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            #region 旧代码已注释
            //if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
            //{
            //    string value = Convert.ToString(dgv_02.CurrentCell.Value);
            //    if (value == "0" || string.IsNullOrEmpty(value))
            //    {
            //        if (_tempData.ContainsKey(dgv_02.CurrentRow.Cells["id"].Value.ToString()))
            //        {
            //            indexKey++;
            //            SaveItemUp("0", dgv_02.CurrentRow.Cells["current_count"].Value.ToString(), dgv_02.CurrentRow.Cells["id"].Value.ToString(), indexKey);//修改库存
            //            SaveInput(dgv_02.CurrentRow.Cells["id"].Value.ToString(), "2", _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["total_count"].ToString(), indexKey, true);
            //        }

            //        editRow = dgv_02.Rows.IndexOf(dgv_02.CurrentRow);
            //        dgv_02.Rows.Remove(dgv_02.CurrentRow);
            //    }
            //    else
            //    {
            //        if (dgv_02.CurrentRow.Cells["id2"].Value != null)
            //        {
            //            try
            //            {
            //                int.Parse(dgv_02.CurrentRow.Cells["number"].Value.ToString());
            //            }
            //            catch
            //            {
            //                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { "选中移动项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //            _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["total_count"].ToString();
            //            dgv_02.CurrentRow.Cells["number"].Value.ToString();
            //            _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["current_count"].ToString();

            //            dgv_02.CurrentRow.Cells["current_count"].Value = int.Parse(dgv_02.CurrentRow.Cells["number"].Value.ToString()) - int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["total_count"].ToString()) + int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["current_count"].ToString());
            //        }
            //        else
            //        {
            //            dgv_02.CurrentRow.Cells["current_count"].Value = dgv_02.CurrentRow.Cells["number"].Value;
            //        }
            //    }
            //}
            #endregion

            ManualModification(dgv_02, dgv_01);


        }

        private void dgv_02_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //  but_reone_Click(null, null);
        }

        private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //  but_addone_Click(null, null);
        }

        private void dgv_02_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_02_CellClick(object sender, GridViewCellEventArgs e)
        {
            //每次点击时，记录器械的数量，作为节点数量
            //当选择一行时才有效
            if (dgv_02.SelectedRows.Count == 1 && dgv_02.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void dgv_01_CellClick(object sender, GridViewCellEventArgs e)
        {
            //每次点击时，记录器械的数量，作为节点数量
            //当选择一行时才有效
            if (dgv_01.SelectedRows.Count == 1 && dgv_01.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_01.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void dgv_01_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            ManualModification(dgv_01, dgv_02);
        }

        private void dgv_02_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv_02.SelectedRows.Count == 1 && dgv_02.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void dgv_01_MouseClick(object sender, MouseEventArgs e)
        {
            //每次点击时，记录器械的数量，作为节点数量
            //当选择一行时才有效
            if (dgv_01.SelectedRows.Count == 1 && dgv_01.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_01.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (IfStorage && _loadFromStar)
            {
                LoadDataDgv01();
            }
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadDataDgv01();
            }
        }

        private void dgv_01_KeyDown(object sender, KeyEventArgs e)
        {
            //每次点击时，记录器械的数量，作为节点数量
            //当选择一行时才有效
            if (dgv_01.SelectedRows.Count == 1 && dgv_01.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_01.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }
            }
        }

        private void dgv_02_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_02.SelectedRows.Count == 1 && dgv_02.CurrentRow.Cells["current_count"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_02.CurrentRow.Cells["current_count"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void tb_number_TextChanged(object sender, EventArgs e)
        {
            if (tb_number.Text.Trim() == "" || tb_number.Text.Trim() == "0")
            {
                tb_number.Text = "1";
                return;
            }
        }
    }
}
