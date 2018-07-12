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
    public partial class HCSCM_set_manager_set_select : TemplateForm
    {
        private DataRow[] arrayDR = null;//用于传输数据
        private DataRow[] arrayDR02 = null;//存放的是基本包信息
        private DataTable DTStorage = new DataTable();//存放存储点信息
        private DataTable ItemData = null;
        private DataTable storageData = null;


        SortedList Sl_type_01 = new SortedList();//存储成本中心
        SortedList Sl_type_01_01 = new SortedList();//都存储成本中心，但范围不同(大)
        SortedList Sl_type_02 = new SortedList();//存储所属顾客
        SortedList Sl_type_02_01 = new SortedList();//存储所属顾客id
        SortedList Sl_uselocation = new SortedList();//存储所属顾客id
        string set_type = "";//存储基本包的类型
        string if_alien = "";//是否为外来包
        string priority = "";//优先级
        private string basename = "";//基本包名字
        private string baseId = "";//基本包id
        string strbarcode_top = "";//选择选项上面的值
        string strbarcode_down = "";//选择选项下面的值
        private SortedList storage = null;
        private SortedList sl_storageid = new SortedList();
        /// <summary>
        /// 最新创建的包id
        /// </summary>
        int newId = 0;
        public HCSCM_set_manager_set_select(string SelectId, string selectname, string strbarcode, string ca_priority, string IsRfid)
        {

            InitializeComponent();
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建实体包";
            basename = selectname;
            baseId = SelectId;
            priority = ca_priority;
            //判断是否显示加急功能键
            if (priority != "1")
            {
                cb_if_urgent.Visible = false;
            }
            //if (IsRfid != "1")
            //{
            //    cb_RFID.Visible = false;
            //}

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            // string check = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec006", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        Sl_type_01_01.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());//用于下拉菜单
                        // cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["id"].ToString() });
                    }

                }
                // cb_cost_center.SelectedIndex = 0;
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        Sl_type_02.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        Sl_type_02_01.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            sl_storageid.Add("0", "");
            DTStorage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);//存储点

            if (DTStorage != null)
            {

                int ii = DTStorage.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTStorage.Rows[i]["id"].ToString() != null && DTStorage.Rows[i]["s_name"].ToString().Trim() != null)
                    {
                        sl_storageid.Add(DTStorage.Rows[i]["id"].ToString().Trim(), DTStorage.Rows[i]["s_name"].ToString().Trim());
                    }
                }
            }
            SortedList sttemp01 = new SortedList();

            sttemp01.Add(1, CnasBaseData.SystemID);
            // string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec001", sttemp01);

            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//基本包信息
            if (getdt != null)
            {
                arrayDR02 = getdt.Select("bar_code=" + "'" + strbarcode + "'");
                cb_customer.Text = Sl_type_02[arrayDR02[0]["customer_code"].ToString()].ToString();
                foreach (RadListDataItem item in cb_cost_center.Items)
                {
                    if (Sl_type_01 != null)
                    {
                        if (item.ToString() == Sl_type_01[arrayDR02[0]["cost_center"].ToString()].ToString())
                        {
                            int indexx = cb_cost_center.Items.IndexOf(item);
                            cb_cost_center.SelectedIndex = indexx;
                            break;
                        }
                    }

                }

                //cb_cost_center.Text = Sl_type_01[arrayDR02[0]["cost_center"].ToString()].ToString();
                tb_weight.Text = arrayDR02[0]["ca_weight"].ToString();
                tb_size.Text = arrayDR02[0]["ca_size"].ToString();
                set_type = arrayDR02[0]["ca_type"].ToString();
                if_alien = arrayDR02[0]["classify"].ToString();
                if (arrayDR02[0]["rfid_retrospect"].ToString() == "1")
                {
                    cb_RFID.Checked = true;
                }
                else
                {
                    cb_RFID.Checked = false;
                }
            }
            if (set_type == "2")//如果为真则说明是特殊包，显示送货单的功能
            {

                if (if_alien == "1")//判断是否为院内包
                {
                    //获取院内送货单的信息
                    DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note' and key_code='Hospital'");
                    if (arrayDR02.Length > 0)//判断是否有值
                    {
                        strbarcode_top = arrayDR02[0]["other_code"].ToString().Trim();
                        strbarcode_down = arrayDR02[1]["other_code"].ToString().Trim();
                        //显示控件
                        rb_BCCO1.Visible = false;
                        rb_BCCO2.Visible = false;
                        lb_ifDelivery_note.Visible = false;
                        rb_BCCO1.Text = arrayDR02[0]["value_code"].ToString().Trim();
                        rb_BCCO2.Text = arrayDR02[1]["value_code"].ToString().Trim();
                    }


                }
                else
                {
                    //获取院外送货单的信息
                    DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-delivery-note' and key_code='Outside the hospital'");
                    if (arrayDR02.Length > 0)//判断是否有值
                    {
                        strbarcode_top = arrayDR02[0]["other_code"].ToString().Trim();
                        strbarcode_down = arrayDR02[1]["other_code"].ToString().Trim();
                        //显示控件
                        rb_BCCO1.Visible = false;
                        rb_BCCO2.Visible = false;
                        lb_ifDelivery_note.Visible = false;
                        rb_BCCO1.Text = arrayDR02[0]["value_code"].ToString().Trim();
                        rb_BCCO2.Text = arrayDR02[1]["value_code"].ToString().Trim();
                    }
                }

            }
            Loaddata(strbarcode);
            ItemData = LoadItemData();

        }
        private void Loaddata(string base_code)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string check = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec006", null);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec006", null);
            if (getdt != null)
            {
                arrayDR = getdt.Select();

                if (arrayDR[0]["max(id)"].ToString() != null)
                {
                    string a = arrayDR[0]["max(id)"].ToString();
                    if (a == "")
                    {
                        a = "0";
                        int toint = newId = int.Parse(a) + 1;
                        this.tb_name.Text = basename + "<" + toint.ToString() + ">";//刷新名字
                    }
                    else
                    {
                        int toint = newId = int.Parse(a) + 1;
                        this.tb_name.Text = basename + "<" + toint.ToString() + ">";//刷新名字
                    }
                }
            }

            dgv_01.Rows.Clear();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, base_code);
            DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec002", sttemp01);//这类基本包，实体包的数量
            sttemp01.Add(2, CnasBaseData.SystemID);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec001", sttemp01);

            if (getdt != null && getdt02 != null)
            {
                if (getdt02.Rows.Count == 0)
                {
                    tb_inum.Text = "0";
                    return;
                }

                tb_inum.Text = getdt02.Rows[0]["COUNT(base_setcode)"].ToString();

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("storage_id") && getdt.Rows[i]["storage_id"] != null) dgv_01.Rows[i].Cells["storage_id"].Value = sl_storageid[getdt.Rows[i]["storage_id"].ToString()].ToString() == "0" ? "" : sl_storageid[getdt.Rows[i]["storage_id"].ToString()].ToString();
                    if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Columns.Contains("ca_name") && getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Columns.Contains("customer_code") && getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = Sl_type_02[getdt.Rows[i]["customer_code"].ToString()].ToString();//值是bar_code
                    if (getdt.Columns.Contains("cost_center") && getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Columns.Contains("location_id") && getdt.Rows[i]["location_id"] != null) dgv_01.Rows[i].Cells["location_id"].Value = getdt.Rows[i]["location_id"] != null && Sl_uselocation[getdt.Rows[i]["location_id"].ToString()] != null ? Sl_uselocation[getdt.Rows[i]["location_id"].ToString()].ToString() : "";
                    if (getdt.Columns.Contains("bar_code") && getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Columns.Contains("cre_date") && getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Columns.Contains("mod_date") && getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Columns.Contains("base_setcode") && getdt.Rows[i]["base_setcode"] != null) dgv_01.Rows[i].Cells["base_setcode"].Value = getdt.Rows[i]["base_setcode"].ToString().ToString();

                }
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[0];
                }
            }

        }

        private DataTable LoadItemData()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttempSetInfo = new SortedList();
            sttempSetInfo.Add(1, baseId);
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-instrument-base-sel001", sttempSetInfo);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-base-sel001", sttempSetInfo);
            return getdt;
        }
        private DataTable LoadLibraryData()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttempSetInfo = new SortedList();
            sttempSetInfo.Add(1, Sl_type_01_01.GetKey(Sl_type_01_01.IndexOfValue(cb_cost_center.Text)));
            string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-costcenter-detail-sel004", sttempSetInfo);
            DataTable getdtLibrary = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-costcenter-detail-sel004", sttempSetInfo);
            // cb_cost_center.Text
            return getdtLibrary;
        }


        private Dictionary<string, string> _tempData = new Dictionary<string, string>();

        private void but_new_Click(object sender, EventArgs e)
        {
            if (this.tb_name.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #region 判断名字是否存在
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(this.cb_customer.Text.Trim())).ToString());
            sttemp01.Add(2, CnasBaseData.SystemID);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec050", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec050", sttemp01);//504
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        if (tb_name.Text.Trim().ToString() == getdt.Rows[i]["ca_name"].ToString().Trim())
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                }
            }


            #endregion

            if (this.cb_customer.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_cost_center.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcostcenter", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_uselocation.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filllocation", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_point.Text.Trim() == "")
            {
                tb_point.Text = "";
            }
            try
            {
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                SortedList sltmp01_01 = new SortedList();
                //sltmp.Add(1, tb_name.Text.Trim().Split('<')[0]);//名字
                sltmp.Add(1, tb_name.Text.Trim());//名字
                sltmp.Add(2, arrayDR02[0]["bar_code"].ToString());//基本包条码base_setcode
                sltmp.Add(3, Sl_type_01.GetKey(Sl_type_01.IndexOfValue(cb_cost_center.Text.Trim())).ToString()); //成本中心
                sltmp.Add(4, Sl_type_02.GetKey(Sl_type_02.IndexOfValue(cb_customer.Text.Trim())).ToString());//顾客
                sltmp.Add(5, Sl_uselocation.GetKey(Sl_uselocation.IndexOfValue(this.cb_uselocation.Text.Trim())).ToString());//使用地点
                sltmp.Add(6, CnasBaseData.SystemID);
                sltmp.Add(7, tb_point.Text.Trim() == "" ? "0" : sl_storageid.GetKey(sl_storageid.IndexOfValue(tb_point.Text.Trim())).ToString());
                if (cb_if_urgent.Checked == true)//如果加急控件打勾，则赋值为1，否则为0
                {
                    sltmp.Add(8, 1);
                }
                else
                {
                    sltmp.Add(8, 0);
                }
                if (cb_RFID.Checked == true)//是否须要RFID追溯
                {
                    sltmp.Add(9, 1);
                }
                else
                {
                    sltmp.Add(9, 0);
                }
                if (set_type != "2")//判断是否为特殊包
                {
                    sltmp.Add(10, "BCC");
                    sltmp.Add(11, "10");
                }
                else
                {
                    if (if_alien == "1")//判断是否为院内包
                    {
                        if (rb_BCCO1.Checked == true)
                        {
                            sltmp.Add(10, strbarcode_top);
                            sltmp.Add(11, "8");
                        }
                        else if (rb_BCCO2.Checked == true)
                        {
                            sltmp.Add(10, strbarcode_down);
                            sltmp.Add(11, "8");
                        }
                        else
                        {
                            sltmp.Add(10, "BCC0S");
                            sltmp.Add(11, "8");

                        }

                    }
                    else
                    {
                        if (rb_BCCO1.Checked == true)
                        {
                            sltmp.Add(10, strbarcode_top);
                            sltmp.Add(11, "8");
                        }
                        else if (rb_BCCO2.Checked == true)
                        {
                            sltmp.Add(10, strbarcode_down);
                            sltmp.Add(11, "8");
                        }
                        else
                        {
                            sltmp.Add(10, "BCC3S");
                            sltmp.Add(11, "8");
                        }
                    }
                }
                sltmp01.Add(1, sltmp);
                sltmp01_01.Add(1, sltmp01);
                // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-add001", sltmp01, null);

                #region 入库添加
                SortedList sltmpUpLiblaryAll = new SortedList();
                SortedList sltmpAddLiblaryAll = new SortedList();

                storageData = LoadLibraryData();
                if (ItemData != null)
                {
                    int key = 1;
                    for (int i = 0; i < ItemData.Rows.Count; i++)
                    {
                        _tempData.Clear();
                        int storyNum = 0;
                        int itemNum = 0;

                        if (ItemData.Rows[i]["in_num"].ToString() != "")//判断是器械是否有值
                        {
                            itemNum = int.Parse(ItemData.Rows[i]["in_num"].ToString());
                        }
                        if (storageData != null)
                        {
                            for (int j = 0; j < storageData.Rows.Count; j++)
                            {
                                _tempData.Add(storageData.Rows[j]["instrument_base_id"].ToString(), storageData.Rows[j]["in_set_count"].ToString());
                            }

                            for (int j = 0; j < storageData.Rows.Count; j++)
                            {
                                if (_tempData.ContainsKey(ItemData.Rows[i]["instrument_id"].ToString()))
                                {

                                    if (_tempData[ItemData.Rows[i]["instrument_id"].ToString()].ToString()!="")
                                    {
                                        storyNum =int.Parse( _tempData[ItemData.Rows[i]["instrument_id"].ToString()].ToString());
                                       // storyNum = int.Parse(storageData.Rows[j]["in_set_count"].ToString());
                                    }
                                    else
                                    {
                                        storyNum = 0;
                                    }
                                    storyNum += itemNum;
                                    SortedList sltmpUpLiblary = new SortedList();
                                    sltmpUpLiblary.Add(1, storyNum);
                                    sltmpUpLiblary.Add(2, CnasBaseData.UserID);
                                    sltmpUpLiblary.Add(3, ItemData.Rows[i]["instrument_id"].ToString());
                                    sltmpUpLiblary.Add(4, Sl_type_01_01.GetKey(Sl_type_01_01.IndexOfValue(cb_cost_center.Text)));
                                    sltmpUpLiblaryAll.Add(key, sltmpUpLiblary);
                                    key++;
                                    break;
                                }
                                else
                                {
                                    SortedList sltmpAddLiblary = new SortedList();
                                    sltmpAddLiblary.Add(1, ItemData.Rows[i]["instrument_id"].ToString());
                                    sltmpAddLiblary.Add(2, Sl_type_01_01.GetKey(Sl_type_01_01.IndexOfValue(cb_cost_center.Text)));
                                    sltmpAddLiblary.Add(3, itemNum);
                                    sltmpAddLiblary.Add(4, CnasBaseData.UserID);
                                    sltmpAddLiblaryAll.Add(key, sltmpAddLiblary);
                                    key++;
                                    break;

                                }

                             
                            }
                        }
                        else
                        {
                            SortedList sltmpAddLiblary = new SortedList();
                            sltmpAddLiblary.Add(1, ItemData.Rows[i]["instrument_id"].ToString());
                            sltmpAddLiblary.Add(2, Sl_type_01_01.GetKey(Sl_type_01_01.IndexOfValue(cb_cost_center.Text)));
                            sltmpAddLiblary.Add(3, itemNum);
                            sltmpAddLiblary.Add(4, CnasBaseData.UserID);
                            sltmpAddLiblaryAll.Add(key, sltmpAddLiblary);
                            key++;
                        }
                    }
                }

                #endregion


                sltmp01_01.Add(2, sltmpUpLiblaryAll);
                sltmp01_01.Add(3, sltmpAddLiblaryAll);
                string strrecint = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-costcenter-detail-set-up001", sltmp01_01);
                int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-costcenter-detail-set-up001", sltmp01_01);
                if (recint <= 0)
                {

                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("adddefeat", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cb_RFID.Checked == true)//判断是否打开RFID界面
                {
                    HCSCM_entityset_manager_rfid hcsm = new HCSCM_entityset_manager_rfid(newId.ToString(), this.tb_name.Text);
                    //获取一个值，指是否在Windows任务栏中显示窗体。
                    hcsm.ShowInTaskbar = false;
                    hcsm.ShowDialog();
                }
                Loaddata(arrayDR02[0]["bar_code"].ToString());
                if (dgv_01.Rows.Count > 0)
                {
                    dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.warning, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }




        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void but_remove_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows.Count == 0) return;
            if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "实体包" }), "删除实体包", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int selectedIndex = dgv_01.Rows.IndexOf(dgv_01.SelectedRows[0]);
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-del001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "实体包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void but_point_Click(object sender, EventArgs e)
        {
            HCSCM_set_storage hcsm = new HCSCM_set_storage();
            hcsm.ShowDialog();

            storage = hcsm.StoragePlace;
            if (storage != null && storage.ContainsKey("s_name"))
            {
                tb_point.Text = storage["s_name"].ToString();
            }
        }

        private void onCostcenterChange()
        {

        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            Sl_type_01_01.Clear();

            string str = Sl_type_02_01.GetKey(Sl_type_02_01.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
            SortedList sl_barcode = new SortedList();
            sl_barcode.Add(1, str);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", sl_barcode);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        Sl_type_01_01.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                        //cb_cost_center.Items.Add(new RadListDataItem() { Text = getdt.Rows[i]["ca_name"].ToString().Trim(), Value = getdt.Rows[i]["id"].ToString() });
                    }
                }
            }
            cb_uselocation.Items.Clear();
            Sl_uselocation.Clear();
            SortedList sl_customer = new SortedList();
            sl_customer.Add(1, str);

            DataTable Uselocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec002", sl_customer);//成本中心
            //this.cb_uselocation.Items.Insert(0, "请选择");
            //RadListDataItem cbxItem = new RadListDataItem("0", "请选择");

            //cb_uselocation.Items.Add(cbxItem);
            if (Uselocation != null)
            {

                int ii = Uselocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Uselocation.Rows[i]["id"].ToString() != null && Uselocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        Sl_uselocation.Add(Uselocation.Rows[i]["id"].ToString().Trim(), Uselocation.Rows[i]["u_uname"].ToString().Trim());
                        cb_uselocation.Items.Add(Uselocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
            //cb_uselocation.Text = "请选择";
        }

        private void sp_main_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_cost_center_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            storageData = LoadLibraryData();
        }

        private void cb_cost_center_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

