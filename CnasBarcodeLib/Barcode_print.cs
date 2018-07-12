using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Xml;
using Cnas.wns.CnasBarcodeLib.Symbologies;

namespace Cnas.wns.CnasBarcodeLib
{
    public partial class Barcode_print : Form
    {
        private string XMLData = "<?xml version='1.0' encoding='gb2312'?>";
        private Barcode b = new Barcode();
        XmlDocument xmldoc = new XmlDocument();
        private float dpiX = 96, dpiY = 96;

        private SortedList Sl_par = new SortedList();
        private SortedList Sl_Label = new SortedList();
        public DesignFormData DesignFormData01 = new DesignFormData();
        private BarcodeData BarcodeData01 = new BarcodeData();
        private BarcodeAddData BarcodeAddData01 = new BarcodeAddData();

        public Barcode_print(string inXML,SortedList SLpar)
        {
            Sl_par = SLpar;
            XMLData = inXML;            
            InitializeComponent();
            Analysis_XML(XMLData);            
        }

        private void Barcode_print_Load(object sender, EventArgs e)
        {
            //Analysis_XML(XMLData);

            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            if (dpiX != 96 || dpiY != 96)
            {
                MessageBox.Show("对不起！请将电脑系统显示的缩放比例设置成100%.");
                this.Close();
            }
            printbarcode();
            
        }


