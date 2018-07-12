namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_instrument_manage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.tb_ins = new Telerik.WinControls.UI.RadTextBox();
            this.but_new = new Telerik.WinControls.UI.RadButton();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.but_edit = new Telerik.WinControls.UI.RadButton();
            this.lb_ins = new System.Windows.Forms.Label();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.sp_main.Panel1.Controls.Add(this.tb_ins);
            this.sp_main.Panel1.Controls.Add(this.but_new);
            this.sp_main.Panel1.Controls.Add(this.but_cancel);
            this.sp_main.Panel1.Controls.Add(this.but_remove);
            this.sp_main.Panel1.Controls.Add(this.but_edit);
            this.sp_main.Panel1.Controls.Add(this.lb_ins);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(649, 450);
            this.sp_main.SplitterDistance = 98;
            this.sp_main.TabIndex = 0;
            // 
            // tb_ins
            // 
            this.tb_ins.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_ins.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_ins.Location = new System.Drawing.Point(101, 63);
            this.tb_ins.Name = "tb_ins";
            this.tb_ins.Size = new System.Drawing.Size(221, 25);
            this.tb_ins.TabIndex = 72;
            this.tb_ins.ThemeName = "Office2007Silver";
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_new.Location = new System.Drawing.Point(13, 13);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 2;
            this.but_new.Text = "          新建";
            this.but_new.ThemeName = "Office2007Silver";
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(537, 13);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "          关闭";
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click_1);
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_remove.Location = new System.Drawing.Point(223, 13);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 3;
            this.but_remove.Text = "          删除";
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_edit.Location = new System.Drawing.Point(118, 13);
            this.but_edit.Name = "but_edit";
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 4;
            this.but_edit.Text = "          修改";
            this.but_edit.ThemeName = "Office2007Silver";
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // lb_ins
            // 
            this.lb_ins.AutoSize = true;
            this.lb_ins.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_ins.Location = new System.Drawing.Point(13, 65);
            this.lb_ins.Name = "lb_ins";
            this.lb_ins.Size = new System.Drawing.Size(89, 20);
            this.lb_ins.TabIndex = 73;
            this.lb_ins.Text = "器械名称：";
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
            gridViewTextBoxColumn1.Width = 59;
            gridViewTextBoxColumn2.HeaderText = "器械名称";
            gridViewTextBoxColumn2.Name = "ins_id";
            gridViewTextBoxColumn2.Width = 141;
            gridViewTextBoxColumn3.HeaderText = "创建时间";
            gridViewTextBoxColumn3.Name = "cre_date";
            gridViewTextBoxColumn3.Width = 141;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "RFID";
            gridViewTextBoxColumn4.Name = "ca_rfid";
            gridViewTextBoxColumn4.Width = 93;
            gridViewTextBoxColumn5.HeaderText = "SN码";
            gridViewTextBoxColumn5.Name = "sm_num";
            gridViewTextBoxColumn5.Width = 93;
            gridViewTextBoxColumn6.HeaderText = "使用次数";
            gridViewTextBoxColumn6.Name = "run_times";
            gridViewTextBoxColumn6.Width = 233;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(649, 348);
            this.dgv_01.TabIndex = 2;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_instrument_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.sp_main);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_instrument_manage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "器械管理";
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel1.PerformLayout();
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadButton but_new;
        private Telerik.WinControls.UI.RadButton but_remove;
        private Telerik.WinControls.UI.RadButton but_edit;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private System.Windows.Forms.Label lb_ins;
        private Telerik.WinControls.UI.RadTextBox tb_ins;
        private Telerik.WinControls.UI.RadGridView dgv_01;

    }
}