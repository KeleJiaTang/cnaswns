namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_costcenter_department
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
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_costcenter_department));
			this.lb_customer = new System.Windows.Forms.Label();
			this.lb_department = new System.Windows.Forms.Label();
			this.but_addall = new Telerik.WinControls.UI.RadButton();
			this.but_addone = new Telerik.WinControls.UI.RadButton();
			this.but_reone = new Telerik.WinControls.UI.RadButton();
			this.but_reall = new Telerik.WinControls.UI.RadButton();
			this.but_save = new Telerik.WinControls.UI.RadButton();
			this.tb_customer = new Telerik.WinControls.UI.RadTextBox();
			this.tb_department = new Telerik.WinControls.UI.RadTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radDgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radDgv_02 = new Telerik.WinControls.UI.RadGridView();
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_customer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_department)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_01.MasterTemplate)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_02.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_customer
			// 
			this.lb_customer.AutoSize = true;
			this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_customer.Location = new System.Drawing.Point(15, 9);
			this.lb_customer.Name = "lb_customer";
			this.lb_customer.Size = new System.Drawing.Size(89, 20);
			this.lb_customer.TabIndex = 31;
			this.lb_customer.Text = "所属客户：";
			// 
			// lb_department
			// 
			this.lb_department.AutoSize = true;
			this.lb_department.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_department.Location = new System.Drawing.Point(469, 9);
			this.lb_department.Name = "lb_department";
			this.lb_department.Size = new System.Drawing.Size(57, 20);
			this.lb_department.TabIndex = 31;
			this.lb_department.Text = "部门：";
			// 
			// but_addall
			// 
			this.but_addall.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_addall.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addall.Location = new System.Drawing.Point(335, 169);
			this.but_addall.Name = "but_addall";
			this.but_addall.Size = new System.Drawing.Size(121, 42);
			this.but_addall.TabIndex = 34;
			this.but_addall.ThemeName = "Office2007Silver";
			this.but_addall.Click += new System.EventHandler(this.but_addall_Click);
			// 
			// but_addone
			// 
			this.but_addone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.Location = new System.Drawing.Point(335, 221);
			this.but_addone.Name = "but_addone";
			this.but_addone.Size = new System.Drawing.Size(121, 42);
			this.but_addone.TabIndex = 34;
			this.but_addone.ThemeName = "Office2007Silver";
			this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
			// 
			// but_reone
			// 
			this.but_reone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_reone.Location = new System.Drawing.Point(335, 273);
			this.but_reone.Name = "but_reone";
			this.but_reone.Size = new System.Drawing.Size(121, 42);
			this.but_reone.TabIndex = 34;
			this.but_reone.ThemeName = "Office2007Silver";
			this.but_reone.Click += new System.EventHandler(this.but_reone_Click);
			// 
			// but_reall
			// 
			this.but_reall.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_reall.Location = new System.Drawing.Point(334, 325);
			this.but_reall.Name = "but_reall";
			this.but_reall.Size = new System.Drawing.Size(121, 42);
			this.but_reall.TabIndex = 34;
			this.but_reall.ThemeName = "Office2007Silver";
			this.but_reall.Click += new System.EventHandler(this.but_reall_Click);
			// 
			// but_save
			// 
			this.but_save.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_save.Location = new System.Drawing.Point(334, 387);
			this.but_save.Name = "but_save";
			this.but_save.Size = new System.Drawing.Size(121, 42);
			this.but_save.TabIndex = 34;
			this.but_save.Text = "保存记录";
			this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_save.ThemeName = "Office2007Silver";
			this.but_save.Click += new System.EventHandler(this.but_save_Click);
			// 
			// tb_customer
			// 
			this.tb_customer.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_customer.Location = new System.Drawing.Point(16, 32);
			this.tb_customer.Name = "tb_customer";
			this.tb_customer.ReadOnly = true;
			this.tb_customer.Size = new System.Drawing.Size(309, 25);
			this.tb_customer.TabIndex = 35;
			this.tb_customer.ThemeName = "Office2007Silver";
			// 
			// tb_department
			// 
			this.tb_department.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_department.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_department.Location = new System.Drawing.Point(470, 32);
			this.tb_department.Name = "tb_department";
			this.tb_department.ReadOnly = true;
			this.tb_department.Size = new System.Drawing.Size(306, 25);
			this.tb_department.TabIndex = 36;
			this.tb_department.ThemeName = "Office2007Silver";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radDgv_01);
			this.groupBox1.Location = new System.Drawing.Point(16, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(309, 432);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "可选成本中心";
			// 
			// radDgv_01
			// 
			this.radDgv_01.BackColor = System.Drawing.SystemColors.Window;
			this.radDgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			this.radDgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radDgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radDgv_01.ForeColor = System.Drawing.SystemColors.ControlText;
			this.radDgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.radDgv_01.Location = new System.Drawing.Point(3, 23);
			// 
			// 
			// 
			this.radDgv_01.MasterTemplate.AllowAddNewRow = false;
			this.radDgv_01.MasterTemplate.AllowCellContextMenu = false;
			this.radDgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewCheckBoxColumn1.EnableExpressionEditor = false;
			gridViewCheckBoxColumn1.IsVisible = false;
			gridViewCheckBoxColumn1.MinWidth = 20;
			gridViewCheckBoxColumn1.Name = "isselected";
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 84;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "名称";
			gridViewTextBoxColumn2.Name = "ca_name";
			gridViewTextBoxColumn2.Width = 200;
			this.radDgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
			this.radDgv_01.MasterTemplate.MultiSelect = true;
			this.radDgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.radDgv_01.Name = "radDgv_01";
			this.radDgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.radDgv_01.ReadOnly = true;
			this.radDgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radDgv_01.ShowGroupPanel = false;
			this.radDgv_01.Size = new System.Drawing.Size(303, 406);
			this.radDgv_01.TabIndex = 4;
			this.radDgv_01.ThemeName = "Office2007Silver";
			this.radDgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radDgv_01_CellDoubleClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radDgv_02);
			this.groupBox2.Location = new System.Drawing.Point(470, 63);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(309, 429);
			this.groupBox2.TabIndex = 37;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "可选成本中心";
			// 
			// radDgv_02
			// 
			this.radDgv_02.BackColor = System.Drawing.SystemColors.Window;
			this.radDgv_02.Cursor = System.Windows.Forms.Cursors.Default;
			this.radDgv_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radDgv_02.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radDgv_02.ForeColor = System.Drawing.SystemColors.ControlText;
			this.radDgv_02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.radDgv_02.Location = new System.Drawing.Point(3, 23);
			// 
			// 
			// 
			this.radDgv_02.MasterTemplate.AllowAddNewRow = false;
			this.radDgv_02.MasterTemplate.AllowCellContextMenu = false;
			this.radDgv_02.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewCheckBoxColumn2.EnableExpressionEditor = false;
			gridViewCheckBoxColumn2.IsVisible = false;
			gridViewCheckBoxColumn2.MinWidth = 20;
			gridViewCheckBoxColumn2.Name = "isselected";
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "编号";
			gridViewTextBoxColumn3.Name = "id2";
			gridViewTextBoxColumn3.Width = 84;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "名称";
			gridViewTextBoxColumn4.Name = "ca_name";
			gridViewTextBoxColumn4.Width = 200;
			this.radDgv_02.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
			this.radDgv_02.MasterTemplate.MultiSelect = true;
			this.radDgv_02.MasterTemplate.ViewDefinition = tableViewDefinition2;
			this.radDgv_02.Name = "radDgv_02";
			this.radDgv_02.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.radDgv_02.ReadOnly = true;
			this.radDgv_02.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radDgv_02.ShowGroupPanel = false;
			this.radDgv_02.Size = new System.Drawing.Size(303, 403);
			this.radDgv_02.TabIndex = 4;
			this.radDgv_02.ThemeName = "Office2007Silver";
			this.radDgv_02.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radDgv_02_CellDoubleClick);
			// 
			// HCSCM_costcenter_department
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(791, 497);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tb_department);
			this.Controls.Add(this.tb_customer);
			this.Controls.Add(this.but_save);
			this.Controls.Add(this.but_reall);
			this.Controls.Add(this.but_reone);
			this.Controls.Add(this.but_addone);
			this.Controls.Add(this.but_addall);
			this.Controls.Add(this.lb_customer);
			this.Controls.Add(this.lb_department);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_costcenter_department";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "关联成本中心";
			this.Load += new System.EventHandler(this.HCSCM_costcenter_department_Load);
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_customer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_department)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radDgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_01)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radDgv_02.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radDgv_02)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label lb_department;
        private Telerik.WinControls.UI.RadButton but_addall;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_reone;
        private Telerik.WinControls.UI.RadButton but_reall;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadTextBox tb_customer;
        private Telerik.WinControls.UI.RadTextBox tb_department;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView radDgv_01;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView radDgv_02;
    }
}