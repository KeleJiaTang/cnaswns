namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_SterilizerDevice
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
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.sp = new System.Windows.Forms.SplitContainer();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_select = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
			this.sp.Panel1.SuspendLayout();
			this.sp.Panel2.SuspendLayout();
			this.sp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// sp
			// 
			this.sp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sp.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.sp.Location = new System.Drawing.Point(0, 0);
			this.sp.Name = "sp";
			this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sp.Panel1
			// 
			this.sp.Panel1.Controls.Add(this.dgv_01);
			// 
			// sp.Panel2
			// 
			this.sp.Panel2.BackColor = System.Drawing.SystemColors.Window;
			this.sp.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.sp.Size = new System.Drawing.Size(448, 473);
			this.sp.SplitterDistance = 370;
			this.sp.TabIndex = 1;
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
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
			this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			gridViewTextBoxColumn1.HeaderText = "编号";
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 80;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "条形码";
			gridViewTextBoxColumn2.Name = "s_barcode";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "灭菌器名称";
			gridViewTextBoxColumn3.Name = "s_name";
			gridViewTextBoxColumn3.Width = 200;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.Size = new System.Drawing.Size(448, 370);
			this.dgv_01.TabIndex = 1;
			this.dgv_01.Text = "radGridView1";
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.but_cancel, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.but_select, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 99);
			this.tableLayoutPanel1.TabIndex = 235;
			// 
			// but_cancel
			// 
			this.but_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(254, 28);
			this.but_cancel.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 233;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click);
			// 
			// but_select
			// 
			this.but_select.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_select.Location = new System.Drawing.Point(95, 28);
			this.but_select.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.but_select.Name = "but_select";
			this.but_select.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_select.Size = new System.Drawing.Size(99, 42);
			this.but_select.TabIndex = 234;
			this.but_select.Text = "选  择";
			this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_select.ThemeName = "Office2007Silver";
			this.but_select.Click += new System.EventHandler(this.but_select_Click);
			// 
			// HCSRS_SterilizerDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 473);
			this.Controls.Add(this.sp);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(456, 505);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(456, 505);
			this.Name = "HCSRS_SterilizerDevice";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.RootElement.MaxSize = new System.Drawing.Size(456, 505);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "请选择灭菌器";
			this.sp.Panel1.ResumeLayout(false);
			this.sp.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
			this.sp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadGridView dgv_01;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}