namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_cycle_location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_cycle_location));
            this.lb_material = new System.Windows.Forms.Label();
            this.but_situ = new System.Windows.Forms.Button();
            this.but_package = new System.Windows.Forms.Button();
            this.but_decon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_material
            // 
            this.lb_material.AutoSize = true;
            this.lb_material.Location = new System.Drawing.Point(6, 8);
            this.lb_material.Name = "lb_material";
            this.lb_material.Size = new System.Drawing.Size(197, 12);
            this.lb_material.TabIndex = 69;
            this.lb_material.Text = "实体器械包进入循环后所去的位置：";
            // 
            // but_situ
            // 
            this.but_situ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_situ.Image = ((System.Drawing.Image)(resources.GetObject("but_situ.Image")));
            this.but_situ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_situ.Location = new System.Drawing.Point(218, 27);
            this.but_situ.Name = "but_situ";
            this.but_situ.Size = new System.Drawing.Size(99, 42);
            this.but_situ.TabIndex = 68;
            this.but_situ.Text = "     原来位置";
            this.but_situ.UseVisualStyleBackColor = true;
            // 
            // but_package
            // 
            this.but_package.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_package.Image = ((System.Drawing.Image)(resources.GetObject("but_package.Image")));
            this.but_package.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_package.Location = new System.Drawing.Point(113, 27);
            this.but_package.Name = "but_package";
            this.but_package.Size = new System.Drawing.Size(99, 42);
            this.but_package.TabIndex = 67;
            this.but_package.Text = "   打包区";
            this.but_package.UseVisualStyleBackColor = true;
            this.but_package.Click += new System.EventHandler(this.but_package_Click);
            // 
            // but_decon
            // 
            this.but_decon.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_decon.Image = ((System.Drawing.Image)(resources.GetObject("but_decon.Image")));
            this.but_decon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_decon.Location = new System.Drawing.Point(8, 27);
            this.but_decon.Name = "but_decon";
            this.but_decon.Size = new System.Drawing.Size(99, 42);
            this.but_decon.TabIndex = 66;
            this.but_decon.Text = "   去污区";
            this.but_decon.UseVisualStyleBackColor = true;
            this.but_decon.Click += new System.EventHandler(this.but_decon_Click);
            // 
            // HCSCM_set_cycle_location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 78);
            this.Controls.Add(this.lb_material);
            this.Controls.Add(this.but_situ);
            this.Controls.Add(this.but_package);
            this.Controls.Add(this.but_decon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HCSCM_set_cycle_location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HCSCM_set_cycle_location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_material;
        private System.Windows.Forms.Button but_situ;
        private System.Windows.Forms.Button but_package;
        private System.Windows.Forms.Button but_decon;
    }
}