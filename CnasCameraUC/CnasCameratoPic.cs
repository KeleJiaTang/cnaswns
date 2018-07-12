using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

using Cnas.wns.CnasCameraDirectShowLib;

namespace Cnas.wns.CnasCameraUC
{
    public partial class CnasCameratoPic : UserControl
    {
        private NormalizedRect _MouseSelectionRect = new NormalizedRect(0, 0, 0, 0);
        ResolutionList resolutions = new ResolutionList();
        Bitmap bitmapData = null;
        private bool _bDrawMouseSelection = false;

        // Zooming
        private bool _bZoomed = false;
        private double _fZoomValue = 1.0;

        // Camera choice
        private CameraChoice _CameraChoice = new CameraChoice();
        

        public CnasCameratoPic()
        {
            InitializeComponent();
        }


        private void comboBoxCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCameraList.SelectedIndex < 0)
            {
                cameraControl.CloseCamera();
            }
            else
            {
                // Set camera
                SetCamera(_CameraChoice.Devices[comboBoxCameraList.SelectedIndex].Mon, null);
            }

            FillResolutionList();
        }

        private void comboBoxResolutionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated)
                return;

            int comboBoxResolutionIndex = comboBoxResolutionList.SelectedIndex;
            if (comboBoxResolutionIndex < 0)
            {
                return;
            }
            resolutions = Camera.GetResolutionList(cameraControl.Moniker);

            if (resolutions == null)
                return;

            if (comboBoxResolutionIndex >= resolutions.Count)
                return; // throw

            if (0 == resolutions[comboBoxResolutionIndex].CompareTo(cameraControl.Resolution))
            {
                // this resolution is already selected
                return;
            }

            // Recreate camera
            SetCamera(cameraControl.Moniker, resolutions[comboBoxResolutionIndex]);


        }

        private void cameraControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!cameraControl.CameraCreated)
                return;

            if (_bZoomed)
                return;

            PointF point = cameraControl.ConvertWinToNorm(new PointF(e.X, e.Y));
            _MouseSelectionRect = new NormalizedRect(point.X, point.Y, point.X, point.Y);

            _bDrawMouseSelection = true;
            UpdateCameraBitmap();
        }

        private void cameraControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_bZoomed)
                return;

            if (!_bDrawMouseSelection)
                return;

            // Zoom
            if (!IsMouseSelectionRectCorrectAndGood())
            {
                // Doesn't allow zoom too much

                _bDrawMouseSelection = false;
                UpdateCameraBitmap();
                return;
            }


            int w = cameraControl.Resolution.Width;
            int h = cameraControl.Resolution.Height;

            double rect_w = w * (_MouseSelectionRect.right - _MouseSelectionRect.left);
            double rect_h = h * (_MouseSelectionRect.bottom - _MouseSelectionRect.top);


            // Save frame proportion

            double ratio_video = ((double)w) / h;
            double ratio_rect = ((double)rect_w) / rect_h;

            //NormalizedRect norm_rect;



            if (ratio_video >= ratio_rect)
            {
                // calculate width
                double needed_rect_width = rect_h * ratio_video;

                _MouseSelectionRect.left -= (float)(((needed_rect_width - rect_w) / 2) / w);
                _MouseSelectionRect.right += (float)(((needed_rect_width - rect_w) / 2) / w);

                _fZoomValue = (double)h / rect_h;
            }
            else
            {
                // calculate height
                double needed_rect_height = rect_w / ratio_video;

                _MouseSelectionRect.top -= (float)(((needed_rect_height - rect_h) / 2) / h);
                _MouseSelectionRect.bottom += (float)(((needed_rect_height - rect_h) / 2) / h);

                _fZoomValue = (double)w / rect_w;
            }



            Rectangle rect = new Rectangle(
                    (int)(_MouseSelectionRect.left * w),
                    (int)(_MouseSelectionRect.top * h),
                    (int)((_MouseSelectionRect.right - _MouseSelectionRect.left) * w),
                    (int)((_MouseSelectionRect.bottom - _MouseSelectionRect.top) * h)
                );


            cameraControl.ZoomToRect(rect);
            _bZoomed = true;
            _bDrawMouseSelection = false;

            UpdateCameraBitmap();

            // Place Zoom button in correct place on form
            UpdateUnzoomButton();

        }

        private void cameraControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!cameraControl.CameraCreated)
                return;

            if (_bZoomed)
                return;

            if (!_bDrawMouseSelection)
                return;

            PointF point = cameraControl.ConvertWinToNorm(new PointF(e.X, e.Y));
            _MouseSelectionRect.right = point.X;
            _MouseSelectionRect.bottom = point.Y;


            UpdateCameraBitmap();
        }

        private void but_photo_Click(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated)
                return;

            try
            {
                bitmapData = cameraControl.SnapshotSourceImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error while getting a snapshot");
            }

            if (bitmapData == null)
                return;

            pic_view.Image = bitmapData;
            pic_view.Update();

            //showdesign();
        }

        private void buttonPinOutputSettings_Click(object sender, EventArgs e)
        {
            if (cameraControl.CameraCreated)
            {
                cameraControl.DisplayPropertyPage_SourcePinOutput(this.Handle);
            }
        }

        private void buttonCameraSettings_Click(object sender, EventArgs e)
        {
            if (cameraControl.CameraCreated)
            {
                Camera.DisplayPropertyPage_Device(cameraControl.Moniker, this.Handle);
            }
        }

        private void buttonCrossbarSettings_Click(object sender, EventArgs e)
        {
            if (cameraControl.CameraCreated)
            {
                cameraControl.DisplayPropertyPage_Crossbar(this.Handle);
            }
        }

        private void buttonMixerOnOff_Click(object sender, EventArgs e)
        {
            cameraControl.MixerEnabled = !cameraControl.MixerEnabled;
        }


        private void but_connect_Click(object sender, EventArgs e)
        {
            if (but_connect.Text == "连接")
            {
                if (comboBoxCameraList.SelectedIndex < 0) return;
                if (comboBoxResolutionList.SelectedIndex < 0)
                {
                    SetCamera(_CameraChoice.Devices[comboBoxCameraList.SelectedIndex].Mon, null);
                }
                else
                {
                    SetCamera(_CameraChoice.Devices[comboBoxCameraList.SelectedIndex].Mon, resolutions[comboBoxResolutionList.SelectedIndex]);
                }
                but_connect.Text = "关闭";
            }
            else
            {
                cameraControl.CloseCamera();
                but_connect.Text = "连接";
            }
        }



        // Unzoom camera and update gui
        private void UnzoomCamera()
        {
            cameraControl.ZoomToRect(new Rectangle(0, 0, cameraControl.Resolution.Width, cameraControl.Resolution.Height));

            _bZoomed = false;
            _fZoomValue = 1.0;

            // gui updates
            UpdateCameraBitmap();
            UpdateUnzoomButton();

            _bDrawMouseSelection = false;
        }

        private void UpdateUnzoomButton()
        {
            if (_bZoomed)
            {
                buttonUnZoom.Left = cameraControl.Left + (cameraControl.ClientRectangle.Width - cameraControl.OutputVideoSize.Width) / 2 + 4;
                buttonUnZoom.Top = cameraControl.Top + (cameraControl.ClientRectangle.Height - cameraControl.OutputVideoSize.Height) / 2 + 40;
                buttonUnZoom.Visible = true;
            }
            else
            {
                buttonUnZoom.Visible = false;
            }
        }

        private void UpdateCameraBitmap()
        {
            if (!cameraControl.MixerEnabled)
                return;

            cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);

            #region D3D bitmap mixer
            //if (cameraControl.UseGDI)
            //{
            //    cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);
            //}
            //else
            //{
            //    cameraControl.OverlayBitmap = GenerateAlphaBitmap();
            //}
            #endregion
        }

        // NOTE: This function is an example of overlay bitmap usage
        // Create bitmap with selection rect, text or any other overlay
        private Bitmap GenerateColorKeyBitmap(bool useAntiAlias)
        {
            int w = cameraControl.OutputVideoSize.Width;
            int h = cameraControl.OutputVideoSize.Height;

            if (w <= 0 || h <= 0)
                return null;

            // Create RGB bitmap
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);

            // configure antialiased drawing or not
            if (useAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            else
            {
                g.SmoothingMode = SmoothingMode.None;
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            }

            // Clear the bitmap with the color key
            g.Clear(cameraControl.GDIColorKey);

            // Draw selection rect --------------------------
            if (_bDrawMouseSelection && IsMouseSelectionRectCorrect())
            {
                Color color_of_pen = Color.Gray;
                if (IsMouseSelectionRectCorrectAndGood())
                {
                    color_of_pen = Color.Green;
                }

                Pen pen = new Pen(color_of_pen, 2.0f);

                Rectangle rect = new Rectangle(
                        (int)(_MouseSelectionRect.left * w),
                        (int)(_MouseSelectionRect.top * h),
                        (int)((_MouseSelectionRect.right - _MouseSelectionRect.left) * w),
                        (int)((_MouseSelectionRect.bottom - _MouseSelectionRect.top) * h)
                    );



                g.DrawLine(pen, rect.Left - 5, rect.Top, rect.Right + 5, rect.Top);
                g.DrawLine(pen, rect.Left - 5, rect.Bottom, rect.Right + 5, rect.Bottom);
                g.DrawLine(pen, rect.Left, rect.Top - 5, rect.Left, rect.Bottom + 5);
                g.DrawLine(pen, rect.Right, rect.Top - 5, rect.Right, rect.Bottom + 5);

                pen.Dispose();

            }

            // Draw zoom text if needed
            if (_bZoomed)
            {
                Font font = new Font("Tahoma", 16);
                Brush textColorKeyed = new SolidBrush(Color.DarkBlue);

                g.DrawString("Zoom: " + Math.Round(_fZoomValue, 1).ToString("0.0") + "x", font, textColorKeyed, 4, 4);

                font.Dispose();
                textColorKeyed.Dispose();
            }

            // Draw text logo for example
            {
                Font font = new Font("Tahoma", 16);
                Brush textColorKeyed = new SolidBrush(Color.Yellow);

                g.DrawString("医疗科技www.cnasis.com", font, textColorKeyed, 4, h - 30);

            }

            // dispose Graphics
            g.Dispose();

            // return the bitmap
            return bmp;
        }


        private void FillResolutionList()
        {
            comboBoxResolutionList.Items.Clear();

            if (!cameraControl.CameraCreated)
                return;

            resolutions = Camera.GetResolutionList(cameraControl.Moniker);

            if (resolutions == null)
                return;


            int index_to_select = -1;

            for (int index = 0; index < resolutions.Count; index++)
            {
                comboBoxResolutionList.Items.Add(resolutions[index].ToString());

                if (resolutions[index].CompareTo(cameraControl.Resolution) == 0)
                {
                    index_to_select = index;
                }
            }

            // select current resolution
            if (index_to_select >= 0)
            {
                comboBoxResolutionList.SelectedIndex = index_to_select;
            }
        }

        private void FillCameraList()
        {
            comboBoxCameraList.Items.Clear();

            _CameraChoice.UpdateDeviceList();

            foreach (var camera_device in _CameraChoice.Devices)
            {
                comboBoxCameraList.Items.Add(camera_device.Name);
            }
        }


        private bool IsMouseSelectionRectCorrect()
        {
            if (Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < float.Epsilon * 10 ||
                Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < float.Epsilon * 10)
            {
                return false;
            }

            if (_MouseSelectionRect.left >= _MouseSelectionRect.right ||
                _MouseSelectionRect.top >= _MouseSelectionRect.bottom)
            {
                return false;
            }

            if (_MouseSelectionRect.left < 0 ||
                _MouseSelectionRect.top < 0 ||
                _MouseSelectionRect.right > 1.0 ||
                _MouseSelectionRect.bottom > 1.0)
            {
                return false;
            }
            return true;
        }

        private bool IsMouseSelectionRectCorrectAndGood()
        {
            if (!IsMouseSelectionRectCorrect())
            {
                return false;

            }

            // Zoom
            if (Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < 0.1f ||
                Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < 0.1f)
            {
                return false;
            }

            return true;
        }

        #region Camera creation and destroy

        // Set current camera to camera_device
        private void SetCamera(IMoniker camera_moniker, Resolution resolution)
        {
            try
            {
                // NOTE: You can debug with DirectShow logging:
                //cameraControl.DirectShowLogFilepath = @"C:\YOUR\LOG\PATH.txt";

                // Makes all magic with camera and DirectShow graph
                cameraControl.SetCamera(camera_moniker, resolution);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Error while running camera");
            }

            if (!cameraControl.CameraCreated)
                return;

            // If you are using Direct3D surface overlay
            // (see documentation about rebuild of library for it)
            //cameraControl.UseGDI = false;

            cameraControl.MixerEnabled = true;
            but_connect.Text = "关闭";

            cameraControl.OutputVideoSizeChanged += Camera_OutputVideoSizeChanged;

            UpdateCameraBitmap();


            // gui update
            UpdateGUIButtons();
        }

        // Update buttons of GUI based on Camera state
        private void UpdateGUIButtons()
        {
            buttonCrossbarSettings.Enabled = (cameraControl.CrossbarAvailable);
        }

        // Event handler for OutputVideoSizeChanged event
        private void Camera_OutputVideoSizeChanged(object sender, EventArgs e)
        {
            // Update camera's bitmap (new size needed)
            UpdateCameraBitmap();

            // Place Zoom button in correct place on form
            UpdateUnzoomButton();
        }


        #endregion

        private void CnasCameratoPic_Load(object sender, EventArgs e)
        {
           
        }

        public void AutoShow()
        {
            // Fill camera list combobox with available cameras
            FillCameraList();

            // Select the first one
            if (comboBoxCameraList.Items.Count > 0)
            {
                comboBoxCameraList.SelectedIndex = 0;
            }

            // Fill camera list combobox with available resolutions
            FillResolutionList();
        }

        private void buttonUnZoom_Click(object sender, EventArgs e)
        {
            UnzoomCamera();
        }

        private void cameraControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnzoomCamera();
        }

        private void CnasCameratoPic_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                cameraControl.CloseCamera();
            }
        }

       
    }
}
