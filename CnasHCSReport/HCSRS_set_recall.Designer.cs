namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_set_recall
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dt_start = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.but_sterilizer = new Telerik.WinControls.UI.RadButton();
            this.dt_end = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lb_sterilizer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.but_printlist = new Telerik.WinControls.UI.RadButton();
            this.but_set = new Telerik.WinControls.UI.RadButton();
            this.but_import = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sterilizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.radGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 646);
            this.splitContainer1.SplitterDistance = 115;
            this.splitContainer1.TabIndex = 1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dt_start);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.but_sterilizer);
            this.radGroupBox1.Controls.Add(this.dt_end);
            this.radGroupBox1.Controls.Add(this.lb_sterilizer);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.but_printlist);
            this.radGroupBox1.Controls.Add(this.but_set);
            this.radGroupBox1.Controls.Add(this.but_import);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "召回包>>主窗体";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1115, 115);
            this.radGroupBox1.TabIndex = 76;
            this.radGroupBox1.Text = "召回包>>主窗体";
            this.radGroupBox1.ThemeName = "Office2007Silver";
            // 
            // dt_start
            // 
            this.dt_start.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dt_start.Location = new System.Drawing.Point(61, 83);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(142, 25);
            this.dt_start.TabIndex = 1;
            this.dt_start.TabStop = false;
            this.dt_start.ThemeName = "Office2007Silver";
            this.dt_start.Value = new System.DateTime(((long)(0)));
            this.dt_start.ValueChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "开始：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_sterilizer
            // 
            this.but_sterilizer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_sterilizer.Location = new System.Drawing.Point(10, 32);
            this.but_sterilizer.Name = "but_sterilizer";
            this.but_sterilizer.Size = new System.Drawing.Size(94, 45);
            this.but_sterilizer.TabIndex = 72;
            this.but_sterilizer.Text = "灭菌器";
            this.but_sterilizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_sterilizer.ThemeName = "Office2007Silver";
            this.but_sterilizer.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // dt_end
            // 
            this.dt_end.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dt_end.Location = new System.Drawing.Point(267, 83);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(194, 25);
            this.dt_end.TabIndex = 2;
            this.dt_end.TabStop = false;
            this.dt_end.ThemeName = "Office2007Silver";
            this.dt_end.Value = new System.DateTime(((long)(0)));
            this.dt_end.ValueChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // lb_sterilizer
            // 
            this.lb_sterilizer.AutoSize = true;
            this.lb_sterilizer.Font = new System.Drawing.Font("宋体", 11F);
            this.lb_sterilizer.Location = new System.Drawing.Point(214, 20);
            this.lb_sterilizer.Name = "lb_sterilizer";
            this.lb_sterilizer.Size = new System.Drawing.Size(0, 15);
            this.lb_sterilizer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(206, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "结束：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_printlist
            // 
            this.but_printlist.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_printlist.Location = new System.Drawing.Point(267, 32);
            this.but_printlist.Name = "but_printlist";
            this.but_printlist.Size = new System.Drawing.Size(94, 45);
            this.but_printlist.TabIndex = 75;
            this.but_printlist.Text = "打印列表";
            this.but_printlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_printlist.ThemeName = "Office2007Silver";
            this.but_printlist.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // but_set
            // 
            this.but_set.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_set.Location = new System.Drawing.Point(109, 32);
            this.but_set.Name = "but_set";
            this.but_set.Size = new System.Drawing.Size(94, 45);
            this.but_set.TabIndex = 73;
            this.but_set.Text = "查器械包";
            this.but_set.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_set.ThemeName = "Office2007Silver";
            this.but_set.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // but_import
            // 
            this.but_import.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_import.Location = new System.Drawing.Point(367, 32);
            this.but_import.Name = "but_import";
            this.but_import.Size = new System.Drawing.Size(94, 45);
            this.but_import.TabIndex = 74;
            this.but_import.Text = "导出列表";
            this.but_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_import.ThemeName = "Office2007Silver";
            this.but_import.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.AllowDrop = true;
            this.dgv_01.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowAddNewRow = false;
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.dgv_01.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "灭菌器";
            gridViewTextBoxColumn1.Name = "s_name";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 180;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "批次号";
            gridViewTextBoxColumn2.Name = "batch";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "创建时间";
            gridViewTextBoxColumn3.Name = "s_time";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 180;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "灭菌程序";
            gridViewTextBoxColumn4.Name = "s_program";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 180;
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
            this.dgv_01.Size = new System.Drawing.Size(1115, 527);
            this.dgv_01.TabIndex = 76;
            this.dgv_01.Text = "radGridView1";
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dgv_01_ViewCellFormatting);
            // 
            // HCSRS_set_recall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "HCSRS_set_recall";
            this.Size = new System.Drawing.Size(1115, 646);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sterilizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_printlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_sterilizer;
        private Telerik.WinControls.UI.RadButton but_import;
        private Telerik.WinControls.UI.RadButton but_set;
        private Telerik.WinControls.UI.RadButton but_sterilizer;
        private Telerik.WinControls.UI.RadDateTimePicker dt_end;
        private Telerik.WinControls.UI.RadDateTimePicker dt_start;
        private Telerik.WinControls.UI.RadButton but_printlist;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
