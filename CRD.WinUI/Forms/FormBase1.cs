using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using CRD.Common;

namespace CRD.WinUI.Forms
{
    public partial class FormBase1 : UserControl
    {
       private SkinColor _currentSkinColor = SkinColor.Default;
        private FormBorderStyle _formBorderStyle = FormBorderStyle.None;
        private bool _isRedrawSuspended;

        public SkinColor CurrentSkinColor
        {
            get { return _currentSkinColor; }
            set { _currentSkinColor = value; }
        }

       

        [Browsable(true)]
        public FormBorderStyle FormStyle
        {
            get { return _formBorderStyle; }
            set { _formBorderStyle = value; }
        }

        public bool IsRedrawSuspended
        {
            get { return _isRedrawSuspended; }
        }

        public FormBase1()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Win32.SetWindowLong(this.Handle, -16, Win32.WS_SYSMENU + Win32.WS_SIZEBOX + Win32.WS_MAXIMIZEBOX + Win32.WS_MINIMIZEBOX);

            int Rgn = Win32.CreateRoundRectRgn(3, 3, this.Width - 2, this.Height - 2, 7, 7);
            Win32.SetWindowRgn(this.Handle, Rgn, true);

            this.PerformReSetFormBitmap();
            base.OnLoad(e);

            if (this!=Shared.MainForm && this.CurrentSkinColor != Shared.CurrentSkinColor)
            {
                Shared.ChangeSkinColor(Shared.CurrentSkinColor, this, true);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int Rgn = Win32.CreateRoundRectRgn(3, 3, this.Width - 2, this.Height - 2, 7, 7);
            Win32.SetWindowRgn(this.Handle, Rgn, true);

        }

        #region ReSetFormBitmap

        public void PerformReSetFormBitmap()
        {
            try
            {
                this.SuspendRedraw();

                ReSetFormBitmap();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.ResumeRedraw();
            }
        }

        public virtual void ReSetFormBitmap()
        {

        }

        #endregion

        #region ChangeBackgroundStripe

        public void PerformChangeBackgroundStripe(BackgroundStripe backgroundStripe)
        {
            try
            {
                ChangeBackgroundStripe(backgroundStripe);
            }
            catch
            {
                throw;
            }
            finally
            {
                this.ResumeRedraw();
            }
        }

        public virtual void ChangeBackgroundStripe(BackgroundStripe backgroundStripe)
        {
            this.CurrentSkinColor = Shared.CurrentSkinColor;
        }

        #endregion

        #region ChangeSkinColor

        public void PerformChangeSkinColor()
        {
            PerformChangeSkinColor(SkinColor.Undefault);
        }

        public void PerformChangeSkinColor(SkinColor skinColor)
        {
            try
            {
                this.SuspendRedraw();

                ChangeSkinColor(skinColor);
            }
            catch
            {
                throw;
            }
            finally
            {
                this.ResumeRedraw();
               // this.Refresh();
            }
        }

        public virtual void ChangeSkinColor(SkinColor skinColor)
        {
            if (this.CurrentSkinColor != skinColor)
            {
                this.ReSetFormBitmap();
                if (skinColor != SkinColor.Undefault)
                {
                    Shared.ChangeSkinColor(skinColor, this);
                }
            }
            else
            {
                this.ReSetFormBitmap();
                Shared.ChangeControlsSkinColor(this);
            }
            this.CurrentSkinColor = Shared.CurrentSkinColor;
        }

        #endregion

        #region Suspend / Resume Controls Painting
        public void SuspendRedraw()
        {
            _isRedrawSuspended = true;
            SuspendRedraw(this);
        }

        public void SuspendRedraw(Control control)
        {
            if (DesignMode) return;
          //  Shared.SuspendRedraw(control);
        }

        public void ResumeRedraw()
        {
            _isRedrawSuspended = false;

            ResumeRedraw(this);
        }

        public void ResumeRedraw(Control control)
        {
            if (DesignMode) return;
         //   Shared.ResumeRedraw(control);
        }

       
        #endregion

    }
}
