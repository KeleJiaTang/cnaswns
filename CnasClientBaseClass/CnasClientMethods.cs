using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;

using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseClassClient
{
    public class CnasClientMethods
    {

        private const string DEFAULT_ENCRYPT_KEY = "www.cnasis.com";

        /// <summary>
        /// 执行流程条件语句
        /// </summary>
        /// <param name="in_type">类型</param>
        /// <param name="in_con">输入条件语句</param>
        /// <returns>返回值:0-通过；1-不通过；3-失败语法错误</returns>
        public static int GetCondition(int in_type, string in_con)
        {
            try
            {
                in_con = in_con.Replace("=", "==");
                in_con = in_con.Replace("!==", "!=");
                in_con = in_con.Replace(">==", ">=");
                in_con = in_con.Replace("<==", "<=");
                in_con = in_con.Replace("and", "&&");
                in_con = in_con.Replace("or", "||");

                ICodeCompiler compiler = (new CSharpCodeProvider().CreateCompiler());
                CompilerParameters cp = new CompilerParameters();
                cp.ReferencedAssemblies.Add("system.dll");

                cp.GenerateExecutable = false;
                cp.GenerateInMemory = true;
                StringBuilder str = new StringBuilder();
                str.Append("using System; \n");
                str.Append("namespace Cnas.wns.CnasBaseClassClient{ \n");
                str.Append("public class GetData { \n");

                str.AppendFormat("    public bool TestCondition()");
                str.Append("{ if(" + in_con + "){ return true;}else{ return false;}\n");
                str.Append("}\n");
                //字符串比较函数
                str.Append("private int CompareStr(string in_01,string in_02){\n");
                str.Append("return string.Compare(in_01, in_02, StringComparison.Ordinal);\n");
                str.Append("}\n");

                str.Append("}\n");
                str.Append("}");


                CompilerResults cr = compiler.CompileAssemblyFromSource(cp, str.ToString());

                Assembly a = cr.CompiledAssembly;
                object compiled = a.CreateInstance("Cnas.wns.CnasBaseClassClient.GetData");
                MethodInfo m = compiled.GetType().GetMethod("TestCondition");
                if ((bool)m.Invoke(compiled, null))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ee)
            {
                return 3;
            }
        }



        /// <summary>
        /// 根据Url返回流
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static Stream GetImage(string strUrl)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");//网页编码==Encoding.UTF8             
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(strUrl));
            req.Method = "GET";
            req.UserAgent = " Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
            req.Accept = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5";
            req.Headers.Add("X-HttpWatch-RID", " 46990-10314");
            req.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.8,en-US;q=0.5,en;q=0.3");
            HttpWebResponse ress = (HttpWebResponse)req.GetResponse();
            return ress.GetResponseStream();
            //pictureBox1.Image = System.Drawing.Image.FromStream(sstreamRes);  
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strPwd">输入字符串</param>
        /// <returns>返回加密字符</returns>
        public static string GetMD5Hash(String strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(strPwd);//将字符编码为一个字节序列 
            byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值 
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        #region //生成入库编号 例如：20071118114255
        public static string Cre_RKnumber()
        {
            int intYear = DateTime.Now.Day;
            int intMonth = DateTime.Now.Month;
            int intDate = DateTime.Now.Year;
            int intHour = DateTime.Now.Hour;
            int intSecond = DateTime.Now.Second;
            int intMinute = DateTime.Now.Minute;
            string strTime = null;
            strTime = intYear.ToString();
            if (intMonth < 10)
            {
                strTime += "0" + intMonth.ToString();
            }
            else
            {
                strTime += intMonth.ToString();
            }
            if (intDate < 10)
            {
                strTime += "0" + intDate.ToString();
            }
            else
            {
                strTime += intDate.ToString();
            }
            if (intHour < 10)
            {
                strTime += "0" + intHour.ToString();
            }
            else
            {
                strTime += intHour.ToString();
            }
            if (intMinute < 10)
            {

                strTime += "0" + intMinute.ToString();
            }
            else
            {
                strTime += intMinute.ToString();
            }
            if (intSecond < 10)
            {

                strTime += "0" + intSecond.ToString();
            }
            else
            {
                strTime += intSecond.ToString();
            }


            return strTime;



        }// end if 
        #endregion

        #region FTP操作

        /// <summary>  
        /// 取得文件名  
        /// </summary>  
        /// <param name="ftpPath">ftp路径</param>  
        /// <returns></returns>  
        public string[] GetFilePath(string userId, string pwd, string ftpPath)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userId, pwd);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UsePassive = true;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

        /// <summary>
        /// ftp的上传功能(上传图片到对应FTP服务器)
        /// </summary>
        /// <param name="userId">FTP：对应的连接FTP的userId</param>
        /// <param name="pwd">FTP：对应的连接FTP的pwd</param>
        /// <param name="filename">文件名称</param>
        /// <param name="ftpPath">文件路径</param>
        public void Upload(string userId, string pwd, string filename, string ftpPath)
        {
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;
            // 根据uri创建FtpWebRequest对象   
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileInf.Name));
            // ftp用户名和密码  
            reqFTP.Credentials = new NetworkCredential(userId, pwd);

            reqFTP.UsePassive = true;
            // 默认为true，连接不会被关闭  
            // 在一个命令之后被执行  
            reqFTP.KeepAlive = false;
            // 指定执行什么命令  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // 指定数据传输类型  
            reqFTP.UseBinary = true;
            // 上传文件时通知服务器文件的大小  
            reqFTP.ContentLength = fileInf.Length;
            // 缓冲大小设置为2kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流 (System.IO.FileStream) 去读上传的文件  
            FileStream fs = fileInf.OpenRead();
            try
            {
                // 把上传的文件写入流  
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的2kb  
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束  
                while (contentLen != 0)
                {
                    // 把内容从file stream 写入 upload stream  
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // 关闭两个流  
                strm.Close();
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// ftp的上传功能(上传图片到对应FTP服务器)
        /// </summary>
        /// <param name="userId">FTP：对应的连接FTP的userId</param>
        /// <param name="pwd">FTP：对应的连接FTP的pwd</param>
        /// <param name="filename">文件名称</param>
        /// <param name="ftpPath">文件路径</param>
        /// <param name="instream">需要上传的文件的文件流</param>
        /// <returns>出现错误返回错误信息，否则返回空</returns>
        public string Upload(string userId, string pwd, string filename, string ftpPath, Stream instream)
        {
            //FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;
            // 根据uri创建FtpWebRequest对象   
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(@ftpPath + filename));
            // ftp用户名和密码  
            reqFTP.Credentials = new NetworkCredential(userId, pwd);

            reqFTP.UsePassive = true;
            // 默认为true，连接不会被关闭  
            // 在一个命令之后被执行  
            reqFTP.KeepAlive = false;


            // 指定执行什么命令  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // 指定数据传输类型  
            reqFTP.UseBinary = true;
            // 上传文件时通知服务器文件的大小  
            //reqFTP.ContentLength = fileInf.Length;
            reqFTP.ContentLength = instream.Length;
            // 缓冲大小设置为2kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流 (System.IO.FileStream) 去读上传的文件  
            //FileStream fs = fileInf.OpenRead();

            System.Net.ServicePointManager.DefaultConnectionLimit = 50;

            try
            {
                // 把上传的文件写入流  
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的2kb  
                //contentLen = fs.Read(buff, 0, buffLength);
                instream.Position = 0;
                contentLen = instream.Read(buff, 0, buffLength);
                // 流内容没有结束  
                while (contentLen != 0)
                {
                    // 把内容从file stream 写入 upload stream  
                    strm.Write(buff, 0, contentLen);
                    contentLen = instream.Read(buff, 0, buffLength);
                }

                // 关闭两个流  
                strm.Close();
                //instream.Close();

                reqFTP = null;

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// 从ftp服务器上下载文件的功能
        /// </summary>
        /// <param name="userId">FTP：对应的连接FTP的userId</param>
        /// <param name="pwd">FTP：对应的连接FTP的pwd</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="ftpPath">文件路径</param>
        /// <returns>返回一个图片的数据流</returns>
        public MemoryStream Download(string userId, string pwd, string fileName, string ftpPath)
        {
            FtpWebRequest reqFTP;
            try
            {
                MemoryStream memStream = new MemoryStream();
                //FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userId, pwd);
                reqFTP.UsePassive = true;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    //outputStream.Write(buffer, 0, readCount);
                    memStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                //outputStream.Close();
                response.Close();
                return memStream;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }
        }





        /// <summary>
        /// 从ftp服务器上下载文件的功能 
        /// </summary>
        /// <param name="userId">FTP：对应的连接FTP的userId</param>
        /// <param name="pwd">FTP：对应的连接FTP的pwd</param>
        /// <param name="ftpPath">FTP路径</param>
        /// <param name="filePath">本地文件路径</param>
        /// <param name="fileName">文件名称</param>
        public void Download(string userId, string pwd, string ftpPath, string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {


                //检测是否存在目录，不存在则先创建
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userId, pwd);
                reqFTP.UsePassive = true;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        /// <summary>
        /// 从ftp服务器上删除文件
        /// </summary>
        /// <param name="userId">FTP：对应的连接FTP的userId</param>
        /// <param name="pwd">FTP：对应的连接FTP的pwd</param>
        /// <param name="ftpPath">文件名称</param>
        /// <param name="fileName">文件路径</param>
        /// <returns>出现错误返回错误信息，否则返回空</returns>
        public string Delete(string userId, string pwd, string ftpPath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userId, pwd);
                reqFTP.UsePassive = true;
                FtpWebResponse listResponse = (FtpWebResponse)reqFTP.GetResponse();
                string sStatus = listResponse.StatusDescription;
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }






        #endregion

        #region DES对称加密解密

        /// <summary>
        /// 使用默认加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string DesEncrypt(string strText)
        {
            try
            {
                return DesEncrypt(strText, DEFAULT_ENCRYPT_KEY);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 使用默认解密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string DesDecrypt(string strText)
        {
            try
            {
                return DesDecrypt(strText, DEFAULT_ENCRYPT_KEY);
            }
            catch
            {
                return "";
            }
        }

        /// <summary> 
        /// Encrypt the string 
        /// Attention:key must be 8 bits 
        /// </summary> 
        /// <param name="strText">string</param> 
        /// <param name="strEncrKey">key</param> 
        /// <returns></returns> 
        public static string DesEncrypt(string strText, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary> 
        /// Decrypt string 
        /// Attention:key must be 8 bits 
        /// </summary> 
        /// <param name="strText">Decrypt string</param> 
        /// <param name="sDecrKey">key</param> 
        /// <returns>output string</returns> 
        public static string DesDecrypt(string strText, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[strText.Length];

            byKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }

        /// <summary> 
        /// Encrypt files 
        /// Attention:key must be 8 bits 
        /// </summary> 
        /// <param name="m_InFilePath">Encrypt file path</param> 
        /// <param name="m_OutFilePath">output file</param> 
        /// <param name="strEncrKey">key</param> 
        public static void DesEncrypt(string m_InFilePath, string m_OutFilePath, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write. 
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption. 
            long rdlen = 0; //This is the total number of bytes written. 
            long totlen = fin.Length; //This is the total length of the input file. 
            int len; //This is the number of bytes to be written at a time. 

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);

            //Read from the input file, then encrypt and write to the output file. 
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }

        /// <summary> 
        /// Decrypt files 
        /// Attention:key must be 8 bits 
        /// </summary> 
        /// <param name="m_InFilePath">Decrypt filepath</param> 
        /// <param name="m_OutFilePath">output filepath</param> 
        /// <param name="sDecrKey">key</param> 
        public static void DesDecrypt(string m_InFilePath, string m_OutFilePath, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write. 
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption. 
            long rdlen = 0; //This is the total number of bytes written. 
            long totlen = fin.Length; //This is the total length of the input file. 
            int len; //This is the number of bytes to be written at a time. 

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

            //Read from the input file, then encrypt and write to the output file. 
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
        #endregion







    }
}
