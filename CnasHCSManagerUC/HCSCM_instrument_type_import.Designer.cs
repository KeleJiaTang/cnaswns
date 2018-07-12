namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_instrument_type_import
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
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.radBut_delete = new Telerik.WinControls.UI.RadButton();
            this.but_import = new Telerik.WinControls.UI.RadButton();
            this.radBut_downloadw = new Telerik.WinControls.UI.RadButton();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBut_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBut_downloadw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
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
            this.sp_main.Panel1.Controls.Add(this.but_cancel);
            this.sp_main.Panel1.Controls.Add(this.but_ok);
            this.sp_main.Panel1.Controls.Add(this.radBut_delete);
            this.sp_main.Panel1.Controls.Add(this.but_import);
            this.sp_main.Panel1.Controls.Add(this.radBut_downloadw);
            this.sp_main.Panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(1066, 625);
            this.sp_main.SplitterDistance = 83;
            this.sp_main.TabIndex = 0;
            // 
            // but_cancel
            // 
            this.but_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(1869, 13);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 0;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.radBut_close_Click);
            // 
            // but_ok
            // 
            this.but_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(1764, 13);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 0;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.radBut_ok_Click);
            // 
            // radBut_delete
            // 
            this.radBut_delete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radBut_delete.Location = new System.Drawing.Point(118, 13);
            this.radBut_delete.Name = "radBut_delete";
            this.radBut_delete.Size = new System.Drawing.Size(99, 42);
            this.radBut_delete.TabIndex = 0;
            this.radBut_delete.Text = "删除行";
            this.radBut_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radBut_delete.ThemeName = "Office2007Silver";
            this.radBut_delete.Click += new System.EventHandler(this.radBut_delete_Click);
            // 
            // but_import
            // 
            this.but_import.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_import.Location = new System.Drawing.Point(13, 13);
            this.but_import.Name = "but_import";
            this.but_import.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_import.Size = new System.Drawing.Size(99, 42);
            this.but_import.TabIndex = 0;
            this.but_import.Text = "导  入";
            this.but_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_import.ThemeName = "Office2007Silver";
            this.but_import.Click += new System.EventHandler(this.radBut_import_Click);
            // 
            // radBut_downloadw
            // 
            this.radBut_downloadw.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radBut_downloadw.Location = new System.Drawing.Point(223, 13);
            this.radBut_downloadw.Name = "radBut_downloadw";
            this.radBut_downloadw.Size = new System.Drawing.Size(136, 42);
            this.radBut_downloadw.TabIndex = 0;
            this.radBut_downloadw.Text = "下载导入模板";
            this.radBut_downloadw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radBut_downloadw.ThemeName = "Office2007Silver";
            this.radBut_downloadw.Click += new System.EventHandler(this.radBut_downloadw_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowHeadersWidth = 80;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.Size = new System.Drawing.Size(1066, 538);
            this.dgv_01.TabIndex = 0;
            this.dgv_01.CurrentCellChanged += new System.EventHandler(this.dgv_01_CurrentCellChanged);
            this.dgv_01.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_01_DataError);
            // 
            // HCSCM_instrument_type_import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 625);
            this.Controls.Add(this.sp_main);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HCSCM_instrument_type_import";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入物品列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBut_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBut_downloadw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private Telerik.WinControls.UI.RadButton radBut_downloadw;
        private Telerik.WinControls.UI.RadButton but_ok;
        private Telerik.WinControls.UI.RadButton but_import;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private System.Windows.Forms.DataGridView dgv_01;
        private Telerik.WinControls.UI.RadButton radBut_delete;
    }
}