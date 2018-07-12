using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasBaseClassClient
{
    /// <summary>
    /// 自拟定模版报表上传辅助类
    /// </summary>
    public class TemFileUploadHelper
    {


        //获取存放模版文件夹根目录
        string TemFileFolderName = ConfigurationManager.AppSettings["TemFileFolderName"].ToString();
        string CustomTemplateReportFtpAddress = ConfigurationManager.AppSettings["CustomTemplateReportFtpAddress"].ToString();

        CnasClientMethods CnasClientMethods01 = new CnasClientMethods();



        public TemFileUploadHelper()
        {
            //检测是否存在目录，不存在则先创建
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemFileFolderName)))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemFileFolderName));
            }
        }




        /// <summary>
        /// 上传 自拟定模版文件
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="FileName"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public bool UploadTemFile(string FolderName, string FileName, Stream fileStream)
        {
            //文件流为null直接返回
            if (fileStream == null) return false;
            try
            {
                //上传图片到FTP
                string rec = CnasClientMethods01.Upload(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, FileName, CustomTemplateReportFtpAddress + FolderName, fileStream);

                if (rec.Length > 0)
                    return false;
            }
            catch
            {
                return false;
            }


            return true;
        }



        /// <summary>
        /// 下载自拟定模版文件
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool DownloadTemFile(string FolderName, string FileName)
        {
            //如果文件存在则先删除文件
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
            if (ExistsTemFile(FolderName, FileName))
                File.Delete(path);
            
            try
            {
                CnasClientMethods01.Download(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, CustomTemplateReportFtpAddress + FolderName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName), FileName);
            }
            catch
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// 根据文件夹名称，文件名返回文件路径
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public string GetTemFilePath(string FolderName, string FileName)
        {

            string path = "";
            //如果文件存在，则返回名称，否则返回空字符串

            if (ExistsTemFile(FolderName, FileName))
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
            else
                return path;
            return path;


        }


         /// <summary>
        /// 根据文件夹名称，文件名返回文件路径
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public string GetTemFilePath(string FolderName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName).Replace("/", "\\");
        }






        /// <summary>
        /// 检查模版文件是否存在
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ExistsTemFile(string FolderName, string FileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
            return File.Exists(path);
        }



        /// <summary>
        /// 根据文件夹名称 文件名称 删除文件
        /// </summary>
        /// <param name="FolderName">文件夹名称</param>
        /// <param name="FileName">文件名称</param>
        public void DeleteTemFile(string FolderName, string FileName)
        {
            try
            {
                CnasClientMethods01.Delete(CnasBaseData.FTP_User, CnasBaseData.FTP_PWD, CustomTemplateReportFtpAddress + FolderName, FileName);
                //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + TemFileFolderName + "\\" + FolderName, FileName).Replace("/", "\\");
                //if (ExistsTemFile(FolderName, FileName))
                //    File.Delete(path);
            }
            catch
            {
            }

        }
    }
}









