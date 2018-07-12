namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_image_batch
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pic_design = new System.Windows.Forms.PictureBox();
			this.dgv_imageList = new System.Windows.Forms.DataGridView();
			this.entity_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entity_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.data_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.spmain = new System.Windows.Forms.SplitContainer();
			this.spLeft = new System.Windows.Forms.SplitContainer();
			this.spright = new System.Windows.Forms.SplitContainer();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_save = new Telerik.WinControls.UI.RadButton();
			this.but_remove = new Telerik.WinControls.UI.RadButton();
			this.but_imput = new Telerik.WinControls.UI.RadButton();
			this.open_file = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_design)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_imageList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spmain)).BeginInit();
			this.spmain.Panel1.SuspendLayout();
			this.spmain.Panel2.SuspendLayout();
			this.spmain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spLeft)).BeginInit();
			this.spLeft.Panel1.SuspendLayout();
			this.spLeft.Panel2.SuspendLayout();
			this.spLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spright)).BeginInit();
			this.spright.Panel1.SuspendLayout();
			this.spright.Panel2.SuspendLayout();
			this.spright.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_imput)).BeginInit();
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
			this.tabControl1.Size = new System.Drawing.Size(650, 627);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.pic_design);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(642, 594);
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
			this.pic_design.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic_design.TabIndex = 1;
			this.pic_design.TabStop = false;
			// 
			// dgv_imageList
			// 
			this.dgv_imageList.AllowUserToAddRows = false;
			this.dgv_imageList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
			this.dgv_imageList.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_imageList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgv_imageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_imageList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entity_id,
            this.entity_name,
            this.data_url});
			this.dgv_imageList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_imageList.Location = new System.Drawing.Point(0, 0);
			this.dgv_imageList.MultiSelect = false;
			this.dgv_imageList.Name = "dgv_imageList";
			this.dgv_imageList.ReadOnly = true;
			this.dgv_imageList.RowHeadersVisible = false;
			this.dgv_imageList.RowTemplate.Height = 23;
			this.dgv_imageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_imageList.Size = new System.Drawing.Size(360, 627);
			this.dgv_imageList.TabIndex = 0;
			this.dgv_imageList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_imageList_RowStateChanged);
			// 
			// entity_id
			// 
			this.entity_id.HeaderText = "entity_id";
			this.entity_id.Name = "entity_id";
			this.entity_id.ReadOnly = true;
			this.entity_id.Visible = false;
			this.entity_id.Width = 200;
			// 
			// entity_name
			// 
			this.entity_name.HeaderText = "图片名称";
			this.entity_name.Name = "entity_name";
			this.entity_name.ReadOnly = true;
			this.entity_name.Width = 320;
			// 
			// data_url
			// 
			this.data_url.HeaderText = "data_url";
			this.data_url.Name = "data_url";
			this.data_url.ReadOnly = true;
			this.data_url.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.label1.Location = new System.Drawing.Point(12, 42);
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
			this.spmain.Size = new System.Drawing.Size(1014, 692);
			this.spmain.SplitterDistance = 360;
			this.spmain.TabIndex = 28;
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
			this.spLeft.Size = new System.Drawing.Size(360, 692);
			this.spLeft.SplitterDistance = 61;
			this.spLeft.TabIndex = 1;
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
			this.spright.Panel1.Controls.Add(this.but_save);
			this.spright.Panel1.Controls.Add(this.but_remove);
			this.spright.Panel1.Controls.Add(this.but_imput);
			// 
			// spright.Panel2
			// 
			this.spright.Panel2.Controls.Add(this.tabControl1);
			this.spright.Size = new System.Drawing.Size(650, 692);
			this.spright.SplitterDistance = 61;
			this.spright.TabIndex = 1;
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(539, 9);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 53;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_save
			// 
			this.but_save.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_save.Location = new System.Drawing.Point(217, 9);
			this.but_save.Name = "but_save";
			this.but_save.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_save.Size = new System.Drawing.Size(99, 42);
			this.but_save.TabIndex = 52;
			this.but_save.Text = "保  存";
			this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_save.ThemeName = "Office2007Silver";
			this.but_save.Click += new System.EventHandler(this.but_save_Click);
			// 
			// but_remove
			// 
			this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_remove.Location = new System.Drawing.Point(112, 9);
			this.but_remove.Name = "but_remove";
			this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_remove.Size = new System.Drawing.Size(99, 42);
			this.but_remove.TabIndex = 51;
			this.but_remove.Text = "删  除";
			this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_remove.ThemeName = "Office2007Silver";
			this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
			// 
			// but_imput
			// 
			this.but_imput.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_imput.Location = new System.Drawing.Point(7, 9);
			this.but_imput.Name = "but_imput";
			this.but_imput.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_imput.Size = new System.Drawing.Size(99, 42);
			this.but_imput.TabIndex = 50;
			this.but_imput.Text = "导  入";
			this.but_imput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_imput.ThemeName = "Office2007Silver";
			this.but_imput.Click += new System.EventHandler(this.but_imput_Click);
			// 
			// open_file
			// 
			this.open_file.Filter = "图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)|*.gif;*.jpg;*.jepg;*bmp;*png";
			this.open_file.FilterIndex = 2;
			this.open_file.Title = "打开图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)";
			// 
			// HCSCM_set_image_batch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1014, 692);
			this.Controls.Add(this.spmain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "HCSCM_set_image_batch";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HCSCM_set_image_batch";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic_design)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_imageList)).EndInit();
			this.spmain.Panel1.ResumeLayout(false);
			this.spmain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spmain)).EndInit();
			this.spmain.ResumeLayout(false);
			this.spLeft.Panel1.ResumeLayout(false);
			this.spLeft.Panel1.PerformLayout();
			this.spLeft.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spLeft)).EndInit();
			this.spLeft.ResumeLayout(false);
			this.spright.Panel1.ResumeLayout(false);
			this.spright.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spright)).EndInit();
			this.spright.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_imput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pic_design;
        private System.Windows.Forms.DataGridView dgv_imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer spmain;
        private System.Windows.Forms.SplitContainer spLeft;
        private System.Windows.Forms.SplitContainer spright;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.DataGridViewTextBoxColumn entity_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn entity_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_url;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadButton but_imput;
        private Telerik.WinControls.UI.RadButton but_cancel;


    }
}