namespace CRD.WinUI.Forms
{
    partial class FunctionFormBase
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ptbRight = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.ptbLeft = new System.Windows.Forms.PictureBox();
            this.ptbBottomRight = new System.Windows.Forms.PictureBox();
            this.ptbBottomLeft = new System.Windows.Forms.PictureBox();
            this.pnlBackGroup = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.btnMin = new CRD.WinUI.Misc.CommandButton();
            this.btnClose = new CRD.WinUI.Misc.CommandButton();
            this.ptbTopMiddle = new System.Windows.Forms.PictureBox();
            this.ptbTopRight = new System.Windows.Forms.PictureBox();
            this.ptbTopLeft = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ptbBottomMiddle = new System.Windows.Forms.Panel();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomLeft)).BeginInit();
            this.pnlCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.ptbRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(687, 31);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(2, 444);
            this.pnlRight.TabIndex = 7;
            // 
            // ptbRight
            // 
            this.ptbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbRight.Location = new System.Drawing.Point(0, 0);
            this.ptbRight.Name = "ptbRight";
            this.ptbRight.Size = new System.Drawing.Size(2, 444);
            this.ptbRight.TabIndex = 0;
            this.ptbRight.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.ptbLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 31);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(2, 444);
            this.pnlLeft.TabIndex = 6;
            // 
            // ptbLeft
            // 
            this.ptbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbLeft.Name = "ptbLeft";
            this.ptbLeft.Size = new System.Drawing.Size(2, 444);
            this.ptbLeft.TabIndex = 0;
            this.ptbLeft.TabStop = false;
            // 
            // ptbBottomRight
            // 
            this.ptbBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptbBottomRight.Location = new System.Drawing.Point(679, 0);
            this.ptbBottomRight.Name = "ptbBottomRight";
            this.ptbBottomRight.Size = new System.Drawing.Size(10, 37);
            this.ptbBottomRight.TabIndex = 2;
            this.ptbBottomRight.TabStop = false;
            // 
            // ptbBottomLeft
            // 
            this.ptbBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbBottomLeft.Name = "ptbBottomLeft";
            this.ptbBottomLeft.Size = new System.Drawing.Size(10, 37);
            this.ptbBottomLeft.TabIndex = 0;
            this.ptbBottomLeft.TabStop = false;
            // 
            // pnlBackGroup
            // 
            this.pnlBackGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGroup.Location = new System.Drawing.Point(0, 31);
            this.pnlBackGroup.Name = "pnlBackGroup";
            this.pnlBackGroup.Size = new System.Drawing.Size(689, 444);
            this.pnlBackGroup.TabIndex = 9;
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText.Location = new System.Drawing.Point(27, 3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(273, 24);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Text";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseMove);
            this.lblText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.caption_MouseUp);
            // 
            // pnlCaption
            // 
            this.pnlCaption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCaption.Controls.Add(this.lblText);
            this.pnlCaption.Controls.Add(this.btnMin);
            this.pnlCaption.Controls.Add(this.btnClose);
            this.pnlCaption.Controls.Add(this.ptbTopMiddle);
            this.pnlCaption.Controls.Add(this.ptbTopRight);
            this.pnlCaption.Controls.Add(this.ptbTopLeft);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(689, 31);
            this.pnlCaption.TabIndex = 5;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnMin.Location = new System.Drawing.Point(610, 0);
            this.btnMin.MouseDownImage = null;
            this.btnMin.MouseMoveImage = null;
            this.btnMin.Name = "btnMin";
            this.btnMin.NormalImage = null;
            this.btnMin.Size = new System.Drawing.Size(31, 22);
            this.btnMin.TabIndex = 4;
            this.btnMin.ToolTip = "关闭";
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(642, 0);
            this.btnClose.MouseDownImage = null;
            this.btnClose.MouseMoveImage = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = null;
            this.btnClose.Size = new System.Drawing.Size(37, 22);
            this.btnClose.TabIndex = 4;
            this.btnClose.ToolTip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ptbTopMiddle
            // 
            this.ptbTopMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbTopMiddle.Location = new System.Drawing.Point(10, 0);
            this.ptbTopMiddle.Name = "ptbTopMiddle";
            this.ptbTopMiddle.Size = new System.Drawing.Size(669, 31);
            this.ptbTopMiddle.TabIndex = 2;
            this.ptbTopMiddle.TabStop = false;
            this.ptbTopMiddle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseMove);
            this.ptbTopMiddle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.caption_MouseUp);
            // 
            // ptbTopRight
            // 
            this.ptbTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptbTopRight.Location = new System.Drawing.Point(679, 0);
            this.ptbTopRight.Name = "ptbTopRight";
            this.ptbTopRight.Size = new System.Drawing.Size(10, 31);
            this.ptbTopRight.TabIndex = 1;
            this.ptbTopRight.TabStop = false;
            // 
            // ptbTopLeft
            // 
            this.ptbTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbTopLeft.Name = "ptbTopLeft";
            this.ptbTopLeft.Size = new System.Drawing.Size(10, 31);
            this.ptbTopLeft.TabIndex = 0;
            this.ptbTopLeft.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.ptbBottomMiddle);
            this.pnlBottom.Controls.Add(this.ptbBottomRight);
            this.pnlBottom.Controls.Add(this.ptbBottomLeft);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 475);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(689, 37);
            this.pnlBottom.TabIndex = 8;
            // 
            // ptbBottomMiddle
            // 
            this.ptbBottomMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbBottomMiddle.Location = new System.Drawing.Point(10, 0);
            this.ptbBottomMiddle.Name = "ptbBottomMiddle";
            this.ptbBottomMiddle.Size = new System.Drawing.Size(669, 37);
            this.ptbBottomMiddle.TabIndex = 3;
            // 
            // FunctionFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 512);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBackGroup);
            this.Controls.Add(this.pnlCaption);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.Name = "FunctionFormBase";
            this.Text = "FunctionFormBase";
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBottomLeft)).EndInit();
            this.pnlCaption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTopLeft)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox ptbRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox ptbLeft;
        private System.Windows.Forms.PictureBox ptbBottomRight;
        private System.Windows.Forms.PictureBox ptbBottomLeft;
        private System.Windows.Forms.Panel pnlCaption;
        private CRD.WinUI.Misc.CommandButton btnClose;
        private System.Windows.Forms.PictureBox ptbTopMiddle;
        private System.Windows.Forms.PictureBox ptbTopRight;
        private System.Windows.Forms.PictureBox ptbTopLeft;
        private CRD.WinUI.Misc.CommandButton btnMin;
        internal System.Windows.Forms.Label lblText;
        internal System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Panel ptbBottomMiddle;
        protected System.Windows.Forms.Panel pnlBackGroup;
    }
}