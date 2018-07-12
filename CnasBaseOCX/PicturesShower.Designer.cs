namespace Cnas.wns.CnasBaseUC
{
	partial class PicturesShower
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
			this.rightBtn = new System.Windows.Forms.Button();
			this.leftBtn = new System.Windows.Forms.Button();
			this.bottomBtns = new System.Windows.Forms.TableLayoutPanel();
			this.mainPicture = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// rightBtn
			// 
			this.rightBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.rightBtn.BackColor = System.Drawing.Color.Transparent;
			this.rightBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.rightBtn.FlatAppearance.BorderSize = 0;
			this.rightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rightBtn.Image = global::Cnas.wns.CnasBaseUC.Properties.Resources.mright;
			this.rightBtn.Location = new System.Drawing.Point(280, 64);
			this.rightBtn.Margin = new System.Windows.Forms.Padding(0);
			this.rightBtn.Name = "rightBtn";
			this.rightBtn.Size = new System.Drawing.Size(40, 40);
			this.rightBtn.TabIndex = 2;
			this.rightBtn.UseVisualStyleBackColor = false;
			this.rightBtn.Click += new System.EventHandler(this.OnRightBtnClick);
			// 
			// leftBtn
			// 
			this.leftBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.leftBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.leftBtn.FlatAppearance.BorderSize = 0;
			this.leftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.leftBtn.Image = global::Cnas.wns.CnasBaseUC.Properties.Resources.mleft;
			this.leftBtn.Location = new System.Drawing.Point(0, 64);
			this.leftBtn.Margin = new System.Windows.Forms.Padding(0);
			this.leftBtn.Name = "leftBtn";
			this.leftBtn.Size = new System.Drawing.Size(40, 40);
			this.leftBtn.TabIndex = 1;
			this.leftBtn.UseVisualStyleBackColor = false;
			this.leftBtn.Click += new System.EventHandler(this.OnLeftBtnClick);
			// 
			// bottomBtns
			// 
			this.bottomBtns.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.bottomBtns.ColumnCount = 1;
			this.bottomBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.bottomBtns.Location = new System.Drawing.Point(144, 164);
			this.bottomBtns.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.bottomBtns.Name = "bottomBtns";
			this.bottomBtns.RowCount = 1;
			this.bottomBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.bottomBtns.Size = new System.Drawing.Size(32, 16);
			this.bottomBtns.TabIndex = 3;
			// 
			// mainPicture
			// 
			this.mainPicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPicture.Location = new System.Drawing.Point(0, 0);
			this.mainPicture.Margin = new System.Windows.Forms.Padding(0);
			this.mainPicture.MinimumSize = new System.Drawing.Size(80, 80);
			this.mainPicture.Name = "mainPicture";
			this.mainPicture.Size = new System.Drawing.Size(320, 180);
			this.mainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.mainPicture.TabIndex = 0;
			this.mainPicture.TabStop = false;
			// 
			// PicturesShower
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.leftBtn);
			this.Controls.Add(this.bottomBtns);
			this.Controls.Add(this.mainPicture);
			this.Controls.Add(this.rightBtn);
			this.Name = "PicturesShower";
			this.Size = new System.Drawing.Size(320, 180);
			this.Resize += new System.EventHandler(this.OnSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox mainPicture;
		private System.Windows.Forms.Button rightBtn;
		private System.Windows.Forms.Button leftBtn;
		private System.Windows.Forms.TableLayoutPanel bottomBtns;
	}
}
