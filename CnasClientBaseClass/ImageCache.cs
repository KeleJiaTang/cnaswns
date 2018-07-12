using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseClassClient
{
    /// <summary>
    /// 此类用于辅助图片显示，如果本地存在图片，则直接调用，没有则访问服务器获取缓存
    /// </summary>
    public class ImageCache
    {

        CnasClientMethods CnasClientMethods01 = new CnasClientMethods();

        //获取缓存图片的文件夹根目录
        string ImageCacheFolderName = ConfigurationManager.AppSettings["ImageCacheFolderName"].ToString();

        ILog _logger = null;

        public ImageCache()
        {
            _logger = LogManager.GetLogger("CnasWNSClient");

            //检测是否存在目录，不存在则先创建
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName)))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName));
            }
        }


        /// <summary>
        /// 根据文件夹名称 文件名称 返回对应图片
        /// </summary>
        /// <param name="FolderName">文件夹名称</param>
        /// <param name="FileName">文件名称</param>
        /// <returns></returns>
        public Image GetImageByFolderNameFileName(string FolderName, string FileName)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ImageCacheFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
                //如果本地不存在当前图片，则下载到本地
                if (!ExistsImageCache(FolderName, FileName))
                {
                    //上传图片到FTP
                    Stream downloadimageStream = CnasClientMethods01.Download(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, FileName, CnasBaseData.FTP_Path + FolderName);
                    //检测是否存在目录，不存在则先创建
                    if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName + "/" + FolderName)))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName + "/" + FolderName));
                    }

                    //直接保存图片到缓存文件夹
                    Image downloadimageImage = System.Drawing.Image.FromStream(downloadimageStream);
                    if (downloadimageImage == null)
                    downloadimageImage.Save(path);

                    //关闭文件流
                    downloadimageStream.Dispose();
                    downloadimageStream.Close();

                    return downloadimageImage;
                }

                FileStream imageStream = File.OpenRead(path);
                Image image = System.Drawing.Image.FromStream(imageStream);
                //关闭文件流
                imageStream.Dispose();
                imageStream.Close();
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据文件夹名称 文件名称 保存图片文件到相应的文件夹目录
        /// </summary>
        /// <param name="FolderName">文件夹名称</param>
        /// <param name="FileName">文件名称</param>
        /// <param name="imageStream">图片文件流</param>
        public bool SaveImageCache(string FolderName, string FileName, Stream imageStream)
        {
            if (imageStream == null) return false;
            try
            {
                //直接保存图片到缓存文件夹
                Image image = System.Drawing.Image.FromStream(imageStream);

                //上传图片到FTP
                string rec = CnasClientMethods01.Upload(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, FileName, CnasBaseData.FTP_Path + FolderName, imageStream);

                if (rec.Length > 0)
                    return false;

                //检测是否存在目录，不存在则先创建
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName + "/" + FolderName)))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImageCacheFolderName + "/" + FolderName));
                }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ImageCacheFolderName + "\\" + FolderName, FileName).Replace("/", "\\");

                image.Save(path);

                //关闭文件流
                imageStream.Dispose();
                imageStream.Close();
                return true;
            }
            catch
            {
                DeleteImageCache(FolderName, FileName);

                return false;
            }
        }


        /// <summary>
        /// 根据文件夹名称 文件名称 删除图片
        /// </summary>
        /// <param name="FolderName">文件夹名称</param>
        /// <param name="FileName">文件名称</param>
        public void DeleteImageCache(string FolderName, string FileName)
        {
            try
            {
                CnasClientMethods01.Delete(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, CnasBaseData.FTP_Path + FolderName, FileName);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ImageCacheFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
                if (ExistsImageCache(FolderName, FileName))
                    File.Delete(path);
            }
            catch
            {
            }

        }



        /// <summary>
        /// 检查缓存图片是否存在
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ExistsImageCache(string FolderName, string FileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ImageCacheFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
            return File.Exists(path);
        }



    }









}
