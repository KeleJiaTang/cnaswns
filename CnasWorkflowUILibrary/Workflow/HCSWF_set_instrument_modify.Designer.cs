namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_set_instrument_modify
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ButtonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.confirmBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.instrumentGrid = new System.Windows.Forms.DataGridView();
			this.inIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inRemarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setLbl = new System.Windows.Forms.Label();
			this.setBarCodeTxt = new System.Windows.Forms.TextBox();
			this.setNameTxt = new System.Windows.Forms.TextBox();
			this.setNameLbl = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.ButtonPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.ButtonPanel, 1, 0);
			this.mainPanel.Controls.Add(this.leftPanel, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(27, 75);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.Size = new System.Drawing.Size(748, 525);
			this.mainPanel.TabIndex = 0;
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.ColumnCount = 1;
			this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonPanel.Controls.Add(this.cancelBtn, 0, 1);
			this.ButtonPanel.Controls.Add(this.confirmBtn, 0, 0);
			this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonPanel.Location = new System.Drawing.Point(652, 0);
			this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.RowCount = 2;
			this.mainPanel.SetRowSpan(this.ButtonPanel, 2);
			this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonPanel.Size = new System.Drawing.Size(96, 525);
			this.ButtonPanel.TabIndex = 0;
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(3, 49);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 5;
			this.cancelBtn.Text = "取 消 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// confirmBtn
			// 
			this.confirmBtn.ActiveControl = null;
			this.confirmBtn.Location = new System.Drawing.Point(3, 3);
			this.confirmBtn.Name = "confirmBtn";
			this.confirmBtn.Size = new System.Drawing.Size(90, 40);
			this.confirmBtn.TabIndex = 4;
			this.confirmBtn.Text = "保 存 ";
			this.confirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.confirmBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.confirmBtn.UseSelectable = true;
			this.confirmBtn.UseTileImage = true;
			this.confirmBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 4;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.leftPanel.Controls.Add(this.instrumentGrid, 0, 3);
			this.leftPanel.Controls.Add(this.setLbl, 0, 0);
			this.leftPanel.Controls.Add(this.setBarCodeTxt, 1, 0);
			this.leftPanel.Controls.Add(this.setNameLbl, 2, 0);
			this.leftPanel.Controls.Add(this.setNameTxt, 3, 0);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 4;
			this.mainPanel.SetRowSpan(this.leftPanel, 2);
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Size = new System.Drawing.Size(652, 525);
			this.leftPanel.TabIndex = 1;
			// 
			// instrumentGrid
			// 
			this.instrumentGrid.AllowUserToAddRows = false;
			this.instrumentGrid.AllowUserToDeleteRows = false;
			this.instrumentGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.instrumentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.instrumentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inIdCol,
            this.inNameCol,
            this.inNumCol,
            this.inTypeCol,
            this.costCNameCol,
            this.inPriceCol,
            this.inRemarkCol});
			this.leftPanel.SetColumnSpan(this.instrumentGrid, 4);
			this.instrumentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.instrumentGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.instrumentGrid.Location = new System.Drawing.Point(0, 33);
			this.instrumentGrid.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.instrumentGrid.Name = "instrumentGrid";
			this.instrumentGrid.RowHeadersVisible = false;
			this.instrumentGrid.RowTemplate.Height = 23;
			this.instrumentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.instrumentGrid.Size = new System.Drawing.Size(651, 492);
			this.instrumentGrid.TabIndex = 3;
			// 
			// inIdCol
			// 
			dataGridViewCellStyle4.NullValue = null;
			this.inIdCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.inIdCol.HeaderText = "编号";
			this.inIdCol.MinimumWidth = 60;
			this.inIdCol.Name = "inIdCol";
			this.inIdCol.ReadOnly = true;
			this.inIdCol.Visible = false;
			this.inIdCol.Width = 60;
			// 
			// inNameCol
			// 
			this.inNameCol.HeaderText = "器械名称";
			this.inNameCol.MinimumWidth = 100;
			this.inNameCol.Name = "inNameCol";
			this.inNameCol.ReadOnly = true;
			this.inNameCol.Width = 200;
			// 
			// inNumCol
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.inNumCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.inNumCol.HeaderText = "器械数量";
			this.inNumCol.MinimumWidth = 100;
			this.inNumCol.Name = "inNumCol";
			// 
			// inTypeCol
			// 
			this.inTypeCol.HeaderText = "器械类型";
			this.inTypeCol.MinimumWidth = 100;
			this.inTypeCol.Name = "inTypeCol";
			this.inTypeCol.ReadOnly = true;
			// 
			// costCNameCol
			// 
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Width = 150;
			// 
			// inPriceCol
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "C2";
			dataGridViewCellStyle6.NullValue = null;
			this.inPriceCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.inPriceCol.HeaderText = "器械价格";
			this.inPriceCol.MinimumWidth = 100;
			this.inPriceCol.Name = "inPriceCol";
			this.inPriceCol.ReadOnly = true;
			this.inPriceCol.Visible = false;
			// 
			// inRemarkCol
			// 
			this.inRemarkCol.HeaderText = "备注";
			this.inRemarkCol.Name = "inRemarkCol";
			// 
			// setLbl
			// 
			this.setLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setLbl.AutoSize = true;
			this.setLbl.Location = new System.Drawing.Point(3, 6);
			this.setLbl.Margin = new System.Windows.Forms.Padding(3);
			this.setLbl.Name = "setLbl";
			this.setLbl.Size = new System.Drawing.Size(105, 20);
			this.setLbl.TabIndex = 0;
			this.setLbl.Text = "器械包条码：";
			// 
			// setBarCodeTxt
			// 
			this.setBarCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setBarCodeTxt.Location = new System.Drawing.Point(114, 3);
			this.setBarCodeTxt.Name = "setBarCodeTxt";
			this.setBarCodeTxt.ReadOnly = true;
			this.setBarCodeTxt.Size = new System.Drawing.Size(209, 27);
			this.setBarCodeTxt.TabIndex = 1;
			// 
			// setNameTxt
			// 
			this.setNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNameTxt.Location = new System.Drawing.Point(440, 3);
			this.setNameTxt.Name = "setNameTxt";
			this.setNameTxt.ReadOnly = true;
			this.setNameTxt.Size = new System.Drawing.Size(209, 27);
			this.setNameTxt.TabIndex = 2;
			// 
			// setNameLbl
			// 
			this.setNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setNameLbl.AutoSize = true;
			this.setNameLbl.Location = new System.Drawing.Point(329, 6);
			this.setNameLbl.Margin = new System.Windows.Forms.Padding(3);
			this.setNameLbl.Name = "setNameLbl";
			this.setNameLbl.Size = new System.Drawing.Size(105, 20);
			this.setNameLbl.TabIndex = 8;
			this.setNameLbl.Text = "器械包名称：";
			// 
			// HCSWF_set_instrument_modify
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 625);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "HCSWF_set_instrument_modify";
			this.Padding = new System.Windows.Forms.Padding(27, 75, 27, 25);
			this.Text = "修改特殊包";
			this.mainPanel.ResumeLayout(false);
			this.ButtonPanel.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel ButtonPanel;
		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.Label setLbl;
		private System.Windows.Forms.TextBox setBarCodeTxt;
		private System.Windows.Forms.TextBox setNameTxt;
		private System.Windows.Forms.Label setNameLbl;
		private System.Windows.Forms.DataGridView instrumentGrid;
		private CnasMetroFramework.Controls.MetroTile confirmBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn inIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inPriceCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inRemarkCol;
	}
}