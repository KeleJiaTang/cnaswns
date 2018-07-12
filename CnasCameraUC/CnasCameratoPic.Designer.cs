namespace Cnas.wns.CnasCameraUC
{
    partial class CnasCameratoPic
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CnasCameratoPic));
            this.cameraControl = new Cnas.wns.CnasCameraUC.CameraControl();
            this.buttonMixerOnOff = new System.Windows.Forms.Button();
            this.buttonCrossbarSettings = new System.Windows.Forms.Button();
            this.but_photo = new System.Windows.Forms.Button();
            this.but_connect = new System.Windows.Forms.Button();
            this.buttonPinOutputSettings = new System.Windows.Forms.Button();
            this.buttonCameraSettings = new System.Windows.Forms.Button();
            this.comboBoxResolutionList = new System.Windows.Forms.ComboBox();
            this.comboBoxCameraList = new System.Windows.Forms.ComboBox();
            this.labelCameraTitle = new System.Windows.Forms.Label();
            this.tabp02 = new System.Windows.Forms.TabPage();
            this.labelResolutionTitle = new System.Windows.Forms.Label();
            this.tabp01 = new System.Windows.Forms.TabPage();
            this.buttonUnZoom = new System.Windows.Forms.Button();
            this.tabc_main = new System.Windows.Forms.TabControl();
            this.gp_top = new System.Windows.Forms.GroupBox();
            this.pic_view = new System.Windows.Forms.PictureBox();
            this.spc_top = new System.Windows.Forms.SplitContainer();
            this.sp_main = new System.Windows.Forms.SplitContainer();
            this.tabp01.SuspendLayout();
            this.tabc_main.SuspendLayout();
            this.gp_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spc_top)).BeginInit();
            this.spc_top.Panel1.SuspendLayout();
            this.spc_top.Panel2.SuspendLayout();
            this.spc_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).BeginInit();
            this.sp_main.Panel1.SuspendLayout();
            this.sp_main.Panel2.SuspendLayout();
            this.sp_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraControl
            // 
            this.cameraControl.DirectShowLogFilepath = "";
            this.cameraControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraControl.Location = new System.Drawing.Point(3, 3);
            this.cameraControl.Name = "cameraControl";
            this.cameraControl.Size = new System.Drawing.Size(782, 465);
            this.cameraControl.TabIndex = 0;
            this.cameraControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cameraControl_MouseDoubleClick);
            this.cameraControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cameraControl_MouseDown);
            this.cameraControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cameraControl_MouseMove);
            this.cameraControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cameraControl_MouseUp);
            // 
            // buttonMixerOnOff
            // 
            this.buttonMixerOnOff.Location = new System.Drawing.Point(488, 63);
            this.buttonMixerOnOff.Name = "buttonMixerOnOff";
            this.buttonMixerOnOff.Size = new System.Drawing.Size(135, 26);
            this.buttonMixerOnOff.TabIndex = 17;
            this.buttonMixerOnOff.Text = "标签(开/关)";
            this.buttonMixerOnOff.UseVisualStyleBackColor = true;
            this.buttonMixerOnOff.Click += new System.EventHandler(this.buttonMixerOnOff_Click);
            // 
            // buttonCrossbarSettings
            // 
            this.buttonCrossbarSettings.Location = new System.Drawing.Point(488, 30);
            this.buttonCrossbarSettings.Name = "buttonCrossbarSettings";
            this.buttonCrossbarSettings.Size = new System.Drawing.Size(135, 26);
            this.buttonCrossbarSettings.TabIndex = 16;
            this.buttonCrossbarSettings.Text = "方向设置";
            this.buttonCrossbarSettings.UseVisualStyleBackColor = true;
            this.buttonCrossbarSettings.Click += new System.EventHandler(this.buttonCrossbarSettings_Click);
            // 
            // but_photo
            // 
            this.but_photo.Location = new System.Drawing.Point(206, 65);
            this.but_photo.Name = "but_photo";
            this.but_photo.Size = new System.Drawing.Size(98, 26);
            this.but_photo.TabIndex = 15;
            this.but_photo.Text = "拍照";
            this.but_photo.UseVisualStyleBackColor = true;
            this.but_photo.Click += new System.EventHandler(this.but_photo_Click);
            // 
            // but_connect
            // 
            this.but_connect.Location = new System.Drawing.Point(206, 30);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(98, 26);
            this.but_connect.TabIndex = 14;
            this.but_connect.Text = "关闭";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // buttonPinOutputSettings
            // 
            this.buttonPinOutputSettings.Location = new System.Drawing.Point(347, 63);
            this.buttonPinOutputSettings.Name = "buttonPinOutputSettings";
            this.buttonPinOutputSettings.Size = new System.Drawing.Size(135, 26);
            this.buttonPinOutputSettings.TabIndex = 13;
            this.buttonPinOutputSettings.Text = "图像输出设置";
            this.buttonPinOutputSettings.UseVisualStyleBackColor = true;
            this.buttonPinOutputSettings.Click += new System.EventHandler(this.buttonPinOutputSettings_Click);
            // 
            // buttonCameraSettings
            // 
            this.buttonCameraSettings.Location = new System.Drawing.Point(347, 30);
            this.buttonCameraSettings.Name = "buttonCameraSettings";
            this.buttonCameraSettings.Size = new System.Drawing.Size(135, 26);
            this.buttonCameraSettings.TabIndex = 12;
            this.buttonCameraSettings.Text = "摄像头设置";
            this.buttonCameraSettings.UseVisualStyleBackColor = true;
            this.buttonCameraSettings.Click += new System.EventHandler(this.buttonCameraSettings_Click);
            // 
            // comboBoxResolutionList
            // 
            this.comboBoxResolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolutionList.FormattingEnabled = true;
            this.comboBoxResolutionList.Location = new System.Drawing.Point(6, 69);
            this.comboBoxResolutionList.Name = "comboBoxResolutionList";
            this.comboBoxResolutionList.Size = new System.Drawing.Size(194, 20);
            this.comboBoxResolutionList.TabIndex = 10;
            this.comboBoxResolutionList.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolutionList_SelectedIndexChanged);
            // 
            // comboBoxCameraList
            // 
            this.comboBoxCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraList.FormattingEnabled = true;
            this.comboBoxCameraList.Location = new System.Drawing.Point(6, 30);
            this.comboBoxCameraList.Name = "comboBoxCameraList";
            this.comboBoxCameraList.Size = new System.Drawing.Size(194, 20);
            this.comboBoxCameraList.TabIndex = 8;
            this.comboBoxCameraList.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameraList_SelectedIndexChanged);
            // 
            // labelCameraTitle
            // 
            this.labelCameraTitle.AutoSize = true;
            this.labelCameraTitle.Location = new System.Drawing.Point(6, 15);
            this.labelCameraTitle.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelCameraTitle.Name = "labelCameraTitle";
            this.labelCameraTitle.Size = new System.Drawing.Size(77, 12);
            this.labelCameraTitle.TabIndex = 9;
            this.labelCameraTitle.Text = "摄像头选择：";
            // 
            // tabp02
            // 
            this.tabp02.BackColor = System.Drawing.SystemColors.Control;
            this.tabp02.Location = new System.Drawing.Point(4, 22);
            this.tabp02.Name = "tabp02";
            this.tabp02.Padding = new System.Windows.Forms.Padding(3);
            this.tabp02.Size = new System.Drawing.Size(792, 475);
            this.tabp02.TabIndex = 1;
            this.tabp02.Text = "图片处理";
            // 
            // labelResolutionTitle
            // 
            this.labelResolutionTitle.AutoSize = true;
            this.labelResolutionTitle.Location = new System.Drawing.Point(6, 54);
            this.labelResolutionTitle.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelResolutionTitle.Name = "labelResolutionTitle";
            this.labelResolutionTitle.Size = new System.Drawing.Size(77, 12);
            this.labelResolutionTitle.TabIndex = 11;
            this.labelResolutionTitle.Text = "分辨率选择：";
            // 
            // tabp01
            // 
            this.tabp01.BackColor = System.Drawing.Color.DarkGray;
            this.tabp01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabp01.Controls.Add(this.buttonUnZoom);
            this.tabp01.Controls.Add(this.cameraControl);
            this.tabp01.Location = new System.Drawing.Point(4, 22);
            this.tabp01.Name = "tabp01";
            this.tabp01.Padding = new System.Windows.Forms.Padding(3);
            this.tabp01.Size = new System.Drawing.Size(792, 475);
            this.tabp01.TabIndex = 0;
            this.tabp01.Text = "拍照";
            // 
            // buttonUnZoom
            // 
            this.buttonUnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnZoom.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnZoom.Image")));
            this.buttonUnZoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUnZoom.Location = new System.Drawing.Point(13, 26);
            this.buttonUnZoom.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUnZoom.Name = "buttonUnZoom";
            this.buttonUnZoom.Size = new System.Drawing.Size(113, 24);
            this.buttonUnZoom.TabIndex = 2;
            this.buttonUnZoom.Text = "Reset zoom";
            this.buttonUnZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUnZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUnZoom.UseVisualStyleBackColor = true;
            this.buttonUnZoom.Visible = false;
            this.buttonUnZoom.Click += new System.EventHandler(this.buttonUnZoom_Click);
            // 
            // tabc_main
            // 
            this.tabc_main.Controls.Add(this.tabp01);
            this.tabc_main.Controls.Add(this.tabp02);
            this.tabc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_main.Location = new System.Drawing.Point(0, 0);
            this.tabc_main.Name = "tabc_main";
            this.tabc_main.SelectedIndex = 0;
            this.tabc_main.Size = new System.Drawing.Size(800, 501);
            this.tabc_main.TabIndex = 0;
            // 
            // gp_top
            // 
            this.gp_top.Controls.Add(this.buttonMixerOnOff);
            this.gp_top.Controls.Add(this.buttonCrossbarSettings);
            this.gp_top.Controls.Add(this.but_photo);
            this.gp_top.Controls.Add(this.but_connect);
            this.gp_top.Controls.Add(this.buttonPinOutputSettings);
            this.gp_top.Controls.Add(this.buttonCameraSettings);
            this.gp_top.Controls.Add(this.comboBoxResolutionList);
            this.gp_top.Controls.Add(this.comboBoxCameraList);
            this.gp_top.Controls.Add(this.labelCameraTitle);
            this.gp_top.Controls.Add(this.labelResolutionTitle);
            this.gp_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_top.Location = new System.Drawing.Point(0, 0);
            this.gp_top.Name = "gp_top";
            this.gp_top.Size = new System.Drawing.Size(627, 95);
            this.gp_top.TabIndex = 0;
            this.gp_top.TabStop = false;
            // 
            // pic_view
            // 
            this.pic_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_view.Location = new System.Drawing.Point(0, 0);
            this.pic_view.Name = "pic_view";
            this.pic_view.Size = new System.Drawing.Size(169, 95);
            this.pic_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_view.TabIndex = 0;
            this.pic_view.TabStop = false;
            // 
            // spc_top
            // 
            this.spc_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_top.Location = new System.Drawing.Point(0, 0);
            this.spc_top.Name = "spc_top";
            // 
            // spc_top.Panel1
            // 
            this.spc_top.Panel1.Controls.Add(this.pic_view);
            // 
            // spc_top.Panel2
            // 
            this.spc_top.Panel2.Controls.Add(this.gp_top);
            this.spc_top.Size = new System.Drawing.Size(800, 95);
            this.spc_top.SplitterDistance = 169;
            this.spc_top.TabIndex = 0;
            // 
            // sp_main
            // 
            this.sp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_main.Location = new System.Drawing.Point(0, 0);
            this.sp_main.Name = "sp_main";
            this.sp_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_main.Panel1
            // 
            this.sp_main.Panel1.Controls.Add(this.spc_top);
            // 
            // sp_main.Panel2
            // 
            this.sp_main.Panel2.Controls.Add(this.tabc_main);
            this.sp_main.Size = new System.Drawing.Size(800, 600);
            this.sp_main.SplitterDistance = 95;
            this.sp_main.TabIndex = 1;
            // 
            // CnasCameratoPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp_main);
            this.Name = "CnasCameratoPic";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CnasCameratoPic_Load);
            this.VisibleChanged += new System.EventHandler(this.CnasCameratoPic_VisibleChanged);
            this.tabp01.ResumeLayout(false);
            this.tabc_main.ResumeLayout(false);
            this.gp_top.ResumeLayout(false);
            this.gp_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_view)).EndInit();
            this.spc_top.Panel1.ResumeLayout(false);
            this.spc_top.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_top)).EndInit();
            this.spc_top.ResumeLayout(false);
            this.sp_main.Panel1.ResumeLayout(false);
            this.sp_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_main)).EndInit();
            this.sp_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CameraControl cameraControl;
        private System.Windows.Forms.Button buttonMixerOnOff;
        private System.Windows.Forms.Button buttonCrossbarSettings;
        private System.Windows.Forms.Button but_photo;
        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Button buttonPinOutputSettings;
        private System.Windows.Forms.Button buttonCameraSettings;
        private System.Windows.Forms.ComboBox comboBoxResolutionList;
        private System.Windows.Forms.ComboBox comboBoxCameraList;
        private System.Windows.Forms.Label labelCameraTitle;
        private System.Windows.Forms.TabPage tabp02;
        private System.Windows.Forms.Label labelResolutionTitle;
        private System.Windows.Forms.TabPage tabp01;
        private System.Windows.Forms.Button buttonUnZoom;
        private System.Windows.Forms.TabControl tabc_main;
        private System.Windows.Forms.GroupBox gp_top;
        private System.Windows.Forms.PictureBox pic_view;
        private System.Windows.Forms.SplitContainer spc_top;
        private System.Windows.Forms.SplitContainer sp_main;
    }
}
