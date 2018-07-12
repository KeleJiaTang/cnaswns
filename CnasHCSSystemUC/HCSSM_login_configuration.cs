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

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_login_configuration : UserControl
    {
        SortedList SL_workid = new SortedList();
        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        string work_id = "";//工作台id
        public HCSSM_login_configuration()
        {
            InitializeComponent();

            #region 按钮图片加载
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            #endregion
            DataTable App = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec010", null);
            if (App != null && App.Rows.Count > 0)
            {
                for (int i = 0; i < App.Rows.Count; i++)
                {

                    SL_workid.Add(App.Rows[i]["app_briefcode"].ToString(), App.Rows[i]["app_name"].ToString());

                }
            }
            Loaddata();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }

        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-workspace-binding-sec002", null);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                //dgv_01.RowCount = ii;
                dgv_01.Rows.Clear();
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["mac_address"].ToString())) dgv_01.Rows[i].Cells["mac_address"].Value = getdt.Rows[i]["mac_address"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["ip_address"].ToString())) dgv_01.Rows[i].Cells["ip_address"].Value = getdt.Rows[i]["ip_address"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["computer"].ToString())) dgv_01.Rows[i].Cells["computer"].Value = getdt.Rows[i]["computer"].ToString();
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["work_id"].ToString()))
                    {
                        dgv_01.Rows[i].Cells["work_num"].Value = getdt.Rows[i]["work_id"].ToString();

                        string[] array = getdt.Rows[i]["work_id"].ToString().Split(new char[] { ',' });//把工作台id截取出来
                        //  work_id = getdt.Rows[i]["work_id"].ToString();
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[j] != "")//当数据是"1111，"时，截取出来的是“1111”和"",所以不要值为""的
                                dgv_01.Rows[i].Cells["work_id"].Value += SL_workid[array[j]].ToString() + ",";
                        }
                    }
                    else
                    {
                        dgv_01.Rows[i].Cells["work_num"].Value = "";
                    }
                    if (!string.IsNullOrEmpty(getdt.Rows[i]["remark"].ToString())) dgv_01.Rows[i].Cells["remark"].Value = getdt.Rows[i]["remark"].ToString();
                }
                if(dgv_01.RowCount>0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["computer"].Value.ToString(), "登录配置" }), "删除登录配置", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-workspace-binding-del001", sltmp, null);
                int recint = reCnasRemotCall_01.RemotInterface.UPData(1, "hcs-workspace-binding-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "选项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "选择" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {

                SortedList slindata = new SortedList();
				int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("mac_address", dgv_01.SelectedRows[0].Cells["mac_address"].Value);
                slindata.Add("computer", dgv_01.SelectedRows[0].Cells["computer"].Value);
                slindata.Add("work_id", dgv_01.SelectedRows[0].Cells["work_num"].Value);
                slindata.Add("remark", dgv_01.SelectedRows[0].Cells["remark"].Value);
                HCSSM_login_configuration_edit hcsm = new HCSSM_login_configuration_edit(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                Loaddata();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "选择" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}
