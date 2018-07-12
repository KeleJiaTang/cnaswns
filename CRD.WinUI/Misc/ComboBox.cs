/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CRD.Common;

namespace CRD.WinUI.Misc
{
    public class ComboBox : System.Windows.Forms.ComboBox
    {
        private Image _mouseMoveImage = null;
        private Image _mouseDownImage = null;
        private Image _normalImage = null;


        public ComboBox()
            : base()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.UpdateStyles();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!DesignMode && this.Items.Count != 0)
            {
                this.DropDownHeight = this.Items.Count * 17;
            }
            ResetBitmap();
        }

        const int WM_ERASEBKGND = 0x14;
        const int WM_PAINT = 0xF;
        const int WM_NC_HITTEST = 0x84;
        const int WM_NC_PAINT = 0x85;
        const int WM_PRINTCLIENT = 0x318;
        const int WM_SETCURSOR = 0x20;

        protected override void WndProc(ref Message m)
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;

            switch (m.Msg)
            {
                case 133:
                    hDC = Win32.GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    Win32.SendMessage(this.Handle, WM_ERASEBKGND, hDC.ToInt32(), 0);
                    SendPrintClientMsg();
                    Win32.SendMessage(this.Handle, WM_PAINT, 0, 0);
                    OverrideControlBorder(gdc);
                    m.Result = (IntPtr)1;	// indicate msg has been processed
                    Win32.ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                case WM_PAINT:
                    base.WndProc(ref m);
                    hDC = Win32.GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);

                    OverrideDropDown(gdc);
                    OverrideControlBorder(gdc);
                    Win32.ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
            //base.WndProc(ref m);
            //if (m.Msg == 0xf || m.Msg == 0x133)
            //{
            //    Shared.ResetBorderColor(m, this);
            //}
        }

        private static int DropDownButtonWidth = 17;

        private void OverrideDropDown(Graphics g)
        {
            if (DesignMode) return;

            Rectangle rect = new Rectangle(this.Width - DropDownButtonWidth, 0, DropDownButtonWidth, this.Height);

            g.FillRectangle(new SolidBrush(Color.White), rect);

            if (this.Enabled)
            {
                if (_mouseEnter)
                {
                    g.DrawImage(this.MouseMoveImage, new Rectangle(this.Width - 20, 3, 16, 16));
                }
                else
                {
                    g.DrawImage(this.NormalImage, new Rectangle(this.Width - 20, 3, 16, 16));
                }
            }
            else
            {
                g.DrawImage(Shared.NotEnableDrawButton, new Rectangle(this.Width - 20, 3, 16, 16));
            }
        }

        private Pen BorderPen = new Pen(Shared.ControlBorderBackColor, 2);
        private Pen BorderPenControl = new Pen(Shared.ControlBorderBackColor, 2);

        private void OverrideControlBorder(Graphics g)
        {
            g.DrawRectangle(new Pen(Shared.ControlBorderBackColor, 2), new Rectangle(0, 0, this.Width, this.Height));

        }

        private void SendPrintClientMsg()
        {
            // We send this message for the control to redraw the client area
            Graphics gClient = this.CreateGraphics();
            IntPtr ptrClientDC = gClient.GetHdc();
            Win32.SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC.ToInt32(), 0);
            gClient.ReleaseHdc(ptrClientDC);
            gClient.Dispose();
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            //绘制区域
            Rectangle r = e.Bounds;

            Font fn = null;
            if (e.Index >= 0)
            {
                if (e.State == DrawItemState.None)
                {
                    //设置字体、字符串格式、对齐方式
                    fn = e.Font;
                    string s = this.Items[e.Index].ToString ();
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    //根据不同的状态用不同的颜色表示
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), r);
                        e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r, sf);
                        e.DrawFocusRectangle();
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), r);
                        e.Graphics.DrawString(s, fn, new SolidBrush(Shared.FontColor), r, sf);
                        e.DrawFocusRectangle();
                    }
                }
                else
                {
                    fn = e.Font;
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    string s = this.Items[e.Index].ToString ();
                    e.Graphics.FillRectangle(new SolidBrush(Shared.ControlBackColor), r);
                    e.Graphics.DrawString(s, fn, new SolidBrush(Shared.FontColor), r, sf);
                    //e.DrawFocusRectangle();
                }
            }

            //base.OnDrawItem(e);
            //g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(this.Width - 20, 0, 20, this.Height));

        }

        private bool _mouseEnter = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEnter = true;

            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            hDC = Win32.GetWindowDC(this.Handle);
            gdc = Graphics.FromHdc(hDC);

            gdc.DrawImage(Shared.MouseMoveDrawButton, new Rectangle(this.Width - 20, 3, 16, 16));

            Win32.ReleaseDC(this.Handle, hDC);
            gdc.Dispose();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseEnter = false;
            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            hDC = Win32.GetWindowDC(this.Handle);
            gdc = Graphics.FromHdc(hDC);

            gdc.DrawImage(Shared.NomalDrawButton, new Rectangle(this.Width - 20, 3, 16, 16));

            Win32.ReleaseDC(this.Handle, hDC);
            base.OnMouseLeave(e);
        }

        public Image MouseMoveImage
        {
            get
            {
                return _mouseMoveImage;
            }
            set
            {
                _mouseMoveImage = value;
            }
        }

        public Image MouseDownImage
        {
            get
            {
                return _mouseDownImage;
            }
            set
            {
                _mouseDownImage = value;
            }
        }

        public Image NormalImage
        {
            get
            {
                return _normalImage;
            }
            set
            {
                _normalImage = value;
            }
        }

        public void ResetBitmap()
        {
            this.NormalImage = Shared.NomalDrawButton;
            this.MouseDownImage = Shared.MouseDownDrawButton;
            this.MouseMoveImage = Shared.MouseMoveDrawButton;
        }


    }
}