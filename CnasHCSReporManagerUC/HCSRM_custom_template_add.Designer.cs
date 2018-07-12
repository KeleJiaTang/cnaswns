namespace Cnas.wns.CnasHCSReporManagerUC
{
    partial class HCSRM_custom_template_add
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtName = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtFile = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnFile = new Telerik.WinControls.UI.RadButton();
            this.rtxtRemark = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnSave = new Telerik.WinControls.UI.RadButton();
            this.rbtnClose = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "模版名称：";
            // 
            // rtxtName
            // 
            this.rtxtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtxtName.Location = new System.Drawing.Point(124, 33);
            this.rtxtName.Name = "rtxtName";
            this.rtxtName.Size = new System.Drawing.Size(293, 25);
            this.rtxtName.TabIndex = 1;
            this.rtxtName.ThemeName = "Office2007Silver";
            // 
            // rtxtFile
            // 
            this.rtxtFile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtxtFile.Location = new System.Drawing.Point(124, 66);
            this.rtxtFile.Name = "rtxtFile";
            this.rtxtFile.ReadOnly = true;
            this.rtxtFile.Size = new System.Drawing.Size(216, 25);
            this.rtxtFile.TabIndex = 5;
            this.rtxtFile.ThemeName = "Office2007Silver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "模版文件：";
            // 
            // rbtnFile
            // 
            this.rbtnFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rbtnFile.Location = new System.Drawing.Point(346, 66);
            this.rbtnFile.Name = "rbtnFile";
            this.rbtnFile.Size = new System.Drawing.Size(71, 25);
            this.rbtnFile.TabIndex = 6;
            this.rbtnFile.Text = "选择文件";
            this.rbtnFile.ThemeName = "Office2007Silver";
            this.rbtnFile.Click += new System.EventHandler(this.rbtnFile_Click);
            // 
            // rtxtRemark
            // 
            this.rtxtRemark.AutoSize = false;
            this.rtxtRemark.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtxtRemark.Location = new System.Drawing.Point(124, 97);
            this.rtxtRemark.Multiline = true;
            this.rtxtRemark.Name = "rtxtRemark";
            this.rtxtRemark.Size = new System.Drawing.Size(293, 94);
            this.rtxtRemark.TabIndex = 5;
            this.rtxtRemark.ThemeName = "Office2007Silver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "备注：";
            // 
            // rbtnSave
            // 
            this.rbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbtnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rbtnSave.Location = new System.Drawing.Point(137, 213);
            this.rbtnSave.Name = "rbtnSave";
            this.rbtnSave.Size = new System.Drawing.Size(97, 44);
            this.rbtnSave.TabIndex = 7;
            this.rbtnSave.Text = "        保存";
            this.rbtnSave.ThemeName = "Office2007Silver";
            this.rbtnSave.Click += new System.EventHandler(this.rbtnSave_Click);
            // 
            // rbtnClose
            // 
            this.rbtnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rbtnClose.Location = new System.Drawing.Point(303, 213);
            this.rbtnClose.Name = "rbtnClose";
            this.rbtnClose.Size = new System.Drawing.Size(95, 44);
            this.rbtnClose.TabIndex = 7;
            this.rbtnClose.Text = "        关闭";
            this.rbtnClose.ThemeName = "Office2007Silver";
            this.rbtnClose.Click += new System.EventHandler(this.rbtnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(423, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 266;
            this.label2.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(423, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 12);
            this.label5.TabIndex = 267;
            this.label5.Text = "*";
            // 
            // HCSRM_custom_template_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(471, 286);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtnClose);
            this.Controls.Add(this.rbtnSave);
            this.Controls.Add(this.rtxtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbtnFile);
            this.Controls.Add(this.rtxtFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxtName);
            this.Controls.Add(this.label1);
            this.Name = "HCSRM_custom_template_add";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HCSRM_custom_template_add";
            this.Load += new System.EventHandler(this.HCSRM_custom_template_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rtxtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox rtxtName;
        private Telerik.WinControls.UI.RadTextBox rtxtFile;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton rbtnFile;
        private Telerik.WinControls.UI.RadTextBox rtxtRemark;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadButton rbtnSave;
        private Telerik.WinControls.UI.RadButton rbtnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}