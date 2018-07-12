using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseUC
{
	public partial class PicturesShower : UserControl
	{
		public bool ImageAdoptLeftToRight { get; set; }
		public bool IsAdoptImageSize { get; set; }
		public PicturesShower()
		{
			InitializeComponent();
			leftBtn.Parent = mainPicture;
			rightBtn.Parent = mainPicture;
			bottomBtns.Parent = mainPicture;
			//bottomBtns.Parent = maskPanel;
			//maskPanel.Parent = mainPicture;
			this.BorderStyle = mainPicture.BorderStyle;
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		public void RefreshControl()
		{
			bottomBtns.ColumnStyles.Clear();
			bottomBtns.Controls.Clear();
			if (Images != null)
			{
				if (Images.Count > 1)
				{
					bottomBtns.Width = Images.Count * 16;
					bottomBtns.ColumnCount = Images.Count;

					for (int i = 0; i < Images.Count; i++)
					{
						RadioButton itemBtn = new RadioButton();
						itemBtn.Click += OnItemClick;
						itemBtn.Width = 16;
						itemBtn.Name = i.ToString();
						bottomBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 16F));
						itemBtn.Anchor = AnchorStyles.None;

						itemBtn.Margin = new System.Windows.Forms.Padding(0);
						bottomBtns.Controls.Add(itemBtn, i, 0);

					}
					leftBtn.Visible = true;
					rightBtn.Visible = true;
				}
				else
				{
					leftBtn.Visible = false;
					rightBtn.Visible = false;
				}

				if (Images.Count > 0)
				{
					SelectImage = Images.ElementAt(0);
					if (bottomBtns.Controls.Count > 0)
					{
						RadioButton selectItem = bottomBtns.Controls[0] as RadioButton;
						if (selectItem != null)
						{
							selectItem.Checked = true;
						}
					}
				}
				else
				{
					SelectImage = null;
				}
			}
		}

		private List<Image> _images = new List<Image>();
		private Image _selectImage = null;

		public Image SelectImage
		{
			get
			{
				return _selectImage;
			}
			set
			{
				if (value != _selectImage)
				{
					_selectImage = value;
					mainPicture.Image = _selectImage;
					//maskPanel.BackgroundImage = _selectImage;
					//DrawImage();
					if (IsAdoptImageSize)
						CalcualteSize();
				}
			}
		}

		public List<Image> Images
		{
			get
			{
				return _images;
			}
			set
			{
				if (value != _images)
				{
					_images = value;
					RefreshControl();
				}
			}
		}

		/// <summary>
		/// 获取下一张图片
		/// </summary>
		/// <param name="isLeft">是否王开始方向获取</param>
		/// <returns>下一张图片</returns>
		private Image GetNewPic(bool isLeft)
		{
			int index = Images.IndexOf(SelectImage);
			int newIndex = 0;
			if (isLeft)
			{
				newIndex = index == 0 ? Images.Count - 1 : index - 1;
			}
			else
			{
				newIndex = index == Images.Count - 1 ? 0 : index + 1;
			}

			if (bottomBtns.Controls.Count > newIndex)
			{
				RadioButton newItem = bottomBtns.Controls[newIndex] as RadioButton;
				if (newItem != null)
				{
					newItem.Checked = true;
				}
			}

			return Images.ElementAt(newIndex);
		}

		#region 点击按钮变更图片

		private void OnLeftBtnClick(object sender, EventArgs e)
		{
			SelectImage = GetNewPic(true);
		}

		private void OnRightBtnClick(object sender, EventArgs e)
		{
			SelectImage = GetNewPic(false);
		}

		private void OnItemClick(object sender, EventArgs e)
		{
			RadioButton btn = sender as RadioButton;
			if (btn != null)
			{
				int index = bottomBtns.Controls.IndexOf(btn);
				index = (index >= 0 && index < Images.Count) ? index : 0;
				SelectImage = Images.ElementAt(index);
			}
		}

		#endregion

		private void OnKeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Up || e.KeyData == Keys.Left || e.KeyData == Keys.Down || e.KeyData == Keys.Right)
			{
				bool isLeft = (e.KeyData == Keys.Up || e.KeyData == Keys.Left) ? true : false;
				SelectImage = GetNewPic(isLeft);
			}
		}

		#region 滑动鼠标变更图片

		private bool _isDrag = false;
		private Point _startPoint = new Point();
		private int _dragRange = 200;

		private void OnMouseDownEvent(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.Cursor = Cursors.Hand; //按下鼠标时，将鼠标形状改为手型
				_isDrag = true;
				_startPoint.X = e.X;
				_startPoint.Y = e.Y;
			}
		}

		private void OnMouseUpEvent(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if ((e.X - _startPoint.X > _dragRange || _startPoint.X - e.X > _dragRange) && _isDrag)
				{
					bool isLeft = _startPoint.X - e.X > _dragRange ? true : false;
					SelectImage = GetNewPic(isLeft);
				}
				this.Cursor = Cursors.Default;
				_isDrag = false;
			}
		}

		#endregion

		private void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{
			PictuerViewer viewer = new PictuerViewer();
			viewer.ImageView.Image = new Bitmap(SelectImage);
			viewer.Width = SelectImage.Width - 50;
			viewer.Height = SelectImage.Height * viewer.Width / SelectImage.Width;
			viewer.ShowDialog();
		}

		private void OnSizeChanged(object sender, EventArgs e)
		{
			int buttonY = (int)(Height - leftBtn.Height)/2;
			leftBtn.Location = new Point(0, buttonY);
			rightBtn.Location = new Point((Width - rightBtn.Width), buttonY);
			int panelX = (int)(Width - bottomBtns.Width) / 2;
			this.bottomBtns.Location = new Point(panelX, (Height - bottomBtns.Height));
		}

		public void CalcualteSize()
		{
			Rectangle rec = Screen.GetWorkingArea(this);
			if (ImageAdoptLeftToRight)
			{
				if (IsAdoptImageSize && SelectImage != null)
				{
					Height = SelectImage.Height * Width / SelectImage.Width;
				}
				else
				{
					Height = rec.Height * Width / rec.Width;
				}
			}
			else
			{
				if (IsAdoptImageSize && SelectImage != null)
				{
					Width = SelectImage.Width * Height / SelectImage.Height;
				}
				else
				{
					Width = rec.Width * Height / rec.Height;
				}
			}
		}
	}
}
