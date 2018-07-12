using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CRD.Common;
using System.Drawing.Imaging;
using Cnas.wns.CnasBaseClassClient;
//using Ourway.Framework.Common.Tools;

namespace CRD.WinUI.Forms
{
    public partial class Main : FormBase, IMainForm
    {
        private Bitmap maxBitmap;
        private Bitmap resoreBitmap;
        private Bitmap HelpBitmap;//帮助
        private Bitmap SupportBitmap;//服务与支持
        private Bitmap BigCloseBitmap;//退出--》大图片
        private Point _captionMouseUp;
        private SkinForm _skinForm;

        private Bitmap skinButton;
        private Bitmap menuButton;
        protected ContextMenuStrip SkinContextMenuStrip1;
        protected Color srcColor;
        public Main()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            this.Controls.Remove(this.pnlBackground);
            //this.Controls.Remove(this.pnlRight);
            //this.Controls.Remove(this.pnlLeft);
            // this.Controls.Remove(this.pnlBottom);
            this.Controls.Remove(this.pnlCaption);


            //this.liCompanyName.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString();





            //
            //this.Font = new Font("微软雅黑",18);
        }

        //public override string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }
        //    set
        //    {
        //        base.Text = value;
        //        if (lblText != null)
        //            this.lblText.Text = value;
        //    }
        //}

