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
    public partial class HCSCM_in_cycle : TemplateForm
    {

        bool if_incycle = false;//初始化不再循环里
        DataTable ifincycle_allset = null;//存储所有是否在循环中的包
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sl_select">选择的实体包信息</param>
        /// <param name="if_incycle">实体在循环中，true为在</param>
        public HCSCM_in_cycle(SortedList Sl_select, bool cycle)
        {
            InitializeComponent();
            #region Button图标
            this.but_showall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allShow", EnumImageType.PNG);
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--移进循环";
            cb_set.Items.Add("新包");
            cb_set.Items.Add("旧包");
            if_incycle = cycle;//赋值是否在循环中
            //移出循环则不显示新旧包选择和提示的控件
            if (cycle == true)
            {
                lb_material.Visible = false;
                cb_set.Visible = false;
                tb_set.Visible = false;
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--移出循环";
            }
            string str_id = "", str_barcode = "", str_name = "";//id,barcode,实体包名称。
            //判断传递过来的参数是否为有值
            if (Sl_select["id"].ToString() != "" && Sl_select["ca_name"].ToString() != "" && Sl_select["bar_code"].ToString() != "")
            {

                dgv_01.RowCount = 1;
                dgv_01.Rows[0].Cells["isselect"].Value = true;//打勾
                dgv_01.Rows[0].Cells["id"].Value = Sl_select["id"].ToString();
                dgv_01.Rows[0].Cells["bar_code"].Value = Sl_select["bar_code"].ToString();
                dgv_01.Rows[0].Cells["ca_name"].Value = Sl_select["ca_name"].ToString();
                dgv_01.Rows[0].Cells["in_cycle"].Value = Sl_select["in_cycle"].ToString();


                //str_id = Sl_select["id"].ToString();
                //str_name = Sl_select["ca_name"].ToString();
                //str_barcode = Sl_select["bar_code"].ToString();
                ////给dgv_01添加一行数据
                //DataGridViewRow drtemp01 = new DataGridViewRow();
                //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
                //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//barcode
                //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//实体包名
                //drtemp01.SetValues(true, str_id, str_barcode, str_name);
                //dgv_01.Rows.Add(drtemp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, Sl_select["id"].ToString());
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec005", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec005", sttemp01);
                //大于零代表有数据,给dgv_01添加一行数据,等于null是新包
                if (getdt == null)
                {
                    tb_set.Text = "新包";

                }
                else
                {
                    tb_set.Text = "旧包";

                }
            }
            if ((bool)dgv_01.Rows[0].Cells["isselect"].Value == false)
            {
                cb_old.Checked = false;
            }
            else
            {
                cb_old.Checked = true;
            }
        }

        private void Loaddata()
        {

            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //为true代表在循环中，所以字段的值是1，否则为9
            if (if_incycle == true)
            {
                sttemp01.Add(2, 1);
            }
            else
            {
                sttemp01.Add(2, 9);
            }
            //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec007", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec007", sttemp01);
            ifincycle_allset = getdt;//赋值查询内容
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

            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }

        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_showall_Click(object sender, EventArgs e)
        {

            Loaddata();
            if ((bool)dgv_01.Rows[0].Cells["isselect"].Value == false)
            {
                cb_old.Checked = false;
            }
            else
            {
                cb_old.Checked = true;
            }

            //从新选择
            this.cb_set.SelectedItem = null;
            this.tb_set.Visible = false;
            this.tb_set.Text = "";
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            //判断是进循环还是出循环，if_incycle == false为进循环
            if (if_incycle == false)
            {
                bool type = true;//新旧包类型，true为新包
                //cb_set为空时，tb_set为判断条件
                if (this.cb_set.Text == "")
                {

                    if (this.tb_set.Text == "新包")
                    {
                        type = true;
                    }
                    else
                    {
                        type = false;
                    }

                }
                //tb_set为空时，cb_set为判断条件
                if (this.tb_set.Text == "")
                {
                    if (this.cb_set.Text == "新包")
                    {
                        type = true;
                    }
                    else
                    {
                        type = false;
                    }
                    if (this.cb_set.SelectedItem == null)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "新旧包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                //存储你要修改的数据
                DataTable dtselect = new DataTable();
                //为datatable添加你需要添加的数据的字段名称
                dtselect.Columns.Add(new DataColumn("id"));
                dtselect.Columns.Add(new DataColumn("bar_code"));
                dtselect.Columns.Add(new DataColumn("ca_name"));
                dtselect.Columns.Add(new DataColumn("in_cycle"));
                DataRow dr = dtselect.NewRow();
                //在循环中判断，取得你需要修改的数据
                for (int i = 0; i < dgv_01.Rows.Count; i++)
                {
                    if ((bool)dgv_01.Rows[i].Cells["isselect"].Value == true)
                    {

                        dr["id"] = dgv_01.Rows[i].Cells["id"].Value.ToString();
                        dr["bar_code"] = dgv_01.Rows[i].Cells["bar_code"].Value;
                        dr["ca_name"] = dgv_01.Rows[i].Cells["ca_name"].Value.ToString();
                        //dr["in_cycle"] = dgv_01.Rows[i].Cells["in_cycle"].Value.ToString();
                        //循环时，检测当前实体包是否在循环中
                        //if (dgv_01.Rows[i].Cells["in_cycle"].Value.ToString() == "否")
                        //{
                        //    dr["in_cycle"] = dgv_01.Rows[i].Cells["in_cycle"].Value.ToString();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("你选择的实体包中存在循环中的实体包，请重新选择。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}

                        //给datatable添加一行数据
                        dtselect.Rows.Add(dr.ItemArray);
                    }
                }
                //如果行数为0，则说明没有选择实体包
                if (dtselect.Rows.Count == 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceset", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                HCSCM_in_cycle_location hcsm = new HCSCM_in_cycle_location(type, dtselect);
                // HCSCM_set_cycle_location hcsm = new HCSCM_set_cycle_location(dtselect, newold_type);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                this.Close();


            }
            else
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
                        #region 出循环时，改工单和包的状态
                        SortedList sltmp = new SortedList();
                        SortedList sltmp01 = new SortedList();
                        sltmp01.Add(1, 9);
                        sltmp01.Add(2, dgv_01.Rows[i].Cells["id"].Value.ToString());
                        sltmp01.Add(3, 6);
                        sltmp01.Add(4, dgv_01.Rows[i].Cells["id"].Value.ToString());
                        sltmp01.Add(5, getdt.Rows[0]["wf_code"].ToString());
                        sltmp.Add(1, sltmp01);
                        // string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-worksetupcycle-up001", sltmp, null);
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
                    this.Close();
                }


            }
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
                }
                else
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselect"].Value = false;
                    }
                }

            }
        }

        private void cb_set_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_01.Rows.Clear();
            if (cb_set.Text == "新包")
            {
                #region 显示新包
                dgv_01.Rows.Clear();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, "=");//等于为新包

                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec008", sttemp01);
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
                sttemp01.Add(2, 9);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec009", sttemp01);

                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec009", sttemp01); ;
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
                }
            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
                #endregion
        }
    }
}
