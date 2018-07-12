namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_image
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_image));
			this.tsm_save = new System.Windows.Forms.ToolStripMenuItem();
			this.tsm_view = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lab_03 = new System.Windows.Forms.Label();
			this.lab_02 = new System.Windows.Forms.Label();
			this.lab_01 = new System.Windows.Forms.Label();
			this.tsm_del = new System.Windows.Forms.ToolStripMenuItem();
			this.tsm_add = new System.Windows.Forms.ToolStripMenuItem();
			this.cb_app = new System.Windows.Forms.ComboBox();
			this.tabc_right = new System.Windows.Forms.TabControl();
			this.tabp01 = new System.Windows.Forms.TabPage();
			this.cms_main = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.prictureDesign = new System.Windows.Forms.PictureBox();
			this.tabp02 = new System.Windows.Forms.TabPage();
			this.PrictureView = new System.Windows.Forms.PictureBox();
			this.gp_top = new System.Windows.Forms.GroupBox();
			this.but_save = new Telerik.WinControls.UI.RadButton();
			this.but_phone = new Telerik.WinControls.UI.RadButton();
			this.tb_search = new Telerik.WinControls.UI.RadTextBox();
			this.sp_right = new System.Windows.Forms.SplitContainer();
			this.pg_design = new System.Windows.Forms.PropertyGrid();
			this.sp_main = new System.Windows.Forms.SplitContainer();
			this.tabc_right.SuspendLayout();
			this.tabp01.SuspendLayout();
			this.cms_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.prictureDesign)).BeginInit();
			this.tabp02.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrictureView)).BeginInit();
			this.gp_top.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_phone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_search)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sp_right)).BeginInit();
			this.sp_right.Panel1.SuspendLayout();
			this.sp_right.Panel2.SuspendLayout();
			this.sp_right.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
			this.sp_main.Panel1.SuspendLayout();
			this.sp_main.Panel2.SuspendLayout();
			this.sp_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// tsm_save
			// 
			this.tsm_save.Name = "tsm_save";
			this.tsm_save.Size = new System.Drawing.Size(124, 22);
			this.tsm_save.Text = "保存图片";
			this.tsm_save.Click += new System.EventHandler(this.tsm_save_Click);
			// 
			// tsm_view
			// 
			this.tsm_view.Name = "tsm_view";
			this.tsm_view.Size = new System.Drawing.Size(124, 22);
			this.tsm_view.Text = "图片预览";
			this.tsm_view.Click += new System.EventHandler(this.tsm_view_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
			// 
			// lab_03
			// 
			this.lab_03.AutoSize = true;
			this.lab_03.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lab_03.ForeColor = System.Drawing.Color.Red;
			this.lab_03.Location = new System.Drawing.Point(308, 17);
			this.lab_03.Name = "lab_03";
			this.lab_03.Size = new System.Drawing.Size(0, 12);
			this.lab_03.TabIndex = 14;
			// 
			// lab_02
			// 
			this.lab_02.AutoSize = true;
			this.lab_02.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lab_02.Location = new System.Drawing.Point(220, 14);
			this.lab_02.Name = "lab_02";
			this.lab_02.Size = new System.Drawing.Size(57, 20);
			this.lab_02.TabIndex = 12;
			this.lab_02.Text = "条码：";
			// 
			// lab_01
			// 
			this.lab_01.AutoSize = true;
			this.lab_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.lab_01.Location = new System.Drawing.Point(6, 14);
			this.lab_01.Name = "lab_01";
			this.lab_01.Size = new System.Drawing.Size(89, 20);
			this.lab_01.TabIndex = 11;
			this.lab_01.Text = "图片大小：";
			// 
			// tsm_del
			// 
			this.tsm_del.Name = "tsm_del";
			this.tsm_del.Size = new System.Drawing.Size(124, 22);
			this.tsm_del.Text = "删除参数";
			this.tsm_del.Click += new System.EventHandler(this.tsm_del_Click);
			// 
			// tsm_add
			// 
			this.tsm_add.Name = "tsm_add";
			this.tsm_add.Size = new System.Drawing.Size(124, 22);
			this.tsm_add.Text = "添加参数";
			this.tsm_add.Click += new System.EventHandler(this.tsm_add_Click);
			// 
			// cb_app
			// 
			this.cb_app.BackColor = System.Drawing.Color.Yellow;
			this.cb_app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_app.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_app.FormattingEnabled = true;
			this.cb_app.Items.AddRange(new object[] {
            "1280x720",
            "800x600",
            "720x540",
            "640x480",
            "560x420",
            "480x360",
            "320x240"});
			this.cb_app.Location = new System.Drawing.Point(8, 38);
			this.cb_app.Name = "cb_app";
			this.cb_app.Size = new System.Drawing.Size(198, 28);
			this.cb_app.TabIndex = 10;
			this.cb_app.SelectedValueChanged += new System.EventHandler(this.cb_app_SelectedValueChanged);
			// 
			// tabc_right
			// 
			this.tabc_right.Controls.Add(this.tabp01);
			this.tabc_right.Controls.Add(this.tabp02);
			this.tabc_right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabc_right.Location = new System.Drawing.Point(0, 0);
			this.tabc_right.Name = "tabc_right";
			this.tabc_right.SelectedIndex = 0;
			this.tabc_right.Size = new System.Drawing.Size(947, 621);
			this.tabc_right.TabIndex = 0;
			this.tabc_right.SelectedIndexChanged += new System.EventHandler(this.tabc_right_SelectedIndexChanged);
			// 
			// tabp01
			// 
			this.tabp01.AutoScroll = true;
			this.tabp01.BackColor = System.Drawing.SystemColors.Window;
			this.tabp01.ContextMenuStrip = this.cms_main;
			this.tabp01.Controls.Add(this.prictureDesign);
			this.tabp01.Location = new System.Drawing.Point(4, 29);
			this.tabp01.Name = "tabp01";
			this.tabp01.Padding = new System.Windows.Forms.Padding(3);
			this.tabp01.Size = new System.Drawing.Size(939, 588);
			this.tabp01.TabIndex = 0;
			this.tabp01.Text = "图片设计";
			// 
			// cms_main
			// 
			this.cms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_add,
            this.tsm_del,
            this.toolStripSeparator1,
            this.tsm_view,
            this.tsm_save});
			this.cms_main.Name = "cms_main";
			this.cms_main.Size = new System.Drawing.Size(125, 98);
			// 
			// prictureDesign
			// 
			this.prictureDesign.BackColor = System.Drawing.SystemColors.Window;
			this.prictureDesign.Location = new System.Drawing.Point(3, 6);
			this.prictureDesign.Name = "prictureDesign";
			this.prictureDesign.Size = new System.Drawing.Size(580, 341);
			this.prictureDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.prictureDesign.TabIndex = 0;
			this.prictureDesign.TabStop = false;
			this.prictureDesign.Click += new System.EventHandler(this.pic_design_Click);
			this.prictureDesign.Resize += new System.EventHandler(this.pic_design_Resize);
			// 
			// tabp02
			// 
			this.tabp02.BackColor = System.Drawing.SystemColors.Window;
			this.tabp02.Controls.Add(this.PrictureView);
			this.tabp02.Location = new System.Drawing.Point(4, 29);
			this.tabp02.Name = "tabp02";
			this.tabp02.Padding = new System.Windows.Forms.Padding(3);
			this.tabp02.Size = new System.Drawing.Size(939, 588);
			this.tabp02.TabIndex = 1;
			this.tabp02.Text = "预览";
			// 
			// PrictureView
			// 
			this.PrictureView.Location = new System.Drawing.Point(4, 6);
			this.PrictureView.Name = "PrictureView";
			this.PrictureView.Size = new System.Drawing.Size(100, 50);
			this.PrictureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PrictureView.TabIndex = 0;
			this.PrictureView.TabStop = false;
			// 
			// gp_top
			// 
			this.gp_top.Controls.Add(this.but_save);
			this.gp_top.Controls.Add(this.but_phone);
			this.gp_top.Controls.Add(this.tb_search);
			this.gp_top.Controls.Add(this.lab_03);
			this.gp_top.Controls.Add(this.cb_app);
			this.gp_top.Controls.Add(this.lab_01);
			this.gp_top.Controls.Add(this.lab_02);
			this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gp_top.Location = new System.Drawing.Point(0, 0);
			this.gp_top.Name = "gp_top";
			this.gp_top.Size = new System.Drawing.Size(947, 75);
			this.gp_top.TabIndex = 0;
			this.gp_top.TabStop = false;
			// 
			// but_save
			// 
			this.but_save.Location = new System.Drawing.Point(836, 23);
			this.but_save.Name = "but_save";
			this.but_save.Size = new System.Drawing.Size(99, 42);
			this.but_save.TabIndex = 18;
			this.but_save.Text = "保存图片";
			this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_save.ThemeName = "Office2007Silver";
			this.but_save.Click += new System.EventHandler(this.tsm_save_Click);
			// 
			// but_phone
			// 
			this.but_phone.Location = new System.Drawing.Point(731, 23);
			this.but_phone.Name = "but_phone";
			this.but_phone.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_phone.Size = new System.Drawing.Size(99, 42);
			this.but_phone.TabIndex = 19;
			this.but_phone.Text = "拍  照";
			this.but_phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_phone.ThemeName = "Office2007Silver";
			this.but_phone.Click += new System.EventHandler(this.but_photo_Click);
			// 
			// tb_search
			// 
			this.tb_search.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tb_search.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_search.Location = new System.Drawing.Point(224, 39);
			this.tb_search.Name = "tb_search";
			this.tb_search.ReadOnly = true;
			this.tb_search.Size = new System.Drawing.Size(224, 25);
			this.tb_search.TabIndex = 17;
			this.tb_search.ThemeName = "Office2007Silver";
			// 
			// sp_right
			// 
			this.sp_right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sp_right.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.sp_right.Location = new System.Drawing.Point(0, 0);
			this.sp_right.Name = "sp_right";
			this.sp_right.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sp_right.Panel1
			// 
			this.sp_right.Panel1.Controls.Add(this.gp_top);
			// 
			// sp_right.Panel2
			// 
			this.sp_right.Panel2.Controls.Add(this.tabc_right);
			this.sp_right.Size = new System.Drawing.Size(947, 700);
			this.sp_right.SplitterDistance = 75;
			this.sp_right.TabIndex = 0;
			// 
			// pg_design
			// 
			this.pg_design.BackColor = System.Drawing.SystemColors.Window;
			this.pg_design.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.pg_design.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pg_design.HelpBackColor = System.Drawing.SystemColors.Window;
			this.pg_design.Location = new System.Drawing.Point(0, 0);
			this.pg_design.Name = "pg_design";
			this.pg_design.Size = new System.Drawing.Size(178, 700);
			this.pg_design.TabIndex = 0;
			this.pg_design.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_design_PropertyValueChanged);
			// 
			// sp_main
			// 
			this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.sp_main.Location = new System.Drawing.Point(0, 0);
			this.sp_main.Name = "sp_main";
			// 
			// sp_main.Panel1
			// 
			this.sp_main.Panel1.Controls.Add(this.pg_design);
			// 
			// sp_main.Panel2
			// 
			this.sp_main.Panel2.Controls.Add(this.sp_right);
			this.sp_main.Size = new System.Drawing.Size(1129, 700);
			this.sp_main.SplitterDistance = 178;
			this.sp_main.TabIndex = 1;
			// 
			// HCSCM_set_image
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1129, 700);
			this.Controls.Add(this.sp_main);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "HCSCM_set_image";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.HCSCM_pack_image_Load);
			this.tabc_right.ResumeLayout(false);
			this.tabp01.ResumeLayout(false);
			this.cms_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.prictureDesign)).EndInit();
			this.tabp02.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PrictureView)).EndInit();
			this.gp_top.ResumeLayout(false);
			this.gp_top.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_phone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_search)).EndInit();
			this.sp_right.Panel1.ResumeLayout(false);
			this.sp_right.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp_right)).EndInit();
			this.sp_right.ResumeLayout(false);
			this.sp_main.Panel1.ResumeLayout(false);
			this.sp_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
			this.sp_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ToolStripMenuItem tsm_save;
        private System.Windows.Forms.ToolStripMenuItem tsm_view;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lab_03;
        private System.Windows.Forms.Label lab_02;
        private System.Windows.Forms.Label lab_01;
        private System.Windows.Forms.ToolStripMenuItem tsm_del;
        private System.Windows.Forms.ToolStripMenuItem tsm_add;
        private System.Windows.Forms.ComboBox cb_app;
        private System.Windows.Forms.TabControl tabc_right;
        private System.Windows.Forms.TabPage tabp01;
        private System.Windows.Forms.ContextMenuStrip cms_main;
        private System.Windows.Forms.TabPage tabp02;
        private System.Windows.Forms.GroupBox gp_top;
        private System.Windows.Forms.SplitContainer sp_right;
        private System.Windows.Forms.PropertyGrid pg_design;
        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadButton but_phone;
		private Telerik.WinControls.UI.RadTextBox tb_search;
		public System.Windows.Forms.PictureBox PrictureView;
		private System.Windows.Forms.PictureBox prictureDesign;
    }
}