        //主界面背景颜色
        public Color MainFormBackGroundColor
        {
            get
            {
                if (this.ptbTopLeft.BackgroundImage != null)
                {
                    Bitmap bitmap = new Bitmap(this.ptbTopLeft.BackgroundImage);
                    this.BackColor = bitmap.GetPixel(20, 15);
                    return Color.FromArgb(255, 255, 255);//白色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        public Color MainFormBackGroundColor2
        {
            get
            {
                if (this.ptbTopLeft.BackgroundImage != null)
                {
                    //Bitmap bitmap = new Bitmap(this.ptbTopLeft.BackgroundImage);
                    //return bitmap.GetPixel(20, 30);
                    return Color.FromArgb(223, 30, 35);//红色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        public Color ControlBackColor
        {
            get
            {
                if (this.pnlBackground.BackgroundImage != null)
                {
                    //  Bitmap bitmap = new Bitmap(this.pnlBackground.BackgroundImage);
                    //  return bitmap.GetPixel(20, 30);
                    return Color.FromArgb(250, 250, 250);//灰色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        //控件背景颜色 包括边框 picbox
        public Color ControlBorderBackColor
        {
            get
            {
                if (this.ptbTopMiddle.BackgroundImage != null)
                {
                    // Bitmap bitmap = new Bitmap(this.ptbTopMiddle.BackgroundImage);
                    // return bitmap.GetPixel(1, 80);
                    return Color.FromArgb(250, 250, 250);//灰色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        public Color PicboxBorderBackColorYellow
        {
            get
            {
                if (this.ptbTopMiddle.BackgroundImage != null)
                {
                    // Bitmap bitmap = new Bitmap(this.ptbTopMiddle.BackgroundImage);
                    // return bitmap.GetPixel(1, 80);
                    return Color.FromArgb(252, 206, 6);//黄色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        //左边导航的背景颜色
        public Color MainFormBorderColor
        {
            get
            {
                if (this.ptbTopLeft.BackgroundImage != null)
                {
                    // Bitmap bitmap = new Bitmap(this.ptbTopLeft.BackgroundImage);
                    // return bitmap.GetPixel(1, 20);
                    return Color.FromArgb(250, 250, 250);//灰色
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            //pboxBottom.SetBounds((this.Width / 2) - (pboxBottom.Width / 2),
            //pboxBottom.Height,
            //pboxBottom.Width, pboxBottom.Height, BoundsSpecified.Location);
            switch (m.Msg)
            {
                case Win32.WM_COMMAND:
                    Win32.SendMessage(Handle, Win32.WM_SYSCOMMAND, (int)m.WParam, (int)m.LParam);
                    break;
                case Win32.WM_SYSCOMMAND:
                    base.WndProc(ref m);

                    if (m.WParam.ToInt64() == Win32.SC_RESTORE)
                    {
                        this.Height += 6;
                        this.Width += 6;
                        maxBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tl-window.png")));
                        this.btnMaxResore.NormalImage = maxBitmap.Clone(new Rectangle(0, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.MouseMoveImage = maxBitmap.Clone(new Rectangle(26, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.MouseDownImage = maxBitmap.Clone(new Rectangle(52, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.ToolTip = "还原";

                        Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
                    }
                    else if (m.WParam.ToInt64() == Win32.SC_MAXIMIZE)
                    {
                        Application.DoEvents();
                        resoreBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tl-windows.png")));
                        this.btnMaxResore.NormalImage = resoreBitmap.Clone(new Rectangle(0, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.MouseMoveImage = resoreBitmap.Clone(new Rectangle(26, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.MouseDownImage = resoreBitmap.Clone(new Rectangle(52, 0, 26, 20), PixelFormat.Format64bppPArgb);
                        this.btnMaxResore.ToolTip = "最大化";

                        Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
                    }

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Controls.Add(this.pnlBackground);
            //this.Controls.Add(this.pnlRight);
            //this.Controls.Add(this.pnlLeft);
            // this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCaption);
            if (!DesignMode)
            {
                this.Hide();
            }
            try
            {
                string backimgpath = "CRD.WinUI.Resources.help.png";
                Assembly assem = Assembly.Load("CRD.WinUI"); ;
                foreach (string resourceName in assem.GetManifestResourceNames())
                {
                    if (backimgpath == resourceName)
                    {
                        // MessageBox.Show(resourceName);
                        Stream stream = assem.GetManifestResourceStream(backimgpath);
                        this.BackgroundImage = new Bitmap(stream);
                    }
                }

                HelpBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-help.png")));//帮助
                SupportBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-config.png"))); //服务与支持
                BigCloseBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-power.png")));//退出--》大图片
                resoreBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.tl-miniz.png")));
                maxBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.tl-windows.png")));
                skinButton = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.ColorBtn.png")));
                menuButton = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.MenuBtn.png")));
            }
            catch (Exception)
            {

                throw;
            }
            //  this.lblText.Text = this.Text;

            Application.DoEvents();

            base.OnLoad(e);

            if (!DesignMode)
            {
                int maxWidth = Screen.GetWorkingArea(this).Width + 15;
                int maxHeight = Screen.GetWorkingArea(this).Height + 8;

                this.MaximumSize = new Size(SystemInformation.WorkingArea.Size.Width + 15, SystemInformation.WorkingArea.Size.Height + 8);
            }

            Application.DoEvents();
            if (this.WindowState == FormWindowState.Normal)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 274, Win32.SC_MAXIMIZE, 0);
            }
            else
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 274, Win32.SC_RESTORE, 0);
            }
            pboxBottom1.SetBounds((this.Width / 2) - (pboxBottom1.Width / 2), (pboxBottom1.Height / 2), pboxBottom1.Width, pboxBottom1.Height, BoundsSpecified.Location);
            this.Show();
        }



        protected override void OnShown(EventArgs e)
        {
            Application.DoEvents();
            base.OnShown(e);
            Shared.FlushMemory();
        }




        public override void ReSetFormBitmap()
        {

            this.pnlCaption.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.bordertm.bmp"));

            this.ptbTopLeft.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.bordertl.bmp"));//CRD.WinUI.Resources.MainWin.Border.bordertl.bmp   
            this.ptbTopMiddle.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.top-bg.png"));//CRD.WinUI.Resources.MainWin.Border.bordertm.bmp
            // this.ptbTopRight.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.bordertr.bmp"));
            // this.ptbLeft.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.borderl.bmp"));
            // this.ptbRight.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.borderr.bmp"));
            //this.ptbBottomLeft.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.borderbl.bmp"));
            // this.ptbBottomMiddle.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.borderbm.bmp"));
            // this.ptbBottomRight.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.borderbr.bmp"));
            this.pnlBackground.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Border.bg.bmp"));
            //add by yibin

            Image logoImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.logo-txt.png"));
            this.logoName.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.logo-txt.png"));

            //this.logoName.Image.Height = logoImage.Height;
            //this.logoName.Image.Width = logoImage.Width;


            this.Logo.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.cs-logo.png"));
            this.logoRight.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.header-bg.png"));

            this.pboxBottom1.BackgroundImage = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.logo.png"));

            Bitmap minBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.tl-miniz.png")));
            this.btnMin.NormalImage = minBitmap.Clone(new Rectangle(0, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnMin.MouseMoveImage = minBitmap.Clone(new Rectangle(26, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnMin.MouseDownImage = minBitmap.Clone(new Rectangle(52, 0, 26, 20), PixelFormat.Format64bppPArgb);

            this.btnMaxResore.NormalImage = maxBitmap.Clone(new Rectangle(0, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnMaxResore.MouseMoveImage = maxBitmap.Clone(new Rectangle(26, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnMaxResore.MouseDownImage = maxBitmap.Clone(new Rectangle(52, 0, 26, 20), PixelFormat.Format64bppPArgb);

            Bitmap closeBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Button.tl-close.png")));
            this.btnClose.NormalImage = closeBitmap.Clone(new Rectangle(0, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnClose.MouseMoveImage = closeBitmap.Clone(new Rectangle(26, 0, 26, 20), PixelFormat.Format64bppPArgb);
            this.btnClose.MouseDownImage = closeBitmap.Clone(new Rectangle(52, 0, 26, 20), PixelFormat.Format64bppPArgb);

            //帮助 大图
            HelpBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-help.png")));//帮助
            this.btnHelp.NormalImage = HelpBitmap.Clone(new Rectangle(0, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnHelp.MouseMoveImage = HelpBitmap.Clone(new Rectangle(60, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnHelp.MouseDownImage = HelpBitmap.Clone(new Rectangle(120, 0, 60, 60), PixelFormat.Format64bppPArgb);

            //服务与支持 大图
            SupportBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-config.png"))); //服务与支持
            this.btnSupport.NormalImage = SupportBitmap.Clone(new Rectangle(0, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnSupport.MouseMoveImage = SupportBitmap.Clone(new Rectangle(60, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnSupport.MouseDownImage = SupportBitmap.Clone(new Rectangle(120, 0, 60, 60), PixelFormat.Format64bppPArgb);


            //退出 大图
            BigCloseBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.OurwayPhoto.tb-power.png")));//退出--》大图片
            this.btnbigClose.NormalImage = BigCloseBitmap.Clone(new Rectangle(0, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnbigClose.MouseMoveImage = BigCloseBitmap.Clone(new Rectangle(60, 0, 60, 60), PixelFormat.Format64bppPArgb);
            this.btnbigClose.MouseDownImage = BigCloseBitmap.Clone(new Rectangle(120, 0, 60, 60), PixelFormat.Format64bppPArgb);
            //this.btnSkin.NormalImage = skinButton.Clone(new Rectangle(0, 0, 40, 14), PixelFormat.Format64bppPArgb);
            //this.btnSkin.MouseMoveImage = skinButton.Clone(new Rectangle(40, 0, 40, 14), PixelFormat.Format64bppPArgb);
            //this.btnSkin.MouseDownImage = skinButton.Clone(new Rectangle(80, 0, 40, 14), PixelFormat.Format64bppPArgb);


            //this.btnMenu.NormalImage = menuButton.Clone(new Rectangle(0, 0, 40, 14), PixelFormat.Format64bppPArgb);
            //this.btnMenu.MouseMoveImage = menuButton.Clone(new Rectangle(40, 0, 40, 14), PixelFormat.Format64bppPArgb);
            //this.btnMenu.MouseDownImage = menuButton.Clone(new Rectangle(80, 0, 40, 14), PixelFormat.Format64bppPArgb);

            this.CurrentSkinColor = SkinColor.Default;
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (this._skinForm != null && !this._skinForm.IsDisposed && this._skinForm.Visible)
            {
                this._skinForm.Close();
            }
        }

        private void ptbTopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) return;

            if (this.FormStyle == FormBorderStyle.FixedDialog ||
                this.FormStyle == FormBorderStyle.Fixed3D)
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
                return;
            }

            if (e.X <= 8 && e.Y <= 8)
            {
                ((Control)sender).Cursor = Cursors.SizeNWSE;
                if (e.Button == MouseButtons.Left) { Win32.ReleaseCapture(); Win32.SendMessage(Handle, 274, 61440 + 4, 0); }
            }
            else if (e.X <= 4)
            {
                ((Control)sender).Cursor = Cursors.SizeWE;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 1, 0);
                }
            }

            else if (e.Y <= 4)
            {
                ((Control)sender).Cursor = Cursors.SizeNS;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 3, 0);
                }
            }
            else
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
        }

        private void ptbTopMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) return;

            if (this.FormStyle == FormBorderStyle.FixedDialog ||
                this.FormStyle == FormBorderStyle.Fixed3D)
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
                return;
            }

            if (e.Y <= 2)
            {
                ((Control)sender).Cursor = Cursors.SizeNS;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 3, 0);
                }
            }
            else
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
        }

        private void ptbTopRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) return;

            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            if (e.Y > 8)
            {
                //  ptbTopRight.Cursor = Cursors.SizeWE;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 2, 0);
                }
            }
            else if (e.X > 5)
            {
                ((Control)sender).Cursor = Cursors.SizeNESW;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 5, 0);
                }
            }
            else
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
        }

        private void Caption_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ((Control)sender).Cursor == Cursors.Default && e.Y <= SystemInformation.CaptionHeight)
            {

            }

            if (e.Y <= SystemInformation.CaptionHeight)
            {
                _captionMouseUp = e.Location;
            }
            else
            {
                _captionMouseUp = Point.Empty;
            }

            if (this._skinForm != null && !this._skinForm.IsDisposed && this._skinForm.Visible)
            {
                this._skinForm.Close();
            }
        }

        private void Caption_DouClick(object sender, EventArgs e)
        {
            if (((Control)sender).Cursor != Cursors.Default) return;
            if (_captionMouseUp == Point.Empty) return;

            Win32.ReleaseCapture();
            if (WindowState != FormWindowState.Maximized)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 273, Win32.SC_MAXIMIZE, 0);

            }
            else
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 273, Win32.SC_RESTORE, 0);
            }
        }

        private void ptbLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            //if (e.Y > this.ptbLeft.Height - 5)
            //{
            //    this.ptbBottomLeft.Cursor = Cursors.SizeNESW;

            //}
            //else
            //{
            //    ptbLeft.Cursor = Cursors.SizeWE;
            //}

            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 7, 0);
            }
        }

        private void ptbRight_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            //  this.ptbRight.Cursor = Cursors.SizeWE;
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 2, 0);
            }
        }

        private void ptbBottomLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            // this.ptbRight.Cursor = Cursors.SizeNESW;
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 7, 0);
            }


        }

        private void ptbBottomMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            ((Control)sender).Cursor = Cursors.SizeNS;
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 6, 0);
            }
        }

        private void ptbBottomRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.FormStyle == FormBorderStyle.Fixed3D) return;
            if (this.FormStyle == FormBorderStyle.FixedDialog) return;

            if (WindowState == FormWindowState.Maximized) return;

            ((Control)sender).Cursor = Cursors.SizeNWSE;
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();

                Win32.SendMessage(Handle, 274, 61440 + 8, 0);
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(this.Handle, 274, Win32.SC_MINIMIZE, 0);
        }

        private void btnMaxResore_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 274, Win32.SC_MAXIMIZE, 0);
            }
            else
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, 274, Win32.SC_RESTORE, 0);
            }
            pboxBottom1.SetBounds((this.Width / 2) - (pboxBottom1.Width / 2), (pboxBottom1.Height / 2), pboxBottom1.Width, pboxBottom1.Height, BoundsSpecified.Location);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSkin_Click(object sender, EventArgs e)
        {
            Win32.ReleaseCapture();
            if (_skinForm == null || _skinForm.IsDisposed)
            {
                _skinForm = new SkinForm();
                _skinForm.StartPosition = FormStartPosition.Manual;
            }
            // _skinForm.Location = new Point(this.Left + this.btnSkin.Left, this.Top + SystemInformation.CaptionHeight);
            _skinForm.Location = new Point(this.Left, this.Top + SystemInformation.CaptionHeight);
            _skinForm.Show();
            _skinForm.BringToFront();
            _skinForm.Visible = true;
        }

        public override void ChangeBackgroundStripe(BackgroundStripe backgroundStripe)
        {
            if (backgroundStripe != BackgroundStripe.Default)
            {
                Stream map = Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.MainWin.Shading." + backgroundStripe.GetHashCode() + ".png");
                this.ptbTopLeft.Image = Mergerimg(map);

                this.ReSetFormBitmap();

                Shared.ChangeBackgroundStripe(backgroundStripe, this);

            }
            else
            {
                this.ptbTopLeft.Image = null;
                ReSetFormBitmap();
            }

            base.ChangeBackgroundStripe(backgroundStripe);

        }

        private Bitmap Mergerimg(Stream map)
        {
            Bitmap backgroudimg = new Bitmap(314, 94);
            Graphics g = Graphics.FromImage(backgroudimg);
            Image caption = Image.FromStream(map);

            g.DrawImage(caption, new Rectangle(0, 28, caption.Width, 64));

            g.DrawLine(new Pen(this.MainFormBorderColor, 3f), new Point(1, 28), new Point(1, 94));
            g.Dispose();

            return backgroudimg;
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void GCtimer_Tick(object sender, EventArgs e)
        {
            Shared.FlushMemory();
        }

        public void PerformAllFormChangeSkinColor(SkinColor skinColor)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormBase)
                {
                    ((FormBase)form).PerformChangeSkinColor(skinColor);
                }
            }
        }

        private void lblText_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) return;

