/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace CRD.Common
{
    /// <summary>
    ///唯一更新网站: http://www.cckan.net
    /// </summary>
    public class WriteXML
    {
        public static void CreateXMLDocument(string XMLDocumentName, string NodeName, string NodeText)
        {
            XmlDocument xmldoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            XmlElement MiscList;

            XmlText xmltext;
            if (System.IO.File.Exists(Application.StartupPath + "\\" + XMLDocumentName + ".xml"))
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(Application.StartupPath + "\\" + XMLDocumentName + ".xml");
                MiscList = xmldoc.CreateElement(NodeName);
                MiscList = xmldoc.CreateElement("", NodeName, "");
                xmltext = xmldoc.CreateTextNode(NodeText);
                MiscList.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).AppendChild(MiscList);
            }
            else
            {
                xmldoc = new XmlDocument();
                //加入XML的声明段落
                xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                xmldoc.AppendChild(xmlnode);
                //加入一个根元素
                xmlelem = xmldoc.CreateElement("", "NodeList", "");
                //  xmltext = xmldoc.CreateTextNode("heyu5220");
                //  xmlelem.AppendChild(xmltext);
                xmldoc.AppendChild(xmlelem);
                //加入另外一个元素
                MiscList = xmldoc.CreateElement(NodeName);
                MiscList = xmldoc.CreateElement("", NodeName, "");
                xmltext = xmldoc.CreateTextNode(NodeText);
                MiscList.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).AppendChild(MiscList);
            }
            //保存创建好的XML文档
            try
            {
                xmldoc.Save(Application.StartupPath + "\\" + XMLDocumentName + ".xml");
            }
            catch (Exception e)
            {
                //显示错误信息
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        public static void DeleteXMLNode(string XMLDocumentName, string NodeName)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\" + XMLDocumentName + ".xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\" + XMLDocumentName + ".xml");
                XmlNodeReader reader = new XmlNodeReader(doc["NodeList"]);

                XmlNodeList xnl = doc["NodeList"].ChildNodes;
                foreach (XmlNode xn in xnl)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.InnerText == NodeName)
                    {
                        doc["NodeList"].RemoveChild(xn);
                        doc.Save(Application.StartupPath + "\\" + XMLDocumentName + ".xml");
                        break;
                    }
                }
            }
            else
            {
            }
        }

        public static void AddComputerNode(string XMLDocumentName, string ComputerName, string IP, string MAC)
        {
            XmlDocument xmldoc;
            XmlElement xmlelem;
            if (System.IO.File.Exists(Application.StartupPath + "\\" + XMLDocumentName + ".xml"))
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(Application.StartupPath + "\\" + XMLDocumentName + ".xml");

                XmlNode root = xmldoc.SelectSingleNode("ComputerNameList");
                XmlElement xe1 = xmldoc.CreateElement("Node");
                xe1.SetAttribute("ComputerName", ComputerName);

                XmlElement xesub1 = xmldoc.CreateElement("IP");
                xesub1.InnerText = IP;
                xe1.AppendChild(xesub1);
                XmlElement xesub2 = xmldoc.CreateElement("MAC");
                xesub2.InnerText = MAC;
                xe1.AppendChild(xesub2);
                root.AppendChild(xe1);

            }
            else
            {
                xmldoc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmldoc.AppendChild(xmldecl);

                //加入一个根元素
                xmlelem = xmldoc.CreateElement("", "ComputerNameList", "");
                xmldoc.AppendChild(xmlelem);

                XmlNode root = xmldoc.SelectSingleNode("ComputerNameList");
                XmlElement xe1 = xmldoc.CreateElement("Node");
                xe1.SetAttribute("ComputerName", ComputerName);

                XmlElement xesub1 = xmldoc.CreateElement("IP");
                xesub1.InnerText = IP;
                xe1.AppendChild(xesub1);
                XmlElement xesub2 = xmldoc.CreateElement("MAC");
                xesub2.InnerText = MAC;
                xe1.AppendChild(xesub2);
                root.AppendChild(xe1);
            }
            //保存创建好的XML文档
            try
            {
                xmldoc.Save(Application.StartupPath + "\\" + XMLDocumentName + ".xml");
            }
            catch (Exception e)
            {
                //显示错误信息

            }
        }

        public static void UpdateComputerNode(string XMLDocumentName, string ComputerName, string IP, string MAC)
        {
            if (!System.IO.File.Exists(Application.StartupPath + "\\" + XMLDocumentName + ".xml"))
            {
                AddComputerNode(XMLDocumentName, ComputerName, IP, MAC);
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLDocumentName + ".xml");

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("ComputerNameList").ChildNodes;
            bool isExist = false;
            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("ComputerName") == ComputerName)
                {
                    //  xe.SetAttribute("ComputerName", ComputerName);
                    isExist = true;
                    XmlNodeList nls = xe.ChildNodes;
                    foreach (XmlNode xn1 in nls)
                    {
                        XmlElement xe2 = (XmlElement)xn1;
                        if (xe2.Name == "IP")
                        {
                            xe2.InnerText = IP;
                        }
                        else if (xe2.Name == "MAC")
                        {
                            xe2.InnerText = MAC;
                        }

                    }
                    return;
                }
            }

            xmlDoc.Save(XMLDocumentName + ".xml");
            if (!isExist)
            {
                AddComputerNode(XMLDocumentName, ComputerName, IP, MAC);
            }
        }

        public static void DeleteComputerNode(string XMLDocumentName, string ComputerName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLDocumentName + ".xml");
            XmlNode root = xmlDoc.SelectSingleNode("ComputerNameList");
            XmlNodeList xnl = xmlDoc.SelectSingleNode("ComputerNameList").ChildNodes;
            for (int i = 0; i < xnl.Count; i++)
            {
                XmlElement xe = (XmlElement)xnl.Item(i);
                if (xe.GetAttribute("ComputerName") == ComputerName)
                {
                    root.RemoveChild(xe);
                    if (i < xnl.Count) i = i - 1;
                }
            }
            xmlDoc.Save(XMLDocumentName + ".xml");

        }

        public static DataTable ComputerListTable(string XMLDocumentName)
        {
            DataTable table = new DataTable();
            if (!System.IO.File.Exists(Application.StartupPath + "\\" + XMLDocumentName + ".xml"))
            {
                return table;
            }
            table.Columns.Add("主机名");
            table.Columns.Add("IP地址");
            table.Columns.Add("MAC地址");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLDocumentName + ".xml");

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("ComputerNameList").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (!string.IsNullOrEmpty(xe.Attributes[0].Value))
                    table.Rows.Add(xe.Attributes[0].Value, xe.ChildNodes[0].InnerText, xe.ChildNodes[1].InnerText);
            }
            return table;
        }
    }
}
