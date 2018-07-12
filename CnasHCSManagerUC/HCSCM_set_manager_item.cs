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
    public partial class HCSCM_set_manager_item : TemplateForm
    {
        int _itemNum = 0;//点击修改器械数量时用到
        private string baseid = "";//基本包id
        private string basetype = "";//基本包类型
        private string basecc = "";//基本包的成本中心
        private string basecu = "";//基本包的客户

        private bool vbut = true;
        public HCSCM_set_manager_item(SortedList SLvalue, bool Vbutton)
        {
            InitializeComponent();
            //设置窗体图标
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "instrumentsNumber", EnumImageType.PNG);
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "addItem", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--添加器械";

            this.tb_name.Text = SLvalue["ca_name"].ToString();

            baseid = SLvalue["id"].ToString();
            basetype = SLvalue["ca_type"].ToString();
            basecc = SLvalue["cost_center"].ToString();
            basecu = SLvalue["customer_code"].ToString();
            vbut = Vbutton;

            //器械类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_instrument_type'");
            this.cb_type.Items.Add(new RadListDataItem() { Text = "----所有----", Value = "0" });
            //  sl_type.Add("0", "----所有----");
            foreach (DataRow dr in typeDR)
            {

                //  sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());

                cb_type.Items.Add(new RadListDataItem() { Text = dr["value_code"].ToString().Trim(), Value = dr["key_code"].ToString().Trim() });
                //cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }

            // cb_type.Text = "----所有----";
            cb_type.SelectedIndex = 0;



            dgv_02.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, baseid);
            //          string test = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-instrument-sec002", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-sec002", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.SystemID);
            //         string test2 = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp02);
            DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp02);
            if (getdt != null && getdt02 != null)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_02.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("instrument_id") && getdt.Rows[i]["instrument_id"] != null) dgv_02.Rows[i].Cells["id"].Value = getdt.Rows[i]["instrument_id"].ToString();//id
                    if (getdt.Columns.Contains("COUNT(instrument_id)") && getdt.Rows[i]["COUNT(instrument_id)"] != null) dgv_02.Rows[i].Cells["number"].Value = getdt.Rows[i]["COUNT(instrument_id)"].ToString();//数量
                    DataRow secDR = getdt02.Select("id=" + getdt.Rows[i]["instrument_id"].ToString())[0];
                    if (getdt02.Columns.Contains("ca_name") && secDR["ca_name"] != null) dgv_02.Rows[i].Cells["ca_name"].Value = secDR["ca_name"].ToString();//名称
                    //if (getdt.Rows[i]["customer_code"] != null) dgv_02.Rows[i].Cells["customer_code"].Value = getdt.Rows[i]["customer_code"].ToString();
                }
                if (dgv_02.Rows.Count > 0)
                {
                    dgv_02.CurrentRow = dgv_02.Rows[0];
                }
                // dgv_02.Rows[0].IsSelected = true;
            }
            //dgv_01.Rows[0].Selected = true;
            //dgv_02.Rows[0].Selected = true;
        }

        private void LoadDgv_01()
        {
            dgv_01.Rows.Clear();
            string strsecdata = tb_sname.Text.Trim();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);

            //  string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp01);//220

            //如果等于nUll，则直接返回
            if (getdt == null) return;
            string selectSql = string.Format(" ca_name like '%" + strsecdata + "%' and  ca_customerID= " + basecu);
            if (cb_type.SelectedItem.Value.ToString() != "0")
            {
                selectSql += string.Format(" and ca_type = " + cb_type.SelectedItem.Value);
            }
            DataRow[] arrayDR = getdt.Select(selectSql);
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
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
            //dgv_01.Rows[0].IsSelected = true;
        }
        private void cleckSelecEvent(object sender, EventArgs e)
        {
            LoadDgv_01();
        }

        private void LoadTheFromEvent(object sender, EventArgs e)
        {
            //  LoadDgv_01();
        }



        private void but_save_Click(object sender, EventArgs e)
        {

            try
            {
                //取基本包id与器械id即可
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, baseid);

                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-sec002", sttemp01);

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                int sint = 0;//器械数量
                int ii = 0;
                if (getdt == null)//添加器械
                {
                    #region  无器械时添加器械
                    if (dgv_02.Rows.Count == 0)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "无器械基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < dgv_02.Rows.Count; i++)
                        {
                            if (dgv_02.Rows[i].Cells["number"].Value != null)
                            {
                                for (int i02 = 0; i02 < int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()); i02++)
                                {
                                    sltmp.Add(1, dgv_02.Rows[i].Cells["id"].Value.ToString());//器械id
                                    sltmp.Add(2, baseid);//基本包id
                                    sltmp.Add(3, basetype);//基本包类型
                                    sltmp01.Add(1, sltmp);
                                    //     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", sltmp01, null);
                                    if (recint > -1)
                                    {
                                        sint++;//添加器械正常，sint自加；
                                    }
                                    sltmp.Clear();
                                    sltmp01.Clear();
                                }
                            }
                            if (sint == int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()))//为真，代表这累器械添加的数量正常
                            {
                                //
                                ii++;
                                sint = 0;//清零
                            }
                        }
                        if (ii == dgv_02.Rows.Count)//ii每次自加成功代表sint在循环里没出错！
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    }
                    #endregion
                }
                else
                {
                    if (dgv_02.Rows.Count == 0)
                    {
                        #region 删除基本包所有器械
                        sltmp.Add(1, baseid);//基本包id
                        sltmp.Add(2, basetype);//基本包类型
                        sltmp01.Add(1, sltmp);
                        // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        //     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-del002", sltmp01, null);
                        if (recint > -1)
                        {

                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("noitem", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        #endregion
                    }
                    else
                    {
                        #region 比较数据库器械数量与dgv_02器械数量，做增加与删除
                        for (int i = 0; i < dgv_02.Rows.Count; i++)//取dgv_02每一行
                        {
                            int sumid = 0;//用于计算这类器械在数据库中是否存在
                            int dtRowsC = getdt.Rows.Count;//getdt表行数
                            for (int j = 0; j < dtRowsC; j++)
                            {
                                #region 器械数量的对比，以dgv_02为准，number大添加，number小删除
                                if (dgv_02.Rows[i].Cells["id02"].Value.ToString() == getdt.Rows[j]["instrument_id"].ToString())
                                {
                                    sumid = 0;
                                    if (int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()) > int.Parse(getdt.Rows[j]["COUNT(instrument_id)"].ToString()))
                                    {
                                        int differ = int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()) - int.Parse(getdt.Rows[i]["COUNT(instrument_id)"].ToString());
                                        for (int j02 = 0; j02 < differ; j02++)
                                        {

                                            sltmp.Add(1, dgv_02.Rows[i].Cells["id02"].Value.ToString());//器械id
                                            sltmp.Add(2, baseid);//基本包id
                                            sltmp.Add(3, basetype);//基本包类型
                                            sltmp01.Add(1, sltmp);
                                            // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                                            //     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", sltmp01, null);
                                            if (recint > -1)
                                            {

                                                sint++;//添加正常，sint自加；
                                            }
                                            sltmp.Clear();
                                            sltmp01.Clear();

                                        }
                                    }
                                    else if (int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()) < int.Parse(getdt.Rows[j]["COUNT(instrument_id)"].ToString()))
                                    {
                                        sltmp.Add(1, dgv_02.Rows[i].Cells["id02"].Value.ToString());//器械id
                                        sltmp.Add(2, baseid);//基本包id
                                        sltmp.Add(3, basetype);//基本包类型
                                        sltmp01.Add(1, sltmp);
                                        // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                                        // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-instrument-del001", sltmp01, null);
                                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-del001", sltmp01, null);
                                        if (recint > -1)
                                        {

                                            sint++;//添加正常，sint自加；
                                        }
                                        sltmp.Clear();
                                        sltmp01.Clear();
                                        for (int j02 = 0; j02 < int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()); j02++)
                                        {

                                            sltmp.Add(1, dgv_02.Rows[i].Cells["id02"].Value.ToString());//器械id
                                            sltmp.Add(2, baseid);//基本包id
                                            sltmp.Add(3, basetype);//基本包类型
                                            sltmp01.Add(1, sltmp);
                                            // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                                            //  string strtmp02 = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-instrument-add001", sltmp01, null);
                                            int recint02 = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", sltmp01, null);
                                            if (recint > -1)
                                            {

                                                sint++;//添加正常，sint自加；
                                            }
                                            sltmp.Clear();
                                            sltmp01.Clear();
                                        }
                                    }

                                }
                                else
                                {
                                    sumid++;
                                    if (sumid == dtRowsC)//sumid累加等于dtrowc，说明这器械id与数据库所有数据比较了，全不相同
                                    {
                                        dgv_02.Rows[i].Cells["id02"].Value.ToString();
                                        int differ = int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString());
                                        for (int j02 = 0; j02 < differ; j02++)
                                        {

                                            sltmp.Add(1, dgv_02.Rows[i].Cells["id02"].Value.ToString());//器械id
                                            sltmp.Add(2, baseid);//基本包id
                                            sltmp.Add(3, basetype);//基本包类型
                                            sltmp01.Add(1, sltmp);
                                            // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                                            //     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", sltmp01, null);
                                            if (recint > -1)
                                            {
                                                sint++;//添加正常，sint自加；
                                                getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-sec002", sttemp01);//添加后重新赋值
                                            }
                                            sltmp.Clear();
                                            sltmp01.Clear();
                                        }
                                    }
                                }
                                #endregion
                                int sumid02 = 0;
                                #region 取数据getdt与dgv_02比较，以getdt的id为主

                                for (int i02 = 0; i02 < dgv_02.Rows.Count; i02++)
                                {
                                    if (dgv_02.Rows[i02].Cells["id02"].Value.ToString() == getdt.Rows[j]["instrument_id"].ToString())
                                    {
                                        sumid02 = 0;
                                    }
                                    else
                                    {
                                        sumid02++;
                                        if (sumid02 == dgv_02.Rows.Count)
                                        {
                                            sltmp.Add(1, getdt.Rows[j]["instrument_id"].ToString());//器械id
                                            sltmp.Add(2, baseid);//基本包id
                                            sltmp.Add(3, basetype);//基本包类型
                                            sltmp01.Add(1, sltmp);
                                            // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                                            // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-instrument-del001", sltmp01, null);
                                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-del001", sltmp01, null);
                                            if (recint > -1)
                                            {

                                                sint++;//添加正常，sint自加；
                                            }
                                            sltmp.Clear();
                                            sltmp01.Clear();
                                            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-sec002", sttemp01);//改后重新赋值
                                            dtRowsC = getdt.Rows.Count;//getdt表行数**
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }

                }
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }




        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_new_Click(object sender, EventArgs e)
        {

            HCSCM_set_manager_item_add hcsm = new HCSCM_set_manager_item_add(basetype, basecc, basecu);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            hcsm.sl_02data.GetKeyList();

            int ii = hcsm.sl_02data.GetKeyList().Count;
            if (ii <= 0) return;
            dgv_01.RowCount = ii;
            for (int i = 0; i < ii; i++)
            {
                if (hcsm.sl_02data.GetKeyList()[i].ToString() != null) dgv_01.Rows[i].Cells["id"].Value = hcsm.sl_02data.GetKeyList()[i].ToString();
                if (hcsm.sl_02data.GetValueList()[i].ToString() != null) dgv_01.Rows[i].Cells["ca_name"].Value = hcsm.sl_02data.GetValueList()[i].ToString();

            }
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
                            int.Parse(dgv_02.Rows[k].Cells["number"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.Rows[i].Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (row.Cells["id"].Value.ToString() == dgv_02.Rows[k].Cells["id"].Value.ToString())
                        {
                            dgv_02.Rows[k].Cells["number"].Value = int.Parse(tb_number.Text) + int.Parse(dgv_02.Rows[k].Cells["number"].Value.ToString());
                            ifNewRows = false;
                        }
                    }
                    if (ifNewRows)
                    {
                        GridViewRowInfo newRow = dgv_02.Rows.AddNew();
                        newRow.Cells[0].Value = row.Cells[0].Value;
                        newRow.Cells[1].Value = row.Cells[1].Value;
                        newRow.Cells[2].Value = tb_number.Text;
                    }
                }
            }
            #endregion


            #region 旧代码
            //if (dgv_01.Rows.Count > 0)
            //{
            //    int num = 0;//计算器械名字出现相同次数！

            //    if (dgv_02.Rows.Count == 0)//这类基本包第一次添加第一把器械
            //    {
            //        string str_id = "", str_app_name = "";
            //        if (dgv_01.SelectedRows[0].Cells["id"] != null) str_id = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        if (dgv_01.SelectedRows[0].Cells["ca_name"] != null) str_app_name = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //        DataGridViewRow drtemp01 = new DataGridViewRow();

            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//ID
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//number
            //        drtemp01.Cells.Add(new DataGridViewTextBoxCell());//器械名

            //        drtemp01.SetValues(str_id, "0", str_app_name);
            //        dgv_02.Rows.Add(drtemp01);
            //        //  dgv_02.RowCount++;
            //        dgv_02.Rows[0].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //        dgv_02.Rows[0].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //        dgv_02.Rows[0].Cells["number"].Value = "1";
            //        dgv_02.Rows[0].Selected = true;
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
            //                dgv_02.Rows[i].Cells["number"].Value = int.Parse(dgv_02.Rows[i].Cells["number"].Value.ToString()) + 1;
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
            //                drtemp01.SetValues(str_id, "1", str_app_name);
            //                dgv_02.Rows.Add(drtemp01);
            //                dgv_02.Rows[i + 1].Selected = true;
            //                //dgv_02.RowCount++;
            //                //dgv_02.Rows[i].Cells["id02"].Value = dgv_01.SelectedRows[0].Cells["id"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["ca_name02"].Value = dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString();
            //                //dgv_02.Rows[i].Cells["number"].Value = "1";

            //                return;
            //            }
            //  }
            //}
            //}
            #endregion

        }






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
                        int.Parse(row.Cells["number"].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { "选中移动项" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    row.Cells["number"].Value = int.Parse(row.Cells["number"].Value.ToString()) - int.Parse(tb_number.Text);
                    if (int.Parse(row.Cells["number"].Value.ToString()) <= 0)
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
            //try
            //{


            //    if (dgv_02.SelectedRows[0].Cells["number"].Value != null)
            //    {
            //        if (int.Parse(dgv_02.SelectedRows[0].Cells["number"].Value.ToString()) > 1)
            //        {
            //            dgv_02.SelectedRows[0].Cells["number"].Value = int.Parse(dgv_02.SelectedRows[0].Cells["number"].Value.ToString()) - 1;
            //        }
            //        else if (int.Parse(dgv_02.SelectedRows[0].Cells["number"].Value.ToString()) == 1)
            //        {

            //            try
            //            {
            //                dgv_02.Rows.RemoveAt(dgv_02.SelectedRows[0].Index);

            //            }
            //            catch
            //            {
            //                //  MessageBox.Show("已经没有数据可以移除");
            //                dgv_02.Rows.Clear();
            //                dgv_02.Rows[0].IsSelected = true;
            //            }
            //        }
            //        else
            //        {
            //            return;
            //        }



            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("没有要移除的器械", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            #endregion
        }

        private void but_addall_Click(object sender, EventArgs e)
        {
            if (basetype == "3")
            {
                but_addall.Enabled = false;
            }
            if (dgv_02.Rows.Count != 0)
            {
                string getNum = dgv_02.SelectedRows[0].Cells["number"].Value.ToString();
                HCSCM_set_manage_item_number hcsm = new HCSCM_set_manage_item_number(getNum);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                hcsm.ShowDialog();
                dgv_02.SelectedRows[0].Cells["number"].Value = hcsm.Inumber;
            }
            else
            {
                MessageBox.Show("请添加器械", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }



        }

        private void dgv_02_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgv_02.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;//将当前单元格设为可读
            //this.dgv_02.CurrentCell = this.dgv_02.Rows[e.RowIndex].Cells[e.ColumnIndex];//获取当前单元格
            //this.dgv_02.BeginEdit(true);//将单元格设为编辑状态
            but_reone_Click(null, null);

        }



        private void LoadSelectChange(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadDgv_01();
            }

        }

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            but_addone_Click(null, null);
        }
        private int editRow = -1;
        private bool isSuccess = true;
        private void dgv_02_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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

        private void dgv_02_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
                    {
                        if (dgv_02.SelectedRows[0].Cells["number"].Value.ToString() == "0" || string.IsNullOrEmpty(dgv_02.SelectedRows[0].Cells["num"].Value.ToString()))
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

        private void dgv_02_SelectionChanged(object sender, EventArgs e)
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

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadDgv_01();
        }
        /// <summary>
        /// 记录手动输入钱最后的数字
        /// </summary>
        private void ItemOldNumber()
        {
            if (dgv_02.SelectedRows.Count == 1 && dgv_02.CurrentRow.Cells["number"].Value != null)
            {
                try
                {
                    _itemNum = int.Parse(dgv_02.CurrentRow.Cells["number"].Value.ToString());
                }
                catch
                {

                }

            }
        }

        private void dgv_02_CellClick(object sender, GridViewCellEventArgs e)
        {
            ItemOldNumber();
        }

        private void dgv_02_KeyDown(object sender, KeyEventArgs e)
        {
            ItemOldNumber();
        }

        private void dgv_02_MouseClick_1(object sender, MouseEventArgs e)
        {
            ItemOldNumber();
        }

        private void dgv_02_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            ManualModification(dgv_02, dgv_01);
        }

        private void ManualModification(RadGridView dgv_02, RadGridView dgv_01)
        {
            if (dgv_02.CurrentRow.Cells["number"].Value != null && !CnasUtilityTools.IsNumeric(dgv_02.CurrentRow.Cells["number"].Value.ToString()))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("InputNum", EnumPromptMessage.warning, new string[] { dgv_02.CurrentRow.Cells["ca_name"].Value.ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_02.CurrentRow.Cells["number"].Value = _itemNum;
                return;
            }
            if (dgv_02.CurrentRow != null && dgv_02.CurrentCell != null)
            {
                string value = Convert.ToString(dgv_02.CurrentCell.Value);
                if (value == "0" || string.IsNullOrEmpty(value))
                {
                    //输入为空或者0时

                    dgv_02.Rows.Remove(dgv_02.CurrentRow);


                }
            }
        }

        private void tb_number_TextChanged(object sender, EventArgs e)
        {
            if (tb_number.Text.Trim() == "" || tb_number.Text.Trim() == "0")
            {
                tb_number.Text = "1";
                return;
            }
        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入

            }
        }

    }
}




