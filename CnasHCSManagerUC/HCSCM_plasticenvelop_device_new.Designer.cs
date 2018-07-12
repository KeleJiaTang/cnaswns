namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_plasticenvelop_device_new
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
            this.gb_bd_test = new System.Windows.Forms.GroupBox();
            this.dt_bd_test = new System.Windows.Forms.DateTimePicker();
            this.rb_unwanted = new System.Windows.Forms.RadioButton();
            this.rb_want = new System.Windows.Forms.RadioButton();
            this.lb_info_time = new System.Windows.Forms.Label();
            this.cb_sales = new Telerik.WinControls.UI.RadDropDownList();
            this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_sales = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
            this.lb_barcode = new System.Windows.Forms.Label();
            this.tb_model = new Telerik.WinControls.UI.RadTextBox();
            this.lb_model = new System.Windows.Forms.Label();
            this.tb_price = new Telerik.WinControls.UI.RadTextBox();
            this.lb_price = new System.Windows.Forms.Label();
            this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lb_remarks = new System.Windows.Forms.Label();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.gb_bd_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_model)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_bd_test
            // 
            this.gb_bd_test.Controls.Add(this.dt_bd_test);
            this.gb_bd_test.Controls.Add(this.rb_unwanted);
            this.gb_bd_test.Controls.Add(this.rb_want);
            this.gb_bd_test.Controls.Add(this.lb_info_time);
            this.gb_bd_test.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gb_bd_test.Location = new System.Drawing.Point(400, 12);
            this.gb_bd_test.Margin = new System.Windows.Forms.Padding(4);
            this.gb_bd_test.Name = "gb_bd_test";
            this.gb_bd_test.Padding = new System.Windows.Forms.Padding(4);
            this.gb_bd_test.Size = new System.Drawing.Size(276, 82);
            this.gb_bd_test.TabIndex = 32;
            this.gb_bd_test.TabStop = false;
            this.gb_bd_test.Text = "生产所需的日常审批测试";
            // 
            // dt_bd_test
            // 
            this.dt_bd_test.CustomFormat = "HH:mm:ss";
            this.dt_bd_test.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dt_bd_test.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_bd_test.Location = new System.Drawing.Point(138, 48);
            this.dt_bd_test.Margin = new System.Windows.Forms.Padding(4);
            this.dt_bd_test.Name = "dt_bd_test";
            this.dt_bd_test.ShowUpDown = true;
            this.dt_bd_test.Size = new System.Drawing.Size(122, 27);
            this.dt_bd_test.TabIndex = 2;
            this.dt_bd_test.Value = new System.DateTime(2016, 1, 13, 12, 33, 53, 0);
            // 
            // rb_unwanted
            // 
            this.rb_unwanted.AutoSize = true;
            this.rb_unwanted.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_unwanted.Location = new System.Drawing.Point(15, 51);
            this.rb_unwanted.Margin = new System.Windows.Forms.Padding(4);
            this.rb_unwanted.Name = "rb_unwanted";
            this.rb_unwanted.Size = new System.Drawing.Size(75, 24);
            this.rb_unwanted.TabIndex = 1;
            this.rb_unwanted.TabStop = true;
            this.rb_unwanted.Text = "不需要";
            this.rb_unwanted.UseVisualStyleBackColor = true;
            this.rb_unwanted.CheckedChanged += new System.EventHandler(this.rb_unwanted_CheckedChanged);
            // 
            // rb_want
            // 
            this.rb_want.AutoSize = true;
            this.rb_want.Checked = true;
            this.rb_want.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_want.Location = new System.Drawing.Point(14, 23);
            this.rb_want.Margin = new System.Windows.Forms.Padding(4);
            this.rb_want.Name = "rb_want";
            this.rb_want.Size = new System.Drawing.Size(59, 24);
            this.rb_want.TabIndex = 1;
            this.rb_want.TabStop = true;
            this.rb_want.Text = "需要";
            this.rb_want.UseVisualStyleBackColor = true;
            this.rb_want.CheckedChanged += new System.EventHandler(this.rb_want_CheckedChanged);
            // 
            // lb_info_time
            // 
            this.lb_info_time.AutoSize = true;
            this.lb_info_time.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_info_time.Location = new System.Drawing.Point(139, 25);
            this.lb_info_time.Name = "lb_info_time";
            this.lb_info_time.Size = new System.Drawing.Size(121, 20);
            this.lb_info_time.TabIndex = 0;
            this.lb_info_time.Text = "每日审批时间：";
            // 
            // cb_sales
            // 
            this.cb_sales.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_sales.Location = new System.Drawing.Point(134, 105);
            this.cb_sales.Name = "cb_sales";
            this.cb_sales.Size = new System.Drawing.Size(229, 25);
            this.cb_sales.TabIndex = 307;
            this.cb_sales.ThemeName = "Office2007Silver";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_type.Location = new System.Drawing.Point(134, 74);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(229, 25);
            this.cb_type.TabIndex = 308;
            this.cb_type.ThemeName = "Office2007Silver";
            // 
            // lb_sales
            // 
            this.lb_sales.AutoSize = true;
            this.lb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_sales.Location = new System.Drawing.Point(61, 105);
            this.lb_sales.Name = "lb_sales";
            this.lb_sales.Size = new System.Drawing.Size(73, 20);
            this.lb_sales.TabIndex = 312;
            this.lb_sales.Text = "销售商：";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_type.Location = new System.Drawing.Point(61, 74);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(73, 20);
            this.lb_type.TabIndex = 313;
            this.lb_type.Text = "生产商：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(29, 43);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(105, 20);
            this.lb_name.TabIndex = 314;
            this.lb_name.Text = "塑封机名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(365, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 12);
            this.label5.TabIndex = 309;
            this.label5.Text = "*";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(134, 43);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 306;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(366, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 12);
            this.label6.TabIndex = 310;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(365, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 311;
            this.label7.Text = "*";
            // 
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_barcode.Location = new System.Drawing.Point(134, 12);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(229, 25);
            this.tb_barcode.TabIndex = 306;
            this.tb_barcode.ThemeName = "Office2007Silver";
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_barcode.Location = new System.Drawing.Point(77, 12);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(57, 20);
            this.lb_barcode.TabIndex = 314;
            this.lb_barcode.Text = "条码：";
            // 
            // tb_model
            // 
            this.tb_model.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_model.Location = new System.Drawing.Point(134, 136);
            this.tb_model.Name = "tb_model";
            this.tb_model.Size = new System.Drawing.Size(229, 25);
            this.tb_model.TabIndex = 306;
            this.tb_model.ThemeName = "Office2007Silver";
            // 
            // lb_model
            // 
            this.lb_model.AutoSize = true;
            this.lb_model.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_model.Location = new System.Drawing.Point(29, 136);
            this.lb_model.Name = "lb_model";
            this.lb_model.Size = new System.Drawing.Size(105, 20);
            this.lb_model.TabIndex = 314;
            this.lb_model.Text = "塑封机型号：";
            // 
            // tb_price
            // 
            this.tb_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_price.Location = new System.Drawing.Point(134, 167);
            this.tb_price.MaxLength = 10;
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(229, 25);
            this.tb_price.TabIndex = 306;
            this.tb_price.ThemeName = "Office2007Silver";
            this.tb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_price_KeyPress);
            // 
            // lb_price
            // 
            this.lb_price.AutoSize = true;
            this.lb_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_price.Location = new System.Drawing.Point(3, 167);
            this.lb_price.Name = "lb_price";
            this.lb_price.Size = new System.Drawing.Size(131, 20);
            this.lb_price.TabIndex = 314;
            this.lb_price.Text = "塑封机价格(元)：";
            // 
            // tb_remarks
            // 
            this.tb_remarks.AcceptsReturn = true;
            this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_remarks.Location = new System.Drawing.Point(400, 136);
            this.tb_remarks.Multiline = true;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(276, 51);
            this.tb_remarks.TabIndex = 315;
            this.tb_remarks.ThemeName = "Office2007Silver";
            // 
            // lb_remarks
            // 
            this.lb_remarks.AutoSize = true;
            this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_remarks.Location = new System.Drawing.Point(396, 105);
            this.lb_remarks.Name = "lb_remarks";
            this.lb_remarks.Size = new System.Drawing.Size(89, 20);
            this.lb_remarks.TabIndex = 316;
            this.lb_remarks.Text = "备注说明：";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(400, 204);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 318;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(265, 204);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 317;
            this.but_ok.Text = " 确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // HCSCM_plasticenvelop_device_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(691, 255);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.tb_remarks);
            this.Controls.Add(this.lb_remarks);
            this.Controls.Add(this.cb_sales);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lb_sales);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.lb_price);
            this.Controls.Add(this.lb_model);
            this.Controls.Add(this.lb_barcode);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_model);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gb_bd_test);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_plasticenvelop_device_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加塑封机";
            this.gb_bd_test.ResumeLayout(false);
            this.gb_bd_test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_model)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_bd_test;
        private System.Windows.Forms.DateTimePicker dt_bd_test;
        private System.Windows.Forms.RadioButton rb_unwanted;
        private System.Windows.Forms.RadioButton rb_want;
        private System.Windows.Forms.Label lb_info_time;
        private Telerik.WinControls.UI.RadDropDownList cb_sales;
        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private System.Windows.Forms.Label lb_sales;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private System.Windows.Forms.Label lb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_model;
        private System.Windows.Forms.Label lb_model;
        private Telerik.WinControls.UI.RadTextBox tb_price;
        private System.Windows.Forms.Label lb_price;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;

    }
}