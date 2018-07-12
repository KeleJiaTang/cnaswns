using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Cnas.wns.CnasBaseInterface;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace CnasRemotingServer
{
    public partial class CnasRemotingService : ServiceBase
    {
        public CnasRemotingService()
        {
            InitializeComponent();
        }


        TcpServerChannel channel = new TcpServerChannel(8090);
        protected override void OnStart(string[] args)
        {
            try
            {

                ChannelServices.RegisterChannel(channel);
                Type t = typeof(Cnas.wns.CnasBaseClassServer.CnasServerMethods);
                RemotingConfiguration.RegisterWellKnownServiceType(t, "CnasServerMethods", WellKnownObjectMode.SingleCall);

                WriteLog(DateTime.Now.ToString() + "    服务启动", EventLogEntryType.Information);



                //Console.WriteLine("CnasServer is start");
                //Console.ReadLine();

                //IntPtr intptr = FindWindow(null, "CnasServerConsole");
                //if (intptr != IntPtr.Zero)
                //{
                //    ShowWindow(intptr, 0);//隐藏这个窗口
                //}

            }
            catch (Exception ex)
            {
                WriteLog(DateTime.Now.ToString() + "    " + ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                ChannelServices.UnregisterChannel(channel);
                WriteLog(DateTime.Now.ToString() + "    服务关闭", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                WriteLog("关闭时发生了：" + ex.Message + ",时间：" + DateTime.Now.ToString(), EventLogEntryType.Error);
            }

        }


        /// <summary>
        /// 将日志写入txt中
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="counter"></param>
        public void WriteLog(string log,EventLogEntryType ele)
        {

            EventLog eventLog = new EventLog("Application");
            string eventSourceName = "Application";
            //if (!EventLog.SourceExists(eventSourceName))
            //{
            //    EventLog.CreateEventSource(eventSourceName, "Application");
            //}
            eventLog.Source = eventSourceName;
            lock (eventLog)
            {

                eventLog.WriteEntry(log, ele, 2000);

            }
            //string fileName = DateTime.Now.ToString("yyyyMMdd") + "Log.txt";
            //string filePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log\\" + fileName;
            //FileStream fs = new FileStream(filePath, FileMode.Append);
            //log = log + "\r\n";
            ////获得字节数组
            //byte[] data = System.Text.Encoding.Default.GetBytes(log);
            ////开始写入
            //fs.Write(data, 0, data.Length);
            ////清空缓冲区、关闭流
            //fs.Flush();
            //fs.Close();
        }








    }
}
