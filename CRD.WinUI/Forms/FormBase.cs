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
    /// <summary>
    /// 常用的窗体之一，用于添加修改等弹出窗体
    /// </summary>
    public partial class FormBase : Form
    {
        //默认的肤色 这是一个枚举
        private SkinColor _currentSkinColor = SkinColor.White;

        //设置窗体无边框
        private FormBorderStyle _formBorderStyle = FormBorderStyle.None;

        //得到一个值表示 是否重绘
        private bool _isRedrawSuspended;

        //当前应用的皮肤
        public SkinColor CurrentSkinColor
        {
            get { return _currentSkinColor; }
            set { _currentSkinColor = value; }
        }

        //public Sys_UserInfo CurrenUserInfo = new Sys_UserInfo();

        //指定方法或是属性是否可以在编辑器中查看Never始终不能,Always始终是可以的，Advanced只有高级用户才能查看
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        //指定事件或是属性是否显示在属性窗口中
        //[Browsable(false)]
        //指定事件或是属性是否显示在属性窗口中
        [Browsable(true)]
        public FormBorderStyle FormStyle
        {
            get { return _formBorderStyle; }
            set { _formBorderStyle = value; }
        }

        //得到一个值表示 是否重绘
        public bool IsRedrawSuspended
        {
            get { return _isRedrawSuspended; }
        }

        ////构造函数
        //public FormBase(Sys_UserInfo UserInfo)
        //{
        //    this.CurrenUserInfo = UserInfo;
        //    this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        //    InitializeComponent();
        //}

        //构造函数
        public FormBase()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }


        //重写的OnLoad事件
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

        //重写的OnResize事件
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int Rgn = Win32.CreateRoundRectRgn(3, 3, this.Width - 2, this.Height - 2, 7, 7);
            Win32.SetWindowRgn(this.Handle, Rgn, true);

        }

        #region  //设置用户控件的图片ReSetFormBitmap

        //设置用户控件的图片
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

        #region  //设置用户控件背景ChangeBackgroundStripe

        //设置用户控件背景
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

        #region //设置皮肤色ChangeSkinColor


        public void PerformChangeSkinColor()
        {
            PerformChangeSkinColor(SkinColor.Undefault);
        }

        //设置皮肤色
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
            }
        }

        //修改皮肤色时
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
        }

        public void ResumeRedraw()
        {
            _isRedrawSuspended = false;

            ResumeRedraw(this);
        }

        public void ResumeRedraw(Control control)
        {
            if (DesignMode) return;
        }

        public void LockWindowUpdate(bool lockUpdate)
        {
            Shared.LockWindowUpdate(this, lockUpdate);
        }
        #endregion

    }
}
