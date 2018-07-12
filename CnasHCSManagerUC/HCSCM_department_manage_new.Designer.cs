namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_department_manage_new
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
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
			this.lb_remarks = new System.Windows.Forms.Label();
			this.lb_customer = new System.Windows.Forms.Label();
			this.lb_name = new System.Windows.Forms.Label();
			this.lb_cssd = new System.Windows.Forms.Label();
			this.tb_customer = new Telerik.WinControls.UI.RadTextBox();
			this.tb_name = new Telerik.WinControls.UI.RadTextBox();
			this.tb_cssd = new Telerik.WinControls.UI.RadTextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_customer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(233, 199);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 6;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(103, 199);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 5;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// tb_remarks
			// 
			this.tb_remarks.AcceptsReturn = true;
			this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_remarks.Location = new System.Drawing.Point(103, 105);
			this.tb_remarks.Multiline = true;
			this.tb_remarks.Name = "tb_remarks";
			this.tb_remarks.Size = new System.Drawing.Size(229, 82);
			this.tb_remarks.TabIndex = 4;
			this.tb_remarks.ThemeName = "Office2007Silver";
			// 
			// lb_remarks
			// 
			this.lb_remarks.AutoSize = true;
			this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_remarks.Location = new System.Drawing.Point(11, 105);
			this.lb_remarks.Name = "lb_remarks";
			this.lb_remarks.Size = new System.Drawing.Size(89, 20);
			this.lb_remarks.TabIndex = 280;
			this.lb_remarks.Text = "备注说明：";
			// 
			// lb_customer
			// 
			this.lb_customer.AutoSize = true;
			this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_customer.Location = new System.Drawing.Point(43, 43);
			this.lb_customer.Name = "lb_customer";
			this.lb_customer.Size = new System.Drawing.Size(57, 20);
			this.lb_customer.TabIndex = 281;
			this.lb_customer.Text = "客户：";
			// 
			// lb_name
			// 
			this.lb_name.AutoSize = true;
			this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_name.Location = new System.Drawing.Point(43, 74);
			this.lb_name.Name = "lb_name";
			this.lb_name.Size = new System.Drawing.Size(57, 20);
			this.lb_name.TabIndex = 282;
			this.lb_name.Text = "名称：";
			// 
			// lb_cssd
			// 
			this.lb_cssd.AutoSize = true;
			this.lb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_cssd.Location = new System.Drawing.Point(39, 12);
			this.lb_cssd.Name = "lb_cssd";
			this.lb_cssd.Size = new System.Drawing.Size(61, 20);
			this.lb_cssd.TabIndex = 284;
			this.lb_cssd.Text = "CSSD：";
			// 
			// tb_customer
			// 
			this.tb_customer.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_customer.Location = new System.Drawing.Point(103, 43);
			this.tb_customer.Name = "tb_customer";
			this.tb_customer.ReadOnly = true;
			this.tb_customer.Size = new System.Drawing.Size(229, 25);
			this.tb_customer.TabIndex = 2;
			this.tb_customer.ThemeName = "Office2007Silver";
			// 
			// tb_name
			// 
			this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_name.Location = new System.Drawing.Point(103, 74);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(229, 25);
			this.tb_name.TabIndex = 3;
			this.tb_name.ThemeName = "Office2007Silver";
			// 
			// tb_cssd
			// 
			this.tb_cssd.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_cssd.Location = new System.Drawing.Point(103, 12);
			this.tb_cssd.Name = "tb_cssd";
			this.tb_cssd.ReadOnly = true;
			this.tb_cssd.Size = new System.Drawing.Size(229, 25);
			this.tb_cssd.TabIndex = 1;
			this.tb_cssd.ThemeName = "Office2007Silver";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(338, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 12);
			this.label4.TabIndex = 279;
			this.label4.Text = "*";
			// 
			// HCSCM_department_manage_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(364, 249);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.tb_remarks);
			this.Controls.Add(this.lb_remarks);
			this.Controls.Add(this.lb_customer);
			this.Controls.Add(this.lb_name);
			this.Controls.Add(this.lb_cssd);
			this.Controls.Add(this.tb_customer);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.tb_cssd);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "HCSCM_department_manage_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "创建部门";
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_customer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_cssd;
        private Telerik.WinControls.UI.RadTextBox tb_customer;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private Telerik.WinControls.UI.RadTextBox tb_cssd;
        private System.Windows.Forms.Label label4;
    }
}