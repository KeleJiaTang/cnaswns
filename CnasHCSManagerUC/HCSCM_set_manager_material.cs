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
    public partial class HCSCM_set_manager_material : TemplateForm
    {
        public HCSCM_set_manager_material()
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            #region 按钮图片加载

           
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);


            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--包装材料管理";
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Loaddata();
        }
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-setmaterial-type-sec001", sltmp);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-setmaterial-type-sec001", sltmp);
            if (getdt != null && getdt.Rows.Count>0)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
					if (getdt.Columns.Contains("expiration_day") && getdt.Rows[i]["expiration_day"] != null) dgv_01.Rows[i].Cells["expiration_day"].Value = getdt.Rows[i]["expiration_day"].ToString();

                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_set_manager_material_new hcsm = new HCSCM_set_manager_material_new(null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
				int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList slindata = new SortedList();
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("expiration_day", dgv_01.SelectedRows[0].Cells["expiration_day"].Value);

                HCSCM_set_manager_material_new hcsm = new HCSCM_set_manager_material_new(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.Text = "修改包装材料";
                hcsm.ShowDialog();
                Loaddata();
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            else
            {
                MessageBox.Show("请选择一行。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void but_remove_Click(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            #region 判断打包材料是否被基本包占用

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//99
            if (getdt != null)
            {
                DataRow[] getdt_01 = getdt.Select();
                foreach (DataRow dr in getdt_01)
                {
                    if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dr["ca_material"].ToString().Trim())
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation", EnumPromptMessage.warning, new string[] { "材料", "基本包", "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            #endregion
            if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "材料" }), "删除材料", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);//delete 表hcs_customer id=dgv_01.SelectedRows[0].Cells["id"].Value.ToString()

            sltmp.Add(1, sltmp01);


            string str = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-setmaterial-type-del001", sltmp, null);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-setmaterial-type-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "材料" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}

    }
}
