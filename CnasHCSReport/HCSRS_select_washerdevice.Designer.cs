namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_select_washerdevice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSRS_select_washerdevice));
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.sp = new System.Windows.Forms.SplitContainer();
			this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
			this.but_select = new Telerik.WinControls.UI.RadButton();
			this.but_cancel = new Telerik.WinControls.UI.RadButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
			this.sp.Panel1.SuspendLayout();
			this.sp.Panel2.SuspendLayout();
			this.sp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// sp
			// 
			resources.ApplyResources(this.sp, "sp");
			this.sp.Name = "sp";
			// 
			// sp.Panel1
			// 
			this.sp.Panel1.Controls.Add(this.dgv_01);
			// 
			// sp.Panel2
			// 
			this.sp.Panel2.BackColor = System.Drawing.SystemColors.Window;
			this.sp.Panel2.Controls.Add(this.tableLayoutPanel1);
			// 
			// dgv_01
			// 
			this.dgv_01.BackColor = System.Drawing.SystemColors.Control;
			this.dgv_01.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(this.dgv_01, "dgv_01");
			this.dgv_01.ForeColor = System.Drawing.SystemColors.ControlText;
			// 
			// 
			// 
			this.dgv_01.MasterTemplate.AllowAddNewRow = false;
			this.dgv_01.MasterTemplate.AllowCellContextMenu = false;
			this.dgv_01.MasterTemplate.AllowColumnHeaderContextMenu = false;
			gridViewTextBoxColumn1.EnableExpressionEditor = false;
			resources.ApplyResources(gridViewTextBoxColumn1, "gridViewTextBoxColumn1");
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 80;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			resources.ApplyResources(gridViewTextBoxColumn2, "gridViewTextBoxColumn2");
			gridViewTextBoxColumn2.Name = "s_barcode";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			resources.ApplyResources(gridViewTextBoxColumn3, "gridViewTextBoxColumn3");
			gridViewTextBoxColumn3.Name = "s_name";
			gridViewTextBoxColumn3.Width = 200;
			this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
			this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.ReadOnly = true;
			this.dgv_01.ShowGroupPanel = false;
			this.dgv_01.ThemeName = "Office2007Silver";
			this.dgv_01.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgv_01_CellDoubleClick);
			// 
			// but_select
			// 
			resources.ApplyResources(this.but_select, "but_select");
			this.but_select.Name = "but_select";
			this.but_select.ThemeName = "Office2007Silver";
			this.but_select.Click += new System.EventHandler(this.but_select_Click);
			// 
			// but_cancel
			// 
			resources.ApplyResources(this.but_cancel, "but_cancel");
			this.but_cancel.Name = "but_cancel";
			this.but_cancel.ThemeName = "Office2007Silver";
			this.but_cancel.Click += new System.EventHandler(this.but_Cancel_Click);
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.but_cancel, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.but_select, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// HCSRS_select_washerdevice
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sp);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HCSRS_select_washerdevice";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.RootElement.MaxSize = new System.Drawing.Size(457, 505);
			this.sp.Panel1.ResumeLayout(false);
			this.sp.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
			this.sp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_select)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
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