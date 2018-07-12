using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseUC;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using System.Diagnostics;

namespace CnasTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EventLog eventLog = new EventLog("Application");
            string aa=eventLog.Source;
            string eventSourceName = "Application";
            //if (!EventLog.SourceExists(eventSourceName))
            //{
            //    EventLog.CreateEventSource(eventSourceName, "Application");
            //}


            //EventLog.CreateEventSource(eventSourceName, "Application");
            eventLog.Source = eventSourceName;
            lock (eventLog)
            {

                eventLog.WriteEntry("21321313131", EventLogEntryType.Error, 2000);
               
            }




            //string eventSourceName = "Application";
            //if (!EventLog.SourceExists(eventSourceName))
            //{
            //    EventLog.CreateEventSource(eventSourceName, "Application");
            //}
            //EventLog.WriteEntry(eventSourceName, "21321313131", EventLogEntryType.Error);
            //CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //SortedList sl = new SortedList();
            //sl.Add(1, "rexxie");
            //string strtemp = reCnasRemotCall.RemotInterface.CheckSelectData("SHCS0010001", sl);
            //this.tb_01.Text = strtemp;

        }

        private void but_test03_Click(object sender, EventArgs e)
        {
            //CnasClientMethods cntm = new CnasClientMethods();
            int bl1 = CnasClientMethods.GetCondition(0, this.tb_04.Text);
            tb_03.Text = bl1.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "xie";
            string s2 = "xyz";
            int c0 = string.Compare("谢", "是", StringComparison.Ordinal);

             c0 = string.Compare(s1, s2, StringComparison.Ordinal);  // -1866

             tb_03.Text = c0.ToString();
            //int c1 = string.Compare(s1, s2, new CultureInfo(0x804), CompareOptions.None);  //  1
            //int c2 = string.Compare(s1, s2, new CultureInfo(0x20804), CompareOptions.None);  // -1

        }
        private int Compare(string in_01,string in_02)
        {
            return string.Compare(in_01, in_02, StringComparison.Ordinal);
        }

        private void barcode_design1_UserXmlUpdate(object sender, EventArgs e, string XMLdata)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cnas.wns.CnasCameraUC.ControlCameraTools ControlCameraTools01 = new Cnas.wns.CnasCameraUC.ControlCameraTools();
            if(ControlCameraTools01.ShowDialog()== DialogResult.OK)
            {
                this.pictureBox1.Image = ControlCameraTools01.BitmapData;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            string rec00=reCnasRemotCall.RemotInterface.Get_SerialNumber(0);
            string rec01 = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
            string rec02 = reCnasRemotCall.RemotInterface.Get_SerialNumber(2);

            tb_03.Text = tb_03.Text + "\r\n" + rec00 + "\r\n" + rec01 + "\r\n" + rec02 + "\r\n";


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string rec00 = Get_SerialNumber(0);
            string rec01 = Get_SerialNumber(1);
            string rec02 = Get_SerialNumber(2);

            tb_03.Text = tb_03.Text + "\r\n" + rec00 + "\r\n" + rec01 + "\r\n" + rec02 + "\r\n";
        }


        #region //生成入库编号 例如：20071118114255
        public static int int_count = 1;
        public string Get_SerialNumber(int intype)
        {
            if (intype == 1)
            {
                if (int_count < 9)
                {
                    int_count++;
                }
                else
                {
                    int_count = 1;
                }
                int intYear = DateTime.Now.Year;
                int intMonth = DateTime.Now.Month;
                int intDate = DateTime.Now.Day;
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

                strTime = strTime + int_count.ToString();
                return strTime;
            }
            else if (intype == 2)
            {
                return System.Guid.NewGuid().ToString();
            }
            else
            {
                return int_count.ToString();
            }

        }// end if 
        #endregion
    }
}
