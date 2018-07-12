using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using System.Security.Permissions;
using CRD.Common;

namespace CRD.WinUI.Misc
{
    //public class GroupBox : System.Windows.Forms.GroupBox
    //{
    //    public GroupBox()
    //        : base()
    //    {
    //        this.BackColor = Color.Transparent;
    //    }

    //    [DefaultValue(typeof(Color), "Transparent")]   
    //    public override System.Drawing.Color BackColor
    //    {
    //        get
    //        {
    //            return base.BackColor;
    //        }
    //        set
    //        {
    //            base.BackColor = value;
    //        }
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        base.OnPaint(e);

    //    //e.Graphics.DrawString(this.Text, this.Font, Brushes.Red, 10, 1);
    //    e.Graphics.DrawLine(new Pen(Shared.ControlBorderBackColor), 1, 7, 8, 7);
    //    e.Graphics.DrawLine(new Pen(Shared.ControlBorderBackColor), 90, 7, this.Width - 2, 7);
    //    e.Graphics.DrawLine(new Pen(Shared.ControlBorderBackColor), 1, 7, 1, this.Height - 2);
    //    e.Graphics.DrawLine(new Pen(Shared.ControlBorderBackColor), 1, this.Height - 2, this.Width - 2, this.Height - 2);
    //    e.Graphics.DrawLine(new Pen(Shared.ControlBorderBackColor), this.Width - 2, 7, this.Width - 2, this.Height - 2);



    //    }
    //}

    [Flags]
    public enum IntTextFormatFlags
    {
        Bottom = 8,
        CalculateRectangle = 0x400,
        Default = 0,
        EndEllipsis = 0x8000,
        ExpandTabs = 0x40,
        ExternalLeading = 0x200,
        HidePrefix = 0x100000,
        HorizontalCenter = 1,
        Internal = 0x1000,
        Left = 0,
        ModifyString = 0x10000,
        NoClipping = 0x100,
        NoFullWidthCharacterBreak = 0x80000,
        NoPrefix = 0x800,
        PathEllipsis = 0x4000,
        PrefixOnly = 0x200000,
        Right = 2,
        RightToLeft = 0x20000,
        SingleLine = 0x20,
        TabStop = 0x80,
        TextBoxControl = 0x2000,
        Top = 0,
        VerticalCenter = 4,
        WordBreak = 0x10,
        WordEllipsis = 0x40000
    }


    //[Designer("System.Windows.Forms.Design.GroupBoxDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Description("DescriptionGroupBox"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch), DefaultEvent("Enter"), DefaultProperty("Text")]
    public class GroupBox : Control
    {
        // Fields
        private Font cachedFont;
        private FlatStyle flatStyle = FlatStyle.Standard;
        private int fontHeight = -1;

