namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_in_cycle
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
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.cb_set = new Telerik.WinControls.UI.RadDropDownList();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.but_showall = new Telerik.WinControls.UI.RadButton();
            this.tb_set = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lb_material = new System.Windows.Forms.Label();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_showall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_set)).BeginInit();
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
            this.sp_main.Panel1.Controls.Add(this.radGroupBox2);
            this.sp_main.Panel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(784, 501);
            this.sp_main.SplitterDistance = 73;
            this.sp_main.TabIndex = 0;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.cb_set);
            this.radGroupBox2.Controls.Add(this.cb_old);
            this.radGroupBox2.Controls.Add(this.but_cancel);
            this.radGroupBox2.Controls.Add(this.but_ok);
            this.radGroupBox2.Controls.Add(this.but_showall);
            this.radGroupBox2.Controls.Add(this.tb_set);
            this.radGroupBox2.Controls.Add(this.lb_material);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.Font = new System.Drawing.Font("宋体", 11F);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(784, 73);
            this.radGroupBox2.TabIndex = 0;
            this.radGroupBox2.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Window;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.Window;
            // 
            // cb_set
            // 
            this.cb_set.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_set.Font = new System.Drawing.Font("宋体", 11F);
            this.cb_set.Location = new System.Drawing.Point(210, 23);
            this.cb_set.Name = "cb_set";
            this.cb_set.Size = new System.Drawing.Size(125, 22);
            this.cb_set.TabIndex = 70;
            this.cb_set.ThemeName = "Office2007Silver";
            this.cb_set.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_set_SelectedIndexChanged);
            // 
            // cb_old
            // 
            this.cb_old.AutoSize = true;
            this.cb_old.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_old.Location = new System.Drawing.Point(18, 21);
            this.cb_old.Name = "cb_old";
            this.cb_old.Size = new System.Drawing.Size(60, 24);
            this.cb_old.TabIndex = 59;
            this.cb_old.Text = "全选";
            this.cb_old.UseVisualStyleBackColor = true;
            this.cb_old.CheckedChanged += new System.EventHandler(this.cb_old_CheckedChanged);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(673, 14);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 67;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(568, 14);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 66;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_showall
            // 
            this.but_showall.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_showall.Location = new System.Drawing.Point(463, 14);
            this.but_showall.Name = "but_showall";
            this.but_showall.Size = new System.Drawing.Size(99, 42);
            this.but_showall.TabIndex = 65;
            this.but_showall.Text = "显示全部";
            this.but_showall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_showall.ThemeName = "Office2007Silver";
            this.but_showall.Click += new System.EventHandler(this.but_showall_Click);
            // 
            // tb_set
            // 
            this.tb_set.AcceptsReturn = true;
            this.tb_set.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_set.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_set.IsReadOnly = true;
            this.tb_set.Location = new System.Drawing.Point(210, 23);
            this.tb_set.Multiline = true;
            this.tb_set.Name = "tb_set";
            this.tb_set.Size = new System.Drawing.Size(125, 22);
            this.tb_set.TabIndex = 295;
            this.tb_set.ThemeName = "Office2007Silver";
            this.tb_set.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.tb_set.Visible = false;
            // 
            // lb_material
            // 
            this.lb_material.AutoSize = true;
            this.lb_material.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_material.Location = new System.Drawing.Point(112, 22);
            this.lb_material.Name = "lb_material";
            this.lb_material.Size = new System.Drawing.Size(95, 20);
            this.lb_material.TabIndex = 69;
            this.lb_material.Text = "新包/旧包：";
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
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.dgv_01.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.HeaderText = "选择";
            gridViewCheckBoxColumn1.Name = "isselect";
            gridViewCheckBoxColumn1.Width = 68;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 86;
            gridViewTextBoxColumn2.HeaderText = "条码";
            gridViewTextBoxColumn2.Name = "bar_code";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 205;
            gridViewTextBoxColumn3.HeaderText = "器械包名称";
            gridViewTextBoxColumn3.Name = "ca_name";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 204;
            gridViewTextBoxColumn4.HeaderText = "是否在循环中";
            gridViewTextBoxColumn4.Name = "in_cycle";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 204;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.Size = new System.Drawing.Size(784, 424);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // HCSCM_in_cycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.sp_main);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_in_cycle";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加入/移出循环";
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_showall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadButton but_showall;
        private System.Windows.Forms.Label lb_material;
        private Telerik.WinControls.UI.RadDropDownList cb_set;
        private Telerik.WinControls.UI.RadGridView dgv_01;
		private System.Windows.Forms.CheckBox cb_old;
        private Telerik.WinControls.UI.RadTextBoxControl tb_set;
    }
}