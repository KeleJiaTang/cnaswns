namespace CRD.WinUI.Forms
{
    partial class TipForm
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
            this.btnClose = new CRD.WinUI.Misc.CommandButton();
            this.btnMessage = new CRD.WinUI.Misc.CommandButton();
            this.ptbBg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(210, 1);
            this.btnClose.MouseDownImage = null;
            this.btnClose.MouseMoveImage = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = null;
            this.btnClose.Size = new System.Drawing.Size(37, 21);
            this.btnClose.TabIndex = 5;
            this.btnClose.ToolTip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessage.BackColor = System.Drawing.Color.Transparent;
            this.btnMessage.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMessage.Location = new System.Drawing.Point(12, 138);
            this.btnMessage.MouseDownImage = null;
            this.btnMessage.MouseMoveImage = null;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.NormalImage = null;
            this.btnMessage.Size = new System.Drawing.Size(16, 16);
            this.btnMessage.TabIndex = 6;
            this.btnMessage.ToolTip = "关闭";
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // ptbBg
            // 
            this.ptbBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbBg.Location = new System.Drawing.Point(0, 0);
            this.ptbBg.Name = "ptbBg";
            this.ptbBg.Size = new System.Drawing.Size(256, 171);
            this.ptbBg.TabIndex = 7;
            this.ptbBg.TabStop = false;
            // 
            // TipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 171);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ptbBg);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TipForm";
            ((System.ComponentModel.ISupportInitialize)(this.ptbBg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CRD.WinUI.Misc.CommandButton btnClose;
        private CRD.WinUI.Misc.CommandButton btnMessage;
        private System.Windows.Forms.PictureBox ptbBg;
    }
}