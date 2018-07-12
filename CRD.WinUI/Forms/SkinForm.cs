using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace CRD.WinUI.Forms
{
    public partial class SkinForm : FormBase
    {
        public SkinForm()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            SetSkinColorBitmap();

            SetTexturesBitmap();

            this.CurrentSkinColor = Shared.CurrentSkinColor;

            base.OnLoad(e);
        }

        void SetSkinColorBitmap()
        {
            Stream skinStream = Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Skin.colors.bmp");

            Bitmap skinBitmap = new Bitmap(Bitmap.FromStream(skinStream));

            this.btnSkinColor0.NormalImage = skinBitmap.Clone(new Rectangle(2, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor0.MouseMoveImage = skinBitmap.Clone(new Rectangle(26, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor0.MouseDownImage = skinBitmap.Clone(new Rectangle(48, 0, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor1.NormalImage = skinBitmap.Clone(new Rectangle(74, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor1.MouseMoveImage = skinBitmap.Clone(new Rectangle(98, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor1.MouseDownImage = skinBitmap.Clone(new Rectangle(120, 0, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor2.NormalImage = skinBitmap.Clone(new Rectangle(146, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor2.MouseMoveImage = skinBitmap.Clone(new Rectangle(170, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor2.MouseDownImage = skinBitmap.Clone(new Rectangle(192, 0, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor3.NormalImage = skinBitmap.Clone(new Rectangle(218, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor3.MouseMoveImage = skinBitmap.Clone(new Rectangle(242, 2, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor3.MouseDownImage = skinBitmap.Clone(new Rectangle(264, 0, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor4.NormalImage = skinBitmap.Clone(new Rectangle(2, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor4.MouseMoveImage = skinBitmap.Clone(new Rectangle(26, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor4.MouseDownImage = skinBitmap.Clone(new Rectangle(48, 24, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor5.NormalImage = skinBitmap.Clone(new Rectangle(74, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor5.MouseMoveImage = skinBitmap.Clone(new Rectangle(98, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor5.MouseDownImage = skinBitmap.Clone(new Rectangle(120, 24, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor6.NormalImage = skinBitmap.Clone(new Rectangle(146, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor6.MouseMoveImage = skinBitmap.Clone(new Rectangle(170, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor6.MouseDownImage = skinBitmap.Clone(new Rectangle(192, 24, 24, 24), PixelFormat.Format64bppPArgb);

            this.btnSkinColor7.NormalImage = skinBitmap.Clone(new Rectangle(218, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor7.MouseMoveImage = skinBitmap.Clone(new Rectangle(242, 26, 20, 20), PixelFormat.Format64bppPArgb);
            this.btnSkinColor7.MouseDownImage = skinBitmap.Clone(new Rectangle(264, 24, 24, 24), PixelFormat.Format64bppPArgb);

        }

        void SetTexturesBitmap()
        {
            Stream texturesStream = Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Skin.textures.bmp");
            Bitmap texturesBitmap = new Bitmap(Bitmap.FromStream(texturesStream));

            this.btnShading0.NormalImage = texturesBitmap.Clone(new Rectangle(2, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading0.MouseMoveImage = texturesBitmap.Clone(new Rectangle(37, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading0.MouseDownImage = texturesBitmap.Clone(new Rectangle(70, 0, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading1.NormalImage = texturesBitmap.Clone(new Rectangle(107, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading1.MouseMoveImage = texturesBitmap.Clone(new Rectangle(142, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading1.MouseDownImage = texturesBitmap.Clone(new Rectangle(175, 0, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading2.NormalImage = texturesBitmap.Clone(new Rectangle(212, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading2.MouseMoveImage = texturesBitmap.Clone(new Rectangle(247, 2, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading2.MouseDownImage = texturesBitmap.Clone(new Rectangle(280, 0, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading3.NormalImage = texturesBitmap.Clone(new Rectangle(2, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading3.MouseMoveImage = texturesBitmap.Clone(new Rectangle(37, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading3.MouseDownImage = texturesBitmap.Clone(new Rectangle(70, 35, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading4.NormalImage = texturesBitmap.Clone(new Rectangle(107, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading4.MouseMoveImage = texturesBitmap.Clone(new Rectangle(142, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading4.MouseDownImage = texturesBitmap.Clone(new Rectangle(175, 35, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading5.NormalImage = texturesBitmap.Clone(new Rectangle(212, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading5.MouseMoveImage = texturesBitmap.Clone(new Rectangle(247, 37, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading5.MouseDownImage = texturesBitmap.Clone(new Rectangle(280, 35, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading6.NormalImage = texturesBitmap.Clone(new Rectangle(2, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading6.MouseMoveImage = texturesBitmap.Clone(new Rectangle(37, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading6.MouseDownImage = texturesBitmap.Clone(new Rectangle(70, 70, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading7.NormalImage = texturesBitmap.Clone(new Rectangle(107, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading7.MouseMoveImage = texturesBitmap.Clone(new Rectangle(142, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading7.MouseDownImage = texturesBitmap.Clone(new Rectangle(175, 70, 35, 35), PixelFormat.Format64bppPArgb);

            this.btnShading8.NormalImage = texturesBitmap.Clone(new Rectangle(212, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading8.MouseMoveImage = texturesBitmap.Clone(new Rectangle(247, 72, 31, 31), PixelFormat.Format64bppPArgb);
            this.btnShading8.MouseDownImage = texturesBitmap.Clone(new Rectangle(280, 70, 35, 35), PixelFormat.Format64bppPArgb);


        }

        private void ChangeBackgroundStripe_Click(object sender, EventArgs e)
        {
            Shared.MainForm.PerformChangeBackgroundStripe(GetBackgroundStripeEnum(((Control)sender).Tag.ToString()));
            this.Hide();
        }

        protected BackgroundStripe GetBackgroundStripeEnum(string stripe)
        {
            BackgroundStripe c = BackgroundStripe.Default;

            if (!string.IsNullOrEmpty(stripe))
            {
                foreach (Enum i in Enum.GetValues(typeof(BackgroundStripe)))
                {
                    if (i.ToString() == stripe)
                    {
                       // c = (BackgroundStripe)Enum.Parse(typeof(BackgroundStripe), i.ToString());
                        c = (BackgroundStripe)i;
                        return c;
                    }

                }
            }
            return c;

        }

        private void ChangeSkinColor_Click(object sender, EventArgs e)
        {
            Shared.MainForm.PerformChangeSkinColor(GetSkinColorEnum(((Control)sender).Tag.ToString()));

            //try
            //{
                Application.DoEvents();

                this.Close();
                this.Dispose(true);
            //}
            //catch
            //{ 
            //}
        }

        protected SkinColor GetSkinColorEnum(string stripe)
        {
            SkinColor c = SkinColor.Default;

            if (!string.IsNullOrEmpty(stripe))
            {
                foreach (Enum i in Enum.GetValues(typeof(SkinColor)))
                {
                    if (i.ToString() == stripe)
                    {
                        c = (SkinColor)i;
                        return c;
                    }

                }
            }
            return c;

        }

        private void ChangeSkinColor_Scroll(object sender, EventArgs e)
        {
            Shared.HSLFilter.Hue = tkbHue.Value > 0 ? tkbHue.Value * 150 / 180 : tkbHue.Value * 210 / 180;

            Shared.HSLFilter.Saturation = stkbSaturation.Value > 0 ? stkbSaturation.Value * 100 / 150 : stkbSaturation.Value * 200 / 150;

            Shared.HSLFilter.Lightness = tkbLightnes.Value > 0 ? tkbLightnes.Value * 10 / 15 : tkbLightnes.Value * 20 / 15;

            Shared.MainForm.PerformChangeSkinColor();
            Shared.CurrentSkinColor = SkinColor.Undefault;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Close();
        }

    }
}
