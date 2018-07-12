using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_image_batch : TemplateForm
    {
        private ImageData ImageData01 = new ImageData();
        public Bitmap BitmapData = null;
        //上传到FTP文件夹的名称
        string folderName = "";

        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();
        /// <summary>
        /// 传递参数列表
        /// </summary>
        private SortedList Sl_Parameter = new SortedList();
        public HCSCM_set_image_batch(SortedList sortedList)
        {
            InitializeComponent();
            this.but_imput.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            this.but_remove.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "delete", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Preservation", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = styStemName + "--照片导入";

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

            //表格栏底色
            this.dgv_imageList.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgv_imageList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_imageList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_imageList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        /// <summary>
        /// 导入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_imput_Click(object sender, EventArgs e)
        {
            //可选多项
            open_file.Multiselect = true;
            open_file.ShowDialog();



            this.dgv_imageList.RowCount = open_file.FileNames.Length;



            //表示传入了多个文件
            if (open_file.FileNames.Length > 0)
            {
                for (int i = 0; i < open_file.FileNames.Length; i++)
                {
                    this.dgv_imageList.Rows[i].Cells[0].Value = "1";
                    this.dgv_imageList.Rows[i].Cells[1].Value = "图片" + (i + 1);
                    this.dgv_imageList.Rows[i].Cells[2].Value = open_file.FileNames[i];
                }

                BitmapData = new System.Drawing.Bitmap(this.dgv_imageList.Rows[0].Cells["data_url"].Value.ToString());
                this.pic_design.Image = BitmapData;


                this.pic_design.Width = BitmapData.Width;
                this.pic_design.Height = BitmapData.Height;

                this.pic_design.Update();
            }
            //dgv_imageList.Rows[1].Selected = true;

            // dgv_imageList.Rows[0].Selected = true;
            //dgv_imageList.SelectedCells[0].Value.ToString();
            //dgv_imageList_RowStateChanged(null,null);

            return;

        }





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
            if (this.dgv_imageList.Rows.Count <= 0) return;
            DataGridViewRow itemRow = e.Row;

            if (itemRow.Selected)
            {
                //如果图片的 URL 为NULl，直接退出
                if (itemRow.Cells["data_url"].Value == null || itemRow.Cells["data_url"].Value.ToString() == "") return;
                BitmapData = new System.Drawing.Bitmap(itemRow.Cells["data_url"].Value.ToString());
                this.pic_design.Image = BitmapData;
                this.pic_design.Width = BitmapData.Width;
                this.pic_design.Height = BitmapData.Height;
                this.pic_design.Update();
            }




        }

        private void but_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.dgv_imageList.Rows.Count <= 0) return;//没有数据则不保存
                int sumnum = 0;//测试是否每张照片都添加成功
                //有几张照片则保存几遍
                for (int i = 0; i < this.dgv_imageList.Rows.Count; i++)
                {

                    //上传到FTP文件夹的名称
                    string folderName = "";

                    int upType = Convert.ToInt32(Sl_Parameter["type"]);
                    //包图片名称
                    string dataUrl = System.IO.Path.GetFileName(dgv_imageList.Rows[i].Cells[2].Value.ToString());

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


                    #region 保存对应条码包的照片
                    //ftp: test.cnasis.cn:cnasftp:ftp123
                    //tsm_view_Click(null, null);
                    //加载图片
                    BitmapData = new System.Drawing.Bitmap(this.dgv_imageList.Rows[i].Cells["data_url"].Value.ToString());


                    FileInfo fi = new FileInfo(this.dgv_imageList.Rows[i].Cells["data_url"].Value.ToString());
                    long logosize = fi.Length;
                    if (logosize > 512000)//大于500kb则不保存
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("bigimage", EnumPromptMessage.warning, new string[] { (i + 1).ToString() }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.pic_design.Image = BitmapData;
                    this.pic_design.Width = BitmapData.Width;
                    this.pic_design.Height = BitmapData.Height;
                    Bitmap _NewBitmap = new Bitmap(this.pic_design.Width, pic_design.Height);
                    //_NewBitmap.SetResolution(203, 203);
                    pic_design.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
                    MemoryStream memStream = new MemoryStream();
                    _NewBitmap.Save(memStream, ImageFormat.Jpeg);
                    CnasClientMethods CnasClientMethods01 = new CnasClientMethods();
                    CnasRemotCall reCnasRemotCall1 = new CnasRemotCall();
                    string objectName = reCnasRemotCall1.RemotInterface.Get_SerialNumber(2) + ".jpg";
                    ImageData01.Name = objectName;
                    ImageCache imageCache = new ImageCache();

                    //保存图片
                    bool result = imageCache.SaveImageCache(folderName, objectName, memStream);
                    if (!result)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorimage", EnumPromptMessage.error, new string[] { "系统错误" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion

                    //获取图片
                    Image picViewImage = imageCache.GetImageByFolderNameFileName(folderName, objectName);
                    //返回不等于""说明有错误信息返回，弹出提示
                    if (picViewImage == null)
                    {
                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorseeim", EnumPromptMessage.error, new string[] { "" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.pic_design.Image = picViewImage;
                    }
                    //rexxie通过条形码更新数据库：关联文件名
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();

                    //图片存储类型
                    sltmp.Add(1, upType);
                    //包ID
                    sltmp.Add(2, Sl_Parameter["pack_id"]);
                    //包条码
                    sltmp.Add(3, Sl_Parameter["pack_barcode"]);
                    //图片名称
                    sltmp.Add(4, objectName);
                    //状态默认可用
                    sltmp.Add(5, 1);
                    sltmp01.Add(1, sltmp);
                    //string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS_image-data-add001", sltmp01, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS_image-data-add001", sltmp01, null);

                    if (recint > -1)
                    {
                        sumnum++;

                    }
                }
                if (sumnum == this.dgv_imageList.Rows.Count)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "照片" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("系统出现错误：" + ex.Message + "请联系管理员。");
            }
        }

        private void but_remove_Click(object sender, EventArgs e)
        {

            if (pic_design.Image == null) return;
            this.dgv_imageList.Rows.Remove(this.dgv_imageList.CurrentRow);
            //如果dgv没有数据，则没有图片显示，清空
            if (dgv_imageList.RowCount == 0)
            {
                pic_design.Image = null;
            }
            //else
            //{
            //    //删除选中行的缓存图片
            //    ImageCache imageCache = new ImageCache();
            //    imageCache.DeleteImageCache(folderName, dgv_imageList.SelectedRows[0].Cells["data_url"].Value.ToString());
            //}



        }






    }
}
