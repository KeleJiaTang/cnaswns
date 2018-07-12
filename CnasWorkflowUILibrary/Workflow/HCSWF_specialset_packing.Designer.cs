using System.Windows.Forms;
namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_specialset_packing
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer  components = null;

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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridContextMenu = new Cnas.wns.CnasMetroFramework.Controls.MetroContextMenu(this.components);
			this.gridDeleteBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.tsm_bcuprint = new System.Windows.Forms.ToolStripMenuItem();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.messageLbl = new System.Windows.Forms.Label();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tempCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pbCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.useLocationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.creDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.expireDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batchCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.groupPanel = new System.Windows.Forms.TableLayoutPanel();
			this.packageTypeLbl = new System.Windows.Forms.Label();
			this.isSimgleLbl = new System.Windows.Forms.Label();
			this.cfmUserLbl = new System.Windows.Forms.Label();
			this.cfmUserTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.uselocationCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.packUserTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.customerCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.customerLbl = new System.Windows.Forms.Label();
			this.useNameLbl = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.batchBCUR = new System.Windows.Forms.RadioButton();
			this.batchBCU = new System.Windows.Forms.RadioButton();
			this.packTypeLbl = new System.Windows.Forms.Label();
			this.packTypeCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.genNumLbl = new System.Windows.Forms.Label();
			this.genNumTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.materialLbl = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.expireDateTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.materialCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.namePanel = new System.Windows.Forms.TableLayoutPanel();
			this.genNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.orderCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.orderCodeLbl = new System.Windows.Forms.Label();
			this.genNameLbl = new System.Windows.Forms.Label();
			this.isSplitCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.packageTypeCbx = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.generateBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.submitBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.printBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.dataGridContextMenu.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.groupBox.SuspendLayout();
			this.groupPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.namePanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridContextMenu
			// 
			this.dataGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridDeleteBtn});
			this.dataGridContextMenu.Name = "mcm_right";
			this.dataGridContextMenu.Size = new System.Drawing.Size(125, 26);
			this.dataGridContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnDataGridContextMenuOpening);
			// 
			// gridDeleteBtn
			// 
			this.gridDeleteBtn.Name = "gridDeleteBtn";
			this.gridDeleteBtn.Size = new System.Drawing.Size(124, 22);
			this.gridDeleteBtn.Text = "删除选中";
			this.gridDeleteBtn.Click += new System.EventHandler(this.OnDataGridDeleteClick);
			// 
			// tsm_bcuprint
			// 
			this.tsm_bcuprint.Name = "tsm_bcuprint";
			this.tsm_bcuprint.Size = new System.Drawing.Size(152, 22);
			this.tsm_bcuprint.Text = "删除选中";
			this.tsm_bcuprint.Click += new System.EventHandler(this.OnDataGridDeleteClick);
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.leftPanel, 0, 0);
			this.mainPanel.Controls.Add(this.buttonPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1006F));
			this.mainPanel.Size = new System.Drawing.Size(1008, 603);
			this.mainPanel.TabIndex = 0;
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 2;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.messageLbl, 0, 2);
			this.leftPanel.Controls.Add(this.dataGrid, 0, 1);
			this.leftPanel.Controls.Add(this.groupBox, 0, 0);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 3;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.Size = new System.Drawing.Size(912, 603);
			this.leftPanel.TabIndex = 0;
			// 
			// messageLbl
			// 
			this.messageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.messageLbl.AutoSize = true;
			this.leftPanel.SetColumnSpan(this.messageLbl, 2);
			this.messageLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.messageLbl.ForeColor = System.Drawing.Color.Green;
			this.messageLbl.Location = new System.Drawing.Point(3, 580);
			this.messageLbl.Margin = new System.Windows.Forms.Padding(3);
			this.messageLbl.Name = "messageLbl";
			this.messageLbl.Size = new System.Drawing.Size(906, 20);
			this.messageLbl.TabIndex = 22;
			this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.tempCodeCol,
            this.pbCodeCol,
            this.setNameCol,
            this.useLocationCol,
            this.creDateCol,
            this.expireDateCol,
            this.batchCol});
			this.leftPanel.SetColumnSpan(this.dataGrid, 2);
			this.dataGrid.ContextMenuStrip = this.dataGridContextMenu;
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.dataGrid.Location = new System.Drawing.Point(3, 231);
			this.dataGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.RowTemplate.Height = 23;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.Size = new System.Drawing.Size(906, 346);
			this.dataGrid.TabIndex = 24;
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			// 
			// tempCodeCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.tempCodeCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.tempCodeCol.HeaderText = "临时条码";
			this.tempCodeCol.MinimumWidth = 120;
			this.tempCodeCol.Name = "tempCodeCol";
			this.tempCodeCol.ReadOnly = true;
			this.tempCodeCol.Width = 120;
			// 
			// pbCodeCol
			// 
			dataGridViewCellStyle2.NullValue = null;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.pbCodeCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.pbCodeCol.HeaderText = "标签条码";
			this.pbCodeCol.MinimumWidth = 120;
			this.pbCodeCol.Name = "pbCodeCol";
			this.pbCodeCol.ReadOnly = true;
			this.pbCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.setNameCol.HeaderText = "名 称";
			this.setNameCol.MinimumWidth = 100;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 215;
			// 
			// useLocationCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.useLocationCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.useLocationCol.HeaderText = "使用地点";
			this.useLocationCol.MinimumWidth = 120;
			this.useLocationCol.Name = "useLocationCol";
			this.useLocationCol.ReadOnly = true;
			this.useLocationCol.Width = 208;
			// 
			// creDateCol
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "yyyy-MM-dd";
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.creDateCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.creDateCol.HeaderText = "生产日期";
			this.creDateCol.MinimumWidth = 100;
			this.creDateCol.Name = "creDateCol";
			this.creDateCol.ReadOnly = true;
			this.creDateCol.Width = 120;
			// 
			// expireDateCol
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "yyyy-MM-dd";
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.expireDateCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.expireDateCol.HeaderText = "失效日期";
			this.expireDateCol.MinimumWidth = 100;
			this.expireDateCol.Name = "expireDateCol";
			this.expireDateCol.ReadOnly = true;
			this.expireDateCol.Width = 120;
			// 
			// batchCol
			// 
			this.batchCol.HeaderText = "批次号";
			this.batchCol.Name = "batchCol";
			this.batchCol.ReadOnly = true;
			this.batchCol.Visible = false;
			// 
			// groupBox
			// 
			this.leftPanel.SetColumnSpan(this.groupBox, 2);
			this.groupBox.Controls.Add(this.groupPanel);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(3, 3);
			this.groupBox.Name = "groupBox";
			this.groupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox.Size = new System.Drawing.Size(906, 222);
			this.groupBox.TabIndex = 1;
			this.groupBox.TabStop = false;
			// 
			// groupPanel
			// 
			this.groupPanel.ColumnCount = 5;
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.groupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.groupPanel.Controls.Add(this.packageTypeLbl, 2, 2);
			this.groupPanel.Controls.Add(this.isSimgleLbl, 0, 2);
			this.groupPanel.Controls.Add(this.cfmUserLbl, 2, 1);
			this.groupPanel.Controls.Add(this.cfmUserTxt, 3, 1);
			this.groupPanel.Controls.Add(this.uselocationCbx, 3, 0);
			this.groupPanel.Controls.Add(this.packUserTxt, 1, 1);
			this.groupPanel.Controls.Add(this.customerCbx, 1, 0);
			this.groupPanel.Controls.Add(this.label1, 0, 1);
			this.groupPanel.Controls.Add(this.customerLbl, 0, 0);
			this.groupPanel.Controls.Add(this.useNameLbl, 2, 0);
			this.groupPanel.Controls.Add(this.groupBox1, 4, 0);
			this.groupPanel.Controls.Add(this.packTypeLbl, 0, 4);
			this.groupPanel.Controls.Add(this.packTypeCbx, 1, 4);
			this.groupPanel.Controls.Add(this.genNumLbl, 2, 4);
			this.groupPanel.Controls.Add(this.genNumTxt, 3, 4);
			this.groupPanel.Controls.Add(this.materialLbl, 2, 3);
			this.groupPanel.Controls.Add(this.tableLayoutPanel2, 3, 3);
			this.groupPanel.Controls.Add(this.namePanel, 0, 3);
			this.groupPanel.Controls.Add(this.isSplitCbx, 1, 2);
			this.groupPanel.Controls.Add(this.packageTypeCbx, 3, 2);
			this.groupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupPanel.Location = new System.Drawing.Point(4, 25);
			this.groupPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupPanel.Name = "groupPanel";
			this.groupPanel.RowCount = 5;
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.groupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.groupPanel.Size = new System.Drawing.Size(898, 192);
			this.groupPanel.TabIndex = 16;
			// 
			// packageTypeLbl
			// 
			this.packageTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.packageTypeLbl.AutoSize = true;
			this.packageTypeLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.packageTypeLbl.Location = new System.Drawing.Point(368, 90);
			this.packageTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.packageTypeLbl.Name = "packageTypeLbl";
			this.packageTypeLbl.Size = new System.Drawing.Size(89, 20);
			this.packageTypeLbl.TabIndex = 35;
			this.packageTypeLbl.Text = "包装类型：";
			// 
			// isSimgleLbl
			// 
			this.isSimgleLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.isSimgleLbl.AutoSize = true;
			this.isSimgleLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.isSimgleLbl.Location = new System.Drawing.Point(4, 90);
			this.isSimgleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.isSimgleLbl.Name = "isSimgleLbl";
			this.isSimgleLbl.Size = new System.Drawing.Size(89, 20);
			this.isSimgleLbl.TabIndex = 34;
			this.isSimgleLbl.Text = "是否拆包：";
			// 
			// cfmUserLbl
			// 
			this.cfmUserLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.cfmUserLbl.AutoSize = true;
			this.cfmUserLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cfmUserLbl.Location = new System.Drawing.Point(368, 54);
			this.cfmUserLbl.Margin = new System.Windows.Forms.Padding(10, 0, 4, 0);
			this.cfmUserLbl.Name = "cfmUserLbl";
			this.cfmUserLbl.Size = new System.Drawing.Size(89, 20);
			this.cfmUserLbl.TabIndex = 20;
			this.cfmUserLbl.Text = "审  核  员：";
			// 
			// cfmUserTxt
			// 
			this.cfmUserTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cfmUserTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cfmUserTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.cfmUserTxt.Lines = new string[0];
			this.cfmUserTxt.Location = new System.Drawing.Point(464, 49);
			this.cfmUserTxt.MaxLength = 32767;
			this.cfmUserTxt.Name = "cfmUserTxt";
			this.cfmUserTxt.PasswordChar = '\0';
			this.cfmUserTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.cfmUserTxt.SelectedText = "";
			this.cfmUserTxt.Size = new System.Drawing.Size(255, 30);
			this.cfmUserTxt.Style = Cnas.wns.CnasMetroFramework.MetroColorStyle.White;
			this.cfmUserTxt.TabIndex = 14;
			this.cfmUserTxt.Theme = Cnas.wns.CnasMetroFramework.MetroThemeStyle.Light;
			this.cfmUserTxt.UseSelectable = true;
			this.cfmUserTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUserEnterKeyDown);
			// 
			// uselocationCbx
			// 
			this.uselocationCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.uselocationCbx.DisplayMember = "Value";
			this.uselocationCbx.FormattingEnabled = true;
			this.uselocationCbx.ItemHeight = 24;
			this.uselocationCbx.Location = new System.Drawing.Point(464, 13);
			this.uselocationCbx.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
			this.uselocationCbx.Name = "uselocationCbx";
			this.uselocationCbx.Size = new System.Drawing.Size(255, 30);
			this.uselocationCbx.TabIndex = 12;
			this.uselocationCbx.UseSelectable = true;
			this.uselocationCbx.ValueMember = "Key";
			this.uselocationCbx.SelectedIndexChanged += new System.EventHandler(this.OnUseLocationChanged);
			// 
			// packUserTxt
			// 
			this.packUserTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packUserTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.packUserTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.packUserTxt.Lines = new string[0];
			this.packUserTxt.Location = new System.Drawing.Point(100, 49);
			this.packUserTxt.MaxLength = 32767;
			this.packUserTxt.Name = "packUserTxt";
			this.packUserTxt.PasswordChar = '\0';
			this.packUserTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.packUserTxt.SelectedText = "";
			this.packUserTxt.Size = new System.Drawing.Size(255, 30);
			this.packUserTxt.TabIndex = 13;
			this.packUserTxt.UseSelectable = true;
			this.packUserTxt.Click += new System.EventHandler(this.OnPackUserTxtClick);
			this.packUserTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUserEnterKeyDown);
			// 
			// customerCbx
			// 
			this.customerCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.customerCbx.DisplayMember = "Value";
			this.customerCbx.FormattingEnabled = true;
			this.customerCbx.ItemHeight = 24;
			this.customerCbx.Location = new System.Drawing.Point(100, 13);
			this.customerCbx.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
			this.customerCbx.Name = "customerCbx";
			this.customerCbx.Size = new System.Drawing.Size(255, 30);
			this.customerCbx.TabIndex = 11;
			this.customerCbx.UseSelectable = true;
			this.customerCbx.ValueMember = "Key";
			this.customerCbx.SelectedIndexChanged += new System.EventHandler(this.OnCustomerCbxSelectionChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(4, 54);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "包  装  人：";
			// 
			// customerLbl
			// 
			this.customerLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerLbl.AutoSize = true;
			this.customerLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.customerLbl.Location = new System.Drawing.Point(4, 19);
			this.customerLbl.Margin = new System.Windows.Forms.Padding(4, 13, 4, 0);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(89, 20);
			this.customerLbl.TabIndex = 22;
			this.customerLbl.Text = "客户名称：";
			// 
			// useNameLbl
			// 
			this.useNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.useNameLbl.AutoSize = true;
			this.useNameLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.useNameLbl.Location = new System.Drawing.Point(369, 18);
			this.useNameLbl.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
			this.useNameLbl.Name = "useNameLbl";
			this.useNameLbl.Size = new System.Drawing.Size(89, 20);
			this.useNameLbl.TabIndex = 24;
			this.useNameLbl.Text = "使用地点：";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(727, 3);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupPanel.SetRowSpan(this.groupBox1, 4);
			this.groupBox1.Size = new System.Drawing.Size(166, 150);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Visible = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.batchBCUR, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.batchBCU, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(160, 124);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// batchBCUR
			// 
			this.batchBCUR.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.batchBCUR.AutoSize = true;
			this.batchBCUR.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.batchBCUR.Location = new System.Drawing.Point(10, 81);
			this.batchBCUR.Margin = new System.Windows.Forms.Padding(10, 5, 4, 5);
			this.batchBCUR.Name = "batchBCUR";
			this.batchBCUR.Size = new System.Drawing.Size(123, 24);
			this.batchBCUR.TabIndex = 52;
			this.batchBCUR.TabStop = true;
			this.batchBCUR.Text = "拆包标签条码";
			this.batchBCUR.UseVisualStyleBackColor = true;
			this.batchBCUR.CheckedChanged += new System.EventHandler(this.OnRadioChanged);
			// 
			// batchBCU
			// 
			this.batchBCU.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.batchBCU.AutoSize = true;
			this.batchBCU.Checked = true;
			this.batchBCU.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.batchBCU.Location = new System.Drawing.Point(10, 19);
			this.batchBCU.Margin = new System.Windows.Forms.Padding(10, 5, 4, 5);
			this.batchBCU.Name = "batchBCU";
			this.batchBCU.Size = new System.Drawing.Size(123, 24);
			this.batchBCU.TabIndex = 51;
			this.batchBCU.TabStop = true;
			this.batchBCU.Text = "批量标签条码";
			this.batchBCU.UseVisualStyleBackColor = true;
			this.batchBCU.CheckedChanged += new System.EventHandler(this.OnRadioChanged);
			// 
			// packTypeLbl
			// 
			this.packTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.packTypeLbl.AutoSize = true;
			this.packTypeLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.packTypeLbl.Location = new System.Drawing.Point(4, 164);
			this.packTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.packTypeLbl.Name = "packTypeLbl";
			this.packTypeLbl.Size = new System.Drawing.Size(89, 20);
			this.packTypeLbl.TabIndex = 28;
			this.packTypeLbl.Text = "是否灭菌：";
			// 
			// packTypeCbx
			// 
			this.packTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packTypeCbx.DisplayMember = "Value";
			this.packTypeCbx.FormattingEnabled = true;
			this.packTypeCbx.ItemHeight = 24;
			this.packTypeCbx.Location = new System.Drawing.Point(100, 159);
			this.packTypeCbx.Name = "packTypeCbx";
			this.packTypeCbx.Size = new System.Drawing.Size(255, 30);
			this.packTypeCbx.TabIndex = 22;
			this.packTypeCbx.UseSelectable = true;
			this.packTypeCbx.ValueMember = "Key";
			// 
			// genNumLbl
			// 
			this.genNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.genNumLbl.AutoSize = true;
			this.genNumLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.genNumLbl.Location = new System.Drawing.Point(368, 164);
			this.genNumLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.genNumLbl.Name = "genNumLbl";
			this.genNumLbl.Size = new System.Drawing.Size(89, 20);
			this.genNumLbl.TabIndex = 21;
			this.genNumLbl.Text = "生成数量：";
			// 
			// genNumTxt
			// 
			this.genNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.genNumTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.genNumTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.genNumTxt.Lines = new string[0];
			this.genNumTxt.Location = new System.Drawing.Point(464, 159);
			this.genNumTxt.MaxLength = 32767;
			this.genNumTxt.Name = "genNumTxt";
			this.genNumTxt.PasswordChar = '\0';
			this.genNumTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.genNumTxt.SelectedText = "";
			this.genNumTxt.Size = new System.Drawing.Size(255, 30);
			this.genNumTxt.TabIndex = 23;
			this.genNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.genNumTxt.UseSelectable = true;
			// 
			// materialLbl
			// 
			this.materialLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.materialLbl.AutoSize = true;
			this.materialLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.materialLbl.Location = new System.Drawing.Point(368, 127);
			this.materialLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.materialLbl.Name = "materialLbl";
			this.materialLbl.Size = new System.Drawing.Size(89, 20);
			this.materialLbl.TabIndex = 26;
			this.materialLbl.Text = "包装材料：";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.expireDateTxt, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.materialCbx, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(461, 118);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(261, 38);
			this.tableLayoutPanel2.TabIndex = 30;
			// 
			// expireDateTxt
			// 
			this.expireDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.expireDateTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.expireDateTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.expireDateTxt.Lines = new string[0];
			this.expireDateTxt.Location = new System.Drawing.Point(209, 4);
			this.expireDateTxt.MaxLength = 32767;
			this.expireDateTxt.Name = "expireDateTxt";
			this.expireDateTxt.PasswordChar = '\0';
			this.expireDateTxt.ReadOnly = true;
			this.expireDateTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.expireDateTxt.SelectedText = "";
			this.expireDateTxt.Size = new System.Drawing.Size(49, 30);
			this.expireDateTxt.TabIndex = 21;
			this.expireDateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.expireDateTxt.UseSelectable = true;
			// 
			// materialCbx
			// 
			this.materialCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.materialCbx.DisplayMember = "Value";
			this.materialCbx.FormattingEnabled = true;
			this.materialCbx.ItemHeight = 24;
			this.materialCbx.Location = new System.Drawing.Point(3, 4);
			this.materialCbx.Name = "materialCbx";
			this.materialCbx.Size = new System.Drawing.Size(200, 30);
			this.materialCbx.TabIndex = 19;
			this.materialCbx.UseSelectable = true;
			this.materialCbx.ValueMember = "Key";
			this.materialCbx.SelectedIndexChanged += new System.EventHandler(this.OnMaterialCbxSelectedIndexChanged);
			// 
			// namePanel
			// 
			this.namePanel.ColumnCount = 2;
			this.groupPanel.SetColumnSpan(this.namePanel, 2);
			this.namePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.namePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.namePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.namePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.namePanel.Controls.Add(this.genNameTxt, 1, 1);
			this.namePanel.Controls.Add(this.orderCbx, 1, 0);
			this.namePanel.Controls.Add(this.orderCodeLbl, 0, 0);
			this.namePanel.Controls.Add(this.genNameLbl, 0, 1);
			this.namePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.namePanel.Location = new System.Drawing.Point(0, 118);
			this.namePanel.Margin = new System.Windows.Forms.Padding(0);
			this.namePanel.Name = "namePanel";
			this.namePanel.RowCount = 2;
			this.namePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.namePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.namePanel.Size = new System.Drawing.Size(358, 38);
			this.namePanel.TabIndex = 18;
			// 
			// genNameTxt
			// 
			this.genNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.genNameTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.genNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.genNameTxt.Lines = new string[0];
			this.genNameTxt.Location = new System.Drawing.Point(100, 39);
			this.genNameTxt.MaxLength = 32767;
			this.genNameTxt.Name = "genNameTxt";
			this.genNameTxt.PasswordChar = '\0';
			this.genNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.genNameTxt.SelectedText = "";
			this.genNameTxt.Size = new System.Drawing.Size(255, 30);
			this.genNameTxt.TabIndex = 18;
			this.genNameTxt.UseSelectable = true;
			// 
			// orderCbx
			// 
			this.orderCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.orderCbx.DisplayMember = "Value";
			this.orderCbx.FormattingEnabled = true;
			this.orderCbx.ItemHeight = 24;
			this.orderCbx.Location = new System.Drawing.Point(100, 3);
			this.orderCbx.Name = "orderCbx";
			this.orderCbx.Size = new System.Drawing.Size(255, 30);
			this.orderCbx.TabIndex = 17;
			this.orderCbx.UseSelectable = true;
			this.orderCbx.ValueMember = "Key";
			this.orderCbx.SelectedIndexChanged += new System.EventHandler(this.OnOrderCbxSelectionChanged);
			// 
			// orderCodeLbl
			// 
			this.orderCodeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.orderCodeLbl.AutoSize = true;
			this.orderCodeLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.orderCodeLbl.Location = new System.Drawing.Point(4, 8);
			this.orderCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.orderCodeLbl.Name = "orderCodeLbl";
			this.orderCodeLbl.Size = new System.Drawing.Size(89, 20);
			this.orderCodeLbl.TabIndex = 20;
			this.orderCodeLbl.Text = "订单条码：";
			// 
			// genNameLbl
			// 
			this.genNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.genNameLbl.AutoSize = true;
			this.genNameLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.genNameLbl.Location = new System.Drawing.Point(4, 44);
			this.genNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.genNameLbl.Name = "genNameLbl";
			this.genNameLbl.Size = new System.Drawing.Size(89, 20);
			this.genNameLbl.TabIndex = 21;
			this.genNameLbl.Text = "打包名称：";
			// 
			// isSplitCbx
			// 
			this.isSplitCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.isSplitCbx.DisplayMember = "Value";
			this.isSplitCbx.FormattingEnabled = true;
			this.isSplitCbx.ItemHeight = 24;
			this.isSplitCbx.Location = new System.Drawing.Point(100, 85);
			this.isSplitCbx.Name = "isSplitCbx";
			this.isSplitCbx.Size = new System.Drawing.Size(255, 30);
			this.isSplitCbx.TabIndex = 14;
			this.isSplitCbx.UseSelectable = true;
			this.isSplitCbx.ValueMember = "Key";
			this.isSplitCbx.SelectedIndexChanged += new System.EventHandler(this.OnSelectionSplitSetSelectionChanged);
			// 
			// packageTypeCbx
			// 
			this.packageTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packageTypeCbx.DisplayMember = "Value";
			this.packageTypeCbx.FormattingEnabled = true;
			this.packageTypeCbx.ItemHeight = 24;
			this.packageTypeCbx.Location = new System.Drawing.Point(464, 85);
			this.packageTypeCbx.Name = "packageTypeCbx";
			this.packageTypeCbx.Size = new System.Drawing.Size(255, 30);
			this.packageTypeCbx.TabIndex = 16;
			this.packageTypeCbx.UseSelectable = true;
			this.packageTypeCbx.ValueMember = "Key";
			this.packageTypeCbx.SelectedIndexChanged += new System.EventHandler(this.OnPackageTypeSelectioChanged);
			// 
			// buttonPanel
			// 
			this.buttonPanel.ColumnCount = 1;
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Controls.Add(this.generateBtn, 0, 0);
			this.buttonPanel.Controls.Add(this.submitBtn, 0, 1);
			this.buttonPanel.Controls.Add(this.cancelBtn, 0, 3);
			this.buttonPanel.Controls.Add(this.printBtn, 0, 2);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPanel.Location = new System.Drawing.Point(912, 0);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.RowCount = 5;
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 384F));
			this.buttonPanel.Size = new System.Drawing.Size(96, 603);
			this.buttonPanel.TabIndex = 3;
			// 
			// generateBtn
			// 
			this.generateBtn.ActiveControl = null;
			this.generateBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.generateBtn.Location = new System.Drawing.Point(3, 13);
			this.generateBtn.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
			this.generateBtn.Name = "generateBtn";
			this.generateBtn.Size = new System.Drawing.Size(90, 40);
			this.generateBtn.TabIndex = 31;
			this.generateBtn.Text = "生 成 ";
			this.generateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.generateBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.generateBtn.UseSelectable = true;
			this.generateBtn.UseTileImage = true;
			this.generateBtn.Click += new System.EventHandler(this.OnGeneratorButtonClick);
			// 
			// submitBtn
			// 
			this.submitBtn.ActiveControl = null;
			this.submitBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.submitBtn.Location = new System.Drawing.Point(3, 59);
			this.submitBtn.Name = "submitBtn";
			this.submitBtn.Size = new System.Drawing.Size(90, 40);
			this.submitBtn.TabIndex = 32;
			this.submitBtn.Text = "提 交 ";
			this.submitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.submitBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.submitBtn.UseSelectable = true;
			this.submitBtn.UseTileImage = true;
			this.submitBtn.Visible = false;
			this.submitBtn.Click += new System.EventHandler(this.OnCommitButtonClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(3, 151);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 34;
			this.cancelBtn.Text = "关闭 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.OnCloseBtnClick);
			// 
			// printBtn
			// 
			this.printBtn.ActiveControl = null;
			this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printBtn.Location = new System.Drawing.Point(3, 105);
			this.printBtn.Name = "printBtn";
			this.printBtn.Size = new System.Drawing.Size(90, 40);
			this.printBtn.TabIndex = 33;
			this.printBtn.Text = "打 印 ";
			this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.printBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printBtn.UseSelectable = true;
			this.printBtn.UseTileImage = true;
			this.printBtn.Click += new System.EventHandler(this.OnPrintButtonClick);
			// 
			// HCSWF_specialset_packing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "HCSWF_specialset_packing";
			this.Size = new System.Drawing.Size(1008, 603);
			this.dataGridContextMenu.ResumeLayout(false);
			this.mainPanel.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.groupPanel.ResumeLayout(false);
			this.groupPanel.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.namePanel.ResumeLayout(false);
			this.namePanel.PerformLayout();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.DataGridView dataGrid;
		private CnasMetroFramework.Controls.MetroComboBox orderCbx;
		private System.Windows.Forms.ToolStripMenuItem tsm_bcuprint;
		private CnasMetroFramework.Controls.MetroContextMenu dataGridContextMenu;
		private ToolStripMenuItem gridDeleteBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private CnasMetroFramework.Controls.MetroTile generateBtn;
		private CnasMetroFramework.Controls.MetroTile submitBtn;
		private CnasMetroFramework.Controls.MetroTile printBtn;
		private TableLayoutPanel groupPanel;
		private CnasMetroFramework.Controls.MetroTextBox packUserTxt;
		private CnasMetroFramework.Controls.MetroTextBox cfmUserTxt;
		private GroupBox groupBox;
		private CnasMetroFramework.Controls.MetroTextBox genNumTxt;
		private TableLayoutPanel namePanel;
		private CnasMetroFramework.Controls.MetroTextBox genNameTxt;
		private Label label1;
		private Label cfmUserLbl;
		private Label genNumLbl;
		private Label genNameLbl;
		private RadioButton batchBCU;
		private RadioButton batchBCUR;
		private CnasMetroFramework.Controls.MetroComboBox uselocationCbx;
		private CnasMetroFramework.Controls.MetroComboBox customerCbx;
		private Label customerLbl;
		private Label useNameLbl;
		private GroupBox groupBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label materialLbl;
		private CnasMetroFramework.Controls.MetroComboBox materialCbx;
		private Label packTypeLbl;
		private CnasMetroFramework.Controls.MetroTextBox expireDateTxt;
		private DataGridViewTextBoxColumn idCol;
		private DataGridViewTextBoxColumn tempCodeCol;
		private DataGridViewTextBoxColumn pbCodeCol;
		private DataGridViewTextBoxColumn setNameCol;
		private DataGridViewTextBoxColumn useLocationCol;
		private DataGridViewTextBoxColumn creDateCol;
		private DataGridViewTextBoxColumn expireDateCol;
		private DataGridViewTextBoxColumn batchCol;
		private TableLayoutPanel tableLayoutPanel2;
		private CnasMetroFramework.Controls.MetroComboBox packTypeCbx;
		private Label messageLbl;
		private Label packageTypeLbl;
		private Label isSimgleLbl;
		private CnasMetroFramework.Controls.MetroComboBox isSplitCbx;
		private CnasMetroFramework.Controls.MetroComboBox packageTypeCbx;
		private Label orderCodeLbl;
	}
}
