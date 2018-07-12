namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_cre_set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_manager_cre_set));
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.but_cancel = new System.Windows.Forms.Button();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.lb_inum = new System.Windows.Forms.Label();
            this.tb_inum = new System.Windows.Forms.TextBox();
            this.but_new = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_setcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_center = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(111, 76);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(396, 25);
            this.tb_name.TabIndex = 44;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(16, 80);
            this.lb_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(97, 15);
            this.lb_name.TabIndex = 43;
            this.lb_name.Text = "基本包名称：";
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.Image = global::Cnas.wns.CnasHCSManagerUC.Properties.Resources.cancel;
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(868, 34);
            this.but_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(132, 52);
            this.but_cancel.TabIndex = 46;
            this.but_cancel.Text = "关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // dgv_01
            // 
            this.dgv_01.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.bar_code,
            this.ca_name,
            this.base_setcode,
            this.cost_center,
            this.customer_code,
            this.cre_date,
            this.mod_date});
            this.dgv_01.Location = new System.Drawing.Point(7, 110);
            this.dgv_01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_01.MultiSelect = false;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(1003, 425);
            this.dgv_01.TabIndex = 47;
            // 
            // lb_inum
            // 
            this.lb_inum.AutoSize = true;
            this.lb_inum.Location = new System.Drawing.Point(721, 11);
            this.lb_inum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_inum.Name = "lb_inum";
            this.lb_inum.Size = new System.Drawing.Size(82, 15);
            this.lb_inum.TabIndex = 48;
            this.lb_inum.Text = "器械包数量";
            // 
            // tb_inum
            // 
            this.tb_inum.BackColor = System.Drawing.SystemColors.Control;
            this.tb_inum.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_inum.Location = new System.Drawing.Point(724, 34);
            this.tb_inum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_inum.Multiline = true;
            this.tb_inum.Name = "tb_inum";
            this.tb_inum.ReadOnly = true;
            this.tb_inum.Size = new System.Drawing.Size(83, 60);
            this.tb_inum.TabIndex = 49;
            this.tb_inum.Text = "0";
            this.tb_inum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
            this.but_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_new.Location = new System.Drawing.Point(19, 11);
            this.but_new.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(132, 52);
            this.but_new.TabIndex = 30;
            this.but_new.Text = "  新建";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // bar_code
            // 
            this.bar_code.HeaderText = "条码";
            this.bar_code.Name = "bar_code";
            this.bar_code.ReadOnly = true;
            // 
            // ca_name
            // 
            this.ca_name.HeaderText = "器械包名称";
            this.ca_name.Name = "ca_name";
            this.ca_name.ReadOnly = true;
            this.ca_name.Width = 120;
            // 
            // base_setcode
            // 
            this.base_setcode.HeaderText = "基本包条码";
            this.base_setcode.Name = "base_setcode";
            this.base_setcode.ReadOnly = true;
            this.base_setcode.Width = 120;
            // 
            // cost_center
            // 
            this.cost_center.HeaderText = "成本中心";
            this.cost_center.Name = "cost_center";
            this.cost_center.ReadOnly = true;
            // 
            // customer_code
            // 
            this.customer_code.HeaderText = "所属客户";
            this.customer_code.Name = "customer_code";
            this.customer_code.ReadOnly = true;
            // 
            // cre_date
            // 
            this.cre_date.HeaderText = "创建日期";
            this.cre_date.Name = "cre_date";
            this.cre_date.ReadOnly = true;
            this.cre_date.Width = 120;
            // 
            // mod_date
            // 
            this.mod_date.HeaderText = "修改日期";
            this.mod_date.Name = "mod_date";
            this.mod_date.ReadOnly = true;
            this.mod_date.Width = 120;
            // 
            // HCSCM_set_manager_cre_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1016, 538);
            this.Controls.Add(this.tb_inum);
            this.Controls.Add(this.lb_inum);
            this.Controls.Add(this.dgv_01);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.but_new);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "HCSCM_set_manager_cre_set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建实体包";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.DataGridView dgv_01;
        private System.Windows.Forms.Label lb_inum;
        private System.Windows.Forms.TextBox tb_inum;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bar_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_setcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_center;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_date;
    }
}