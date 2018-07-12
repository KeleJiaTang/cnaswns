using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_instrument_manage_new : TemplateForm
    {
        private string Strselectid = "";
        private string Instrument_id = "";
        public HCSCM_instrument_manage_new(SortedList SLdata, string ins_id,string ins)
        {
            
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--新建实体器械";
            Instrument_id = ins_id;
            tb_name.Text = HCSCM_instrument_manage.txt;

            if (SLdata != null)
            {
                this.Text = ConfigurationManager.AppSettings["SystemName"] + "--修改实体器械";
                Strselectid = SLdata["id"].ToString();
                tb_name.Text = ins;
                this.tb_rfid.Text = SLdata["ca_rfid"].ToString();
                this.tb_sn.Text = SLdata["sm_num"].ToString();
            }

            }
        private void but_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //“新建”按钮的触发事件
        private void but_ok_Click_1(object sender, EventArgs e)
        {
            if (tb_rfid.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillRFID",EnumPromptMessage.warning),"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            try
            { 
            if (Strselectid == "")
            {
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, tb_rfid.Text.Trim());
                sltmp.Add(2, Instrument_id);
                sltmp.Add(3, tb_sn.Text.Trim());
                sltmp01.Add(1, sltmp);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
               // string ggg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-add001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-add001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful",EnumPromptMessage.warning,new string[]{"实体器械"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                SortedList sttmp01 = new SortedList();
                SortedList sttmp = new SortedList();
                sttmp01.Add(1, tb_rfid.Text.Trim());
                sttmp01.Add(2, tb_sn.Text.Trim());
                sttmp01.Add(3, Strselectid);
                sttmp.Add(1, sttmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-up001", sttmp, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "实体器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lb_rfid_Click(object sender, EventArgs e)
        {

        }
    }
}
