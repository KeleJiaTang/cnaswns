namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_costcenter_manage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
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
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
            this.lb_cssd = new System.Windows.Forms.Label();
            this.but_new = new Telerik.WinControls.UI.RadButton();
            this.but_printlist = new Telerik.WinControls.UI.RadButton();
            this.but_department = new Telerik.WinControls.UI.RadButton();
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.tb_cssd = new Telerik.WinControls.UI.RadTextBox();
            this.radlb_customer = new Telerik.WinControls.UI.RadLabel();
            this.but_edit = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radlb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.sp_main.Size = new System.Drawing.Size(776, 447);
            this.sp_main.SplitterDistance = 150;
            this.sp_main.TabIndex = 0;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.radGroupBox1.Controls.Add(this.cb_type);
            this.radGroupBox1.Controls.Add(this.lb_cssd);
            this.radGroupBox1.Controls.Add(this.but_new);
            this.radGroupBox1.Controls.Add(this.but_printlist);
            this.radGroupBox1.Controls.Add(this.but_department);
            this.radGroupBox1.Controls.Add(this.but_remove);
            this.radGroupBox1.Controls.Add(this.tb_cssd);
            this.radGroupBox1.Controls.Add(this.radlb_customer);
            this.radGroupBox1.Controls.Add(this.but_edit);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "成本中心管理>>主窗口";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(776, 150);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "成本中心管理>>主窗口";
            this.radGroupBox1.ThemeName = "Office2007Silver";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_type.Location = new System.Drawing.Point(74, 115);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(246, 25);
            this.cb_type.TabIndex = 5;
            this.cb_type.ThemeName = "Office2007Silver";
            this.cb_type.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // lb_cssd
            // 
            this.lb_cssd.AutoSize = true;
            this.lb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_cssd.Location = new System.Drawing.Point(7, 86);
            this.lb_cssd.Name = "lb_cssd";
            this.lb_cssd.Size = new System.Drawing.Size(61, 20);
            this.lb_cssd.TabIndex = 44;
            this.lb_cssd.Text = "CSSD：";
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_new.Location = new System.Drawing.Point(11, 34);
            this.but_new.Name = "but_new";
            this.but_new.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 1;
            this.but_new.Text = " 新  建";
            this.but_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_new.ThemeName = "Office2007Silver";
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // but_printlist
            // 
            this.but_printlist.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_printlist.Location = new System.Drawing.Point(466, 34);
            this.but_printlist.Name = "but_printlist";
            this.but_printlist.Size = new System.Drawing.Size(110, 42);
            this.but_printlist.TabIndex = 1;
            this.but_printlist.Text = "打印列表";
            this.but_printlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_printlist.ThemeName = "Office2007Silver";
            this.but_printlist.Click += new System.EventHandler(this.but_printlist_Click);
            // 
            // but_department
            // 
            this.but_department.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_department.Location = new System.Drawing.Point(350, 34);
            this.but_department.Name = "but_department";
            this.but_department.Size = new System.Drawing.Size(110, 42);
            this.but_department.TabIndex = 1;
            this.but_department.Text = "配置部门";
            this.but_department.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_department.ThemeName = "Office2007Silver";
            this.but_department.Click += new System.EventHandler(this.but_department_Click);
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_remove.Location = new System.Drawing.Point(221, 34);
            this.but_remove.Name = "but_remove";
            this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 1;
            this.but_remove.Text = "删  除";
            this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // tb_cssd
            // 
            this.tb_cssd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_cssd.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_cssd.Location = new System.Drawing.Point(74, 84);
            this.tb_cssd.Name = "tb_cssd";
            this.tb_cssd.Size = new System.Drawing.Size(246, 25);
            this.tb_cssd.TabIndex = 4;
            this.tb_cssd.ThemeName = "Office2007Silver";
            // 
            // radlb_customer
            // 
            this.radlb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radlb_customer.Location = new System.Drawing.Point(4, 115);
            this.radlb_customer.Name = "radlb_customer";
            this.radlb_customer.Size = new System.Drawing.Size(63, 23);
            this.radlb_customer.TabIndex = 3;
            this.radlb_customer.Text = "客  户：";
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_edit.Location = new System.Drawing.Point(116, 34);
            this.but_edit.Name = "but_edit";
            this.but_edit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 1;
            this.but_edit.Text = "修  改";
            this.but_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_edit.ThemeName = "Office2007Silver";
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 59;
            gridViewTextBoxColumn2.HeaderText = "条码";
            gridViewTextBoxColumn2.Name = "bar_code";
            gridViewTextBoxColumn2.Width = 141;
            gridViewTextBoxColumn3.HeaderText = "成本中心名称";
            gridViewTextBoxColumn3.Name = "ca_name";
            gridViewTextBoxColumn3.Width = 180;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "所属客户";
            gridViewTextBoxColumn4.Name = "cu_id";
            gridViewTextBoxColumn4.Width = 180;
            gridViewTextBoxColumn5.HeaderText = "自有成本号";
            gridViewTextBoxColumn5.Name = "custmer_cnumber";
            gridViewTextBoxColumn5.Width = 93;
            gridViewTextBoxColumn6.HeaderText = "备注说明";
            gridViewTextBoxColumn6.Name = "ca_remarks";
            gridViewTextBoxColumn6.Width = 233;
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
            this.dgv_01.Size = new System.Drawing.Size(776, 293);
            this.dgv_01.TabIndex = 1;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.SelectionChanged += new System.EventHandler(this.dgv_01_SelectionChanged);
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_costcenter_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.sp_main);
            this.Name = "HCSCM_costcenter_manage";
            this.Size = new System.Drawing.Size(776, 447);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cssd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radlb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label lb_cssd;
        private Telerik.WinControls.UI.RadButton but_new;
        private Telerik.WinControls.UI.RadButton but_printlist;
        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private Telerik.WinControls.UI.RadButton but_department;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadTextBox tb_cssd;
        private Telerik.WinControls.UI.RadLabel radlb_customer;
        private Telerik.WinControls.UI.RadButton but_edit;
    }
}
