namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_entityset_manager_rfid
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_rNumber = new System.Windows.Forms.Label();
            this.tb_rNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lb_number = new System.Windows.Forms.Label();
            this.tb_iNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_setName = new Telerik.WinControls.UI.RadTextBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_bindingRfid = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_iNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_bindingRfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.lb_rNumber);
            this.splitContainer1.Panel1.Controls.Add(this.tb_rNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lb_number);
            this.splitContainer1.Panel1.Controls.Add(this.tb_iNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lb_name);
            this.splitContainer1.Panel1.Controls.Add(this.tb_setName);
            this.splitContainer1.Panel1.Controls.Add(this.but_cancel);
            this.splitContainer1.Panel1.Controls.Add(this.but_bindingRfid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(781, 642);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 0;
            // 
            // lb_rNumber
            // 
            this.lb_rNumber.AutoSize = true;
            this.lb_rNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_rNumber.Location = new System.Drawing.Point(24, 76);
            this.lb_rNumber.Name = "lb_rNumber";
            this.lb_rNumber.Size = new System.Drawing.Size(89, 20);
            this.lb_rNumber.TabIndex = 350;
            this.lb_rNumber.Text = "绑定总数：";
            // 
            // tb_rNumber
            // 
            this.tb_rNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_rNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_rNumber.Location = new System.Drawing.Point(121, 74);
            this.tb_rNumber.Name = "tb_rNumber";
            this.tb_rNumber.ReadOnly = true;
            this.tb_rNumber.Size = new System.Drawing.Size(264, 25);
            this.tb_rNumber.TabIndex = 349;
            this.tb_rNumber.ThemeName = "Office2007Silver";
            // 
            // lb_number
            // 
            this.lb_number.AutoSize = true;
            this.lb_number.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_number.Location = new System.Drawing.Point(24, 45);
            this.lb_number.Name = "lb_number";
            this.lb_number.Size = new System.Drawing.Size(89, 20);
            this.lb_number.TabIndex = 348;
            this.lb_number.Text = "器械总数：";
            // 
            // tb_iNumber
            // 
            this.tb_iNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_iNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_iNumber.Location = new System.Drawing.Point(121, 43);
            this.tb_iNumber.Name = "tb_iNumber";
            this.tb_iNumber.ReadOnly = true;
            this.tb_iNumber.Size = new System.Drawing.Size(264, 25);
            this.tb_iNumber.TabIndex = 347;
            this.tb_iNumber.ThemeName = "Office2007Silver";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(10, 14);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(105, 20);
            this.lb_name.TabIndex = 346;
            this.lb_name.Text = "实体包名称：";
            // 
            // tb_setName
            // 
            this.tb_setName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_setName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_setName.Location = new System.Drawing.Point(121, 12);
            this.tb_setName.Name = "tb_setName";
            this.tb_setName.ReadOnly = true;
            this.tb_setName.Size = new System.Drawing.Size(264, 25);
            this.tb_setName.TabIndex = 345;
            this.tb_setName.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(670, 57);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 14;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_bindingRfid
            // 
            this.but_bindingRfid.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_bindingRfid.Location = new System.Drawing.Point(670, 6);
            this.but_bindingRfid.Name = "but_bindingRfid";
            this.but_bindingRfid.Size = new System.Drawing.Size(99, 42);
            this.but_bindingRfid.TabIndex = 13;
            this.but_bindingRfid.Text = "绑定RFID";
            this.but_bindingRfid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_bindingRfid.ThemeName = "Office2007Silver";
            this.but_bindingRfid.Click += new System.EventHandler(this.but_print_Click);
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
            gridViewTextBoxColumn2.HeaderText = "器械名称";
            gridViewTextBoxColumn2.Name = "ca_name";
            gridViewTextBoxColumn2.Width = 300;
            gridViewTextBoxColumn3.HeaderText = "器械数量";
            gridViewTextBoxColumn3.Name = "number";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.HeaderText = "绑定RFID数量";
            gridViewTextBoxColumn4.Name = "binding_number";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.HeaderText = "实体包条码";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "bar_code";
            gridViewTextBoxColumn5.Width = 250;
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
            this.dgv_01.Size = new System.Drawing.Size(781, 532);
            this.dgv_01.TabIndex = 3;
            this.dgv_01.ThemeName = "Office2007Silver";
            this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // HCSCM_entityset_manager_rfid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 642);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_entityset_manager_rfid";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_entityset_manager_rfid";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_rNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_iNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_bindingRfid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_bindingRfid;
        private System.Windows.Forms.Label lb_name;
        private Telerik.WinControls.UI.RadTextBox tb_setName;
        private System.Windows.Forms.Label lb_rNumber;
        private Telerik.WinControls.UI.RadTextBox tb_rNumber;
        private System.Windows.Forms.Label lb_number;
        private Telerik.WinControls.UI.RadTextBox tb_iNumber;
    }
}