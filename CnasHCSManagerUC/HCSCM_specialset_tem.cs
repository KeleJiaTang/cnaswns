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
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_specialset_tem : UserControl
    {
        private DataRow[] arrayDR = null;//用于传输数据
        public SortedList sl_spe = new SortedList();
        public SortedList sl_customer = new SortedList();
        public SortedList sl_customerid = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_location = new SortedList();
        public HCSCM_specialset_tem()
        {
            InitializeComponent();
            #region 按钮图片加载
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_item.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "instrumentManagement", EnumImageType.PNG);
            #endregion

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttlmp = new SortedList();
            sttlmp.Add(1, CnasBaseData.SystemID);
            DataTable Specialset = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sec001", sttlmp);
            if (Specialset != null && Specialset.Rows.Count > 0)
            {
                for (int i = 0; i < Specialset.Rows.Count; i++)
                {
                    sl_spe.Add(Specialset.Rows[i]["id"].ToString(), Specialset.Rows[i]["name"].ToString());
                }
            }
            //获取客户数据
            DataTable DTcustomer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (DTcustomer != null)
            {
                this.raddl_customer.Items.Add("----所有----");
                sl_customer.Add("0", "----所有----");
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["id"].ToString() != null && DTcustomer.Rows[i]["bar_code"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_customer.Add(DTcustomer.Rows[i]["bar_code"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        sl_customerid.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        raddl_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                raddl_customer.Text = "----所有----";
            }
            //获取使用地点数据
            DataTable DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_location.Add(DTlocation.Rows[i]["id"].ToString().Trim(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
            SortedList customerid = new SortedList();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心


            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_costcenter.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            Loaddate();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void Loaddate()
        {
			dgv_01.ClearSelection();
            string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.raddl_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttlmp = new SortedList();
            sttlmp.Add(1, CnasBaseData.SystemID);
            //string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-sec001", sttlmp);
            DataTable Item = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-sec001", sttlmp);
            try
            {
                string str_seach = radText_name.Text.Trim();
                
                if (str_usertp == "0")//查询所有客户的基本包
                {
                    if (str_seach.Length > 0)
                    {
                        str_seach = "name like '%" + str_seach + "%' or ca_name_cc like '%" + str_seach + "%'";
                        arrayDR = Item.Select(str_seach);
                    }
                    else
                    {                        
                        arrayDR = Item.Select();
                        //str_seach = "customer_barcode=" + "'" + str_usertp + "'";
                        //arrayDR = Item.Select(str_seach);
                    }
                }
                else
                {
                    if (str_seach.Length > 0)
                    {
                        str_seach = "customer_barcode=" + "'" + str_usertp + "'" + " and ( name like '%" + str_seach + "%' or ca_name_cc like '%" + str_seach + "%')";
                        arrayDR = Item.Select(str_seach);//根据客户查询包
                    }
                    else
                    {
                        str_seach = "customer_barcode=" + "'" + str_usertp + "'";
                        arrayDR = Item.Select(str_seach);
                    }
                }
               
            }
            catch
            {
                MessageBox.Show("输入的信息有误，请重新输入。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgv_01.Rows.Clear();
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {


                if (dr["user_id"] != null) dgv_01.Rows[i].Cells["s_user"].Value = dr["user_id"].ToString();
                if (dr["cre_date"] != null) dgv_01.Rows[i].Cells["s_time"].Value = dr["cre_date"].ToString();
                if (dr["name"] != null) dgv_01.Rows[i].Cells["s_specialset"].Value = dr["name"].ToString();
                if (dr["id"] != null) dgv_01.Rows[i].Cells["idCol"].Value = dr["id"].ToString();
                if (dr["customer_barcode"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[dr["customer_barcode"].ToString()].ToString();
                if (dr["location_id"] != null) dgv_01.Rows[i].Cells["s_location"].Value = sl_location[dr["location_id"].ToString()].ToString();
                if (dr["cost_center"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter[dr["cost_center"].ToString()].ToString();

                i++;


            }
            dgv_01.CurrentRow = dgv_01.Rows[0];

        }
        /// <summary>
        /// 新建按钮触发事件
        /// </summary>
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_specialset_add HCSM = new HCSCM_specialset_add(null);
            HCSM.ShowDialog();
            Loaddate();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }
        /// <summary>
        /// "器械管理"按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_item_Click(object sender, EventArgs e)
        {
			
            if (dgv_01.SelectedRows.Count > 0)
            {
				try
				{ 
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList aa = new SortedList();
                aa.Add("name", dgv_01.SelectedRows[0].Cells["s_specialset"].Value.ToString());
                aa.Add("id", dgv_01.SelectedRows[0].Cells["idCol"].Value.ToString());
                aa.Add("customer", sl_customer.GetKey(sl_customer.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value.ToString())));
                aa.Add("customerid", sl_customerid.GetKey(sl_customerid.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value.ToString())));
                aa.Add("costcentername", sl_costcenter.GetKey(sl_costcenter.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_costcenter"].Value.ToString())));
                aa.Add("costcenter", dgv_01.SelectedRows[0].Cells["s_costcenter"].Value.ToString());
                bool iswindows = true;
                HCSCM_specialset_item_add HH = new HCSCM_specialset_item_add(aa, iswindows);
                Loaddate();
                HH.ShowDialog();
                if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }
				}
			catch(Exception ex)
			{			}
            }
			
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "配置", "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        /// <summary>
        /// "修改"按钮的触发事件
        /// </summary>
        private void but_edit_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                sltmp.Add("name", dgv_01.SelectedRows[0].Cells["s_specialset"].Value.ToString());
                sltmp.Add("id", dgv_01.SelectedRows[0].Cells["idCol"].Value.ToString());
                sltmp.Add("customer", dgv_01.SelectedRows[0].Cells["s_customer"].Value.ToString());
                sltmp.Add("location", dgv_01.SelectedRows[0].Cells["s_location"].Value.ToString());
                sltmp.Add("costcenter", dgv_01.SelectedRows[0].Cells["s_costcenter"].Value.ToString());
                HCSCM_specialset_add hh = new HCSCM_specialset_add(sltmp);
                hh.ShowDialog();
                Loaddate();
                if (dgv_01.Rows.Count > selectedIndex)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// “删除”按钮的触发事件
        /// </summary>
        private void but_remove_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                #region 判断模板是否被物品占用
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-item-sec001", null);//99
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["specialset_tem_id"].ToString() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["idCol"].Value.ToString() == getdt.Rows[i]["specialset_tem_id"].ToString().Trim())
                            {
                                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation", EnumPromptMessage.warning, new string[] { "订单模板", "订单器械", "订单器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["s_specialset"].Value.ToString(), "订单器械模块" }), ConfigurationManager.AppSettings["SystemName"] + "--删除订单器械模块", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["idCol"].Value);
                sltmp.Add(1, sltmp01);

                // string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-washing-device-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-specialset-del001", sltmp, null);


                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "订单器械模块" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "订单器械模块" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_edit_Click(null, null);
        }

        private void raddl_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Loaddate();
        }

        private void radBut_sel_Click(object sender, EventArgs e)
        {
            Loaddate();
        }

        private void radText_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Loaddate();
            }

        }
    }
}
