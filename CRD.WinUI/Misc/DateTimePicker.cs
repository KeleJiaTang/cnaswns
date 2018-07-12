using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using CRD.Common;

namespace CRD.WinUI.Misc
{
    public class DateTimePicker : System.Windows.Forms.DateTimePicker
    {
        private Image _mouseMoveImage = null;
        private Image _mouseDownImage = null;
        private Image _normalImage = null;

        #region ComboInfoHelper
        internal class ComboInfoHelper
        {
            [DllImport("user32")]
            private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

            #region RECT struct
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
            #endregion

            #region ComboBoxInfo Struct
            [StructLayout(LayoutKind.Sequential)]
            private struct ComboBoxInfo
            {
                public int cbSize;
                public RECT rcItem;
                public RECT rcButton;
                public IntPtr stateButton;
                public IntPtr hwndCombo;
                public IntPtr hwndEdit;
                public IntPtr hwndList;
            }
            #endregion

            public static int GetComboDropDownWidth()
            {
                ComboBox cb = new ComboBox();
                int width = GetComboDropDownWidth(cb.Handle);
                cb.Dispose();
                return width;
            }
            public static int GetComboDropDownWidth(IntPtr handle)
            {
                ComboBoxInfo cbi = new ComboBoxInfo();
                cbi.cbSize = Marshal.SizeOf(cbi);
                GetComboBoxInfo(handle, ref cbi);
                int width = cbi.rcButton.Right - cbi.rcButton.Left;
                return width;
            }
        }
        #endregion

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, object lParam);

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        const int WM_ERASEBKGND = 0x14;
        const int WM_PAINT = 0xF;
        const int WM_NC_HITTEST = 0x84;
        const int WM_NC_PAINT = 0x85;
        const int WM_PRINTCLIENT = 0x318;
        const int WM_SETCURSOR = 0x20;


        private Pen BorderPen = new Pen(Shared.ControlBorderBackColor, 2);
        private Pen BorderPenControl = new Pen(Shared.ControlBorderBackColor, 2);
        private bool DroppedDown = false;
        private int InvalidateSince = 0;
        private static int DropDownButtonWidth = 17;

        static DateTimePicker()
        {
            // 2 pixel extra is for the 3D border around the pulldown button on the left and right
            DropDownButtonWidth = ComboInfoHelper.GetComboDropDownWidth() + 2;
        }

        public DateTimePicker()
            : base()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ResetBitmap();
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

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            this.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {

            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            switch (m.Msg)
            {
                case WM_NC_PAINT:
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    SendMessage(this.Handle, WM_ERASEBKGND, hDC, 0);
                    SendPrintClientMsg();
                    SendMessage(this.Handle, WM_PAINT, IntPtr.Zero, 0);
                    OverrideControlBorder(gdc);
                    m.Result = (IntPtr)1;	// indicate msg has been processed
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                case WM_PAINT:
                    base.WndProc(ref m);
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    OverrideDropDown(gdc);
                    OverrideControlBorder(gdc);
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                /*
                // We don't need this anymore, handle by WM_SETCURSOR
                case WM_NC_HITTEST: 
                    base.WndProc(ref m);
                    if (DroppedDown)
                    {
                        OverrideDropDown(gdc);
                        OverrideControlBorder(gdc);
                    }
                    break;
                */
                case WM_SETCURSOR:
                    base.WndProc(ref m);
                    // The value 3 is discovered by trial on error, and cover all kinds of scenarios
                    // InvalidateSince < 2 wil have problem if the control is not in focus and dropdown is clicked
                    if (DroppedDown && InvalidateSince < 3)
                    {
                        Invalidate();
                        InvalidateSince++;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void SendPrintClientMsg()
        {
            // We send this message for the control to redraw the client area
            Graphics gClient = this.CreateGraphics();
            IntPtr ptrClientDC = gClient.GetHdc();
            SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC, 0);
            gClient.ReleaseHdc(ptrClientDC);
            gClient.Dispose();
        }

        private void OverrideDropDown(Graphics g)
        {
            //if (!this.ShowUpDown)
            //{
            Rectangle rect = new Rectangle(this.Width - DropDownButtonWidth, 0, DropDownButtonWidth, this.Height);
            //ControlPaint.DrawComboButton(g, rect, ButtonState.Flat);
            //}
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
            gdc.Dispose();
            base.OnMouseLeave(e);
        }

        private void OverrideControlBorder(Graphics g)
        {
            g.DrawRectangle(new Pen(Shared.ControlBorderBackColor, 2), new Rectangle(0, 0, this.Width, this.Height));
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            InvalidateSince = 0;
            DroppedDown = true;
            base.OnDropDown(eventargs);
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            DroppedDown = false;
            base.OnCloseUp(eventargs);
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

    }
}
