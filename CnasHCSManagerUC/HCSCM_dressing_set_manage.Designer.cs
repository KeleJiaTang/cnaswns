namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_dressing_set_manage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_dressing_set_manage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.but_sel = new System.Windows.Forms.Button();
            this.but_list = new System.Windows.Forms.Button();
            this.but_print = new System.Windows.Forms.Button();
            this.but_media = new System.Windows.Forms.Button();
            this.but_remove = new System.Windows.Forms.Button();
            this.tb_sname = new System.Windows.Forms.TextBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.lb_customer = new System.Windows.Forms.Label();
            this.but_new = new System.Windows.Forms.Button();
            this.cb_customer = new System.Windows.Forms.ComboBox();
            this.but_edit = new System.Windows.Forms.Button();
            this.cs_select = new Cnas.wns.CnasBaseUC.ControlSeachButton();
            this.but_import = new System.Windows.Forms.Button();
            this.but_details = new System.Windows.Forms.Button();
            this.lb_sname = new System.Windows.Forms.Label();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sterilizer_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_center = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            this.gp_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.Controls.Add(this.gp_top);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.dgv_01);
            this.sp_main.Size = new System.Drawing.Size(800, 500);
            this.sp_main.SplitterDistance = 190;
            this.sp_main.TabIndex = 0;
            // 
            // gp_top
            // 
            this.gp_top.BackColor = System.Drawing.SystemColors.Window;
            this.gp_top.Controls.Add(this.but_sel);
            this.gp_top.Controls.Add(this.but_list);
            this.gp_top.Controls.Add(this.but_print);
            this.gp_top.Controls.Add(this.but_media);
            this.gp_top.Controls.Add(this.but_remove);
            this.gp_top.Controls.Add(this.tb_sname);
            this.gp_top.Controls.Add(this.lb_info);
            this.gp_top.Controls.Add(this.lb_customer);
            this.gp_top.Controls.Add(this.but_new);
            this.gp_top.Controls.Add(this.cb_customer);
            this.gp_top.Controls.Add(this.but_edit);
            this.gp_top.Controls.Add(this.cs_select);
            this.gp_top.Controls.Add(this.but_import);
            this.gp_top.Controls.Add(this.but_details);
            this.gp_top.Controls.Add(this.lb_sname);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(800, 190);
            this.gp_top.TabIndex = 1;
            this.gp_top.TabStop = false;
            // 
            // but_sel
            // 
            this.but_sel.Location = new System.Drawing.Point(626, 122);
            this.but_sel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_sel.Name = "but_sel";
            this.but_sel.Size = new System.Drawing.Size(56, 21);
            this.but_sel.TabIndex = 72;
            this.but_sel.Text = "查询";
            this.but_sel.UseVisualStyleBackColor = true;
            this.but_sel.Click += new System.EventHandler(this.but_sel_Click);
            // 
            // but_list
            // 
            this.but_list.Image = ((System.Drawing.Image)(resources.GetObject("but_list.Image")));
            this.but_list.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_list.Location = new System.Drawing.Point(370, 65);
            this.but_list.Name = "but_list";
            this.but_list.Size = new System.Drawing.Size(99, 42);
            this.but_list.TabIndex = 71;
            this.but_list.Text = "     打印清单";
            this.but_list.UseVisualStyleBackColor = true;
            // 
            // but_print
            // 
            this.but_print.Image = ((System.Drawing.Image)(resources.GetObject("but_print.Image")));
            this.but_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_print.Location = new System.Drawing.Point(370, 24);
            this.but_print.Name = "but_print";
            this.but_print.Size = new System.Drawing.Size(99, 42);
            this.but_print.TabIndex = 70;
            this.but_print.Text = "     打印";
            this.but_print.UseVisualStyleBackColor = true;
            // 
            // but_media
            // 
            this.but_media.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_media.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_media.Location = new System.Drawing.Point(109, 65);
            this.but_media.Name = "but_media";
            this.but_media.Size = new System.Drawing.Size(99, 42);
            this.but_media.TabIndex = 40;
            this.but_media.Text = "照片";
            this.but_media.UseVisualStyleBackColor = true;
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_remove.Image = ((System.Drawing.Image)(resources.GetObject("but_remove.Image")));
            this.but_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_remove.Location = new System.Drawing.Point(208, 24);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 25;
            this.but_remove.Text = "  删除";
            this.but_remove.UseVisualStyleBackColor = true;
            this.but_remove.Click += new System.EventHandler(this.but_remove_Click);
            // 
            // tb_sname
            // 
            this.tb_sname.Location = new System.Drawing.Point(461, 122);
            this.tb_sname.Name = "tb_sname";
            this.tb_sname.Size = new System.Drawing.Size(160, 21);
            this.tb_sname.TabIndex = 38;
            this.tb_sname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sname_KeyDown);
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_info.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info.Location = new System.Drawing.Point(9, 1);
            this.lb_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(140, 14);
            this.lb_info.TabIndex = 22;
            this.lb_info.Text = "敷料包管理-->主窗口";
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Location = new System.Drawing.Point(9, 126);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(65, 12);
            this.lb_customer.TabIndex = 37;
            this.lb_customer.Text = "所属客户：";
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
            this.but_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_new.Location = new System.Drawing.Point(9, 24);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 23;
            this.but_new.Text = "  新建";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // cb_customer
            // 
            this.cb_customer.BackColor = System.Drawing.Color.Yellow;
            this.cb_customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_customer.FormattingEnabled = true;
            this.cb_customer.Location = new System.Drawing.Point(76, 122);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(218, 20);
            this.cb_customer.TabIndex = 36;
            this.cb_customer.SelectedIndexChanged += new System.EventHandler(this.cb_customer_SelectedIndexChanged);
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_edit.Image = ((System.Drawing.Image)(resources.GetObject("but_edit.Image")));
            this.but_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_edit.Location = new System.Drawing.Point(109, 24);
            this.but_edit.Name = "but_edit";
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 24;
            this.but_edit.Text = "  修改";
            this.but_edit.UseVisualStyleBackColor = true;
            this.but_edit.Click += new System.EventHandler(this.but_edit_Click);
            // 
            // cs_select
            // 
            this.cs_select.BackColor = System.Drawing.Color.Transparent;
            this.cs_select.Location = new System.Drawing.Point(738, 11);
            this.cs_select.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cs_select.Name = "cs_select";
            this.cs_select.Size = new System.Drawing.Size(450, 63);
            this.cs_select.TabIndex = 35;
            this.cs_select.Visible = false;
            // 
            // but_import
            // 
            this.but_import.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_import.Location = new System.Drawing.Point(9, 65);
            this.but_import.Name = "but_import";
            this.but_import.Size = new System.Drawing.Size(99, 42);
            this.but_import.TabIndex = 26;
            this.but_import.Text = "导入";
            this.but_import.UseVisualStyleBackColor = true;
            // 
            // but_details
            // 
            this.but_details.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_details.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_details.Location = new System.Drawing.Point(208, 65);
            this.but_details.Name = "but_details";
            this.but_details.Size = new System.Drawing.Size(99, 42);
            this.but_details.TabIndex = 33;
            this.but_details.Text = "敷料包详情";
            this.but_details.UseVisualStyleBackColor = true;
            this.but_details.Click += new System.EventHandler(this.but_details_Click);
            // 
            // lb_sname
            // 
            this.lb_sname.AutoSize = true;
            this.lb_sname.Location = new System.Drawing.Point(368, 127);
            this.lb_sname.Name = "lb_sname";
            this.lb_sname.Size = new System.Drawing.Size(101, 12);
            this.lb_sname.TabIndex = 39;
            this.lb_sname.Text = "敷料包名称查询：";
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ca_name,
            this.bar_code,
            this.ca_size,
            this.ca_weight,
            this.ca_price,
            this.sterilizer_type,
            this.cost_center,
            this.ca_material,
            this.ca_customer,
            this.cre_date,
            this.mod_date,
            this.ca_remarks});
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.MultiSelect = false;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(800, 306);
            this.dgv_01.TabIndex = 0;
            // 
            // id
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // ca_name
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.ca_name.HeaderText = "名称";
            this.ca_name.Name = "ca_name";
            this.ca_name.ReadOnly = true;
            // 
            // bar_code
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bar_code.DefaultCellStyle = dataGridViewCellStyle3;
            this.bar_code.HeaderText = "条码";
            this.bar_code.Name = "bar_code";
            this.bar_code.ReadOnly = true;
            // 
            // ca_size
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_size.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_size.HeaderText = "尺寸";
            this.ca_size.Name = "ca_size";
            this.ca_size.ReadOnly = true;
            // 
            // ca_weight
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_weight.DefaultCellStyle = dataGridViewCellStyle5;
            this.ca_weight.HeaderText = "重量";
            this.ca_weight.Name = "ca_weight";
            this.ca_weight.ReadOnly = true;
            // 
            // ca_price
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_price.DefaultCellStyle = dataGridViewCellStyle6;
            this.ca_price.HeaderText = "价格";
            this.ca_price.Name = "ca_price";
            this.ca_price.ReadOnly = true;
            // 
            // sterilizer_type
            // 
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sterilizer_type.DefaultCellStyle = dataGridViewCellStyle7;
            this.sterilizer_type.HeaderText = "灭菌程序";
            this.sterilizer_type.Name = "sterilizer_type";
            this.sterilizer_type.ReadOnly = true;
            // 
            // cost_center
            // 
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cost_center.DefaultCellStyle = dataGridViewCellStyle8;
            this.cost_center.HeaderText = "成本中心";
            this.cost_center.Name = "cost_center";
            this.cost_center.ReadOnly = true;
            // 
            // ca_material
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_material.DefaultCellStyle = dataGridViewCellStyle9;
            this.ca_material.HeaderText = "包装材料";
            this.ca_material.Name = "ca_material";
            this.ca_material.Visible = false;
            // 
            // ca_customer
            // 
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_customer.DefaultCellStyle = dataGridViewCellStyle10;
            this.ca_customer.HeaderText = "客户";
            this.ca_customer.Name = "ca_customer";
            this.ca_customer.ReadOnly = true;
            this.ca_customer.Visible = false;
            // 
            // cre_date
            // 
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cre_date.DefaultCellStyle = dataGridViewCellStyle11;
            this.cre_date.HeaderText = "创建日期";
            this.cre_date.Name = "cre_date";
            this.cre_date.ReadOnly = true;
            // 
            // mod_date
            // 
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mod_date.DefaultCellStyle = dataGridViewCellStyle12;
            this.mod_date.HeaderText = "修改日期";
            this.mod_date.Name = "mod_date";
            this.mod_date.ReadOnly = true;
            // 
            // ca_remarks
            // 
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_remarks.DefaultCellStyle = dataGridViewCellStyle13;
            this.ca_remarks.HeaderText = "备注说明";
            this.ca_remarks.Name = "ca_remarks";
            this.ca_remarks.ReadOnly = true;
            // 
            // HCSCM_dressing_set_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp_main);
            this.Name = "HCSCM_dressing_set_manage";
            this.Size = new System.Drawing.Size(800, 500);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp_main;
        private System.Windows.Forms.Label lb_sname;
        private System.Windows.Forms.TextBox tb_sname;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.ComboBox cb_customer;
        private CnasBaseUC.ControlSeachButton cs_select;
        private System.Windows.Forms.Button but_details;
        private System.Windows.Forms.Button but_import;
        private System.Windows.Forms.Button but_remove;
        private System.Windows.Forms.Button but_edit;
        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.GroupBox gp_top;
        private System.Windows.Forms.Button but_media;
        private System.Windows.Forms.Button but_list;
        private System.Windows.Forms.Button but_print;
        private System.Windows.Forms.Button but_sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bar_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sterilizer_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_center;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_remarks;
    }
}
