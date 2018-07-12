using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cnas.wns.CnasBaseClassClient
{
    public class HAMResourcesImageHelper
    {
        private static HAMResourcesImageHelper _instance = null;

		public static HAMResourcesImageHelper Instance
		{
			get
			{
				if (_instance == null)
					_instance = new HAMResourcesImageHelper();
				return _instance;
			}
		}

		public HAMResourcesImageHelper()
		{
			_skinIconName = ConfigurationManager.AppSettings["SkinIconName"].ToString();
		}

		private string _skinIconName = string.Empty; 

        /// <summary>
        /// 获取设置读取图标的 根文件夹（皮肤名称）
        /// </summary>
        public string SkinIconName
        {
            get
            {
                return _skinIconName;
            }
            set { _skinIconName = value; }
        }


        private Assembly _assemblyWinUI = null;
        /// <summary>
        /// 获取程序集
        /// </summary>
        public Assembly AssemblyWinUI
        {
            get
            {
                if (_assemblyWinUI == null)
                {
                    _assemblyWinUI = Assembly.Load("HAM");
                }

                return _assemblyWinUI;
            }
        }



        /// <summary>
        /// 根据图片名称，返回图片文件(调用此方法，默认传入后缀为 PNG 格式的图片)
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="imageName">图片名称</param>
        /// <returns></returns>
        public Image GetResourcesImage(string folderName, string imageName)
        {
            return GetResourcesImage(folderName, imageName, EnumImageType.PNG);
        }





        /// <summary>
        /// 根据图片名称，返回图片文件
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="imageName">图片名称</param>
        /// <param name="enumImageType">图片后缀</param>
        /// <returns></returns>
        public Image GetResourcesImage(string folderName, string imageName, EnumImageType enumImageType)
        {

            string imageType = Enum.GetName(typeof(EnumImageType), (int)enumImageType);

            Image bgImage = null;
            try
            {
                string imageFile = "HAM.Resources." + SkinIconName + "." + folderName + "." + imageName + "." + imageType.ToLower();
				bgImage = Image.FromStream(this.AssemblyWinUI.GetManifestResourceStream(imageFile));
            }
            catch
            {
                return bgImage = null;
            }

            return bgImage;
        }


        /// <summary>
        ///  根据图片名称，返回图片文件流
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="imageName"></param>
        /// <param name="enumImageType"></param>
        /// <returns></returns>
		public Stream GetResourcesStream(string folderName, string imageName, EnumImageType enumImageType)
		{
			string imageType = Enum.GetName(typeof(EnumImageType), (int)enumImageType);

			Stream stream = null;
			try
			{
                string imageFile = "HAM.Resources." + SkinIconName + "." + folderName + "." + imageName + "." + imageType.ToLower();
				stream = AssemblyWinUI.GetManifestResourceStream(imageFile);
			}
			catch
			{
				return stream = null;
			}

			return stream;
		}

        /// <summary>
        /// 根据图片名称，返回图片文件，可对文件进行处理后返回
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="imageName">图片名称</param>
        /// <param name="rectangle">new Rectangle(0, 0, 16, 16)  需要处理的尺寸</param>
        /// <param name="pixelFormat">PixelFormat.Format64bppPArgb 图像像素格式</param>
        /// <param name="enumImageType">图片后缀</param>
        /// <returns></returns>
        public Image GetResourcesImage(string folderName, string imageName, Rectangle rectangle, PixelFormat pixelFormat, EnumImageType enumImageType)
        {
            string imageType = Enum.GetName(typeof(EnumImageType), (int)enumImageType);

            Image bgImage = null;
            try
            {
                string imageFile = "HAM.Resources." + SkinIconName + "." + folderName + "." + imageName + "." + imageType.ToLower();
                Bitmap bitmapImage = new Bitmap(Bitmap.FromStream(AssemblyWinUI.GetManifestResourceStream(imageFile)));//帮助
                bgImage = bitmapImage.Clone(rectangle, pixelFormat);
            }
            catch
            {
                return bgImage = null;
            }

            return bgImage;
        }


    }







}
