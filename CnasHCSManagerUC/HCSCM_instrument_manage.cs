using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_instrument_manage : TemplateForm
    {
        private SortedList sl_type = new SortedList();
        //private DataRow[] arrayDR = null;
        private string select_id = "";
        public static String txt = "";
        private string ins = "";
        public HCSCM_instrument_manage(SortedList slselect)
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);


            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            ins = tb_ins.Text = slselect["ca_name"].ToString();
            select_id = slselect["id"].ToString();
            //string get = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec003", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec003", null);
            if(getdt!=null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for(int i=0;i<ii;i++)
                {
                    if(getdt.Rows[i]["id"].ToString()!=null&&getdt.Rows[i]["ca_name"].ToString().Trim()!=null)
                    {
                        sl_type.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }          
            Loaddata(select_id);
            ////表格栏底色
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            ////DGV表格首行字段居中对齐
            //dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  
        }
        /// <summary>
        /// 读取数据库数据
        /// </summary>
        private void Loaddata(string ins_id)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp = new SortedList();
            sttmp.Add(1, ins_id);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-sec001", sttmp);
            if (getdt != null && getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["ins_id"] != null) dgv_01.Rows[i].Cells["ins_id"].Value =sl_type[getdt.Rows[i]["ins_id"].ToString()].ToString();
                    if (getdt.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["run_times"].Value = getdt.Rows[i]["run_times"].ToString();
                    if (getdt.Rows[i]["ca_rfid"] != null) dgv_01.Rows[i].Cells["ca_rfid"].Value = getdt.Rows[i]["ca_rfid"].ToString();
                    if (getdt.Rows[i]["sm_num"] != null) dgv_01.Rows[i].Cells["sm_num"].Value = getdt.Rows[i]["sm_num"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        //新建
        private void but_new_Click(object sender, EventArgs e)
        {
            txt = tb_ins.Text;
            HCSCM_instrument_manage_new hcsm = new HCSCM_instrument_manage_new(null, select_id, ins);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(select_id);
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }
        //修改
        private void but_edit_Click(object sender, EventArgs e)
        {
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("ca_rfid", dgv_01.SelectedRows[0].Cells["ca_rfid"].Value);
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("sm_num", dgv_01.SelectedRows[0].Cells["sm_num"].Value);
                HCSCM_instrument_manage_new hcsm = new HCSCM_instrument_manage_new(slindata, null, ins);
                hcsm.ShowDialog();
                Loaddata(select_id);
				if(dgv_01.Rows.Count>selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改","实体器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata(select_id);
            }
        }
        //删除
        private void but_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete",EnumPromptMessage.warning,new string[]{dgv_01.SelectedRows[0].Cells["id"].Value.ToString(),tb_ins.Text}),ConfigurationManager.AppSettings["SystemName"] + "--删除实体器械", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-del001", sltmp, null);

                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful",EnumPromptMessage.warning,new string[]{"实体器械"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //Loaddata(select_id);
                }
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "实体器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void but_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_ins_Click(object sender, EventArgs e)
        {

        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}

