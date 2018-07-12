namespace Cnas.wns.CnasHCSReport
{
    partial class reportTable
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_quarter = new System.Windows.Forms.DataGridView();
            this.name02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratio02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_year = new System.Windows.Forms.DataGridView();
            this.name03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthnum03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_month = new System.Windows.Forms.DataGridView();
            this.name01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratio01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.but_ok = new System.Windows.Forms.Button();
            this.cb_month = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_onlyyear = new System.Windows.Forms.ComboBox();
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quarter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_month)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_quarter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgv_year, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgv_month, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1142, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_quarter
            // 
            this.dgv_quarter.AllowUserToAddRows = false;
            this.dgv_quarter.AllowUserToDeleteRows = false;
            this.dgv_quarter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_quarter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_quarter.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_quarter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_quarter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_quarter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_quarter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name02,
            this.num02,
            this.ratio02});
            this.dgv_quarter.Location = new System.Drawing.Point(574, 59);
            this.dgv_quarter.Name = "dgv_quarter";
            this.dgv_quarter.RowHeadersVisible = false;
            this.dgv_quarter.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_quarter.RowTemplate.Height = 23;
            this.dgv_quarter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_quarter.Size = new System.Drawing.Size(565, 268);
            this.dgv_quarter.TabIndex = 4;
            // 
            // name02
            // 
            this.name02.HeaderText = "指标名称";
            this.name02.Name = "name02";
            // 
            // num02
            // 
            this.num02.HeaderText = "总数量";
            this.num02.Name = "num02";
            // 
            // ratio02
            // 
            this.ratio02.HeaderText = "比率";
            this.ratio02.Name = "ratio02";
            // 
            // dgv_year
            // 
            this.dgv_year.AllowUserToAddRows = false;
            this.dgv_year.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_year.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_year.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_year.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_year.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name03,
            this.num03,
            this.monthnum03,
            this.year03,
            this.index03});
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_year, 2);
            this.dgv_year.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_year.Location = new System.Drawing.Point(3, 389);
            this.dgv_year.Name = "dgv_year";
            this.dgv_year.RowHeadersVisible = false;
            this.dgv_year.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_year.RowTemplate.Height = 23;
            this.dgv_year.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_year.Size = new System.Drawing.Size(1136, 269);
            this.dgv_year.TabIndex = 5;
            // 
            // name03
            // 
            this.name03.HeaderText = "指标名称";
            this.name03.Name = "name03";
            // 
            // num03
            // 
            this.num03.HeaderText = "总数量";
            this.num03.Name = "num03";
            // 
            // monthnum03
            // 
            this.monthnum03.HeaderText = "月平均数量";
            this.monthnum03.Name = "monthnum03";
            // 
            // year03
            // 
            this.year03.HeaderText = "上年同期";
            this.year03.Name = "year03";
            // 
            // index03
            // 
            this.index03.HeaderText = "对比指数";
            this.index03.Name = "index03";
            // 
            // dgv_month
            // 
            this.dgv_month.AllowUserToAddRows = false;
            this.dgv_month.AllowUserToDeleteRows = false;
            this.dgv_month.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_month.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_month.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_month.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_month.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_month.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name01,
            this.num01,
            this.ratio01});
            this.dgv_month.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_month.Location = new System.Drawing.Point(3, 59);
            this.dgv_month.Name = "dgv_month";
            this.dgv_month.RowHeadersVisible = false;
            this.dgv_month.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_month.RowTemplate.Height = 23;
            this.dgv_month.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_month.Size = new System.Drawing.Size(565, 268);
            this.dgv_month.TabIndex = 3;
            // 
            // name01
            // 
            this.name01.HeaderText = "指标名称";
            this.name01.Name = "name01";
            // 
            // num01
            // 
            this.num01.HeaderText = "总数量";
            this.num01.Name = "num01";
            // 
            // ratio01
            // 
            this.ratio01.HeaderText = "比率";
            this.ratio01.Name = "ratio01";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.but_ok, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_month, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(565, 50);
            this.tableLayoutPanel2.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "月";
            // 
            // but_ok
            // 
            this.but_ok.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.but_ok.Location = new System.Drawing.Point(487, 13);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 23);
            this.but_ok.TabIndex = 2;
            this.but_ok.Text = "确定";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // cb_month
            // 
            this.cb_month.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_month.FormattingEnabled = true;
            this.cb_month.Location = new System.Drawing.Point(408, 15);
            this.cb_month.Name = "cb_month";
            this.cb_month.Size = new System.Drawing.Size(50, 20);
            this.cb_month.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "月度指标";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(329, 15);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(50, 20);
            this.comboBox3.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button1, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(574, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(565, 50);
            this.tableLayoutPanel3.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "季度指标";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(396, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(50, 20);
            this.comboBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "年";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(317, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(50, 20);
            this.comboBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(487, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "季度";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.cb_onlyyear, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 333);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1136, 50);
            this.tableLayoutPanel4.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 34);
            this.label7.TabIndex = 5;
            this.label7.Text = "年度指标";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Location = new System.Drawing.Point(1058, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1035, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "年";
            // 
            // cb_onlyyear
            // 
            this.cb_onlyyear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_onlyyear.FormattingEnabled = true;
            this.cb_onlyyear.Location = new System.Drawing.Point(979, 15);
            this.cb_onlyyear.Name = "cb_onlyyear";
            this.cb_onlyyear.Size = new System.Drawing.Size(50, 20);
            this.cb_onlyyear.TabIndex = 10;
            // 
            // cb_year
            // 
            this.cb_year.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Location = new System.Drawing.Point(329, 10);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(50, 20);
            this.cb_year.TabIndex = 4;
            // 
            // reportTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "reportTable";
            this.Text = "reportTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quarter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_month)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_quarter;
        private System.Windows.Forms.DataGridView dgv_month;
        private System.Windows.Forms.DataGridView dgv_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn name02;
        private System.Windows.Forms.DataGridViewTextBoxColumn num02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratio02;
        private System.Windows.Forms.DataGridViewTextBoxColumn name01;
        private System.Windows.Forms.DataGridViewTextBoxColumn num01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratio01;
        private System.Windows.Forms.DataGridViewTextBoxColumn name03;
        private System.Windows.Forms.DataGridViewTextBoxColumn num03;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthnum03;
        private System.Windows.Forms.DataGridViewTextBoxColumn year03;
        private System.Windows.Forms.DataGridViewTextBoxColumn index03;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.ComboBox cb_month;
        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_onlyyear;



    }
}