namespace Cnas.wns.CnasHCSReporManagerUC
{
    partial class HCSRM_custom_template_report_add
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
            this.scmain = new System.Windows.Forms.SplitContainer();
            this.rbtnPrint = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnClose = new Telerik.WinControls.UI.RadButton();
            this.rtxtTem_name = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rbtnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).BeginInit();
            this.scmain.Panel1.SuspendLayout();
            this.scmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTem_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // scmain
            // 
            this.scmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scmain.Location = new System.Drawing.Point(0, 0);
            this.scmain.Name = "scmain";
            this.scmain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scmain.Panel1
            // 
            this.scmain.Panel1.Controls.Add(this.rbtnPrint);
            this.scmain.Panel1.Controls.Add(this.label1);
            this.scmain.Panel1.Controls.Add(this.rbtnClose);
            this.scmain.Panel1.Controls.Add(this.rtxtTem_name);
            this.scmain.Panel1.Controls.Add(this.radLabel1);
            this.scmain.Panel1.Controls.Add(this.rbtnSave);
            this.scmain.Size = new System.Drawing.Size(859, 806);
            this.scmain.SplitterDistance = 56;
            this.scmain.TabIndex = 1;
            // 
            // rbtnPrint
            // 
            this.rbtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnPrint.Location = new System.Drawing.Point(499, 7);
            this.rbtnPrint.Name = "rbtnPrint";
            this.rbtnPrint.Size = new System.Drawing.Size(111, 41);
            this.rbtnPrint.TabIndex = 1;
            this.rbtnPrint.Text = "       打印";
            this.rbtnPrint.ThemeName = "Office2007Silver";
            this.rbtnPrint.Click += new System.EventHandler(this.rbtnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(373, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 266;
            this.label1.Text = "*";
            // 
            // rbtnClose
            // 
            this.rbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnClose.Location = new System.Drawing.Point(739, 7);
            this.rbtnClose.Name = "rbtnClose";
            this.rbtnClose.Size = new System.Drawing.Size(111, 41);
            this.rbtnClose.TabIndex = 1;
            this.rbtnClose.Text = "       关闭";
            this.rbtnClose.ThemeName = "Office2007Silver";
            this.rbtnClose.Click += new System.EventHandler(this.rbtnClose_Click);
            // 
            // rtxtTem_name
            // 
            this.rtxtTem_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtxtTem_name.Location = new System.Drawing.Point(105, 17);
            this.rtxtTem_name.Name = "rtxtTem_name";
            this.rtxtTem_name.Size = new System.Drawing.Size(264, 25);
            this.rtxtTem_name.TabIndex = 2;
            this.rtxtTem_name.ThemeName = "Office2007Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel1.Location = new System.Drawing.Point(44, 18);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 23);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "名称：";
            // 
            // rbtnSave
            // 
            this.rbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSave.Location = new System.Drawing.Point(616, 7);
            this.rbtnSave.Name = "rbtnSave";
            this.rbtnSave.Size = new System.Drawing.Size(111, 41);
            this.rbtnSave.TabIndex = 0;
            this.rbtnSave.Text = "       保存";
            this.rbtnSave.ThemeName = "Office2007Silver";
            this.rbtnSave.Click += new System.EventHandler(this.rbtnSave_Click);
            // 
            // HCSRM_custom_template_report_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(859, 806);
            this.Controls.Add(this.scmain);
            this.Name = "HCSRM_custom_template_report_add";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSRM_custom_template_report_add";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HCSRM_custom_template_report_add_Load);
            this.scmain.Panel1.ResumeLayout(false);
            this.scmain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).EndInit();
            this.scmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbtnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTem_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scmain;
        private Telerik.WinControls.UI.RadTextBox rtxtTem_name;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbtnSave;
        private Telerik.WinControls.UI.RadButton rbtnClose;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton rbtnPrint;
    }
}