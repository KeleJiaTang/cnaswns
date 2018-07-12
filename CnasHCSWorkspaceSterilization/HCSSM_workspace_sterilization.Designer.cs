namespace Cnas.wns.CnasHCSWorkspaceSterilization
{
    partial class HCSSM_workspace_sterilization
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
            this.components = new System.ComponentModel.Container();
            this.met_main = new Cnas.wns.CnasMetroFramework.Controls.MetroTabControl();
            this.tabp_01 = new System.Windows.Forms.TabPage();
            this.spc_main = new System.Windows.Forms.SplitContainer();
            this.spc_left = new System.Windows.Forms.SplitContainer();
            this.mett_03 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.mett_02 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.ml_01 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.mett_01 = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
            this.spc_right = new System.Windows.Forms.SplitContainer();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.tb_seach = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
            this.ml_16 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.ml_15 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.cmt_main = new Cnas.wns.CnasBaseUC.ControlMonitoring();
            this.mcb_ordertype = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
            this.ml_14 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.mcb_cost = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
            this.mcb_customer = new Cnas.wns.CnasMetroFramework.Controls.MetroComboBox();
            this.mtb_cssd = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
            this.ml_13 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.ml_12 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.ml_11 = new Cnas.wns.CnasMetroFramework.Controls.MetroLabel();
            this.met_right = new Cnas.wns.CnasMetroFramework.Controls.MetroTabControl();
            this.tabp_11 = new System.Windows.Forms.TabPage();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.set_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wf_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.run_times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcm_right = new Cnas.wns.CnasMetroFramework.Controls.MetroContextMenu(this.components);
            this.tsm_print = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_hand = new System.Windows.Forms.ToolStripMenuItem();
            this.tabp_12 = new System.Windows.Forms.TabPage();
            this.tabp_02 = new System.Windows.Forms.TabPage();
            this.tabp_03 = new System.Windows.Forms.TabPage();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.met_main.SuspendLayout();
            this.tabp_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_main)).BeginInit();
            this.spc_main.Panel1.SuspendLayout();
            this.spc_main.Panel2.SuspendLayout();
            this.spc_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_left)).BeginInit();
            this.spc_left.Panel1.SuspendLayout();
            this.spc_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_right)).BeginInit();
            this.spc_right.Panel1.SuspendLayout();
            this.spc_right.Panel2.SuspendLayout();
            this.spc_right.SuspendLayout();
            this.gp_top.SuspendLayout();
            this.met_right.SuspendLayout();
            this.tabp_11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            this.mcm_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // met_main
            // 
            this.met_main.Controls.Add(this.tabp_01);
            this.met_main.Controls.Add(this.tabp_02);
            this.met_main.Controls.Add(this.tabp_03);
            this.met_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.met_main.Location = new System.Drawing.Point(20, 60);
            this.met_main.Name = "met_main";
            this.met_main.SelectedIndex = 0;
            this.met_main.Size = new System.Drawing.Size(1209, 654);
            this.met_main.TabIndex = 0;
            this.met_main.UseSelectable = true;
            // 
            // tabp_01
            // 
            this.tabp_01.BackColor = System.Drawing.Color.Transparent;
            this.tabp_01.Controls.Add(this.spc_main);
            this.tabp_01.Location = new System.Drawing.Point(4, 39);
            this.tabp_01.Name = "tabp_01";
            this.tabp_01.Size = new System.Drawing.Size(1201, 611);
            this.tabp_01.TabIndex = 0;
            this.tabp_01.Text = "工单处理";
            // 
            // spc_main
            // 
            this.spc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_main.Location = new System.Drawing.Point(0, 0);
            this.spc_main.Name = "spc_main";
            // 
            // spc_main.Panel1
            // 
            this.spc_main.Panel1.Controls.Add(this.spc_left);
            // 
            // spc_main.Panel2
            // 
            this.spc_main.Panel2.Controls.Add(this.spc_right);
            this.spc_main.Size = new System.Drawing.Size(1201, 611);
            this.spc_main.SplitterDistance = 217;
            this.spc_main.TabIndex = 0;
            // 
            // spc_left
            // 
            this.spc_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_left.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_left.Location = new System.Drawing.Point(0, 0);
            this.spc_left.Name = "spc_left";
            this.spc_left.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spc_left.Panel1
            // 
            this.spc_left.Panel1.Controls.Add(this.mett_03);
            this.spc_left.Panel1.Controls.Add(this.mett_02);
            this.spc_left.Panel1.Controls.Add(this.ml_01);
            this.spc_left.Panel1.Controls.Add(this.mett_01);
            this.spc_left.Size = new System.Drawing.Size(217, 611);
            this.spc_left.SplitterDistance = 170;
            this.spc_left.TabIndex = 0;
            // 
            // mett_03
            // 
            this.mett_03.ActiveControl = null;
            this.mett_03.Location = new System.Drawing.Point(5, 96);
            this.mett_03.Name = "mett_03";
            this.mett_03.Size = new System.Drawing.Size(207, 67);
            this.mett_03.TabIndex = 7;
            this.mett_03.Text = "其它功能";
            this.mett_03.UseSelectable = true;
            // 
            // mett_02
            // 
            this.mett_02.ActiveControl = null;
            this.mett_02.Location = new System.Drawing.Point(112, 31);
            this.mett_02.Name = "mett_02";
            this.mett_02.Size = new System.Drawing.Size(100, 59);
            this.mett_02.TabIndex = 6;
            this.mett_02.Text = "信息处理";
            this.mett_02.UseSelectable = true;
            // 
            // ml_01
            // 
            this.ml_01.AutoSize = true;
            this.ml_01.Location = new System.Drawing.Point(6, 8);
            this.ml_01.Name = "ml_01";
            this.ml_01.Size = new System.Drawing.Size(65, 20);
            this.ml_01.TabIndex = 5;
            this.ml_01.Text = "功能区：";
            // 
            // mett_01
            // 
            this.mett_01.ActiveControl = null;
            this.mett_01.Location = new System.Drawing.Point(6, 31);
            this.mett_01.Name = "mett_01";
            this.mett_01.Size = new System.Drawing.Size(100, 59);
            this.mett_01.TabIndex = 4;
            this.mett_01.Text = "条码扫描";
            this.mett_01.UseSelectable = true;
            this.mett_01.Click += new System.EventHandler(this.mett_01_Click);
            // 
            // spc_right
            // 
            this.spc_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_right.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_right.Location = new System.Drawing.Point(0, 0);
            this.spc_right.Name = "spc_right";
            this.spc_right.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spc_right.Panel1
            // 
            this.spc_right.Panel1.Controls.Add(this.gp_top);
            // 
            // spc_right.Panel2
            // 
            this.spc_right.Panel2.Controls.Add(this.met_right);
            this.spc_right.Size = new System.Drawing.Size(980, 611);
            this.spc_right.SplitterDistance = 171;
            this.spc_right.TabIndex = 0;
            // 
            // gp_top
            // 
            this.gp_top.Controls.Add(this.tb_seach);
            this.gp_top.Controls.Add(this.ml_16);
            this.gp_top.Controls.Add(this.ml_15);
            this.gp_top.Controls.Add(this.cmt_main);
            this.gp_top.Controls.Add(this.mcb_ordertype);
            this.gp_top.Controls.Add(this.ml_14);
            this.gp_top.Controls.Add(this.mcb_cost);
            this.gp_top.Controls.Add(this.mcb_customer);
            this.gp_top.Controls.Add(this.mtb_cssd);
            this.gp_top.Controls.Add(this.ml_13);
            this.gp_top.Controls.Add(this.ml_12);
            this.gp_top.Controls.Add(this.ml_11);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(980, 171);
            this.gp_top.TabIndex = 0;
            this.gp_top.TabStop = false;
            this.gp_top.SizeChanged += new System.EventHandler(this.gp_top_SizeChanged);
            // 
            // tb_seach
            // 
            this.tb_seach.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_seach.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
            this.tb_seach.Lines = new string[0];
            this.tb_seach.Location = new System.Drawing.Point(84, 135);
            this.tb_seach.MaxLength = 32767;
            this.tb_seach.Name = "tb_seach";
            this.tb_seach.PasswordChar = '\0';
            this.tb_seach.PromptText = "请输入查询信息！！";
            this.tb_seach.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_seach.SelectedText = "";
            this.tb_seach.Size = new System.Drawing.Size(260, 30);
            this.tb_seach.TabIndex = 14;
            this.tb_seach.UseSelectable = true;
            // 
            // ml_16
            // 
            this.ml_16.AutoSize = true;
            this.ml_16.Location = new System.Drawing.Point(367, 61);
            this.ml_16.Name = "ml_16";
            this.ml_16.Size = new System.Drawing.Size(79, 20);
            this.ml_16.TabIndex = 13;
            this.ml_16.Text = "信息提示：";
            // 
            // ml_15
            // 
            this.ml_15.AutoSize = true;
            this.ml_15.Location = new System.Drawing.Point(6, 136);
            this.ml_15.Name = "ml_15";
            this.ml_15.Size = new System.Drawing.Size(51, 20);
            this.ml_15.TabIndex = 11;
            this.ml_15.Text = "搜索：";
            // 
            // cmt_main
            // 
            this.cmt_main.BackColor = System.Drawing.Color.Transparent;
            this.cmt_main.Location = new System.Drawing.Point(367, 125);
            this.cmt_main.Name = "cmt_main";
            this.cmt_main.Size = new System.Drawing.Size(613, 43);
            this.cmt_main.TabIndex = 10;
            this.cmt_main.UserMonitoButtonSelect += new Cnas.wns.CnasBaseUC.ControlMonitoring.MonitoButtonSelect(this.cmt_main_UserMonitoButtonSelect);
            // 
            // mcb_ordertype
            // 
            this.mcb_ordertype.FormattingEnabled = true;
            this.mcb_ordertype.ItemHeight = 24;
            this.mcb_ordertype.Items.AddRange(new object[] {
            "0：全部"});
            this.mcb_ordertype.Location = new System.Drawing.Point(452, 14);
            this.mcb_ordertype.Name = "mcb_ordertype";
            this.mcb_ordertype.Size = new System.Drawing.Size(261, 30);
            this.mcb_ordertype.TabIndex = 9;
            this.mcb_ordertype.UseSelectable = true;
            this.mcb_ordertype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mcb_ordertype_KeyPress);
            this.mcb_ordertype.Leave += new System.EventHandler(this.mcb_ordertype_Leave);
            // 
            // ml_14
            // 
            this.ml_14.AutoSize = true;
            this.ml_14.Location = new System.Drawing.Point(367, 17);
            this.ml_14.Name = "ml_14";
            this.ml_14.Size = new System.Drawing.Size(79, 20);
            this.ml_14.TabIndex = 8;
            this.ml_14.Text = "工单类型：";
            // 
            // mcb_cost
            // 
            this.mcb_cost.FormattingEnabled = true;
            this.mcb_cost.ItemHeight = 24;
            this.mcb_cost.Items.AddRange(new object[] {
            "0：全部"});
            this.mcb_cost.Location = new System.Drawing.Point(84, 95);
            this.mcb_cost.Name = "mcb_cost";
            this.mcb_cost.Size = new System.Drawing.Size(261, 30);
            this.mcb_cost.TabIndex = 7;
            this.mcb_cost.UseSelectable = true;
            this.mcb_cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mcb_cost_KeyPress);
            this.mcb_cost.Leave += new System.EventHandler(this.mcb_cost_Leave);
            // 
            // mcb_customer
            // 
            this.mcb_customer.FormattingEnabled = true;
            this.mcb_customer.ItemHeight = 24;
            this.mcb_customer.Items.AddRange(new object[] {
            "0：全部",
            "广东省人民医院",
            "上海医院",
            "重庆医院"});
            this.mcb_customer.Location = new System.Drawing.Point(84, 56);
            this.mcb_customer.Name = "mcb_customer";
            this.mcb_customer.Size = new System.Drawing.Size(261, 30);
            this.mcb_customer.TabIndex = 6;
            this.mcb_customer.UseSelectable = true;
            this.mcb_customer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mcb_customer_KeyPress);
            this.mcb_customer.Leave += new System.EventHandler(this.mcb_customer_Leave);
            // 
            // mtb_cssd
            // 
            this.mtb_cssd.BackColor = System.Drawing.Color.White;
            this.mtb_cssd.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
            this.mtb_cssd.FontWeight = Cnas.wns.CnasMetroFramework.MetroTextBoxWeight.Bold;
            this.mtb_cssd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mtb_cssd.Lines = new string[] {
        "广东省人民医院"};
            this.mtb_cssd.Location = new System.Drawing.Point(84, 17);
            this.mtb_cssd.MaxLength = 100;
            this.mtb_cssd.Name = "mtb_cssd";
            this.mtb_cssd.PasswordChar = '\0';
            this.mtb_cssd.ReadOnly = true;
            this.mtb_cssd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtb_cssd.SelectedText = "";
            this.mtb_cssd.Size = new System.Drawing.Size(261, 30);
            this.mtb_cssd.TabIndex = 5;
            this.mtb_cssd.Text = "广东省人民医院";
            this.mtb_cssd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtb_cssd.UseCustomBackColor = true;
            this.mtb_cssd.UseSelectable = true;
            // 
            // ml_13
            // 
            this.ml_13.AutoSize = true;
            this.ml_13.Location = new System.Drawing.Point(4, 102);
            this.ml_13.Name = "ml_13";
            this.ml_13.Size = new System.Drawing.Size(79, 20);
            this.ml_13.TabIndex = 4;
            this.ml_13.Text = "成本中心：";
            // 
            // ml_12
            // 
            this.ml_12.AutoSize = true;
            this.ml_12.Location = new System.Drawing.Point(4, 61);
            this.ml_12.Name = "ml_12";
            this.ml_12.Size = new System.Drawing.Size(79, 20);
            this.ml_12.TabIndex = 3;
            this.ml_12.Text = "客户名称：";
            // 
            // ml_11
            // 
            this.ml_11.AutoSize = true;
            this.ml_11.Location = new System.Drawing.Point(6, 24);
            this.ml_11.Name = "ml_11";
            this.ml_11.Size = new System.Drawing.Size(59, 20);
            this.ml_11.TabIndex = 2;
            this.ml_11.Text = "CSSD：";
            // 
            // met_right
            // 
            this.met_right.Controls.Add(this.tabp_11);
            this.met_right.Controls.Add(this.tabp_12);
            this.met_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.met_right.Location = new System.Drawing.Point(0, 0);
            this.met_right.Name = "met_right";
            this.met_right.SelectedIndex = 0;
            this.met_right.Size = new System.Drawing.Size(980, 436);
            this.met_right.TabIndex = 0;
            this.met_right.UseSelectable = true;
            // 
            // tabp_11
            // 
            this.tabp_11.BackColor = System.Drawing.Color.Transparent;
            this.tabp_11.Controls.Add(this.dgv_01);
            this.tabp_11.Location = new System.Drawing.Point(4, 39);
            this.tabp_11.Name = "tabp_11";
            this.tabp_11.Size = new System.Drawing.Size(972, 393);
            this.tabp_11.TabIndex = 0;
            this.tabp_11.Text = "处理单列表";
            // 
            // dgv_01
            // 
            this.dgv_01.AllowUserToAddRows = false;
            this.dgv_01.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.set_code,
            this.ca_name,
            this.status,
            this.wf_code,
            this.run_times,
            this.cre_date,
            this.remark});
            this.dgv_01.ContextMenuStrip = this.mcm_right;
            this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_01.Location = new System.Drawing.Point(0, 0);
            this.dgv_01.MultiSelect = false;
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.ReadOnly = true;
            this.dgv_01.RowHeadersVisible = false;
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_01.Size = new System.Drawing.Size(972, 393);
            this.dgv_01.TabIndex = 5;
            // 
            // id
            // 
            this.id.FillWeight = 40F;
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // set_code
            // 
            this.set_code.FillWeight = 83.45177F;
            this.set_code.HeaderText = "条形码";
            this.set_code.Name = "set_code";
            this.set_code.ReadOnly = true;
            // 
            // ca_name
            // 
            this.ca_name.FillWeight = 83.45177F;
            this.ca_name.HeaderText = "名称";
            this.ca_name.Name = "ca_name";
            this.ca_name.ReadOnly = true;
            // 
            // status
            // 
            this.status.FillWeight = 83.45177F;
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // wf_code
            // 
            this.wf_code.HeaderText = "流程";
            this.wf_code.Name = "wf_code";
            this.wf_code.ReadOnly = true;
            // 
            // run_times
            // 
            this.run_times.FillWeight = 40F;
            this.run_times.HeaderText = "循环";
            this.run_times.Name = "run_times";
            this.run_times.ReadOnly = true;
            // 
            // cre_date
            // 
            this.cre_date.FillWeight = 83.45177F;
            this.cre_date.HeaderText = "创建时间";
            this.cre_date.Name = "cre_date";
            this.cre_date.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.FillWeight = 83.45177F;
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // mcm_right
            // 
            this.mcm_right.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_print,
            this.tsm_hand});
            this.mcm_right.Name = "mcm_right";
            this.mcm_right.Size = new System.Drawing.Size(125, 48);
            // 
            // tsm_print
            // 
            this.tsm_print.Name = "tsm_print";
            this.tsm_print.Size = new System.Drawing.Size(124, 22);
            this.tsm_print.Text = "打印条码";
            this.tsm_print.Click += new System.EventHandler(this.tsm_print_Click);
            // 
            // tsm_hand
            // 
            this.tsm_hand.Name = "tsm_hand";
            this.tsm_hand.Size = new System.Drawing.Size(124, 22);
            this.tsm_hand.Text = "手动处理";
            // 
            // tabp_12
            // 
            this.tabp_12.BackColor = System.Drawing.Color.Transparent;
            this.tabp_12.Location = new System.Drawing.Point(4, 39);
            this.tabp_12.Name = "tabp_12";
            this.tabp_12.Size = new System.Drawing.Size(972, 393);
            this.tabp_12.TabIndex = 1;
            this.tabp_12.Text = "其它";
            // 
            // tabp_02
            // 
            this.tabp_02.BackColor = System.Drawing.Color.Transparent;
            this.tabp_02.Location = new System.Drawing.Point(4, 39);
            this.tabp_02.Name = "tabp_02";
            this.tabp_02.Size = new System.Drawing.Size(1201, 611);
            this.tabp_02.TabIndex = 1;
            this.tabp_02.Text = "信息查询";
            // 
            // tabp_03
            // 
            this.tabp_03.BackColor = System.Drawing.Color.Transparent;
            this.tabp_03.Location = new System.Drawing.Point(4, 39);
            this.tabp_03.Name = "tabp_03";
            this.tabp_03.Size = new System.Drawing.Size(1201, 611);
            this.tabp_03.TabIndex = 2;
            this.tabp_03.Text = "其它";
            // 
            // tb_barcode
            // 
            this.tb_barcode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_barcode.Location = new System.Drawing.Point(697, 25);
            this.tb_barcode.MaxLength = 50;
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(1, 29);
            this.tb_barcode.TabIndex = 0;
            this.tb_barcode.TextChanged += new System.EventHandler(this.tb_barcode_TextChanged);
            this.tb_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_barcode_KeyDown);
            this.tb_barcode.Leave += new System.EventHandler(this.tb_barcode_Leave);
            // 
            // HCSSM_workspace_decon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 734);
            this.Controls.Add(this.met_main);
            this.Controls.Add(this.tb_barcode);
            this.Name = "HCSSM_workspace_decon";
            this.Text = "去污区工作台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.HCSSM_workspace_decon_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HCSSM_workspace_decon_FormClosed);
            this.Load += new System.EventHandler(this.HCSSM_workspace_decon_Load);
            this.met_main.ResumeLayout(false);
            this.tabp_01.ResumeLayout(false);
            this.spc_main.Panel1.ResumeLayout(false);
            this.spc_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_main)).EndInit();
            this.spc_main.ResumeLayout(false);
            this.spc_left.Panel1.ResumeLayout(false);
            this.spc_left.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_left)).EndInit();
            this.spc_left.ResumeLayout(false);
            this.spc_right.Panel1.ResumeLayout(false);
            this.spc_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_right)).EndInit();
            this.spc_right.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            this.met_right.ResumeLayout(false);
            this.tabp_11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            this.mcm_right.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CnasMetroFramework.Controls.MetroTabControl met_main;
        private System.Windows.Forms.TabPage tabp_01;
        private System.Windows.Forms.TabPage tabp_02;
        private System.Windows.Forms.TabPage tabp_03;
        private System.Windows.Forms.SplitContainer spc_main;
        private System.Windows.Forms.SplitContainer spc_right;
        private System.Windows.Forms.GroupBox gp_top;
        private CnasMetroFramework.Controls.MetroTabControl met_right;
        private System.Windows.Forms.TabPage tabp_11;
        private System.Windows.Forms.TabPage tabp_12;
        private System.Windows.Forms.DataGridView dgv_01;
        private CnasMetroFramework.Controls.MetroLabel ml_11;
        private CnasMetroFramework.Controls.MetroLabel ml_13;
        private CnasMetroFramework.Controls.MetroLabel ml_12;
        private CnasMetroFramework.Controls.MetroTextBox mtb_cssd;
        private CnasMetroFramework.Controls.MetroComboBox mcb_customer;
        private CnasMetroFramework.Controls.MetroComboBox mcb_cost;
        private System.Windows.Forms.TextBox tb_barcode;
        private CnasMetroFramework.Controls.MetroComboBox mcb_ordertype;
        private CnasMetroFramework.Controls.MetroLabel ml_14;
        private CnasBaseUC.ControlMonitoring cmt_main;
        private CnasMetroFramework.Controls.MetroLabel ml_15;
        private CnasMetroFramework.Controls.MetroLabel ml_16;
        private System.Windows.Forms.SplitContainer spc_left;
        private CnasMetroFramework.Controls.MetroTile mett_03;
        private CnasMetroFramework.Controls.MetroTile mett_02;
        private CnasMetroFramework.Controls.MetroLabel ml_01;
        private CnasMetroFramework.Controls.MetroTile mett_01;
        private CnasMetroFramework.Controls.MetroTextBox tb_seach;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn set_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn wf_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn run_times;
        private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private CnasMetroFramework.Controls.MetroContextMenu mcm_right;
        private System.Windows.Forms.ToolStripMenuItem tsm_print;
        private System.Windows.Forms.ToolStripMenuItem tsm_hand;

    }
}