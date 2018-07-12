using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CRD.Common;

namespace CRD.WinUI.Forms
{
    public partial class EnterUserControl : UserControl
    {
        public EnterUserControl()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            this.Controls.Remove(this.pnlRight);
            this.Controls.Remove(this.pnlLeft);
            this.Controls.Remove(this.pnlBackGroup);
        }

        protected override void WndProc(ref Message m)
        {
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
                        //this.btnMaxResore.NormalImage = maxBitmap.Clone(new Rectangle(0, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.MouseMoveImage = maxBitmap.Clone(new Rectangle(32, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.MouseDownImage = maxBitmap.Clone(new Rectangle(64, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.ToolTip = "还原";

                        //Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
                    }
                    else if (m.WParam.ToInt64() == Win32.SC_MAXIMIZE)
                    {
                        Application.DoEvents();
                        //this.btnMaxResore.NormalImage = resoreBitmap.Clone(new Rectangle(0, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.MouseMoveImage = resoreBitmap.Clone(new Rectangle(32, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.MouseDownImage = resoreBitmap.Clone(new Rectangle(64, 0, 32, 22), PixelFormat.Format64bppPArgb);
                        //this.btnMaxResore.ToolTip = "最大化";

                       // Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
                    }

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


      

        protected override void OnLoad(EventArgs e)
        {
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBackGroup);
           

            if (!DesignMode)
            {
                this.Hide();
            }

            base.OnLoad(e);

            Win32.SetWindowLong(this.Handle, -16,Win32.GetWindowLong(this.Handle,-16) -Win32.WS_MAXIMIZEBOX );

            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
           
        }

        private void Caption_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 9, 0);
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
               
            }
        }

        private void caption_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ((Control)sender).Cursor == Cursors.Default && e.Y <= SystemInformation.CaptionHeight)
            {
                Win32.TrackPopupMenu(Win32.GetSystemMenu(Handle, 0).ToInt32(), 2, Cursor.Position.X, Cursor.Position.Y, 0, Handle, 0);
            }
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        this.Region = new Region(new Rectangle(3, 3, this.ClientRectangle.Width - 2 * 3, this.ClientRectangle.Height - 2 * 3));

        //        int Rgn = Win32.CreateRoundRectRgn(3, 3, ClientSize.Width + 4, Height - 2, 7, 7);
        //        Win32.SetWindowRgn(this.Handle, Rgn, true);
        //    }
        //    base.OnResize(e);
        //}
    }
}

