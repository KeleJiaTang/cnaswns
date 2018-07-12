namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_send_order_manager
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.orderNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.btnSearch = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.dgv_send_order = new System.Windows.Forms.DataGridView();
			this.send_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cu_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.u_uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fillCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.set_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.send_batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnView = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPrint = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.label3 = new System.Windows.Forms.Label();
			this.creStartTime = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.creEndTime = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBccCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.cbbCust = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbbLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOrderNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.sendOrderLbl = new System.Windows.Forms.Label();
			this.txtSendOrder = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_send_order)).BeginInit();
			this.btnPanel.SuspendLayout();
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
			this.tableLayoutPanel1.Controls.Add(this.orderNameTxt, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgv_send_order, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnPanel, 4, 4);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.creStartTime, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.creEndTime, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtBccCode, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.cbbCust, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbbLocation, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderNum, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.sendOrderLbl, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtSendOrder, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 551);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// orderNameTxt
			// 
			this.orderNameTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.orderNameTxt.BackColor = System.Drawing.Color.White;
			this.orderNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.orderNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.orderNameTxt.Lines = new string[0];
			this.orderNameTxt.Location = new System.Drawing.Point(449, 39);
			this.orderNameTxt.MaxLength = 32767;
			this.orderNameTxt.Name = "orderNameTxt";
			this.orderNameTxt.PasswordChar = '\0';
			this.orderNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.orderNameTxt.SelectedText = "";
			this.orderNameTxt.Size = new System.Drawing.Size(250, 30);
			this.orderNameTxt.TabIndex = 4;
			this.orderNameTxt.UseCustomBackColor = true;
			this.orderNameTxt.UseSelectable = true;
			// 
			// btnSearch
			// 
			this.btnSearch.ActiveControl = null;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(857, 98);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.btnSearch.Name = "btnSearch";
			this.tableLayoutPanel1.SetRowSpan(this.btnSearch, 4);
			this.btnSearch.Size = new System.Drawing.Size(90, 40);
			this.btnSearch.TabIndex = 9;
			this.btnSearch.Text = "查 询 ";
			this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.UseSelectable = true;
			this.btnSearch.UseTileImage = true;
			this.btnSearch.Click += new System.EventHandler(this.OnbtnSearch_Click);
			// 
			// dgv_send_order
			// 
			this.dgv_send_order.AllowUserToAddRows = false;
			this.dgv_send_order.AllowUserToDeleteRows = false;
			this.dgv_send_order.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_send_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_send_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.send_code,
            this.orderCodeCol,
            this.orderNameCol,
            this.cu_name,
            this.u_uname,
            this.fillCol,
            this.set_Count,
            this.cre_date,
            this.send_batch});
			this.tableLayoutPanel1.SetColumnSpan(this.dgv_send_order, 4);
			this.dgv_send_order.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_send_order.Location = new System.Drawing.Point(3, 144);
			this.dgv_send_order.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dgv_send_order.Name = "dgv_send_order";
			this.dgv_send_order.ReadOnly = true;
			this.dgv_send_order.RowHeadersVisible = false;
			this.dgv_send_order.RowTemplate.Height = 23;
			this.dgv_send_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_send_order.Size = new System.Drawing.Size(848, 407);
			this.dgv_send_order.TabIndex = 27;
			this.dgv_send_order.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_send_order_CellDoubleClick);
			// 
			// send_code
			// 
			this.send_code.FillWeight = 31.221F;
			this.send_code.HeaderText = "发货单号";
			this.send_code.Name = "send_code";
			this.send_code.ReadOnly = true;
			this.send_code.Width = 120;
			// 
			// orderCodeCol
			// 
			this.orderCodeCol.FillWeight = 340.5927F;
			this.orderCodeCol.HeaderText = "订单编号";
			this.orderCodeCol.MinimumWidth = 100;
			this.orderCodeCol.Name = "orderCodeCol";
			this.orderCodeCol.ReadOnly = true;
			this.orderCodeCol.Width = 120;
			// 
			// orderNameCol
			// 
			this.orderNameCol.FillWeight = 272.0812F;
			this.orderNameCol.HeaderText = "订单名称";
			this.orderNameCol.Name = "orderNameCol";
			this.orderNameCol.ReadOnly = true;
			this.orderNameCol.Width = 180;
			// 
			// cu_name
			// 
			this.cu_name.FillWeight = 31.221F;
			this.cu_name.HeaderText = "客户名称";
			this.cu_name.MinimumWidth = 120;
			this.cu_name.Name = "cu_name";
			this.cu_name.ReadOnly = true;
			this.cu_name.Width = 180;
			// 
			// u_uname
			// 
			this.u_uname.FillWeight = 31.221F;
			this.u_uname.HeaderText = "使用地点";
			this.u_uname.MinimumWidth = 120;
			this.u_uname.Name = "u_uname";
			this.u_uname.ReadOnly = true;
			this.u_uname.Width = 120;
			// 
			// fillCol
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fillCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.fillCol.FillWeight = 31.221F;
			this.fillCol.HeaderText = "填写数量";
			this.fillCol.MinimumWidth = 80;
			this.fillCol.Name = "fillCol";
			this.fillCol.ReadOnly = true;
			// 
			// set_Count
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.set_Count.DefaultCellStyle = dataGridViewCellStyle2;
			this.set_Count.FillWeight = 31.221F;
			this.set_Count.HeaderText = "扫描包数量";
			this.set_Count.MinimumWidth = 100;
			this.set_Count.Name = "set_Count";
			this.set_Count.ReadOnly = true;
			this.set_Count.Width = 120;
			// 
			// cre_date
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm";
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle3;
			this.cre_date.FillWeight = 31.221F;
			this.cre_date.HeaderText = "发放时间";
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 150;
			// 
			// send_batch
			// 
			this.send_batch.HeaderText = "发货批次";
			this.send_batch.Name = "send_batch";
			this.send_batch.ReadOnly = true;
			this.send_batch.Visible = false;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnView, 0, 0);
			this.btnPanel.Controls.Add(this.btnPrint, 0, 1);
			this.btnPanel.Controls.Add(this.btnClose, 0, 2);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(854, 141);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 4;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Size = new System.Drawing.Size(96, 410);
			this.btnPanel.TabIndex = 28;
			// 
			// btnView
			// 
			this.btnView.ActiveControl = null;
			this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnView.Location = new System.Drawing.Point(3, 3);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(90, 40);
			this.btnView.TabIndex = 22;
			this.btnView.Text = "查 看 ";
			this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnView.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnView.UseSelectable = true;
			this.btnView.UseTileImage = true;
			this.btnView.Click += new System.EventHandler(this.OnbtnView_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.ActiveControl = null;
			this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPrint.Location = new System.Drawing.Point(3, 49);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(90, 40);
			this.btnPrint.TabIndex = 23;
			this.btnPrint.Text = "打 印 ";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.UseSelectable = true;
			this.btnPrint.UseTileImage = true;
			this.btnPrint.Visible = false;
			this.btnPrint.Click += new System.EventHandler(this.OnbtnPrint_Click);
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClose.Location = new System.Drawing.Point(3, 95);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 24;
			this.btnClose.Text = "关 闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 114);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 20);
			this.label3.TabIndex = 33;
			this.label3.Text = "开始时间：";
			// 
			// creStartTime
			// 
			this.creStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.creStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creStartTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.creStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creStartTime.Location = new System.Drawing.Point(98, 111);
			this.creStartTime.Name = "creStartTime";
			this.creStartTime.Size = new System.Drawing.Size(250, 27);
			this.creStartTime.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(354, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 34;
			this.label4.Text = "结束时间：";
			// 
			// creEndTime
			// 
			this.creEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.creEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creEndTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.creEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creEndTime.Location = new System.Drawing.Point(449, 111);
			this.creEndTime.Name = "creEndTime";
			this.creEndTime.Size = new System.Drawing.Size(250, 27);
			this.creEndTime.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(354, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 32;
			this.label2.Text = "条        码：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 35;
			this.label5.Text = "客户名称：";
			// 
			// txtBccCode
			// 
			this.txtBccCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtBccCode.BackColor = System.Drawing.Color.White;
			this.txtBccCode.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtBccCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtBccCode.Lines = new string[0];
			this.txtBccCode.Location = new System.Drawing.Point(449, 75);
			this.txtBccCode.MaxLength = 32767;
			this.txtBccCode.Name = "txtBccCode";
			this.txtBccCode.PasswordChar = '\0';
			this.txtBccCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtBccCode.SelectedText = "";
			this.txtBccCode.Size = new System.Drawing.Size(250, 30);
			this.txtBccCode.TabIndex = 6;
			this.txtBccCode.UseCustomBackColor = true;
			this.txtBccCode.UseSelectable = true;
			this.txtBccCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBccCode_KeyDown);
			// 
			// cbbCust
			// 
			this.cbbCust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbCust.DisplayMember = "Value";
			this.cbbCust.FormattingEnabled = true;
			this.cbbCust.ItemHeight = 24;
			this.cbbCust.Location = new System.Drawing.Point(98, 3);
			this.cbbCust.Name = "cbbCust";
			this.cbbCust.Size = new System.Drawing.Size(250, 30);
			this.cbbCust.TabIndex = 1;
			this.cbbCust.UseSelectable = true;
			this.cbbCust.ValueMember = "Key";
			this.cbbCust.SelectedIndexChanged += new System.EventHandler(this.cbbCust_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(354, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 36;
			this.label6.Text = "科        室：";
			// 
			// cbbLocation
			// 
			this.cbbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbLocation.DisplayMember = "Value";
			this.cbbLocation.FormattingEnabled = true;
			this.cbbLocation.ItemHeight = 24;
			this.cbbLocation.Location = new System.Drawing.Point(449, 3);
			this.cbbLocation.Name = "cbbLocation";
			this.cbbLocation.Size = new System.Drawing.Size(250, 30);
			this.cbbLocation.TabIndex = 2;
			this.cbbLocation.UseSelectable = true;
			this.cbbLocation.ValueMember = "Key";
			this.cbbLocation.SelectedIndexChanged += new System.EventHandler(this.cbbLocation_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 31;
			this.label1.Text = "订单编号：";
			// 
			// txtOrderNum
			// 
			this.txtOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrderNum.BackColor = System.Drawing.Color.White;
			this.txtOrderNum.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderNum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderNum.Lines = new string[0];
			this.txtOrderNum.Location = new System.Drawing.Point(98, 39);
			this.txtOrderNum.MaxLength = 32767;
			this.txtOrderNum.Name = "txtOrderNum";
			this.txtOrderNum.PasswordChar = '\0';
			this.txtOrderNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderNum.SelectedText = "";
			this.txtOrderNum.Size = new System.Drawing.Size(250, 30);
			this.txtOrderNum.TabIndex = 3;
			this.txtOrderNum.UseCustomBackColor = true;
			this.txtOrderNum.UseSelectable = true;
			this.txtOrderNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNum_KeyDown);
			// 
			// sendOrderLbl
			// 
			this.sendOrderLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.sendOrderLbl.AutoSize = true;
			this.sendOrderLbl.Location = new System.Drawing.Point(3, 80);
			this.sendOrderLbl.Name = "sendOrderLbl";
			this.sendOrderLbl.Size = new System.Drawing.Size(89, 20);
			this.sendOrderLbl.TabIndex = 30;
			this.sendOrderLbl.Text = "发货单号：";
			// 
			// txtSendOrder
			// 
			this.txtSendOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtSendOrder.BackColor = System.Drawing.Color.White;
			this.txtSendOrder.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtSendOrder.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtSendOrder.Lines = new string[0];
			this.txtSendOrder.Location = new System.Drawing.Point(98, 75);
			this.txtSendOrder.MaxLength = 32767;
			this.txtSendOrder.Name = "txtSendOrder";
			this.txtSendOrder.PasswordChar = '\0';
			this.txtSendOrder.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSendOrder.SelectedText = "";
			this.txtSendOrder.Size = new System.Drawing.Size(250, 30);
			this.txtSendOrder.TabIndex = 5;
			this.txtSendOrder.UseCustomBackColor = true;
			this.txtSendOrder.UseSelectable = true;
			this.txtSendOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendOrder_KeyDown);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(354, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 20);
			this.label7.TabIndex = 39;
			this.label7.Text = "订单名称：";
			// 
			// HCSSM_send_order_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 631);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HCSSM_send_order_manager";
			this.Text = "发货单查询";
			this.Load += new System.EventHandler(this.HCSSM_send_order_manager_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_send_order)).EndInit();
			this.btnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private CnasMetroFramework.Controls.MetroTextBox txtSendOrder;
		private CnasMetroFramework.Controls.MetroTextBox txtBccCode;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderNum;
		private System.Windows.Forms.DateTimePicker creStartTime;
		private System.Windows.Forms.DateTimePicker creEndTime;
		private System.Windows.Forms.DataGridView dgv_send_order;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile btnView;
		private CnasMetroFramework.Controls.MetroTile btnPrint;
		private CnasMetroFramework.Controls.MetroTile btnSearch;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.Label sendOrderLbl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private CnasMetroFramework.Controls.MetroComboBox cbbCust;
		private CnasMetroFramework.Controls.MetroComboBox cbbLocation;
		private CnasMetroFramework.Controls.MetroTextBox orderNameTxt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn cu_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn u_uname;
		private System.Windows.Forms.DataGridViewTextBoxColumn fillCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn set_Count;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_batch;

	}
}