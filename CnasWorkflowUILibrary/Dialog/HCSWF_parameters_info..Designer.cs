namespace Cnas.wns.CnasWorkflowUILibrary
{
    partial class HCSWF_parameters_info
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
			this.tex_remark = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tex_remark
			// 
			this.tex_remark.BackColor = System.Drawing.SystemColors.Window;
			this.tex_remark.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tex_remark.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tex_remark.Location = new System.Drawing.Point(20, 60);
			this.tex_remark.Multiline = true;
			this.tex_remark.Name = "tex_remark";
			this.tex_remark.Size = new System.Drawing.Size(621, 235);
			this.tex_remark.TabIndex = 1;
			this.tex_remark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex_remark_KeyPress);
			// 
			// HCSWF_parameters_info
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 315);
			this.Controls.Add(this.tex_remark);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(661, 315);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(661, 315);
			this.Name = "HCSWF_parameters_info";
			this.Text = "请输入备注信息：";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tex_remark;
    }
}