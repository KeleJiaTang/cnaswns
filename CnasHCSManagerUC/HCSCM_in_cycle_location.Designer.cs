namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_in_cycle_location
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
            this.but_situ = new System.Windows.Forms.Button();
            this.lb_material = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // but_situ
            // 
            this.but_situ.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.but_situ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_situ.Location = new System.Drawing.Point(8, 32);
            this.but_situ.Name = "but_situ";
            this.but_situ.Size = new System.Drawing.Size(99, 42);
            this.but_situ.TabIndex = 64;
            this.but_situ.Text = "原来位置";
            this.but_situ.UseVisualStyleBackColor = true;
            this.but_situ.Click += new System.EventHandler(this.but_situ_Click);
            // 
            // lb_material
            // 
            this.lb_material.AutoSize = true;
            this.lb_material.Location = new System.Drawing.Point(4, 9);
            this.lb_material.Name = "lb_material";
            this.lb_material.Size = new System.Drawing.Size(105, 20);
            this.lb_material.TabIndex = 65;
            this.lb_material.Text = "请选择位置：";
            // 
            // HCSCM_in_cycle_location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(128, 85);
            this.Controls.Add(this.lb_material);
            this.Controls.Add(this.but_situ);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_in_cycle_location";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_in_cycle_location";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_situ;
        private System.Windows.Forms.Label lb_material;
    }
}