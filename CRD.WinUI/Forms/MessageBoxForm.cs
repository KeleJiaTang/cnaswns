using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CRD.Common;

namespace CRD.WinUI.Forms
{
    public partial class MessageBoxForm : FunctionFormBase
    {
        public MessageBoxForm()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

        public MessageBoxForm(string message)
            : this(message, string.Empty)
        {

        }

        public MessageBoxForm(string message, string text)
            : this(message, text, MessageBoxIcon.Information)
        {


        }

        public MessageBoxForm(string message, string text, MessageBoxIcon messageBoxIcon)
            : this()
        {
            this.btnCancel.Visible = false;
            this.btnYes.Visible = false;
            this.btnNo.Visible = false;

            if (!string.IsNullOrEmpty(text))
                this.Text = text;
            else
                this.Text = "Information";

            this.lblMessage.Text = message;

            this.btnOk.Left = (this.Width - this.btnOk.Width) / 2 - 10;

            this.ptbMessageIcon.Top = (this.pnlBackGroup.Height - this.ptbMessageIcon.Height) / 2;

            if (messageBoxIcon == MessageBoxIcon.Error)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tiperror.png"));
            }

            else if (messageBoxIcon == MessageBoxIcon.Warning)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipwarn.png"));
            }

            else if (messageBoxIcon == MessageBoxIcon.Question)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipques.png"));
            }

            else
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipnorm.png"));
            }
        }

        public MessageBoxForm(string message, MessageBoxButtons MessageBoxButton)
            : this(message, string.Empty, MessageBoxButton)
        {

        }

        public MessageBoxForm(string message, string text, MessageBoxButtons MessageBoxButton)
            : this(message, text, MessageBoxButton, MessageBoxIcon.Question)
        {

        }

        public MessageBoxForm(string message, string text, MessageBoxButtons MessageBoxButton, MessageBoxIcon messageBoxIcon)
            : this()
        {
            if (!string.IsNullOrEmpty(text))
                this.Text = text;
            else
                this.Text = "Information";

            this.ptbMessageIcon.Top = (this.pnlBackGroup.Height - this.ptbMessageIcon.Height) / 2;

            if (MessageBoxButton == MessageBoxButtons.YesNo)
            {
                this.btnOk.Visible = false;
                this.btnCancel.Visible = false;

                this.btnYes.Left = (this.Width - this.btnYes.Width * 2 - 5) / 2 - 30;
                this.btnNo.Left = this.btnYes.Width + this.btnYes.Left + 45;
            }
            else
            {
                this.btnYes.Visible = false;
                this.btnNo.Visible = false;

                this.btnOk.Left = (this.Width - this.btnOk.Width * 2 - 5) / 2 - 30;
                this.btnCancel.Left = this.btnOk.Width + this.btnOk.Left + 45;
            }

            this.lblMessage.Text = message;

            if (messageBoxIcon == MessageBoxIcon.Error)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tiperror.png"));
            }

            else if (messageBoxIcon == MessageBoxIcon.Warning)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipwarn.png"));
            }

            else if (messageBoxIcon == MessageBoxIcon.Information)
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipnorm.png"));
            }

            else
            {
                this.ptbMessageIcon.Image = Image.FromStream(Shared.AssemblyWinUI.GetManifestResourceStream("CRD.WinUI.Resources.Common.msgbox.tipques.png"));
            }

        }

        //字符的对齐方式
        private ContentAlignment _lblmessagetextAlgin;

        //字符的对齐方式
        public ContentAlignment LblmessagetextAlgin
        {
            set
            {
                _lblmessagetextAlgin = value;
                lblMessage.TextAlign = _lblmessagetextAlgin;
            }
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            CRD.WinUI.Misc.Button button = (CRD.WinUI.Misc.Button)sender;
            this.DialogResult = button.DialogResult;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Win32.SetWindowLong(this.Handle, -16, Win32.GetWindowLong(this.Handle, -16) - Win32.WS_SYSMENU);


            this.ptbMessageIcon.Top = (this.pnlBackGroup.Height - this.ptbMessageIcon.Height) / 2;

        }
    }
}
