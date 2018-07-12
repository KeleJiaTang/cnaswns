/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;
using CRD.Common;
using System.Text;
using System.Reflection;
using CRD.WinUI.Forms;
using System.Windows.Forms;
using System.Drawing;
using CRD.WinUI.Misc;
using System.Runtime.InteropServices;

namespace CRD.WinUI
{
    public abstract class Shared
    {
        private static SkinColor _currentSkinColor = SkinColor.Default;
        private static BackgroundStripe _currentStripe = BackgroundStripe.Default;
        private static Assembly _assemblyWinUI = null;
        private static IMainForm _mainForm;
        private static HSLFilter _HSLFilter;
        private static Bitmap drawButton = null;
        private static Bitmap scrollbarButton = null;

        public static Assembly AssemblyWinUI
        {
            get
            {
                if (_assemblyWinUI == null)
                {
                    _assemblyWinUI = Assembly.Load("CRD.WinUI");
                }

                return _assemblyWinUI;
            }
        }

        public static SkinColor CurrentSkinColor
        {
            get { return _currentSkinColor; }
            set { _currentSkinColor = value; }
        }

        public static BackgroundStripe CurrentBackgroundStripe
        {
            get { return _currentStripe; }
            set { _currentStripe = value; }
        }

        public static IMainForm MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }

