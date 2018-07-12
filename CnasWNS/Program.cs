using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Cnas.wns
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //判断进程池是否已经存在该进程
            //bool checkProcessIsTrue = false;
            //var processList = System.Diagnostics.Process.GetProcessesByName("CnasServerConsole");

            ////循环进程池
            //foreach (System.Diagnostics.Process process in processList)
            //{
            //    //存在则记录
            //    if (process.ProcessName == "CnasServerConsole")
            //    {
            //        checkProcessIsTrue = true;
            //        break;
            //    }
            //}

            ////如果存在则不再重新打开
            //if (!checkProcessIsTrue)
            //{
            //    //System.Environment.CurrentDirectory

            //    //自动启动依赖的数据注入程序
            //    string pathValue = System.IO.Directory.GetCurrentDirectory().Replace("CnasWNS", "CnasServerConsole");
            //    System.Diagnostics.Process.Start(pathValue + @"\CnasServerConsole.exe");
            //}



            //1.这里判定是否已经有实例在运行
            //只运行一个实例
            //Process instance = RunningInstance();
            //if (instance == null)
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new MyContext());
            //}
            //else
            //{
            //    //1.2 已经有一个实例在运行
            //    HandleRunningInstance(instance);
            //}
            //转换成英文版
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(ConfigurationManager.AppSettings["localization"].ToString());

            Application.Run(new MyContext());

        }


        //2.在进程中查找是否已经有实例在运行
        #region  确保程序只运行一个实例
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }


        //3.已经有了就把它激活，并将其窗口放置最前端
        private static void HandleRunningInstance(Process instance)
        {
            //MessageBox.Show("已经在运行！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowWindowAsync(instance.MainWindowHandle, 1);  //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion




    }
}
