namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_login_configuration
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.but_edit = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
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
            this.sp_main.Margin = new System.Windows.Forms.Padding(0);
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
            this.sp_main.Size = new System.Drawing.Size(1366, 842);
            this.sp_main.SplitterDistance = 88;
            this.sp_main.TabIndex = 1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.radGroupBox1.Controls.Add(this.but_remove);
            this.radGroupBox1.Controls.Add(this.but_edit);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "登录配置管理>>主窗口";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1366, 88);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "登录配置管理>>主窗口";
            this.radGroupBox1.ThemeName = "Office2007Silver";
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 11F);
            this.but_remove.Location = new System.Drawing.Point(116, 31);
            this.but_remove.Name = "but_remove";
            this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 2;
            this.but_remove.Text = "删  除";
            this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 11F);
            this.but_edit.Location = new System.Drawing.Point(11, 31);
            this.but_edit.Name = "but_edit";
            this.but_edit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 4;
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
            this.dgv_01.MasterTemplate.AllowAddNewRow = false;
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn8.HeaderText = "编号";
            gridViewTextBoxColumn8.Name = "id";
            gridViewTextBoxColumn8.Width = 44;
            gridViewTextBoxColumn9.HeaderText = "计算机名称";
            gridViewTextBoxColumn9.Name = "computer";
            gridViewTextBoxColumn9.Width = 176;
            gridViewTextBoxColumn10.HeaderText = "MAC";
            gridViewTextBoxColumn10.Name = "mac_address";
            gridViewTextBoxColumn10.Width = 176;
            gridViewTextBoxColumn11.HeaderText = "ip地址";
            gridViewTextBoxColumn11.Name = "ip_address";
            gridViewTextBoxColumn11.Width = 176;
            gridViewTextBoxColumn12.HeaderText = "工作台配置";
            gridViewTextBoxColumn12.Name = "work_id";
            gridViewTextBoxColumn12.Width = 388;
            gridViewTextBoxColumn13.HeaderText = "备注";
            gridViewTextBoxColumn13.Name = "remark";
            gridViewTextBoxColumn13.Width = 390;
            gridViewTextBoxColumn14.HeaderText = "work_num";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "work_num";
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(1366, 750);
            this.dgv_01.TabIndex = 4;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSSM_login_configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp_main);
            this.Name = "HCSSM_login_configuration";
            this.Size = new System.Drawing.Size(1366, 842);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadButton but_edit;
        private Telerik.WinControls.UI.RadGridView dgv_01;

    }
}
