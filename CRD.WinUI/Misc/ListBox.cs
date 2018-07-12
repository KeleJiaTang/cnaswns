using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using CRD.Common;
using System.Windows.Forms;

namespace CRD.WinUI.Misc
{
    

    public class ListBox : System.Windows.Forms.ListBox
    {
        const int WM_ERASEBKGND = 0x14;
        const int WM_PAINT = 0xF;
        const int WM_NC_HITTEST = 0x84;
        const int WM_NC_PAINT = 0x85;
        const int WM_PRINTCLIENT = 0x318;
        const int WM_SETCURSOR = 0x20;

        public ListBox()
            : base()
        {
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
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
                    OverrideControlBorder(gdc);
                    //  OverrideDropDown(gdc);
                    // OverrideControlBorder(gdc);
                    Win32.ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }

           // base.WndProc(ref m);
            //if (m.Msg == 0xf || m.Msg == 0x133)
            //{
            //    Shared.ResetBorderColor(m, this);
            //}
        }

        private void OverrideControlBorder(Graphics gdc)
        {
            gdc.DrawImage(Shared.ScrollBarUpButton, new Rectangle(this.Width - 20, 0, 16, 16));
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
                    string s = (string)this.Items[e.Index];
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
                    string s = (string)this.Items[e.Index];
                    e.Graphics.FillRectangle(new SolidBrush(Shared.ControlBackColor), r);
                    e.Graphics.DrawString(s, fn, new SolidBrush(Shared.FontColor), r, sf);
                    //e.DrawFocusRectangle();
                }
                
            }
            
        }
    }
}
