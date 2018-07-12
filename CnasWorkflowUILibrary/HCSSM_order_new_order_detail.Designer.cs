namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_new_order_detail
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnSave = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnViewImage = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.lb_instrumentNum = new System.Windows.Forms.Label();
			this.txt_InstrumentNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txt_setNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.lb_SetNum = new System.Windows.Forms.Label();
			this.btnPatient = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnImage = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.bindingCodeTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.dgv_Instrument = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrument_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c_codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.send_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.metroLabel4 = new System.Windows.Forms.Label();
			this.txtCreTime = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.bindingCodeLbl = new System.Windows.Forms.Label();
			this.txtCustmoer = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel8 = new System.Windows.Forms.Label();
			this.txtOrderPerson = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel5 = new System.Windows.Forms.Label();
			this.metroLabel7 = new System.Windows.Forms.Label();
			this.txtLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel1 = new System.Windows.Forms.Label();
			this.txtOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel6 = new System.Windows.Forms.Label();
			this.txtOrderName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel3 = new System.Windows.Forms.Label();
			this.txtOrderState = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtOrderNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.btnPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Controls.Add(this.btnPanel, 1, 0);
			this.mainPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(950, 551);
			this.mainPanel.TabIndex = 0;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 2;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnSave, 0, 0);
			this.btnPanel.Controls.Add(this.btnViewImage, 0, 1);
			this.btnPanel.Controls.Add(this.lb_instrumentNum, 0, 8);
			this.btnPanel.Controls.Add(this.txt_InstrumentNum, 1, 8);
			this.btnPanel.Controls.Add(this.txt_setNum, 1, 7);
			this.btnPanel.Controls.Add(this.lb_SetNum, 0, 7);
			this.btnPanel.Controls.Add(this.btnPatient, 0, 2);
			this.btnPanel.Controls.Add(this.btnImage, 0, 3);
			this.btnPanel.Controls.Add(this.btnClose, 0, 4);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(809, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 9;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.Size = new System.Drawing.Size(141, 551);
			this.btnPanel.TabIndex = 3;
			// 
			// btnSave
			// 
			this.btnSave.ActiveControl = null;
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPanel.SetColumnSpan(this.btnSave, 2);
			this.btnSave.Location = new System.Drawing.Point(2, 2);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(135, 40);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "保           存";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.UseSelectable = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.OnbtnSave_Click);
			// 
			// btnViewImage
			// 
			this.btnViewImage.ActiveControl = null;
			this.btnViewImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPanel.SetColumnSpan(this.btnViewImage, 2);
			this.btnViewImage.Location = new System.Drawing.Point(3, 47);
			this.btnViewImage.Name = "btnViewImage";
			this.btnViewImage.Size = new System.Drawing.Size(135, 40);
			this.btnViewImage.TabIndex = 32;
			this.btnViewImage.Text = "查 看 图 片";
			this.btnViewImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnViewImage.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnViewImage.UseSelectable = true;
			this.btnViewImage.UseTileImage = true;
			this.btnViewImage.Click += new System.EventHandler(this.btnViewImage_Click);
			// 
			// lb_instrumentNum
			// 
			this.lb_instrumentNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lb_instrumentNum.AutoSize = true;
			this.lb_instrumentNum.Location = new System.Drawing.Point(3, 523);
			this.lb_instrumentNum.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.lb_instrumentNum.Name = "lb_instrumentNum";
			this.lb_instrumentNum.Size = new System.Drawing.Size(83, 20);
			this.lb_instrumentNum.TabIndex = 27;
			this.lb_instrumentNum.Text = "物    品(件)";
			// 
			// txt_InstrumentNum
			// 
			this.txt_InstrumentNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_InstrumentNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txt_InstrumentNum.Lines = new string[] {
        "0"};
			this.txt_InstrumentNum.Location = new System.Drawing.Point(88, 518);
			this.txt_InstrumentNum.Margin = new System.Windows.Forms.Padding(2);
			this.txt_InstrumentNum.MaxLength = 32767;
			this.txt_InstrumentNum.Name = "txt_InstrumentNum";
			this.txt_InstrumentNum.PasswordChar = '\0';
			this.txt_InstrumentNum.ReadOnly = true;
			this.txt_InstrumentNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txt_InstrumentNum.SelectedText = "";
			this.txt_InstrumentNum.Size = new System.Drawing.Size(51, 30);
			this.txt_InstrumentNum.TabIndex = 22;
			this.txt_InstrumentNum.Text = "0";
			this.txt_InstrumentNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_InstrumentNum.UseSelectable = true;
			this.txt_InstrumentNum.Visible = false;
			// 
			// txt_setNum
			// 
			this.txt_setNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_setNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txt_setNum.Lines = new string[] {
        "0"};
			this.txt_setNum.Location = new System.Drawing.Point(88, 484);
			this.txt_setNum.Margin = new System.Windows.Forms.Padding(2);
			this.txt_setNum.MaxLength = 32767;
			this.txt_setNum.Name = "txt_setNum";
			this.txt_setNum.PasswordChar = '\0';
			this.txt_setNum.ReadOnly = true;
			this.txt_setNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txt_setNum.SelectedText = "";
			this.txt_setNum.Size = new System.Drawing.Size(51, 30);
			this.txt_setNum.TabIndex = 21;
			this.txt_setNum.Text = "0";
			this.txt_setNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_setNum.UseSelectable = true;
			this.txt_setNum.Visible = false;
			// 
			// lb_SetNum
			// 
			this.lb_SetNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lb_SetNum.AutoSize = true;
			this.lb_SetNum.Location = new System.Drawing.Point(3, 489);
			this.lb_SetNum.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.lb_SetNum.Name = "lb_SetNum";
			this.lb_SetNum.Size = new System.Drawing.Size(83, 20);
			this.lb_SetNum.TabIndex = 26;
			this.lb_SetNum.Text = "器械包(个)";
			// 
			// btnPatient
			// 
			this.btnPatient.ActiveControl = null;
			this.btnPatient.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPanel.SetColumnSpan(this.btnPatient, 2);
			this.btnPatient.Location = new System.Drawing.Point(3, 93);
			this.btnPatient.Name = "btnPatient";
			this.btnPatient.Size = new System.Drawing.Size(135, 40);
			this.btnPatient.TabIndex = 33;
			this.btnPatient.Text = "病 人 信 息";
			this.btnPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPatient.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPatient.UseSelectable = true;
			this.btnPatient.UseTileImage = true;
			this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
			// 
			// btnImage
			// 
			this.btnImage.ActiveControl = null;
			this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPanel.SetColumnSpan(this.btnImage, 2);
			this.btnImage.Location = new System.Drawing.Point(3, 139);
			this.btnImage.Name = "btnImage";
			this.btnImage.Size = new System.Drawing.Size(135, 40);
			this.btnImage.TabIndex = 34;
			this.btnImage.Text = "订 单 图 片";
			this.btnImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImage.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImage.UseSelectable = true;
			this.btnImage.UseTileImage = true;
			this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPanel.SetColumnSpan(this.btnClose, 2);
			this.btnClose.Location = new System.Drawing.Point(3, 185);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(135, 40);
			this.btnClose.TabIndex = 35;
			this.btnClose.Text = "关          闭";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.OnbtnClose_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.bindingCodeTxt, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.dgv_Instrument, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtCreTime, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.bindingCodeLbl, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.txtCustmoer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel8, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderPerson, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtLocation, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderType, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel6, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderName, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderState, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderNum, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 551);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// bindingCodeTxt
			// 
			this.bindingCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.bindingCodeTxt.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.bindingCodeTxt, 3);
			this.bindingCodeTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.bindingCodeTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bindingCodeTxt.Lines = new string[0];
			this.bindingCodeTxt.Location = new System.Drawing.Point(98, 147);
			this.bindingCodeTxt.MaxLength = 32767;
			this.bindingCodeTxt.Name = "bindingCodeTxt";
			this.bindingCodeTxt.PasswordChar = '\0';
			this.bindingCodeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.bindingCodeTxt.SelectedText = "";
			this.bindingCodeTxt.Size = new System.Drawing.Size(708, 30);
			this.bindingCodeTxt.TabIndex = 19;
			this.bindingCodeTxt.UseSelectable = true;
			// 
			// dgv_Instrument
			// 
			this.dgv_Instrument.AllowUserToAddRows = false;
			this.dgv_Instrument.AllowUserToDeleteRows = false;
			this.dgv_Instrument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_Instrument.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_Instrument.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_Instrument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Instrument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.instrument_code,
            this.ca_name,
            this.codeTypeName,
            this.codeType,
            this.c_codeType,
            this.num,
            this.send_count,
            this.remark});
			this.tableLayoutPanel1.SetColumnSpan(this.dgv_Instrument, 4);
			this.dgv_Instrument.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_Instrument.Location = new System.Drawing.Point(3, 180);
			this.dgv_Instrument.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dgv_Instrument.Name = "dgv_Instrument";
			this.dgv_Instrument.RowHeadersVisible = false;
			this.dgv_Instrument.RowTemplate.Height = 23;
			this.dgv_Instrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_Instrument.Size = new System.Drawing.Size(803, 371);
			this.dgv_Instrument.TabIndex = 20;
			this.dgv_Instrument.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Instrument_CellDoubleClick);
			// 
			// id
			// 
			this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			this.id.Width = 5;
			// 
			// instrument_code
			// 
			this.instrument_code.HeaderText = "品名id";
			this.instrument_code.Name = "instrument_code";
			this.instrument_code.Visible = false;
			// 
			// ca_name
			// 
			this.ca_name.HeaderText = "品名";
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			// 
			// codeTypeName
			// 
			this.codeTypeName.HeaderText = "类型";
			this.codeTypeName.Name = "codeTypeName";
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
			// 
			// num
			// 
			this.num.HeaderText = "数量";
			this.num.Name = "num";
			// 
			// send_count
			// 
			this.send_count.HeaderText = "已发放数量";
			this.send_count.Name = "send_count";
			this.send_count.ReadOnly = true;
			// 
			// remark
			// 
			this.remark.HeaderText = "备注";
			this.remark.Name = "remark";
			// 
			// metroLabel4
			// 
			this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.Location = new System.Drawing.Point(3, 8);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(89, 20);
			this.metroLabel4.TabIndex = 9;
			this.metroLabel4.Text = "客户名称：";
			// 
			// txtCreTime
			// 
			this.txtCreTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCreTime.BackColor = System.Drawing.Color.White;
			this.txtCreTime.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCreTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCreTime.Lines = new string[0];
			this.txtCreTime.Location = new System.Drawing.Point(507, 111);
			this.txtCreTime.MaxLength = 32767;
			this.txtCreTime.Name = "txtCreTime";
			this.txtCreTime.PasswordChar = '\0';
			this.txtCreTime.ReadOnly = true;
			this.txtCreTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCreTime.SelectedText = "";
			this.txtCreTime.Size = new System.Drawing.Size(299, 30);
			this.txtCreTime.TabIndex = 18;
			this.txtCreTime.UseSelectable = true;
			// 
			// bindingCodeLbl
			// 
			this.bindingCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.bindingCodeLbl.AutoSize = true;
			this.bindingCodeLbl.Location = new System.Drawing.Point(3, 152);
			this.bindingCodeLbl.Name = "bindingCodeLbl";
			this.bindingCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.bindingCodeLbl.TabIndex = 28;
			this.bindingCodeLbl.Text = "绑  定  号：";
			// 
			// txtCustmoer
			// 
			this.txtCustmoer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCustmoer.BackColor = System.Drawing.Color.White;
			this.txtCustmoer.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCustmoer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCustmoer.Lines = new string[0];
			this.txtCustmoer.Location = new System.Drawing.Point(98, 3);
			this.txtCustmoer.MaxLength = 32767;
			this.txtCustmoer.Name = "txtCustmoer";
			this.txtCustmoer.PasswordChar = '\0';
			this.txtCustmoer.ReadOnly = true;
			this.txtCustmoer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCustmoer.SelectedText = "";
			this.txtCustmoer.Size = new System.Drawing.Size(298, 30);
			this.txtCustmoer.TabIndex = 11;
			this.txtCustmoer.UseSelectable = true;
			// 
			// metroLabel8
			// 
			this.metroLabel8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.Location = new System.Drawing.Point(412, 116);
			this.metroLabel8.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new System.Drawing.Size(89, 20);
			this.metroLabel8.TabIndex = 22;
			this.metroLabel8.Text = "创建时间：";
			// 
			// txtOrderPerson
			// 
			this.txtOrderPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderPerson.BackColor = System.Drawing.Color.White;
			this.txtOrderPerson.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderPerson.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderPerson.Lines = new string[0];
			this.txtOrderPerson.Location = new System.Drawing.Point(98, 111);
			this.txtOrderPerson.MaxLength = 32767;
			this.txtOrderPerson.Name = "txtOrderPerson";
			this.txtOrderPerson.PasswordChar = '\0';
			this.txtOrderPerson.ReadOnly = true;
			this.txtOrderPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderPerson.SelectedText = "";
			this.txtOrderPerson.Size = new System.Drawing.Size(298, 30);
			this.txtOrderPerson.TabIndex = 17;
			this.txtOrderPerson.UseSelectable = true;
			// 
			// metroLabel5
			// 
			this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(412, 8);
			this.metroLabel5.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(89, 20);
			this.metroLabel5.TabIndex = 10;
			this.metroLabel5.Text = "科        室：";
			// 
			// metroLabel7
			// 
			this.metroLabel7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.Location = new System.Drawing.Point(3, 116);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(89, 20);
			this.metroLabel7.TabIndex = 21;
			this.metroLabel7.Text = "下  单  人：";
			// 
			// txtLocation
			// 
			this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocation.BackColor = System.Drawing.Color.White;
			this.txtLocation.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtLocation.Lines = new string[0];
			this.txtLocation.Location = new System.Drawing.Point(507, 3);
			this.txtLocation.MaxLength = 32767;
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.PasswordChar = '\0';
			this.txtLocation.ReadOnly = true;
			this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLocation.SelectedText = "";
			this.txtLocation.Size = new System.Drawing.Size(299, 30);
			this.txtLocation.TabIndex = 12;
			this.txtLocation.UseSelectable = true;
			// 
			// metroLabel1
			// 
			this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(3, 44);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(89, 20);
			this.metroLabel1.TabIndex = 7;
			this.metroLabel1.Text = "订单类型：";
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
			this.txtOrderType.Size = new System.Drawing.Size(298, 30);
			this.txtOrderType.TabIndex = 13;
			this.txtOrderType.UseSelectable = true;
			// 
			// metroLabel6
			// 
			this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.Location = new System.Drawing.Point(412, 80);
			this.metroLabel6.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(89, 20);
			this.metroLabel6.TabIndex = 18;
			this.metroLabel6.Text = "订单名称：";
			// 
			// txtOrderName
			// 
			this.txtOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderName.BackColor = System.Drawing.Color.White;
			this.txtOrderName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderName.Lines = new string[0];
			this.txtOrderName.Location = new System.Drawing.Point(507, 75);
			this.txtOrderName.MaxLength = 32767;
			this.txtOrderName.Name = "txtOrderName";
			this.txtOrderName.PasswordChar = '\0';
			this.txtOrderName.ReadOnly = true;
			this.txtOrderName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderName.SelectedText = "";
			this.txtOrderName.Size = new System.Drawing.Size(299, 30);
			this.txtOrderName.TabIndex = 16;
			this.txtOrderName.UseSelectable = true;
			// 
			// metroLabel3
			// 
			this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(412, 44);
			this.metroLabel3.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(89, 20);
			this.metroLabel3.TabIndex = 16;
			this.metroLabel3.Text = "订单状态：";
			// 
			// txtOrderState
			// 
			this.txtOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderState.BackColor = System.Drawing.Color.White;
			this.txtOrderState.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderState.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderState.Lines = new string[0];
			this.txtOrderState.Location = new System.Drawing.Point(507, 39);
			this.txtOrderState.MaxLength = 32767;
			this.txtOrderState.Name = "txtOrderState";
			this.txtOrderState.PasswordChar = '\0';
			this.txtOrderState.ReadOnly = true;
			this.txtOrderState.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderState.SelectedText = "";
			this.txtOrderState.Size = new System.Drawing.Size(299, 30);
			this.txtOrderState.TabIndex = 14;
			this.txtOrderState.UseSelectable = true;
			// 
			// txtOrderNum
			// 
			this.txtOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderNum.BackColor = System.Drawing.Color.White;
			this.txtOrderNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderNum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderNum.Lines = new string[0];
			this.txtOrderNum.Location = new System.Drawing.Point(98, 75);
			this.txtOrderNum.MaxLength = 32767;
			this.txtOrderNum.Name = "txtOrderNum";
			this.txtOrderNum.PasswordChar = '\0';
			this.txtOrderNum.ReadOnly = true;
			this.txtOrderNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderNum.SelectedText = "";
			this.txtOrderNum.Size = new System.Drawing.Size(298, 30);
			this.txtOrderNum.TabIndex = 15;
			this.txtOrderNum.UseSelectable = true;
			// 
			// metroLabel2
			// 
			this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(3, 80);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(89, 20);
			this.metroLabel2.TabIndex = 8;
			this.metroLabel2.Text = "订单编号：";
			// 
			// HCSSM_order_new_order_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 631);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MinimumSize = new System.Drawing.Size(775, 530);
			this.Name = "HCSSM_order_new_order_detail";
			this.Text = "订单详情";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.Load += new System.EventHandler(this.HCSSM_order_new_order_detail_Load);
			this.mainPanel.ResumeLayout(false);
			this.btnPanel.ResumeLayout(false);
			this.btnPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private CnasMetroFramework.Controls.MetroTextBox bindingCodeTxt;
		private CnasMetroFramework.Controls.MetroTextBox txtCreTime;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderPerson;
		private System.Windows.Forms.Label metroLabel7;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderName;
		private System.Windows.Forms.Label metroLabel6;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderState;
		private System.Windows.Forms.Label metroLabel3;
		private System.Windows.Forms.Label metroLabel1;
		private System.Windows.Forms.Label metroLabel2;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderType;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderNum;
		private System.Windows.Forms.Label metroLabel4;
		private CnasMetroFramework.Controls.MetroTextBox txtCustmoer;
		private System.Windows.Forms.Label metroLabel5;
		private CnasMetroFramework.Controls.MetroTextBox txtLocation;
		private System.Windows.Forms.DataGridView dgv_Instrument;
		private System.Windows.Forms.Label metroLabel8;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private CnasMetroFramework.Controls.MetroTile btnSave;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn instrument_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeTypeName;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeType;
		private System.Windows.Forms.DataGridViewTextBoxColumn c_codeType;
		private System.Windows.Forms.DataGridViewTextBoxColumn num;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn remark;
		private CnasMetroFramework.Controls.MetroTile btnViewImage;
		private System.Windows.Forms.Label bindingCodeLbl;
		private CnasMetroFramework.Controls.MetroTile btnImage;
		private System.Windows.Forms.Label lb_SetNum;
		private System.Windows.Forms.Label lb_instrumentNum;
		private CnasMetroFramework.Controls.MetroTextBox txt_setNum;
		private CnasMetroFramework.Controls.MetroTextBox txt_InstrumentNum;
		private CnasMetroFramework.Controls.MetroTile btnPatient;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

	}
}