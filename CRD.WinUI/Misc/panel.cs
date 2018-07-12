using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CRD.WinUI.Misc
{
    public class panel : System.Windows.Forms.Panel
    {
        private Color imageTransparentColor;

        public panel()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                Shared.ResetBorderColor(m, this);
            }
        }


        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);

           // Bitmap bitmap=new Bitmap(this.BackgroundImage);
            if (Shared.MainForm!=null)
            this.BackColor = Shared.MainForm.MainFormBackGroundColor; // bitmap.GetPixel(2, 2);
      

        }

        //protected override 

        public Color ImageTransparentColor
        {
            get
            {
                return this.imageTransparentColor;
            }
            set
            {
                this.imageTransparentColor = value;

                Bitmap image = this.BackgroundImage as Bitmap;

                if (((image != null) && (value != Color.Empty)) && !ImageAnimator.CanAnimate(image))
                {
                    try
                    {
                        this.BackColor = Shared.MainForm.MainFormBackGroundColor;
                        image.MakeTransparent(this.imageTransparentColor);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
