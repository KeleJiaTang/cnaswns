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
    public partial class HCSCM_set_size : TemplateForm
    {
        public string Length = "";
        public string Weidth = "";
        public string Hight = "";
        public string Stu = "";
        private double sum = 1;
        public HCSCM_set_size(string L,string W,string H,string S)
        {
            Length = L;
            Weidth = W;
            Hight = H;
            Stu = S;
            InitializeComponent();
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--STU换算";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();

            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_set_size'");//包的大小
            foreach (DataRow dr in arrayDR)
            {

                sum *= Convert.ToDouble(dr["value_code"].ToString());
            }
            tb_hight.Text = H;
            tb_width.Text = W;
            tb_length.Text = L;
            tb_stu.Text = S;

        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改

            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ISNumber的作用是判断输入按键是否为数字
            //（char）8是退格键的健值，可允许用户敲退格键对输入的数字进行修改
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tb_stu.Text = "0.000";
            if (tb_length.Text.Trim() == "")
            {
                // 
                tb_length.Text = "0";
                //
                return;

            }
            if (tb_hight.Text.Trim() != "0" && tb_length.Text.Trim() != "0" && tb_width.Text.Trim() != "0")
            {
                 
               Stu=tb_stu.Text = Math.Round(Convert.ToDouble(tb_hight.Text.Trim()) * Convert.ToDouble(tb_length.Text.Trim()) * Convert.ToDouble(tb_width.Text.Trim()) / sum,4).ToString();
            }
            Length =tb_length.Text.Trim();
        }

        private void tb_width_TextChanged(object sender, EventArgs e)
        {
            tb_stu.Text = "0.000";
            if (tb_width.Text.Trim() == "")
            {
                tb_width.Text = "0";
                return;
            }

            if (tb_hight.Text.Trim() != "0" && tb_length.Text.Trim() != "0" && tb_width.Text.Trim() != "0" )
            {
                Stu=tb_stu.Text = Math.Round(Convert.ToDouble(tb_hight.Text.Trim()) * Convert.ToDouble(tb_length.Text.Trim()) * Convert.ToDouble(tb_width.Text.Trim()) / sum, 4).ToString();

            }
            Weidth = tb_width.Text.Trim();
        }

        private void tb_hight_TextChanged(object sender, EventArgs e)
        {
            tb_stu.Text = "0.000";
            if(tb_hight.Text.Trim() == "")
            {
                tb_hight.Text = "0";
                return;
            }

            if (tb_hight.Text.Trim() != "0" && tb_length.Text.Trim() != "0" && tb_width.Text.Trim() != "0" )
            {
                Stu=tb_stu.Text = Math.Round(Convert.ToDouble(tb_hight.Text.Trim()) * Convert.ToDouble(tb_length.Text.Trim()) * Convert.ToDouble(tb_width.Text.Trim()) / sum, 4).ToString();

            }
            Hight =tb_hight.Text.Trim();
        }
    }
}
