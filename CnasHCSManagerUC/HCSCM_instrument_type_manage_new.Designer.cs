namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_instrument_type_manage_new
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
            this.cb_type = new Telerik.WinControls.UI.RadDropDownList();
            this.but_cancel = new Telerik.WinControls.UI.RadButton();
            this.but_ok = new Telerik.WinControls.UI.RadButton();
            this.lb_mail = new System.Windows.Forms.Label();
            this.lb_telephone = new System.Windows.Forms.Label();
            this.lb_contacts = new System.Windows.Forms.Label();
            this.lb_price = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_weight = new Telerik.WinControls.UI.RadTextBox();
            this.tb_brand = new Telerik.WinControls.UI.RadTextBox();
            this.tb_times = new Telerik.WinControls.UI.RadTextBox();
            this.tb_price = new Telerik.WinControls.UI.RadTextBox();
            this.tb_name = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_complexity = new Telerik.WinControls.UI.RadDropDownList();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_sterilizer = new Telerik.WinControls.UI.RadDropDownList();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_washing = new Telerik.WinControls.UI.RadDropDownList();
            this.label19 = new System.Windows.Forms.Label();
            this.lb_vender = new System.Windows.Forms.Label();
            this.cb_vender = new Telerik.WinControls.UI.RadDropDownList();
            this.label21 = new System.Windows.Forms.Label();
            this.lb_sales = new System.Windows.Forms.Label();
            this.cb_sales = new Telerik.WinControls.UI.RadDropDownList();
            this.label23 = new System.Windows.Forms.Label();
            this.lb_customer = new System.Windows.Forms.Label();
            this.cb_customer = new Telerik.WinControls.UI.RadDropDownList();
            this.tb_size = new Telerik.WinControls.UI.RadTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tb_bargain_price = new Telerik.WinControls.UI.RadTextBox();
            this.lb_bargain_price = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_weight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_brand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_complexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sterilizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_washing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_vender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bargain_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_type.Location = new System.Drawing.Point(122, 43);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(229, 25);
            this.cb_type.TabIndex = 2;
            this.cb_type.ThemeName = "Office2007Silver";
            this.cb_type.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_type_SelectedIndexChanged);
            this.cb_type.TextChanged += new System.EventHandler(this.cb_type_TextChanged);
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_cancel.Location = new System.Drawing.Point(467, 242);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 16;
            this.but_cancel.Text = "关  闭";
            this.but_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_cancel.ThemeName = "Office2007Silver";
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click_1);
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_ok.Location = new System.Drawing.Point(252, 242);
            this.but_ok.Name = "but_ok";
            this.but_ok.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.but_ok.Size = new System.Drawing.Size(99, 42);
            this.but_ok.TabIndex = 15;
            this.but_ok.Text = "确  定";
            this.but_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_ok.ThemeName = "Office2007Silver";
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click_1);
            // 
            // lb_mail
            // 
            this.lb_mail.AutoSize = true;
            this.lb_mail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_mail.Location = new System.Drawing.Point(389, 167);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(76, 20);
            this.lb_mail.TabIndex = 302;
            this.lb_mail.Text = "重量(g)：";
            // 
            // lb_telephone
            // 
            this.lb_telephone.AutoSize = true;
            this.lb_telephone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_telephone.Location = new System.Drawing.Point(408, 74);
            this.lb_telephone.Name = "lb_telephone";
            this.lb_telephone.Size = new System.Drawing.Size(57, 20);
            this.lb_telephone.TabIndex = 301;
            this.lb_telephone.Text = "品牌：";
            // 
            // lb_contacts
            // 
            this.lb_contacts.AutoSize = true;
            this.lb_contacts.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_contacts.Location = new System.Drawing.Point(376, 43);
            this.lb_contacts.Name = "lb_contacts";
            this.lb_contacts.Size = new System.Drawing.Size(89, 20);
            this.lb_contacts.TabIndex = 300;
            this.lb_contacts.Text = "可用次数：";
            // 
            // lb_price
            // 
            this.lb_price.AutoSize = true;
            this.lb_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_price.Location = new System.Drawing.Point(37, 165);
            this.lb_price.Name = "lb_price";
            this.lb_price.Size = new System.Drawing.Size(83, 20);
            this.lb_price.TabIndex = 303;
            this.lb_price.Text = "价格(元)：";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_type.Location = new System.Drawing.Point(61, 43);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(57, 20);
            this.lb_type.TabIndex = 304;
            this.lb_type.Text = "类型：";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_name.Location = new System.Drawing.Point(62, 12);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(57, 20);
            this.lb_name.TabIndex = 305;
            this.lb_name.Text = "名称：";
            // 
            // tb_weight
            // 
            this.tb_weight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_weight.Location = new System.Drawing.Point(467, 167);
            this.tb_weight.MaxLength = 10;
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(229, 25);
            this.tb_weight.TabIndex = 13;
            this.tb_weight.ThemeName = "Office2007Silver";
            this.tb_weight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_weight_KeyPress);
            // 
            // tb_brand
            // 
            this.tb_brand.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_brand.Location = new System.Drawing.Point(467, 74);
            this.tb_brand.Name = "tb_brand";
            this.tb_brand.Size = new System.Drawing.Size(229, 25);
            this.tb_brand.TabIndex = 10;
            this.tb_brand.ThemeName = "Office2007Silver";
            // 
            // tb_times
            // 
            this.tb_times.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_times.Location = new System.Drawing.Point(467, 43);
            this.tb_times.MaxLength = 10;
            this.tb_times.Name = "tb_times";
            this.tb_times.Size = new System.Drawing.Size(229, 25);
            this.tb_times.TabIndex = 9;
            this.tb_times.ThemeName = "Office2007Silver";
            this.tb_times.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_size_KeyPress);
            // 
            // tb_price
            // 
            this.tb_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_price.Location = new System.Drawing.Point(122, 165);
            this.tb_price.MaxLength = 10;
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(229, 25);
            this.tb_price.TabIndex = 7;
            this.tb_price.ThemeName = "Office2007Silver";
            this.tb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_weight_KeyPress);
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_name.Location = new System.Drawing.Point(122, 12);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(229, 25);
            this.tb_name.TabIndex = 1;
            this.tb_name.ThemeName = "Office2007Silver";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(354, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 12);
            this.label6.TabIndex = 298;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(356, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 297;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.Location = new System.Drawing.Point(376, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 304;
            this.label8.Text = "清洗难度：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cb_complexity
            // 
            this.cb_complexity.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_complexity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_complexity.Location = new System.Drawing.Point(467, 12);
            this.cb_complexity.Name = "cb_complexity";
            this.cb_complexity.Size = new System.Drawing.Size(229, 25);
            this.cb_complexity.TabIndex = 8;
            this.cb_complexity.ThemeName = "Office2007Silver";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.Location = new System.Drawing.Point(376, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 304;
            this.label11.Text = "灭菌程序：";
            // 
            // cb_sterilizer
            // 
            this.cb_sterilizer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_sterilizer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_sterilizer.Location = new System.Drawing.Point(467, 136);
            this.cb_sterilizer.Name = "cb_sterilizer";
            this.cb_sterilizer.Size = new System.Drawing.Size(229, 25);
            this.cb_sterilizer.TabIndex = 12;
            this.cb_sterilizer.ThemeName = "Office2007Silver";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label17.Location = new System.Drawing.Point(376, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 304;
            this.label17.Text = "清洗程序：";
            // 
            // cb_washing
            // 
            this.cb_washing.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_washing.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_washing.Location = new System.Drawing.Point(467, 105);
            this.cb_washing.Name = "cb_washing";
            this.cb_washing.Size = new System.Drawing.Size(229, 25);
            this.cb_washing.TabIndex = 11;
            this.cb_washing.ThemeName = "Office2007Silver";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(356, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(12, 12);
            this.label19.TabIndex = 297;
            this.label19.Text = "*";
            // 
            // lb_vender
            // 
            this.lb_vender.AutoSize = true;
            this.lb_vender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_vender.Location = new System.Drawing.Point(46, 74);
            this.lb_vender.Name = "lb_vender";
            this.lb_vender.Size = new System.Drawing.Size(73, 20);
            this.lb_vender.TabIndex = 304;
            this.lb_vender.Text = "生产商：";
            // 
            // cb_vender
            // 
            this.cb_vender.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_vender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_vender.Location = new System.Drawing.Point(122, 74);
            this.cb_vender.Name = "cb_vender";
            this.cb_vender.Size = new System.Drawing.Size(229, 25);
            this.cb_vender.TabIndex = 3;
            this.cb_vender.ThemeName = "Office2007Silver";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(356, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 12);
            this.label21.TabIndex = 297;
            this.label21.Text = "*";
            // 
            // lb_sales
            // 
            this.lb_sales.AutoSize = true;
            this.lb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_sales.Location = new System.Drawing.Point(46, 105);
            this.lb_sales.Name = "lb_sales";
            this.lb_sales.Size = new System.Drawing.Size(73, 20);
            this.lb_sales.TabIndex = 304;
            this.lb_sales.Text = "销售商：";
            // 
            // cb_sales
            // 
            this.cb_sales.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_sales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_sales.Location = new System.Drawing.Point(122, 105);
            this.cb_sales.Name = "cb_sales";
            this.cb_sales.Size = new System.Drawing.Size(229, 25);
            this.cb_sales.TabIndex = 4;
            this.cb_sales.ThemeName = "Office2007Silver";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(356, 142);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 12);
            this.label23.TabIndex = 297;
            this.label23.Text = "*";
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_customer.Location = new System.Drawing.Point(62, 136);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(57, 20);
            this.lb_customer.TabIndex = 304;
            this.lb_customer.Text = "客户：";
            // 
            // cb_customer
            // 
            this.cb_customer.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_customer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_customer.Location = new System.Drawing.Point(122, 136);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(229, 25);
            this.cb_customer.TabIndex = 5;
            this.cb_customer.ThemeName = "Office2007Silver";
            this.cb_customer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cb_customer_SelectedIndexChanged);
            this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
            // 
            // tb_size
            // 
            this.tb_size.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_size.Location = new System.Drawing.Point(467, 198);
            this.tb_size.MaxLength = 10;
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(229, 25);
            this.tb_size.TabIndex = 14;
            this.tb_size.ThemeName = "Office2007Silver";
            this.tb_size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_weight_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label27.Location = new System.Drawing.Point(372, 198);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 20);
            this.label27.TabIndex = 302;
            this.label27.Text = "长度(mm)：";
            // 
            // tb_bargain_price
            // 
            this.tb_bargain_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tb_bargain_price.Location = new System.Drawing.Point(122, 196);
            this.tb_bargain_price.MaxLength = 10;
            this.tb_bargain_price.Name = "tb_bargain_price";
            this.tb_bargain_price.Size = new System.Drawing.Size(229, 25);
            this.tb_bargain_price.TabIndex = 14;
            this.tb_bargain_price.Text = "0";
            this.tb_bargain_price.ThemeName = "Office2007Silver";
            this.tb_bargain_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_weight_KeyPress);
            // 
            // lb_bargain_price
            // 
            this.lb_bargain_price.AutoSize = true;
            this.lb_bargain_price.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_bargain_price.Location = new System.Drawing.Point(6, 196);
            this.lb_bargain_price.Name = "lb_bargain_price";
            this.lb_bargain_price.Size = new System.Drawing.Size(115, 20);
            this.lb_bargain_price.TabIndex = 302;
            this.lb_bargain_price.Text = "处理价格(元)：";
            // 
            // HCSCM_instrument_type_manage_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(728, 292);
            this.Controls.Add(this.cb_customer);
            this.Controls.Add(this.cb_sales);
            this.Controls.Add(this.cb_vender);
            this.Controls.Add(this.cb_washing);
            this.Controls.Add(this.cb_sterilizer);
            this.Controls.Add(this.cb_complexity);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lb_customer);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.lb_sales);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.lb_vender);
            this.Controls.Add(this.lb_bargain_price);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lb_mail);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lb_telephone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_contacts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_price);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tb_bargain_price);
            this.Controls.Add(this.tb_size);
            this.Controls.Add(this.tb_weight);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tb_brand);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tb_times);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_instrument_type_manage_new";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建器械";
            ((System.ComponentModel.ISupportInitialize)(this.cb_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_weight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_brand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_complexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sterilizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_washing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_vender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_sales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bargain_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cb_type;
        private Telerik.WinControls.UI.RadButton but_cancel;
        private Telerik.WinControls.UI.RadButton but_ok;
        private System.Windows.Forms.Label lb_mail;
        private System.Windows.Forms.Label lb_telephone;
        private System.Windows.Forms.Label lb_contacts;
        private System.Windows.Forms.Label lb_price;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_name;
        private Telerik.WinControls.UI.RadTextBox tb_weight;
        private Telerik.WinControls.UI.RadTextBox tb_brand;
        private Telerik.WinControls.UI.RadTextBox tb_times;
        private Telerik.WinControls.UI.RadTextBox tb_price;
        private Telerik.WinControls.UI.RadTextBox tb_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Telerik.WinControls.UI.RadDropDownList cb_complexity;
        private System.Windows.Forms.Label label11;
        private Telerik.WinControls.UI.RadDropDownList cb_sterilizer;
        private System.Windows.Forms.Label label17;
        private Telerik.WinControls.UI.RadDropDownList cb_washing;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lb_vender;
        private Telerik.WinControls.UI.RadDropDownList cb_vender;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lb_sales;
        private Telerik.WinControls.UI.RadDropDownList cb_sales;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb_customer;
        private Telerik.WinControls.UI.RadDropDownList cb_customer;
        private Telerik.WinControls.UI.RadTextBox tb_size;
        private System.Windows.Forms.Label label27;
        private Telerik.WinControls.UI.RadTextBox tb_bargain_price;
        private System.Windows.Forms.Label lb_bargain_price;
    }
}