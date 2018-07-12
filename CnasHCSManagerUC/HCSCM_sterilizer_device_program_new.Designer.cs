namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_sterilizer_device_program_new
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_sterilizer_device_program_new));
            this.lb_barcode = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_program = new System.Windows.Forms.Label();
            this.lb_remarks = new System.Windows.Forms.Label();
            this.tb_remarks = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.cb_program = new System.Windows.Forms.ComboBox();
            this.but_cancel = new System.Windows.Forms.Button();
            this.but_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_run_time = new System.Windows.Forms.Label();
            this.tb_run_time = new System.Windows.Forms.TextBox();
            this.lb_type = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Location = new System.Drawing.Point(79, 21);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(41, 12);
            this.lb_barcode.TabIndex = 1;
            this.lb_barcode.Text = "条码：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(79, 46);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(41, 12);
            this.lb_name.TabIndex = 2;
            this.lb_name.Text = "名称：";
            // 
            // lb_program
            // 
            this.lb_program.AutoSize = true;
            this.lb_program.Location = new System.Drawing.Point(55, 71);
            this.lb_program.Name = "lb_program";
            this.lb_program.Size = new System.Drawing.Size(65, 12);
            this.lb_program.TabIndex = 3;
            this.lb_program.Text = "灭菌程序：";
            // 
            // lb_remarks
            // 
            this.lb_remarks.AutoSize = true;
            this.lb_remarks.Location = new System.Drawing.Point(55, 149);
            this.lb_remarks.Name = "lb_remarks";
            this.lb_remarks.Size = new System.Drawing.Size(65, 12);
            this.lb_remarks.TabIndex = 4;
            this.lb_remarks.Text = "备注说明：";
            // 
            // tb_remarks
            // 
            this.tb_remarks.BackColor = System.Drawing.Color.White;
            this.tb_remarks.Location = new System.Drawing.Point(126, 146);
            this.tb_remarks.Multiline = true;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(197, 61);
            this.tb_remarks.TabIndex = 5;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(126, 44);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(197, 21);
            this.tb_name.TabIndex = 6;
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(126, 18);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(197, 21);
            this.tb_barcode.TabIndex = 7;
            // 
            // cb_program
            // 
            this.cb_program.BackColor = System.Drawing.Color.Yellow;
            this.cb_program.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_program.FormattingEnabled = true;
            this.cb_program.Location = new System.Drawing.Point(126, 70);
            this.cb_program.Name = "cb_program";
            this.cb_program.Size = new System.Drawing.Size(197, 20);
            this.cb_program.TabIndex = 8;
            // 
            // but_cancel
            // 
            this.but_cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_cancel.Image")));
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(224, 216);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 51;
            this.but_cancel.Text = "取消  ";
            this.but_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Image = ((System.Drawing.Image)(resources.GetObject("but_ok.Image")));
            this.but_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_ok.Location = new System.Drawing.Point(69, 216);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 52;
            this.but_ok.Text = "确定  ";
            this.but_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(329, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 55;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(329, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 56;
            this.label2.Text = "*";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lb_run_time
            // 
            this.lb_run_time.AutoSize = true;
            this.lb_run_time.Location = new System.Drawing.Point(13, 96);
            this.lb_run_time.Name = "lb_run_time";
            this.lb_run_time.Size = new System.Drawing.Size(107, 12);
            this.lb_run_time.TabIndex = 12;
            this.lb_run_time.Text = "运行时间(分钟）：";
            // 
            // tb_run_time
            // 
            this.tb_run_time.Location = new System.Drawing.Point(125, 93);
            this.tb_run_time.Name = "tb_run_time";
            this.tb_run_time.Size = new System.Drawing.Size(198, 21);
            this.tb_run_time.TabIndex = 13;
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Location = new System.Drawing.Point(55, 121);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(65, 12);
            this.lb_type.TabIndex = 14;
            this.lb_type.Text = "灭菌类型：";
            // 
            // cb_type
            // 
            this.cb_type.BackColor = System.Drawing.Color.Yellow;
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(126, 121);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(197, 20);
            this.cb_type.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(329, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(329, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "*";
            // 
            // HCSCM_sterilizer_device_program_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(361, 279);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.tb_run_time);
            this.Controls.Add(this.lb_run_time);
            this.Controls.Add(this.cb_program);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_remarks);
            this.Controls.Add(this.lb_remarks);
            this.Controls.Add(this.lb_program);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_sterilizer_device_program_new";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加灭菌流程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_barcode;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_program;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.ComboBox cb_program;
        protected System.Windows.Forms.TextBox tb_remarks;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_run_time;
        private System.Windows.Forms.TextBox tb_run_time;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}