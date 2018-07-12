namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_cycle
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.but_sel = new Telerik.WinControls.UI.RadButton();
            this.tb_sel = new Telerik.WinControls.UI.RadTextBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.lb_sname = new Telerik.WinControls.UI.RadLabel();
            this.but_putcycle = new Telerik.WinControls.UI.RadButton();
            this.but_incycle = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_new = new System.Windows.Forms.CheckBox();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_sname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_putcycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_incycle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.sp_main.Panel1.Controls.Add(this.but_sel);
            this.sp_main.Panel1.Controls.Add(this.tb_sel);
            this.sp_main.Panel1.Controls.Add(this.but_cancel);
            this.sp_main.Panel1.Controls.Add(this.lb_sname);
            this.sp_main.Panel1.Controls.Add(this.but_putcycle);
            this.sp_main.Panel1.Controls.Add(this.but_incycle);
            this.sp_main.Panel1.Controls.Add(this.groupBox1);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(792, 567);
            this.sp_main.SplitterDistance = 117;
            this.sp_main.TabIndex = 0;
            // 
            // but_sel
            // 
            this.but_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_sel.Location = new System.Drawing.Point(261, 75);
            this.but_sel.Name = "but_sel";
            this.but_sel.Size = new System.Drawing.Size(52, 26);
            this.but_sel.TabIndex = 68;
            this.but_sel.Text = "查询";
            this.but_sel.ThemeName = "Office2007Silver";
            this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
            // 
            // tb_sel
            // 
            this.tb_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_sel.Location = new System.Drawing.Point(12, 75);
            this.tb_sel.Name = "tb_sel";
            this.tb_sel.Size = new System.Drawing.Size(243, 25);
            this.tb_sel.TabIndex = 67;
            this.tb_sel.ThemeName = "Office2007Silver";
            this.tb_sel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
            this.tb_sel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sname_KeyDown);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(681, 12);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 353;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // lb_sname
            // 
            this.lb_sname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_sname.Location = new System.Drawing.Point(12, 31);
            this.lb_sname.Name = "lb_sname";
            this.lb_sname.Size = new System.Drawing.Size(159, 23);
            this.lb_sname.TabIndex = 66;
            this.lb_sname.Text = "搜索内容(条码、名称)";
            this.lb_sname.ThemeName = "Office2007Silver";
            // 
            // but_putcycle
            // 
            this.but_putcycle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_putcycle.Location = new System.Drawing.Point(575, 12);
            this.but_putcycle.Name = "but_putcycle";
            this.but_putcycle.Size = new System.Drawing.Size(99, 42);
            this.but_putcycle.TabIndex = 353;
            this.but_putcycle.Text = "出循环";
            this.but_putcycle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_putcycle.ThemeName = "Office2007Silver";
            this.but_putcycle.Click += new System.EventHandler(this.but_putcycle_Click);
            // 
            // but_incycle
            // 
            this.but_incycle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_incycle.Location = new System.Drawing.Point(468, 12);
            this.but_incycle.Name = "but_incycle";
            this.but_incycle.Size = new System.Drawing.Size(99, 42);
            this.but_incycle.TabIndex = 352;
            this.but_incycle.Text = "进循环";
            this.but_incycle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_incycle.ThemeName = "Office2007Silver";
            this.but_incycle.Click += new System.EventHandler(this.but_incycle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_new);
            this.groupBox1.Controls.Add(this.cb_old);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox1.Location = new System.Drawing.Point(468, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 47);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // cb_new
            // 
            this.cb_new.AutoSize = true;
            this.cb_new.Location = new System.Drawing.Point(141, 17);
            this.cb_new.Name = "cb_new";
            this.cb_new.Size = new System.Drawing.Size(60, 24);
            this.cb_new.TabIndex = 5;
            this.cb_new.Text = "清空";
            this.cb_new.UseVisualStyleBackColor = true;
            this.cb_new.CheckedChanged += new System.EventHandler(this.cb_new_CheckedChanged);
            // 
            // cb_old
            // 
            this.cb_old.AutoSize = true;
            this.cb_old.Location = new System.Drawing.Point(12, 16);
            this.cb_old.Name = "cb_old";
            this.cb_old.Size = new System.Drawing.Size(60, 24);
            this.cb_old.TabIndex = 4;
            this.cb_old.Text = "全选";
            this.cb_old.UseVisualStyleBackColor = true;
            this.cb_old.CheckedChanged += new System.EventHandler(this.cb_old_CheckedChanged);
            // 
            // dgv_01
            // 
            this.dgv_01.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.Name = "isselect";
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.HeaderText = "条码";
            gridViewTextBoxColumn2.Name = "bar_code";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.HeaderText = "实体器械包名称";
            gridViewTextBoxColumn3.Name = "ca_name";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.HeaderText = "是否在循环中";
            gridViewTextBoxColumn4.Name = "in_cycle";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 250;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.MultiSelect = true;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.Size = new System.Drawing.Size(792, 446);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.SelectionChanged += new System.EventHandler(this.dgv_01_SelectionChanged);
            // 
            // HCSCM_set_cycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.sp_main);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HCSCM_set_cycle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_set_cycle";
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel1.PerformLayout();
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_sname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_putcycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_incycle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_new;
        private System.Windows.Forms.CheckBox cb_old;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_putcycle;
        private Telerik.WinControls.UI.RadButton but_incycle;
        private Telerik.WinControls.UI.RadButton but_sel;
        private Telerik.WinControls.UI.RadTextBox tb_sel;
        private Telerik.WinControls.UI.RadLabel lb_sname;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}