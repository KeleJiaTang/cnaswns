namespace Cnas.wns.CnasHCSReport
{
    partial class HCSRS_setpatient
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.tb_num = new Telerik.WinControls.UI.RadTextBox();
            this.tb_sterilizer = new Telerik.WinControls.UI.RadTextBox();
            this.tb_barcode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sterilizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.radButton1);
            this.splitContainer1.Panel1.Controls.Add(this.tb_num);
            this.splitContainer1.Panel1.Controls.Add(this.tb_sterilizer);
            this.splitContainer1.Panel1.Controls.Add(this.tb_barcode);
            this.splitContainer1.Panel1.Controls.Add(this.radLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.radLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(893, 511);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radButton1.Location = new System.Drawing.Point(780, 11);
            this.radButton1.Name = "radButton1";
            this.radButton1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.radButton1.Size = new System.Drawing.Size(99, 42);
            this.radButton1.TabIndex = 88;
            this.radButton1.Text = "关   闭";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.ThemeName = "Office2007Silver";
            this.radButton1.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // tb_num
            // 
            this.tb_num.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_num.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_num.Location = new System.Drawing.Point(436, 20);
            this.tb_num.Name = "tb_num";
            this.tb_num.ReadOnly = true;
            this.tb_num.Size = new System.Drawing.Size(120, 25);
            this.tb_num.TabIndex = 4;
            this.tb_num.ThemeName = "Office2007Silver";
            // 
            // tb_sterilizer
            // 
            this.tb_sterilizer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_sterilizer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_sterilizer.Location = new System.Drawing.Point(215, 20);
            this.tb_sterilizer.Name = "tb_sterilizer";
            this.tb_sterilizer.ReadOnly = true;
            this.tb_sterilizer.Size = new System.Drawing.Size(120, 25);
            this.tb_sterilizer.TabIndex = 3;
            this.tb_sterilizer.ThemeName = "Office2007Silver";
            // 
            // tb_barcode
            // 
            this.tb_barcode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_barcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_barcode.Location = new System.Drawing.Point(89, 20);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(120, 25);
            this.tb_barcode.TabIndex = 2;
            this.tb_barcode.ThemeName = "Office2007Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel2.Location = new System.Drawing.Point(360, 21);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 23);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "灭菌批次：";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel1.Location = new System.Drawing.Point(17, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 23);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "灭 菌 器：";
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
            gridViewTextBoxColumn1.HeaderText = "包名称";
            gridViewTextBoxColumn1.Name = "name";
            gridViewTextBoxColumn1.Width = 180;
            gridViewTextBoxColumn2.HeaderText = "包条码";
            gridViewTextBoxColumn2.Name = "barcode";
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "病人";
            gridViewTextBoxColumn3.Name = "people";
            gridViewTextBoxColumn3.Width = 180;
            this.dgv_01.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(893, 435);
            this.dgv_01.TabIndex = 0;
            this.dgv_01.Text = "radGridView1";
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // HCSRS_setpatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 511);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(901, 543);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(901, 543);
            this.Name = "HCSRS_setpatient";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(901, 543);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "已使用的包";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sterilizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView dgv_01;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tb_num;
        private Telerik.WinControls.UI.RadTextBox tb_sterilizer;
        private Telerik.WinControls.UI.RadTextBox tb_barcode;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}