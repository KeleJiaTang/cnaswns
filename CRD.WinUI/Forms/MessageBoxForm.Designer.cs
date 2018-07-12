namespace CRD.WinUI.Forms
{
    partial class MessageBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxForm));
            this.btnNo = new CRD.WinUI.Misc.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCancel = new CRD.WinUI.Misc.Button();
            this.ptbMessageIcon = new System.Windows.Forms.PictureBox();
            this.btnYes = new CRD.WinUI.Misc.Button();
            this.btnOk = new CRD.WinUI.Misc.Button();
            this.ptbBottomMiddle.SuspendLayout();
            this.pnlBackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMessageIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbBottomMiddle
            // 
            this.ptbBottomMiddle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbBottomMiddle.BackgroundImage")));
            this.ptbBottomMiddle.Controls.Add(this.btnCancel);
            this.ptbBottomMiddle.Controls.Add(this.btnNo);
            this.ptbBottomMiddle.Controls.Add(this.btnOk);
            this.ptbBottomMiddle.Controls.Add(this.btnYes);
            this.ptbBottomMiddle.Size = new System.Drawing.Size(424, 37);
            // 
            // pnlBackGroup
            // 
            this.pnlBackGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackGroup.BackgroundImage")));
            this.pnlBackGroup.Controls.Add(this.ptbMessageIcon);
            this.pnlBackGroup.Controls.Add(this.lblMessage);
            this.pnlBackGroup.Location = new System.Drawing.Point(2, 31);
            this.pnlBackGroup.Size = new System.Drawing.Size(440, 57);
            // 
            // btnNo
            // 
            this.btnNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNo.BackgroundImage")));
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.Caption = "否";
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnNo.Location = new System.Drawing.Point(294, 4);
            this.btnNo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnNo.MouseDownImage")));
            this.btnNo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnNo.MouseMoveImage")));
            this.btnNo.Name = "btnNo";
            this.btnNo.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnNo.NormalImage")));
            this.btnNo.Size = new System.Drawing.Size(76, 29);
            this.btnNo.TabIndex = 14;
            this.btnNo.ToolTip = null;
            this.btnNo.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(79, 2);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(331, 52);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Caption = "取 消";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(126, 4);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.NormalImage")));
            this.btnCancel.Size = new System.Drawing.Size(76, 29);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.ToolTip = null;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // ptbMessageIcon
            // 
            this.ptbMessageIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbMessageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ptbMessageIcon.Location = new System.Drawing.Point(29, 10);
            this.ptbMessageIcon.Name = "ptbMessageIcon";
            this.ptbMessageIcon.Size = new System.Drawing.Size(40, 40);
            this.ptbMessageIcon.TabIndex = 10;
            this.ptbMessageIcon.TabStop = false;
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYes.BackgroundImage")));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.Caption = "是";
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnYes.Location = new System.Drawing.Point(210, 4);
            this.btnYes.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnYes.MouseDownImage")));
            this.btnYes.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnYes.MouseMoveImage")));
            this.btnYes.Name = "btnYes";
            this.btnYes.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnYes.NormalImage")));
            this.btnYes.Size = new System.Drawing.Size(76, 29);
            this.btnYes.TabIndex = 13;
            this.btnYes.ToolTip = null;
            this.btnYes.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.Caption = "确 定";
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnOk.Location = new System.Drawing.Point(42, 4);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnOk.NormalImage")));
            this.btnOk.Size = new System.Drawing.Size(76, 29);
            this.btnOk.TabIndex = 12;
            this.btnOk.ToolTip = null;
            this.btnOk.Click += new System.EventHandler(this.btn_Click);
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 125);
            this.Controls.Add(this.pnlBackGroup);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "MessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "综合缴费4.0提示信息";
            this.Controls.SetChildIndex(this.pnlBackGroup, 0);
            this.ptbBottomMiddle.ResumeLayout(false);
            this.pnlBackGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMessageIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CRD.WinUI.Misc.Button btnNo;
        private System.Windows.Forms.Label lblMessage;
        private CRD.WinUI.Misc.Button btnCancel;
        private System.Windows.Forms.PictureBox ptbMessageIcon;
        private CRD.WinUI.Misc.Button btnYes;
        private CRD.WinUI.Misc.Button btnOk;

    }
}