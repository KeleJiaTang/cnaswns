namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_storage_set
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
			this.lb_instrument = new System.Windows.Forms.Label();
			this.lb_storage = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgv_02 = new Telerik.WinControls.UI.RadGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.but_sel = new Telerik.WinControls.UI.RadButton();
			this.tb_set = new Telerik.WinControls.UI.RadTextBox();
			this.tb_storage = new Telerik.WinControls.UI.RadTextBox();
			this.but_save = new Telerik.WinControls.UI.RadButton();
			this.but_reall = new Telerik.WinControls.UI.RadButton();
			this.but_reone = new Telerik.WinControls.UI.RadButton();
			this.but_addone = new Telerik.WinControls.UI.RadButton();
			this.but_addall = new Telerik.WinControls.UI.RadButton();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_set)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_storage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_instrument
			// 
			this.lb_instrument.AutoSize = true;
			this.lb_instrument.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_instrument.Location = new System.Drawing.Point(12, 12);
			this.lb_instrument.Name = "lb_instrument";
			this.lb_instrument.Size = new System.Drawing.Size(105, 20);
			this.lb_instrument.TabIndex = 56;
			this.lb_instrument.Text = "实体包名称：";
			// 
			// lb_storage
			// 
			this.lb_storage.AutoSize = true;
			this.lb_storage.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lb_storage.Location = new System.Drawing.Point(484, 12);
			this.lb_storage.Name = "lb_storage";
			this.lb_storage.Size = new System.Drawing.Size(105, 20);
			this.lb_storage.TabIndex = 54;
			this.lb_storage.Text = "存储点名称：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgv_02);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.groupBox2.Location = new System.Drawing.Point(485, 45);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(321, 482);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "已选实体包";
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
			this.dgv_02.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id2";
			gridViewTextBoxColumn1.Width = 74;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "名称";
			gridViewTextBoxColumn2.Name = "ca_name2";
			gridViewTextBoxColumn2.Width = 221;
			this.dgv_02.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
			this.dgv_02.MasterTemplate.MultiSelect = true;
			this.dgv_02.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv_02.Name = "dgv_02";
			this.dgv_02.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_02.ReadOnly = true;
			this.dgv_02.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_02.ShowGroupPanel = false;
			this.dgv_02.Size = new System.Drawing.Size(315, 456);
			this.dgv_02.TabIndex = 0;
			this.dgv_02.Text = "radGridView2";
			this.dgv_02.ThemeName = "Office2007Silver";
			this.dgv_02.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_02_CellDoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgv_01);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.groupBox1.Location = new System.Drawing.Point(16, 45);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(326, 482);
			this.groupBox1.TabIndex = 47;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "可选实体包";
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
			this.dgv_01.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "编号";
			gridViewTextBoxColumn3.Name = "id";
			gridViewTextBoxColumn3.Width = 71;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "名称";
			gridViewTextBoxColumn4.Name = "ca_name";
			gridViewTextBoxColumn4.Width = 229;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
			this.dgv_01.MasterTemplate.MultiSelect = true;
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition2;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.Size = new System.Drawing.Size(320, 456);
			this.dgv_01.TabIndex = 0;
			this.dgv_01.Text = "radGridView1";
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// but_sel
			// 
			this.but_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_sel.Location = new System.Drawing.Point(291, 12);
			this.but_sel.Name = "but_sel";
			this.but_sel.Size = new System.Drawing.Size(48, 25);
			this.but_sel.TabIndex = 58;
			this.but_sel.Text = "查询";
			this.but_sel.ThemeName = "Office2007Silver";
			this.but_sel.Click += new System.EventHandler(this.bt_sel_Click);
			// 
			// tb_set
			// 
			this.tb_set.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_set.Location = new System.Drawing.Point(122, 12);
			this.tb_set.Name = "tb_set";
			this.tb_set.Size = new System.Drawing.Size(163, 25);
			this.tb_set.TabIndex = 59;
			this.tb_set.ThemeName = "Office2007Silver";
			this.tb_set.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_set_KeyDown);
			// 
			// tb_storage
			// 
			this.tb_storage.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_storage.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_storage.Location = new System.Drawing.Point(587, 12);
			this.tb_storage.Name = "tb_storage";
			this.tb_storage.ReadOnly = true;
			this.tb_storage.Size = new System.Drawing.Size(216, 25);
			this.tb_storage.TabIndex = 60;
			this.tb_storage.ThemeName = "Office2007Silver";
			// 
			// but_save
			// 
			this.but_save.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.but_save.Location = new System.Drawing.Point(351, 370);
			this.but_save.Name = "but_save";
			this.but_save.Size = new System.Drawing.Size(121, 42);
			this.but_save.TabIndex = 61;
			this.but_save.Text = "保存记录";
			this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_save.ThemeName = "Office2007Silver";
			this.but_save.Click += new System.EventHandler(this.but_save_Click);
			// 
			// but_reall
			// 
			this.but_reall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.but_reall.Location = new System.Drawing.Point(351, 308);
			this.but_reall.Name = "but_reall";
			this.but_reall.Size = new System.Drawing.Size(121, 42);
			this.but_reall.TabIndex = 62;
			this.but_reall.Text = "                                                                                 " +
    "                                 ";
			this.but_reall.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_reall.ThemeName = "Office2007Silver";
			this.but_reall.Click += new System.EventHandler(this.but_reall_Click);
			// 
			// but_reone
			// 
			this.but_reone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.but_reone.Location = new System.Drawing.Point(351, 256);
			this.but_reone.Name = "but_reone";
			this.but_reone.Size = new System.Drawing.Size(121, 42);
			this.but_reone.TabIndex = 63;
			this.but_reone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_reone.ThemeName = "Office2007Silver";
			this.but_reone.Click += new System.EventHandler(this.but_reone_Click);
			// 
			// but_addone
			// 
			this.but_addone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.Location = new System.Drawing.Point(351, 206);
			this.but_addone.Name = "but_addone";
			this.but_addone.Size = new System.Drawing.Size(121, 42);
			this.but_addone.TabIndex = 64;
			this.but_addone.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addone.ThemeName = "Office2007Silver";
			this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
			// 
			// but_addall
			// 
			this.but_addall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.but_addall.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addall.Location = new System.Drawing.Point(351, 154);
			this.but_addall.Name = "but_addall";
			this.but_addall.Size = new System.Drawing.Size(121, 42);
			this.but_addall.TabIndex = 65;
			this.but_addall.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.but_addall.ThemeName = "Office2007Silver";
			this.but_addall.Click += new System.EventHandler(this.but_addall_Click);
			// 
			// HCSCM_storage_set
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(823, 538);
			this.Controls.Add(this.but_save);
			this.Controls.Add(this.but_reall);
			this.Controls.Add(this.but_reone);
			this.Controls.Add(this.but_addone);
			this.Controls.Add(this.but_addall);
			this.Controls.Add(this.tb_storage);
			this.Controls.Add(this.tb_set);
			this.Controls.Add(this.but_sel);
			this.Controls.Add(this.lb_instrument);
			this.Controls.Add(this.lb_storage);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_storage_set";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_set)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_storage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_reone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_addall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_instrument;
        private System.Windows.Forms.Label lb_storage;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton but_sel;
        private Telerik.WinControls.UI.RadTextBox tb_set;
        private Telerik.WinControls.UI.RadTextBox tb_storage;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadButton but_reall;
        private Telerik.WinControls.UI.RadButton but_reone;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_addall;
		private Telerik.WinControls.UI.RadGridView dgv_02;
		private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}