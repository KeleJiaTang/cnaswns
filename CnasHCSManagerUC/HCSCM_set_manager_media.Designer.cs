namespace Cnas.wns.CnasHCSManagerUC
{
    partial class HCSCM_set_manager_media
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSCM_set_manager_media));
            this.but_dis_media = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.dgv_01 = new System.Windows.Forms.DataGridView();
            this.but_remove = new System.Windows.Forms.Button();
            this.but_new = new System.Windows.Forms.Button();
            this.but_edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // but_dis_media
            // 
            this.but_dis_media.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_dis_media.Image = ((System.Drawing.Image)(resources.GetObject("but_dis_media.Image")));
            this.but_dis_media.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_dis_media.Location = new System.Drawing.Point(325, 15);
            this.but_dis_media.Name = "but_dis_media";
            this.but_dis_media.Size = new System.Drawing.Size(119, 42);
            this.but_dis_media.TabIndex = 31;
            this.but_dis_media.Text = "    照片查看";
            this.but_dis_media.UseVisualStyleBackColor = true;
            // 
            // but_cancel
            // 
            this.but_cancel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cancel.Image = global::Cnas.wns.CnasHCSManagerUC.Properties.Resources.cancel;
            this.but_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_cancel.Location = new System.Drawing.Point(447, 15);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(99, 42);
            this.but_cancel.TabIndex = 33;
            this.but_cancel.Text = "  关闭";
            this.but_cancel.UseVisualStyleBackColor = true;
            // 
            // dgv_01
            // 
            this.dgv_01.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_01.Location = new System.Drawing.Point(7, 83);
            this.dgv_01.Name = "dgv_01";
            this.dgv_01.RowTemplate.Height = 23;
            this.dgv_01.Size = new System.Drawing.Size(539, 298);
            this.dgv_01.TabIndex = 34;
            // 
            // but_remove
            // 
            this.but_remove.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_remove.Image = ((System.Drawing.Image)(resources.GetObject("but_remove.Image")));
            this.but_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_remove.Location = new System.Drawing.Point(207, 15);
            this.but_remove.Name = "but_remove";
            this.but_remove.Size = new System.Drawing.Size(99, 42);
            this.but_remove.TabIndex = 10;
            this.but_remove.Text = "  删除";
            this.but_remove.UseVisualStyleBackColor = true;
            // 
            // but_new
            // 
            this.but_new.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
            this.but_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_new.Location = new System.Drawing.Point(7, 15);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(99, 42);
            this.but_new.TabIndex = 8;
            this.but_new.Text = "  新建";
            this.but_new.UseVisualStyleBackColor = true;
            // 
            // but_edit
            // 
            this.but_edit.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_edit.Image = ((System.Drawing.Image)(resources.GetObject("but_edit.Image")));
            this.but_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_edit.Location = new System.Drawing.Point(107, 15);
            this.but_edit.Name = "but_edit";
            this.but_edit.Size = new System.Drawing.Size(99, 42);
            this.but_edit.TabIndex = 9;
            this.but_edit.Text = "  修改";
            this.but_edit.UseVisualStyleBackColor = true;
            // 
            // HCSCM_set_manager_media
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(558, 395);
            this.Controls.Add(this.dgv_01);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_dis_media);
            this.Controls.Add(this.but_remove);
            this.Controls.Add(this.but_new);
            this.Controls.Add(this.but_edit);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HCSCM_set_manager_media";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "照片管理";
            this.Load += new System.EventHandler(this.HCSCM_manager_media_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_remove;
        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.Button but_edit;
        private System.Windows.Forms.Button but_dis_media;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.DataGridView dgv_01;
    }
}