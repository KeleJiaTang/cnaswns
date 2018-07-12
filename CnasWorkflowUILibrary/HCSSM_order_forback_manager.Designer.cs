namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_forback_manager
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.orderNameLbl = new System.Windows.Forms.TableLayoutPanel();
			this.orderNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnSearch = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.cbbCust = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.dgv_OrderDetail = new System.Windows.Forms.DataGridView();
			this.cu_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.u_uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.set_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.handle_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wf_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wf_code_back = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isToPackOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgv_Do = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toPackArea_Out = new System.Windows.Forms.ToolStripMenuItem();
			this.useArea_Out = new System.Windows.Forms.ToolStripMenuItem();
			this.packArea_Out = new System.Windows.Forms.ToolStripMenuItem();
			this.printBackOrder = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.cbbLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.creEndTime = new System.Windows.Forms.DateTimePicker();
			this.creStartTime = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTempCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.cbbOrderState = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtOrderCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.orderNameLbl.SuspendLayout();
			this.btnPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).BeginInit();
			this.dgv_Do.SuspendLayout();
			this.SuspendLayout();
			// 
			// orderNameLbl
			// 
			this.orderNameLbl.ColumnCount = 5;
			this.orderNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.orderNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderNameLbl.Controls.Add(this.orderNameTxt, 3, 1);
			this.orderNameLbl.Controls.Add(this.label6, 0, 0);
			this.orderNameLbl.Controls.Add(this.btnSearch, 4, 0);
			this.orderNameLbl.Controls.Add(this.cbbCust, 1, 0);
			this.orderNameLbl.Controls.Add(this.btnPanel, 4, 4);
			this.orderNameLbl.Controls.Add(this.dgv_OrderDetail, 0, 4);
			this.orderNameLbl.Controls.Add(this.label1, 2, 0);
			this.orderNameLbl.Controls.Add(this.cbbLocation, 3, 0);
			this.orderNameLbl.Controls.Add(this.creEndTime, 3, 3);
			this.orderNameLbl.Controls.Add(this.creStartTime, 1, 3);
			this.orderNameLbl.Controls.Add(this.label3, 2, 3);
			this.orderNameLbl.Controls.Add(this.label4, 0, 3);
			this.orderNameLbl.Controls.Add(this.label2, 0, 2);
			this.orderNameLbl.Controls.Add(this.txtTempCode, 1, 2);
			this.orderNameLbl.Controls.Add(this.cbbOrderState, 3, 2);
			this.orderNameLbl.Controls.Add(this.label7, 2, 2);
			this.orderNameLbl.Controls.Add(this.label5, 0, 1);
			this.orderNameLbl.Controls.Add(this.txtOrderCode, 1, 1);
			this.orderNameLbl.Controls.Add(this.label8, 2, 1);
			this.orderNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orderNameLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.orderNameLbl.Location = new System.Drawing.Point(21, 60);
			this.orderNameLbl.Name = "orderNameLbl";
			this.orderNameLbl.RowCount = 5;
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.orderNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.orderNameLbl.Size = new System.Drawing.Size(992, 558);
			this.orderNameLbl.TabIndex = 0;
			// 
			// orderNameTxt
			// 
			this.orderNameTxt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.orderNameTxt.BackColor = System.Drawing.Color.White;
			this.orderNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.orderNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.orderNameTxt.Lines = new string[0];
			this.orderNameTxt.Location = new System.Drawing.Point(409, 39);
			this.orderNameTxt.MaxLength = 32767;
			this.orderNameTxt.Name = "orderNameTxt";
			this.orderNameTxt.PasswordChar = '\0';
			this.orderNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.orderNameTxt.SelectedText = "";
			this.orderNameTxt.Size = new System.Drawing.Size(200, 30);
			this.orderNameTxt.TabIndex = 4;
			this.orderNameTxt.UseCustomBackColor = true;
			this.orderNameTxt.UseSelectable = true;
			this.orderNameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderCode_KeyDown);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(3, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 34;
			this.label6.Text = "客户名称：";
			// 
			// btnSearch
			// 
			this.btnSearch.ActiveControl = null;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(899, 98);
			this.btnSearch.Name = "btnSearch";
			this.orderNameLbl.SetRowSpan(this.btnSearch, 4);
			this.btnSearch.Size = new System.Drawing.Size(90, 40);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "查 询 ";
			this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.UseSelectable = true;
			this.btnSearch.UseTileImage = true;
			this.btnSearch.Click += new System.EventHandler(this.OnbtnSearch_Click);
			// 
			// cbbCust
			// 
			this.cbbCust.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnClose, 0, 0);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(896, 141);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 1;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Size = new System.Drawing.Size(96, 417);
			this.btnPanel.TabIndex = 26;
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Location = new System.Drawing.Point(3, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 22;
			this.btnClose.Text = "关 闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// dgv_OrderDetail
			// 
			this.dgv_OrderDetail.AllowUserToAddRows = false;
			this.dgv_OrderDetail.AllowUserToDeleteRows = false;
			this.dgv_OrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_OrderDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dgv_OrderDetail.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_OrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_OrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cu_name,
            this.u_uname,
            this.order_type,
            this.set_code,
            this.ca_name,
            this.handle_state,
            this.wf_code,
            this.user_name,
            this.cre_date,
            this.batch,
            this.wf_code_back,
            this.isToPackOut});
			this.orderNameLbl.SetColumnSpan(this.dgv_OrderDetail, 4);
			this.dgv_OrderDetail.ContextMenuStrip = this.dgv_Do;
			this.dgv_OrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_OrderDetail.Location = new System.Drawing.Point(0, 141);
			this.dgv_OrderDetail.Margin = new System.Windows.Forms.Padding(0);
			this.dgv_OrderDetail.MultiSelect = false;
			this.dgv_OrderDetail.Name = "dgv_OrderDetail";
			this.dgv_OrderDetail.ReadOnly = true;
			this.dgv_OrderDetail.RowHeadersVisible = false;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv_OrderDetail.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv_OrderDetail.RowTemplate.Height = 23;
			this.dgv_OrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_OrderDetail.Size = new System.Drawing.Size(896, 417);
			this.dgv_OrderDetail.TabIndex = 9;
			// 
			// cu_name
			// 
			this.cu_name.HeaderText = "客户名称";
			this.cu_name.Name = "cu_name";
			this.cu_name.ReadOnly = true;
			// 
			// u_uname
			// 
			this.u_uname.HeaderText = "使用地点";
			this.u_uname.Name = "u_uname";
			this.u_uname.ReadOnly = true;
			// 
			// order_type
			// 
			this.order_type.HeaderText = "订单类型";
			this.order_type.Name = "order_type";
			this.order_type.ReadOnly = true;
			this.order_type.Visible = false;
			// 
			// set_code
			// 
			this.set_code.HeaderText = "订单编号";
			this.set_code.Name = "set_code";
			this.set_code.ReadOnly = true;
			// 
			// ca_name
			// 
			this.ca_name.HeaderText = "订单名称";
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			// 
			// handle_state
			// 
			this.handle_state.HeaderText = "状态";
			this.handle_state.Name = "handle_state";
			this.handle_state.ReadOnly = true;
			// 
			// wf_code
			// 
			this.wf_code.HeaderText = "流程";
			this.wf_code.Name = "wf_code";
			this.wf_code.ReadOnly = true;
			// 
			// user_name
			// 
			this.user_name.HeaderText = "创建人";
			this.user_name.Name = "user_name";
			this.user_name.ReadOnly = true;
			// 
			// cre_date
			// 
			this.cre_date.HeaderText = "创建日期";
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			// 
			// batch
			// 
			this.batch.HeaderText = "批次";
			this.batch.Name = "batch";
			this.batch.ReadOnly = true;
			this.batch.Visible = false;
			// 
			// wf_code_back
			// 
			this.wf_code_back.HeaderText = "wf_code";
			this.wf_code_back.Name = "wf_code_back";
			this.wf_code_back.ReadOnly = true;
			this.wf_code_back.Visible = false;
			// 
			// isToPackOut
			// 
			this.isToPackOut.HeaderText = "是否转打包区出院";
			this.isToPackOut.Name = "isToPackOut";
			this.isToPackOut.ReadOnly = true;
			this.isToPackOut.Visible = false;
			// 
			// dgv_Do
			// 
			this.dgv_Do.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_Do.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toPackArea_Out,
            this.useArea_Out,
            this.packArea_Out,
            this.printBackOrder});
			this.dgv_Do.Name = "dgv_Do";
			this.dgv_Do.Size = new System.Drawing.Size(159, 100);
			this.dgv_Do.Opening += new System.ComponentModel.CancelEventHandler(this.dgv_Do_Opening);
			// 
			// toPackArea_Out
			// 
			this.toPackArea_Out.Name = "toPackArea_Out";
			this.toPackArea_Out.Size = new System.Drawing.Size(158, 24);
			this.toPackArea_Out.Text = "再次清洗";
			this.toPackArea_Out.Click += new System.EventHandler(this.toPackArea_Out_Click);
			// 
			// useArea_Out
			// 
			this.useArea_Out.Name = "useArea_Out";
			this.useArea_Out.Size = new System.Drawing.Size(158, 24);
			this.useArea_Out.Text = "出院";
			this.useArea_Out.Click += new System.EventHandler(this.useArea_Out_Click);
			// 
			// packArea_Out
			// 
			this.packArea_Out.Name = "packArea_Out";
			this.packArea_Out.Size = new System.Drawing.Size(158, 24);
			this.packArea_Out.Text = "出院";
			this.packArea_Out.Click += new System.EventHandler(this.packArea_Out_Click);
			// 
			// printBackOrder
			// 
			this.printBackOrder.Name = "printBackOrder";
			this.printBackOrder.Size = new System.Drawing.Size(158, 24);
			this.printBackOrder.Text = "打印签收单";
			this.printBackOrder.Click += new System.EventHandler(this.printBackOrder_Click);
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
			this.label1.TabIndex = 37;
			this.label1.Text = "科        室：";
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
			// creEndTime
			// 
			this.creEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.creEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creEndTime.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.creEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creEndTime.Location = new System.Drawing.Point(409, 111);
			this.creEndTime.Name = "creEndTime";
			this.creEndTime.Size = new System.Drawing.Size(200, 27);
			this.creEndTime.TabIndex = 8;
			// 
			// creStartTime
			// 
			this.creStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.creStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creStartTime.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.creStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creStartTime.Location = new System.Drawing.Point(98, 111);
			this.creStartTime.Name = "creStartTime";
			this.creStartTime.Size = new System.Drawing.Size(200, 27);
			this.creStartTime.TabIndex = 7;
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
			this.label3.TabIndex = 31;
			this.label3.Text = "结束时间：";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(3, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 35;
			this.label4.Text = "开始时间：";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 38;
			this.label2.Text = "铁牌编号：";
			// 
			// txtTempCode
			// 
			this.txtTempCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtTempCode.BackColor = System.Drawing.SystemColors.Window;
			this.txtTempCode.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtTempCode.Lines = new string[0];
			this.txtTempCode.Location = new System.Drawing.Point(98, 75);
			this.txtTempCode.MaxLength = 32767;
			this.txtTempCode.Name = "txtTempCode";
			this.txtTempCode.PasswordChar = '\0';
			this.txtTempCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTempCode.SelectedText = "";
			this.txtTempCode.Size = new System.Drawing.Size(200, 30);
			this.txtTempCode.TabIndex = 5;
			this.txtTempCode.UseCustomBackColor = true;
			this.txtTempCode.UseSelectable = true;
			this.txtTempCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempCode_KeyDown);
			// 
			// cbbOrderState
			// 
			this.cbbOrderState.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbOrderState.DisplayMember = "Value";
			this.cbbOrderState.FormattingEnabled = true;
			this.cbbOrderState.ItemHeight = 24;
			this.cbbOrderState.Location = new System.Drawing.Point(409, 75);
			this.cbbOrderState.Name = "cbbOrderState";
			this.cbbOrderState.Size = new System.Drawing.Size(200, 30);
			this.cbbOrderState.TabIndex = 6;
			this.cbbOrderState.UseSelectable = true;
			this.cbbOrderState.ValueMember = "Key";
			this.cbbOrderState.SelectedIndexChanged += new System.EventHandler(this.cbbOrderState_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(314, 80);
			this.label7.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 20);
			this.label7.TabIndex = 40;
			this.label7.Text = "状        态：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(3, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 33;
			this.label5.Text = "订单编号：";
			// 
			// txtOrderCode
			// 
			this.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderCode.BackColor = System.Drawing.Color.White;
			this.txtOrderCode.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderCode.Lines = new string[0];
			this.txtOrderCode.Location = new System.Drawing.Point(98, 39);
			this.txtOrderCode.MaxLength = 32767;
			this.txtOrderCode.Name = "txtOrderCode";
			this.txtOrderCode.PasswordChar = '\0';
			this.txtOrderCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderCode.SelectedText = "";
			this.txtOrderCode.Size = new System.Drawing.Size(200, 30);
			this.txtOrderCode.TabIndex = 3;
			this.txtOrderCode.UseCustomBackColor = true;
			this.txtOrderCode.UseSelectable = true;
			this.txtOrderCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderCode_KeyDown);
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(314, 44);
			this.label8.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 20);
			this.label8.TabIndex = 42;
			this.label8.Text = "订单名称：";
			// 
			// HCSSM_order_forback_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 639);
			this.Controls.Add(this.orderNameLbl);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HCSSM_order_forback_manager";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 21);
			this.Text = "院外器械出院管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.HCSSM_order_manager_Load);
			this.orderNameLbl.ResumeLayout(false);
			this.orderNameLbl.PerformLayout();
			this.btnPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).EndInit();
			this.dgv_Do.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel orderNameLbl;
		private CnasMetroFramework.Controls.MetroComboBox cbbCust;
		private CnasMetroFramework.Controls.MetroComboBox cbbLocation;
		private System.Windows.Forms.DateTimePicker creStartTime;
		private System.Windows.Forms.DateTimePicker creEndTime;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private System.Windows.Forms.DataGridView dgv_OrderDetail;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderCode;
		private CnasMetroFramework.Controls.MetroTile btnSearch;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private CnasMetroFramework.Controls.MetroTextBox txtTempCode;
		private System.Windows.Forms.ContextMenuStrip dgv_Do;
		private System.Windows.Forms.ToolStripMenuItem useArea_Out;
		private System.Windows.Forms.ToolStripMenuItem toPackArea_Out;
		private System.Windows.Forms.ToolStripMenuItem packArea_Out;
		private System.Windows.Forms.ToolStripMenuItem printBackOrder;
		private System.Windows.Forms.Label label7;
		private CnasMetroFramework.Controls.MetroComboBox cbbOrderState;
		private System.Windows.Forms.DataGridViewTextBoxColumn cu_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn u_uname;
		private System.Windows.Forms.DataGridViewTextBoxColumn order_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn set_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn handle_state;
		private System.Windows.Forms.DataGridViewTextBoxColumn wf_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn batch;
		private System.Windows.Forms.DataGridViewTextBoxColumn wf_code_back;
		private System.Windows.Forms.DataGridViewTextBoxColumn isToPackOut;
		private System.Windows.Forms.Label label8;
		private CnasMetroFramework.Controls.MetroTextBox orderNameTxt;
	}
}