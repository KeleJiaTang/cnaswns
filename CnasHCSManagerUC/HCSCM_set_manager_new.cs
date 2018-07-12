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
    public partial class HCSCM_set_manager_new : TemplateForm
    {
        private SortedList sl_type_01 = new SortedList();//存放清洗程序
        private SortedList sl_type_02 = new SortedList();//存放包装材料
        private SortedList sl_type_03 = new SortedList();//存放客户(barcode与名字)
        private SortedList sl_type_03_01 = new SortedList();//存放客户(id与名字)，感觉没必要！！！
        private SortedList sl_type_04 = new SortedList();//存放成本中心
        private SortedList sl_type_05 = new SortedList();//存放摆放类型
        private SortedList sl_type_06 = new SortedList();//存放灭菌程序
        private SortedList sl_type_07 = new SortedList();//存放包的类型
        private SortedList sl_type_08 = new SortedList();//存放包的清洗等级
        private string Length = "300";//长
        private string Weidth = "500";//宽
        private string Hight = "300";//包的高
        private string Stu = "1.000";//Stu
        private string Selectid = "";//被选择的id
        private string Strselectname = "";
        private string order_set = "";//是否为订单包

        //  public bool ifOrderSetSuccess;//判断创建订单包时，是否成功
        /// 创建数据
        /// </summary>
        /// <param name="SLdata">基本包修改的信息</param>
        /// <param name="iforder">是否为订单包</param>
        public HCSCM_set_manager_new(SortedList SLdata, string iforder)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            if (iforder == "1")
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建订单包";
                this.lb_minimum_set.Visible = false;
                this.tb_minimum_set.Visible = false;
                this.cb_RFID.Visible = false;
                this.lb_priority.Visible = false;
                this.rb_vurgent.Visible = false;
                this.rb_urgent.Visible = false;
                this.rb_normal.Visible = false;
                this.groupBox1.Visible = false;
            }
            else
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建基本包";
            }

            order_set = iforder;//赋值，是否为订单包
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] arrayDR = null;
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-program-sec001", null);//清洗程序
            if (getdt != null)
            {

                sl_type_01.Add("0", "无清洗程序");
                this.cb_washing.Items.Add("无清洗程序");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_01.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["pr_name"].ToString().Trim());
                        cb_washing.Items.Add(getdt.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("hcs-setmaterial-type-sec002", null);//打包材料
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null && getdt.Rows[i]["expiration_day"].ToString().Trim() != null)
                    {
                        sl_type_02.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        sl_type_02.Add(getdt.Rows[i]["ca_name"].ToString().Trim(), getdt.Rows[i]["expiration_day"].ToString().Trim());
                        cb_material.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
                    {
                        sl_type_03_01.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        sl_type_03.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                        cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }


            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_put_type'");//摆放类型
            foreach (DataRow dr in arrayDR)
            {

                sl_type_05.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_put.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);//灭菌程序
            if (getdt != null)
            {

                sl_type_06.Add("0", "无灭菌程序");
                this.cb_sterilizer.Items.Add("无灭菌程序");
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_06.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["pr_name"].ToString().Trim());
                        cb_sterilizer.Items.Add(getdt.Rows[i]["pr_name"].ToString().Trim());
                    }
                }
            }

            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_type'");//包的类型
            foreach (DataRow dr in arrayDR)
            {
                sl_type_07.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }


            arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_complexity'");//包的清洗等级
            foreach (DataRow dr in arrayDR)
            {

                sl_type_08.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                this.cb_complexity.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            if (SLdata != null)
            {
                if (iforder == "1")
                {
                    this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改订单包";
                }
                else
                {
                    this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改基本包";
                }


                Selectid = SLdata["id"].ToString();
                tb_barcode.Text = SLdata["bar_code"].ToString();
                tb_expiration.Text = SLdata["ca_expiration"].ToString();
                Strselectname = tb_name.Text = SLdata["ca_name"].ToString();
                tb_price.Text = SLdata["handle_price"].ToString();//.Substring(1, SLdata["handle_price"].ToString().Length - 1);
                tb_remarks.Text = SLdata["ca_remarks"].ToString();
                tb_size.Text = SLdata["ca_size"].ToString();
                tb_times.Text = SLdata["ca_times"].ToString();
                tb_weight.Text = SLdata["ca_weight"].ToString();
                cb_complexity.Text = sl_type_08.GetKey(sl_type_08.IndexOfValue(SLdata["ca_complexity"].ToString())).ToString() + ":" + SLdata["ca_complexity"].ToString();
                cb_customer.Text = sl_type_03[SLdata["customer_code"].ToString()].ToString();
                cb_cost_center.Text = SLdata["cost_center"].ToString();
                cb_material.Text = sl_type_02[SLdata["ca_material"].ToString()].ToString();
                cb_put.Text = SLdata["put_type"].ToString() + ":" + sl_type_05[SLdata["put_type"].ToString()].ToString();
                cb_type.Text = sl_type_07.GetKey(sl_type_07.IndexOfValue(SLdata["ca_type"].ToString())) + ":" + SLdata["ca_type"].ToString();
                cb_sterilizer.Text = sl_type_06.ContainsKey(SLdata["sterilizer_type"].ToString()) ? sl_type_06[SLdata["sterilizer_type"].ToString()].ToString() : string.Empty;
                cb_washing.Text = sl_type_01[SLdata["washing_type"].ToString()].ToString();

                if (tb_minimum_set.Visible == false)
                    tb_minimum_set.Text = SLdata["minimum_set"].ToString();

                if (cb_type.Text.Trim() == "2:特殊器械包")
                {
                    cb_if.Visible = true;
                    cb_type.Enabled = false;//不允许修改特殊包类型
                }
                if (SLdata["ca_priority"].ToString() == "1")
                {
                    rb_normal.Checked = true;
                }
                else if (SLdata["ca_priority"].ToString() == "2")
                {
                    rb_urgent.Checked = true;
                }
                else
                {
                    rb_vurgent.Checked = true;
                }
                if (SLdata["classify"].ToString() == "1")//是否为院内包
                {
                    cb_if.Checked = true;
                }
                else
                {
                    cb_if.Checked = false;
                }
                if (SLdata["rfid_retrospect"].ToString() == "1")//true则须要RFID追溯
                {
                    cb_RFID.Checked = true;
                }
                else
                {
                    cb_RFID.Checked = false;
                }

                string str = tb_size.Text;
                string[] sArray = str.Split('x');
                tb_stu.Text = Calculation_stu(sArray[0], sArray[1], sArray[2]);
                Length = sArray[0].ToString();
                Weidth = sArray[1].ToString();
                Hight = sArray[2].ToString();
                #region 修改时单包锁定
                if (cb_type.Text == "3:单器械包")
                {
                    Strselectname = tb_name.Text = SLdata["ca_name"].ToString();
                    tb_name.Enabled = false;
                    cb_type.Enabled = false;
                }
                else
                {
                    Strselectname = tb_name.Text = SLdata["ca_name"].ToString();

                }
                #endregion
            }

        }
        /// <summary>
        /// 输入长宽高，计算出STU
        /// </summary>
        /// <param name="L">长</param>
        /// <param name="W">宽</param>
        /// <param name="H">高</param>
        /// <returns></returns>
        private string Calculation_stu(string L, string W, string H)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            double sum = 1;
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_size'");//包的大小
            foreach (DataRow dr in arrayDR)
            {

                sum *= Convert.ToDouble(dr["value_code"].ToString());
            }
            Stu = Math.Round(Convert.ToDouble(H) * Convert.ToDouble(L) * Convert.ToDouble(W) / sum, 4).ToString();
            return Stu;
        }

        private void tb_remarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_input_Click(object sender, EventArgs e)
        {

            HCSCM_set_size hcsm = new HCSCM_set_size(Length, Weidth, Hight, Stu);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Length = hcsm.Length;
            Weidth = hcsm.Weidth;
            Hight = hcsm.Hight;
            Stu = hcsm.Stu;
            tb_size.Text = Length + "x" + Weidth + "x" + Hight;
            tb_stu.Text = Stu;


        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {

            if (this.tb_name.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillname", EnumPromptMessage.warning, new string[] { "" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


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
            if (this.cb_material.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillmaterial", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_price.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillprice", EnumPromptMessage.warning, new string[] { "处理" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (this.cb_put.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillput", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_weight.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillweight", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_stu.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillsize", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_washing.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillwastype", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_sterilizer.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillstrtype", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_complexity.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filldifficulty", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cb_type.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "包的" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_times.Text.Trim() == "")
            {
                tb_times.Text = "";
            }
            if (tb_minimum_set.Text.Trim() == "")
            {
                tb_minimum_set.Text = "";
            }
            try
            {

                if (Selectid == "")
                {
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    #region 判断名字是否存在
                    if (order_set == "1")//判断是否是订单包
                    {

                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, CnasBaseData.SystemID);
                        sttemp01.Add(2, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));
                        sttemp01.Add(3, "1");
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec050", sttemp01);//503
                        if (getdt != null)
                        {
                            DataRow[] getdt_01 = getdt.Select();
                            foreach (DataRow dr in getdt_01)
                            {


                                if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {

                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, CnasBaseData.SystemID);
                        sttemp01.Add(2, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));
                        sttemp01.Add(3, "0");
                        string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec050", sttemp01);
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec050", sttemp01);//503
                        if (getdt != null)
                        {
                            DataRow[] getdt_01 = getdt.Select();
                            foreach (DataRow dr in getdt_01)
                            {


                                if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }

                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());//名字
                    sltmp.Add(2, tb_barcode.Text.Trim());//条码
                    sltmp.Add(3, tb_expiration.Text.Trim());//保质期
                    sltmp.Add(4, tb_price.Text.Trim());//价格
                    sltmp.Add(5, tb_remarks.Text.Trim());//备注
                    sltmp.Add(6, tb_size.Text.Trim());//大小
                    if (tb_times.Text.Trim() == "")
                    {
                        sltmp.Add(7, "NULL");//使用次数
                    }
                    else
                    {
                        sltmp.Add(7, tb_times.Text.Trim());//使用次数
                    }

                    sltmp.Add(8, tb_weight.Text.Trim());//重量
                    sltmp.Add(9, cb_complexity.Text.Trim().Substring(0, 1));//清洗难度
                    sltmp.Add(10, cb_type.Text.Trim().Substring(0, 1));//包的类型
                    sltmp.Add(11, sl_type_04.GetKey(sl_type_04.IndexOfValue(cb_cost_center.Text.Trim())));//成本中心
                    sltmp.Add(12, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));//顾客
                    sltmp.Add(13, sl_type_02.GetKey(sl_type_02.IndexOfValue(cb_material.Text.Trim())));//打包材料
                    sltmp.Add(14, cb_put.Text.Trim().Substring(0, 1));//摆放方式
                    sltmp.Add(15, sl_type_06.GetKey(sl_type_06.IndexOfValue(cb_sterilizer.Text.Trim())));//灭菌类型
                    sltmp.Add(16, sl_type_01.GetKey(sl_type_01.IndexOfValue(cb_washing.Text.Trim())));//清洗类型

                    if (this.rb_normal.Checked)
                    {
                        sltmp.Add(17, 1);//为正常包
                    }
                    else if (this.rb_urgent.Checked)
                    {
                        sltmp.Add(17, 2);//为紧急包
                    }
                    else
                    {
                        sltmp.Add(17, 3);//为非常紧急包
                    }
                    sltmp.Add(18, CnasBaseData.SystemID);
                    sltmp.Add(19, CnasBaseData.UserName);//创建人
                    if (this.cb_if.Checked)//是否为院内特殊包
                    {
                        sltmp.Add(20, 1);
                    }
                    else
                    {
                        sltmp.Add(20, 0);
                    }
                    sltmp.Add(21, order_set);
                    if (tb_minimum_set.Text == "")
                    {
                        sltmp.Add(22, "NULL");
                    }
                    else
                    {
                        sltmp.Add(22, tb_minimum_set.Text);
                    }

                    if (this.cb_RFID.Checked)//是否须要RFID追溯
                    {
                        sltmp.Add(23, 1);
                    }
                    else
                    {
                        sltmp.Add(23, 0);
                    }

                    sltmp01.Add(1, sltmp);

                    // string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-base-add001", sltmp01, null);
                    if (recint > -1)
                    {
                        if (order_set == "1")
                        {

                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    else
                    {

                        MessageBox.Show("对不起，系统增加出错，请联系管理员。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    if (order_set == "0")
                    {
                        string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec003", null);
                        DataTable getdt2 = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec003", null);//查询基本包最后创建的信息，取id121
                        string strid = "";
                        if (getdt2 != null)
                        {
                            DataRow arrayDR = getdt2.Select()[0];
                            strid = arrayDR["id"].ToString().Trim();

                            SortedList slindata = new SortedList();
                            slindata.Add("ca_name", tb_name.Text.Trim());
                            slindata.Add("id", arrayDR["id"].ToString().Trim());
                            slindata.Add("ca_type", cb_type.Text.Trim().Substring(0, 1));
                            slindata.Add("cost_center", sl_type_04.GetKey(sl_type_04.IndexOfValue(cb_cost_center.Text)).ToString());
                            slindata.Add("customer_code", sl_type_03_01.GetKey(sl_type_03_01.IndexOfValue(cb_customer.Text)).ToString());
                            //string strname = tb_name.Text.Trim();
                            //string strtype = cb_type.Text.Trim().Substring(0, 1);
                            //string strcc = sl_type_04.GetKey(sl_type_04.IndexOfValue(cb_cost_center.Text)).ToString();
                            HCSCM_set_manager_item hcsm = new HCSCM_set_manager_item(slindata, true);
                            hcsm.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec003", null);
                        DataTable getdt2 = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec003", null);//查询基本包最后创建的信息，取id121
                        string strid = "";
                        if (getdt2 != null)
                        {
                            DataRow arrayDR = getdt2.Select()[0];
                            strid = arrayDR["id"].ToString().Trim();
                            SortedList aa = new SortedList();
                            aa.Add("name", tb_name.Text.Trim());
                            aa.Add("id", arrayDR["id"].ToString().Trim());
                            aa.Add("type", cb_type.Text.Trim().Substring(0, 1));
                            aa.Add("customer", sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text)));
                            aa.Add("customerid", sl_type_03_01.GetKey(sl_type_03_01.IndexOfValue(cb_customer.Text)));
                            aa.Add("costcentername", sl_type_04.GetKey(sl_type_04.IndexOfValue(cb_cost_center.Text)));
                            aa.Add("costcenter", cb_cost_center.Text);
                            bool iswindows = false;
                            HCSCM_specialset_item_add HCSR = new HCSCM_specialset_item_add(aa, iswindows);
                            HCSR.ShowDialog();
                            this.Close();

                        }

                    }
                }
                else
                {
                    #region 判断名字是否存在
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    if (this.tb_name.Text.Trim() != Strselectname)
                    {
                        if (order_set == "1")//判断是否是订单包
                        {

                            SortedList sttemp01 = new SortedList();
                            sttemp01.Add(1, CnasBaseData.SystemID);
                            sttemp01.Add(2, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));
                            sttemp01.Add(3, "1");
                            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec050", sttemp01);//503
                            if (getdt != null)
                            {
                                DataRow[] getdt_01 = getdt.Select();
                                foreach (DataRow dr in getdt_01)
                                {


                                    if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {

                            SortedList sttemp01 = new SortedList();
                            sttemp01.Add(1, CnasBaseData.SystemID);
                            sttemp01.Add(2, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));
                            sttemp01.Add(3, "0");
                            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec050", sttemp01);//503
                            if (getdt != null)
                            {
                                DataRow[] getdt_01 = getdt.Select();
                                foreach (DataRow dr in getdt_01)
                                {


                                    if (tb_name.Text.Trim().ToString() == dr["ca_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp.Add(1, tb_name.Text.Trim());//名字

                    sltmp.Add(2, tb_expiration.Text.Trim());//保质期
                    sltmp.Add(3, tb_price.Text.Trim());//价格
                    sltmp.Add(4, tb_remarks.Text.Trim());//备注

                    sltmp.Add(5, tb_size.Text.Trim());//大小
                    if (tb_times.Text.Trim() == "")
                    {
                        sltmp.Add(6, "NULL");//使用次数
                    }
                    else
                    {
                        sltmp.Add(6, tb_times.Text.Trim());//使用次数
                    }

                    sltmp.Add(7, tb_weight.Text.Trim());//重量
                    sltmp.Add(8, cb_complexity.Text.Trim().Substring(0, 1));//清洗难度
                    sltmp.Add(9, cb_type.Text.Trim().Substring(0, 1));//包的类型
                    sltmp.Add(10, sl_type_04.GetKey(sl_type_04.IndexOfValue(cb_cost_center.Text.Trim())));//成本中心
                    sltmp.Add(11, sl_type_03.GetKey(sl_type_03.IndexOfValue(cb_customer.Text.Trim())));//顾客
                    sltmp.Add(12, sl_type_02.GetKey(sl_type_02.IndexOfValue(cb_material.Text.Trim())));//打包材料
                    sltmp.Add(13, cb_put.Text.Trim().Substring(0, 1));//摆放方式
                    sltmp.Add(14, sl_type_06.GetKey(sl_type_06.IndexOfValue(cb_sterilizer.Text.Trim())));//灭菌类型
                    sltmp.Add(15, sl_type_01.GetKey(sl_type_01.IndexOfValue(cb_washing.Text.Trim())));//清洗类型
                    if (this.rb_normal.Checked)
                    {
                        sltmp.Add(16, 1);//为正常包
                    }
                    else if (this.rb_urgent.Checked)
                    {
                        sltmp.Add(16, 2);//为紧急包
                    }
                    else
                    {
                        sltmp.Add(16, 3);//为非常紧急包
                    }
                    sltmp.Add(17, CnasBaseData.UserName);
                    if (this.cb_if.Checked)
                    {
                        sltmp.Add(18, 1);
                    }
                    else
                    {
                        sltmp.Add(18, 0);
                    }
                    sltmp.Add(19, order_set);
                    if (tb_minimum_set.Text == "")
                    {
                        sltmp.Add(20, "NULL");
                    }
                    else
                    {
                        sltmp.Add(20, tb_minimum_set.Text);
                    }

                    if (this.cb_RFID.Checked)//是否须要RFID追溯
                    {
                        sltmp.Add(21, 1);
                    }
                    else
                    {
                        sltmp.Add(21, 0);
                    }
                    sltmp.Add(22, Selectid);

                    sltmp01.Add(1, sltmp);
                    //  string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-up001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-base-up001", sltmp01, null);
                    if (recint > -1)
                    {
                        if (order_set == "1")
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "订单包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("对不起，系统修改出错，请联系管理员。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("unknowerror", EnumPromptMessage.error, new string[] { ex.Message }), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }



        private void tb_minimum_set_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }





        private void tb_price_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (tb_price.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(tb_price.Text, out oldf);
                    b2 = float.TryParse(tb_price.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }

                }

            }
        }

        private void tb_weight_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (tb_weight.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(tb_weight.Text, out oldf);
                    b2 = float.TryParse(tb_weight.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }

                }

            }
        }

        private void tb_times_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void cb_material_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            foreach (string i in sl_type_02.GetKeyList())
            {
                if (cb_material.SelectedItem.ToString() == i)//选择打包材料，对应的保质日期显示出来
                {
                    tb_expiration.Text = sl_type_02[cb_material.Text].ToString();
                }
            }
        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            this.cb_cost_center.Items.Clear();
            sl_type_04.Clear();
            string str = sl_type_03_01.GetKey(sl_type_03_01.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id条码
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
                    if (getdt.Rows[i]["bar_code"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_type_04.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                        this.cb_cost_center.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
        }

        private void cb_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cb_type.Text.Trim() == "2:特殊器械包")
            {
                cb_if.Visible = true;
                cb_if.Checked = true;
            }
            else
            {
                cb_if.Visible = false;
                cb_if.Checked = false;
            }
        }

    }
}

//        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (tb_name.Text!=null)
//            {
//                cb_type.Text = "3:单器械包";
//            }
//        }
//    }
//}
