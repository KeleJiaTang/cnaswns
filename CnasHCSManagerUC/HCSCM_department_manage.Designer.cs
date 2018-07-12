namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_department_manage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.but_costcenter = new Telerik.WinControls.UI.RadButton();
            this.tb_customer = new Telerik.WinControls.UI.RadTextBox();
            this.lb_customer = new Telerik.WinControls.UI.RadLabel();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_printlist = new Telerik.WinControls.UI.RadButton();
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.but_edit = new Telerik.WinControls.UI.RadButton();
            this.but_new = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_costcenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.Controls.Add(this.radGroupBox1);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(723, 414);
            this.sp_main.SplitterDistance = 94;
            this.sp_main.TabIndex = 1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.but_costcenter);
            this.radGroupBox1.Controls.Add(this.tb_customer);
            this.radGroupBox1.Controls.Add(this.lb_customer);
            this.radGroupBox1.Controls.Add(this.but_cancel);
            this.radGroupBox1.Controls.Add(this.but_printlist);
            this.radGroupBox1.Controls.Add(this.but_remove);
            this.radGroupBox1.Controls.Add(this.but_edit);
            this.radGroupBox1.Controls.Add(this.but_new);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(723, 94);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Window;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.Window;
            // 
            // but_costcenter
            // 
            this.but_costcenter.Font = new System.Drawing.Font("宋体", 11F);
            this.but_costcenter.Location = new System.Drawing.Point(350, 12);
            this.but_costcenter.Name = "but_costcenter";
            this.but_costcenter.Size = new System.Drawing.Size(136, 42);
            this.but_costcenter.TabIndex = 64;
            this.but_costcenter.Text = "配置成本中心";
            this.but_costcenter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_costcenter.ThemeName = "Office2007Silver";
            this.but_costcenter.Click += new System.EventHandler(this.but_costcenter_Click);
            // 
            // tb_customer
            // 
            this.tb_customer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_customer.Font = new System.Drawing.Font("宋体", 11F);
            this.tb_customer.Location = new System.Drawing.Point(100, 62);
            this.tb_customer.Name = "tb_customer";
            this.tb_customer.ReadOnly = true;
            this.tb_customer.Size = new System.Drawing.Size(220, 22);
            this.tb_customer.TabIndex = 66;
            this.tb_customer.ThemeName = "Office2007Silver";
            // 
            // lb_customer
            // 
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(11, 62);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(86, 23);
            this.lb_customer.TabIndex = 65;
            this.lb_customer.Text = "所属客户：";
            this.lb_customer.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 11F);
            this.but_cancel.Location = new System.Drawing.Point(598, 12);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 61;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_close_Click);
            // 
            // but_printlist
            // 
            this.but_printlist.Font = new System.Drawing.Font("宋体", 11F);
            this.but_printlist.Location = new System.Drawing.Point(493, 12);
            this.but_printlist.Name = "but_printlist";
            this.but_printlist.Size = new System.Drawing.Size(99, 42);
            this.but_printlist.TabIndex = 61;
            this.but_printlist.Text = "打印列表";
            this.but_printlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_printlist.ThemeName = "Office2007Silver";
            this.but_printlist.Click += new System.EventHandler(this.but_print_Click);
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 11F);
            this.but_remove.Location = new System.Drawing.Point(221, 12);
            this.but_remove.Name = "but_remove";
            this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 61;
            this.but_remove.Text = "删  除";
            this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 11F);
            this.but_edit.Location = new System.Drawing.Point(116, 12);
            this.but_edit.Name = "but_edit";
            this.but_edit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 62;
            this.but_edit.Text = "修  改";
            this.but_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_edit.ThemeName = "Office2007Silver";
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 11F);
            this.but_new.Location = new System.Drawing.Point(11, 12);
            this.but_new.Name = "but_new";
            this.but_new.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 63;
            this.but_new.Text = "新  建";
            this.but_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_new.ThemeName = "Office2007Silver";
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("宋体", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.HeaderText = "部门名称";
            gridViewTextBoxColumn2.Name = "ca_name";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.HeaderText = "备注说明";
            gridViewTextBoxColumn3.Name = "ca_remarks";
            gridViewTextBoxColumn3.Width = 350;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(723, 316);
            this.dgv_01.TabIndex = 4;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_department_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(723, 414);
            this.Controls.Add(this.sp_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_department_manage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门管理";
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_costcenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox tb_customer;
        private Telerik.WinControls.UI.RadLabel lb_customer;
        private Telerik.WinControls.UI.RadButton but_costcenter;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_printlist;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadButton but_edit;
        private Telerik.WinControls.UI.RadButton but_new;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}