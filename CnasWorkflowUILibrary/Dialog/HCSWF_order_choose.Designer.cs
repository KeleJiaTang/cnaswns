namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_order_choose
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.orderDataGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.useLocationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.credateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.searchPanel = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.searchBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.orderCodeTxt = new System.Windows.Forms.TextBox();
			this.setNameLbl = new System.Windows.Forms.Label();
			this.orderNameTxt = new System.Windows.Forms.TextBox();
			this.orderCodeLbl = new System.Windows.Forms.Label();
			this.orderTypeCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.confirmBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.orderDataGrid)).BeginInit();
			this.searchPanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.orderDataGrid, 0, 1);
			this.mainPanel.Controls.Add(this.searchPanel, 0, 0);
			this.mainPanel.Controls.Add(this.buttonPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(21, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(1012, 563);
			this.mainPanel.TabIndex = 0;
			// 
			// orderDataGrid
			// 
			this.orderDataGrid.AllowUserToAddRows = false;
			this.orderDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.orderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.orderDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.orderCodeCol,
            this.orderNameCol,
            this.orderTypeCol,
            this.customerCol,
            this.useLocationCol,
            this.credateCol});
			this.orderDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orderDataGrid.Location = new System.Drawing.Point(0, 36);
			this.orderDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.orderDataGrid.Name = "orderDataGrid";
			this.orderDataGrid.ReadOnly = true;
			this.orderDataGrid.RowHeadersVisible = false;
			this.orderDataGrid.RowTemplate.Height = 23;
			this.orderDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.orderDataGrid.Size = new System.Drawing.Size(916, 527);
			this.orderDataGrid.TabIndex = 7;
			this.orderDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.MinimumWidth = 70;
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			this.idCol.Width = 70;
			// 
			// orderCodeCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.orderCodeCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.orderCodeCol.HeaderText = "订单条码";
			this.orderCodeCol.MinimumWidth = 120;
			this.orderCodeCol.Name = "orderCodeCol";
			this.orderCodeCol.ReadOnly = true;
			this.orderCodeCol.Width = 120;
			// 
			// orderNameCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.orderNameCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.orderNameCol.HeaderText = "订单名称";
			this.orderNameCol.MinimumWidth = 120;
			this.orderNameCol.Name = "orderNameCol";
			this.orderNameCol.ReadOnly = true;
			this.orderNameCol.Width = 180;
			// 
			// orderTypeCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.orderTypeCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.orderTypeCol.HeaderText = "订单类型";
			this.orderTypeCol.MinimumWidth = 120;
			this.orderTypeCol.Name = "orderTypeCol";
			this.orderTypeCol.ReadOnly = true;
			this.orderTypeCol.Width = 180;
			// 
			// customerCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.customerCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.customerCol.HeaderText = "客户";
			this.customerCol.MinimumWidth = 120;
			this.customerCol.Name = "customerCol";
			this.customerCol.ReadOnly = true;
			this.customerCol.Width = 180;
			// 
			// useLocationCol
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.useLocationCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.useLocationCol.HeaderText = "使用地点";
			this.useLocationCol.MinimumWidth = 100;
			this.useLocationCol.Name = "useLocationCol";
			this.useLocationCol.ReadOnly = true;
			this.useLocationCol.Width = 180;
			// 
			// credateCol
			// 
			dataGridViewCellStyle6.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.credateCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.credateCol.HeaderText = "创建时间";
			this.credateCol.MinimumWidth = 120;
			this.credateCol.Name = "credateCol";
			this.credateCol.ReadOnly = true;
			this.credateCol.Width = 180;
			// 
			// searchPanel
			// 
			this.searchPanel.ColumnCount = 7;
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchPanel.Controls.Add(this.label1, 0, 0);
			this.searchPanel.Controls.Add(this.searchBtn, 6, 0);
			this.searchPanel.Controls.Add(this.orderCodeTxt, 1, 0);
			this.searchPanel.Controls.Add(this.setNameLbl, 2, 0);
			this.searchPanel.Controls.Add(this.orderNameTxt, 3, 0);
			this.searchPanel.Controls.Add(this.orderCodeLbl, 4, 0);
			this.searchPanel.Controls.Add(this.orderTypeCbx, 5, 0);
			this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchPanel.Location = new System.Drawing.Point(0, 0);
			this.searchPanel.Margin = new System.Windows.Forms.Padding(0);
			this.searchPanel.Name = "searchPanel";
			this.searchPanel.RowCount = 1;
			this.searchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.searchPanel.Size = new System.Drawing.Size(916, 36);
			this.searchPanel.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 20);
			this.label1.TabIndex = 23;
			this.label1.Text = "订单条码";
			// 
			// searchBtn
			// 
			this.searchBtn.ActiveControl = null;
			this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.searchBtn.Location = new System.Drawing.Point(766, 3);
			this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(80, 30);
			this.searchBtn.TabIndex = 4;
			this.searchBtn.Text = "查 询 ";
			this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.searchBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.searchBtn.UseSelectable = true;
			this.searchBtn.UseTileImage = true;
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// orderCodeTxt
			// 
			this.orderCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.orderCodeTxt.Location = new System.Drawing.Point(82, 4);
			this.orderCodeTxt.Name = "orderCodeTxt";
			this.orderCodeTxt.Size = new System.Drawing.Size(150, 27);
			this.orderCodeTxt.TabIndex = 1;
			// 
			// setNameLbl
			// 
			this.setNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setNameLbl.AutoSize = true;
			this.setNameLbl.Location = new System.Drawing.Point(246, 8);
			this.setNameLbl.Margin = new System.Windows.Forms.Padding(11, 0, 3, 0);
			this.setNameLbl.Name = "setNameLbl";
			this.setNameLbl.Size = new System.Drawing.Size(73, 20);
			this.setNameLbl.TabIndex = 4;
			this.setNameLbl.Text = "订单名称";
			// 
			// orderNameTxt
			// 
			this.orderNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.orderNameTxt.Location = new System.Drawing.Point(325, 4);
			this.orderNameTxt.Name = "orderNameTxt";
			this.orderNameTxt.Size = new System.Drawing.Size(150, 27);
			this.orderNameTxt.TabIndex = 2;
			// 
			// orderCodeLbl
			// 
			this.orderCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderCodeLbl.AutoSize = true;
			this.orderCodeLbl.Location = new System.Drawing.Point(481, 8);
			this.orderCodeLbl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.orderCodeLbl.Name = "orderCodeLbl";
			this.orderCodeLbl.Size = new System.Drawing.Size(73, 20);
			this.orderCodeLbl.TabIndex = 1;
			this.orderCodeLbl.Text = "订单类型";
			// 
			// orderTypeCbx
			// 
			this.orderTypeCbx.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.orderTypeCbx.DisplayMember = "Value";
			this.orderTypeCbx.FormattingEnabled = true;
			this.orderTypeCbx.ItemHeight = 24;
			this.orderTypeCbx.Location = new System.Drawing.Point(560, 3);
			this.orderTypeCbx.Name = "orderTypeCbx";
			this.orderTypeCbx.Size = new System.Drawing.Size(200, 30);
			this.orderTypeCbx.TabIndex = 3;
			this.orderTypeCbx.UseSelectable = true;
			this.orderTypeCbx.ValueMember = "Key";
			// 
			// buttonPanel
			// 
			this.buttonPanel.ColumnCount = 1;
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Controls.Add(this.cancelBtn, 0, 1);
			this.buttonPanel.Controls.Add(this.confirmBtn, 0, 0);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPanel.Location = new System.Drawing.Point(916, 0);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.RowCount = 2;
			this.mainPanel.SetRowSpan(this.buttonPanel, 2);
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Size = new System.Drawing.Size(96, 563);
			this.buttonPanel.TabIndex = 3;
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(3, 46);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "取 消 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// confirmBtn
			// 
			this.confirmBtn.ActiveControl = null;
			this.confirmBtn.Location = new System.Drawing.Point(3, 2);
			this.confirmBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.confirmBtn.Name = "confirmBtn";
			this.confirmBtn.Size = new System.Drawing.Size(90, 40);
			this.confirmBtn.TabIndex = 5;
			this.confirmBtn.Text = "保 存 ";
			this.confirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.confirmBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.confirmBtn.UseSelectable = true;
			this.confirmBtn.UseTileImage = true;
			this.confirmBtn.Click += new System.EventHandler(this.OnConfirmBtnClick);
			// 
			// HCSWF_order_choose
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1054, 643);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.Name = "HCSWF_order_choose";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 20);
			this.Text = "添加处理订单";
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.orderDataGrid)).EndInit();
			this.searchPanel.ResumeLayout(false);
			this.searchPanel.PerformLayout();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel searchPanel;
		private System.Windows.Forms.Label orderCodeLbl;
		private System.Windows.Forms.TextBox orderCodeTxt;
		private System.Windows.Forms.TextBox orderNameTxt;
		private System.Windows.Forms.Label setNameLbl;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private System.Windows.Forms.DataGridView orderDataGrid;
		private CnasMetroFramework.Controls.MetroTile confirmBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private CnasMetroFramework.Controls.MetroTile searchBtn;
		private System.Windows.Forms.Label label1;
		private CnasMetroFramework.Controls.MetroComboBox orderTypeCbx;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn useLocationCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn credateCol;
	}
}