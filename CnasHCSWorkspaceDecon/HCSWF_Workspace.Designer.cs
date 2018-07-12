namespace Cnas.wns.CnasHCSWorkspaceDecon
{
	partial class HCSWF_Workspace
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
			this.messageShower = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// messageShower
			// 
			this.messageShower.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnShowMessageDialog);
			// 
			// HCSWF_Workspace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 570);
			this.Name = "HCSWF_Workspace";
			this.Text = "HCSWF_Workspace";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnWorkSpaceFormClosed);
			this.Load += new System.EventHandler(this.OnWorkSpaceFormLoad);
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker messageShower;
	}
}