namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_access_car
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.InfoDescription = new System.Windows.Forms.TableLayoutPanel();
			this.areaLbl = new System.Windows.Forms.Label();
			this.carNumTxt = new System.Windows.Forms.TextBox();
			this.carNumLbl = new System.Windows.Forms.Label();
			this.areaTxt = new System.Windows.Forms.TextBox();
			this.userLbl = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.carDataGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.carCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.runTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.leftPanel.SuspendLayout();
			this.InfoDescription.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.carDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 1;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.InfoDescription, 0, 0);
			this.leftPanel.Controls.Add(this.carDataGrid, 0, 1);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 2;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Size = new System.Drawing.Size(1067, 750);
			this.leftPanel.TabIndex = 0;
			// 
			// InfoDescription
			// 
			this.InfoDescription.ColumnCount = 4;
			this.InfoDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.InfoDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.InfoDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.InfoDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.InfoDescription.Controls.Add(this.areaLbl, 0, 1);
			this.InfoDescription.Controls.Add(this.carNumTxt, 3, 1);
			this.InfoDescription.Controls.Add(this.carNumLbl, 2, 1);
			this.InfoDescription.Controls.Add(this.areaTxt, 1, 1);
			this.InfoDescription.Controls.Add(this.userLbl, 0, 0);
			this.InfoDescription.Controls.Add(this.userNameTxt, 1, 0);
			this.InfoDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InfoDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.InfoDescription.Location = new System.Drawing.Point(0, 0);
			this.InfoDescription.Margin = new System.Windows.Forms.Padding(0);
			this.InfoDescription.Name = "InfoDescription";
			this.InfoDescription.RowCount = 2;
			this.InfoDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.InfoDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.InfoDescription.Size = new System.Drawing.Size(1067, 72);
			this.InfoDescription.TabIndex = 2;
			// 
			// areaLbl
			// 
			this.areaLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.areaLbl.AutoSize = true;
			this.areaLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.areaLbl.Location = new System.Drawing.Point(3, 40);
			this.areaLbl.Margin = new System.Windows.Forms.Padding(3);
			this.areaLbl.Name = "areaLbl";
			this.areaLbl.Size = new System.Drawing.Size(81, 20);
			this.areaLbl.TabIndex = 0;
			this.areaLbl.Text = "地      点：";
			this.areaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// carNumTxt
			// 
			this.carNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.carNumTxt.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.carNumTxt.ForeColor = System.Drawing.Color.DarkSeaGreen;
			this.carNumTxt.Location = new System.Drawing.Point(985, 32);
			this.carNumTxt.MinimumSize = new System.Drawing.Size(4, 30);
			this.carNumTxt.Name = "carNumTxt";
			this.carNumTxt.ReadOnly = true;
			this.carNumTxt.Size = new System.Drawing.Size(79, 35);
			this.carNumTxt.TabIndex = 3;
			this.carNumTxt.Text = "8888";
			this.carNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// carNumLbl
			// 
			this.carNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNumLbl.AutoSize = true;
			this.carNumLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.carNumLbl.Location = new System.Drawing.Point(874, 40);
			this.carNumLbl.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
			this.carNumLbl.Name = "carNumLbl";
			this.carNumLbl.Size = new System.Drawing.Size(105, 20);
			this.carNumLbl.TabIndex = 1;
			this.carNumLbl.Text = "运输车数量：";
			this.carNumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// areaTxt
			// 
			this.areaTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.areaTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.areaTxt.Location = new System.Drawing.Point(90, 36);
			this.areaTxt.Name = "areaTxt";
			this.areaTxt.ReadOnly = true;
			this.areaTxt.Size = new System.Drawing.Size(768, 27);
			this.areaTxt.TabIndex = 2;
			// 
			// userLbl
			// 
			this.userLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.userLbl.AutoSize = true;
			this.userLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.userLbl.Location = new System.Drawing.Point(3, 4);
			this.userLbl.Margin = new System.Windows.Forms.Padding(3);
			this.userLbl.Name = "userLbl";
			this.userLbl.Size = new System.Drawing.Size(81, 20);
			this.userLbl.TabIndex = 4;
			this.userLbl.Text = "用      户：";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.InfoDescription.SetColumnSpan(this.userNameTxt, 3);
			this.userNameTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.userNameTxt.Location = new System.Drawing.Point(90, 3);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(974, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// carDataGrid
			// 
			this.carDataGrid.AllowUserToAddRows = false;
			this.carDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.carDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.carDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.carDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.carCodeCol,
            this.nameCol,
            this.setNumCol,
            this.runTimeCol});
			this.carDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.carDataGrid.Location = new System.Drawing.Point(0, 72);
			this.carDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.carDataGrid.MultiSelect = false;
			this.carDataGrid.Name = "carDataGrid";
			this.carDataGrid.RowHeadersVisible = false;
			this.carDataGrid.RowTemplate.Height = 23;
			this.carDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.carDataGrid.ShowCellErrors = false;
			this.carDataGrid.Size = new System.Drawing.Size(1067, 678);
			this.carDataGrid.TabIndex = 4;
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.idCol.Visible = false;
			this.idCol.Width = 75;
			// 
			// carCodeCol
			// 
			dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.carCodeCol.DefaultCellStyle = dataGridViewCellStyle17;
			this.carCodeCol.HeaderText = "运输车条码";
			this.carCodeCol.Name = "carCodeCol";
			this.carCodeCol.ReadOnly = true;
			this.carCodeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.carCodeCol.Width = 120;
			// 
			// nameCol
			// 
			this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.nameCol.DefaultCellStyle = dataGridViewCellStyle18;
			this.nameCol.HeaderText = "运输车名称";
			this.nameCol.MinimumWidth = 120;
			this.nameCol.Name = "nameCol";
			this.nameCol.ReadOnly = true;
			// 
			// setNumCol
			// 
			dataGridViewCellStyle19.Format = "N0";
			dataGridViewCellStyle19.NullValue = null;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNumCol.DefaultCellStyle = dataGridViewCellStyle19;
			this.setNumCol.HeaderText = "器械包数量";
			this.setNumCol.MinimumWidth = 120;
			this.setNumCol.Name = "setNumCol";
			this.setNumCol.ReadOnly = true;
			this.setNumCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.setNumCol.Width = 120;
			// 
			// runTimeCol
			// 
			dataGridViewCellStyle20.Format = "N0";
			dataGridViewCellStyle20.NullValue = null;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.runTimeCol.DefaultCellStyle = dataGridViewCellStyle20;
			this.runTimeCol.HeaderText = "使用次数";
			this.runTimeCol.MinimumWidth = 100;
			this.runTimeCol.Name = "runTimeCol";
			this.runTimeCol.ReadOnly = true;
			this.runTimeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// HCSWF_access_car
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(667, 500);
			this.Name = "HCSWF_access_car";
			this.Size = new System.Drawing.Size(1067, 750);
			this.leftPanel.ResumeLayout(false);
			this.InfoDescription.ResumeLayout(false);
			this.InfoDescription.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.carDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.TableLayoutPanel InfoDescription;
		private System.Windows.Forms.Label areaLbl;
		private System.Windows.Forms.TextBox areaTxt;
		private System.Windows.Forms.Label carNumLbl;
		private System.Windows.Forms.TextBox carNumTxt;
		private System.Windows.Forms.DataGridView carDataGrid;
		private System.Windows.Forms.Label userLbl;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn carCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn runTimeCol;

	}
}