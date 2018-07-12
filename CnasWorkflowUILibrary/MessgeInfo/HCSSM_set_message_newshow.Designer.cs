namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_set_message_newshow
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox = new Telerik.WinControls.UI.RadGroupBox();
			this.LeftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.noteListBox = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnDel = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnDisable = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.refreshBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
			this.groupBox.SuspendLayout();
			this.LeftPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.groupBox, 0, 0);
			this.mainPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.Size = new System.Drawing.Size(705, 462);
			this.mainPanel.TabIndex = 0;
			// 
			// groupBox
			// 
			this.groupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.groupBox.Controls.Add(this.LeftPanel);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.groupBox.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
			this.groupBox.HeaderText = "消息列表";
			this.groupBox.Location = new System.Drawing.Point(3, 3);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(603, 456);
			this.groupBox.TabIndex = 1;
			this.groupBox.Text = "消息列表";
			// 
			// LeftPanel
			// 
			this.LeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LeftPanel.ColumnCount = 1;
			this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.LeftPanel.Controls.Add(this.noteListBox, 0, 0);
			this.LeftPanel.Location = new System.Drawing.Point(2, 22);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.RowCount = 1;
			this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.LeftPanel.Size = new System.Drawing.Size(599, 432);
			this.LeftPanel.TabIndex = 2;
			// 
			// noteListBox
			// 
			this.noteListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.noteListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noteListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.noteListBox.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.noteListBox.FormattingEnabled = true;
			this.noteListBox.ItemHeight = 40;
			this.noteListBox.Location = new System.Drawing.Point(0, 0);
			this.noteListBox.Margin = new System.Windows.Forms.Padding(0);
			this.noteListBox.MinimumSize = new System.Drawing.Size(598, 4);
			this.noteListBox.Name = "noteListBox";
			this.noteListBox.Size = new System.Drawing.Size(599, 432);
			this.noteListBox.TabIndex = 2;
			this.noteListBox.Click += new System.EventHandler(this.noteListBox_Click);
			this.noteListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.noteListBox_DrawItem);
			this.noteListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.OnMeasureItemEvent);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.closeBtn, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnDel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnDisable, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.refreshBtn, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(609, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(96, 462);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Location = new System.Drawing.Point(3, 141);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 6;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// btnDel
			// 
			this.btnDel.ActiveControl = null;
			this.btnDel.Location = new System.Drawing.Point(3, 95);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(90, 40);
			this.btnDel.TabIndex = 5;
			this.btnDel.Text = "删 除 ";
			this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDel.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDel.UseSelectable = true;
			this.btnDel.UseTileImage = true;
			this.btnDel.Click += new System.EventHandler(this.BtnDel_Click);
			// 
			// btnDisable
			// 
			this.btnDisable.ActiveControl = null;
			this.btnDisable.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnDisable.Location = new System.Drawing.Point(3, 49);
			this.btnDisable.Name = "btnDisable";
			this.btnDisable.Size = new System.Drawing.Size(90, 40);
			this.btnDisable.TabIndex = 4;
			this.btnDisable.Text = "禁 用 ";
			this.btnDisable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDisable.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDisable.UseSelectable = true;
			this.btnDisable.UseTileImage = true;
			this.btnDisable.Visible = false;
			this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
			// 
			// refreshBtn
			// 
			this.refreshBtn.ActiveControl = null;
			this.refreshBtn.Location = new System.Drawing.Point(3, 3);
			this.refreshBtn.Name = "refreshBtn";
			this.refreshBtn.Size = new System.Drawing.Size(90, 40);
			this.refreshBtn.TabIndex = 3;
			this.refreshBtn.Text = "刷 新 ";
			this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.refreshBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.refreshBtn.UseSelectable = true;
			this.refreshBtn.UseTileImage = true;
			this.refreshBtn.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// HCSSM_set_message_newshow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 542);
			this.Controls.Add(this.mainPanel);
			this.MinimumSize = new System.Drawing.Size(744, 475);
			this.Name = "HCSSM_set_message_newshow";
			this.Text = "器械包消息";
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.LeftPanel.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.ListBox noteListBox;
		private CnasMetroFramework.Controls.MetroTile refreshBtn;
		private CnasMetroFramework.Controls.MetroTile btnDisable;
		private CnasMetroFramework.Controls.MetroTile btnDel;
		private Telerik.WinControls.UI.RadGroupBox groupBox;
		private System.Windows.Forms.TableLayoutPanel LeftPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
	}
}