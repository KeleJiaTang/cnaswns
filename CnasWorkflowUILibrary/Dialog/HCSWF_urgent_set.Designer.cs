namespace Cnas.wns.CnasWorkflowUILibrary.Dialog
{
    partial class HCSWF_urgent_set
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.urgentBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.setDataGrid = new System.Windows.Forms.DataGridView();
			this.setIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setBarCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.setNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wf_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.urgentTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.washingPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sterilizerPCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costCNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.selBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.label2 = new System.Windows.Forms.Label();
			this.selNameTxt = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.customerCbx = new System.Windows.Forms.ComboBox();
			this.carNameLbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.locationCbx = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 772F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.setDataGrid, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 53);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 482);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.69633F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.30367F));
			this.tableLayoutPanel2.Controls.Add(this.closeBtn, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.urgentBtn, 1, 0);
			this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(775, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(94, 99);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.closeBtn.Location = new System.Drawing.Point(2, 57);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(2);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 5;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// urgentBtn
			// 
			this.urgentBtn.ActiveControl = null;
			this.urgentBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.urgentBtn.Location = new System.Drawing.Point(2, 10);
			this.urgentBtn.Margin = new System.Windows.Forms.Padding(2);
			this.urgentBtn.Name = "urgentBtn";
			this.urgentBtn.Size = new System.Drawing.Size(90, 37);
			this.urgentBtn.TabIndex = 4;
			this.urgentBtn.Text = "加急";
			this.urgentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.urgentBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.urgentBtn.UseSelectable = true;
			this.urgentBtn.UseTileImage = true;
			this.urgentBtn.Click += new System.EventHandler(this.urgentBtn_Click);
			// 
			// setDataGrid
			// 
			this.setDataGrid.AllowUserToAddRows = false;
			this.setDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.setDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.setDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setIdCol,
            this.setBarCodeCol,
            this.setNameCol,
            this.wf_name,
            this.p_name,
            this.urgentTypeCol,
            this.washingPCol,
            this.sterilizerPCol,
            this.costCNameCol});
			this.setDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setDataGrid.Location = new System.Drawing.Point(0, 105);
			this.setDataGrid.Margin = new System.Windows.Forms.Padding(0);
			this.setDataGrid.Name = "setDataGrid";
			this.setDataGrid.RowHeadersVisible = false;
			this.setDataGrid.RowTemplate.Height = 23;
			this.setDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.setDataGrid.Size = new System.Drawing.Size(772, 377);
			this.setDataGrid.TabIndex = 4;
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
			this.setBarCodeCol.HeaderText = "器械包条码";
			this.setBarCodeCol.MinimumWidth = 120;
			this.setBarCodeCol.Name = "setBarCodeCol";
			this.setBarCodeCol.ReadOnly = true;
			this.setBarCodeCol.Width = 200;
			// 
			// setNameCol
			// 
			this.setNameCol.HeaderText = "器械包名称";
			this.setNameCol.MinimumWidth = 120;
			this.setNameCol.Name = "setNameCol";
			this.setNameCol.ReadOnly = true;
			this.setNameCol.Width = 200;
			// 
			// wf_name
			// 
			this.wf_name.HeaderText = "待执行流程";
			this.wf_name.Name = "wf_name";
			this.wf_name.Width = 120;
			// 
			// p_name
			// 
			this.p_name.HeaderText = "紧急情况";
			this.p_name.Name = "p_name";
			this.p_name.Width = 120;
			// 
			// urgentTypeCol
			// 
			this.urgentTypeCol.HeaderText = "单次加急";
			this.urgentTypeCol.MinimumWidth = 120;
			this.urgentTypeCol.Name = "urgentTypeCol";
			this.urgentTypeCol.ReadOnly = true;
			this.urgentTypeCol.Visible = false;
			this.urgentTypeCol.Width = 120;
			// 
			// washingPCol
			// 
			this.washingPCol.HeaderText = "清洗程序";
			this.washingPCol.MinimumWidth = 100;
			this.washingPCol.Name = "washingPCol";
			this.washingPCol.ReadOnly = true;
			this.washingPCol.Visible = false;
			this.washingPCol.Width = 150;
			// 
			// sterilizerPCol
			// 
			this.sterilizerPCol.HeaderText = "灭菌程序";
			this.sterilizerPCol.MinimumWidth = 100;
			this.sterilizerPCol.Name = "sterilizerPCol";
			this.sterilizerPCol.ReadOnly = true;
			this.sterilizerPCol.Visible = false;
			this.sterilizerPCol.Width = 150;
			// 
			// costCNameCol
			// 
			this.costCNameCol.HeaderText = "成本中心";
			this.costCNameCol.MinimumWidth = 100;
			this.costCNameCol.Name = "costCNameCol";
			this.costCNameCol.ReadOnly = true;
			this.costCNameCol.Width = 120;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel5);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(766, 99);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.Controls.Add(this.selBtn, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 0);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Font = new System.Drawing.Font("宋体", 11F);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 23);
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(760, 73);
			this.tableLayoutPanel5.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.selNameTxt, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 36);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(666, 37);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// selBtn
			// 
			this.selBtn.ActiveControl = null;
			this.selBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.selBtn.Location = new System.Drawing.Point(669, 39);
			this.selBtn.Name = "selBtn";
			this.selBtn.Size = new System.Drawing.Size(88, 30);
			this.selBtn.TabIndex = 25;
			this.selBtn.Text = "查询";
			this.selBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.selBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.selBtn.UseSelectable = true;
			this.selBtn.UseTileImage = true;
			this.selBtn.Click += new System.EventHandler(this.selBtn_Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 8);
			this.label2.Margin = new System.Windows.Forms.Padding(3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "名        称：";
			// 
			// selNameTxt
			// 
			this.selNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.selNameTxt.Location = new System.Drawing.Point(98, 3);
			this.selNameTxt.Name = "selNameTxt";
			this.selNameTxt.Size = new System.Drawing.Size(565, 27);
			this.selNameTxt.TabIndex = 3;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 4;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Controls.Add(this.customerCbx, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.carNameLbl, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.locationCbx, 3, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(666, 36);
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// customerCbx
			// 
			this.customerCbx.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.customerCbx.DisplayMember = "Value";
			this.customerCbx.FormattingEnabled = true;
			this.customerCbx.Location = new System.Drawing.Point(98, 4);
			this.customerCbx.Name = "customerCbx";
			this.customerCbx.Size = new System.Drawing.Size(233, 28);
			this.customerCbx.TabIndex = 1;
			this.customerCbx.ValueMember = "key";
			this.customerCbx.SelectedIndexChanged += new System.EventHandler(this.customerCbx_SelectedIndexChanged);
			// 
			// carNameLbl
			// 
			this.carNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.carNameLbl.AutoSize = true;
			this.carNameLbl.Location = new System.Drawing.Point(3, 8);
			this.carNameLbl.Margin = new System.Windows.Forms.Padding(3);
			this.carNameLbl.Name = "carNameLbl";
			this.carNameLbl.Size = new System.Drawing.Size(89, 20);
			this.carNameLbl.TabIndex = 5;
			this.carNameLbl.Text = "客        户：";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(347, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "使用地点:";
			// 
			// locationCbx
			// 
			this.locationCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.locationCbx.DisplayMember = "Value";
			this.locationCbx.FormattingEnabled = true;
			this.locationCbx.Location = new System.Drawing.Point(429, 4);
			this.locationCbx.Name = "locationCbx";
			this.locationCbx.Size = new System.Drawing.Size(234, 28);
			this.locationCbx.TabIndex = 2;
			this.locationCbx.ValueMember = "Key";
			this.locationCbx.SelectedValueChanged += new System.EventHandler(this.locationCbx_SelectedValueChanged);
			// 
			// HCSWF_urgent_set
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("宋体", 9F);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSWF_urgent_set";
			this.Text = "单次加急";
			this.Load += new System.EventHandler(this.LoadFormExecution);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.setDataGrid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView setDataGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox selNameTxt;
        private System.Windows.Forms.Label carNameLbl;
        private System.Windows.Forms.Label label1;
        private CnasMetroFramework.Controls.MetroTile selBtn;
        private CnasMetroFramework.Controls.MetroTile closeBtn;
        private CnasMetroFramework.Controls.MetroTile urgentBtn;
        private System.Windows.Forms.ComboBox customerCbx;
        private System.Windows.Forms.ComboBox locationCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn setIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn setBarCodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn setNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn wf_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn urgentTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn washingPCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sterilizerPCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn costCNameCol;
    }
}