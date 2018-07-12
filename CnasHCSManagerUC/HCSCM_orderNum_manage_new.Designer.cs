namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_orderNum_manage_new
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
            this.rb_BCCO1 = new System.Windows.Forms.RadioButton();
            this.rb_BCCO2 = new System.Windows.Forms.RadioButton();
            this.rb_BCCO4 = new System.Windows.Forms.RadioButton();
            this.rb_BCCO3 = new System.Windows.Forms.RadioButton();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.tb_remarks = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lb_remarks = new System.Windows.Forms.Label();
            this.lb_ifDelivery_note = new System.Windows.Forms.Label();
            this.lb_customer = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_location = new System.Windows.Forms.Label();
            this.cb_location = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_location)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rb_BCCO1
            // 
            this.rb_BCCO1.BackColor = System.Drawing.Color.AliceBlue;
            this.rb_BCCO1.Checked = true;
            this.rb_BCCO1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_BCCO1.Location = new System.Drawing.Point(105, 105);
            this.rb_BCCO1.Name = "rb_BCCO1";
            this.rb_BCCO1.Size = new System.Drawing.Size(229, 23);
            this.rb_BCCO1.TabIndex = 279;
            this.rb_BCCO1.TabStop = true;
            this.rb_BCCO1.Text = "送货单（BCC01）";
            this.rb_BCCO1.UseVisualStyleBackColor = false;
            // 
            // rb_BCCO2
            // 
            this.rb_BCCO2.BackColor = System.Drawing.Color.OldLace;
            this.rb_BCCO2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_BCCO2.Location = new System.Drawing.Point(105, 136);
            this.rb_BCCO2.Name = "rb_BCCO2";
            this.rb_BCCO2.Size = new System.Drawing.Size(229, 23);
            this.rb_BCCO2.TabIndex = 280;
            this.rb_BCCO2.Text = "送货取货单（BCC02）";
            this.rb_BCCO2.UseVisualStyleBackColor = false;
            // 
            // rb_BCCO4
            // 
            this.rb_BCCO4.BackColor = System.Drawing.Color.OldLace;
            this.rb_BCCO4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_BCCO4.Location = new System.Drawing.Point(105, 168);
            this.rb_BCCO4.Name = "rb_BCCO4";
            this.rb_BCCO4.Size = new System.Drawing.Size(229, 23);
            this.rb_BCCO4.TabIndex = 280;
            this.rb_BCCO4.Text = "送货取货单（BCC04）";
            this.rb_BCCO4.UseVisualStyleBackColor = false;
            // 
            // rb_BCCO3
            // 
            this.rb_BCCO3.BackColor = System.Drawing.Color.AliceBlue;
            this.rb_BCCO3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rb_BCCO3.Location = new System.Drawing.Point(105, 198);
            this.rb_BCCO3.Name = "rb_BCCO3";
            this.rb_BCCO3.Size = new System.Drawing.Size(229, 23);
            this.rb_BCCO3.TabIndex = 279;
            this.rb_BCCO3.Text = "送货单（BCC03）";
            this.rb_BCCO3.UseVisualStyleBackColor = false;
            // 
            // cb_customer
            // 
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(105, 43);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(229, 25);
            this.cb_customer.TabIndex = 289;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(235, 323);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 296;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(105, 323);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 295;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // tb_remarks
            // 
            this.tb_remarks.AcceptsReturn = true;
            this.tb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_remarks.Location = new System.Drawing.Point(105, 229);
            this.tb_remarks.Multiline = true;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(229, 82);
            this.tb_remarks.TabIndex = 294;
            this.tb_remarks.ThemeName = "Office2007Silver";
            // 
            // lb_remarks
            // 
            this.lb_remarks.AutoSize = true;
            this.lb_remarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_remarks.Location = new System.Drawing.Point(10, 229);
            this.lb_remarks.Name = "lb_remarks";
            this.lb_remarks.Size = new System.Drawing.Size(89, 20);
            this.lb_remarks.TabIndex = 299;
            this.lb_remarks.Text = "备注说明：";
            // 
            // lb_ifDelivery_note
            // 
            this.lb_ifDelivery_note.AutoSize = true;
            this.lb_ifDelivery_note.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_ifDelivery_note.Location = new System.Drawing.Point(10, 105);
            this.lb_ifDelivery_note.Name = "lb_ifDelivery_note";
            this.lb_ifDelivery_note.Size = new System.Drawing.Size(89, 20);
            this.lb_ifDelivery_note.TabIndex = 300;
            this.lb_ifDelivery_note.Text = "条码类型：";
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(42, 43);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(57, 20);
            this.lb_customer.TabIndex = 304;
            this.lb_customer.Text = "客户：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(42, 12);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(57, 20);
            this.lb_name.TabIndex = 305;
            this.lb_name.Text = "名称：";
            // 
            // tb_name
            // 
            this.tb_name.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(105, 12);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 288;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(340, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 297;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(340, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 297;
            this.label1.Text = "*";
            // 
            // lb_location
            // 
            this.lb_location.AutoSize = true;
            this.lb_location.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_location.Location = new System.Drawing.Point(10, 74);
            this.lb_location.Name = "lb_location";
            this.lb_location.Size = new System.Drawing.Size(89, 20);
            this.lb_location.TabIndex = 304;
            this.lb_location.Text = "使用地点：";
            // 
            // cb_location
            // 
            this.cb_location.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_location.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_location.Location = new System.Drawing.Point(105, 74);
            this.cb_location.Name = "cb_location";
            this.cb_location.Size = new System.Drawing.Size(229, 25);
            this.cb_location.TabIndex = 289;
            this.cb_location.ThemeName = "Office2007Silver";
            // 
            // HCSCM_orderNum_manage_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(367, 374);
            this.Controls.Add(this.cb_location);
            this.Controls.Add(this.cb_customer);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.tb_remarks);
            this.Controls.Add(this.lb_remarks);
            this.Controls.Add(this.lb_location);
            this.Controls.Add(this.lb_ifDelivery_note);
            this.Controls.Add(this.lb_customer);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rb_BCCO3);
            this.Controls.Add(this.rb_BCCO4);
            this.Controls.Add(this.rb_BCCO1);
            this.Controls.Add(this.rb_BCCO2);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_orderNum_manage_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建订单号";
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_location)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_BCCO1;
        private System.Windows.Forms.RadioButton rb_BCCO2;
        private System.Windows.Forms.RadioButton rb_BCCO4;
        private System.Windows.Forms.RadioButton rb_BCCO3;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadTextBoxControl tb_remarks;
        private System.Windows.Forms.Label lb_remarks;
        private System.Windows.Forms.Label lb_ifDelivery_note;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label lb_name;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_location;
        private Telerik.WinControls.UI.RadDropDownList cb_location;
    }
}