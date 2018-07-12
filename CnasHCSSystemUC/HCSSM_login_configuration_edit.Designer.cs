namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_login_configuration_edit
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
            this.lb_MAC = new Telerik.WinControls.UI.RadLabel();
            this.lb_computer = new Telerik.WinControls.UI.RadLabel();
            this.lb_remark = new Telerik.WinControls.UI.RadLabel();
            this.tb_MAC = new Telerik.WinControls.UI.RadTextBoxControl();
            this.tb_computer = new Telerik.WinControls.UI.RadTextBoxControl();
            this.tb_remark = new Telerik.WinControls.UI.RadTextBoxControl();
            this.but_OK = new Telerik.WinControls.UI.RadButton();
            this.but_Cancel = new Telerik.WinControls.UI.RadButton();
            this.work = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_remark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_MAC
            // 
            this.lb_MAC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_MAC.Location = new System.Drawing.Point(25, 29);
            this.lb_MAC.Name = "lb_MAC";
            this.lb_MAC.Size = new System.Drawing.Size(87, 23);
            this.lb_MAC.TabIndex = 0;
            this.lb_MAC.Text = "MAC地址：";
            // 
            // lb_computer
            // 
            this.lb_computer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_computer.Location = new System.Drawing.Point(12, 58);
            this.lb_computer.Name = "lb_computer";
            this.lb_computer.Size = new System.Drawing.Size(102, 23);
            this.lb_computer.TabIndex = 0;
            this.lb_computer.Text = "计算机名称：";
            // 
            // lb_remark
            // 
            this.lb_remark.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_remark.Location = new System.Drawing.Point(57, 122);
            this.lb_remark.Name = "lb_remark";
            this.lb_remark.Size = new System.Drawing.Size(55, 23);
            this.lb_remark.TabIndex = 0;
            this.lb_remark.Text = "备注：";
            // 
            // tb_MAC
            // 
            this.tb_MAC.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_MAC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_MAC.IsReadOnly = true;
            this.tb_MAC.Location = new System.Drawing.Point(116, 29);
            this.tb_MAC.Name = "tb_MAC";
            this.tb_MAC.Size = new System.Drawing.Size(255, 23);
            this.tb_MAC.TabIndex = 2;
            this.tb_MAC.ThemeName = "Office2007Silver";
            // 
            // tb_computer
            // 
            this.tb_computer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_computer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_computer.IsReadOnly = true;
            this.tb_computer.Location = new System.Drawing.Point(116, 58);
            this.tb_computer.Name = "tb_computer";
            this.tb_computer.Size = new System.Drawing.Size(255, 23);
            this.tb_computer.TabIndex = 2;
            this.tb_computer.ThemeName = "Office2007Silver";
            // 
            // tb_remark
            // 
            this.tb_remark.AcceptsReturn = true;
            this.tb_remark.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_remark.Location = new System.Drawing.Point(116, 127);
            this.tb_remark.Multiline = true;
            this.tb_remark.Name = "tb_remark";
            this.tb_remark.Size = new System.Drawing.Size(255, 114);
            this.tb_remark.TabIndex = 2;
            this.tb_remark.ThemeName = "Office2007Silver";
            // 
            // but_OK
            // 
            this.but_OK.Location = new System.Drawing.Point(116, 253);
            this.but_OK.Name = "but_OK";
            this.but_OK.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_OK.Size = new System.Drawing.Size(99, 42);
            this.but_OK.TabIndex = 3;
            this.but_OK.Text = "确  定";
            this.but_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_OK.ThemeName = "Office2007Silver";
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.Location = new System.Drawing.Point(272, 253);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_Cancel.Size = new System.Drawing.Size(99, 42);
            this.but_Cancel.TabIndex = 3;
            this.but_Cancel.Text = "关  闭";
            this.but_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_Cancel.ThemeName = "Office2007Silver";
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // work
            // 
            this.work.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.work.Location = new System.Drawing.Point(10, 87);
            this.work.Name = "work";
            this.work.Size = new System.Drawing.Size(102, 23);
            this.work.TabIndex = 0;
            this.work.Text = "工作台配置：";
            // 
            // HCSSM_login_configuration_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(392, 311);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.tb_remark);
            this.Controls.Add(this.tb_computer);
            this.Controls.Add(this.tb_MAC);
            this.Controls.Add(this.work);
            this.Controls.Add(this.lb_remark);
            this.Controls.Add(this.lb_computer);
            this.Controls.Add(this.lb_MAC);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSSM_login_configuration_edit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSSM_login_configuration_edit";
            this.Load += new System.EventHandler(this.HCSSM_login_configuration_edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lb_MAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_remark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lb_MAC;
        private Telerik.WinControls.UI.RadLabel lb_computer;
        private Telerik.WinControls.UI.RadLabel lb_remark;
        private Telerik.WinControls.UI.RadTextBoxControl tb_MAC;
        private Telerik.WinControls.UI.RadTextBoxControl tb_computer;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remark;
        private Telerik.WinControls.UI.RadButton but_OK;
        private Telerik.WinControls.UI.RadButton but_Cancel;
        private Telerik.WinControls.UI.RadLabel work;
    }
}