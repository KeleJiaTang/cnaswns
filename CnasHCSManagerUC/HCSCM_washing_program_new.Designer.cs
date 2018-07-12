namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_washing_program_new
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
			this.lb_type = new System.Windows.Forms.Label();
			this.lb_barcode = new System.Windows.Forms.Label();
			this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tb_name = new Telerik.WinControls.UI.RadTextBox();
			this.lb_name = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_run_time = new Telerik.WinControls.UI.RadTextBox();
			this.lb_run_time = new System.Windows.Forms.Label();
			this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
			this.lb_remarks = new System.Windows.Forms.Label();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_run_time)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_type
			// 
			this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_type.Location = new System.Drawing.Point(169, 74);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(229, 25);
			this.cb_type.TabIndex = 2;
			this.cb_type.ThemeName = "Office2007Silver";
			// 
			// lb_type
			// 
			this.lb_type.AutoSize = true;
			this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_type.Location = new System.Drawing.Point(74, 74);
			this.lb_type.Name = "lb_type";
			this.lb_type.Size = new System.Drawing.Size(89, 20);
			this.lb_type.TabIndex = 359;
			this.lb_type.Text = "清洗类型：";
			// 
			// lb_barcode
			// 
			this.lb_barcode.AutoSize = true;
			this.lb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_barcode.Location = new System.Drawing.Point(106, 12);
			this.lb_barcode.Name = "lb_barcode";
			this.lb_barcode.Size = new System.Drawing.Size(57, 20);
			this.lb_barcode.TabIndex = 360;
			this.lb_barcode.Text = "条码：";
			// 
			// tb_barcode
			// 
			this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_barcode.Location = new System.Drawing.Point(169, 12);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.Size = new System.Drawing.Size(229, 25);
			this.tb_barcode.TabIndex = 356;
			this.tb_barcode.ThemeName = "Office2007Silver";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label16.ForeColor = System.Drawing.Color.Red;
			this.label16.Location = new System.Drawing.Point(400, 51);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 12);
			this.label16.TabIndex = 358;
			this.label16.Text = "*";
			// 
			// tb_name
			// 
			this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_name.Location = new System.Drawing.Point(169, 43);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(229, 25);
			this.tb_name.TabIndex = 1;
			this.tb_name.ThemeName = "Office2007Silver";
			// 
			// lb_name
			// 
			this.lb_name.AutoSize = true;
			this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_name.Location = new System.Drawing.Point(42, 43);
			this.lb_name.Name = "lb_name";
			this.lb_name.Size = new System.Drawing.Size(121, 20);
			this.lb_name.TabIndex = 360;
			this.lb_name.Text = "清洗程序名称：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(400, 109);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 12);
			this.label7.TabIndex = 358;
			this.label7.Text = "*";
			// 
			// tb_run_time
			// 
			this.tb_run_time.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_run_time.Location = new System.Drawing.Point(169, 105);
			this.tb_run_time.MaxLength = 3;
			this.tb_run_time.Name = "tb_run_time";
			this.tb_run_time.Size = new System.Drawing.Size(229, 25);
			this.tb_run_time.TabIndex = 3;
			this.tb_run_time.ThemeName = "Office2007Silver";
			this.tb_run_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_run_time_KeyPress);
			// 
			// lb_run_time
			// 
			this.lb_run_time.AutoSize = true;
			this.lb_run_time.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_run_time.Location = new System.Drawing.Point(10, 105);
			this.lb_run_time.Name = "lb_run_time";
			this.lb_run_time.Size = new System.Drawing.Size(153, 20);
			this.lb_run_time.TabIndex = 360;
			this.lb_run_time.Text = "运行时间（分钟）：";
			// 
			// tb_remarks
			// 
			this.tb_remarks.AcceptsReturn = true;
			this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_remarks.Location = new System.Drawing.Point(169, 136);
			this.tb_remarks.Multiline = true;
			this.tb_remarks.Name = "tb_remarks";
			this.tb_remarks.Size = new System.Drawing.Size(229, 87);
			this.tb_remarks.TabIndex = 4;
			this.tb_remarks.ThemeName = "Office2007Silver";
			// 
			// lb_remarks
			// 
			this.lb_remarks.AutoSize = true;
			this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_remarks.Location = new System.Drawing.Point(74, 136);
			this.lb_remarks.Name = "lb_remarks";
			this.lb_remarks.Size = new System.Drawing.Size(89, 20);
			this.lb_remarks.TabIndex = 362;
			this.lb_remarks.Text = "备注说明：";
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(299, 236);
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
			this.but_ok.Location = new System.Drawing.Point(169, 236);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 5;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(400, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 12);
			this.label1.TabIndex = 358;
			this.label1.Text = "*";
			// 
			// HCSCM_washing_program_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(424, 289);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.tb_remarks);
			this.Controls.Add(this.lb_remarks);
			this.Controls.Add(this.cb_type);
			this.Controls.Add(this.lb_type);
			this.Controls.Add(this.lb_run_time);
			this.Controls.Add(this.lb_name);
			this.Controls.Add(this.lb_barcode);
			this.Controls.Add(this.tb_run_time);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tb_barcode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label16);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_washing_program_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "新增清洗程序";
			((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_run_time)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_barcode;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private System.Windows.Forms.Label label16;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadTextBox tb_run_time;
        private System.Windows.Forms.Label lb_run_time;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private System.Windows.Forms.Label label1;
    }
}