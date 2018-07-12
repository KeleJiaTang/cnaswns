namespace Cnas.wns.CnasHCSReport
{
    partial class ColumnTable
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
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.WinControls.UI.CartesianArea cartesianArea2 = new Telerik.WinControls.UI.CartesianArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnTable));
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cb_month = new System.Windows.Forms.ComboBox();
            this.but_ok = new System.Windows.Forms.Button();
            this.radChartView2 = new Telerik.WinControls.UI.RadChartView();
            this.c1List1 = new C1.Win.C1List.C1List();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChartView1.Location = new System.Drawing.Point(512, 3);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(503, 550);
            this.radChartView1.TabIndex = 1;
            this.radChartView1.Text = "radChartView1";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(761, 104);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(50, 20);
            this.comboBox3.TabIndex = 11;
            // 
            // cb_month
            // 
            this.cb_month.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_month.FormattingEnabled = true;
            this.cb_month.Location = new System.Drawing.Point(834, 104);
            this.cb_month.Name = "cb_month";
            this.cb_month.Size = new System.Drawing.Size(50, 20);
            this.cb_month.TabIndex = 12;
            // 
            // but_ok
            // 
            this.but_ok.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.but_ok.Location = new System.Drawing.Point(909, 104);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 23);
            this.but_ok.TabIndex = 13;
            this.but_ok.Text = "确定";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // radChartView2
            // 
            this.radChartView2.AreaDesign = cartesianArea2;
            this.radChartView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChartView2.Location = new System.Drawing.Point(3, 3);
            this.radChartView2.Name = "radChartView2";
            this.radChartView2.ShowGrid = false;
            this.radChartView2.Size = new System.Drawing.Size(503, 550);
            this.radChartView2.TabIndex = 14;
            this.radChartView2.Text = "radChartView3";
            // 
            // c1List1
            // 
            this.c1List1.AddItemSeparator = ';';
            this.c1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark;
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images"))));
            this.c1List1.Location = new System.Drawing.Point(420, 481);
            this.c1List1.MatchEntryTimeout = ((long)(2000));
            this.c1List1.Name = "c1List1";
            this.c1List1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1List1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1List1.PreviewInfo.ZoomFactor = 75D;
            this.c1List1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1List1.PrintInfo.PageSettings")));
            this.c1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1List1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1List1.ShowHeaderCheckBox = false;
            this.c1List1.Size = new System.Drawing.Size(8, 8);
            this.c1List1.TabIndex = 15;
            this.c1List1.Text = "c1List1";
            this.c1List1.PropBag = resources.GetString("c1List1.PropBag");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radChartView2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radChartView1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 556);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // ColumnTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 556);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.c1List1);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.cb_month);
            this.Controls.Add(this.comboBox3);
            this.Name = "ColumnTable";
            this.Text = "ColumnTable";
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadChartView radChartView1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox cb_month;
        private System.Windows.Forms.Button but_ok;
        private Telerik.WinControls.UI.RadChartView radChartView2;
        private C1.Win.C1List.C1List c1List1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;





    }
}