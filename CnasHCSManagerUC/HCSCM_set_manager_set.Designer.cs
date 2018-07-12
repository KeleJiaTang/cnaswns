namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_manager_set));
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.but_sel = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.tb_sname = new System.Windows.Forms.TextBox();
            this.but_print = new System.Windows.Forms.Button();
            this.cb_customer = new System.Windows.Forms.ComboBox();
            this.but_list = new System.Windows.Forms.Button();
            this.lb_customer = new System.Windows.Forms.Label();
            this.but_dis_media = new System.Windows.Forms.Button();
            this.but_media = new System.Windows.Forms.Button();
            this.but_remove = new System.Windows.Forms.Button();
            this.but_edit = new System.Windows.Forms.Button();
            this.but_new = new System.Windows.Forms.Button();
            this.lb_sname = new System.Windows.Forms.Label();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_center = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.sp_main.Panel1.Controls.Add(this.but_sel);
            this.sp_main.Panel1.Controls.Add(this.but_cancel);
            this.sp_main.Panel1.Controls.Add(this.tb_sname);
            this.sp_main.Panel1.Controls.Add(this.but_print);
            this.sp_main.Panel1.Controls.Add(this.cb_customer);
            this.sp_main.Panel1.Controls.Add(this.but_list);
            this.sp_main.Panel1.Controls.Add(this.lb_customer);
            this.sp_main.Panel1.Controls.Add(this.but_dis_media);
            this.sp_main.Panel1.Controls.Add(this.but_media);
            this.sp_main.Panel1.Controls.Add(this.but_remove);
            this.sp_main.Panel1.Controls.Add(this.but_edit);
            this.sp_main.Panel1.Controls.Add(this.but_new);
            this.sp_main.Panel1.Controls.Add(this.lb_sname);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(724, 458);
            this.sp_main.SplitterDistance = 166;
            this.sp_main.TabIndex = 0;
            // 
            // but_sel
            // 
            this.but_sel.Location = new System.Drawing.Point(672, 132);
            this.but_sel.Name = "but_sel";
            this.but_sel.Size = new System.Drawing.Size(41, 23);
            this.but_sel.TabIndex = 48;
            this.but_sel.Text = "确认";
            this.but_sel.UseVisualStyleBackColor = true;
            this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.Image = global::Cnas.wns.CnasHCSManagerUC.Properties.Resources.cancel;
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(614, 26);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 47;
            this.but_cancel.Text = "  关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // tb_sname
            // 
            this.tb_sname.Location = new System.Drawing.Point(452, 134);
            this.tb_sname.Name = "tb_sname";
            this.tb_sname.Size = new System.Drawing.Size(215, 21);
            this.tb_sname.TabIndex = 42;
            this.tb_sname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
            // 
            // but_print
            // 
            this.but_print.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_print.Image = ((System.Drawing.Image)(resources.GetObject("but_print.Image")));
            this.but_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_print.Location = new System.Drawing.Point(211, 74);
            this.but_print.Name = "but_print";
            this.but_print.Size = new System.Drawing.Size(99, 42);
            this.but_print.TabIndex = 36;
            this.but_print.Text = "  打印";
            this.but_print.UseVisualStyleBackColor = true;
            // 
            // cb_customer
            // 
            this.cb_customer.BackColor = System.Drawing.Color.Yellow;
            this.cb_customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_customer.FormattingEnabled = true;
            this.cb_customer.Location = new System.Drawing.Point(74, 135);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(236, 20);
            this.cb_customer.TabIndex = 40;
            this.cb_customer.SelectedIndexChanged += new System.EventHandler(this.cb_customer_SelectedIndexChanged);
            // 
            // but_list
            // 
            this.but_list.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_list.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_list.Location = new System.Drawing.Point(316, 74);
            this.but_list.Name = "but_list";
            this.but_list.Size = new System.Drawing.Size(99, 42);
            this.but_list.TabIndex = 35;
            this.but_list.Text = "打印器械清单";
            this.but_list.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.but_list.UseVisualStyleBackColor = true;
            this.but_list.Click += new System.EventHandler(this.but_list_Click);
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Location = new System.Drawing.Point(14, 138);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(65, 12);
            this.lb_customer.TabIndex = 41;
            this.lb_customer.Text = "所属客户：";
            // 
            // but_dis_media
            // 
            this.but_dis_media.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_dis_media.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_dis_media.Location = new System.Drawing.Point(110, 74);
            this.but_dis_media.Name = "but_dis_media";
            this.but_dis_media.Size = new System.Drawing.Size(99, 42);
            this.but_dis_media.TabIndex = 33;
            this.but_dis_media.Text = "照片查看";
            this.but_dis_media.UseVisualStyleBackColor = true;
            // 
            // but_media
            // 
            this.but_media.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_media.Image = ((System.Drawing.Image)(resources.GetObject("but_media.Image")));
            this.but_media.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_media.Location = new System.Drawing.Point(10, 74);
            this.but_media.Name = "but_media";
            this.but_media.Size = new System.Drawing.Size(99, 42);
            this.but_media.TabIndex = 32;
            this.but_media.Text = "  照片";
            this.but_media.UseVisualStyleBackColor = true;
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_remove.Image = ((System.Drawing.Image)(resources.GetObject("but_remove.Image")));
            this.but_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_remove.Location = new System.Drawing.Point(211, 26);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 31;
            this.but_remove.Text = "  删除";
            this.but_remove.UseVisualStyleBackColor = true;
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_edit.Image = ((System.Drawing.Image)(resources.GetObject("but_edit.Image")));
            this.but_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_edit.Location = new System.Drawing.Point(110, 26);
            this.but_edit.Name = "but_edit";
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 30;
            this.but_edit.Text = "  修改";
            this.but_edit.UseVisualStyleBackColor = true;
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
            this.but_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_new.Location = new System.Drawing.Point(10, 26);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 29;
            this.but_new.Text = "  新建";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // lb_sname
            // 
            this.lb_sname.AutoSize = true;
            this.lb_sname.Location = new System.Drawing.Point(416, 138);
            this.lb_sname.Name = "lb_sname";
            this.lb_sname.Size = new System.Drawing.Size(41, 12);
            this.lb_sname.TabIndex = 43;
            this.lb_sname.Text = "查询：";
            // 
            // dgv_01
            // 
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.bar_code,
            this.ca_name,
            this.cost_center,
            this.customer_code,
            this.ca_position,
            this.cre_date,
            this.mod_date});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.MultiSelect = false;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(724, 288);
            this.dgv_01.TabIndex = 0;
            // 
            // id
            // 
            this.id.FillWeight = 76.82458F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 75;
            // 
            // bar_code
            // 
            this.bar_code.HeaderText = "条码";
            this.bar_code.Name = "bar_code";
            this.bar_code.Width = 98;
            // 
            // ca_name
            // 
            this.ca_name.FillWeight = 97.36474F;
            this.ca_name.HeaderText = "器械包名称";
            this.ca_name.Name = "ca_name";
            this.ca_name.ReadOnly = true;
            this.ca_name.Width = 95;
            // 
            // cost_center
            // 
            this.cost_center.FillWeight = 87.79713F;
            this.cost_center.HeaderText = "成本中心";
            this.cost_center.Name = "cost_center";
            this.cost_center.ReadOnly = true;
            // 
            // customer_code
            // 
            this.customer_code.HeaderText = "客户";
            this.customer_code.Name = "customer_code";
            this.customer_code.Width = 98;
            // 
            // ca_position
            // 
            this.ca_position.FillWeight = 105.7073F;
            this.ca_position.HeaderText = "位置";
            this.ca_position.Name = "ca_position";
            this.ca_position.ReadOnly = true;
            this.ca_position.Width = 103;
            // 
            // cre_date
            // 
            this.cre_date.FillWeight = 112.9817F;
            this.cre_date.HeaderText = "创建日期";
            this.cre_date.Name = "cre_date";
            this.cre_date.ReadOnly = true;
            this.cre_date.Width = 116;
            // 
            // mod_date
            // 
            this.mod_date.FillWeight = 119.3246F;
            this.mod_date.HeaderText = "修改日期";
            this.mod_date.Name = "mod_date";
            this.mod_date.ReadOnly = true;
            this.mod_date.Width = 116;
            // 
            // HCSCM_set_manager_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 458);
            this.Controls.Add(this.sp_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HCSCM_set_manager_set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "器械包管理";
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
        private System.Windows.Forms.Button but_remove;
        private System.Windows.Forms.Button but_edit;
        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.Button but_dis_media;
        private System.Windows.Forms.Button but_media;
        private System.Windows.Forms.Button but_print;
        private System.Windows.Forms.Button but_list;
       // private CnasBaseUC.ControlSeachButton cs_select;
        private System.Windows.Forms.Label lb_sname;
        private System.Windows.Forms.TextBox tb_sname;
        private System.Windows.Forms.ComboBox cb_customer;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bar_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_center;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_position;
        private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_date;
    }
}