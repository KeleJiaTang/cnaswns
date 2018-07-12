namespace Cnas.wns.CnasHCSSystemUC
{
	partial class HCSSM_system_config_manager
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.SendSetWithBiology = new System.Windows.Forms.CheckBox();
			this.setInCSSDTimeLbl = new System.Windows.Forms.Label();
			this.IsShowRFIDDialog = new System.Windows.Forms.CheckBox();
			this.CheckedSetInstrument = new System.Windows.Forms.CheckBox();
			this.saveBtn = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.printPanel = new System.Windows.Forms.TableLayoutPanel();
			this.barCodePrinterLbl = new System.Windows.Forms.Label();
			this.printTxt_0 = new Telerik.WinControls.UI.RadTextBox();
			this.printTxt_1 = new Telerik.WinControls.UI.RadTextBox();
			this.printSettingBtn_0 = new System.Windows.Forms.Button();
			this.printSettingBtn_1 = new System.Windows.Forms.Button();
			this.docPrinterLbl = new System.Windows.Forms.Label();
			this.UseSetWithBiology = new System.Windows.Forms.CheckBox();
			this.setInCSSDTimePanel = new System.Windows.Forms.TableLayoutPanel();
			this.timeLbl = new System.Windows.Forms.Label();
			this.SetInCSSDTime = new Telerik.WinControls.UI.RadTextBox();
			this.groupBox1.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.printPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.printTxt_0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printTxt_1)).BeginInit();
			this.setInCSSDTimePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SetInCSSDTime)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.mainPanel);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(700, 558);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainPanel.Controls.Add(this.SendSetWithBiology, 0, 3);
			this.mainPanel.Controls.Add(this.setInCSSDTimeLbl, 0, 5);
			this.mainPanel.Controls.Add(this.IsShowRFIDDialog, 0, 1);
			this.mainPanel.Controls.Add(this.CheckedSetInstrument, 1, 2);
			this.mainPanel.Controls.Add(this.saveBtn, 0, 0);
			this.mainPanel.Controls.Add(this.groupBox2, 1, 6);
			this.mainPanel.Controls.Add(this.UseSetWithBiology, 1, 0);
			this.mainPanel.Controls.Add(this.setInCSSDTimePanel, 1, 5);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mainPanel.Location = new System.Drawing.Point(3, 23);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 5;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainPanel.Size = new System.Drawing.Size(694, 532);
			this.mainPanel.TabIndex = 1;
			// 
			// SendSetWithBiology
			// 
			this.SendSetWithBiology.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.SendSetWithBiology.AutoSize = true;
			this.mainPanel.SetColumnSpan(this.SendSetWithBiology, 2);
			this.SendSetWithBiology.Location = new System.Drawing.Point(5, 141);
			this.SendSetWithBiology.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.SendSetWithBiology.Name = "SendSetWithBiology";
			this.SendSetWithBiology.Size = new System.Drawing.Size(284, 24);
			this.SendSetWithBiology.TabIndex = 2;
			this.SendSetWithBiology.Text = "无生物监测结果是否可以发送无菌包";
			this.SendSetWithBiology.UseVisualStyleBackColor = true;
			// 
			// setInCSSDTimeLbl
			// 
			this.setInCSSDTimeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.setInCSSDTimeLbl.AutoSize = true;
			this.setInCSSDTimeLbl.Location = new System.Drawing.Point(3, 173);
			this.setInCSSDTimeLbl.Name = "setInCSSDTimeLbl";
			this.setInCSSDTimeLbl.Size = new System.Drawing.Size(112, 20);
			this.setInCSSDTimeLbl.TabIndex = 5;
			this.setInCSSDTimeLbl.Text = "包在CSSD时间:";
			// 
			// IsShowRFIDDialog
			// 
			this.IsShowRFIDDialog.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.IsShowRFIDDialog.AutoSize = true;
			this.mainPanel.SetColumnSpan(this.IsShowRFIDDialog, 2);
			this.IsShowRFIDDialog.Location = new System.Drawing.Point(5, 81);
			this.IsShowRFIDDialog.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.IsShowRFIDDialog.Name = "IsShowRFIDDialog";
			this.IsShowRFIDDialog.Size = new System.Drawing.Size(235, 24);
			this.IsShowRFIDDialog.TabIndex = 1;
			this.IsShowRFIDDialog.Text = "工作台是否使用RFID监测器械";
			this.IsShowRFIDDialog.UseVisualStyleBackColor = true;
			// 
			// CheckedSetInstrument
			// 
			this.CheckedSetInstrument.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.CheckedSetInstrument.AutoSize = true;
			this.mainPanel.SetColumnSpan(this.CheckedSetInstrument, 2);
			this.CheckedSetInstrument.Location = new System.Drawing.Point(5, 111);
			this.CheckedSetInstrument.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.CheckedSetInstrument.Name = "CheckedSetInstrument";
			this.CheckedSetInstrument.Size = new System.Drawing.Size(348, 24);
			this.CheckedSetInstrument.TabIndex = 0;
			this.CheckedSetInstrument.Text = "包装界面是否需要把所有器械勾选才允许通过";
			this.CheckedSetInstrument.UseVisualStyleBackColor = true;
			// 
			// saveBtn
			// 
			this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.saveBtn.Location = new System.Drawing.Point(3, 3);
			this.saveBtn.MaximumSize = new System.Drawing.Size(90, 40);
			this.saveBtn.MinimumSize = new System.Drawing.Size(100, 42);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(100, 42);
			this.saveBtn.TabIndex = 6;
			this.saveBtn.Text = "保 存 ";
			this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
			// 
			// groupBox2
			// 
			this.mainPanel.SetColumnSpan(this.groupBox2, 2);
			this.groupBox2.Controls.Add(this.printPanel);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 201);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(688, 328);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "打印机设置";
			// 
			// printPanel
			// 
			this.printPanel.ColumnCount = 3;
			this.printPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.printPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.printPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 362F));
			this.printPanel.Controls.Add(this.barCodePrinterLbl, 0, 1);
			this.printPanel.Controls.Add(this.printTxt_0, 1, 0);
			this.printPanel.Controls.Add(this.printTxt_1, 1, 1);
			this.printPanel.Controls.Add(this.printSettingBtn_0, 2, 0);
			this.printPanel.Controls.Add(this.printSettingBtn_1, 2, 1);
			this.printPanel.Controls.Add(this.docPrinterLbl, 0, 0);
			this.printPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPanel.Location = new System.Drawing.Point(3, 23);
			this.printPanel.Margin = new System.Windows.Forms.Padding(0);
			this.printPanel.Name = "printPanel";
			this.printPanel.RowCount = 3;
			this.printPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.printPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.printPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.printPanel.Size = new System.Drawing.Size(682, 302);
			this.printPanel.TabIndex = 7;
			// 
			// barCodePrinterLbl
			// 
			this.barCodePrinterLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.barCodePrinterLbl.AutoSize = true;
			this.barCodePrinterLbl.Location = new System.Drawing.Point(19, 46);
			this.barCodePrinterLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.barCodePrinterLbl.Name = "barCodePrinterLbl";
			this.barCodePrinterLbl.Size = new System.Drawing.Size(92, 20);
			this.barCodePrinterLbl.TabIndex = 7;
			this.barCodePrinterLbl.Text = "条码打印机:";
			// 
			// printTxt_0
			// 
			this.printTxt_0.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printTxt_0.BackColor = System.Drawing.Color.LightGray;
			this.printTxt_0.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.printTxt_0.Location = new System.Drawing.Point(117, 5);
			this.printTxt_0.Name = "printTxt_0";
			this.printTxt_0.ReadOnly = true;
			this.printTxt_0.Size = new System.Drawing.Size(280, 25);
			this.printTxt_0.TabIndex = 8;
			// 
			// printTxt_1
			// 
			this.printTxt_1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.printTxt_1.BackColor = System.Drawing.Color.LightGray;
			this.printTxt_1.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.printTxt_1.Location = new System.Drawing.Point(117, 41);
			this.printTxt_1.Name = "printTxt_1";
			this.printTxt_1.ReadOnly = true;
			this.printTxt_1.Size = new System.Drawing.Size(280, 25);
			this.printTxt_1.TabIndex = 9;
			// 
			// printSettingBtn_0
			// 
			this.printSettingBtn_0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printSettingBtn_0.Location = new System.Drawing.Point(403, 3);
			this.printSettingBtn_0.MaximumSize = new System.Drawing.Size(90, 30);
			this.printSettingBtn_0.Name = "printSettingBtn_0";
			this.printSettingBtn_0.Size = new System.Drawing.Size(75, 30);
			this.printSettingBtn_0.TabIndex = 10;
			this.printSettingBtn_0.Text = "设 置";
			this.printSettingBtn_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.printSettingBtn_0.UseVisualStyleBackColor = true;
			this.printSettingBtn_0.Click += new System.EventHandler(this.OnPrintSettingBtnClick);
			// 
			// printSettingBtn_1
			// 
			this.printSettingBtn_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printSettingBtn_1.Location = new System.Drawing.Point(403, 39);
			this.printSettingBtn_1.MaximumSize = new System.Drawing.Size(90, 30);
			this.printSettingBtn_1.Name = "printSettingBtn_1";
			this.printSettingBtn_1.Size = new System.Drawing.Size(75, 30);
			this.printSettingBtn_1.TabIndex = 11;
			this.printSettingBtn_1.Text = "设 置 ";
			this.printSettingBtn_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.printSettingBtn_1.UseVisualStyleBackColor = true;
			this.printSettingBtn_1.Click += new System.EventHandler(this.OnPrintSettingBtnClick);
			// 
			// docPrinterLbl
			// 
			this.docPrinterLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.docPrinterLbl.AutoSize = true;
			this.docPrinterLbl.Location = new System.Drawing.Point(3, 8);
			this.docPrinterLbl.Name = "docPrinterLbl";
			this.docPrinterLbl.Size = new System.Drawing.Size(108, 20);
			this.docPrinterLbl.TabIndex = 6;
			this.docPrinterLbl.Text = "    文档打印机:";
			// 
			// UseSetWithBiology
			// 
			this.UseSetWithBiology.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.UseSetWithBiology.AutoSize = true;
			this.mainPanel.SetColumnSpan(this.UseSetWithBiology, 2);
			this.UseSetWithBiology.Location = new System.Drawing.Point(5, 51);
			this.UseSetWithBiology.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.UseSetWithBiology.Name = "UseSetWithBiology";
			this.UseSetWithBiology.Size = new System.Drawing.Size(284, 24);
			this.UseSetWithBiology.TabIndex = 3;
			this.UseSetWithBiology.Text = "无生物监测结果是否可以领用无菌包";
			this.UseSetWithBiology.UseVisualStyleBackColor = true;
			// 
			// setInCSSDTimePanel
			// 
			this.setInCSSDTimePanel.ColumnCount = 2;
			this.setInCSSDTimePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.setInCSSDTimePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.setInCSSDTimePanel.Controls.Add(this.timeLbl, 1, 0);
			this.setInCSSDTimePanel.Controls.Add(this.SetInCSSDTime, 0, 0);
			this.setInCSSDTimePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.setInCSSDTimePanel.Location = new System.Drawing.Point(118, 168);
			this.setInCSSDTimePanel.Margin = new System.Windows.Forms.Padding(0);
			this.setInCSSDTimePanel.Name = "setInCSSDTimePanel";
			this.setInCSSDTimePanel.RowCount = 1;
			this.setInCSSDTimePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.setInCSSDTimePanel.Size = new System.Drawing.Size(576, 30);
			this.setInCSSDTimePanel.TabIndex = 9;
			// 
			// timeLbl
			// 
			this.timeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.timeLbl.AutoSize = true;
			this.timeLbl.Location = new System.Drawing.Point(63, 5);
			this.timeLbl.Name = "timeLbl";
			this.timeLbl.Size = new System.Drawing.Size(510, 20);
			this.timeLbl.TabIndex = 6;
			this.timeLbl.Text = "小时";
			// 
			// SetInCSSDTime
			// 
			this.SetInCSSDTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.SetInCSSDTime.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.SetInCSSDTime.Location = new System.Drawing.Point(3, 3);
			this.SetInCSSDTime.Name = "SetInCSSDTime";
			this.SetInCSSDTime.Size = new System.Drawing.Size(54, 24);
			this.SetInCSSDTime.TabIndex = 4;
			this.SetInCSSDTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SetInCSSDTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPressEvent);
			// 
			// HCSSM_system_config_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "HCSSM_system_config_manager";
			this.Size = new System.Drawing.Size(700, 558);
			this.Load += new System.EventHandler(this.OnDialogLoaded);
			this.groupBox1.ResumeLayout(false);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.printPanel.ResumeLayout(false);
			this.printPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.printTxt_0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printTxt_1)).EndInit();
			this.setInCSSDTimePanel.ResumeLayout(false);
			this.setInCSSDTimePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SetInCSSDTime)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.CheckBox SendSetWithBiology;
		private System.Windows.Forms.Label setInCSSDTimeLbl;
		private Telerik.WinControls.UI.RadTextBox SetInCSSDTime;
		private System.Windows.Forms.CheckBox UseSetWithBiology;
		private System.Windows.Forms.CheckBox IsShowRFIDDialog;
		private System.Windows.Forms.CheckBox CheckedSetInstrument;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.TableLayoutPanel printPanel;
		private System.Windows.Forms.Label barCodePrinterLbl;
		private System.Windows.Forms.Label docPrinterLbl;
		private Telerik.WinControls.UI.RadTextBox printTxt_0;
		private Telerik.WinControls.UI.RadTextBox printTxt_1;
		private System.Windows.Forms.Button printSettingBtn_0;
		private System.Windows.Forms.Button printSettingBtn_1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TableLayoutPanel setInCSSDTimePanel;
		private System.Windows.Forms.Label timeLbl;

	}
}
