namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCS_packset_dealinstrument_detail
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
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.dgv_Instrument = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrument_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c_codeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.deal_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.now_deal_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customerLbl = new System.Windows.Forms.Label();
			this.txtCustmoer = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.locationLbl = new System.Windows.Forms.Label();
			this.txtCreTime = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.creTimeLbl = new System.Windows.Forms.Label();
			this.txtOrderPerson = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.creUserLbl = new System.Windows.Forms.Label();
			this.orderCodeLbl = new System.Windows.Forms.Label();
			this.txtOrderNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderNameLbl = new System.Windows.Forms.Label();
			this.txtOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtOrderName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderTypeLbl = new System.Windows.Forms.Label();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnSave = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnImage = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPatient = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnViewImage = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPrintBcu = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.statisisInfoBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).BeginInit();
			this.btnPanel.SuspendLayout();
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
			this.mainPanel.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.mainPanel.Controls.Add(this.btnPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(925, 490);
			this.mainPanel.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.dgv_Instrument, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.customerLbl, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.txtCustmoer, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.locationLbl, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.txtCreTime, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.creTimeLbl, 2, 3);
			this.tableLayoutPanel2.Controls.Add(this.txtOrderPerson, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.txtLocation, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.creUserLbl, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.orderCodeLbl, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.txtOrderNum, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.orderNameLbl, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.txtOrderType, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.txtOrderName, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.orderTypeLbl, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 5;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(792, 490);
			this.tableLayoutPanel2.TabIndex = 25;
			// 
			// dgv_Instrument
			// 
			this.dgv_Instrument.AllowUserToAddRows = false;
			this.dgv_Instrument.AllowUserToDeleteRows = false;
			this.dgv_Instrument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_Instrument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_Instrument.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_Instrument.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_Instrument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Instrument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ca_name,
            this.codeTypeName,
            this.instrument_code,
            this.codeType,
            this.c_codeType,
            this.num,
            this.deal_count,
            this.now_deal_count,
            this.remark});
			this.tableLayoutPanel2.SetColumnSpan(this.dgv_Instrument, 4);
			this.dgv_Instrument.Location = new System.Drawing.Point(3, 141);
			this.dgv_Instrument.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dgv_Instrument.Name = "dgv_Instrument";
			this.dgv_Instrument.RowHeadersVisible = false;
			this.dgv_Instrument.RowTemplate.Height = 23;
			this.dgv_Instrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_Instrument.Size = new System.Drawing.Size(786, 349);
			this.dgv_Instrument.TabIndex = 8;
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
			// ca_name
			// 
			this.ca_name.HeaderText = "品名";
			this.ca_name.MinimumWidth = 60;
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			// 
			// codeTypeName
			// 
			this.codeTypeName.HeaderText = "类型";
			this.codeTypeName.MinimumWidth = 60;
			this.codeTypeName.Name = "codeTypeName";
			this.codeTypeName.ReadOnly = true;
			// 
			// instrument_code
			// 
			this.instrument_code.HeaderText = "品名id";
			this.instrument_code.Name = "instrument_code";
			this.instrument_code.Visible = false;
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
			this.num.MinimumWidth = 60;
			this.num.Name = "num";
			this.num.ReadOnly = true;
			// 
			// deal_count
			// 
			this.deal_count.HeaderText = "已处理数量";
			this.deal_count.MinimumWidth = 60;
			this.deal_count.Name = "deal_count";
			this.deal_count.ReadOnly = true;
			// 
			// now_deal_count
			// 
			this.now_deal_count.HeaderText = "本次处理数量";
			this.now_deal_count.MinimumWidth = 60;
			this.now_deal_count.Name = "now_deal_count";
			// 
			// remark
			// 
			this.remark.HeaderText = "备注";
			this.remark.Name = "remark";
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Location = new System.Drawing.Point(3, 7);
			this.customerLbl.Margin = new System.Windows.Forms.Padding(3);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(89, 20);
			this.customerLbl.TabIndex = 9;
			this.customerLbl.Text = "客户名称：";
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
			this.txtCustmoer.Size = new System.Drawing.Size(295, 29);
			this.txtCustmoer.TabIndex = 1;
			this.txtCustmoer.UseSelectable = true;
			// 
			// locationLbl
			// 
			this.locationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.locationLbl.AutoSize = true;
			this.locationLbl.Location = new System.Drawing.Point(399, 7);
			this.locationLbl.Margin = new System.Windows.Forms.Padding(3);
			this.locationLbl.Name = "locationLbl";
			this.locationLbl.Size = new System.Drawing.Size(89, 20);
			this.locationLbl.TabIndex = 10;
			this.locationLbl.Text = "科        室：";
			// 
			// txtCreTime
			// 
			this.txtCreTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCreTime.BackColor = System.Drawing.Color.White;
			this.txtCreTime.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCreTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCreTime.Lines = new string[0];
			this.txtCreTime.Location = new System.Drawing.Point(494, 109);
			this.txtCreTime.MaxLength = 32767;
			this.txtCreTime.Name = "txtCreTime";
			this.txtCreTime.PasswordChar = '\0';
			this.txtCreTime.ReadOnly = true;
			this.txtCreTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCreTime.SelectedText = "";
			this.txtCreTime.Size = new System.Drawing.Size(295, 29);
			this.txtCreTime.TabIndex = 7;
			this.txtCreTime.UseSelectable = true;
			// 
			// creTimeLbl
			// 
			this.creTimeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.creTimeLbl.AutoSize = true;
			this.creTimeLbl.Location = new System.Drawing.Point(399, 113);
			this.creTimeLbl.Margin = new System.Windows.Forms.Padding(3);
			this.creTimeLbl.Name = "creTimeLbl";
			this.creTimeLbl.Size = new System.Drawing.Size(89, 20);
			this.creTimeLbl.TabIndex = 22;
			this.creTimeLbl.Text = "创建时间：";
			// 
			// txtOrderPerson
			// 
			this.txtOrderPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderPerson.BackColor = System.Drawing.Color.White;
			this.txtOrderPerson.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderPerson.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderPerson.Lines = new string[0];
			this.txtOrderPerson.Location = new System.Drawing.Point(98, 109);
			this.txtOrderPerson.MaxLength = 32767;
			this.txtOrderPerson.Name = "txtOrderPerson";
			this.txtOrderPerson.PasswordChar = '\0';
			this.txtOrderPerson.ReadOnly = true;
			this.txtOrderPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderPerson.SelectedText = "";
			this.txtOrderPerson.Size = new System.Drawing.Size(295, 29);
			this.txtOrderPerson.TabIndex = 6;
			this.txtOrderPerson.UseSelectable = true;
			// 
			// txtLocation
			// 
			this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocation.BackColor = System.Drawing.Color.White;
			this.txtLocation.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtLocation.Lines = new string[0];
			this.txtLocation.Location = new System.Drawing.Point(494, 3);
			this.txtLocation.MaxLength = 32767;
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.PasswordChar = '\0';
			this.txtLocation.ReadOnly = true;
			this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLocation.SelectedText = "";
			this.txtLocation.Size = new System.Drawing.Size(295, 29);
			this.txtLocation.TabIndex = 2;
			this.txtLocation.UseSelectable = true;
			// 
			// creUserLbl
			// 
			this.creUserLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.creUserLbl.AutoSize = true;
			this.creUserLbl.Location = new System.Drawing.Point(7, 113);
			this.creUserLbl.Margin = new System.Windows.Forms.Padding(3);
			this.creUserLbl.Name = "creUserLbl";
			this.creUserLbl.Size = new System.Drawing.Size(85, 20);
			this.creUserLbl.TabIndex = 21;
			this.creUserLbl.Text = "下  单 人：";
			// 
			// orderCodeLbl
			// 
			this.orderCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderCodeLbl.AutoSize = true;
			this.orderCodeLbl.Location = new System.Drawing.Point(3, 42);
			this.orderCodeLbl.Margin = new System.Windows.Forms.Padding(3);
			this.orderCodeLbl.Name = "orderCodeLbl";
			this.orderCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.orderCodeLbl.TabIndex = 8;
			this.orderCodeLbl.Text = "订单编号：";
			// 
			// txtOrderNum
			// 
			this.txtOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderNum.BackColor = System.Drawing.Color.White;
			this.txtOrderNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderNum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderNum.Lines = new string[0];
			this.txtOrderNum.Location = new System.Drawing.Point(98, 38);
			this.txtOrderNum.MaxLength = 32767;
			this.txtOrderNum.Name = "txtOrderNum";
			this.txtOrderNum.PasswordChar = '\0';
			this.txtOrderNum.ReadOnly = true;
			this.txtOrderNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderNum.SelectedText = "";
			this.txtOrderNum.Size = new System.Drawing.Size(295, 29);
			this.txtOrderNum.TabIndex = 3;
			this.txtOrderNum.UseSelectable = true;
			// 
			// orderNameLbl
			// 
			this.orderNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderNameLbl.AutoSize = true;
			this.orderNameLbl.Location = new System.Drawing.Point(399, 42);
			this.orderNameLbl.Margin = new System.Windows.Forms.Padding(3);
			this.orderNameLbl.Name = "orderNameLbl";
			this.orderNameLbl.Size = new System.Drawing.Size(89, 20);
			this.orderNameLbl.TabIndex = 18;
			this.orderNameLbl.Text = "订单名称：";
			// 
			// txtOrderType
			// 
			this.txtOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderType.BackColor = System.Drawing.Color.White;
			this.txtOrderType.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderType.Lines = new string[0];
			this.txtOrderType.Location = new System.Drawing.Point(98, 73);
			this.txtOrderType.MaxLength = 32767;
			this.txtOrderType.Name = "txtOrderType";
			this.txtOrderType.PasswordChar = '\0';
			this.txtOrderType.ReadOnly = true;
			this.txtOrderType.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderType.SelectedText = "";
			this.txtOrderType.Size = new System.Drawing.Size(295, 30);
			this.txtOrderType.TabIndex = 5;
			this.txtOrderType.UseSelectable = true;
			this.txtOrderType.Visible = false;
			// 
			// txtOrderName
			// 
			this.txtOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderName.BackColor = System.Drawing.Color.White;
			this.txtOrderName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderName.Lines = new string[0];
			this.txtOrderName.Location = new System.Drawing.Point(494, 38);
			this.txtOrderName.MaxLength = 32767;
			this.txtOrderName.Name = "txtOrderName";
			this.txtOrderName.PasswordChar = '\0';
			this.txtOrderName.ReadOnly = true;
			this.txtOrderName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderName.SelectedText = "";
			this.txtOrderName.Size = new System.Drawing.Size(295, 29);
			this.txtOrderName.TabIndex = 4;
			this.txtOrderName.UseSelectable = true;
			// 
			// orderTypeLbl
			// 
			this.orderTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderTypeLbl.AutoSize = true;
			this.orderTypeLbl.Location = new System.Drawing.Point(3, 78);
			this.orderTypeLbl.Margin = new System.Windows.Forms.Padding(3);
			this.orderTypeLbl.Name = "orderTypeLbl";
			this.orderTypeLbl.Size = new System.Drawing.Size(89, 20);
			this.orderTypeLbl.TabIndex = 7;
			this.orderTypeLbl.Text = "订单类型：";
			this.orderTypeLbl.Visible = false;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnSave, 0, 0);
			this.btnPanel.Controls.Add(this.btnImage, 0, 4);
			this.btnPanel.Controls.Add(this.btnPatient, 0, 3);
			this.btnPanel.Controls.Add(this.btnViewImage, 0, 2);
			this.btnPanel.Controls.Add(this.btnPrintBcu, 0, 1);
			this.btnPanel.Controls.Add(this.statisisInfoBtn, 0, 5);
			this.btnPanel.Controls.Add(this.btnClose, 0, 6);
			this.btnPanel.Location = new System.Drawing.Point(792, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 8;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
			this.btnPanel.Size = new System.Drawing.Size(133, 490);
			this.btnPanel.TabIndex = 25;
			// 
			// btnSave
			// 
			this.btnSave.ActiveControl = null;
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnSave.Location = new System.Drawing.Point(4, 4);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 40);
			this.btnSave.TabIndex = 21;
			this.btnSave.Text = "提          交 ";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.UseSelectable = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.OnbtnSave_Click);
			// 
			// btnImage
			// 
			this.btnImage.ActiveControl = null;
			this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnImage.Location = new System.Drawing.Point(3, 193);
			this.btnImage.Name = "btnImage";
			this.btnImage.Size = new System.Drawing.Size(127, 40);
			this.btnImage.TabIndex = 25;
			this.btnImage.Text = "订 单 图 片 ";
			this.btnImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImage.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImage.UseSelectable = true;
			this.btnImage.UseTileImage = true;
			this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
			// 
			// btnPatient
			// 
			this.btnPatient.ActiveControl = null;
			this.btnPatient.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPatient.Location = new System.Drawing.Point(4, 146);
			this.btnPatient.Margin = new System.Windows.Forms.Padding(4);
			this.btnPatient.Name = "btnPatient";
			this.btnPatient.Size = new System.Drawing.Size(125, 40);
			this.btnPatient.TabIndex = 24;
			this.btnPatient.Text = "病 人 信 息 ";
			this.btnPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPatient.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPatient.UseSelectable = true;
			this.btnPatient.UseTileImage = true;
			this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
			// 
			// btnViewImage
			// 
			this.btnViewImage.ActiveControl = null;
			this.btnViewImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnViewImage.Location = new System.Drawing.Point(3, 99);
			this.btnViewImage.Name = "btnViewImage";
			this.btnViewImage.Size = new System.Drawing.Size(127, 40);
			this.btnViewImage.TabIndex = 23;
			this.btnViewImage.Text = "查 看 图 片 ";
			this.btnViewImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnViewImage.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnViewImage.UseSelectable = true;
			this.btnViewImage.UseTileImage = true;
			this.btnViewImage.Click += new System.EventHandler(this.btnViewImage_Click);
			// 
			// btnPrintBcu
			// 
			this.btnPrintBcu.ActiveControl = null;
			this.btnPrintBcu.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPrintBcu.Location = new System.Drawing.Point(4, 52);
			this.btnPrintBcu.Margin = new System.Windows.Forms.Padding(4);
			this.btnPrintBcu.Name = "btnPrintBcu";
			this.btnPrintBcu.Size = new System.Drawing.Size(125, 40);
			this.btnPrintBcu.TabIndex = 22;
			this.btnPrintBcu.Text = "打 印 标 签 ";
			this.btnPrintBcu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrintBcu.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrintBcu.UseSelectable = true;
			this.btnPrintBcu.UseTileImage = true;
			this.btnPrintBcu.Click += new System.EventHandler(this.btnPrintBcu_Click);
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Location = new System.Drawing.Point(4, 288);
			this.btnClose.Margin = new System.Windows.Forms.Padding(4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(125, 40);
			this.btnClose.TabIndex = 26;
			this.btnClose.Text = "关          闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.OnbtnClose_Click);
			// 
			// statisisInfoBtn
			// 
			this.statisisInfoBtn.ActiveControl = null;
			this.statisisInfoBtn.Location = new System.Drawing.Point(4, 240);
			this.statisisInfoBtn.Margin = new System.Windows.Forms.Padding(4);
			this.statisisInfoBtn.Name = "statisisInfoBtn";
			this.statisisInfoBtn.Size = new System.Drawing.Size(125, 40);
			this.statisisInfoBtn.TabIndex = 27;
			this.statisisInfoBtn.Text = "不合格信息 ";
			this.statisisInfoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.statisisInfoBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statisisInfoBtn.UseSelectable = true;
			this.statisisInfoBtn.UseTileImage = true;
			this.statisisInfoBtn.Click += new System.EventHandler(this.statisisInfoBtn_Click);
			// 
			// HCS_packset_dealinstrument_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 570);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "HCS_packset_dealinstrument_detail";
			this.Text = "订单待处理";
			this.Load += new System.EventHandler(this.HCS_packset_dealinstrument_detail_Load);
			this.mainPanel.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Instrument)).EndInit();
			this.btnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private CnasMetroFramework.Controls.MetroTextBox txtCreTime;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderPerson;
		private System.Windows.Forms.Label creUserLbl;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderName;
		private System.Windows.Forms.Label orderNameLbl;
		private System.Windows.Forms.Label orderTypeLbl;
		private System.Windows.Forms.Label orderCodeLbl;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderType;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderNum;
		private System.Windows.Forms.Label customerLbl;
		private CnasMetroFramework.Controls.MetroTextBox txtCustmoer;
		private System.Windows.Forms.Label locationLbl;
		private CnasMetroFramework.Controls.MetroTextBox txtLocation;
		private System.Windows.Forms.DataGridView dgv_Instrument;
		private System.Windows.Forms.Label creTimeLbl;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private CnasMetroFramework.Controls.MetroTile btnSave;
		private CnasMetroFramework.Controls.MetroTile btnPrintBcu;
		private CnasMetroFramework.Controls.MetroTile btnPatient;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeTypeName;
		private System.Windows.Forms.DataGridViewTextBoxColumn instrument_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn codeType;
		private System.Windows.Forms.DataGridViewTextBoxColumn c_codeType;
		private System.Windows.Forms.DataGridViewTextBoxColumn num;
		private System.Windows.Forms.DataGridViewTextBoxColumn deal_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn now_deal_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn remark;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private CnasMetroFramework.Controls.MetroTile btnViewImage;
		private CnasMetroFramework.Controls.MetroTile btnImage;
		private CnasMetroFramework.Controls.MetroTile statisisInfoBtn;
	}
}