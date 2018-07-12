namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_setdetail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_order_setdetail));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lbOrderSetName = new System.Windows.Forms.Label();
			this.txtOrderSetName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCustomerName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOrderName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLocationName = new System.Windows.Forms.TextBox();
			this.imagePanel = new System.Windows.Forms.TableLayoutPanel();
			this.instrumentGrid = new System.Windows.Forms.DataGridView();
			this.pictureBoxData = new Cnas.wns.CnasBaseUC.PicturesShower();
			this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnSetImage = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.btnClose = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainPanel.SuspendLayout();
			this.imagePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).BeginInit();
			this.btnPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 5;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.Controls.Add(this.lbOrderSetName, 0, 0);
			this.mainPanel.Controls.Add(this.txtOrderSetName, 1, 0);
			this.mainPanel.Controls.Add(this.label2, 2, 0);
			this.mainPanel.Controls.Add(this.txtCustomerName, 3, 0);
			this.mainPanel.Controls.Add(this.label4, 0, 1);
			this.mainPanel.Controls.Add(this.txtOrderName, 1, 1);
			this.mainPanel.Controls.Add(this.label6, 2, 1);
			this.mainPanel.Controls.Add(this.txtLocationName, 3, 1);
			this.mainPanel.Controls.Add(this.imagePanel, 0, 2);
			this.mainPanel.Controls.Add(this.btnPanel, 4, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 4;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainPanel.Size = new System.Drawing.Size(920, 510);
			this.mainPanel.TabIndex = 0;
			// 
			// lbOrderSetName
			// 
			this.lbOrderSetName.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbOrderSetName.AutoSize = true;
			this.lbOrderSetName.Location = new System.Drawing.Point(3, 6);
			this.lbOrderSetName.Margin = new System.Windows.Forms.Padding(3);
			this.lbOrderSetName.Name = "lbOrderSetName";
			this.lbOrderSetName.Size = new System.Drawing.Size(73, 20);
			this.lbOrderSetName.TabIndex = 0;
			this.lbOrderSetName.Text = "包  名  称";
			// 
			// txtOrderSetName
			// 
			this.txtOrderSetName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderSetName.Location = new System.Drawing.Point(82, 3);
			this.txtOrderSetName.Name = "txtOrderSetName";
			this.txtOrderSetName.ReadOnly = true;
			this.txtOrderSetName.Size = new System.Drawing.Size(310, 27);
			this.txtOrderSetName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(398, 6);
			this.label2.Margin = new System.Windows.Forms.Padding(3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "客户名称";
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCustomerName.Location = new System.Drawing.Point(477, 3);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.ReadOnly = true;
			this.txtCustomerName.Size = new System.Drawing.Size(329, 27);
			this.txtCustomerName.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 39);
			this.label4.Margin = new System.Windows.Forms.Padding(3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 20);
			this.label4.TabIndex = 13;
			this.label4.Text = "所在订单";
			// 
			// txtOrderName
			// 
			this.txtOrderName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOrderName.Location = new System.Drawing.Point(82, 36);
			this.txtOrderName.Name = "txtOrderName";
			this.txtOrderName.ReadOnly = true;
			this.txtOrderName.Size = new System.Drawing.Size(310, 27);
			this.txtOrderName.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(398, 39);
			this.label6.Margin = new System.Windows.Forms.Padding(3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 20);
			this.label6.TabIndex = 17;
			this.label6.Text = "使用地点";
			// 
			// txtLocationName
			// 
			this.txtLocationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocationName.Location = new System.Drawing.Point(477, 36);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.ReadOnly = true;
			this.txtLocationName.Size = new System.Drawing.Size(329, 27);
			this.txtLocationName.TabIndex = 4;
			// 
			// imagePanel
			// 
			this.imagePanel.ColumnCount = 3;
			this.mainPanel.SetColumnSpan(this.imagePanel, 4);
			this.imagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.imagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.imagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.imagePanel.Controls.Add(this.instrumentGrid, 0, 0);
			this.imagePanel.Controls.Add(this.pictureBoxData, 1, 0);
			this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePanel.Location = new System.Drawing.Point(0, 66);
			this.imagePanel.Margin = new System.Windows.Forms.Padding(0);
			this.imagePanel.Name = "imagePanel";
			this.imagePanel.RowCount = 1;
			this.mainPanel.SetRowSpan(this.imagePanel, 2);
			this.imagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.imagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 444F));
			this.imagePanel.Size = new System.Drawing.Size(809, 444);
			this.imagePanel.TabIndex = 19;
			// 
			// instrumentGrid
			// 
			this.instrumentGrid.AllowUserToAddRows = false;
			this.instrumentGrid.AllowUserToDeleteRows = false;
			this.instrumentGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.instrumentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.instrumentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.inNameCol,
            this.inNumCol,
            this.inTypeCol});
			this.instrumentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.instrumentGrid.GridColor = System.Drawing.SystemColors.ControlLight;
			this.instrumentGrid.Location = new System.Drawing.Point(0, 0);
			this.instrumentGrid.Margin = new System.Windows.Forms.Padding(0);
			this.instrumentGrid.MultiSelect = false;
			this.instrumentGrid.Name = "instrumentGrid";
			this.instrumentGrid.ReadOnly = true;
			this.instrumentGrid.RowHeadersVisible = false;
			this.instrumentGrid.RowTemplate.Height = 23;
			this.instrumentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.instrumentGrid.Size = new System.Drawing.Size(390, 444);
			this.instrumentGrid.TabIndex = 5;
			this.instrumentGrid.SelectionChanged += new System.EventHandler(this.instrumentGrid_SelectionChanged);
			// 
			// pictureBoxData
			// 
			this.pictureBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imagePanel.SetColumnSpan(this.pictureBoxData, 2);
			this.pictureBoxData.ImageAdoptLeftToRight = false;
			this.pictureBoxData.Images = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("pictureBoxData.Images")));
			this.pictureBoxData.IsAdoptImageSize = false;
			this.pictureBoxData.Location = new System.Drawing.Point(390, 0);
			this.pictureBoxData.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBoxData.Name = "pictureBoxData";
			this.pictureBoxData.SelectImage = null;
			this.pictureBoxData.Size = new System.Drawing.Size(419, 331);
			this.pictureBoxData.TabIndex = 6;
			// 
			// btnPanel
			// 
			this.btnPanel.ColumnCount = 1;
			this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Controls.Add(this.btnSetImage, 0, 0);
			this.btnPanel.Controls.Add(this.btnClose, 0, 1);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPanel.Location = new System.Drawing.Point(809, 0);
			this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.RowCount = 3;
			this.mainPanel.SetRowSpan(this.btnPanel, 4);
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.btnPanel.Size = new System.Drawing.Size(111, 510);
			this.btnPanel.TabIndex = 20;
			// 
			// btnSetImage
			// 
			this.btnSetImage.ActiveControl = null;
			this.btnSetImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnSetImage.Location = new System.Drawing.Point(3, 3);
			this.btnSetImage.Name = "btnSetImage";
			this.btnSetImage.Size = new System.Drawing.Size(105, 40);
			this.btnSetImage.TabIndex = 22;
			this.btnSetImage.Text = "包图片 ";
			this.btnSetImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSetImage.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSetImage.UseSelectable = true;
			this.btnSetImage.UseTileImage = true;
			this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
			// 
			// btnClose
			// 
			this.btnClose.ActiveControl = null;
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClose.Location = new System.Drawing.Point(3, 49);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(105, 40);
			this.btnClose.TabIndex = 23;
			this.btnClose.Text = "关    闭 ";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.UseSelectable = true;
			this.btnClose.UseTileImage = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// idCol
			// 
			this.idCol.HeaderText = "编号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			this.idCol.Visible = false;
			this.idCol.Width = 45;
			// 
			// inNameCol
			// 
			this.inNameCol.HeaderText = "器械名称";
			this.inNameCol.MinimumWidth = 130;
			this.inNameCol.Name = "inNameCol";
			this.inNameCol.ReadOnly = true;
			this.inNameCol.Width = 180;
			// 
			// inNumCol
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.NullValue = null;
			this.inNumCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.inNumCol.HeaderText = "数量";
			this.inNumCol.MinimumWidth = 140;
			this.inNumCol.Name = "inNumCol";
			this.inNumCol.ReadOnly = true;
			this.inNumCol.Width = 180;
			// 
			// inTypeCol
			// 
			this.inTypeCol.HeaderText = "器械类型";
			this.inTypeCol.MinimumWidth = 100;
			this.inTypeCol.Name = "inTypeCol";
			this.inTypeCol.ReadOnly = true;
			// 
			// HCSSM_order_setdetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 590);
			this.Controls.Add(this.mainPanel);
			this.MinimumSize = new System.Drawing.Size(815, 570);
			this.Name = "HCSSM_order_setdetail";
			this.Text = "订单包详情";
			this.Load += new System.EventHandler(this.HCSSM_order_setdetail_Load);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.imagePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.instrumentGrid)).EndInit();
			this.btnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.Label lbOrderSetName;
		private System.Windows.Forms.TextBox txtOrderSetName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCustomerName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtOrderName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtLocationName;
		private System.Windows.Forms.TableLayoutPanel imagePanel;
		private CnasBaseUC.PicturesShower pictureBoxData;
		private System.Windows.Forms.DataGridView instrumentGrid;
		private System.Windows.Forms.TableLayoutPanel btnPanel;
		private CnasMetroFramework.Controls.MetroTile btnSetImage;
		private CnasMetroFramework.Controls.MetroTile btnClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inNumCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn inTypeCol;
	}
}