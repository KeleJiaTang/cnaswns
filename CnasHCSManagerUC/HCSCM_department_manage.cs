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

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_department_manage : TemplateForm
    {
        SortedList SLvalue = new SortedList();   //存储客户与名称，作为参数传值。
        public HCSCM_department_manage(SortedList SLdata)
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_costcenter.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "configurationCostCenter", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);


            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            //设置窗体图标
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--部门管理";
         
            this.tb_customer.Text = SLdata["cu_name"].ToString();

            //赋值 存储客户与名称
            SLvalue.Add("ca_name", SLdata["cu_name"].ToString());
            SLvalue.Add("id", SLdata["id"].ToString());

            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }

        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            SortedList sltmp = new SortedList();
            //客户ID
            sltmp.Add(1, SLvalue["id"].ToString().Trim());
           


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-department-sec001", sltmp);
            //根据客户ID 返回部门列表数据
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sltmp);
            if (getdt != null &&getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {

                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("ca_name") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
					if (getdt.Columns.Contains("ca_remarks") && !string.IsNullOrEmpty(getdt.Rows[i]["ca_remarks"].ToString())) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();

                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }

        }

        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_department_manage_new hcsm = new HCSCM_department_manage_new(SLvalue, null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                //部门ID
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                //部门名称
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                //部门描述
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                HCSCM_department_manage_new hcsm = new HCSCM_department_manage_new(SLvalue, slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                Loaddata();
               // dgv_01.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
				if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex ];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count != 0)
            {
                string remove = "";
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                #region 判断部门是否被用户占用

                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);//39


                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["department_id"].ToString().Trim())
                        {
                            remove = "部门已被用户，";
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
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "部门" }), "删除部门", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);//delete 表hcs_customer id=dgv_01.SelectedRows[0].Cells["id"].Value.ToString()

                sltmp.Add(1, sltmp01);

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-department-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-department-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Loaddata();
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_costcenter_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count != 0)
            {
                SortedList SLinfo = new SortedList();
                bool ifde = false;
                SLinfo.Add("ifsec", ifde);
                //部门ID
                SLinfo.Add("de_id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                //部门名称
                SLinfo.Add("de_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
                //客户名称
                SLinfo.Add("cu_name", SLvalue["ca_name"].ToString());
                //客户Id
                SLinfo.Add("cu_id", SLvalue["id"].ToString());

                HCSCM_costcenter_department hcsm = new HCSCM_costcenter_department(SLinfo);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "配置", "部门" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void but_print_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='department'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}
