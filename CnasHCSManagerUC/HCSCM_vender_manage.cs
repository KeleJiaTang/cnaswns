using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_vender_manage : UserControl
    {

        SortedList sl_type01 = new SortedList();
        DataTable getdt02 = new DataTable();
        public HCSCM_vender_manage()
        {
            InitializeComponent();
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_vender_type'");
            this.cb_type.Items.Add("----所有----");

            //this.rad_cb_type.Items.Add("----所有----");


            foreach (DataRow dr in arrayDR)
            {


                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());


                //this.rad_cb_type.Items.Add(dr["key_code"].ToString().Trim() + "：" + dr["value_code"].ToString().Trim());


                //根据编号找厂商
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());



            }

            cb_type.Text = "----所有----";

            ////默认选中第一项
            //this.rad_cb_type.SelectedIndex = 0;dgv_01.
            Loaddata(null);
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }

        }
        DataTable getdt = new DataTable();
        /// <summary>
        /// 刷新datagridview界面
        /// </summary>
        /// <param name="strnum">传入厂商类型1，2，3</param>
        private void Loaddata(string strnum)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strnum);
            if (cb_type.Text == "----所有----")
            {
                string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-vender-sec002", null);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
            }
            else
            {
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec001", sttemp01);
            }

            if (getdt != null && getdt.Rows.Count>0)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                //dgv_01.RowCount = ii;
                dgv_01.Rows.Clear();

                dgv_01.RowCount = ii;

                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("v_name") && !string.IsNullOrEmpty(getdt.Rows[i]["v_name"].ToString())) dgv_01.Rows[i].Cells["v_name"].Value = getdt.Rows[i]["v_name"].ToString();
					if (getdt.Columns.Contains("v_address") && !string.IsNullOrEmpty(getdt.Rows[i]["v_address"].ToString())) dgv_01.Rows[i].Cells["v_address"].Value = getdt.Rows[i]["v_address"].ToString();
					if (getdt.Columns.Contains("v_telephone") && !string.IsNullOrEmpty(getdt.Rows[i]["v_telephone"].ToString())) dgv_01.Rows[i].Cells["v_telephone"].Value = getdt.Rows[i]["v_telephone"].ToString();
					if (getdt.Columns.Contains("v_postcode") && !string.IsNullOrEmpty(getdt.Rows[i]["v_postcode"].ToString())) dgv_01.Rows[i].Cells["v_postcode"].Value = getdt.Rows[i]["v_postcode"].ToString();
					if (getdt.Columns.Contains("v_email") && !string.IsNullOrEmpty(getdt.Rows[i]["v_email"].ToString())) dgv_01.Rows[i].Cells["v_email"].Value = getdt.Rows[i]["v_email"].ToString();
					if (getdt.Columns.Contains("v_website") && !string.IsNullOrEmpty(getdt.Rows[i]["v_website"].ToString())) dgv_01.Rows[i].Cells["v_website"].Value = getdt.Rows[i]["v_website"].ToString();
					if (getdt.Columns.Contains("vender_type") && !string.IsNullOrEmpty(getdt.Rows[i]["vender_type"].ToString())) dgv_01.Rows[i].Cells["vender_type"].Value = sl_type01[getdt.Rows[i]["vender_type"].ToString()].ToString();
                    // if (getdt.Rows[i]["sales_ID"] != null) rad_dgv_01.Rows[i].Cells["sales_id"].Value = sl_type01[getdt.Rows[i]["sales_id"].ToString()].ToString();
					if (getdt.Columns.Contains("contact_name") && !string.IsNullOrEmpty(getdt.Rows[i]["contact_name"].ToString())) dgv_01.Rows[i].Cells["contact_name"].Value = getdt.Rows[i]["contact_name"].ToString();
					if (getdt.Columns.Contains("is_outinstrument") && !string.IsNullOrEmpty(getdt.Rows[i]["is_outinstrument"].ToString())) dgv_01.Rows[i].Cells["insVender"].Value = getdt.Rows[i]["is_outinstrument"].ToString()=="1"?"是":"否";

                }
				if (dgv_01.Rows.Count > 0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            }
        }

        private void dgv_01_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void but_new_Click(object sender, EventArgs e)
        {



            HCSCM_vender_manage_new hcsm = new HCSCM_vender_manage_new(null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (hcsm.type02 != "")//判断是否选择厂商类型
            {
				int inrec = sl_type01.IndexOfKey(hcsm.type02);//这个key位置的索引
				this.cb_type.Text = sl_type01.GetKey(inrec) + "：" + sl_type01.GetByIndex(inrec);
                Loaddata(hcsm.type02);
              
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
                }
            }

        }

      

        private void but_edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList slindata = new SortedList();
            try
            {
				slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["id"].Value);
				slindata.Add("v_name", dgv_01.SelectedRows[0].Cells["v_name"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_name"].Value);
				slindata.Add("contact_name", dgv_01.SelectedRows[0].Cells["contact_name"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["contact_name"].Value);
                slindata.Add("vender_type", sl_type01.GetKey(sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["vender_type"].Value)));
				slindata.Add("v_address", dgv_01.SelectedRows[0].Cells["v_address"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_address"].Value);
				slindata.Add("v_telephone", dgv_01.SelectedRows[0].Cells["v_telephone"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_telephone"].Value);
				slindata.Add("v_postcode", dgv_01.SelectedRows[0].Cells["v_postcode"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_postcode"].Value);
				slindata.Add("v_email", dgv_01.SelectedRows[0].Cells["v_email"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_email"].Value);
				slindata.Add("v_website", dgv_01.SelectedRows[0].Cells["v_website"].Value == null ? string.Empty : dgv_01.SelectedRows[0].Cells["v_website"].Value);
				slindata.Add("insvender", dgv_01.SelectedRows[0].Cells["insVender"].Value.ToString() == "否" ? 0 : 1);
                HCSCM_vender_manage_new hcsm = new HCSCM_vender_manage_new(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
				if (tb_suchen.Text == string.Empty)
				{
					if (hcsm.type02 != "")
					{
						int inrec = sl_type01.IndexOfKey(hcsm.type02);
						this.cb_type.Text = sl_type01.GetKey(inrec) + "：" + sl_type01.GetByIndex(inrec);
						Loaddata(hcsm.type02);
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
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }





        private void but_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string remove = "";
            try
            {

                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                #region 判断生产商ID是否被清洗机占用

                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-washing-device-sec001", sttemp01);//79
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = "供应商已被清洗机";
                                break;
                                //MessageBox.Show("生厂商已被清洗机定义，如要删除，请先解除清洗机");
                                //return;
                            }
                        }
                    }
                }

                #endregion
                #region 判断生厂商ID是否被灭菌器占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("hcs-sterilizer-device-sec001", sttemp01);//80


                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",灭菌器";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }
                #endregion
                #region 判断生产占用商ID是否被运输工具占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-transport-device-sec001", sttemp01);//81

                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vendor"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vendor"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",运输工具";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }

                #endregion
                #region 判断生产商ID是否被塑封机占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-plasticenvelop-device-sec001", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",塑封机";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }
                #endregion
                #region 判断生产商ID是否被手术器械类型占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",手术器械类型";
                                MessageBox.Show(remove, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                if (remove != "")
                {
                    MessageBox.Show(remove + "占用，如要删除，请先解除与以上的关联。");
                    return;
                }
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["v_name"].Value.ToString(), "供应商" }), "删除厂商", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-vender-del001", sltmp, null);
                int recint = reCnasRemotCall_01.RemotInterface.UPData(1, "HCS-vender-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int inrec = sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["vender_type"].Value);
                    string strvalue = sl_type01.GetKey(inrec).ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void cs_select_UserRadioButtonSelect(object sender, EventArgs e, string infodata)
        {
            MessageBox.Show(infodata);
        }



        private void tb_suchen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
					GetData();
                }
                catch
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            try
            {
				GetData();
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
		private void GetData()
		{
			dgv_01.Rows.Clear();
			string strsecdata = tb_suchen.Text.Trim();
			DataRow[] arrayDR = null;
			string str_usertp = cb_type.Text.Substring(0, 1);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();

			            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-vender-sec002", null);
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec002", null);
			if (getdt == null) return;
			if (cb_type.Text == "----所有----")
			{
				arrayDR = getdt.Select("v_name like '%" + strsecdata + "%' ");
			}
			else
			{
				arrayDR = getdt.Select("vender_type=" + str_usertp + " and ( v_name like '%" + strsecdata + "%' )");
			}
			int ii = arrayDR.Length;
			if (ii <= 0) return;
			dgv_01.RowCount = ii;
			int i = 0;
			foreach (DataRow dr in arrayDR)
			{
				if (getdt.Columns.Contains("id") && !string.IsNullOrEmpty(getdt.Rows[i]["id"].ToString())) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
				if (getdt.Columns.Contains("v_name") && !string.IsNullOrEmpty(getdt.Rows[i]["v_name"].ToString())) dgv_01.Rows[i].Cells["v_name"].Value = dr["v_name"].ToString();
				if (getdt.Columns.Contains("v_address") && !string.IsNullOrEmpty(getdt.Rows[i]["v_address"].ToString())) dgv_01.Rows[i].Cells["v_address"].Value = dr["v_address"].ToString();
				if (getdt.Columns.Contains("v_telephone") && !string.IsNullOrEmpty(getdt.Rows[i]["v_telephone"].ToString())) dgv_01.Rows[i].Cells["v_telephone"].Value = dr["v_telephone"].ToString();
				if (getdt.Columns.Contains("v_postcode") && !string.IsNullOrEmpty(getdt.Rows[i]["v_postcode"].ToString())) dgv_01.Rows[i].Cells["v_postcode"].Value = dr["v_postcode"].ToString();
				if (getdt.Columns.Contains("v_email") && !string.IsNullOrEmpty(getdt.Rows[i]["v_email"].ToString())) dgv_01.Rows[i].Cells["v_email"].Value = dr["v_email"].ToString();
				if (getdt.Columns.Contains("v_website") && !string.IsNullOrEmpty(getdt.Rows[i]["v_website"].ToString())) dgv_01.Rows[i].Cells["v_website"].Value = dr["v_website"].ToString();
				if (getdt.Columns.Contains("vender_type") &&!string.IsNullOrEmpty( getdt.Rows[i]["vender_type"].ToString())) dgv_01.Rows[i].Cells["vender_type"].Value = sl_type01[dr["vender_type"].ToString()].ToString();
				if (getdt.Columns.Contains("contact_name") && !string.IsNullOrEmpty(getdt.Rows[i]["contact_name"].ToString())) dgv_01.Rows[i].Cells["contact_name"].Value = dr["contact_name"].ToString();
				i++;
			}
			if(dgv_01.Rows.Count>0)
			{
				dgv_01.CurrentRow = dgv_01.Rows[0];
			}
		}


        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_printlist_Click(object sender, EventArgs e)
        {


            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='vender'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();




            //PrintHelper.Instance.Print_DataGridView(this.rad_dgv_01, pringxml);

            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;

        }





        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_new_Click(object sender, EventArgs e)
        {

            HCSCM_vender_manage_new hcsm = new HCSCM_vender_manage_new(null);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            if (hcsm.type02 != "")//判断是否选择厂商类型
            {
                Loaddata(hcsm.type02);
                int inrec = sl_type01.IndexOfKey(hcsm.type02);//这个key位置的索引
                this.cb_type.Text = sl_type01.GetKey(inrec) + "：" + sl_type01.GetByIndex(inrec);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_edit_Click(object sender, EventArgs e)
        {


            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("v_name", dgv_01.SelectedRows[0].Cells["v_name"].Value);
                slindata.Add("contact_name", dgv_01.SelectedRows[0].Cells["contact_name"].Value);
                slindata.Add("vender_type", sl_type01.GetKey(sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["vender_type"].Value)));
                slindata.Add("v_address", dgv_01.SelectedRows[0].Cells["v_address"].Value);
                slindata.Add("v_telephone", dgv_01.SelectedRows[0].Cells["v_telephone"].Value);
                slindata.Add("v_postcode", dgv_01.SelectedRows[0].Cells["v_postcode"].Value);
                slindata.Add("v_email", dgv_01.SelectedRows[0].Cells["v_email"].Value);
                slindata.Add("v_website", dgv_01.SelectedRows[0].Cells["v_website"].Value);
                HCSCM_vender_manage_new hcsm = new HCSCM_vender_manage_new(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                if (hcsm.type02 != "")
                {
                    Loaddata(hcsm.type02);
                    int inrec = sl_type01.IndexOfKey(hcsm.type02);
                    this.cb_type.Text = sl_type01.GetKey(inrec) + "：" + sl_type01.GetByIndex(inrec);
                    //this.cb_type.Text = sl_type01[hcsm.type02].ToString();
                }

            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_delete_Click(object sender, EventArgs e)
        {
            string remove = "";
            try
            {
                CnasRemotCall reCnasRemotCall_01 = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                #region 判断生产商ID是否被清洗机占用

                DataTable getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-washing-device-sec001", sttemp01);//79
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = "供应商已被清洗机";
                                break;
                                //MessageBox.Show("生厂商已被清洗机定义，如要删除，请先解除清洗机");
                                //return;
                            }
                        }
                    }
                }

                #endregion
                #region 判断生厂商ID是否被灭菌器占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("hcs-sterilizer-device-sec001", sttemp01);//80


                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",灭菌器";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }
                #endregion
                #region 判断生产占用商ID是否被运输工具占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-transport-device-sec001", sttemp01);//81

                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vendor"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vendor"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",运输工具";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }

                #endregion
                #region 判断生产商ID是否被塑封机占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-plasticenvelop-device-sec001", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {

                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",塑封机";
                                break;
                                //MessageBox.Show("生厂商已被灭菌器定义，如要删除，请先解除灭菌器");
                                //return;
                            }
                        }
                    }
                }
                #endregion
                #region 判断生产商ID是否被手术器械类型占用
                getdt = reCnasRemotCall_01.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["ca_vender"].ToString().Trim() != null)
                        {
                            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["ca_vender"].ToString().Trim() ||
                                dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["sales_id"].ToString().Trim())
                            {
                                remove = remove + ",手术器械类型等占用，如要删除，请先解除以上说到的关系。";
                                MessageBox.Show(remove, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion

                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["v_name"].Value.ToString(), "供应商" }), "删除厂商", MessageBoxButtons.YesNo) == DialogResult.No) return;
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);

                //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-vender-del001", sltmp, null);
                int recint = reCnasRemotCall_01.RemotInterface.UPData(1, "HCS-vender-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int inrec = sl_type01.IndexOfValue(dgv_01.SelectedRows[0].Cells["vender_type"].Value);
                    string strvalue = sl_type01.GetKey(inrec).ToString();
                    Loaddata(strvalue);
                }
            }
            catch
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "供应商" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rad_cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string strnum = cb_type.SelectedItem.ToString().Substring(0, 1);
            Loaddata(strnum);
        }

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_edit_Click(null, null);
		}
    }
}
