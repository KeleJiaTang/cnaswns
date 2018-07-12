namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_barcode_manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_barcode_manager));
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.but_print = new System.Windows.Forms.Button();
            this.but_refresh = new System.Windows.Forms.Button();
            this.cb_barcode = new System.Windows.Forms.ComboBox();
            this.lab_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabc_main = new System.Windows.Forms.TabControl();
            this.tabp01 = new System.Windows.Forms.TabPage();
            this.tabp02 = new System.Windows.Forms.TabPage();
            this.pic_help = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            this.gp_top.SuspendLayout();
            this.tabc_main.SuspendLayout();
            this.tabp02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
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
            this.sp_main.Panel1.Controls.Add(this.gp_top);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.tabc_main);
            this.sp_main.Size = new System.Drawing.Size(860, 600);
            this.sp_main.SplitterDistance = 90;
            this.sp_main.TabIndex = 0;
            // 
            // gp_top
            // 
            this.gp_top.Controls.Add(this.but_print);
            this.gp_top.Controls.Add(this.but_refresh);
            this.gp_top.Controls.Add(this.cb_barcode);
            this.gp_top.Controls.Add(this.lab_info);
            this.gp_top.Controls.Add(this.label1);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(860, 90);
            this.gp_top.TabIndex = 2;
            this.gp_top.TabStop = false;
            // 
            // but_print
            // 
            this.but_print.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_print.Image = ((System.Drawing.Image)(resources.GetObject("but_print.Image")));
            this.but_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_print.Location = new System.Drawing.Point(637, 20);
            this.but_print.Name = "but_print";
            this.but_print.Size = new System.Drawing.Size(123, 42);
            this.but_print.TabIndex = 71;
            this.but_print.Text = "手动打印";
            this.but_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_print.UseVisualStyleBackColor = true;
            this.but_print.Click += new System.EventHandler(this.but_print_Click);
            // 
            // but_refresh
            // 
            this.but_refresh.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_refresh.Image = ((System.Drawing.Image)(resources.GetObject("but_refresh.Image")));
            this.but_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_refresh.Location = new System.Drawing.Point(508, 20);
            this.but_refresh.Name = "but_refresh";
            this.but_refresh.Size = new System.Drawing.Size(123, 42);
            this.but_refresh.TabIndex = 27;
            this.but_refresh.Text = "重置记录";
            this.but_refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_refresh.UseVisualStyleBackColor = true;
            this.but_refresh.Click += new System.EventHandler(this.but_refresh_Click);
            // 
            // cb_barcode
            // 
            this.cb_barcode.BackColor = System.Drawing.Color.Yellow;
            this.cb_barcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_barcode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_barcode.FormattingEnabled = true;
            this.cb_barcode.Location = new System.Drawing.Point(112, 31);
            this.cb_barcode.Name = "cb_barcode";
            this.cb_barcode.Size = new System.Drawing.Size(251, 23);
            this.cb_barcode.TabIndex = 1;
            this.cb_barcode.SelectedValueChanged += new System.EventHandler(this.cb_barcode_SelectedValueChanged);
            // 
            // lab_info
            // 
            this.lab_info.AutoSize = true;
            this.lab_info.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_info.Location = new System.Drawing.Point(6, 0);
            this.lab_info.Name = "lab_info";
            this.lab_info.Size = new System.Drawing.Size(160, 16);
            this.lab_info.TabIndex = 1;
            this.lab_info.Text = "条形码管理-->主窗口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码类型：";
            // 
            // tabc_main
            // 
            this.tabc_main.Controls.Add(this.tabp01);
            this.tabc_main.Controls.Add(this.tabp02);
            this.tabc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_main.Location = new System.Drawing.Point(0, 0);
            this.tabc_main.Name = "tabc_main";
            this.tabc_main.SelectedIndex = 0;
            this.tabc_main.Size = new System.Drawing.Size(860, 506);
            this.tabc_main.TabIndex = 2;
            // 
            // tabp01
            // 
            this.tabp01.AutoScroll = true;
            this.tabp01.BackColor = System.Drawing.SystemColors.Window;
            this.tabp01.Location = new System.Drawing.Point(4, 25);
            this.tabp01.Name = "tabp01";
            this.tabp01.Padding = new System.Windows.Forms.Padding(3);
            this.tabp01.Size = new System.Drawing.Size(852, 477);
            this.tabp01.TabIndex = 0;
            this.tabp01.Text = "条码设计器";
            // 
            // tabp02
            // 
            this.tabp02.Controls.Add(this.pic_help);
            this.tabp02.Location = new System.Drawing.Point(4, 25);
            this.tabp02.Name = "tabp02";
            this.tabp02.Padding = new System.Windows.Forms.Padding(3);
            this.tabp02.Size = new System.Drawing.Size(852, 477);
            this.tabp02.TabIndex = 1;
            this.tabp02.Text = "帮助";
            this.tabp02.UseVisualStyleBackColor = true;
            // 
            // pic_help
            // 
            this.pic_help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_help.Location = new System.Drawing.Point(3, 3);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(846, 471);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_help.TabIndex = 0;
            this.pic_help.TabStop = false;
            // 
            // HCSSM_barcode_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.sp_main);
            this.Name = "HCSSM_barcode_manager";
            this.Size = new System.Drawing.Size(860, 600);
            this.Load += new System.EventHandler(this.HCSSM_barcode_manager_Load);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            this.tabc_main.ResumeLayout(false);
            this.tabp02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.ComboBox cb_barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gp_top;
        private System.Windows.Forms.Label lab_info;
        private System.Windows.Forms.Button but_refresh;
        private System.Windows.Forms.TabControl tabc_main;
        private System.Windows.Forms.TabPage tabp01;
        private System.Windows.Forms.TabPage tabp02;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.Button but_print;
    }
}
