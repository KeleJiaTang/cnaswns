namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_SelectSet
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_select = new Telerik.WinControls.UI.RadTextBox();
            this.but_select = new Telerik.WinControls.UI.RadButton();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.button1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dgv_test = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test.MasterTemplate)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.dgv_test);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 659);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_select);
            this.groupBox1.Controls.Add(this.but_select);
            this.groupBox1.Controls.Add(this.but_cancel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.cb_customer);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1036, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_select
            // 
            this.tb_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_select.Location = new System.Drawing.Point(442, 31);
            this.tb_select.Name = "tb_select";
            this.tb_select.Size = new System.Drawing.Size(208, 25);
            this.tb_select.TabIndex = 83;
            this.tb_select.ThemeName = "Office2007Silver";
            this.tb_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_select_KeyDown);
            // 
            // but_select
            // 
            this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_select.Location = new System.Drawing.Point(792, 20);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(136, 42);
            this.but_select.TabIndex = 85;
            this.but_select.Text = "选择器械包";
            this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_select.ThemeName = "Office2007Silver";
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(931, 20);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 86;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button1.Location = new System.Drawing.Point(657, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 25);
            this.button1.TabIndex = 84;
            this.button1.Text = "查询";
            this.button1.ThemeName = "Office2007Silver";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel2.Location = new System.Drawing.Point(287, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(166, 23);
            this.radLabel2.TabIndex = 82;
            this.radLabel2.Text = "包名称，条形码查询：";
            // 
            // cb_customer
            // 
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(53, 31);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(213, 25);
            this.cb_customer.TabIndex = 80;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel1.Location = new System.Drawing.Point(6, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 23);
            this.radLabel1.TabIndex = 81;
            this.radLabel1.Text = "客户：";
            // 
            // dgv_test
            // 
            this.dgv_test.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_test.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_test.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_test.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_test.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_test.MasterTemplate.AllowAddNewRow = false;
            this.dgv_test.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_test.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "条形码";
            gridViewTextBoxColumn1.Name = "s_barcode";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "手术包名称";
            gridViewTextBoxColumn2.Name = "s_name";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "手术包循环次数";
            gridViewTextBoxColumn3.Name = "s_runcycle";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "成本中心";
            gridViewTextBoxColumn4.Name = "s_costcenter";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "医院";
            gridViewTextBoxColumn5.Name = "s_customer";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "打包材料";
            gridViewTextBoxColumn6.Name = "s_pack";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "风险等级";
            gridViewTextBoxColumn7.Name = "s_risk";
            gridViewTextBoxColumn7.Width = 150;
            this.dgv_test.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dgv_test.MasterTemplate.EnableGrouping = false;
            this.dgv_test.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_test.Name = "dgv_test";
            this.dgv_test.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_test.ReadOnly = true;
            this.dgv_test.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_test.Size = new System.Drawing.Size(1036, 567);
            this.dgv_test.TabIndex = 2;
            this.dgv_test.Text = "radGridView1";
            this.dgv_test.ThemeName = "Office2007Silver";
            this.dgv_test.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_test_CellDoubleClick);
            this.dgv_test.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_test_MouseDoubleClick);
            // 
            // HCSRS_SelectSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 659);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1044, 691);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1044, 691);
            this.Name = "HCSRS_SelectSet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1044, 691);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择器械包";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView dgv_test;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadButton button1;
        private Telerik.WinControls.UI.RadTextBox tb_select;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}