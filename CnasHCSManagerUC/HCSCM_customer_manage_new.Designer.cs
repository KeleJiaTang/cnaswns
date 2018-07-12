namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_customer_manage_new
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
			this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.tb_address = new Telerik.WinControls.UI.RadTextBoxControl();
			this.lb_address = new System.Windows.Forms.Label();
			this.lb_contacts = new System.Windows.Forms.Label();
			this.lb_name = new System.Windows.Forms.Label();
			this.lb_type = new System.Windows.Forms.Label();
			this.lb_barcode = new System.Windows.Forms.Label();
			this.tb_contacts = new Telerik.WinControls.UI.RadTextBox();
			this.tb_name = new Telerik.WinControls.UI.RadTextBox();
			this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_telephone = new Telerik.WinControls.UI.RadTextBox();
			this.lb_telephone = new System.Windows.Forms.Label();
			this.tb_mail = new Telerik.WinControls.UI.RadTextBox();
			this.lb_mail = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_address)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_contacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_telephone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_mail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_type
			// 
			this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_type.Location = new System.Drawing.Point(108, 43);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(229, 25);
			this.cb_type.TabIndex = 2;
			this.cb_type.ThemeName = "Office2007Silver";
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(238, 292);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 9;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(108, 292);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 8;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// tb_address
			// 
			this.tb_address.AcceptsReturn = true;
			this.tb_address.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_address.Location = new System.Drawing.Point(108, 198);
			this.tb_address.Multiline = true;
			this.tb_address.Name = "tb_address";
			this.tb_address.Size = new System.Drawing.Size(229, 82);
			this.tb_address.TabIndex = 7;
			this.tb_address.ThemeName = "Office2007Silver";
			// 
			// lb_address
			// 
			this.lb_address.AutoSize = true;
			this.lb_address.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_address.Location = new System.Drawing.Point(13, 198);
			this.lb_address.Name = "lb_address";
			this.lb_address.Size = new System.Drawing.Size(89, 20);
			this.lb_address.TabIndex = 283;
			this.lb_address.Text = "备注说明：";
			// 
			// lb_contacts
			// 
			this.lb_contacts.AutoSize = true;
			this.lb_contacts.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_contacts.Location = new System.Drawing.Point(29, 105);
			this.lb_contacts.Name = "lb_contacts";
			this.lb_contacts.Size = new System.Drawing.Size(73, 20);
			this.lb_contacts.TabIndex = 284;
			this.lb_contacts.Text = "联系人：";
			// 
			// lb_name
			// 
			this.lb_name.AutoSize = true;
			this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_name.Location = new System.Drawing.Point(46, 74);
			this.lb_name.Name = "lb_name";
			this.lb_name.Size = new System.Drawing.Size(57, 20);
			this.lb_name.TabIndex = 285;
			this.lb_name.Text = "名称：";
			// 
			// lb_type
			// 
			this.lb_type.AutoSize = true;
			this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_type.Location = new System.Drawing.Point(14, 43);
			this.lb_type.Name = "lb_type";
			this.lb_type.Size = new System.Drawing.Size(89, 20);
			this.lb_type.TabIndex = 286;
			this.lb_type.Text = "医院类型：";
			// 
			// lb_barcode
			// 
			this.lb_barcode.AutoSize = true;
			this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_barcode.Location = new System.Drawing.Point(46, 12);
			this.lb_barcode.Name = "lb_barcode";
			this.lb_barcode.Size = new System.Drawing.Size(57, 20);
			this.lb_barcode.TabIndex = 287;
			this.lb_barcode.Text = "条码：";
			// 
			// tb_contacts
			// 
			this.tb_contacts.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_contacts.Location = new System.Drawing.Point(108, 105);
			this.tb_contacts.Name = "tb_contacts";
			this.tb_contacts.Size = new System.Drawing.Size(229, 25);
			this.tb_contacts.TabIndex = 4;
			this.tb_contacts.ThemeName = "Office2007Silver";
			// 
			// tb_name
			// 
			this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_name.Location = new System.Drawing.Point(108, 74);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(229, 25);
			this.tb_name.TabIndex = 3;
			this.tb_name.ThemeName = "Office2007Silver";
			// 
			// tb_barcode
			// 
			this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_barcode.Location = new System.Drawing.Point(108, 12);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.ReadOnly = true;
			this.tb_barcode.Size = new System.Drawing.Size(229, 25);
			this.tb_barcode.TabIndex = 1;
			this.tb_barcode.ThemeName = "Office2007Silver";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(343, 75);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 12);
			this.label6.TabIndex = 282;
			this.label6.Text = "*";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(343, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 12);
			this.label7.TabIndex = 281;
			this.label7.Text = "*";
			// 
			// tb_telephone
			// 
			this.tb_telephone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_telephone.Location = new System.Drawing.Point(108, 136);
			this.tb_telephone.Name = "tb_telephone";
			this.tb_telephone.Size = new System.Drawing.Size(229, 25);
			this.tb_telephone.TabIndex = 5;
			this.tb_telephone.ThemeName = "Office2007Silver";
			// 
			// lb_telephone
			// 
			this.lb_telephone.AutoSize = true;
			this.lb_telephone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_telephone.Location = new System.Drawing.Point(13, 136);
			this.lb_telephone.Name = "lb_telephone";
			this.lb_telephone.Size = new System.Drawing.Size(89, 20);
			this.lb_telephone.TabIndex = 284;
			this.lb_telephone.Text = "联系电话：";
			// 
			// tb_mail
			// 
			this.tb_mail.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_mail.Location = new System.Drawing.Point(108, 167);
			this.tb_mail.Name = "tb_mail";
			this.tb_mail.Size = new System.Drawing.Size(229, 25);
			this.tb_mail.TabIndex = 6;
			this.tb_mail.ThemeName = "Office2007Silver";
			// 
			// lb_mail
			// 
			this.lb_mail.AutoSize = true;
			this.lb_mail.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_mail.Location = new System.Drawing.Point(13, 167);
			this.lb_mail.Name = "lb_mail";
			this.lb_mail.Size = new System.Drawing.Size(89, 20);
			this.lb_mail.TabIndex = 284;
			this.lb_mail.Text = "电子邮箱：";
			// 
			// HCSCM_customer_manage_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(373, 340);
			this.Controls.Add(this.cb_type);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.tb_address);
			this.Controls.Add(this.lb_address);
			this.Controls.Add(this.lb_mail);
			this.Controls.Add(this.lb_telephone);
			this.Controls.Add(this.lb_contacts);
			this.Controls.Add(this.lb_name);
			this.Controls.Add(this.lb_type);
			this.Controls.Add(this.lb_barcode);
			this.Controls.Add(this.tb_mail);
			this.Controls.Add(this.tb_telephone);
			this.Controls.Add(this.tb_contacts);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.tb_barcode);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_customer_manage_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加客户";
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_address)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_contacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_telephone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_mail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_address;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.Label lb_contacts;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_contacts;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadTextBox tb_telephone;
        private Telerik.WinControls.UI.RadTextBox tb_mail;
        private System.Windows.Forms.Label lb_telephone;
        private System.Windows.Forms.Label lb_mail;

    }
}