namespace Cnas.wns.CnasHCSSystemUC
{
    partial class HCSSM_app_bpm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_app_bpm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gp_00 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_app = new System.Windows.Forms.ComboBox();
            this.but_01 = new System.Windows.Forms.Button();
            this.gp_01 = new System.Windows.Forms.GroupBox();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.isselected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pd_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pd_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pd_scan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp_02 = new System.Windows.Forms.GroupBox();
            this.dgv_02 = new System.Windows.Forms.DataGridView();
            this.pd_code02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pd_name02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pd_scan02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp_03 = new System.Windows.Forms.GroupBox();
            this.dgv_03 = new System.Windows.Forms.DataGridView();
            this.pd_code2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pd_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_01 = new System.Windows.Forms.TextBox();
            this.chb_wf = new System.Windows.Forms.CheckBox();
            this.tabc_01 = new System.Windows.Forms.TabControl();
            this.tabp_11 = new System.Windows.Forms.TabPage();
            this.tabp_12 = new System.Windows.Forms.TabPage();
            this.but_02 = new System.Windows.Forms.Button();
            this.tb_02 = new System.Windows.Forms.TextBox();
            this.tabp_13 = new System.Windows.Forms.TabPage();
            this.gp_00.SuspendLayout();
            this.gp_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            this.gp_02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
            this.gp_03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_03)).BeginInit();
            this.tabc_01.SuspendLayout();
            this.tabp_11.SuspendLayout();
            this.tabp_12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_00
            // 
            this.gp_00.Controls.Add(this.label1);
            this.gp_00.Controls.Add(this.cb_app);
            this.gp_00.Location = new System.Drawing.Point(17, 5);
            this.gp_00.Name = "gp_00";
            this.gp_00.Size = new System.Drawing.Size(984, 51);
            this.gp_00.TabIndex = 20;
            this.gp_00.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择App：";
            // 
            // cb_app
            // 
            this.cb_app.BackColor = System.Drawing.Color.Yellow;
            this.cb_app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_app.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_app.FormattingEnabled = true;
            this.cb_app.Location = new System.Drawing.Point(99, 15);
            this.cb_app.Name = "cb_app";
            this.cb_app.Size = new System.Drawing.Size(541, 28);
            this.cb_app.TabIndex = 0;
            this.cb_app.SelectedValueChanged += new System.EventHandler(this.cb_app_SelectedValueChanged);
            // 
            // but_01
            // 
            this.but_01.Enabled = false;
            this.but_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_01.Image = ((System.Drawing.Image)(resources.GetObject("but_01.Image")));
            this.but_01.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_01.Location = new System.Drawing.Point(516, 679);
            this.but_01.Name = "but_01";
            this.but_01.Size = new System.Drawing.Size(119, 42);
            this.but_01.TabIndex = 25;
            this.but_01.Text = "保存流程";
            this.but_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_01.UseVisualStyleBackColor = true;
            this.but_01.Click += new System.EventHandler(this.but_01_Click);
            // 
            // gp_01
            // 
            this.gp_01.Controls.Add(this.dgv_01);
            this.gp_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gp_01.Location = new System.Drawing.Point(17, 63);
            this.gp_01.Name = "gp_01";
            this.gp_01.Size = new System.Drawing.Size(327, 661);
            this.gp_01.TabIndex = 26;
            this.gp_01.TabStop = false;
            this.gp_01.Text = "可选流程";
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_01.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isselected,
            this.pd_code,
            this.pd_name,
            this.pd_scan});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(3, 23);
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(321, 635);
            this.dgv_01.TabIndex = 1;
            this.dgv_01.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_01_CellClick);
            // 
            // isselected
            // 
            this.isselected.FillWeight = 30.27647F;
            this.isselected.HeaderText = "";
            this.isselected.Name = "isselected";
            this.isselected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isselected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pd_code
            // 
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_code.DefaultCellStyle = dataGridViewCellStyle17;
            this.pd_code.FillWeight = 69.28934F;
            this.pd_code.HeaderText = "编号";
            this.pd_code.Name = "pd_code";
            this.pd_code.ReadOnly = true;
            // 
            // pd_name
            // 
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_name.DefaultCellStyle = dataGridViewCellStyle18;
            this.pd_name.FillWeight = 104.1511F;
            this.pd_name.HeaderText = "名称";
            this.pd_name.Name = "pd_name";
            this.pd_name.ReadOnly = true;
            // 
            // pd_scan
            // 
            this.pd_scan.HeaderText = "pd_scan";
            this.pd_scan.Name = "pd_scan";
            this.pd_scan.ReadOnly = true;
            this.pd_scan.Visible = false;
            // 
            // gp_02
            // 
            this.gp_02.Controls.Add(this.dgv_02);
            this.gp_02.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gp_02.Location = new System.Drawing.Point(350, 63);
            this.gp_02.Name = "gp_02";
            this.gp_02.Size = new System.Drawing.Size(288, 610);
            this.gp_02.TabIndex = 27;
            this.gp_02.TabStop = false;
            this.gp_02.Text = "已选流程";
            // 
            // dgv_02
            // 
            this.dgv_02.AllowUserToAddRows = false;
            this.dgv_02.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_02.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_02.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_02.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pd_code02,
            this.pd_name02,
            this.pd_scan02});
            this.dgv_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_02.Location = new System.Drawing.Point(3, 23);
            this.dgv_02.Name = "dgv_02";
            this.dgv_02.RowHeadersVisible = false;
            this.dgv_02.RowTemplate.Height = 23;
            this.dgv_02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_02.Size = new System.Drawing.Size(282, 584);
            this.dgv_02.TabIndex = 1;
            this.dgv_02.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_02_CellClick);
            // 
            // pd_code02
            // 
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_code02.DefaultCellStyle = dataGridViewCellStyle19;
            this.pd_code02.FillWeight = 69.28934F;
            this.pd_code02.HeaderText = "编号";
            this.pd_code02.Name = "pd_code02";
            this.pd_code02.ReadOnly = true;
            // 
            // pd_name02
            // 
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_name02.DefaultCellStyle = dataGridViewCellStyle20;
            this.pd_name02.FillWeight = 104.1511F;
            this.pd_name02.HeaderText = "名称";
            this.pd_name02.Name = "pd_name02";
            this.pd_name02.ReadOnly = true;
            // 
            // pd_scan02
            // 
            this.pd_scan02.HeaderText = "pd_scan";
            this.pd_scan02.Name = "pd_scan02";
            this.pd_scan02.ReadOnly = true;
            this.pd_scan02.Visible = false;
            // 
            // gp_03
            // 
            this.gp_03.Controls.Add(this.dgv_03);
            this.gp_03.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gp_03.Location = new System.Drawing.Point(3, -5);
            this.gp_03.Name = "gp_03";
            this.gp_03.Size = new System.Drawing.Size(321, 609);
            this.gp_03.TabIndex = 31;
            this.gp_03.TabStop = false;
            // 
            // dgv_03
            // 
            this.dgv_03.AllowUserToAddRows = false;
            this.dgv_03.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_03.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_03.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_03.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_03.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pd_code2,
            this.pd_name2,
            this.pr_priority,
            this.pr_condition});
            this.dgv_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_03.Location = new System.Drawing.Point(3, 23);
            this.dgv_03.Name = "dgv_03";
            this.dgv_03.RowHeadersVisible = false;
            this.dgv_03.RowTemplate.Height = 23;
            this.dgv_03.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_03.Size = new System.Drawing.Size(315, 583);
            this.dgv_03.TabIndex = 2;
            this.dgv_03.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_03_CellClick);
            // 
            // pd_code2
            // 
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_code2.DefaultCellStyle = dataGridViewCellStyle21;
            this.pd_code2.FillWeight = 70.7382F;
            this.pd_code2.HeaderText = "编号";
            this.pd_code2.Name = "pd_code2";
            this.pd_code2.ReadOnly = true;
            // 
            // pd_name2
            // 
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_name2.DefaultCellStyle = dataGridViewCellStyle22;
            this.pd_name2.FillWeight = 88.93038F;
            this.pd_name2.HeaderText = "名称";
            this.pd_name2.Name = "pd_name2";
            this.pd_name2.ReadOnly = true;
            // 
            // pr_priority
            // 
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pr_priority.DefaultCellStyle = dataGridViewCellStyle23;
            this.pr_priority.FillWeight = 85.38593F;
            this.pr_priority.HeaderText = "优先级";
            this.pr_priority.Name = "pr_priority";
            this.pr_priority.ReadOnly = true;
            this.pr_priority.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pr_priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pr_condition
            // 
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pr_condition.DefaultCellStyle = dataGridViewCellStyle24;
            this.pr_condition.FillWeight = 85.38593F;
            this.pr_condition.HeaderText = "执行条件";
            this.pr_condition.Name = "pr_condition";
            this.pr_condition.ReadOnly = true;
            this.pr_condition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pr_condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tb_01
            // 
            this.tb_01.BackColor = System.Drawing.Color.White;
            this.tb_01.Location = new System.Drawing.Point(8, 610);
            this.tb_01.Multiline = true;
            this.tb_01.Name = "tb_01";
            this.tb_01.ReadOnly = true;
            this.tb_01.Size = new System.Drawing.Size(316, 40);
            this.tb_01.TabIndex = 33;
            // 
            // chb_wf
            // 
            this.chb_wf.AutoSize = true;
            this.chb_wf.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chb_wf.Location = new System.Drawing.Point(368, 689);
            this.chb_wf.Name = "chb_wf";
            this.chb_wf.Size = new System.Drawing.Size(92, 24);
            this.chb_wf.TabIndex = 34;
            this.chb_wf.Text = "全选流程";
            this.chb_wf.UseVisualStyleBackColor = true;
            this.chb_wf.CheckedChanged += new System.EventHandler(this.chb_wf_CheckedChanged);
            // 
            // tabc_01
            // 
            this.tabc_01.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabc_01.Controls.Add(this.tabp_11);
            this.tabc_01.Controls.Add(this.tabp_12);
            this.tabc_01.Controls.Add(this.tabp_13);
            this.tabc_01.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabc_01.Location = new System.Drawing.Point(644, 63);
            this.tabc_01.Multiline = true;
            this.tabc_01.Name = "tabc_01";
            this.tabc_01.SelectedIndex = 0;
            this.tabc_01.Size = new System.Drawing.Size(356, 661);
            this.tabc_01.TabIndex = 35;
            // 
            // tabp_11
            // 
            this.tabp_11.Controls.Add(this.gp_03);
            this.tabp_11.Controls.Add(this.tb_01);
            this.tabp_11.Location = new System.Drawing.Point(4, 4);
            this.tabp_11.Name = "tabp_11";
            this.tabp_11.Padding = new System.Windows.Forms.Padding(3);
            this.tabp_11.Size = new System.Drawing.Size(322, 653);
            this.tabp_11.TabIndex = 0;
            this.tabp_11.Text = "下一步流程";
            this.tabp_11.UseVisualStyleBackColor = true;
            // 
            // tabp_12
            // 
            this.tabp_12.BackColor = System.Drawing.SystemColors.Control;
            this.tabp_12.Controls.Add(this.but_02);
            this.tabp_12.Controls.Add(this.tb_02);
            this.tabp_12.Location = new System.Drawing.Point(4, 4);
            this.tabp_12.Name = "tabp_12";
            this.tabp_12.Padding = new System.Windows.Forms.Padding(3);
            this.tabp_12.Size = new System.Drawing.Size(322, 653);
            this.tabp_12.TabIndex = 1;
            this.tabp_12.Text = "条码参数";
            // 
            // but_02
            // 
            this.but_02.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_02.Image = ((System.Drawing.Image)(resources.GetObject("but_02.Image")));
            this.but_02.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_02.Location = new System.Drawing.Point(207, 107);
            this.but_02.Name = "but_02";
            this.but_02.Size = new System.Drawing.Size(115, 42);
            this.but_02.TabIndex = 35;
            this.but_02.Text = "保存参数";
            this.but_02.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_02.UseVisualStyleBackColor = true;
            this.but_02.Click += new System.EventHandler(this.but_02_Click);
            // 
            // tb_02
            // 
            this.tb_02.BackColor = System.Drawing.Color.White;
            this.tb_02.Location = new System.Drawing.Point(6, 20);
            this.tb_02.Multiline = true;
            this.tb_02.Name = "tb_02";
            this.tb_02.Size = new System.Drawing.Size(316, 72);
            this.tb_02.TabIndex = 34;
            // 
            // tabp_13
            // 
            this.tabp_13.BackColor = System.Drawing.SystemColors.Control;
            this.tabp_13.Location = new System.Drawing.Point(4, 4);
            this.tabp_13.Name = "tabp_13";
            this.tabp_13.Size = new System.Drawing.Size(322, 653);
            this.tabp_13.TabIndex = 2;
            this.tabp_13.Text = "其他";
            // 
            // HCSSM_app_bpm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1016, 738);
            this.Controls.Add(this.tabc_01);
            this.Controls.Add(this.chb_wf);
            this.Controls.Add(this.gp_02);
            this.Controls.Add(this.gp_01);
            this.Controls.Add(this.gp_00);
            this.Controls.Add(this.but_01);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 770);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 770);
            this.Name = "HCSSM_app_bpm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1024, 770);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流程配置";
            this.Load += new System.EventHandler(this.HCSSM_app_bpm_Load);
            this.gp_00.ResumeLayout(false);
            this.gp_00.PerformLayout();
            this.gp_01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.gp_02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
            this.gp_03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_03)).EndInit();
            this.tabc_01.ResumeLayout(false);
            this.tabp_11.ResumeLayout(false);
            this.tabp_11.PerformLayout();
            this.tabp_12.ResumeLayout(false);
            this.tabp_12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_00;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_app;
        private System.Windows.Forms.Button but_01;
        private System.Windows.Forms.GroupBox gp_01;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.GroupBox gp_02;
        private System.Windows.Forms.DataGridView dgv_02;
        private System.Windows.Forms.GroupBox gp_03;
        private System.Windows.Forms.DataGridView dgv_03;
        private System.Windows.Forms.TextBox tb_01;
        private System.Windows.Forms.CheckBox chb_wf;
        private System.Windows.Forms.TabControl tabc_01;
        private System.Windows.Forms.TabPage tabp_11;
        private System.Windows.Forms.TabPage tabp_12;
        private System.Windows.Forms.TabPage tabp_13;
        private System.Windows.Forms.Button but_02;
        private System.Windows.Forms.TextBox tb_02;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isselected;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_scan;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_code02;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_name02;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_scan02;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_code2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_condition;
    }
}