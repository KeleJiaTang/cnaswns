using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_storage_manage : UserControl
    {
        SortedList sl_type = new SortedList();//器械类型
        SortedList sl_customer = new SortedList();//客户
        SortedList sl_customer01 = new SortedList();//客户
		SortedList sl_costcenter = new SortedList();//成本中心
		SortedList sl_costcenter2 = new SortedList();//成本中心
        SortedList sl_uselocation = new SortedList();//使用地点
        DataTable DTcustomer = new DataTable();//读取客户数据
        DataTable DTcostcenter = new DataTable();//读取成本中心数据
        DataTable DTlocation = new DataTable();//读取使用地点数据
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
        public HCSCM_storage_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.bt_ins.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "configureSterilizer", EnumImageType.PNG);
            this.bt_set.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "configureSet", EnumImageType.PNG);
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "export", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取存储点类型
            DataRow[] type = CnasBaseData.SystemBaseData.Select("type_code='HCS-storage-type'");
            if (type.Length > 0)
            {
                foreach (DataRow dr in type)
                {
                    sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                }
            }

            //获取使用地点数据
            DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_uselocation.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
			//获取成本中心数据
			DTcostcenter = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
			if (DTcostcenter != null)
			{
				int ii = DTcostcenter.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (DTcostcenter.Rows[i]["id"].ToString() != null && DTcostcenter.Rows[i]["ca_name"].ToString().Trim() != null)
					{
						sl_costcenter.Add(DTcostcenter.Rows[i]["id"].ToString(), DTcostcenter.Rows[i]["ca_name"].ToString().Trim());
					}
				}
			}
            //获取客户数据
            DTcustomer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (DTcustomer != null)
            {
                this.cb_customer.Items.Add("----所有----");
                sl_customer.Add("0", "----所有----");
                int ii = DTcustomer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTcustomer.Rows[i]["id"].ToString() != null && DTcustomer.Rows[i]["cu_name"].ToString().Trim() != null)
                    {

                        sl_customer.Add(DTcustomer.Rows[i]["id"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        sl_customer01.Add(DTcustomer.Rows[i]["bar_code"].ToString(), DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(DTcustomer.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                cb_customer.Text = "----所有----";
            }
            Loaddata(null);
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCS'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
        }

		private void Costcenter(string customerid)
		{
			sl_costcenter2.Clear();
			SortedList sl_barcode = new SortedList();
			sl_barcode.Add(1, customerid);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string ggg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-costcenter-sec002", sl_barcode);
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
			if (getdt != null)
			{
				int ii = getdt.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
					{
						sl_costcenter2.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
					}
				}
			}
		}

        private void Loaddata(string s_customer)
        {
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            DataTable getdt = null;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();


            if (cb_customer.Text == "----所有----" || s_customer == null)
            {
                //返回所有存储点数据
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            }
            else
            {
                sttemp01.Add(1, s_customer);//客户ID
               
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec002", sttemp01);
            }
            if (getdt != null &&getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("s_type") && getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type[getdt.Rows[i]["s_type"].ToString()].ToString();
					if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("s_barcode") && getdt.Rows[i]["s_barcode"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["s_barcode"].ToString();
					if (getdt.Columns.Contains("s_name") && getdt.Rows[i]["s_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["s_name"].ToString();
					if (getdt.Columns.Contains("s_customer") && getdt.Rows[i]["s_customer"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[getdt.Rows[i]["s_customer"].ToString()].ToString();
					if (getdt.Columns.Contains("s_room") && getdt.Rows[i]["s_room"] != null) dgv_01.Rows[i].Cells["s_room"].Value = getdt.Rows[i]["s_room"].ToString();
					if (getdt.Columns.Contains("s_basket") && getdt.Rows[i]["s_basket"] != null) dgv_01.Rows[i].Cells["s_basket"].Value = getdt.Rows[i]["s_basket"].ToString();
					Costcenter(getdt.Rows[i]["s_customer"].ToString());
					if (getdt.Columns.Contains("s_costcenter") && getdt.Rows[i]["s_costcenter"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter2[getdt.Rows[i]["s_costcenter"].ToString()].ToString();
					if (getdt.Columns.Contains("s_cabinet") && getdt.Rows[i]["s_cabinet"] != null) dgv_01.Rows[i].Cells["s_cabinet"].Value = getdt.Rows[i]["s_cabinet"].ToString();
					if (getdt.Columns.Contains("s_remarks") && getdt.Rows[i]["s_remarks"] != null) dgv_01.Rows[i].Cells["s_remarks"].Value = getdt.Rows[i]["s_remarks"].ToString();
					if (getdt.Columns.Contains("s_uselocation") && getdt.Rows[i]["s_uselocation"] != null) dgv_01.Rows[i].Cells["s_uselocation"].Value = sl_uselocation[getdt.Rows[i]["s_uselocation"].ToString()].ToString();

                }
				if (dgv_01.Rows.Count > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
			}
        }



        private void but_new_Click(object sender, EventArgs e)
        {

            HCSCM_storage_manage_new hcsm = new HCSCM_storage_manage_new(null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(null);
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }

        }
        //客户的查询触发事件
        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb_ins.Checked = false;
            rb_base.Checked = false;
            if (this.cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }
        //修改
        private void but_edit_Click(object sender, EventArgs e)
        {
			if(dgv_01.SelectedRows.Count==0)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();//存取和传递dgv某一行数据
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value);
                slindata.Add("s_barcode", dgv_01.SelectedRows[0].Cells["s_barcode"].Value);
                slindata.Add("s_type", dgv_01.SelectedRows[0].Cells["s_type"].Value);
                slindata.Add("s_room", dgv_01.SelectedRows[0].Cells["s_room"].Value);
                slindata.Add("s_customer", sl_customer.GetKey(sl_customer.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value)));
                slindata.Add("s_uselocation", sl_uselocation.GetKey(sl_uselocation.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_uselocation"].Value)));
				Costcenter(sl_customer.GetKey(sl_customer.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value)).ToString());
                slindata.Add("s_costcenter", sl_costcenter2.GetKey(sl_costcenter2.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_costcenter"].Value)));
                slindata.Add("s_basket", dgv_01.SelectedRows[0].Cells["s_basket"].Value);
                slindata.Add("s_remarks", dgv_01.SelectedRows[0].Cells["s_remarks"].Value);
                slindata.Add("s_cabinet", dgv_01.SelectedRows[0].Cells["s_cabinet"].Value);
                HCSCM_storage_manage_new hcsm = new HCSCM_storage_manage_new(slindata);
                hcsm.ShowDialog();
				if (tb_sel.Text == string.Empty)
				{
					if (rb_base.Checked == false && rb_ins.Checked == false)
					{
						if (this.cb_customer.Text == "----所有----")
						{

							Loaddata(null);
						}
						else
						{
							Loaddata(sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
						}
					}
					else
					{
						if (rb_ins.Checked == true)
						{
							rb_CheckedChanged(null, null);
						}
						if (rb_base.Checked == true)
						{
							rb_base_CheckedChanged(null, null);
						}
					}
				}
				else
				{
					GetData();
				}
				if (dgv_01.Rows.Count > selectedIndex)
				{
					dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
				}
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //删除
        private void but_remove_Click(object sender, EventArgs e)
        {
			if (dgv_01.SelectedRows.Count == 0)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            try
            {
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                #region 判断存储点是否被实体包占用

                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec004", sttemp01);//137
                if (getdt != null)
                {

                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
						if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["storage_id_02"].ToString().Trim() || dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["storage_id"].ToString().Trim())
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation", EnumPromptMessage.warning, new string[] { "存储点", "实体包", "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                #endregion
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString(), "存储点" }), ConfigurationManager.AppSettings["SystemName"] + "--删除存储点", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasremotCall = new CnasRemotCall();
                string gg = reCnasremotCall.RemotInterface.CheckUPData(1, "HCS-storage-del001", sltmp, null);
                int recint = reCnasremotCall.RemotInterface.UPData(1, "HCS-storage-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "存储点" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 器械存储区按钮
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            SortedList sltmp02 = new SortedList();
            DataTable getdt = null;

            if (cb_customer.Text.Trim() == "----所有----")
            {
                sltmp.Add(1, 2);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec004", sltmp);
            }
            else
            {
                string customer = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
                sltmp01.Add(1, Convert.ToInt32(customer));
                sltmp01.Add(2, 2);
                //string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec003", sltmp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec003", sltmp01);
            }
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
					if (getdt.Columns.Contains("s_type") && getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type[getdt.Rows[i]["s_type"].ToString()].ToString();
					if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("s_barcode") && getdt.Rows[i]["s_barcode"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["s_barcode"].ToString();
					if (getdt.Columns.Contains("s_name") && getdt.Rows[i]["s_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["s_name"].ToString();
					if (getdt.Columns.Contains("s_customer") && getdt.Rows[i]["s_customer"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[getdt.Rows[i]["s_customer"].ToString()].ToString();
					if (getdt.Columns.Contains("s_room") && getdt.Rows[i]["s_room"] != null) dgv_01.Rows[i].Cells["s_room"].Value = getdt.Rows[i]["s_room"].ToString();
					if (getdt.Columns.Contains("s_basket") && getdt.Rows[i]["s_basket"] != null) dgv_01.Rows[i].Cells["s_basket"].Value = getdt.Rows[i]["s_basket"].ToString();
					if (getdt.Columns.Contains("s_costcenter") && getdt.Rows[i]["s_costcenter"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter[getdt.Rows[i]["s_costcenter"].ToString()].ToString();
					if (getdt.Columns.Contains("s_cabinet") && getdt.Rows[i]["s_cabinet"] != null) dgv_01.Rows[i].Cells["s_cabinet"].Value = getdt.Rows[i]["s_cabinet"].ToString();
					if (getdt.Columns.Contains("s_remarks") && getdt.Rows[i]["s_remarks"] != null) dgv_01.Rows[i].Cells["s_remarks"].Value = getdt.Rows[i]["s_remarks"].ToString();
					if (getdt.Columns.Contains("s_uselocation") && getdt.Rows[i]["s_uselocation"] != null) dgv_01.Rows[i].Cells["s_uselocation"].Value = sl_uselocation[getdt.Rows[i]["s_uselocation"].ToString()].ToString();

                }
				if(dgv_01.Rows.Count>0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            }
			bt_ins.Enabled = true;
			bt_set.Enabled = false;
        }
        #endregion



        #region 器械包存储点按钮
        private void rb_base_CheckedChanged(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            SortedList sltmp02 = new SortedList();
            DataTable getdt = null;
            if (cb_customer.Text.Trim() == "----所有----")
            {
                sltmp.Add(1, 1);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec004", sltmp);
            }
            else
            {
                string customer = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();
                sltmp01.Add(1, Convert.ToInt32(customer));
                sltmp01.Add(2, 1);
                sltmp02.Add(1, sltmp01);
                string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec003", sltmp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec003", sltmp01);
            }

            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("s_type") && getdt.Columns.Contains("s_type") && getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type[getdt.Rows[i]["s_type"].ToString()].ToString();
					if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("s_barcode") && getdt.Rows[i]["s_barcode"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["s_barcode"].ToString();
					if (getdt.Columns.Contains("s_name") && getdt.Rows[i]["s_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["s_name"].ToString();
					if (getdt.Columns.Contains("s_customer") && getdt.Rows[i]["s_customer"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[getdt.Rows[i]["s_customer"].ToString()].ToString();
					if (getdt.Columns.Contains("s_room") && getdt.Rows[i]["s_room"] != null) dgv_01.Rows[i].Cells["s_room"].Value = getdt.Rows[i]["s_room"].ToString();
					if (getdt.Columns.Contains("s_basket") && getdt.Rows[i]["s_basket"] != null) dgv_01.Rows[i].Cells["s_basket"].Value = getdt.Rows[i]["s_basket"].ToString();
					if (getdt.Columns.Contains("s_costcenter") && getdt.Rows[i]["s_costcenter"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter[getdt.Rows[i]["s_costcenter"].ToString()].ToString();
					if (getdt.Columns.Contains("s_cabinet") && getdt.Rows[i]["s_cabinet"] != null) dgv_01.Rows[i].Cells["s_cabinet"].Value = getdt.Rows[i]["s_cabinet"].ToString();
					if (getdt.Columns.Contains("s_remarks") && getdt.Rows[i]["s_remarks"] != null) dgv_01.Rows[i].Cells["s_remarks"].Value = getdt.Rows[i]["s_remarks"].ToString();
					if (getdt.Columns.Contains("s_uselocation") && getdt.Rows[i]["s_uselocation"] != null) dgv_01.Rows[i].Cells["s_uselocation"].Value = sl_uselocation[getdt.Rows[i]["s_uselocation"].ToString()].ToString();

                }
				if (dgv_01.Rows.Count > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            }
			bt_ins.Enabled = false;
			bt_set.Enabled = true;
        }
        #endregion
        private void bt_ins_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList slttp = new SortedList();
                slttp.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slttp.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                slttp.Add("s_customer", sl_customer01.GetKey(sl_customer01.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value)).ToString());
                HCSCM_storage_items hcsm = new HCSCM_storage_items(slttp);
                hcsm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_set_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
                SortedList slttp = new SortedList();
                slttp.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                slttp.Add("s_customer", sl_customer01.GetKey(sl_customer01.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_customer"].Value)).ToString());
                slttp.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                HCSCM_storage_set hcsm = new HCSCM_storage_set(slttp);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一行数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

      

        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, "存储点");

        }

        private void but_print_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.SelectedRows.Count ==0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["s_barcode"].Value != null ?
					dgv_01.CurrentRow.Cells["s_barcode"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["s_name"].Value != null ?
					dgv_01.CurrentRow.Cells["s_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("P013", codeName);

					string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private DataRow[] arrayDR = null;
        private void but_sel_Click(object sender, EventArgs e)
        {
			GetData();
        }

        private void tb_sel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)//Enter键
            {
				GetData();
			}
        }

		private void GetData()
		{
			             dgv_01.Rows.Clear();
						 dgv_01.ClearSelection(); ;
                string strsecdata = tb_sel.Text.Trim().ToUpper();

                string str_usertp = sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString();

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string a = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec001", null);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
                if (getdt != null)
                {


                    #region 查询条件

					try
					{
						if (str_usertp == "0")//0代表所有客户
						{
							arrayDR = getdt.Select(" s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%'  ");

						}
						else
						{
							arrayDR = getdt.Select("s_customer=" + "'" + str_usertp + "'" + " and ( s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%')");

						}


						//"实体包存储点"按钮选中的查询
						if (rb_base.Checked == true)
						{

							if (str_usertp == "0")//0代表所有客户
							{
								arrayDR = getdt.Select("s_type=" + "'" + 1 + "'" + "and  (s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%' ) ");
							}
							else
							{
								arrayDR = getdt.Select("s_type=" + "'" + 1 + "'" + " and s_customer='" + str_usertp + "'" + "and ( s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%' ");//根据客户查询包
							}
						}

						//"器械存储点"按钮选中的查询
						if (rb_ins.Checked == true)
						{

							if (str_usertp == "0")//0代表所有客户
							{
								arrayDR = getdt.Select("s_type=" + "'" + 2 + "'" + "and  (s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%' ) ");
							}
							else
							{
								arrayDR = getdt.Select("s_type=" + "'" + 2 + "'" + " and s_customer='" + str_usertp + "'" + "and ( s_name like '%" + strsecdata + "%'or s_barcode like '%" + strsecdata + "%' ");//根据客户查询包
							}
						}
					}
					catch(Exception ex)
					{

					}

                    #endregion


                    int ii = arrayDR.Length;
                    if (ii <= 0) return;
                    dgv_01.RowCount = ii;
                    int i = 0;
                    foreach (DataRow dr in arrayDR)
                    {
						if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
						if (getdt.Columns.Contains("s_barcode") && getdt.Rows[i]["s_barcode"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = dr["s_barcode"].ToString();
						if (getdt.Columns.Contains("s_name") && getdt.Rows[i]["s_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = dr["s_name"].ToString();
						if (getdt.Columns.Contains("s_customer") && getdt.Rows[i]["s_customer"] != null) dgv_01.Rows[i].Cells["s_customer"].Value = sl_customer[dr["s_customer"].ToString()].ToString();
						if (getdt.Columns.Contains("s_type") && getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type[dr["s_type"].ToString()].ToString();
						if (getdt.Columns.Contains("s_costcenter") && getdt.Rows[i]["s_costcenter"] != null) dgv_01.Rows[i].Cells["s_costcenter"].Value = sl_costcenter[dr["s_costcenter"].ToString()].ToString();
						if (getdt.Columns.Contains("s_remarks") && getdt.Rows[i]["s_remarks"] != null) dgv_01.Rows[i].Cells["s_remarks"].Value = dr["s_remarks"].ToString();
						if (getdt.Columns.Contains("s_basket") && getdt.Rows[i]["s_basket"] != null) dgv_01.Rows[i].Cells["s_basket"].Value = dr["s_basket"].ToString();
						if (getdt.Columns.Contains("s_room") && getdt.Rows[i]["s_room"] != null) dgv_01.Rows[i].Cells["s_room"].Value = dr["s_room"].ToString();
						if (getdt.Columns.Contains("s_cabinet") && getdt.Rows[i]["s_cabinet"] != null) dgv_01.Rows[i].Cells["s_cabinet"].Value = dr["s_cabinet"].ToString();
						if (getdt.Columns.Contains("s_uselocation") && getdt.Rows[i]["s_uselocation"] != null) dgv_01.Rows[i].Cells["s_uselocation"].Value = sl_uselocation[dr["s_uselocation"].ToString()].ToString();
                        i++;
                    }
                }
			if(dgv_01.Rows.Count>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
				dgv_01_SelectionChanged(null, null);
			}
		}
        private void but_printlist_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='storage'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            rb_ins.Checked = false;
            rb_base.Checked = false;
            if (this.cb_customer.Text == "----所有----")
            {
                Loaddata(null);
            }
            else
            {
                Loaddata(sl_customer.GetKey(sl_customer.IndexOfValue(this.cb_customer.Text)).ToString());
            }
        }

        private void dgv_01_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null && dgv_01.SelectedRows[0].Cells["s_type"].Value != null &&
               sl_type.GetKey(sl_type.IndexOfValue(dgv_01.SelectedRows[0].Cells["s_type"].Value)).ToString() == "2")
            {
                bt_set.Enabled = false;
                bt_ins.Enabled = true;
            }
            else
            {
                bt_ins.Enabled = false;
                bt_set.Enabled = true;
            }
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}
