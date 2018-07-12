namespace Cnas.wns.CnasHCSReporManagerUC
{
    partial class HCSRM_custom_template_report
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.scmain = new System.Windows.Forms.SplitContainer();
            this.rtvCustomTemplate = new Telerik.WinControls.UI.RadTreeView();
            this.rCustomTemplateMenu = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.rvgCustomFile = new Telerik.WinControls.UI.RadGridView();
            this.CustomFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmtEditReport = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomTemplateMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmtAddTem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtUpdateTem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtAddTemReport = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).BeginInit();
            this.scmain.Panel1.SuspendLayout();
            this.scmain.Panel2.SuspendLayout();
            this.scmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtvCustomTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvgCustomFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvgCustomFile.MasterTemplate)).BeginInit();
            this.CustomFileMenu.SuspendLayout();
            this.CustomTemplateMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scmain
            // 
            this.scmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scmain.Location = new System.Drawing.Point(0, 0);
            this.scmain.Name = "scmain";
            // 
            // scmain.Panel1
            // 
            this.scmain.Panel1.Controls.Add(this.rtvCustomTemplate);
            // 
            // scmain.Panel2
            // 
            this.scmain.Panel2.Controls.Add(this.rvgCustomFile);
            this.scmain.Size = new System.Drawing.Size(1029, 618);
            this.scmain.SplitterDistance = 274;
            this.scmain.TabIndex = 0;
            // 
            // rtvCustomTemplate
            // 
            this.rtvCustomTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.rtvCustomTemplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtvCustomTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtvCustomTemplate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtvCustomTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtvCustomTemplate.Location = new System.Drawing.Point(0, 0);
            this.rtvCustomTemplate.Name = "rtvCustomTemplate";
            this.rtvCustomTemplate.RadContextMenu = this.rCustomTemplateMenu;
            this.rtvCustomTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtvCustomTemplate.Size = new System.Drawing.Size(274, 618);
            this.rtvCustomTemplate.TabIndex = 7;
            this.rtvCustomTemplate.Text = "radTreeView1";
            this.rtvCustomTemplate.ThemeName = "Office2007Silver";
            this.rtvCustomTemplate.NodeMouseClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.rtvCustomTemplate_NodeMouseClick);
            // 
            // rCustomTemplateMenu
            // 
            this.rCustomTemplateMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2,
            this.radMenuItem3});
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "新增模版";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "修改模版";
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "根据模版创建报表";
            // 
            // rvgCustomFile
            // 
            this.rvgCustomFile.BackColor = System.Drawing.SystemColors.Control;
            this.rvgCustomFile.ContextMenuStrip = this.CustomFileMenu;
            this.rvgCustomFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.rvgCustomFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvgCustomFile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rvgCustomFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.rvgCustomFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rvgCustomFile.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rvgCustomFile.MasterTemplate.AllowAddNewRow = false;
            this.rvgCustomFile.MasterTemplate.AllowCellContextMenu = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "报表名称";
            gridViewTextBoxColumn2.Name = "report_name";
            gridViewTextBoxColumn2.Width = 300;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "创建时间";
            gridViewTextBoxColumn3.Name = "cre_date";
            gridViewTextBoxColumn3.Width = 200;
            this.rvgCustomFile.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.rvgCustomFile.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rvgCustomFile.Name = "rvgCustomFile";
            this.rvgCustomFile.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rvgCustomFile.ReadOnly = true;
            this.rvgCustomFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rvgCustomFile.ShowGroupPanel = false;
            this.rvgCustomFile.Size = new System.Drawing.Size(751, 618);
            this.rvgCustomFile.TabIndex = 0;
            this.rvgCustomFile.Text = "radGridView2";
            this.rvgCustomFile.ThemeName = "Office2007Silver";
            this.rvgCustomFile.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rvgCustomFile_CellDoubleClick);
            // 
            // CustomFileMenu
            // 
            this.CustomFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtEditReport});
            this.CustomFileMenu.Name = "CustomFileMenu";
            this.CustomFileMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // tsmtEditReport
            // 
            this.tsmtEditReport.Name = "tsmtEditReport";
            this.tsmtEditReport.Size = new System.Drawing.Size(124, 22);
            this.tsmtEditReport.Text = "修改报表";
            this.tsmtEditReport.Click += new System.EventHandler(this.tsmtEditReport_Click);
            // 
            // CustomTemplateMenu
            // 
            this.CustomTemplateMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtAddTem,
            this.tsmtUpdateTem,
            this.tsmtAddTemReport});
            this.CustomTemplateMenu.Name = "CustomTemplateMenu";
            this.CustomTemplateMenu.Size = new System.Drawing.Size(173, 70);
            // 
            // tsmtAddTem
            // 
            this.tsmtAddTem.Name = "tsmtAddTem";
            this.tsmtAddTem.Size = new System.Drawing.Size(172, 22);
            this.tsmtAddTem.Text = "新增模版";
            this.tsmtAddTem.Click += new System.EventHandler(this.tsmtAddTem_Click);
            // 
            // tsmtUpdateTem
            // 
            this.tsmtUpdateTem.Name = "tsmtUpdateTem";
            this.tsmtUpdateTem.Size = new System.Drawing.Size(172, 22);
            this.tsmtUpdateTem.Text = "修改模版";
            this.tsmtUpdateTem.Click += new System.EventHandler(this.tsmtUpdateTem_Click);
            // 
            // tsmtAddTemReport
            // 
            this.tsmtAddTemReport.Name = "tsmtAddTemReport";
            this.tsmtAddTemReport.Size = new System.Drawing.Size(172, 22);
            this.tsmtAddTemReport.Text = "根据模版新建报表";
            this.tsmtAddTemReport.Click += new System.EventHandler(this.tsmtAddTemReport_Click);
            // 
            // HCSRM_custom_template_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scmain);
            this.Name = "HCSRM_custom_template_report";
            this.Size = new System.Drawing.Size(1029, 618);
            this.Load += new System.EventHandler(this.HCSRM_custom_template_report_Load);
            this.scmain.Panel1.ResumeLayout(false);
            this.scmain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).EndInit();
            this.scmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rtvCustomTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvgCustomFile.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvgCustomFile)).EndInit();
            this.CustomFileMenu.ResumeLayout(false);
            this.CustomTemplateMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scmain;
        private Telerik.WinControls.UI.RadGridView rvgCustomFile;
        private System.Windows.Forms.ContextMenuStrip CustomTemplateMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmtAddTem;
        private System.Windows.Forms.ToolStripMenuItem tsmtUpdateTem;
        private System.Windows.Forms.ToolStripMenuItem tsmtAddTemReport;
        private System.Windows.Forms.ContextMenuStrip CustomFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmtEditReport;
        private Telerik.WinControls.UI.RadTreeView rtvCustomTemplate;
        private Telerik.WinControls.UI.RadContextMenu rCustomTemplateMenu;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
    }
}
