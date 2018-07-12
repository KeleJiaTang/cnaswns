using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AutoUpdate
{
    public class Config
    {
        private bool enabled = true;
        public bool Enabled { get { return enabled; } set { enabled = value; } }

        private string serverUrl = "";
        public string ServerUrl { get { return serverUrl; } set { serverUrl = value; } }


        private bool isUpdate = true;
        //判断用户是否中断过更新
        public bool IsUpdate { get { return isUpdate; } set { isUpdate = value; } }



        private UpdateFileList updateFileList = new UpdateFileList();
        public UpdateFileList UpdateFileList
        {
            get { return updateFileList; }
            set { updateFileList = value; }
        }



        public static Config LoadConfig(string file)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                StreamReader sr = new StreamReader(file);
                Config config = xs.Deserialize(sr) as Config;
                sr.Close();

                return config;
            }
            catch (Exception)
            {
            }
            return null;
        }



        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }









    }

    public class UpdateFileList : List<LocalFile>
    {
    }
}
