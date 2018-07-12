using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{

    public partial class HCSCM_set_manage_image : TemplateForm
    {
        private ILog _logger = null;


        //dt图片列表
        DataTable dtImageList = null;
        //上传到FTP文件夹的名称
        string folderName = "";

        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();

        /// <summary>
        /// 传递参数列表
        /// </summary>
        private SortedList Sl_Parameter = new SortedList();
        public HCSCM_set_manage_image(SortedList sortedList)
        {
            InitializeComponent();
            _logger = LogManager.GetLogger("CnasWNSClient");
            // _logger.Info("aaaaaa");

            but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            but_sort.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "modifyOrder", EnumImageType.PNG);
            but_big.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "enlarge", EnumImageType.PNG);
            but_small.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "narrow", EnumImageType.PNG);
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);

            pic_design.MouseWheel += new MouseEventHandler(pic_design_MouseWheel);

            this.Text = styStemName + "--照片列表";

            //参数赋值
            Sl_Parameter = sortedList;

            int upType = Convert.ToInt32(Sl_Parameter["type"]);

            // 确定上传图片的类型
            // 1-包  2-器械  
            if (upType == 1)
            {
                folderName = "set/";
            }
            else if (upType == 2)
            {
                folderName = "instruments/";
            }
            else if (upType == 3)
            {
                folderName = "safetyTimeReport/";
            }

            ////表格栏底色
            //this.dgv_imageList.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dgv_imageList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_imageList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_imageList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }



        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSCM_set_manage_image_Load(object sender, EventArgs e)
        {
            DataBaind();
        }



        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBaind()
        {

            this.dgv_imageList.Rows.Clear();
            #region 加载已有照片数据
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();


            //图片存储类型
            sttemp01.Add(1, Sl_Parameter["type"]);
            //包ID
            sttemp01.Add(2, Sl_Parameter["pack_id"]);
            //图片状态
            sttemp01.Add(3, 1);

            dtImageList = reCnasRemotCall.RemotInterface.SelectData("HCS-image-sec001", sttemp01);

            if (dtImageList != null)
            {
                int ii = dtImageList.Rows.Count;
                if (ii <= 0) return;
                this.dgv_imageList.RowCount = ii;

                for (int i = 0; i < ii; i++)
                {
                    if (dtImageList.Rows[i]["id"] != null) this.dgv_imageList.Rows[i].Cells["id"].Value = dtImageList.Rows[i]["id"].ToString();
                    if (dtImageList.Rows[i]["entity_id"] != null) this.dgv_imageList.Rows[i].Cells["entity_id"].Value = dtImageList.Rows[i]["entity_id"].ToString();
                    this.dgv_imageList.Rows[i].Cells["entity_name"].Value = "图片" + (i + 1);
                    if (dtImageList.Rows[i]["data_url"] != null) this.dgv_imageList.Rows[i].Cells["data_url"].Value = dtImageList.Rows[i]["data_url"].ToString();
                    if (dtImageList.Rows[i]["sort"] != null) this.dgv_imageList.Rows[i].Cells["sort"].Value = dtImageList.Rows[i]["sort"].ToString();
                }
                if (dgv_imageList.Rows.Count > 0)
                    dgv_imageList.CurrentRow = dgv_imageList.Rows[0];
                //获取图片,默认显示第一张图片
                ImageCache imageCache = new ImageCache();
                Image picViewImage = imageCache.GetImageByFolderNameFileName(folderName, dtImageList.Rows[0]["data_url"].ToString());
                //返回不等于""说明有错误信息返回，弹出提示
                if (picViewImage == null)
                {
                    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("DelSever", EnumPromptMessage.warning, new string[] { }), ConfigurationManager.AppSettings["SystemName"] + "--删除数据", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    but_remove_Click(null, null);
                    //MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorseeim", EnumPromptMessage.error, new string[] { "" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.pic_design.Image = picViewImage;
                    //给图片宽高赋值
                    this.pic_design.Width = tabPage1.Width;

                    this.pic_design.Height = tabPage1.Height;

                    Width = this.pic_design.Width;
                    height = this.pic_design.Height;


                    //this.tb_sort.Text = dgv_imageList.SelectedRows[0].Cells["sort"].Value.ToString();

                }

                ////默认显示第一张图片
                //CnasClientMethods CnasClientMethods01 = new CnasClientMethods();
                ////下载文件，返回文件流
                //MemoryStream memStream02 = CnasClientMethods01.Download(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, this.dgv_imageList.CurrentRow.Cells["data_url"].Value.ToString(), CnasBaseData.FTP_Path + folderName);




                ////返回不等于""说明有错误信息返回，弹出提示
                //if (memStream02 == null)
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorseeim", EnumPromptMessage.error), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //    Image image = System.Drawing.Image.FromStream(memStream02);
                //    //给图片宽高赋值
                //    this.pic_design.Width = tabPage1.Width;

                //    this.pic_design.Height = tabPage1.Height;
                //    this.pic_design.Image = image;
                //    Width = this.pic_design.Width;
                //    height = this.pic_design.Height;

                //    memStream02.Close();
                //    this.tb_sort.Text = dgv_imageList.SelectedRows[0].Cells["sort"].Value.ToString();
                //}

            }

            #endregion
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_remove_Click(object sender, EventArgs e)
        {
            try
            {
                 //判断用户是否有选择行
            if (this.dgv_imageList.SelectedRows.Count > 0)
            {

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                //状态
                sltmp01.Add(1, 9);
                //图片ID
                sltmp01.Add(2, dgv_imageList.SelectedRows[0].Cells["id"].Value.ToString()); 
                sltmp.Add(1, sltmp01);

                DialogResult dialogResult = MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { this.dgv_imageList.SelectedRows[0].Cells["entity_name"].Value.ToString(), "图片" }), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete", EnumPromptMessage.warning, new string[] { dgv_01.SelectedRows[0].Cells["ca_name"].Value.ToString(), "基本包" }), "删除基本包", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //  string up = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS_image-data-del001", sltmp, null);

                    //删除选中行的缓存图片
                    ImageCache imageCache = new ImageCache();
                    imageCache.DeleteImageCache(folderName, dgv_imageList.SelectedRows[0].Cells["data_url"].Value.ToString());
                    //根据ID改变图片的状态，变为不可用
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS_image-data-del001", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("deletesuccessful", EnumPromptMessage.warning, new string[] { "图片" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataBaind();
                    }
                }
            }
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 选择行发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_imageList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

           
        }
        /// <summary>
        /// 修改顺序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_sort_Click(object sender, EventArgs e)
        {
            if (pic_design.Image == null) return;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            //顺序号
            sltmp01.Add(1, this.tb_sort.Text.Trim());
            //图片ID
            sltmp01.Add(2, this.dgv_imageList.CurrentRow.Cells["id"].Value);
            sltmp.Add(1, sltmp01);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-image-data-up001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "图片" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBaind();
            }
        }

        private void pic_design_MouseMove(object sender, MouseEventArgs e)
        {
            pic_design.SizeMode = PictureBoxSizeMode.Zoom;
            double scale = 1;
            if (pic_design.Height > 0)
            {
                scale = (double)pic_design.Width / pic_design.Height;

            }
            // pic_design.Width+=(int)()
        }
        /// <summary>
        /// 图片放大按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_close_Click(object sender, EventArgs e)
        {
            if (pic_design.Image == null) return;
            but_small.Enabled = true;
            _percent = _percent + (double)0.1;

            // pic_design.Image = PicSized(_bitmap, _percent);
            int w = Convert.ToInt32(tabPage1.Width * _percent);
            int h = Convert.ToInt32(tabPage1.Height * _percent);
            if (w < 50 || h < 50)
            {
                but_small.Enabled = false;
            }
            if (w > 99999 || h > 99999)
            {
                but_big.Enabled = false;
            }
            this.pic_design.Width = w;
            this.pic_design.Height = h;
            Width = w;
            height = h;
            //pic_design.Image.Height = pic_design.Handle * _percent;
        }
        /// <summary>
        /// 图片缩小按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (pic_design.Image == null) return;
            but_big.Enabled = true;
            _percent = _percent - (double)0.1;
            int w = Convert.ToInt32(tabPage1.Width * _percent);
            int h = Convert.ToInt32(tabPage1.Height * _percent);
            if (w < 50 || h < 50)
            {
                but_small.Enabled = false;
            }
            if (w > 99999 || h > 99999)
            {
                but_big.Enabled = false;
            }
            this.pic_design.Width = w;
            this.pic_design.Height = h;
            Width = w;
            height = h;

            // pic_design.Image = PicSized(_bitmap, _percent);
        }
        double _percent = 1;

        Bitmap _bitmap = null;
        /// <summary>
        /// 滑轮滚动图片放大、缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pic_design.Image == null) return;
            var t = pic_design.Image.Size;
            t.Width += e.Delta;
            t.Height += e.Delta;
            if (t.Width < 0 || t.Height < 0)
            {
                return;
            }
            if (t.Width > 10000 || t.Height > 10000)
            {
                return;
            }
            Width = this.pic_design.Width += e.Delta;
            height = this.pic_design.Height += e.Delta;

        }

        #region 图片拖动

        int driftX = 0, driftY = 0;
        int mx = 0, my = 0;
        bool wselected = false;
        Point p = new Point();
        int Width = 0;
        int height = 0;

        #endregion
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (pic_design.Image == null) return;
            if (wselected)
            {
                driftX = p.X - e.X;
                driftY = p.Y - e.Y;
                mx = mx - driftX;
                my = my - driftY;
                Bitmap JPEG = new Bitmap(this.pic_design.Image, Width, height);
                Graphics g = pic_design.CreateGraphics();
                g.Clear(pic_design.BackColor);
                g.DrawImage(JPEG, mx, my);
                p.X = e.X;
                p.Y = e.Y;
                JPEG.Dispose();
                g.Dispose();//图像移动的距离
            }
        }
        /// <summary>
        /// 鼠标松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_MouseUp(object sender, MouseEventArgs e)
        {

            pic_design.Cursor = Cursors.Default; //松开鼠标时，形状恢复为箭头

            wselected = false;
            this.pic_design.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_MouseDown(object sender, MouseEventArgs e)
        {
            pic_design.Cursor = Cursors.Hand; //按下鼠标时，将鼠标形状改为手型
            wselected = true;
            p.X = e.X;
            p.Y = e.Y;
        }

        private void tb_sort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入

            }
        }

        private void tb_sort_TextChanged(object sender, EventArgs e)
        {
            if (tb_sort.Text.Trim() == "" || tb_sort.Text.Trim() == "0")
            {
                tb_sort.Text = "1";
                return;
            }
        }

        private void dgv_imageList_RowStateChanged(object sender, EventArgs e)
        {
            if (this.dgv_imageList.Rows.Count <= 0) return;
            if (dgv_imageList.CurrentRow == null) return;
            GridViewRowInfo itemRow = dgv_imageList.CurrentRow;


            if (itemRow.IsSelected)
            {
                //如果图片的 URL 为NULl，直接退出
                if (itemRow.Cells["data_url"].Value == null) return;
                tb_sort.Text = itemRow.Cells["sort"].Value.ToString();

                //获取图片
                ImageCache imageCache = new ImageCache();
                Image picViewImage = imageCache.GetImageByFolderNameFileName(folderName, itemRow.Cells["data_url"].Value.ToString());

                //返回不等于""说明有错误信息返回，弹出提示
                if (picViewImage == null)
                {
                    if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("DelSever", EnumPromptMessage.warning, new string[] { }), ConfigurationManager.AppSettings["SystemName"] + "--删除数据", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    but_remove_Click(null, null);
                    //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    //int selectedIndex = dgv_imageList.Rows.IndexOf(dgv_imageList.SelectedRows[0]);
                    //SortedList sltmp = new SortedList();
                    //SortedList sltmp01 = new SortedList();
                    //sltmp01.Add(1, dgv_imageList.SelectedRows[0].Cells["id"].Value);
                    //sltmp.Add(1, sltmp01);
                    //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-image-data-Del001", sltmp, null);
                    //int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-image-data-Del001", sltmp, null);
                    //if (recint > -1)
                    //{

                    //    //dgv_imageList.Rows.RemoveAt(selectedIndex);//移除选择的dgv的数据
                    //    //if (dgv_imageList.Rows.Count > 0)
                    //    //{

                    //    //    dgv_imageList.CurrentRow.Selected = true;


                    //    //}
                    //}
                    // return;
                }
                else
                {
                    this.pic_design.Image = picViewImage;
                    //给图片宽高赋值
                    this.pic_design.Width = tabPage1.Width;

                    this.pic_design.Height = tabPage1.Height;

                    Width = this.pic_design.Width;
                    height = this.pic_design.Height;


                    this.tb_sort.Text = dgv_imageList.SelectedRows[0].Cells["sort"].Value.ToString();

                }

                //CnasClientMethods CnasClientMethods01 = new CnasClientMethods();
                ////下载文件，返回文件流
                //MemoryStream memStream02 = CnasClientMethods01.Download(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, itemRow.Cells["data_url"].Value.ToString(), CnasBaseData.FTP_Path + folderName);
                ////返回不等于""说明有错误信息返回，弹出提示
                //if (memStream02 == null)
                //{
                //    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorseeim", EnumPromptMessage.error), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //    Image image = System.Drawing.Image.FromStream(memStream02);
                //    this.pic_design.Width = image.Width;
                //    this.pic_design.Height = image.Height;
                //    this.pic_design.Image = image;
                //    memStream02.Close();
                //}
            }
        }

        private void dgv_imageList_RowStateChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
           
        }
    }
}
