namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_usergroup
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_02 = new Telerik.WinControls.UI.RadGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_search = new Telerik.WinControls.UI.RadTextBox();
            this.cb_new = new System.Windows.Forms.CheckBox();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.lab_search = new System.Windows.Forms.Label();
            this.but_save = new Telerik.WinControls.UI.RadButton();
            this.but_reall = new Telerik.WinControls.UI.RadButton();
            this.but_reone = new Telerik.WinControls.UI.RadButton();
            this.but_addone = new Telerik.WinControls.UI.RadButton();
            this.but_addall = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_01);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 553);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可选功能模块";
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
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "isselected";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "group_id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "群组名";
            gridViewTextBoxColumn2.Name = "group_name";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "群组类型";
            gridViewTextBoxColumn3.Name = "group_type";
            gridViewTextBoxColumn3.Width = 150;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dgv_01.MasterTemplate.MultiSelect = true;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(315, 527);
            this.dgv_01.TabIndex = 4;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_02);
            this.groupBox2.Location = new System.Drawing.Point(459, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 553);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已经选功能模块";
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
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "isselected2";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "编号";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "group_id2";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "群组名";
            gridViewTextBoxColumn5.Name = "group_name2";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "群组类型";
            gridViewTextBoxColumn6.Name = "group_type2";
            gridViewTextBoxColumn6.Width = 150;
            this.dgv_02.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.dgv_02.MasterTemplate.MultiSelect = true;
            this.dgv_02.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgv_02.Name = "dgv_02";
            this.dgv_02.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_02.ReadOnly = true;
            this.dgv_02.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_02.ShowGroupPanel = false;
            this.dgv_02.Size = new System.Drawing.Size(315, 527);
            this.dgv_02.TabIndex = 5;
            this.dgv_02.ThemeName = "Office2007Silver";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_search);
            this.groupBox3.Controls.Add(this.cb_new);
            this.groupBox3.Controls.Add(this.cb_old);
            this.groupBox3.Controls.Add(this.lab_search);
            this.groupBox3.Location = new System.Drawing.Point(12, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(770, 31);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // tb_search
            // 
            this.tb_search.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_search.Location = new System.Drawing.Point(133, 25);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(185, 25);
            this.tb_search.TabIndex = 4;
            this.tb_search.ThemeName = "Office2007Silver";
            this.tb_search.Visible = false;
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.but_save_Click);
            // 
            // cb_new
            // 
            this.cb_new.AutoSize = true;
            this.cb_new.Location = new System.Drawing.Point(607, 26);
            this.cb_new.Name = "cb_new";
            this.cb_new.Size = new System.Drawing.Size(92, 24);
            this.cb_new.TabIndex = 3;
            this.cb_new.Text = "全选已选";
            this.cb_new.UseVisualStyleBackColor = true;
            this.cb_new.Visible = false;
            this.cb_new.CheckedChanged += new System.EventHandler(this.cb_new_CheckedChanged);
            // 
            // cb_old
            // 
            this.cb_old.AutoSize = true;
            this.cb_old.Location = new System.Drawing.Point(452, 26);
            this.cb_old.Name = "cb_old";
            this.cb_old.Size = new System.Drawing.Size(92, 24);
            this.cb_old.TabIndex = 2;
            this.cb_old.Text = "全选可选";
            this.cb_old.UseVisualStyleBackColor = true;
            this.cb_old.Visible = false;
            this.cb_old.CheckedChanged += new System.EventHandler(this.cb_old_CheckedChanged);
            // 
            // lab_search
            // 
            this.lab_search.AutoSize = true;
            this.lab_search.Location = new System.Drawing.Point(16, 27);
            this.lab_search.Name = "lab_search";
            this.lab_search.Size = new System.Drawing.Size(121, 20);
            this.lab_search.TabIndex = 0;
            this.lab_search.Text = "搜索功能模块：";
            this.lab_search.Visible = false;
            // 
            // but_save
            // 
            this.but_save.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_save.Location = new System.Drawing.Point(334, 415);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(119, 42);
            this.but_save.TabIndex = 26;
            this.but_save.Text = "保存记录";
            this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_save.ThemeName = "Office2007Silver";
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // but_reall
            // 
            this.but_reall.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_reall.Location = new System.Drawing.Point(335, 293);
            this.but_reall.Name = "but_reall";
            this.but_reall.Size = new System.Drawing.Size(119, 42);
            this.but_reall.TabIndex = 27;
            this.but_reall.ThemeName = "Office2007Silver";
            this.but_reall.Click += new System.EventHandler(this.but_reall_Click);
            // 
            // but_reone
            // 
            this.but_reone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_reone.Location = new System.Drawing.Point(335, 232);
            this.but_reone.Name = "but_reone";
            this.but_reone.Size = new System.Drawing.Size(119, 42);
            this.but_reone.TabIndex = 27;
            this.but_reone.ThemeName = "Office2007Silver";
            this.but_reone.Click += new System.EventHandler(this.but_reone_Click);
            // 
            // but_addone
            // 
            this.but_addone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.but_addone.Location = new System.Drawing.Point(335, 171);
            this.but_addone.Name = "but_addone";
            this.but_addone.Size = new System.Drawing.Size(119, 42);
            this.but_addone.TabIndex = 27;
            this.but_addone.ThemeName = "Office2007Silver";
            this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
            // 
            // but_addall
            // 
            this.but_addall.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_addall.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.but_addall.Location = new System.Drawing.Point(335, 110);
            this.but_addall.Name = "but_addall";
            this.but_addall.Size = new System.Drawing.Size(119, 42);
            this.but_addall.TabIndex = 27;
            this.but_addall.ThemeName = "Office2007Silver";
            this.but_addall.Click += new System.EventHandler(this.but_addall_Click);
            // 
            // HCSSM_usergroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(790, 577);
            this.Controls.Add(this.but_reall);
            this.Controls.Add(this.but_reone);
            this.Controls.Add(this.but_addone);
            this.Controls.Add(this.but_addall);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(798, 610);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(798, 610);
            this.Name = "HCSSM_usergroup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(798, 610);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "群用户管理： ";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cb_new;
        private System.Windows.Forms.CheckBox cb_old;
        private System.Windows.Forms.Label lab_search;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadGridView dgv_02;
        private Telerik.WinControls.UI.RadButton but_reone;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadButton but_reall;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_addall;
        private Telerik.WinControls.UI.RadTextBox tb_search;
    }
}