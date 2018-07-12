namespace Cnas.wns.CnasHCSReport
{
    partial class Form1
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
            C1.Win.C1Gauge.C1GaugeSegment c1GaugeSegment2 = new C1.Win.C1Gauge.C1GaugeSegment();
            C1.Win.C1Gauge.C1GaugeMarks c1GaugeMarks2 = new C1.Win.C1Gauge.C1GaugeMarks();
            C1.Win.C1Gauge.C1GaugeLabels c1GaugeLabels2 = new C1.Win.C1Gauge.C1GaugeLabels();
            C1.Win.C1Gauge.C1GaugeSector c1GaugeSector2 = new C1.Win.C1Gauge.C1GaugeSector();
            this.c1Gauge1 = new C1.Win.C1Gauge.C1Gauge();
            this.c1RadialGauge1 = new C1.Win.C1Gauge.C1RadialGauge();
            ((System.ComponentModel.ISupportInitialize)(this.c1Gauge1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Gauge1
            // 
            this.c1Gauge1.Gauges.AddRange(new C1.Win.C1Gauge.C1GaugeBase[] {
            this.c1RadialGauge1});
            this.c1Gauge1.Location = new System.Drawing.Point(266, 243);
            this.c1Gauge1.Name = "c1Gauge1";
            this.c1Gauge1.Size = new System.Drawing.Size(200, 200);
            this.c1Gauge1.TabIndex = 0;
            this.c1Gauge1.ViewTag = ((long)(664140801242852009));
            // 
            // c1RadialGauge1
            // 
            this.c1RadialGauge1.Cap.Border.Color = System.Drawing.Color.DimGray;
            this.c1RadialGauge1.Cap.Filling.BrushType = C1.Win.C1Gauge.C1GaugeBrushType.Gradient;
            this.c1RadialGauge1.Cap.Filling.Color = System.Drawing.Color.Silver;
            this.c1RadialGauge1.Cap.Filling.Color2 = System.Drawing.Color.SlateGray;
            this.c1RadialGauge1.Cap.Gradient.Direction = C1.Win.C1Gauge.C1GaugeGradientDirection.RadialInner;
            this.c1RadialGauge1.Cap.Radius = 7D;
            this.c1RadialGauge1.Cap.Shadow.Visible = true;
            c1GaugeSegment2.Border.LineStyle = C1.Win.C1Gauge.C1GaugeBorderStyle.None;
            c1GaugeSegment2.Clippings.AddRange(new C1.Win.C1Gauge.C1GaugeClipping[] {
            new C1.Win.C1Gauge.C1GaugeClipping("Face", C1.Win.C1Gauge.C1GaugeClipOperation.Intersect, 1D)});
            c1GaugeSegment2.Filling.BrushType = C1.Win.C1Gauge.C1GaugeBrushType.Gradient;
            c1GaugeSegment2.Filling.Color = System.Drawing.Color.White;
            c1GaugeSegment2.Filling.Color2 = System.Drawing.Color.Transparent;
            c1GaugeSegment2.Filling.Opacity = 0.6D;
            c1GaugeSegment2.Filling.Opacity2 = 0D;
            c1GaugeSegment2.Filling.SwapColors = true;
            c1GaugeSegment2.Gradient.Direction = C1.Win.C1Gauge.C1GaugeGradientDirection.BackwardDiagonal;
            c1GaugeSegment2.HitTestable = false;
            c1GaugeSegment2.InnerRadius = 140D;
            c1GaugeSegment2.StartAngle = -90D;
            c1GaugeSegment2.SweepAngle = 150D;
            this.c1RadialGauge1.CoverShapes.AddRange(new C1.Win.C1Gauge.C1GaugeBaseShape[] {
            c1GaugeSegment2});
            c1GaugeMarks2.Filling.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            c1GaugeMarks2.Interval = 10D;
            c1GaugeMarks2.Length = 10D;
            c1GaugeMarks2.Shape = C1.Win.C1Gauge.C1GaugeMarkShape.Round;
            c1GaugeMarks2.ViewTag = ((long)(767083127391568622));
            c1GaugeMarks2.Width = 1.5D;
            c1GaugeLabels2.Color = System.Drawing.Color.LightGray;
            c1GaugeLabels2.FontSize = 6D;
            c1GaugeLabels2.Interval = 30D;
            c1GaugeLabels2.Location = 71D;
            c1GaugeLabels2.ViewTag = ((long)(767646077344989934));
            this.c1RadialGauge1.Decorators.AddRange(new C1.Win.C1Gauge.C1GaugeDecorator[] {
            c1GaugeMarks2,
            c1GaugeLabels2});
            c1GaugeSector2.Border.Color = System.Drawing.Color.Silver;
            c1GaugeSector2.Border.Thickness = 2D;
            c1GaugeSector2.CenterRadius = 15D;
            c1GaugeSector2.CornerRadius = 3D;
            c1GaugeSector2.Filling.BrushType = C1.Win.C1Gauge.C1GaugeBrushType.Gradient;
            c1GaugeSector2.Filling.Color = System.Drawing.Color.SlateGray;
            c1GaugeSector2.Filling.Color2 = System.Drawing.Color.Black;
            c1GaugeSector2.Gradient.Direction = C1.Win.C1Gauge.C1GaugeGradientDirection.RadialInner;
            c1GaugeSector2.HitTestable = false;
            c1GaugeSector2.Name = "Face";
            c1GaugeSector2.StartAngle = -90D;
            c1GaugeSector2.SweepAngle = 90D;
            this.c1RadialGauge1.FaceShapes.AddRange(new C1.Win.C1Gauge.C1GaugeBaseShape[] {
            c1GaugeSector2});
            this.c1RadialGauge1.Maximum = 150D;
            this.c1RadialGauge1.Name = "c1RadialGauge1";
            this.c1RadialGauge1.Pointer.Border.LineStyle = C1.Win.C1Gauge.C1GaugeBorderStyle.None;
            this.c1RadialGauge1.Pointer.Filling.Color = System.Drawing.Color.Firebrick;
            this.c1RadialGauge1.Pointer.Length = 80D;
            this.c1RadialGauge1.Pointer.Offset = -15D;
            this.c1RadialGauge1.Pointer.Shadow.Visible = true;
            this.c1RadialGauge1.Pointer.Shape = C1.Win.C1Gauge.C1GaugePointerShape.Round;
            this.c1RadialGauge1.Pointer.Value = 30D;
            this.c1RadialGauge1.Pointer.Width = 3.5D;
            this.c1RadialGauge1.PointerOriginX = 0.8D;
            this.c1RadialGauge1.PointerOriginY = 0.8D;
            this.c1RadialGauge1.Radius = 0.76D;
            this.c1RadialGauge1.StartAngle = -90D;
            this.c1RadialGauge1.SweepAngle = 90D;
            this.c1RadialGauge1.Viewport.AspectPinX = 0.5D;
            this.c1RadialGauge1.Viewport.AspectPinY = 0.5D;
            this.c1RadialGauge1.Viewport.AspectRatio = 1D;
            this.c1RadialGauge1.ViewTag = ((long)(766520177438147310));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 911);
            this.Controls.Add(this.c1Gauge1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1Gauge1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Gauge.C1Gauge c1Gauge1;
        private C1.Win.C1Gauge.C1RadialGauge c1RadialGauge1;
    }
}