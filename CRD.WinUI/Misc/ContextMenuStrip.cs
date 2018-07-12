using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using CRD.Common;
using System.ComponentModel;

namespace CRD.WinUI.Misc
{
    [ToolboxBitmap(typeof(System.Windows.Forms.ContextMenuStrip))]
    public class ContextMenuStrip : System.Windows.Forms.ContextMenuStrip
    {
        int borderWidth = SystemInformation.BorderSize.Width;

        public ContextMenuStrip()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            ProfessionalColorTable ColorTable = new ProfessionalColorTable();
            ColorTable.UseSystemColors = true;
            if (!DesignMode)
            {
                this.Renderer = new ToolStripRenderer(ColorTable);
            }
            else
            {
                this.Renderer = new ToolStripProfessionalRenderer(ColorTable);
            }
            this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Font = new Font(this.Font.FontFamily, 10);
        }

        public ContextMenuStrip(IContainer container)
            : base(container)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            ProfessionalColorTable ColorTable = new ProfessionalColorTable();
            ColorTable.UseSystemColors = true;
            if (!DesignMode)
            {
                this.Renderer = new ToolStripRenderer(ColorTable);
            }
            else
            {
                this.Renderer = new ToolStripProfessionalRenderer(ColorTable);
            }
            this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Font = new Font(this.Font.FontFamily, 10);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                //GraphicsPath tpath = new GraphicsPath(FillMode.Winding);
                //tpath.AddRectangle(new Rectangle(borderWidth, borderWidth, Width - 2 * borderWidth - 5, Height + 1));

                //this.Region = new Region(tpath);

                //int Rgn;
                //Rgn = Win32.CreateRoundRectRgn(0, 0, Width + borderWidth, Height + 1,7, 7);
                //Win32.SetWindowRgn(this.Handle, Rgn, false);

                //this.Region = new Region(new Rectangle(3, 3, this.ClientRectangle.Width - 2 * 3, this.ClientRectangle.Height - 2 * 3));

                int Rgn = Win32.CreateRoundRectRgn(1, 1, ClientSize.Width , Height , 7, 7);
                Win32.SetWindowRgn(this.Handle, Rgn, true);
            }

            int result = Win32.SetClassLong(this.Handle, Win32.GCL_STYLE, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!DesignMode)
            {
                Graphics g = e.Graphics;

               SolidBrush bruch = new SolidBrush(Shared.MainForm.PicboxBorderBackColorYellow);
            
                g.FillRectangle(bruch, 0, 0, 25, this.Height);

                bruch = new SolidBrush(Color.White);
                g.FillRectangle(bruch, 27, 0, this.Width - 27, this.Height);

               // Pen pen = new Pen(Color.FromArgb(25, 85, 95), 1f);
                Pen pen = new Pen(Shared.ControlBorderBackColor, 1f);
                e.Graphics.DrawPath(pen, CreateRoundedRectanglePath(new Rectangle(1, 1, ClientSize.Width-3, Height-3), 5));
            }

            base.OnPaint(e);

        }

        internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        } 
  


    }
}
