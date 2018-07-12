using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_operational_costs_new : TemplateForm
    {
        private SortedList sl_type = new SortedList();
        private SortedList sl_user = new SortedList();
        string stratr = "";//用于判断新建和修改（=“”时为新建数据，有值时为修改数据）
        public HCSRS_operational_costs_new(SortedList slttmp)
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新增运营成本";
            //this.Font = new Font(this.Font.FontFamily, 11);
            //给月份下拉列表赋值
            for (int i = 0; i < 3; i++)
            {
                cb_time.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyy-MM"));
            }

            cb_time.SelectedIndex = 0;//月份初始化时的默认值

            tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            //获取成本类型的数据
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-operationalcosts-type'");
            foreach (DataRow dr in typeDR)
            {
                sl_type.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
                cb_type.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);
            //获取用户表的数据
            DataTable User = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sltmp);
            if (User != null)
            {
                int kk = User.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (User.Rows[i]["id"].ToString() != null && User.Rows[i]["user_name"].ToString() != null)
                    {
                        sl_user.Add(User.Rows[i]["id"].ToString(), User.Rows[i]["user_name"].ToString());
                    }
                }
            }
            //修改时给界面获取原本数据
            if (slttmp != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改运营成本";
                stratr = slttmp["id"].ToString();
                cb_type.Text = sl_type.GetKey(sl_type.IndexOfValue(slttmp["type"].ToString())).ToString() + ":" + slttmp["type"].ToString();
                cb_time.Text = slttmp["time"].ToString();
                tb_money.Text = slttmp["money"].ToString();
				tb_remark.Text = slttmp["remark"] == null?string.Empty:slttmp["remark"].ToString();
            }
        }
        /// <summary>
        /// 确定按钮事件
        /// </summary>
        private void but_ok_Click(object sender, EventArgs e)
        {
           
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void but_ok_Click_1(object sender, EventArgs e)
        {
            if (cb_type.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("filltype", EnumPromptMessage.warning, new string[] { "成本" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable DTtype = null;
            SortedList sltemp = new SortedList();
            sltemp.Add(1, DateTime.Parse(cb_time.Text.ToString()));
            if (stratr == "")
            {
                string gs = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-operating-cost-sec005", sltemp);
                DTtype = reCnasRemotCall.RemotInterface.SelectData("HCS-operating-cost-sec005", sltemp);
            }
            else
            {
                sltemp.Add(2, stratr);
                string gs = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-operating-cost-sec006", sltemp);

                DTtype = reCnasRemotCall.RemotInterface.SelectData("HCS-operating-cost-sec006", sltemp);
            }
            if (DTtype != null && DTtype.Rows.Count > 0)
            {
                for (int i = 0; i < DTtype.Rows.Count; i++)
                {
                    if (cb_type.Text.Substring(0, 1) == DTtype.Rows[i]["operation_type"].ToString())
                    {
                        MessageBox.Show("该月的费用类型已有数据,请重新选择", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if (tb_money.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillmoney", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (stratr == "")
            {
                // CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList slttmp = new SortedList();
                SortedList slttmp01 = new SortedList();
                slttmp.Add(1, cb_type.Text.Trim().Substring(0, 1));
                slttmp.Add(2, tb_money.Text.Trim());
                slttmp.Add(3, DateTime.Parse(cb_time.Text.ToString()));
                slttmp.Add(4, sl_user.GetKey(sl_user.IndexOfValue(CnasBaseData.UserName)));
                slttmp.Add(5, tb_remark.Text.Trim());
                slttmp01.Add(1, slttmp);
                string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-operatingcost-add001", slttmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-operatingcost-add001", slttmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "运营成本" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else//修改
            {
                SortedList sttemp = new SortedList();
                SortedList sttemp01 = new SortedList();
                sttemp.Add(1, cb_type.Text.Trim().Substring(0, 1));
                sttemp.Add(2, tb_money.Text.Trim());
                sttemp.Add(3, DateTime.Parse(cb_time.Text.ToString()));
                sttemp.Add(4, sl_user.GetKey(sl_user.IndexOfValue(CnasBaseData.UserName)));
                sttemp.Add(5, stratr);
                sttemp01.Add(1, sttemp);
                // CnasRemotCall reCnasRemotCall=new CnasRemotCall();
                string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-operatingcost-up001", sttemp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-operatingcost-up001", sttemp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "运营成本" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_money_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }
    }
}
