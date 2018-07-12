namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_specialset_pack
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.materialCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.expireDateTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.packTypeCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.packTypeLbl = new System.Windows.Forms.Label();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tempCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pbCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.useLocationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.creDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.expireDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batchCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.isSplitCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.genNumTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.isSplitLbl = new System.Windows.Forms.Label();
			this.customerLbl = new System.Windows.Forms.Label();
			this.useNameLbl = new System.Windows.Forms.Label();
			this.txtCustomerName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtLocationName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.packUserTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.cfmUserLbl = new System.Windows.Forms.Label();
			this.cfmUserTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.rightPanel = new System.Windows.Forms.TableLayoutPanel();
			this.generateBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.label3 = new System.Windows.Forms.Label();
			this.genNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.mainPanel.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.rightPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 5;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.tableLayoutPanel2, 2, 2);
			this.mainPanel.Controls.Add(this.packTypeCbx, 1, 3);
			this.mainPanel.Controls.Add(this.packTypeLbl, 0, 3);
			this.mainPanel.Controls.Add(this.dataGrid, 0, 4);
			this.mainPanel.Controls.Add(this.tableLayoutPanel1, 2, 3);
			this.mainPanel.Controls.Add(this.customerLbl, 0, 0);
			this.mainPanel.Controls.Add(this.useNameLbl, 2, 0);
			this.mainPanel.Controls.Add(this.txtCustomerName, 1, 0);
			this.mainPanel.Controls.Add(this.txtLocationName, 3, 0);
			this.mainPanel.Controls.Add(this.label1, 0, 1);
			this.mainPanel.Controls.Add(this.packUserTxt, 1, 1);
			this.mainPanel.Controls.Add(this.cfmUserLbl, 2, 1);
			this.mainPanel.Controls.Add(this.cfmUserTxt, 3, 1);
			this.mainPanel.Controls.Add(this.rightPanel, 4, 0);
			this.mainPanel.Controls.Add(this.label3, 0, 2);
			this.mainPanel.Controls.Add(this.genNameTxt, 1, 2);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 5;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(950, 551);
			this.mainPanel.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.mainPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.materialCbx, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.expireDateTxt, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(428, 72);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(426, 36);
			this.tableLayoutPanel2.TabIndex = 20;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(263, 8);
			this.label6.Margin = new System.Windows.Forms.Padding(3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 11;
			this.label6.Text = "有  效  期：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 17;
			this.label5.Text = "包装材料：";
			// 
			// materialCbx
			// 
			this.materialCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.materialCbx.DisplayMember = "Value";
			this.materialCbx.FormattingEnabled = true;
			this.materialCbx.ItemHeight = 24;
			this.materialCbx.Location = new System.Drawing.Point(98, 3);
			this.materialCbx.Name = "materialCbx";
			this.materialCbx.Size = new System.Drawing.Size(159, 30);
			this.materialCbx.TabIndex = 6;
			this.materialCbx.UseSelectable = true;
			this.materialCbx.ValueMember = "Key";
			this.materialCbx.SelectedIndexChanged += new System.EventHandler(this.materialCbx_SelectedIndexChanged);
			// 
			// expireDateTxt
			// 
			this.expireDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.expireDateTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.expireDateTxt.Lines = new string[0];
			this.expireDateTxt.Location = new System.Drawing.Point(358, 3);
			this.expireDateTxt.MaxLength = 32767;
			this.expireDateTxt.Name = "expireDateTxt";
			this.expireDateTxt.PasswordChar = '\0';
			this.expireDateTxt.ReadOnly = true;
			this.expireDateTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.expireDateTxt.SelectedText = "";
			this.expireDateTxt.Size = new System.Drawing.Size(65, 30);
			this.expireDateTxt.TabIndex = 7;
			this.expireDateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.expireDateTxt.UseSelectable = true;
			// 
			// packTypeCbx
			// 
			this.packTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packTypeCbx.DisplayMember = "Value";
			this.packTypeCbx.FormattingEnabled = true;
			this.packTypeCbx.ItemHeight = 24;
			this.packTypeCbx.Location = new System.Drawing.Point(100, 111);
			this.packTypeCbx.Name = "packTypeCbx";
			this.packTypeCbx.Size = new System.Drawing.Size(325, 30);
			this.packTypeCbx.TabIndex = 8;
			this.packTypeCbx.UseSelectable = true;
			this.packTypeCbx.ValueMember = "Key";
			// 
			// packTypeLbl
			// 
			this.packTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.packTypeLbl.AutoSize = true;
			this.packTypeLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.packTypeLbl.Location = new System.Drawing.Point(4, 116);
			this.packTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.packTypeLbl.Name = "packTypeLbl";
			this.packTypeLbl.Size = new System.Drawing.Size(89, 20);
			this.packTypeLbl.TabIndex = 30;
			this.packTypeLbl.Text = "包装类型：";
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.tempCodeCol,
            this.pbCodeCol,
            this.setNameCol,
            this.useLocationCol,
            this.creDateCol,
            this.expireDateCol,
            this.batchCol});
			this.mainPanel.SetColumnSpan(this.dataGrid, 4);
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.dataGrid.Location = new System.Drawing.Point(3, 147);
			this.dataGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.RowTemplate.Height = 23;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.Size = new System.Drawing.Size(848, 404);
			this.dataGrid.TabIndex = 11;
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			// 
			// tempCodeCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.tempCodeCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.tempCodeCol.HeaderText = "临时条码";
			this.tempCodeCol.Name = "tempCodeCol";
			this.tempCodeCol.ReadOnly = true;
			// 
			// pbCodeCol
			// 
			dataGridViewCellStyle2.NullValue = null;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.pbCodeCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.pbCodeCol.HeaderText = "标签条码";
			this.pbCodeCol.Name = "pbCodeCol";
			this.pbCodeCol.ReadOnly = true;
			// 
			// setNameCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.setNameCol.HeaderText = "名 称";
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			// 
			// useLocationCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.useLocationCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.useLocationCol.HeaderText = "使用地点";
			this.useLocationCol.Name = "useLocationCol";
			this.useLocationCol.ReadOnly = true;
			// 
			// creDateCol
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "yyyy-MM-dd";
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.creDateCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.creDateCol.HeaderText = "生产日期";
			this.creDateCol.Name = "creDateCol";
			this.creDateCol.ReadOnly = true;
			// 
			// expireDateCol
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "yyyy-MM-dd";
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.expireDateCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.expireDateCol.HeaderText = "失效日期";
			this.expireDateCol.Name = "expireDateCol";
			this.expireDateCol.ReadOnly = true;
			// 
			// batchCol
			// 
			this.batchCol.HeaderText = "批次号";
			this.batchCol.Name = "batchCol";
			this.batchCol.ReadOnly = true;
			this.batchCol.Visible = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.mainPanel.SetColumnSpan(this.tableLayoutPanel1, 2);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.isSplitCbx, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.genNumTxt, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.isSplitLbl, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(428, 108);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 36);
			this.tableLayoutPanel1.TabIndex = 19;
			this.tableLayoutPanel1.Resize += new System.EventHandler(this.OnSizeChanged);
			// 
			// isSplitCbx
			// 
			this.isSplitCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.isSplitCbx.DisplayMember = "Value";
			this.isSplitCbx.FormattingEnabled = true;
			this.isSplitCbx.ItemHeight = 24;
			this.isSplitCbx.Location = new System.Drawing.Point(98, 3);
			this.isSplitCbx.Name = "isSplitCbx";
			this.isSplitCbx.Size = new System.Drawing.Size(159, 30);
			this.isSplitCbx.TabIndex = 9;
			this.isSplitCbx.UseSelectable = true;
			this.isSplitCbx.ValueMember = "Key";
			// 
			// genNumTxt
			// 
			this.genNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.genNumTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.genNumTxt.Lines = new string[0];
			this.genNumTxt.Location = new System.Drawing.Point(358, 3);
			this.genNumTxt.MaxLength = 32767;
			this.genNumTxt.Name = "genNumTxt";
			this.genNumTxt.PasswordChar = '\0';
			this.genNumTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.genNumTxt.SelectedText = "";
			this.genNumTxt.Size = new System.Drawing.Size(65, 30);
			this.genNumTxt.TabIndex = 10;
			this.genNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.genNumTxt.UseCustomBackColor = true;
			this.genNumTxt.UseSelectable = true;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(263, 8);
			this.label2.Margin = new System.Windows.Forms.Padding(3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "生成数量：";
			// 
			// isSplitLbl
			// 
			this.isSplitLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.isSplitLbl.AutoSize = true;
			this.isSplitLbl.Location = new System.Drawing.Point(3, 8);
			this.isSplitLbl.Margin = new System.Windows.Forms.Padding(3);
			this.isSplitLbl.Name = "isSplitLbl";
			this.isSplitLbl.Size = new System.Drawing.Size(89, 20);
			this.isSplitLbl.TabIndex = 33;
			this.isSplitLbl.Text = "是否拆分：";
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.customerLbl.Location = new System.Drawing.Point(5, 8);
			this.customerLbl.Margin = new System.Windows.Forms.Padding(3);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(89, 20);
			this.customerLbl.TabIndex = 3;
			this.customerLbl.Text = "客户名称：";
			// 
			// useNameLbl
			// 
			this.useNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.useNameLbl.AutoSize = true;
			this.useNameLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.useNameLbl.Location = new System.Drawing.Point(431, 8);
			this.useNameLbl.Margin = new System.Windows.Forms.Padding(3);
			this.useNameLbl.Name = "useNameLbl";
			this.useNameLbl.Size = new System.Drawing.Size(89, 20);
			this.useNameLbl.TabIndex = 5;
			this.useNameLbl.Text = "使用地点：";
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCustomerName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtCustomerName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCustomerName.Lines = new string[0];
			this.txtCustomerName.Location = new System.Drawing.Point(100, 3);
			this.txtCustomerName.MaxLength = 32767;
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.PasswordChar = '\0';
			this.txtCustomerName.ReadOnly = true;
			this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCustomerName.SelectedText = "";
			this.txtCustomerName.Size = new System.Drawing.Size(325, 30);
			this.txtCustomerName.TabIndex = 1;
			this.txtCustomerName.UseSelectable = true;
			// 
			// txtLocationName
			// 
			this.txtLocationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocationName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLocationName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtLocationName.Lines = new string[0];
			this.txtLocationName.Location = new System.Drawing.Point(526, 3);
			this.txtLocationName.MaxLength = 32767;
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.PasswordChar = '\0';
			this.txtLocationName.ReadOnly = true;
			this.txtLocationName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLocationName.SelectedText = "";
			this.txtLocationName.Size = new System.Drawing.Size(325, 30);
			this.txtLocationName.TabIndex = 2;
			this.txtLocationName.UseSelectable = true;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(5, 44);
			this.label1.Margin = new System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "打  包  人：";
			// 
			// packUserTxt
			// 
			this.packUserTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packUserTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.packUserTxt.Lines = new string[0];
			this.packUserTxt.Location = new System.Drawing.Point(100, 39);
			this.packUserTxt.MaxLength = 32767;
			this.packUserTxt.Name = "packUserTxt";
			this.packUserTxt.PasswordChar = '\0';
			this.packUserTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.packUserTxt.SelectedText = "";
			this.packUserTxt.Size = new System.Drawing.Size(325, 30);
			this.packUserTxt.TabIndex = 3;
			this.packUserTxt.UseCustomBackColor = true;
			this.packUserTxt.UseSelectable = true;
			this.packUserTxt.Click += new System.EventHandler(this.packUserTxt_Click);
			this.packUserTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUserEnterKeyDown);
			// 
			// cfmUserLbl
			// 
			this.cfmUserLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.cfmUserLbl.AutoSize = true;
			this.cfmUserLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cfmUserLbl.Location = new System.Drawing.Point(435, 44);
			this.cfmUserLbl.Margin = new System.Windows.Forms.Padding(3);
			this.cfmUserLbl.Name = "cfmUserLbl";
			this.cfmUserLbl.Size = new System.Drawing.Size(85, 20);
			this.cfmUserLbl.TabIndex = 9;
			this.cfmUserLbl.Text = "审  核 员：";
			// 
			// cfmUserTxt
			// 
			this.cfmUserTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cfmUserTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.cfmUserTxt.Lines = new string[0];
			this.cfmUserTxt.Location = new System.Drawing.Point(526, 39);
			this.cfmUserTxt.MaxLength = 32767;
			this.cfmUserTxt.Name = "cfmUserTxt";
			this.cfmUserTxt.PasswordChar = '\0';
			this.cfmUserTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.cfmUserTxt.SelectedText = "";
			this.cfmUserTxt.Size = new System.Drawing.Size(325, 30);
			this.cfmUserTxt.TabIndex = 4;
			this.cfmUserTxt.UseCustomBackColor = true;
			this.cfmUserTxt.UseSelectable = true;
			this.cfmUserTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUserEnterKeyDown);
			// 
			// rightPanel
			// 
			this.rightPanel.ColumnCount = 1;
			this.rightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.rightPanel.Controls.Add(this.generateBtn, 0, 0);
			this.rightPanel.Controls.Add(this.printBtn, 0, 1);
			this.rightPanel.Controls.Add(this.cancelBtn, 0, 2);
			this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPanel.Location = new System.Drawing.Point(854, 0);
			this.rightPanel.Margin = new System.Windows.Forms.Padding(0);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.RowCount = 4;
			this.mainPanel.SetRowSpan(this.rightPanel, 5);
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.rightPanel.Size = new System.Drawing.Size(96, 551);
			this.rightPanel.TabIndex = 15;
			// 
			// generateBtn
			// 
			this.generateBtn.ActiveControl = null;
			this.generateBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.generateBtn.Location = new System.Drawing.Point(3, 3);
			this.generateBtn.Name = "generateBtn";
			this.generateBtn.Size = new System.Drawing.Size(90, 40);
			this.generateBtn.TabIndex = 22;
			this.generateBtn.Text = "生 成 ";
			this.generateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.generateBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.generateBtn.UseSelectable = true;
			this.generateBtn.UseTileImage = true;
			this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(3, 49);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 23;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(3, 95);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 24;
			this.cancelBtn.Text = "关闭 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 80);
			this.label3.Margin = new System.Windows.Forms.Padding(3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 20);
			this.label3.TabIndex = 13;
			this.label3.Text = "打包名称：";
			// 
			// genNameTxt
			// 
			this.genNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.genNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.genNameTxt.Lines = new string[0];
			this.genNameTxt.Location = new System.Drawing.Point(100, 75);
			this.genNameTxt.MaxLength = 32767;
			this.genNameTxt.Name = "genNameTxt";
			this.genNameTxt.PasswordChar = '\0';
			this.genNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.genNameTxt.SelectedText = "";
			this.genNameTxt.Size = new System.Drawing.Size(325, 30);
			this.genNameTxt.TabIndex = 5;
			this.genNameTxt.UseCustomBackColor = true;
			this.genNameTxt.UseSelectable = true;
			// 
			// HCSSM_order_specialset_pack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 631);
			this.Controls.Add(this.mainPanel);
			this.Name = "HCSSM_order_specialset_pack";
			this.Text = "打印标签";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HCSSM_order_specialset_pack_FormClosing);
			this.Load += new System.EventHandler(this.HCSSM_order_specialset_pack_Load);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.rightPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.Label customerLbl;
		private System.Windows.Forms.Label useNameLbl;
		private CnasMetroFramework.Controls.MetroTextBox txtCustomerName;
		private CnasMetroFramework.Controls.MetroTextBox txtLocationName;
		private System.Windows.Forms.Label label1;
		private CnasMetroFramework.Controls.MetroTextBox packUserTxt;
		private System.Windows.Forms.Label cfmUserLbl;
		private CnasMetroFramework.Controls.MetroTextBox cfmUserTxt;
		private System.Windows.Forms.Label label2;
		private CnasMetroFramework.Controls.MetroTextBox genNumTxt;
		private System.Windows.Forms.Label label3;
		private CnasMetroFramework.Controls.MetroTextBox genNameTxt;
		private System.Windows.Forms.TableLayoutPanel rightPanel;
		private CnasMetroFramework.Controls.MetroTile generateBtn;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private System.Windows.Forms.Label label5;
		private CnasMetroFramework.Controls.MetroTextBox expireDateTxt;
		private CnasMetroFramework.Controls.MetroComboBox materialCbx;
		private System.Windows.Forms.DataGridView dataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn tempCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn pbCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn useLocationCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn creDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn expireDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn batchCol;
		private System.Windows.Forms.Label packTypeLbl;
		private CnasMetroFramework.Controls.MetroComboBox packTypeCbx;
		private System.Windows.Forms.Label isSplitLbl;
		private CnasMetroFramework.Controls.MetroComboBox isSplitCbx;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}