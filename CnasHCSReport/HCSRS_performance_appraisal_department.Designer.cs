namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_performance_appraisal_department
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
			this.sp_main = new System.Windows.Forms.SplitContainer();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_list = new Telerik.WinControls.UI.RadButton();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.cb_department = new Telerik.WinControls.UI.RadDropDownList();
			this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
			this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
			this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
			this.dt_start = new Telerik.WinControls.UI.RadDateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.dt_end = new Telerik.WinControls.UI.RadDateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
			this.sp_main.Panel1.SuspendLayout();
			this.sp_main.Panel2.SuspendLayout();
			this.sp_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_list)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_department)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dt_start)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_end)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// sp_main
			// 
			this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sp_main.Location = new System.Drawing.Point(0, 0);
			this.sp_main.Name = "sp_main";
			this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sp_main.Panel1
			// 
			this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
			this.sp_main.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// sp_main.Panel2
			// 
			this.sp_main.Panel2.BackColor = System.Drawing.SystemColors.Window;
			this.sp_main.Panel2.Controls.Add(this.dgv_01);
			this.sp_main.Size = new System.Drawing.Size(695, 672);
			this.sp_main.SplitterDistance = 137;
			this.sp_main.TabIndex = 0;
			// 
			// but_cancel
			// 
			this.but_cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.but_cancel.Location = new System.Drawing.Point(593, 12);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 274;
			this.but_cancel.Text = "关闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_list
			// 
			this.but_list.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.but_list.Location = new System.Drawing.Point(141, 12);
			this.but_list.Name = "but_list";
			this.but_list.Size = new System.Drawing.Size(99, 42);
			this.but_list.TabIndex = 274;
			this.but_list.Text = "打印列表";
			this.but_list.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_list.ThemeName = "Office2007Silver";
			this.but_list.Click += new System.EventHandler(this.but_list_Click);
			// 
			// but_ok
			// 
			this.but_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.but_ok.Location = new System.Drawing.Point(3, 12);
			this.but_ok.Name = "but_ok";
			this.but_ok.Size = new System.Drawing.Size(99, 42);
			this.but_ok.TabIndex = 273;
			this.but_ok.Text = "查询";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// cb_department
			// 
			this.cb_department.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cb_department.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_department.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_department.Location = new System.Drawing.Point(309, 70);
			this.cb_department.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.cb_department.Name = "cb_department";
			this.cb_department.Size = new System.Drawing.Size(180, 25);
			this.cb_department.TabIndex = 272;
			this.cb_department.ThemeName = "Office2007Silver";
			this.cb_department.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_department_SelectedIndexChanged);
			// 
			// cb_customer
			// 
			this.cb_customer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
			this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cb_customer.Location = new System.Drawing.Point(66, 70);
			this.cb_customer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.cb_customer.Name = "cb_customer";
			this.cb_customer.Size = new System.Drawing.Size(174, 25);
			this.cb_customer.TabIndex = 271;
			this.cb_customer.ThemeName = "Office2007Silver";
			this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
			// 
			// radLabel2
			// 
			this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel2.Location = new System.Drawing.Point(248, 71);
			this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.radLabel2.Name = "radLabel2";
			this.radLabel2.Size = new System.Drawing.Size(55, 23);
			this.radLabel2.TabIndex = 270;
			this.radLabel2.Text = "部门：";
			// 
			// radLabel1
			// 
			this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel1.Location = new System.Drawing.Point(5, 71);
			this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new System.Drawing.Size(55, 23);
			this.radLabel1.TabIndex = 269;
			this.radLabel1.Text = "客户：";
			// 
			// dt_start
			// 
			this.dt_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.dt_start.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dt_start.Location = new System.Drawing.Point(66, 105);
			this.dt_start.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.dt_start.Name = "dt_start";
			this.dt_start.Size = new System.Drawing.Size(174, 25);
			this.dt_start.TabIndex = 265;
			this.dt_start.TabStop = false;
			this.dt_start.Text = "2016年6月22日";
			this.dt_start.ThemeName = "Office2007Silver";
			this.dt_start.Value = new System.DateTime(2016, 6, 22, 16, 51, 24, 963);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.label2.Location = new System.Drawing.Point(3, 107);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 20);
			this.label2.TabIndex = 264;
			this.label2.Text = "开始：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.label3.Location = new System.Drawing.Point(246, 107);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 20);
			this.label3.TabIndex = 267;
			this.label3.Text = "结束：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.SystemColors.Window;
			this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_01.Location = new System.Drawing.Point(0, 0);
			// 
			// 
			// 
			this.dgv_01.MasterTemplate.AllowAddNewRow = false;
			gridViewTextBoxColumn11.HeaderText = "流程环节";
			gridViewTextBoxColumn11.Name = "pd_name";
			gridViewTextBoxColumn11.Width = 280;
			gridViewTextBoxColumn12.EnableExpressionEditor = false;
			gridViewTextBoxColumn12.HeaderText = "类型";
			gridViewTextBoxColumn12.Name = "isconfirm";
			gridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn12.Width = 215;
			gridViewTextBoxColumn12.WrapText = true;
			gridViewTextBoxColumn13.EnableExpressionEditor = false;
			gridViewTextBoxColumn13.HeaderText = "数量";
			gridViewTextBoxColumn13.Name = "num";
			gridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn13.Width = 182;
			gridViewTextBoxColumn13.WrapText = true;
			gridViewTextBoxColumn14.EnableExpressionEditor = false;
			gridViewTextBoxColumn14.HeaderText = "用户";
			gridViewTextBoxColumn14.IsVisible = false;
			gridViewTextBoxColumn14.Name = "user";
			gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn14.Width = 200;
			gridViewTextBoxColumn14.WrapText = true;
			gridViewTextBoxColumn15.EnableExpressionEditor = false;
			gridViewTextBoxColumn15.HeaderText = "wf_code";
			gridViewTextBoxColumn15.IsVisible = false;
			gridViewTextBoxColumn15.Name = "wf_code";
			gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn15.Width = 180;
			gridViewTextBoxColumn15.WrapText = true;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15});
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition3;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.Size = new System.Drawing.Size(695, 531);
			this.dgv_01.TabIndex = 82;
			this.dgv_01.Text = "radGridView1";
			this.dgv_01.ThemeName = "Office2007Silver";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.dt_end, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.but_cancel, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cb_customer, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cb_department, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.radLabel2, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.dt_start, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 137);
			this.tableLayoutPanel1.TabIndex = 275;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.but_ok, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.but_list, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(243, 67);
			this.tableLayoutPanel2.TabIndex = 275;
			// 
			// dt_end
			// 
			this.dt_end.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dt_end.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dt_end.Location = new System.Drawing.Point(309, 105);
			this.dt_end.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.dt_end.Name = "dt_end";
			this.dt_end.Size = new System.Drawing.Size(180, 25);
			this.dt_end.TabIndex = 276;
			this.dt_end.TabStop = false;
			this.dt_end.Text = "2016年6月22日";
			this.dt_end.ThemeName = "Office2007Silver";
			this.dt_end.Value = new System.DateTime(2016, 6, 22, 16, 51, 24, 963);
			// 
			// HCSRS_performance_appraisal_department
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 672);
			this.Controls.Add(this.sp_main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "HCSRS_performance_appraisal_department";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "部门绩效考核";
			this.sp_main.Panel1.ResumeLayout(false);
			this.sp_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
			this.sp_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_list)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_department)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dt_start)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_end)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadDateTimePicker dt_start;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList cb_department;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_list;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadGridView dgv_01;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private Telerik.WinControls.UI.RadDateTimePicker dt_end;
    }
}