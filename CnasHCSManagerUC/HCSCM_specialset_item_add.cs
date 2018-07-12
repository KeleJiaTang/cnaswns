using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using CnasUI;
using System.Configuration;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_specialset_item_add : TemplateForm
    {
        public SortedList ssid = new SortedList();
        public SortedList sl_type = new SortedList();
        public bool isselect;
        public HCSCM_specialset_item_add(SortedList slttmp, bool iswindows)
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            //radButton2.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cleantemplat", EnumImageType.PNG);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--添加器械";
            //this.Font = new Font(this.Font.FontFamily, 11);
            tb_setname.Text = slttmp["name"].ToString();
            ssid = slttmp;
            isselect = iswindows;
            //包的类型
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-order-template-type'");
            foreach (DataRow dr in arrayDR)
            {

                if (int.Parse(dr["key_code"].ToString()) < 3)
                {

                    sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                    cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
                }
            }
            cb_type.Text = "1:器械";
            if (isselect == false)
            {
                cb_type.Enabled = false;
            }
            else
            {
                cb_type.Enabled = true;
            }
            loaddate();//加载DGV_01
            loaddate02();//加载DGV_02

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void loaddate()
        {
            try
            {
                SortedList sl_costcenterbar = new SortedList();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList costcenterid = new SortedList();
                costcenterid.Add(1, ssid["customerid"].ToString());
                DataTable Costcenterid = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec0015", costcenterid);
                if (Costcenterid != null)
                {
                    int ii = Costcenterid.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (Costcenterid.Rows[i]["bar_code"].ToString() != null && Costcenterid.Rows[i]["ca_name"].ToString().Trim() != null)
                        {
                            sl_costcenterbar.Add(Costcenterid.Rows[i]["bar_code"].ToString().Trim(), Costcenterid.Rows[i]["ca_name"].ToString().Trim());
                        }
                    }
                }
                dgv_01.Rows.Clear();
                DataTable getdt = null;
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, CnasBaseData.SystemID);
                sttemp01.Add(2, ssid["customer"].ToString());
                //sttemp01.Add(3, sl_costcenterbar.GetKey(sl_costcenterbar.IndexOfValue(ssid["costcenter"].ToString())));
                if (cb_type.Text.ToString().Substring(0, 1) == "1")
                {
                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec0010", sttemp01);
                }
                else
                {
                    string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec015", sttemp01);
                    getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec015", sttemp01);
                }


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
                    if (dgv_01.Rows.Count > 0)
                    {
                        dgv_01.CurrentRow = dgv_01.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void loaddate02()
        {
            try
            {
                DataTable ssitem = null;
                dgv_02.Rows.Clear();
                CnasRemotCall reCnasRemotCall01 = new CnasRemotCall();
                SortedList slttp = new SortedList();
                slttp.Add(1, ssid["id"]);
                if (isselect == true)
                {
                    ssitem = reCnasRemotCall01.RemotInterface.SelectData("HCS-specialset-item-sec002", slttp);
                }
                else if (isselect == false)
                {
                    string ss = reCnasRemotCall01.RemotInterface.CheckSelectData("HCS-set-instrument-sec003", slttp);
                    ssitem = reCnasRemotCall01.RemotInterface.SelectData("HCS-set-instrument-sec003", slttp);
                }
                if (ssitem != null)
                {

                    int ii = ssitem.Rows.Count;
                    if (ii <= 0) return;
                    dgv_02.RowCount = ii;
                    for (int i = 0; i < ii; i++)
                    {
                        if (ssitem.Columns.Contains("instrument_name") && ssitem.Rows[i]["instrument_name"] != null) dgv_02.Rows[i].Cells["ca_name"].Value = ssitem.Rows[i]["instrument_name"].ToString();
                        if (ssitem.Columns.Contains("num") && ssitem.Rows[i]["num"] != null) dgv_02.Rows[i].Cells["num"].Value = ssitem.Rows[i]["num"].ToString();
                        if (ssitem.Columns.Contains("instrument_id") && ssitem.Rows[i]["instrument_id"] != null) dgv_02.Rows[i].Cells["id"].Value = ssitem.Rows[i]["instrument_id"].ToString();
                        if (isselect == true)
                        {
                            if (ssitem.Columns.Contains("type") && ssitem.Rows[i]["type"] != null)
                            {
                                dgv_02.Rows[i].Cells["type"].Value = sl_type[ssitem.Rows[i]["type"].ToString()];
                                dgv_02.Rows[i].Cells["typeID"].Value = ssitem.Rows[i]["type"];
                            }
                        }
                        else
                        {
                            dgv_02.Rows[i].Cells["type"].Value = "器械";
                            dgv_02.Rows[i].Cells["typeID"].Value = "1";
                        }

                    }
                    if (dgv_02.Rows.Count > 0)
                    {
                        dgv_02.CurrentRow = dgv_02.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }
            //tb_insname.DataBindings.Add("Text", dgv_01.SelectedCells, "Value");
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            #region 向右移
            IList<GridViewRowInfo> sourceCollection = null;
            sourceCollection = dgv_01.SelectedRows;
            if (sourceCollection != null)
            {
                int count = sourceCollection.Count;
                for (int i = 0; i < count; i++)
                {
                    bool ifNewRows = true;
                    GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                    for (int k = 0; k < dgv_02.RowCount; k++)
                    {
                        try
                        {
                            int.Parse(dgv_02.Rows[k].Cells["num"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.Rows[i].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (row.Cells["id"].Value.ToString() == dgv_02.Rows[k].Cells["id"].Value.ToString() && cb_type.Text.Substring(0, 1) == dgv_02.Rows[k].Cells["typeID"].Value.ToString())
                        {
                            dgv_02.Rows[k].Cells["num"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["num"].Value.ToString());
                            ifNewRows = false;
                        }
                    }
                    if (ifNewRows)
                    {
                        GridViewRowInfo newRow = dgv_02.Rows.AddNew();
                        newRow.Cells[0].Value = row.Cells[0].Value;
                        newRow.Cells[1].Value = row.Cells[1].Value;
                        newRow.Cells[2].Value = tb_number.Text;
                        string str = cb_type.Text;
                        string[] s = str.Split(new char[] { ':' });
                        newRow.Cells[3].Value = s[1];
                        newRow.Cells[4].Value = s[0];
                    }
                }
            }
            #endregion

            #region 旧代码
            //    if (tb_insname.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (tb_num.Text == string.Empty||tb_num.Text=="0")
            //{
            //    MessageBox.Show("请填写移动的数量", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (tb_insname.Text != "")
            //{
            //    int num = 0;//计算器械名字出现相同次数！

            //    if (dgv_02.Rows.Count == 0)//这类基本包第一次添加第一把器械
            //    {
            //        string str_id = "", str_app_name = "", str_type = "";
            //        if (dgv_01.SelectedRows[0].Cells["id"] != null) str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        if (dgv_01.SelectedRows[0].Cells["ca_name"] != null) str_app_name = tb_insname.Text;
            //        if (cb_type.Text != null) str_type = cb_type.Text.Substring(2);
            //        DataGridViewRow drtemp01 = new DataGridViewRow();
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//number
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//类型

            //        drtemp01.SetValues(str_id, "0", str_app_name, str_type);
            //        dgv_02.Rows.Add(drtemp01);
            //        //  dgv_02.RowCount++;
            //        dgv_02.Rows[0].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        dgv_02.Rows[0].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //        dgv_02.Rows[0].Cells["num"].Value = tb_num.Text;
            //        dgv_02.Rows[0].Cells["type"].Value = cb_type.Text.Substring(2);

            //        // dgv_02.Rows[0].Selected = true;
            //    }
            //    else
            //    {
            //        if (tb_num.Text == string.Empty)
            //        {
            //            MessageBox.Show("请填写移动的数量", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        for (int i = 0; i < dgv_02.Rows.Count; i++)
            //        {
            //            try
            //            {
            //                dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //            }
            //            catch
            //            {
            //                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dgv_02.Rows[i].Cells["id02"].Value.ToString())//全部不同才添加
            //            {
            //                dgv_02.Rows[i].Cells["num"].Value = int.Parse(dgv_02.Rows[i].Cells["num"].Value.ToString()) + int.Parse(tb_num.Text);
            //                dgv_02.Rows[0].Selected = false;
            //                dgv_02.Rows[i].Selected = true;
            //                num--;
            //            }
            //            num++;

            //            if (num == dgv_02.Rows.Count)//
            //            {
            //                string str_id = "", str_app_name = "";
            //                if (dgv_01.SelectedRows[0].Cells["id"].Value != null) str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //                if (dgv_01.SelectedRows[0].Cells["ca_name"].Value != null) str_app_name = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //                DataGridViewRow drtemp01 = new DataGridViewRow();

            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//number
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //                drtemp01.SetValues(str_id, str_app_name, tb_num.Text, cb_type.Text.Substring(2));
            //                dgv_02.Rows.Add(drtemp01);
            //                dgv_02.Rows[i + 1].Selected = true;
            //                //dgv_02.RowCount++;
            //                //dgv_02.Rows[i].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["number"].Value = "1";

            //                return;
            //            }
            //        }


            //    }
            //}
            #endregion



        }
        /// <summary>
        /// 移动器械"+1"
        /// </summary>

        private void but_reone_Click(object sender, EventArgs e)
        {

            #region 向左移
            dynamic sourceCollection = (from item in dgv_02.SelectedRows select item).ToList();
            if (sourceCollection != null)
            {
                int count = sourceCollection.Count;
                for (int i = 0; i < count; i++)
                {
                    GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                    try
                    {
                        int.Parse(row.Cells["num"].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { "选中移动项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    row.Cells["num"].Value = int.Parse(row.Cells["num"].Value.ToString()) - int.Parse(tb_number.Text);
                    if (int.Parse(row.Cells["num"].Value.ToString()) <= 0)
                    {
                        int index = dgv_02.Rows.IndexOf(row);
                        dgv_02.Rows.Remove(row);
                    }
                    else
                    {
                        if (!row.IsSelected)
                            row.IsSelected = true;
                    }
                }
            }
            #endregion

            #region 旧代码
            //if (dgv_02.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("请选择要移出的数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (dgv_02.Rows.Count > 0)
            //    if (dgv_02.SelectedRows.Count > 0)
            //        cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(dgv_02.SelectedRows[0].Cells["type"].Value)).ToString() + "："
            //                       + dgv_02.SelectedRows[0].Cells["type"].Value;
            //cb_type_TextChanged(null, null);
            //int ii = dgv_01.Rows.Count;
            ////dgv_01.ClearSelection();
            ////for (int i = 0; i < ii; i++)
            ////{
            ////	if (dgv_01.Rows[i].Cells["id"].Value.ToString() == dgv_02.SelectedRows[0].Cells["id02"].Value.ToString())
            ////	{
            ////		dgv_01.Rows[i].Selected = true;
            ////	}
            ////}

            //if (dgv_02.Rows.Count != 0 && dgv_02.SelectedRows[0].Cells["num"].Value != null)
            //{
            //    string str_num = dgv_02.SelectedRows[0].Cells["num"].Value.ToString();
            //    int int_num;
            //    int.TryParse(str_num, out int_num);
            //    if (int_num > 1)
            //    {
            //        dgv_02.SelectedRows[0].Cells["num"].Value = int_num - 1;
            //    }
            //    else
            //    {
            //        dgv_02.Rows.RemoveAt(dgv_02.SelectedRows[0].Index);
            //    }
            //    //if (int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) > 1)
            //    //{
            //    //	dgv_02.SelectedRows[0].Cells["num"].Value = int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) - 1;
            //    //}
            //    //else if (int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) == 1)
            //    //{

            //    //	try
            //    //	{


            //    //	}
            //    //	catch
            //    //	{
            //    //		//  MessageBox.Show("已经没有数据可以移除");
            //    //		dgv_02.Rows.Clear();
            //    //		dgv_02.Rows[0].Selected = true;
            //    //	}
            //    //}
            //    //else
            //    //{
            //    //	return;
            //    //}
            //}
            #endregion
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void but_ok_Click(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList inputs = new SortedList();
            SortedList slttp = new SortedList();
            SortedList slttp01 = new SortedList();
            if (isselect == true)
            {
                slttp.Add(1, ssid["id"]);
                //大于0的时候先删除再添加数据
                if (dgv_02.Rows.Count > 0)
                {
                    for (int j = 0; j < dgv_02.Rows.Count; j++)
                    {
                        if (dgv_02.Rows[j].Cells["num"].Value.ToString() == "0" || dgv_02.Rows[j].Cells["num"].Value.ToString() == null)
                        {
                            dgv_02.Rows.RemoveAt(dgv_02.Rows[j].Index);
                        }
                    }
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        SortedList slttp02 = new SortedList();

                        slttp02.Add(1, ssid["id"]);
                        slttp02.Add(2, dgv_02.Rows[i].Cells["id"].Value);
                        slttp02.Add(3, dgv_02.Rows[i].Cells["num"].Value);
                        slttp02.Add(4, dgv_02.Rows[i].Cells["ca_name"].Value.ToString());
                        slttp02.Add(5, sl_type.GetKey(sl_type.IndexOfValue(dgv_02.Rows[i].Cells["type"].Value.ToString().ToString())));
                        slttp01.Add(i + 1, slttp02);

                    }
                    inputs.Add(2, slttp01);

                    SortedList parameter01 = new SortedList();
                    parameter01.Add(1, ssid["id"].ToString());
                    SortedList parameter02 = new SortedList();
                    parameter02.Add(1, parameter01);
                    inputs.Add(1, parameter02);
                    string pp = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-specialset-item-add001", inputs);
                    int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-specialset-item-add001", inputs);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
                //行数等于0的时候直接清空
                else
                {
                    SortedList parameter01 = new SortedList();
                    parameter01.Add(1, ssid["id"].ToString());
                    SortedList parameter02 = new SortedList();
                    parameter02.Add(1, parameter01);
                    string pp = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-specialset-item-add002", inputs);
                    int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-specialset-item-add002", parameter02);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
            }
            else if (isselect == false)
            {
                for (int j = 0; j < dgv_02.Rows.Count; j++)
                {
                    if (dgv_02.Rows[j].Cells["num"].Value.ToString() == "0" || dgv_02.Rows[j].Cells["num"].Value.ToString() == null)
                    {
                        dgv_02.Rows.RemoveAt(dgv_02.Rows[j].Index);
                    }
                }
                if (dgv_02.Rows.Count == 0)
                {
                    slttp.Add(1, ssid["id"].ToString());
                    slttp.Add(2, ssid["type"].ToString());
                    slttp01.Add(1, slttp);
                    int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-set-instrument-del002", slttp01);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    SortedList delectInstrument = new SortedList();
                    SortedList delectInstrument01 = new SortedList();
                    delectInstrument.Add(1, ssid["id"].ToString());
                    delectInstrument.Add(2, ssid["type"].ToString());
                    delectInstrument01.Add(1, delectInstrument);
                    int recint01 = reCnasRemotCall.RemotInterface.UPDataList("HCS-set-instrument-del002", delectInstrument01);
                    for (int i = 0; i < dgv_02.Rows.Count; i++)
                    {
                        int instrumentNum = int.Parse(dgv_02.Rows[i].Cells["num"].Value.ToString());
                        for (int j = 0; j < instrumentNum; j++)
                        {

                            slttp.Add(1, dgv_02.Rows[i].Cells["id"].Value.ToString());//器械id
                            slttp.Add(2, ssid["id"].ToString());//基本包id
                            slttp.Add(3, ssid["type"].ToString());//基本包类型
                            slttp01.Add(1, slttp);
                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", slttp01, null);

                            slttp.Clear();
                            slttp01.Clear();
                        }
                    }
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        private void tb_insname_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
        /// <summary>
        /// 查询按钮的触发事件
        /// </summary>
        private void but_sel_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            DataTable getdt = null;
            DataRow[] arrayDR = null;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            sttemp01.Add(2, ssid["customer"].ToString());
         //   sttemp01.Add(3, ssid["costcentername"].ToString());

            if (cb_type.Text.Substring(0, 1) == "1")
            {
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec0010", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec0010", sttemp01);
            }
            else
            {
                string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec015", sttemp01);
                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec015", sttemp01);
            }
            if (getdt != null && getdt.Rows.Count > 0)
                arrayDR = getdt.Select("ca_name like '%" + strsecdata + "%' ");
            if (arrayDR == null) return;
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
            dgv_01_SelectionChanged(null, null);
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_sname.Clear();
            loaddate();
        }

        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_01_SelectionChanged(object sender, EventArgs e)
        {
            //tb_insname.Clear();
            //tb_num.Clear();
            //if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0].Cells["ca_name"].Value != null)
            //{
            //    tb_insname.Text = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //    tb_num.Text = "1";
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count == 0)
            {
                MessageBox.Show("没有可以请空的物品", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定要清空订单模板的物品？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No) return;
            dgv_02.Rows.Clear();
        }

        private void but_sel_Click_1(object sender, EventArgs e)
        {


        }

        private void but_cancel_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void but_addone_Click_1(object sender, EventArgs e)
        {

        }

        private void but_reone_Click_1(object sender, EventArgs e)
        {
            if (dgv_02.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要移出的数据", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_02.Rows.Count > 0)
                if (dgv_02.SelectedRows.Count > 0)
                    if (dgv_02.SelectedRows[0].Cells["type"].Value.ToString() != cb_type.Text.Substring(2))
                    {
                        MessageBox.Show("你好，你移出的物品类型不符合", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            if (dgv_02.Rows.Count != 0 && dgv_02.SelectedRows[0].Cells["num"].Value != null)
            {
                if (int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) > 1)
                {
                    dgv_02.SelectedRows[0].Cells["num"].Value = int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) - 1;
                }
                else if (int.Parse(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()) == 1)
                {

                    try
                    {
                        dgv_02.Rows.RemoveAt(dgv_02.SelectedRows[0].Index);

                    }
                    catch
                    {
                        //  MessageBox.Show("已经没有数据可以移除");
                        dgv_02.Rows.Clear();
                        if (dgv_02.Rows.Count > 0)
                        {
                            dgv_02.CurrentRow = dgv_02.Rows[0];
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void but_ok_Click_1(object sender, EventArgs e)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList inputs = new SortedList();
            SortedList slttp = new SortedList();
            SortedList slttp01 = new SortedList();
            slttp.Add(1, ssid["id"]);
            //大于0的时候先删除再添加数据
            if (dgv_02.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList slttp02 = new SortedList();

                    slttp02.Add(1, ssid["id"]);
                    slttp02.Add(2, dgv_02.Rows[i].Cells["id"].Value);
                    slttp02.Add(3, dgv_02.Rows[i].Cells["num"].Value);
                    slttp02.Add(4, dgv_02.Rows[i].Cells["ca_name"].Value.ToString());
                    slttp02.Add(5, sl_type.GetKey(sl_type.IndexOfValue(dgv_02.Rows[i].Cells["type"].Value.ToString().ToString())));
                    slttp01.Add(i + 1, slttp02);

                }
                inputs.Add(2, slttp01);

                SortedList parameter01 = new SortedList();
                parameter01.Add(1, ssid["id"].ToString());
                SortedList parameter02 = new SortedList();
                parameter02.Add(1, parameter01);
                inputs.Add(1, parameter02);
                string pp = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-specialset-item-add001", inputs);
                int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-specialset-item-add001", inputs);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            //行数等于0的时候直接清空
            else
            {
                SortedList parameter01 = new SortedList();
                parameter01.Add(1, ssid["id"].ToString());
                SortedList parameter02 = new SortedList();
                parameter02.Add(1, parameter01);
                string pp = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-specialset-item-add002", inputs);
                int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-specialset-item-add002", parameter02);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单器械模板" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
        }

        private void cb_type_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tb_sname.Clear();
            loaddate();
        }

        private void but_addone_Click_2(object sender, EventArgs e)
        {
            #region 旧代码
            //if (tb_insname.Text == "")
            //{
            //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (tb_insname.Text != "")
            //{
            //    int num = 0;//计算器械名字出现相同次数！

            //    if (dgv_02.Rows.Count == 0)//这类基本包第一次添加第一把器械
            //    {
            //        string str_id = "", str_app_name = "", str_type = "";
            //        if (dgv_01.SelectedRows[0].Cells["id"] != null) str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        if (dgv_01.SelectedRows[0].Cells["ca_name"] != null) str_app_name = tb_insname.Text;
            //        if (cb_type.Text != null) str_type = cb_type.Text.Substring(2);
            //        DataGridViewRow drtemp01 = new DataGridViewRow();

            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//number
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//类型

            //        drtemp01.SetValues(str_id, "0", str_app_name, str_type);
            //        dgv_02.Rows.Add(drtemp01);
            //        //  dgv_02.RowCount++;
            //        dgv_02.Rows[0].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        dgv_02.Rows[0].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //        dgv_02.Rows[0].Cells["num"].Value = tb_num.Text;
            //        dgv_02.Rows[0].Cells["type"].Value = cb_type.Text.Substring(2);

            //        // dgv_02.Rows[0].Selected = true;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dgv_02.Rows.Count; i++)
            //        {
            //            try
            //            {
            //                dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //            }
            //            catch
            //            {
            //                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choiceitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //            if (dgv_01.SelectedRows[0].Cells["id"].Value.ToString() == dgv_02.Rows[i].Cells["id02"].Value.ToString())//全部不同才添加
            //            {
            //                dgv_02.Rows[i].Cells["num"].Value = int.Parse(dgv_02.Rows[i].Cells["num"].Value.ToString()) + int.Parse(tb_num.Text);
            //                dgv_02.Rows[0].Selected = false;
            //                dgv_02.Rows[i].Selected = true;
            //                num--;
            //            }
            //            num++;

            //            if (num == dgv_02.Rows.Count)//
            //            {
            //                string str_id = "", str_app_name = "";
            //                if (dgv_01.SelectedRows[0].Cells["id"].Value != null) str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //                if (dgv_01.SelectedRows[0].Cells["ca_name"].Value != null) str_app_name = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //                DataGridViewRow drtemp01 = new DataGridViewRow();

            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//number
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //                drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名
            //                drtemp01.SetValues(str_id, str_app_name, tb_num.Text, cb_type.Text.Substring(2));
            //                dgv_02.Rows.Add(drtemp01);
            //                dgv_02.Rows[i + 1].Selected = true;
            //                //dgv_02.RowCount++;
            //                //dgv_02.Rows[i].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["number"].Value = "1";

            //                return;
            //            }
            //        }


            //    }
            //}
            #endregion


        }

        //private void but_reone_Click_2(object sender, EventArgs e)
        //{

        //}

        //private void but_ok_Click_2(object sender, EventArgs e)
        //{

        //}

        //private void cb_type_SelectedIndexChanged_2(object sender, EventArgs e)
        //{

        //}

        //private void but_sel_Click_2(object sender, EventArgs e)
        //{
        //	dgv_01.Rows.Clear();
        //	string strsecdata = tb_sname.Text.Trim();
        //	DataTable getdt = null;
        //	DataRow[] arrayDR = null;

        //	CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        //	SortedList sttemp01 = new SortedList();
        //	sttemp01.Add(1, CnasBaseData.SystemID);
        //	sttemp01.Add(2, ssid["customer"].ToString());
        //	sttemp01.Add(3, ssid["costcenter"].ToString());

        //	if (cb_type.Text.Substring(0, 1) == "1")
        //	{
        //		//string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec005", sttemp01);
        //		getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec0010", sttemp01);
        //	}
        //	else
        //	{
        //		getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec015", sttemp01);
        //	}
        //	if (getdt != null && getdt.Rows.Count > 0)
        //		arrayDR = getdt.Select("ca_name like '%" + strsecdata + "%' ");

        //	int ii = arrayDR.Length;
        //	if (ii <= 0) return;
        //	dgv_01.RowCount = ii;
        //	int i = 0;
        //	foreach (DataRow dr in arrayDR)
        //	{
        //		if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dr["id"].ToString();
        //		if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dr["ca_name"].ToString();

        //		i++;
        //	}
        //}

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void cb_type_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_sname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                GetData();
            }
        }

        private void cb_type_TextChanged(object sender, EventArgs e)
        {
            tb_sname.Clear();
            // tb_insname.Clear();
            loaddate();
            dgv_01_SelectionChanged(null, null);
        }

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            but_addone_Click(null, null);
        }

        private void dgv_02_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            but_reone_Click(null, null);
        }

        private void dgv_02_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCell num = dgv_02.CurrentCell;
            //DataGridViewColumn col = num.OwningColumn;
            //if (col.Name == "num")
            //{
            //	if (Convert.ToString(num.Value) == "0")
            //	{
            //		//dgv_02.Rows.RemoveAt(num.RowIndex);
            //		dgv_02.Rows[num.RowIndex].Visible = false;
            //	}

            //}
            try
            {
                if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
                {
                    string value = Convert.ToString(dgv_02.CurrentCell.Value);
                    if (value == "0" || string.IsNullOrEmpty(value))
                    {
                        if (dgv_02.EndEdit())
                        {
                            editRow = dgv_02.Rows.IndexOf(dgv_02.CurrentRow);
                            //editRow = currentRowIndex;
                            //int nextIndex = (currentRowIndex + 1 >= dgv_02.Rows.Count) ? dgv_02.Rows.Count - 1 : currentRowIndex + 1;
                            //dgv_02.CurrentCell = dgv_02.Rows[nextIndex].Cells["num"];
                            isSuccess = true;
                            dgv_02.Rows.Remove(dgv_02.CurrentRow);
                        }
                    }
                }
            }
            catch (Exception)
            {
                isSuccess = false;
            }



        }

        //private int editRow = -1;

        private void dgv_02_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (editRow == -1 && isSuccess)
                {
                    dgv_02.Rows.Remove(dgv_02.Rows[editRow]);
                    editRow = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_02_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int editRow = -1;
        private bool isSuccess = true;

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (editRow != -1 && !isSuccess)
                {
                    dgv_02.Rows.Remove(dgv_02.Rows[editRow]);
                    editRow = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgv_02_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
                    {
                        if (dgv_02.SelectedRows[0].Cells["num"].Value.ToString() == "0" || string.IsNullOrEmpty(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()))
                        {
                            isSuccess = true;
                            dgv_02.Rows.Remove(dgv_02.SelectedRows[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
                
            }
        }

        private void tb_number_TextChanged(object sender, EventArgs e)
        {
            if (tb_number.Text.Trim() == "" || tb_number.Text.Trim()=="0")
            {
                tb_number.Text = "1";
                return;
            }
        }
    }
}