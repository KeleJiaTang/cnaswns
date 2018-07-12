using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_user_group_new : TemplateForm
    {
        private SortedList sl_type = new SortedList();
        private string Strselectid = "";
        public HCSSM_user_group_new(SortedList SLdata)
        {
            InitializeComponent();//
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新增用户群组";

            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type'");
            foreach (DataRow dr in arrayDR)
            {
                sl_type.Add(dr["value_code"].ToString().Trim(), dr["key_code"].ToString().Trim());
                this.cb_type.Items.Add(dr["value_code"].ToString().Trim());
            }
            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--更新用户群组";
                //lb_info.Text = "用户群组-更新";
                Strselectid = SLdata["id"]==null?string.Empty:SLdata["id"].ToString();
				this.tb_name.Text = SLdata["group_name"] == null ? string.Empty : SLdata["group_name"].ToString();
				this.tb_description.Text = SLdata["group_description"] == null ? string.Empty : SLdata["group_description"].ToString();
				this.cb_type.Text = SLdata["group_typename"] == null ? string.Empty : SLdata["group_typename"].ToString();
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if(tb_name.Text.Trim()=="" || cb_type.Text.Trim()=="")
            {
                MessageBox.Show("对不起，请填写正确信息！！！！");
                return;
            }
            CnasBaseData.If_LoadData = 1;
            if (Strselectid == "")//insert data
            {
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, tb_name.Text.Trim());
                sltmp01.Add(2, sl_type[cb_type.Text.Trim()].ToString());
                sltmp01.Add(3, tb_description.Text.Trim());
                sltmp01.Add(4, CnasBaseData.SystemID);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup-add001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，增加群组成功。");
                    this.Close();
                }
            }else// update data
            {
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, tb_name.Text.Trim());                
                sltmp01.Add(2, tb_description.Text.Trim());
                sltmp01.Add(3, Strselectid);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-usergroup-up001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，更新群组成功。");
                    this.Close();
                }
            }

        }
    }
}
