using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReporManagerUC
{
    public partial class HCSRM_custom_template_add : TemplateForm
    {

        int tem_id = 0;
        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        DataTable dtRowDate = new DataTable();


        public HCSRM_custom_template_add(int id)
        {
            InitializeComponent();
            if (id != 0)
                tem_id = id;
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSRM_custom_template_add_Load(object sender, EventArgs e)
        {
            //获取系统名称
            string SystemName = ConfigurationManager.AppSettings["SystemName"].ToString();

            #region Button图标

            this.rbtnSave.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.rbtnClose.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion

            //设置窗体图标
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //设置窗体标题
            this.Text = SystemName + "--模版添加";


            SortedList sellist = new SortedList();
            sellist.Add(1, tem_id);
            //string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-template-sec002", sellist);
            dtRowDate = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-template-sec002", sellist);

            if (dtRowDate == null) dtRowDate = new DataTable();


            //判断是否是修改
            if (tem_id != 0)
            {
                this.Text = SystemName + "--模版修改";

                //如果是修改，但是未返回数据，则直接关闭窗体
                if (dtRowDate.Rows.Count <= 0) this.Close();

                rtxtName.Text = dtRowDate.Rows[0]["tem_name"].ToString();
                rtxtFile.Text = dtRowDate.Rows[0]["filename"].ToString();
                rtxtRemark.Text = dtRowDate.Rows[0]["remark"].ToString();
            }



        }


        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Word2003文件|*.doc|Word2007文件|*.docx|Excel2003文件|*.xls|Excel2007文件|*.xlsx|PPT2007文件|*.pptx|PPT2003文件|*.ppt";


            //可选多项
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //找到文件名比如“1.jpg”前面的那个“\”的位置
                int position = openFile.FileName.LastIndexOf("\\");
                //从完整路径中截取出来文件名“1.jpg”
                string fileName = openFile.FileName.Substring(position + 1);

                rtxtFile.Text = fileName;
                rtxtFile.Tag = openFile.FileName;
            }

        }

        /// <summary>
        /// 关闭本窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSave_Click(object sender, EventArgs e)
        {

            //模版名称为空则提示
            if (string.IsNullOrEmpty(rtxtName.Text))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatename", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //模版文件未传则提示
            if (string.IsNullOrEmpty(rtxtFile.Text))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatefile", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            //模版上传辅助类
            TemFileUploadHelper temFileUploadHelper = new TemFileUploadHelper();
            string fileName = reCnasRemotCall.RemotInterface.Get_SerialNumber(2) + Path.GetExtension(rtxtFile.Text);

            try
            {
                //判断是否是修改
                if (tem_id == 0)
                {
                    FileStream fileStream = File.Open(rtxtFile.Tag.ToString(), FileMode.Open);
                    temFileUploadHelper.UploadTemFile(@"Template\", fileName, fileStream);
                    fileStream.Close();
                    fileStream.Dispose();

                    SortedList addlist = new SortedList();
                    SortedList addlist01 = new SortedList();
                    addlist.Add(1, rtxtName.Text);
                    addlist.Add(2, rtxtFile.Text);
                    addlist.Add(3, DateTime.Now);
                    addlist.Add(4, rtxtRemark.Text);
                    addlist.Add(5, fileName);
                    addlist01.Add(1, addlist);

                    //string ss = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-custom-template-add001", addlist01, null);
                    int addDataService = reCnasRemotCall.RemotInterface.UPData(1, "HCS-custom-template-add001", addlist01, null);

                    if (addDataService > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("succeed", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                else
                {

                    //如果是修改，但是未返回数据，则直接关闭窗体
                    if (dtRowDate.Rows.Count <= 0) this.Close();

                    //如果文件不一样，则说明重新上传了文件，则重新上传一次
                    if (dtRowDate.Rows[0]["filename"].ToString() != rtxtFile.Text)
                    {
                        temFileUploadHelper.DeleteTemFile(@"Template\", dtRowDate.Rows[0]["guidname"].ToString());

                        FileStream fileStream = File.Open(rtxtFile.Tag.ToString(), FileMode.Open);
                        temFileUploadHelper.UploadTemFile(@"Template\", fileName, fileStream);
                        fileStream.Close();
                        fileStream.Dispose();
                    }

                    SortedList uplist = new SortedList();
                    SortedList uplist01 = new SortedList();
                    uplist.Add(1, rtxtName.Text);
                    uplist.Add(2, rtxtFile.Text);
                    uplist.Add(3, DateTime.Now);
                    uplist.Add(4, rtxtRemark.Text);
                    uplist.Add(5, fileName);
                    uplist.Add(6, tem_id);
                    uplist01.Add(1, uplist);

                    string ss = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-custom-template-up001", uplist01, null);
                    int UpDataService = reCnasRemotCall.RemotInterface.UPData(1, "HCS-custom-template-up001", uplist01, null);

                    if (UpDataService > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("editsucceed", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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




    }
}
