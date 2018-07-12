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
    public partial class HCSCM_set_image : TemplateForm
    {

        private SortedList Sl_par = new SortedList();
        private SortedList Sl_Label = new SortedList();
        public ImageData ImageData01 = new ImageData();

        //private ImageAddData ImageAddData01 = new ImageAddData();
        public delegate void XmlUpdate(object sender, EventArgs e, string XMLdata);
        [Browsable(true), Description("选择生成XML事件。"), Category("操作")]
        public event XmlUpdate UserXmlUpdate;
        //Bitmap myBmp;
        Point mouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)

        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();

        private SortedList Sl_Parameter = new SortedList();


        /// <summary>
        /// 构造函数
        /// </summary>
        public HCSCM_set_image(SortedList sortedList)
        {
            InitializeComponent();
            but_phone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Photo", EnumImageType.PNG);
            but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            //参数赋值
            Sl_Parameter = sortedList;

            this.tb_search.Text = Sl_Parameter["pack_barcode"].ToString();
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSCM_pack_image_Load(object sender, EventArgs e)
        {
            //ImageData01.Name=CnasClientMethods.Cre_RKnumber();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            // 获得一个编码，为图片名称
            ImageData01.Name = reCnasRemotCall.RemotInterface.Get_SerialNumber(2);
            cb_app.SelectedIndex = 0;
            this.Text = styStemName + "--拍摄照片";
        }



        /// <summary>
        /// 拍照事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_photo_Click(object sender, EventArgs e)
        {
            Cnas.wns.CnasCameraUC.ControlCameraTools ControlCameraTools01 = new Cnas.wns.CnasCameraUC.ControlCameraTools();
            if (ControlCameraTools01.ShowDialog() == DialogResult.OK)
            {
                this.prictureDesign.Image = ControlCameraTools01.BitmapData;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_app_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cb_app.Text.Trim())
            {
                case "1280x720":
                    RefreshDesignSize(1280, 720);
                    break;
                case "800x600":
                    RefreshDesignSize(800, 600);
                    break;
                case "720x540":
                    RefreshDesignSize(720, 540);
                    break;
                case "640x480":
                    RefreshDesignSize(640, 480);
                    break;
                case "560x420":
                    RefreshDesignSize(560, 420);
                    break;
                case "480x360":
                    RefreshDesignSize(480, 360);
                    break;
                case "320x240":
                    RefreshDesignSize(320, 240);
                    break;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void RefreshDesignSize(int x, int y)
        {
            prictureDesign.Height = y;
            prictureDesign.Width = x;
            PrictureView.Height = y;
            PrictureView.Width = x;
            ImageData01.Height = y;
            ImageData01.Width = x;
            this.pg_design.Tag = "ImageData";
            pg_design.SelectedObject = ImageData01;
            pg_design.Refresh();
        }



        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_add_Click(object sender, EventArgs e)
        {
            int labcount = 0, intlab = 0;
            while (intlab == 0)
            {
                labcount++;
                if (Sl_Label["par_" + labcount.ToString()] == null)
                {
                    intlab = 1;
                }
            }
            string strname = "par_" + labcount.ToString();
            Label lab_tmp = new Label();
            lab_tmp.Name = strname;
            lab_tmp.Text = strname;
            lab_tmp.AutoSize = true;
            lab_tmp.ForeColor = Color.Red;
            lab_tmp.BackColor = Color.Transparent;
            lab_tmp.Location = new Point(20, 20);
            lab_tmp.Font = new Font("宋体", 15, FontStyle.Bold);
            lab_tmp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseDown);
            lab_tmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseMove);
            lab_tmp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseUp);
            Sl_Label.Add(strname, lab_tmp);
            ImageAddData BarcodeAddData_tmp = new ImageAddData();
            BarcodeAddData_tmp.Name = strname;
            this.Sl_par.Add(strname, BarcodeAddData_tmp);
            this.prictureDesign.Controls.Add(lab_tmp);
            lab_tmp.BringToFront();
        }




        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_del_Click(object sender, EventArgs e)
        {
            if (pg_design.Tag != null && this.pg_design.Tag.ToString() == "ImageAddData")
            {
                ImageAddData ImageAddDatatmp = (ImageAddData)this.pg_design.SelectedObject;
                string str_info_name = ImageAddDatatmp.Name;
                Label lab_tmp = (Label)this.Sl_Label[str_info_name];
                this.prictureDesign.Controls.Remove(lab_tmp);
                Sl_Label.Remove(str_info_name);
                Sl_par.Remove(str_info_name);
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "删除", "参数" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 图片预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_view_Click(object sender, EventArgs e)
        {

            PrictureView.Height = prictureDesign.Height;
            PrictureView.Width = prictureDesign.Width;
            Bitmap _NewBitmap = new Bitmap(this.prictureDesign.Width, prictureDesign.Height);
            //_NewBitmap.SetResolution(203, 203);
            prictureDesign.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            this.PrictureView.Image = _NewBitmap;
            //_NewBitmap.Save(stream)
            this.tabc_right.SelectedIndex = 1;
        }



        /// <summary>
        /// 图片保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_save_Click(object sender, EventArgs e)
        {
            string str_ImageData = this.ImageData01.GetXML();
            string str_ImageAddData = "";
            if (this.Sl_par.Count > 0)
            {
                str_ImageAddData = "<ImageAddData>";
                for (int i = 0; i < Sl_par.Count; i++)
                {
                    ImageAddData ImageAddDatatmp = (ImageAddData)Sl_par.GetByIndex(i);
                    str_ImageAddData = str_ImageAddData + ImageAddDatatmp.GetXML();
                }
                str_ImageAddData = str_ImageAddData + "</ImageAddData>";
            }
            string strxmltmp = "<Data>" + str_ImageData + str_ImageAddData + "</Data>";
            //UserXmlUpdate(sender, e, strxmltmp);


            //上传到FTP文件夹的名称
            string folderName = "";

            int upType = Convert.ToInt32(Sl_Parameter["type"]);
            //包图片名称
            string dataUrl = ImageData01.Name + ".jpg";

            // 确定上传图片的类型
            // 1-包  2-器械  
			EUploadType eUpType = (EUploadType)upType;
			folderName = CnasUtilityTools.GetFolderName(eUpType);


            #region 保存对应条码包的照片
            //ftp: test.cnasis.cn:cnasftp:ftp123
            tsm_view_Click(null, null);
            Bitmap _NewBitmap = new Bitmap(this.PrictureView.Width, PrictureView.Height);
            //_NewBitmap.SetResolution(203, 203);
            prictureDesign.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            MemoryStream memStream = new MemoryStream();
            _NewBitmap.Save(memStream, ImageFormat.Jpeg);


            ImageCache imageCache = new ImageCache();

            //保存图片
            bool result = imageCache.SaveImageCache(folderName, ImageData01.Name + ".jpg", memStream);
            if (!result)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorimage", EnumPromptMessage.error, new string[] { "系统错误" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
            }

            #endregion

            //获取图片
            Image picViewImage = imageCache.GetImageByFolderNameFileName(folderName, ImageData01.Name + ".jpg");
            //返回不等于""说明有错误信息返回，弹出提示
            if (picViewImage == null)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorseeim", EnumPromptMessage.error, new string[] { "" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.PrictureView.Image = picViewImage;
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
            sltmp.Add(4, dataUrl);
            //状态默认可用
            sltmp.Add(5, 1);
            sltmp01.Add(1, sltmp);
            //string gg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS_image-data-add001", sltmp01, null);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS_image-data-add001", sltmp01, null);

            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "照片" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
            }
        }

        private void label_all_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lab_tmp = (Label)sender;
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                lab_tmp.Focus();
                //显示属性
                ImageAddData ImageAddDatatmp = (ImageAddData)this.Sl_par[lab_tmp.Name];
                this.pg_design.Tag = "ImageAddData";
                pg_design.SelectedObject = ImageAddDatatmp;
                pg_design.Refresh();
            }
        }



        private void label_all_MouseMove(object sender, MouseEventArgs e)
        {
            Label lab_tmp = (Label)sender;
            lab_tmp.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = lab_tmp.Location.X + moveX;
                y = lab_tmp.Location.Y + moveY;
                lab_tmp.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }




        private void label_all_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lab_tmp = (Label)sender;
                isMove = false;
                //显示属性
                ImageAddData ImageAddDatatmp = (ImageAddData)this.Sl_par[lab_tmp.Name];
                if (lab_tmp.Location.X < 0 || lab_tmp.Location.X > this.prictureDesign.Width || lab_tmp.Location.Y < 0 || lab_tmp.Location.Y > prictureDesign.Height)
                {
                    lab_tmp.Location = new Point(ImageAddDatatmp.X, ImageAddDatatmp.Y);
                }
                else
                {
                    ImageAddDatatmp.X = lab_tmp.Location.X;
                    ImageAddDatatmp.Y = lab_tmp.Location.Y;
                }

                this.pg_design.Refresh();
            }
        }



        /// <summary>
        /// 图片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_Click(object sender, EventArgs e)
        {
            this.pg_design.Tag = "ImageData";
            pg_design.SelectedObject = this.ImageData01;
            pg_design.Refresh();
        }



        /// <summary>
        /// 属性值发生变化时发生
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pg_design_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string strtag = this.pg_design.Tag.ToString();
            if (strtag == "ImageAddData")
            {
                ImageAddData ImageAddDatatmp = (ImageAddData)pg_design.SelectedObject;
                string new_key = ImageAddDatatmp.Name;
                Label lab_tmp = (Label)this.Sl_Label[new_key];
                if (ImageAddDatatmp.Value == "")
                {
                    lab_tmp.Text = lab_tmp.Name;
                }
                else
                {
                    lab_tmp.Text = ImageAddDatatmp.Value;
                }
                lab_tmp.ForeColor = ImageAddDatatmp.FontColor;
                lab_tmp.Location = new Point(ImageAddDatatmp.X, ImageAddDatatmp.Y);
                if (ImageAddDatatmp.Bold == true)
                {
                    lab_tmp.Font = new Font("宋体", ImageAddDatatmp.ForeSize, FontStyle.Bold);
                }
                else
                {
                    lab_tmp.Font = new Font("宋体", ImageAddDatatmp.ForeSize, FontStyle.Regular);
                }
            }
            else if (strtag == "ImageData")
            {
                this.prictureDesign.Height = this.ImageData01.Height;
                this.prictureDesign.Width = this.ImageData01.Width;
            }
        }


        /// <summary>
        /// 调整大小时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_design_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < prictureDesign.Controls.Count; i++)
            {
                Control Control01 = prictureDesign.Controls[i];
                if (Control01.Location.X > prictureDesign.Height || Control01.Location.Y > prictureDesign.Width)
                {
                    Control01.Location = new Point(50, 50);
                }
            }
        }




        /// <summary>
        /// 选显卡切换时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabc_right_SelectedIndexChanged(object sender, EventArgs e)
        {

            //切换到预览时，预览图片
            if (this.tabc_right.SelectedIndex == 1)
            {
                PrictureView.Height = prictureDesign.Height;
                PrictureView.Width = prictureDesign.Width;
                Bitmap _NewBitmap = new Bitmap(this.prictureDesign.Width, prictureDesign.Height);
                //_NewBitmap.SetResolution(203, 203);
                prictureDesign.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
                this.PrictureView.Image = _NewBitmap;
                //_NewBitmap.Save(stream)
                this.tabc_right.SelectedIndex = 1;
            }


        }






    }
}
