namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_person_set
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.userLbl = new System.Windows.Forms.Label();
			this.areaLbl = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.personTxt = new System.Windows.Forms.TextBox();
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
			this.leftPanel.Controls.Add(this.userLbl, 0, 0);
			this.leftPanel.Controls.Add(this.areaLbl, 0, 1);
			this.leftPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.leftPanel.Controls.Add(this.personTxt, 1, 1);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 3;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.leftPanel.Size = new System.Drawing.Size(866, 630);
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
			this.setDataGrid.Location = new System.Drawing.Point(0, 70);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.ReadOnly = true;
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(866, 560);
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
			this.setNameCol.Width = 200;
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
			this.setUseLoCol.MinimumWidth = 80;
			this.setUseLoCol.Name = "setUseLoCol";
			this.setUseLoCol.ReadOnly = true;
			this.setUseLoCol.Width = 180;
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
			this.sterilizerPCol.Width = 180;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Width = 180;
			// 
			// userLbl
			// 
			this.userLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.userLbl.AutoSize = true;
			this.userLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userLbl.Location = new System.Drawing.Point(3, 7);
			this.userLbl.Margin = new System.Windows.Forms.Padding(3);
			this.userLbl.Name = "userLbl";
			this.userLbl.Size = new System.Drawing.Size(85, 20);
			this.userLbl.TabIndex = 6;
			this.userLbl.Text = "用       户：";
			// 
			// areaLbl
			// 
			this.areaLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.areaLbl.AutoSize = true;
			this.areaLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.areaLbl.Location = new System.Drawing.Point(3, 42);
			this.areaLbl.Margin = new System.Windows.Forms.Padding(3);
			this.areaLbl.Name = "areaLbl";
			this.areaLbl.Size = new System.Drawing.Size(85, 20);
			this.areaLbl.TabIndex = 0;
			this.areaLbl.Text = "病       人：";
			this.areaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTxt.Location = new System.Drawing.Point(95, 4);
			this.userNameTxt.Margin = new System.Windows.Forms.Padding(4);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(767, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// personTxt
			// 
			this.personTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.personTxt.Location = new System.Drawing.Point(95, 39);
			this.personTxt.Margin = new System.Windows.Forms.Padding(4);
			this.personTxt.Name = "personTxt";
			this.personTxt.Size = new System.Drawing.Size(767, 27);
			this.personTxt.TabIndex = 2;
			this.personTxt.Click += new System.EventHandler(this.OnPersonClick);
			this.personTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpEvent);
			// 
			// HCSWF_person_set
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "HCSWF_person_set";
			this.Size = new System.Drawing.Size(866, 630);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.Label areaLbl;
		private System.Windows.Forms.TextBox personTxt;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.Label userLbl;
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
