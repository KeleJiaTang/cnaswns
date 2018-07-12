namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_instrument_manage_new
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
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.lb_sn = new System.Windows.Forms.Label();
			this.lb_rfid = new System.Windows.Forms.Label();
			this.lb_ins = new System.Windows.Forms.Label();
			this.tb_sn = new Telerik.WinControls.UI.RadTextBox();
			this.tb_rfid = new Telerik.WinControls.UI.RadTextBox();
			this.tb_name = new Telerik.WinControls.UI.RadTextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_sn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_rfid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(244, 112);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 290;
			this.but_cancel.Text = "        关闭";
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click_1);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(114, 112);
			this.but_ok.Name = "but_ok";
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 289;
			this.but_ok.Text = "           确定";
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click_1);
			// 
			// lb_sn
			// 
			this.lb_sn.AutoSize = true;
			this.lb_sn.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_sn.Location = new System.Drawing.Point(54, 41);
			this.lb_sn.Name = "lb_sn";
			this.lb_sn.Size = new System.Drawing.Size(60, 20);
			this.lb_sn.TabIndex = 293;
			this.lb_sn.Text = "SN码：";
			// 
			// lb_rfid
			// 
			this.lb_rfid.AutoSize = true;
			this.lb_rfid.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_rfid.Location = new System.Drawing.Point(26, 73);
			this.lb_rfid.Name = "lb_rfid";
			this.lb_rfid.Size = new System.Drawing.Size(88, 20);
			this.lb_rfid.TabIndex = 294;
			this.lb_rfid.Text = "器械RFID：";
			// 
			// lb_ins
			// 
			this.lb_ins.AutoSize = true;
			this.lb_ins.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_ins.Location = new System.Drawing.Point(25, 12);
			this.lb_ins.Name = "lb_ins";
			this.lb_ins.Size = new System.Drawing.Size(89, 20);
			this.lb_ins.TabIndex = 295;
			this.lb_ins.Text = "器械名称：";
			// 
			// tb_sn
			// 
			this.tb_sn.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_sn.Location = new System.Drawing.Point(114, 41);
			this.tb_sn.Name = "tb_sn";
			this.tb_sn.ReadOnly = true;
			this.tb_sn.Size = new System.Drawing.Size(229, 25);
			this.tb_sn.TabIndex = 286;
			this.tb_sn.ThemeName = "Office2007Silver";
			// 
			// tb_rfid
			// 
			this.tb_rfid.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_rfid.Location = new System.Drawing.Point(114, 71);
			this.tb_rfid.Name = "tb_rfid";
			this.tb_rfid.Size = new System.Drawing.Size(229, 25);
			this.tb_rfid.TabIndex = 287;
			this.tb_rfid.ThemeName = "Office2007Silver";
			// 
			// tb_name
			// 
			this.tb_name.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_name.Location = new System.Drawing.Point(114, 12);
			this.tb_name.Name = "tb_name";
			this.tb_name.ReadOnly = true;
			this.tb_name.Size = new System.Drawing.Size(229, 25);
			this.tb_name.TabIndex = 285;
			this.tb_name.ThemeName = "Office2007Silver";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(349, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 12);
			this.label4.TabIndex = 291;
			this.label4.Text = "*";
			// 
			// HCSCM_instrument_manage_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(371, 165);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.lb_sn);
			this.Controls.Add(this.lb_rfid);
			this.Controls.Add(this.lb_ins);
			this.Controls.Add(this.tb_sn);
			this.Controls.Add(this.tb_rfid);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_instrument_manage_new";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "新建器械";
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_sn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_rfid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private System.Windows.Forms.Label lb_sn;
        private System.Windows.Forms.Label lb_rfid;
        private System.Windows.Forms.Label lb_ins;
        private Telerik.WinControls.UI.RadTextBox tb_sn;
        private Telerik.WinControls.UI.RadTextBox tb_rfid;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label4;
    }
}