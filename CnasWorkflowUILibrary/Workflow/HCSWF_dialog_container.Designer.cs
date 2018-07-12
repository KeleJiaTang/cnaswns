namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_dialog_container
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.confirmBtn = new System.Windows.Forms.PictureBox();
			this.cancelBtn = new System.Windows.Forms.PictureBox();
			this.infoGroup = new System.Windows.Forms.GroupBox();
			this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
			this.resultLbl = new System.Windows.Forms.Label();
			this.buttonGroup = new System.Windows.Forms.ListBox();
			this.setDataGridContextMenu = new Cnas.wns.CnasMetroFramework.Controls.MetroContextMenu(this.components);
			this.printTsm = new System.Windows.Forms.ToolStripMenuItem();
			this.handTsm = new System.Windows.Forms.ToolStripMenuItem();
			this.mainPanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.confirmBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).BeginInit();
			this.infoGroup.SuspendLayout();
			this.infoPanel.SuspendLayout();
			this.setDataGridContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.mainPanel.Controls.Add(this.buttonPanel, 1, 1);
			this.mainPanel.Controls.Add(this.infoGroup, 0, 0);
			this.mainPanel.Controls.Add(this.buttonGroup, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(27, 75);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.Size = new System.Drawing.Size(1146, 650);
			this.mainPanel.TabIndex = 0;
			// 
			// buttonPanel
			// 
			this.buttonPanel.ColumnCount = 1;
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Controls.Add(this.confirmBtn, 0, 0);
			this.buttonPanel.Controls.Add(this.cancelBtn, 0, 1);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPanel.Location = new System.Drawing.Point(946, 494);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.RowCount = 2;
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Size = new System.Drawing.Size(200, 156);
			this.buttonPanel.TabIndex = 0;
			// 
			// confirmBtn
			// 
			this.confirmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.confirmBtn.Location = new System.Drawing.Point(0, 0);
			this.confirmBtn.Margin = new System.Windows.Forms.Padding(0);
			this.confirmBtn.Name = "confirmBtn";
			this.confirmBtn.Size = new System.Drawing.Size(200, 75);
			this.confirmBtn.TabIndex = 0;
			this.confirmBtn.TabStop = false;
			this.confirmBtn.Click += new System.EventHandler(this.OnConfirmBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cancelBtn.Location = new System.Drawing.Point(0, 75);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(200, 75);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.TabStop = false;
			this.cancelBtn.Click += new System.EventHandler(this.OnCancelBtnClick);
			// 
			// infoGroup
			// 
			this.infoGroup.Controls.Add(this.infoPanel);
			this.infoGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoGroup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.infoGroup.Location = new System.Drawing.Point(0, 0);
			this.infoGroup.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.infoGroup.Name = "infoGroup";
			this.infoGroup.Padding = new System.Windows.Forms.Padding(4);
			this.mainPanel.SetRowSpan(this.infoGroup, 2);
			this.infoGroup.Size = new System.Drawing.Size(944, 650);
			this.infoGroup.TabIndex = 1;
			this.infoGroup.TabStop = false;
			this.infoGroup.Text = "信息";
			// 
			// infoPanel
			// 
			this.infoPanel.ColumnCount = 1;
			this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.infoPanel.Controls.Add(this.resultLbl, 0, 1);
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPanel.Location = new System.Drawing.Point(4, 24);
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.RowCount = 2;
			this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.infoPanel.Size = new System.Drawing.Size(936, 622);
			this.infoPanel.TabIndex = 1;
			// 
			// resultLbl
			// 
			this.resultLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.resultLbl.AutoSize = true;
			this.resultLbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
			this.resultLbl.ForeColor = System.Drawing.Color.Red;
			this.resultLbl.Location = new System.Drawing.Point(3, 593);
			this.resultLbl.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.resultLbl.Name = "resultLbl";
			this.resultLbl.Size = new System.Drawing.Size(930, 28);
			this.resultLbl.TabIndex = 1;
			this.resultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonGroup
			// 
			this.buttonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.buttonGroup.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.buttonGroup.FormattingEnabled = true;
			this.buttonGroup.ItemHeight = 90;
			this.buttonGroup.Location = new System.Drawing.Point(946, 10);
			this.buttonGroup.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.buttonGroup.Name = "buttonGroup";
			this.buttonGroup.Size = new System.Drawing.Size(200, 484);
			this.buttonGroup.TabIndex = 31;
			this.buttonGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnButtonGroupMouseClick);
			this.buttonGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnButtonGroupDrawItem);
			// 
			// setDataGridContextMenu
			// 
			this.setDataGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printTsm,
            this.handTsm});
			this.setDataGridContextMenu.Name = "mcm_right";
			this.setDataGridContextMenu.Size = new System.Drawing.Size(125, 48);
			// 
			// printTsm
			// 
			this.printTsm.Name = "printTsm";
			this.printTsm.Size = new System.Drawing.Size(124, 22);
			this.printTsm.Text = "打印条码";
			this.printTsm.Click += new System.EventHandler(this.onPrintSetBarCode);
			// 
			// handTsm
			// 
			this.handTsm.Name = "handTsm";
			this.handTsm.Size = new System.Drawing.Size(124, 22);
			this.handTsm.Text = "手动处理";
			this.handTsm.Click += new System.EventHandler(this.OnHandTsmClick);
			// 
			// HCSWF_dialog_container
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 750);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1200, 726);
			this.Name = "HCSWF_dialog_container";
			this.Padding = new System.Windows.Forms.Padding(27, 75, 27, 25);
			this.Text = "HCSWFDialogContainer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
			this.mainPanel.ResumeLayout(false);
			this.buttonPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.confirmBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).EndInit();
			this.infoGroup.ResumeLayout(false);
			this.infoPanel.ResumeLayout(false);
			this.infoPanel.PerformLayout();
			this.setDataGridContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private System.Windows.Forms.GroupBox infoGroup;
		private System.Windows.Forms.ListBox buttonGroup;
		private System.Windows.Forms.PictureBox confirmBtn;
		private System.Windows.Forms.PictureBox cancelBtn;
		private CnasMetroFramework.Controls.MetroContextMenu setDataGridContextMenu;
		private System.Windows.Forms.ToolStripMenuItem printTsm;
		private System.Windows.Forms.ToolStripMenuItem handTsm;
		private System.Windows.Forms.TableLayoutPanel infoPanel;
		private System.Windows.Forms.Label resultLbl;
	}
}