        public static Color ControlBackColor
        {
            get
            {
                if (Shared.MainForm != null)
                {
                    return Shared.MainForm.MainFormBackGroundColor;
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        public static Color PicboxBorderBackColorYellow
        {
            get
            {
                if (Shared.MainForm != null)
                {
                    return Shared.MainForm.PicboxBorderBackColorYellow;
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }


        public static Color ControlBorderBackColor
        {
            get
            {
                if (Shared.MainForm != null)
                {
                    return Shared.MainForm.ControlBorderBackColor;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public static Color MainFormBackGroundColor
        {
            get
            {
                if (Shared.MainForm != null)
                {
                    return Shared.MainForm.MainFormBackGroundColor;
                }
                else
                {
                    return SystemColors.Control;
                }
            }
        }

        public static Color FontColor
        {
            get { return Color.FromArgb(22, 61, 101); }
        }

        public static HSLFilter HSLFilter
        {
            get
            {
                if (_HSLFilter == null) _HSLFilter = new HSLFilter();
                return _HSLFilter;
            }
        }

        public static Bitmap ScrollBarButton
        {
            get
            {
                if (scrollbarButton == null)
                {
                    scrollbarButton = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.scroll.scroll.bmp"), true, false), new Size(114, 114));
                }
                return scrollbarButton;
            }
        }

        public static Image ScrollBarUpButton
        {
            get { return ScrollBarButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Bitmap DrawButton
        {
            get
            {
                if (drawButton == null)
                {
                    drawButton = new Bitmap(Bitmap.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.button.arrow.bmp"), true, false), new Size(64, 16));
                }
                return drawButton;
            }
        }

        public static Image NomalDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseDownDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(16, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseMoveDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(32, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image NotEnableDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(48, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        #region ChangeSkinColor

        public static void ChangeSkinColor(SkinColor skinColor, Control control)
        {
            ChangeSkinColor(skinColor, control, false);
        }

        public static void ChangeSkinColor(SkinColor skinColor, Control control, bool Reset)
        {

            if (!Reset && Shared.MainForm.CurrentSkinColor == skinColor) return;

            //Shared.HSLFilter.Hue = 0;
            //Shared.HSLFilter.Saturation = 0;
            //Shared.HSLFilter.Lightness = 0;

            switch (skinColor)
            {
                case SkinColor.Default:
                    return;
                case SkinColor.草莓:
                    Shared.HSLFilter.Hue = 130;
                    Shared.HSLFilter.Saturation = -30;
                    Shared.HSLFilter.Lightness = 20;
                    break;
                case SkinColor.橘子:
                    Shared.HSLFilter.Hue = -175;
                    Shared.HSLFilter.Saturation = 0;
                    Shared.HSLFilter.Lightness = 0;
                    break;
                case SkinColor.青草:
                    Shared.HSLFilter.Hue = -115;
                    Shared.HSLFilter.Saturation = -100;
                    Shared.HSLFilter.Lightness = 5;

                    //Shared.HSLFilter.Hue =150;
                    //Shared.HSLFilter.Saturation =10;
                    //Shared.HSLFilter.Lightness = 20;

                    //Shared.HSLFilter.Hue = 0;
                    //Shared.HSLFilter.Saturation = -10;
                    //Shared.HSLFilter.Lightness = -20;

                    break;
                case SkinColor.灰蓝:
                    Shared.HSLFilter.Hue = -5;
                    Shared.HSLFilter.Saturation = -50;
                    Shared.HSLFilter.Lightness = 7;
                    break;
                case SkinColor.紫罗兰:
                    Shared.HSLFilter.Hue = 55;
                    Shared.HSLFilter.Saturation = -20;
                    Shared.HSLFilter.Lightness = 20;
                    break;
                case SkinColor.巧克力:
                    Shared.HSLFilter.Hue = -180;
                    Shared.HSLFilter.Saturation = -100;
                    Shared.HSLFilter.Lightness = 12;
                    break;
                case SkinColor.OFFICE:
                    Shared.HSLFilter.Hue = 5;
                    Shared.HSLFilter.Saturation = -100;
                    Shared.HSLFilter.Lightness = 0;
                    break;
                case SkinColor.White:
                    Shared.HSLFilter.Hue = 255;
                    Shared.HSLFilter.Saturation =255;
                    Shared.HSLFilter.Lightness = 255;
                    break;
                default:
                    break;
            }

            CurrentSkinColor = skinColor;

            Shared.ChangeControlsSkinColor(control);
        }

        public static void ChangeControlsSkinColor(Control parentControl)
        {
            Shared.ChangeControlSkinColor(parentControl);

            foreach (Control control in parentControl.Controls)
            {
                if (control.Controls.Count > 0)
                {
                    ChangeControlsSkinColor(control);
                }
                else
                {
                    Shared.ChangeControlSkinColor(control);
                }
            }
        }

        public static void ChangeControlSkinColor(Control control)
        {

            if (control is CRD.WinUI.Misc.Button)
            {
                CRD.WinUI.Misc.Button btn = (CRD.WinUI.Misc.Button)control;

                btn.ResetBackGroundImage();

                btn.NormalImage = Shared.HSLFilter.ExecuteFilter(btn.NormalImage);
                btn.MouseDownImage = Shared.HSLFilter.ExecuteFilter(btn.MouseDownImage);
                btn.MouseMoveImage = Shared.HSLFilter.ExecuteFilter(btn.MouseMoveImage);

                btn.Invalidate();
                return;
            }

            if (control is CRD.WinUI.Misc.CommandButton)
            {
                CRD.WinUI.Misc.CommandButton btn = (CRD.WinUI.Misc.CommandButton)control;

                btn.NormalImage = Shared.HSLFilter.ExecuteFilter(btn.NormalImage);

                if (string.Compare(btn.Name, "btnClose") != 0)
                {
                    btn.MouseDownImage = Shared.HSLFilter.ExecuteFilter(btn.MouseDownImage);
                    btn.MouseMoveImage = Shared.HSLFilter.ExecuteFilter(btn.MouseMoveImage);
                }

                btn.Invalidate();
            }

            else if (control is System.Windows.Forms.PictureBox)
            {
                System.Windows.Forms.PictureBox ptb = (System.Windows.Forms.PictureBox)control;
                if (ptb.Image != null)
                {
                    //  ptb.Image = Shared.HSLFilter.ExecuteFilter(ptb.Image);
                }

                if (ptb.BackgroundImage != null)
                {
                    ptb.BackgroundImage = Shared.HSLFilter.ExecuteFilter(ptb.BackgroundImage);
                }
            }

            else if (control is CRD.WinUI.Misc.ComboBox)
            {
                CRD.WinUI.Misc.ComboBox btn = (CRD.WinUI.Misc.ComboBox)control;

                btn.NormalImage = Shared.HSLFilter.ExecuteFilter(btn.NormalImage);
                btn.MouseDownImage = Shared.HSLFilter.ExecuteFilter(btn.MouseDownImage);
                btn.MouseMoveImage = Shared.HSLFilter.ExecuteFilter(btn.MouseMoveImage);

                btn.Invalidate();
            }

            else if (control is CRD.WinUI.Misc.DateTimePicker)
            {
                CRD.WinUI.Misc.DateTimePicker btn = (CRD.WinUI.Misc.DateTimePicker)control;

                btn.NormalImage = Shared.HSLFilter.ExecuteFilter(btn.NormalImage);
                btn.MouseDownImage = Shared.HSLFilter.ExecuteFilter(btn.MouseDownImage);
                btn.MouseMoveImage = Shared.HSLFilter.ExecuteFilter(btn.MouseMoveImage);

                btn.Invalidate();
            }

            else if (control is CRD.WinUI.Misc.TabControl)
            {
                //IntPtr hDC = Win32.GetWindowDC(control.Handle);
                //Graphics gdc = Graphics.FromHdc(hDC);

                ((CRD.WinUI.Misc.TabControl)control).ChangeSkinColor();
                //Win32.ReleaseDC(control.Handle, hDC);
                //gdc.Dispose();
            }
            else
            {
                if (control.BackgroundImage != null)
                {
                    control.BackgroundImage = Shared.HSLFilter.ExecuteFilter(control.BackgroundImage);
                    control.Invalidate();
                }

            }
        }

        public static void ChangeBackgroundStripe(BackgroundStripe backgroundStripe, Control control)
        {
            if (backgroundStripe != BackgroundStripe.Default)
            {
                switch (backgroundStripe)
                {
                    case BackgroundStripe.淡淡墨绿:
                        break;

                    case BackgroundStripe.芙蓉轻粉:
                        ChangeSkinColor(SkinColor.草莓, control);
                        break;

                    case BackgroundStripe.荷叶嫩绿:
                        ChangeSkinColor(SkinColor.青草, control);
                        break;

                    case BackgroundStripe.橘黄雪花:
                        ChangeSkinColor(SkinColor.橘子, control);
                        break;

                    case BackgroundStripe.清雅幽兰:
                        break;

                    case BackgroundStripe.空灵淡蓝:
                        ChangeSkinColor(SkinColor.灰蓝, control);
                        break;

                    case BackgroundStripe.柔和雅灰:

                        break;

                    case BackgroundStripe.腊梅飘香:
                        ChangeSkinColor(SkinColor.OFFICE, control);
                        break;
                    case BackgroundStripe.白色:
                        ChangeSkinColor(SkinColor.White, control);
                        break;
                    default:
                        break;
                }
            }

            Shared.MainForm.CurrentSkinColor = Shared.CurrentSkinColor;
        }

        #endregion

        #region FlushMemory
        public static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static void FlushMemory()
        {
            GarbageCollect();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Win32.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        #region Suspend / Resume Redraw

        internal static void SuspendRedraw(Control control)
        {
            if (!control.IsHandleCreated) return;

            IntPtr hWnd = control.Handle;
            IntPtr eventMask = IntPtr.Zero;

            // Stop redrawing:
            Win32.SendMessage(hWnd, Win32.WM_SETREDRAW, 0, 0);

            // Stop sending of events:
            Win32.SendMessage(hWnd, Win32.EM_GETEVENTMASK, 0, 0);
        }

        internal static void ResumeRedraw(Control control)
        {
            if (!control.IsHandleCreated) return;

            IntPtr hWnd = control.Handle;
            IntPtr eventMask = IntPtr.Zero;

            // turn on events
            Win32.SendMessage(hWnd, Win32.EM_SETEVENTMASK, 0, eventMask.ToInt32());

            // turn on redrawing
            Win32.SendMessage(hWnd, Win32.WM_SETREDRAW, 1, 0);

            control.Invalidate(true);
        }

        internal static void LockWindowUpdate(Form form, bool lockUpdate)
        {
            if (lockUpdate)
            {
                Win32.LockWindowUpdate(form.Handle);
            }
            else
            {
                Win32.LockWindowUpdate(IntPtr.Zero);
                form.Invalidate(true);
                form.Update();
            }
        }
        #endregion

        #region Show MessageBox

        public static DialogResult ShowInfo(string message)
        {
            return ShowInfo(message, string.Empty);
        }

        public static DialogResult ShowInfo(string message, string text)
        {
            using (MessageBoxForm messagebox = new MessageBoxForm(message, text))
            {
                return messagebox.ShowDialog();
            }
        }

        public static DialogResult ShowConfirm(string message)
        {
            return ShowConfirm(message, string.Empty);
        }

        public static DialogResult ShowConfirm(string message, string text)
        {
            return ShowConfirm(message, text, MessageBoxButtons.OKCancel);
        }

        public static DialogResult ShowConfirm(string message, string text, MessageBoxButtons messageBoxButton)
        {
            return ShowConfirm(message, text, messageBoxButton, MessageBoxIcon.Question);
        }

        public static DialogResult ShowConfirm(string message, string text, MessageBoxButtons messageBoxButton, MessageBoxIcon messageBoxIcon)
        {
            using (MessageBoxForm messagebox = new MessageBoxForm(message, text, messageBoxButton, messageBoxIcon))
            {
                return messagebox.ShowDialog();
            }
        }

        public static DialogResult ShowError(string message)
        {
            return ShowError(message, string.Empty);
        }

        public static DialogResult ShowError(string message, string text)
        {
            using (MessageBoxForm messagebox = new MessageBoxForm(message, text, MessageBoxIcon.Error))
            {
                return messagebox.ShowDialog();
            }
        }

        #endregion

        internal static void ResetBorderColor(Message m, Control control)
        {

            System.Drawing.Pen pen = pen = new Pen(Shared.ControlBorderBackColor, 1);
            IntPtr hDC = Win32.GetWindowDC(m.HWnd);
            if (hDC.ToInt32() == 0)
            {
                return;
            }

            if (pen != null)
            {
                //绘制边框 
                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
                pen.Dispose();
            }

            //返回结果 
            //m.Result = IntPtr.Zero;

            //释放 
            Win32.ReleaseDC(m.HWnd, hDC);
        }
    }

    public enum SkinColor
    {
        Default,
        草莓,
        橘子,
        青草,
        灰蓝,
        紫罗兰,
        巧克力,
        OFFICE,
        Undefault,
        White
    }

    public enum BackgroundStripe
    {
        Default,
        淡淡墨绿,
        芙蓉轻粉,
        荷叶嫩绿,
        橘黄雪花,
        清雅幽兰,
        空灵淡蓝,
        柔和雅灰,
        腊梅飘香,
        白色
    }
}
