namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_washin_program
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
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.but_cancel = new System.Windows.Forms.Button();
            this.but_ok = new System.Windows.Forms.Button();
            this.lb_model = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_remarks = new System.Windows.Forms.Label();
            this.tb_remarks = new System.Windows.Forms.TextBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.lb_barcode = new System.Windows.Forms.Label();
            this.lb_info = new System.Windows.Forms.Label();
            this.tb_model = new System.Windows.Forms.TextBox();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.lb_price = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.gb_bd_test.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_bd_test
            // 
            this.gb_bd_test.Controls.Add(this.dt_bd_test);
            this.gb_bd_test.Controls.Add(this.rb_unwanted);
            this.gb_bd_test.Controls.Add(this.rb_want);
            this.gb_bd_test.Controls.Add(this.lb_info_time);
            this.gb_bd_test.Location = new System.Drawing.Point(384, 47);
            this.gb_bd_test.Name = "gb_bd_test";
            this.gb_bd_test.Size = new System.Drawing.Size(282, 135);
            this.gb_bd_test.TabIndex = 32;
            this.gb_bd_test.TabStop = false;
            this.gb_bd_test.Text = "生产所需的日常审批测试";
            // 
            // dt_bd_test
            // 
            this.dt_bd_test.CustomFormat = "HH:mm:ss";
            this.dt_bd_test.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_bd_test.Location = new System.Drawing.Point(8, 87);
            this.dt_bd_test.Name = "dt_bd_test";
            this.dt_bd_test.ShowUpDown = true;
            this.dt_bd_test.Size = new System.Drawing.Size(200, 21);
            this.dt_bd_test.TabIndex = 2;
            this.dt_bd_test.Value = new System.DateTime(2016, 1, 13, 12, 33, 53, 0);
            // 
            // rb_unwanted
            // 
            this.rb_unwanted.AutoSize = true;
            this.rb_unwanted.Location = new System.Drawing.Point(173, 27);
            this.rb_unwanted.Name = "rb_unwanted";
            this.rb_unwanted.Size = new System.Drawing.Size(59, 16);
            this.rb_unwanted.TabIndex = 1;
            this.rb_unwanted.TabStop = true;
            this.rb_unwanted.Text = "不需要";
            this.rb_unwanted.UseVisualStyleBackColor = true;
            // 
            // rb_want
            // 
            this.rb_want.AutoSize = true;
            this.rb_want.Checked = true;
            this.rb_want.Location = new System.Drawing.Point(6, 27);
            this.rb_want.Name = "rb_want";
            this.rb_want.Size = new System.Drawing.Size(47, 16);
            this.rb_want.TabIndex = 1;
            this.rb_want.TabStop = true;
            this.rb_want.Text = "需要";
            this.rb_want.UseVisualStyleBackColor = true;
            // 
            // lb_info_time
            // 
            this.lb_info_time.AutoSize = true;
            this.lb_info_time.Location = new System.Drawing.Point(6, 62);
            this.lb_info_time.Name = "lb_info_time";
            this.lb_info_time.Size = new System.Drawing.Size(77, 12);
            this.lb_info_time.TabIndex = 0;
            this.lb_info_time.Text = "每日审批时间";
            // 
            // cb_type
            // 
            this.cb_type.BackColor = System.Drawing.Color.Yellow;
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(98, 153);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(229, 20);
            this.cb_type.TabIndex = 18;
            // 
            // but_cancel
            // 
            this.but_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(384, 303);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 26;
            this.but_cancel.Text = "关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            // 
            // but_ok
            // 
            this.but_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_ok.Location = new System.Drawing.Point(228, 303);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 25;
            this.but_ok.Text = "确定";
            this.but_ok.UseVisualStyleBackColor = true;
            // 
            // lb_model
            // 
            this.lb_model.AutoSize = true;
            this.lb_model.Location = new System.Drawing.Point(21, 208);
            this.lb_model.Name = "lb_model";
            this.lb_model.Size = new System.Drawing.Size(65, 12);
            this.lb_model.TabIndex = 30;
            this.lb_model.Text = "清洗机型号";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Location = new System.Drawing.Point(21, 156);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(41, 12);
            this.lb_type.TabIndex = 31;
            this.lb_type.Text = "生产商";
            // 
            // lb_remarks
            // 
            this.lb_remarks.AutoSize = true;
            this.lb_remarks.Location = new System.Drawing.Point(382, 198);
            this.lb_remarks.Name = "lb_remarks";
            this.lb_remarks.Size = new System.Drawing.Size(29, 12);
            this.lb_remarks.TabIndex = 29;
            this.lb_remarks.Text = "描述";
            // 
            // tb_remarks
            // 
            this.tb_remarks.Location = new System.Drawing.Point(437, 198);
            this.tb_remarks.Multiline = true;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(229, 81);
            this.tb_remarks.TabIndex = 23;
            // 
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.SystemColors.Control;
            this.tb_barcode.Location = new System.Drawing.Point(98, 47);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(229, 21);
            this.tb_barcode.TabIndex = 28;
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Location = new System.Drawing.Point(21, 50);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(29, 12);
            this.lb_barcode.TabIndex = 27;
            this.lb_barcode.Text = "条码";
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info.Location = new System.Drawing.Point(313, 10);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(88, 16);
            this.lb_info.TabIndex = 24;
            this.lb_info.Text = "添加塑封机";
            // 
            // tb_model
            // 
            this.tb_model.Location = new System.Drawing.Point(98, 205);
            this.tb_model.Name = "tb_model";
            this.tb_model.Size = new System.Drawing.Size(229, 21);
            this.tb_model.TabIndex = 19;
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(98, 258);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(229, 21);
            this.tb_price.TabIndex = 22;
            // 
            // lb_price
            // 
            this.lb_price.AutoSize = true;
            this.lb_price.Location = new System.Drawing.Point(21, 261);
            this.lb_price.Name = "lb_price";
            this.lb_price.Size = new System.Drawing.Size(65, 12);
            this.lb_price.TabIndex = 20;
            this.lb_price.Text = "清洗机价格";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(98, 100);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 21);
            this.tb_name.TabIndex = 17;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(21, 103);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(29, 12);
            this.lb_name.TabIndex = 21;
            this.lb_name.Text = "名字";
            // 
            // HCSCM_washin_device_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 366);
            this.Controls.Add(this.gb_bd_test);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.lb_model);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.lb_remarks);
            this.Controls.Add(this.tb_remarks);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.lb_barcode);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.tb_model);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.lb_price);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HCSCM_washin_device_new";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_washin_device_new";
            this.gb_bd_test.ResumeLayout(false);
            this.gb_bd_test.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_bd_test;
        private System.Windows.Forms.DateTimePicker dt_bd_test;
        private System.Windows.Forms.RadioButton rb_unwanted;
        private System.Windows.Forms.RadioButton rb_want;
        private System.Windows.Forms.Label lb_info_time;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Label lb_model;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.TextBox tb_remarks;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.Label lb_barcode;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.TextBox tb_model;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.Label lb_price;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lb_name;
    }
}