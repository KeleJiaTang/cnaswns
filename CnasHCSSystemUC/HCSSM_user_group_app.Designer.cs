namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_user_group_app
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_02 = new Telerik.WinControls.UI.RadGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_new = new System.Windows.Forms.CheckBox();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.lab_search = new System.Windows.Forms.Label();
            this.but_reall = new Telerik.WinControls.UI.RadButton();
            this.but_reaone = new Telerik.WinControls.UI.RadButton();
            this.but_addall = new Telerik.WinControls.UI.RadButton();
            this.but_addone = new Telerik.WinControls.UI.RadButton();
            this.but_save = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_reall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reaone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_01);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 560);
            this.groupBox1.TabIndex = 0;
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
            gridViewCheckBoxColumn3.EnableExpressionEditor = false;
            gridViewCheckBoxColumn3.IsVisible = false;
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "isselected";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "编号";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "id";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "简码";
            gridViewTextBoxColumn8.Name = "app_briefcode";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "名称";
            gridViewTextBoxColumn9.Name = "app_name";
            gridViewTextBoxColumn9.Width = 150;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn3,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.dgv_01.MasterTemplate.MultiSelect = true;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(315, 534);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.Text = "radGridView1";
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_02);
            this.groupBox2.Location = new System.Drawing.Point(455, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 560);
            this.groupBox2.TabIndex = 1;
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
            gridViewCheckBoxColumn4.EnableExpressionEditor = false;
            gridViewCheckBoxColumn4.IsVisible = false;
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "isselected2";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "编号";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "id2";
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "简码";
            gridViewTextBoxColumn11.Name = "app_briefcode2";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "名称";
            gridViewTextBoxColumn12.Name = "app_name2";
            gridViewTextBoxColumn12.Width = 150;
            this.dgv_02.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn4,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dgv_02.MasterTemplate.MultiSelect = true;
            this.dgv_02.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.dgv_02.Name = "dgv_02";
            this.dgv_02.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_02.ReadOnly = true;
            this.dgv_02.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_02.ShowGroupPanel = false;
            this.dgv_02.Size = new System.Drawing.Size(315, 534);
            this.dgv_02.TabIndex = 3;
            this.dgv_02.Text = "radGridView2";
            this.dgv_02.ThemeName = "Office2007Silver";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_new);
            this.groupBox3.Controls.Add(this.cb_old);
            this.groupBox3.Controls.Add(this.tb_search);
            this.groupBox3.Controls.Add(this.lab_search);
            this.groupBox3.Location = new System.Drawing.Point(13, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 62);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // cb_new
            // 
            this.cb_new.AutoSize = true;
            this.cb_new.Location = new System.Drawing.Point(664, 26);
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
            this.cb_old.Location = new System.Drawing.Point(442, 26);
            this.cb_old.Name = "cb_old";
            this.cb_old.Size = new System.Drawing.Size(92, 24);
            this.cb_old.TabIndex = 2;
            this.cb_old.Text = "全选可选";
            this.cb_old.UseVisualStyleBackColor = true;
            this.cb_old.Visible = false;
            this.cb_old.CheckedChanged += new System.EventHandler(this.cb_old_CheckedChanged);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(121, 24);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(197, 21);
            this.tb_search.TabIndex = 1;
            this.tb_search.Visible = false;
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
            // but_reall
            // 
            this.but_reall.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_reall.Location = new System.Drawing.Point(338, 334);
            this.but_reall.Name = "but_reall";
            this.but_reall.Size = new System.Drawing.Size(111, 42);
            this.but_reall.TabIndex = 34;
            this.but_reall.ThemeName = "Office2007Silver";
            this.but_reall.Click += new System.EventHandler(this.but_reall_Click);
            // 
            // but_reaone
            // 
            this.but_reaone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_reaone.Location = new System.Drawing.Point(338, 273);
            this.but_reaone.Name = "but_reaone";
            this.but_reaone.Size = new System.Drawing.Size(111, 42);
            this.but_reaone.TabIndex = 35;
            this.but_reaone.ThemeName = "Office2007Silver";
            this.but_reaone.Click += new System.EventHandler(this.but_reone_Click);
            // 
            // but_addall
            // 
            this.but_addall.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_addall.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.but_addall.Location = new System.Drawing.Point(338, 154);
            this.but_addall.Name = "but_addall";
            this.but_addall.Size = new System.Drawing.Size(111, 42);
            this.but_addall.TabIndex = 37;
            this.but_addall.ThemeName = "Office2007Silver";
            this.but_addall.Click += new System.EventHandler(this.but_addall_Click);
            // 
            // but_addone
            // 
            this.but_addone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_addone.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.but_addone.Location = new System.Drawing.Point(338, 212);
            this.but_addone.Name = "but_addone";
            this.but_addone.Size = new System.Drawing.Size(111, 42);
            this.but_addone.TabIndex = 36;
            this.but_addone.ThemeName = "Office2007Silver";
            this.but_addone.Click += new System.EventHandler(this.but_addone_Click);
            // 
            // but_save
            // 
            this.but_save.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_save.Location = new System.Drawing.Point(338, 456);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(111, 42);
            this.but_save.TabIndex = 33;
            this.but_save.Text = "          保存记录";
            this.but_save.ThemeName = "Office2007Silver";
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // HCSSM_user_group_app
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(788, 596);
            this.Controls.Add(this.but_reall);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.but_reaone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_addall);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.but_addone);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSSM_user_group_app";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置群组:";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_reall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reaone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_addone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label lab_search;
        private System.Windows.Forms.CheckBox cb_new;
        private System.Windows.Forms.CheckBox cb_old;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadGridView dgv_02;
        private Telerik.WinControls.UI.RadButton but_reall;
        private Telerik.WinControls.UI.RadButton but_reaone;
        private Telerik.WinControls.UI.RadButton but_addall;
        private Telerik.WinControls.UI.RadButton but_addone;
        private Telerik.WinControls.UI.RadButton but_save;
    }
}