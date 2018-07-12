namespace Cnas.wns.CnasHCSReport
{
    partial class SelectSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_select = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_cancel = new System.Windows.Forms.Button();
            this.cb_customer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_select = new System.Windows.Forms.Button();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.s_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_runcycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_costcenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_pack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_risk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_01);
            this.splitContainer1.Size = new System.Drawing.Size(716, 555);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tb_select);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.but_cancel);
            this.groupBox1.Controls.Add(this.cb_customer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.but_select);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 22);
            this.button1.TabIndex = 79;
            this.button1.Text = "查";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_select
            // 
            this.tb_select.Location = new System.Drawing.Point(475, 79);
            this.tb_select.Name = "tb_select";
            this.tb_select.Size = new System.Drawing.Size(151, 21);
            this.tb_select.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "查询：";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_cancel.Image")));
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(579, 16);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 76;
            this.but_cancel.Text = "关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // cb_customer
            // 
            this.cb_customer.FormattingEnabled = true;
            this.cb_customer.Location = new System.Drawing.Point(48, 79);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(179, 20);
            this.cb_customer.TabIndex = 2;
            this.cb_customer.SelectedIndexChanged += new System.EventHandler(this.cb_customer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "客户：";
            // 
            // but_select
            // 
            this.but_select.Location = new System.Drawing.Point(12, 17);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(107, 41);
            this.but_select.TabIndex = 0;
            this.but_select.Text = "选择器械包";
            this.but_select.UseVisualStyleBackColor = true;
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_barcode,
            this.s_name,
            this.s_runcycle,
            this.s_costcenter,
            this.s_customer,
            this.s_pack,
            this.s_risk});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.MultiSelect = false;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(716, 395);
            this.dgv_01.TabIndex = 0;
            this.dgv_01.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // s_barcode
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_barcode.DefaultCellStyle = dataGridViewCellStyle1;
            this.s_barcode.HeaderText = "条形码";
            this.s_barcode.Name = "s_barcode";
            this.s_barcode.ReadOnly = true;
            this.s_barcode.Width = 130;
            // 
            // s_name
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.s_name.HeaderText = "手术包名称";
            this.s_name.Name = "s_name";
            this.s_name.ReadOnly = true;
            // 
            // s_runcycle
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_runcycle.DefaultCellStyle = dataGridViewCellStyle3;
            this.s_runcycle.HeaderText = "手术包循环次数";
            this.s_runcycle.Name = "s_runcycle";
            this.s_runcycle.ReadOnly = true;
            // 
            // s_costcenter
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_costcenter.DefaultCellStyle = dataGridViewCellStyle4;
            this.s_costcenter.HeaderText = "成本中心";
            this.s_costcenter.Name = "s_costcenter";
            this.s_costcenter.ReadOnly = true;
            // 
            // s_customer
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.s_customer.HeaderText = "医院";
            this.s_customer.Name = "s_customer";
            this.s_customer.ReadOnly = true;
            // 
            // s_pack
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_pack.DefaultCellStyle = dataGridViewCellStyle6;
            this.s_pack.HeaderText = "打包材料";
            this.s_pack.Name = "s_pack";
            this.s_pack.ReadOnly = true;
            // 
            // s_risk
            // 
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_risk.DefaultCellStyle = dataGridViewCellStyle7;
            this.s_risk.HeaderText = "风险等级";
            this.s_risk.Name = "s_risk";
            this.s_risk.ReadOnly = true;
            // 
            // SelectSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 555);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectSet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_select;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_runcycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_costcenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_pack;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_risk;
    }
}