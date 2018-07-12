namespace Cnas.wns.CnasBarcodeLib
{
    partial class Barcode_print
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
			this.PrintDialog = new System.Windows.Forms.PrintDialog();
			this.PrintDoc = new System.Drawing.Printing.PrintDocument();
			this.pan_print = new System.Windows.Forms.Panel();
			this.barcode = new System.Windows.Forms.PictureBox();
			this.pic_print = new System.Windows.Forms.PictureBox();
			this.pan_print.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_print)).BeginInit();
			this.SuspendLayout();
			// 
			// PrintDialog
			// 
			this.PrintDialog.UseEXDialog = true;
			// 
			// PrintDoc
			// 
			this.PrintDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.print01_EndPrint);
			this.PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print01_PrintPage);
			// 
			// pan_print
			// 
			this.pan_print.BackColor = System.Drawing.Color.White;
			this.pan_print.Controls.Add(this.barcode);
			this.pan_print.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pan_print.Location = new System.Drawing.Point(0, 0);
			this.pan_print.Name = "pan_print";
			this.pan_print.Size = new System.Drawing.Size(400, 250);
			this.pan_print.TabIndex = 0;
			this.pan_print.DoubleClick += new System.EventHandler(this.pan_print_DoubleClick);
			// 
			// barcode
			// 
			this.barcode.BackColor = System.Drawing.Color.White;
			this.barcode.Location = new System.Drawing.Point(54, 50);
			this.barcode.Name = "barcode";
			this.barcode.Size = new System.Drawing.Size(216, 81);
			this.barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.barcode.TabIndex = 1;
			this.barcode.TabStop = false;
			// 
			// pic_print
			// 
			this.pic_print.BackColor = System.Drawing.Color.White;
			this.pic_print.Location = new System.Drawing.Point(3, 3);
			this.pic_print.Name = "pic_print";
			this.pic_print.Size = new System.Drawing.Size(100, 50);
			this.pic_print.TabIndex = 1;
			this.pic_print.TabStop = false;
			// 
			// Barcode_print
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 250);
			this.Controls.Add(this.pan_print);
			this.Controls.Add(this.pic_print);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Barcode_print";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Barcode_print";
			this.Load += new System.EventHandler(this.Barcode_print_Load);
			this.pan_print.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_print)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Panel pan_print;
        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.PictureBox pic_print;
		public System.Windows.Forms.PrintDialog PrintDialog;
		public System.Drawing.Printing.PrintDocument PrintDoc;
    }
}