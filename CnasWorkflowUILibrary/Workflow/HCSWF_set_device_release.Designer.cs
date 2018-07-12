namespace Cnas.wns.CnasWorkflowUILibrary
{
    partial class HCSWF_set_device_release
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
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setPriortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setUseLoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.washingPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sterilizerPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.packageBatchPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lbUser = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.lbBatch = new System.Windows.Forms.Label();
			this.txtBatch = new System.Windows.Forms.TextBox();
			this.setNumTxt = new System.Windows.Forms.TextBox();
			this.txtBatchEndDate = new System.Windows.Forms.DateTimePicker();
			this.setNumLbl = new System.Windows.Forms.Label();
			this.lbBatchEndDate = new System.Windows.Forms.Label();
			this.txtBatchStartDate = new System.Windows.Forms.DateTimePicker();
			this.txtCreateDate = new System.Windows.Forms.DateTimePicker();
			this.lbBatchStart = new System.Windows.Forms.Label();
			this.machineTxt = new System.Windows.Forms.TextBox();
			this.lbCreateDate = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbProgram = new System.Windows.Forms.Label();
			this.txtProgram = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.yesReleaseBtn = new Telerik.WinControls.UI.RadRadioButton();
			this.noReleaseBtn = new Telerik.WinControls.UI.RadRadioButton();
			this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.packageBatchPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.yesReleaseBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noReleaseBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
			this.SuspendLayout();
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 1;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.setDataGrid, 0, 1);
			this.leftPanel.Controls.Add(this.packageBatchPanel, 0, 0);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 2;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.Size = new System.Drawing.Size(895, 586);
			this.leftPanel.TabIndex = 0;
			// 
			// setDataGrid
			// 
			this.setDataGrid.AllowUserToAddRows = false;
			this.setDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.setDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.setDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.setDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setIdCol,
            this.setBarCodeCol,
            this.setNameCol,
            this.setTypeCol,
            this.setPriortyCol,
            this.setUseLoCol,
            this.washingPCol,
            this.sterilizerPCol,
            this.costCNameCol});
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 205);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.ReadOnly = true;
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(895, 381);
			this.setDataGrid.TabIndex = 10;
			// 
			// setIdCol
			// 
			this.setIdCol.HeaderText = "编号";
			this.setIdCol.MinimumWidth = 70;
			this.setIdCol.Name = "setIdCol";
			this.setIdCol.ReadOnly = true;
			this.setIdCol.Visible = false;
			this.setIdCol.Width = 70;
			// 
			// setBarCodeCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setBarCodeCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 120;
			// 
			// setNameCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setNameCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 200;
			// 
			// setTypeCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setTypeCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.setTypeCol.HeaderText = "器械包类型";
			this.setTypeCol.MinimumWidth = 120;
			this.setTypeCol.Name = "setTypeCol";
			this.setTypeCol.ReadOnly = true;
			this.setTypeCol.Width = 120;
			// 
			// setPriortyCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setPriortyCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.setPriortyCol.HeaderText = "优先级";
			this.setPriortyCol.MinimumWidth = 80;
			this.setPriortyCol.Name = "setPriortyCol";
			this.setPriortyCol.ReadOnly = true;
			// 
			// setUseLoCol
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.setUseLoCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.setUseLoCol.HeaderText = "使用地点";
			this.setUseLoCol.MinimumWidth = 100;
			this.setUseLoCol.Name = "setUseLoCol";
			this.setUseLoCol.ReadOnly = true;
			// 
			// washingPCol
			// 
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.washingPCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			this.washingPCol.Width = 180;
			// 
			// sterilizerPCol
			// 
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.sterilizerPCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			this.sterilizerPCol.Width = 180;
			// 
			// costCNameCol
			// 
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.costCNameCol.DefaultCellStyle = dataGridViewCellStyle8;
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Width = 180;
			// 
			// packageBatchPanel
			// 
			this.packageBatchPanel.ColumnCount = 4;
			this.packageBatchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.packageBatchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.packageBatchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.packageBatchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.packageBatchPanel.Controls.Add(this.lbUser, 0, 0);
			this.packageBatchPanel.Controls.Add(this.userNameTxt, 1, 0);
			this.packageBatchPanel.Controls.Add(this.lbBatch, 0, 4);
			this.packageBatchPanel.Controls.Add(this.txtBatch, 1, 4);
			this.packageBatchPanel.Controls.Add(this.setNumTxt, 3, 4);
			this.packageBatchPanel.Controls.Add(this.txtBatchEndDate, 3, 3);
			this.packageBatchPanel.Controls.Add(this.setNumLbl, 2, 4);
			this.packageBatchPanel.Controls.Add(this.lbBatchEndDate, 2, 3);
			this.packageBatchPanel.Controls.Add(this.txtBatchStartDate, 1, 3);
			this.packageBatchPanel.Controls.Add(this.txtCreateDate, 1, 2);
			this.packageBatchPanel.Controls.Add(this.lbBatchStart, 0, 3);
			this.packageBatchPanel.Controls.Add(this.machineTxt, 1, 1);
			this.packageBatchPanel.Controls.Add(this.lbCreateDate, 0, 2);
			this.packageBatchPanel.Controls.Add(this.label1, 0, 1);
			this.packageBatchPanel.Controls.Add(this.lbProgram, 2, 1);
			this.packageBatchPanel.Controls.Add(this.txtProgram, 3, 1);
			this.packageBatchPanel.Controls.Add(this.tableLayoutPanel1, 2, 5);
			this.packageBatchPanel.Controls.Add(this.radLabel1, 1, 5);
			this.packageBatchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.packageBatchPanel.Location = new System.Drawing.Point(0, 0);
			this.packageBatchPanel.Margin = new System.Windows.Forms.Padding(0);
			this.packageBatchPanel.Name = "packageBatchPanel";
			this.packageBatchPanel.RowCount = 6;
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.packageBatchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.packageBatchPanel.Size = new System.Drawing.Size(895, 205);
			this.packageBatchPanel.TabIndex = 1;
			// 
			// lbUser
			// 
			this.lbUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbUser.AutoSize = true;
			this.lbUser.Location = new System.Drawing.Point(8, 6);
			this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 7, 0);
			this.lbUser.Name = "lbUser";
			this.lbUser.Size = new System.Drawing.Size(85, 20);
			this.lbUser.TabIndex = 5;
			this.lbUser.Text = "用       户：";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packageBatchPanel.SetColumnSpan(this.userNameTxt, 3);
			this.userNameTxt.Location = new System.Drawing.Point(103, 3);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.ReadOnly = true;
			this.userNameTxt.Size = new System.Drawing.Size(789, 27);
			this.userNameTxt.TabIndex = 1;
			// 
			// lbBatch
			// 
			this.lbBatch.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbBatch.AutoSize = true;
			this.lbBatch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lbBatch.Location = new System.Drawing.Point(7, 140);
			this.lbBatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbBatch.Name = "lbBatch";
			this.lbBatch.Size = new System.Drawing.Size(89, 20);
			this.lbBatch.TabIndex = 1;
			this.lbBatch.Text = "释放批次：";
			// 
			// txtBatch
			// 
			this.txtBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBatch.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this.txtBatch.Location = new System.Drawing.Point(103, 135);
			this.txtBatch.Name = "txtBatch";
			this.txtBatch.ReadOnly = true;
			this.txtBatch.Size = new System.Drawing.Size(336, 31);
			this.txtBatch.TabIndex = 10;
			this.txtBatch.Text = "888";
			this.txtBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// setNumTxt
			// 
			this.setNumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNumTxt.BackColor = System.Drawing.SystemColors.Control;
			this.setNumTxt.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.setNumTxt.Location = new System.Drawing.Point(555, 135);
			this.setNumTxt.Name = "setNumTxt";
			this.setNumTxt.ReadOnly = true;
			this.setNumTxt.Size = new System.Drawing.Size(337, 31);
			this.setNumTxt.TabIndex = 7;
			this.setNumTxt.Text = "0";
			this.setNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtBatchEndDate
			// 
			this.txtBatchEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBatchEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.txtBatchEndDate.Enabled = false;
			this.txtBatchEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtBatchEndDate.Location = new System.Drawing.Point(555, 102);
			this.txtBatchEndDate.Name = "txtBatchEndDate";
			this.txtBatchEndDate.Size = new System.Drawing.Size(337, 27);
			this.txtBatchEndDate.TabIndex = 6;
			// 
			// setNumLbl
			// 
			this.setNumLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setNumLbl.AutoSize = true;
			this.setNumLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.setNumLbl.Location = new System.Drawing.Point(459, 140);
			this.setNumLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.setNumLbl.Name = "setNumLbl";
			this.setNumLbl.Size = new System.Drawing.Size(89, 20);
			this.setNumLbl.TabIndex = 11;
			this.setNumLbl.Text = "数        量：";
			// 
			// lbBatchEndDate
			// 
			this.lbBatchEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbBatchEndDate.AutoSize = true;
			this.lbBatchEndDate.Location = new System.Drawing.Point(459, 105);
			this.lbBatchEndDate.Margin = new System.Windows.Forms.Padding(17, 0, 4, 0);
			this.lbBatchEndDate.Name = "lbBatchEndDate";
			this.lbBatchEndDate.Size = new System.Drawing.Size(89, 20);
			this.lbBatchEndDate.TabIndex = 7;
			this.lbBatchEndDate.Text = "结束时间：";
			// 
			// txtBatchStartDate
			// 
			this.txtBatchStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBatchStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.txtBatchStartDate.Enabled = false;
			this.txtBatchStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtBatchStartDate.Location = new System.Drawing.Point(103, 102);
			this.txtBatchStartDate.Name = "txtBatchStartDate";
			this.txtBatchStartDate.Size = new System.Drawing.Size(336, 27);
			this.txtBatchStartDate.TabIndex = 5;
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.packageBatchPanel.SetColumnSpan(this.txtCreateDate, 3);
			this.txtCreateDate.CustomFormat = "yyyy-MM-dd";
			this.txtCreateDate.Enabled = false;
			this.txtCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtCreateDate.Location = new System.Drawing.Point(103, 69);
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.Size = new System.Drawing.Size(789, 27);
			this.txtCreateDate.TabIndex = 4;
			// 
			// lbBatchStart
			// 
			this.lbBatchStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbBatchStart.AutoSize = true;
			this.lbBatchStart.Location = new System.Drawing.Point(4, 105);
			this.lbBatchStart.Margin = new System.Windows.Forms.Padding(4, 0, 7, 0);
			this.lbBatchStart.Name = "lbBatchStart";
			this.lbBatchStart.Size = new System.Drawing.Size(89, 20);
			this.lbBatchStart.TabIndex = 3;
			this.lbBatchStart.Text = "开始时间：";
			// 
			// machineTxt
			// 
			this.machineTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.machineTxt.BackColor = System.Drawing.SystemColors.Control;
			this.machineTxt.Location = new System.Drawing.Point(103, 36);
			this.machineTxt.Name = "machineTxt";
			this.machineTxt.ReadOnly = true;
			this.machineTxt.Size = new System.Drawing.Size(336, 27);
			this.machineTxt.TabIndex = 2;
			// 
			// lbCreateDate
			// 
			this.lbCreateDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbCreateDate.AutoSize = true;
			this.lbCreateDate.Location = new System.Drawing.Point(4, 72);
			this.lbCreateDate.Margin = new System.Windows.Forms.Padding(4, 0, 7, 0);
			this.lbCreateDate.Name = "lbCreateDate";
			this.lbCreateDate.Size = new System.Drawing.Size(89, 20);
			this.lbCreateDate.TabIndex = 5;
			this.lbCreateDate.Text = "生产日期：";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 7, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "机器名称：";
			// 
			// lbProgram
			// 
			this.lbProgram.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbProgram.AutoSize = true;
			this.lbProgram.Location = new System.Drawing.Point(459, 39);
			this.lbProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbProgram.Name = "lbProgram";
			this.lbProgram.Size = new System.Drawing.Size(89, 20);
			this.lbProgram.TabIndex = 9;
			this.lbProgram.Text = "程序名称：";
			// 
			// txtProgram
			// 
			this.txtProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProgram.BackColor = System.Drawing.SystemColors.Control;
			this.txtProgram.Location = new System.Drawing.Point(555, 36);
			this.txtProgram.Name = "txtProgram";
			this.txtProgram.ReadOnly = true;
			this.txtProgram.Size = new System.Drawing.Size(337, 27);
			this.txtProgram.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.packageBatchPanel.SetColumnSpan(this.tableLayoutPanel1, 2);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.yesReleaseBtn, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.noReleaseBtn, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(442, 169);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(453, 36);
			this.tableLayoutPanel1.TabIndex = 19;
			// 
			// yesReleaseBtn
			// 
			this.yesReleaseBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.yesReleaseBtn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.yesReleaseBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this.yesReleaseBtn.Location = new System.Drawing.Point(60, 4);
			this.yesReleaseBtn.Margin = new System.Windows.Forms.Padding(60, 0, 18, 0);
			this.yesReleaseBtn.Name = "yesReleaseBtn";
			this.yesReleaseBtn.Size = new System.Drawing.Size(41, 27);
			this.yesReleaseBtn.TabIndex = 8;
			this.yesReleaseBtn.Text = "是";
			this.yesReleaseBtn.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
			// 
			// noReleaseBtn
			// 
			this.noReleaseBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.noReleaseBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this.noReleaseBtn.Location = new System.Drawing.Point(124, 4);
			this.noReleaseBtn.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.noReleaseBtn.Name = "noReleaseBtn";
			this.noReleaseBtn.Size = new System.Drawing.Size(41, 27);
			this.noReleaseBtn.TabIndex = 9;
			this.noReleaseBtn.TabStop = false;
			this.noReleaseBtn.Text = "否";
			// 
			// radLabel1
			// 
			this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 13F);
			this.radLabel1.Location = new System.Drawing.Point(356, 173);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new System.Drawing.Size(83, 27);
			this.radLabel1.TabIndex = 20;
			this.radLabel1.Text = "是否释放：";
			this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// HCSWF_set_device_release
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftPanel);
			this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "HCSWF_set_device_release";
			this.Size = new System.Drawing.Size(895, 586);
			this.leftPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.packageBatchPanel.ResumeLayout(false);
			this.packageBatchPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.yesReleaseBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noReleaseBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbUser;
		private System.Windows.Forms.TextBox userNameTxt;
		private System.Windows.Forms.TextBox machineTxt;
		private System.Windows.Forms.TableLayoutPanel packageBatchPanel;
		private System.Windows.Forms.Label lbCreateDate;
		private System.Windows.Forms.Label lbBatchStart;
		private System.Windows.Forms.Label lbBatchEndDate;
		private System.Windows.Forms.TextBox txtProgram;
		private System.Windows.Forms.Label lbProgram;
		private System.Windows.Forms.DateTimePicker txtBatchStartDate;
		private System.Windows.Forms.DateTimePicker txtBatchEndDate;
		private System.Windows.Forms.DateTimePicker txtCreateDate;
		private System.Windows.Forms.DataGridView setDataGrid;
		private System.Windows.Forms.Label lbBatch;
		private System.Windows.Forms.TextBox txtBatch;
		private System.Windows.Forms.TextBox setNumTxt;
		private System.Windows.Forms.Label setNumLbl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private Telerik.WinControls.UI.RadRadioButton yesReleaseBtn;
		private Telerik.WinControls.UI.RadRadioButton noReleaseBtn;
		private Telerik.WinControls.UI.RadLabel radLabel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setPriortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn setUseLoCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn washingPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;



	}
}