namespace CRD.WinUI.Forms
{
    partial class SkinForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tkbLightnes = new System.Windows.Forms.TrackBar();
            this.stkbSaturation = new System.Windows.Forms.TrackBar();
            this.tkbHue = new System.Windows.Forms.TrackBar();
            this.btnSkinColor7 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor3 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor6 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor5 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor2 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor4 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor1 = new CRD.WinUI.Misc.CommandButton();
            this.btnSkinColor0 = new CRD.WinUI.Misc.CommandButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnShading8 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading5 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading2 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading7 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading6 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading4 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading3 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading1 = new CRD.WinUI.Misc.CommandButton();
            this.btnShading0 = new CRD.WinUI.Misc.CommandButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbLightnes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stkbSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHue)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(165, 184);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.tkbLightnes);
            this.tabPage2.Controls.Add(this.stkbSaturation);
            this.tabPage2.Controls.Add(this.tkbHue);
            this.tabPage2.Controls.Add(this.btnSkinColor7);
            this.tabPage2.Controls.Add(this.btnSkinColor3);
            this.tabPage2.Controls.Add(this.btnSkinColor6);
            this.tabPage2.Controls.Add(this.btnSkinColor5);
            this.tabPage2.Controls.Add(this.btnSkinColor2);
            this.tabPage2.Controls.Add(this.btnSkinColor4);
            this.tabPage2.Controls.Add(this.btnSkinColor1);
            this.tabPage2.Controls.Add(this.btnSkinColor0);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(157, 159);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调色";
            // 
            // tkbLightnes
            // 
            this.tkbLightnes.AutoSize = false;
            this.tkbLightnes.LargeChange = 2;
            this.tkbLightnes.Location = new System.Drawing.Point(10, 125);
            this.tkbLightnes.Maximum = 15;
            this.tkbLightnes.Minimum = -15;
            this.tkbLightnes.Name = "tkbLightnes";
            this.tkbLightnes.Size = new System.Drawing.Size(129, 25);
            this.tkbLightnes.SmallChange = 3;
            this.tkbLightnes.TabIndex = 4;
            this.tkbLightnes.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbLightnes.Scroll += new System.EventHandler(this.ChangeSkinColor_Scroll);
            // 
            // stkbSaturation
            // 
            this.stkbSaturation.AutoSize = false;
            this.stkbSaturation.Location = new System.Drawing.Point(10, 95);
            this.stkbSaturation.Maximum = 150;
            this.stkbSaturation.Minimum = -150;
            this.stkbSaturation.Name = "stkbSaturation";
            this.stkbSaturation.Size = new System.Drawing.Size(129, 25);
            this.stkbSaturation.SmallChange = 15;
            this.stkbSaturation.TabIndex = 4;
            this.stkbSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.stkbSaturation.Scroll += new System.EventHandler(this.ChangeSkinColor_Scroll);
            // 
            // tkbHue
            // 
            this.tkbHue.AutoSize = false;
            this.tkbHue.Location = new System.Drawing.Point(10, 65);
            this.tkbHue.Maximum = 180;
            this.tkbHue.Minimum = -180;
            this.tkbHue.Name = "tkbHue";
            this.tkbHue.Size = new System.Drawing.Size(129, 24);
            this.tkbHue.SmallChange = 15;
            this.tkbHue.TabIndex = 4;
            this.tkbHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbHue.Scroll += new System.EventHandler(this.ChangeSkinColor_Scroll);
            // 
            // btnSkinColor7
            // 
            this.btnSkinColor7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor7.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor7.Location = new System.Drawing.Point(117, 40);
            this.btnSkinColor7.MouseDownImage = null;
            this.btnSkinColor7.MouseMoveImage = null;
            this.btnSkinColor7.Name = "btnSkinColor7";
            this.btnSkinColor7.NormalImage = null;
            this.btnSkinColor7.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor7.TabIndex = 3;
            this.btnSkinColor7.Tag = "OFFICE";
            this.btnSkinColor7.ToolTip = "OFFICE";
            this.btnSkinColor7.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor3
            // 
            this.btnSkinColor3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor3.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor3.Location = new System.Drawing.Point(117, 10);
            this.btnSkinColor3.MouseDownImage = null;
            this.btnSkinColor3.MouseMoveImage = null;
            this.btnSkinColor3.Name = "btnSkinColor3";
            this.btnSkinColor3.NormalImage = null;
            this.btnSkinColor3.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor3.TabIndex = 3;
            this.btnSkinColor3.Tag = "青草";
            this.btnSkinColor3.ToolTip = "青草";
            this.btnSkinColor3.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor6
            // 
            this.btnSkinColor6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor6.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor6.Location = new System.Drawing.Point(82, 40);
            this.btnSkinColor6.MouseDownImage = null;
            this.btnSkinColor6.MouseMoveImage = null;
            this.btnSkinColor6.Name = "btnSkinColor6";
            this.btnSkinColor6.NormalImage = null;
            this.btnSkinColor6.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor6.TabIndex = 3;
            this.btnSkinColor6.Tag = "巧克力";
            this.btnSkinColor6.ToolTip = "巧克力";
            this.btnSkinColor6.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor5
            // 
            this.btnSkinColor5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor5.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor5.Location = new System.Drawing.Point(47, 40);
            this.btnSkinColor5.MouseDownImage = null;
            this.btnSkinColor5.MouseMoveImage = null;
            this.btnSkinColor5.Name = "btnSkinColor5";
            this.btnSkinColor5.NormalImage = null;
            this.btnSkinColor5.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor5.TabIndex = 2;
            this.btnSkinColor5.Tag = "紫罗兰";
            this.btnSkinColor5.ToolTip = "紫罗兰";
            this.btnSkinColor5.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor2
            // 
            this.btnSkinColor2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor2.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor2.Location = new System.Drawing.Point(82, 10);
            this.btnSkinColor2.MouseDownImage = null;
            this.btnSkinColor2.MouseMoveImage = null;
            this.btnSkinColor2.Name = "btnSkinColor2";
            this.btnSkinColor2.NormalImage = null;
            this.btnSkinColor2.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor2.TabIndex = 3;
            this.btnSkinColor2.Tag = "橘子";
            this.btnSkinColor2.ToolTip = "橘子";
            this.btnSkinColor2.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor4
            // 
            this.btnSkinColor4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor4.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor4.Location = new System.Drawing.Point(12, 40);
            this.btnSkinColor4.MouseDownImage = null;
            this.btnSkinColor4.MouseMoveImage = null;
            this.btnSkinColor4.Name = "btnSkinColor4";
            this.btnSkinColor4.NormalImage = null;
            this.btnSkinColor4.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor4.TabIndex = 1;
            this.btnSkinColor4.Tag = "灰蓝";
            this.btnSkinColor4.ToolTip = "灰蓝";
            this.btnSkinColor4.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor1
            // 
            this.btnSkinColor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor1.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor1.Location = new System.Drawing.Point(47, 10);
            this.btnSkinColor1.MouseDownImage = null;
            this.btnSkinColor1.MouseMoveImage = null;
            this.btnSkinColor1.Name = "btnSkinColor1";
            this.btnSkinColor1.NormalImage = null;
            this.btnSkinColor1.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor1.TabIndex = 2;
            this.btnSkinColor1.Tag = "草莓";
            this.btnSkinColor1.ToolTip = "草莓";
            this.btnSkinColor1.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // btnSkinColor0
            // 
            this.btnSkinColor0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSkinColor0.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnSkinColor0.Location = new System.Drawing.Point(12, 10);
            this.btnSkinColor0.MouseDownImage = null;
            this.btnSkinColor0.MouseMoveImage = null;
            this.btnSkinColor0.Name = "btnSkinColor0";
            this.btnSkinColor0.NormalImage = null;
            this.btnSkinColor0.Size = new System.Drawing.Size(24, 24);
            this.btnSkinColor0.TabIndex = 1;
            this.btnSkinColor0.Tag = "Default";
            this.btnSkinColor0.ToolTip = "Default";
            this.btnSkinColor0.Click += new System.EventHandler(this.ChangeSkinColor_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnShading8);
            this.tabPage1.Controls.Add(this.btnShading5);
            this.tabPage1.Controls.Add(this.btnShading2);
            this.tabPage1.Controls.Add(this.btnShading7);
            this.tabPage1.Controls.Add(this.btnShading6);
            this.tabPage1.Controls.Add(this.btnShading4);
            this.tabPage1.Controls.Add(this.btnShading3);
            this.tabPage1.Controls.Add(this.btnShading1);
            this.tabPage1.Controls.Add(this.btnShading0);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(157, 159);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "底纹";
            // 
            // btnShading8
            // 
            this.btnShading8.BackColor = System.Drawing.Color.Transparent;
            this.btnShading8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading8.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading8.Location = new System.Drawing.Point(104, 102);
            this.btnShading8.MouseDownImage = null;
            this.btnShading8.MouseMoveImage = null;
            this.btnShading8.Name = "btnShading8";
            this.btnShading8.NormalImage = null;
            this.btnShading8.Size = new System.Drawing.Size(35, 35);
            this.btnShading8.TabIndex = 0;
            this.btnShading8.Tag = "腊梅飘香";
            this.btnShading8.ToolTip = "腊梅飘香";
            this.btnShading8.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading5
            // 
            this.btnShading5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading5.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading5.Location = new System.Drawing.Point(104, 59);
            this.btnShading5.MouseDownImage = null;
            this.btnShading5.MouseMoveImage = null;
            this.btnShading5.Name = "btnShading5";
            this.btnShading5.NormalImage = null;
            this.btnShading5.Size = new System.Drawing.Size(35, 35);
            this.btnShading5.TabIndex = 0;
            this.btnShading5.Tag = "清雅幽兰";
            this.btnShading5.ToolTip = "清雅幽兰";
            this.btnShading5.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading2
            // 
            this.btnShading2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading2.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading2.Location = new System.Drawing.Point(104, 18);
            this.btnShading2.MouseDownImage = null;
            this.btnShading2.MouseMoveImage = null;
            this.btnShading2.Name = "btnShading2";
            this.btnShading2.NormalImage = null;
            this.btnShading2.Size = new System.Drawing.Size(35, 35);
            this.btnShading2.TabIndex = 0;
            this.btnShading2.Tag = "芙蓉轻粉";
            this.btnShading2.ToolTip = "芙蓉轻粉";
            this.btnShading2.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading7
            // 
            this.btnShading7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading7.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading7.Location = new System.Drawing.Point(58, 102);
            this.btnShading7.MouseDownImage = null;
            this.btnShading7.MouseMoveImage = null;
            this.btnShading7.Name = "btnShading7";
            this.btnShading7.NormalImage = null;
            this.btnShading7.Size = new System.Drawing.Size(35, 35);
            this.btnShading7.TabIndex = 0;
            this.btnShading7.Tag = "柔和雅灰";
            this.btnShading7.ToolTip = "柔和雅灰";
            this.btnShading7.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading6
            // 
            this.btnShading6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading6.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading6.Location = new System.Drawing.Point(14, 102);
            this.btnShading6.MouseDownImage = null;
            this.btnShading6.MouseMoveImage = null;
            this.btnShading6.Name = "btnShading6";
            this.btnShading6.NormalImage = null;
            this.btnShading6.Size = new System.Drawing.Size(35, 35);
            this.btnShading6.TabIndex = 0;
            this.btnShading6.Tag = "空灵淡蓝";
            this.btnShading6.ToolTip = "空灵淡蓝";
            this.btnShading6.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading4
            // 
            this.btnShading4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading4.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading4.Location = new System.Drawing.Point(58, 59);
            this.btnShading4.MouseDownImage = null;
            this.btnShading4.MouseMoveImage = null;
            this.btnShading4.Name = "btnShading4";
            this.btnShading4.NormalImage = null;
            this.btnShading4.Size = new System.Drawing.Size(35, 35);
            this.btnShading4.TabIndex = 0;
            this.btnShading4.Tag = "橘黄雪花";
            this.btnShading4.ToolTip = "橘黄雪花";
            this.btnShading4.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading3
            // 
            this.btnShading3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading3.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading3.Location = new System.Drawing.Point(14, 59);
            this.btnShading3.MouseDownImage = null;
            this.btnShading3.MouseMoveImage = null;
            this.btnShading3.Name = "btnShading3";
            this.btnShading3.NormalImage = null;
            this.btnShading3.Size = new System.Drawing.Size(35, 35);
            this.btnShading3.TabIndex = 0;
            this.btnShading3.Tag = "荷叶嫩绿";
            this.btnShading3.ToolTip = "荷叶嫩绿";
            this.btnShading3.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading1
            // 
            this.btnShading1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading1.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading1.Location = new System.Drawing.Point(58, 18);
            this.btnShading1.MouseDownImage = null;
            this.btnShading1.MouseMoveImage = null;
            this.btnShading1.Name = "btnShading1";
            this.btnShading1.NormalImage = null;
            this.btnShading1.Size = new System.Drawing.Size(35, 35);
            this.btnShading1.TabIndex = 0;
            this.btnShading1.Tag = "淡淡墨绿";
            this.btnShading1.ToolTip = "淡淡墨绿";
            this.btnShading1.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // btnShading0
            // 
            this.btnShading0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShading0.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnShading0.Location = new System.Drawing.Point(14, 18);
            this.btnShading0.MouseDownImage = null;
            this.btnShading0.MouseMoveImage = null;
            this.btnShading0.Name = "btnShading0";
            this.btnShading0.NormalImage = null;
            this.btnShading0.Size = new System.Drawing.Size(35, 35);
            this.btnShading0.TabIndex = 0;
            this.btnShading0.Tag = "Default";
            this.btnShading0.ToolTip = "Default";
            this.btnShading0.Click += new System.EventHandler(this.ChangeBackgroundStripe_Click);
            // 
            // SkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(165, 184);
            this.Controls.Add(this.tabControl1);
            this.Name = "SkinForm";
            this.ShowInTaskbar = false;
            this.Text = "SkinForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tkbLightnes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stkbSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHue)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar tkbHue;
        private CRD.WinUI.Misc.CommandButton btnSkinColor3;
        private CRD.WinUI.Misc.CommandButton btnSkinColor2;
        private CRD.WinUI.Misc.CommandButton btnSkinColor1;
        private CRD.WinUI.Misc.CommandButton btnSkinColor0;
        private CRD.WinUI.Misc.CommandButton btnShading8;
        private CRD.WinUI.Misc.CommandButton btnShading5;
        private CRD.WinUI.Misc.CommandButton btnShading2;
        private CRD.WinUI.Misc.CommandButton btnShading7;
        private CRD.WinUI.Misc.CommandButton btnShading6;
        private CRD.WinUI.Misc.CommandButton btnShading4;
        private CRD.WinUI.Misc.CommandButton btnShading3;
        private CRD.WinUI.Misc.CommandButton btnShading1;
        private CRD.WinUI.Misc.CommandButton btnShading0;
        private System.Windows.Forms.TrackBar tkbLightnes;
        private System.Windows.Forms.TrackBar stkbSaturation;
        private CRD.WinUI.Misc.CommandButton btnSkinColor7;
        private CRD.WinUI.Misc.CommandButton btnSkinColor6;
        private CRD.WinUI.Misc.CommandButton btnSkinColor5;
        private CRD.WinUI.Misc.CommandButton btnSkinColor4;
    }
}