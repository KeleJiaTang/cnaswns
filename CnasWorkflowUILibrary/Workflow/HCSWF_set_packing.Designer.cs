namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_set_packing
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.instrumentGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isPackagedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userLbl = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.txtConfirmName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.setLbl = new System.Windows.Forms.Label();
			this.setNameTxt = new System.Windows.Forms.TextBox();
			this.useLocationLbl = new System.Windows.Forms.Label();
			this.useLocationTxt = new System.Windows.Forms.TextBox();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 4;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.Controls.Add(this.instrumentGrid, 0, 2);
			this.mainPanel.Controls.Add(this.userLbl, 0, 0);
			this.mainPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.mainPanel.Controls.Add(this.txtConfirmName, 3, 0);
			this.mainPanel.Controls.Add(this.label1, 2, 0);
			this.mainPanel.Controls.Add(this.setLbl, 0, 1);
			this.mainPanel.Controls.Add(this.setNameTxt, 1, 1);
			this.mainPanel.Controls.Add(this.useLocationLbl, 2, 1);
			this.mainPanel.Controls.Add(this.useLocationTxt, 3, 1);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 3;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.Size = new System.Drawing.Size(717, 400);
			this.mainPanel.TabIndex = 0;
			// 
			// instrumentGrid
			// 
			this.instrumentGrid.AllowUserToAddRows = false;
			this.instrumentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.instrumentGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.instrumentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.instrumentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.inNameCol,
            this.inTypeCol,
            this.inNumCol,
            this.isPackagedCol,
            this.costCNameCol,
            this.inPriceCol});
			this.mainPanel.SetColumnSpan(this.instrumentGrid, 4);
			this.instrumentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.instrumentGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.instrumentGrid.Location = new System.Drawing.Point(3, 66);
			this.instrumentGrid.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.instrumentGrid.Name = "instrumentGrid";
			this.instrumentGrid.RowHeadersVisible = false;
			this.instrumentGrid.RowTemplate.Height = 23;
			this.instrumentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.instrumentGrid.Size = new System.Drawing.Size(711, 334);
			this.instrumentGrid.TabIndex = 11;
			this.instrumentGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnIntrumentGridKeyDown);
			// 
			// idCol
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.idCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			this.idCol.Width = 60;
			// 
			// inNameCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inNameCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.inNameCol.HeaderText = "名 称";
			this.inNameCol.MinimumWidth = 150;
			this.inNameCol.Name = "inNameCol";
			this.inNameCol.ReadOnly = true;
			this.inNameCol.Width = 250;
			// 
			// inTypeCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inTypeCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.inTypeCol.HeaderText = "器械类型";
			this.inTypeCol.MinimumWidth = 120;
			this.inTypeCol.Name = "inTypeCol";
			this.inTypeCol.ReadOnly = true;
			this.inTypeCol.Width = 180;
			// 
			// inNumCol
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N0";
			dataGridViewCellStyle4.NullValue = null;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inNumCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.inNumCol.HeaderText = "器械数量";
			this.inNumCol.MinimumWidth = 120;
			this.inNumCol.Name = "inNumCol";
			this.inNumCol.ReadOnly = true;
			this.inNumCol.Width = 120;
			// 
			// isPackagedCol
			// 
			this.isPackagedCol.HeaderText = "已打包";
			this.isPackagedCol.MinimumWidth = 80;
			this.isPackagedCol.Name = "isPackagedCol";
			this.isPackagedCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.isPackagedCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.isPackagedCol.Width = 120;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 120;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Visible = false;
			this.costCNameCol.Width = 180;
			// 
			// inPriceCol
			// 
			dataGridViewCellStyle6.Format = "C2";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inPriceCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.inPriceCol.HeaderText = "器械价格";
			this.inPriceCol.MinimumWidth = 120;
			this.inPriceCol.Name = "inPriceCol";
			this.inPriceCol.ReadOnly = true;
			this.inPriceCol.Visible = false;
			this.inPriceCol.Width = 120;
			// 
			// userLbl
			// 
			this.userLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.userLbl.AutoSize = true;
			this.userLbl.Location = new System.Drawing.Point(3, 6);
			this.userLbl.Margin = new System.Windows.Forms.Padding(3);
			this.userLbl.Name = "userLbl";
			this.userLbl.Size = new System.Drawing.Size(89, 20);
			this.userLbl.TabIndex = 0;
			this.userLbl.Text = "打  包  员：";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTxt.Location = new System.Drawing.Point(98, 3);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(252, 27);
			this.userNameTxt.TabIndex = 2;
			// 
			// txtConfirmName
			// 
			this.txtConfirmName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConfirmName.Location = new System.Drawing.Point(461, 3);
			this.txtConfirmName.MaxLength = 50;
			this.txtConfirmName.Name = "txtConfirmName";
			this.txtConfirmName.Size = new System.Drawing.Size(253, 27);
			this.txtConfirmName.TabIndex = 13;
			this.txtConfirmName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCfmUserKeyDown);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(366, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 11;
			this.label1.Text = "审  核  员：";
			// 
			// setLbl
			// 
			this.setLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setLbl.AutoSize = true;
			this.setLbl.Location = new System.Drawing.Point(3, 39);
			this.setLbl.Margin = new System.Windows.Forms.Padding(3);
			this.setLbl.Name = "setLbl";
			this.setLbl.Size = new System.Drawing.Size(89, 20);
			this.setLbl.TabIndex = 1;
			this.setLbl.Text = "器  械  包：";
			// 
			// setNameTxt
			// 
			this.setNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNameTxt.Location = new System.Drawing.Point(98, 36);
			this.setNameTxt.Name = "setNameTxt";
			this.setNameTxt.ReadOnly = true;
			this.setNameTxt.Size = new System.Drawing.Size(252, 27);
			this.setNameTxt.TabIndex = 4;
			// 
			// useLocationLbl
			// 
			this.useLocationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.useLocationLbl.AutoSize = true;
			this.useLocationLbl.Location = new System.Drawing.Point(366, 39);
			this.useLocationLbl.Margin = new System.Windows.Forms.Padding(3);
			this.useLocationLbl.Name = "useLocationLbl";
			this.useLocationLbl.Size = new System.Drawing.Size(89, 20);
			this.useLocationLbl.TabIndex = 2;
			this.useLocationLbl.Text = "使用地点：";
			// 
			// useLocationTxt
			// 
			this.useLocationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useLocationTxt.Location = new System.Drawing.Point(461, 36);
			this.useLocationTxt.Name = "useLocationTxt";
			this.useLocationTxt.ReadOnly = true;
			this.useLocationTxt.Size = new System.Drawing.Size(253, 27);
			this.useLocationTxt.TabIndex = 10;
			// 
			// HCSWF_set_packing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "HCSWF_set_packing";
			this.Size = new System.Drawing.Size(717, 400);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.DataGridView instrumentGrid;
		private System.Windows.Forms.Label userLbl;
		private System.Windows.Forms.Label setLbl;
		private System.Windows.Forms.Label useLocationLbl;
		private System.Windows.Forms.TextBox setNameTxt;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.TextBox useLocationTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtConfirmName;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNumCol;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isPackagedCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inPriceCol;
	}
}