        private void Analysis_XML(string inXML)
        {
            xmldoc.LoadXml(inXML);
            XmlElement DesignFormDataXML = xmldoc["Data"]["DesignFormData"];
            XmlElement BarcodeDataXML = xmldoc["Data"]["BarcodeData"];
            //XmlElement BarcodeAddDataXML = xmldoc["Data"]["BarcodeAddData"];
            XmlNodeList  BarcodeAddDataXML = xmldoc.SelectNodes("/Data/BarcodeAddData/BarcodeAdd");
            string aaa0 = DesignFormDataXML.InnerXml;
            string aaa1 = BarcodeDataXML.InnerXml;
            //string aaa2 = BarcodeAddDataXML.InnerXml;


            #region 构造DesignFormData-BarcodeDataXML-BarCode

            //DesignFormDataXML
            DesignFormData01.BarCodeHeight = int.Parse(DesignFormDataXML["BarCodeHeight"].InnerText.Trim());
            DesignFormData01.BarCodeWidth = int.Parse(DesignFormDataXML["BarCodeWidth"].InnerText.Trim());
            DesignFormData01.Height = int.Parse(DesignFormDataXML["Height"].InnerText.Trim());
            DesignFormData01.Width = int.Parse(DesignFormDataXML["Width"].InnerText.Trim());
            DesignFormData01.PrintHeight = int.Parse(DesignFormDataXML["PrintHeight"].InnerText.Trim());
            DesignFormData01.PrintWidth = int.Parse(DesignFormDataXML["PrintWidth"].InnerText.Trim());
            DesignFormData01.DPI = int.Parse(DesignFormDataXML["DPI"].InnerText.Trim());
            //构造组件
            this.Height = (int)(DesignFormData01.PrintHeight / (float)25.4 * DesignFormData01.DPI);
            this.Width = (int)(DesignFormData01.PrintWidth / (float)25.4 * DesignFormData01.DPI);

            //this.Height = DesignFormData01.Height;
            //this.Width = DesignFormData01.Width;

            //BarcodeDataXML
            BarcodeData01.Height = int.Parse(BarcodeDataXML["Height"].InnerText.Trim());
            BarcodeData01.Width = int.Parse(BarcodeDataXML["Width"].InnerText.Trim());
            BarcodeData01.IsLabel = bool.Parse(BarcodeDataXML["IsLabel"].InnerText.Trim().ToLower());
            if (Sl_par ==null || Sl_par["BarcodeValue"] == null)
            {
                BarcodeData01.BarcodeValue = BarcodeDataXML["BarcodeValue"].InnerText.Trim();
            }else
            {
                BarcodeData01.BarcodeValue = Sl_par["BarcodeValue"].ToString();
            }
            BarcodeData01.X = int.Parse(BarcodeDataXML["X"].InnerText.Trim());
            BarcodeData01.Y = int.Parse(BarcodeDataXML["Y"].InnerText.Trim());

            string str_tmp = BarcodeDataXML["Alignment"].InnerText.Trim();
            foreach (AlignmentPositions type in Enum.GetValues(typeof(AlignmentPositions)))
            {
                if (str_tmp == type.ToString()) BarcodeData01.Alignment = type;
            }
            str_tmp = BarcodeDataXML["Background"].InnerText.Trim();
            BarcodeData01.Background = System.Drawing.Color.FromArgb(int.Parse(str_tmp));
            str_tmp = BarcodeDataXML["Foreground"].InnerText.Trim();
            BarcodeData01.Foreground = System.Drawing.Color.FromArgb(int.Parse(str_tmp));
            str_tmp = BarcodeDataXML["Encoding"].InnerText.Trim();
            foreach (TYPE type in Enum.GetValues(typeof(TYPE)))
            {
                if (str_tmp == type.ToString()) BarcodeData01.Encoding = type;
            }
            str_tmp = BarcodeDataXML["LabelLocation"].InnerText.Trim();
            foreach (LabelPositions type in Enum.GetValues(typeof(LabelPositions)))
            {
                if (str_tmp == type.ToString()) BarcodeData01.LabelLocation = type;
            }
            str_tmp = BarcodeDataXML["Rotate"].InnerText.Trim();
            foreach (RotateFlipType type in Enum.GetValues(typeof(RotateFlipType)))
            {
                if (str_tmp == type.ToString()) BarcodeData01.Rotate = type;
            }

            //构造组件
            reEncode();

            #endregion


            #region 构造BarcodeAddDataXML
            //BarcodeAddDataXML
            if (BarcodeAddDataXML != null && BarcodeAddDataXML.Count>0)
            {
                string str_Bold = "", str_DefaultValue = "", str_ForeSize = "", str_Name = "", str_X = "", str_Y = "";
                for(int i=0;i<BarcodeAddDataXML.Count;i++)
                {
                    str_Bold=BarcodeAddDataXML[i]["Bold"].InnerXml;
                    str_DefaultValue = BarcodeAddDataXML[i]["DefaultValue"].InnerXml;
                    str_ForeSize = BarcodeAddDataXML[i]["ForeSize"].InnerXml;
                    str_Name = BarcodeAddDataXML[i]["Name"].InnerXml;
                    str_X = BarcodeAddDataXML[i]["X"].InnerXml.Trim();
                    str_Y = BarcodeAddDataXML[i]["Y"].InnerXml.Trim();
                    Label lab_tmp = new Label();
                    lab_tmp.AutoSize = true;
                    lab_tmp.Location = new Point(int.Parse(str_X), int.Parse(str_Y));
                    if (str_Bold.ToLower() == "true")
                    {
                        lab_tmp.Font = new Font("宋体", int.Parse(str_ForeSize), FontStyle.Bold);
                    }
                    else
                    {
                        lab_tmp.Font = new Font("宋体", int.Parse(str_ForeSize), FontStyle.Regular);
                    } 
                    if(Sl_par !=null && Sl_par[str_Name] !=null)
                    {
                        lab_tmp.Text = Sl_par[str_Name].ToString();
                    }else
                    {
                        lab_tmp.Text = str_DefaultValue;
                    }
                    this.pan_print.Controls.Add(lab_tmp);
                    lab_tmp.BringToFront();
                }
                
            }

            #endregion          

        }
        private void reEncode()
        {
            try
            {
                if (BarcodeData01.Encoding != TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = BarcodeData01.IsLabel;
                    b.Alignment = BarcodeData01.Alignment;
                    b.RotateFlipType = BarcodeData01.Rotate;
                    b.LabelPosition = BarcodeData01.LabelLocation;
                    barcode.Image = b.Encode(BarcodeData01.Encoding, BarcodeData01.BarcodeValue, BarcodeData01.Foreground, BarcodeData01.Background, BarcodeData01.Width, BarcodeData01.Height);
                    
                }
                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;
                barcode.Location = new Point(BarcodeData01.X, BarcodeData01.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起！条形码模版已经被破坏，无法打印，错误描述："+ex.Message);
            }
        }

        private void printbarcode()
        {
            this.PrintDialog.Document = this.PrintDoc;
            PrintDoc.Print(); 
        }

        private void print01_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap _NewBitmap = new Bitmap(this.pan_print.Width, pan_print.Height);
            //pan_print.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            ////e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
            //e.Graphics.DrawImage(_NewBitmap, 0, 0, DesignFormData01.PrintWidth, DesignFormData01.PrintHeight);

            Bitmap _NewBitmap = new Bitmap(pan_print.Width, pan_print.Height);
            //_NewBitmap.SetResolution(203, 203);
            pan_print.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            System.Drawing.Printing.PrinterResolution prnres = new System.Drawing.Printing.PrinterResolution();
            int iiix = PrintDoc.PrinterSettings.DefaultPageSettings.PrinterResolution.X;
            int iiiy = PrintDoc.PrinterSettings.DefaultPageSettings.PrinterResolution.Y;
            if (iiix < this.DesignFormData01.DPI)
            {
                MessageBox.Show("对不起！当前默认打印机分辨率和配置分辨率不符，可能会导致打印失真。");
            }
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.DrawImage(_NewBitmap, 0, 0, dpiX * DesignFormData01.PrintWidth / (float)25.4, dpiY * DesignFormData01.PrintHeight / (float)25.4);
        }

        private void print01_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.Close();
        }

        private void pan_print_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
