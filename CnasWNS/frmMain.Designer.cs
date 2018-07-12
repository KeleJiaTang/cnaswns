namespace Cnas.wns
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.stss_main = new System.Windows.Forms.StatusStrip();
            this.tssl01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl03 = new System.Windows.Forms.ToolStripStatusLabel();
            this.spc_info = new System.Windows.Forms.SplitContainer();
            this.qeb_main = new Qios.DevSuite.Components.QExplorerBar();
            this.qei_tmp = new Qios.DevSuite.Components.QExplorerItem(this.components);
            this.qei_mag = new Qios.DevSuite.Components.QExplorerItem(this.components);
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.tsm_system = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_help = new System.Windows.Forms.ToolStripMenuItem();
            this.系统帮助SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件注册RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.tsm_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.stss_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_info)).BeginInit();
            this.spc_info.Panel1.SuspendLayout();
            this.spc_info.SuspendLayout();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // stss_main
            // 
            this.stss_main.AutoSize = false;
            this.stss_main.BackColor = System.Drawing.SystemColors.Window;
            this.stss_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stss_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stss_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl01,
            this.toolStripStatusLabel1,
            this.tssl02,
            this.toolStripStatusLabel3,
            this.tssl03});
            this.stss_main.Location = new System.Drawing.Point(0, 475);
            this.stss_main.Name = "stss_main";
            this.stss_main.Size = new System.Drawing.Size(816, 22);
            this.stss_main.Stretch = false;
            this.stss_main.TabIndex = 3;
            this.stss_main.Text = "stss_main";
            // 
            // tssl01
            // 
            this.tssl01.BackColor = System.Drawing.SystemColors.Window;
            this.tssl01.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssl01.Name = "tssl01";
            this.tssl01.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tssl01.Size = new System.Drawing.Size(259, 17);
            this.tssl01.Spring = true;
            this.tssl01.Text = "医疗科技有限公司";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssl02
            // 
            this.tssl02.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssl02.Name = "tssl02";
            this.tssl02.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tssl02.Size = new System.Drawing.Size(259, 17);
            this.tssl02.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // tssl03
            // 
            this.tssl03.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssl03.Name = "tssl03";
            this.tssl03.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tssl03.Size = new System.Drawing.Size(259, 17);
            this.tssl03.Spring = true;
            this.tssl03.Text = "打包区：接受清洗手术包";
            // 
            // spc_info
            // 
            this.spc_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_info.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_info.Location = new System.Drawing.Point(0, 28);
            this.spc_info.Name = "spc_info";
            // 
            // spc_info.Panel1
            // 
            //this.spc_info.Panel1.Controls.Add(this.qeb_main);
            //this.spc_info.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //this.spc_info.Panel1MinSize = 10;
            // 
            // spc_info.Panel2
            // 
            this.spc_info.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.spc_info.Panel2.Margin = new System.Windows.Forms.Padding(6);
            this.spc_info.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.spc_info.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spc_info.Panel2MinSize = 10;
            this.spc_info.Size = new System.Drawing.Size(816, 447);
            this.spc_info.SplitterDistance = 217;
            this.spc_info.SplitterWidth = 2;
            this.spc_info.TabIndex = 4;
            // 
            // qeb_main
            // 
            //this.qeb_main.ColorScheme.ExplorerBarBackground1.SetColor("VistaBlack", System.Drawing.Color.White, false);
            //this.qeb_main.ColorScheme.ExplorerBarBackground2.SetColor("VistaBlack", System.Drawing.Color.White, false);
            //this.qeb_main.ColorScheme.ExplorerBarBorder.SetColor("VistaBlack", System.Drawing.SystemColors.Menu, false);
            //this.qeb_main.ColorScheme.ExplorerBarExpandedGroupItemBackground1.SetColor("VistaBlack", System.Drawing.SystemColors.Window, false);
            //this.qeb_main.ColorScheme.ExplorerBarGroupItemBackground1.SetColor("Default", System.Drawing.SystemColors.Window, false);
            //this.qeb_main.ColorScheme.ExplorerBarGroupItemBackground1.SetColor("VistaBlack", System.Drawing.SystemColors.Window, false);
            //this.qeb_main.ColorScheme.ExplorerBarHotGroupItemBackground1.SetColor("VistaBlack", System.Drawing.SystemColors.Window, false);
            //this.qeb_main.ColorScheme.ExplorerBarPressedGroupItemBackground1.SetColor("VistaBlack", System.Drawing.SystemColors.Window, false);
            //this.qeb_main.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.qeb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.qeb_main.ExplorerItems.AddRange(new Qios.DevSuite.Components.QMenuItem[] {
            //this.qei_tmp});
            //this.qeb_main.Location = new System.Drawing.Point(0, 0);
            //this.qeb_main.Name = "qeb_main";
            //this.qeb_main.PersistGuid = new System.Guid("a863a74e-32ea-43ef-ab38-810367137306");
            //this.qeb_main.Size = new System.Drawing.Size(217, 447);
            //this.qeb_main.TabIndex = 0;
            // 
            // qei_tmp
            // 
            this.qei_tmp.Icon = ((System.Drawing.Icon)(resources.GetObject("qei_tmp.Icon")));
            this.qei_tmp.MenuItems.AddRange(new Qios.DevSuite.Components.QMenuItem[] {
            this.qei_mag});
            this.qei_tmp.Title = "用户工作台";
            // 
            // qei_mag
            // 
            this.qei_mag.Icon = ((System.Drawing.Icon)(resources.GetObject("qei_mag.Icon")));
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_system,
            this.tsm_help,
            this.tsm_logout,
            this.tsm_exit});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(816, 28);
            this.menuStrip_main.TabIndex = 5;
            // 
            // tsm_system
            // 
            this.tsm_system.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.tsm_system.Image = ((System.Drawing.Image)(resources.GetObject("tsm_system.Image")));
            this.tsm_system.Name = "tsm_system";
            this.tsm_system.Size = new System.Drawing.Size(79, 24);
            this.tsm_system.Text = "系统(&S)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            // 
            // tsm_help
            // 
            this.tsm_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统帮助SToolStripMenuItem,
            this.软件注册RToolStripMenuItem});
            this.tsm_help.Image = ((System.Drawing.Image)(resources.GetObject("tsm_help.Image")));
            this.tsm_help.Name = "tsm_help";
            this.tsm_help.Size = new System.Drawing.Size(81, 24);
            this.tsm_help.Text = "帮助(&H)";
            // 
            // 系统帮助SToolStripMenuItem
            // 
            this.系统帮助SToolStripMenuItem.Name = "系统帮助SToolStripMenuItem";
            this.系统帮助SToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.系统帮助SToolStripMenuItem.Text = "系统帮助(&S)";
            // 
            // 软件注册RToolStripMenuItem
            // 
            this.软件注册RToolStripMenuItem.Name = "软件注册RToolStripMenuItem";
            this.软件注册RToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.软件注册RToolStripMenuItem.Text = "软件注册(&R)";
            // 
            // tsm_logout
            // 
            this.tsm_logout.Image = ((System.Drawing.Image)(resources.GetObject("tsm_logout.Image")));
            this.tsm_logout.Name = "tsm_logout";
            this.tsm_logout.Size = new System.Drawing.Size(64, 24);
            this.tsm_logout.Text = "注销";
            // 
            // tsm_exit
            // 
            this.tsm_exit.Image = ((System.Drawing.Image)(resources.GetObject("tsm_exit.Image")));
            this.tsm_exit.Name = "tsm_exit";
            this.tsm_exit.Size = new System.Drawing.Size(64, 24);
            this.tsm_exit.Text = "退出";
            this.tsm_exit.Click += new System.EventHandler(this.tsm_exit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 497);
            this.Controls.Add(this.spc_info);
            this.Controls.Add(this.stss_main);
            this.Controls.Add(this.menuStrip_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HCS管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.stss_main.ResumeLayout(false);
            this.stss_main.PerformLayout();
            this.spc_info.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_info)).EndInit();
            this.spc_info.ResumeLayout(false);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stss_main;
        private System.Windows.Forms.ToolStripStatusLabel tssl01;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl02;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssl03;
        private System.Windows.Forms.SplitContainer spc_info;
        private Qios.DevSuite.Components.QExplorerBar qeb_main;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem tsm_system;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm_help;
        private System.Windows.Forms.ToolStripMenuItem 系统帮助SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm_logout;
        private System.Windows.Forms.ToolStripMenuItem tsm_exit;
        private System.Windows.Forms.ToolStripMenuItem 软件注册RToolStripMenuItem;
        private Qios.DevSuite.Components.QExplorerItem qei_tmp;
        private Qios.DevSuite.Components.QExplorerItem qei_mag;
    }
}