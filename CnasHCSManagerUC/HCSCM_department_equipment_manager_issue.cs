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
    public partial class HCSCM_department_equipment_manager_issue : TemplateForm
    {

        private Dictionary<string, DataRow> _tempData = new Dictionary<string, DataRow>();
        private Dictionary<string, GridViewRowInfo> _tempDataDgv01 = new Dictionary<string, GridViewRowInfo>();
        int indexKey = 0;//第一key值，避免重复
        SortedList conditionAll = new SortedList();
        /// <summary>
        /// 出库日志集合
        /// </summary>
        SortedList conditionStorageInput = new SortedList();
        /// <summary>
        /// 出库数据修改
        /// </summary>
        SortedList conditionUp = new SortedList();
        /// <summary>
        /// 初始化时是否执行
        /// </summary>
        bool _loadFromStar = false;
        /// <summary>
        /// 点击修改器械数量时用到
        /// </summary>
        int _itemNum = 0;
        /// <summary>
        /// 选择的要出库的数据
        /// </summary>
        GridViewRowInfo SelRow = null;
        public HCSCM_department_equipment_manager_issue(GridViewRowInfo row)
        {
            InitializeComponent();
            #region 加载图片
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--部门器械出库";
            #endregion
            SelRow = row;
        }

        private void but_addone_Click(object sender, EventArgs e)
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

        private void but_reone_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_01.ClearSelection();
                dynamic sourceCollection = (from item in dgv_02.SelectedRows select item).ToList();
                if (sourceCollection != null)
                {
                    //List<GridViewRowInfo> aa = sourceCollection.ToList();
                    int count = sourceCollection.Count;

                    for (int i = 0; i < count; i++)
                    {
                        GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                        //GridViewRowInfo row = item as GridViewRowInfo;
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
                            //if (_tempData.ContainsKey(row.Cells["id"].Value.ToString()))
                            //{
                            //    indexKey++;
                            //    SaveItemUp("0", row.Cells["current_count"].Value.ToString(), row.Cells["id"].Value.ToString(), indexKey);//修改库存
                            //    SaveInput(row.Cells["id"].Value.ToString(), "2", _tempData[row.Cells["id"].Value.ToString()]["total_count"].ToString(), indexKey, true);
                            //}


                            theRightData(row);



                            int index = dgv_02.Rows.IndexOf(row);
                            dgv_02.Rows.Remove(row);//
                            //count--;
                            //i--;
                        }
                        else
                        {


                            theRightData(row);


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
                newRow.Tag = row.Tag;
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
                newRow.Tag = row.Tag;
            }
        }


        private void but_save_Click(object sender, EventArgs e)
        {
            #region 出库保存动作
            if (dgv_02.RowCount == 0)
            {
                return;
            }


            for (int i = 0; i < dgv_02.RowCount; i++)
            {
                indexKey++;
                //出库保存，添加日志
                // SaveItemUp(dgv_01.Rows[i].Cells["number"].Value.ToString(), "0", dgv_01.Rows[i].Cells["id"].Value.ToString(), indexKey);
                SaveInput(dgv_02.Rows[i].Cells["id"].Value.ToString(), "2", dgv_02.Rows[i].Cells["current_count"].Value.ToString(), indexKey, false);
                DataRow row = dgv_02.Rows[i].Tag as DataRow;
                if (row == null) return;
                if (dgv_02.Rows[i].Cells["current_count"].Value.ToString() == row["current_count"].ToString())
                {
                    SaveItemUp(dgv_02.Rows[i].Cells["number"].Value.ToString(), "0", dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
                }
                else
                {
                    int residualCount = int.Parse(row["current_count"].ToString()) - int.Parse(dgv_02.Rows[i].Cells["current_count"].Value.ToString());
                    SaveItemUp(dgv_02.Rows[i].Cells["number"].Value.ToString(), residualCount.ToString(), dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
                }

                //if (_tempData.ContainsKey(dgv_02.Rows[i].Cells["id"].Value.ToString()))//表2存在则修改
                //{

                //    //  SaveItemUp(dgv_02.Rows[i].Cells["number"].Value.ToString(), _tempData[dgv_02.Rows[i].Cells["id"].Value.ToString()].["current_count"].Value.ToString(), dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
                //}
                //else
                //{
                //    SaveItemUp(dgv_02.Rows[i].Cells["number"].Value.ToString(), "0", dgv_02.Rows[i].Cells["id"].Value.ToString(), indexKey);
                //}

            }

            //交互数据库
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            if (conditionUp.Count > 0 || conditionStorageInput.Count > 0)
            {
                conditionAll.Add(1, conditionUp);
                conditionAll.Add(5, conditionStorageInput);
                string tes = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-in-out-log-all001", conditionAll);
                int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-in-out-log-all001", conditionAll);

                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "出库" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            #endregion
        }

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
            if (SelRow != null)
            {
                int k = 0;
                cb_customer.Text = SelRow.Cells["in_customer"].Value.ToString();
                foreach (RadListDataItem item in cb_customer.Items)
                {
                    if (cb_customer.Text == item.Text)
                    {
                        cb_customer.SelectedIndex = k;
                    }
                    k++;
                }
                //for (int i = 0; i < cb_customer.MaxLength; i++)
                //{
                //    if (cb_customer.Text == cb_customer)
                //    {
                //        cb_customer.SelectedIndex = i;
                //        break;
                //    }
                //}
                int j = 0;
                cb_cost_center.Text = SelRow.Cells["in_costcenter"].Value.ToString();
                foreach (RadListDataItem item in cb_cost_center.Items)
                {
                    if (cb_cost_center.Text == item.Text)
                    {
                        cb_cost_center.SelectedIndex = j;
                    }
                    j++;
                }

                LoadDataDgv02();
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {
                    if (dgv_01.Rows[i].Cells["id2"].Value.ToString() == SelRow.Cells["id"].Value.ToString())
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[i];
                        break;
                    }
                }
            }
            else
            {
                LoadDataDgv02();
            }



        }
        /// <summary>
        /// 把dgv02的数据填写到字典上
        /// </summary>
        private void DictionaryTempDataDgv01()
        {
            _tempDataDgv01.Clear();
            for (int i = 0; i < dgv_02.Rows.Count; i++)
            {
                _tempDataDgv01.Add(dgv_02.Rows[i].Cells["id2"].Value.ToString(), dgv_02.Rows[i]);
            }
        }

        private void LoadDataDgv02()
        {
            DictionaryTempDataDgv01();
            _tempData.Clear();
            // initialDataDgv02.Rows.Clear();
            dgv_01.Rows.Clear();
            dgv_02.Rows.Clear();
            dgv_01.ClearSelection();
            dgv_02.ClearSelection();
            
            string str_usertp = this.cb_customer.Text;
            string str_cc_id = this.cb_cost_center.Text;
            string str_type = this.cb_type.SelectedItem.Value.ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            // string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("hcs-instrument-costcenter-detail-sel001", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-instrument-costcenter-detail-sel001", null);
            if (getdt == null) return;
            string selectSql = "current_count<>0";
            if (str_usertp != "----所有----")
                selectSql += string.Format(" and in_customer='{0}'", str_usertp);
            if (str_cc_id != "----所有----")
                selectSql += string.Format(" and in_costcenter='{0}'", str_cc_id);
            if (str_type != "0")
                selectSql += string.Format(" and type_id='{0}'", str_type);
            //selectSql += " order by id";
            DataRow[] arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            int rowCount = dgv_01.RowCount - 1;
            foreach (DataRow dr in arrayDR)
            {
                if (!string.IsNullOrEmpty(dr["current_count"].ToString()))
                {
                    if (_tempDataDgv01.ContainsKey(dr["id"].ToString()))
                    {
                        int Dgv02CurrentCount = int.Parse(_tempDataDgv01[dr["id"].ToString()].Cells["current_count"].Value.ToString());
                        int totalCount = int.Parse(dr["current_count"].ToString()) - Dgv02CurrentCount;
                        if (totalCount == 0)
                        {
                            dgv_01.RowCount = rowCount--;
                            continue;
                        }
                        else
                        {
                            dgv_01.Rows[i].Cells["current_count"].Value = int.Parse(dr["current_count"].ToString()) - Dgv02CurrentCount;
                        }
                    }
                    else
                    {
                        dgv_01.Rows[i].Cells["current_count"].Value = dr["current_count"].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(dr["id"].ToString())) dgv_01.Rows[i].Cells["id2"].Value = dr["id"].ToString();
                if (!string.IsNullOrEmpty(dr["instrument_base_id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["instrument_base_id"].ToString();
                if (!string.IsNullOrEmpty(dr["in_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = dr["in_name"].ToString();
                if (!string.IsNullOrEmpty(dr["total_count"].ToString())) dgv_01.Rows[i].Cells["number"].Value = dr["total_count"].ToString();

                _tempData.Add(dr["instrument_base_id"].ToString(), dr);
                dgv_01.Rows[i].Tag = dr;
                i++;
            }
            // initialDataDgv02 = (DataTable)dgv_01.DataSource;
            //获取dgv_01表的数据
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void OnselectChangeEvent(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

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

            if (_loadFromStar)
            {
                LoadDataDgv02();
            }
        }

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_02.Rows.Clear();
            if (_loadFromStar)
            {
                LoadDataDgv02();
            }
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_loadFromStar)
            {
                LoadDataDgv02();
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
        /// <summary>
        /// 用于点击修改时对dgv_01与dgv_02的修改
        /// </summary>
        /// <param name="dgv_02"></param>
        /// <param name="dgv_01"></param>
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
                            newRow.Tag = dgv_02.CurrentRow.Tag;
                        }
                    }
                    //  dgv_02.Rows.Remove(dgv_02.CurrentRow);

                }
            }
        }

        private void addRows(RadGridView dgv_02, RadGridView dgv_01)
        {
            GridViewRowInfo newRow = dgv_01.Rows.AddNew();
            if (_tempData.ContainsKey(dgv_02.CurrentRow.Cells["id"].Value.ToString()))
            {
                newRow.Cells[0].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["instrument_base_id"].ToString();
                newRow.Cells[1].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["id"].ToString();
                newRow.Cells[2].Value = _tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["in_name"].ToString();
                newRow.Cells[3].Value = int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["total_count"].ToString());
                newRow.Cells[4].Value = int.Parse(_tempData[dgv_02.CurrentRow.Cells["id"].Value.ToString()]["current_count"].ToString());
            }
            dgv_02.Rows.Remove(dgv_02.CurrentRow);
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

        private void dgv_02_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            ManualModification(dgv_02, dgv_01);
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

        private void but_sel_Click(object sender, EventArgs e)
        {
            if (_loadFromStar)
            {
                LoadDataDgv02();
            }
        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadDataDgv02();
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

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入

            }
        }
    }
}
