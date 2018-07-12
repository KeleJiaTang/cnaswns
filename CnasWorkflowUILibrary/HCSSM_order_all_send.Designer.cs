namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_all_send
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgv_send_order = new System.Windows.Forms.DataGridView();
			this.send_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fillCountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setCountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.send_batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.metroLabel1 = new System.Windows.Forms.Label();
			this.cbbCreDate = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.metroLabel3 = new System.Windows.Forms.Label();
			this.txtOrderName = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel5 = new System.Windows.Forms.Label();
			this.txtOrderType = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel6 = new System.Windows.Forms.Label();
			this.cbbBatchCode = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.txtOrderNum = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new System.Windows.Forms.Label();
			this.metroLabel7 = new System.Windows.Forms.Label();
			this.metroLabel4 = new System.Windows.Forms.Label();
			this.txtCustmoer = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.txtLocation = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPrintSend = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnView = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_send_order)).BeginInit();
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
			this.mainPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.mainPanel.Controls.Add(this.btnPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(15, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(699, 501);
			this.mainPanel.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cbbCreDate, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.dgv_send_order, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderName, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderType, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel6, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbbBatchCode, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtOrderNum, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtCustmoer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtLocation, 3, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 501);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// dgv_send_order
			// 
			this.dgv_send_order.AllowUserToAddRows = false;
			this.dgv_send_order.AllowUserToDeleteRows = false;
			this.dgv_send_order.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_send_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_send_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.send_code,
            this.fillCountCol,
            this.setCountCol,
            this.cre_date,
            this.send_batch});
			this.tableLayoutPanel1.SetColumnSpan(this.dgv_send_order, 4);
			this.dgv_send_order.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_send_order.Location = new System.Drawing.Point(0, 144);
			this.dgv_send_order.Margin = new System.Windows.Forms.Padding(0);
			this.dgv_send_order.Name = "dgv_send_order";
			this.dgv_send_order.ReadOnly = true;
			this.dgv_send_order.RowHeadersVisible = false;
			this.dgv_send_order.RowTemplate.Height = 23;
			this.dgv_send_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_send_order.Size = new System.Drawing.Size(603, 357);
			this.dgv_send_order.TabIndex = 8;
			this.dgv_send_order.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ondgv_send_order_CellDoubleClick);
			// 
			// send_code
			// 
			this.send_code.HeaderText = "发货单号";
			this.send_code.Name = "send_code";
			this.send_code.ReadOnly = true;
			this.send_code.Width = 120;
			// 
			// fillCountCol
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fillCountCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.fillCountCol.HeaderText = "填写数量";
			this.fillCountCol.Name = "fillCountCol";
			this.fillCountCol.ReadOnly = true;
			this.fillCountCol.Width = 150;
			// 
			// setCountCol
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.setCountCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.setCountCol.HeaderText = "扫描包数量";
			this.setCountCol.Name = "setCountCol";
			this.setCountCol.ReadOnly = true;
			this.setCountCol.Width = 150;
			// 
			// cre_date
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle9.Format = "yyyy-MM-dd HH:mm";
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle9;
			this.cre_date.HeaderText = "发放时间";
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 180;
			// 
			// send_batch
			// 
			this.send_batch.HeaderText = "发货批次";
			this.send_batch.Name = "send_batch";
			this.send_batch.ReadOnly = true;
			this.send_batch.Visible = false;
			// 
			// metroLabel1
			// 
			this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(3, 80);
			this.metroLabel1.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(89, 20);
			this.metroLabel1.TabIndex = 8;
			this.metroLabel1.Text = "订单类型：";
			this.metroLabel1.Visible = false;
			// 
			// cbbCreDate
			// 
			this.cbbCreDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbCreDate.FormattingEnabled = true;
			this.cbbCreDate.ItemHeight = 24;
			this.cbbCreDate.Location = new System.Drawing.Point(98, 111);
			this.cbbCreDate.Name = "cbbCreDate";
			this.cbbCreDate.Size = new System.Drawing.Size(194, 30);
			this.cbbCreDate.TabIndex = 6;
			this.cbbCreDate.UseSelectable = true;
			this.cbbCreDate.Visible = false;
			this.cbbCreDate.SelectedValueChanged += new System.EventHandler(this.cbbCreDate_SelectedValueChanged);
			// 
			// metroLabel3
			// 
			this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(3, 116);
			this.metroLabel3.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(89, 20);
			this.metroLabel3.TabIndex = 26;
			this.metroLabel3.Text = "创建时间：";
			this.metroLabel3.Visible = false;
			// 
			// txtOrderName
			// 
			this.txtOrderName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderName.BackColor = System.Drawing.Color.White;
			this.txtOrderName.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderName.Lines = new string[0];
			this.txtOrderName.Location = new System.Drawing.Point(405, 39);
			this.txtOrderName.MaxLength = 32767;
			this.txtOrderName.Name = "txtOrderName";
			this.txtOrderName.PasswordChar = '\0';
			this.txtOrderName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderName.SelectedText = "";
			this.txtOrderName.Size = new System.Drawing.Size(195, 30);
			this.txtOrderName.TabIndex = 4;
			this.txtOrderName.UseSelectable = true;
			// 
			// metroLabel5
			// 
			this.metroLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(298, 8);
			this.metroLabel5.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(101, 20);
			this.metroLabel5.TabIndex = 24;
			this.metroLabel5.Text = "科           室：";
			// 
			// txtOrderType
			// 
			this.txtOrderType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderType.BackColor = System.Drawing.Color.White;
			this.txtOrderType.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtOrderType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtOrderType.Lines = new string[0];
			this.txtOrderType.Location = new System.Drawing.Point(98, 75);
			this.txtOrderType.MaxLength = 32767;
			this.txtOrderType.Name = "txtOrderType";
			this.txtOrderType.PasswordChar = '\0';
			this.txtOrderType.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOrderType.SelectedText = "";
			this.txtOrderType.Size = new System.Drawing.Size(194, 30);
			this.txtOrderType.TabIndex = 5;
			this.txtOrderType.UseSelectable = true;
			this.txtOrderType.Visible = false;
			// 
			// metroLabel6
			// 
			this.metroLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.Location = new System.Drawing.Point(298, 44);
			this.metroLabel6.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(101, 20);
			this.metroLabel6.TabIndex = 21;
			this.metroLabel6.Text = "订 单 名 称：";
			// 
			// cbbBatchCode
			// 
			this.cbbBatchCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbbBatchCode.FormattingEnabled = true;
			this.cbbBatchCode.ItemHeight = 24;
			this.cbbBatchCode.Location = new System.Drawing.Point(405, 111);
			this.cbbBatchCode.Name = "cbbBatchCode";
			this.cbbBatchCode.Size = new System.Drawing.Size(195, 30);
			this.cbbBatchCode.TabIndex = 7;
			this.cbbBatchCode.UseSelectable = true;
			this.cbbBatchCode.Visible = false;
			// 
			// txtOrderNum
			// 
			this.txtOrderNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
			this.txtOrderNum.Size = new System.Drawing.Size(194, 30);
			this.txtOrderNum.TabIndex = 3;
			this.txtOrderNum.UseSelectable = true;
			// 
			// metroLabel2
			// 
			this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(3, 44);
			this.metroLabel2.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(89, 20);
			this.metroLabel2.TabIndex = 13;
			this.metroLabel2.Text = "订单编号：";
			// 
			// metroLabel7
			// 
			this.metroLabel7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.Location = new System.Drawing.Point(301, 116);
			this.metroLabel7.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(98, 20);
			this.metroLabel7.TabIndex = 27;
			this.metroLabel7.Text = "批次(Guid)：";
			this.metroLabel7.Visible = false;
			// 
			// metroLabel4
			// 
			this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.Location = new System.Drawing.Point(3, 8);
			this.metroLabel4.Margin = new System.Windows.Forms.Padding(3);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(89, 20);
			this.metroLabel4.TabIndex = 22;
			this.metroLabel4.Text = "客户名称：";
			// 
			// txtCustmoer
			// 
			this.txtCustmoer.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtCustmoer.BackColor = System.Drawing.Color.White;
			this.txtCustmoer.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtCustmoer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCustmoer.Lines = new string[0];
			this.txtCustmoer.Location = new System.Drawing.Point(98, 3);
			this.txtCustmoer.MaxLength = 32767;
			this.txtCustmoer.Name = "txtCustmoer";
			this.txtCustmoer.PasswordChar = '\0';
			this.txtCustmoer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCustmoer.SelectedText = "";
			this.txtCustmoer.Size = new System.Drawing.Size(194, 30);
			this.txtCustmoer.TabIndex = 1;
			this.txtCustmoer.UseSelectable = true;
			// 
			// txtLocation
			// 
			this.txtLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtLocation.BackColor = System.Drawing.Color.White;
			this.txtLocation.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.txtLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtLocation.Lines = new string[0];
			this.txtLocation.Location = new System.Drawing.Point(405, 3);
			this.txtLocation.MaxLength = 32767;
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.PasswordChar = '\0';
			this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLocation.SelectedText = "";
			this.txtLocation.Size = new System.Drawing.Size(195, 30);
			this.txtLocation.TabIndex = 2;
			this.txtLocation.UseSelectable = true;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnClose, 0, 2);
			this.btnPanel.Controls.Add(this.btnPrintSend, 0, 1);
			this.btnPanel.Controls.Add(this.btnView, 0, 0);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(603, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 4;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Size = new System.Drawing.Size(96, 501);
			this.btnPanel.TabIndex = 20;
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClose.Location = new System.Drawing.Point(2, 90);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 23;
			this.btnClose.Text = "关 闭";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.OnbtnClose_Click);
			// 
			// btnPrintSend
			// 
			this.btnPrintSend.ActiveControl = null;
			this.btnPrintSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPrintSend.Location = new System.Drawing.Point(2, 46);
			this.btnPrintSend.Margin = new System.Windows.Forms.Padding(2);
			this.btnPrintSend.Name = "btnPrintSend";
			this.btnPrintSend.Size = new System.Drawing.Size(90, 40);
			this.btnPrintSend.TabIndex = 22;
			this.btnPrintSend.Text = "打 印";
			this.btnPrintSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrintSend.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrintSend.UseSelectable = true;
			this.btnPrintSend.UseTileImage = true;
			this.btnPrintSend.Visible = false;
			this.btnPrintSend.Click += new System.EventHandler(this.OnbtnPrintSend_Click);
			// 
			// btnView
			// 
			this.btnView.ActiveControl = null;
			this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnView.Location = new System.Drawing.Point(2, 2);
			this.btnView.Margin = new System.Windows.Forms.Padding(2);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(90, 40);
			this.btnView.TabIndex = 21;
			this.btnView.Text = "查 看";
			this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnView.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnView.UseSelectable = true;
			this.btnView.UseTileImage = true;
			this.btnView.Click += new System.EventHandler(this.OnbtnView_Click);
			// 
			// HCSSM_order_all_send
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 577);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.Name = "HCSSM_order_all_send";
			this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
			this.Text = "发货单";
			this.Load += new System.EventHandler(this.HCSSM_order_all_send_Load);
			this.mainPanel.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_send_order)).EndInit();
			this.btnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.DataGridView dgv_send_order;
		private System.Windows.Forms.Label metroLabel1;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderType;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderName;
		private System.Windows.Forms.Label metroLabel6;
		private System.Windows.Forms.Label metroLabel2;
		private CnasMetroFramework.Controls.MetroTextBox txtOrderNum;
		private System.Windows.Forms.Label metroLabel4;
		private CnasMetroFramework.Controls.MetroTextBox txtCustmoer;
		private System.Windows.Forms.Label metroLabel5;
		private CnasMetroFramework.Controls.MetroTextBox txtLocation;
		private System.Windows.Forms.Label metroLabel3;
		private CnasMetroFramework.Controls.MetroComboBox cbbCreDate;
		private System.Windows.Forms.Label metroLabel7;
		private CnasMetroFramework.Controls.MetroComboBox cbbBatchCode;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private CnasMetroFramework.Controls.MetroTile btnPrintSend;
		private CnasMetroFramework.Controls.MetroTile btnView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn fillCountCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setCountCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn send_batch;

	}
}