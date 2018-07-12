using AutoUpdate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace UpdateApplication
{
    static class Program
    {


        const string FILENAME = "update.config";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException exp)
            {
                MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OperProcess oper = new OperProcess();
                Config config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
                //如果用户点击过更新但是没有更新完，则强制用户继续更新
                if (config.IsUpdate)
                {
                    Application.Exit();
                }
                else {
                    oper.StartProcess();
                }
                
            }
        }
    }
}
