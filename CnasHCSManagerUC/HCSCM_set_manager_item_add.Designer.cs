namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_item_add
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
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
			this.lb_sname = new System.Windows.Forms.Label();
			this.but_sel = new Telerik.WinControls.UI.RadButton();
			this.but_addone = new Telerik.WinControls.UI.RadButton();
			this.but_reone = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.tb_sname = new Telerik.WinControls.UI.RadTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgv_02 = new Telerik.WinControls.UI.RadGridView();
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_sname)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_sname
			// 
			this.lb_sname.AutoSize = true;
			this.lb_sname.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_sname.Location = new System.Drawing.Point(18, 19);
			this.lb_sname.Name = "lb_sname";
			this.lb_sname.Size = new System.Drawing.Size(89, 20);
			this.lb_sname.TabIndex = 60;
			this.lb_sname.Text = "器械名称：";
			// 
			// but_sel
			// 
			this.but_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_sel.Location = new System.Drawing.Point(291, 18);
			this.but_sel.Name = "but_sel";
			this.but_sel.Size = new System.Drawing.Size(48, 25);
			this.but_sel.TabIndex = 65;
			this.but_sel.Text = "查询";
			this.but_sel.ThemeName = "Office2007Silver";
			this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
			// 
			// but_addone
			// 
			this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.Location = new System.Drawing.Point(345, 206);
			this.but_addone.Name = "but_addone";
			this.but_addone.Size = new System.Drawing.Size(99, 42);
			this.but_addone.TabIndex = 66;
			this.but_addone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.ThemeName = "Office2007Silver";
			this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
			// 
			// but_reone
			// 
			this.but_reone.Location = new System.Drawing.Point(345, 258);
			this.but_reone.Name = "but_reone";
			this.but_reone.Size = new System.Drawing.Size(99, 42);
			this.but_reone.TabIndex = 67;
			this.but_reone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_reone.ThemeName = "Office2007Silver";
			this.but_reone.Click += new System.EventHandler(this.but_reone_Click);
			// 
			// but_ok
			// 
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(561, 12);
			this.but_ok.Name = "but_ok";
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 67;
			this.but_ok.Text = "确定";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_save_Click);
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(666, 12);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 68;
			this.but_cancel.Text = "关闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// tb_sname
			// 
			this.tb_sname.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_sname.Location = new System.Drawing.Point(102, 18);
			this.tb_sname.Name = "tb_sname";
			this.tb_sname.Size = new System.Drawing.Size(183, 25);
			this.tb_sname.TabIndex = 0;
			this.tb_sname.ThemeName = "Office2007Silver";
			this.tb_sname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgv_01);
			this.groupBox1.Location = new System.Drawing.Point(22, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(317, 368);
			this.groupBox1.TabIndex = 73;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "添加列表";
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.SystemColors.Window;
			this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_01.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_01.Location = new System.Drawing.Point(3, 23);
			// 
			// 
			// 
			this.dgv_01.MasterTemplate.AllowAddNewRow = false;
			this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.dgv_01.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 83;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "名称";
			gridViewTextBoxColumn2.Name = "ca_name";
			gridViewTextBoxColumn2.Width = 208;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
			this.dgv_01.MasterTemplate.MultiSelect = true;
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.Size = new System.Drawing.Size(311, 342);
			this.dgv_01.TabIndex = 4;
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgv_02);
			this.groupBox2.Location = new System.Drawing.Point(456, 62);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(309, 368);
			this.groupBox2.TabIndex = 73;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "器械列表";
			// 
			// dgv_02
			// 
			this.dgv_02.BackColor = System.Drawing.SystemColors.Window;
			this.dgv_02.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_02.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_02.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv_02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_02.Location = new System.Drawing.Point(3, 23);
			// 
			// 
			// 
			this.dgv_02.MasterTemplate.AllowAddNewRow = false;
			this.dgv_02.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_02.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.dgv_02.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "编号";
			gridViewTextBoxColumn3.Name = "id2";
			gridViewTextBoxColumn3.Width = 84;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "名称";
			gridViewTextBoxColumn4.Name = "ca_name";
			gridViewTextBoxColumn4.Width = 199;
			this.dgv_02.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
			this.dgv_02.MasterTemplate.MultiSelect = true;
			this.dgv_02.MasterTemplate.ViewDefinition = tableViewDefinition2;
			this.dgv_02.Name = "dgv_02";
			this.dgv_02.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_02.ReadOnly = true;
			this.dgv_02.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_02.ShowGroupPanel = false;
			this.dgv_02.Size = new System.Drawing.Size(303, 342);
			this.dgv_02.TabIndex = 4;
			this.dgv_02.ThemeName = "Office2007Silver";
			this.dgv_02.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_02_CellDoubleClick);
			// 
			// HCSCM_set_manager_item_add
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(785, 449);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tb_sname);
			this.Controls.Add(this.but_cancel);
			this.Controls.Add(this.but_ok);
			this.Controls.Add(this.but_reone);
			this.Controls.Add(this.but_addone);
			this.Controls.Add(this.but_sel);
			this.Controls.Add(this.lb_sname);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_set_manager_item_add";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "器械类型选择";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HCSCM_set_manager_item_add_FormClosed);
			this.Load += new System.EventHandler(this.HCSCM_set_manager_item_add_Load);
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_sname)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_sname;
        private Telerik.WinControls.UI.RadButton but_sel;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_reone;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadTextBox tb_sname;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView dgv_02;
    }
}