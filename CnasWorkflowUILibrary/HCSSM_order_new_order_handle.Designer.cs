namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_new_order_handle
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnSave = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.txtOrderPerson = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.leftSplitter = new System.Windows.Forms.SplitContainer();
			this.orderPanel = new System.Windows.Forms.TableLayoutPanel();
			this.txtLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel4 = new System.Windows.Forms.Label();
			this.metroLabel5 = new System.Windows.Forms.Label();
			this.txtCustomer = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel3 = new System.Windows.Forms.Label();
			this.metroLabel1 = new System.Windows.Forms.Label();
			this.txtOrderState = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel6 = new System.Windows.Forms.Label();
			this.metroLabel2 = new System.Windows.Forms.Label();
			this.txtOrderName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtOrderNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.mainTab = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgv_Instrument = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.sendInfoPreview = new System.Windows.Forms.DataGridView();
			this.thingIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.thingRemakCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scanPanel = new System.Windows.Forms.TableLayoutPanel();
			this.gb_temp = new Telerik.WinControls.UI.RadGroupBox();
			this.scanInnerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.dgv_BcuData = new System.Windows.Forms.DataGridView();
			this.bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.b_bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.b_ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.t_b_bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scanCodeLbl = new System.Windows.Forms.TableLayoutPanel();
			this.metroLabel9 = new System.Windows.Forms.Label();
			this.metBcuCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.resultLbl = new System.Windows.Forms.Label();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrument_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num_send_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.send_count_now = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.for_label = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.send_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c_codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainPanel.SuspendLayout();
			this.btnPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.leftSplitter)).BeginInit();
			this.leftSplitter.Panel1.SuspendLayout();
			this.leftSplitter.Panel2.SuspendLayout();
			this.leftSplitter.SuspendLayout();
			this.orderPanel.SuspendLayout();
			this.mainTab.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sendInfoPreview)).BeginInit();
			this.scanPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gb_temp)).BeginInit();
			this.gb_temp.SuspendLayout();
			this.scanInnerPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_BcuData)).BeginInit();
			this.scanCodeLbl.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 3;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.btnPanel, 2, 0);
			this.mainPanel.Controls.Add(this.leftSplitter, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(1155, 635);
			this.mainPanel.TabIndex = 0;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnSave, 0, 0);
			this.btnPanel.Controls.Add(this.txtOrderPerson, 0, 3);
			this.btnPanel.Controls.Add(this.btnClose, 0, 2);
			this.btnPanel.Controls.Add(this.printBtn, 0, 1);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(1059, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 5;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnPanel.Size = new System.Drawing.Size(96, 635);
			this.btnPanel.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.ActiveControl = null;
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnSave.Location = new System.Drawing.Point(3, 0);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 40);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "提 交 ";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.UseSelectable = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.OnbtnSave_Click);
			// 
			// txtOrderPerson
			// 
			this.txtOrderPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderPerson.BackColor = System.Drawing.Color.White;
			this.txtOrderPerson.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderPerson.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderPerson.Lines = new string[0];
			this.txtOrderPerson.Location = new System.Drawing.Point(3, 245);
			this.txtOrderPerson.MaxLength = 32767;
			this.txtOrderPerson.Name = "txtOrderPerson";
			this.txtOrderPerson.PasswordChar = '\0';
			this.txtOrderPerson.ReadOnly = true;
			this.txtOrderPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderPerson.SelectedText = "";
			this.txtOrderPerson.Size = new System.Drawing.Size(90, 30);
			this.txtOrderPerson.TabIndex = 34;
			this.txtOrderPerson.UseSelectable = true;
			this.txtOrderPerson.Visible = false;
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClose.Location = new System.Drawing.Point(3, 92);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 33;
			this.btnClose.Text = "关 闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.OnbtnClose_Click);
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(3, 46);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 32;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.OnPrintBtnClick);
			// 
			// leftSplitter
			// 
			this.leftSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftSplitter.Location = new System.Drawing.Point(0, 0);
			this.leftSplitter.Margin = new System.Windows.Forms.Padding(0);
			this.leftSplitter.Name = "leftSplitter";
			// 
			// leftSplitter.Panel1
			// 
			this.leftSplitter.Panel1.Controls.Add(this.orderPanel);
			// 
			// leftSplitter.Panel2
			// 
			this.leftSplitter.Panel2.Controls.Add(this.scanPanel);
			this.leftSplitter.Size = new System.Drawing.Size(1059, 635);
			this.leftSplitter.SplitterDistance = 690;
			this.leftSplitter.TabIndex = 0;
			// 
			// orderPanel
			// 
			this.orderPanel.ColumnCount = 4;
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.orderPanel.Controls.Add(this.txtLocation, 3, 0);
			this.orderPanel.Controls.Add(this.metroLabel4, 0, 0);
			this.orderPanel.Controls.Add(this.metroLabel5, 2, 0);
			this.orderPanel.Controls.Add(this.txtCustomer, 1, 0);
			this.orderPanel.Controls.Add(this.metroLabel3, 0, 2);
			this.orderPanel.Controls.Add(this.metroLabel1, 0, 1);
			this.orderPanel.Controls.Add(this.txtOrderState, 1, 2);
			this.orderPanel.Controls.Add(this.txtOrderType, 1, 1);
			this.orderPanel.Controls.Add(this.metroLabel6, 2, 2);
			this.orderPanel.Controls.Add(this.metroLabel2, 2, 1);
			this.orderPanel.Controls.Add(this.txtOrderName, 3, 2);
			this.orderPanel.Controls.Add(this.txtOrderNum, 3, 1);
			this.orderPanel.Controls.Add(this.mainTab, 0, 3);
			this.orderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orderPanel.Location = new System.Drawing.Point(0, 0);
			this.orderPanel.Margin = new System.Windows.Forms.Padding(0);
			this.orderPanel.Name = "orderPanel";
			this.orderPanel.RowCount = 4;
			this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.orderPanel.Size = new System.Drawing.Size(690, 635);
			this.orderPanel.TabIndex = 21;
			// 
			// txtLocation
			// 
			this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocation.BackColor = System.Drawing.Color.White;
			this.txtLocation.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtLocation.Lines = new string[0];
			this.txtLocation.Location = new System.Drawing.Point(443, 3);
			this.txtLocation.MaxLength = 32767;
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.PasswordChar = '\0';
			this.txtLocation.ReadOnly = true;
			this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLocation.SelectedText = "";
			this.txtLocation.Size = new System.Drawing.Size(244, 30);
			this.txtLocation.TabIndex = 22;
			this.txtLocation.UseSelectable = true;
			// 
			// metroLabel4
			// 
			this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.Location = new System.Drawing.Point(3, 8);
			this.metroLabel4.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(89, 20);
			this.metroLabel4.TabIndex = 9;
			this.metroLabel4.Text = "客户名称：";
			// 
			// metroLabel5
			// 
			this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(348, 8);
			this.metroLabel5.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(89, 20);
			this.metroLabel5.TabIndex = 10;
			this.metroLabel5.Text = "科        室：";
			// 
			// txtCustomer
			// 
			this.txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCustomer.BackColor = System.Drawing.Color.White;
			this.txtCustomer.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCustomer.Lines = new string[0];
			this.txtCustomer.Location = new System.Drawing.Point(98, 3);
			this.txtCustomer.MaxLength = 32767;
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.PasswordChar = '\0';
			this.txtCustomer.ReadOnly = true;
			this.txtCustomer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCustomer.SelectedText = "";
			this.txtCustomer.Size = new System.Drawing.Size(244, 30);
			this.txtCustomer.TabIndex = 21;
			this.txtCustomer.UseSelectable = true;
			// 
			// metroLabel3
			// 
			this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(3, 80);
			this.metroLabel3.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(89, 20);
			this.metroLabel3.TabIndex = 16;
			this.metroLabel3.Text = "订单状态：";
			// 
			// metroLabel1
			// 
			this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(3, 44);
			this.metroLabel1.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(89, 20);
			this.metroLabel1.TabIndex = 7;
			this.metroLabel1.Text = "订单类型：";
			// 
			// txtOrderState
			// 
			this.txtOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderState.BackColor = System.Drawing.Color.White;
			this.txtOrderState.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderState.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderState.Lines = new string[0];
			this.txtOrderState.Location = new System.Drawing.Point(98, 75);
			this.txtOrderState.MaxLength = 32767;
			this.txtOrderState.Name = "txtOrderState";
			this.txtOrderState.PasswordChar = '\0';
			this.txtOrderState.ReadOnly = true;
			this.txtOrderState.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderState.SelectedText = "";
			this.txtOrderState.Size = new System.Drawing.Size(244, 30);
			this.txtOrderState.TabIndex = 25;
			this.txtOrderState.UseSelectable = true;
			// 
			// txtOrderType
			// 
			this.txtOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderType.BackColor = System.Drawing.Color.White;
			this.txtOrderType.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderType.Lines = new string[0];
			this.txtOrderType.Location = new System.Drawing.Point(98, 39);
			this.txtOrderType.MaxLength = 32767;
			this.txtOrderType.Name = "txtOrderType";
			this.txtOrderType.PasswordChar = '\0';
			this.txtOrderType.ReadOnly = true;
			this.txtOrderType.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderType.SelectedText = "";
			this.txtOrderType.Size = new System.Drawing.Size(244, 30);
			this.txtOrderType.TabIndex = 23;
			this.txtOrderType.UseSelectable = true;
			// 
			// metroLabel6
			// 
			this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.Location = new System.Drawing.Point(348, 80);
			this.metroLabel6.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(89, 20);
			this.metroLabel6.TabIndex = 18;
			this.metroLabel6.Text = "订单名称：";
			// 
			// metroLabel2
			// 
			this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(348, 44);
			this.metroLabel2.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(89, 20);
			this.metroLabel2.TabIndex = 8;
			this.metroLabel2.Text = "订单编号：";
			// 
			// txtOrderName
			// 
			this.txtOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderName.BackColor = System.Drawing.Color.White;
			this.txtOrderName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderName.Lines = new string[0];
			this.txtOrderName.Location = new System.Drawing.Point(443, 75);
			this.txtOrderName.MaxLength = 32767;
			this.txtOrderName.Name = "txtOrderName";
			this.txtOrderName.PasswordChar = '\0';
			this.txtOrderName.ReadOnly = true;
			this.txtOrderName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderName.SelectedText = "";
			this.txtOrderName.Size = new System.Drawing.Size(244, 30);
			this.txtOrderName.TabIndex = 26;
			this.txtOrderName.UseSelectable = true;
			// 
			// txtOrderNum
			// 
			this.txtOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderNum.BackColor = System.Drawing.Color.White;
			this.txtOrderNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderNum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderNum.Lines = new string[0];
			this.txtOrderNum.Location = new System.Drawing.Point(443, 39);
			this.txtOrderNum.MaxLength = 32767;
			this.txtOrderNum.Name = "txtOrderNum";
			this.txtOrderNum.PasswordChar = '\0';
			this.txtOrderNum.ReadOnly = true;
			this.txtOrderNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderNum.SelectedText = "";
			this.txtOrderNum.Size = new System.Drawing.Size(244, 30);
			this.txtOrderNum.TabIndex = 24;
			this.txtOrderNum.UseSelectable = true;
			// 
			// mainTab
			// 
			this.orderPanel.SetColumnSpan(this.mainTab, 4);
			this.mainTab.Controls.Add(this.tabPage1);
			this.mainTab.Controls.Add(this.tabPage2);
			this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTab.Location = new System.Drawing.Point(3, 111);
			this.mainTab.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.mainTab.Name = "mainTab";
			this.mainTab.SelectedIndex = 0;
			this.mainTab.Size = new System.Drawing.Size(684, 524);
			this.mainTab.TabIndex = 27;
			this.mainTab.SelectedIndexChanged += new System.EventHandler(this.OnTabControlSelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgv_Instrument);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(676, 491);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "处理";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgv_Instrument
			// 
			this.dgv_Instrument.AllowUserToAddRows = false;
			this.dgv_Instrument.AllowUserToDeleteRows = false;
			this.dgv_Instrument.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_Instrument.ColumnHeadersHeight = 28;
			this.dgv_Instrument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ca_name,
            this.instrument_code,
            this.num_send_count,
            this.send_count_now,
            this.remark,
            this.for_label,
            this.codeTypeName,
            this.num,
            this.send_count,
            this.codeType,
            this.c_codeType});
			this.dgv_Instrument.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_Instrument.Location = new System.Drawing.Point(3, 3);
			this.dgv_Instrument.Margin = new System.Windows.Forms.Padding(0);
			this.dgv_Instrument.Name = "dgv_Instrument";
			this.dgv_Instrument.RowHeadersVisible = false;
			this.dgv_Instrument.RowTemplate.Height = 23;
			this.dgv_Instrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_Instrument.Size = new System.Drawing.Size(670, 485);
			this.dgv_Instrument.TabIndex = 28;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.sendInfoPreview);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(676, 491);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "预览";
			this.tabPage2.UseVisualStyleBackColor = true;
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
            this.thingRemakCol});
			this.sendInfoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sendInfoPreview.Location = new System.Drawing.Point(3, 3);
			this.sendInfoPreview.Margin = new System.Windows.Forms.Padding(0);
			this.sendInfoPreview.MultiSelect = false;
			this.sendInfoPreview.Name = "sendInfoPreview";
			this.sendInfoPreview.ReadOnly = true;
			this.sendInfoPreview.RowHeadersVisible = false;
			this.sendInfoPreview.RowTemplate.Height = 23;
			this.sendInfoPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.sendInfoPreview.Size = new System.Drawing.Size(670, 485);
			this.sendInfoPreview.TabIndex = 29;
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
			this.thingNameCol.Width = 180;
			// 
			// thingNumCol
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.thingNumCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.thingNumCol.HeaderText = "数量";
			this.thingNumCol.Name = "thingNumCol";
			this.thingNumCol.ReadOnly = true;
			this.thingNumCol.Width = 80;
			// 
			// thingRemakCol
			// 
			this.thingRemakCol.HeaderText = "备注";
			this.thingRemakCol.Name = "thingRemakCol";
			this.thingRemakCol.ReadOnly = true;
			this.thingRemakCol.Width = 180;
			// 
			// scanPanel
			// 
			this.scanPanel.ColumnCount = 1;
			this.scanPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scanPanel.Controls.Add(this.gb_temp, 0, 0);
			this.scanPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scanPanel.Location = new System.Drawing.Point(0, 0);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.RowCount = 1;
			this.scanPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scanPanel.Size = new System.Drawing.Size(365, 635);
			this.scanPanel.TabIndex = 0;
			// 
			// gb_temp
			// 
			this.gb_temp.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.gb_temp.Controls.Add(this.scanInnerPanel);
			this.gb_temp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gb_temp.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.gb_temp.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
			this.gb_temp.HeaderText = "扫描包外标签";
			this.gb_temp.Location = new System.Drawing.Point(2, 0);
			this.gb_temp.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
			this.gb_temp.Name = "gb_temp";
			this.gb_temp.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
			this.gb_temp.Size = new System.Drawing.Size(360, 635);
			this.gb_temp.TabIndex = 1;
			this.gb_temp.Text = "扫描包外标签";
			// 
			// scanInnerPanel
			// 
			this.scanInnerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scanInnerPanel.ColumnCount = 1;
			this.scanInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.scanInnerPanel.Controls.Add(this.dgv_BcuData, 0, 1);
			this.scanInnerPanel.Controls.Add(this.scanCodeLbl, 0, 0);
			this.scanInnerPanel.Controls.Add(this.resultLbl, 0, 2);
			this.scanInnerPanel.Location = new System.Drawing.Point(2, 22);
			this.scanInnerPanel.Name = "scanInnerPanel";
			this.scanInnerPanel.RowCount = 3;
			this.scanInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.scanInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.scanInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.scanInnerPanel.Size = new System.Drawing.Size(356, 610);
			this.scanInnerPanel.TabIndex = 0;
			// 
			// dgv_BcuData
			// 
			this.dgv_BcuData.AllowUserToAddRows = false;
			this.dgv_BcuData.AllowUserToDeleteRows = false;
			this.dgv_BcuData.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_BcuData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_BcuData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bid,
            this.b_bar_code,
            this.b_ca_name,
            this.setTypeCol,
            this.t_b_bar_code});
			this.dgv_BcuData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_BcuData.Location = new System.Drawing.Point(0, 36);
			this.dgv_BcuData.Margin = new System.Windows.Forms.Padding(0);
			this.dgv_BcuData.MultiSelect = false;
			this.dgv_BcuData.Name = "dgv_BcuData";
			this.dgv_BcuData.ReadOnly = true;
			this.dgv_BcuData.RowHeadersVisible = false;
			this.dgv_BcuData.RowTemplate.Height = 23;
			this.dgv_BcuData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_BcuData.Size = new System.Drawing.Size(356, 554);
			this.dgv_BcuData.TabIndex = 3;
			// 
			// bid
			// 
			this.bid.HeaderText = "序号";
			this.bid.Name = "bid";
			this.bid.ReadOnly = true;
			this.bid.Width = 80;
			// 
			// b_bar_code
			// 
			this.b_bar_code.HeaderText = "条形码";
			this.b_bar_code.Name = "b_bar_code";
			this.b_bar_code.ReadOnly = true;
			this.b_bar_code.Width = 120;
			// 
			// b_ca_name
			// 
			this.b_ca_name.HeaderText = "器械包名称";
			this.b_ca_name.Name = "b_ca_name";
			this.b_ca_name.ReadOnly = true;
			this.b_ca_name.Width = 180;
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
			// scanCodeLbl
			// 
			this.scanCodeLbl.ColumnCount = 2;
			this.scanCodeLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.scanCodeLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.scanCodeLbl.Controls.Add(this.metroLabel9, 0, 0);
			this.scanCodeLbl.Controls.Add(this.metBcuCode, 1, 0);
			this.scanCodeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scanCodeLbl.Location = new System.Drawing.Point(0, 0);
			this.scanCodeLbl.Margin = new System.Windows.Forms.Padding(0);
			this.scanCodeLbl.Name = "scanCodeLbl";
			this.scanCodeLbl.RowCount = 1;
			this.scanCodeLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.scanCodeLbl.Size = new System.Drawing.Size(356, 36);
			this.scanCodeLbl.TabIndex = 16;
			// 
			// metroLabel9
			// 
			this.metroLabel9.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel9.AutoSize = true;
			this.metroLabel9.Location = new System.Drawing.Point(3, 8);
			this.metroLabel9.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel9.Name = "metroLabel9";
			this.metroLabel9.Size = new System.Drawing.Size(89, 20);
			this.metroLabel9.TabIndex = 9;
			this.metroLabel9.Text = "扫描条码：";
			// 
			// metBcuCode
			// 
			this.metBcuCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.metBcuCode.BackColor = System.Drawing.Color.White;
			this.metBcuCode.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.metBcuCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.metBcuCode.Lines = new string[0];
			this.metBcuCode.Location = new System.Drawing.Point(98, 3);
			this.metBcuCode.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.metBcuCode.MaxLength = 32767;
			this.metBcuCode.Name = "metBcuCode";
			this.metBcuCode.PasswordChar = '\0';
			this.metBcuCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metBcuCode.SelectedText = "";
			this.metBcuCode.Size = new System.Drawing.Size(258, 30);
			this.metBcuCode.TabIndex = 2;
			this.metBcuCode.UseCustomBackColor = true;
			this.metBcuCode.UseSelectable = true;
			this.metBcuCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metBcuCode_KeyDown);
			this.metBcuCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.metBcuCode_KeyPress);
			// 
			// resultLbl
			// 
			this.resultLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.resultLbl.AutoSize = true;
			this.resultLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.resultLbl.ForeColor = System.Drawing.Color.Green;
			this.resultLbl.Location = new System.Drawing.Point(3, 590);
			this.resultLbl.Name = "resultLbl";
			this.resultLbl.Size = new System.Drawing.Size(350, 20);
			this.resultLbl.TabIndex = 17;
			this.resultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.resultLbl.Visible = false;
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			// 
			// ca_name
			// 
			this.ca_name.FillWeight = 133.9236F;
			this.ca_name.HeaderText = "物品名称";
			this.ca_name.MinimumWidth = 80;
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			this.ca_name.Width = 200;
			// 
			// instrument_code
			// 
			this.instrument_code.HeaderText = "品名id";
			this.instrument_code.Name = "instrument_code";
			this.instrument_code.Visible = false;
			// 
			// num_send_count
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.num_send_count.DefaultCellStyle = dataGridViewCellStyle1;
			this.num_send_count.FillWeight = 184.3153F;
			this.num_send_count.HeaderText = "已发放数量/总数量";
			this.num_send_count.MinimumWidth = 150;
			this.num_send_count.Name = "num_send_count";
			this.num_send_count.ReadOnly = true;
			this.num_send_count.Width = 150;
			// 
			// send_count_now
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.send_count_now.DefaultCellStyle = dataGridViewCellStyle2;
			this.send_count_now.FillWeight = 22.65554F;
			this.send_count_now.HeaderText = "此次发放数量";
			this.send_count_now.MinimumWidth = 75;
			this.send_count_now.Name = "send_count_now";
			this.send_count_now.Width = 150;
			// 
			// remark
			// 
			this.remark.FillWeight = 22.65554F;
			this.remark.HeaderText = "备注";
			this.remark.MinimumWidth = 65;
			this.remark.Name = "remark";
			this.remark.Visible = false;
			this.remark.Width = 65;
			// 
			// for_label
			// 
			this.for_label.FillWeight = 61.29996F;
			this.for_label.HeaderText = "标签";
			this.for_label.MinimumWidth = 80;
			this.for_label.Name = "for_label";
			this.for_label.Visible = false;
			this.for_label.Width = 150;
			// 
			// codeTypeName
			// 
			this.codeTypeName.FillWeight = 98.24655F;
			this.codeTypeName.HeaderText = "类型";
			this.codeTypeName.MinimumWidth = 80;
			this.codeTypeName.Name = "codeTypeName";
			this.codeTypeName.ReadOnly = true;
			this.codeTypeName.Width = 150;
			// 
			// num
			// 
			this.num.HeaderText = "器械数量";
			this.num.Name = "num";
			this.num.Visible = false;
			// 
			// send_count
			// 
			this.send_count.HeaderText = "已发放数量";
			this.send_count.Name = "send_count";
			this.send_count.Visible = false;
			// 
			// codeType
			// 
			this.codeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.codeType.HeaderText = "类型枚举值";
			this.codeType.Name = "codeType";
			this.codeType.Visible = false;
			this.codeType.Width = 5;
			// 
			// c_codeType
			// 
			this.c_codeType.HeaderText = "子类型枚举值";
			this.c_codeType.Name = "c_codeType";
			this.c_codeType.Visible = false;
			this.c_codeType.Width = 150;
			// 
			// HCSSM_order_new_order_handle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1195, 715);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.Name = "HCSSM_order_new_order_handle";
			this.Text = "发货处理";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HCSSM_order_new_order_handle_FormClosing);
			this.Load += new System.EventHandler(this.HCSSM_order_new_order_handle_Load);
			this.mainPanel.ResumeLayout(false);
			this.btnPanel.ResumeLayout(false);
			this.leftSplitter.Panel1.ResumeLayout(false);
			this.leftSplitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.leftSplitter)).EndInit();
			this.leftSplitter.ResumeLayout(false);
			this.orderPanel.ResumeLayout(false);
			this.orderPanel.PerformLayout();
			this.mainTab.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sendInfoPreview)).EndInit();
			this.scanPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gb_temp)).EndInit();
			this.gb_temp.ResumeLayout(false);
			this.scanInnerPanel.ResumeLayout(false);
			this.scanInnerPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_BcuData)).EndInit();
			this.scanCodeLbl.ResumeLayout(false);
			this.scanCodeLbl.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderPerson;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderName;
		private System.Windows.Forms.Label metroLabel6;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderState;
		private System.Windows.Forms.Label metroLabel3;
		private System.Windows.Forms.Label metroLabel1;
		private System.Windows.Forms.Label metroLabel2;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderType;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderNum;
		private System.Windows.Forms.Label metroLabel4;
		private CnasMetroFramework.Controls.MetroTextBox txtCustomer;
		private System.Windows.Forms.Label metroLabel5;
		private CnasMetroFramework.Controls.MetroTextBox txtLocation;
		private System.Windows.Forms.DataGridView dgv_Instrument;
		private System.Windows.Forms.Label metroLabel9;
		private CnasMetroFramework.Controls.MetroTextBox metBcuCode;
		private Telerik.WinControls.UI.RadGroupBox gb_temp;
		private System.Windows.Forms.DataGridView dgv_BcuData;
		private CnasMetroFramework.Controls.MetroTile btnSave;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.SplitContainer leftSplitter;
		private System.Windows.Forms.TableLayoutPanel orderPanel;
		private System.Windows.Forms.TableLayoutPanel scanPanel;
		private System.Windows.Forms.TableLayoutPanel scanInnerPanel;
		private System.Windows.Forms.TableLayoutPanel scanCodeLbl;
		private System.Windows.Forms.Label resultLbl;
		private System.Windows.Forms.DataGridViewTextBoxColumn bid;
		private System.Windows.Forms.DataGridViewTextBoxColumn b_bar_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn b_ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn t_b_bar_code;
		private System.Windows.Forms.TabControl mainTab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView sendInfoPreview;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn thingRemakCol;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn instrument_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn num_send_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_count_now;
		private System.Windows.Forms.DataGridViewTextBoxColumn remark;
		private System.Windows.Forms.DataGridViewTextBoxColumn for_label;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeTypeName;
		private System.Windows.Forms.DataGridViewTextBoxColumn num;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeType;
		private System.Windows.Forms.DataGridViewTextBoxColumn c_codeType;
	}
}