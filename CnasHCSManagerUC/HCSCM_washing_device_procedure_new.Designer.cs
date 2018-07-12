namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_washing_device_procedure_new
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_washing_device_procedure_new));
            this.lb_barcode = new System.Windows.Forms.Label();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lb_program = new System.Windows.Forms.Label();
            this.cb_program = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.but_ok = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_barcode
            // 
            this.lb_barcode.AutoSize = true;
            this.lb_barcode.Location = new System.Drawing.Point(73, 20);
            this.lb_barcode.Name = "lb_barcode";
            this.lb_barcode.Size = new System.Drawing.Size(41, 12);
            this.lb_barcode.TabIndex = 71;
            this.lb_barcode.Text = "条码：";
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(112, 18);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(243, 21);
            this.tb_barcode.TabIndex = 72;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(28, 46);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(89, 12);
            this.lb_name.TabIndex = 71;
            this.lb_name.Text = "清洗流程名称：";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(112, 44);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(243, 21);
            this.tb_name.TabIndex = 72;
            // 
            // lb_program
            // 
            this.lb_program.AutoSize = true;
            this.lb_program.Location = new System.Drawing.Point(50, 73);
            this.lb_program.Name = "lb_program";
            this.lb_program.Size = new System.Drawing.Size(65, 12);
            this.lb_program.TabIndex = 71;
            this.lb_program.Text = "清洗程序：";
            // 
            // cb_program
            // 
            this.cb_program.BackColor = System.Drawing.Color.Yellow;
            this.cb_program.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_program.FormattingEnabled = true;
            this.cb_program.Location = new System.Drawing.Point(112, 70);
            this.cb_program.Name = "cb_program";
            this.cb_program.Size = new System.Drawing.Size(243, 20);
            this.cb_program.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(360, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 269;
            this.label3.Text = "*";
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_ok.Image = ((System.Drawing.Image)(resources.GetObject("but_ok.Image")));
            this.but_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_ok.Location = new System.Drawing.Point(111, 112);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 74;
            this.but_ok.Text = "   确定";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_cancel.Image")));
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(237, 112);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 75;
            this.but_cancel.Text = "   关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // HCSCM_washing_device_procedure_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(376, 166);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.cb_program);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lb_program);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.lb_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_washing_device_procedure_new";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加清洗流程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_barcode;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lb_program;
        private System.Windows.Forms.ComboBox cb_program;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_cancel;

    }
}