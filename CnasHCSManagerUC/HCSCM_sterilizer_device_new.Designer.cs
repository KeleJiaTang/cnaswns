namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_sterilizer_device_new
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
            this.gp_bd = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rb_bd_yes = new System.Windows.Forms.RadioButton();
            this.dtp_bd = new System.Windows.Forms.DateTimePicker();
            this.rb_bd_no = new System.Windows.Forms.RadioButton();
            this.lb_bd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lb_remarks = new System.Windows.Forms.Label();
            this.cb_sales = new Telerik.WinControls.UI.RadDropDownList();
            this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_sales = new System.Windows.Forms.Label();
            this.lb_vender = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_barcode = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_price = new Telerik.WinControls.UI.RadTextBox();
            this.tb_model = new Telerik.WinControls.UI.RadTextBox();
            this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_stu = new Telerik.WinControls.UI.RadTextBox();
            this.lb_stu = new System.Windows.Forms.Label();
            this.tb_minstu = new Telerik.WinControls.UI.RadTextBox();
            this.lb_minstu = new System.Windows.Forms.Label();
            this.tb_maxstu = new Telerik.WinControls.UI.RadTextBox();
            this.lb_maxstu = new System.Windows.Forms.Label();
            this.gp_bd.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_model)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_stu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_minstu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_maxstu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_bd
            // 
            this.gp_bd.Controls.Add(this.tableLayoutPanel1);
            this.gp_bd.Font = new System.Drawing.Font("宋体", 11F);
            this.gp_bd.Location = new System.Drawing.Point(400, 12);
            this.gp_bd.Name = "gp_bd";
            this.gp_bd.Size = new System.Drawing.Size(271, 87);
            this.gp_bd.TabIndex = 56;
            this.gp_bd.TabStop = false;
            this.gp_bd.Text = "日常审批测试";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.94595F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.05405F));
            this.tableLayoutPanel1.Controls.Add(this.rb_bd_yes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtp_bd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rb_bd_no, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_bd, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 64);
            this.tableLayoutPanel1.TabIndex = 274;
            // 
            // rb_bd_yes
            // 
            this.rb_bd_yes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rb_bd_yes.AutoSize = true;
            this.rb_bd_yes.Checked = true;
            this.rb_bd_yes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_bd_yes.Location = new System.Drawing.Point(3, 3);
            this.rb_bd_yes.Name = "rb_bd_yes";
            this.rb_bd_yes.Size = new System.Drawing.Size(59, 24);
            this.rb_bd_yes.TabIndex = 9;
            this.rb_bd_yes.TabStop = true;
            this.rb_bd_yes.Text = "需要";
            this.rb_bd_yes.UseVisualStyleBackColor = true;
            this.rb_bd_yes.CheckedChanged += new System.EventHandler(this.rb_bd_yes_CheckedChanged);
            // 
            // dtp_bd
            // 
            this.dtp_bd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_bd.CustomFormat = " HH:mm:tt";
            this.dtp_bd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_bd.Location = new System.Drawing.Point(124, 34);
            this.dtp_bd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dtp_bd.Name = "dtp_bd";
            this.dtp_bd.ShowUpDown = true;
            this.dtp_bd.Size = new System.Drawing.Size(138, 24);
            this.dtp_bd.TabIndex = 11;
            // 
            // rb_bd_no
            // 
            this.rb_bd_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rb_bd_no.AutoSize = true;
            this.rb_bd_no.Cursor = System.Windows.Forms.Cursors.Default;
            this.rb_bd_no.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_bd_no.Location = new System.Drawing.Point(3, 35);
            this.rb_bd_no.Name = "rb_bd_no";
            this.rb_bd_no.Size = new System.Drawing.Size(75, 24);
            this.rb_bd_no.TabIndex = 10;
            this.rb_bd_no.Text = "不需要";
            this.rb_bd_no.UseVisualStyleBackColor = true;
            this.rb_bd_no.CheckedChanged += new System.EventHandler(this.rb_bd_no_CheckedChanged);
            // 
            // lb_bd
            // 
            this.lb_bd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_bd.AutoSize = true;
            this.lb_bd.Font = new System.Drawing.Font("宋体", 11F);
            this.lb_bd.Location = new System.Drawing.Point(124, 6);
            this.lb_bd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lb_bd.Name = "lb_bd";
            this.lb_bd.Size = new System.Drawing.Size(112, 15);
            this.lb_bd.TabIndex = 3;
            this.lb_bd.Text = "每天审批时间：";
            this.lb_bd.Click += new System.EventHandler(this.lb_bd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(371, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 273;
            this.label3.Text = "*";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(403, 297);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 14;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(266, 297);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 13;
            this.but_ok.Text = "确  定 ";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_OK_Click_1);
            // 
            // tb_remarks
            // 
            this.tb_remarks.AcceptsReturn = true;
            this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_remarks.Location = new System.Drawing.Point(402, 136);
            this.tb_remarks.Multiline = true;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(269, 149);
            this.tb_remarks.TabIndex = 12;
            this.tb_remarks.ThemeName = "Office2007Silver";
            // 
            // lb_remarks
            // 
            this.lb_remarks.AutoSize = true;
            this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_remarks.Location = new System.Drawing.Point(396, 105);
            this.lb_remarks.Name = "lb_remarks";
            this.lb_remarks.Size = new System.Drawing.Size(89, 20);
            this.lb_remarks.TabIndex = 336;
            this.lb_remarks.Text = "备注说明：";
            // 
            // cb_sales
            // 
            this.cb_sales.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_sales.Location = new System.Drawing.Point(136, 105);
            this.cb_sales.Name = "cb_sales";
            this.cb_sales.Size = new System.Drawing.Size(229, 25);
            this.cb_sales.TabIndex = 3;
            this.cb_sales.ThemeName = "Office2007Silver";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_type.Location = new System.Drawing.Point(136, 74);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(229, 25);
            this.cb_type.TabIndex = 2;
            this.cb_type.ThemeName = "Office2007Silver";
            // 
            // lb_sales
            // 
            this.lb_sales.AutoSize = true;
            this.lb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_sales.Location = new System.Drawing.Point(63, 105);
            this.lb_sales.Name = "lb_sales";
            this.lb_sales.Size = new System.Drawing.Size(73, 20);
            this.lb_sales.TabIndex = 329;
            this.lb_sales.Text = "销售商：";
            // 
            // lb_vender
            // 
            this.lb_vender.AutoSize = true;
            this.lb_vender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_vender.Location = new System.Drawing.Point(63, 74);
            this.lb_vender.Name = "lb_vender";
            this.lb_vender.Size = new System.Drawing.Size(73, 20);
            this.lb_vender.TabIndex = 330;
            this.lb_vender.Text = "生产商：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label10.Location = new System.Drawing.Point(5, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 20);
            this.label10.TabIndex = 333;
            this.label10.Text = "灭菌器价格(元)：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.Location = new System.Drawing.Point(31, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 331;
            this.label11.Text = "灭菌器型号：";
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_barcode.Location = new System.Drawing.Point(79, 12);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(57, 20);
            this.lb_barcode.TabIndex = 332;
            this.lb_barcode.Text = "条码：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(79, 43);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(57, 20);
            this.lb_name.TabIndex = 334;
            this.lb_name.Text = "名称：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(371, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 12);
            this.label14.TabIndex = 326;
            this.label14.Text = "*";
            // 
            // tb_price
            // 
            this.tb_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_price.Location = new System.Drawing.Point(136, 167);
            this.tb_price.MaxLength = 10;
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(229, 25);
            this.tb_price.TabIndex = 5;
            this.tb_price.ThemeName = "Office2007Silver";
            this.tb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_price_KeyPress);
            // 
            // tb_model
            // 
            this.tb_model.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_model.Location = new System.Drawing.Point(136, 136);
            this.tb_model.Name = "tb_model";
            this.tb_model.Size = new System.Drawing.Size(229, 25);
            this.tb_model.TabIndex = 4;
            this.tb_model.ThemeName = "Office2007Silver";
            // 
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_barcode.Location = new System.Drawing.Point(136, 12);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(229, 25);
            this.tb_barcode.TabIndex = 321;
            this.tb_barcode.ThemeName = "Office2007Silver";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(136, 43);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 1;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(371, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 12);
            this.label15.TabIndex = 327;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(371, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 12);
            this.label16.TabIndex = 328;
            this.label16.Text = "*";
            // 
            // tb_stu
            // 
            this.tb_stu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_stu.Location = new System.Drawing.Point(136, 198);
            this.tb_stu.MaxLength = 10;
            this.tb_stu.Name = "tb_stu";
            this.tb_stu.Size = new System.Drawing.Size(229, 25);
            this.tb_stu.TabIndex = 6;
            this.tb_stu.ThemeName = "Office2007Silver";
            this.tb_stu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_stu_KeyPress);
            // 
            // lb_stu
            // 
            this.lb_stu.AutoSize = true;
            this.lb_stu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_stu.Location = new System.Drawing.Point(18, 198);
            this.lb_stu.Name = "lb_stu";
            this.lb_stu.Size = new System.Drawing.Size(118, 20);
            this.lb_stu.TabIndex = 331;
            this.lb_stu.Text = "标准容积(stu)：";
            // 
            // tb_minstu
            // 
            this.tb_minstu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_minstu.Location = new System.Drawing.Point(136, 229);
            this.tb_minstu.MaxLength = 10;
            this.tb_minstu.Name = "tb_minstu";
            this.tb_minstu.Size = new System.Drawing.Size(229, 25);
            this.tb_minstu.TabIndex = 7;
            this.tb_minstu.ThemeName = "Office2007Silver";
            this.tb_minstu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_minstu_KeyPress);
            // 
            // lb_minstu
            // 
            this.lb_minstu.AutoSize = true;
            this.lb_minstu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_minstu.Location = new System.Drawing.Point(18, 229);
            this.lb_minstu.Name = "lb_minstu";
            this.lb_minstu.Size = new System.Drawing.Size(118, 20);
            this.lb_minstu.TabIndex = 331;
            this.lb_minstu.Text = "最低容积(stu)：";
            // 
            // tb_maxstu
            // 
            this.tb_maxstu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_maxstu.Location = new System.Drawing.Point(136, 260);
            this.tb_maxstu.MaxLength = 10;
            this.tb_maxstu.Name = "tb_maxstu";
            this.tb_maxstu.Size = new System.Drawing.Size(229, 25);
            this.tb_maxstu.TabIndex = 8;
            this.tb_maxstu.ThemeName = "Office2007Silver";
            this.tb_maxstu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_maxstu_KeyPress);
            // 
            // lb_maxstu
            // 
            this.lb_maxstu.AutoSize = true;
            this.lb_maxstu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_maxstu.Location = new System.Drawing.Point(18, 260);
            this.lb_maxstu.Name = "lb_maxstu";
            this.lb_maxstu.Size = new System.Drawing.Size(118, 20);
            this.lb_maxstu.TabIndex = 331;
            this.lb_maxstu.Text = "最高容积(stu)：";
            // 
            // HCSCM_sterilizer_device_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(692, 353);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.tb_remarks);
            this.Controls.Add(this.lb_remarks);
            this.Controls.Add(this.cb_sales);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lb_sales);
            this.Controls.Add(this.lb_vender);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_maxstu);
            this.Controls.Add(this.lb_minstu);
            this.Controls.Add(this.lb_stu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_barcode);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_maxstu);
            this.Controls.Add(this.tb_minstu);
            this.Controls.Add(this.tb_stu);
            this.Controls.Add(this.tb_model);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.gp_bd);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_sterilizer_device_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加灭菌器";
            this.gp_bd.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_model)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_stu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_minstu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_maxstu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_bd;
        private System.Windows.Forms.RadioButton rb_bd_no;
        private System.Windows.Forms.RadioButton rb_bd_yes;
        private System.Windows.Forms.DateTimePicker dtp_bd;
        private System.Windows.Forms.Label lb_bd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private Telerik.WinControls.UI.RadDropDownList cb_sales;
        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private System.Windows.Forms.Label lb_sales;
        private System.Windows.Forms.Label lb_vender;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_barcode;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label label14;
        private Telerik.WinControls.UI.RadTextBox tb_price;
        private Telerik.WinControls.UI.RadTextBox tb_model;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Telerik.WinControls.UI.RadTextBox tb_stu;
        private System.Windows.Forms.Label lb_stu;
        private Telerik.WinControls.UI.RadTextBox tb_minstu;
        private System.Windows.Forms.Label lb_minstu;
        private Telerik.WinControls.UI.RadTextBox tb_maxstu;
        private System.Windows.Forms.Label lb_maxstu;
    }
}