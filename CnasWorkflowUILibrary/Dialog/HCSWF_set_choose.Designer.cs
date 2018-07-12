namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_set_choose
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
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setPriortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setUseLoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.washingPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sterilizerPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.searchPanel = new System.Windows.Forms.TableLayoutPanel();
			this.searchBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.setBarCodeLbl = new System.Windows.Forms.Label();
			this.setbarCodeTxt = new System.Windows.Forms.TextBox();
			this.setNameLbl = new System.Windows.Forms.Label();
			this.setNameTxt = new System.Windows.Forms.TextBox();
			this.setPriortyLbl = new System.Windows.Forms.Label();
			this.setPriortyCbx = new System.Windows.Forms.ComboBox();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.confirmBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.searchPanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.setDataGrid, 0, 1);
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
			// setDataGrid
			// 
			this.setDataGrid.AllowUserToAddRows = false;
			this.setDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.setDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.setDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setIdCol,
            this.setBarCodeCol,
            this.setNameCol,
            this.setTypeCol,
            this.setPriortyCol,
            this.setUseLoCol,
            this.washingPCol,
            this.sterilizerPCol,
            this.costCNameCol});
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 36);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.ReadOnly = true;
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(916, 527);
			this.setDataGrid.TabIndex = 4;
			this.setDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
			// 
			// setIdCol
			// 
			this.setIdCol.HeaderText = "编号";
			this.setIdCol.MinimumWidth = 70;
			this.setIdCol.Name = "setIdCol";
			this.setIdCol.ReadOnly = true;
			this.setIdCol.Width = 70;
			// 
			// setBarCodeCol
			// 
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 120;
			// 
			// setTypeCol
			// 
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Width = 120;
			// 
			// setPriortyCol
			// 
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.MinimumWidth = 55;
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			// 
			// setUseLoCol
			// 
			this.setUseLoCol.HeaderText = "使用地点";
			this.setUseLoCol.MinimumWidth = 100;
			this.setUseLoCol.Name = "setUseLoCol";
			this.setUseLoCol.ReadOnly = true;
			// 
			// washingPCol
			// 
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			// 
			// sterilizerPCol
			// 
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			// 
			// costCNameCol
			// 
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
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
			this.searchPanel.Controls.Add(this.searchBtn, 6, 0);
			this.searchPanel.Controls.Add(this.setBarCodeLbl, 0, 0);
			this.searchPanel.Controls.Add(this.setbarCodeTxt, 1, 0);
			this.searchPanel.Controls.Add(this.setNameLbl, 2, 0);
			this.searchPanel.Controls.Add(this.setNameTxt, 3, 0);
			this.searchPanel.Controls.Add(this.setPriortyLbl, 4, 0);
			this.searchPanel.Controls.Add(this.setPriortyCbx, 5, 0);
			this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchPanel.Location = new System.Drawing.Point(0, 0);
			this.searchPanel.Margin = new System.Windows.Forms.Padding(0);
			this.searchPanel.Name = "searchPanel";
			this.searchPanel.RowCount = 1;
			this.searchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.searchPanel.Size = new System.Drawing.Size(916, 36);
			this.searchPanel.TabIndex = 2;
			// 
			// searchBtn
			// 
			this.searchBtn.ActiveControl = null;
			this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.searchBtn.Location = new System.Drawing.Point(653, 3);
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
			// setBarCodeLbl
			// 
			this.setBarCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setBarCodeLbl.AutoSize = true;
			this.setBarCodeLbl.Location = new System.Drawing.Point(3, 8);
			this.setBarCodeLbl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.setBarCodeLbl.Name = "setBarCodeLbl";
			this.setBarCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.setBarCodeLbl.TabIndex = 1;
			this.setBarCodeLbl.Text = "器械包条码";
			// 
			// setbarCodeTxt
			// 
			this.setbarCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setbarCodeTxt.Location = new System.Drawing.Point(98, 4);
			this.setbarCodeTxt.Name = "setbarCodeTxt";
			this.setbarCodeTxt.Size = new System.Drawing.Size(121, 27);
			this.setbarCodeTxt.TabIndex = 1;
			// 
			// setNameLbl
			// 
			this.setNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setNameLbl.AutoSize = true;
			this.setNameLbl.Location = new System.Drawing.Point(233, 8);
			this.setNameLbl.Margin = new System.Windows.Forms.Padding(11, 0, 3, 0);
			this.setNameLbl.Name = "setNameLbl";
			this.setNameLbl.Size = new System.Drawing.Size(89, 20);
			this.setNameLbl.TabIndex = 4;
			this.setNameLbl.Text = "器械包名称";
			// 
			// setNameTxt
			// 
			this.setNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNameTxt.Location = new System.Drawing.Point(328, 4);
			this.setNameTxt.Name = "setNameTxt";
			this.setNameTxt.Size = new System.Drawing.Size(121, 27);
			this.setNameTxt.TabIndex = 2;
			// 
			// setPriortyLbl
			// 
			this.setPriortyLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setPriortyLbl.AutoSize = true;
			this.setPriortyLbl.Location = new System.Drawing.Point(463, 8);
			this.setPriortyLbl.Margin = new System.Windows.Forms.Padding(11, 0, 3, 0);
			this.setPriortyLbl.Name = "setPriortyLbl";
			this.setPriortyLbl.Size = new System.Drawing.Size(57, 20);
			this.setPriortyLbl.TabIndex = 3;
			this.setPriortyLbl.Text = "优先级";
			// 
			// setPriortyCbx
			// 
			this.setPriortyCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setPriortyCbx.DisplayMember = "Value";
			this.setPriortyCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.setPriortyCbx.FormattingEnabled = true;
			this.setPriortyCbx.Location = new System.Drawing.Point(526, 4);
			this.setPriortyCbx.Name = "setPriortyCbx";
			this.setPriortyCbx.Size = new System.Drawing.Size(121, 28);
			this.setPriortyCbx.TabIndex = 3;
			this.setPriortyCbx.ValueMember = "Key";
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
			// HCSWF_set_choose
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1054, 643);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.Name = "HCSWF_set_choose";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 20);
			this.Text = "添加器械包";
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.searchPanel.ResumeLayout(false);
			this.searchPanel.PerformLayout();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel searchPanel;
		private System.Windows.Forms.Label setBarCodeLbl;
		private System.Windows.Forms.ComboBox setPriortyCbx;
		private System.Windows.Forms.Label setPriortyLbl;
		private System.Windows.Forms.TextBox setbarCodeTxt;
		private System.Windows.Forms.TextBox setNameTxt;
		private System.Windows.Forms.Label setNameLbl;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setUseLoCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn washingPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private CnasMetroFramework.Controls.MetroTile confirmBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private CnasMetroFramework.Controls.MetroTile searchBtn;
	}
}