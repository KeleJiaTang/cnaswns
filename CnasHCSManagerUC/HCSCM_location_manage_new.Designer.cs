namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_location_manage_new
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
			this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
			this.lb_remarks = new System.Windows.Forms.Label();
			this.lb_name = new System.Windows.Forms.Label();
			this.lb_type = new System.Windows.Forms.Label();
			this.lb_barcode = new System.Windows.Forms.Label();
			this.tb_name = new Telerik.WinControls.UI.RadTextBox();
			this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
			this.lb_customer = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.cb_costcenter = new Telerik.WinControls.UI.RadDropDownList();
			this.lb_costcenter = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_costcenter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_type
			// 
			this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_type.Location = new System.Drawing.Point(140, 74);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(229, 25);
			this.cb_type.TabIndex = 3;
			this.cb_type.ThemeName = "Office2007Silver";
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(270, 261);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 8;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(140, 261);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 7;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// tb_remarks
			// 
			this.tb_remarks.AcceptsReturn = true;
			this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_remarks.Location = new System.Drawing.Point(140, 167);
			this.tb_remarks.Multiline = true;
			this.tb_remarks.Name = "tb_remarks";
			this.tb_remarks.Size = new System.Drawing.Size(229, 82);
			this.tb_remarks.TabIndex = 6;
			this.tb_remarks.ThemeName = "Office2007Silver";
			// 
			// lb_remarks
			// 
			this.lb_remarks.AutoSize = true;
			this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_remarks.Location = new System.Drawing.Point(46, 167);
			this.lb_remarks.Name = "lb_remarks";
			this.lb_remarks.Size = new System.Drawing.Size(89, 20);
			this.lb_remarks.TabIndex = 299;
			this.lb_remarks.Text = "备注说明：";
			// 
			// lb_name
			// 
			this.lb_name.AutoSize = true;
			this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_name.Location = new System.Drawing.Point(78, 43);
			this.lb_name.Name = "lb_name";
			this.lb_name.Size = new System.Drawing.Size(57, 20);
			this.lb_name.TabIndex = 303;
			this.lb_name.Text = "名称：";
			// 
			// lb_type
			// 
			this.lb_type.AutoSize = true;
			this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_type.Location = new System.Drawing.Point(14, 74);
			this.lb_type.Name = "lb_type";
			this.lb_type.Size = new System.Drawing.Size(121, 20);
			this.lb_type.TabIndex = 304;
			this.lb_type.Text = "使用地点类型：";
			// 
			// lb_barcode
			// 
			this.lb_barcode.AutoSize = true;
			this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_barcode.Location = new System.Drawing.Point(78, 12);
			this.lb_barcode.Name = "lb_barcode";
			this.lb_barcode.Size = new System.Drawing.Size(57, 20);
			this.lb_barcode.TabIndex = 305;
			this.lb_barcode.Text = "条码：";
			// 
			// tb_name
			// 
			this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_name.Location = new System.Drawing.Point(140, 43);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(229, 25);
			this.tb_name.TabIndex = 2;
			this.tb_name.ThemeName = "Office2007Silver";
			// 
			// tb_barcode
			// 
			this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_barcode.Location = new System.Drawing.Point(140, 12);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.ReadOnly = true;
			this.tb_barcode.Size = new System.Drawing.Size(229, 25);
			this.tb_barcode.TabIndex = 1;
			this.tb_barcode.ThemeName = "Office2007Silver";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(371, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 12);
			this.label9.TabIndex = 298;
			this.label9.Text = "*";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label10.ForeColor = System.Drawing.Color.Red;
			this.label10.Location = new System.Drawing.Point(371, 81);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(12, 12);
			this.label10.TabIndex = 297;
			this.label10.Text = "*";
			// 
			// cb_customer
			// 
			this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_customer.Location = new System.Drawing.Point(140, 105);
			this.cb_customer.Name = "cb_customer";
			this.cb_customer.Size = new System.Drawing.Size(229, 25);
			this.cb_customer.TabIndex = 4;
			this.cb_customer.ThemeName = "Office2007Silver";
			this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
			this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
			// 
			// lb_customer
			// 
			this.lb_customer.AutoSize = true;
			this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_customer.Location = new System.Drawing.Point(78, 105);
			this.lb_customer.Name = "lb_customer";
			this.lb_customer.Size = new System.Drawing.Size(57, 20);
			this.lb_customer.TabIndex = 308;
			this.lb_customer.Text = "客户：";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.Red;
			this.label12.Location = new System.Drawing.Point(371, 112);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(12, 12);
			this.label12.TabIndex = 307;
			this.label12.Text = "*";
			// 
			// cb_costcenter
			// 
			this.cb_costcenter.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_costcenter.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_costcenter.Location = new System.Drawing.Point(140, 136);
			this.cb_costcenter.Name = "cb_costcenter";
			this.cb_costcenter.Size = new System.Drawing.Size(229, 25);
			this.cb_costcenter.TabIndex = 5;
			this.cb_costcenter.ThemeName = "Office2007Silver";
			// 
			// lb_costcenter
			// 
			this.lb_costcenter.AutoSize = true;
			this.lb_costcenter.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_costcenter.Location = new System.Drawing.Point(46, 136);
			this.lb_costcenter.Name = "lb_costcenter";
			this.lb_costcenter.Size = new System.Drawing.Size(89, 20);
			this.lb_costcenter.TabIndex = 311;
			this.lb_costcenter.Text = "成本中心：";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label14.ForeColor = System.Drawing.Color.Red;
			this.label14.Location = new System.Drawing.Point(371, 142);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(12, 12);
			this.label14.TabIndex = 310;
			this.label14.Text = "*";
			// 
			// HCSCM_location_manage_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(408, 312);
			this.Controls.Add(this.cb_costcenter);
			this.Controls.Add(this.lb_costcenter);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.cb_customer);
			this.Controls.Add(this.lb_customer);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.cb_type);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.tb_remarks);
			this.Controls.Add(this.lb_remarks);
			this.Controls.Add(this.lb_name);
			this.Controls.Add(this.lb_type);
			this.Controls.Add(this.lb_barcode);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.tb_barcode);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_location_manage_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "新建使用地点";
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_costcenter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.UI.RadDropDownList cb_costcenter;
        private System.Windows.Forms.Label lb_costcenter;
        private System.Windows.Forms.Label label14;
    }
}