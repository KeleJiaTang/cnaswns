using System.Windows.Controls;
namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_set_message_show
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.deleteBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.disableBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setPanel = new System.Windows.Forms.TableLayoutPanel();
			this.setLbl = new System.Windows.Forms.Label();
			this.setCodeTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.setNameTxt = new Cnas.wns.CnasMetroFramework.Controls.MetroTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.messageGbx = new System.Windows.Forms.GroupBox();
			this.messageGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subjectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priortyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainPanel.SuspendLayout();
			this.btnPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			this.setPanel.SuspendLayout();
			this.messageGbx.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.messageGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.btnPanel, 1, 0);
			this.mainPanel.Controls.Add(this.leftPanel, 0, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.18692F));
			this.mainPanel.Size = new System.Drawing.Size(760, 535);
			this.mainPanel.TabIndex = 0;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.closeBtn, 0, 3);
			this.btnPanel.Controls.Add(this.deleteBtn, 0, 2);
			this.btnPanel.Controls.Add(this.disableBtn, 0, 1);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(664, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 4;
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.Size = new System.Drawing.Size(96, 535);
			this.btnPanel.TabIndex = 9;
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Location = new System.Drawing.Point(3, 95);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 23;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.ActiveControl = null;
			this.deleteBtn.Location = new System.Drawing.Point(3, 49);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(90, 40);
			this.deleteBtn.TabIndex = 22;
			this.deleteBtn.Text = "删 除 ";
			this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.deleteBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.deleteBtn.UseSelectable = true;
			this.deleteBtn.UseTileImage = true;
			this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// disableBtn
			// 
			this.disableBtn.ActiveControl = null;
			this.disableBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.disableBtn.Location = new System.Drawing.Point(3, 3);
			this.disableBtn.Name = "disableBtn";
			this.disableBtn.Size = new System.Drawing.Size(90, 40);
			this.disableBtn.TabIndex = 21;
			this.disableBtn.Text = "禁 用 ";
			this.disableBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.disableBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.disableBtn.UseSelectable = true;
			this.disableBtn.UseTileImage = true;
			this.disableBtn.Visible = false;
			this.disableBtn.Click += new System.EventHandler(this.disableBtn_Click);
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 1;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Controls.Add(this.setPanel, 0, 0);
			this.leftPanel.Controls.Add(this.messageGbx, 0, 1);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 2;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.leftPanel.Size = new System.Drawing.Size(664, 535);
			this.leftPanel.TabIndex = 1;
			// 
			// setPanel
			// 
			this.setPanel.ColumnCount = 4;
			this.setPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.setPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.setPanel.Controls.Add(this.setLbl, 0, 0);
			this.setPanel.Controls.Add(this.setCodeTxt, 1, 0);
			this.setPanel.Controls.Add(this.setNameTxt, 3, 0);
			this.setPanel.Controls.Add(this.label1, 2, 0);
			this.setPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setPanel.Location = new System.Drawing.Point(0, 0);
			this.setPanel.Margin = new System.Windows.Forms.Padding(0);
			this.setPanel.Name = "setPanel";
			this.setPanel.RowCount = 1;
			this.setPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.setPanel.Size = new System.Drawing.Size(664, 36);
			this.setPanel.TabIndex = 2;
			// 
			// setLbl
			// 
			this.setLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setLbl.AutoSize = true;
			this.setLbl.Location = new System.Drawing.Point(3, 8);
			this.setLbl.Margin = new System.Windows.Forms.Padding(3);
			this.setLbl.Name = "setLbl";
			this.setLbl.Size = new System.Drawing.Size(89, 20);
			this.setLbl.TabIndex = 3;
			this.setLbl.Text = "器械包条码";
			// 
			// setCodeTxt
			// 
			this.setCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setCodeTxt.BackColor = System.Drawing.Color.White;
			this.setCodeTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.setCodeTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.setCodeTxt.Lines = new string[0];
			this.setCodeTxt.Location = new System.Drawing.Point(98, 3);
			this.setCodeTxt.MaxLength = 32767;
			this.setCodeTxt.Name = "setCodeTxt";
			this.setCodeTxt.PasswordChar = '\0';
			this.setCodeTxt.ReadOnly = true;
			this.setCodeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.setCodeTxt.SelectedText = "";
			this.setCodeTxt.Size = new System.Drawing.Size(226, 29);
			this.setCodeTxt.TabIndex = 1;
			this.setCodeTxt.UseSelectable = true;
			// 
			// setNameTxt
			// 
			this.setNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.setNameTxt.BackColor = System.Drawing.Color.White;
			this.setNameTxt.FontSize = Cnas.wns.CnasMetroFramework.MetroTextBoxSize.Medium;
			this.setNameTxt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.setNameTxt.Lines = new string[0];
			this.setNameTxt.Location = new System.Drawing.Point(435, 3);
			this.setNameTxt.MaxLength = 32767;
			this.setNameTxt.Name = "setNameTxt";
			this.setNameTxt.PasswordChar = '\0';
			this.setNameTxt.ReadOnly = true;
			this.setNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.setNameTxt.SelectedText = "";
			this.setNameTxt.Size = new System.Drawing.Size(226, 29);
			this.setNameTxt.TabIndex = 2;
			this.setNameTxt.UseSelectable = true;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(340, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "器械包名称";
			// 
			// messageGbx
			// 
			this.messageGbx.Controls.Add(this.messageGrid);
			this.messageGbx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageGbx.Location = new System.Drawing.Point(0, 39);
			this.messageGbx.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.messageGbx.Name = "messageGbx";
			this.messageGbx.Size = new System.Drawing.Size(664, 496);
			this.messageGbx.TabIndex = 7;
			this.messageGbx.TabStop = false;
			this.messageGbx.Text = "消息列表";
			// 
			// messageGrid
			// 
			this.messageGrid.AllowUserToAddRows = false;
			this.messageGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.messageGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.messageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.messageGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.subjectCol,
            this.priortyCol,
            this.typeCol,
            this.descriptionCol,
            this.startDateCol,
            this.endDateCol,
            this.stateCol});
			this.messageGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageGrid.Location = new System.Drawing.Point(3, 23);
			this.messageGrid.Margin = new System.Windows.Forms.Padding(0);
			this.messageGrid.MultiSelect = false;
			this.messageGrid.Name = "messageGrid";
			this.messageGrid.ReadOnly = true;
			this.messageGrid.RowHeadersVisible = false;
			this.messageGrid.RowTemplate.Height = 23;
			this.messageGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.messageGrid.Size = new System.Drawing.Size(658, 470);
			this.messageGrid.TabIndex = 3;
			this.messageGrid.SelectionChanged += new System.EventHandler(this.OnMessageListSelectionChanged);
			// 
			// idCol
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.idCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.idCol.HeaderText = "编号";
			this.idCol.MinimumWidth = 70;
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			this.idCol.Width = 70;
			// 
			// subjectCol
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.subjectCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.subjectCol.HeaderText = "主  题";
			this.subjectCol.MinimumWidth = 100;
			this.subjectCol.Name = "subjectCol";
			this.subjectCol.ReadOnly = true;
			this.subjectCol.Width = 150;
			// 
			// priortyCol
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.priortyCol.DefaultCellStyle = dataGridViewCellStyle3;
			this.priortyCol.HeaderText = "优先级";
			this.priortyCol.MinimumWidth = 80;
			this.priortyCol.Name = "priortyCol";
			this.priortyCol.ReadOnly = true;
			this.priortyCol.Width = 120;
			// 
			// typeCol
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.typeCol.DefaultCellStyle = dataGridViewCellStyle4;
			this.typeCol.HeaderText = "消息类型";
			this.typeCol.MinimumWidth = 90;
			this.typeCol.Name = "typeCol";
			this.typeCol.ReadOnly = true;
			this.typeCol.Width = 120;
			// 
			// descriptionCol
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.descriptionCol.DefaultCellStyle = dataGridViewCellStyle5;
			this.descriptionCol.HeaderText = "信息描述";
			this.descriptionCol.MinimumWidth = 120;
			this.descriptionCol.Name = "descriptionCol";
			this.descriptionCol.ReadOnly = true;
			this.descriptionCol.Width = 200;
			// 
			// startDateCol
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.startDateCol.DefaultCellStyle = dataGridViewCellStyle6;
			this.startDateCol.HeaderText = "开始时间";
			this.startDateCol.MinimumWidth = 120;
			this.startDateCol.Name = "startDateCol";
			this.startDateCol.ReadOnly = true;
			this.startDateCol.Width = 150;
			// 
			// endDateCol
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "yyyy-MM-dd HH:mm";
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.endDateCol.DefaultCellStyle = dataGridViewCellStyle7;
			this.endDateCol.HeaderText = "结束时间";
			this.endDateCol.MinimumWidth = 120;
			this.endDateCol.Name = "endDateCol";
			this.endDateCol.ReadOnly = true;
			this.endDateCol.Width = 150;
			// 
			// stateCol
			// 
			this.stateCol.HeaderText = "状态";
			this.stateCol.Name = "stateCol";
			this.stateCol.ReadOnly = true;
			this.stateCol.Visible = false;
			// 
			// HCSSM_set_message_show
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 615);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "HCSSM_set_message_show";
			this.Text = "器械包消息";
			this.Load += new System.EventHandler(this.OnFormLoaded);
			this.mainPanel.ResumeLayout(false);
			this.btnPanel.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.setPanel.ResumeLayout(false);
			this.setPanel.PerformLayout();
			this.messageGbx.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.messageGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
		private CnasMetroFramework.Controls.MetroTile deleteBtn;
		private CnasMetroFramework.Controls.MetroTile disableBtn;
		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.GroupBox messageGbx;
		private System.Windows.Forms.DataGridView messageGrid;
		private System.Windows.Forms.TableLayoutPanel setPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label setLbl;
		private CnasMetroFramework.Controls.MetroTextBox setCodeTxt;
		private CnasMetroFramework.Controls.MetroTextBox setNameTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn subjectCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn priortyCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn startDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn endDateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn stateCol;



	}
}