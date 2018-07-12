namespace Cnas.wns.CnasHCSWorkspaceDecon
{
    partial class HCSSM_procedure_manual
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
            this.sp_02 = new System.Windows.Forms.SplitContainer();
            this.panel_01 = new System.Windows.Forms.Panel();
            this.tex_remark = new System.Windows.Forms.TextBox();
            this.ml_13 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.gp_03 = new System.Windows.Forms.GroupBox();
            this.pic_01 = new System.Windows.Forms.PictureBox();
            this.pic_02 = new System.Windows.Forms.PictureBox();
            this.tabp_12 = new System.Windows.Forms.TabPage();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.met_right.SuspendLayout();
            this.tabp_11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_02)).BeginInit();
            this.sp_02.Panel1.SuspendLayout();
            this.sp_02.Panel2.SuspendLayout();
            this.sp_02.SuspendLayout();
            this.panel_01.SuspendLayout();
            this.gp_03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_02)).BeginInit();
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
            this.met_right.TabIndex = 2;
            this.met_right.UseSelectable = true;
            // 
            // tabp_11
            // 
            this.tabp_11.BackColor = System.Drawing.Color.Transparent;
            this.tabp_11.Controls.Add(this.sp_02);
            this.tabp_11.Location = new System.Drawing.Point(4, 39);
            this.tabp_11.Name = "tabp_11";
            this.tabp_11.Size = new System.Drawing.Size(752, 477);
            this.tabp_11.TabIndex = 0;
            this.tabp_11.Text = "处理选择";
            // 
            // sp_02
            // 
            this.sp_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_02.Location = new System.Drawing.Point(0, 0);
            this.sp_02.Name = "sp_02";
            // 
            // sp_02.Panel1
            // 
            this.sp_02.Panel1.Controls.Add(this.panel_01);
            // 
            // sp_02.Panel2
            // 
            this.sp_02.Panel2.Controls.Add(this.gp_03);
            this.sp_02.Size = new System.Drawing.Size(752, 477);
            this.sp_02.SplitterDistance = 561;
            this.sp_02.TabIndex = 1;
            // 
            // panel_01
            // 
            this.panel_01.Controls.Add(this.tex_remark);
            this.panel_01.Controls.Add(this.ml_13);
            this.panel_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_01.Location = new System.Drawing.Point(0, 0);
            this.panel_01.Name = "panel_01";
            this.panel_01.Size = new System.Drawing.Size(561, 477);
            this.panel_01.TabIndex = 0;
            // 
            // tex_remark
            // 
            this.tex_remark.BackColor = System.Drawing.SystemColors.Window;
            this.tex_remark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex_remark.Location = new System.Drawing.Point(3, 73);
            this.tex_remark.Multiline = true;
            this.tex_remark.Name = "tex_remark";
            this.tex_remark.ReadOnly = true;
            this.tex_remark.Size = new System.Drawing.Size(496, 404);
            this.tex_remark.TabIndex = 12;
            this.tex_remark.Click += new System.EventHandler(this.tex_remark_Click);
            // 
            // ml_13
            // 
            this.ml_13.AutoSize = true;
            this.ml_13.Location = new System.Drawing.Point(3, 36);
            this.ml_13.Name = "ml_13";
            this.ml_13.Size = new System.Drawing.Size(79, 20);
            this.ml_13.TabIndex = 11;
            this.ml_13.Text = "备注信息：";
            // 
            // gp_03
            // 
            this.gp_03.Controls.Add(this.pic_01);
            this.gp_03.Controls.Add(this.pic_02);
            this.gp_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_03.Location = new System.Drawing.Point(0, 0);
            this.gp_03.Name = "gp_03";
            this.gp_03.Size = new System.Drawing.Size(187, 477);
            this.gp_03.TabIndex = 9;
            this.gp_03.TabStop = false;
            this.gp_03.Text = "选择";
            // 
            // pic_01
            // 
            this.pic_01.Location = new System.Drawing.Point(2, 106);
            this.pic_01.Name = "pic_01";
            this.pic_01.Size = new System.Drawing.Size(180, 80);
            this.pic_01.TabIndex = 2;
            this.pic_01.TabStop = false;
            // 
            // pic_02
            // 
            this.pic_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_02.Location = new System.Drawing.Point(2, 20);
            this.pic_02.Name = "pic_02";
            this.pic_02.Size = new System.Drawing.Size(180, 80);
            this.pic_02.TabIndex = 4;
            this.pic_02.TabStop = false;
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
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.Color.White;
            this.tb_barcode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_barcode.Location = new System.Drawing.Point(521, 28);
            this.tb_barcode.MaxLength = 50;
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(1, 26);
            this.tb_barcode.TabIndex = 3;
            this.tb_barcode.TextChanged += new System.EventHandler(this.tb_barcode_TextChanged);
            this.tb_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_barcode_KeyPress);
            this.tb_barcode.Leave += new System.EventHandler(this.tb_barcode_Leave);
            // 
            // HCSSM_procedure_manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.met_right);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HCSSM_procedure_manual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "流程手动处理";
            this.Activated += new System.EventHandler(this.HCSSM_procedure_manual_Activated);
            this.Load += new System.EventHandler(this.HCSSM_procedure_manual_Load);
            this.met_right.ResumeLayout(false);
            this.tabp_11.ResumeLayout(false);
            this.sp_02.Panel1.ResumeLayout(false);
            this.sp_02.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_02)).EndInit();
            this.sp_02.ResumeLayout(false);
            this.panel_01.ResumeLayout(false);
            this.panel_01.PerformLayout();
            this.gp_03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CnasMetroFramework.Controls.MetroTabControl met_right;
        private System.Windows.Forms.TabPage tabp_11;
        private System.Windows.Forms.SplitContainer sp_02;
        private System.Windows.Forms.GroupBox gp_03;
        private System.Windows.Forms.PictureBox pic_01;
        private System.Windows.Forms.PictureBox pic_02;
        private System.Windows.Forms.TabPage tabp_12;
        private System.Windows.Forms.Panel panel_01;
        private System.Windows.Forms.TextBox tex_remark;
        private CnasMetroFramework.Controls.MetroLabel ml_13;
        private System.Windows.Forms.TextBox tb_barcode;

    }
}