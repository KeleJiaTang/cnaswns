namespace Cnas.wns.CnasWorkflowUILibrary
{
	partial class HCSWF_specialset_pack
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSWF_specialset_pack));
			this.specialSetPacking = new Cnas.wns.CnasWorkflowUILibrary.HCSWF_specialset_packing();
			this.SuspendLayout();
			// 
			// specialSetPacking
			// 
			this.specialSetPacking.Dock = System.Windows.Forms.DockStyle.Fill;
			this.specialSetPacking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.specialSetPacking.Location = new System.Drawing.Point(20, 60);
			this.specialSetPacking.Margin = new System.Windows.Forms.Padding(0);
			this.specialSetPacking.Name = "specialSetPacking";
			this.specialSetPacking.OutputParameters = ((System.Collections.SortedList)(resources.GetObject("specialSetPacking.OutputParameters")));
			this.specialSetPacking.PdCode = "";
			this.specialSetPacking.ScanBarCodes = ((System.Collections.SortedList)(resources.GetObject("specialSetPacking.ScanBarCodes")));
			this.specialSetPacking.Size = new System.Drawing.Size(1047, 750);
			this.specialSetPacking.TabIndex = 1;
			// 
			// HCSWF_specialset_pack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1087, 830);
			this.Controls.Add(this.specialSetPacking);
			this.Name = "HCSWF_specialset_pack";
			this.Text = "打包特殊包";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosedEvent);
			this.ResumeLayout(false);

		}

		#endregion

		private HCS_packset_all_dealinstrument dealOrderNum;
		private HCSWF_specialset_packing specialSetPacking;
	}
}