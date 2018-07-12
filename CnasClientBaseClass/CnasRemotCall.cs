using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using System.Configuration;

namespace Cnas.wns.CnasBaseClassClient
{
    public class CnasRemotCall
    {
        //string Tcp_connect = "tcp://127.0.0.1:8090/zb_outstore";
        public CnasHCSInterface RemotInterface = null;
        string Tcp_connect = ConfigurationManager.AppSettings["Tcp_connect"].ToString();
        public CnasRemotCall()
        {
            //ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            RemotInterface = (CnasHCSInterface)Activator.GetObject(typeof(CnasHCSInterface), Tcp_connect);
        }
        public CnasRemotCall(string strip)
        {
            Tcp_connect = strip;
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            RemotInterface = (CnasHCSInterface)Activator.GetObject(typeof(CnasHCSInterface), Tcp_connect);
        }
    }
}
