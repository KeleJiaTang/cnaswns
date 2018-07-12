namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_check_send_setlist
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setUseLoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setPriortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sendTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnsPanel = new System.Windows.Forms.TableLayoutPanel();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupPanel = new System.Windows.Forms.TableLayoutPanel();
			this.customerLbl = new System.Windows.Forms.Label();
			this.customerTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.useLocationTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.setNumTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.useLocationLbl = new System.Windows.Forms.Label();
			this.carNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.setNumLbl = new System.Windows.Forms.Label();
			this.carNameLbl = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.btnsPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.setDataGrid, 0, 1);
			this.mainPanel.Controls.Add(this.btnsPanel, 1, 0);
			this.mainPanel.Controls.Add(this.groupBox1, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(21, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(866, 608);
			this.mainPanel.TabIndex = 0;
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
            this.setUseLoCol,
            this.setPriortyCol,
            this.sendTimeCol,
            this.setTypeCol,
            this.remarkCol});
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(3, 109);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(764, 496);
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
			this.setNameCol.Width = 180;
			// 
			// setUseLoCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setUseLoCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.setUseLoCol.HeaderText = "使用地点";
			this.setUseLoCol.MinimumWidth = 100;
			this.setUseLoCol.Name = "setUseLoCol";
			this.setUseLoCol.Width = 180;
			// 
			// setPriortyCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setPriortyCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.MinimumWidth = 80;
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			this.setPriortyCol.Visible = false;
			// 
			// sendTimeCol
			// 
			dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sendTimeCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.sendTimeCol.HeaderText = "发送时间";
			this.sendTimeCol.MinimumWidth = 100;
			this.sendTimeCol.Name = "sendTimeCol";
			this.sendTimeCol.ReadOnly = true;
			this.sendTimeCol.Width = 180;
			// 
			// setTypeCol
			// 
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setTypeCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Visible = false;
			this.setTypeCol.Width = 120;
			// 
			// remarkCol
			// 
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.remarkCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.remarkCol.HeaderText = "备 注";
			this.remarkCol.MinimumWidth = 100;
			this.remarkCol.Name = "remarkCol";
			this.remarkCol.ReadOnly = true;
			// 
			// btnsPanel
			// 
			this.btnsPanel.ColumnCount = 1;
			this.btnsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnsPanel.Controls.Add(this.printBtn, 0, 0);
			this.btnsPanel.Controls.Add(this.closeBtn, 0, 1);
			this.btnsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnsPanel.Location = new System.Drawing.Point(770, 0);
			this.btnsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnsPanel.Name = "btnsPanel";
			this.btnsPanel.RowCount = 2;
			this.mainPanel.SetRowSpan(this.btnsPanel, 2);
			this.btnsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnsPanel.Size = new System.Drawing.Size(96, 608);
			this.btnsPanel.TabIndex = 0;
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(3, 13);
			this.printBtn.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 5;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.OnPrintBtnClick);
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Location = new System.Drawing.Point(3, 61);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 6;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupPanel);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(764, 100);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupPanel
			// 
			this.groupPanel.ColumnCount = 4;
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.groupPanel.Controls.Add(this.customerLbl, 0, 0);
			this.groupPanel.Controls.Add(this.customerTxt, 1, 0);
			this.groupPanel.Controls.Add(this.useLocationTxt, 2, 0);
			this.groupPanel.Controls.Add(this.setNumTxt, 3, 1);
			this.groupPanel.Controls.Add(this.useLocationLbl, 2, 0);
			this.groupPanel.Controls.Add(this.carNameTxt, 1, 1);
			this.groupPanel.Controls.Add(this.setNumLbl, 2, 1);
			this.groupPanel.Controls.Add(this.carNameLbl, 0, 1);
			this.groupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupPanel.Location = new System.Drawing.Point(3, 23);
			this.groupPanel.Name = "groupPanel";
			this.groupPanel.RowCount = 2;
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.groupPanel.Size = new System.Drawing.Size(758, 74);
			this.groupPanel.TabIndex = 0;
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Location = new System.Drawing.Point(4, 8);
			this.customerLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(73, 20);
			this.customerLbl.TabIndex = 29;
			this.customerLbl.Text = "客        户";
			// 
			// customerTxt
			// 
			this.customerTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.customerTxt.BackColor = System.Drawing.Color.White;
			this.customerTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.customerTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.customerTxt.Lines = new string[0];
			this.customerTxt.Location = new System.Drawing.Point(84, 4);
			this.customerTxt.MaxLength = 32767;
			this.customerTxt.Name = "customerTxt";
			this.customerTxt.PasswordChar = '\0';
			this.customerTxt.ReadOnly = true;
			this.customerTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.customerTxt.SelectedText = "";
			this.customerTxt.Size = new System.Drawing.Size(200, 29);
			this.customerTxt.TabIndex = 1;
			this.customerTxt.UseSelectable = true;
			// 
			// useLocationTxt
			// 
			this.useLocationTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.useLocationTxt.BackColor = System.Drawing.Color.White;
			this.useLocationTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.useLocationTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.useLocationTxt.Lines = new string[0];
			this.useLocationTxt.Location = new System.Drawing.Point(397, 4);
			this.useLocationTxt.MaxLength = 32767;
			this.useLocationTxt.Name = "useLocationTxt";
			this.useLocationTxt.PasswordChar = '\0';
			this.useLocationTxt.ReadOnly = true;
			this.useLocationTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.useLocationTxt.SelectedText = "";
			this.useLocationTxt.Size = new System.Drawing.Size(200, 29);
			this.useLocationTxt.TabIndex = 2;
			this.useLocationTxt.UseSelectable = true;
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.setNumTxt.BackColor = System.Drawing.Color.White;
			this.setNumTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.setNumTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.setNumTxt.Lines = new string[0];
			this.setNumTxt.Location = new System.Drawing.Point(397, 41);
			this.setNumTxt.MaxLength = 32767;
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.PasswordChar = '\0';
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.setNumTxt.SelectedText = "";
			this.setNumTxt.Size = new System.Drawing.Size(200, 29);
			this.setNumTxt.TabIndex = 4;
			this.setNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.setNumTxt.UseSelectable = true;
			// 
			// useLocationLbl
			// 
			this.useLocationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.useLocationLbl.AutoSize = true;
			this.useLocationLbl.Location = new System.Drawing.Point(305, 8);
			this.useLocationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.useLocationLbl.Name = "useLocationLbl";
			this.useLocationLbl.Size = new System.Drawing.Size(85, 20);
			this.useLocationLbl.TabIndex = 26;
			this.useLocationLbl.Text = "使 用 地 点";
			// 
			// carNameTxt
			// 
			this.carNameTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.carNameTxt.BackColor = System.Drawing.Color.White;
			this.carNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.carNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.carNameTxt.Lines = new string[0];
			this.carNameTxt.Location = new System.Drawing.Point(84, 41);
			this.carNameTxt.MaxLength = 32767;
			this.carNameTxt.Name = "carNameTxt";
			this.carNameTxt.PasswordChar = '\0';
			this.carNameTxt.ReadOnly = true;
			this.carNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.carNameTxt.SelectedText = "";
			this.carNameTxt.Size = new System.Drawing.Size(200, 29);
			this.carNameTxt.TabIndex = 3;
			this.carNameTxt.UseSelectable = true;
			// 
			// setNumLbl
			// 
			this.setNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setNumLbl.AutoSize = true;
			this.setNumLbl.Location = new System.Drawing.Point(301, 45);
			this.setNumLbl.Margin = new System.Windows.Forms.Padding(14, 0, 4, 0);
			this.setNumLbl.Name = "setNumLbl";
			this.setNumLbl.Size = new System.Drawing.Size(89, 20);
			this.setNumLbl.TabIndex = 3;
			this.setNumLbl.Text = "器械包数量";
			// 
			// carNameLbl
			// 
			this.carNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.carNameLbl.AutoSize = true;
			this.carNameLbl.Location = new System.Drawing.Point(4, 45);
			this.carNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.carNameLbl.Name = "carNameLbl";
			this.carNameLbl.Size = new System.Drawing.Size(73, 20);
			this.carNameLbl.TabIndex = 4;
			this.carNameLbl.Text = "运输车名";
			// 
			// HCSWF_check_send_setlist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 688);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HCSWF_check_send_setlist";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 20);
			this.Text = "运输列表查看";
			this.Load += new System.EventHandler(this.OnFormLoaded);
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.btnsPanel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupPanel.ResumeLayout(false);
			this.groupPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel btnsPanel;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
		private System.Windows.Forms.TableLayoutPanel groupPanel;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.Label setNumLbl;
		private System.Windows.Forms.Label carNameLbl;
		private CnasMetroFramework.Controls.MetroTextBox carNameTxt;
		private CnasMetroFramework.Controls.MetroTextBox setNumTxt;
		private System.Windows.Forms.Label useLocationLbl;
		private CnasMetroFramework.Controls.MetroTextBox useLocationTxt;
		private System.Windows.Forms.Label customerLbl;
		private CnasMetroFramework.Controls.MetroTextBox customerTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setUseLoCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sendTimeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn remarkCol;
	}
}