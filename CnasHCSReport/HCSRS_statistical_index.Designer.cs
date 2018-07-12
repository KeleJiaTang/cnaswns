namespace Cnas.wns.CnasHCSReport
{
	partial class HCSRS_statistical_index
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_print = new Telerik.WinControls.UI.RadButton();
            this.but_import = new Telerik.WinControls.UI.RadButton();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.dgv_01 = new Telerik.WinControls.UI.RadGridView();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(977, 577);
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            this.radSplitContainer1.ThemeName = "Office2007Silver";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.radGroupBox1);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel1.Size = new System.Drawing.Size(977, 82);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.3568935F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -204);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Office2007Silver";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.but_cancel);
            this.radGroupBox1.Controls.Add(this.but_print);
            this.radGroupBox1.Controls.Add(this.but_import);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(977, 82);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.ThemeName = "Office2007Silver";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(850, 12);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_print
            // 
            this.but_print.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_print.Location = new System.Drawing.Point(122, 12);
            this.but_print.Name = "but_print";
            this.but_print.Size = new System.Drawing.Size(99, 42);
            this.but_print.TabIndex = 2;
            this.but_print.Text = "打印列表";
            this.but_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_print.ThemeName = "Office2007Silver";
            this.but_print.Click += new System.EventHandler(this.but_print_Click);
            // 
            // but_import
            // 
            this.but_import.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_import.Location = new System.Drawing.Point(12, 12);
            this.but_import.Name = "but_import";
            this.but_import.Size = new System.Drawing.Size(99, 42);
            this.but_import.TabIndex = 1;
            this.but_import.Text = "导出列表";
            this.but_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_import.ThemeName = "Office2007Silver";
            this.but_import.Click += new System.EventHandler(this.but_import_Click);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.dgv_01);
            this.splitPanel2.Location = new System.Drawing.Point(0, 86);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel2.Size = new System.Drawing.Size(977, 491);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.3568935F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 204);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2007Silver";
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
            this.dgv_01.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgv_01.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_01.ShowGroupPanel = false;
            this.dgv_01.Size = new System.Drawing.Size(977, 491);
            this.dgv_01.TabIndex = 0;
            this.dgv_01.ThemeName = "Office2007Silver";
            // 
            // HCSRS_statistical_index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(977, 577);
            this.Controls.Add(this.radSplitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(985, 609);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(985, 609);
            this.Name = "HCSRS_statistical_index";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(985, 609);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_import)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
		private Telerik.WinControls.UI.SplitPanel splitPanel1;
		private Telerik.WinControls.UI.SplitPanel splitPanel2;
		private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
		private Telerik.WinControls.UI.RadButton but_print;
		private Telerik.WinControls.UI.RadButton but_import;
		private Telerik.WinControls.UI.RadGridView dgv_01;
		private Telerik.WinControls.RadThemeManager radThemeManager1;
		private Telerik.WinControls.UI.RadButton but_cancel;
	}
}