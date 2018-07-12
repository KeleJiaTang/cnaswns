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
    public partial class HCSSM_user_group_app : TemplateForm
    {
        private DataTable dtappall = new DataTable();
        private DataTable dtgpappall = new DataTable();
        private SortedList sl_gpapp = new SortedList();
        private SortedList sl_allapp = new SortedList();
        private string Strgroupid = "";
        public HCSSM_user_group_app(string str_groupid,string str_gpname,string str_gptype)
        {
            InitializeComponent();
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reaone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
           
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--配置群组";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            Strgroupid = str_groupid;
            this.Text = this.Text+"  "+str_gptype + "->" + str_gpname;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);


            string a = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-app-sec001", sttemp01);
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec001", sttemp01);

            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, str_groupid);



            string b = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-usergroup_app-sec001", sttemp01);
            dtgpappall = reCnasRemotCall.RemotInterface.SelectData("HCS-usergroup_app-sec001", sttemp02);
            
            if (dtappall != null)
            {

                DataRow[] arrayDR = dtappall.Select("app_type=1");
                if (dtgpappall == null)//无配置文件，全部放到dvg_01
                {
                    foreach (DataRow dr in arrayDR)
                    {
                        string str_id = "", str_app_name = "", str_app_briefcode = "";
                        if (dtappall.Columns.Contains("id") && dr["id"] != null) str_id = dr["id"].ToString();
						if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
						if (dtappall.Columns.Contains("app_briefcode") && dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
						GridViewRowInfo drtemp01 = null;
                        //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                        //drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);                        
                        //dgv_01.Rows.Add(drtemp01);
                        drtemp01 = dgv_01.Rows.AddNew();
                        sl_allapp.Add(str_id, str_app_name);
						if (drtemp01 != null)
						{
							drtemp01.Cells[0].Value = false;
							drtemp01.Cells[1].Value = str_id;
							drtemp01.Cells[2].Value = str_app_briefcode;
							drtemp01.Cells[3].Value = str_app_name;
						}

						drtemp01.Tag = dr;
                    }
                }
                else
                {
                    foreach (DataRow dr in arrayDR)
                    {
                        string str_id = "", str_app_name = "", str_app_briefcode = "";
						if (dtappall.Columns.Contains("id") && dr["id"] != null) str_id = dr["id"].ToString();
						if (dtappall.Columns.Contains("app_name") && dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
						if (dtappall.Columns.Contains("app_briefcode") && dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
                        GridViewRowInfo drtemp01 = null;
                        //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
                        //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                        //drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
                        DataRow[] arrayDRsec = dtgpappall.Select("app_id=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            //dgv_02.Rows.Add(drtemp01);
                            drtemp01 = dgv_02.Rows.AddNew();
                            sl_gpapp.Add(str_id, str_app_name);
                        }else
                        {
                            drtemp01 = dgv_01.Rows.AddNew();
                            sl_allapp.Add(str_id, str_app_name);
                        }
                        if (drtemp01 != null)
                        {
                            drtemp01.Cells[0].Value = false;
                            drtemp01.Cells[1].Value = str_id;
                            drtemp01.Cells[2].Value = str_app_briefcode;
                            drtemp01.Cells[3].Value = str_app_name;
                        }

                        drtemp01.Tag = dr;
                    }
                   
                }
            }
        }
        private void LoadDate()
        {

        }

        private void but_addall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
            //if(dgv_01.Rows.Count>0)
            //{                
            //    for(int i=0;i<dgv_01.Rows.Count;i++)
            //    {
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["app_name"] != null) str_app_name = dgv_01.Rows[i].Cells["app_name"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["app_briefcode"] != null) str_app_briefcode = dgv_01.Rows[i].Cells["app_briefcode"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        dgv_02.Rows.Add(drtemp01);
            //        sl_gpapp.Add(str_id, str_app_name);
                    
            //    }
            //    dgv_01.Rows.Clear();
            //    sl_allapp.Clear();
            //}
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
            //if (dgv_01.Rows.Count > 0)
            //{
            //    //SortedList sol_select = new SortedList();
            //    for (int i = 0; i < dgv_01.Rows.Count; i++)
            //    {                   
            //        if (bool.Parse( dgv_01.Rows[i].Cells["isselected"].Value.ToString()) == false) continue;
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["app_name"] != null) str_app_name = dgv_01.Rows[i].Cells["app_name"].Value.ToString();
            //        if (dgv_01.Rows[i].Cells["app_briefcode"] != null) str_app_briefcode = dgv_01.Rows[i].Cells["app_briefcode"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        dgv_02.Rows.Add(drtemp01);
            //        sl_gpapp.Add(str_id, str_app_name);
            //    }

            //    dgv_01.Rows.Clear();
            //    sl_allapp.Clear();
            //    DataRow[] arrayDR = dtappall.Select("app_type=1");
            //    foreach (DataRow dr in arrayDR)
            //    {
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dr["id"] != null) str_id = dr["id"].ToString();
            //        if (dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
            //        if (dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        if (sl_gpapp.IndexOfKey(str_id) < 0)
            //        {
            //            dgv_01.Rows.Add(drtemp01);
            //            sl_allapp.Add(str_id, str_app_name);
            //        }
            //    }
            //}
        }

        private void but_reone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
            //if (dgv_02.Rows.Count > 0)
            //{               
            //    for (int i = 0; i < dgv_02.Rows.Count; i++)
            //    {
            //        if (bool.Parse(dgv_02.Rows[i].Cells["isselected2"].Value.ToString()) == false) continue;
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dgv_02.Rows[i].Cells["id2"] != null) str_id = dgv_02.Rows[i].Cells["id2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["app_name2"] != null) str_app_name = dgv_02.Rows[i].Cells["app_name2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["app_briefcode2"] != null) str_app_briefcode = dgv_02.Rows[i].Cells["app_briefcode2"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        dgv_01.Rows.Add(drtemp01);
            //        sl_allapp.Add(str_id, str_app_name);
            //    }

            //    dgv_02.Rows.Clear();
            //    sl_gpapp.Clear();
            //    DataRow[] arrayDR = dtappall.Select("app_type=1");
            //    foreach (DataRow dr in arrayDR)
            //    {
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dr["id"] != null) str_id = dr["id"].ToString();
            //        if (dr["app_name"] != null) str_app_name = dr["app_name"].ToString();
            //        if (dr["app_briefcode"] != null) str_app_briefcode = dr["app_briefcode"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        if (sl_allapp.IndexOfKey(str_id) < 0)
            //        {
            //            dgv_02.Rows.Add(drtemp01);
            //            sl_gpapp.Add(str_id, str_app_name);
            //        }
            //    }
            //}
        }

        private void but_reall_Click(object sender, EventArgs e)
        {

            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
            //if (dgv_02.Rows.Count > 0)
            //{

            //    for (int i = 0; i < dgv_02.Rows.Count; i++)
            //    {
            //        string str_id = "", str_app_name = "", str_app_briefcode = "";
            //        if (dgv_02.Rows[i].Cells["id2"] != null) str_id = dgv_02.Rows[i].Cells["id2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["app_name2"] != null) str_app_name = dgv_02.Rows[i].Cells["app_name2"].Value.ToString();
            //        if (dgv_02.Rows[i].Cells["app_briefcode2"] != null) str_app_briefcode = dgv_02.Rows[i].Cells["app_briefcode2"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//简码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_briefcode, str_app_name);
            //        dgv_01.Rows.Add(drtemp01);
            //        sl_allapp.Add(str_id, str_app_name);
            //    }
            //    dgv_02.Rows.Clear();
            //    sl_gpapp.Clear();
            //}
        }

        private void cb_old_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count > 0)
            {   
                if(cb_old.Checked==true)
                {
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        dgv_01.Rows[i].Cells["isselected"].Value = true;  
                    }
                }else
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
                string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_app-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-usergroup_app-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组配置成功。");
                    this.Close();
                }
            }else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, Strgroupid);
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-usergroup_app-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup_app-del001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，群组配置成功。");
                    this.Close();
                }

            }
        }

    }
}
