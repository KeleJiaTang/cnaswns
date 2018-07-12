namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_check_car
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.setNumTxt = new System.Windows.Forms.TextBox();
			this.carNumLbl = new System.Windows.Forms.Label();
			this.carNameTxt = new System.Windows.Forms.TextBox();
			this.carNameLbl = new System.Windows.Forms.Label();
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setPriortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setUseLoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.washing_ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sterilizerPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BtnTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPri = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.BtnTablePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.BtnTablePanel, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 75);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 626);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.setNumTxt, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.carNumLbl, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.carNameTxt, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.carNameLbl, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.setDataGrid, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(917, 650);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNumTxt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.setNumTxt.Location = new System.Drawing.Point(101, 39);
			this.setNumTxt.Margin = new System.Windows.Forms.Padding(4);
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.Size = new System.Drawing.Size(812, 23);
			this.setNumTxt.TabIndex = 2;
			// 
			// carNumLbl
			// 
			this.carNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNumLbl.AutoSize = true;
			this.carNumLbl.Location = new System.Drawing.Point(4, 40);
			this.carNumLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.carNumLbl.Name = "carNumLbl";
			this.carNumLbl.Size = new System.Drawing.Size(89, 20);
			this.carNumLbl.TabIndex = 7;
			this.carNumLbl.Text = "器械包数量";
			// 
			// carNameTxt
			// 
			this.carNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.carNameTxt.Location = new System.Drawing.Point(101, 4);
			this.carNameTxt.Margin = new System.Windows.Forms.Padding(4);
			this.carNameTxt.Name = "carNameTxt";
			this.carNameTxt.ReadOnly = true;
			this.carNameTxt.Size = new System.Drawing.Size(812, 27);
			this.carNameTxt.TabIndex = 1;
			// 
			// carNameLbl
			// 
			this.carNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNameLbl.AutoSize = true;
			this.carNameLbl.Location = new System.Drawing.Point(20, 7);
			this.carNameLbl.Margin = new System.Windows.Forms.Padding(17, 0, 4, 0);
			this.carNameLbl.Name = "carNameLbl";
			this.carNameLbl.Size = new System.Drawing.Size(73, 20);
			this.carNameLbl.TabIndex = 4;
			this.carNameLbl.Text = "运  输  车";
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
            this.washing_ca_name,
            this.sterilizerPCol,
            this.costCNameCol});
			this.tableLayoutPanel2.SetColumnSpan(this.setDataGrid, 2);
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 66);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(917, 584);
			this.setDataGrid.TabIndex = 5;
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
			// 
			// washing_ca_name
			// 
			this.washing_ca_name.HeaderText = "清洗程序";
			this.washing_ca_name.MinimumWidth = 100;
			this.washing_ca_name.Name = "washing_ca_name";
			this.washing_ca_name.ReadOnly = true;
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
			// BtnTablePanel
			// 
			this.BtnTablePanel.ColumnCount = 1;
			this.BtnTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BtnTablePanel.Controls.Add(this.closeBtn, 0, 1);
			this.BtnTablePanel.Controls.Add(this.btnPri, 0, 0);
			this.BtnTablePanel.Location = new System.Drawing.Point(917, 0);
			this.BtnTablePanel.Margin = new System.Windows.Forms.Padding(0);
			this.BtnTablePanel.Name = "BtnTablePanel";
			this.BtnTablePanel.RowCount = 2;
			this.BtnTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BtnTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BtnTablePanel.Size = new System.Drawing.Size(96, 114);
			this.BtnTablePanel.TabIndex = 3;
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Location = new System.Drawing.Point(3, 49);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 4;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// btnPri
			// 
			this.btnPri.ActiveControl = null;
			this.btnPri.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPri.Location = new System.Drawing.Point(3, 3);
			this.btnPri.Name = "btnPri";
			this.btnPri.Size = new System.Drawing.Size(90, 40);
			this.btnPri.TabIndex = 3;
			this.btnPri.Text = "打 印 ";
			this.btnPri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPri.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPri.UseSelectable = true;
			this.btnPri.UseTileImage = true;
			this.btnPri.Click += new System.EventHandler(this.btnPri_Click);
			// 
			// HCSWF_check_car
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 726);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1067, 726);
			this.Name = "HCSWF_check_car";
			this.Padding = new System.Windows.Forms.Padding(27, 75, 27, 25);
			this.Text = "查看运输车";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.BtnTablePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.Label carNameLbl;
		private System.Windows.Forms.TextBox carNameTxt;
		private System.Windows.Forms.Label carNumLbl;
		private System.Windows.Forms.TextBox setNumTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setUseLoCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn washing_ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private System.Windows.Forms.TableLayoutPanel BtnTablePanel;
		private CnasMetroFramework.Controls.MetroTile btnPri;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
	}
}