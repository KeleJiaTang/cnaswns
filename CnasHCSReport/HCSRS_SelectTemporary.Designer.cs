namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_SelectTemporary
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.but_select = new Telerik.WinControls.UI.RadButton();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 659);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.but_select);
            this.groupBox1.Controls.Add(this.but_cancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1036, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // but_select
            // 
            this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_select.Location = new System.Drawing.Point(12, 20);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(136, 42);
            this.but_select.TabIndex = 88;
            this.but_select.Text = "选择器械包";
            this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_select.ThemeName = "Office2007Silver";
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(925, 20);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 87;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
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
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "条形码";
            gridViewTextBoxColumn1.Name = "s_barcode";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "临时包名称";
            gridViewTextBoxColumn2.Name = "s_name";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "医院";
            gridViewTextBoxColumn3.Name = "s_customer";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "成本中心";
            gridViewTextBoxColumn4.Name = "s_costcenter";
            gridViewTextBoxColumn4.Width = 150;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgv_01.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(1036, 565);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSRS_SelectTemporary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 659);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1044, 691);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1044, 691);
            this.Name = "HCSRS_SelectTemporary";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1044, 691);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择临时包";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}