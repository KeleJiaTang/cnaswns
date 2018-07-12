namespace Cnas.wns.CnasBarcodeLib
{
    partial class Barcode_design
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Barcode_design));
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.tabc_left = new System.Windows.Forms.TabControl();
            this.cms_main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_print = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_dprint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_create = new System.Windows.Forms.ToolStripMenuItem();
            this.tp01 = new System.Windows.Forms.TabPage();
            this.pg_design = new System.Windows.Forms.PropertyGrid();
            this.tp02 = new System.Windows.Forms.TabPage();
            this.pg_barcode = new System.Windows.Forms.PropertyGrid();
            this.gb_right = new System.Windows.Forms.GroupBox();
            this.sp_right = new System.Windows.Forms.SplitContainer();
            this.pan_design = new System.Windows.Forms.Panel();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.gp_info = new System.Windows.Forms.GroupBox();
            this.rtb_xml = new System.Windows.Forms.RichTextBox();
            this.print01 = new System.Drawing.Printing.PrintDocument();
            this.printPD01 = new System.Windows.Forms.PrintPreviewDialog();
            this.printD01 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            this.tabc_left.SuspendLayout();
            this.cms_main.SuspendLayout();
            this.tp01.SuspendLayout();
            this.tp02.SuspendLayout();
            this.gb_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_right)).BeginInit();
            this.sp_right.Panel1.SuspendLayout();
            this.sp_right.Panel2.SuspendLayout();
            this.sp_right.SuspendLayout();
            this.pan_design.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.gp_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.Controls.Add(this.tabc_left);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.gb_right);
            this.sp_main.Size = new System.Drawing.Size(885, 520);
            this.sp_main.SplitterDistance = 230;
            this.sp_main.TabIndex = 0;
            // 
            // tabc_left
            // 
            this.tabc_left.Controls.Add(this.tp01);
            this.tabc_left.Controls.Add(this.tp02);
            this.tabc_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_left.Location = new System.Drawing.Point(0, 0);
            this.tabc_left.Name = "tabc_left";
            this.tabc_left.SelectedIndex = 0;
            this.tabc_left.Size = new System.Drawing.Size(230, 520);
            this.tabc_left.TabIndex = 0;
            // 
            // cms_main
            // 
            this.cms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_add,
            this.tsm_del,
            this.toolStripSeparator1,
            this.tsm_print,
            this.tsm_dprint,
            this.tsm_create});
            this.cms_main.Name = "cms_main";
            this.cms_main.Size = new System.Drawing.Size(125, 120);
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
            // tsm_print
            // 
            this.tsm_print.Name = "tsm_print";
            this.tsm_print.Size = new System.Drawing.Size(124, 22);
            this.tsm_print.Text = "打印预览";
            this.tsm_print.Click += new System.EventHandler(this.tsm_print_Click);
            // 
            // tsm_dprint
            // 
            this.tsm_dprint.Name = "tsm_dprint";
            this.tsm_dprint.Size = new System.Drawing.Size(124, 22);
            this.tsm_dprint.Text = "直接打印";
            this.tsm_dprint.Click += new System.EventHandler(this.tsm_dprint_Click);
            // 
            // tsm_create
            // 
            this.tsm_create.Name = "tsm_create";
            this.tsm_create.Size = new System.Drawing.Size(124, 22);
            this.tsm_create.Text = "生成参数";
            this.tsm_create.Click += new System.EventHandler(this.tsm_create_Click);
            // 
            // tp01
            // 
            this.tp01.Controls.Add(this.pg_design);
            this.tp01.Location = new System.Drawing.Point(4, 22);
            this.tp01.Name = "tp01";
            this.tp01.Padding = new System.Windows.Forms.Padding(3);
            this.tp01.Size = new System.Drawing.Size(222, 494);
            this.tp01.TabIndex = 0;
            this.tp01.Text = "参数设置";
            this.tp01.UseVisualStyleBackColor = true;
            // 
            // pg_design
            // 
            this.pg_design.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_design.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_design.Location = new System.Drawing.Point(3, 3);
            this.pg_design.Name = "pg_design";
            this.pg_design.Size = new System.Drawing.Size(216, 488);
            this.pg_design.TabIndex = 87;
            this.pg_design.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_design_PropertyValueChanged);
            // 
            // tp02
            // 
            this.tp02.Controls.Add(this.pg_barcode);
            this.tp02.Location = new System.Drawing.Point(4, 22);
            this.tp02.Name = "tp02";
            this.tp02.Padding = new System.Windows.Forms.Padding(3);
            this.tp02.Size = new System.Drawing.Size(222, 494);
            this.tp02.TabIndex = 1;
            this.tp02.Text = "其他";
            this.tp02.UseVisualStyleBackColor = true;
            // 
            // pg_barcode
            // 
            this.pg_barcode.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_barcode.Location = new System.Drawing.Point(3, 3);
            this.pg_barcode.Name = "pg_barcode";
            this.pg_barcode.Size = new System.Drawing.Size(216, 488);
            this.pg_barcode.TabIndex = 88;
            this.pg_barcode.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_barcode_PropertyValueChanged);
            // 
            // gb_right
            // 
            this.gb_right.Controls.Add(this.sp_right);
            this.gb_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_right.Location = new System.Drawing.Point(0, 0);
            this.gb_right.Name = "gb_right";
            this.gb_right.Size = new System.Drawing.Size(651, 520);
            this.gb_right.TabIndex = 0;
            this.gb_right.TabStop = false;
            this.gb_right.Text = "设计界面";
            // 
            // sp_right
            // 
            this.sp_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_right.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sp_right.Location = new System.Drawing.Point(3, 17);
            this.sp_right.Name = "sp_right";
            this.sp_right.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_right.Panel1
            // 
            this.sp_right.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sp_right.Panel1.ContextMenuStrip = this.cms_main;
            this.sp_right.Panel1.Controls.Add(this.pan_design);
            // 
            // sp_right.Panel2
            // 
            this.sp_right.Panel2.Controls.Add(this.gp_info);
            this.sp_right.Size = new System.Drawing.Size(645, 500);
            this.sp_right.SplitterDistance = 426;
            this.sp_right.TabIndex = 1;
            // 
            // pan_design
            // 
            this.pan_design.AllowDrop = true;
            this.pan_design.BackColor = System.Drawing.Color.White;
            this.pan_design.ContextMenuStrip = this.cms_main;
            this.pan_design.Controls.Add(this.barcode);
            this.pan_design.Location = new System.Drawing.Point(3, 8);
            this.pan_design.Name = "pan_design";
            this.pan_design.Size = new System.Drawing.Size(400, 250);
            this.pan_design.TabIndex = 0;
            this.pan_design.Click += new System.EventHandler(this.pan_design_Click);
            // 
            // barcode
            // 
            this.barcode.Location = new System.Drawing.Point(53, 41);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(293, 151);
            this.barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.barcode.TabIndex = 0;
            this.barcode.TabStop = false;
            this.barcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barcode_MouseDown);
            this.barcode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barcode_MouseMove);
            this.barcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.barcode_MouseUp);
            // 
            // gp_info
            // 
            this.gp_info.Controls.Add(this.rtb_xml);
            this.gp_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_info.Location = new System.Drawing.Point(0, 0);
            this.gp_info.Name = "gp_info";
            this.gp_info.Size = new System.Drawing.Size(645, 70);
            this.gp_info.TabIndex = 0;
            this.gp_info.TabStop = false;
            this.gp_info.Text = "模版XML";
            // 
            // rtb_xml
            // 
            this.rtb_xml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_xml.Location = new System.Drawing.Point(3, 17);
            this.rtb_xml.Name = "rtb_xml";
            this.rtb_xml.ReadOnly = true;
            this.rtb_xml.Size = new System.Drawing.Size(639, 50);
            this.rtb_xml.TabIndex = 0;
            this.rtb_xml.Text = "";
            // 
            // print01
            // 
            this.print01.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print01_PrintPage);
            // 
            // printPD01
            // 
            this.printPD01.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPD01.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPD01.ClientSize = new System.Drawing.Size(400, 300);
            this.printPD01.Enabled = true;
            this.printPD01.Icon = ((System.Drawing.Icon)(resources.GetObject("printPD01.Icon")));
            this.printPD01.Name = "printPD01";
            this.printPD01.Visible = false;
            // 
            // printD01
            // 
            this.printD01.UseEXDialog = true;
            // 
            // Barcode_design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp_main);
            this.Name = "Barcode_design";
            this.Size = new System.Drawing.Size(885, 520);
            this.Load += new System.EventHandler(this.Barcode_design_Load);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            this.tabc_left.ResumeLayout(false);
            this.cms_main.ResumeLayout(false);
            this.tp01.ResumeLayout(false);
            this.tp02.ResumeLayout(false);
            this.gb_right.ResumeLayout(false);
            this.sp_right.Panel1.ResumeLayout(false);
            this.sp_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_right)).EndInit();
            this.sp_right.ResumeLayout(false);
            this.pan_design.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.gp_info.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.GroupBox gb_right;
        private System.Windows.Forms.Panel pan_design;
        private System.Windows.Forms.TabControl tabc_left;
        private System.Windows.Forms.TabPage tp01;
        private System.Windows.Forms.TabPage tp02;
        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.PropertyGrid pg_design;
        private System.Windows.Forms.PropertyGrid pg_barcode;
        private System.Windows.Forms.ContextMenuStrip cms_main;
        private System.Windows.Forms.ToolStripMenuItem tsm_add;
        private System.Windows.Forms.ToolStripMenuItem tsm_del;
        private System.Windows.Forms.ToolStripMenuItem tsm_create;
        private System.Windows.Forms.SplitContainer sp_right;
        private System.Windows.Forms.GroupBox gp_info;
        private System.Windows.Forms.RichTextBox rtb_xml;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsm_print;
        private System.Drawing.Printing.PrintDocument print01;
        private System.Windows.Forms.ToolStripMenuItem tsm_dprint;
        private System.Windows.Forms.PrintPreviewDialog printPD01;
        private System.Windows.Forms.PrintDialog printD01;
    }
}
