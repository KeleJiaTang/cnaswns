/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CRD.WinUI
{

    public interface IFilter
    {
        Image ExecuteFilter(Image inputImage);
    }

    public abstract class BasicFilter : IFilter
    {
        private Color _bgColor = Color.FromArgb(0, 0, 0, 0);
        private InterpolationMode _interpolation = InterpolationMode.HighQualityBicubic;

        public abstract Image ExecuteFilter(Image img);

        public Color BackgroundColor
        {
            get
            {
                return this._bgColor;
            }
            set
            {
                this._bgColor = value;
            }
        }

        public InterpolationMode Interpolation
        {
            get
            {
                return this._interpolation;
            }
            set
            {
                this._interpolation = value;
            }
        }
    }

    public class HSLFilter : BasicFilter
    {
        private double _hue = 0.0;
        private double _lightness = 0.0;
        private double _saturation = 0.0;

        public override Image ExecuteFilter(Image img)
        {
            if (img == null) return null;

            PixelFormat pixelFormat = img.PixelFormat;
            //switch (pixelFormat)
            //{
            //    case PixelFormat.Format16bppGrayScale:
            //        return img;
            //}

            return this.ExecuteRgb8(img);

            if (pixelFormat == PixelFormat.Format8bppIndexed|| pixelFormat == PixelFormat.Format24bppRgb || pixelFormat == PixelFormat.Format32bppArgb || pixelFormat == PixelFormat.Format32bppRgb)
            {
                return this.ExecuteRgb8(img);
            }

            //if (((pixelFormat == PixelFormat.Format32bppRgb) ? 1 : 0) != 0)
            //{
            //    return this.ExecuteRgb8(img);
            //}
            if (pixelFormat == PixelFormat.Format48bppRgb)
            {
                return img;
            }
            return img;
        }

        private Image ExecuteRgb8(Image img)
        {
            try
            {
                Bitmap result = new Bitmap(img);
                result.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                Rectangle imageRect = new Rectangle(0, 0, result.Width, result.Height);
                //BitmapData bmpData = result.LockBits(imageRect, ImageLockMode.ReadWrite,img.PixelFormat);
                BitmapData bmpData = result.LockBits(imageRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                //int pixelBytes = Image.GetPixelFormatSize(img.PixelFormat) / 8;
                int pixelBytes = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
                IntPtr ptr = bmpData.Scan0;
                int size = bmpData.Stride * result.Height;
                byte[] pixels = new byte[(size - 1) + 1];
                double sat = (127.0 * this._saturation) / 100.0;
                double lum = (127.0 * this._lightness) / 100.0;
                Marshal.Copy(ptr, pixels, 0, size);
                int pixelFormat = result.Height - 1;
                for (int row = 0; row <= pixelFormat; row++)
                {
                    int newWidth = result.Width - 1;
                    for (int col = 0; col <= newWidth; col++)
                    {
                        double H;
                        double S;
                        int index = (row * bmpData.Stride) + (col * pixelBytes);
                        double R = pixels[index + 2];
                        double G = pixels[index + 1];
                        double B = pixels[index + 0];
                        double min = R;
                        if (G < min)
                        {
                            min = G;
                        }
                        if (B < min)
                        {
                            min = B;
                        }
                        double max = R;
                        double f1 = 0.0;
                        double f2 = G - B;
                        if (G > max)
                        {
                            max = G;
                            f1 = 120.0;
                            f2 = B - R;
                        }
                        if (B > max)
                        {
                            max = B;
                            f1 = 240.0;
                            f2 = R - G;
                        }
                        double dif = max - min;
                        double sum = max + min;
                        double L = 0.5 * sum;
                        if (dif == 0.0)
                        {
                            H = 0.0;
                            S = 0.0;
                        }
                        else
                        {
                            if (L < 127.5)
                            {
                                S = (255.0 * dif) / sum;
                            }
                            else
                            {
                                S = (255.0 * dif) / (510.0 - sum);
                            }
                            H = f1 + ((60.0 * f2) / dif);
                            if (H < 0.0)
                            {
                                H += 360.0;
                            }
                            if (H >= 360.0)
                            {
                                H -= 360.0;
                            }
                        }
                        H += this._hue;
                        if (H >= 360.0)
                        {
                            H -= 360.0;
                        }
                        S += sat;
                        if (S < 0.0)
                        {
                            S = 0.0;
                        }
                        if (S > 255.0)
                        {
                            S = 255.0;
                        }
                        L += lum;
                        if (L < 0.0)
                        {
                            L = 0.0;
                        }
                        if (L > 255.0)
                        {
                            L = 255.0;
                        }
                        if (S == 0.0)
                        {
                            R = L;
                            G = L;
                            B = L;
                        }
                        else
                        {
                            double v2;
                            if (L < 127.5)
                            {
                                v2 = (0.00392156862745098 * L) * (255.0 + S);
                            }
                            else
                            {
                                v2 = (L + S) - ((0.00392156862745098 * S) * L);
                            }
                            double v1 = (2.0 * L) - v2;
                            double v3 = v2 - v1;
                            double H1 = H + 120.0;
                            if (H1 >= 360.0)
                            {
                                H1 -= 360.0;
                            }
                            if (H1 < 60.0)
                            {
                                R = v1 + ((v3 * H1) * 0.016666666666666666);
                            }
                            else if (H1 < 180.0)
                            {
                                R = v2;
                            }
                            else if (H1 < 240.0)
                            {
                                R = v1 + (v3 * (4.0 - (H1 * 0.016666666666666666)));
                            }
                            else
                            {
                                R = v1;
                            }
                            H1 = H;
                            if (H1 < 60.0)
                            {
                                G = v1 + ((v3 * H1) * 0.016666666666666666);
                            }
                            else if (H1 < 180.0)
                            {
                                G = v2;
                            }
                            else if (H1 < 240.0)
                            {
                                G = v1 + (v3 * (4.0 - (H1 * 0.016666666666666666)));
                            }
                            else
                            {
                                G = v1;
                            }
                            H1 = H - 120.0;
                            if (H1 < 0.0)
                            {
                                H1 += 360.0;
                            }
                            if (H1 < 60.0)
                            {
                                B = v1 + ((v3 * H1) * 0.016666666666666666);
                            }
                            else if (H1 < 180.0)
                            {
                                B = v2;
                            }
                            else if (H1 < 240.0)
                            {
                                B = v1 + (v3 * (4.0 - (H1 * 0.016666666666666666)));
                            }
                            else
                            {
                                B = v1;
                            }
                        }
                        pixels[index + 2] = (byte)Math.Round(R);
                        pixels[index + 1] = (byte)Math.Round(G);
                        pixels[index + 0] = (byte)Math.Round(B);
                    }
                }
                Marshal.Copy(pixels, 0, ptr, size);
                result.UnlockBits(bmpData);
                return result;
            }
            catch
            {
                return img;
            }
        }

        public double Hue
        {
            get
            {
                return this._hue;
            }
            set
            {
                this._hue = value;
                while (this._hue < 0.0)
                {
                    this._hue += 360.0;
                }
                while (this._hue >= 360.0)
                {
                    this._hue -= 360.0;
                }
            }
        }

        public double Lightness
        {
            get
            {
                return this._lightness;
            }
            set
            {
                if ((value >= -100.0) & (value <= 100.0))
                {
                    this._lightness = value;
                }
            }
        }

        public double Saturation
        {
            get
            {
                return this._saturation;
            }
            set
            {
                //if ((value >= -100.0) & (value <= 100.0))
                //{
                this._saturation = value;
                //}
            }
        }
    }

}
