namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_department_equipment_manager_Selrecord
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.startTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.endTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.but_cancel);
            this.splitContainer1.Panel1.Controls.Add(this.startTimePicker);
            this.splitContainer1.Panel1.Controls.Add(this.endTimePicker);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(982, 784);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.TabIndex = 1;
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "yyyy年MM月dd日 HH:mm";
            this.startTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(105, 12);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(220, 25);
            this.startTimePicker.TabIndex = 68;
            this.startTimePicker.TabStop = false;
            this.startTimePicker.ThemeName = "Office2007Silver";
            this.startTimePicker.Value = new System.DateTime(((long)(0)));
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "yyyy年MM月dd日 HH:mm";
            this.endTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(459, 12);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(219, 25);
            this.endTimePicker.TabIndex = 69;
            this.endTimePicker.TabStop = false;
            this.endTimePicker.ThemeName = "Office2007Silver";
            this.endTimePicker.Value = new System.DateTime(((long)(0)));
            this.endTimePicker.ValueChanged += new System.EventHandler(this.endTimePicker_ValueChanged);
            this.endTimePicker.TextChanged += new System.EventHandler(this.endTimePicker_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "开始时间：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(364, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 71;
            this.label3.Text = "结束时间：";
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
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "编号";
            gridViewTextBoxColumn9.Name = "id";
            gridViewTextBoxColumn9.Width = 63;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "物品名称";
            gridViewTextBoxColumn10.Name = "ca_name";
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "客户";
            gridViewTextBoxColumn11.Name = "cu_name";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "成本中心";
            gridViewTextBoxColumn12.Name = "cc_name";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "物品类型";
            gridViewTextBoxColumn13.Name = "value_code";
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.HeaderText = "数据类型";
            gridViewTextBoxColumn14.Name = "act_type";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.HeaderText = "数量";
            gridViewTextBoxColumn15.Name = "act_count";
            gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.HeaderText = "创建日期";
            gridViewTextBoxColumn16.Name = "cre_date";
            gridViewTextBoxColumn16.Width = 150;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.Size = new System.Drawing.Size(982, 721);
            this.dgv_01.TabIndex = 3;
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(871, 7);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 72;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // HCSCM_department_equipment_manager_Selrecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(982, 784);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_department_equipment_manager_Selrecord";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_department_equipment_manager_Selrecord";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadDateTimePicker startTimePicker;
        private Telerik.WinControls.UI.RadDateTimePicker endTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadButton but_cancel;
    }
}