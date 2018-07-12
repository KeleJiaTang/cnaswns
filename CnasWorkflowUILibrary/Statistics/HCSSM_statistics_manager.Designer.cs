namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_statistics_manager
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.dgv_01 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entity_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entity_typeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.location_idText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.middlePanel = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.cbbType = new System.Windows.Forms.ComboBox();
			this.cbbreason = new System.Windows.Forms.ComboBox();
			this.lbreason = new System.Windows.Forms.Label();
			this.lbDateTime = new System.Windows.Forms.Label();
			this.creenddate = new System.Windows.Forms.DateTimePicker();
			this.lbstartDate = new System.Windows.Forms.Label();
			this.crestartdate = new System.Windows.Forms.DateTimePicker();
			this.searchBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.topPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnPri = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnDel = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnEdit = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.maingroupBox = new System.Windows.Forms.GroupBox();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			this.middlePanel.SuspendLayout();
			this.topPanel.SuspendLayout();
			this.maingroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 1;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.dgv_01, 0, 2);
			this.mainPanel.Controls.Add(this.middlePanel, 0, 1);
			this.mainPanel.Controls.Add(this.topPanel, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(4, 25);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 3;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(925, 804);
			this.mainPanel.TabIndex = 0;
			// 
			// dgv_01
			// 
			this.dgv_01.AllowUserToAddRows = false;
			this.dgv_01.AllowUserToDeleteRows = false;
			this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.location_id,
            this.entity_type,
            this.type,
            this.ca_name,
            this.entity_typeText,
            this.typeText,
            this.bar_code,
            this.location_idText,
            this.num,
            this.cre_date,
            this.remark});
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Location = new System.Drawing.Point(3, 121);
			this.dgv_01.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RowHeadersVisible = false;
			this.dgv_01.RowTemplate.Height = 23;
			this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_01.Size = new System.Drawing.Size(919, 683);
			this.dgv_01.TabIndex = 1;
			this.dgv_01.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_01_CellContentClick);
			this.dgv_01.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "编码";
			this.id.MinimumWidth = 70;
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			this.id.Width = 70;
			// 
			// location_id
			// 
			this.location_id.HeaderText = "区域id";
			this.location_id.Name = "location_id";
			this.location_id.ReadOnly = true;
			this.location_id.Visible = false;
			this.location_id.Width = 10;
			// 
			// entity_type
			// 
			this.entity_type.HeaderText = "类型id";
			this.entity_type.Name = "entity_type";
			this.entity_type.ReadOnly = true;
			this.entity_type.Visible = false;
			this.entity_type.Width = 10;
			// 
			// type
			// 
			this.type.HeaderText = "原因id";
			this.type.Name = "type";
			this.type.ReadOnly = true;
			this.type.Visible = false;
			this.type.Width = 10;
			// 
			// ca_name
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ca_name.DefaultCellStyle = dataGridViewCellStyle1;
			this.ca_name.HeaderText = "名称";
			this.ca_name.MinimumWidth = 120;
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			this.ca_name.Width = 180;
			// 
			// entity_typeText
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.entity_typeText.DefaultCellStyle = dataGridViewCellStyle2;
			this.entity_typeText.HeaderText = "类型";
			this.entity_typeText.MinimumWidth = 80;
			this.entity_typeText.Name = "entity_typeText";
			this.entity_typeText.ReadOnly = true;
			// 
			// typeText
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.typeText.DefaultCellStyle = dataGridViewCellStyle3;
			this.typeText.HeaderText = "原因";
			this.typeText.MinimumWidth = 80;
			this.typeText.Name = "typeText";
			this.typeText.ReadOnly = true;
			this.typeText.Width = 150;
			// 
			// bar_code
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bar_code.DefaultCellStyle = dataGridViewCellStyle4;
			this.bar_code.HeaderText = "条码";
			this.bar_code.MinimumWidth = 80;
			this.bar_code.Name = "bar_code";
			this.bar_code.ReadOnly = true;
			this.bar_code.Width = 120;
			// 
			// location_idText
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.location_idText.DefaultCellStyle = dataGridViewCellStyle5;
			this.location_idText.HeaderText = "工作区";
			this.location_idText.MinimumWidth = 120;
			this.location_idText.Name = "location_idText";
			this.location_idText.ReadOnly = true;
			this.location_idText.Width = 160;
			// 
			// num
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.num.DefaultCellStyle = dataGridViewCellStyle6;
			this.num.HeaderText = "数量";
			this.num.MinimumWidth = 80;
			this.num.Name = "num";
			this.num.ReadOnly = true;
			this.num.Width = 80;
			// 
			// cre_date
			// 
			dataGridViewCellStyle7.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle7;
			this.cre_date.HeaderText = "创建日期";
			this.cre_date.MinimumWidth = 100;
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 180;
			// 
			// remark
			// 
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.remark.DefaultCellStyle = dataGridViewCellStyle8;
			this.remark.HeaderText = "备注";
			this.remark.MinimumWidth = 80;
			this.remark.Name = "remark";
			this.remark.ReadOnly = true;
			this.remark.Width = 200;
			// 
			// middlePanel
			// 
			this.middlePanel.ColumnCount = 5;
			this.middlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.middlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.middlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.middlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.middlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.middlePanel.Controls.Add(this.label1, 0, 0);
			this.middlePanel.Controls.Add(this.cbbType, 1, 0);
			this.middlePanel.Controls.Add(this.cbbreason, 3, 0);
			this.middlePanel.Controls.Add(this.lbreason, 2, 0);
			this.middlePanel.Controls.Add(this.lbDateTime, 2, 1);
			this.middlePanel.Controls.Add(this.creenddate, 3, 1);
			this.middlePanel.Controls.Add(this.lbstartDate, 0, 1);
			this.middlePanel.Controls.Add(this.crestartdate, 1, 1);
			this.middlePanel.Controls.Add(this.searchBtn, 4, 0);
			this.middlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.middlePanel.Location = new System.Drawing.Point(0, 46);
			this.middlePanel.Margin = new System.Windows.Forms.Padding(0);
			this.middlePanel.Name = "middlePanel";
			this.middlePanel.RowCount = 2;
			this.middlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
			this.middlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
			this.middlePanel.Size = new System.Drawing.Size(925, 72);
			this.middlePanel.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "类       型";
			// 
			// cbbType
			// 
			this.cbbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbType.FormattingEnabled = true;
			this.cbbType.Location = new System.Drawing.Point(84, 7);
			this.cbbType.Name = "cbbType";
			this.cbbType.Size = new System.Drawing.Size(267, 28);
			this.cbbType.TabIndex = 1;
			// 
			// cbbreason
			// 
			this.cbbreason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbreason.FormattingEnabled = true;
			this.cbbreason.Location = new System.Drawing.Point(438, 7);
			this.cbbreason.Name = "cbbreason";
			this.cbbreason.Size = new System.Drawing.Size(267, 28);
			this.cbbreason.TabIndex = 5;
			// 
			// lbreason
			// 
			this.lbreason.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbreason.AutoSize = true;
			this.lbreason.Location = new System.Drawing.Point(362, 7);
			this.lbreason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbreason.Name = "lbreason";
			this.lbreason.Size = new System.Drawing.Size(69, 20);
			this.lbreason.TabIndex = 4;
			this.lbreason.Text = "原       因";
			// 
			// lbDateTime
			// 
			this.lbDateTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbDateTime.AutoSize = true;
			this.lbDateTime.Location = new System.Drawing.Point(358, 43);
			this.lbDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbDateTime.Name = "lbDateTime";
			this.lbDateTime.Size = new System.Drawing.Size(73, 20);
			this.lbDateTime.TabIndex = 6;
			this.lbDateTime.Text = "结束日期";
			// 
			// creenddate
			// 
			this.creenddate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.creenddate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.creenddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creenddate.Location = new System.Drawing.Point(439, 39);
			this.creenddate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.creenddate.Name = "creenddate";
			this.creenddate.Size = new System.Drawing.Size(265, 27);
			this.creenddate.TabIndex = 7;
			this.creenddate.Value = new System.DateTime(2016, 5, 27, 0, 0, 0, 0);
			// 
			// lbstartDate
			// 
			this.lbstartDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbstartDate.AutoSize = true;
			this.lbstartDate.Location = new System.Drawing.Point(4, 43);
			this.lbstartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbstartDate.Name = "lbstartDate";
			this.lbstartDate.Size = new System.Drawing.Size(73, 20);
			this.lbstartDate.TabIndex = 2;
			this.lbstartDate.Text = "开始日期";
			// 
			// crestartdate
			// 
			this.crestartdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.crestartdate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.crestartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.crestartdate.Location = new System.Drawing.Point(85, 39);
			this.crestartdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.crestartdate.Name = "crestartdate";
			this.crestartdate.Size = new System.Drawing.Size(265, 27);
			this.crestartdate.TabIndex = 9;
			this.crestartdate.Value = new System.DateTime(2016, 5, 27, 0, 0, 0, 0);
			// 
			// searchBtn
			// 
			this.searchBtn.ActiveControl = null;
			this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.searchBtn.Location = new System.Drawing.Point(711, 39);
			this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
			this.searchBtn.Name = "searchBtn";
			this.middlePanel.SetRowSpan(this.searchBtn, 2);
			this.searchBtn.Size = new System.Drawing.Size(80, 27);
			this.searchBtn.TabIndex = 22;
			this.searchBtn.Text = "查 询 ";
			this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.searchBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.searchBtn.UseSelectable = true;
			this.searchBtn.UseTileImage = true;
			this.searchBtn.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// topPanel
			// 
			this.topPanel.ColumnCount = 4;
			this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topPanel.Controls.Add(this.btnPri, 0, 0);
			this.topPanel.Controls.Add(this.btnDel, 0, 0);
			this.topPanel.Controls.Add(this.btnEdit, 0, 0);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topPanel.Location = new System.Drawing.Point(0, 0);
			this.topPanel.Margin = new System.Windows.Forms.Padding(0);
			this.topPanel.Name = "topPanel";
			this.topPanel.RowCount = 1;
			this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.topPanel.Size = new System.Drawing.Size(925, 46);
			this.topPanel.TabIndex = 3;
			// 
			// btnPri
			// 
			this.btnPri.ActiveControl = null;
			this.btnPri.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPri.Location = new System.Drawing.Point(195, 3);
			this.btnPri.Name = "btnPri";
			this.btnPri.Size = new System.Drawing.Size(90, 40);
			this.btnPri.TabIndex = 23;
			this.btnPri.Text = "打 印 ";
			this.btnPri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPri.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPri.UseSelectable = true;
			this.btnPri.UseTileImage = true;
			this.btnPri.Click += new System.EventHandler(this.btnPri_Click);
			// 
			// btnDel
			// 
			this.btnDel.ActiveControl = null;
			this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnDel.Location = new System.Drawing.Point(99, 3);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(90, 40);
			this.btnDel.TabIndex = 22;
			this.btnDel.Text = "删 除 ";
			this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDel.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDel.UseSelectable = true;
			this.btnDel.UseTileImage = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.ActiveControl = null;
			this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEdit.Location = new System.Drawing.Point(3, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(90, 40);
			this.btnEdit.TabIndex = 20;
			this.btnEdit.Text = "修 改 ";
			this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEdit.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.UseSelectable = true;
			this.btnEdit.UseTileImage = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// maingroupBox
			// 
			this.maingroupBox.Controls.Add(this.mainPanel);
			this.maingroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maingroupBox.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.maingroupBox.Location = new System.Drawing.Point(0, 0);
			this.maingroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.maingroupBox.Name = "maingroupBox";
			this.maingroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.maingroupBox.Size = new System.Drawing.Size(933, 834);
			this.maingroupBox.TabIndex = 1;
			this.maingroupBox.TabStop = false;
			this.maingroupBox.Text = "质量管理";
			// 
			// HCSSM_statistics_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.maingroupBox);
			this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "HCSSM_statistics_manager";
			this.Size = new System.Drawing.Size(933, 834);
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			this.middlePanel.ResumeLayout(false);
			this.middlePanel.PerformLayout();
			this.topPanel.ResumeLayout(false);
			this.maingroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.DataGridView dgv_01;
		private System.Windows.Forms.TableLayoutPanel middlePanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbbType;
		private System.Windows.Forms.Label lbstartDate;
		private System.Windows.Forms.Label lbreason;
		private System.Windows.Forms.ComboBox cbbreason;
		private System.Windows.Forms.Label lbDateTime;
		private System.Windows.Forms.DateTimePicker creenddate;
		private System.Windows.Forms.GroupBox maingroupBox;
		private System.Windows.Forms.TableLayoutPanel topPanel;
		private System.Windows.Forms.DateTimePicker crestartdate;
		private CnasMetroFramework.Controls.MetroTile btnEdit;
		private CnasMetroFramework.Controls.MetroTile btnDel;
		private CnasMetroFramework.Controls.MetroTile btnPri;
		private CnasMetroFramework.Controls.MetroTile searchBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn location_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn entity_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn type;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn entity_typeText;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeText;
		private System.Windows.Forms.DataGridViewTextBoxColumn bar_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn location_idText;
		private System.Windows.Forms.DataGridViewTextBoxColumn num;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn remark;
	}
}