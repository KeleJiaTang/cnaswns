namespace Cnas.wns.CnasHCSReport
{
    partial class FindSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.gb_top = new System.Windows.Forms.GroupBox();
            this.cb_sel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_cycle = new System.Windows.Forms.ComboBox();
            this.tb_sterbar = new System.Windows.Forms.TextBox();
            this.tb_stername = new System.Windows.Forms.TextBox();
            this.tb_batch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_select = new System.Windows.Forms.Button();
            this.dgv_02 = new System.Windows.Forms.DataGridView();
            this.s_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.set_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_sterilizer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_costcenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_expiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_packuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.gb_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // sp
            // 
            this.sp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp.Location = new System.Drawing.Point(0, 0);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.gb_top);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.dgv_02);
            this.sp.Size = new System.Drawing.Size(1000, 572);
            this.sp.SplitterDistance = 143;
            this.sp.TabIndex = 2;
            // 
            // gb_top
            // 
            this.gb_top.BackColor = System.Drawing.SystemColors.Window;
            this.gb_top.Controls.Add(this.cb_sel);
            this.gb_top.Controls.Add(this.label3);
            this.gb_top.Controls.Add(this.cb_cycle);
            this.gb_top.Controls.Add(this.tb_sterbar);
            this.gb_top.Controls.Add(this.tb_stername);
            this.gb_top.Controls.Add(this.tb_batch);
            this.gb_top.Controls.Add(this.label2);
            this.gb_top.Controls.Add(this.label1);
            this.gb_top.Controls.Add(this.but_Cancel);
            this.gb_top.Controls.Add(this.but_select);
            this.gb_top.Location = new System.Drawing.Point(4, 0);
            this.gb_top.Name = "gb_top";
            this.gb_top.Size = new System.Drawing.Size(997, 140);
            this.gb_top.TabIndex = 0;
            this.gb_top.TabStop = false;
            // 
            // cb_sel
            // 
            this.cb_sel.AutoSize = true;
            this.cb_sel.Location = new System.Drawing.Point(6, 117);
            this.cb_sel.Name = "cb_sel";
            this.cb_sel.Size = new System.Drawing.Size(52, 17);
            this.cb_sel.TabIndex = 240;
            this.cb_sel.Text = "全选";
            this.cb_sel.UseVisualStyleBackColor = true;
            this.cb_sel.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 239;
            this.label3.Text = "召回到";
            // 
            // cb_cycle
            // 
            this.cb_cycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cycle.FormattingEnabled = true;
            this.cb_cycle.Location = new System.Drawing.Point(372, 36);
            this.cb_cycle.Name = "cb_cycle";
            this.cb_cycle.Size = new System.Drawing.Size(121, 20);
            this.cb_cycle.TabIndex = 238;
            this.cb_cycle.SelectedIndexChanged += new System.EventHandler(this.cb_cycle_SelectedIndexChanged);
            // 
            // tb_sterbar
            // 
            this.tb_sterbar.Location = new System.Drawing.Point(11, 36);
            this.tb_sterbar.Name = "tb_sterbar";
            this.tb_sterbar.ReadOnly = true;
            this.tb_sterbar.Size = new System.Drawing.Size(100, 21);
            this.tb_sterbar.TabIndex = 237;
            // 
            // tb_stername
            // 
            this.tb_stername.Location = new System.Drawing.Point(117, 36);
            this.tb_stername.Name = "tb_stername";
            this.tb_stername.ReadOnly = true;
            this.tb_stername.Size = new System.Drawing.Size(100, 21);
            this.tb_stername.TabIndex = 236;
            // 
            // tb_batch
            // 
            this.tb_batch.Location = new System.Drawing.Point(73, 63);
            this.tb_batch.Name = "tb_batch";
            this.tb_batch.ReadOnly = true;
            this.tb_batch.Size = new System.Drawing.Size(100, 21);
            this.tb_batch.TabIndex = 235;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 234;
            this.label2.Text = "灭菌批次:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 233;
            this.label1.Text = "灭菌器";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_Cancel.Image")));
            this.but_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Cancel.Location = new System.Drawing.Point(889, 20);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(99, 42);
            this.but_Cancel.TabIndex = 232;
            this.but_Cancel.Text = "      关闭";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_select
            // 
            this.but_select.Location = new System.Drawing.Point(790, 20);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(99, 43);
            this.but_select.TabIndex = 26;
            this.but_select.Text = "召回";
            this.but_select.UseVisualStyleBackColor = true;
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // dgv_02
            // 
            this.dgv_02.AllowUserToAddRows = false;
            this.dgv_02.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_02.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_02.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_select,
            this.id,
            this.base_set,
            this.set_barcode,
            this.s_storage,
            this.s_cycle,
            this.s_sterilizer,
            this.s_batch,
            this.s_customer,
            this.s_costcenter,
            this.s_expiration,
            this.s_packuser,
            this.s_assessor});
            this.dgv_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_02.Location = new System.Drawing.Point(0, 0);
            this.dgv_02.MultiSelect = false;
            this.dgv_02.Name = "dgv_02";
            this.dgv_02.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_02.RowHeadersVisible = false;
            this.dgv_02.RowTemplate.Height = 23;
            this.dgv_02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_02.Size = new System.Drawing.Size(1000, 425);
            this.dgv_02.TabIndex = 2;
            // 
            // s_select
            // 
            this.s_select.HeaderText = "召回";
            this.s_select.Name = "s_select";
            // 
            // id
            // 
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // base_set
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.base_set.DefaultCellStyle = dataGridViewCellStyle1;
            this.base_set.HeaderText = "器械包";
            this.base_set.Name = "base_set";
            // 
            // set_barcode
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.set_barcode.DefaultCellStyle = dataGridViewCellStyle2;
            this.set_barcode.HeaderText = "包条码";
            this.set_barcode.Name = "set_barcode";
            // 
            // s_storage
            // 
            this.s_storage.HeaderText = "存储点";
            this.s_storage.Name = "s_storage";
            // 
            // s_cycle
            // 
            this.s_cycle.HeaderText = "所在循环位置";
            this.s_cycle.Name = "s_cycle";
            // 
            // s_sterilizer
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_sterilizer.DefaultCellStyle = dataGridViewCellStyle3;
            this.s_sterilizer.HeaderText = "灭菌器";
            this.s_sterilizer.Name = "s_sterilizer";
            // 
            // s_batch
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_batch.DefaultCellStyle = dataGridViewCellStyle4;
            this.s_batch.HeaderText = "灭菌批次";
            this.s_batch.Name = "s_batch";
            // 
            // s_customer
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.s_customer.HeaderText = "客户";
            this.s_customer.Name = "s_customer";
            // 
            // s_costcenter
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_costcenter.DefaultCellStyle = dataGridViewCellStyle6;
            this.s_costcenter.HeaderText = "成本中心";
            this.s_costcenter.Name = "s_costcenter";
            // 
            // s_expiration
            // 
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_expiration.DefaultCellStyle = dataGridViewCellStyle7;
            this.s_expiration.HeaderText = "有效期";
            this.s_expiration.Name = "s_expiration";
            // 
            // s_packuser
            // 
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_packuser.DefaultCellStyle = dataGridViewCellStyle8;
            this.s_packuser.HeaderText = "打包员";
            this.s_packuser.Name = "s_packuser";
            // 
            // s_assessor
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_assessor.DefaultCellStyle = dataGridViewCellStyle9;
            this.s_assessor.HeaderText = "审核人";
            this.s_assessor.Name = "s_assessor";
            // 
            // FindSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 572);
            this.Controls.Add(this.sp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FindSet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "器械包";
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
            this.sp.ResumeLayout(false);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp;
        private System.Windows.Forms.GroupBox gb_top;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_select;
        private System.Windows.Forms.DataGridView dgv_02;
        private System.Windows.Forms.TextBox tb_sterbar;
        private System.Windows.Forms.TextBox tb_stername;
        private System.Windows.Forms.TextBox tb_batch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_cycle;
        private System.Windows.Forms.CheckBox cb_sel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn s_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_set;
        private System.Windows.Forms.DataGridViewTextBoxColumn set_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sterilizer;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_costcenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_expiration;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_packuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_assessor;
    }
}