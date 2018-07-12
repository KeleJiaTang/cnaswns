namespace Cnas.wns.CnasWorkflowUILibrary
{
    partial class HCSSM_set_message_manager
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.mainpanel = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgv_01 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ca_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.message_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.message_priorty = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.note_procedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cre_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mod_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.write_procedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnDel = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnPri = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnEdit = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnEnabled = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.messageSubject = new System.Windows.Forms.Label();
			this.messageSubjectTxt = new System.Windows.Forms.TextBox();
			this.messageType = new System.Windows.Forms.Label();
			this.messageLevel = new System.Windows.Forms.Label();
			this.barcodelb = new System.Windows.Forms.Label();
			this.barcodeTxt = new System.Windows.Forms.TextBox();
			this.userBarCodelb = new System.Windows.Forms.Label();
			this.userCodeBar = new System.Windows.Forms.TextBox();
			this.messageTypeCbx = new System.Windows.Forms.ComboBox();
			this.MessageLevelCbx = new System.Windows.Forms.ComboBox();
			this.searchBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.mainpanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainpanel
			// 
			this.mainpanel.ColumnCount = 1;
			this.mainpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainpanel.Controls.Add(this.groupBox1, 0, 0);
			this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainpanel.Location = new System.Drawing.Point(0, 0);
			this.mainpanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainpanel.Name = "mainpanel";
			this.mainpanel.RowCount = 1;
			this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainpanel.Size = new System.Drawing.Size(1000, 667);
			this.mainpanel.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new System.Drawing.Size(1000, 667);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "包的管理";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.dgv_01, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.messageSubject, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.messageSubjectTxt, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.messageType, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.messageLevel, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.barcodelb, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.barcodeTxt, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.userBarCodelb, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.userCodeBar, 6, 1);
			this.tableLayoutPanel1.Controls.Add(this.messageTypeCbx, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.MessageLevelCbx, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.searchBtn, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 639);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// dgv_01
			// 
			this.dgv_01.AllowUserToAddRows = false;
			this.dgv_01.AllowUserToDeleteRows = false;
			this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv_01.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.bar_code,
            this.ca_name,
            this.subject,
            this.message_type,
            this.message_priorty,
            this.description,
            this.start_date,
            this.end_date,
            this.note_procedure,
            this.cre_date,
            this.mod_date,
            this.write_procedure,
            this.state});
			this.tableLayoutPanel1.SetColumnSpan(this.dgv_01, 7);
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv_01.DefaultCellStyle = dataGridViewCellStyle13;
			this.dgv_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_01.Location = new System.Drawing.Point(3, 118);
			this.dgv_01.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgv_01.Name = "dgv_01";
			this.dgv_01.ReadOnly = true;
			this.dgv_01.RowHeadersVisible = false;
			this.dgv_01.RowTemplate.Height = 23;
			this.dgv_01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_01.Size = new System.Drawing.Size(988, 517);
			this.dgv_01.TabIndex = 1;
			this.dgv_01.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "编号";
			this.id.MinimumWidth = 70;
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			this.id.Width = 70;
			// 
			// bar_code
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bar_code.DefaultCellStyle = dataGridViewCellStyle2;
			this.bar_code.HeaderText = "器械包条码";
			this.bar_code.MinimumWidth = 80;
			this.bar_code.Name = "bar_code";
			this.bar_code.ReadOnly = true;
			this.bar_code.Width = 120;
			// 
			// ca_name
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ca_name.DefaultCellStyle = dataGridViewCellStyle3;
			this.ca_name.HeaderText = "器械包名称";
			this.ca_name.MinimumWidth = 80;
			this.ca_name.Name = "ca_name";
			this.ca_name.ReadOnly = true;
			this.ca_name.Width = 120;
			// 
			// subject
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.subject.DefaultCellStyle = dataGridViewCellStyle4;
			this.subject.HeaderText = "主题";
			this.subject.MinimumWidth = 80;
			this.subject.Name = "subject";
			this.subject.ReadOnly = true;
			this.subject.Width = 150;
			// 
			// message_type
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.message_type.DefaultCellStyle = dataGridViewCellStyle5;
			this.message_type.HeaderText = "消息类型";
			this.message_type.MinimumWidth = 80;
			this.message_type.Name = "message_type";
			this.message_type.ReadOnly = true;
			// 
			// message_priorty
			// 
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.message_priorty.DefaultCellStyle = dataGridViewCellStyle6;
			this.message_priorty.HeaderText = "消息优先级";
			this.message_priorty.MinimumWidth = 80;
			this.message_priorty.Name = "message_priorty";
			this.message_priorty.ReadOnly = true;
			this.message_priorty.Width = 120;
			// 
			// description
			// 
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.description.DefaultCellStyle = dataGridViewCellStyle7;
			this.description.HeaderText = "内容";
			this.description.MinimumWidth = 150;
			this.description.Name = "description";
			this.description.ReadOnly = true;
			this.description.Width = 200;
			// 
			// start_date
			// 
			dataGridViewCellStyle8.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.start_date.DefaultCellStyle = dataGridViewCellStyle8;
			this.start_date.HeaderText = "提醒开始时间";
			this.start_date.MinimumWidth = 120;
			this.start_date.Name = "start_date";
			this.start_date.ReadOnly = true;
			this.start_date.Width = 180;
			// 
			// end_date
			// 
			dataGridViewCellStyle9.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.end_date.DefaultCellStyle = dataGridViewCellStyle9;
			this.end_date.HeaderText = "提醒结束时间";
			this.end_date.MinimumWidth = 120;
			this.end_date.Name = "end_date";
			this.end_date.ReadOnly = true;
			this.end_date.Width = 180;
			// 
			// note_procedure
			// 
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.note_procedure.DefaultCellStyle = dataGridViewCellStyle10;
			this.note_procedure.HeaderText = "提醒节点";
			this.note_procedure.MinimumWidth = 120;
			this.note_procedure.Name = "note_procedure";
			this.note_procedure.ReadOnly = true;
			this.note_procedure.Width = 150;
			// 
			// cre_date
			// 
			dataGridViewCellStyle11.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.cre_date.DefaultCellStyle = dataGridViewCellStyle11;
			this.cre_date.HeaderText = "创建时间";
			this.cre_date.MinimumWidth = 120;
			this.cre_date.Name = "cre_date";
			this.cre_date.ReadOnly = true;
			this.cre_date.Width = 180;
			// 
			// mod_date
			// 
			dataGridViewCellStyle12.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mod_date.DefaultCellStyle = dataGridViewCellStyle12;
			this.mod_date.HeaderText = "修改时间";
			this.mod_date.MinimumWidth = 120;
			this.mod_date.Name = "mod_date";
			this.mod_date.ReadOnly = true;
			this.mod_date.Width = 180;
			// 
			// write_procedure
			// 
			this.write_procedure.HeaderText = "流程点";
			this.write_procedure.MaxInputLength = 32;
			this.write_procedure.MinimumWidth = 80;
			this.write_procedure.Name = "write_procedure";
			this.write_procedure.ReadOnly = true;
			this.write_procedure.Visible = false;
			this.write_procedure.Width = 180;
			// 
			// state
			// 
			this.state.HeaderText = "状态";
			this.state.MaxInputLength = 32;
			this.state.MinimumWidth = 80;
			this.state.Name = "state";
			this.state.ReadOnly = true;
			this.state.Visible = false;
			this.state.Width = 80;
			// 
			// btnDel
			// 
			this.btnDel.ActiveControl = null;
			this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnDel.Location = new System.Drawing.Point(99, 4);
			this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(90, 38);
			this.btnDel.TabIndex = 23;
			this.btnDel.Text = "删 除 ";
			this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDel.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDel.UseSelectable = true;
			this.btnDel.UseTileImage = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnPri
			// 
			this.btnPri.ActiveControl = null;
			this.btnPri.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPri.Location = new System.Drawing.Point(195, 4);
			this.btnPri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnPri.Name = "btnPri";
			this.btnPri.Size = new System.Drawing.Size(90, 38);
			this.btnPri.TabIndex = 24;
			this.btnPri.Text = "打 印 ";
			this.btnPri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPri.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPri.UseSelectable = true;
			this.btnPri.UseTileImage = true;
			this.btnPri.Click += new System.EventHandler(this.btnPri_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.ActiveControl = null;
			this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEdit.Location = new System.Drawing.Point(3, 4);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(90, 38);
			this.btnEdit.TabIndex = 21;
			this.btnEdit.Text = "修 改 ";
			this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEdit.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.UseSelectable = true;
			this.btnEdit.UseTileImage = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnEnabled
			// 
			this.btnEnabled.ActiveControl = null;
			this.btnEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEnabled.Location = new System.Drawing.Point(291, 4);
			this.btnEnabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnEnabled.Name = "btnEnabled";
			this.btnEnabled.Size = new System.Drawing.Size(90, 38);
			this.btnEnabled.TabIndex = 22;
			this.btnEnabled.Text = "禁 用 ";
			this.btnEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEnabled.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEnabled.UseSelectable = true;
			this.btnEnabled.UseTileImage = true;
			this.btnEnabled.Visible = false;
			this.btnEnabled.Click += new System.EventHandler(this.btnEnabled_Click);
			// 
			// messageSubject
			// 
			this.messageSubject.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.messageSubject.AutoSize = true;
			this.messageSubject.Location = new System.Drawing.Point(4, 52);
			this.messageSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.messageSubject.Name = "messageSubject";
			this.messageSubject.Size = new System.Drawing.Size(73, 20);
			this.messageSubject.TabIndex = 2;
			this.messageSubject.Text = "消息主题";
			// 
			// messageSubjectTxt
			// 
			this.messageSubjectTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageSubjectTxt.Location = new System.Drawing.Point(84, 49);
			this.messageSubjectTxt.Name = "messageSubjectTxt";
			this.messageSubjectTxt.Size = new System.Drawing.Size(200, 27);
			this.messageSubjectTxt.TabIndex = 1;
			// 
			// messageType
			// 
			this.messageType.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.messageType.AutoSize = true;
			this.messageType.Location = new System.Drawing.Point(4, 86);
			this.messageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.messageType.Name = "messageType";
			this.messageType.Size = new System.Drawing.Size(73, 20);
			this.messageType.TabIndex = 1;
			this.messageType.Text = "消息类型";
			// 
			// messageLevel
			// 
			this.messageLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.messageLevel.AutoSize = true;
			this.messageLevel.Location = new System.Drawing.Point(291, 86);
			this.messageLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.messageLevel.Name = "messageLevel";
			this.messageLevel.Size = new System.Drawing.Size(89, 20);
			this.messageLevel.TabIndex = 3;
			this.messageLevel.Text = "消息优先级";
			// 
			// barcodelb
			// 
			this.barcodelb.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.barcodelb.AutoSize = true;
			this.barcodelb.Location = new System.Drawing.Point(291, 52);
			this.barcodelb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.barcodelb.Name = "barcodelb";
			this.barcodelb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.barcodelb.Size = new System.Drawing.Size(89, 20);
			this.barcodelb.TabIndex = 0;
			this.barcodelb.Text = "器械包条码";
			this.barcodelb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// barcodeTxt
			// 
			this.barcodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.barcodeTxt.Location = new System.Drawing.Point(387, 49);
			this.barcodeTxt.Name = "barcodeTxt";
			this.barcodeTxt.Size = new System.Drawing.Size(200, 27);
			this.barcodeTxt.TabIndex = 2;
			// 
			// userBarCodelb
			// 
			this.userBarCodelb.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.userBarCodelb.AutoSize = true;
			this.userBarCodelb.Location = new System.Drawing.Point(690, 52);
			this.userBarCodelb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.userBarCodelb.Name = "userBarCodelb";
			this.userBarCodelb.Size = new System.Drawing.Size(73, 20);
			this.userBarCodelb.TabIndex = 14;
			this.userBarCodelb.Text = "用户条码";
			this.userBarCodelb.Visible = false;
			// 
			// userCodeBar
			// 
			this.userCodeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.userCodeBar.Location = new System.Drawing.Point(770, 49);
			this.userCodeBar.Name = "userCodeBar";
			this.userCodeBar.Size = new System.Drawing.Size(221, 27);
			this.userCodeBar.TabIndex = 99;
			this.userCodeBar.Visible = false;
			// 
			// messageTypeCbx
			// 
			this.messageTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTypeCbx.DisplayMember = "Value";
			this.messageTypeCbx.FormattingEnabled = true;
			this.messageTypeCbx.Location = new System.Drawing.Point(84, 82);
			this.messageTypeCbx.Name = "messageTypeCbx";
			this.messageTypeCbx.Size = new System.Drawing.Size(200, 28);
			this.messageTypeCbx.TabIndex = 3;
			this.messageTypeCbx.ValueMember = "Key";
			// 
			// MessageLevelCbx
			// 
			this.MessageLevelCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessageLevelCbx.DisplayMember = "Value";
			this.MessageLevelCbx.FormattingEnabled = true;
			this.MessageLevelCbx.Location = new System.Drawing.Point(387, 82);
			this.MessageLevelCbx.Name = "MessageLevelCbx";
			this.MessageLevelCbx.Size = new System.Drawing.Size(200, 28);
			this.MessageLevelCbx.TabIndex = 4;
			this.MessageLevelCbx.ValueMember = "Key";
			// 
			// searchBtn
			// 
			this.searchBtn.ActiveControl = null;
			this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.searchBtn.Location = new System.Drawing.Point(593, 83);
			this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(80, 27);
			this.searchBtn.TabIndex = 5;
			this.searchBtn.Text = "查 询 ";
			this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.searchBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.searchBtn.UseSelectable = true;
			this.searchBtn.UseTileImage = true;
			this.searchBtn.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 5);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.btnPri, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnEdit, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnEnabled, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnDel, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(686, 46);
			this.tableLayoutPanel3.TabIndex = 100;
			// 
			// HCSSM_set_message_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.mainpanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimumSize = new System.Drawing.Size(667, 667);
			this.Name = "HCSSM_set_message_manager";
			this.Size = new System.Drawing.Size(1000, 667);
			this.mainpanel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TableLayoutPanel mainpanel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox messageTypeCbx;
		private System.Windows.Forms.DataGridView dgv_01;
		private System.Windows.Forms.Label messageType;
		private System.Windows.Forms.TextBox barcodeTxt;
		private System.Windows.Forms.Label barcodelb;
		private System.Windows.Forms.ComboBox MessageLevelCbx;
		private System.Windows.Forms.Label messageLevel;
		private System.Windows.Forms.TextBox messageSubjectTxt;
		private System.Windows.Forms.Label messageSubject;
		private System.Windows.Forms.TextBox userCodeBar;
		private System.Windows.Forms.Label userBarCodelb;
		private CnasMetroFramework.Controls.MetroTile btnDel;
		private CnasMetroFramework.Controls.MetroTile btnPri;
		private CnasMetroFramework.Controls.MetroTile btnEdit;
		private CnasMetroFramework.Controls.MetroTile btnEnabled;
		private CnasMetroFramework.Controls.MetroTile searchBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn bar_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn ca_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn subject;
		private System.Windows.Forms.DataGridViewTextBoxColumn message_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn message_priorty;
		private System.Windows.Forms.DataGridViewTextBoxColumn description;
		private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn note_procedure;
		private System.Windows.Forms.DataGridViewTextBoxColumn cre_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn mod_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn write_procedure;
		private System.Windows.Forms.DataGridViewTextBoxColumn state;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}