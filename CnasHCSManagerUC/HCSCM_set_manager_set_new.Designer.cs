namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_set_new
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.but_sel = new Telerik.WinControls.UI.RadButton();
            this.tb_sname = new Telerik.WinControls.UI.RadTextBox();
            this.lb_sname = new Telerik.WinControls.UI.RadLabel();
            this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_type = new Telerik.WinControls.UI.RadLabel();
            this.lb_customer = new Telerik.WinControls.UI.RadLabel();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_select = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_sname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.cb_customer);
            this.splitContainer1.Panel1.Controls.Add(this.but_sel);
            this.splitContainer1.Panel1.Controls.Add(this.tb_sname);
            this.splitContainer1.Panel1.Controls.Add(this.lb_sname);
            this.splitContainer1.Panel1.Controls.Add(this.cb_type);
            this.splitContainer1.Panel1.Controls.Add(this.lb_type);
            this.splitContainer1.Panel1.Controls.Add(this.lb_customer);
            this.splitContainer1.Panel1.Controls.Add(this.but_cancel);
            this.splitContainer1.Panel1.Controls.Add(this.but_select);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(690, 367);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 0;
            // 
            // cb_customer
            // 
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(117, 12);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(243, 25);
            this.cb_customer.TabIndex = 350;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
            // 
            // but_sel
            // 
            this.but_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_sel.Location = new System.Drawing.Point(308, 90);
            this.but_sel.Name = "but_sel";
            this.but_sel.Size = new System.Drawing.Size(52, 26);
            this.but_sel.TabIndex = 353;
            this.but_sel.Text = "查询";
            this.but_sel.ThemeName = "Office2007Silver";
            this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
            // 
            // tb_sname
            // 
            this.tb_sname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_sname.Location = new System.Drawing.Point(117, 91);
            this.tb_sname.Name = "tb_sname";
            this.tb_sname.Size = new System.Drawing.Size(185, 25);
            this.tb_sname.TabIndex = 352;
            this.tb_sname.ThemeName = "Office2007Silver";
            this.tb_sname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
            // 
            // lb_sname
            // 
            this.lb_sname.Font = new System.Drawing.Font("宋体", 11F);
            this.lb_sname.Location = new System.Drawing.Point(117, 72);
            this.lb_sname.Name = "lb_sname";
            this.lb_sname.Size = new System.Drawing.Size(158, 21);
            this.lb_sname.TabIndex = 351;
            this.lb_sname.Text = "搜索内容(条码、名称)";
            this.lb_sname.ThemeName = "Office2007Silver";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_type.Location = new System.Drawing.Point(117, 43);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(243, 25);
            this.cb_type.TabIndex = 350;
            this.cb_type.ThemeName = "Office2007Silver";
            this.cb_type.TextChanged += new System.EventHandler(this.cb_type_TextChanged);
            // 
            // lb_type
            // 
            this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_type.Location = new System.Drawing.Point(10, 42);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(102, 23);
            this.lb_type.TabIndex = 349;
            this.lb_type.Text = "基本包类型：";
            // 
            // lb_customer
            // 
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(25, 12);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(86, 23);
            this.lb_customer.TabIndex = 349;
            this.lb_customer.Text = "所属客户：";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(579, 12);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 347;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_select
            // 
            this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_select.Location = new System.Drawing.Point(464, 12);
            this.but_select.Name = "but_select";
            this.but_select.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_select.Size = new System.Drawing.Size(99, 42);
            this.but_select.TabIndex = 348;
            this.but_select.Text = "选  择";
            this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_select.ThemeName = "Office2007Silver";
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.HeaderText = "条码";
            gridViewTextBoxColumn2.Name = "bar_code";
            gridViewTextBoxColumn2.Width = 151;
            gridViewTextBoxColumn3.HeaderText = "基本包名称";
            gridViewTextBoxColumn3.Name = "ca_name";
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.HeaderText = "成本中心";
            gridViewTextBoxColumn4.Name = "cost_center";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.HeaderText = "优先级";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "ca_priority";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.HeaderText = "RFID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "rfid_retrospect";
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(690, 243);
            this.dgv_01.TabIndex = 3;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_set_manager_set_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 367);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_set_manager_set_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择基本包";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_sname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private Telerik.WinControls.UI.RadLabel lb_type;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadLabel lb_customer;
        private Telerik.WinControls.UI.RadButton but_sel;
        private Telerik.WinControls.UI.RadTextBox tb_sname;
        private Telerik.WinControls.UI.RadLabel lb_sname;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}