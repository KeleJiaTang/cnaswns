using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using Telerik.WinControls.UI;
using System.Drawing;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_usergroup : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();
        private SortedList sl_02data = new SortedList();
        private SortedList sl_01data = new SortedList();
        private SortedList sl_gptype = new SortedList();
        private string Struserid = "";
        /// <summary>
        /// 在dvg_01中显示ca_usergroup表的内容
        /// </summary>
        /// <param name="str_groupid">传入你选择的这一行数据表的ID</param>
        public HCSSM_usergroup(string str_userid, string str_username)
        {
            InitializeComponent();

            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            //this.Font = new System.Drawing.Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--群用户管理";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            Struserid = str_userid;//把user的ID存在Strgroupid字符串中
            this.Text = this.Text + "  " + "用户：" + str_username;

            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach (DataRow dr in arrayDR)
            {
                sl_gptype.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            dtall = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup-sec001", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, str_userid);
            dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup_user-sec002", sttemp02);
            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)//dtall有几行就循环几次
                {
                    string str_id = "", str_group_name = "", str_group_type = "";
                    if (dtall.Columns.Contains("id") && dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
					if (dtall.Columns.Contains("group_name") && dtall.Rows[i]["group_name"] != null) str_group_name = dtall.Rows[i]["group_name"].ToString();
					if (dtall.Columns.Contains("group_type") && dtall.Rows[i]["group_type"] != null) str_group_type = sl_gptype[dtall.Rows[i]["group_type"].ToString()].ToString();
                    GridViewRowInfo drtemp01 = null;
                    //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    //drtemp01.SetValues(false, str_id, str_group_name, str_group_type);
                    if (dtselect == null)//判断dtselect datatable是否为空
                    {
                        drtemp01 = dgv_01.Rows.AddNew();
                        sl_01data.Add(str_id, str_group_name);//sl_01data集合存储，str_id为键，str_group_name为名字

                    }
                    else
                    {
                        DataRow[] arrayDRsec = dtselect.Select("group_id=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            drtemp01 = dgv_02.Rows.AddNew();
                            sl_02data.Add(str_id, str_group_name);
                        }
                        else
                        {
                            drtemp01 = dgv_01.Rows.AddNew();
                            sl_01data.Add(str_id, str_group_name);
                        }
                    }
                    if (drtemp01 != null)
                    {
                        drtemp01.Cells[0].Value = false;
                        drtemp01.Cells[1].Value = str_id;
                        drtemp01.Cells[2].Value = str_group_name;
                        drtemp01.Cells[3].Value = str_group_type;
                    }

                    drtemp01.Tag = dtall.Rows[i];
                }

            }

        }

      
        private void but_addall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
           
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
          
        }

        private void but_reall_Click(object sender, EventArgs e)
        {
            //if (dgv_02.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dgv_02.Rows.Count; i++)
            //    {
            //        string str_id = "", str_group_name = "", str_group_type = "";
            //        if (dgv_02.Rows[i].Cells["group_id2"] != null) str_id = dgv_02.Rows[i].Cells["group_id2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["user_name2"] != null) str_group_name = dgv_02.Rows[i].Cells["user_name2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["group_type2"] != null) str_group_type = dgv_02.Rows[i].Cells["group_type2"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_group_name, str_group_type);
            //        dgv_01.Rows.Add(drtemp01);
            //        sl_01data.Add(str_id, str_group_name);
            //    }
            //    dgv_02.Rows.Clear();
            //    sl_02data.Clear();
            //}
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
        }

        private void but_reone_Click(object sender, EventArgs e)
        {

            //if (dgv_02.Rows.Count > 0)
            //{
            //    //添加dgv_01数据
            //    for (int i = 0; i < dgv_02.Rows.Count; i++)
            //    {
            //        if (bool.Parse(dgv_02.Rows[i].Cells["isselected2"].Value.ToString()) == false) continue;
            //        string str_id = "", str_group_name = "", str_group_type = "";
            //        if (dgv_02.Rows[i].Cells["group_id2"] != null) str_id = dgv_02.Rows[i].Cells["group_id2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["user_name2"] != null) str_group_name = dgv_02.Rows[i].Cells["user_name2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["group_type2"] != null) str_group_type = dgv_02.Rows[i].Cells["group_type2"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_group_name, str_group_type);
            //        dgv_01.Rows.Add(drtemp01);
            //        sl_01data.Add(str_id, str_group_name);
            //    }

            //    dgv_02.Rows.Clear();
            //    sl_02data.Clear();

            //    //刷新dgv_02数据
            //    for (int i = 0; i < dtall.Rows.Count; i++)
            //    {
            //        string str_id = "", str_group_name = "", str_group_type = "";
            //        if (dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
            //        if (dtall.Rows[i]["group_name"] != null) str_group_name = dtall.Rows[i]["group_name"].ToString();
            //        if (dtall.Rows[i]["group_type"] != null) str_group_type = dtall.Rows[i]["group_type"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_group_name, str_group_type);
            //        if (sl_01data.IndexOfKey(str_id) < 0)
            //        {
            //            dgv_02.Rows.Add(drtemp01);
            //            sl_02data.Add(str_id, str_group_name);
            //        }
            //    }
            //}
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, Struserid);//用户ID号
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();                    
                    sltmp_02.Add(1, dgv_02.Rows[i].Cells["group_id2"].Value);
                    sltmp_02.Add(2, Struserid);
                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-usergroup_user-add002", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组配置成功。");
                    this.Close();
                }
            }else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, Struserid);//用户ID号
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup_user-del002", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组配置成功。");
                    this.Close();
                }
            }
        }

        private void cb_old_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)//判断dgv_01里是否有选项，有就全选或取消。
            {
                if (cb_old.Checked == true)
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = false;
                    }
                }
            }
        }

        

        private void cb_new_CheckedChanged(object sender, EventArgs e)
        {

            if (dgv_02.Rows.Count > 0)//判断dgv_02里是否有选项，有就全选或取消。
            {
                if (cb_new.Checked == true)
                {
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        dgv_02.Rows[i].Cells["isselected2"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        dgv_02.Rows[i].Cells["isselected2"].Value = false;
                    }
                }
            }
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void but_save_Click(object sender, KeyEventArgs e)
        {

        }
    }
}
