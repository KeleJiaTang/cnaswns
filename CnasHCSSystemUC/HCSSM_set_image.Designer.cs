namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_set_image
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_set_image));
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.pg_design = new System.Windows.Forms.PropertyGrid();
            this.sp_right = new System.Windows.Forms.SplitContainer();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.but_photo = new System.Windows.Forms.Button();
            this.lab_03 = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.lab_02 = new System.Windows.Forms.Label();
            this.lab_01 = new System.Windows.Forms.Label();
            this.cb_app = new System.Windows.Forms.ComboBox();
            this.tabc_right = new System.Windows.Forms.TabControl();
            this.tabp01 = new System.Windows.Forms.TabPage();
            this.cms_main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_view = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_save = new System.Windows.Forms.ToolStripMenuItem();
            this.pic_design = new System.Windows.Forms.PictureBox();
            this.tabp02 = new System.Windows.Forms.TabPage();
            this.pic_view = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_right)).BeginInit();
            this.sp_right.Panel1.SuspendLayout();
            this.sp_right.Panel2.SuspendLayout();
            this.sp_right.SuspendLayout();
            this.gp_top.SuspendLayout();
            this.tabc_right.SuspendLayout();
            this.tabp01.SuspendLayout();
            this.cms_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_design)).BeginInit();
            this.tabp02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_view)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.sp_main.Size = new System.Drawing.Size(800, 600);
            this.sp_main.SplitterDistance = 170;
            this.sp_main.TabIndex = 0;
            // 
            // pg_design
            // 
            this.pg_design.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_design.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_design.Location = new System.Drawing.Point(0, 0);
            this.pg_design.Name = "pg_design";
            this.pg_design.Size = new System.Drawing.Size(170, 600);
            this.pg_design.TabIndex = 0;
            this.pg_design.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_design_PropertyValueChanged);
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
            this.sp_right.Size = new System.Drawing.Size(626, 600);
            this.sp_right.SplitterDistance = 70;
            this.sp_right.TabIndex = 0;
            // 
            // gp_top
            // 
            this.gp_top.Controls.Add(this.but_photo);
            this.gp_top.Controls.Add(this.lab_03);
            this.gp_top.Controls.Add(this.tb_search);
            this.gp_top.Controls.Add(this.lab_02);
            this.gp_top.Controls.Add(this.lab_01);
            this.gp_top.Controls.Add(this.cb_app);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(626, 70);
            this.gp_top.TabIndex = 0;
            this.gp_top.TabStop = false;
            // 
            // but_photo
            // 
            this.but_photo.Image = ((System.Drawing.Image)(resources.GetObject("but_photo.Image")));
            this.but_photo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_photo.Location = new System.Drawing.Point(509, 17);
            this.but_photo.Name = "but_photo";
            this.but_photo.Size = new System.Drawing.Size(99, 42);
            this.but_photo.TabIndex = 15;
            this.but_photo.Text = "拍照 ";
            this.but_photo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_photo.UseVisualStyleBackColor = true;
            this.but_photo.Click += new System.EventHandler(this.but_photo_Click);
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
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(251, 34);
            this.tb_search.Name = "tb_search";
            this.tb_search.ReadOnly = true;
            this.tb_search.Size = new System.Drawing.Size(226, 24);
            this.tb_search.TabIndex = 13;
            // 
            // lab_02
            // 
            this.lab_02.AutoSize = true;
            this.lab_02.Location = new System.Drawing.Point(249, 14);
            this.lab_02.Name = "lab_02";
            this.lab_02.Size = new System.Drawing.Size(67, 15);
            this.lab_02.TabIndex = 12;
            this.lab_02.Text = "包条码：";
            // 
            // lab_01
            // 
            this.lab_01.AutoSize = true;
            this.lab_01.Location = new System.Drawing.Point(7, 15);
            this.lab_01.Name = "lab_01";
            this.lab_01.Size = new System.Drawing.Size(82, 15);
            this.lab_01.TabIndex = 11;
            this.lab_01.Text = "图片大小：";
            // 
            // cb_app
            // 
            this.cb_app.BackColor = System.Drawing.Color.Yellow;
            this.cb_app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_app.FormattingEnabled = true;
            this.cb_app.Items.AddRange(new object[] {
            "1280x720",
            "800x600",
            "720x540",
            "640x480",
            "560x420",
            "480x360",
            "320x240"});
            this.cb_app.Location = new System.Drawing.Point(8, 35);
            this.cb_app.Name = "cb_app";
            this.cb_app.Size = new System.Drawing.Size(198, 23);
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
            this.tabc_right.Size = new System.Drawing.Size(626, 526);
            this.tabc_right.TabIndex = 0;
            // 
            // tabp01
            // 
            this.tabp01.AutoScroll = true;
            this.tabp01.BackColor = System.Drawing.SystemColors.Window;
            this.tabp01.ContextMenuStrip = this.cms_main;
            this.tabp01.Controls.Add(this.pic_design);
            this.tabp01.Location = new System.Drawing.Point(4, 25);
            this.tabp01.Name = "tabp01";
            this.tabp01.Padding = new System.Windows.Forms.Padding(3);
            this.tabp01.Size = new System.Drawing.Size(618, 497);
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
            // tsm_add
            // 
            this.tsm_add.Name = "tsm_add";
            this.tsm_add.Size = new System.Drawing.Size(124, 22);
            this.tsm_add.Text = "添加参数";
            this.tsm_add.Click += new System.EventHandler(this.tsm_add_Click);
            // 
            // tsm_del
            // 
            this.tsm_del.Name = "tsm_del";
            this.tsm_del.Size = new System.Drawing.Size(124, 22);
            this.tsm_del.Text = "删除参数";
            this.tsm_del.Click += new System.EventHandler(this.tsm_del_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsm_view
            // 
            this.tsm_view.Name = "tsm_view";
            this.tsm_view.Size = new System.Drawing.Size(124, 22);
            this.tsm_view.Text = "图片预览";
            this.tsm_view.Click += new System.EventHandler(this.tsm_view_Click);
            // 
            // tsm_save
            // 
            this.tsm_save.Name = "tsm_save";
            this.tsm_save.Size = new System.Drawing.Size(124, 22);
            this.tsm_save.Text = "保存图片";
            this.tsm_save.Click += new System.EventHandler(this.tsm_save_Click);
            // 
            // pic_design
            // 
            this.pic_design.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pic_design.Location = new System.Drawing.Point(3, 6);
            this.pic_design.Name = "pic_design";
            this.pic_design.Size = new System.Drawing.Size(580, 341);
            this.pic_design.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_design.TabIndex = 0;
            this.pic_design.TabStop = false;
            this.pic_design.Click += new System.EventHandler(this.pic_design_Click);
            this.pic_design.Resize += new System.EventHandler(this.pic_design_Resize);
            // 
            // tabp02
            // 
            this.tabp02.BackColor = System.Drawing.Color.DarkGray;
            this.tabp02.Controls.Add(this.pic_view);
            this.tabp02.Location = new System.Drawing.Point(4, 25);
            this.tabp02.Name = "tabp02";
            this.tabp02.Padding = new System.Windows.Forms.Padding(3);
            this.tabp02.Size = new System.Drawing.Size(618, 497);
            this.tabp02.TabIndex = 1;
            this.tabp02.Text = "预览";
            // 
            // pic_view
            // 
            this.pic_view.Location = new System.Drawing.Point(4, 6);
            this.pic_view.Name = "pic_view";
            this.pic_view.Size = new System.Drawing.Size(100, 50);
            this.pic_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_view.TabIndex = 0;
            this.pic_view.TabStop = false;
            // 
            // HCSSM_set_image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.sp_main);
            this.Name = "HCSSM_set_image";
            this.Size = new System.Drawing.Size(800, 600);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            this.sp_right.Panel1.ResumeLayout(false);
            this.sp_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_right)).EndInit();
            this.sp_right.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            this.tabc_right.ResumeLayout(false);
            this.tabp01.ResumeLayout(false);
            this.cms_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_design)).EndInit();
            this.tabp02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.PropertyGrid pg_design;
        private System.Windows.Forms.SplitContainer sp_right;
        private System.Windows.Forms.GroupBox gp_top;
        private System.Windows.Forms.Label lab_02;
        private System.Windows.Forms.Label lab_01;
        private System.Windows.Forms.ComboBox cb_app;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label lab_03;
        private System.Windows.Forms.TabControl tabc_right;
        private System.Windows.Forms.TabPage tabp01;
        private System.Windows.Forms.TabPage tabp02;
        private System.Windows.Forms.PictureBox pic_view;
        private System.Windows.Forms.Button but_photo;
        private System.Windows.Forms.ContextMenuStrip cms_main;
        private System.Windows.Forms.ToolStripMenuItem tsm_add;
        private System.Windows.Forms.ToolStripMenuItem tsm_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsm_view;
        private System.Windows.Forms.ToolStripMenuItem tsm_save;
        private System.Windows.Forms.PictureBox pic_design;
    }
}
