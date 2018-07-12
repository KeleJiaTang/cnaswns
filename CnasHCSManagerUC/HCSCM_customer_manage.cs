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
    public partial class HCSCM_customer_manage : UserControl
    {

        SortedList sl_type = new SortedList();
        DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_customer_type'");
        public HCSCM_customer_manage()
        {

            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_department.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "department", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);


            #endregion

            dgv_01.Columns[9].FormatString = "{0:yyyy-MM-dd  HH24:mm}";

            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();

            foreach (DataRow dr in arrayDR)
            {
                //根据编号找厂商
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());

            }

            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //  string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-customer-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec001", sttemp01);
            //集合存储客户ID，作为条件查询客户的数据表
            SortedList sttemp02 = new SortedList();
            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
					if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("cu_name") && !string.IsNullOrEmpty(getdt.Rows[i]["cu_name"].ToString())) dgv_01.Rows[i].Cells["cu_name"].Value = getdt.Rows[i]["cu_name"].ToString();
                    if (getdt.Columns.Contains("bar_code") && !string.IsNullOrEmpty(getdt.Rows[i]["bar_code"].ToString())) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Columns.Contains("cu_address") && !string.IsNullOrEmpty(getdt.Rows[i]["cu_address"].ToString())) dgv_01.Rows[i].Cells["cu_address"].Value = getdt.Rows[i]["cu_address"].ToString();
                    if (getdt.Columns.Contains("c_contacts") && !string.IsNullOrEmpty(getdt.Rows[i]["c_contacts"].ToString())) dgv_01.Rows[i].Cells["c_contacts"].Value = getdt.Rows[i]["c_contacts"].ToString();
                    if (getdt.Columns.Contains("c_mail") && !string.IsNullOrEmpty(getdt.Rows[i]["c_mail"].ToString())) dgv_01.Rows[i].Cells["c_mail"].Value = getdt.Rows[i]["c_mail"].ToString();
                    if (getdt.Columns.Contains("c_telephone") && !string.IsNullOrEmpty(getdt.Rows[i]["c_telephone"].ToString())) dgv_01.Rows[i].Cells["c_telephone"].Value = getdt.Rows[i]["c_telephone"].ToString();
                    if (getdt.Columns.Contains("ca_type") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_type"].ToString())) dgv_01.Rows[i].Cells["ca_type"].Value = sl_type[getdt.Rows[i]["ca_type"].ToString()];
                    if (getdt.Columns.Contains("cre_date") && !string.IsNullOrEmpty(getdt.Rows[i]["cre_date"].ToString())) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("mod_date") && !string.IsNullOrEmpty(getdt.Rows[i]["mod_date"].ToString())) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    //计算客户下部门的数量
                    sttemp02.Add(1, getdt.Rows[i]["id"].ToString());
                    // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-department-sec001", sttemp02);
                    DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sttemp02);
                    if (getdt02 != null)
                    {
                        if (getdt.Columns.Contains("ca_department") && getdt.Rows[i]["ca_department"] != null) dgv_01.Rows[i].Cells["ca_department"].Value = getdt02.Rows.Count;
                    }
                    else
                    {
                        if (getdt.Columns.Contains("ca_department") && getdt.Rows[i]["ca_department"] != null) dgv_01.Rows[i].Cells["ca_department"].Value = 0;
                    }
                    //清空集合内容
                    sttemp02.Clear();
                    if (dgv_01.Rows.Count > 0)
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                }
                // dgv_01.Rows[0].IsSelected = true;
            }

        }




        private void but_remove_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {


                // 存储被占用的名称
                string remove = "客户已被";
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);

                #region 判断客户ID是否被成本中心占用

                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-costcenter-sec001", sttemp01);//39


                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["cu_id"].ToString().Trim())
                        {
                            remove = "成本中心，";
                            break;
                        }
                    }
                }


                #endregion

                #region 判断客户barcode是否被基本包占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//106
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == getdt.Rows[i]["customer_code"].ToString().Trim())
                        {
                            remove = remove + ",基本包";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断客户是否被部门占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-department-sec002", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["cu_id"].ToString().Trim())
                        {
                            remove = remove + ",部门";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断客户barcode是否被实体包占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-set-sec004", sttemp01);//137
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == getdt.Rows[i]["customer_code"].ToString().Trim())
                        {
                            remove = remove + ",实体包";
                            break;
                        }
                    }
                }
                #endregion

                #region 判断客户barcode是否被器械类型占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);//113
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["bar_code"].Value.ToString() == getdt.Rows[i]["ca_customer"].ToString().Trim())
                        {
                            remove = remove + ",器械类型";
                            break;
                        }
                    }
                }
                #endregion

                #region   判断客户是否被使用地点占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-use-location-sec001", null);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["u_customer"].ToString().Trim())
                        {
                            remove = remove + ",使用地点";
                            break;

                        }
                    }
                }
                #endregion

                #region 判断客户是否被用户占用

                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);//39


                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["customer_id"].ToString().Trim())
                        {
                            remove = "客户已被用户，";
                            break;
                        }
                    }
                }


                #endregion

                #region 判断客户是否被存储点占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-storage-sec001", null);//143
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["s_customer"].ToString().Trim())
                        {
                            remove = remove + ",存储点";
                            break;
                        }
                    }
                }
                #endregion


                if (remove != "客户已被")
                {
                    MessageBox.Show(remove + "占用，如要删除，请先解除与以上的关联。");
                    return;
                }
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["cu_name"].Value.ToString(), "客户" }), "删除客户", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);//delete 表hcs_customer id=dgv_01.SelectedRows[0].Cells["id"].Value.ToString()

                sltmp.Add(1, sltmp01);

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-customer-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-customer-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "客户" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //Loaddata();
                }
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除的", "客户" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void but_new_Click_1(object sender, EventArgs e)
        {
            HCSCM_customer_manage_new hcsm = new HCSCM_customer_manage_new(null, arrayDR);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;

            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgv_01.SelectedRows.Count > 0)
                {
                    int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    SortedList slindata = new SortedList();
                    slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                    slindata.Add("cu_name", dgv_01.SelectedRows[0].Cells["cu_name"].Value);
                    slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
					slindata.Add("cu_address", dgv_01.SelectedRows[0].Cells["cu_address"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["cu_address"].Value);
					slindata.Add("ca_type", dgv_01.SelectedRows[0].Cells["ca_type"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_type"].Value);
					slindata.Add("ca_department", dgv_01.SelectedRows[0].Cells["ca_department"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["ca_department"].Value);
					slindata.Add("c_mail", dgv_01.SelectedRows[0].Cells["c_mail"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["c_mail"].Value);
					slindata.Add("c_telephone", dgv_01.SelectedRows[0].Cells["c_telephone"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["c_telephone"].Value);
					slindata.Add("c_contacts", dgv_01.SelectedRows[0].Cells["c_contacts"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["c_contacts"].Value);

                    HCSCM_customer_manage_new hcsm = new HCSCM_customer_manage_new(slindata, arrayDR);
                    //获取一个值，指是否在Windows任务栏中显示窗体。
                    hcsm.ShowInTaskbar = false;
                    hcsm.Text = "修改客户";
                    hcsm.ShowDialog();
                    Loaddata();
                    if (dgv_01.Rows.Count > selectedIndex)
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                    }
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改的", "客户" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        /// <summary>
        /// 部门绑定成本中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_department_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList slindata = new SortedList();

                //客户ID
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                //客户名称
                slindata.Add("cu_name", dgv_01.SelectedRows[0].Cells["cu_name"].Value.ToString());
                HCSCM_department_manage hcsm = new HCSCM_department_manage(slindata);



                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;

                hcsm.ShowDialog();
                Loaddata();
                if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }

            }
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "客户");
        }



        private void gp_top_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='customer'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click_1(null, null);
        }




    }
}
