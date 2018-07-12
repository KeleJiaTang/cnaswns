namespace Cnas.wns.CnasHCSReport
{
	partial class HCSRS_common_dialog
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
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.endTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
			this.startTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
			this.searchTypeCbx = new Telerik.WinControls.UI.RadDropDownList();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.searchType = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.bnt_print = new Telerik.WinControls.UI.RadButton();
			this.but_sel = new Telerik.WinControls.UI.RadButton();
			this.bnt_cancel = new Telerik.WinControls.UI.RadButton();
			this.dgv = new Telerik.WinControls.UI.RadGridView();
			((System.ComponentModel.ISupportInitialize)(this.endTimePicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startTimePicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.searchTypeCbx)).BeginInit();
			this.mainPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnt_print)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bnt_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// endTimePicker
			// 
			this.endTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.endTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.endTimePicker.Location = new System.Drawing.Point(406, 44);
			this.endTimePicker.MinDate = new System.DateTime(1970, 1, 2, 0, 0, 0, 0);
			this.endTimePicker.Name = "endTimePicker";
			this.endTimePicker.Size = new System.Drawing.Size(199, 25);
			this.endTimePicker.TabIndex = 3;
			this.endTimePicker.TabStop = false;
			this.endTimePicker.ThemeName = "Office2007Silver";
			this.endTimePicker.Value = new System.DateTime(1970, 1, 2, 0, 0, 0, 0);
			this.endTimePicker.ValueChanged += new System.EventHandler(this.cb_indicator_TextChanged);
			// 
			// startTimePicker
			// 
			this.startTimePicker.CustomFormat = "yyyy年MM月dd日 HH:mm";
			this.startTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.startTimePicker.Location = new System.Drawing.Point(105, 44);
			this.startTimePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
			this.startTimePicker.Name = "startTimePicker";
			this.startTimePicker.Size = new System.Drawing.Size(200, 25);
			this.startTimePicker.TabIndex = 2;
			this.startTimePicker.TabStop = false;
			this.startTimePicker.ThemeName = "Office2007Silver";
			this.startTimePicker.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
			this.startTimePicker.ValueChanged += new System.EventHandler(this.cb_indicator_TextChanged);
			// 
			// searchTypeCbx
			// 
			this.searchTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.searchTypeCbx.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.searchTypeCbx.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.searchTypeCbx.Location = new System.Drawing.Point(105, 13);
			this.searchTypeCbx.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.searchTypeCbx.Name = "searchTypeCbx";
			this.searchTypeCbx.Size = new System.Drawing.Size(200, 25);
			this.searchTypeCbx.TabIndex = 1;
			this.searchTypeCbx.ThemeName = "Office2007Silver";
			this.searchTypeCbx.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.searchTypeCbx_SelectedIndexChanged);
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 4;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.startTimePicker, 1, 1);
			this.mainPanel.Controls.Add(this.endTimePicker, 3, 1);
			this.mainPanel.Controls.Add(this.searchTypeCbx, 1, 0);
			this.mainPanel.Controls.Add(this.searchType, 0, 0);
			this.mainPanel.Controls.Add(this.label2, 0, 1);
			this.mainPanel.Controls.Add(this.label3, 2, 1);
			this.mainPanel.Controls.Add(this.tableLayoutPanel1, 0, 2);
			this.mainPanel.Controls.Add(this.dgv, 3, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 3;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(610, 119);
			this.mainPanel.TabIndex = 6;
			// 
			// searchType
			// 
			this.searchType.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.searchType.AutoSize = true;
			this.searchType.Location = new System.Drawing.Point(10, 14);
			this.searchType.Margin = new System.Windows.Forms.Padding(10, 8, 3, 0);
			this.searchType.Name = "searchType";
			this.searchType.Size = new System.Drawing.Size(89, 20);
			this.searchType.TabIndex = 6;
			this.searchType.Text = "查询方式：";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "开始时间：";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(311, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "结束时间：";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.mainPanel.SetColumnSpan(this.tableLayoutPanel1, 4);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.bnt_print, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.but_sel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.bnt_cancel, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 72);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 47);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// bnt_print
			// 
			this.bnt_print.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bnt_print.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.bnt_print.Location = new System.Drawing.Point(255, 3);
			this.bnt_print.Name = "bnt_print";
			this.bnt_print.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.bnt_print.Size = new System.Drawing.Size(99, 41);
			this.bnt_print.TabIndex = 5;
			this.bnt_print.Text = "打  印        ";
			this.bnt_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.bnt_print.ThemeName = "Office2007Silver";
			this.bnt_print.Visible = false;
			this.bnt_print.Click += new System.EventHandler(this.bnt_print_Click);
			// 
			// but_sel
			// 
			this.but_sel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.but_sel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_sel.Location = new System.Drawing.Point(128, 3);
			this.but_sel.Name = "but_sel";
			this.but_sel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_sel.Size = new System.Drawing.Size(99, 41);
			this.but_sel.TabIndex = 4;
			this.but_sel.Text = "查  询";
			this.but_sel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_sel.ThemeName = "Office2007Silver";
			this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
			// 
			// bnt_cancel
			// 
			this.bnt_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.bnt_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.bnt_cancel.Location = new System.Drawing.Point(383, 3);
			this.bnt_cancel.Name = "bnt_cancel";
			this.bnt_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.bnt_cancel.Size = new System.Drawing.Size(99, 41);
			this.bnt_cancel.TabIndex = 6;
			this.bnt_cancel.Text = "关  闭";
			this.bnt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.bnt_cancel.ThemeName = "Office2007Silver";
			this.bnt_cancel.Click += new System.EventHandler(this.bnt_cancel_Click);
			// 
			// dgv
			// 
			this.dgv.Location = new System.Drawing.Point(406, 3);
			// 
			// 
			// 
			this.dgv.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(199, 35);
			this.dgv.TabIndex = 10;
			this.dgv.Text = "dgv";
			this.dgv.Visible = false;
			// 
			// HCSRS_common_dialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(610, 119);
			this.Controls.Add(this.mainPanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSRS_common_dialog";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "HCSRS_CleanFail";
			this.Load += new System.EventHandler(this.HCSRS_common_dialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.endTimePicker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startTimePicker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.searchTypeCbx)).EndInit();
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bnt_print)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_sel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bnt_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Telerik.WinControls.UI.RadDateTimePicker endTimePicker;
		private Telerik.WinControls.UI.RadDateTimePicker startTimePicker;
		private Telerik.WinControls.UI.RadDropDownList searchTypeCbx;
		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.Label searchType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton bnt_cancel;
        private Telerik.WinControls.UI.RadButton bnt_print;
        private Telerik.WinControls.UI.RadButton but_sel;
        private Telerik.WinControls.UI.RadGridView dgv;
        
	}
}