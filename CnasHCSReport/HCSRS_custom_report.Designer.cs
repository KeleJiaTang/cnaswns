namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_custom_report
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
            this.scmain = new System.Windows.Forms.SplitContainer();
            this.rtvCustomTemplate = new Telerik.WinControls.UI.RadTreeView();
            this.btnPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).BeginInit();
            this.scmain.Panel1.SuspendLayout();
            this.scmain.Panel2.SuspendLayout();
            this.scmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtvCustomTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // scmain
            // 
            this.scmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scmain.Location = new System.Drawing.Point(0, 0);
            this.scmain.Name = "scmain";
            // 
            // scmain.Panel1
            // 
            this.scmain.Panel1.Controls.Add(this.rtvCustomTemplate);
            // 
            // scmain.Panel2
            // 
            this.scmain.Panel2.Controls.Add(this.btnPanel);
            this.scmain.Size = new System.Drawing.Size(1298, 843);
            this.scmain.SplitterDistance = 292;
            this.scmain.TabIndex = 3;
            // 
            // rtvCustomTemplate
            // 
            this.rtvCustomTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.rtvCustomTemplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtvCustomTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtvCustomTemplate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtvCustomTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtvCustomTemplate.Location = new System.Drawing.Point(0, 0);
            this.rtvCustomTemplate.Name = "rtvCustomTemplate";
            this.rtvCustomTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtvCustomTemplate.Size = new System.Drawing.Size(292, 843);
            this.rtvCustomTemplate.TabIndex = 8;
            this.rtvCustomTemplate.Text = "radTreeView1";
            this.rtvCustomTemplate.ThemeName = "Office2007Silver";
            this.rtvCustomTemplate.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.rtvCustomTemplate_SelectedNodeChanged);
            this.rtvCustomTemplate.NodeMouseClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.rtvCustomTemplate_NodeMouseClick);
            // 
            // btnPanel
            // 
            this.btnPanel.AutoScroll = true;
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(0, 0);
            this.btnPanel.Margin = new System.Windows.Forms.Padding(32);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(1002, 843);
            this.btnPanel.TabIndex = 0;
            // 
            // HCSRS_custom_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.scmain);
            this.Name = "HCSRS_custom_report";
            this.Size = new System.Drawing.Size(1298, 843);
            this.Load += new System.EventHandler(this.HCSRS_custom_report_Load);
            this.scmain.Panel1.ResumeLayout(false);
            this.scmain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scmain)).EndInit();
            this.scmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rtvCustomTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scmain;
        private Telerik.WinControls.UI.RadTreeView rtvCustomTemplate;
        private System.Windows.Forms.FlowLayoutPanel btnPanel;




    }
}
