namespace Cnas.wns.CnasHCSWorkspaceSterilization
{
    partial class HCSSM_parameters_select
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
            this.met_right = new Cnas.wns.CnasMetroFramework.Controls.MetroTabControl();
            this.tabp_11 = new System.Windows.Forms.TabPage();
            this.sp_01 = new System.Windows.Forms.SplitContainer();
            this.gp_01 = new System.Windows.Forms.GroupBox();
            this.mlab_next = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.gp_02 = new System.Windows.Forms.GroupBox();
            this.mett_03 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.mett_02 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.mett_01 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.tex_remark = new System.Windows.Forms.TextBox();
            this.ml_13 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.mcb_result = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
            this.ml_12 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.tabp_12 = new System.Windows.Forms.TabPage();
            this.met_right.SuspendLayout();
            this.tabp_11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_01)).BeginInit();
            this.sp_01.Panel1.SuspendLayout();
            this.sp_01.Panel2.SuspendLayout();
            this.sp_01.SuspendLayout();
            this.gp_01.SuspendLayout();
            this.gp_02.SuspendLayout();
            this.SuspendLayout();
            // 
            // met_right
            // 
            this.met_right.Controls.Add(this.tabp_11);
            this.met_right.Controls.Add(this.tabp_12);
            this.met_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.met_right.Location = new System.Drawing.Point(20, 60);
            this.met_right.Name = "met_right";
            this.met_right.SelectedIndex = 0;
            this.met_right.Size = new System.Drawing.Size(760, 520);
            this.met_right.TabIndex = 1;
            this.met_right.UseSelectable = true;
            // 
            // tabp_11
            // 
            this.tabp_11.BackColor = System.Drawing.Color.Transparent;
            this.tabp_11.Controls.Add(this.sp_01);
            this.tabp_11.Location = new System.Drawing.Point(4, 39);
            this.tabp_11.Name = "tabp_11";
            this.tabp_11.Size = new System.Drawing.Size(752, 477);
            this.tabp_11.TabIndex = 0;
            this.tabp_11.Text = "处理选择";
            // 
            // sp_01
            // 
            this.sp_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_01.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_01.Location = new System.Drawing.Point(0, 0);
            this.sp_01.Name = "sp_01";
            this.sp_01.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_01.Panel1
            // 
            this.sp_01.Panel1.Controls.Add(this.gp_01);
            // 
            // sp_01.Panel2
            // 
            this.sp_01.Panel2.Controls.Add(this.gp_02);
            this.sp_01.Size = new System.Drawing.Size(752, 477);
            this.sp_01.SplitterDistance = 159;
            this.sp_01.TabIndex = 0;
            // 
            // gp_01
            // 
            this.gp_01.Controls.Add(this.mlab_next);
            this.gp_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_01.Location = new System.Drawing.Point(0, 0);
            this.gp_01.Name = "gp_01";
            this.gp_01.Size = new System.Drawing.Size(752, 159);
            this.gp_01.TabIndex = 1;
            this.gp_01.TabStop = false;
            // 
            // mlab_next
            // 
            this.mlab_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlab_next.FontSize = Cnas.wns.CnasMetroFramework.MetroLabelSize.Tall;
            this.mlab_next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mlab_next.Location = new System.Drawing.Point(3, 17);
            this.mlab_next.Name = "mlab_next";
            this.mlab_next.Size = new System.Drawing.Size(746, 139);
            this.mlab_next.TabIndex = 2;
            this.mlab_next.Text = "请选择有问题包的类型? 1-少器械；2-多器械；3-器械损坏";
            this.mlab_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mlab_next.UseCustomForeColor = true;
            // 
            // gp_02
            // 
            this.gp_02.Controls.Add(this.mett_03);
            this.gp_02.Controls.Add(this.mett_02);
            this.gp_02.Controls.Add(this.mett_01);
            this.gp_02.Controls.Add(this.tex_remark);
            this.gp_02.Controls.Add(this.ml_13);
            this.gp_02.Controls.Add(this.mcb_result);
            this.gp_02.Controls.Add(this.ml_12);
            this.gp_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_02.Location = new System.Drawing.Point(0, 0);
            this.gp_02.Name = "gp_02";
            this.gp_02.Size = new System.Drawing.Size(752, 314);
            this.gp_02.TabIndex = 2;
            this.gp_02.TabStop = false;
            // 
            // mett_03
            // 
            this.mett_03.ActiveControl = null;
            this.mett_03.Location = new System.Drawing.Point(504, 204);
            this.mett_03.Name = "mett_03";
            this.mett_03.Size = new System.Drawing.Size(230, 80);
            this.mett_03.TabIndex = 13;
            this.mett_03.Text = "确定选择";
            this.mett_03.UseSelectable = true;
            this.mett_03.Click += new System.EventHandler(this.mett_03_Click);
            // 
            // mett_02
            // 
            this.mett_02.ActiveControl = null;
            this.mett_02.Location = new System.Drawing.Point(627, 113);
            this.mett_02.Name = "mett_02";
            this.mett_02.Size = new System.Drawing.Size(107, 75);
            this.mett_02.TabIndex = 12;
            this.mett_02.Text = "退出";
            this.mett_02.UseSelectable = true;
            this.mett_02.Click += new System.EventHandler(this.mett_02_Click);
            // 
            // mett_01
            // 
            this.mett_01.ActiveControl = null;
            this.mett_01.Location = new System.Drawing.Point(504, 113);
            this.mett_01.Name = "mett_01";
            this.mett_01.Size = new System.Drawing.Size(108, 75);
            this.mett_01.TabIndex = 11;
            this.mett_01.Text = "重新选择";
            this.mett_01.UseSelectable = true;
            this.mett_01.Click += new System.EventHandler(this.mett_01_Click);
            // 
            // tex_remark
            // 
            this.tex_remark.Location = new System.Drawing.Point(93, 113);
            this.tex_remark.Multiline = true;
            this.tex_remark.Name = "tex_remark";
            this.tex_remark.Size = new System.Drawing.Size(375, 171);
            this.tex_remark.TabIndex = 10;
            // 
            // ml_13
            // 
            this.ml_13.AutoSize = true;
            this.ml_13.Location = new System.Drawing.Point(13, 113);
            this.ml_13.Name = "ml_13";
            this.ml_13.Size = new System.Drawing.Size(79, 20);
            this.ml_13.TabIndex = 9;
            this.ml_13.Text = "备注信息：";
            // 
            // mcb_result
            // 
            this.mcb_result.FormattingEnabled = true;
            this.mcb_result.ItemHeight = 24;
            this.mcb_result.Items.AddRange(new object[] {
            "0：正常处理",
            "1：处理失败",
            "2：其他"});
            this.mcb_result.Location = new System.Drawing.Point(93, 39);
            this.mcb_result.Name = "mcb_result";
            this.mcb_result.Size = new System.Drawing.Size(641, 30);
            this.mcb_result.TabIndex = 8;
            this.mcb_result.UseSelectable = true;
            // 
            // ml_12
            // 
            this.ml_12.AutoSize = true;
            this.ml_12.Location = new System.Drawing.Point(13, 44);
            this.ml_12.Name = "ml_12";
            this.ml_12.Size = new System.Drawing.Size(79, 20);
            this.ml_12.TabIndex = 7;
            this.ml_12.Text = "处理结果：";
            // 
            // tabp_12
            // 
            this.tabp_12.BackColor = System.Drawing.Color.Transparent;
            this.tabp_12.Location = new System.Drawing.Point(4, 39);
            this.tabp_12.Name = "tabp_12";
            this.tabp_12.Size = new System.Drawing.Size(752, 477);
            this.tabp_12.TabIndex = 1;
            this.tabp_12.Text = "其它";
            // 
            // HCSSM_parameters_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.met_right);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HCSSM_parameters_select";
            this.Text = "处理选择";
            this.met_right.ResumeLayout(false);
            this.tabp_11.ResumeLayout(false);
            this.sp_01.Panel1.ResumeLayout(false);
            this.sp_01.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_01)).EndInit();
            this.sp_01.ResumeLayout(false);
            this.gp_01.ResumeLayout(false);
            this.gp_02.ResumeLayout(false);
            this.gp_02.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CnasMetroFramework.Controls.MetroTabControl met_right;
        private System.Windows.Forms.TabPage tabp_11;
        private System.Windows.Forms.TabPage tabp_12;
        private System.Windows.Forms.SplitContainer sp_01;
        private System.Windows.Forms.GroupBox gp_01;
        private CnasMetroFramework.Controls.MetroLabel mlab_next;
        private System.Windows.Forms.GroupBox gp_02;
        private CnasMetroFramework.Controls.MetroComboBox mcb_result;
        private CnasMetroFramework.Controls.MetroLabel ml_12;
        private CnasMetroFramework.Controls.MetroLabel ml_13;
        private System.Windows.Forms.TextBox tex_remark;
        private CnasMetroFramework.Controls.MetroTile mett_03;
        private CnasMetroFramework.Controls.MetroTile mett_02;
        private CnasMetroFramework.Controls.MetroTile mett_01;
    }
}