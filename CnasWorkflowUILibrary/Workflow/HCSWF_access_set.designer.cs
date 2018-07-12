namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_access_set
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.lbpackageCount = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.setNumTxt = new System.Windows.Forms.TextBox();
			this.lbUser = new System.Windows.Forms.Label();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 2;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.setDataGrid, 0, 2);
			this.leftPanel.Controls.Add(this.lbpackageCount, 0, 1);
			this.leftPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.leftPanel.Controls.Add(this.setNumTxt, 1, 1);
			this.leftPanel.Controls.Add(this.lbUser, 0, 0);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 3;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Size = new System.Drawing.Size(1067, 1000);
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
			this.leftPanel.SetColumnSpan(this.setDataGrid, 2);
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 74);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(1067, 926);
			this.setDataGrid.TabIndex = 3;
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
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setBarCodeCol.DefaultCellStyle = dataGridViewCellStyle9;
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle10;
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 120;
			// 
			// setTypeCol
			// 
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setTypeCol.DefaultCellStyle = dataGridViewCellStyle11;
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Width = 120;
			// 
			// setPriortyCol
			// 
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setPriortyCol.DefaultCellStyle = dataGridViewCellStyle12;
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.MinimumWidth = 55;
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			// 
			// setUseLoCol
			// 
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setUseLoCol.DefaultCellStyle = dataGridViewCellStyle13;
			this.setUseLoCol.HeaderText = "使用地点";
			this.setUseLoCol.MinimumWidth = 100;
			this.setUseLoCol.Name = "setUseLoCol";
			// 
			// washingPCol
			// 
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.washingPCol.DefaultCellStyle = dataGridViewCellStyle14;
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			// 
			// sterilizerPCol
			// 
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sterilizerPCol.DefaultCellStyle = dataGridViewCellStyle15;
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle16;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			// 
			// lbpackageCount
			// 
			this.lbpackageCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbpackageCount.AutoSize = true;
			this.lbpackageCount.Location = new System.Drawing.Point(4, 45);
			this.lbpackageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbpackageCount.Name = "lbpackageCount";
			this.lbpackageCount.Size = new System.Drawing.Size(105, 20);
			this.lbpackageCount.TabIndex = 2;
			this.lbpackageCount.Text = "器械包数量：";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTxt.Location = new System.Drawing.Point(117, 5);
			this.userNameTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(946, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNumTxt.Location = new System.Drawing.Point(117, 42);
			this.setNumTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.Size = new System.Drawing.Size(946, 27);
			this.setNumTxt.TabIndex = 2;
			// 
			// lbUser
			// 
			this.lbUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbUser.AutoSize = true;
			this.lbUser.Location = new System.Drawing.Point(8, 8);
			this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUser.Name = "lbUser";
			this.lbUser.Size = new System.Drawing.Size(101, 20);
			this.lbUser.TabIndex = 4;
			this.lbUser.Text = "用           户：";
			// 
			// HCSWF_access_set
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "HCSWF_access_set";
			this.Size = new System.Drawing.Size(1067, 1000);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.Label lbpackageCount;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.TextBox setNumTxt;
		private System.Windows.Forms.Label lbUser;
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

	}
}