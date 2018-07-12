using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    public partial class DownloadConfirm : Form
    {


        const string FILENAME = "update.config";


        List<DownloadFileInfo> downloadFileList = null;

        public DownloadConfirm(List<DownloadFileInfo> dfl)
        {
            InitializeComponent();

            downloadFileList = dfl;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString() });
                this.listDownloadFile.Items.Add(item);
            }

            this.Activate();
            this.Focus();
        }



        /// <summary>
        /// 判断用户是否做过点击更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("更新将强制关闭已经打开的程序，是否继续!", "警告提醒", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                //关掉主程序
                OperProcess oper = new OperProcess();
                oper.InitUpdateEnvironment();


                Config config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
                config.IsUpdate = true;
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));


            }
           
        }

       
        /// <summary>
        /// 点击稍后更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {

            //关掉主程序，还是先杀掉以前的进程，避免出现死进程
            OperProcess oper = new OperProcess();
            oper.InitUpdateEnvironment();


        }


    }
}