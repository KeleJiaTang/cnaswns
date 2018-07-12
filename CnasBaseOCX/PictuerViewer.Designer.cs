namespace Cnas.wns.CnasBaseUC
{
	partial class PictuerViewer
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
			this.ImageView = new Cnas.wns.CnasBaseUC.ImageViewer();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageView
			// 
			this.ImageView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ImageView.GifAnimation = true;
			this.ImageView.GifFPS = 15D;
			this.ImageView.Image = null;
			this.ImageView.Location = new System.Drawing.Point(0, 0);
			this.ImageView.Margin = new System.Windows.Forms.Padding(0);
			this.ImageView.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.ImageView.MenuPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.ImageView.MinimumSize = new System.Drawing.Size(454, 145);
			this.ImageView.Name = "ImageView";
			this.ImageView.NavigationPanelColor = System.Drawing.SystemColors.Control;
			this.ImageView.NavigationTextColor = System.Drawing.Color.Black;
			this.ImageView.OpenButton = false;
			this.ImageView.PreviewButton = true;
			this.ImageView.PreviewPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.ImageView.PreviewText = "预览";
			this.ImageView.PreviewTextColor = System.Drawing.Color.Black;
			this.ImageView.Rotation = 0;
			this.ImageView.Scrollbars = false;
			this.ImageView.ShowPreview = true;
			this.ImageView.Size = new System.Drawing.Size(740, 467);
			this.ImageView.TabIndex = 0;
			this.ImageView.TextColor = System.Drawing.Color.Black;
			this.ImageView.Zoom = 100D;
			// 
			// PictuerViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 467);
			this.Controls.Add(this.ImageView);
			this.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.MinimumSize = new System.Drawing.Size(460, 150);
			this.Name = "PictuerViewer";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "图片查看";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public ImageViewer ImageView;



	}
}