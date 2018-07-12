namespace CRD.WinUI.Forms
{
    partial class EnterUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ptbRight = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.ptbLeft = new System.Windows.Forms.PictureBox();
            this.pnlBackGroup = new System.Windows.Forms.Panel();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.ptbRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(687, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(2, 512);
            this.pnlRight.TabIndex = 7;
            // 
            // ptbRight
            // 
            this.ptbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbRight.Location = new System.Drawing.Point(0, 0);
            this.ptbRight.Name = "ptbRight";
            this.ptbRight.Size = new System.Drawing.Size(2, 512);
            this.ptbRight.TabIndex = 0;
            this.ptbRight.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.ptbLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(2, 512);
            this.pnlLeft.TabIndex = 6;
            // 
            // ptbLeft
            // 
            this.ptbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLeft.Location = new System.Drawing.Point(0, 0);
            this.ptbLeft.Name = "ptbLeft";
            this.ptbLeft.Size = new System.Drawing.Size(2, 512);
            this.ptbLeft.TabIndex = 0;
            this.ptbLeft.TabStop = false;
            // 
            // pnlBackGroup
            // 
            this.pnlBackGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGroup.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGroup.Name = "pnlBackGroup";
            this.pnlBackGroup.Size = new System.Drawing.Size(689, 512);
            this.pnlBackGroup.TabIndex = 9;
            this.pnlBackGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackGroup.BackgroundImage")));
            // 
            // EnterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBackGroup);
            this.Name = "EnterUserControl";
            this.Size = new System.Drawing.Size(689, 512);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbRight)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox ptbRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox ptbLeft;
        protected System.Windows.Forms.Panel pnlBackGroup;
    }
}