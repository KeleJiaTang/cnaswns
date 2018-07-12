using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReporManagerUC
{
    public partial class HCSRM_custom_template_report_add : TemplateForm
    {

        int custom_tem_id = 0;
        int id = 0;

        //存储模版数据
        DataTable dtTemRowDate = new DataTable();


        DataTable dtRowDate = new DataTable();


        //获取系统名称
        string SystemName = ConfigurationManager.AppSettings["SystemName"].ToString();

        //数据访问
        CnasRemotCall reCnasRemotCall = new CnasRemotCall();

        private AxDSOFramer.AxFramerControl axFramerControl = new AxDSOFramer.AxFramerControl();


        Thread thOpen;


        /// <summary>
        /// 传入模版Id，则为新增，传入id则为修改
        /// </summary>
        /// <param name="custom_tem_id"></param>
        /// <param name="id"></param>
        public HCSRM_custom_template_report_add(int custom_tem_id, int id)
        {
            InitializeComponent();

            this.custom_tem_id = custom_tem_id;
            this.id = id;



        }

        private HCSRM_custom_template_report HCSRM_custom_template_report01 = null;

        public HCSRM_custom_template_report_add(int custom_tem_id, int id, HCSRM_custom_template_report repparent)
        {
            InitializeComponent();

            this.custom_tem_id = custom_tem_id;
            this.id = id;

            HCSRM_custom_template_report01 = repparent;



        }



        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSRM_custom_template_report_add_Load(object sender, EventArgs e)
        {
            Init("");

            //thOpen = new Thread(new ThreadStart(FOpen));
            //((System.ComponentModel.ISupportInitialize)(this.axFramerControl)).BeginInit();
            //axFramerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            //axFramerControl.Enabled = true;
            //axFramerControl.Location = new System.Drawing.Point(0, 0);

            //this.scmain.Panel2.Controls.Add(axFramerControl);

            //((System.ComponentModel.ISupportInitialize)(this.axFramerControl)).EndInit();


            ////启动现成加载EXCEL
            //thOpen.Start();




            #region Button图标

            this.rbtnSave.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.rbtnClose.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.rbtnPrint.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            #endregion


            //设置窗体图标
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //设置窗体标题
            this.Text = SystemName + "--报表添加";

            this.axFramerControl.Titlebar = false;
            this.axFramerControl.Menubar = false;
            this.axFramerControl.Toolbars = true;


            //修改报表
            if (custom_tem_id == 0 && id != 0)
            {
                //设置窗体标题
                this.Text = SystemName + "--修改报表";

            }



            DataBind();
        }






        //private void FOpen()
        //{

        //    lock (axFramerControl)
        //    {
        //        try
        //        {


        //            DataBind();


        //        }
        //        catch { }

        //    }
        //}





        /// <summary>
        /// usercontrol控件初始化
        /// </summary>
        /// <param name="_sFilePath">本地文件全路径</param>
        public void Init(string _sFilePath)
        {
            try
            {
                RegControl();//注册控件
                //if (!CheckFile(_sFilePath))//判断是否为所支持的office文件
                //{
                //    throw new ApplicationException("文件不存在或未标识的文件格式!");
                //}
                AddOfficeControl();
                //这里一定要先把dso控件加到界面上才能初始化dso控件,
                //这个dso控件在没有被show出来之前是不能进行初始化操作的,很奇怪为什么作者这样考虑.....
                //InitOfficeControl(_sFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegControl()
        {
            try
            {
                Assembly thisExe = Assembly.GetExecutingAssembly();
                System.IO.Stream myS = thisExe.GetManifestResourceStream("NameSpaceName.dsoframer.ocx");

                string sPath = System.Environment.CurrentDirectory + @"/dsoframer.ocx";

                //MessageBox.Show(sPath);

                //ProcessStartInfo psi = new ProcessStartInfo("regsvr32", "/s " + sPath);
                //Process.Start(psi);

                //System.Diagnostics.Process.Start("cmd.exe", "/c regsvr32 " + sPath);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }


        /// <summary>
        /// 添加控件
        /// </summary>
        private void AddOfficeControl()
        {
            try
            {
                this.scmain.Panel2.Controls.Add(axFramerControl);
                axFramerControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 初始化office控件
        /// </summary>
        /// <param name="_sFilePath">本地文档路径</param>
        private void InitOfficeControl(string _sFilePath)
        {
            try
            {
                if (axFramerControl == null)
                {
                    throw new ApplicationException("请先初始化office控件对象！");
                }

                //this.m_axFramerControl.SetMenuDisplay(48);
                //这个方法很特别，一个组合菜单控制方法，我还没有找到参数的规律，有兴趣的朋友可以研究一下
                string sExt = System.IO.Path.GetExtension(_sFilePath).Replace(".", "");
                //this.m_axFramerControl.CreateNew(this.LoadOpenFileType(sExt));//创建新的文件
                this.axFramerControl.Open(_sFilePath, false, this.LoadOpenFileType(sExt), "", "");//打开文件
                //隐藏标题
                this.axFramerControl.Titlebar = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据后缀名得到打开方式,下面这个方法是dso打开文件时需要的一个参数，代表office文件类型
        /// </summary>
        /// <param name="_sExten"></param>
        /// <returns></returns>
        private string LoadOpenFileType(string _sExten)
        {
            try
            {
                string sOpenType = "";
                switch (_sExten.ToLower())
                {
                    case "xls":
                        sOpenType = "Excel.Sheet";
                        break;
                    case "doc":
                        sOpenType = "Word.Document";
                        break;
                    case "ppt":
                        sOpenType = "PowerPoint.Show";
                        break;
                    case "vsd":
                        sOpenType = "Visio.Drawing";
                        break;
                    default:
                        sOpenType = "Word.Document";
                        break;
                }
                return sOpenType;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }










        /// <summary>
        /// 加载数据
        /// </summary>
        public void DataBind()
        {

            //模版上传辅助类
            TemFileUploadHelper temFileUploadHelper = new TemFileUploadHelper();


            //新建报表
            if (custom_tem_id != 0 && id == 0)
            {

                SortedList sellist = new SortedList();
                sellist.Add(1, custom_tem_id);
                //string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-template-sec002", sellist);
                dtTemRowDate = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-template-sec002", sellist);

                if (dtTemRowDate == null) dtTemRowDate = new DataTable();

                if (dtTemRowDate.Rows.Count > 0)
                {
                    //先下载模版文件
                    temFileUploadHelper.DownloadTemFile(@"Template\", dtTemRowDate.Rows[0]["guidname"].ToString());
                    string file = temFileUploadHelper.GetTemFilePath(@"Template\", dtTemRowDate.Rows[0]["guidname"].ToString());

                    //生成一个临时文件，用于存储数据
                    string tem_fileName = dtTemRowDate.Rows[0]["guidname"].ToString().Replace(Path.GetExtension(file), "");

                    string tem_file = temFileUploadHelper.GetTemFilePath(@"Template\", dtTemRowDate.Rows[0]["guidname"].ToString()).Replace(tem_fileName, tem_fileName + "_tem");

                    //如果有则先删除
                    if (File.Exists(tem_file))
                        File.Delete(tem_file);

                    try
                    {
                        this.axFramerControl.Open(@file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }


            //修改报表
            if (custom_tem_id == 0 && id != 0)
            {


                SortedList sellist1 = new SortedList();
                sellist1.Add(1, id);
                //string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-template-sec002", sellist);
                dtRowDate = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-template-report-sec002", sellist1);

                if (dtRowDate == null) dtRowDate = new DataTable();


                //this.Text = SystemName + "--模版修改";

                //如果是修改，但是未返回数据，则直接关闭窗体
                if (dtRowDate.Rows.Count <= 0) this.Close();

                rtxtTem_name.Text = dtRowDate.Rows[0]["report_name"].ToString();

                //先下载模版文件
                temFileUploadHelper.DownloadTemFile(@"Report\", dtRowDate.Rows[0]["file_name"].ToString());
                string file = temFileUploadHelper.GetTemFilePath(@"Report\", dtRowDate.Rows[0]["file_name"].ToString());

                string tem_fileName = dtRowDate.Rows[0]["file_name"].ToString().Replace(Path.GetExtension(file), "");

                string tem_file = temFileUploadHelper.GetTemFilePath(@"Report\", dtRowDate.Rows[0]["file_name"].ToString()).Replace(tem_fileName, tem_fileName + "_tem");


                if (File.Exists(tem_file))
                    File.Delete(tem_file);


                //把数据存放到临时文件
                File.Copy(file, tem_file, true);

                try
                {
                    this.axFramerControl.Open(@file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
        }



        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnClose_Click(object sender, EventArgs e)
        {
            //this.axFramerControl.Dispose();
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSave_Click(object sender, EventArgs e)
        {

            //this.axFramerControl.Dispose();
            //this.axFramerControl.Close();

            //模版名称为空则提示
            if (string.IsNullOrEmpty(rtxtTem_name.Text))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("customtemplatename", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //模版上传辅助类
            TemFileUploadHelper temFileUploadHelper = new TemFileUploadHelper();


            //新建报表
            if (custom_tem_id != 0 && id == 0)
            {
                if (dtTemRowDate.Rows.Count > 0)
                {

                    string file = temFileUploadHelper.GetTemFilePath(@"Template\", dtTemRowDate.Rows[0]["guidname"].ToString());


                    //检测是否存在目录，不存在则先创建
                    if (!Directory.Exists(temFileUploadHelper.GetTemFilePath(@"Report\")))
                    {
                        Directory.CreateDirectory(temFileUploadHelper.GetTemFilePath(@"Report\"));
                    }

                    string newGuid = Guid.NewGuid().ToString();
                    string reportFile = temFileUploadHelper.GetTemFilePath(@"Report\") + newGuid + Path.GetExtension(file);


                    //生成一个临时的文件
                    string tem_fileName = dtTemRowDate.Rows[0]["guidname"].ToString().Replace(Path.GetExtension(file), "");

                    string tem_file = temFileUploadHelper.GetTemFilePath(@"Template\", dtTemRowDate.Rows[0]["guidname"].ToString()).Replace(tem_fileName, tem_fileName + "_tem");


                    this.axFramerControl.Save();
                    this.axFramerControl.Save(tem_file, true, "", "");
                    this.axFramerControl.Close();


                    //把数据存放到临时文件
                    File.Copy(file, reportFile);

                    FileStream fileStream = File.Open(reportFile, FileMode.Open);
                    temFileUploadHelper.UploadTemFile(@"Report\", newGuid + Path.GetExtension(file), fileStream);
                    fileStream.Dispose();
                    fileStream.Close();

                    SortedList addlist = new SortedList();
                    SortedList addlist01 = new SortedList();
                    addlist.Add(1, custom_tem_id);
                    addlist.Add(2, rtxtTem_name.Text);
                    addlist.Add(3, newGuid + Path.GetExtension(file));
                    addlist.Add(4, DateTime.Now);
                    addlist01.Add(1, addlist);

                    string ss = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-custom-template-report-add001", addlist01, null);
                    int addDataService = reCnasRemotCall.RemotInterface.UPData(1, "HCS-custom-template-report-add001", addlist01, null);

                    if (addDataService > -1)
                    {

                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("succeed", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        HCSRM_custom_template_report01.DataBindReport();
                    }

                }
            }

            //修改报表
            if (custom_tem_id == 0 && id != 0)
            {
                string file = temFileUploadHelper.GetTemFilePath(@"Report\", dtRowDate.Rows[0]["file_name"].ToString());

                //获取打开文档的句柄(文件类型)
                //Microsoft.Office.Interop.Excel.Workbook workbook = (Microsoft.Office.Interop.Excel.Workbook)this.axFramerControl.ActiveDocument;
                //workbook.Saved = true;
                //workbook.Save();

                //Microsoft.Office.Interop.Word.Words words = (Microsoft.Office.Interop.Word.Words)this.axFramerControl.ActiveDocument;

                string tem_fileName = dtRowDate.Rows[0]["file_name"].ToString().Replace(Path.GetExtension(file), "");

                string tem_file = temFileUploadHelper.GetTemFilePath(@"Report\", dtRowDate.Rows[0]["file_name"].ToString()).Replace(tem_fileName, tem_fileName + "_tem");


                this.axFramerControl.Save();
                this.axFramerControl.Save(tem_file, true, "", "");
                this.axFramerControl.Close();

                //return;

                //如果是修改，但是未返回数据，则直接关闭窗体
                if (dtRowDate.Rows.Count <= 0) this.Close();
                SortedList uplist = new SortedList();
                SortedList uplist01 = new SortedList();
                uplist.Add(1, rtxtTem_name.Text);
                uplist.Add(2, id);
                uplist01.Add(1, uplist);

                //string ss = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-custom-template-report-up001", uplist01, null);
                int UpDataService = reCnasRemotCall.RemotInterface.UPData(1, "HCS-custom-template-report-up001", uplist01, null);

                //先删除服务器文件
                temFileUploadHelper.DeleteTemFile(@"Report\", dtRowDate.Rows[0]["file_name"].ToString());

                FileStream fileStream = File.Open(file, FileMode.Open);
                temFileUploadHelper.UploadTemFile(@"Report\", dtRowDate.Rows[0]["file_name"].ToString(), fileStream);
                fileStream.Dispose();
                fileStream.Close();

                if (UpDataService > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("editsucceed", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    HCSRM_custom_template_report01.DataBindReport();
                }


            }
        }


        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnPrint_Click(object sender, EventArgs e)
        {
            if (this.axFramerControl.IsHandleCreated)
            {
                this.axFramerControl.PrintPreview();
            }
        }

    }
}
