using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;

using Cnas.wns.CnasBaseClassClient;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_set_image : UserControl
    {
        private SortedList Sl_par = new SortedList();
        private SortedList Sl_Label = new SortedList();
        private ImageData ImageData01 = new ImageData();
        //private ImageAddData ImageAddData01 = new ImageAddData();
        public delegate void XmlUpdate(object sender, EventArgs e, string XMLdata);
        [Browsable(true), Description("选择生成XML事件。"), Category("操作")]
        public event XmlUpdate UserXmlUpdate;
        //Bitmap myBmp;
        Point mouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)

        public HCSSM_set_image()
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            //ImageData01.Name=CnasClientMethods.Cre_RKnumber();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            ImageData01.Name = reCnasRemotCall.RemotInterface.Get_SerialNumber(2);
            cb_app.SelectedIndex = 0;
        }

        private void but_photo_Click(object sender, EventArgs e)
        {
            Cnas.wns.CnasCameraUC.ControlCameraTools ControlCameraTools01 = new Cnas.wns.CnasCameraUC.ControlCameraTools();
            if (ControlCameraTools01.ShowDialog() == DialogResult.OK)
            {
                this.pic_design.Image = ControlCameraTools01.BitmapData;
            }
        }

        private void cb_app_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(cb_app.Text.Trim())
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

        private void RefreshDesignSize(int x,int y)
        {
            pic_design.Height = y;
            pic_design.Width = x;
            pic_view.Height = y;
            pic_view.Width = x;
            ImageData01.Height = y;
            ImageData01.Width = x;
            this.pg_design.Tag = "ImageData";
            pg_design.SelectedObject = ImageData01;
            pg_design.Refresh();
        }

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
            this.pic_design.Controls.Add(lab_tmp);
            lab_tmp.BringToFront();
        }

        private void tsm_del_Click(object sender, EventArgs e)
        {
            if (pg_design.Tag != null && this.pg_design.Tag.ToString() == "ImageAddData")
            {
                ImageAddData ImageAddDatatmp = (ImageAddData)this.pg_design.SelectedObject;
                string str_info_name = ImageAddDatatmp.Name;
                Label lab_tmp = (Label)this.Sl_Label[str_info_name];
                this.pic_design.Controls.Remove(lab_tmp);
                Sl_Label.Remove(str_info_name);
                Sl_par.Remove(str_info_name);
            }
            else
            {
                MessageBox.Show("对不起！请先选定要删除的参数。");
            }
        }

        private void tsm_view_Click(object sender, EventArgs e)
        {

            pic_view.Height = pic_design.Height;
            pic_view.Width = pic_design.Width;
            Bitmap _NewBitmap = new Bitmap(this.pic_design.Width, pic_design.Height);
            //_NewBitmap.SetResolution(203, 203);
            pic_design.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            this.pic_view.Image = _NewBitmap;
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
            string strxmltmp = "<Data>" + str_ImageData + str_ImageAddData+ "</Data>";
            //UserXmlUpdate(sender, e, strxmltmp);


            #region 保存对应条码包的照片
            //ftp: test.cnasis.cn:cnasftp:ftp123
            tsm_view_Click(null, null);
            Bitmap _NewBitmap = new Bitmap(this.pic_view.Width, pic_view.Height);
            //_NewBitmap.SetResolution(203, 203);
            pic_design.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            MemoryStream memStream = new MemoryStream();
            _NewBitmap.Save(memStream, ImageFormat.Jpeg);

			string folderName = CnasUtilityTools.GetFolderName(EUploadType.Set);

			ImageCache imageCache = new ImageCache();
			//保存图片
			bool result = imageCache.SaveImageCache(folderName, ImageData01.Name + ".jpg", memStream);

            #endregion

			if (!result)
            {
                MessageBox.Show("对不起！上传图片失败，请检查文件服务器和网络." );
                return;
            }
            else
            {
				this.pic_view.Image = imageCache.GetImageByFolderNameFileName(folderName, ImageData01.Name + ".jpg");
            }

            MessageBox.Show("恭喜你！图片生成成功。");
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
                if (lab_tmp.Location.X < 0 || lab_tmp.Location.X > this.pic_design.Width || lab_tmp.Location.Y < 0 || lab_tmp.Location.Y > pic_design.Height)
                {
                    lab_tmp.Location=new Point(ImageAddDatatmp.X,ImageAddDatatmp.Y);
                }
                else
                {
                    ImageAddDatatmp.X = lab_tmp.Location.X;
                    ImageAddDatatmp.Y = lab_tmp.Location.Y;
                }
                
                this.pg_design.Refresh();
            }
        }

        private void pic_design_Click(object sender, EventArgs e)
        {
            this.pg_design.Tag = "ImageData";
            pg_design.SelectedObject = this.ImageData01;
            pg_design.Refresh();
        }

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
                this.pic_design.Height = this.ImageData01.Height;
                this.pic_design.Width = this.ImageData01.Width;
            }
        }

        private void pic_design_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < pic_design.Controls.Count; i++)
            {
                Control Control01 = pic_design.Controls[i];
                if (Control01.Location.X > pic_design.Height || Control01.Location.Y > pic_design.Width)
                {
                    Control01.Location = new Point(50, 50);
                }
            }
        }





    }
}
