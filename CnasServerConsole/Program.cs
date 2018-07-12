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

namespace Cnas.wns.CnasServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpServerChannel channel = new TcpServerChannel(8090);
                ChannelServices.RegisterChannel(channel);
                Type t = typeof(Cnas.wns.CnasBaseClassServer.CnasServerMethods);
                RemotingConfiguration.RegisterWellKnownServiceType(t, "CnasServerMethods", WellKnownObjectMode.SingleCall);
                
                Console.WriteLine("CnasServer is start");
                Console.ReadLine();

                //IntPtr intptr = FindWindow(null, "CnasServerConsole");
                //if (intptr != IntPtr.Zero)
                //{
                //    ShowWindow(intptr, 0);//隐藏这个窗口
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.ReadLine();
            }

        }


        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    }



}
