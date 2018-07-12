namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_washing_program
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
			this.sp_main = new System.Windows.Forms.SplitContainer();
			this.but_print = new Telerik.WinControls.UI.RadButton();
			this.but_new = new Telerik.WinControls.UI.RadButton();
			this.but_edit = new Telerik.WinControls.UI.RadButton();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.but_remove = new Telerik.WinControls.UI.RadButton();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
			this.sp_main.Panel1.SuspendLayout();
			this.sp_main.Panel2.SuspendLayout();
			this.sp_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.but_print)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_new)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_edit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// sp_main
			// 
			this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.sp_main.Location = new System.Drawing.Point(0, 0);
			this.sp_main.Margin = new System.Windows.Forms.Padding(0);
			this.sp_main.Name = "sp_main";
			this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sp_main.Panel1
			// 
			this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
			this.sp_main.Panel1.Controls.Add(this.but_print);
			this.sp_main.Panel1.Controls.Add(this.but_new);
			this.sp_main.Panel1.Controls.Add(this.but_edit);
			this.sp_main.Panel1.Controls.Add(this.but_cancel);
			this.sp_main.Panel1.Controls.Add(this.but_remove);
			// 
			// sp_main.Panel2
			// 
			this.sp_main.Panel2.Controls.Add(this.dgv_01);
			this.sp_main.Size = new System.Drawing.Size(843, 467);
			this.sp_main.SplitterDistance = 60;
			this.sp_main.TabIndex = 0;
			// 
			// but_print
			// 
			this.but_print.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_print.Location = new System.Drawing.Point(357, 13);
			this.but_print.Name = "but_print";
			this.but_print.Size = new System.Drawing.Size(99, 42);
			this.but_print.TabIndex = 15;
			this.but_print.Text = "打印条码";
			this.but_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_print.ThemeName = "Office2007Silver";
			this.but_print.Click += new System.EventHandler(this.but_print_Click);
			// 
			// but_new
			// 
			this.but_new.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_new.Location = new System.Drawing.Point(13, 13);
			this.but_new.Name = "but_new";
			this.but_new.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_new.Size = new System.Drawing.Size(99, 42);
			this.but_new.TabIndex = 11;
			this.but_new.Text = "新  建";
			this.but_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_new.ThemeName = "Office2007Silver";
			this.but_new.Click += new System.EventHandler(this.but_new_Click);
			// 
			// but_edit
			// 
			this.but_edit.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_edit.Location = new System.Drawing.Point(118, 13);
			this.but_edit.Name = "but_edit";
			this.but_edit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_edit.Size = new System.Drawing.Size(99, 42);
			this.but_edit.TabIndex = 12;
			this.but_edit.Text = "修  改";
			this.but_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_edit.ThemeName = "Office2007Silver";
			this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(462, 13);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 13;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
			// 
			// but_remove
			// 
			this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_remove.Location = new System.Drawing.Point(223, 13);
			this.but_remove.Name = "but_remove";
			this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_remove.Size = new System.Drawing.Size(99, 42);
			this.but_remove.TabIndex = 14;
			this.but_remove.Text = "删  除";
			this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_remove.ThemeName = "Office2007Silver";
			this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
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
			gridViewTextBoxColumn19.HeaderText = "编号";
			gridViewTextBoxColumn19.Name = "id";
			gridViewTextBoxColumn19.Width = 59;
			gridViewTextBoxColumn20.HeaderText = "条码";
			gridViewTextBoxColumn20.Name = "bar_code";
			gridViewTextBoxColumn20.Width = 141;
			gridViewTextBoxColumn21.HeaderText = "程序名称";
			gridViewTextBoxColumn21.Name = "pr_name";
			gridViewTextBoxColumn21.Width = 141;
			gridViewTextBoxColumn22.HeaderText = "程序类型";
			gridViewTextBoxColumn22.Name = "p_type";
			gridViewTextBoxColumn22.Width = 150;
			gridViewTextBoxColumn23.HeaderText = "运行时间(分)";
			gridViewTextBoxColumn23.Name = "p_time";
			gridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			gridViewTextBoxColumn23.Width = 100;
			gridViewTextBoxColumn24.HeaderText = "备注说明";
			gridViewTextBoxColumn24.Name = "ca_remarks";
			gridViewTextBoxColumn24.Width = 250;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
			this.dgv_01.MasterTemplate.EnableGrouping = false;
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition4;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.Size = new System.Drawing.Size(843, 403);
			this.dgv_01.TabIndex = 5;
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.OnDataGridDoubleClick);
			// 
			// HCSCM_washing_program
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 467);
			this.Controls.Add(this.sp_main);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_washing_program";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "清洗程序窗体";
			this.sp_main.Panel1.ResumeLayout(false);
			this.sp_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
			this.sp_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.but_print)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_new)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_edit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadButton but_print;
        private Telerik.WinControls.UI.RadButton but_new;
        private Telerik.WinControls.UI.RadButton but_edit;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadGridView dgv_01;
    }
}