using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CRD.Common;

namespace CRD.WinUI.Misc
{
   public class PictureBox:System.Windows.Forms.PictureBox
    {
       public PictureBox()
           : base()
       {
           this.BackColor = System.Drawing.Color.Transparent;
       }

       protected override void WndProc(ref System.Windows.Forms.Message m)
       {
           base.WndProc(ref m);
           if (m.Msg == 0xf || m.Msg == 0x133)
           {
               Shared.ResetBorderColor(m, this);
           }
       }


       //protected override void OnPaint(PaintEventArgs e)
       //{
       //    //IntPtr hDC = IntPtr.Zero;
       //    //Graphics gdc = null;
       //    //hDC = Win32.GetWindowDC(this.Handle);
       //    //gdc = Graphics.FromHdc(hDC);

       //    //gdc.DrawImage(Shared.MouseMoveDrawButton, new Rectangle(this.Width - 20, 3, 16, 16));

       //    //Win32.ReleaseDC(this.Handle, hDC);
       //    //gdc.Dispose();
       //    Pen pp = new Pen(Color.Blue);
       //    e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
       //    base.OnPaint(e);
       //}
       //protected override void OnPaint(PaintEventArgs e)
       //{
       //    if (!DesignMode)
       //    {
       //        Graphics g = e.Graphics;

       //        //SolidBrush bruch = new SolidBrush(Shared.MainForm.MainFormBackGroundColor2);

       //        //g.FillRectangle(bruch, 0, 0, 25, this.Height);

       //        //bruch = new SolidBrush(Color.White);
       //        //g.FillRectangle(bruch, 27, 0, this.Width - 27, this.Height);

       //        // Pen pen = new Pen(Color.FromArgb(25, 85, 95), 1f);
       //        Pen pen = new Pen(Shared.MainForm.MainFormBackGroundColor2, 1f);
       //        e.Graphics.DrawRectangle(pen, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
       //    }

       //    base.OnPaint(e);

       //}
    }
}
