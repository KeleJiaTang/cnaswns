namespace Cnas.wns.CnasHCSReport
{
    partial class SterilizerDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SterilizerDevice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.gb_top = new System.Windows.Forms.GroupBox();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_select = new System.Windows.Forms.Button();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.gb_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
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
            this.sp.Panel2.Controls.Add(this.dgv_01);
            this.sp.Size = new System.Drawing.Size(515, 416);
            this.sp.SplitterDistance = 104;
            this.sp.TabIndex = 1;
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.but_Cancel);
            this.gb_top.Controls.Add(this.but_select);
            this.gb_top.Location = new System.Drawing.Point(0, 0);
            this.gb_top.Name = "gb_top";
            this.gb_top.Size = new System.Drawing.Size(523, 104);
            this.gb_top.TabIndex = 0;
            this.gb_top.TabStop = false;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("but_Cancel.Image")));
            this.but_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Cancel.Location = new System.Drawing.Point(245, 32);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(99, 42);
            this.but_Cancel.TabIndex = 232;
            this.but_Cancel.Text = "      关闭";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_select
            // 
            this.but_select.Location = new System.Drawing.Point(140, 32);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(99, 42);
            this.but_select.TabIndex = 26;
            this.but_select.Text = "选择";
            this.but_select.UseVisualStyleBackColor = true;
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.s_name,
            this.s_barcode});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(515, 308);
            this.dgv_01.TabIndex = 0;
            this.dgv_01.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_01_CellDoubleClick);
            // 
            // id
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            // 
            // s_name
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.s_name.HeaderText = "灭菌器名称";
            this.s_name.Name = "s_name";
            // 
            // s_barcode
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.s_barcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.s_barcode.HeaderText = "条形码";
            this.s_barcode.Name = "s_barcode";
            this.s_barcode.Width = 130;
            // 
            // SterilizerDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 416);
            this.Controls.Add(this.sp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SterilizerDevice";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择灭菌器";
            this.Load += new System.EventHandler(this.SterilizerDevice_Load);
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
            this.sp.ResumeLayout(false);
            this.gb_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp;
        private System.Windows.Forms.GroupBox gb_top;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_select;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_barcode;
    }
}