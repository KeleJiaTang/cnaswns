namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_load_car
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setPriortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.washingPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sterilizerPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userNameLbl = new System.Windows.Forms.Label();
			this.carNameLbl = new System.Windows.Forms.Label();
			this.carNumLbl = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.carNameTxt = new System.Windows.Forms.TextBox();
			this.setNumTxt = new System.Windows.Forms.TextBox();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.setDataGrid, 0, 3);
			this.mainPanel.Controls.Add(this.userNameLbl, 0, 0);
			this.mainPanel.Controls.Add(this.carNameLbl, 0, 1);
			this.mainPanel.Controls.Add(this.carNumLbl, 0, 2);
			this.mainPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.mainPanel.Controls.Add(this.carNameTxt, 1, 1);
			this.mainPanel.Controls.Add(this.setNumTxt, 1, 2);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 4;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(867, 617);
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
            this.washingPCol,
            this.sterilizerPCol,
            this.costCNameCol});
			this.mainPanel.SetColumnSpan(this.setDataGrid, 2);
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 95);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.ReadOnly = true;
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(867, 522);
			this.setDataGrid.TabIndex = 5;
			// 
			// setIdCol
			// 
			this.setIdCol.HeaderText = "编号";
			this.setIdCol.Name = "setIdCol";
			this.setIdCol.ReadOnly = true;
			this.setIdCol.Visible = false;
			this.setIdCol.Width = 60;
			// 
			// setBarCodeCol
			// 
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setBarCodeCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			this.setNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle9;
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			// 
			// setTypeCol
			// 
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setTypeCol.DefaultCellStyle = dataGridViewCellStyle10;
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Width = 120;
			// 
			// setPriortyCol
			// 
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setPriortyCol.DefaultCellStyle = dataGridViewCellStyle11;
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			// 
			// washingPCol
			// 
			this.washingPCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.washingPCol.DefaultCellStyle = dataGridViewCellStyle12;
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			// 
			// sterilizerPCol
			// 
			this.sterilizerPCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sterilizerPCol.DefaultCellStyle = dataGridViewCellStyle13;
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			// 
			// costCNameCol
			// 
			this.costCNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle14;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			// 
			// userNameLbl
			// 
			this.userNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.userNameLbl.AutoSize = true;
			this.userNameLbl.Location = new System.Drawing.Point(12, 7);
			this.userNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.userNameLbl.Name = "userNameLbl";
			this.userNameLbl.Size = new System.Drawing.Size(97, 20);
			this.userNameLbl.TabIndex = 1;
			this.userNameLbl.Text = "用          户：";
			// 
			// carNameLbl
			// 
			this.carNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNameLbl.AutoSize = true;
			this.carNameLbl.Location = new System.Drawing.Point(12, 39);
			this.carNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.carNameLbl.Name = "carNameLbl";
			this.carNameLbl.Size = new System.Drawing.Size(97, 20);
			this.carNameLbl.TabIndex = 2;
			this.carNameLbl.Text = "运   输   车：";
			// 
			// carNumLbl
			// 
			this.carNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNumLbl.AutoSize = true;
			this.carNumLbl.Location = new System.Drawing.Point(4, 69);
			this.carNumLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.carNumLbl.Name = "carNumLbl";
			this.carNumLbl.Size = new System.Drawing.Size(105, 20);
			this.carNumLbl.TabIndex = 3;
			this.carNumLbl.Text = "器械包数量：";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTxt.Location = new System.Drawing.Point(117, 4);
			this.userNameTxt.Margin = new System.Windows.Forms.Padding(4);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(746, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// carNameTxt
			// 
			this.carNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.carNameTxt.Location = new System.Drawing.Point(117, 36);
			this.carNameTxt.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
			this.carNameTxt.Name = "carNameTxt";
			this.carNameTxt.ReadOnly = true;
			this.carNameTxt.Size = new System.Drawing.Size(746, 27);
			this.carNameTxt.TabIndex = 3;
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNumTxt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.setNumTxt.Location = new System.Drawing.Point(117, 68);
			this.setNumTxt.Margin = new System.Windows.Forms.Padding(4);
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.Size = new System.Drawing.Size(746, 23);
			this.setNumTxt.TabIndex = 4;
			// 
			// HCSWF_load_car
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "HCSWF_load_car";
			this.Size = new System.Drawing.Size(867, 617);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.Label userNameLbl;
		private System.Windows.Forms.Label carNameLbl;
		private System.Windows.Forms.Label carNumLbl;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.TextBox carNameTxt;
		private System.Windows.Forms.TextBox setNumTxt;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn washingPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
	}
}
