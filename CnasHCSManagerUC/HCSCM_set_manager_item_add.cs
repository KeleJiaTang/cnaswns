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
    public partial class HCSCM_set_manager_item_add : TemplateForm
    {
        //private string type = "";

        public SortedList sl_02data = new SortedList();//存储所需的器械
        string set_type = "";//包类型，主要针对单包
        private string set_cc = "";//基本包的成本中心
        private string set_cucc = "";//基本包的客户cssd自身成本中心
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">基本包类型</param>
        /// <param name="cc">基本包成本中心</param>
        public HCSCM_set_manager_item_add(string type, string cc, string cu)
        {
            InitializeComponent();
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--器械类型选择";
            //加载出这个客户底下的所有成本中心
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, cu);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sttemp01);//41没si_id要改（时间）
            //查出cssd的成本中心
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-CSSD-costcenter'");
            string[] code_cc = arrayDR[0]["value_code"].ToString().Split(',');
            for (int i = 0; i < code_cc.Length; i++)
            {
                if (code_cc[i] != "")//判空
                {
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        dgv_01.RowCount = ii;
                        for (int j = 0; j < ii; j++)
                        {
                            if (getdt.Rows[j]["bar_code"].ToString() == code_cc[i])
                            {
                                set_cucc = code_cc[i];
                            }
                        }

                    }
                }
            }
            foreach (DataRow dr in arrayDR)
            {

                //sl_type_05.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                //this.cb_put.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }

            set_type = type;
            set_cc = cc;
            Loaddata();
        }

        private void Loaddata()
        {

            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            sttemp01.Add(2, set_cc);
            sttemp01.Add(3, set_cucc);
            //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec005", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec005", sttemp01);//220

            if (getdt != null)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                }
            }
            if (dgv_01.Rows.Count > 0)
                dgv_01.CurrentRow = dgv_01.Rows[0];
        }

        private void but_save_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgv_02.RowCount; i++)
			{
                sl_02data.Add(dgv_02.Rows[i].Cells["id2"].Value.ToString(), dgv_02.Rows[i].Cells["ca_name"].Value.ToString());
			}
            this.Close();
            
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            dgv_02.Rows.Clear();
            sl_02data.Clear();
            this.Close();
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            //dgv_02.Rows.Clear();
            //sl_02data.Clear();
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
            //if (dgv_01.Rows.Count > 0)
            //{
            //    //SortedList sol_select = new SortedList();


            //    string str_id = "", str_app_name = "";
            //    if (dgv_02.Rows.Count == 0)//如果dgv_02没数据，则第一次添加数据，后面查重会赛选
            //    {
            //        for (int k = 0; k < dgv_01.Rows.Count; k++)
            //        {
            //            if (dgv_01.Rows[k].Cells["isselected"].Value == null) continue;
            //            if (bool.Parse(dgv_01.Rows[k].Cells["isselected"].Value.ToString()) == false) continue;
            //            if (dgv_01.Rows[k].Cells["id"] != null) str_id = dgv_01.Rows[k].Cells["id"].Value.ToString();
            //            if (dgv_01.Rows[k].Cells["ca_name"] != null) str_app_name = dgv_01.Rows[k].Cells["ca_name"].Value.ToString();

            //            DataGridViewRow drtemp01 = new DataGridViewRow();
            //            drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //            drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //            drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名

            //            drtemp01.SetValues(false, str_id, str_app_name);
            //            dgv_02.Rows.Add(drtemp01);
            //            sl_02data.Add(str_id, str_app_name);
            //        }
            //    }
            //    else
            //    {
            //        int sum = 0;//判断重复
            //        for (int i = 0; i < dgv_01.Rows.Count; i++)
            //        {
            //            if (dgv_01.Rows[i].Cells["isselected"].Value == null) continue;
            //            if (bool.Parse(dgv_01.Rows[i].Cells["isselected"].Value.ToString()) == false) continue;
            //            for (int j = 0; j < dgv_02.Rows.Count; j++)//循环查重
            //            {
            //                if (dgv_01.Rows[i].Cells["id"].Value.ToString() != dgv_02.Rows[j].Cells["id02"].Value.ToString())//如果dgv_02中已经存这个id的器械，则不添加
            //                {
            //                    sum++;
            //                }
            //                else
            //                {
            //                    sum--;
            //                }



            //            }
            //            if (sum == dgv_02.Rows.Count)//如果相等，则说明这个器械已经与表全部器械比较过了，不重复，可以添加
            //            {
            //                if (dgv_01.Rows[i].Cells["id"] != null) str_id = dgv_01.Rows[i].Cells["id"].Value.ToString();
            //                if (dgv_01.Rows[i].Cells["ca_name"] != null) str_app_name = dgv_01.Rows[i].Cells["ca_name"].Value.ToString();

            //                DataGridViewRow drtemp01 = new DataGridViewRow();
            //                drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名

            //                drtemp01.SetValues(false, str_id, str_app_name);
            //                dgv_02.Rows.Add(drtemp01);
            //                sl_02data.Add(str_id, str_app_name);
            //            }
            //            sum = 0;
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
            //        if (dgv_02.Rows[i].Cells["isselect02"].Value == null) continue;
            //        if (bool.Parse(dgv_02.Rows[i].Cells["isselect02"].Value.ToString()) == false) continue;
            //        string str_id = "", str_app_name = "";
            //        if (dgv_02.Rows[i].Cells["id02"] != null) str_id = dgv_02.Rows[i].Cells["id02"].Value.ToString();
                    
            //        if (dgv_02.Rows[i].Cells["ca_name02"] != null) str_app_name = dgv_02.Rows[i].Cells["ca_name02"].Value.ToString();
            //        try//抛异常的为重复的，移除重复的
            //        {
            //            sl_02data.Add(str_id, str_app_name);
            //        }
            //        catch
            //        {
            //            sl_02data.Remove(str_id);
            //        }
            //    }
            //}

        }

        private void HCSCM_set_manager_item_add_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                dgv_01.Rows.Clear();
                string strsecdata = tb_sname.Text.Trim();


                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                sttemp01.Add(2, set_cc);
                sttemp01.Add(3, set_cucc);
                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec005", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec005", sttemp01);
                DataRow[] arrayDR = arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' ");
                int ii = arrayDR.Length;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int i = 0;
                foreach (DataRow dr in arrayDR)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
					if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();

                    i++;
                }
            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {

            dgv_01.Rows.Clear();
            //需要查询器械的名称
            string strsecdata = tb_sname.Text.Trim();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            sttemp01.Add(2, set_cc);
            sttemp01.Add(3, set_cucc);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec005", sttemp01);
            //查询统一成本中心的器械
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec005", sttemp01);

            //如果等于nUll，则直接返回
            if (getdt == null) return;

            DataRow[] arrayDR = getdt.Select(" ca_name like '%" + strsecdata + "%' ");
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
				if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();

                i++;
            }
        }

        private void HCSCM_set_manager_item_add_Load(object sender, EventArgs e)
        {

        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_addone_Click(null, null);
		}

		private void dgv_02_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_reone_Click(null, null);
		}
    }
}
