using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns
{
    public partial class Login : Form
    {
        /// <summary>
        /// 主窗体加载前的欢迎窗体
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        Timer timer1 = new Timer();
        private void Login_Load(object sender, EventArgs e)
        {
            //设置窗体图标
            this.BackgroundImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "welcomeBackImg", EnumImageType.PNG);

            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));




            this.timer1.Interval = 100;
            this.timer1.Tick += timer1_Tick;
            this.timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (radProgressBar1.Value1 < radProgressBar1.Maximum)
            {
                radProgressBar1.Value1++;
            }
        }



        /// <summary>
        /// 用户关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// 用户关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
