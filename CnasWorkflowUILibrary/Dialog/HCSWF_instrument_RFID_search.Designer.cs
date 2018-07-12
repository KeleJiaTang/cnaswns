namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_instrument_RFID_search
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.instrumentGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrumentSNCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.needNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.getNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isPackagedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
			this.setInfoPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setUseTxt = new Telerik.WinControls.UI.RadTextBox();
			this.setNameTxt = new Telerik.WinControls.UI.RadTextBox();
			this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
			this.setLbl = new Telerik.WinControls.UI.RadLabel();
			this.setBarCodeTxt = new Telerik.WinControls.UI.RadTextBox();
			this.btnSave = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
			this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
			this.txtReadScanCount = new Telerik.WinControls.UI.RadTextBox();
			this.txtUnReadScanCount = new Telerik.WinControls.UI.RadTextBox();
			this.lightBox = new System.Windows.Forms.PictureBox();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
			this.radGroupBox1.SuspendLayout();
			this.setInfoPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setUseTxt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.setNameTxt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.setLbl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.setBarCodeTxt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtReadScanCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUnReadScanCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lightBox)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 1;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.instrumentGrid, 0, 1);
			this.mainPanel.Controls.Add(this.radGroupBox1, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(1054, 459);
			this.mainPanel.TabIndex = 1;
			// 
			// instrumentGrid
			// 
			this.instrumentGrid.AllowUserToAddRows = false;
			this.instrumentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.instrumentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.instrumentGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.instrumentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.instrumentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.inNameCol,
            this.inTypeCol,
            this.instrumentSNCol,
            this.inNumCol,
            this.needNumCol,
            this.getNumCol,
            this.isPackagedCol,
            this.costCNameCol,
            this.inPriceCol});
			this.mainPanel.SetColumnSpan(this.instrumentGrid, 11);
			this.instrumentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.instrumentGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.instrumentGrid.Location = new System.Drawing.Point(0, 106);
			this.instrumentGrid.Margin = new System.Windows.Forms.Padding(0);
			this.instrumentGrid.Name = "instrumentGrid";
			this.instrumentGrid.RowHeadersVisible = false;
			this.instrumentGrid.RowTemplate.Height = 23;
			this.instrumentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.instrumentGrid.Size = new System.Drawing.Size(1054, 353);
			this.instrumentGrid.TabIndex = 8;
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			// 
			// inNameCol
			// 
			this.inNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inNameCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.inNameCol.HeaderText = "名 称";
			this.inNameCol.MinimumWidth = 200;
			this.inNameCol.Name = "inNameCol";
			this.inNameCol.ReadOnly = true;
			this.inNameCol.Width = 200;
			// 
			// inTypeCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inTypeCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.inTypeCol.HeaderText = "器械类型";
			this.inTypeCol.MinimumWidth = 100;
			this.inTypeCol.Name = "inTypeCol";
			this.inTypeCol.ReadOnly = true;
			// 
			// instrumentSNCol
			// 
			this.instrumentSNCol.HeaderText = "器械序列号";
			this.instrumentSNCol.Name = "instrumentSNCol";
			this.instrumentSNCol.Visible = false;
			// 
			// inNumCol
			// 
			dataGridViewCellStyle3.Format = "N0";
			dataGridViewCellStyle3.NullValue = null;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inNumCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.inNumCol.HeaderText = "器械数量";
			this.inNumCol.MinimumWidth = 150;
			this.inNumCol.Name = "inNumCol";
			this.inNumCol.ReadOnly = true;
			// 
			// needNumCol
			// 
			this.needNumCol.HeaderText = "RFID器械数量";
			this.needNumCol.MinimumWidth = 100;
			this.needNumCol.Name = "needNumCol";
			// 
			// getNumCol
			// 
			this.getNumCol.HeaderText = "实际rfid器械数量";
			this.getNumCol.MinimumWidth = 150;
			this.getNumCol.Name = "getNumCol";
			// 
			// isPackagedCol
			// 
			this.isPackagedCol.HeaderText = "已扫描";
			this.isPackagedCol.Name = "isPackagedCol";
			this.isPackagedCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.isPackagedCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.isPackagedCol.Visible = false;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 200;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Visible = false;
			// 
			// inPriceCol
			// 
			dataGridViewCellStyle5.Format = "C2";
			dataGridViewCellStyle5.NullValue = null;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inPriceCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.inPriceCol.HeaderText = "器械价格";
			this.inPriceCol.Name = "inPriceCol";
			this.inPriceCol.ReadOnly = true;
			this.inPriceCol.Visible = false;
			// 
			// radGroupBox1
			// 
			this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.radGroupBox1.Controls.Add(this.setInfoPanel);
			this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
			this.radGroupBox1.HeaderText = "";
			this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.radGroupBox1.Name = "radGroupBox1";
			this.radGroupBox1.Size = new System.Drawing.Size(1048, 100);
			this.radGroupBox1.TabIndex = 13;
			// 
			// setInfoPanel
			// 
			this.setInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.setInfoPanel.ColumnCount = 8;
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.setInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInfoPanel.Controls.Add(this.setUseTxt, 1, 1);
			this.setInfoPanel.Controls.Add(this.setNameTxt, 2, 0);
			this.setInfoPanel.Controls.Add(this.radLabel1, 0, 1);
			this.setInfoPanel.Controls.Add(this.setLbl, 0, 0);
			this.setInfoPanel.Controls.Add(this.setBarCodeTxt, 1, 0);
			this.setInfoPanel.Controls.Add(this.btnSave, 7, 0);
			this.setInfoPanel.Controls.Add(this.closeBtn, 7, 1);
			this.setInfoPanel.Controls.Add(this.radLabel2, 3, 0);
			this.setInfoPanel.Controls.Add(this.radLabel3, 3, 1);
			this.setInfoPanel.Controls.Add(this.txtReadScanCount, 4, 0);
			this.setInfoPanel.Controls.Add(this.txtUnReadScanCount, 4, 1);
			this.setInfoPanel.Controls.Add(this.lightBox, 5, 0);
			this.setInfoPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setInfoPanel.Location = new System.Drawing.Point(2, 2);
			this.setInfoPanel.Name = "setInfoPanel";
			this.setInfoPanel.RowCount = 2;
			this.setInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.setInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.setInfoPanel.Size = new System.Drawing.Size(1044, 96);
			this.setInfoPanel.TabIndex = 0;
			// 
			// setUseTxt
			// 
			this.setUseTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.setInfoPanel.SetColumnSpan(this.setUseTxt, 2);
			this.setUseTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setUseTxt.Location = new System.Drawing.Point(80, 53);
			this.setUseTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
			this.setUseTxt.Name = "setUseTxt";
			this.setUseTxt.ReadOnly = true;
			this.setUseTxt.Size = new System.Drawing.Size(406, 25);
			this.setUseTxt.TabIndex = 5;
			// 
			// setNameTxt
			// 
			this.setNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.setNameTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setNameTxt.Location = new System.Drawing.Point(286, 13);
			this.setNameTxt.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.setNameTxt.Name = "setNameTxt";
			this.setNameTxt.ReadOnly = true;
			this.setNameTxt.Size = new System.Drawing.Size(200, 25);
			this.setNameTxt.TabIndex = 3;
			// 
			// radLabel1
			// 
			this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel1.Location = new System.Drawing.Point(3, 53);
			this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new System.Drawing.Size(68, 23);
			this.radLabel1.TabIndex = 1;
			this.radLabel1.Text = "使用地点";
			// 
			// setLbl
			// 
			this.setLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.setLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setLbl.Location = new System.Drawing.Point(3, 15);
			this.setLbl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.setLbl.Name = "setLbl";
			this.setLbl.Size = new System.Drawing.Size(71, 23);
			this.setLbl.TabIndex = 0;
			this.setLbl.Text = "器  械  包";
			// 
			// setBarCodeTxt
			// 
			this.setBarCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.setBarCodeTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setBarCodeTxt.Location = new System.Drawing.Point(80, 13);
			this.setBarCodeTxt.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.setBarCodeTxt.Name = "setBarCodeTxt";
			this.setBarCodeTxt.ReadOnly = true;
			this.setBarCodeTxt.Size = new System.Drawing.Size(200, 25);
			this.setBarCodeTxt.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.ActiveControl = null;
			this.btnSave.Location = new System.Drawing.Point(952, 0);
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 40);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "确 认";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.UseSelectable = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Location = new System.Drawing.Point(952, 48);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 7;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// radLabel2
			// 
			this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel2.Location = new System.Drawing.Point(499, 15);
			this.radLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
			this.radLabel2.Name = "radLabel2";
			this.radLabel2.Size = new System.Drawing.Size(55, 23);
			this.radLabel2.TabIndex = 27;
			this.radLabel2.Text = "已扫描";
			// 
			// radLabel3
			// 
			this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel3.Location = new System.Drawing.Point(499, 53);
			this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.radLabel3.Name = "radLabel3";
			this.radLabel3.Size = new System.Drawing.Size(55, 23);
			this.radLabel3.TabIndex = 29;
			this.radLabel3.Text = "未扫描";
			// 
			// txtReadScanCount
			// 
			this.txtReadScanCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReadScanCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReadScanCount.ForeColor = System.Drawing.Color.Red;
			this.txtReadScanCount.Location = new System.Drawing.Point(560, 13);
			this.txtReadScanCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.txtReadScanCount.Name = "txtReadScanCount";
			this.txtReadScanCount.ReadOnly = true;
			this.txtReadScanCount.Size = new System.Drawing.Size(172, 25);
			this.txtReadScanCount.TabIndex = 4;
			// 
			// txtUnReadScanCount
			// 
			this.txtUnReadScanCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnReadScanCount.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.txtUnReadScanCount.ForeColor = System.Drawing.Color.OrangeRed;
			this.txtUnReadScanCount.Location = new System.Drawing.Point(560, 53);
			this.txtUnReadScanCount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
			this.txtUnReadScanCount.Name = "txtUnReadScanCount";
			this.txtUnReadScanCount.ReadOnly = true;
			this.txtUnReadScanCount.Size = new System.Drawing.Size(172, 25);
			this.txtUnReadScanCount.TabIndex = 6;
			// 
			// lightBox
			// 
			this.lightBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lightBox.Location = new System.Drawing.Point(769, 14);
			this.lightBox.Margin = new System.Windows.Forms.Padding(20, 14, 20, 20);
			this.lightBox.Name = "lightBox";
			this.setInfoPanel.SetRowSpan(this.lightBox, 2);
			this.lightBox.Size = new System.Drawing.Size(90, 62);
			this.lightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lightBox.TabIndex = 22;
			this.lightBox.TabStop = false;
			// 
			// HCSWF_instrument_RFID_search
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1094, 539);
			this.Controls.Add(this.mainPanel);
			this.Name = "HCSWF_instrument_RFID_search";
			this.Text = "RFID追踪管理";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HCSWF_instrument_RFID_search_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.Load += new System.EventHandler(this.OnDialogLoad);
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
			this.radGroupBox1.ResumeLayout(false);
			this.setInfoPanel.ResumeLayout(false);
			this.setInfoPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.setUseTxt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.setNameTxt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.setLbl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.setBarCodeTxt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtReadScanCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUnReadScanCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lightBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.DataGridView instrumentGrid;
		private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
		private System.Windows.Forms.TableLayoutPanel setInfoPanel;
		private Telerik.WinControls.UI.RadLabel setLbl;
		private Telerik.WinControls.UI.RadLabel radLabel1;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
		private Telerik.WinControls.UI.RadTextBox setBarCodeTxt;
		private Telerik.WinControls.UI.RadTextBox setUseTxt;
		private Telerik.WinControls.UI.RadTextBox setNameTxt;
		private System.Windows.Forms.PictureBox lightBox;
		private CnasMetroFramework.Controls.MetroTile btnSave;
		private Telerik.WinControls.UI.RadTextBox txtReadScanCount;
		private Telerik.WinControls.UI.RadLabel radLabel2;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn instrumentSNCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn needNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn getNumCol;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isPackagedCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inPriceCol;
		private Telerik.WinControls.UI.RadTextBox txtUnReadScanCount;
		private Telerik.WinControls.UI.RadLabel radLabel3;
	}
}