namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_storage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_new = new Telerik.WinControls.UI.RadButton();
            this.but_select = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
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
            this.sp.Panel1.Controls.Add(this.but_cancel);
            this.sp.Panel1.Controls.Add(this.but_new);
            this.sp.Panel1.Controls.Add(this.but_select);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.dgv_01);
            this.sp.Size = new System.Drawing.Size(576, 382);
            this.sp.SplitterDistance = 59;
            this.sp.TabIndex = 0;
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(467, 8);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 233;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_new.Location = new System.Drawing.Point(9, 8);
            this.but_new.Name = "but_new";
            this.but_new.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 233;
            this.but_new.Text = "新  建";
            this.but_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_new.ThemeName = "Office2007Silver";
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // but_select
            // 
            this.but_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_select.Location = new System.Drawing.Point(114, 8);
            this.but_select.Name = "but_select";
            this.but_select.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_select.Size = new System.Drawing.Size(99, 42);
            this.but_select.TabIndex = 233;
            this.but_select.Text = "选  择";
            this.but_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_select.ThemeName = "Office2007Silver";
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.HeaderText = "存储点";
            gridViewTextBoxColumn2.Name = "s_name";
            gridViewTextBoxColumn2.Width = 151;
            gridViewTextBoxColumn3.HeaderText = "条形码";
            gridViewTextBoxColumn3.Name = "s_barcode";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.HeaderText = "存储点类型";
            gridViewTextBoxColumn4.Name = "s_type";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.HeaderText = "使用地点";
            gridViewTextBoxColumn5.Name = "s_location";
            gridViewTextBoxColumn5.Width = 100;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(576, 319);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_set_storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(576, 382);
            this.Controls.Add(this.sp);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_set_storage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择存储点";
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
            this.sp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_select;
        private Telerik.WinControls.UI.RadButton but_new;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}