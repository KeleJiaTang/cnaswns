namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_dressing_info_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_dressing_info_manage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.but_close = new System.Windows.Forms.Button();
            this.tb_dre = new System.Windows.Forms.TextBox();
            this.lb_dre = new System.Windows.Forms.Label();
            this.but_remove = new System.Windows.Forms.Button();
            this.but_edit = new System.Windows.Forms.Button();
            this.but_new = new System.Windows.Forms.Button();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dre_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dre_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dre_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dre_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.sp_main.Panel1.Controls.Add(this.but_close);
            this.sp_main.Panel1.Controls.Add(this.tb_dre);
            this.sp_main.Panel1.Controls.Add(this.lb_dre);
            this.sp_main.Panel1.Controls.Add(this.but_remove);
            this.sp_main.Panel1.Controls.Add(this.but_edit);
            this.sp_main.Panel1.Controls.Add(this.but_new);
            this.sp_main.Panel1.Font = new System.Drawing.Font("宋体", 12F);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(606, 384);
            this.sp_main.SplitterDistance = 131;
            this.sp_main.TabIndex = 0;
            // 
            // but_close
            // 
            this.but_close.Font = new System.Drawing.Font("宋体", 11F);
            this.but_close.Image = ((System.Drawing.Image)(resources.GetObject("but_close.Image")));
            this.but_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_close.Location = new System.Drawing.Point(416, 12);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(99, 42);
            this.but_close.TabIndex = 73;
            this.but_close.Text = "    关闭";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // tb_dre
            // 
            this.tb_dre.Font = new System.Drawing.Font("宋体", 11F);
            this.tb_dre.Location = new System.Drawing.Point(117, 64);
            this.tb_dre.Multiline = true;
            this.tb_dre.Name = "tb_dre";
            this.tb_dre.ReadOnly = true;
            this.tb_dre.Size = new System.Drawing.Size(176, 28);
            this.tb_dre.TabIndex = 72;
            // 
            // lb_dre
            // 
            this.lb_dre.AutoSize = true;
            this.lb_dre.Font = new System.Drawing.Font("宋体", 11F);
            this.lb_dre.Location = new System.Drawing.Point(14, 67);
            this.lb_dre.Name = "lb_dre";
            this.lb_dre.Size = new System.Drawing.Size(97, 15);
            this.lb_dre.TabIndex = 71;
            this.lb_dre.Text = "敷料包名称：";
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_remove.Image = ((System.Drawing.Image)(resources.GetObject("but_remove.Image")));
            this.but_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_remove.Location = new System.Drawing.Point(211, 12);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 68;
            this.but_remove.Text = "  删除";
            this.but_remove.UseVisualStyleBackColor = true;
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_edit.Image = ((System.Drawing.Image)(resources.GetObject("but_edit.Image")));
            this.but_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_edit.Location = new System.Drawing.Point(111, 12);
            this.but_edit.Name = "but_edit";
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 67;
            this.but_edit.Text = "  修改";
            this.but_edit.UseVisualStyleBackColor = true;
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
            this.but_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_new.Location = new System.Drawing.Point(12, 12);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 66;
            this.but_new.Text = "  新建";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dre_id,
            this.dre_name,
            this.dre_type,
            this.dre_count,
            this.ca_remarks});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(606, 249);
            this.dgv_01.TabIndex = 0;
            // 
            // id
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // dre_id
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dre_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.dre_id.HeaderText = "敷料包名称";
            this.dre_id.Name = "dre_id";
            this.dre_id.ReadOnly = true;
            this.dre_id.Width = 113;
            // 
            // dre_name
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dre_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.dre_name.HeaderText = "敷料名称";
            this.dre_name.Name = "dre_name";
            this.dre_name.ReadOnly = true;
            this.dre_name.Width = 114;
            // 
            // dre_type
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dre_type.DefaultCellStyle = dataGridViewCellStyle4;
            this.dre_type.HeaderText = "衣物类型";
            this.dre_type.Name = "dre_type";
            this.dre_type.ReadOnly = true;
            this.dre_type.Width = 113;
            // 
            // dre_count
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dre_count.DefaultCellStyle = dataGridViewCellStyle5;
            this.dre_count.HeaderText = "衣物数量";
            this.dre_count.Name = "dre_count";
            this.dre_count.ReadOnly = true;
            this.dre_count.Width = 114;
            // 
            // ca_remarks
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_remarks.DefaultCellStyle = dataGridViewCellStyle6;
            this.ca_remarks.HeaderText = "备注说明";
            this.ca_remarks.Name = "ca_remarks";
            this.ca_remarks.ReadOnly = true;
            this.ca_remarks.Width = 113;
            // 
            // HCSCM_dressing_info_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(606, 384);
            this.Controls.Add(this.sp_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_dressing_info_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "敷料衣物管理";
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel1.PerformLayout();
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.Button but_edit;
        private System.Windows.Forms.Button but_remove;
        private System.Windows.Forms.Label lb_dre;
        private System.Windows.Forms.TextBox tb_dre;
        private System.Windows.Forms.Button but_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dre_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dre_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dre_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dre_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_remarks;

    }
}