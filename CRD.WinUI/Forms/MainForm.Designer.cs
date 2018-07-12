namespace CRD.WinUI.Forms
{
    partial class MainForm
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
            this.btnClose = new CRD.WinUI.Misc.CommandButton();
            this.btnMaxResore = new CRD.WinUI.Misc.CommandButton();
            this.btnMin = new CRD.WinUI.Misc.CommandButton();
            this.btnMenu = new CRD.WinUI.Misc.CommandButton();
            this.btnSkin = new CRD.WinUI.Misc.CommandButton();
            this.lblText = new System.Windows.Forms.Label();
            this.ptbTopRight = new System.Windows.Forms.PictureBox();
            this.ptbTopMiddle = new System.Windows.Forms.PictureBox();
            this.ptbTopLeft = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ptbBottomRight = new System.Windows.Forms.PictureBox();
            this.ptbBottomMiddle = new System.Windows.Forms.PictureBox();
            this.ptbBottomLeft = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.ptbLeft = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ptbRight = new System.Windows.Forms.PictureBox();
            this.GCtimer = new System.Windows.Forms.Timer(this.components);
            this.pnlBackground = new CRD.WinUI.Misc.panel();
            this.pnlCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCaption.Controls.Add(this.btnClose);
            this.pnlCaption.Controls.Add(this.btnMaxResore);
            this.pnlCaption.Controls.Add(this.btnMin);
            this.pnlCaption.Controls.Add(this.btnMenu);
            this.pnlCaption.Controls.Add(this.btnSkin);
            this.pnlCaption.Controls.Add(this.lblText);
            this.pnlCaption.Controls.Add(this.ptbTopRight);
            this.pnlCaption.Controls.Add(this.ptbTopMiddle);
            this.pnlCaption.Controls.Add(this.ptbTopLeft);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(592, 30);
            this.pnlCaption.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(548, 0);
            this.btnClose.MouseDownImage = null;
            this.btnClose.MouseMoveImage = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = null;
            this.btnClose.Size = new System.Drawing.Size(37, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.ToolTip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaxResore
            // 
            this.btnMaxResore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxResore.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMaxResore.Location = new System.Drawing.Point(516, 0);
            this.btnMaxResore.MouseDownImage = null;
            this.btnMaxResore.MouseMoveImage = null;
            this.btnMaxResore.Name = "btnMaxResore";
            this.btnMaxResore.NormalImage = null;
            this.btnMaxResore.Size = new System.Drawing.Size(32, 22);
            this.btnMaxResore.TabIndex = 3;
            this.btnMaxResore.ToolTip = "最大化";
            this.btnMaxResore.Click += new System.EventHandler(this.btnMaxResore_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMin.Location = new System.Drawing.Point(485, 0);
            this.btnMin.MouseDownImage = null;
            this.btnMin.MouseMoveImage = null;
            this.btnMin.Name = "btnMin";
            this.btnMin.NormalImage = null;
            this.btnMin.Size = new System.Drawing.Size(31, 22);
            this.btnMin.TabIndex = 3;
            this.btnMin.ToolTip = "最小化";
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnMenu.Location = new System.Drawing.Point(428, 6);
            this.btnMenu.MouseDownImage = null;
            this.btnMenu.MouseMoveImage = null;
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.NormalImage = null;
            this.btnMenu.Size = new System.Drawing.Size(40, 14);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.ToolTip = null;
            this.btnMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseClick);
            // 
            // btnSkin
            // 
            this.btnSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkin.BackColor = System.Drawing.Color.Transparent;
            this.btnSkin.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkin.Location = new System.Drawing.Point(374, 6);
            this.btnSkin.MouseDownImage = null;
            this.btnSkin.MouseMoveImage = null;
            this.btnSkin.Name = "btnSkin";
            this.btnSkin.NormalImage = null;
            this.btnSkin.Size = new System.Drawing.Size(40, 14);
            this.btnSkin.TabIndex = 5;
            this.btnSkin.ToolTip = null;
            this.btnSkin.Click += new System.EventHandler(this.btnSkin_Click);
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Location = new System.Drawing.Point(30, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(283, 26);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.lblText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblText_MouseMove);
            this.lblText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // ptbTopRight
            // 
            this.ptbTopRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptbTopRight.Location = new System.Drawing.Point(584, 0);
            this.ptbTopRight.Name = "ptbTopRight";
            this.ptbTopRight.Size = new System.Drawing.Size(8, 30);
            this.ptbTopRight.TabIndex = 2;
            this.ptbTopRight.TabStop = false;
            this.ptbTopRight.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.ptbTopRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbTopRight_MouseMove);
            this.ptbTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // ptbTopMiddle
            // 
            this.ptbTopMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.ptbTopMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTopMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbTopMiddle.Location = new System.Drawing.Point(313, 0);
            this.ptbTopMiddle.Name = "ptbTopMiddle";
            this.ptbTopMiddle.Size = new System.Drawing.Size(279, 30);
            this.ptbTopMiddle.TabIndex = 1;
            this.ptbTopMiddle.TabStop = false;
            this.ptbTopMiddle.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.ptbTopMiddle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbTopMiddle_MouseMove);
            this.ptbTopMiddle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // ptbTopLeft
            // 
            this.ptbTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbTopLeft.Name = "ptbTopLeft";
            this.ptbTopLeft.Size = new System.Drawing.Size(313, 30);
            this.ptbTopLeft.TabIndex = 0;
            this.ptbTopLeft.TabStop = false;
            this.ptbTopLeft.DoubleClick += new System.EventHandler(this.Caption_DouClick);
            this.ptbTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbTopLeft_MouseMove);
            this.ptbTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseUp);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.ptbBottomRight);
            this.pnlBottom.Controls.Add(this.ptbBottomMiddle);
            this.pnlBottom.Controls.Add(this.ptbBottomLeft);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 413);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(592, 10);
            this.pnlBottom.TabIndex = 2;
            // 
            // ptbBottomRight
            // 
            this.ptbBottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptbBottomRight.Location = new System.Drawing.Point(584, 0);
            this.ptbBottomRight.Name = "ptbBottomRight";
            this.ptbBottomRight.Size = new System.Drawing.Size(8, 10);
            this.ptbBottomRight.TabIndex = 1;
            this.ptbBottomRight.TabStop = false;
            this.ptbBottomRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbBottomRight_MouseMove);
            // 
            // ptbBottomMiddle
            // 
            this.ptbBottomMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbBottomMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbBottomMiddle.Location = new System.Drawing.Point(8, 0);
            this.ptbBottomMiddle.Name = "ptbBottomMiddle";
            this.ptbBottomMiddle.Size = new System.Drawing.Size(584, 10);
            this.ptbBottomMiddle.TabIndex = 2;
            this.ptbBottomMiddle.TabStop = false;
            this.ptbBottomMiddle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbBottomMiddle_MouseMove);
            // 
            // ptbBottomLeft
            // 
            this.ptbBottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbBottomLeft.Name = "ptbBottomLeft";
            this.ptbBottomLeft.Size = new System.Drawing.Size(8, 10);
            this.ptbBottomLeft.TabIndex = 0;
            this.ptbBottomLeft.TabStop = false;
            this.ptbBottomLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbBottomLeft_MouseMove);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.ptbLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 30);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(6, 383);
            this.pnlLeft.TabIndex = 3;
            // 
            // ptbLeft
            // 
            this.ptbLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbLeft.Name = "ptbLeft";
            this.ptbLeft.Size = new System.Drawing.Size(6, 383);
            this.ptbLeft.TabIndex = 0;
            this.ptbLeft.TabStop = false;
            this.ptbLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbLeft_MouseMove);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.ptbRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(587, 30);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(5, 383);
            this.pnlRight.TabIndex = 4;
            // 
            // ptbRight
            // 
            this.ptbRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbRight.Location = new System.Drawing.Point(0, 0);
            this.ptbRight.Name = "ptbRight";
            this.ptbRight.Size = new System.Drawing.Size(5, 383);
            this.ptbRight.TabIndex = 0;
            this.ptbRight.TabStop = false;
            this.ptbRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbRight_MouseMove);
            // 
            // GCtimer
            // 
            this.GCtimer.Interval = 6000;
            this.GCtimer.Tick += new System.EventHandler(this.GCtimer_Tick);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.ImageTransparentColor = System.Drawing.Color.Empty;
            this.pnlBackground.Location = new System.Drawing.Point(6, 30);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(581, 383);
            this.pnlBackground.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 423);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCaption);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.pnlCaption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlCaption;
        internal System.Windows.Forms.PictureBox ptbTopRight;
        internal System.Windows.Forms.PictureBox ptbTopMiddle;
        internal System.Windows.Forms.PictureBox ptbTopLeft;
        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.PictureBox ptbBottomMiddle;
        internal System.Windows.Forms.PictureBox ptbBottomRight;
        internal System.Windows.Forms.PictureBox ptbBottomLeft;
        internal System.Windows.Forms.Panel pnlLeft;
        internal System.Windows.Forms.PictureBox ptbLeft;
        internal System.Windows.Forms.Panel pnlRight;
        internal System.Windows.Forms.PictureBox ptbRight;
        internal CRD.WinUI.Misc.CommandButton btnClose;
        internal CRD.WinUI.Misc.CommandButton btnMaxResore;
        internal CRD.WinUI.Misc.CommandButton btnMin;
        internal System.Windows.Forms.Timer GCtimer;
        internal CRD.WinUI.Misc.CommandButton btnMenu;
        internal CRD.WinUI.Misc.CommandButton btnSkin;
        protected CRD.WinUI.Misc.panel pnlBackground;
        internal System.Windows.Forms.Label lblText;

    }
}