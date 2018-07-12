namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_manager
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.orderNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.cbbCust = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.btnSearch = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnViewSend = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPrint = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnViewOrder = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.orderGrid = new System.Windows.Forms.DataGridView();
			this.set_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cu_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.u_uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.handle_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wf_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wf_code_back = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbbLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbbOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.creEndTime = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.creStartTime = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.cbbOrderState = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtOrderCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderNameLbl = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.btnPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.orderNameTxt, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.cbbCust, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnPanel, 4, 4);
			this.tableLayoutPanel1.Controls.Add(this.orderGrid, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbbLocation, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbbOrderType, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.creEndTime, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.creStartTime, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.cbbOrderState, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderCode, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.orderNameLbl, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1058, 565);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// orderNameTxt
			// 
			this.orderNameTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.orderNameTxt.BackColor = System.Drawing.Color.White;
			this.orderNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.orderNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.orderNameTxt.Lines = new string[0];
			this.orderNameTxt.Location = new System.Drawing.Point(409, 75);
			this.orderNameTxt.MaxLength = 32767;
			this.orderNameTxt.Name = "orderNameTxt";
			this.orderNameTxt.PasswordChar = '\0';
			this.orderNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.orderNameTxt.SelectedText = "";
			this.orderNameTxt.Size = new System.Drawing.Size(200, 30);
			this.orderNameTxt.TabIndex = 6;
			this.orderNameTxt.UseCustomBackColor = true;
			this.orderNameTxt.UseSelectable = true;
			// 
			// cbbCust
			// 
			this.cbbCust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbCust.DisplayMember = "Value";
			this.cbbCust.FormattingEnabled = true;
			this.cbbCust.ItemHeight = 24;
			this.cbbCust.Location = new System.Drawing.Point(98, 3);
			this.cbbCust.Name = "cbbCust";
			this.cbbCust.Size = new System.Drawing.Size(200, 30);
			this.cbbCust.TabIndex = 1;
			this.cbbCust.UseSelectable = true;
			this.cbbCust.ValueMember = "Key";
			this.cbbCust.SelectedValueChanged += new System.EventHandler(this.cbbCust_SelectedValueChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.ActiveControl = null;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(945, 98);
			this.btnSearch.Name = "btnSearch";
			this.tableLayoutPanel1.SetRowSpan(this.btnSearch, 4);
			this.btnSearch.Size = new System.Drawing.Size(110, 40);
			this.btnSearch.TabIndex = 9;
			this.btnSearch.Text = "查    询 ";
			this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.UseSelectable = true;
			this.btnSearch.UseTileImage = true;
			this.btnSearch.Click += new System.EventHandler(this.OnbtnSearch_Click);
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnViewSend, 0, 2);
			this.btnPanel.Controls.Add(this.btnPrint, 0, 1);
			this.btnPanel.Controls.Add(this.btnViewOrder, 0, 0);
			this.btnPanel.Controls.Add(this.btnClose, 0, 3);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPanel.Location = new System.Drawing.Point(942, 141);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 5;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
			this.btnPanel.Size = new System.Drawing.Size(116, 424);
			this.btnPanel.TabIndex = 26;
			// 
			// btnViewSend
			// 
			this.btnViewSend.ActiveControl = null;
			this.btnViewSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnViewSend.Location = new System.Drawing.Point(3, 92);
			this.btnViewSend.Name = "btnViewSend";
			this.btnViewSend.Size = new System.Drawing.Size(110, 40);
			this.btnViewSend.TabIndex = 24;
			this.btnViewSend.Text = "发货单 ";
			this.btnViewSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnViewSend.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnViewSend.UseSelectable = true;
			this.btnViewSend.UseTileImage = true;
			this.btnViewSend.Click += new System.EventHandler(this.OnbtnViewSend_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.ActiveControl = null;
			this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPrint.Location = new System.Drawing.Point(3, 46);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(110, 40);
			this.btnPrint.TabIndex = 23;
			this.btnPrint.Text = "打    印 ";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.UseSelectable = true;
			this.btnPrint.UseTileImage = true;
			this.btnPrint.Click += new System.EventHandler(this.OnbtnPrint_Click);
			// 
			// btnViewOrder
			// 
			this.btnViewOrder.ActiveControl = null;
			this.btnViewOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnViewOrder.Location = new System.Drawing.Point(3, 0);
			this.btnViewOrder.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.btnViewOrder.Name = "btnViewOrder";
			this.btnViewOrder.Size = new System.Drawing.Size(110, 40);
			this.btnViewOrder.TabIndex = 22;
			this.btnViewOrder.Text = "查    看 ";
			this.btnViewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnViewOrder.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnViewOrder.UseSelectable = true;
			this.btnViewOrder.UseTileImage = true;
			this.btnViewOrder.Click += new System.EventHandler(this.OnbtnViewOrder_Click);
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClose.Location = new System.Drawing.Point(3, 138);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(110, 40);
			this.btnClose.TabIndex = 25;
			this.btnClose.Text = "关    闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// orderGrid
			// 
			this.orderGrid.AllowUserToAddRows = false;
			this.orderGrid.AllowUserToDeleteRows = false;
			this.orderGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.orderGrid.ColumnHeadersHeight = 28;
			this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.set_code,
            this.ca_name,
            this.cu_name,
            this.u_uname,
            this.order_type,
            this.handle_state,
            this.wf_code,
            this.wf_code_back,
            this.user_name,
            this.cre_date,
            this.batch});
			this.tableLayoutPanel1.SetColumnSpan(this.orderGrid, 4);
			this.orderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orderGrid.Location = new System.Drawing.Point(0, 141);
			this.orderGrid.Margin = new System.Windows.Forms.Padding(0);
			this.orderGrid.MultiSelect = false;
			this.orderGrid.Name = "orderGrid";
			this.orderGrid.ReadOnly = true;
			this.orderGrid.RowHeadersVisible = false;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.orderGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.orderGrid.RowTemplate.Height = 23;
			this.orderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.orderGrid.Size = new System.Drawing.Size(942, 424);
			this.orderGrid.TabIndex = 28;
			this.orderGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ondgv_OrderDetail_CellContentDoubleClick);
			// 
			// set_code
			// 
			this.set_code.HeaderText = "订单编号";
			this.set_code.Name = "set_code";
			this.set_code.ReadOnly = true;
			this.set_code.Width = 120;
			// 
			// ca_name
			// 
			this.ca_name.HeaderText = "订单名称";
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			this.ca_name.Width = 180;
			// 
			// cu_name
			// 
			this.cu_name.HeaderText = "客户名称";
			this.cu_name.MinimumWidth = 120;
			this.cu_name.Name = "cu_name";
			this.cu_name.ReadOnly = true;
			this.cu_name.Width = 150;
			// 
			// u_uname
			// 
			this.u_uname.HeaderText = "使用地点";
			this.u_uname.Name = "u_uname";
			this.u_uname.ReadOnly = true;
			this.u_uname.Width = 150;
			// 
			// order_type
			// 
			this.order_type.HeaderText = "订单类型";
			this.order_type.Name = "order_type";
			this.order_type.ReadOnly = true;
			this.order_type.Width = 150;
			// 
			// handle_state
			// 
			this.handle_state.HeaderText = "状态";
			this.handle_state.MinimumWidth = 50;
			this.handle_state.Name = "handle_state";
			this.handle_state.ReadOnly = true;
			this.handle_state.Width = 80;
			// 
			// wf_code
			// 
			this.wf_code.HeaderText = "流程";
			this.wf_code.Name = "wf_code";
			this.wf_code.ReadOnly = true;
			this.wf_code.Width = 250;
			// 
			// wf_code_back
			// 
			this.wf_code_back.HeaderText = "wf_code_back";
			this.wf_code_back.Name = "wf_code_back";
			this.wf_code_back.ReadOnly = true;
			this.wf_code_back.Visible = false;
			// 
			// user_name
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.user_name.DefaultCellStyle = dataGridViewCellStyle1;
			this.user_name.HeaderText = "创建人";
			this.user_name.Name = "user_name";
			this.user_name.ReadOnly = true;
			this.user_name.Width = 80;
			// 
			// cre_date
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle2;
			this.cre_date.HeaderText = "创建日期";
			this.cre_date.MinimumWidth = 150;
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 180;
			// 
			// batch
			// 
			this.batch.HeaderText = "批次";
			this.batch.Name = "batch";
			this.batch.ReadOnly = true;
			this.batch.Visible = false;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(3, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 33;
			this.label6.Text = "客户名称：";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(314, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 28;
			this.label1.Text = "使用地点：";
			// 
			// cbbLocation
			// 
			this.cbbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbLocation.DisplayMember = "Value";
			this.cbbLocation.FormattingEnabled = true;
			this.cbbLocation.ItemHeight = 24;
			this.cbbLocation.Location = new System.Drawing.Point(409, 3);
			this.cbbLocation.Name = "cbbLocation";
			this.cbbLocation.Size = new System.Drawing.Size(200, 30);
			this.cbbLocation.TabIndex = 2;
			this.cbbLocation.UseSelectable = true;
			this.cbbLocation.ValueMember = "Key";
			this.cbbLocation.SelectedValueChanged += new System.EventHandler(this.cbbLocation_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(3, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 29;
			this.label2.Text = "订单类型：";
			// 
			// cbbOrderType
			// 
			this.cbbOrderType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbOrderType.DisplayMember = "Value";
			this.cbbOrderType.FormattingEnabled = true;
			this.cbbOrderType.ItemHeight = 24;
			this.cbbOrderType.Location = new System.Drawing.Point(98, 39);
			this.cbbOrderType.Name = "cbbOrderType";
			this.cbbOrderType.Size = new System.Drawing.Size(200, 30);
			this.cbbOrderType.TabIndex = 3;
			this.cbbOrderType.UseSelectable = true;
			this.cbbOrderType.ValueMember = "Key";
			this.cbbOrderType.SelectedValueChanged += new System.EventHandler(this.cbbOrderType_SelectedValueChanged);
			// 
			// creEndTime
			// 
			this.creEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.creEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creEndTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.creEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creEndTime.Location = new System.Drawing.Point(409, 111);
			this.creEndTime.Name = "creEndTime";
			this.creEndTime.Size = new System.Drawing.Size(200, 27);
			this.creEndTime.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(314, 114);
			this.label3.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 20);
			this.label3.TabIndex = 30;
			this.label3.Text = "结束时间：";
			// 
			// creStartTime
			// 
			this.creStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.creStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creStartTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.creStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creStartTime.Location = new System.Drawing.Point(98, 111);
			this.creStartTime.Name = "creStartTime";
			this.creStartTime.Size = new System.Drawing.Size(200, 27);
			this.creStartTime.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(3, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 31;
			this.label4.Text = "开始时间：";
			// 
			// cbbOrderState
			// 
			this.cbbOrderState.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbOrderState.DisplayMember = "Value";
			this.cbbOrderState.FormattingEnabled = true;
			this.cbbOrderState.ItemHeight = 24;
			this.cbbOrderState.Location = new System.Drawing.Point(409, 39);
			this.cbbOrderState.Name = "cbbOrderState";
			this.cbbOrderState.Size = new System.Drawing.Size(200, 30);
			this.cbbOrderState.TabIndex = 4;
			this.cbbOrderState.UseSelectable = true;
			this.cbbOrderState.ValueMember = "Key";
			this.cbbOrderState.SelectedIndexChanged += new System.EventHandler(this.cbbOrderState_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(314, 44);
			this.label7.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 20);
			this.label7.TabIndex = 34;
			this.label7.Text = "状        态：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(3, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 32;
			this.label5.Text = "订单编号：";
			// 
			// txtOrderCode
			// 
			this.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderCode.BackColor = System.Drawing.Color.White;
			this.txtOrderCode.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderCode.Lines = new string[0];
			this.txtOrderCode.Location = new System.Drawing.Point(98, 75);
			this.txtOrderCode.MaxLength = 32767;
			this.txtOrderCode.Name = "txtOrderCode";
			this.txtOrderCode.PasswordChar = '\0';
			this.txtOrderCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderCode.SelectedText = "";
			this.txtOrderCode.Size = new System.Drawing.Size(200, 30);
			this.txtOrderCode.TabIndex = 5;
			this.txtOrderCode.UseCustomBackColor = true;
			this.txtOrderCode.UseSelectable = true;
			this.txtOrderCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderCode_KeyDown);
			// 
			// orderNameLbl
			// 
			this.orderNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderNameLbl.AutoSize = true;
			this.orderNameLbl.Location = new System.Drawing.Point(314, 80);
			this.orderNameLbl.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.orderNameLbl.Name = "orderNameLbl";
			this.orderNameLbl.Size = new System.Drawing.Size(89, 20);
			this.orderNameLbl.TabIndex = 43;
			this.orderNameLbl.Text = "订单名称：";
			// 
			// HCSSM_order_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1098, 645);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HCSSM_order_manager";
			this.Text = "订单查询";
			this.Load += new System.EventHandler(this.HCSSM_order_manager_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.btnPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private CnasMetroFramework.Controls.MetroComboBox cbbCust;
		private CnasMetroFramework.Controls.MetroComboBox cbbLocation;
		private CnasMetroFramework.Controls.MetroComboBox cbbOrderType;
		private System.Windows.Forms.DateTimePicker creStartTime;
		private System.Windows.Forms.DateTimePicker creEndTime;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private System.Windows.Forms.DataGridView orderGrid;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderCode;
		private CnasMetroFramework.Controls.MetroTile btnViewSend;
		private CnasMetroFramework.Controls.MetroTile btnPrint;
		private CnasMetroFramework.Controls.MetroTile btnViewOrder;
		private CnasMetroFramework.Controls.MetroTile btnSearch;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private CnasMetroFramework.Controls.MetroComboBox cbbOrderState;
		private CnasMetroFramework.Controls.MetroTextBox orderNameTxt;
		private System.Windows.Forms.Label orderNameLbl;
		private System.Windows.Forms.DataGridViewTextBoxColumn set_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn cu_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn u_uname;
		private System.Windows.Forms.DataGridViewTextBoxColumn order_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn handle_state;
		private System.Windows.Forms.DataGridViewTextBoxColumn wf_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn wf_code_back;
		private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn batch;
	}
}