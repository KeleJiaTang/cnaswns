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
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_orderset_manager : UserControl
    {
        private DataRow[] arrayDR = null;//用于传输数据
        SortedList Sl_type_01 = new SortedList();//存储成本中心
        SortedList Sl_typeid_05 = new SortedList();//存储客户id
        SortedList Sl_type_02 = new SortedList();//存储清洗等级
        SortedList Sl_type_03 = new SortedList();//存储紧急度，优先级
        SortedList Sl_type_04 = new SortedList();//存储包的类型
        SortedList Sl_type_05 = new SortedList();//存储所属顾客
        private string strbarcodexml = "";// 条码打印BarCodeXML数据
		int selectedIndex;
        public HCSCM_orderset_manager()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            #region 按钮图片加载
            this.but_instrument.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "instrument", EnumImageType.PNG);
            this.but_dis_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "pictureView", EnumImageType.PNG);
            this.but_media.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Photo", EnumImageType.PNG);
            this.but_imput.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "photoImport", EnumImageType.PNG);
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_edit.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "edit", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_printlist.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion
            //设定按字体来缩放控件  
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //获取打印条码的 XML 数据信息
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='BCT'");
            strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_complexity'");//清洗难度等级
            foreach (DataRow dr in arrayDR)
            {
                Sl_type_02.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_priority_type'");//清洗难度等级
            foreach (DataRow dr in arrayDR)
            {
                Sl_type_03.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_type'");//包的类型
            foreach (DataRow dr in arrayDR)
            {
                Sl_type_04.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());

                    }
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {

                this.raddl_customer.Items.Add("----所有----");
                Sl_type_05.Add("0", "----所有----");
                int aa = getdt.Rows.Count;
                if (aa <= 0) return;
                for (int i = 0; i < aa; i++)
                {
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_05.Add(getdt.Rows[i]["bar_code"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        Sl_typeid_05.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["bar_code"].ToString().Trim());
                        raddl_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }

                raddl_customer.Text = "----所有----";

            }
            GetData();
            if (dgv_01.RowCount > 0)//初次加载，如果dgv_01有数据，则默认选中第一行
            {
                dgv_01.Rows[0].IsSelected = true;
            }
        }

        /// <summary>
        /// 显示基本包
        /// </summary>
        /// <param name="cu_barcode">值为null时查询所有，不为null时根据客户barcode查询</param>
        private void Loaddata(string cu_barcode)
        {

            dgv_01.Rows.Clear();
			dgv_01.ClearSelection();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            DataTable getdt = null;
            if (cu_barcode == null)
            {
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec010", sttemp01);
            }
            else
            {
                sttemp01.Add(2, cu_barcode);
                //string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec002", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec011", sttemp01);
            }


            if (getdt != null && getdt.Rows.Count > 0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Columns.Contains("customer_code") && getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = getdt.Rows[i]["customer_code"].ToString();//值是bar_code
                    if (getdt.Columns.Contains("ca_priority") && getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = Sl_type_03[getdt.Rows[i]["ca_priority"].ToString()].ToString();
                    if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Columns.Contains("ca_weight") && getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = getdt.Rows[i]["ca_weight"].ToString();
                    if (getdt.Columns.Contains("ca_size") && getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = getdt.Rows[i]["ca_size"].ToString();
                    if (getdt.Columns.Contains("handle_price") && getdt.Rows[i]["handle_price"] != null) dgv_01.Rows[i].Cells["handle_price"].Value = double.Parse(getdt.Rows[i]["handle_price"].ToString()).ToString("C");
                    if (getdt.Columns.Contains("washing_type") && getdt.Rows[i]["washing_type"] != null) dgv_01.Rows[i].Cells["washing_type"].Value = getdt.Rows[i]["washing_type"].ToString();
                    if (getdt.Columns.Contains("sterilizer_type") && getdt.Rows[i]["sterilizer_type"] != null) dgv_01.Rows[i].Cells["sterilizer_type"].Value = getdt.Rows[i]["sterilizer_type"].ToString();
                    if (getdt.Columns.Contains("ca_complexity") && getdt.Rows[i]["ca_complexity"] != null) dgv_01.Rows[i].Cells["ca_complexity"].Value = Sl_type_02[getdt.Rows[i]["ca_complexity"].ToString()].ToString();
                    if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    //ifgetdt.Columns.Contains("id") &&  (getdt.Rows[i]["user_barcode"] != null) dgv_01.Rows[i].Cells["user_code"].Value = getdt.Rows[i]["user_code"].ToString();
                    if (getdt.Columns.Contains("ca_material") && getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["ca_material"].Value = getdt.Rows[i]["ca_material"].ToString();
                    if (getdt.Columns.Contains("put_type") && getdt.Rows[i]["put_type"] != null) dgv_01.Rows[i].Cells["put_type"].Value = getdt.Rows[i]["put_type"].ToString();
                    if (getdt.Columns.Contains("ca_expiration") && getdt.Rows[i]["ca_expiration"] != null) dgv_01.Rows[i].Cells["ca_expiration"].Value = getdt.Rows[i]["ca_expiration"].ToString();
                    if (getdt.Columns.Contains("ca_times") && getdt.Rows[i]["ca_times"] != null) dgv_01.Rows[i].Cells["ca_times"].Value = getdt.Rows[i]["ca_times"].ToString();
                    if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Columns.Contains("cre_person") && getdt.Rows[i]["cre_person"] != null) dgv_01.Rows[i].Cells["cre_person"].Value = getdt.Rows[i]["cre_person"].ToString();
                    if (getdt.Columns.Contains("mod_person") && getdt.Rows[i]["mod_person"] != null) dgv_01.Rows[i].Cells["mod_person"].Value = getdt.Rows[i]["mod_person"].ToString();
                    if (getdt.Columns.Contains("ca_type") && getdt.Rows[i]["ca_type"] != null) dgv_01.Rows[i].Cells["ca_type"].Value = Sl_type_04[getdt.Rows[i]["ca_type"].ToString()].ToString();
                    if (getdt.Columns.Contains("ca_remarks") && getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                    if (getdt.Columns.Contains("classify") && getdt.Rows[i]["classify"] != null) dgv_01.Rows[i].Cells["classify"].Value = getdt.Rows[i]["classify"].ToString();
                    if (getdt.Columns.Contains("order_package") && getdt.Rows[i]["order_package"] != null) dgv_01.Rows[i].Cells["spec"].Value = getdt.Rows[i]["order_package"].ToString();
                    if (getdt.Columns.Contains("minimum_set") && getdt.Rows[i]["minimum_set"] != null) dgv_01.Rows[i].Cells["minimum_set"].Value = getdt.Rows[i]["minimum_set"].ToString();
                    if (getdt.Columns.Contains("rfid_retrospect") && getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = getdt.Rows[i]["rfid_retrospect"].ToString();

                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
            }

        }

        private void raddl_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radBut_new_Click(object sender, EventArgs e)
        {
            HCSCM_set_manager_new hcsm = new HCSCM_set_manager_new(null, "1");
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
            //if(hcsm.ifOrderSetSuccess)
            //{
            // but_instrument_Click(null,null);
            //}
           
        }

        private void radBut_edit_Click(object sender, EventArgs e)
        {
			
			
            SortedList slindata = new SortedList();
            try
            {
                if (dgv_01.SelectedRows.Count > 0)
                {
					selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                    slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                    slindata.Add("ca_name", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                    slindata.Add("bar_code", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                    slindata.Add("customer_code", dgv_01.SelectedRows[0].Cells["customer_code"].Value);//值是barcode
                    slindata.Add("ca_priority", Sl_type_03.GetKey(Sl_type_03.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_priority"].Value.ToString())));
                    slindata.Add("cost_center", dgv_01.SelectedRows[0].Cells["cost_center"].Value);
                    slindata.Add("ca_weight", dgv_01.SelectedRows[0].Cells["ca_weight"].Value);
                    slindata.Add("ca_size", dgv_01.SelectedRows[0].Cells["ca_size"].Value);
                    slindata.Add("handle_price", double.Parse(dgv_01.SelectedRows[0].Cells["handle_price"].Value.ToString().Substring(1)));
                    slindata.Add("washing_type", dgv_01.SelectedRows[0].Cells["washing_type"].Value);//值是清洗程序id
                    slindata.Add("sterilizer_type", dgv_01.SelectedRows[0].Cells["sterilizer_type"].Value);//值是灭菌程序id
                    slindata.Add("ca_complexity", dgv_01.SelectedRows[0].Cells["ca_complexity"].Value);
                    slindata.Add("ca_material", dgv_01.SelectedRows[0].Cells["ca_material"].Value);//值是包装材料id
                    slindata.Add("put_type", dgv_01.SelectedRows[0].Cells["put_type"].Value);//值是摆放类型value_code字段
                    slindata.Add("ca_expiration", dgv_01.SelectedRows[0].Cells["ca_expiration"].Value);
                    slindata.Add("ca_times", dgv_01.SelectedRows[0].Cells["ca_times"].Value);
                    slindata.Add("ca_type", dgv_01.SelectedRows[0].Cells["ca_type"].Value);
                    slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);
                    slindata.Add("classify", dgv_01.SelectedRows[0].Cells["classify"].Value);
                    slindata.Add("spec", dgv_01.SelectedRows[0].Cells["spec"].Value);
                    slindata.Add("minimum_set", dgv_01.SelectedRows[0].Cells["minimum_set"].Value);
                    slindata.Add("rfid_retrospect", dgv_01.SelectedRows[0].Cells["rfid_retrospect"].Value);
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "修改", "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            HCSCM_set_manager_new hcsm = new HCSCM_set_manager_new(slindata, "1");
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            GetData();
            if (dgv_01.Rows.Count > selectedIndex)
            {
                dgv_01.CurrentRow = dgv_01.Rows[selectedIndex];
            }
        }

        private void radBut_remove_Click(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //SortedList sttemp01 = new SortedList();
            //sttemp01.Add(1, CnasBaseData.SystemID);
            #region 判断基本包是否被实体包占用

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-order-package-sec001", null);//137
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["instrument_code"].ToString().Trim() != null)
                        if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == getdt.Rows[i]["instrument_code"].ToString().Trim())
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("relation2", EnumPromptMessage.warning, new string[] { "订单包","" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
            }


            #endregion

            if (dgv_01.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "订单包" }), "删除订单包", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp01.Add(2, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                // string a = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-base-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //  GetData();
                }
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_01.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //获得当前选择行数据
                string barCode = dgv_01.CurrentRow.Cells["bar_code"].Value != null ?
                    dgv_01.CurrentRow.Cells["bar_code"].Value.ToString() : string.Empty;
                string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
                    dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

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

        private void radBut_sel_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void radTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                GetData();
            }
        }

        private void GetData()
        {
            dgv_01.Rows.Clear();
            string strsecdata = radText_name.Text.Trim().ToUpper();

            string str_usertp = Sl_type_05.GetKey(Sl_type_05.IndexOfValue(this.raddl_customer.Text)).ToString();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //    string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec010", sttemp01);
            if (getdt == null) return;
            string selectSql = string.Format("(bar_code like '%{0}%' or ca_name like '%{0}%' or ca_name_cc like '%{0}%')", strsecdata);
            if (str_usertp != "0")
                selectSql += string.Format(" and customer_code='{0}'", str_usertp);

            arrayDR = getdt.Select(selectSql).OrderBy(item => item["id"]).ToArray();


            //try
            //{
            //    if (str_usertp == "0")//查询所有客户的基本包
            //    {
            //        arrayDR = getdt.Select(" bar_code like '%" + strsecdata + "%' or ca_name like '%" + strsecdata + "%' or ca_name_cc like '%" + strsecdata + "%'");
            //    }
            //    else
            //    {
            //        arrayDR = getdt.Select("customer_code=" + "'" + str_usertp + "'" + " and ( bar_code like '%" + strsecdata + "%' or ca_name like '%" + strsecdata + "%' or ca_name_cc like '%" + strsecdata + "%')");//根据客户查询包
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("输入的信息有误，请重新输入。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            int ii = arrayDR.Length;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            int i = 0;
            foreach (DataRow dr in arrayDR)
            {
                if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
                if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();
                if (getdt.Columns.Contains("customer_code") && getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = dr["customer_code"].ToString();//值是bar_code
                if (getdt.Columns.Contains("ca_priority") && getdt.Rows[i]["ca_priority"] != null) dgv_01.Rows[i].Cells["ca_priority"].Value = Sl_type_03[dr["ca_priority"].ToString()].ToString();
                if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[dr["cost_center"].ToString()].ToString();
                if (getdt.Columns.Contains("ca_weight") && getdt.Rows[i]["ca_weight"] != null) dgv_01.Rows[i].Cells["ca_weight"].Value = dr["ca_weight"].ToString();
                if (getdt.Columns.Contains("ca_size") && getdt.Rows[i]["ca_size"] != null) dgv_01.Rows[i].Cells["ca_size"].Value = dr["ca_size"].ToString();
                if (getdt.Columns.Contains("handle_price") && getdt.Rows[i]["handle_price"] != null) dgv_01.Rows[i].Cells["handle_price"].Value = double.Parse(dr["handle_price"].ToString()).ToString("C");
                if (getdt.Columns.Contains("washing_type") && getdt.Rows[i]["washing_type"] != null) dgv_01.Rows[i].Cells["washing_type"].Value = dr["washing_type"].ToString();
                if (getdt.Columns.Contains("sterilizer_type") && getdt.Rows[i]["sterilizer_type"] != null) dgv_01.Rows[i].Cells["sterilizer_type"].Value = dr["sterilizer_type"].ToString();
                if (getdt.Columns.Contains("ca_complexity") && getdt.Rows[i]["ca_complexity"] != null) dgv_01.Rows[i].Cells["ca_complexity"].Value = Sl_type_02[dr["ca_complexity"].ToString()].ToString();
                if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = dr["bar_code"].ToString();
                //  getdt.Columns.Contains("id") &&         if (getdt.Rows[i]["user_barcode"] != null) dgv_01.Rows[i].Cells["user_code"].Value = dr["user_barcode"].ToString();
                if (getdt.Columns.Contains("ca_material") && getdt.Rows[i]["ca_material"] != null) dgv_01.Rows[i].Cells["ca_material"].Value = dr["ca_material"].ToString();
                if (getdt.Columns.Contains("put_type") && getdt.Rows[i]["put_type"] != null) dgv_01.Rows[i].Cells["put_type"].Value = dr["put_type"].ToString();
                if (getdt.Columns.Contains("ca_expiration") && getdt.Rows[i]["ca_expiration"] != null) dgv_01.Rows[i].Cells["ca_expiration"].Value = dr["ca_expiration"].ToString();
                if (getdt.Columns.Contains("ca_times") && getdt.Rows[i]["ca_times"] != null) dgv_01.Rows[i].Cells["ca_times"].Value = dr["ca_times"].ToString();
                if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dr["cre_date"].ToString();
                if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = dr["mod_date"].ToString();
                if (getdt.Columns.Contains("cre_person") && getdt.Rows[i]["cre_person"] != null) dgv_01.Rows[i].Cells["cre_person"].Value = dr["cre_person"].ToString();
                if (getdt.Columns.Contains("mod_person") && getdt.Rows[i]["mod_person"] != null) dgv_01.Rows[i].Cells["mod_person"].Value = dr["mod_person"].ToString();
                if (getdt.Columns.Contains("ca_type") && getdt.Rows[i]["ca_type"] != null) dgv_01.Rows[i].Cells["ca_type"].Value = Sl_type_04[dr["ca_type"].ToString()].ToString();
                if (getdt.Columns.Contains("ca_remarks") && getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = dr["ca_remarks"].ToString();
                if (getdt.Columns.Contains("classify") && getdt.Rows[i]["classify"] != null) dgv_01.Rows[i].Cells["classify"].Value = dr["classify"].ToString();
                if (getdt.Columns.Contains("minimum_set") && getdt.Rows[i]["minimum_set"] != null) dgv_01.Rows[i].Cells["minimum_set"].Value = dr["minimum_set"].ToString();
                if (getdt.Columns.Contains("rfid_retrospect") && getdt.Rows[i]["rfid_retrospect"] != null) dgv_01.Rows[i].Cells["rfid_retrospect"].Value = dr["rfid_retrospect"].ToString();
                i++;
            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        private void radButton1_Click_1(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='costcenter'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }

        private void raddl_customer_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            radBut_edit_Click(null, null);
        }

        private void raddl_customer_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void but_instrument_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count > 0)
            {
				try
				{
					int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
					SortedList aa = new SortedList();
					aa.Add("name", dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString());
					aa.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
					aa.Add("type", Sl_type_04.GetKey(Sl_type_04.IndexOfValue(dgv_01.SelectedRows[0].Cells["ca_type"].Value.ToString())).ToString());
					aa.Add("customer", dgv_01.SelectedRows[0].Cells["customer_code"].Value.ToString());
					aa.Add("customerid", Sl_typeid_05.GetKey(Sl_typeid_05.IndexOfValue(dgv_01.SelectedRows[0].Cells["customer_code"].Value.ToString())));
					aa.Add("costcentername", Sl_type_01.GetKey(Sl_type_01.IndexOfValue(dgv_01.SelectedRows[0].Cells["cost_center"].Value.ToString())));
					aa.Add("costcenter", dgv_01.SelectedRows[0].Cells["cost_center"].Value.ToString());
					bool iswindows = false;
					HCSCM_specialset_item_add HCSR = new HCSCM_specialset_item_add(aa, iswindows);
					HCSR.ShowDialog();
				}
				catch(Exception ex)
				{ }
            }
        }

        private void but_media_Click(object sender, EventArgs e)
        {
            try
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：包
                sortedList.Add("type", "1");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", this.dgv_01.SelectedRows[0].Cells["bar_code"].Value);

                HCSCM_set_image HCSCM_pack_image = new HCSCM_set_image(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_pack_image.ShowInTaskbar = false;
                HCSCM_pack_image.ShowDialog();
            }
            catch
            {
                MessageBox.Show("请选择一行。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void but_dis_media_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "查看", "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SortedList sortedList = new SortedList();

                //设置一个类型，表明这次上传图片的类型是：包
                sortedList.Add("type", "1");
                //包ID
                sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
                //包的条码
                sortedList.Add("pack_barcode", this.dgv_01.SelectedRows[0].Cells["bar_code"].Value);

                HCSCM_set_manage_image HCSCM_set_manage_image = new HCSCM_set_manage_image(sortedList);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                HCSCM_set_manage_image.ShowInTaskbar = false;
                HCSCM_set_manage_image.ShowDialog();

            }
            catch
            {
                MessageBox.Show("数据异常，请检测。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void but_imput_Click(object sender, EventArgs e)
        {




            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "导入照片", "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SortedList sortedList = new SortedList();

            //设置一个类型，表明这次上传图片的类型是：包
            sortedList.Add("type", "1");
            //包ID
            sortedList.Add("pack_id", this.dgv_01.SelectedRows[0].Cells["id"].Value);
            //包的条码
            sortedList.Add("pack_barcode", this.dgv_01.SelectedRows[0].Cells["bar_code"].Value);

            HCSCM_set_image_batch HCSCM_set_image_batch = new HCSCM_set_image_batch(sortedList);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            HCSCM_set_image_batch.ShowInTaskbar = false;
            HCSCM_set_image_batch.ShowDialog();
        }

        private void radlb_customer_Click(object sender, EventArgs e)
        {

        }

        private void radText_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void radlb_sel_Click(object sender, EventArgs e)
        {

        }
    }
}
