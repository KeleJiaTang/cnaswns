namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_set_device_load
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
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
			this.detailPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lbProgram = new System.Windows.Forms.Label();
			this.txtProgramName = new System.Windows.Forms.TextBox();
			this.lbPackage = new System.Windows.Forms.Label();
			this.setNumTxt = new System.Windows.Forms.TextBox();
			this.lbBatch = new System.Windows.Forms.Label();
			this.txtBatch = new System.Windows.Forms.TextBox();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.machineTxt = new System.Windows.Forms.TextBox();
			this.lbMachine = new System.Windows.Forms.Label();
			this.lbUser = new System.Windows.Forms.Label();
			this.btnChange = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.detailPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 1;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.Size = new System.Drawing.Size(450, 450);
			this.mainPanel.TabIndex = 0;
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 1;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.setDataGrid, 0, 1);
			this.leftPanel.Controls.Add(this.detailPanel, 0, 0);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 2;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Size = new System.Drawing.Size(869, 688);
			this.leftPanel.TabIndex = 0;
			// 
			// setDataGrid
			// 
			this.setDataGrid.AllowUserToAddRows = false;
			this.setDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
			this.setDataGrid.Location = new System.Drawing.Point(1, 105);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.ReadOnly = true;
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(867, 580);
			this.setDataGrid.TabIndex = 7;
			// 
			// setIdCol
			// 
			this.setIdCol.HeaderText = "编号";
			this.setIdCol.MinimumWidth = 70;
			this.setIdCol.Name = "setIdCol";
			this.setIdCol.ReadOnly = true;
			this.setIdCol.Visible = false;
			this.setIdCol.Width = 70;
			// 
			// setBarCodeCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setBarCodeCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 120;
			// 
			// setTypeCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setTypeCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Width = 120;
			// 
			// setPriortyCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setPriortyCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.MinimumWidth = 55;
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			// 
			// setUseLoCol
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setUseLoCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.setUseLoCol.HeaderText = "使用地点";
			this.setUseLoCol.MinimumWidth = 100;
			this.setUseLoCol.Name = "setUseLoCol";
			this.setUseLoCol.ReadOnly = true;
			// 
			// washingPCol
			// 
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.washingPCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			// 
			// sterilizerPCol
			// 
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sterilizerPCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			// 
			// detailPanel
			// 
			this.detailPanel.ColumnCount = 5;
			this.detailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.detailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.detailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.detailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.detailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.detailPanel.Controls.Add(this.lbProgram, 2, 1);
			this.detailPanel.Controls.Add(this.txtProgramName, 3, 1);
			this.detailPanel.Controls.Add(this.lbPackage, 0, 2);
			this.detailPanel.Controls.Add(this.setNumTxt, 1, 2);
			this.detailPanel.Controls.Add(this.lbBatch, 2, 2);
			this.detailPanel.Controls.Add(this.txtBatch, 3, 2);
			this.detailPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.detailPanel.Controls.Add(this.machineTxt, 1, 1);
			this.detailPanel.Controls.Add(this.lbMachine, 0, 1);
			this.detailPanel.Controls.Add(this.lbUser, 0, 0);
			this.detailPanel.Controls.Add(this.btnChange, 4, 2);
			this.detailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailPanel.Location = new System.Drawing.Point(0, 0);
			this.detailPanel.Margin = new System.Windows.Forms.Padding(0);
			this.detailPanel.Name = "detailPanel";
			this.detailPanel.RowCount = 3;
			this.detailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.detailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.detailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.detailPanel.Size = new System.Drawing.Size(869, 102);
			this.detailPanel.TabIndex = 0;
			// 
			// lbProgram
			// 
			this.lbProgram.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbProgram.AutoSize = true;
			this.lbProgram.Location = new System.Drawing.Point(313, 39);
			this.lbProgram.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.lbProgram.Name = "lbProgram";
			this.lbProgram.Size = new System.Drawing.Size(89, 20);
			this.lbProgram.TabIndex = 5;
			this.lbProgram.Text = "程序名称：";
			// 
			// txtProgramName
			// 
			this.txtProgramName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProgramName.Location = new System.Drawing.Point(408, 36);
			this.txtProgramName.Name = "txtProgramName";
			this.txtProgramName.ReadOnly = true;
			this.txtProgramName.Size = new System.Drawing.Size(200, 27);
			this.txtProgramName.TabIndex = 3;
			// 
			// lbPackage
			// 
			this.lbPackage.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbPackage.AutoSize = true;
			this.lbPackage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lbPackage.Location = new System.Drawing.Point(4, 74);
			this.lbPackage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPackage.Name = "lbPackage";
			this.lbPackage.Size = new System.Drawing.Size(89, 20);
			this.lbPackage.TabIndex = 7;
			this.lbPackage.Text = "数        量：";
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNumTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.setNumTxt.Location = new System.Drawing.Point(100, 70);
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.Size = new System.Drawing.Size(200, 27);
			this.setNumTxt.TabIndex = 4;
			this.setNumTxt.Text = "0";
			this.setNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbBatch
			// 
			this.lbBatch.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbBatch.AutoSize = true;
			this.lbBatch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lbBatch.Location = new System.Drawing.Point(313, 74);
			this.lbBatch.Margin = new System.Windows.Forms.Padding(3);
			this.lbBatch.Name = "lbBatch";
			this.lbBatch.Size = new System.Drawing.Size(89, 20);
			this.lbBatch.TabIndex = 9;
			this.lbBatch.Text = "批        次：";
			// 
			// txtBatch
			// 
			this.txtBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBatch.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtBatch.ForeColor = System.Drawing.Color.DarkSeaGreen;
			this.txtBatch.Location = new System.Drawing.Point(408, 69);
			this.txtBatch.MaxLength = 10;
			this.txtBatch.Name = "txtBatch";
			this.txtBatch.ReadOnly = true;
			this.txtBatch.Size = new System.Drawing.Size(200, 29);
			this.txtBatch.TabIndex = 5;
			this.txtBatch.Text = "888";
			this.txtBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBatch.TextChanged += new System.EventHandler(this.txtBatch_TextChanged);
			this.txtBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTxtBatchKeyDown);
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.detailPanel.SetColumnSpan(this.userNameTxt, 3);
			this.userNameTxt.Location = new System.Drawing.Point(100, 3);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(508, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// machineTxt
			// 
			this.machineTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.machineTxt.BackColor = System.Drawing.SystemColors.Control;
			this.machineTxt.Location = new System.Drawing.Point(100, 36);
			this.machineTxt.Name = "machineTxt";
			this.machineTxt.ReadOnly = true;
			this.machineTxt.Size = new System.Drawing.Size(200, 27);
			this.machineTxt.TabIndex = 2;
			// 
			// lbMachine
			// 
			this.lbMachine.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbMachine.AutoSize = true;
			this.lbMachine.Location = new System.Drawing.Point(4, 39);
			this.lbMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbMachine.Name = "lbMachine";
			this.lbMachine.Size = new System.Drawing.Size(89, 20);
			this.lbMachine.TabIndex = 0;
			this.lbMachine.Text = "机器名称：";
			// 
			// lbUser
			// 
			this.lbUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbUser.AutoSize = true;
			this.lbUser.Location = new System.Drawing.Point(4, 6);
			this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUser.Name = "lbUser";
			this.lbUser.Size = new System.Drawing.Size(89, 20);
			this.lbUser.TabIndex = 3;
			this.lbUser.Text = "用        户：";
			// 
			// btnChange
			// 
			this.btnChange.ActiveControl = null;
			this.btnChange.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnChange.Location = new System.Drawing.Point(621, 69);
			this.btnChange.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(105, 30);
			this.btnChange.TabIndex = 6;
			this.btnChange.Text = "变更批次编号 ";
			this.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnChange.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChange.UseSelectable = true;
			this.btnChange.UseTileImage = true;
			this.btnChange.Click += new System.EventHandler(this.btnChangce_Click);
			// 
			// HCSWF_set_device_load
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(600, 562);
			this.Name = "HCSWF_set_device_load";
			this.Size = new System.Drawing.Size(869, 688);
			this.leftPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.detailPanel.ResumeLayout(false);
			this.detailPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.TableLayoutPanel detailPanel;
		private System.Windows.Forms.Label lbMachine;
		private System.Windows.Forms.Label lbUser;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.Label lbProgram;
		private System.Windows.Forms.TextBox txtProgramName;
		private System.Windows.Forms.TextBox machineTxt;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.Label lbPackage;
		private System.Windows.Forms.TextBox setNumTxt;
		private System.Windows.Forms.Label lbBatch;
		private System.Windows.Forms.TextBox txtBatch;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setUseLoCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn washingPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private CnasMetroFramework.Controls.MetroTile btnChange;
	}
}