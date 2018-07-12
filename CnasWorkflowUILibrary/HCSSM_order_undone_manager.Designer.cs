namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_undone_manager
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnSearch = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.cbbOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.txtOrderCode = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.cbbCust = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.creEndTime = new System.Windows.Forms.DateTimePicker();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnHandleOrder = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.dgv_OrderDetail = new System.Windows.Forms.DataGridView();
			this.set_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cu_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.u_uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.handle_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cbbLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.creStartTime = new System.Windows.Forms.DateTimePicker();
			this.tableLayoutPanel1.SuspendLayout();
			this.btnPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).BeginInit();
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
			this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbbOrderType, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderCode, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbbCust, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.creEndTime, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnPanel, 4, 3);
			this.tableLayoutPanel1.Controls.Add(this.dgv_OrderDetail, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.cbbLocation, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.creStartTime, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 60);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 558);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(322, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 20);
			this.label1.TabIndex = 37;
			this.label1.Text = "科      室：";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(314, 44);
			this.label2.Margin = new System.Windows.Forms.Padding(3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 36;
			this.label2.Text = "订单类型：";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(314, 78);
			this.label3.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
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
			this.label4.Location = new System.Drawing.Point(3, 78);
			this.label4.Margin = new System.Windows.Forms.Padding(3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 35;
			this.label4.Text = "开始时间：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(3, 44);
			this.label5.Margin = new System.Windows.Forms.Padding(3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 33;
			this.label5.Text = "订单编号：";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(3, 8);
			this.label6.Margin = new System.Windows.Forms.Padding(3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 34;
			this.label6.Text = "客户名称：";
			// 
			// btnSearch
			// 
			this.btnSearch.ActiveControl = null;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(899, 62);
			this.btnSearch.Name = "btnSearch";
			this.tableLayoutPanel1.SetRowSpan(this.btnSearch, 3);
			this.btnSearch.Size = new System.Drawing.Size(90, 40);
			this.btnSearch.TabIndex = 7;
			this.btnSearch.Text = "查 询 ";
			this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.UseSelectable = true;
			this.btnSearch.UseTileImage = true;
			this.btnSearch.Click += new System.EventHandler(this.OnbtnSearch_Click);
			// 
			// cbbOrderType
			// 
			this.cbbOrderType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbOrderType.DisplayMember = "Value";
			this.cbbOrderType.FormattingEnabled = true;
			this.cbbOrderType.ItemHeight = 24;
			this.cbbOrderType.Location = new System.Drawing.Point(409, 39);
			this.cbbOrderType.Name = "cbbOrderType";
			this.cbbOrderType.Size = new System.Drawing.Size(200, 30);
			this.cbbOrderType.TabIndex = 4;
			this.cbbOrderType.UseSelectable = true;
			this.cbbOrderType.ValueMember = "Key";
			this.cbbOrderType.SelectedValueChanged += new System.EventHandler(this.cbbOrderType_SelectedValueChanged);
			// 
			// txtOrderCode
			// 
			this.txtOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
			// creEndTime
			// 
			this.creEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.creEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creEndTime.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.creEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creEndTime.Location = new System.Drawing.Point(409, 75);
			this.creEndTime.Name = "creEndTime";
			this.creEndTime.Size = new System.Drawing.Size(200, 27);
			this.creEndTime.TabIndex = 6;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnHandleOrder, 0, 0);
			this.btnPanel.Controls.Add(this.btnClose, 0, 1);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(896, 105);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 4;
			this.tableLayoutPanel1.SetRowSpan(this.btnPanel, 2);
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.6087F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.6087F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.78261F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.btnPanel.Size = new System.Drawing.Size(96, 453);
			this.btnPanel.TabIndex = 26;
			// 
			// btnHandleOrder
			// 
			this.btnHandleOrder.ActiveControl = null;
			this.btnHandleOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnHandleOrder.Location = new System.Drawing.Point(3, 3);
			this.btnHandleOrder.Name = "btnHandleOrder";
			this.btnHandleOrder.Size = new System.Drawing.Size(90, 40);
			this.btnHandleOrder.TabIndex = 22;
			this.btnHandleOrder.Text = "处 理 ";
			this.btnHandleOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnHandleOrder.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnHandleOrder.UseSelectable = true;
			this.btnHandleOrder.UseTileImage = true;
			this.btnHandleOrder.Click += new System.EventHandler(this.OnbtnHandleOrder_Click);
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// dgv_OrderDetail
			// 
			this.dgv_OrderDetail.AllowUserToAddRows = false;
			this.dgv_OrderDetail.AllowUserToDeleteRows = false;
			this.dgv_OrderDetail.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_OrderDetail.ColumnHeadersHeight = 28;
			this.dgv_OrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.set_code,
            this.ca_name,
            this.order_type,
            this.cu_name,
            this.u_uname,
            this.handle_state,
            this.cre_date,
            this.user_name,
            this.batch});
			this.tableLayoutPanel1.SetColumnSpan(this.dgv_OrderDetail, 4);
			this.dgv_OrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_OrderDetail.Location = new System.Drawing.Point(3, 108);
			this.dgv_OrderDetail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dgv_OrderDetail.MultiSelect = false;
			this.dgv_OrderDetail.Name = "dgv_OrderDetail";
			this.dgv_OrderDetail.ReadOnly = true;
			this.dgv_OrderDetail.RowHeadersVisible = false;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv_OrderDetail.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.tableLayoutPanel1.SetRowSpan(this.dgv_OrderDetail, 2);
			this.dgv_OrderDetail.RowTemplate.Height = 23;
			this.dgv_OrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_OrderDetail.Size = new System.Drawing.Size(890, 450);
			this.dgv_OrderDetail.TabIndex = 28;
			this.dgv_OrderDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ondgv_OrderDetail_CellContentDoubleClick);
			// 
			// set_code
			// 
			this.set_code.FillWeight = 487.3096F;
			this.set_code.HeaderText = "订单编号";
			this.set_code.MinimumWidth = 100;
			this.set_code.Name = "set_code";
			this.set_code.ReadOnly = true;
			this.set_code.Width = 150;
			// 
			// ca_name
			// 
			this.ca_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ca_name.FillWeight = 44.67005F;
			this.ca_name.HeaderText = "订单名称";
			this.ca_name.MinimumWidth = 150;
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			// 
			// order_type
			// 
			this.order_type.FillWeight = 44.67005F;
			this.order_type.HeaderText = "订单类型";
			this.order_type.MinimumWidth = 100;
			this.order_type.Name = "order_type";
			this.order_type.ReadOnly = true;
			this.order_type.Width = 200;
			// 
			// cu_name
			// 
			this.cu_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.cu_name.FillWeight = 44.67005F;
			this.cu_name.HeaderText = "客户名称";
			this.cu_name.MinimumWidth = 120;
			this.cu_name.Name = "cu_name";
			this.cu_name.ReadOnly = true;
			// 
			// u_uname
			// 
			this.u_uname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.u_uname.FillWeight = 44.67005F;
			this.u_uname.HeaderText = "使用地点";
			this.u_uname.MinimumWidth = 120;
			this.u_uname.Name = "u_uname";
			this.u_uname.ReadOnly = true;
			// 
			// handle_state
			// 
			this.handle_state.FillWeight = 44.67005F;
			this.handle_state.HeaderText = "状态";
			this.handle_state.MinimumWidth = 100;
			this.handle_state.Name = "handle_state";
			this.handle_state.ReadOnly = true;
			// 
			// cre_date
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle1;
			this.cre_date.FillWeight = 44.67005F;
			this.cre_date.HeaderText = "创建日期";
			this.cre_date.MinimumWidth = 120;
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 180;
			// 
			// user_name
			// 
			this.user_name.FillWeight = 44.67005F;
			this.user_name.HeaderText = "创建人";
			this.user_name.MinimumWidth = 100;
			this.user_name.Name = "user_name";
			this.user_name.ReadOnly = true;
			// 
			// batch
			// 
			this.batch.HeaderText = "批次";
			this.batch.Name = "batch";
			this.batch.ReadOnly = true;
			this.batch.Visible = false;
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
			// creStartTime
			// 
			this.creStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.creStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creStartTime.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.creStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creStartTime.Location = new System.Drawing.Point(98, 75);
			this.creStartTime.Name = "creStartTime";
			this.creStartTime.Size = new System.Drawing.Size(200, 27);
			this.creStartTime.TabIndex = 5;
			// 
			// HCSSM_order_undone_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 639);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HCSSM_order_undone_manager";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 21);
			this.Text = "处理订单";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.HCSSM_order_manager_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.btnPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).EndInit();
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
		private System.Windows.Forms.DataGridView dgv_OrderDetail;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderCode;
		private CnasMetroFramework.Controls.MetroTile btnHandleOrder;
		private CnasMetroFramework.Controls.MetroTile btnSearch;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn set_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn order_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn cu_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn u_uname;
		private System.Windows.Forms.DataGridViewTextBoxColumn handle_state;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn batch;
	}
}