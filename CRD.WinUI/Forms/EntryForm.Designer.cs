namespace CRD.WinUI.Forms
{
    partial class EntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.SuspendLayout();
            // 
            // ptbBottomMiddle
            // 
            this.ptbBottomMiddle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbBottomMiddle.BackgroundImage")));
            this.ptbBottomMiddle.Size = new System.Drawing.Size(951, 37);
            // 
            // pnlBackGroup
            // 
            this.pnlBackGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackGroup.BackgroundImage")));
            this.pnlBackGroup.Location = new System.Drawing.Point(2, 31);
            this.pnlBackGroup.Size = new System.Drawing.Size(967, 430);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 498);
            this.Controls.Add(this.pnlBackGroup);
            this.Location = new System.Drawing.Point(400, 300);
            this.Name = "EntryForm";
            this.Text = "EntryForm";
            this.Controls.SetChildIndex(this.pnlBackGroup, 0);
            this.ResumeLayout(false);

        }

        #endregion
    }
}