namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_department_equipment_manager_edit
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
            this.label16 = new System.Windows.Forms.Label();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_customer = new Telerik.WinControls.UI.RadLabel();
            this.cb_cost_center = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_total = new Telerik.WinControls.UI.RadLabel();
            this.lb_costcenter = new Telerik.WinControls.UI.RadLabel();
            this.tb_currentCount = new Telerik.WinControls.UI.RadTextBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_cost_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_costcenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(328, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 12);
            this.label16.TabIndex = 349;
            this.label16.Text = "*";
            // 
            // cb_customer
            // 
            this.cb_customer.DisplayMember = "Text";
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(112, 12);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(214, 25);
            this.cb_customer.TabIndex = 1;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.ValueMember = "Value";
            this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
            // 
            // lb_customer
            // 
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(25, 12);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(86, 23);
            this.lb_customer.TabIndex = 43;
            this.lb_customer.Text = "所属客户：";
            // 
            // cb_cost_center
            // 
            this.cb_cost_center.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_cost_center.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_cost_center.Location = new System.Drawing.Point(112, 43);
            this.cb_cost_center.Name = "cb_cost_center";
            this.cb_cost_center.Size = new System.Drawing.Size(214, 25);
            this.cb_cost_center.TabIndex = 2;
            this.cb_cost_center.ThemeName = "Office2007Silver";
            // 
            // lb_total
            // 
            this.lb_total.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_total.Location = new System.Drawing.Point(41, 75);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(71, 23);
            this.lb_total.TabIndex = 351;
            this.lb_total.Text = "库存量：";
            this.lb_total.ThemeName = "Office2007Silver";
            // 
            // lb_costcenter
            // 
            this.lb_costcenter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_costcenter.Location = new System.Drawing.Point(26, 46);
            this.lb_costcenter.Name = "lb_costcenter";
            this.lb_costcenter.Size = new System.Drawing.Size(86, 23);
            this.lb_costcenter.TabIndex = 61;
            this.lb_costcenter.Text = "成本中心：";
            // 
            // tb_currentCount
            // 
            this.tb_currentCount.BackColor = System.Drawing.SystemColors.Window;
            this.tb_currentCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_currentCount.Location = new System.Drawing.Point(112, 74);
            this.tb_currentCount.MaxLength = 4;
            this.tb_currentCount.Name = "tb_currentCount";
            this.tb_currentCount.Size = new System.Drawing.Size(214, 25);
            this.tb_currentCount.TabIndex = 3;
            this.tb_currentCount.ThemeName = "Office2007Silver";
            this.tb_currentCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_total_KeyPress);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(225, 117);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 5;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(112, 117);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 4;
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
            this.label1.Location = new System.Drawing.Point(328, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 349;
            this.label1.Text = "*";
            // 
            // HCSCM_department_equipment_manager_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(355, 184);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cb_customer);
            this.Controls.Add(this.lb_customer);
            this.Controls.Add(this.cb_cost_center);
            this.Controls.Add(this.lb_total);
            this.Controls.Add(this.lb_costcenter);
            this.Controls.Add(this.tb_currentCount);
            this.Name = "HCSCM_department_equipment_manager_edit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_department_equipment_manager_edit";
            this.Load += new System.EventHandler(this.LoadFromEnent);
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_cost_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_costcenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cb_cost_center;
        private Telerik.WinControls.UI.RadLabel lb_costcenter;
        private System.Windows.Forms.Label label16;
        private Telerik.WinControls.UI.RadLabel lb_total;
        private Telerik.WinControls.UI.RadTextBox tb_currentCount;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadLabel lb_customer;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private System.Windows.Forms.Label label1;
    }
}