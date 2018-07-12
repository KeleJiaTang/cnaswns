namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_set_message_new
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.packagePanel = new System.Windows.Forms.TableLayoutPanel();
			this.packageLbl = new System.Windows.Forms.Label();
			this.paBarCodeTxt = new System.Windows.Forms.TextBox();
			this.costCenterLbl = new System.Windows.Forms.Label();
			this.paNameTxt = new System.Windows.Forms.TextBox();
			this.messagebox = new System.Windows.Forms.GroupBox();
			this.messaageInfoPanel = new System.Windows.Forms.TableLayoutPanel();
			this.priortyLbel = new System.Windows.Forms.Label();
			this.endDatePak = new System.Windows.Forms.DateTimePicker();
			this.endDateLbl = new System.Windows.Forms.Label();
			this.subjectLbl = new System.Windows.Forms.Label();
			this.locationLbl = new System.Windows.Forms.Label();
			this.subjectTxt = new System.Windows.Forms.TextBox();
			this.priortyCbx = new System.Windows.Forms.ComboBox();
			this.messageTypeCbx = new System.Windows.Forms.ComboBox();
			this.messageTypeLbl = new System.Windows.Forms.Label();
			this.startDateLbl = new System.Windows.Forms.Label();
			this.startDatePak = new System.Windows.Forms.DateTimePicker();
			this.descriptionLbl = new System.Windows.Forms.Label();
			this.descriptionTxt = new System.Windows.Forms.TextBox();
			this.locationPanel = new System.Windows.Forms.TableLayoutPanel();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.confirmBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.mainPanel.SuspendLayout();
			this.packagePanel.SuspendLayout();
			this.messagebox.SuspendLayout();
			this.messaageInfoPanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
			this.mainPanel.Controls.Add(this.packagePanel, 0, 0);
			this.mainPanel.Controls.Add(this.messagebox, 0, 1);
			this.mainPanel.Controls.Add(this.buttonPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(21, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(759, 520);
			this.mainPanel.TabIndex = 0;
			// 
			// packagePanel
			// 
			this.packagePanel.ColumnCount = 4;
			this.packagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.packagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.packagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.packagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.packagePanel.Controls.Add(this.packageLbl, 0, 0);
			this.packagePanel.Controls.Add(this.paBarCodeTxt, 1, 0);
			this.packagePanel.Controls.Add(this.costCenterLbl, 2, 0);
			this.packagePanel.Controls.Add(this.paNameTxt, 3, 0);
			this.packagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.packagePanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.packagePanel.Location = new System.Drawing.Point(0, 0);
			this.packagePanel.Margin = new System.Windows.Forms.Padding(0);
			this.packagePanel.Name = "packagePanel";
			this.packagePanel.RowCount = 1;
			this.packagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.packagePanel.Size = new System.Drawing.Size(663, 36);
			this.packagePanel.TabIndex = 0;
			// 
			// packageLbl
			// 
			this.packageLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.packageLbl.AutoSize = true;
			this.packageLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.packageLbl.Location = new System.Drawing.Point(3, 10);
			this.packageLbl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
			this.packageLbl.Name = "packageLbl";
			this.packageLbl.Size = new System.Drawing.Size(89, 20);
			this.packageLbl.TabIndex = 0;
			this.packageLbl.Text = "器械包条码";
			// 
			// paBarCodeTxt
			// 
			this.paBarCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.paBarCodeTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.paBarCodeTxt.Location = new System.Drawing.Point(98, 4);
			this.paBarCodeTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.paBarCodeTxt.Name = "paBarCodeTxt";
			this.paBarCodeTxt.ReadOnly = true;
			this.paBarCodeTxt.Size = new System.Drawing.Size(230, 27);
			this.paBarCodeTxt.TabIndex = 1;
			this.paBarCodeTxt.TabStop = false;
			// 
			// costCenterLbl
			// 
			this.costCenterLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.costCenterLbl.AutoSize = true;
			this.costCenterLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.costCenterLbl.Location = new System.Drawing.Point(334, 8);
			this.costCenterLbl.Name = "costCenterLbl";
			this.costCenterLbl.Size = new System.Drawing.Size(89, 20);
			this.costCenterLbl.TabIndex = 9;
			this.costCenterLbl.Text = "器械包名称";
			this.costCenterLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.costCenterLbl.Visible = false;
			// 
			// paNameTxt
			// 
			this.paNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.paNameTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.paNameTxt.Location = new System.Drawing.Point(429, 4);
			this.paNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.paNameTxt.Name = "paNameTxt";
			this.paNameTxt.ReadOnly = true;
			this.paNameTxt.Size = new System.Drawing.Size(231, 27);
			this.paNameTxt.TabIndex = 2;
			this.paNameTxt.TabStop = false;
			// 
			// messagebox
			// 
			this.messagebox.Controls.Add(this.messaageInfoPanel);
			this.messagebox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messagebox.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.messagebox.Location = new System.Drawing.Point(3, 39);
			this.messagebox.Name = "messagebox";
			this.messagebox.Size = new System.Drawing.Size(657, 478);
			this.messagebox.TabIndex = 1;
			this.messagebox.TabStop = false;
			this.messagebox.Text = "信息";
			// 
			// messaageInfoPanel
			// 
			this.messaageInfoPanel.ColumnCount = 4;
			this.messaageInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.messaageInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.messaageInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.messaageInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.messaageInfoPanel.Controls.Add(this.priortyLbel, 0, 1);
			this.messaageInfoPanel.Controls.Add(this.endDatePak, 3, 2);
			this.messaageInfoPanel.Controls.Add(this.endDateLbl, 2, 2);
			this.messaageInfoPanel.Controls.Add(this.subjectLbl, 0, 0);
			this.messaageInfoPanel.Controls.Add(this.locationLbl, 0, 3);
			this.messaageInfoPanel.Controls.Add(this.subjectTxt, 1, 0);
			this.messaageInfoPanel.Controls.Add(this.priortyCbx, 1, 1);
			this.messaageInfoPanel.Controls.Add(this.messageTypeCbx, 3, 1);
			this.messaageInfoPanel.Controls.Add(this.messageTypeLbl, 2, 1);
			this.messaageInfoPanel.Controls.Add(this.startDateLbl, 0, 2);
			this.messaageInfoPanel.Controls.Add(this.startDatePak, 1, 2);
			this.messaageInfoPanel.Controls.Add(this.descriptionLbl, 0, 4);
			this.messaageInfoPanel.Controls.Add(this.descriptionTxt, 1, 4);
			this.messaageInfoPanel.Controls.Add(this.locationPanel, 1, 3);
			this.messaageInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messaageInfoPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.messaageInfoPanel.Location = new System.Drawing.Point(3, 23);
			this.messaageInfoPanel.Margin = new System.Windows.Forms.Padding(0);
			this.messaageInfoPanel.Name = "messaageInfoPanel";
			this.messaageInfoPanel.RowCount = 5;
			this.messaageInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.messaageInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.messaageInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.messaageInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.messaageInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.messaageInfoPanel.Size = new System.Drawing.Size(651, 452);
			this.messaageInfoPanel.TabIndex = 0;
			// 
			// priortyLbel
			// 
			this.priortyLbel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.priortyLbel.AutoSize = true;
			this.priortyLbel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.priortyLbel.Location = new System.Drawing.Point(3, 40);
			this.priortyLbel.Name = "priortyLbel";
			this.priortyLbel.Size = new System.Drawing.Size(73, 20);
			this.priortyLbel.TabIndex = 1;
			this.priortyLbel.Text = "优  先  级";
			// 
			// endDatePak
			// 
			this.endDatePak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.endDatePak.Checked = false;
			this.endDatePak.CustomFormat = "yyyy-MM-dd HH:mm";
			this.endDatePak.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.endDatePak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.endDatePak.Location = new System.Drawing.Point(412, 70);
			this.endDatePak.Name = "endDatePak";
			this.endDatePak.ShowCheckBox = true;
			this.endDatePak.Size = new System.Drawing.Size(236, 27);
			this.endDatePak.TabIndex = 7;
			// 
			// endDateLbl
			// 
			this.endDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.endDateLbl.AutoSize = true;
			this.endDateLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.endDateLbl.Location = new System.Drawing.Point(333, 73);
			this.endDateLbl.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
			this.endDateLbl.Name = "endDateLbl";
			this.endDateLbl.Size = new System.Drawing.Size(73, 20);
			this.endDateLbl.TabIndex = 1;
			this.endDateLbl.Text = "结束时间";
			// 
			// subjectLbl
			// 
			this.subjectLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.subjectLbl.AutoSize = true;
			this.subjectLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.subjectLbl.Location = new System.Drawing.Point(7, 6);
			this.subjectLbl.Name = "subjectLbl";
			this.subjectLbl.Size = new System.Drawing.Size(69, 20);
			this.subjectLbl.TabIndex = 0;
			this.subjectLbl.Text = "主       题";
			// 
			// locationLbl
			// 
			this.locationLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.locationLbl.AutoSize = true;
			this.locationLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.locationLbl.Location = new System.Drawing.Point(3, 104);
			this.locationLbl.Name = "locationLbl";
			this.locationLbl.Size = new System.Drawing.Size(73, 20);
			this.locationLbl.TabIndex = 3;
			this.locationLbl.Text = "提  醒  点";
			// 
			// subjectTxt
			// 
			this.subjectTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messaageInfoPanel.SetColumnSpan(this.subjectTxt, 3);
			this.subjectTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.subjectTxt.Location = new System.Drawing.Point(82, 3);
			this.subjectTxt.Name = "subjectTxt";
			this.subjectTxt.Size = new System.Drawing.Size(566, 27);
			this.subjectTxt.TabIndex = 3;
			this.subjectTxt.Tag = "1";
			// 
			// priortyCbx
			// 
			this.priortyCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.priortyCbx.BackColor = System.Drawing.Color.White;
			this.priortyCbx.DisplayMember = "Value";
			this.priortyCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.priortyCbx.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.priortyCbx.FormattingEnabled = true;
			this.priortyCbx.Location = new System.Drawing.Point(82, 36);
			this.priortyCbx.Name = "priortyCbx";
			this.priortyCbx.Size = new System.Drawing.Size(235, 28);
			this.priortyCbx.TabIndex = 4;
			this.priortyCbx.ValueMember = "Key";
			// 
			// messageTypeCbx
			// 
			this.messageTypeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTypeCbx.BackColor = System.Drawing.Color.White;
			this.messageTypeCbx.DisplayMember = "Value";
			this.messageTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.messageTypeCbx.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.messageTypeCbx.FormattingEnabled = true;
			this.messageTypeCbx.Location = new System.Drawing.Point(412, 36);
			this.messageTypeCbx.Name = "messageTypeCbx";
			this.messageTypeCbx.Size = new System.Drawing.Size(236, 28);
			this.messageTypeCbx.TabIndex = 5;
			this.messageTypeCbx.ValueMember = "Key";
			// 
			// messageTypeLbl
			// 
			this.messageTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.messageTypeLbl.AutoSize = true;
			this.messageTypeLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.messageTypeLbl.Location = new System.Drawing.Point(333, 40);
			this.messageTypeLbl.Name = "messageTypeLbl";
			this.messageTypeLbl.Size = new System.Drawing.Size(73, 20);
			this.messageTypeLbl.TabIndex = 6;
			this.messageTypeLbl.Text = "信息类型";
			// 
			// startDateLbl
			// 
			this.startDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.startDateLbl.AutoSize = true;
			this.startDateLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.startDateLbl.Location = new System.Drawing.Point(3, 73);
			this.startDateLbl.Name = "startDateLbl";
			this.startDateLbl.Size = new System.Drawing.Size(73, 20);
			this.startDateLbl.TabIndex = 0;
			this.startDateLbl.Text = "开始时间";
			// 
			// startDatePak
			// 
			this.startDatePak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startDatePak.CustomFormat = "yyyy-MM-dd HH:mm";
			this.startDatePak.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.startDatePak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.startDatePak.Location = new System.Drawing.Point(82, 70);
			this.startDatePak.Name = "startDatePak";
			this.startDatePak.Size = new System.Drawing.Size(235, 27);
			this.startDatePak.TabIndex = 6;
			// 
			// descriptionLbl
			// 
			this.descriptionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionLbl.AutoSize = true;
			this.descriptionLbl.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.descriptionLbl.Location = new System.Drawing.Point(3, 138);
			this.descriptionLbl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.descriptionLbl.Name = "descriptionLbl";
			this.descriptionLbl.Size = new System.Drawing.Size(73, 20);
			this.descriptionLbl.TabIndex = 4;
			this.descriptionLbl.Text = "信息描述";
			// 
			// descriptionTxt
			// 
			this.descriptionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messaageInfoPanel.SetColumnSpan(this.descriptionTxt, 3);
			this.descriptionTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.descriptionTxt.Location = new System.Drawing.Point(79, 128);
			this.descriptionTxt.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionTxt.Multiline = true;
			this.descriptionTxt.Name = "descriptionTxt";
			this.descriptionTxt.Size = new System.Drawing.Size(572, 324);
			this.descriptionTxt.TabIndex = 10;
			// 
			// locationPanel
			// 
			this.locationPanel.ColumnCount = 1;
			this.messaageInfoPanel.SetColumnSpan(this.locationPanel, 3);
			this.locationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.locationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.locationPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.locationPanel.Location = new System.Drawing.Point(79, 100);
			this.locationPanel.Margin = new System.Windows.Forms.Padding(0);
			this.locationPanel.Name = "locationPanel";
			this.locationPanel.RowCount = 1;
			this.locationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.locationPanel.Size = new System.Drawing.Size(572, 28);
			this.locationPanel.TabIndex = 8;
			this.locationPanel.TabStop = true;
			// 
			// buttonPanel
			// 
			this.buttonPanel.ColumnCount = 1;
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Controls.Add(this.cancelBtn, 0, 1);
			this.buttonPanel.Controls.Add(this.confirmBtn, 0, 0);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPanel.Location = new System.Drawing.Point(663, 0);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.RowCount = 2;
			this.mainPanel.SetRowSpan(this.buttonPanel, 2);
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.buttonPanel.Size = new System.Drawing.Size(96, 520);
			this.buttonPanel.TabIndex = 2;
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(3, 49);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 22;
			this.cancelBtn.Text = "取 消 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// confirmBtn
			// 
			this.confirmBtn.ActiveControl = null;
			this.confirmBtn.Location = new System.Drawing.Point(3, 3);
			this.confirmBtn.Name = "confirmBtn";
			this.confirmBtn.Size = new System.Drawing.Size(90, 40);
			this.confirmBtn.TabIndex = 21;
			this.confirmBtn.Text = "保 存 ";
			this.confirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.confirmBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.confirmBtn.UseSelectable = true;
			this.confirmBtn.UseTileImage = true;
			this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
			// 
			// HCSSM_set_message_new
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(801, 600);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MinimumSize = new System.Drawing.Size(801, 600);
			this.Name = "HCSSM_set_message_new";
			this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 20);
			this.Text = "HCSForm";
			this.mainPanel.ResumeLayout(false);
			this.packagePanel.ResumeLayout(false);
			this.packagePanel.PerformLayout();
			this.messagebox.ResumeLayout(false);
			this.messaageInfoPanel.ResumeLayout(false);
			this.messaageInfoPanel.PerformLayout();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel packagePanel;
		private System.Windows.Forms.GroupBox messagebox;
		private System.Windows.Forms.Label packageLbl;
		private System.Windows.Forms.TextBox paBarCodeTxt;
		private System.Windows.Forms.TableLayoutPanel messaageInfoPanel;
		private System.Windows.Forms.Label subjectLbl;
		private System.Windows.Forms.Label priortyLbel;
		private System.Windows.Forms.Label locationLbl;
		private System.Windows.Forms.TextBox subjectTxt;
		private System.Windows.Forms.Label messageTypeLbl;
		private System.Windows.Forms.ComboBox priortyCbx;
		private System.Windows.Forms.ComboBox messageTypeCbx;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private System.Windows.Forms.Label startDateLbl;
		private System.Windows.Forms.Label endDateLbl;
		private System.Windows.Forms.DateTimePicker startDatePak;
		private System.Windows.Forms.DateTimePicker endDatePak;
		private System.Windows.Forms.Label descriptionLbl;
		private System.Windows.Forms.TextBox descriptionTxt;
		private System.Windows.Forms.TableLayoutPanel locationPanel;
		private CnasMetroFramework.Controls.MetroTile confirmBtn;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private System.Windows.Forms.Label costCenterLbl;
		private System.Windows.Forms.TextBox paNameTxt;




	}
}