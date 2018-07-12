namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_entityset_manager_bindingRfid
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
            this.but_remove = new Telerik.WinControls.UI.RadButton();
            this.lb_rNumber = new System.Windows.Forms.Label();
            this.tb_rNumber = new Telerik.WinControls.UI.RadTextBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_reconnect = new Telerik.WinControls.UI.RadButton();
            this.lb_number = new System.Windows.Forms.Label();
            this.tb_iNumber = new Telerik.WinControls.UI.RadTextBox();
            this.but_feelingEmpty = new Telerik.WinControls.UI.RadButton();
            this.tb_setName = new Telerik.WinControls.UI.RadTextBox();
            this.but_binding = new Telerik.WinControls.UI.RadButton();
            this.but_save = new Telerik.WinControls.UI.RadButton();
            this.lb_name = new System.Windows.Forms.Label();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_iNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_feelingEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_binding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.but_remove);
            this.splitContainer1.Panel1.Controls.Add(this.lb_rNumber);
            this.splitContainer1.Panel1.Controls.Add(this.tb_rNumber);
            this.splitContainer1.Panel1.Controls.Add(this.but_cancel);
            this.splitContainer1.Panel1.Controls.Add(this.but_reconnect);
            this.splitContainer1.Panel1.Controls.Add(this.lb_number);
            this.splitContainer1.Panel1.Controls.Add(this.tb_iNumber);
            this.splitContainer1.Panel1.Controls.Add(this.but_feelingEmpty);
            this.splitContainer1.Panel1.Controls.Add(this.tb_setName);
            this.splitContainer1.Panel1.Controls.Add(this.but_binding);
            this.splitContainer1.Panel1.Controls.Add(this.but_save);
            this.splitContainer1.Panel1.Controls.Add(this.lb_name);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(780, 559);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 11F);
            this.but_remove.Location = new System.Drawing.Point(563, 12);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(100, 42);
            this.but_remove.TabIndex = 6;
            this.but_remove.Text = "删除绑定";
            this.but_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_remove.ThemeName = "Office2007Silver";
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // lb_rNumber
            // 
            this.lb_rNumber.AutoSize = true;
            this.lb_rNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_rNumber.Location = new System.Drawing.Point(25, 76);
            this.lb_rNumber.Name = "lb_rNumber";
            this.lb_rNumber.Size = new System.Drawing.Size(73, 20);
            this.lb_rNumber.TabIndex = 361;
            this.lb_rNumber.Text = "绑定数：";
            // 
            // tb_rNumber
            // 
            this.tb_rNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_rNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_rNumber.Location = new System.Drawing.Point(104, 74);
            this.tb_rNumber.Name = "tb_rNumber";
            this.tb_rNumber.ReadOnly = true;
            this.tb_rNumber.Size = new System.Drawing.Size(255, 25);
            this.tb_rNumber.TabIndex = 360;
            this.tb_rNumber.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 11F);
            this.but_cancel.Location = new System.Drawing.Point(669, 60);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 5;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click_1);
            // 
            // but_reconnect
            // 
            this.but_reconnect.Font = new System.Drawing.Font("宋体", 11F);
            this.but_reconnect.Location = new System.Drawing.Point(458, 12);
            this.but_reconnect.Name = "but_reconnect";
            this.but_reconnect.Size = new System.Drawing.Size(99, 42);
            this.but_reconnect.TabIndex = 4;
            this.but_reconnect.Text = "重新连接";
            this.but_reconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_reconnect.ThemeName = "Office2007Silver";
            this.but_reconnect.Visible = false;
            this.but_reconnect.Click += new System.EventHandler(this.but_reconnect_Click);
            // 
            // lb_number
            // 
            this.lb_number.AutoSize = true;
            this.lb_number.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_number.Location = new System.Drawing.Point(41, 45);
            this.lb_number.Name = "lb_number";
            this.lb_number.Size = new System.Drawing.Size(57, 20);
            this.lb_number.TabIndex = 359;
            this.lb_number.Text = "总数：";
            // 
            // tb_iNumber
            // 
            this.tb_iNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_iNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_iNumber.Location = new System.Drawing.Point(104, 43);
            this.tb_iNumber.Name = "tb_iNumber";
            this.tb_iNumber.ReadOnly = true;
            this.tb_iNumber.Size = new System.Drawing.Size(255, 25);
            this.tb_iNumber.TabIndex = 358;
            this.tb_iNumber.ThemeName = "Office2007Silver";
            // 
            // but_feelingEmpty
            // 
            this.but_feelingEmpty.Font = new System.Drawing.Font("宋体", 11F);
            this.but_feelingEmpty.Location = new System.Drawing.Point(564, 60);
            this.but_feelingEmpty.Name = "but_feelingEmpty";
            this.but_feelingEmpty.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_feelingEmpty.Size = new System.Drawing.Size(99, 42);
            this.but_feelingEmpty.TabIndex = 4;
            this.but_feelingEmpty.Text = "清  空";
            this.but_feelingEmpty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_feelingEmpty.ThemeName = "Office2007Silver";
            this.but_feelingEmpty.Click += new System.EventHandler(this.but_feelingEmpty_Click);
            // 
            // tb_setName
            // 
            this.tb_setName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_setName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_setName.Location = new System.Drawing.Point(104, 12);
            this.tb_setName.Name = "tb_setName";
            this.tb_setName.ReadOnly = true;
            this.tb_setName.Size = new System.Drawing.Size(255, 25);
            this.tb_setName.TabIndex = 356;
            this.tb_setName.ThemeName = "Office2007Silver";
            // 
            // but_binding
            // 
            this.but_binding.Font = new System.Drawing.Font("宋体", 11F);
            this.but_binding.Location = new System.Drawing.Point(669, 12);
            this.but_binding.Name = "but_binding";
            this.but_binding.Size = new System.Drawing.Size(99, 42);
            this.but_binding.TabIndex = 4;
            this.but_binding.Text = "重新绑定";
            this.but_binding.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_binding.ThemeName = "Office2007Silver";
            this.but_binding.Click += new System.EventHandler(this.but_binding_Click);
            // 
            // but_save
            // 
            this.but_save.Font = new System.Drawing.Font("宋体", 11F);
            this.but_save.Location = new System.Drawing.Point(458, 60);
            this.but_save.Name = "but_save";
            this.but_save.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_save.Size = new System.Drawing.Size(99, 42);
            this.but_save.TabIndex = 4;
            this.but_save.Text = "保  存";
            this.but_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_save.ThemeName = "Office2007Silver";
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(9, 14);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(89, 20);
            this.lb_name.TabIndex = 357;
            this.lb_name.Text = "器械名称：";
            // 
            // dgv_01
            // 
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Font = new System.Drawing.Font("宋体", 11F);
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
            this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.HeaderText = "RFID";
            gridViewTextBoxColumn2.Name = "RFID";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn2.Width = 350;
            gridViewTextBoxColumn3.HeaderText = "绑定情况";
            gridViewTextBoxColumn3.Name = "repeat";
            gridViewTextBoxColumn3.Width = 350;
            gridViewTextBoxColumn4.HeaderText = "类型";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "ca_type";
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgv_01.MasterTemplate.EnableGrouping = false;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.Size = new System.Drawing.Size(780, 445);
            this.dgv_01.TabIndex = 6;
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // HCSCM_entityset_manager_bindingRfid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(780, 559);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_entityset_manager_bindingRfid";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_entityset_manager_bindingRfid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HCSCM_entityset_manager_bindingRfid_FormClosing);
            this.Load += new System.EventHandler(this.HCSCM_entityset_manager_bindingRfid_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_reconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_iNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_feelingEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_binding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_binding;
        private Telerik.WinControls.UI.RadButton but_save;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadButton but_remove;
		private Telerik.WinControls.UI.RadButton but_feelingEmpty;
        private Telerik.WinControls.UI.RadButton but_reconnect;
		private System.Windows.Forms.Label lb_rNumber;
		private Telerik.WinControls.UI.RadTextBox tb_rNumber;
		private System.Windows.Forms.Label lb_number;
		private Telerik.WinControls.UI.RadTextBox tb_iNumber;
		private Telerik.WinControls.UI.RadTextBox tb_setName;
		private System.Windows.Forms.Label lb_name;

    }
}