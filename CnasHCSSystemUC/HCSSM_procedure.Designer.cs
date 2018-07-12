namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_procedure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_procedure));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.tabp02 = new System.Windows.Forms.TabPage();
            this.tabp01 = new System.Windows.Forms.TabPage();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            this.tabc_main = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.spc_main = new System.Windows.Forms.SplitContainer();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.tb_search = new Telerik.WinControls.UI.RadTextBox();
            this.cb_app = new Telerik.WinControls.UI.RadDropDownList();
            this.but_list = new Telerik.WinControls.UI.RadButton();
            this.but_par = new Telerik.WinControls.UI.RadButton();
            this.but_barcode = new Telerik.WinControls.UI.RadButton();
            this.but_relation = new Telerik.WinControls.UI.RadButton();
            this.but_import = new Telerik.WinControls.UI.RadButton();
            this.but_app = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.tabp02.SuspendLayout();
            this.tabp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            this.tabc_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_main)).BeginInit();
            this.spc_main.Panel1.SuspendLayout();
            this.spc_main.Panel2.SuspendLayout();
            this.spc_main.SuspendLayout();
            this.gp_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_app)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_par)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_relation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_app)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_help
            // 
            this.pic_help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_help.Image = ((System.Drawing.Image)(resources.GetObject("pic_help.Image")));
            this.pic_help.Location = new System.Drawing.Point(3, 3);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(850, 349);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_help.TabIndex = 0;
            this.pic_help.TabStop = false;
            // 
            // tabp02
            // 
            this.tabp02.Controls.Add(this.pic_help);
            this.tabp02.Location = new System.Drawing.Point(4, 25);
            this.tabp02.Name = "tabp02";
            this.tabp02.Padding = new System.Windows.Forms.Padding(3);
            this.tabp02.Size = new System.Drawing.Size(856, 355);
            this.tabp02.TabIndex = 1;
            this.tabp02.Text = "帮助";
            this.tabp02.UseVisualStyleBackColor = true;
            // 
            // tabp01
            // 
            this.tabp01.Controls.Add(this.dgv_01);
            this.tabp01.Location = new System.Drawing.Point(4, 25);
            this.tabp01.Name = "tabp01";
            this.tabp01.Padding = new System.Windows.Forms.Padding(3);
            this.tabp01.Size = new System.Drawing.Size(856, 355);
            this.tabp01.TabIndex = 0;
            this.tabp01.Text = "流程列表";
            this.tabp01.UseVisualStyleBackColor = true;
            // 
            // dgv_01
            // 
            this.dgv_01.BackColor = System.Drawing.Color.Transparent;
            this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_01.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowAddNewRow = false;
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "流程编码";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "流程名称";
            gridViewTextBoxColumn2.Name = "pd_name";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "流程条形码";
            gridViewTextBoxColumn3.Name = "pd_bcode";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 180;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "描述";
            gridViewTextBoxColumn4.Name = "pd_description";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 300;
            gridViewTextBoxColumn4.WrapText = true;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(850, 349);
            this.dgv_01.TabIndex = 1;
            this.dgv_01.Text = "radGridView1";
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dgv_01_ViewCellFormatting);
            // 
            // tabc_main
            // 
            this.tabc_main.Controls.Add(this.tabp01);
            this.tabc_main.Controls.Add(this.tabp02);
            this.tabc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_main.Location = new System.Drawing.Point(0, 0);
            this.tabc_main.Name = "tabc_main";
            this.tabc_main.SelectedIndex = 0;
            this.tabc_main.Size = new System.Drawing.Size(864, 384);
            this.tabc_main.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(427, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "搜索内容(名称、编码)";
            // 
            // spc_main
            // 
            this.spc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_main.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spc_main.Location = new System.Drawing.Point(0, 0);
            this.spc_main.Name = "spc_main";
            this.spc_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spc_main.Panel1
            // 
            this.spc_main.Panel1.Controls.Add(this.gp_top);
            // 
            // spc_main.Panel2
            // 
            this.spc_main.Panel2.Controls.Add(this.tabc_main);
            this.spc_main.Size = new System.Drawing.Size(864, 518);
            this.spc_main.SplitterDistance = 130;
            this.spc_main.TabIndex = 2;
            // 
            // gp_top
            // 
            this.gp_top.Controls.Add(this.tb_search);
            this.gp_top.Controls.Add(this.cb_app);
            this.gp_top.Controls.Add(this.but_list);
            this.gp_top.Controls.Add(this.but_par);
            this.gp_top.Controls.Add(this.but_barcode);
            this.gp_top.Controls.Add(this.but_relation);
            this.gp_top.Controls.Add(this.but_import);
            this.gp_top.Controls.Add(this.but_app);
            this.gp_top.Controls.Add(this.label1);
            this.gp_top.Controls.Add(this.radGroupBox1);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(864, 130);
            this.gp_top.TabIndex = 1;
            this.gp_top.TabStop = false;
            // 
            // tb_search
            // 
            this.tb_search.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_search.Location = new System.Drawing.Point(591, 90);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(181, 25);
            this.tb_search.TabIndex = 92;
            this.tb_search.ThemeName = "Office2007Silver";
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTextBox1_KeyDown);
            // 
            // cb_app
            // 
            this.cb_app.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_app.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_app.Location = new System.Drawing.Point(7, 91);
            this.cb_app.Name = "cb_app";
            this.cb_app.Size = new System.Drawing.Size(299, 25);
            this.cb_app.TabIndex = 91;
            this.cb_app.ThemeName = "Office2007Silver";
            this.cb_app.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_app_SelectedIndexChanged);
            // 
            // but_list
            // 
            this.but_list.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_list.Location = new System.Drawing.Point(674, 36);
            this.but_list.Name = "but_list";
            this.but_list.Size = new System.Drawing.Size(98, 42);
            this.but_list.TabIndex = 90;
            this.but_list.Text = "打印列表";
            this.but_list.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_list.ThemeName = "Office2007Silver";
            this.but_list.Click += new System.EventHandler(this.but_list_Click);
            // 
            // but_par
            // 
            this.but_par.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_par.Location = new System.Drawing.Point(206, 36);
            this.but_par.Name = "but_par";
            this.but_par.Size = new System.Drawing.Size(98, 42);
            this.but_par.TabIndex = 88;
            this.but_par.Text = "流程参数";
            this.but_par.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_par.ThemeName = "Office2007Silver";
            this.but_par.Click += new System.EventHandler(this.but_par_Click_1);
            // 
            // but_barcode
            // 
            this.but_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_barcode.Location = new System.Drawing.Point(574, 36);
            this.but_barcode.Name = "but_barcode";
            this.but_barcode.Size = new System.Drawing.Size(98, 42);
            this.but_barcode.TabIndex = 90;
            this.but_barcode.Text = "打印条码";
            this.but_barcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_barcode.ThemeName = "Office2007Silver";
            this.but_barcode.Click += new System.EventHandler(this.but_barcode_Click);
            // 
            // but_relation
            // 
            this.but_relation.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_relation.Location = new System.Drawing.Point(107, 36);
            this.but_relation.Name = "but_relation";
            this.but_relation.Size = new System.Drawing.Size(98, 42);
            this.but_relation.TabIndex = 87;
            this.but_relation.Text = "流程关系";
            this.but_relation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_relation.ThemeName = "Office2007Silver";
            this.but_relation.Click += new System.EventHandler(this.but_relation_Click_1);
            // 
            // but_import
            // 
            this.but_import.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_import.Location = new System.Drawing.Point(474, 36);
            this.but_import.Name = "but_import";
            this.but_import.Size = new System.Drawing.Size(98, 42);
            this.but_import.TabIndex = 89;
            this.but_import.Text = "导出列表";
            this.but_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_import.ThemeName = "Office2007Silver";
            this.but_import.Click += new System.EventHandler(this.but_import_Click_1);
            // 
            // but_app
            // 
            this.but_app.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_app.Location = new System.Drawing.Point(7, 36);
            this.but_app.Name = "but_app";
            this.but_app.Size = new System.Drawing.Size(98, 42);
            this.but_app.TabIndex = 86;
            this.but_app.Text = "App流程";
            this.but_app.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_app.ThemeName = "Office2007Silver";
            this.but_app.Click += new System.EventHandler(this.but_app_Click_1);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "流程管理>>主窗口";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(862, 124);
            this.radGroupBox1.TabIndex = 93;
            this.radGroupBox1.Text = "流程管理>>主窗口";
            this.radGroupBox1.ThemeName = "Office2007Silver";
            // 
            // HCSSM_procedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.spc_main);
            this.Name = "HCSSM_procedure";
            this.Size = new System.Drawing.Size(864, 518);
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.tabp02.ResumeLayout(false);
            this.tabp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.tabc_main.ResumeLayout(false);
            this.spc_main.Panel1.ResumeLayout(false);
            this.spc_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_main)).EndInit();
            this.spc_main.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_app)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_par)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_relation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_app)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.TabPage tabp02;
        private System.Windows.Forms.TabPage tabp01;
        private System.Windows.Forms.TabControl tabc_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer spc_main;
        private System.Windows.Forms.GroupBox gp_top;
        private Telerik.WinControls.UI.RadButton but_relation;
        private Telerik.WinControls.UI.RadButton but_app;
        private Telerik.WinControls.UI.RadButton but_par;
        private Telerik.WinControls.UI.RadButton but_list;
        private Telerik.WinControls.UI.RadButton but_barcode;
        private Telerik.WinControls.UI.RadButton but_import;
        private Telerik.WinControls.UI.RadDropDownList cb_app;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadTextBox tb_search;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
