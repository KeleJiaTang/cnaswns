namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_set_edit
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
            this.cb_if_urgent = new System.Windows.Forms.CheckBox();
            this.cb_ifhospital = new System.Windows.Forms.CheckBox();
            this.cb_RFID = new System.Windows.Forms.CheckBox();
            this.lb_barcode = new System.Windows.Forms.Label();
            this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_customer = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_cost_center = new System.Windows.Forms.Label();
            this.cb_cost_center = new Telerik.WinControls.UI.RadDropDownList();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_location = new System.Windows.Forms.Label();
            this.cb_location = new Telerik.WinControls.UI.RadDropDownList();
            this.tb_point = new Telerik.WinControls.UI.RadTextBox();
            this.lb_point = new System.Windows.Forms.Label();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.but_rea = new Telerik.WinControls.UI.RadButton();
            this.but_point = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_cost_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_location)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_rea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_if_urgent
            // 
            this.cb_if_urgent.AutoSize = true;
            this.cb_if_urgent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_if_urgent.Location = new System.Drawing.Point(96, 229);
            this.cb_if_urgent.Name = "cb_if_urgent";
            this.cb_if_urgent.Size = new System.Drawing.Size(92, 24);
            this.cb_if_urgent.TabIndex = 274;
            this.cb_if_urgent.Text = "单次加急";
            this.cb_if_urgent.UseVisualStyleBackColor = true;
            // 
            // cb_ifhospital
            // 
            this.cb_ifhospital.AutoSize = true;
            this.cb_ifhospital.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_ifhospital.Location = new System.Drawing.Point(224, 198);
            this.cb_ifhospital.Name = "cb_ifhospital";
            this.cb_ifhospital.Size = new System.Drawing.Size(108, 24);
            this.cb_ifhospital.TabIndex = 274;
            this.cb_ifhospital.Text = "院内手术包";
            this.cb_ifhospital.UseVisualStyleBackColor = true;
            this.cb_ifhospital.Visible = false;
            // 
            // cb_RFID
            // 
            this.cb_RFID.AutoSize = true;
            this.cb_RFID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_RFID.Location = new System.Drawing.Point(97, 198);
            this.cb_RFID.Name = "cb_RFID";
            this.cb_RFID.Size = new System.Drawing.Size(91, 24);
            this.cb_RFID.TabIndex = 279;
            this.cb_RFID.Text = "RFID追溯";
            this.cb_RFID.UseVisualStyleBackColor = true;
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_barcode.Location = new System.Drawing.Point(42, 15);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(57, 20);
            this.lb_barcode.TabIndex = 344;
            this.lb_barcode.Text = "条码：";
            // 
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_barcode.Location = new System.Drawing.Point(99, 12);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(229, 25);
            this.tb_barcode.TabIndex = 343;
            this.tb_barcode.ThemeName = "Office2007Silver";
            // 
            // cb_customer
            // 
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(99, 74);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(229, 25);
            this.cb_customer.TabIndex = 346;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
            this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(42, 74);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(57, 20);
            this.lb_customer.TabIndex = 348;
            this.lb_customer.Text = "客户：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(42, 43);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(57, 20);
            this.lb_name.TabIndex = 349;
            this.lb_name.Text = "名称：";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(99, 43);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 345;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(335, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 12);
            this.label12.TabIndex = 347;
            this.label12.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(335, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 12);
            this.label8.TabIndex = 347;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(335, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 12);
            this.label9.TabIndex = 347;
            this.label9.Text = "*";
            // 
            // lb_cost_center
            // 
            this.lb_cost_center.AutoSize = true;
            this.lb_cost_center.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_cost_center.Location = new System.Drawing.Point(10, 105);
            this.lb_cost_center.Name = "lb_cost_center";
            this.lb_cost_center.Size = new System.Drawing.Size(89, 20);
            this.lb_cost_center.TabIndex = 348;
            this.lb_cost_center.Text = "成本中心：";
            // 
            // cb_cost_center
            // 
            this.cb_cost_center.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_cost_center.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_cost_center.Location = new System.Drawing.Point(99, 105);
            this.cb_cost_center.Name = "cb_cost_center";
            this.cb_cost_center.Size = new System.Drawing.Size(229, 25);
            this.cb_cost_center.TabIndex = 346;
            this.cb_cost_center.ThemeName = "Office2007Silver";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(335, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 12);
            this.label11.TabIndex = 347;
            this.label11.Text = "*";
            // 
            // lb_location
            // 
            this.lb_location.AutoSize = true;
            this.lb_location.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_location.Location = new System.Drawing.Point(10, 136);
            this.lb_location.Name = "lb_location";
            this.lb_location.Size = new System.Drawing.Size(89, 20);
            this.lb_location.TabIndex = 348;
            this.lb_location.Text = "使用地点：";
            // 
            // cb_location
            // 
            this.cb_location.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_location.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_location.Location = new System.Drawing.Point(99, 136);
            this.cb_location.Name = "cb_location";
            this.cb_location.Size = new System.Drawing.Size(229, 25);
            this.cb_location.TabIndex = 346;
            this.cb_location.ThemeName = "Office2007Silver";
            // 
            // tb_point
            // 
            this.tb_point.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_point.Location = new System.Drawing.Point(99, 167);
            this.tb_point.Name = "tb_point";
            this.tb_point.ReadOnly = true;
            this.tb_point.Size = new System.Drawing.Size(127, 25);
            this.tb_point.TabIndex = 343;
            this.tb_point.ThemeName = "Office2007Silver";
            // 
            // lb_point
            // 
            this.lb_point.AutoSize = true;
            this.lb_point.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_point.Location = new System.Drawing.Point(26, 167);
            this.lb_point.Name = "lb_point";
            this.lb_point.Size = new System.Drawing.Size(73, 20);
            this.lb_point.TabIndex = 344;
            this.lb_point.Text = "存储点：";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(228, 267);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 351;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(96, 267);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 350;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_rea
            // 
            this.but_rea.Font = new System.Drawing.Font("宋体", 11F);
            this.but_rea.Location = new System.Drawing.Point(230, 167);
            this.but_rea.Name = "but_rea";
            this.but_rea.Size = new System.Drawing.Size(48, 25);
            this.but_rea.TabIndex = 351;
            this.but_rea.Text = "清空";
            this.but_rea.ThemeName = "Office2007Silver";
            this.but_rea.Click += new System.EventHandler(this.but_rea_Click);
            // 
            // but_point
            // 
            this.but_point.Font = new System.Drawing.Font("宋体", 11F);
            this.but_point.Location = new System.Drawing.Point(281, 167);
            this.but_point.Name = "but_point";
            this.but_point.Size = new System.Drawing.Size(48, 25);
            this.but_point.TabIndex = 351;
            this.but_point.Text = "选择";
            this.but_point.ThemeName = "Office2007Silver";
            this.but_point.Click += new System.EventHandler(this.but_point_Click);
            // 
            // HCSCM_set_manager_set_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(359, 317);
            this.Controls.Add(this.but_point);
            this.Controls.Add(this.but_rea);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.cb_location);
            this.Controls.Add(this.lb_location);
            this.Controls.Add(this.cb_cost_center);
            this.Controls.Add(this.lb_cost_center);
            this.Controls.Add(this.cb_customer);
            this.Controls.Add(this.lb_customer);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lb_point);
            this.Controls.Add(this.lb_barcode);
            this.Controls.Add(this.tb_point);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.cb_RFID);
            this.Controls.Add(this.cb_ifhospital);
            this.Controls.Add(this.cb_if_urgent);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_set_manager_set_edit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_cost_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_location)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_rea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_if_urgent;
        private System.Windows.Forms.CheckBox cb_ifhospital;
        private System.Windows.Forms.CheckBox cb_RFID;
        private System.Windows.Forms.Label lb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label lb_name;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_cost_center;
        private Telerik.WinControls.UI.RadDropDownList cb_cost_center;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_location;
        private Telerik.WinControls.UI.RadDropDownList cb_location;
        private Telerik.WinControls.UI.RadTextBox tb_point;
        private System.Windows.Forms.Label lb_point;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadButton but_rea;
        private Telerik.WinControls.UI.RadButton but_point;
    }
}