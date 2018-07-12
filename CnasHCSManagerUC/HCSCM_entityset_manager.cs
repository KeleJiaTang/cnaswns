using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using Cnas.wns.CnasBarcodeLib;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_entityset_manager : UserControl
    {
        DataTable DTstorage = new DataTable();
        DataTable DTlocation = new DataTable();
        SortedList Sl_type_01 = new SortedList();
        SortedList Sl_type_02 = new SortedList();

        SortedList sl_type_customer_id = new SortedList();
        SortedList Sl_id = new SortedList();
        SortedList Sl_location = new SortedList();
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
        public HCSCM_entityset_manager()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_dis_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "pictureView", EnumImageType.PNG);
            this.but_incycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "outCycle", EnumImageType.PNG);
            this.but_putcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "feedingCycle", EnumImageType.PNG);
            this.but_newcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportNew", EnumImageType.PNG);
            this.but_oldcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "batchImportOld", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            this.but_rfid.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "configurationRFID", EnumImageType.PNG);
            #endregion

            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--器械包管理";
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCC'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
            DataRow[] arrayDR = null;//用于传输数据
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心


            if (getdt != null)
            {
                this.cb_cost_center.Items.Add("----所有----");
                Sl_type_01.Add("0", "----所有----");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
                cb_cost_center.Text = "----所有----";


            }
            DTstorage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            Sl_id.Add("0", "");
            if (DTstorage != null)
            {
                int ii = DTstorage.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTstorage.Rows[i]["id"].ToString() != null && DTstorage.Rows[i]["s_name"].ToString().Trim() != null)
                    {
                        Sl_id.Add(DTstorage.Rows[i]["id"].ToString().Trim(), DTstorage.Rows[i]["s_name"].ToString().Trim());
                    }
                }
            }

            //string s = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec001", null);

            DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        Sl_location.Add(DTlocation.Rows[i]["id"].ToString().Trim(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }

            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                arrayDR = getdt.Select();
                this.cb_customer.Items.Add("----所有----");
                Sl_type_02.Add("0", "----所有----");
                sl_type_customer_id.Add("0", "----所有----");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_02.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        sl_type_customer_id.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }

                cb_customer.SelectedIndex = 0;
            }
            //GetData();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }
        //private void Loaddata(string cu_barcode)
        //{
        //    dgv_01.Rows.Clear();
        //    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        //    SortedList sttemp01 = new SortedList();
        //    sttemp01.Add(1, CnasBaseData.SystemID);
        //    DataTable getdt = null;
        //    if (cu_barcode == null)
        //    {
        //        // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
        //        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
        //    }
        //    else
        //    {
        //        sttemp01.Add(2, cu_barcode);
        //        // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec003", sttemp01);
        //        getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec003", sttemp01);
        //    }


        //    if (getdt != null)
        //    {

        //        int ii = getdt.Rows.Count;
        //        if (ii <= 0) return;
        //        dgv_01.RowCount = ii;
        //        for (int i = 0; i < ii; i++)
        //        {
        //            dgv_01.Rows[i].Cells["select"].Value = false;

        //           // if (getdt.Columns.Contains("urgent") && getdt.Rows[i]["urgent"] != null) dgv_01.Rows[i].Cells["urgent"].Value = (getdt.Rows[i]["urgent"].ToString() == "1") ? "是" : "否";
        //            if (getdt.Columns.Contains("ca_priorityName") && getdt.Rows[i]["ca_priorityName"] != null) dgv_01.Rows[i].Cells["ca_priorityName"].Value = getdt.Rows[i]["ca_priorityName"].ToString();
        //            if (getdt.Columns.Contains("base_name") && getdt.Rows[i]["base_name"] != null) dgv_01.Rows[i].Cells["base_name"].Value = getdt.Rows[i]["base_name"].ToString();
        //            if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
        //            if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
        //            if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[getdt.Rows[i]["cost_center"].ToString()].ToString();
        //            if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
        //            if (getdt.Columns.Contains("ca_position") && getdt.Rows[i]["ca_position"] != null) dgv_01.Rows[i].Cells["ca_position"].Value = getdt.Rows[i]["ca_position"].ToString();
        //            if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
        //            if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
        //            if (getdt.Columns.Contains("storage_id") && getdt.Rows[i]["storage_id"] != null) dgv_01.Rows[i].Cells["storage_id"].Value = getdt.Rows[i]["storage_id"].ToString() == "0" ? "" : Sl_id[getdt.Rows[i]["storage_id"].ToString()].ToString();
        //            if (getdt.Columns.Contains("location_id") && getdt.Rows[i]["location_id"] != null) dgv_01.Rows[i].Cells["location_id"].Value = getdt.Rows[i]["location_id"].ToString() == "" ? "" : Sl_location[getdt.Rows[i]["location_id"].ToString()].ToString();
        //            if (getdt.Columns.Contains("customer_code") && getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = Sl_type_02[getdt.Rows[i]["customer_code"].ToString()].ToString();
        //            if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (getdt.Rows[i]["in_cycle"].ToString() == "9") ? "否" : "是";
        //            if (getdt.Columns.Contains("urgent") && getdt.Rows[i]["urgent"] != null) dgv_01.Rows[i].Cells["urgent"].Value = getdt.Rows[i]["urgent"].ToString();
        //            if (getdt.Columns.Contains("rfid_retrospect") && getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = getdt.Rows[i]["rfid_retrospect"].ToString();
        //            if (getdt.Columns.Contains("ca_priority") && getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = getdt.Rows[i]["ca_priority"].ToString().Trim();
        //        }
        //    }  
        //    if(dgv_01.Rows.Count>0)
        //    {
        //        dgv_01.CurrentRow = dgv_01.Rows[0];
        //    }
        //}

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_set_manager_set_new hcsm = new HCSCM_set_manager_set_new();
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("customer_code", dgv_01.SelectedRows[0].Cells["cu_name"].Value);//值是barcode
                slindata.Add("storage_id", dgv_01.SelectedRows[0].Cells["storage_id"].Value);
                slindata.Add("location_id", dgv_01.SelectedRows[0].Cells["location_id"].Value);
                slindata.Add("cost_center", dgv_01.SelectedRows[0].Cells["cc_name"].Value);
                slindata.Add("ca_position", dgv_01.SelectedRows[0].Cells["ca_position"].Value);
                slindata.Add("urgent", dgv_01.SelectedRows[0].Cells["urgent"].Value);
                slindata.Add("ca_priority", dgv_01.SelectedRows[0].Cells["ca_priority"].Value);
                slindata.Add("rfid_retrospect", dgv_01.SelectedRows[0].Cells["rfid_retrospect"].Value);

            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HCSCM_set_manager_set_edit hcsm = new HCSCM_set_manager_set_edit(slindata);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private Dictionary<string, string> _tempData = new Dictionary<string, string>();

        private void but_remove_Click(object sender, EventArgs e)
        {
            SortedList sltmpALL = new SortedList();

            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            //判断实体包是否在循环内
            if (dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString() == "是")
            {
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicecycledelete", EnumPromptMessage.warning, new string[] { }), "删除实体包", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //开始出循环

                SortedList slwork_id = new SortedList();
                slwork_id.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec006", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec006", slwork_id);//查出旧实体包原来的动作
                #region 出循环时，改工单和包的状态
                SortedList slcycle = new SortedList();
                SortedList slcycle01 = new SortedList();
                slcycle01.Add(1, 9);
                slcycle01.Add(2, dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slcycle01.Add(3, 6);
                slcycle01.Add(4, dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slcycle01.Add(5, getdt.Rows[0]["wf_code"].ToString());
                slcycle.Add(1, slcycle01);
                // string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-worksetupcycle-up001", slcycle, null);
                if (recint <= 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fail", EnumPromptMessage.warning, new string[] { }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion
            }
            else
            {
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "实体包" }), "删除实体包", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

          

            #region 修改包器械库存数量
            SortedList sltmpUpLiblaryAll = new SortedList();
            SortedList sltmpAddLiblaryAll = new SortedList();
            DataTable SelSetItem = GetSelItemNum(dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString());


            DataTable storageData = GetLibraryItemNum(dgv_01.SelectedRows[0].Cells["CCID"].Value.ToString());
            if (SelSetItem != null)
            {
                int key = 1;
                for (int i = 0; i < SelSetItem.Rows.Count; i++)
                {
                    _tempData.Clear();
                    int storyNum = 0;
                    int itemNum = 0;

                    if (SelSetItem.Rows[i]["instrument_num"].ToString() != "")//判断是器械是否有值
                    {
                        itemNum = int.Parse(SelSetItem.Rows[i]["instrument_num"].ToString());
                    }
                    if (storageData != null)
                    {
                        for (int j = 0; j < storageData.Rows.Count; j++)
                        {
                            _tempData.Add(storageData.Rows[j]["instrument_base_id"].ToString(), storageData.Rows[j]["in_set_count"].ToString());
                        }

                        for (int j = 0; j < storageData.Rows.Count; j++)
                        {
                            if (_tempData.ContainsKey(SelSetItem.Rows[i]["ca_instrument_id"].ToString()))
                            {

                                if (_tempData[SelSetItem.Rows[i]["ca_instrument_id"].ToString()].ToString() != "")
                                {
                                    storyNum = int.Parse(_tempData[SelSetItem.Rows[i]["ca_instrument_id"].ToString()].ToString());
                                    // storyNum = int.Parse(storageData.Rows[j]["in_set_count"].ToString());
                                }
                                else
                                {
                                    storyNum = 0;
                                }
                                storyNum -= itemNum;
                                SortedList sltmpUpLiblary = new SortedList();
                                sltmpUpLiblary.Add(1, storyNum);
                                sltmpUpLiblary.Add(2, CnasBaseData.UserID);
                                sltmpUpLiblary.Add(3, SelSetItem.Rows[i]["ca_instrument_id"].ToString());
                                sltmpUpLiblary.Add(4, dgv_01.SelectedRows[0].Cells["CCID"].Value.ToString());
                                sltmpUpLiblaryAll.Add(key, sltmpUpLiblary);
                                key++;
                                break;
                            }
                        }
                    }
                    
                }
            }

            sltmpALL.Add(1, sltmpUpLiblaryAll);
            string strrecint = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-costcenter-detail-up006", sltmpUpLiblaryAll);
            int recintALL = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-costcenter-detail-up006", sltmpUpLiblaryAll);
            #endregion


            

            #region 删除实体包
            DelSelSet();
            #endregion




        }
        //获取实体包的器械列表和对应数量
        //获取对应器械的库存量
        //在循环里扣除对应器械的数量

        /// <summary>
        /// 获取实体包的器械列表
        /// </summary>
        /// <param name="setID">实体包ID</param>
        /// <returns></returns>
        private DataTable GetSelItemNum(string setCode)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttempSetInfo = new SortedList();
            sttempSetInfo.Add(1,CnasBaseData.SystemID);
            sttempSetInfo.Add(2, setCode);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-info-sec007", sttempSetInfo);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-info-sec007", sttempSetInfo);
            return getdt;
        }
        /// <summary>
        /// 删除实体包
        /// </summary>
        /// <param name="setID">实体包ID</param>
        private void DelSelSet()
        {
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            int sucint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-del001", sltmp, null);
            if (sucint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                if (dgv_01.Rows.Count > 0)
                {
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



        /// <summary>
        /// 获得成本中心下所有库存器械
        /// </summary>
        /// <param name="costCenterID">成本中心</param>
        /// <returns></returns>
        private DataTable GetLibraryItemNum(string costCenterID)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttempSetInfo = new SortedList();
            sttempSetInfo.Add(1, costCenterID);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-costcenter-detail-sel004", sttempSetInfo);
            DataTable getdtLibrary = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-costcenter-detail-sel004", sttempSetInfo);
            // cb_cost_center.Text
            return getdtLibrary;
        }

        private void but_list_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            try
            {
                DataRow[] arrayDR = null;
                dgv_01.Rows.Clear();
                dgv_01.ClearSelection();
                string strsecdata = tb_sname.Text.Trim().ToUpper();

                string str_usertp = Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString();
                string str_cc_id = Sl_type_01.GetKey(Sl_type_01.IndexOfValue(this.cb_cost_center.Text)).ToString();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);
                if (getdt == null) return;
                string selectSql = string.Format("(bar_code like '%{0}%' or ca_name like '%{1}%')", strsecdata, strsecdata);
                if (str_usertp != "0")
                    selectSql += string.Format(" and customer_code='{0}'", str_usertp);
                if (str_cc_id != "0")
                    selectSql += string.Format(" and cost_center='{0}'", str_cc_id);

                arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    // if (getdt.Columns.Contains("urgent") && getdt.Rows[i]["urgent"] != null) dgv_01.Rows[i].Cells["urgent"].Value = (dr["urgent"].ToString() == "1") ? "是" : "否";
                    if (getdt.Columns.Contains("ca_priorityName") && getdt.Rows[i]["ca_priorityName"] != null) dgv_01.Rows[i].Cells["ca_priorityName"].Value = dr["ca_priorityName"].ToString();
                    if (getdt.Columns.Contains("base_name") && getdt.Rows[i]["base_name"] != null) dgv_01.Rows[i].Cells["base_name"].Value = dr["base_name"].ToString();
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                    if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = dr["cost_center"].ToString();
                    if (getdt.Columns.Contains("CCID") && getdt.Rows[i]["CCID"] != null) dgv_01.Rows[i].Cells["CCID"].Value = dr["CCID"].ToString();
                    if (getdt.Columns.Contains("cc_name") && getdt.Rows[i]["cc_name"] != null) dgv_01.Rows[i].Cells["cc_name"].Value = dr["cc_name"].ToString();
                    if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                    if (getdt.Columns.Contains("ca_position") && getdt.Rows[i]["ca_position"] != null) dgv_01.Rows[i].Cells["ca_position"].Value = dr["ca_position"].ToString();
                    if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                    if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                    if (getdt.Columns.Contains("storage_id") && getdt.Rows[i]["storage_id"] != null) dgv_01.Rows[i].Cells["storage_id"].Value = dr["storage_id"].ToString() == "0" ? "" : Sl_id[dr["storage_id"].ToString()].ToString();
                    if (getdt.Columns.Contains("location_id") && getdt.Rows[i]["location_id"] != null) dgv_01.Rows[i].Cells["location_id"].Value = dr["location_id"].ToString() == "" ? "" : Sl_location[dr["location_id"].ToString()].ToString();
                    if (getdt.Columns.Contains("customer_code") && getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = dr["customer_code"].ToString();
                    if (getdt.Columns.Contains("cu_name") && getdt.Rows[i]["cu_name"] != null) dgv_01.Rows[i].Cells["cu_name"].Value = dr["cu_name"].ToString();
                    if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (dr["in_cycle"].ToString() == "9") ? "否" : "是";
                    if (getdt.Columns.Contains("urgent") && getdt.Rows[i]["urgent"] != null) dgv_01.Rows[i].Cells["urgent"].Value = dr["urgent"].ToString();
                    if (getdt.Columns.Contains("run_times") && getdt.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["run_times"].Value = dr["run_times"].ToString();
                    if (getdt.Columns.Contains("rfid_retrospect") && getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = dr["rfid_retrospect"].ToString();
                    if (getdt.Columns.Contains("ca_priority") && getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = dr["ca_priority"].ToString().Trim();
                    i++;
                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                GetData();
            }
        }

        //private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.cb_customer.Text == "----所有----")
        //    {
        //        Loaddata(null);
        //    }
        //    else
        //    {
        //        Loaddata(Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString());
        //    }
        //}

        private void but_sel_Click(object sender, EventArgs e)
        {
            GetData();
        }



        private void but_incycle_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //var state = this.dgv_01.CurrentRow.Selected;
            //return;
            //判断选择的实体包是否在循环内
            if (dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString() == "否")
            {
                //判断是否选择了某一行
                if (this.dgv_01.SelectedRows.Count != 0)
                {
                    //集合存储，选择的这一横的，数据
                    SortedList Sl_select = new SortedList();
                    Sl_select.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                    Sl_select.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString());
                    Sl_select.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
                    Sl_select.Add("in_cycle", dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString());
                    //是否在循环中，初始化默认为不在
                    bool if_incycle = false;

                    if (dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString() == "是")
                    {
                        if_incycle = true;
                    }
                    else
                    {
                        if_incycle = false;
                    }
                    int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    HCSCM_in_cycle hcsm = new HCSCM_in_cycle(Sl_select, if_incycle);
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
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillloop", EnumPromptMessage.warning, new string[] { "在" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void but_putcycle_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //判断选择的实体包是否在循环内
            if (dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString() == "是")
            {
                //判断是否选择了某一行
                if (this.dgv_01.SelectedRows.Count != 0)
                {
                    int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    //集合存储，选择这一横的，数据
                    SortedList Sl_select = new SortedList();
                    Sl_select.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                    Sl_select.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString());
                    Sl_select.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
                    Sl_select.Add("in_cycle", dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString());
                    //是否在循环中，初始化默认为不在
                    bool if_incycle = false;

                    if (dgv_01.SelectedRows[0].Cells["in_cycle"].Value.ToString() == "是")
                    {
                        if_incycle = true;
                    }
                    else
                    {
                        if_incycle = false;
                    }

                    HCSCM_in_cycle hcsm = new HCSCM_in_cycle(Sl_select, if_incycle);
                    //获取一个值，指是否在Windows任务栏中显示窗体。
                    hcsm.ShowInTaskbar = false;
                    hcsm.ShowDialog();
                    GetData();
                    if (dgv_01.Rows.Count > 0)
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                    }
                }
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillloop", EnumPromptMessage.warning, new string[] { "不在" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "查看", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList sortedList = new SortedList();
            //如果当前选择的行 小于等于 0，表示用户当前未选择任意一行
            if (this.dgv_01.SelectedRows.Count <= 0) return;
            //dgv_01.SelectedRows[0]
            //获得实体包ID
            int packId = Convert.ToInt32(dgv_01.SelectedRows[0].Cells["id"].Value);

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, packId);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec004", sttemp01);
            //根据实体包ID获得实体包信息
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec005", sttemp01);

            //设置一个类型，表明这次上传图片的类型是：包
            sortedList.Add("type", "1");
            //包ID
            sortedList.Add("pack_id", getdt.Rows[0]["id"].ToString());

            HCSCM_set_manage_image HCSCM_set_manage_image = new HCSCM_set_manage_image(sortedList);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            HCSCM_set_manage_image.ShowInTaskbar = false;
            HCSCM_set_manage_image.ShowDialog();

        }


        private void but_newcycle_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show("请选择实体包。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            HCSCM_set_cycle hcsm = new HCSCM_set_cycle(true);//参数true为新包
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private void but_oldcycle_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show("请选择实体包。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            HCSCM_set_cycle hcsm = new HCSCM_set_cycle(false);//参数true为新包，false为旧包
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "实体包");
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

                int ii = dgv_01.Rows.Count;
                for (int i = 0; i < ii; i++)
                {
                    if (dgv_01.Rows[i].Cells["select"].Value != null && (bool)dgv_01.Rows[i].Cells["select"].Value == true)
                    {
                        string barCode = dgv_01.Rows[i].Cells["bar_code"].Value != null ?
                    dgv_01.Rows[i].Cells["bar_code"].Value.ToString() : string.Empty;
                        string codeName = dgv_01.Rows[i].Cells["ca_name"].Value != null ?
                            dgv_01.Rows[i].Cells["ca_name"].Value.ToString() : string.Empty;
                        SortedList parameters = new SortedList();
                        parameters.Add("BarcodeValue", barCode);
                        parameters.Add("P013", codeName);

                        string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
                    }
                }
                //获得当前选择行数据
                //string barCode = dgv_01.CurrentRow.Cells["bar_code"].Value != null ?
                //	dgv_01.CurrentRow.Cells["bar_code"].Value.ToString() : string.Empty;
                //string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
                //	dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

                //if (!string.IsNullOrEmpty(barCode))
                //{
                //	SortedList parameters = new SortedList();
                //	parameters.Add("BarcodeValue", barCode);
                //	parameters.Add("Value", codeName);

                //	string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
                //	if (!string.IsNullOrEmpty(printResult))
                //		MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //	MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void but_list_Click_1(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='entityset'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cb_customer_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (this.cb_customer.Text == "----所有----")
            //{
            //    Loaddata(null);
            //}
            //else
            //{
            //    Loaddata(Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text)).ToString());
            //}
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            Sl_type_01.Clear();
            this.cb_cost_center.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
            Sl_type_01.Add("0", "----所有----");
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
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());

                        this.cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["bar_code"].ToString().Trim() });
                    }
                }
            }
            cb_cost_center.SelectedIndex = 0;

        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }

        private void but_rfid_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "配置RFID", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HCSCM_entityset_manager_rfid hcsm = new HCSCM_entityset_manager_rfid(dgv_01.SelectedRows[0].Cells["id"].Value.ToString(), dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
        }

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetData();
        }
    }
}
