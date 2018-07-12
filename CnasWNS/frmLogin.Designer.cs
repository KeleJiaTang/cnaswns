namespace Cnas.wns
{
    partial class frmLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tex_user = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_rec = new System.Windows.Forms.CheckBox();
            this.com_workare = new System.Windows.Forms.ComboBox();
            this.but_cancel = new System.Windows.Forms.Button();
            this.tex_pwd = new System.Windows.Forms.TextBox();
            this.but_ok = new System.Windows.Forms.Button();
            //this.qRibbonItem8 = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_customer = new System.Windows.Forms.Label();
            this.lab_software = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_site = new System.Windows.Forms.Label();
            this.liVersions = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "用   户:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(8, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "密   码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "工作台:";
            // 
            // tex_user
            // 
            this.tex_user.BackColor = System.Drawing.SystemColors.Window;
            this.tex_user.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tex_user.Location = new System.Drawing.Point(84, 68);
            this.tex_user.MaxLength = 30;
            this.tex_user.Name = "tex_user";
            this.tex_user.Size = new System.Drawing.Size(181, 29);
            this.tex_user.TabIndex = 1;
            this.tex_user.Tag = "请输入您的用户名称";
            this.tex_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex_user_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.check_rec);
            this.groupBox1.Controls.Add(this.com_workare);
            this.groupBox1.Controls.Add(this.but_cancel);
            this.groupBox1.Controls.Add(this.tex_pwd);
            this.groupBox1.Controls.Add(this.but_ok);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tex_user);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(389, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // check_rec
            // 
            this.check_rec.AutoSize = true;
            this.check_rec.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_rec.ForeColor = System.Drawing.Color.Black;
            this.check_rec.Location = new System.Drawing.Point(84, 145);
            this.check_rec.Name = "check_rec";
            this.check_rec.Size = new System.Drawing.Size(154, 24);
            this.check_rec.TabIndex = 11;
            this.check_rec.Text = "记录工作台和用户名";
            this.check_rec.UseVisualStyleBackColor = true;
            // 
            // com_workare
            // 
            this.com_workare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.com_workare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_workare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.com_workare.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_workare.FormattingEnabled = true;
            this.com_workare.Location = new System.Drawing.Point(82, 26);
            this.com_workare.Name = "com_workare";
            this.com_workare.Size = new System.Drawing.Size(185, 29);
            this.com_workare.TabIndex = 12;
            // 
            // but_cancel
            // 
            this.but_cancel.BackColor = System.Drawing.Color.Transparent;
            this.but_cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.but_cancel.FlatAppearance.BorderSize = 0;
            this.but_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_cancel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.ForeColor = System.Drawing.Color.Black;
            this.but_cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_cancel.Image")));
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(273, 87);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(95, 52);
            this.but_cancel.TabIndex = 4;
            this.but_cancel.Text = "退出";
            this.but_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_cancel.UseVisualStyleBackColor = false;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            this.but_cancel.MouseLeave += new System.EventHandler(this.but_cancel_MouseLeave);
            this.but_cancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_cancel_MouseMove);
            // 
            // tex_pwd
            // 
            this.tex_pwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tex_pwd.Location = new System.Drawing.Point(84, 110);
            this.tex_pwd.MaxLength = 50;
            this.tex_pwd.Name = "tex_pwd";
            this.tex_pwd.PasswordChar = '*';
            this.tex_pwd.Size = new System.Drawing.Size(181, 29);
            this.tex_pwd.TabIndex = 2;
            this.tex_pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex_pwd_KeyDown);
            // 
            // but_ok
            // 
            this.but_ok.BackColor = System.Drawing.Color.Transparent;
            this.but_ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.but_ok.FlatAppearance.BorderSize = 0;
            this.but_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_ok.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_ok.ForeColor = System.Drawing.Color.Black;
            this.but_ok.Image = ((System.Drawing.Image)(resources.GetObject("but_ok.Image")));
            this.but_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_ok.Location = new System.Drawing.Point(273, 26);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(95, 56);
            this.but_ok.TabIndex = 3;
            this.but_ok.Text = "确定";
            this.but_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_ok.UseVisualStyleBackColor = false;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            this.but_ok.MouseLeave += new System.EventHandler(this.but_ok_MouseLeave);
            this.but_ok.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_ok_MouseMove);
            // 
            // qRibbonItem8
            // 
            //this.qRibbonItem8.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            //this.qRibbonItem8.ControlSize = new System.Drawing.Size(120, 120);
            //this.qRibbonItem8.HotkeyText = "FD";
            //this.qRibbonItem8.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItem8.Icon")));
            //this.qRibbonItem8.Title = "确认";
            // 
            // pictureBox1
            // 
            //this.pictureBox1.BackgroundImage = global::Cnas.wns.Properties.Resources.lg_frm_bg02;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(769, 231);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lab_customer
            // 
            this.lab_customer.AutoSize = true;
            this.lab_customer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_customer.Location = new System.Drawing.Point(23, 255);
            this.lab_customer.Name = "lab_customer";
            this.lab_customer.Size = new System.Drawing.Size(127, 16);
            this.lab_customer.TabIndex = 6;
            this.lab_customer.Text = "广东省人民医院";
            // 
            // lab_software
            // 
            this.lab_software.AutoSize = true;
            this.lab_software.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_software.Location = new System.Drawing.Point(23, 319);
            this.lab_software.Name = "lab_software";
            this.lab_software.Size = new System.Drawing.Size(161, 16);
            this.lab_software.TabIndex = 7;
            this.lab_software.Text = "智能物联网管理平台";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(350, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "CopyRight © 2006-2015 医疗科技 support@cnasis.com";
            // 
            // lab_site
            // 
            this.lab_site.AutoSize = true;
            this.lab_site.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_site.Location = new System.Drawing.Point(23, 286);
            this.lab_site.Name = "lab_site";
            this.lab_site.Size = new System.Drawing.Size(127, 16);
            this.lab_site.TabIndex = 9;
            this.lab_site.Text = "广东省人民医院";
            // 
            // liVersions
            // 
            this.liVersions.AutoSize = true;
            this.liVersions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.liVersions.Location = new System.Drawing.Point(23, 351);
            this.liVersions.Name = "liVersions";
            this.liVersions.Size = new System.Drawing.Size(110, 16);
            this.liVersions.TabIndex = 10;
            this.liVersions.Text = "当前版本号：";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(771, 409);
            this.Controls.Add(this.liVersions);
            this.Controls.Add(this.lab_site);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab_software);
            this.Controls.Add(this.lab_customer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tex_user;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tex_pwd;
        private System.Windows.Forms.ComboBox com_workare;
        private System.Windows.Forms.CheckBox check_rec;
        //private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItem8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lab_customer;
        private System.Windows.Forms.Label lab_software;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_site;
        private System.Windows.Forms.Label liVersions;
    }
}

