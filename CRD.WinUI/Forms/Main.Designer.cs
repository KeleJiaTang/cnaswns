namespace CRD.WinUI.Forms
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.liCompanyName = new System.Windows.Forms.Label();
            this.btnbigClose = new CRD.WinUI.Misc.CommandButton();
            this.btnSupport = new CRD.WinUI.Misc.CommandButton();
            this.btnHelp = new CRD.WinUI.Misc.CommandButton();
            this.logoName = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.btnClose = new CRD.WinUI.Misc.CommandButton();
            this.btnMin = new CRD.WinUI.Misc.CommandButton();
            this.btnMaxResore = new CRD.WinUI.Misc.CommandButton();
            this.ptbTopLeft = new System.Windows.Forms.PictureBox();
            this.ptbTopMiddle = new System.Windows.Forms.PictureBox();
            this.logoRight = new System.Windows.Forms.PictureBox();
            this.GCtimer = new System.Windows.Forms.Timer(this.components);
            this.pnlBackground = new CRD.WinUI.Misc.panel();
            this.panelbottom = new CRD.WinUI.Misc.panel();
            this.pboxBottom1 = new CRD.WinUI.Misc.PictureBox();
            this.pnlCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoRight)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.panelbottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBottom1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCaption.Controls.Add(this.liCompanyName);
            this.pnlCaption.Controls.Add(this.btnbigClose);
            this.pnlCaption.Controls.Add(this.btnSupport);
            this.pnlCaption.Controls.Add(this.btnHelp);
            this.pnlCaption.Controls.Add(this.logoName);
            this.pnlCaption.Controls.Add(this.Logo);
            this.pnlCaption.Controls.Add(this.btnClose);
            this.pnlCaption.Controls.Add(this.btnMin);
            this.pnlCaption.Controls.Add(this.btnMaxResore);
            this.pnlCaption.Controls.Add(this.ptbTopLeft);
            this.pnlCaption.Controls.Add(this.ptbTopMiddle);
            this.pnlCaption.Controls.Add(this.logoRight);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(775, 90);
            this.pnlCaption.TabIndex = 0;
            // 
            // liCompanyName
            // 
            this.liCompanyName.AutoSize = true;
            this.liCompanyName.BackColor = System.Drawing.SystemColors.Control;
            this.liCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.liCompanyName.Location = new System.Drawing.Point(341, 41);
            this.liCompanyName.Name = "liCompanyName";
            this.liCompanyName.Size = new System.Drawing.Size(106, 22);
            this.liCompanyName.TabIndex = 13;
            this.liCompanyName.Text = "艾萨人民医院";
            // 
            // btnbigClose
            // 
            this.btnbigClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbigClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbigClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbigClose.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnbigClose.Location = new System.Drawing.Point(705, 24);
            this.btnbigClose.MouseDownImage = null;
            this.btnbigClose.MouseMoveImage = null;
            this.btnbigClose.Name = "btnbigClose";
            this.btnbigClose.NormalImage = null;
            this.btnbigClose.Size = new System.Drawing.Size(60, 60);
            this.btnbigClose.TabIndex = 12;
            this.btnbigClose.ToolTip = "退出";
            this.btnbigClose.Click += new System.EventHandler(this.btnbigClose_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupport.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnSupport.Location = new System.Drawing.Point(633, 24);
            this.btnSupport.MouseDownImage = null;
            this.btnSupport.MouseMoveImage = null;
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.NormalImage = null;
            this.btnSupport.Size = new System.Drawing.Size(60, 60);
            this.btnSupport.TabIndex = 11;
            this.btnSupport.ToolTip = "联系我们";
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnHelp.Location = new System.Drawing.Point(564, 24);
            this.btnHelp.MouseDownImage = null;
            this.btnHelp.MouseMoveImage = null;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.NormalImage = null;
            this.btnHelp.Size = new System.Drawing.Size(60, 60);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.ToolTip = "下载操作手册";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // logoName
            // 
            this.logoName.BackColor = System.Drawing.Color.White;
            this.logoName.Location = new System.Drawing.Point(96, 25);
            this.logoName.Name = "logoName";
            this.logoName.Size = new System.Drawing.Size(240, 43);
            this.logoName.TabIndex = 8;
            this.logoName.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(90, 90);
            this.Logo.TabIndex = 9;
            this.Logo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(747, 0);
            this.btnClose.MouseDownImage = null;
            this.btnClose.MouseMoveImage = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = null;
            this.btnClose.Size = new System.Drawing.Size(26, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.ToolTip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMin.Location = new System.Drawing.Point(695, 0);
            this.btnMin.MouseDownImage = null;
            this.btnMin.MouseMoveImage = null;
            this.btnMin.Name = "btnMin";
            this.btnMin.NormalImage = null;
            this.btnMin.Size = new System.Drawing.Size(26, 20);
            this.btnMin.TabIndex = 3;
            this.btnMin.ToolTip = "最小化";
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMaxResore
            // 
            this.btnMaxResore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxResore.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMaxResore.Location = new System.Drawing.Point(721, 0);
            this.btnMaxResore.MouseDownImage = null;
            this.btnMaxResore.MouseMoveImage = null;
            this.btnMaxResore.Name = "btnMaxResore";
            this.btnMaxResore.NormalImage = null;
            this.btnMaxResore.Size = new System.Drawing.Size(26, 20);
            this.btnMaxResore.TabIndex = 3;
            this.btnMaxResore.ToolTip = "最大化";
            this.btnMaxResore.Click += new System.EventHandler(this.btnMaxResore_Click);
            // 
            // ptbTopLeft
            // 
            this.ptbTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbTopLeft.Name = "ptbTopLeft";
            this.ptbTopLeft.Size = new System.Drawing.Size(0, 90);
            this.ptbTopLeft.TabIndex = 0;
            this.ptbTopLeft.TabStop = false;
            this.ptbTopLeft.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.ptbTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbTopLeft_MouseMove);
            this.ptbTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // ptbTopMiddle
            // 
            this.ptbTopMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.ptbTopMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTopMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbTopMiddle.Location = new System.Drawing.Point(0, 0);
            this.ptbTopMiddle.Name = "ptbTopMiddle";
            this.ptbTopMiddle.Size = new System.Drawing.Size(233, 90);
            this.ptbTopMiddle.TabIndex = 1;
            this.ptbTopMiddle.TabStop = false;
            this.ptbTopMiddle.Click += new System.EventHandler(this.ptbTopMiddle_Click);
            this.ptbTopMiddle.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.ptbTopMiddle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbTopMiddle_MouseMove);
            this.ptbTopMiddle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // logoRight
            // 
            this.logoRight.BackColor = System.Drawing.Color.White;
            this.logoRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.logoRight.Location = new System.Drawing.Point(233, 0);
            this.logoRight.Name = "logoRight";
            this.logoRight.Size = new System.Drawing.Size(542, 90);
            this.logoRight.TabIndex = 9;
            this.logoRight.TabStop = false;
            this.logoRight.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            // 
            // GCtimer
            // 
            this.GCtimer.Interval = 6000;
            this.GCtimer.Tick += new System.EventHandler(this.GCtimer_Tick);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackground.Controls.Add(this.panelbottom);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.ImageTransparentColor = System.Drawing.Color.Empty;
            this.pnlBackground.Location = new System.Drawing.Point(0, 90);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(775, 333);
            this.pnlBackground.TabIndex = 5;
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.pboxBottom1);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.ImageTransparentColor = System.Drawing.Color.Empty;
            this.panelbottom.Location = new System.Drawing.Point(0, 278);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(775, 55);
            this.panelbottom.TabIndex = 1;
            this.panelbottom.Visible = false;
            // 
            // pboxBottom1
            // 
            this.pboxBottom1.BackColor = System.Drawing.Color.Transparent;
            this.pboxBottom1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxBottom1.Location = new System.Drawing.Point(163, 8);
            this.pboxBottom1.Name = "pboxBottom1";
            this.pboxBottom1.Size = new System.Drawing.Size(322, 42);
            this.pboxBottom1.TabIndex = 7;
            this.pboxBottom1.TabStop = false;
            this.pboxBottom1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 423);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Main";
            this.Text = "MainForm";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.pnlCaption.ResumeLayout(false);
            this.pnlCaption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoRight)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.panelbottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBottom1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlCaption;
        internal System.Windows.Forms.PictureBox ptbTopMiddle;
        internal CRD.WinUI.Misc.CommandButton btnClose;
        internal CRD.WinUI.Misc.CommandButton btnMaxResore;
        internal CRD.WinUI.Misc.CommandButton btnMin;
        internal System.Windows.Forms.Timer GCtimer;
        internal System.Windows.Forms.PictureBox ptbTopLeft;
        private System.Windows.Forms.PictureBox logoName;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox logoRight;
        internal Misc.CommandButton btnHelp;
        internal Misc.CommandButton btnSupport;
        internal Misc.CommandButton btnbigClose;
        protected Misc.panel pnlBackground;
        private Misc.panel panelbottom;
        private Misc.PictureBox pboxBottom1;
        private System.Windows.Forms.Label liCompanyName;

    }
}