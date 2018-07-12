namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_send_orderList_manager
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.useLocationTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.customerCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.btnsPanel = new System.Windows.Forms.TableLayoutPanel();
			this.previewBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.customerLbl = new System.Windows.Forms.Label();
			this.orderGrid = new System.Windows.Forms.DataGridView();
			this.customerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.useLocationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.carNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sendTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batchNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uselocationLbl = new System.Windows.Forms.Label();
			this.endDateLbl = new System.Windows.Forms.Label();
			this.endDatePicker = new System.Windows.Forms.DateTimePicker();
			this.startDatePicker = new System.Windows.Forms.DateTimePicker();
			this.startDateLbl = new System.Windows.Forms.Label();
			this.searchBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.uselocationCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.mainPanel.SuspendLayout();
			this.btnsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 5;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.useLocationTxt, 4, 1);
			this.mainPanel.Controls.Add(this.customerCbx, 1, 1);
			this.mainPanel.Controls.Add(this.btnsPanel, 0, 0);
			this.mainPanel.Controls.Add(this.customerLbl, 0, 1);
			this.mainPanel.Controls.Add(this.orderGrid, 0, 3);
			this.mainPanel.Controls.Add(this.uselocationLbl, 2, 1);
			this.mainPanel.Controls.Add(this.endDateLbl, 2, 2);
			this.mainPanel.Controls.Add(this.endDatePicker, 3, 2);
			this.mainPanel.Controls.Add(this.startDatePicker, 1, 2);
			this.mainPanel.Controls.Add(this.startDateLbl, 0, 2);
			this.mainPanel.Controls.Add(this.searchBtn, 4, 2);
			this.mainPanel.Controls.Add(this.uselocationCbx, 3, 1);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 4;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(793, 582);
			this.mainPanel.TabIndex = 0;
			// 
			// useLocationTxt
			// 
			this.useLocationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useLocationTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.useLocationTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.useLocationTxt.Lines = new string[0];
			this.useLocationTxt.Location = new System.Drawing.Point(593, 49);
			this.useLocationTxt.Margin = new System.Windows.Forms.Padding(2);
			this.useLocationTxt.MaxLength = 32767;
			this.useLocationTxt.Name = "useLocationTxt";
			this.useLocationTxt.PasswordChar = '\0';
			this.useLocationTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.useLocationTxt.SelectedText = "";
			this.useLocationTxt.Size = new System.Drawing.Size(198, 30);
			this.useLocationTxt.TabIndex = 22;
			this.useLocationTxt.UseSelectable = true;
			this.useLocationTxt.Visible = false;
			this.useLocationTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
			// 
			// customerCbx
			// 
			this.customerCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.customerCbx.DisplayMember = "Value";
			this.customerCbx.FormattingEnabled = true;
			this.customerCbx.ItemHeight = 24;
			this.customerCbx.Location = new System.Drawing.Point(82, 49);
			this.customerCbx.Name = "customerCbx";
			this.customerCbx.Size = new System.Drawing.Size(200, 30);
			this.customerCbx.TabIndex = 1;
			this.customerCbx.UseSelectable = true;
			this.customerCbx.ValueMember = "Key";
			this.customerCbx.SelectionChangeCommitted += new System.EventHandler(this.OnCustomerSelectionChanged);
			// 
			// btnsPanel
			// 
			this.btnsPanel.ColumnCount = 4;
			this.mainPanel.SetColumnSpan(this.btnsPanel, 5);
			this.btnsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.btnsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.btnsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.btnsPanel.Controls.Add(this.previewBtn, 0, 0);
			this.btnsPanel.Controls.Add(this.printBtn, 1, 0);
			this.btnsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnsPanel.Location = new System.Drawing.Point(0, 0);
			this.btnsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnsPanel.Name = "btnsPanel";
			this.btnsPanel.RowCount = 1;
			this.btnsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnsPanel.Size = new System.Drawing.Size(793, 46);
			this.btnsPanel.TabIndex = 0;
			// 
			// previewBtn
			// 
			this.previewBtn.ActiveControl = null;
			this.previewBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.previewBtn.Location = new System.Drawing.Point(3, 3);
			this.previewBtn.Name = "previewBtn";
			this.previewBtn.Size = new System.Drawing.Size(90, 40);
			this.previewBtn.TabIndex = 21;
			this.previewBtn.Text = "查 看 ";
			this.previewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.previewBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.previewBtn.UseSelectable = true;
			this.previewBtn.UseTileImage = true;
			this.previewBtn.Click += new System.EventHandler(this.OnPreviewBtnClick);
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(99, 3);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 22;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.OnPrintClick);
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Location = new System.Drawing.Point(7, 54);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(69, 20);
			this.customerLbl.TabIndex = 1;
			this.customerLbl.Text = "客       户";
			// 
			// orderGrid
			// 
			this.orderGrid.AllowUserToAddRows = false;
			this.orderGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerCol,
            this.useLocationCol,
            this.carNameCol,
            this.setNumCol,
            this.sendTimeCol,
            this.batchNumCol});
			this.mainPanel.SetColumnSpan(this.orderGrid, 5);
			this.orderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orderGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
			this.orderGrid.Location = new System.Drawing.Point(3, 119);
			this.orderGrid.MultiSelect = false;
			this.orderGrid.Name = "orderGrid";
			this.orderGrid.ReadOnly = true;
			this.orderGrid.RowHeadersVisible = false;
			this.orderGrid.RowTemplate.Height = 23;
			this.orderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.orderGrid.Size = new System.Drawing.Size(787, 460);
			this.orderGrid.TabIndex = 6;
			this.orderGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnOrderGridDoubleClick);
			// 
			// customerCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.customerCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.customerCol.HeaderText = "客  户";
			this.customerCol.Name = "customerCol";
			this.customerCol.ReadOnly = true;
			this.customerCol.Width = 180;
			// 
			// useLocationCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.useLocationCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.useLocationCol.HeaderText = "使用地点";
			this.useLocationCol.MinimumWidth = 120;
			this.useLocationCol.Name = "useLocationCol";
			this.useLocationCol.ReadOnly = true;
			this.useLocationCol.Width = 250;
			// 
			// carNameCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.carNameCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.carNameCol.HeaderText = "运输车名";
			this.carNameCol.MinimumWidth = 100;
			this.carNameCol.Name = "carNameCol";
			this.carNameCol.ReadOnly = true;
			this.carNameCol.Width = 120;
			// 
			// setNumCol
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNumCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.setNumCol.HeaderText = "器械包数量";
			this.setNumCol.MinimumWidth = 120;
			this.setNumCol.Name = "setNumCol";
			this.setNumCol.ReadOnly = true;
			this.setNumCol.Width = 150;
			// 
			// sendTimeCol
			// 
			dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sendTimeCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.sendTimeCol.HeaderText = "发送时间";
			this.sendTimeCol.MinimumWidth = 120;
			this.sendTimeCol.Name = "sendTimeCol";
			this.sendTimeCol.ReadOnly = true;
			this.sendTimeCol.Width = 180;
			// 
			// batchNumCol
			// 
			this.batchNumCol.HeaderText = "batchNum";
			this.batchNumCol.Name = "batchNumCol";
			this.batchNumCol.ReadOnly = true;
			this.batchNumCol.Visible = false;
			// 
			// uselocationLbl
			// 
			this.uselocationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.uselocationLbl.AutoSize = true;
			this.uselocationLbl.Location = new System.Drawing.Point(300, 54);
			this.uselocationLbl.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.uselocationLbl.Name = "uselocationLbl";
			this.uselocationLbl.Size = new System.Drawing.Size(73, 20);
			this.uselocationLbl.TabIndex = 3;
			this.uselocationLbl.Text = "使用地点";
			// 
			// endDateLbl
			// 
			this.endDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.endDateLbl.AutoSize = true;
			this.endDateLbl.Location = new System.Drawing.Point(300, 89);
			this.endDateLbl.Name = "endDateLbl";
			this.endDateLbl.Size = new System.Drawing.Size(73, 20);
			this.endDateLbl.TabIndex = 4;
			this.endDateLbl.Text = "结束时间";
			// 
			// endDatePicker
			// 
			this.endDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.endDatePicker.CustomFormat = "yyyy-MM-dd HH:mm";
			this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.endDatePicker.Location = new System.Drawing.Point(379, 85);
			this.endDatePicker.Name = "endDatePicker";
			this.endDatePicker.Size = new System.Drawing.Size(209, 27);
			this.endDatePicker.TabIndex = 4;
			this.endDatePicker.Value = new System.DateTime(2016, 5, 27, 0, 0, 0, 0);
			this.endDatePicker.ValueChanged += new System.EventHandler(this.OnDateTimePikcerChanged);
			// 
			// startDatePicker
			// 
			this.startDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.startDatePicker.CustomFormat = "yyyy-MM-dd HH:mm";
			this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.startDatePicker.Location = new System.Drawing.Point(82, 85);
			this.startDatePicker.Name = "startDatePicker";
			this.startDatePicker.Size = new System.Drawing.Size(200, 27);
			this.startDatePicker.TabIndex = 3;
			this.startDatePicker.Value = new System.DateTime(2016, 5, 27, 0, 0, 0, 0);
			this.startDatePicker.ValueChanged += new System.EventHandler(this.OnDateTimePikcerChanged);
			// 
			// startDateLbl
			// 
			this.startDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.startDateLbl.AutoSize = true;
			this.startDateLbl.Location = new System.Drawing.Point(3, 89);
			this.startDateLbl.Name = "startDateLbl";
			this.startDateLbl.Size = new System.Drawing.Size(73, 20);
			this.startDateLbl.TabIndex = 2;
			this.startDateLbl.Text = "开始时间";
			// 
			// searchBtn
			// 
			this.searchBtn.ActiveControl = null;
			this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.searchBtn.Location = new System.Drawing.Point(593, 84);
			this.searchBtn.Margin = new System.Windows.Forms.Padding(2);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(90, 30);
			this.searchBtn.TabIndex = 5;
			this.searchBtn.Text = "查 询 ";
			this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.searchBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.searchBtn.UseSelectable = true;
			this.searchBtn.UseTileImage = true;
			this.searchBtn.Click += new System.EventHandler(this.OnSearchBtnClick);
			// 
			// uselocationCbx
			// 
			this.uselocationCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.uselocationCbx.DisplayMember = "Value";
			this.uselocationCbx.FormattingEnabled = true;
			this.uselocationCbx.ItemHeight = 24;
			this.uselocationCbx.Location = new System.Drawing.Point(379, 49);
			this.uselocationCbx.Name = "uselocationCbx";
			this.uselocationCbx.Size = new System.Drawing.Size(209, 30);
			this.uselocationCbx.TabIndex = 2;
			this.uselocationCbx.UseSelectable = true;
			this.uselocationCbx.ValueMember = "Key";
			this.uselocationCbx.SelectedIndexChanged += new System.EventHandler(this.OnUseLocationSelectionChanged);
			// 
			// HCSWF_send_orderList_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "HCSWF_send_orderList_manager";
			this.Size = new System.Drawing.Size(793, 582);
			this.Load += new System.EventHandler(this.OnControlLoaded);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.btnsPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel btnsPanel;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private CnasMetroFramework.Controls.MetroTile previewBtn;
		private System.Windows.Forms.Label customerLbl;
		private System.Windows.Forms.Label startDateLbl;
		private System.Windows.Forms.Label uselocationLbl;
		private System.Windows.Forms.Label endDateLbl;
		private System.Windows.Forms.DateTimePicker startDatePicker;
		private System.Windows.Forms.DateTimePicker endDatePicker;
		private CnasMetroFramework.Controls.MetroComboBox uselocationCbx;
		private CnasMetroFramework.Controls.MetroComboBox customerCbx;
		private CnasMetroFramework.Controls.MetroTile searchBtn;
		private System.Windows.Forms.DataGridView orderGrid;
		private CnasMetroFramework.Controls.MetroTextBox useLocationTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn useLocationCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn carNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sendTimeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn batchNumCol;
	}
}
