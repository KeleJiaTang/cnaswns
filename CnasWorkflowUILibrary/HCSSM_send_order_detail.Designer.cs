namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_send_order_detail
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.LeftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.sendTimeTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.sendCodeTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderCodeTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.locationTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.customerTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.customerLbl = new System.Windows.Forms.Label();
			this.orderCodeLbl = new System.Windows.Forms.Label();
			this.sendCodeLbl = new System.Windows.Forms.Label();
			this.locationLbl = new System.Windows.Forms.Label();
			this.orderNameLbl = new System.Windows.Forms.Label();
			this.sendTimeLbl = new System.Windows.Forms.Label();
			this.dataGridTab = new System.Windows.Forms.TabControl();
			this.OverviewPage = new System.Windows.Forms.TabPage();
			this.sendInfoPreview = new System.Windows.Forms.DataGridView();
			this.thingIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingRemarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.detailPage = new System.Windows.Forms.TabPage();
			this.detailGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bcuCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.t_b_bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BtnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			this.LeftPanel.SuspendLayout();
			this.dataGridTab.SuspendLayout();
			this.OverviewPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sendInfoPreview)).BeginInit();
			this.detailPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
			this.BtnPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.LeftPanel, 0, 0);
			this.mainPanel.Controls.Add(this.BtnPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(670, 597);
			this.mainPanel.TabIndex = 0;
			// 
			// LeftPanel
			// 
			this.LeftPanel.ColumnCount = 4;
			this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.LeftPanel.Controls.Add(this.sendTimeTxt, 3, 2);
			this.LeftPanel.Controls.Add(this.sendCodeTxt, 1, 2);
			this.LeftPanel.Controls.Add(this.orderNameTxt, 3, 1);
			this.LeftPanel.Controls.Add(this.orderCodeTxt, 1, 1);
			this.LeftPanel.Controls.Add(this.locationTxt, 3, 0);
			this.LeftPanel.Controls.Add(this.customerTxt, 1, 0);
			this.LeftPanel.Controls.Add(this.customerLbl, 0, 0);
			this.LeftPanel.Controls.Add(this.orderCodeLbl, 0, 1);
			this.LeftPanel.Controls.Add(this.sendCodeLbl, 0, 2);
			this.LeftPanel.Controls.Add(this.locationLbl, 2, 0);
			this.LeftPanel.Controls.Add(this.orderNameLbl, 2, 1);
			this.LeftPanel.Controls.Add(this.sendTimeLbl, 2, 2);
			this.LeftPanel.Controls.Add(this.dataGridTab, 0, 3);
			this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.RowCount = 4;
			this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.LeftPanel.Size = new System.Drawing.Size(574, 597);
			this.LeftPanel.TabIndex = 0;
			// 
			// sendTimeTxt
			// 
			this.sendTimeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.sendTimeTxt.BackColor = System.Drawing.Color.White;
			this.sendTimeTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.sendTimeTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.sendTimeTxt.Lines = new string[0];
			this.sendTimeTxt.Location = new System.Drawing.Point(385, 75);
			this.sendTimeTxt.MaxLength = 32767;
			this.sendTimeTxt.Name = "sendTimeTxt";
			this.sendTimeTxt.PasswordChar = '\0';
			this.sendTimeTxt.ReadOnly = true;
			this.sendTimeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.sendTimeTxt.SelectedText = "";
			this.sendTimeTxt.Size = new System.Drawing.Size(186, 30);
			this.sendTimeTxt.TabIndex = 6;
			this.sendTimeTxt.UseSelectable = true;
			// 
			// sendCodeTxt
			// 
			this.sendCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.sendCodeTxt.BackColor = System.Drawing.Color.White;
			this.sendCodeTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.sendCodeTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.sendCodeTxt.Lines = new string[0];
			this.sendCodeTxt.Location = new System.Drawing.Point(98, 75);
			this.sendCodeTxt.MaxLength = 32767;
			this.sendCodeTxt.Name = "sendCodeTxt";
			this.sendCodeTxt.PasswordChar = '\0';
			this.sendCodeTxt.ReadOnly = true;
			this.sendCodeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.sendCodeTxt.SelectedText = "";
			this.sendCodeTxt.Size = new System.Drawing.Size(186, 30);
			this.sendCodeTxt.TabIndex = 5;
			this.sendCodeTxt.UseSelectable = true;
			// 
			// orderNameTxt
			// 
			this.orderNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.orderNameTxt.BackColor = System.Drawing.Color.White;
			this.orderNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.orderNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.orderNameTxt.Lines = new string[0];
			this.orderNameTxt.Location = new System.Drawing.Point(385, 39);
			this.orderNameTxt.MaxLength = 32767;
			this.orderNameTxt.Name = "orderNameTxt";
			this.orderNameTxt.PasswordChar = '\0';
			this.orderNameTxt.ReadOnly = true;
			this.orderNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.orderNameTxt.SelectedText = "";
			this.orderNameTxt.Size = new System.Drawing.Size(186, 30);
			this.orderNameTxt.TabIndex = 4;
			this.orderNameTxt.UseSelectable = true;
			// 
			// orderCodeTxt
			// 
			this.orderCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.orderCodeTxt.BackColor = System.Drawing.Color.White;
			this.orderCodeTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.orderCodeTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.orderCodeTxt.Lines = new string[0];
			this.orderCodeTxt.Location = new System.Drawing.Point(98, 39);
			this.orderCodeTxt.MaxLength = 32767;
			this.orderCodeTxt.Name = "orderCodeTxt";
			this.orderCodeTxt.PasswordChar = '\0';
			this.orderCodeTxt.ReadOnly = true;
			this.orderCodeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.orderCodeTxt.SelectedText = "";
			this.orderCodeTxt.Size = new System.Drawing.Size(186, 30);
			this.orderCodeTxt.TabIndex = 3;
			this.orderCodeTxt.UseSelectable = true;
			// 
			// locationTxt
			// 
			this.locationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.locationTxt.BackColor = System.Drawing.Color.White;
			this.locationTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.locationTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.locationTxt.Lines = new string[0];
			this.locationTxt.Location = new System.Drawing.Point(385, 3);
			this.locationTxt.MaxLength = 32767;
			this.locationTxt.Name = "locationTxt";
			this.locationTxt.PasswordChar = '\0';
			this.locationTxt.ReadOnly = true;
			this.locationTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.locationTxt.SelectedText = "";
			this.locationTxt.Size = new System.Drawing.Size(186, 30);
			this.locationTxt.TabIndex = 2;
			this.locationTxt.UseSelectable = true;
			// 
			// customerTxt
			// 
			this.customerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.customerTxt.BackColor = System.Drawing.Color.White;
			this.customerTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.customerTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.customerTxt.Lines = new string[0];
			this.customerTxt.Location = new System.Drawing.Point(98, 3);
			this.customerTxt.MaxLength = 32767;
			this.customerTxt.Name = "customerTxt";
			this.customerTxt.PasswordChar = '\0';
			this.customerTxt.ReadOnly = true;
			this.customerTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.customerTxt.SelectedText = "";
			this.customerTxt.Size = new System.Drawing.Size(186, 30);
			this.customerTxt.TabIndex = 1;
			this.customerTxt.UseSelectable = true;
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Location = new System.Drawing.Point(3, 8);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(89, 20);
			this.customerLbl.TabIndex = 0;
			this.customerLbl.Text = "客        户：";
			// 
			// orderCodeLbl
			// 
			this.orderCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderCodeLbl.AutoSize = true;
			this.orderCodeLbl.Location = new System.Drawing.Point(3, 44);
			this.orderCodeLbl.Name = "orderCodeLbl";
			this.orderCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.orderCodeLbl.TabIndex = 1;
			this.orderCodeLbl.Text = "订单编号：";
			// 
			// sendCodeLbl
			// 
			this.sendCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.sendCodeLbl.AutoSize = true;
			this.sendCodeLbl.Location = new System.Drawing.Point(3, 80);
			this.sendCodeLbl.Name = "sendCodeLbl";
			this.sendCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.sendCodeLbl.TabIndex = 2;
			this.sendCodeLbl.Text = "发货单号：";
			// 
			// locationLbl
			// 
			this.locationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.locationLbl.AutoSize = true;
			this.locationLbl.Location = new System.Drawing.Point(290, 8);
			this.locationLbl.Name = "locationLbl";
			this.locationLbl.Size = new System.Drawing.Size(89, 20);
			this.locationLbl.TabIndex = 3;
			this.locationLbl.Text = "使用地点：";
			// 
			// orderNameLbl
			// 
			this.orderNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderNameLbl.AutoSize = true;
			this.orderNameLbl.Location = new System.Drawing.Point(290, 44);
			this.orderNameLbl.Name = "orderNameLbl";
			this.orderNameLbl.Size = new System.Drawing.Size(89, 20);
			this.orderNameLbl.TabIndex = 4;
			this.orderNameLbl.Text = "订单名称：";
			// 
			// sendTimeLbl
			// 
			this.sendTimeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.sendTimeLbl.AutoSize = true;
			this.sendTimeLbl.Location = new System.Drawing.Point(290, 80);
			this.sendTimeLbl.Name = "sendTimeLbl";
			this.sendTimeLbl.Size = new System.Drawing.Size(89, 20);
			this.sendTimeLbl.TabIndex = 5;
			this.sendTimeLbl.Text = "发送时间：";
			// 
			// dataGridTab
			// 
			this.LeftPanel.SetColumnSpan(this.dataGridTab, 4);
			this.dataGridTab.Controls.Add(this.OverviewPage);
			this.dataGridTab.Controls.Add(this.detailPage);
			this.dataGridTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridTab.Location = new System.Drawing.Point(3, 111);
			this.dataGridTab.Name = "dataGridTab";
			this.dataGridTab.SelectedIndex = 0;
			this.dataGridTab.Size = new System.Drawing.Size(568, 483);
			this.dataGridTab.TabIndex = 7;
			// 
			// OverviewPage
			// 
			this.OverviewPage.Controls.Add(this.sendInfoPreview);
			this.OverviewPage.Location = new System.Drawing.Point(4, 29);
			this.OverviewPage.Name = "OverviewPage";
			this.OverviewPage.Padding = new System.Windows.Forms.Padding(3);
			this.OverviewPage.Size = new System.Drawing.Size(560, 450);
			this.OverviewPage.TabIndex = 0;
			this.OverviewPage.Text = "总览";
			this.OverviewPage.UseVisualStyleBackColor = true;
			// 
			// sendInfoPreview
			// 
			this.sendInfoPreview.AllowUserToAddRows = false;
			this.sendInfoPreview.AllowUserToDeleteRows = false;
			this.sendInfoPreview.BackgroundColor = System.Drawing.SystemColors.Window;
			this.sendInfoPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.sendInfoPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thingIdCol,
            this.thingNameCol,
            this.thingNumCol,
            this.thingRemarkCol});
			this.sendInfoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sendInfoPreview.Location = new System.Drawing.Point(3, 3);
			this.sendInfoPreview.Margin = new System.Windows.Forms.Padding(0);
			this.sendInfoPreview.MultiSelect = false;
			this.sendInfoPreview.Name = "sendInfoPreview";
			this.sendInfoPreview.ReadOnly = true;
			this.sendInfoPreview.RowHeadersVisible = false;
			this.sendInfoPreview.RowTemplate.Height = 23;
			this.sendInfoPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.sendInfoPreview.Size = new System.Drawing.Size(554, 444);
			this.sendInfoPreview.TabIndex = 8;
			// 
			// thingIdCol
			// 
			this.thingIdCol.HeaderText = "序号";
			this.thingIdCol.Name = "thingIdCol";
			this.thingIdCol.ReadOnly = true;
			this.thingIdCol.Width = 80;
			// 
			// thingNameCol
			// 
			this.thingNameCol.HeaderText = "物品名称";
			this.thingNameCol.Name = "thingNameCol";
			this.thingNameCol.ReadOnly = true;
			this.thingNameCol.Width = 190;
			// 
			// thingNumCol
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.thingNumCol.DefaultCellStyle = dataGridViewCellStyle9;
			this.thingNumCol.HeaderText = "数量";
			this.thingNumCol.Name = "thingNumCol";
			this.thingNumCol.ReadOnly = true;
			// 
			// thingRemarkCol
			// 
			this.thingRemarkCol.HeaderText = "备注";
			this.thingRemarkCol.Name = "thingRemarkCol";
			this.thingRemarkCol.ReadOnly = true;
			this.thingRemarkCol.Width = 180;
			// 
			// detailPage
			// 
			this.detailPage.Controls.Add(this.detailGrid);
			this.detailPage.Location = new System.Drawing.Point(4, 29);
			this.detailPage.Margin = new System.Windows.Forms.Padding(0);
			this.detailPage.Name = "detailPage";
			this.detailPage.Padding = new System.Windows.Forms.Padding(3);
			this.detailPage.Size = new System.Drawing.Size(560, 450);
			this.detailPage.TabIndex = 1;
			this.detailPage.Text = "详情";
			this.detailPage.UseVisualStyleBackColor = true;
			// 
			// detailGrid
			// 
			this.detailGrid.AllowUserToAddRows = false;
			this.detailGrid.AllowUserToDeleteRows = false;
			this.detailGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.detailGrid.ColumnHeadersHeight = 28;
			this.detailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.setNameCol,
            this.bcuCodeCol,
            this.startDateCol,
            this.endDateCol,
            this.setTypeCol,
            this.t_b_bar_code});
			this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailGrid.Location = new System.Drawing.Point(3, 3);
			this.detailGrid.Margin = new System.Windows.Forms.Padding(0);
			this.detailGrid.MultiSelect = false;
			this.detailGrid.Name = "detailGrid";
			this.detailGrid.ReadOnly = true;
			this.detailGrid.RowHeadersVisible = false;
			this.detailGrid.RowTemplate.Height = 23;
			this.detailGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.detailGrid.Size = new System.Drawing.Size(554, 444);
			this.detailGrid.TabIndex = 9;
			// 
			// idCol
			// 
			this.idCol.HeaderText = "序号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			this.idCol.Width = 80;
			// 
			// setNameCol
			// 
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 180;
			// 
			// bcuCodeCol
			// 
			this.bcuCodeCol.HeaderText = "包外标签";
			this.bcuCodeCol.Name = "bcuCodeCol";
			this.bcuCodeCol.ReadOnly = true;
			this.bcuCodeCol.Width = 120;
			// 
			// startDateCol
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "yyyy-MM-dd";
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.startDateCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.startDateCol.HeaderText = "灭菌日期";
			this.startDateCol.Name = "startDateCol";
			this.startDateCol.ReadOnly = true;
			this.startDateCol.Width = 180;
			// 
			// endDateCol
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "yyyy-MM-dd";
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.endDateCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.endDateCol.HeaderText = "失效日期";
			this.endDateCol.Name = "endDateCol";
			this.endDateCol.ReadOnly = true;
			this.endDateCol.Width = 180;
			// 
			// setTypeCol
			// 
			this.setTypeCol.HeaderText = "setType";
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Visible = false;
			// 
			// t_b_bar_code
			// 
			this.t_b_bar_code.HeaderText = "T条形码";
			this.t_b_bar_code.Name = "t_b_bar_code";
			this.t_b_bar_code.ReadOnly = true;
			this.t_b_bar_code.Visible = false;
			// 
			// BtnPanel
			// 
			this.BtnPanel.ColumnCount = 1;
			this.BtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BtnPanel.Controls.Add(this.btnClose, 0, 1);
			this.BtnPanel.Controls.Add(this.printBtn, 0, 0);
			this.BtnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnPanel.Location = new System.Drawing.Point(574, 0);
			this.BtnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.BtnPanel.Name = "BtnPanel";
			this.BtnPanel.RowCount = 2;
			this.BtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BtnPanel.Size = new System.Drawing.Size(96, 597);
			this.BtnPanel.TabIndex = 21;
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Location = new System.Drawing.Point(3, 49);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 23;
			this.btnClose.Text = "关 闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(3, 3);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 22;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.OnPrintBtnClick);
			// 
			// HCSSM_send_order_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(710, 677);
			this.Controls.Add(this.mainPanel);
			this.Name = "HCSSM_send_order_detail";
			this.Text = "发货单详情";
			this.Load += new System.EventHandler(this.OnFormLoaded);
			this.mainPanel.ResumeLayout(false);
			this.LeftPanel.ResumeLayout(false);
			this.LeftPanel.PerformLayout();
			this.dataGridTab.ResumeLayout(false);
			this.OverviewPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sendInfoPreview)).EndInit();
			this.detailPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
			this.BtnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel LeftPanel;
		private System.Windows.Forms.TableLayoutPanel BtnPanel;
		private System.Windows.Forms.Label customerLbl;
		private System.Windows.Forms.Label orderCodeLbl;
		private System.Windows.Forms.Label sendCodeLbl;
		private System.Windows.Forms.Label locationLbl;
		private System.Windows.Forms.Label orderNameLbl;
		private System.Windows.Forms.Label sendTimeLbl;
		private CnasMetroFramework.Controls.MetroTextBox sendCodeTxt;
		private CnasMetroFramework.Controls.MetroTextBox orderNameTxt;
		private CnasMetroFramework.Controls.MetroTextBox orderCodeTxt;
		private CnasMetroFramework.Controls.MetroTextBox locationTxt;
		private CnasMetroFramework.Controls.MetroTextBox customerTxt;
		private CnasMetroFramework.Controls.MetroTextBox sendTimeTxt;
		private System.Windows.Forms.TabControl dataGridTab;
		private System.Windows.Forms.TabPage OverviewPage;
		private System.Windows.Forms.TabPage detailPage;
		private System.Windows.Forms.DataGridView sendInfoPreview;
		private System.Windows.Forms.DataGridView detailGrid;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingRemarkCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn bcuCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn startDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn endDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn t_b_bar_code;
	}
}