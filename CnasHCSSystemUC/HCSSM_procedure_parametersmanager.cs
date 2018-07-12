using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Text.RegularExpressions;
using CnasUI;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_procedure_parametersmanager : TemplateForm
    {
        public HCSSM_procedure_parametersmanager()
        {
            InitializeComponent();
            this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--新增参数";
        }

        private void but_05_Click(object sender, EventArgs e)
        {
            if (tb_11.Text.Trim() == "" || tb_12.Text.Trim() == "" || tb_13.Text.Trim() == "" || tb_14.Text.Trim() == "" || cb_par02.Text == "")
            {
                MessageBox.Show("对不起，请填写正确信息！！！！");
                return;
            }
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, tb_11.Text.Trim());
            sltmp01.Add(2, tb_12.Text.Trim());
            sltmp01.Add(3, tb_13.Text.Trim());
            sltmp01.Add(4, cb_par02.Text.Substring(0, 1));
            sltmp01.Add(5, tb_14.Text.Trim());
            sltmp01.Add(6, CnasBaseData.SystemID);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-pdparameter-add01", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，增加流程参数成功。");
                this.Close();
            }
            else
            {
                MessageBox.Show("对不起，增加流程参数失败，可能是编码重复。");
            }
        }
    }
}
