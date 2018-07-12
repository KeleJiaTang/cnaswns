using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_costcenter_manage : UserControl
    {
        private SortedList sl_type01 = new SortedList();
        DataTable getdt = new DataTable();
        /// <summary>
        /// 所有的CSSD的成本中心
        /// </summary>
        string[] code_cc = { };
        //private  DataRow[] arrayDR = null; //存放根据si_id查询hcs_customer表的每一行
        public HCSCM_costcenter_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_department.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_department.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "configurationDepartment", EnumImageType.PNG);
            #endregion

            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec001", sttemp01);

            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString() != null)
                        cb_type.Items.Add(getdt.Rows[i]["cu_name"].ToString());
                    sl_type01.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
                }
                Loaddata(CnasBaseData.SystemID);
                if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
                {
                    dgv_01.Rows[0].IsSelected = true;
                }
            }
            try
            {
                //查出cssd的成本中心
                DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-CSSD-costcenter'");
                code_cc = arrayDR[0]["value_code"].ToString().Split(',');
               
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("creCSSD__cc", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="strnum">查询条件</param>
        private void Loaddata(string strnum)
        {
            dgv_01.Rows.Clear();
            DataTable getdt = null;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strnum);
            if (strnum == "1")
            {
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec001", sttemp01);
            }
            else
            {
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sttemp01);
            }
            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Columns.Contains("cu_id") && !string.IsNullOrEmpty(getdt.Rows[i]["cu_id"].ToString())) dgv_01.Rows[i].Cells["cu_id"].Value = sl_type01[getdt.Rows[i]["cu_id"].ToString()].ToString();
                    if (getdt.Columns.Contains("custmer_cnumber") && !string.IsNullOrEmpty(getdt.Rows[i]["custmer_cnumber"].ToString())) dgv_01.Rows[i].Cells["custmer_cnumber"].Value = getdt.Rows[i]["custmer_cnumber"].ToString();
                    if (getdt.Columns.Contains("ca_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_remarks"].ToString())) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                }
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {

            HCSCM_costcenter_manage_new hcsm = new HCSCM_costcenter_manage_new(getdt, null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (hcsm.type != "")
            {
                Loaddata(hcsm.type);
                this.cb_type.Text = sl_type01[hcsm.type].ToString();
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
                }
            }
        }



        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("custmer_cnumber", dgv_01.SelectedRows[0].Cells["custmer_cnumber"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["custmer_cnumber"].Value);
                slindata.Add("cu_id", dgv_01.SelectedRows[0].Cells["cu_id"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["cu_id"].Value);
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                HCSCM_costcenter_manage_new hcsm = new HCSCM_costcenter_manage_new(getdt, slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                string str = hcsm.type;
                if (hcsm.type != "")
                {
                    Loaddata(hcsm.type);
                    this.cb_type.Text = sl_type01[hcsm.type].ToString();
                }
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

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除的", "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < code_cc.Length; i++)//如果选择的是CSSD的成本中心则不能删除
            {
                if (code_cc[i] != "")//为空则不比较
                {
                    if (code_cc[i] == dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString())
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("delNot", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }

            try
            {
                string remove = "";
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                #region 判断成本中心barcode是否被基本包占用
                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//106
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                        if (getdt.Rows[i]["cost_center"].ToString() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == getdt.Rows[i]["cost_center"].ToString().Trim())
                            {
                                remove = "成本中被基本包，";
                                break;
                            }
                        }

                }
                #endregion

                #region 判断成本中心barcode是否被实体包占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-sec004", sttemp01);//137
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == dr["cost_center"].ToString().Trim())
                        {
                            remove = remove + "实体包";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断成本中心barcode是否被器械类型占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);//113
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == dr["cost_center"].ToString().Trim())
                        {
                            remove = remove + ",器械类型";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断成本中心是否被使用地点占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-use-location-sec001", null);//143
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["u_costcenter"].ToString().Trim())
                        {
                            remove = remove + ",使用地点";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断成本中心是否被存储点占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-storage-sec001", null);//143
                if (getdt != null)
                {
                    DataRow[] getdt_01 = getdt.Select();
                    foreach (DataRow dr in getdt_01)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["s_costcenter"].ToString().Trim())
                        {
                            remove = remove + ",存储点";
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
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "成本中心" }), "删除成本中心", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-vender-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-costcenter-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_01.Rows.RemoveAt(selectedIndex);
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
                    //int inrec = sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["cu_id"].Value);
                    //string strkey = sl_type01.GetKey(inrec).ToString();
                    //this.cb_type.Text = sl_type01[strkey].ToString();
                    //Loaddata(strkey);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void but_department_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "配置的", "成本中心" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList SLinfo = new SortedList();
            bool ifcc = true;
            SLinfo.Add("ifsec", ifcc);
            try
            {
                //成本中心ID
                SLinfo.Add("cc_id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                //成本中心名称
                SLinfo.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
                //客户名称
                SLinfo.Add("cu_name", dgv_01.SelectedRows[0].Cells["cu_id"].Value.ToString());

                int customer = 0; //客户Id

                foreach (var key in sl_type01.Keys)
                {
                    if (sl_type01[key].ToString() == dgv_01.SelectedRows[0].Cells["cu_id"].Value.ToString())
                    {
                        customer = Convert.ToInt32(key);
                        break;
                    }
                }

                //客户名称
                SLinfo.Add("cu_id", customer);

                HCSCM_costcenter_department hcsm = new HCSCM_costcenter_department(SLinfo);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;

                hcsm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='costcenter'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
			
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string key_code = sl_type01.GetKey(sl_type01.IndexOfValue(cb_type.SelectedItem.ToString())).ToString();

            Loaddata(key_code);
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }

        private void dgv_01_SelectionChanged(object sender, EventArgs e)
        {
            
        }

    }
}
