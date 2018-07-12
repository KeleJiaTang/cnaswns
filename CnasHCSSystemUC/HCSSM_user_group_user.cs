using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_user_group_user : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();
        private SortedList sl_02data = new SortedList();
        private SortedList sl_01data = new SortedList();
        private string Strgroupid = "";
        public HCSSM_user_group_user(string str_groupid, string str_gpname, string str_gptype)
        {
            InitializeComponent();
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--群用户管理";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            Strgroupid = str_groupid;
            this.Text = this.Text+"  "+str_gptype + "->" + str_gpname;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            dtall = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, str_groupid);
            dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup_user-sec001", sttemp02);

            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_user_name = "", str_user_nick = "";
                    if (dtall.Columns.Contains("id") && dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
					if (dtall.Columns.Contains("user_name") && dtall.Rows[i]["user_name"] != null) str_user_name = dtall.Rows[i]["user_name"].ToString();
					if (dtall.Columns.Contains("user_nick") && dtall.Rows[i]["user_nick"] != null) str_user_nick = dtall.Rows[i]["user_nick"].ToString();
                    GridViewRowInfo drtemp01 = null;// new GridViewRowInfo(dgv_02.viewInfo);

                    //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    //drtemp01.SetValues(false, str_id, str_user_name, str_user_nick);
                    if (dtselect == null)
                    {
                        drtemp01 = dgv_01.Rows.AddNew();

                        sl_01data.Add(str_id, str_user_name);
                        
                    }
                    else
                    {
                        
                        DataRow[] arrayDRsec = dtselect.Select("user_id=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            drtemp01 = dgv_02.Rows.AddNew();
                            //dgv_02.Rows.Add(drtemp01);
                            sl_02data.Add(str_id, str_user_name);
                        }
                        else
                        {
                            drtemp01 = dgv_01.Rows.AddNew();
                            //dgv_01.Rows.Add(drtemp01);
                            sl_01data.Add(str_id, str_user_name);
                        }
                    }
                    if (drtemp01 != null)
                    {
                        drtemp01.Cells[0].Value = false;
                        drtemp01.Cells[1].Value = str_id;
                        drtemp01.Cells[2].Value = str_user_name;
                        drtemp01.Cells[3].Value = str_user_nick;
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
        private void but_reone_Click(object sender, EventArgs e)
        {
           CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
        }

        private void but_reall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, Strgroupid);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, Strgroupid);
                    sltmp_02.Add(2, dgv_02.Rows[i].Cells["id2"].Value);
                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组用户配置成功。");
                    this.Close();
                }
            }else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, Strgroupid);
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_user-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup_user-del001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组用户配置成功。");
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
            if (dgv_02.Rows.Count > 0)
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
    }
}
