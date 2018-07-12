namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manage_image
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_manage_image));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pic_design = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spmain = new System.Windows.Forms.SplitContainer();
            this.spLeft = new System.Windows.Forms.SplitContainer();
            this.dgv_imageList = new Telerik.WinControls.UI.RadGridView();
            this.spright = new System.Windows.Forms.SplitContainer();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.tb_sort = new Telerik.WinControls.UI.RadTextBox();
            this.but_small = new Telerik.WinControls.UI.RadButton();
            this.but_big = new Telerik.WinControls.UI.RadButton();
            this.but_sort = new Telerik.WinControls.UI.RadButton();
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.lb_sort = new System.Windows.Forms.Label();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_design)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmain)).BeginInit();
            this.spmain.Panel1.SuspendLayout();
            this.spmain.Panel2.SuspendLayout();
            this.spmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spLeft)).BeginInit();
            this.spLeft.Panel1.SuspendLayout();
            this.spLeft.Panel2.SuspendLayout();
            this.spLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_imageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_imageList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spright)).BeginInit();
            this.spright.Panel1.SuspendLayout();
            this.spright.Panel2.SuspendLayout();
            this.spright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_small)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_big)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(939, 701);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.pic_design);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(931, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "预览";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pic_design
            // 
            this.pic_design.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pic_design.Location = new System.Drawing.Point(3, 3);
            this.pic_design.Name = "pic_design";
            this.pic_design.Size = new System.Drawing.Size(580, 341);
            this.pic_design.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_design.TabIndex = 1;
            this.pic_design.TabStop = false;
            this.pic_design.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_design_MouseDown);
            this.pic_design.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_design_MouseMove_1);
            this.pic_design.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_design_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "已有照片：";
            // 
            // spmain
            // 
            this.spmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spmain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.spmain.Location = new System.Drawing.Point(0, 0);
            this.spmain.Name = "spmain";
            // 
            // spmain.Panel1
            // 
            this.spmain.Panel1.AutoScroll = true;
            this.spmain.Panel1.Controls.Add(this.spLeft);
            // 
            // spmain.Panel2
            // 
            this.spmain.Panel2.AutoScroll = true;
            this.spmain.Panel2.Controls.Add(this.spright);
            this.spmain.Size = new System.Drawing.Size(1303, 775);
            this.spmain.SplitterDistance = 360;
            this.spmain.TabIndex = 27;
            // 
            // spLeft
            // 
            this.spLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spLeft.Location = new System.Drawing.Point(0, 0);
            this.spLeft.Name = "spLeft";
            this.spLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spLeft.Panel1
            // 
            this.spLeft.Panel1.Controls.Add(this.label1);
            // 
            // spLeft.Panel2
            // 
            this.spLeft.Panel2.Controls.Add(this.dgv_imageList);
            this.spLeft.Size = new System.Drawing.Size(360, 775);
            this.spLeft.SplitterDistance = 70;
            this.spLeft.TabIndex = 1;
            // 
            // dgv_imageList
            // 
            this.dgv_imageList.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_imageList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_imageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_imageList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_imageList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_imageList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_imageList.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_imageList.MasterTemplate.AllowAddNewRow = false;
            this.dgv_imageList.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_imageList.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "entity_id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "entity_id";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 130;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "图片";
            gridViewTextBoxColumn3.Name = "entity_name";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.HeaderText = "顺序号";
            gridViewTextBoxColumn4.Name = "sort";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.HeaderText = "data_url";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "data_url";
            this.dgv_imageList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgv_imageList.MasterTemplate.MultiSelect = true;
            this.dgv_imageList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_imageList.Name = "dgv_imageList";
            this.dgv_imageList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_imageList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_imageList.ShowGroupPanel = false;
            this.dgv_imageList.Size = new System.Drawing.Size(360, 701);
            this.dgv_imageList.TabIndex = 75;
            this.dgv_imageList.ThemeName = "Office2007Silver";
            this.dgv_imageList.SelectionChanged += new System.EventHandler(this.dgv_imageList_RowStateChanged);
            this.dgv_imageList.RowsChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.dgv_imageList_RowStateChanged);
            // 
            // spright
            // 
            this.spright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spright.Location = new System.Drawing.Point(0, 0);
            this.spright.Name = "spright";
            this.spright.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spright.Panel1
            // 
            this.spright.Panel1.Controls.Add(this.but_cancel);
            this.spright.Panel1.Controls.Add(this.tb_sort);
            this.spright.Panel1.Controls.Add(this.but_small);
            this.spright.Panel1.Controls.Add(this.but_big);
            this.spright.Panel1.Controls.Add(this.but_sort);
            this.spright.Panel1.Controls.Add(this.but_remove);
            this.spright.Panel1.Controls.Add(this.lb_sort);
            // 
            // spright.Panel2
            // 
            this.spright.Panel2.Controls.Add(this.tabControl1);
            this.spright.Size = new System.Drawing.Size(939, 775);
            this.spright.SplitterDistance = 70;
            this.spright.TabIndex = 1;
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(827, 13);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 55;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // tb_sort
            // 
            this.tb_sort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_sort.Location = new System.Drawing.Point(91, 19);
            this.tb_sort.Name = "tb_sort";
            this.tb_sort.Size = new System.Drawing.Size(50, 25);
            this.tb_sort.TabIndex = 2;
            this.tb_sort.Text = "1";
            this.tb_sort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sort.ThemeName = "Office2007Silver";
            this.tb_sort.TextChanged += new System.EventHandler(this.tb_sort_TextChanged);
            this.tb_sort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sort_KeyPress);
            // 
            // but_small
            // 
            this.but_small.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_small.Location = new System.Drawing.Point(283, 13);
            this.but_small.Name = "but_small";
            this.but_small.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_small.Size = new System.Drawing.Size(99, 42);
            this.but_small.TabIndex = 54;
            this.but_small.Text = "缩  小";
            this.but_small.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_small.ThemeName = "Office2007Silver";
            this.but_small.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_big
            // 
            this.but_big.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_big.Location = new System.Drawing.Point(178, 13);
            this.but_big.Name = "but_big";
            this.but_big.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_big.Size = new System.Drawing.Size(99, 42);
            this.but_big.TabIndex = 54;
            this.but_big.Text = "放  大";
            this.but_big.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_big.ThemeName = "Office2007Silver";
            this.but_big.Click += new System.EventHandler(this.but_close_Click);
            // 
            // but_sort
            // 
            this.but_sort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_sort.Location = new System.Drawing.Point(721, 13);
            this.but_sort.Name = "but_sort";
            this.but_sort.Size = new System.Drawing.Size(99, 42);
            this.but_sort.TabIndex = 54;
            this.but_sort.Text = "修改顺序";
            this.but_sort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_sort.ThemeName = "Office2007Silver";
            this.but_sort.Click += new System.EventHandler(this.but_sort_Click);
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_remove.Location = new System.Drawing.Point(616, 13);
            this.but_remove.Name = "but_remove";
            this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 53;
            this.but_remove.Text = "删  除";
            this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // lb_sort
            // 
            this.lb_sort.AutoSize = true;
            this.lb_sort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_sort.Location = new System.Drawing.Point(22, 21);
            this.lb_sort.Name = "lb_sort";
            this.lb_sort.Size = new System.Drawing.Size(73, 20);
            this.lb_sort.TabIndex = 49;
            this.lb_sort.Text = "顺序号：";
            // 
            // open_file
            // 
            this.open_file.Filter = "图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)|*.gif;*.jpg;*.jepg;*bmp;*png";
            this.open_file.FilterIndex = 2;
            this.open_file.Title = "打开图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)";
            // 
            // HCSCM_set_manage_image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1303, 775);
            this.Controls.Add(this.spmain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HCSCM_set_manage_image";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HCSCM_set_manage_image_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_design)).EndInit();
            this.spmain.Panel1.ResumeLayout(false);
            this.spmain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spmain)).EndInit();
            this.spmain.ResumeLayout(false);
            this.spLeft.Panel1.ResumeLayout(false);
            this.spLeft.Panel1.PerformLayout();
            this.spLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spLeft)).EndInit();
            this.spLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_imageList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_imageList)).EndInit();
            this.spright.Panel1.ResumeLayout(false);
            this.spright.Panel1.PerformLayout();
            this.spright.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spright)).EndInit();
            this.spright.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_small)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_big)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pic_design;
        private System.Windows.Forms.SplitContainer spmain;
        private System.Windows.Forms.SplitContainer spLeft;
        private System.Windows.Forms.SplitContainer spright;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.Label lb_sort;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadButton but_small;
        private Telerik.WinControls.UI.RadButton but_big;
        private Telerik.WinControls.UI.RadButton but_sort;
        private Telerik.WinControls.UI.RadTextBox tb_sort;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadGridView dgv_imageList;
    }
}