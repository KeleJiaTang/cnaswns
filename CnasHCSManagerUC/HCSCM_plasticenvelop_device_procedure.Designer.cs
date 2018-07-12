namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_plasticenvelop_device_procedure
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
			this.lb_washing = new System.Windows.Forms.Label();
			this.lb_cssd = new System.Windows.Forms.Label();
			this.tb_cssd = new Telerik.WinControls.UI.RadTextBox();
			this.tb_department = new Telerik.WinControls.UI.RadTextBox();
			this.but_save = new Telerik.WinControls.UI.RadButton();
			this.but_reall = new Telerik.WinControls.UI.RadButton();
			this.but_reone = new Telerik.WinControls.UI.RadButton();
			this.but_addone = new Telerik.WinControls.UI.RadButton();
			this.but_addall = new Telerik.WinControls.UI.RadButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgv_02 = new Telerik.WinControls.UI.RadGridView();
			((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_department)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_washing
			// 
			this.lb_washing.AutoSize = true;
			this.lb_washing.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_washing.Location = new System.Drawing.Point(463, 14);
			this.lb_washing.Name = "lb_washing";
			this.lb_washing.Size = new System.Drawing.Size(105, 20);
			this.lb_washing.TabIndex = 51;
			this.lb_washing.Text = "塑封机名称：";
			// 
			// lb_cssd
			// 
			this.lb_cssd.AutoSize = true;
			this.lb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_cssd.Location = new System.Drawing.Point(22, 12);
			this.lb_cssd.Name = "lb_cssd";
			this.lb_cssd.Size = new System.Drawing.Size(61, 20);
			this.lb_cssd.TabIndex = 52;
			this.lb_cssd.Text = "CSSD：";
			// 
			// tb_cssd
			// 
			this.tb_cssd.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_cssd.Location = new System.Drawing.Point(86, 12);
			this.tb_cssd.Name = "tb_cssd";
			this.tb_cssd.ReadOnly = true;
			this.tb_cssd.Size = new System.Drawing.Size(249, 25);
			this.tb_cssd.TabIndex = 3;
			this.tb_cssd.ThemeName = "Office2007Silver";
			// 
			// tb_department
			// 
			this.tb_department.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_department.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_department.Location = new System.Drawing.Point(574, 12);
			this.tb_department.Name = "tb_department";
			this.tb_department.ReadOnly = true;
			this.tb_department.Size = new System.Drawing.Size(202, 25);
			this.tb_department.TabIndex = 4;
			this.tb_department.ThemeName = "Office2007Silver";
			// 
			// but_save
			// 
			this.but_save.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_save.Location = new System.Drawing.Point(349, 400);
			this.but_save.Name = "but_save";
			this.but_save.Size = new System.Drawing.Size(105, 42);
			this.but_save.TabIndex = 53;
			this.but_save.Text = "保存记录";
			this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_save.ThemeName = "Office2007Silver";
			this.but_save.Click += new System.EventHandler(this.but_save_Click);
			// 
			// but_reall
			// 
			this.but_reall.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_reall.Location = new System.Drawing.Point(349, 338);
			this.but_reall.Name = "but_reall";
			this.but_reall.Size = new System.Drawing.Size(104, 42);
			this.but_reall.TabIndex = 54;
			this.but_reall.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_reall.ThemeName = "Office2007Silver";
			this.but_reall.Click += new System.EventHandler(this.but_reall_Click);
			// 
			// but_reone
			// 
			this.but_reone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_reone.Location = new System.Drawing.Point(350, 286);
			this.but_reone.Name = "but_reone";
			this.but_reone.Size = new System.Drawing.Size(104, 42);
			this.but_reone.TabIndex = 55;
			this.but_reone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_reone.ThemeName = "Office2007Silver";
			this.but_reone.Click += new System.EventHandler(this.but_reone_Click);
			// 
			// but_addone
			// 
			this.but_addone.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.Location = new System.Drawing.Point(350, 234);
			this.but_addone.Name = "but_addone";
			this.but_addone.Size = new System.Drawing.Size(104, 42);
			this.but_addone.TabIndex = 56;
			this.but_addone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.ThemeName = "Office2007Silver";
			this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
			// 
			// but_addall
			// 
			this.but_addall.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_addall.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addall.Location = new System.Drawing.Point(350, 182);
			this.but_addall.Name = "but_addall";
			this.but_addall.Size = new System.Drawing.Size(104, 42);
			this.but_addall.TabIndex = 57;
			this.but_addall.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addall.ThemeName = "Office2007Silver";
			this.but_addall.Click += new System.EventHandler(this.but_addall_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgv_01);
			this.groupBox1.Location = new System.Drawing.Point(26, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(309, 484);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "可选塑封程序";
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.SystemColors.Window;
			this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_01.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_01.Location = new System.Drawing.Point(3, 18);
			// 
			// 
			// 
			this.dgv_01.MasterTemplate.AllowAddNewRow = false;
			this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 84;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "名称";
			gridViewTextBoxColumn2.Name = "ca_name";
			gridViewTextBoxColumn2.Width = 200;
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
			this.dgv_01.Size = new System.Drawing.Size(303, 463);
			this.dgv_01.TabIndex = 4;
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgv_02);
			this.groupBox2.Location = new System.Drawing.Point(467, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(309, 484);
			this.groupBox2.TabIndex = 58;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "可选塑封程序";
			// 
			// dgv_02
			// 
			this.dgv_02.BackColor = System.Drawing.SystemColors.Window;
			this.dgv_02.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_02.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_02.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv_02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_02.Location = new System.Drawing.Point(3, 18);
			// 
			// 
			// 
			this.dgv_02.MasterTemplate.AllowAddNewRow = false;
			this.dgv_02.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_02.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "编号";
			gridViewTextBoxColumn3.Name = "id";
			gridViewTextBoxColumn3.Width = 84;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "名称";
			gridViewTextBoxColumn4.Name = "ca_name";
			gridViewTextBoxColumn4.Width = 200;
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
			this.dgv_02.Size = new System.Drawing.Size(303, 463);
			this.dgv_02.TabIndex = 4;
			this.dgv_02.ThemeName = "Office2007Silver";
			this.dgv_02.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_02_CellDoubleClick);
			// 
			// HCSCM_plasticenvelop_device_procedure
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(801, 554);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.but_save);
			this.Controls.Add(this.tb_department);
			this.Controls.Add(this.tb_cssd);
			this.Controls.Add(this.but_reall);
			this.Controls.Add(this.lb_washing);
			this.Controls.Add(this.but_addall);
			this.Controls.Add(this.but_reone);
			this.Controls.Add(this.lb_cssd);
			this.Controls.Add(this.but_addone);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_plasticenvelop_device_procedure";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "塑封流程管理";
			((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_department)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).EndInit();
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

        private System.Windows.Forms.Label lb_washing;
        private System.Windows.Forms.Label lb_cssd;
        private Telerik.WinControls.UI.RadTextBox tb_cssd;
        private Telerik.WinControls.UI.RadTextBox tb_department;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadButton but_reall;
        private Telerik.WinControls.UI.RadButton but_reone;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_addall;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView dgv_02;

    }
}