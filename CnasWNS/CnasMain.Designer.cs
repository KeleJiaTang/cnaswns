namespace Cnas.wns
{
    partial class CnasMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CnasMain));
			this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
			this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
			this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.LeftMenu = new Telerik.WinControls.UI.RadPageView();
			this.radPageViewContent = new Telerik.WinControls.UI.RadPageView();
			this.pnlBackground.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LeftMenu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radPageViewContent)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlBackground
			// 
			this.pnlBackground.BackColor = System.Drawing.SystemColors.Window;
			this.pnlBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackground.BackgroundImage")));
			this.pnlBackground.Controls.Add(this.splitContainer1);
			this.pnlBackground.Size = new System.Drawing.Size(1021, 701);
			// 
			// documentTabStrip1
			// 
			this.documentTabStrip1.CanUpdateChildIndex = true;
			this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
			this.documentTabStrip1.Name = "documentTabStrip1";
			// 
			// 
			// 
			this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
			this.documentTabStrip1.Size = new System.Drawing.Size(727, 700);
			this.documentTabStrip1.TabIndex = 0;
			this.documentTabStrip1.TabStop = false;
			this.documentTabStrip1.TabStripAlignment = Telerik.WinControls.UI.TabStripAlignment.Left;
			// 
			// radSplitContainer1
			// 
			this.radSplitContainer1.IsCleanUpTarget = true;
			this.radSplitContainer1.Location = new System.Drawing.Point(5, 209);
			this.radSplitContainer1.Name = "radSplitContainer1";
			this.radSplitContainer1.Padding = new System.Windows.Forms.Padding(5);
			// 
			// 
			// 
			this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
			this.radSplitContainer1.Size = new System.Drawing.Size(980, 496);
			this.radSplitContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(249, 200);
			this.radSplitContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(49, 0);
			this.radSplitContainer1.TabIndex = 0;
			this.radSplitContainer1.TabStop = false;
			// 
			// toolTabStrip1
			// 
			this.toolTabStrip1.CanUpdateChildIndex = true;
			this.toolTabStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolTabStrip1.Name = "toolTabStrip1";
			// 
			// 
			// 
			this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
			this.toolTabStrip1.Size = new System.Drawing.Size(249, 496);
			this.toolTabStrip1.SizeInfo.AbsoluteSize = new System.Drawing.Size(249, 200);
			this.toolTabStrip1.SizeInfo.SplitterCorrection = new System.Drawing.Size(49, 0);
			this.toolTabStrip1.TabIndex = 1;
			this.toolTabStrip1.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.LeftMenu);
			this.splitContainer1.Panel1MinSize = 0;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.radPageViewContent);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(1021, 701);
			this.splitContainer1.SplitterDistance = 226;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 2;
			// 
			// LeftMenu
			// 
			this.LeftMenu.CausesValidation = false;
			this.LeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.LeftMenu.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
			this.LeftMenu.Location = new System.Drawing.Point(0, 0);
			this.LeftMenu.Name = "LeftMenu";
			this.LeftMenu.Size = new System.Drawing.Size(226, 701);
			this.LeftMenu.TabIndex = 5;
			this.LeftMenu.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
			((Telerik.WinControls.UI.RadPageViewStackElement)(this.LeftMenu.GetChildAt(0))).ItemSelectionMode = Telerik.WinControls.UI.StackViewItemSelectionMode.ContentWithSelected;
			((Telerik.WinControls.UI.RadPageViewStackElement)(this.LeftMenu.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
			((Telerik.WinControls.UI.RadPageViewLabelElement)(this.LeftMenu.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
			// 
			// radPageViewContent
			// 
			this.radPageViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radPageViewContent.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.radPageViewContent.Location = new System.Drawing.Point(0, 0);
			this.radPageViewContent.Name = "radPageViewContent";
			this.radPageViewContent.Size = new System.Drawing.Size(794, 701);
			this.radPageViewContent.TabIndex = 15;
			this.radPageViewContent.Text = "radPageView1";
			// 
			// CnasMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(1021, 791);
			this.Controls.Add(this.pnlBackground);
			this.CurrentSkinColor = CRD.WinUI.SkinColor.Default;
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CnasMain";
			this.Text = "HCS管理系统";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CnasMain_FormClosed);
			this.Load += new System.EventHandler(this.CnasMain_Load);
			this.Controls.SetChildIndex(this.pnlBackground, 0);
			this.pnlBackground.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LeftMenu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radPageViewContent)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPageView LeftMenu;
        private Telerik.WinControls.UI.RadPageView radPageViewContent;
    }
}