namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSSM_order_image_add
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSSM_order_image_add));
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.confirmBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.cancelBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.photoBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.importBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.deleteBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.picSplit = new System.Windows.Forms.SplitContainer();
			this.pictureGrid = new System.Windows.Forms.DataGridView();
			this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictureNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uploadStateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.filePathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imageNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gridContextMenu = new Cnas.wns.CnasMetroFramework.Controls.MetroContextMenu(this.components);
			this.reloadBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.contextDeleteBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.picTab = new System.Windows.Forms.TabControl();
			this.preViewPage = new System.Windows.Forms.TabPage();
			this.picturePreview = new Cnas.wns.CnasBaseUC.PicturesShower();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.orderPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lab_orderNum = new System.Windows.Forms.Label();
			this.closeBtn = new Cnas.wns.CnasMetroFramework.Controls.MetroTile();
			this.txt_orderNum = new System.Windows.Forms.TextBox();
			this.uploadFileWorker = new System.ComponentModel.BackgroundWorker();
			this.mainPanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picSplit)).BeginInit();
			this.picSplit.Panel1.SuspendLayout();
			this.picSplit.Panel2.SuspendLayout();
			this.picSplit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureGrid)).BeginInit();
			this.gridContextMenu.SuspendLayout();
			this.picTab.SuspendLayout();
			this.preViewPage.SuspendLayout();
			this.orderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 1;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.buttonPanel, 0, 0);
			this.mainPanel.Controls.Add(this.picSplit, 0, 2);
			this.mainPanel.Controls.Add(this.orderPanel, 0, 1);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.mainPanel.Location = new System.Drawing.Point(20, 60);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 3;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Size = new System.Drawing.Size(960, 565);
			this.mainPanel.TabIndex = 0;
			// 
			// buttonPanel
			// 
			this.buttonPanel.ColumnCount = 5;
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.buttonPanel.Controls.Add(this.confirmBtn, 3, 0);
			this.buttonPanel.Controls.Add(this.cancelBtn, 4, 0);
			this.buttonPanel.Controls.Add(this.photoBtn, 0, 0);
			this.buttonPanel.Controls.Add(this.importBtn, 1, 0);
			this.buttonPanel.Controls.Add(this.deleteBtn, 2, 0);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPanel.Location = new System.Drawing.Point(0, 0);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.RowCount = 1;
			this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.buttonPanel.Size = new System.Drawing.Size(960, 46);
			this.buttonPanel.TabIndex = 16;
			// 
			// confirmBtn
			// 
			this.confirmBtn.ActiveControl = null;
			this.confirmBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.confirmBtn.Location = new System.Drawing.Point(773, 3);
			this.confirmBtn.Name = "confirmBtn";
			this.confirmBtn.Size = new System.Drawing.Size(88, 40);
			this.confirmBtn.TabIndex = 25;
			this.confirmBtn.Text = "确 认 ";
			this.confirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.confirmBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.confirmBtn.UseSelectable = true;
			this.confirmBtn.UseTileImage = true;
			this.confirmBtn.Click += new System.EventHandler(this.OnConfirmBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.ActiveControl = null;
			this.cancelBtn.Location = new System.Drawing.Point(867, 3);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(90, 40);
			this.cancelBtn.TabIndex = 26;
			this.cancelBtn.Text = "取 消 ";
			this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelBtn.UseSelectable = true;
			this.cancelBtn.UseTileImage = true;
			this.cancelBtn.Click += new System.EventHandler(this.OnCancelBtnClick);
			// 
			// photoBtn
			// 
			this.photoBtn.ActiveControl = null;
			this.photoBtn.Location = new System.Drawing.Point(3, 3);
			this.photoBtn.Name = "photoBtn";
			this.photoBtn.Size = new System.Drawing.Size(88, 40);
			this.photoBtn.TabIndex = 22;
			this.photoBtn.Text = "拍 照 ";
			this.photoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.photoBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.photoBtn.UseSelectable = true;
			this.photoBtn.UseTileImage = true;
			this.photoBtn.Click += new System.EventHandler(this.OnPhotoBtnClick);
			// 
			// importBtn
			// 
			this.importBtn.ActiveControl = null;
			this.importBtn.Location = new System.Drawing.Point(97, 3);
			this.importBtn.Name = "importBtn";
			this.importBtn.Size = new System.Drawing.Size(88, 40);
			this.importBtn.TabIndex = 23;
			this.importBtn.Text = "导 入 ";
			this.importBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.importBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.importBtn.UseSelectable = true;
			this.importBtn.UseTileImage = true;
			this.importBtn.Click += new System.EventHandler(this.OnImportBtnClick);
			// 
			// deleteBtn
			// 
			this.deleteBtn.ActiveControl = null;
			this.deleteBtn.Location = new System.Drawing.Point(191, 3);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(88, 40);
			this.deleteBtn.TabIndex = 24;
			this.deleteBtn.Text = "删 除 ";
			this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.deleteBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.deleteBtn.UseSelectable = true;
			this.deleteBtn.UseTileImage = true;
			this.deleteBtn.Click += new System.EventHandler(this.OnDeleteBtnClick);
			// 
			// picSplit
			// 
			this.picSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picSplit.Location = new System.Drawing.Point(3, 89);
			this.picSplit.Name = "picSplit";
			// 
			// picSplit.Panel1
			// 
			this.picSplit.Panel1.Controls.Add(this.pictureGrid);
			// 
			// picSplit.Panel2
			// 
			this.picSplit.Panel2.Controls.Add(this.picTab);
			this.picSplit.Size = new System.Drawing.Size(954, 473);
			this.picSplit.SplitterDistance = 332;
			this.picSplit.TabIndex = 18;
			// 
			// pictureGrid
			// 
			this.pictureGrid.AllowUserToAddRows = false;
			this.pictureGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.pictureGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.pictureGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.pictureGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.pictureGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.pictureNameCol,
            this.uploadStateCol,
            this.filePathCol,
            this.imageNameCol,
            this.statusCol,
            this.imageCol});
			this.pictureGrid.ContextMenuStrip = this.gridContextMenu;
			this.pictureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
			this.pictureGrid.Location = new System.Drawing.Point(0, 0);
			this.pictureGrid.Margin = new System.Windows.Forms.Padding(0);
			this.pictureGrid.MultiSelect = false;
			this.pictureGrid.Name = "pictureGrid";
			this.pictureGrid.ReadOnly = true;
			this.pictureGrid.RowHeadersVisible = false;
			this.pictureGrid.RowTemplate.Height = 23;
			this.pictureGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.pictureGrid.Size = new System.Drawing.Size(332, 473);
			this.pictureGrid.TabIndex = 2;
			this.pictureGrid.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// idCol
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.idCol.DefaultCellStyle = dataGridViewCellStyle1;
			this.idCol.FillWeight = 106.599F;
			this.idCol.HeaderText = "编 号";
			this.idCol.Name = "idCol";
			this.idCol.ReadOnly = true;
			// 
			// pictureNameCol
			// 
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.pictureNameCol.DefaultCellStyle = dataGridViewCellStyle2;
			this.pictureNameCol.FillWeight = 123.2503F;
			this.pictureNameCol.HeaderText = "名 称";
			this.pictureNameCol.Name = "pictureNameCol";
			this.pictureNameCol.ReadOnly = true;
			// 
			// uploadStateCol
			// 
			this.uploadStateCol.FillWeight = 70.1507F;
			this.uploadStateCol.HeaderText = "状 态";
			this.uploadStateCol.Name = "uploadStateCol";
			this.uploadStateCol.ReadOnly = true;
			// 
			// filePathCol
			// 
			this.filePathCol.HeaderText = "文件位置";
			this.filePathCol.Name = "filePathCol";
			this.filePathCol.ReadOnly = true;
			this.filePathCol.Visible = false;
			// 
			// imageNameCol
			// 
			this.imageNameCol.HeaderText = "imageName";
			this.imageNameCol.Name = "imageNameCol";
			this.imageNameCol.ReadOnly = true;
			this.imageNameCol.Visible = false;
			// 
			// statusCol
			// 
			this.statusCol.HeaderText = "uploadState";
			this.statusCol.Name = "statusCol";
			this.statusCol.ReadOnly = true;
			this.statusCol.Visible = false;
			// 
			// imageCol
			// 
			this.imageCol.HeaderText = "imageCol";
			this.imageCol.Name = "imageCol";
			this.imageCol.ReadOnly = true;
			this.imageCol.Visible = false;
			// 
			// gridContextMenu
			// 
			this.gridContextMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.gridContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadBtn,
            this.contextDeleteBtn});
			this.gridContextMenu.Name = "mcm_right";
			this.gridContextMenu.Size = new System.Drawing.Size(143, 52);
			this.gridContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextMenuOpening);
			// 
			// reloadBtn
			// 
			this.reloadBtn.Name = "reloadBtn";
			this.reloadBtn.Size = new System.Drawing.Size(142, 24);
			this.reloadBtn.Text = "重新上传";
			this.reloadBtn.Click += new System.EventHandler(this.OnReLoadClick);
			// 
			// contextDeleteBtn
			// 
			this.contextDeleteBtn.Name = "contextDeleteBtn";
			this.contextDeleteBtn.Size = new System.Drawing.Size(142, 24);
			this.contextDeleteBtn.Text = "删除选择";
			this.contextDeleteBtn.Click += new System.EventHandler(this.OnDeleteBtnClick);
			// 
			// picTab
			// 
			this.picTab.Controls.Add(this.preViewPage);
			this.picTab.Controls.Add(this.tabPage2);
			this.picTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picTab.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.picTab.Location = new System.Drawing.Point(0, 0);
			this.picTab.Name = "picTab";
			this.picTab.SelectedIndex = 0;
			this.picTab.Size = new System.Drawing.Size(618, 473);
			this.picTab.TabIndex = 0;
			// 
			// preViewPage
			// 
			this.preViewPage.Controls.Add(this.picturePreview);
			this.preViewPage.Location = new System.Drawing.Point(4, 29);
			this.preViewPage.Name = "preViewPage";
			this.preViewPage.Padding = new System.Windows.Forms.Padding(3);
			this.preViewPage.Size = new System.Drawing.Size(610, 440);
			this.preViewPage.TabIndex = 0;
			this.preViewPage.Text = "预览";
			this.preViewPage.UseVisualStyleBackColor = true;
			// 
			// picturePreview
			// 
			this.picturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.picturePreview.ImageAdoptLeftToRight = false;
			this.picturePreview.Images = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("picturePreview.Images")));
			this.picturePreview.IsAdoptImageSize = false;
			this.picturePreview.Location = new System.Drawing.Point(0, 0);
			this.picturePreview.Name = "picturePreview";
			this.picturePreview.SelectImage = null;
			this.picturePreview.Size = new System.Drawing.Size(480, 270);
			this.picturePreview.TabIndex = 3;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(610, 440);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "其他";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// orderPanel
			// 
			this.orderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.orderPanel.ColumnCount = 3;
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.0281F));
			this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.9719F));
			this.orderPanel.Controls.Add(this.lab_orderNum, 0, 0);
			this.orderPanel.Controls.Add(this.closeBtn, 1, 0);
			this.orderPanel.Controls.Add(this.txt_orderNum, 1, 0);
			this.orderPanel.Location = new System.Drawing.Point(0, 46);
			this.orderPanel.Margin = new System.Windows.Forms.Padding(0);
			this.orderPanel.Name = "orderPanel";
			this.orderPanel.RowCount = 1;
			this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.orderPanel.Size = new System.Drawing.Size(960, 40);
			this.orderPanel.TabIndex = 19;
			// 
			// lab_orderNum
			// 
			this.lab_orderNum.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lab_orderNum.AutoSize = true;
			this.lab_orderNum.Location = new System.Drawing.Point(3, 13);
			this.lab_orderNum.Name = "lab_orderNum";
			this.lab_orderNum.Size = new System.Drawing.Size(76, 20);
			this.lab_orderNum.TabIndex = 3;
			this.lab_orderNum.Text = "订单编号:";
			// 
			// closeBtn
			// 
			this.closeBtn.ActiveControl = null;
			this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeBtn.Location = new System.Drawing.Point(867, 3);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(90, 40);
			this.closeBtn.TabIndex = 27;
			this.closeBtn.Text = "关 闭 ";
			this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.closeBtn.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.closeBtn.UseSelectable = true;
			this.closeBtn.UseTileImage = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// txt_orderNum
			// 
			this.txt_orderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_orderNum.Location = new System.Drawing.Point(85, 9);
			this.txt_orderNum.Name = "txt_orderNum";
			this.txt_orderNum.ReadOnly = true;
			this.txt_orderNum.Size = new System.Drawing.Size(380, 27);
			this.txt_orderNum.TabIndex = 1;
			// 
			// uploadFileWorker
			// 
			this.uploadFileWorker.WorkerReportsProgress = true;
			this.uploadFileWorker.WorkerSupportsCancellation = true;
			this.uploadFileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnUploadingEvent);
			this.uploadFileWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
			this.uploadFileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnUploaded);
			// 
			// HCSSM_order_image_add
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 645);
			this.Controls.Add(this.mainPanel);
			this.Name = "HCSSM_order_image_add";
			this.Text = "订单图片";
			this.Load += new System.EventHandler(this.OnFormLoaded);
			this.mainPanel.ResumeLayout(false);
			this.buttonPanel.ResumeLayout(false);
			this.picSplit.Panel1.ResumeLayout(false);
			this.picSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picSplit)).EndInit();
			this.picSplit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureGrid)).EndInit();
			this.gridContextMenu.ResumeLayout(false);
			this.picTab.ResumeLayout(false);
			this.preViewPage.ResumeLayout(false);
			this.orderPanel.ResumeLayout(false);
			this.orderPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private CnasMetroFramework.Controls.MetroTile cancelBtn;
		private CnasMetroFramework.Controls.MetroTile confirmBtn;
		private System.Windows.Forms.TableLayoutPanel buttonPanel;
		private CnasMetroFramework.Controls.MetroTile photoBtn;
		private CnasMetroFramework.Controls.MetroTile importBtn;
		private CnasMetroFramework.Controls.MetroTile deleteBtn;
		private System.Windows.Forms.SplitContainer picSplit;
		private System.Windows.Forms.DataGridView pictureGrid;
		private System.Windows.Forms.TabControl picTab;
		private System.Windows.Forms.TabPage preViewPage;
		private System.Windows.Forms.TabPage tabPage2;
		private CnasBaseUC.PicturesShower picturePreview;
		private System.ComponentModel.BackgroundWorker uploadFileWorker;
		private CnasMetroFramework.Controls.MetroContextMenu gridContextMenu;
		private System.Windows.Forms.ToolStripMenuItem reloadBtn;
		private System.Windows.Forms.ToolStripMenuItem contextDeleteBtn;
		private System.Windows.Forms.TableLayoutPanel orderPanel;
		private System.Windows.Forms.TextBox txt_orderNum;
		private System.Windows.Forms.Label lab_orderNum;
		private CnasMetroFramework.Controls.MetroTile closeBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn pictureNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn uploadStateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn filePathCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn imageNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn imageCol;
	}
}