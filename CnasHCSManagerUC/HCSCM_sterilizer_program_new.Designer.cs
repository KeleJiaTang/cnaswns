namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_sterilizer_program_new
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
			this.label3 = new System.Windows.Forms.Label();
			this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
			this.lb_type = new System.Windows.Forms.Label();
			this.lb_upper_level = new System.Windows.Forms.Label();
			this.lb_lower_level = new System.Windows.Forms.Label();
			this.lb_run_time = new System.Windows.Forms.Label();
			this.lb_barcode = new System.Windows.Forms.Label();
			this.lb_program = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tb_upper_level = new Telerik.WinControls.UI.RadTextBox();
			this.tb_lower_level = new Telerik.WinControls.UI.RadTextBox();
			this.tb_run_time = new Telerik.WinControls.UI.RadTextBox();
			this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
			this.tb_program = new Telerik.WinControls.UI.RadTextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
			this.lb_remarks = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_upper_level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_lower_level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_run_time)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_program)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(391, 170);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 12);
			this.label3.TabIndex = 335;
			this.label3.Text = "*";
			// 
			// cb_type
			// 
			this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_type.Location = new System.Drawing.Point(156, 74);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(229, 25);
			this.cb_type.TabIndex = 2;
			this.cb_type.ThemeName = "Office2007Silver";
			// 
			// lb_type
			// 
			this.lb_type.AutoSize = true;
			this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_type.Location = new System.Drawing.Point(67, 74);
			this.lb_type.Name = "lb_type";
			this.lb_type.Size = new System.Drawing.Size(89, 20);
			this.lb_type.TabIndex = 350;
			this.lb_type.Text = "灭菌类型：";
			// 
			// lb_upper_level
			// 
			this.lb_upper_level.AutoSize = true;
			this.lb_upper_level.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_upper_level.Location = new System.Drawing.Point(67, 136);
			this.lb_upper_level.Name = "lb_upper_level";
			this.lb_upper_level.Size = new System.Drawing.Size(89, 20);
			this.lb_upper_level.TabIndex = 356;
			this.lb_upper_level.Text = "温度上限：";
			// 
			// lb_lower_level
			// 
			this.lb_lower_level.AutoSize = true;
			this.lb_lower_level.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_lower_level.Location = new System.Drawing.Point(67, 167);
			this.lb_lower_level.Name = "lb_lower_level";
			this.lb_lower_level.Size = new System.Drawing.Size(89, 20);
			this.lb_lower_level.TabIndex = 352;
			this.lb_lower_level.Text = "温度下限：";
			// 
			// lb_run_time
			// 
			this.lb_run_time.AutoSize = true;
			this.lb_run_time.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_run_time.Location = new System.Drawing.Point(14, 105);
			this.lb_run_time.Name = "lb_run_time";
			this.lb_run_time.Size = new System.Drawing.Size(142, 20);
			this.lb_run_time.TabIndex = 351;
			this.lb_run_time.Text = "运行时间(分钟）：";
			// 
			// lb_barcode
			// 
			this.lb_barcode.AutoSize = true;
			this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_barcode.Location = new System.Drawing.Point(99, 43);
			this.lb_barcode.Name = "lb_barcode";
			this.lb_barcode.Size = new System.Drawing.Size(57, 20);
			this.lb_barcode.TabIndex = 355;
			this.lb_barcode.Text = "条码：";
			// 
			// lb_program
			// 
			this.lb_program.AutoSize = true;
			this.lb_program.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_program.Location = new System.Drawing.Point(99, 12);
			this.lb_program.Name = "lb_program";
			this.lb_program.Size = new System.Drawing.Size(57, 20);
			this.lb_program.TabIndex = 357;
			this.lb_program.Text = "名称：";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label17.ForeColor = System.Drawing.Color.Red;
			this.label17.Location = new System.Drawing.Point(391, 139);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 12);
			this.label17.TabIndex = 346;
			this.label17.Text = "*";
			// 
			// tb_upper_level
			// 
			this.tb_upper_level.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_upper_level.Location = new System.Drawing.Point(156, 136);
			this.tb_upper_level.MaxLength = 10;
			this.tb_upper_level.Name = "tb_upper_level";
			this.tb_upper_level.Size = new System.Drawing.Size(229, 25);
			this.tb_upper_level.TabIndex = 4;
			this.tb_upper_level.ThemeName = "Office2007Silver";
			this.tb_upper_level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_upper_level_KeyPress);
			// 
			// tb_lower_level
			// 
			this.tb_lower_level.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_lower_level.Location = new System.Drawing.Point(156, 167);
			this.tb_lower_level.MaxLength = 10;
			this.tb_lower_level.Name = "tb_lower_level";
			this.tb_lower_level.Size = new System.Drawing.Size(229, 25);
			this.tb_lower_level.TabIndex = 5;
			this.tb_lower_level.ThemeName = "Office2007Silver";
			this.tb_lower_level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_lower_level_KeyPress);
			// 
			// tb_run_time
			// 
			this.tb_run_time.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_run_time.Location = new System.Drawing.Point(156, 105);
			this.tb_run_time.MaxLength = 10;
			this.tb_run_time.Name = "tb_run_time";
			this.tb_run_time.Size = new System.Drawing.Size(229, 25);
			this.tb_run_time.TabIndex = 3;
			this.tb_run_time.ThemeName = "Office2007Silver";
			this.tb_run_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_run_time_KeyPress);
			// 
			// tb_barcode
			// 
			this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_barcode.Location = new System.Drawing.Point(156, 43);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.ReadOnly = true;
			this.tb_barcode.Size = new System.Drawing.Size(229, 25);
			this.tb_barcode.TabIndex = 337;
			this.tb_barcode.ThemeName = "Office2007Silver";
			// 
			// tb_program
			// 
			this.tb_program.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_program.Location = new System.Drawing.Point(156, 12);
			this.tb_program.Name = "tb_program";
			this.tb_program.Size = new System.Drawing.Size(229, 25);
			this.tb_program.TabIndex = 1;
			this.tb_program.ThemeName = "Office2007Silver";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label15.ForeColor = System.Drawing.Color.Red;
			this.label15.Location = new System.Drawing.Point(391, 20);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(12, 12);
			this.label15.TabIndex = 347;
			this.label15.Text = "*";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label16.ForeColor = System.Drawing.Color.Red;
			this.label16.Location = new System.Drawing.Point(391, 78);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 12);
			this.label16.TabIndex = 348;
			this.label16.Text = "*";
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(289, 291);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 8;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(156, 291);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 7;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_OK_Click_1);
			// 
			// tb_remarks
			// 
			this.tb_remarks.AcceptsReturn = true;
			this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_remarks.Location = new System.Drawing.Point(156, 198);
			this.tb_remarks.Multiline = true;
			this.tb_remarks.Name = "tb_remarks";
			this.tb_remarks.Size = new System.Drawing.Size(229, 81);
			this.tb_remarks.TabIndex = 6;
			this.tb_remarks.ThemeName = "Office2007Silver";
			// 
			// lb_remarks
			// 
			this.lb_remarks.AutoSize = true;
			this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_remarks.Location = new System.Drawing.Point(67, 198);
			this.lb_remarks.Name = "lb_remarks";
			this.lb_remarks.Size = new System.Drawing.Size(89, 20);
			this.lb_remarks.TabIndex = 361;
			this.lb_remarks.Text = "备注说明：";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(391, 108);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 12);
			this.label9.TabIndex = 346;
			this.label9.Text = "*";
			// 
			// HCSCM_sterilizer_program_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(420, 342);
			this.Controls.Add(this.tb_remarks);
			this.Controls.Add(this.lb_remarks);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cb_type);
			this.Controls.Add(this.lb_type);
			this.Controls.Add(this.lb_upper_level);
			this.Controls.Add(this.lb_lower_level);
			this.Controls.Add(this.lb_run_time);
			this.Controls.Add(this.lb_barcode);
			this.Controls.Add(this.lb_program);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.tb_upper_level);
			this.Controls.Add(this.tb_lower_level);
			this.Controls.Add(this.tb_run_time);
			this.Controls.Add(this.tb_barcode);
			this.Controls.Add(this.tb_program);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label16);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_sterilizer_program_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加灭菌程序";
			this.Load += new System.EventHandler(this.HCSCM_sterilizer_program_new_Load);
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_upper_level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_lower_level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_run_time)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_program)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_upper_level;
        private System.Windows.Forms.Label lb_lower_level;
        private System.Windows.Forms.Label lb_run_time;
        private System.Windows.Forms.Label lb_barcode;
        private System.Windows.Forms.Label lb_program;
        private System.Windows.Forms.Label label17;
        private Telerik.WinControls.UI.RadTextBox tb_upper_level;
        private Telerik.WinControls.UI.RadTextBox tb_lower_level;
        private Telerik.WinControls.UI.RadTextBox tb_run_time;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_program;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.Label label9;
    }
}