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
    public partial class HCSCM_department_equipment_manager_edit : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();
        private DataTable selectDataInfo = new DataTable();
        private SortedList sl_gpapp = new SortedList();
        private SortedList sl_01data = new SortedList();
        private int itemID = 0;
        private int baseItemID = 0;
        private string SelCuName = "";
        private string totalCount = "";
        private string currentCount = "";
        public HCSCM_department_equipment_manager_edit(int id, string SelCustomer, int type, string SeltotalCount, string SelcurrentCount,int baseID)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            itemID = id;
            baseItemID = baseID;
            SelCuName = SelCustomer;
            totalCount = SeltotalCount;
            currentCount = SelcurrentCount;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, itemID);
            selectDataInfo = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-costcenter-detail-sel003", sttemp01);

            //this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            //this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            //this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改部门器械";
            cb_customer.Enabled = false;
            cb_cost_center.Enabled = false;
            if (type == 1)
            {
                cb_cost_center.Enabled = false;
            }

        }

        private void JudgeLoadInfo()
        {
            // cb_customer.Text = SelCuName;

            foreach (RadListDataItem item in cb_customer.Items)
            {
                if (selectDataInfo != null)
                {
                    if (item.Text == SelCuName)
                    {
                        int indexx = cb_customer.Items.IndexOf(item);
                        cb_customer.SelectedIndex = indexx;
                        break;
                    }
                }

            }


            foreach (RadListDataItem item in cb_cost_center.Items)
            {
                if (selectDataInfo != null)
                {
                    if (item.Value.ToString() == selectDataInfo.Rows[0]["cost_center_id"].ToString())
                    {
                        int indexx = cb_cost_center.Items.IndexOf(item);
                        cb_cost_center.SelectedIndex = indexx;
                        break;
                    }
                }

            }
            tb_currentCount.Text = selectDataInfo.Rows[0]["in_store_count"].ToString();

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

            }
            JudgeLoadInfo();
            // LoadDataDgv01();
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
            }

        }

        private void but_sel_Click(object sender, EventArgs e)
        {

        }

        private void tb_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        //private void but_save_Click(object sender, EventArgs e)
        //{
        //    if (this.cb_cost_center.Text == "")
        //    {
        //        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    SortedList conditionStorage = new SortedList();
        //    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        //    SortedList sltmp = new SortedList();
        //    SortedList sltmp01 = new SortedList();

        //    int total = int.Parse(tb_total.Text);
        //    sltmp01.Add(1, total);

        //    sltmp01.Add(3, CnasBaseData.UserID);
        //    sltmp01.Add(4, cb_cost_center.SelectedItem.Value);
        //    sltmp01.Add(5, itemID);
        //    sltmp.Add(1, sltmp01);
        //    string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-instrument-costcenter-detail-up002", sltmp, null);
        //    int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-instrument-costcenter-detail-up002", sltmp, null);

        //    SortedList sltmpDel = new SortedList();
        //    SortedList sltmpDel01 = new SortedList();
        //    sltmpDel.Add(1, selectDataInfo.Rows[0]["instrument_base_id"].ToString());
        //    sltmpDel01.Add(1, sltmpDel);
        //    string sql2 = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-storage-data-del001", sltmpDel01, null);
        //    int recint2 = reCnasRemotCall.RemotInterface.UPData(1, "HCS-storage-data-del001", sltmpDel01, null);

        //    int resultstroage = reCnasRemotCall.RemotInterface.UPDataList("HCS-storage-data-add001", conditionStorage);

        //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    this.Close();

        //}

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (this.cb_cost_center.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_currentCount.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("LibraryNum", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                //填写出库数量
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int num = int.Parse(tb_currentCount.Text);//差值
            num = num - int.Parse(currentCount);
            SortedList conditionUp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, int.Parse(totalCount));
            sltmp01.Add(2, int.Parse(tb_currentCount.Text));
            sltmp01.Add(3, CnasBaseData.UserID);
            sltmp01.Add(4, cb_cost_center.SelectedItem.Value);
            sltmp01.Add(5, itemID);
            conditionUp.Add(1, sltmp01);

            #region  出库日志
            SortedList sltmpOut = new SortedList();
            SortedList conditionStorageInput = new SortedList();
            sltmpOut.Add(1, baseItemID);
            sltmpOut.Add(2, cb_cost_center.SelectedItem.Value);
            sltmpOut.Add(3, 3);
            sltmpOut.Add(4, num);
            sltmpOut.Add(5, CnasBaseData.UserID);
            conditionStorageInput.Add(1, sltmpOut);
            #endregion
         //    string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-instrument-costcenter-detail-up002", conditionUp, conditionStorageInput);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-instrument-costcenter-detail-up002", conditionUp, conditionStorageInput);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
