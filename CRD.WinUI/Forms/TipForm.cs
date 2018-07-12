using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CRD.WinUI.Forms
{
    public partial class TipForm : FormBase
    {
        public TipForm()
        {
            InitializeComponent();
        }

        public override void ReSetFormBitmap()
        {
            Bitmap closeBitmap = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.Tip.close_btn.bmp")));
            this.btnClose.NormalImage = closeBitmap.Clone(new Rectangle(0, 0, 37, 21), PixelFormat.Format64bppPArgb);
            this.btnClose.MouseMoveImage = closeBitmap.Clone(new Rectangle(37, 0, 37, 21), PixelFormat.Format64bppPArgb);
            this.btnClose.MouseDownImage = closeBitmap.Clone(new Rectangle(74, 0, 37, 21), PixelFormat.Format64bppPArgb);

            this.ptbBg.BackgroundImage = Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.Tip.tipbg.bmp"), true, false);
            this.BackgroundImage = this.ptbBg.BackgroundImage;

            this.btnMessage.NormalImage =Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.Tip.watch_btn_hover.ico"));
            this.btnMessage.MouseDownImage = Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.Tip.watch_btn_press.ico"));
            this.btnMessage.MouseMoveImage = Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.Tip.watch_btn_hover.ico")); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height-this.Height);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            PerformMessageClick();
        }

        public virtual void PerformMessageClick()
        {
 
        }
    }
}
