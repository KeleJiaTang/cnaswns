namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manage_item_number
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
			this.lb_number = new System.Windows.Forms.Label();
			this.tb_number = new Telerik.WinControls.UI.RadTextBox();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.tb_number)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_number
			// 
			this.lb_number.AutoSize = true;
			this.lb_number.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_number.Location = new System.Drawing.Point(20, 26);
			this.lb_number.Name = "lb_number";
			this.lb_number.Size = new System.Drawing.Size(89, 20);
			this.lb_number.TabIndex = 321;
			this.lb_number.Text = "器械数量：";
			// 
			// tb_number
			// 
			this.tb_number.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_number.Location = new System.Drawing.Point(117, 24);
			this.tb_number.MaxLength = 10;
			this.tb_number.Name = "tb_number";
			this.tb_number.Size = new System.Drawing.Size(304, 25);
			this.tb_number.TabIndex = 1;
			this.tb_number.ThemeName = "Office2007Silver";
			this.tb_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_number_KeyPress);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(455, 12);
			this.but_ok.Name = "but_ok";
			this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 2;
			this.but_ok.Text = "确  定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// HCSCM_set_manage_item_number
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(566, 61);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.lb_number);
			this.Controls.Add(this.tb_number);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_set_manage_item_number";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "填写器械数量";
			((System.ComponentModel.ISupportInitialize)(this.tb_number)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_number;
        private Telerik.WinControls.UI.RadTextBox tb_number;
        private Telerik.WinControls.UI.RadButton but_ok;
    }
}