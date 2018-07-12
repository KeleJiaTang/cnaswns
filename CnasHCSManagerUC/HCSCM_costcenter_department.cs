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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_costcenter_department : TemplateForm
    {
        private DataTable dtccall = new DataTable();
        private DataTable dtgpappall = new DataTable();
        private SortedList sl_gpapp = new SortedList();
        private SortedList sl_allapp = new SortedList();
        private string Strdeid = "";
        private bool ifinfo = true;////判断参数数据是从哪里成本中心，还是部门传过来,true为成本中心。
        public HCSCM_costcenter_department(SortedList slinfo)
        {
            InitializeComponent();
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //设置窗体图标
            //this.Font = new Font(this.Font.FontFamily, 11);



            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--关联成本中心";
            ifinfo = (bool)slinfo["ifsec"];
            if ((bool)slinfo["ifsec"])//判断参数数据是从哪里成本中心，还是部门传过来。
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--配置部门";

                Strdeid = slinfo["cc_id"].ToString();
                tb_customer.Text = slinfo["cu_name"].ToString();
                tb_department.Text = slinfo["ca_name"].ToString();
                lb_department.Text = "成本中心";

                //客户Id
                string cu_id = slinfo["cu_id"].ToString();


                groupBox1.Text = "可选部门";
                groupBox2.Text = "已选部门";
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();

                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, cu_id);
                //根据客户id查询部门所有字段
                dtccall = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sttemp01);



                SortedList sttemp02 = new SortedList();
                sttemp02.Add(1, Strdeid);
                 string strtest = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-department-sec002", sttemp02);
                dtgpappall = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-department-sec002", sttemp02);
            }
            else
            {

                //部门ID
                Strdeid = slinfo["de_id"].ToString();
                //客户名称
                tb_customer.Text = slinfo["cu_name"].ToString();
                //部门名称
                tb_department.Text = slinfo["de_name"].ToString();
                //客户Id
                string cu_id = slinfo["cu_id"].ToString();

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();


                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, cu_id);
                //获取所有的成本中心数据
                dtccall = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sttemp01);



                SortedList sttemp02 = new SortedList();
                sttemp02.Add(1, Strdeid);
                string strtest = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-department-sec001", sttemp02);
                //获取已经和部门绑定的成本中心
                dtgpappall = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-department-sec001", sttemp02);
            }
            if (dtccall != null)
            {
                for (int i = 0; i < dtccall.Rows.Count; i++)//dtall有几行就循环几次
                {
                    DataRow[] arrayDR = dtccall.Select();
                    string str_id = "", str_app_name = "";
                    if (dtccall.Columns.Contains("id") && dtccall.Rows[i]["id"] != null) str_id = dtccall.Rows[i]["id"].ToString();
                    if (dtccall.Columns.Contains("ca_name") && dtccall.Rows[i]["ca_name"] != null) str_app_name = dtccall.Rows[i]["ca_name"].ToString();
                    GridViewRowInfo drtemp01 = null;
                    if (dtgpappall == null)//无关联的，全部放到dvg_01
                    {
                          
                            drtemp01 = radDgv_01.Rows.AddNew();
                            sl_allapp.Add(str_id, str_app_name);//sl_01data集合存储，str_id为键，str_group_name为名字
                        
                    }
                    else
                    {
                            DataRow[] arrayDRsec = null;
                            //判断参数数据是从哪里成本中心，还是部门传过来。
                            //同时判断成本中心是否已经选择过
                            if ((bool)slinfo["ifsec"])
                            {
                                arrayDRsec = dtgpappall.Select("de_id=" + str_id);
                            }
                            else
                            {
                                arrayDRsec = dtgpappall.Select("cc_id=" + str_id);
                            }
                            //如果成本中心已经被选择过，则放入已选列表
                            if (arrayDRsec.Length > 0)
                            {
                                drtemp01 = radDgv_02.Rows.AddNew();
                                sl_gpapp.Add(str_id, str_app_name);
                            }
                            else
                            {
                                drtemp01 = radDgv_01.Rows.AddNew();
                                sl_allapp.Add(str_id, str_app_name);
                            }
                    }
                    if (drtemp01 != null)
                    {
                        drtemp01.Cells[0].Value = false;
                        drtemp01.Cells[1].Value = str_id;
                        drtemp01.Cells[2].Value = str_app_name;
                    }
                    drtemp01.Tag = dtccall.Rows[i];
                    
                }
            }
        }

        private void but_addall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(radDgv_01, radDgv_02, false, true);

            //if (radDgv_01.Rows.Count > 0)
            //{
            //    for (int i = 0; i < radDgv_01.Rows.Count; i++)
            //    {
            //        string str_id = "", str_cc_name = "";
            //        if (radDgv_01.Rows[i].Cells["id"] != null) str_id = radDgv_01.Rows[i].Cells["id"].Value.ToString();
            //        if (radDgv_01.Rows[i].Cells["ca_name"] != null) str_cc_name = radDgv_01.Rows[i].Cells["ca_name"].Value.ToString();

            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id

            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_cc_name);
            //        radDgv_02.Rows.Add(drtemp01);
            //        sl_gpapp.Add(str_id, str_cc_name);

            //    }
            //    radDgv_01.Rows.Clear();
            //    sl_allapp.Clear();
            //}
        }

        private void but_reall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(radDgv_01, radDgv_02, false, false);

            //if (radDgv_02.Rows.Count > 0)
            //{

            //    for (int i = 0; i < radDgv_02.Rows.Count; i++)
            //    {
            //        string str_id = "", str_cc_name = "";
            //        if (radDgv_02.Rows[i].Cells["id2"] != null) str_id = radDgv_02.Rows[i].Cells["id2"].Value.ToString();
            //        if (radDgv_02.Rows[i].Cells["ca_name2"] != null) str_cc_name = radDgv_02.Rows[i].Cells["ca_name2"].Value.ToString();

            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码            
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_cc_name);
            //        radDgv_01.Rows.Add(drtemp01);
            //        sl_allapp.Add(str_id, str_cc_name);
            //    }
            //    radDgv_02.Rows.Clear();
            //    sl_gpapp.Clear();
            //}
        }

        private void but_addone_Click(object sender, EventArgs e)
        {

            CnasUtilityTools.MoveData(radDgv_01, radDgv_02, true, true);
            //if (radDgv_01.Rows.Count > 0)
            //{
            //    //SortedList sol_select = new SortedList();
            //    for (int i = 0; i < radDgv_01.Rows.Count; i++)
            //    {
            //        if (bool.Parse(radDgv_01.Rows[i].Cells["isselected"].Value.ToString()) == false) continue;
            //        string str_id = "", str_cc_name = "";
            //        if (radDgv_01.Rows[i].Cells["id"] != null) str_id = radDgv_01.Rows[i].Cells["id"].Value.ToString();
            //        if (radDgv_01.Rows[i].Cells["ca_name"] != null) str_cc_name = radDgv_01.Rows[i].Cells["ca_name"].Value.ToString();

            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_cc_name);
            //        radDgv_02.Rows.Add(drtemp01);
            //        sl_gpapp.Add(str_id, str_cc_name);
            //    }

            //    radDgv_01.Rows.Clear();
            //    sl_allapp.Clear();
            //    DataRow[] arrayDR = dtccall.Select();
            //    foreach (DataRow dr in arrayDR)//刷新dgv_01
            //    {
            //        string str_id = "", str_app_name = "";
            //        if (dr["id"] != null) str_id = dr["id"].ToString();
            //        if (dr["ca_name"] != null) str_app_name = dr["ca_name"].ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_name);
            //        if (sl_gpapp.IndexOfKey(str_id) < 0)
            //        {
            //            radDgv_01.Rows.Add(drtemp01);
            //            sl_allapp.Add(str_id, str_app_name);
            //        }
            //    }
            //}
        }

        private void but_reone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(radDgv_01, radDgv_02, true, false);
            //if (radDgv_02.Rows.Count > 0)
            //{
            //    for (int i = 0; i < radDgv_02.Rows.Count; i++)
            //    {
            //        if (bool.Parse(radDgv_02.Rows[i].Cells["isselected2"].Value.ToString()) == false) continue;
            //        string str_id = "", str_app_name = "";
            //        if (radDgv_02.Rows[i].Cells["id2"] != null) str_id = radDgv_02.Rows[i].Cells["id2"].Value.ToString();
            //        if (radDgv_02.Rows[i].Cells["ca_name2"] != null) str_app_name = radDgv_02.Rows[i].Cells["ca_name2"].Value.ToString();

            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_name);
            //        radDgv_01.Rows.Add(drtemp01);
            //        sl_allapp.Add(str_id, str_app_name);
            //    }

            //    radDgv_02.Rows.Clear();
            //    sl_gpapp.Clear();
            //    DataRow[] arrayDR = dtccall.Select();
            //    foreach (DataRow dr in arrayDR)
            //    {
            //        string str_id = "", str_app_name = "";
            //        if (dtccall.Columns.Contains("id") && dr["id"] != null) str_id = dr["id"].ToString();
            //        if (dtccall.Columns.Contains("ca_name") && dr["ca_name"] != null) str_app_name = dr["ca_name"].ToString();

            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//编码
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
            //        drtemp01.SetValues(false, str_id, str_app_name);
            //        if (sl_allapp.IndexOfKey(str_id) < 0)
            //        {
            //            radDgv_02.Rows.Add(drtemp01);
            //            sl_gpapp.Add(str_id, str_app_name);
            //        }
            //    }
            //}
        }

        private void but_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (radDgv_02.Rows.Count > 0)
                {
                    SortedList sltmp01 = new SortedList();
                    SortedList sltmp02 = new SortedList();
                    SortedList sltmp_01 = new SortedList();
                    sltmp_01.Add(1, Strdeid);
                    sltmp01.Add(1, sltmp_01);
                    for (int i = 0; i < radDgv_02.Rows.Count; i++)
                    {
                        if (ifinfo)//判断参数信息是从哪里传过来
                        {
                            SortedList sltmp_02 = new SortedList();
                            sltmp_02.Add(2, radDgv_02.Rows[i].Cells["id2"].Value.ToString());
                            sltmp_02.Add(1, Strdeid);
                            sltmp02.Add(i + 1, sltmp_02);
                        }
                        else
                        {
                            SortedList sltmp_02 = new SortedList();
                            sltmp_02.Add(1, radDgv_02.Rows[i].Cells["id2"].Value.ToString());
                            sltmp_02.Add(2, Strdeid);
                            sltmp02.Add(i + 1, sltmp_02);
                        }
                        
                    }
                    if (ifinfo)//判断参数信息是从哪里传过来
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-costcenter-department-add001", sltmp01, sltmp02);
                        int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-costcenter-department-add002", sltmp01, sltmp02);
                        if (recint > -1)
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("configuresuccessful", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-costcenter-department-add001", sltmp01, sltmp02);
                        int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-costcenter-department-add001", sltmp01, sltmp02);
                        if (recint > -1)
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("configuresuccessful", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    SortedList sltmp01 = new SortedList();
                    SortedList sltmp_01 = new SortedList();
                    sltmp_01.Add(1, Strdeid);
                    sltmp01.Add(1, sltmp_01);
                    if (ifinfo)//判断参数信息是从哪里传过来
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-costcenter-department-del001", sltmp01, null);
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-costcenter-department-del002", sltmp01, null);
                        if (recint > -1)
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("configuresuccessful", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-costcenter-department-del001", sltmp01, null);
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-costcenter-department-del001", sltmp01, null);
                        if (recint > -1)
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("configuresuccessful", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }



        }

        private void HCSCM_costcenter_department_Load(object sender, EventArgs e)
        {


        }

		private void radDgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_addone_Click(null, null);
		}

		private void radDgv_02_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_reone_Click(null, null);
		}
    }
}
