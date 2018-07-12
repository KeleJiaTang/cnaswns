namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_sterilizer_program
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn28 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn29 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn30 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
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
			this.sp_main.Size = new System.Drawing.Size(899, 478);
			this.sp_main.SplitterDistance = 73;
			this.sp_main.TabIndex = 0;
			// 
			// but_print
			// 
			this.but_print.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_print.Location = new System.Drawing.Point(326, 10);
			this.but_print.Name = "but_print";
			this.but_print.Size = new System.Drawing.Size(99, 42);
			this.but_print.TabIndex = 10;
			this.but_print.Text = "打印条码";
			this.but_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_print.ThemeName = "Office2007Silver";
			this.but_print.Click += new System.EventHandler(this.but_print_Click);
			// 
			// but_new
			// 
			this.but_new.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_new.Location = new System.Drawing.Point(11, 10);
			this.but_new.Name = "but_new";
			this.but_new.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_new.Size = new System.Drawing.Size(99, 42);
			this.but_new.TabIndex = 6;
			this.but_new.Text = "新  建";
			this.but_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_new.ThemeName = "Office2007Silver";
			this.but_new.Click += new System.EventHandler(this.but_new_Click);
			// 
			// but_edit
			// 
			this.but_edit.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_edit.Location = new System.Drawing.Point(116, 10);
			this.but_edit.Name = "but_edit";
			this.but_edit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_edit.Size = new System.Drawing.Size(99, 42);
			this.but_edit.TabIndex = 7;
			this.but_edit.Text = "修  改";
			this.but_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_edit.ThemeName = "Office2007Silver";
			this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
			// 
			// but_cancel
			// 
			this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_cancel.Location = new System.Drawing.Point(790, 10);
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_cancel.Size = new System.Drawing.Size(99, 42);
			this.but_cancel.TabIndex = 8;
			this.but_cancel.Text = "关  闭";
			this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click_1);
			// 
			// but_remove
			// 
			this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.but_remove.Location = new System.Drawing.Point(221, 10);
			this.but_remove.Name = "but_remove";
			this.but_remove.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.but_remove.Size = new System.Drawing.Size(99, 42);
			this.but_remove.TabIndex = 9;
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
			gridViewTextBoxColumn25.HeaderText = "编号";
			gridViewTextBoxColumn25.Name = "id";
			gridViewTextBoxColumn25.Width = 59;
			gridViewTextBoxColumn26.HeaderText = "条码";
			gridViewTextBoxColumn26.Name = "bar_code";
			gridViewTextBoxColumn26.Width = 141;
			gridViewTextBoxColumn27.HeaderText = "程序名称";
			gridViewTextBoxColumn27.Name = "pr_name";
			gridViewTextBoxColumn27.Width = 141;
			gridViewTextBoxColumn28.EnableExpressionEditor = false;
			gridViewTextBoxColumn28.HeaderText = "温度等级（高）";
			gridViewTextBoxColumn28.Name = "upper_level";
			gridViewTextBoxColumn28.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			gridViewTextBoxColumn28.Width = 100;
			gridViewTextBoxColumn29.HeaderText = "温度等级（低）";
			gridViewTextBoxColumn29.Name = "lower_level";
			gridViewTextBoxColumn29.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			gridViewTextBoxColumn29.Width = 100;
			gridViewTextBoxColumn30.HeaderText = "运行时间";
			gridViewTextBoxColumn30.Name = "run_time";
			gridViewTextBoxColumn30.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
			gridViewTextBoxColumn30.Width = 100;
			gridViewTextBoxColumn31.HeaderText = "程序类型";
			gridViewTextBoxColumn31.Name = "p_type";
			gridViewTextBoxColumn31.Width = 100;
			gridViewTextBoxColumn32.HeaderText = "备注说明";
			gridViewTextBoxColumn32.Name = "ca_remarks";
			gridViewTextBoxColumn32.Width = 300;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27,
            gridViewTextBoxColumn28,
            gridViewTextBoxColumn29,
            gridViewTextBoxColumn30,
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32});
			this.dgv_01.MasterTemplate.EnableGrouping = false;
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition4;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.dgv_01.ReadOnly = true;
			this.dgv_01.Size = new System.Drawing.Size(899, 401);
			this.dgv_01.TabIndex = 4;
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// HCSCM_sterilizer_program
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 478);
			this.Controls.Add(this.sp_main);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSCM_sterilizer_program";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "灭菌程序";
			this.Load += new System.EventHandler(this.HCSCM_sterilizer_program_Load);
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