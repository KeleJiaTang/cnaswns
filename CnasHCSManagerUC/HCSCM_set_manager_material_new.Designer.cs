namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_material_new
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_expiration_day = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_expiration_day = new Telerik.WinControls.UI.RadTextBox();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_expiration_day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(340, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 267;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(340, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 268;
            this.label2.Text = "*";
            // 
            // lb_expiration_day
            // 
            this.lb_expiration_day.AutoSize = true;
            this.lb_expiration_day.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_expiration_day.Location = new System.Drawing.Point(10, 45);
            this.lb_expiration_day.Name = "lb_expiration_day";
            this.lb_expiration_day.Size = new System.Drawing.Size(89, 20);
            this.lb_expiration_day.TabIndex = 322;
            this.lb_expiration_day.Text = "保质天数：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(10, 14);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(89, 20);
            this.lb_name.TabIndex = 323;
            this.lb_name.Text = "包装材料：";
            // 
            // tb_expiration_day
            // 
            this.tb_expiration_day.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_expiration_day.Location = new System.Drawing.Point(105, 43);
            this.tb_expiration_day.Name = "tb_expiration_day";
            this.tb_expiration_day.Size = new System.Drawing.Size(229, 25);
            this.tb_expiration_day.TabIndex = 2;
            this.tb_expiration_day.ThemeName = "Office2007Silver";
            this.tb_expiration_day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_expiration_day_KeyPress_1);
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(105, 12);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 1;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(235, 77);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 4;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(105, 77);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 3;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // HCSCM_set_manager_material_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(362, 128);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.lb_expiration_day);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.tb_expiration_day);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_set_manager_material_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加包装材料";
            ((System.ComponentModel.ISupportInitialize)(this.tb_expiration_day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_expiration_day;
        private System.Windows.Forms.Label lb_name;
        private Telerik.WinControls.UI.RadTextBox tb_expiration_day;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
    }
}