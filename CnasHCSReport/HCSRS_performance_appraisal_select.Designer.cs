namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_performance_appraisal_select
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.sp_main = new System.Windows.Forms.SplitContainer();
			this.tb_sname = new Telerik.WinControls.UI.RadTextBox();
			this.but_select = new Telerik.WinControls.UI.RadButton();
			this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
			this.but_ok = new Telerik.WinControls.UI.RadButton();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.closeBtn = new Telerik.WinControls.UI.RadButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
			this.sp_main.Panel1.SuspendLayout();
			this.sp_main.Panel2.SuspendLayout();
			this.sp_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_sname)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
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
			this.sp_main.Panel2.Controls.Add(this.dgv_01);
			this.sp_main.Size = new System.Drawing.Size(846, 666);
			this.sp_main.SplitterDistance = 60;
			this.sp_main.TabIndex = 0;
			// 
			// tb_sname
			// 
			this.tb_sname.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tb_sname.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.tb_sname.Location = new System.Drawing.Point(200, 17);
			this.tb_sname.Name = "tb_sname";
			this.tb_sname.Size = new System.Drawing.Size(250, 25);
			this.tb_sname.TabIndex = 63;
			this.tb_sname.ThemeName = "Office2007Silver";
			this.tb_sname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
			// 
			// but_select
			// 
			this.but_select.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_select.Location = new System.Drawing.Point(639, 9);
			this.but_select.Name = "but_select";
			this.but_select.Size = new System.Drawing.Size(99, 42);
			this.but_select.TabIndex = 4;
			this.but_select.Text = "选  择";
			this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_select.ThemeName = "Office2007Silver";
			this.but_select.Click += new System.EventHandler(this.but_select_Click);
			// 
			// radLabel1
			// 
			this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.radLabel1.Location = new System.Drawing.Point(3, 18);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new System.Drawing.Size(191, 23);
			this.radLabel1.TabIndex = 4;
			this.radLabel1.Text = "搜索内容(条码、用户昵称)";
			// 
			// but_ok
			// 
			this.but_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_ok.Location = new System.Drawing.Point(456, 17);
			this.but_ok.Name = "but_ok";
			this.but_ok.Size = new System.Drawing.Size(45, 25);
			this.but_ok.TabIndex = 5;
			this.but_ok.Text = "确认";
			this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_ok.ThemeName = "Office2007Silver";
			this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
			this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.dgv_01.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgv_01.Location = new System.Drawing.Point(0, 0);
			// 
			// 
			// 
			this.dgv_01.MasterTemplate.AllowAddNewRow = false;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 80;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "条码";
			gridViewTextBoxColumn2.Name = "user_bcode";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "用户昵称";
			gridViewTextBoxColumn3.Name = "user_nick";
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "用户类型";
			gridViewTextBoxColumn4.Name = "user_typename";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "登陆名";
			gridViewTextBoxColumn5.Name = "user_name";
			gridViewTextBoxColumn5.Width = 150;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "员工编号";
			gridViewTextBoxColumn6.Name = "user_eid";
			gridViewTextBoxColumn6.Width = 150;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "user_type";
			gridViewTextBoxColumn7.IsVisible = false;
			gridViewTextBoxColumn7.Name = "user_type";
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.Size = new System.Drawing.Size(846, 602);
			this.dgv_01.TabIndex = 4;
			this.dgv_01.Text = "radGridView1";
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// closeBtn
			// 
			this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.closeBtn.Location = new System.Drawing.Point(744, 9);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(99, 42);
			this.closeBtn.TabIndex = 64;
			this.closeBtn.Text = "关  闭";
			this.closeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.closeBtn.ThemeName = "Office2007Silver";
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.but_ok, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tb_sname, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.but_select, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.closeBtn, 4, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 60);
			this.tableLayoutPanel1.TabIndex = 65;
			// 
			// HCSRS_performance_appraisal_select
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 666);
			this.Controls.Add(this.sp_main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimumSize = new System.Drawing.Size(791, 698);
			this.Name = "HCSRS_performance_appraisal_select";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "用户列表";
			this.sp_main.Panel1.ResumeLayout(false);
			this.sp_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
			this.sp_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tb_sname)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadTextBox tb_sname;
        private Telerik.WinControls.UI.RadGridView dgv_01;
		private Telerik.WinControls.UI.RadButton closeBtn;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}