            if (this.FormStyle == FormBorderStyle.FixedDialog ||
                this.FormStyle == FormBorderStyle.Fixed3D)
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
                return;
            }

            if (e.Y <= 4)
            {
                ((Control)sender).Cursor = Cursors.SizeNS;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 3, 0);
                }
            }
            else
            {
                ((Control)sender).Cursor = Cursors.Default;
                if (e.Button == MouseButtons.Left && e.Y <= SystemInformation.CaptionHeight)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void btnMenu_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //  btnMenu.ContextMenuStrip = SkinContextMenuStrip1;
                //   btnMenu.ContextMenuStrip.Show(this.Left + this.btnMenu .Left, this.Top + SystemInformation.CaptionHeight);

            }
            catch (Exception)
            {
                MessageBoxForm objfor = new MessageBoxForm("正在建设中！！！");
            }
        }

        private void ptbTopMiddle_Click(object sender, EventArgs e)
        {

        }

        //改变pictureBox的边框颜色，设置pb边框颜色，重绘，外观
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(Color.Red);
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }

        //帮助
        private void btnHelp_Click(object sender, EventArgs e)
        {
            //string DownLoadPath = VersionHelper.DownLoadPath;
            //DownLoadPath += "\\软件操作手册.doc";
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = " doc files(*.doc)|*.doc|All files(*.*)|*.*";
            //saveFileDialog1.FilterIndex = 1;
            //saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.FileName += System.IO.Path.GetFileName(DownLoadPath);

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    bool isImpersonated = false;
            //    try
            //    {
            //        if (VersionHelper.impersonateValidUser())
            //        {
            //            isImpersonated = true;
            //            File.Copy(DownLoadPath, saveFileDialog1.FileName, true);
            //            MessageBox.Show("下载成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message+ex.StackTrace, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        if (isImpersonated)
            //            VersionHelper.undoImpersonation();
            //    }
            //}
            if (MessageBox.Show("艾萨信息科技有限公司，联系热线：020-38609122", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
        }

        //服务与支持
        private void btnSupport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("艾萨信息科技有限公司，联系热线：020-38609122", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
        }

        //退出
        private void btnbigClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定退出系统？", "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Application.Exit();
        }


    }
}
