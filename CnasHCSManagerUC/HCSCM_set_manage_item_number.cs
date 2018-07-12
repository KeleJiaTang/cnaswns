using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
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
    public partial class HCSCM_set_manage_item_number : TemplateForm
    {
        public string Inumber = "1";
        public HCSCM_set_manage_item_number(string getNum)
        {
            InitializeComponent();
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--填写器械数量";
            Inumber = this.tb_number.Text = getNum;

        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void tb_number_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_number.Text.Trim() == "" && this.tb_number.Text.Trim() == "0")
            {
                // 
                this.tb_number.Text = "1";
                //
                return;

            }
            Inumber = this.tb_number.Text.Trim();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            Inumber = this.tb_number.Text.Trim();
            this.Close();
        }
    }
}
