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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReporManagerUC
{
    public partial class HCSRM_custom_template_report : UserControl
    {

        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        DataTable dtDate = new DataTable();
        DataTable dtReportData = new DataTable();



        public HCSRM_custom_template_report()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 窗体加载，加载初始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSRM_custom_template_report_Load(object sender, EventArgs e)
        {
            //this.rgvCustomTemplate.CellClick += rgvCustomTemplate_CellClick;

            this.rCustomTemplateMenu.Items[0].Click += tsmtAddTem_Click;
            this.rCustomTemplateMenu.Items[1].Click += tsmtUpdateTem_Click;
            this.rCustomTemplateMenu.Items[2].Click += tsmtAddTemReport_Click;




            DataBind();
        }





        /// <summary>
        /// 加载数据
        /// </summary>
        public void DataBind()
        {

            rtvCustomTemplate.Nodes.Clear();
            rvgCustomFile.Rows.Clear();



            //加载自定义模版数据
            dtDate = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-template-sec001", null);
            if (dtDate == null) dtDate = new DataTable();

            //如果数据大于0则绑定数据
            if (dtDate.Rows.Count > 0)
            {
                RadPageViewPage rpvPage = new RadPageViewPage();

                rpvPage.Font = new Font(rpvPage.Font.FontFamily, 11);

                RadTreeNode rtn = new RadTreeNode();
                rtn.Text = "个性报表模板名称";
                rtn.Name = "-1";

                rtn.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "books_stack", EnumImageType.PNG);

                rtn.Expanded = true;

                for (int i = 0; i < dtDate.Rows.Count; i++)
                {
                    RadTreeNode rtnChildren = new RadTreeNode();
                    //绑定模版名称
                    rtnChildren.Text = dtDate.Rows[i]["tem_name"].ToString();
                    //绑定ID数据
                    rtnChildren.Name = dtDate.Rows[i]["id"].ToString();


                    rtnChildren.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "book", EnumImageType.PNG);


                    rtn.Nodes.Add(rtnChildren);
                }


                rtvCustomTemplate.Nodes.Add(rtn);
            }

        }


        /// <summary>
        /// 新增模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmtAddTem_Click(object sender, EventArgs e)
        {
            HCSRM_custom_template_add HCSRM_custom_template_add = new HCSRM_custom_template_add(0);
            HCSRM_custom_template_add.ShowInTaskbar = false;
            if (HCSRM_custom_template_add.ShowDialog() == DialogResult.OK)
                DataBind();


        }




        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmtUpdateTem_Click(object sender, EventArgs e)
        {
            if (this.rtvCustomTemplate.SelectedNode.Name == "-1") return;

            if (this.rtvCustomTemplate.SelectedNodes.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatenotselect", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(this.rtvCustomTemplate.SelectedNode.Name);

            HCSRM_custom_template_add hCSRM_custom_template_add = new HCSRM_custom_template_add(id);
            hCSRM_custom_template_add.ShowInTaskbar = false;

            if (hCSRM_custom_template_add.ShowDialog() == DialogResult.OK)
                DataBind();
        }



        /// <summary>
        /// 根据模版新建报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmtAddTemReport_Click(object sender, EventArgs e)
        {
            if (this.rtvCustomTemplate.SelectedNode.Name == "-1") return;

            if (this.rtvCustomTemplate.SelectedNodes.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatenotselect", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = Convert.ToInt32(this.rtvCustomTemplate.SelectedNode.Name);
            HCSRM_custom_template_report_add hCSRM_custom_template_report_add = new HCSRM_custom_template_report_add(id, 0, this);
            hCSRM_custom_template_report_add.ShowInTaskbar = false;
            hCSRM_custom_template_report_add.ShowDialog();
        }



        /// <summary>
        /// 修改报表文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmtEditReport_Click(object sender, EventArgs e)
        {

            if (this.rvgCustomFile.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatenotselect", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = Convert.ToInt32(this.rvgCustomFile.CurrentRow.Cells["id"].Value);


            HCSRM_custom_template_report_add hCSRM_custom_template_report_add = new HCSRM_custom_template_report_add(0, id, this);
            //hCSRM_custom_template_report_add.ShowInTaskbar = false;
            hCSRM_custom_template_report_add.Show();

        }



        /// <summary>
        /// 模版行点击事件，点击则加载相关联的报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtvCustomTemplate_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {
            DataBindReport();
        }

        public void DataBindReport()
        {
            if (this.rtvCustomTemplate.SelectedNode.Name == "-1") return;
            this.rvgCustomFile.Rows.Clear();
            int id = Convert.ToInt32(this.rtvCustomTemplate.SelectedNode.Name);
            SortedList sellist = new SortedList();
            sellist.Add(1, id);
            //string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-template-report-sec003", sellist);
            dtReportData = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-template-report-sec003", sellist);
            if (dtReportData == null) dtReportData = new DataTable();


            //如果数据大于0则绑定数据
            if (dtReportData.Rows.Count > 0)
            {
                this.rvgCustomFile.RowCount = dtReportData.Rows.Count;

                for (int i = 0; i < dtReportData.Rows.Count; i++)
                {
                    //绑定ID数据
                    this.rvgCustomFile.Rows[i].Cells["id"].Value = dtReportData.Rows[i]["id"].ToString();
                    //绑定模版名称
                    this.rvgCustomFile.Rows[i].Cells["report_name"].Value = dtReportData.Rows[i]["report_name"].ToString();

                    this.rvgCustomFile.Rows[i].Cells["cre_date"].Value = dtReportData.Rows[i]["cre_date"].ToString();

                }
            }

        }






        /// <summary>
        /// 双击打开修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rvgCustomFile_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (this.rvgCustomFile.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatenotselect", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = Convert.ToInt32(this.rvgCustomFile.CurrentRow.Cells["id"].Value);


            HCSRM_custom_template_report_add hCSRM_custom_template_report_add = new HCSRM_custom_template_report_add(0, id, this);
            //hCSRM_custom_template_report_add.ShowInTaskbar = false;
            hCSRM_custom_template_report_add.Show();



        }







    }
}
