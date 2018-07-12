using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary.Dialog
{
    public partial class HCSWF_urgent_set : BaseForm
    {
        public string AppId { get; set; }
        /// <summary>
        /// 用户的所属地方
        /// </summary>
        private int locationType;

        private int locationid;
        /// <summary>
        /// 初始加载时不Load数据
        /// </summary>
        private bool ifLoad = false;

        public HCSWF_urgent_set()
        {
            InitializeComponent();

            #region 加载button图片
            selBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
            urgentBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mUrgent32", EnumImageType.PNG);
            closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
            #endregion
           

        }
        /// <summary>
        /// load form event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFormExecution(object sender, EventArgs e)
        {
            CnasRemotCall remoteCall = new CnasRemotCall();
            SortedList condition = new SortedList();
            condition.Add(1, CnasBaseData.SystemID);
            condition.Add(2, CnasBaseData.UserBaseInfo.UserID);
            string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-user-sec050", condition);
            DataTable data = remoteCall.RemotInterface.SelectData("HCS-user-sec050", condition);
            if (data != null && data.Rows.Count > 0)
            {
                locationType = int.Parse(data.Rows[0]["u_locationtype"].ToString());
                locationid = int.Parse(data.Rows[0]["lo_id"].ToString());
            }
            else
            {
                locationType = 0;
                locationid = 0;
            }
            InitializeCustomerCbx();
            InitializeUseLocationCbx();
            ifLoad = true;
            LoadData();
        }
        /// <summary>
        /// 客户下拉列表内容
        /// </summary>
        public void InitializeCustomerCbx()
        {
            customerCbx.Items.Clear();
            customerCbx.Items.Add(new KeyValuePair<string, string>("0", "所有"));

            if (CnasBaseData.UserAccessCustomer != null && CnasBaseData.UserAccessCustomer.Rows.Count > 0)
            {
                foreach (DataRow item in CnasBaseData.UserAccessCustomer.Rows)
                {
                    string key = item["id"].ToString();
                    string value = item["cu_name"].ToString();
                    KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
                    customerCbx.Items.Add(cbxItem);
                    if (CnasBaseData.UserBaseInfo != null && CnasBaseData.UserBaseInfo.CustomerId.ToString() == key)
                    {
                        int index = customerCbx.Items.IndexOf(cbxItem);
                        customerCbx.SelectedIndex = index;
                    }
                }
            }
            //customerCbx.Items.Clear();
            //KeyValuePair<string, string> defaultItem = new KeyValuePair<string, string>("0", "--所有--");
            //customerCbx.Items.Add(defaultItem);
            //CnasRemotCall remoteCall = new CnasRemotCall();
            //SortedList condition = new SortedList();
            //condition.Add(1, CnasBaseData.SystemID);
            ////string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-customer-sec001", condition);
            //DataTable data = remoteCall.RemotInterface.SelectData("HCS-customer-sec001", condition);
            //if (data != null && data.Rows.Count > 0)
            //{
            //    foreach (DataRow item in data.Rows)
            //    {
            //        string key = item["id"].ToString();
            //        string value = item["cu_name"].ToString();
            //        KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
            //        customerCbx.Items.Add(cbxItem);
            //        if (CnasBaseData.UserBaseInfo != null && CnasBaseData.UserBaseInfo.CustomerId.ToString() == key)
            //        {
            //            if (locationType >= 5)//区别于显示全部还是单个
            //            {
            //                int index = customerCbx.Items.IndexOf(cbxItem);
            //                customerCbx.SelectedIndex = index;
            //                customerCbx.Enabled = false;
            //            }
            //        }
            //    }
            //    customerCbx.SelectedIndex = 0;
            //}
        }

        private void InitializeUseLocationCbx()
        {
            locationCbx.Items.Clear();
            locationCbx.Items.Add(new KeyValuePair<string, string>("0", "所有"));
            SortedList condition = new SortedList();
            CnasRemotCall remoteCall = new CnasRemotCall();
            if (customerCbx.SelectedIndex > 0 && customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
            {
                condition.Add(1, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
            }
            else
            {
                string customerIds = string.Empty;
                foreach (var item in customerCbx.Items)
                {
                    KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
                    customerIds += string.Format("'{0}',", cbxData.Key);
                }
                customerIds = customerIds.TrimEnd(',');
                condition.Add(1, customerIds);
            }
            string sql = "HCS-use-location-sec002";
            if (AppId == "1050")
            {
                sql = "HCS-use-location-sec011";
                condition.Add(2, CnasBaseData.UserBaseInfo.UserID);
            }

            string sqlTest = remoteCall.RemotInterface.CheckSelectData(sql, condition);
            DataTable data = remoteCall.RemotInterface.SelectData(sql, condition);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    string key = item["id"].ToString();
                    string value = item["u_uname"].ToString();
                    KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
                    locationCbx.Items.Add(cbxItem);
                }

                if (data.Rows.Count == 1)
                {
                    locationCbx.Items.RemoveAt(0);
                    locationCbx.Enabled = false;
                }
                locationCbx.SelectedIndex = 0;
            }
            //locationCbx.Items.Clear();
            //KeyValuePair<string, string> defaultItem = new KeyValuePair<string, string>("0", "--所有--");
            //locationCbx.Items.Add(defaultItem);
            //SortedList condition = new SortedList();

            //CnasRemotCall remoteCall = new CnasRemotCall();
            //if (customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
            //{
            //    condition.Add(1, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
            //}
            //else
            //{
            //    condition.Add(1, "0");
            //}
            //DataTable data = null;
            //if (((KeyValuePair<string, string>)customerCbx.SelectedItem).Key == "0")
            //{
            //    string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-use-location-sec001", null);
            //    data = remoteCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            //}
            //else
            //{
            //    string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-use-location-sec002", condition);
            //    data = remoteCall.RemotInterface.SelectData("HCS-use-location-sec002", condition);
            //}

            //if (data != null && data.Rows.Count > 0)
            //{
            //    foreach (DataRow item in data.Rows)
            //    {
            //        string key = item["id"].ToString();
            //        string value = item["u_uname"].ToString();
            //        KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
            //        locationCbx.Items.Add(cbxItem);
            //        if (CnasBaseData.UserBaseInfo != null && locationid.ToString() == key)
            //        {
            //            if (locationType > 5)//区别于显示全部还是单个
            //            {
            //                int index = locationCbx.Items.IndexOf(cbxItem);
            //                locationCbx.SelectedIndex = index;
            //                locationCbx.Enabled = false;
            //            }
            //        }
            //    }
            //    locationCbx.SelectedIndex = 0;
            //}
        }

        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeUseLocationCbx();
            if (ifLoad)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            setDataGrid.Rows.Clear();
            SortedList condition = new SortedList();
            CnasRemotCall remoteCall = new CnasRemotCall();

            if (customerCbx.SelectedIndex > 0 && customerCbx.SelectedItem != null && customerCbx.SelectedItem is KeyValuePair<string, string>)
            {
                condition.Add(1, ((KeyValuePair<string, string>)customerCbx.SelectedItem).Key);
            }
            else
            {
                string costCenter = string.Empty;
                foreach (var item in customerCbx.Items)
                {
                    KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
                    costCenter += string.Format("'{0}',", cbxData.Key);
                }
                costCenter = costCenter.TrimEnd(',');
                condition.Add(1, costCenter);
            }

            if (locationCbx.SelectedIndex > 0 && locationCbx.SelectedItem != null && locationCbx.SelectedItem is KeyValuePair<string, string>)
            {
                condition.Add(2, ((KeyValuePair<string, string>)locationCbx.SelectedItem).Key);
            }
            else
            {
                string costCenter = string.Empty;
                foreach (var item in locationCbx.Items)
                {
                    KeyValuePair<string, string> cbxData = (KeyValuePair<string, string>)item;
                    costCenter += string.Format("'{0}',", cbxData.Key);
                }
                costCenter = costCenter.TrimEnd(',');
                condition.Add(2, costCenter);
            }

            condition.Add(3, selNameTxt.Text);
            condition.Add(4, CnasBaseData.SystemID);
            string sqlTest = remoteCall.RemotInterface.CheckSelectData("hcs-work-urgent-sel001 ", condition);
            DataTable data = remoteCall.RemotInterface.SelectData("hcs-work-urgent-sel001", condition);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    int rowIndex = setDataGrid.Rows.Add();
                    if (data.Columns.Contains("set_code")) setDataGrid.Rows[rowIndex].Cells["setBarCodeCol"].Value = item["set_code"];
                    if (data.Columns.Contains("set_name")) setDataGrid.Rows[rowIndex].Cells["setNameCol"].Value = item["set_name"];
                    if (data.Columns.Contains("set_urgent")) setDataGrid.Rows[rowIndex].Cells["urgentTypeCol"].Value = item["set_urgent"];
                    if (data.Columns.Contains("set_wpname")) setDataGrid.Rows[rowIndex].Cells["washingPCol"].Value = item["set_wpname"];
                    if (data.Columns.Contains("set_spname")) setDataGrid.Rows[rowIndex].Cells["sterilizerPCol"].Value = item["set_spname"];
                    if (data.Columns.Contains("set_cnaame")) setDataGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["set_cnaame"];
                    if (data.Columns.Contains("wf_name")) setDataGrid.Rows[rowIndex].Cells["wf_name"].Value = item["wf_name"];
                    if (data.Columns.Contains("p_name")) setDataGrid.Rows[rowIndex].Cells["p_name"].Value = item["p_name"];
                }
            }

        }

        private void selBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void urgentBtn_Click(object sender, EventArgs e)
        {
            CnasRemotCall remoteClient = new CnasRemotCall();
            SortedList condition = new SortedList();
            for (int i = 0; i < setDataGrid.SelectedRows.Count; i++)
            {
                if (setDataGrid.Columns.Contains("setBarCodeCol") && !string.IsNullOrEmpty(setDataGrid.Columns.Contains("setBarCodeCol").ToString()))
                {
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, setDataGrid.SelectedRows[i].Cells["setBarCodeCol"].Value.ToString());
                    condition.Add(i + 1, sltmp01);
                }
            }
            if (condition.Count > 0)
            {
                string testSql = remoteClient.RemotInterface.CheckUPDataList("hcs-work-urgent-up001", condition);
                int result = remoteClient.RemotInterface.UPDataList("hcs-work-urgent-up001", condition);
                if (result > 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "单次加急" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void locationCbx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ifLoad)
            {
                LoadData();
            }
        }
    }
}