        // Events
        [Category("CatPropertyChanged"), EditorBrowsable(EditorBrowsableState.Always), Description("ControlOnAutoSizeChangedDescr"), Browsable(true)]
        public event EventHandler AutoSizeChanged
        {
            add
            {
                base.AutoSizeChanged += value;
            }
            remove
            {
                base.AutoSizeChanged -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event EventHandler Click
        {
            add
            {
                base.Click += value;
            }
            remove
            {
                base.Click -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler DoubleClick
        {
            add
            {
                base.DoubleClick += value;
            }
            remove
            {
                base.DoubleClick -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event KeyEventHandler KeyDown
        {
            add
            {
                base.KeyDown += value;
            }
            remove
            {
                base.KeyDown -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                base.KeyPress += value;
            }
            remove
            {
                base.KeyPress -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event KeyEventHandler KeyUp
        {
            add
            {
                base.KeyUp += value;
            }
            remove
            {
                base.KeyUp -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event MouseEventHandler MouseClick
        {
            add
            {
                base.MouseClick += value;
            }
            remove
            {
                base.MouseClick -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event MouseEventHandler MouseDoubleClick
        {
            add
            {
                base.MouseDoubleClick += value;
            }
            remove
            {
                base.MouseDoubleClick -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event MouseEventHandler MouseDown
        {
            add
            {
                base.MouseDown += value;
            }
            remove
            {
                base.MouseDown -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event EventHandler MouseEnter
        {
            add
            {
                base.MouseEnter += value;
            }
            remove
            {
                base.MouseEnter -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event EventHandler MouseLeave
        {
            add
            {
                base.MouseLeave += value;
            }
            remove
            {
                base.MouseLeave -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event MouseEventHandler MouseMove
        {
            add
            {
                base.MouseMove += value;
            }
            remove
            {
                base.MouseMove -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public event MouseEventHandler MouseUp
        {
            add
            {
                base.MouseUp += value;
            }
            remove
            {
                base.MouseUp -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler TabStopChanged
        {
            add
            {
                base.TabStopChanged += value;
            }
            remove
            {
                base.TabStopChanged -= value;
            }
        }

        // Methods
        public GroupBox()
        {
            //base.SetState2(0x800, true);
            base.SetStyle(ControlStyles.ContainerControl, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, this.OwnerDraw);
            base.SetStyle(ControlStyles.Selectable, false);
            this.TabStop = false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = Color.Transparent;

        }
        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new GroupBoxAccessibleObject(this);
        }

        private void DrawGroupBox(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clientRectangle = base.ClientRectangle;
            int num = 8;
            Color disabledColor = SystemColors.Control; // base.DisabledColor;
            //Pen pen = new Pen(ControlPaint.Light(disabledColor, 1f));
            Pen pen = new Pen(Shared.ControlBorderBackColor == SystemColors.Control ? Color.Black : Shared.ControlBorderBackColor, 0.3f);
            //Pen pen2 = new Pen(ControlPaint.Dark(disabledColor, 0f));
            Pen pen2 = new Pen(Shared.ControlBorderBackColor == SystemColors.Control ? Color.Black : Shared.ControlBorderBackColor, 0f);
            clientRectangle.X += num;
            clientRectangle.Width -= 2 * num;
            try
            {
                Size size;
                int num2;
                //if (this.UseCompatibleTextRendering)
                //{
                //    using (Brush brush = new SolidBrush(this.ForeColor))
                //    {
                //        using (StringFormat format = new StringFormat())
                //        {
                //            format.HotkeyPrefix = this.ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide;
                //            if (this.RightToLeft == RightToLeft.Yes)
                //            {
                //                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                //            }
                //            size = Size.Ceiling(graphics.MeasureString(this.Text, this.Font, clientRectangle.Width, format));
                //            if (base.Enabled)
                //            {
                //                graphics.DrawString(this.Text, this.Font, brush, clientRectangle, format);
                //            }
                //            else
                //            {
                //                ControlPaint.DrawStringDisabled(graphics, this.Text, this.Font, disabledColor, clientRectangle, format);
                //            }
                //        }
                //        goto Label_01E7;
                //    }
                //}

                IntTextFormatFlags flags = IntTextFormatFlags.TextBoxControl | IntTextFormatFlags.WordBreak;
                if (!this.ShowKeyboardCues)
                {
                    flags |= IntTextFormatFlags.HidePrefix;
                }
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    flags |= IntTextFormatFlags.RightToLeft;
                    flags |= IntTextFormatFlags.Right;
                }

                Graphics graphics2 = e.Graphics;

                size = graphics2.MeasureString(this.Text, this.Font).ToSize();
                if (base.Enabled)
                {
                   // graphics2.DrawString(this.Text, this.Font, new SolidBrush(Shared.ControlBorderBackColor == SystemColors.Control ? Color.Black : Shared.ControlBorderBackColor), 8, 0);
                    graphics2.DrawString(this.Text, this.Font, new SolidBrush(Shared.FontColor), 8, 0);
                }
                else
                {
                    ControlPaint.DrawStringDisabled(graphics2, this.Text, this.Font, disabledColor, clientRectangle, (TextFormatFlags)flags);
                }

            Label_01E7:
                num2 = num;
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    num2 += size.Width;
                }
                int num3 = Math.Min((int)(num2 + size.Width), (int)(base.Width - 6));
                int num4 = base.FontHeight / 2;
                graphics.DrawLine(pen, 1, num4, 1, base.Height - 1);
                //graphics.DrawLine(pen2, 0, num4, 0, base.Height - 2);
                graphics.DrawLine(pen, 1, base.Height - 1, base.Width - 1, base.Height - 1);
                //graphics.DrawLine(pen2, 0, base.Height - 2, base.Width - 1, base.Height - 2);
                graphics.DrawLine(pen2, 1, num4 - 1, num2 - 1, num4 - 1);
                ////graphics.DrawLine(pen, 1, num4, num2, num4);
                graphics.DrawLine(pen2, num3, num4 - 1, base.Width - 2, num4 - 1);
                ////graphics.DrawLine(pen, num3, num4, base.Width - 1, num4);
                graphics.DrawLine(pen, (int)(base.Width - 1), (int)(num4 - 1), (int)(base.Width - 1), (int)(base.Height - 1));
                ////graphics.DrawLine(pen2, base.Width - 2, num4, base.Width - 2, base.Height - 2);
            }
            finally
            {
                pen.Dispose();
                pen2.Dispose();
            }
        }

        //public  Size GetPreferredSizeCore(Size proposedSize)
        //{
        //    Size size2 = (this.SizeFromClientSize(Size.Empty) + new Size(0, this.fontHeight)) + base.Padding.Size;
        //    return (this.LayoutEngine.GetPreferredSize(this, proposedSize - size2) + size2);
        //}

        protected override void OnFontChanged(EventArgs e)
        {
            this.fontHeight = -1;
            this.cachedFont = null;
            base.Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if ((Application.RenderWithVisualStyles && (base.Width >= 10)) && (base.Height >= 10))
            {
                GroupBoxState state = base.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled;
                TextFormatFlags flags = TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
                if (!this.ShowKeyboardCues)
                {
                    flags |= TextFormatFlags.HidePrefix;
                }
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                }
                //if (this.ShouldSerializeForeColor() || !base.Enabled)
                //{
                //    Color textColor = base.Enabled ? this.ForeColor : TextRenderer.DisabledTextColor(this.BackColor);
                //    GroupBoxRenderer.DrawGroupBox(e.Graphics, new Rectangle(0, 0, base.Width, base.Height), this.Text, this.Font, textColor, flags, state);
                //}
                //else
                //{
                //    GroupBoxRenderer.DrawGroupBox(e.Graphics, new Rectangle(0, 0, base.Width, base.Height), this.Text, this.Font, flags, state);
                //}
            }
            else
            {
                this.DrawGroupBox(e);
            }
            base.OnPaint(e);
        }

        //[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        //protected  override bool ProcessMnemonic(char charCode)
        //{
        //    if (!Control.IsMnemonic(charCode, this.Text) || !this.CanProcessMnemonic())
        //    {
        //        return false;
        //    }
        //    IntSecurity.ModifyFocus.Assert();
        //    try
        //    {
        //        base.SelectNextControl(null, true, true, true, false);
        //    }
        //    finally
        //    {
        //        CodeAccessPermission.RevertAssert();
        //    }
        //    return true;
        //}

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if ((factor.Width != 1f) && (factor.Height != 1f))
            {
                this.fontHeight = -1;
                this.cachedFont = null;
            }
            base.ScaleControl(factor, specified);
        }

        public override string ToString()
        {
            return (base.ToString() + ", Text: " + this.Text);
        }

        private void WmEraseBkgnd(ref Message m)
        {
            Win32.RECT rect = new Win32.RECT();
            Win32.GetClientRect(new HandleRef(this, base.Handle), ref rect);
            using (Graphics graphics = Graphics.FromHdcInternal(m.WParam))
            {
                using (Brush brush = new SolidBrush(this.BackColor))
                {
                    graphics.FillRectangle(brush, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                }
            }
            m.Result = (IntPtr)1;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (this.OwnerDraw)
            {
                base.WndProc(ref m);
            }
            else
            {
                int msg = m.Msg;
                if (msg != 20)
                {
                    if (msg == 0x3d)
                    {
                        base.WndProc(ref m);
                        if (((int)((long)m.LParam)) == -12)
                        {
                            m.Result = IntPtr.Zero;
                        }
                        return;
                    }
                    if (msg != 0x318)
                    {
                        base.WndProc(ref m);
                        return;
                    }
                }
                this.WmEraseBkgnd(ref m);
            }
        }

        // Properties
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [Category("CatLayout"), Localizable(true), Browsable(true), DefaultValue(1), Description("ControlAutoSizeModeDescr")]
        public AutoSizeMode AutoSizeMode
        {
            get
            {
                return base.GetAutoSizeMode();
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(AutoSizeMode));
                }
                //if (base.GetAutoSizeMode() != value)
                //{
                //    base.SetAutoSizeMode(value);
                //    if (this.ParentInternal != null)
                //    {
                //        if (this.ParentInternal.LayoutEngine == DefaultLayout.Instance)
                //        {
                //            this.ParentInternal.LayoutEngine.InitLayout(this, BoundsSpecified.Size);
                //        }
                //        LayoutTransaction.DoLayout(this.ParentInternal, this, PropertyNames.AutoSize);
                //    }
                //}
            }
        }

        internal virtual Control ParentInternal
        {
            get
            {
                return this.Parent;
            }
            set
            {
                if (this.Parent != value)
                {
                    if (value != null)
                    {
                        value.Controls.Add(this);
                    }
                    else
                    {
                        this.Parent.Controls.Remove(this);
                    }
                }
            }
        }

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams createParams = base.CreateParams;
                if (!this.OwnerDraw)
                {
                    createParams.ClassName = "BUTTON";
                    createParams.Style |= 7;
                }
                else
                {
                    createParams.ClassName = null;
                    createParams.Style &= -8;
                }
                createParams.ExStyle |= 0x10000;
                return createParams;
            }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(3);
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 100);
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Size clientSize = base.ClientSize;
                if (this.fontHeight == -1)
                {
                    this.fontHeight = this.Font.Height;
                    this.cachedFont = this.Font;
                }
                else if (!object.ReferenceEquals(this.cachedFont, this.Font))
                {
                    this.fontHeight = this.Font.Height;
                    this.cachedFont = this.Font;
                }
                Padding padding = base.Padding;
                return new Rectangle(padding.Left, this.fontHeight + padding.Top, Math.Max(clientSize.Width - padding.Horizontal, 0), Math.Max((clientSize.Height - this.fontHeight) - padding.Vertical, 0));
            }
        }

        //[Description("ButtonFlatStyleDescr"), Category("CatAppearance"), DefaultValue(2)]
        public FlatStyle FlatStyle
        {
            get
            {
                return this.flatStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(FlatStyle));
                }
                if (this.flatStyle != value)
                {
                    bool ownerDraw = this.OwnerDraw;
                    this.flatStyle = value;
                    bool flag2 = this.OwnerDraw != ownerDraw;
                    base.SetStyle(ControlStyles.ContainerControl, true);
                    base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserMouse | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, this.OwnerDraw);
                    if (flag2)
                    {
                        base.RecreateHandle();
                    }
                    else
                    {
                        this.Refresh();
                    }
                }
            }
        }

        private bool OwnerDraw
        {
            get
            {
                return (this.FlatStyle != FlatStyle.System);
            }
        }

        public bool SupportsUseCompatibleTextRendering
        {
            get
            {
                return true;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        [Localizable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                bool visible = base.Visible;
                try
                {
                    if (visible && base.IsHandleCreated)
                    {
                        this.SendMessage(11, 0, 0);
                    }
                    base.Text = value;
                }
                finally
                {
                    if (visible && base.IsHandleCreated)
                    {
                        this.SendMessage(11, 1, 0);
                    }
                }
                base.Invalidate(true);
            }
        }


        // Nested Types
        [ComVisible(true)]
        internal class GroupBoxAccessibleObject : Control.ControlAccessibleObject
        {
            // Methods
            internal GroupBoxAccessibleObject(GroupBox owner)
                : base(owner)
            {
            }

            // Properties
            public override AccessibleRole Role
            {
                get
                {
                    AccessibleRole accessibleRole = base.Owner.AccessibleRole;
                    if (accessibleRole != AccessibleRole.Default)
                    {
                        return accessibleRole;
                    }
                    return AccessibleRole.Grouping;
                }
            }
        }

        internal IntPtr SendMessage(int msg, int wparam, int lparam)
        {
            return new IntPtr(Win32.SendMessage(this.Handle, msg, wparam, lparam));
        }



    }


}
