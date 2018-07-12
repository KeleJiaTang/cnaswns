namespace Cnas.wns
{
    partial class mytest
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
            this.tbc_all = new System.Windows.Forms.TabControl();
            this.tp_01 = new System.Windows.Forms.TabPage();
            this.tp_other = new System.Windows.Forms.TabPage();
            this.tbc_all.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc_all
            // 
            this.tbc_all.Controls.Add(this.tp_01);
            this.tbc_all.Controls.Add(this.tp_other);
            this.tbc_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_all.Location = new System.Drawing.Point(0, 0);
            this.tbc_all.Name = "tbc_all";
            this.tbc_all.SelectedIndex = 0;
            this.tbc_all.Size = new System.Drawing.Size(806, 514);
            this.tbc_all.TabIndex = 0;
            // 
            // tp_01
            // 
            this.tp_01.Location = new System.Drawing.Point(4, 22);
            this.tp_01.Name = "tp_01";
            this.tp_01.Padding = new System.Windows.Forms.Padding(3);
            this.tp_01.Size = new System.Drawing.Size(798, 488);
            this.tp_01.TabIndex = 0;
            this.tp_01.Text = "控件测试";
            this.tp_01.UseVisualStyleBackColor = true;
            this.tp_01.Click += new System.EventHandler(this.tp_01_Click);
            // 
            // tp_other
            // 
            this.tp_other.Location = new System.Drawing.Point(4, 22);
            this.tp_other.Name = "tp_other";
            this.tp_other.Padding = new System.Windows.Forms.Padding(3);
            this.tp_other.Size = new System.Drawing.Size(798, 488);
            this.tp_other.TabIndex = 1;
            this.tp_other.Text = "其他";
            this.tp_other.UseVisualStyleBackColor = true;
            // 
            // mytest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 514);
            this.Controls.Add(this.tbc_all);
            this.Name = "mytest";
            this.Text = "mytest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mytest_FormClosed);
            this.tbc_all.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbc_all;
        private System.Windows.Forms.TabPage tp_01;
        private System.Windows.Forms.TabPage tp_other;
    }
}