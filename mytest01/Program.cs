using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSReport;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mytest01
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
			CnasRemotCall remoteClient = new CnasRemotCall();
			CnasBaseData.SystemID = "1";
			CnasBaseData.SystemBaseData = remoteClient.RemotInterface.SelectData("HCS-systemdata-sec001", null);
			Application.Run(new TestMessageInfocs());
        }
    }
}
