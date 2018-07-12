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
    public partial class HCSCM_set_cycle : TemplateForm
    {
        bool newold_type;//包的新旧类型
        public HCSCM_set_cycle(bool type)
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_incycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "feedingCycle", EnumImageType.PNG);
            this.but_putcycle.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "outCycle", EnumImageType.PNG);

            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新包批量导入/导出循环";
            newold_type = type;//包的新旧类型赋值
            //如果类型是旧包，则显示出循环的按钮
            if (type == false)
            {
                but_putcycle.Visible = true;
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--旧包批量导入/导出循环";

            }
            Loaddata(type);



        }
        /// <summary>
        /// 刷新dgv
        /// </summary>
        /// <param name="set_newold">true为新包，false为旧包</param>
        private void Loaddata(bool set_newold)
        {
            if (set_newold == true)
            {
                #region 显示新包
                dgv_01.Rows.Clear();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, "=");//等于为新包

                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec008", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec008", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    for (int i = 0; i < ii; i++)
                    {

                        if (dgv_01.Rows[i].Cells["isselect"].Value == null) dgv_01.Rows[i].Cells["isselect"].Value = false;//不打勾
                        if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
						if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
						if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
						if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (getdt.Rows[i]["in_cycle"].ToString() == "9") ? "否" : "是";

                    }
                    dgv_01.Rows[0].IsSelected = true;
                }
                #endregion
            }
            else
            {
                #region 显示旧包
                dgv_01.Rows.Clear();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, ">");//大于为旧包

                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec008", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec008", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    for (int i = 0; i < ii; i++)
                    {

                        if (dgv_01.Rows[i].Cells["isselect"].Value == null) dgv_01.Rows[i].Cells["isselect"].Value = false;//不打勾
						if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
						if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
						if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
						if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (getdt.Rows[i]["in_cycle"].ToString() == "9") ? "否" : "是";

                    }
                    dgv_01.Rows[0].IsSelected = true;
                }
            }
                #endregion
        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cb_old_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)
            {
                if (cb_old.Checked == true)
                {
                    //全打钩
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselect"].Value = true;
                    }
                    cb_new.Checked = false;

                }

            }
        }
        private void cb_new_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)
            {
                if (cb_new.Checked == true)
                {
                    //取消打钩
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselect"].Value = false;
                    }
                    cb_old.Checked = false;
                }
            }
        }
        private void but_incycle_Click(object sender, EventArgs e)
        {

            //存储你要修改的数据
            DataTable dtselect = new DataTable();
            //为datatable添加你需要添加的数据的字段名称
            dtselect.Columns.Add(new DataColumn("id"));
            dtselect.Columns.Add(new DataColumn("bar_code"));
            dtselect.Columns.Add(new DataColumn("ca_name"));
            dtselect.Columns.Add(new DataColumn("in_cycle"));
            DataRow dr = dtselect.NewRow();
            //int position = 0;//插入数据的位置
            //在循环中判断，取得你需要修改的数据
            for (int i = 0; i < dgv_01.Rows.Count; i++)
            {
                if ((bool)dgv_01.Rows[i].Cells["isselect"].Value == true)
                {
                   // InsertAt  InsertAt
                   
                    dr["id"] = dgv_01.Rows[i].Cells["id"].Value.ToString();
                    dr["bar_code"] =  dgv_01.Rows[i].Cells["bar_code"].Value;
                    dr["ca_name"] =  dgv_01.Rows[i].Cells["ca_name"].Value.ToString();
                    //循环时，检测当前实体包是否在循环中
                    if (dgv_01.Rows[i].Cells["in_cycle"].Value.ToString() == "否")
                    {
                        dr["in_cycle"]  = dgv_01.Rows[i].Cells["in_cycle"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("putcycle", EnumPromptMessage.warning, new string[] { "存在" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //给datatable添加一行数据
                    //dtselect.Rows.InsertAt(dr, position);
                    dtselect.Rows.Add(dr.ItemArray);
                    //position++;
                }
            }
            //如果行数为0，则说明没有选择实体包
            if (dtselect.Rows.Count == 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HCSCM_in_cycle_location hcsm = new HCSCM_in_cycle_location(newold_type, dtselect);
            // HCSCM_set_cycle_location hcsm = new HCSCM_set_cycle_location(dtselect, newold_type);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(newold_type);
            cb_old.Checked = false;
            cb_new.Checked = false;
        }

        private void but_putcycle_Click(object sender, EventArgs e)
        {
            if (dgv_01 != null)
            {
                int slect = 0;//用于判断有没有选择实体包
                int success = 0;//用于判断添加是否添加成功
                //判断是否存在已经不在循环里的包
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {
                    //为false的代表是不打勾的，不需移出循环
                    if ((bool)dgv_01.Rows[i].Cells["isselect"].Value == false)
                    {
                        slect++;//每存在一个不打勾的实体包加1
                        continue;
                    }
                    //放进循环前，判断当前实体包是否在循环中
                    if (dgv_01.Rows[i].Cells["in_cycle"].Value.ToString() == "否")
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("putcycle", EnumPromptMessage.warning, new string[] { "不在" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //如果相等说明没有选择实体包
                if (slect == dgv_01.Rows.Count)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                slect = 0;//清零
                //datatable几行就循环几次，在工单中为每一个旧的打勾的实体包修改记录
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {

                    //为false的代表是不打勾的，不需移出循环
                    if ((bool)dgv_01.Rows[i].Cells["isselect"].Value == false)
                    {
                        slect++;//每存在一个不打勾的实体包加1
                        continue;
                    }
                    //开始出循环
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    SortedList sttemp01 = new SortedList();
                    sttemp01.Add(1, dgv_01.Rows[i].Cells["id"].Value.ToString());
                    string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec006", sttemp01);
                    DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec006", sttemp01);//查出旧实体包原来的动作
                    if (getdt == null) return;
                    #region 出循环时，还原包的记录
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, 9);
                    sltmp01.Add(2, dgv_01.Rows[i].Cells["id"].Value.ToString());
                    sltmp01.Add(3, 6);
                    sltmp01.Add(4, dgv_01.Rows[i].Cells["id"].Value.ToString());
                    sltmp01.Add(5, getdt.Rows[0]["wf_code"].ToString());
                    sltmp.Add(1, sltmp01);
                    //  string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                    if (recint > -1)
                    {
                        success++;
                    }
                    #endregion
                }

                //如果需要添加的数量等于添加成功的数量，则移出成功
                if (dgv_01.Rows.Count - slect == success)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "实体包已经移出循环" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorloop", EnumPromptMessage.error, new string[] { "移出" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Loaddata(newold_type);
            }
            cb_old.Checked = false;
            cb_new.Checked = false;
        }
        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
				GetData();
            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
			
				GetData();
			
        }

		private void GetData()
		{
			if (newold_type == true)
			{
				#region 对新包内容查询
				dgv_01.Rows.Clear();
				DataRow[] arrayDR = null;
				string strsecdata = tb_sel.Text.Trim().ToUpper();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList sttemp01 = new SortedList();
				sttemp01.Add(1, "=");//等于为新包
				//string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec008", sttemp01);
				DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec008", sttemp01);
				arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%'");
				if (arrayDR.Length > 0)
				{
					int ii = arrayDR.Length;
					if (ii <= 0) return;
					dgv_01.RowCount = ii;
					int i = 0;
					foreach (DataRow dr in arrayDR)
					{
						if (dgv_01.Rows[i].Cells["isselect"].Value == null) dgv_01.Rows[i].Cells["isselect"].Value = false;//不打勾
						if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
						if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
						if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
						if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (dr["in_cycle"].ToString() == "9") ? "否" : "是";

						i++;
					}
				}
				#endregion
			}
			else
			{
				#region 对旧包内容查询
				dgv_01.Rows.Clear();
				DataRow[] arrayDR = null;
				string strsecdata = tb_sel.Text.Trim();
				string str = strsecdata.ToUpper();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList sttemp01 = new SortedList();
				sttemp01.Add(1, ">");//等于为新包
				//string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec008", sttemp01);
				DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec008", sttemp01);
				arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' or bar_code like '%" + strsecdata + "%'");
				if (arrayDR.Length > 0)
				{
					int ii = arrayDR.Length;
					if (ii <= 0) return;
					dgv_01.RowCount = ii;
					int i = 0;
					foreach (DataRow dr in arrayDR)
					{
						if (dgv_01.Rows[i].Cells["isselect"].Value == null) dgv_01.Rows[i].Cells["isselect"].Value = false;//不打勾
						if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
						if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
						if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
						if (getdt.Columns.Contains("in_cycle") && getdt.Rows[i]["in_cycle"] != null) dgv_01.Rows[i].Cells["in_cycle"].Value = (dr["in_cycle"].ToString() == "9") ? "否" : "是";
						i++;
					}
				}
				#endregion
			}
		}
        private void tb_sname_KeyDown(object sender, KeyPressEventArgs e)
        {

        }

        private void dgv_01_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_01.SelectedRows.Count; i++)
			{
                //dgv_01.Rows[i].Cells["isselect"].Value = true;
                dgv_01.SelectedRows[i].Cells["isselect"].Value = true;
			}
        }
    }
}
