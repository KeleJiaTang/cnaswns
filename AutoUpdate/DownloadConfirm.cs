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
        /// �ж��û��Ƿ�����������²���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("���½�ǿ�ƹر��Ѿ��򿪵ĳ����Ƿ����!", "��������", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                //�ص�������
                OperProcess oper = new OperProcess();
                oper.InitUpdateEnvironment();


                Config config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
                config.IsUpdate = true;
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));


            }
           
        }

       
        /// <summary>
        /// ����Ժ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {

            //�ص������򣬻�����ɱ����ǰ�Ľ��̣��������������
            OperProcess oper = new OperProcess();
            oper.InitUpdateEnvironment();


        }


    }
}