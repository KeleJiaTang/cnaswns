using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml;


//using System.Reflection;
//using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasBarcodeLib
{
    public partial class Barcode_design : UserControl
    {
        private SortedList Sl_par = new SortedList();
        private SortedList Sl_Label = new SortedList();
        private DesignFormData DesignFormData01 = new DesignFormData();
        private BarcodeData BarcodeData01 = new BarcodeData();
        private BarcodeAddData BarcodeAddData01 = new BarcodeAddData();
        private float dpiX=96, dpiY=96;

        public delegate void XmlUpdate(object sender, EventArgs e, string XMLdata);
        [Browsable(true), Description("选择生成XML事件。"), Category("操作")]
        public event XmlUpdate UserXmlUpdate;

        //Bitmap myBmp;
        Point mouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)


        private string XMLData = "";        
        private XmlDocument xmldoc = new XmlDocument();

        private Barcode b = new Barcode();
        public Barcode_design(string inXML)
        {
            InitializeComponent();
            XMLData = inXML;
            rtb_xml.Text = XMLData;
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
                    barcode.Image = b.Encode(BarcodeData01.Encoding, BarcodeData01.BarcodeValue , BarcodeData01.Foreground, BarcodeData01.Background, BarcodeData01.Width, BarcodeData01.Height);
                }

                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;
                barcode.Location = new Point((this.pan_design.Location.X + this.pan_design.Width / 2) - barcode.Width / 2, (this.pan_design.Location.Y + this.pan_design.Height / 2) - barcode.Height / 2);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch
        }

        private void Barcode_design_Load(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            if (dpiX != 96 || dpiY != 96)
            {
                MessageBox.Show("对不起！请讲电脑系统显示的缩放比例设置成100%.");
                this.Hide();
            }
            if (XMLData.Length > 0)
            { 
                Analysis_XML(XMLData);
                this.pg_design.SelectedObject = DesignFormData01;
                this.pg_design.Refresh();
                this.pg_barcode.SelectedObject = BarcodeData01;
                this.pg_barcode.Refresh();
            }
            else
            {                
                this.pan_design.Height = (int)(DesignFormData01.PrintHeight / (float)25.4 * DesignFormData01.DPI);
                this.pan_design.Width = (int)(DesignFormData01.PrintWidth / (float)25.4 * DesignFormData01.DPI);

                //this.pan_design.Height = (int)(dpiY * DesignFormData01.PrintHeight / (float)25.4 * DesignFormData01.DPI / dpiY);
                //this.pan_design.Width = (int)(dpiX * DesignFormData01.PrintWidth / (float)25.4 * DesignFormData01.DPI / dpiX);
                reEncode();
            }
        }


        private void Analysis_XML(string inXML)
        {
            xmldoc.LoadXml(inXML);
            XmlElement DesignFormDataXML = xmldoc["Data"]["DesignFormData"];
            XmlElement BarcodeDataXML = xmldoc["Data"]["BarcodeData"];
            //XmlElement BarcodeAddDataXML = xmldoc["Data"]["BarcodeAddData"];
            XmlNodeList BarcodeAddDataXML = xmldoc.SelectNodes("/Data/BarcodeAddData/BarcodeAdd");
            string aaa0 = DesignFormDataXML.InnerXml;
            string aaa1 = BarcodeDataXML.InnerXml;


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
            this.pan_design.Height = (int)(DesignFormData01.PrintHeight / (float)25.4 * DesignFormData01.DPI);
            this.pan_design.Width = (int)(DesignFormData01.PrintWidth / (float)25.4 * DesignFormData01.DPI);

            //this.Height = DesignFormData01.Height;
            //this.Width = DesignFormData01.Width;

            //BarcodeDataXML
            BarcodeData01.Height = int.Parse(BarcodeDataXML["Height"].InnerText.Trim());
            BarcodeData01.Width = int.Parse(BarcodeDataXML["Width"].InnerText.Trim());
            BarcodeData01.IsLabel = bool.Parse(BarcodeDataXML["IsLabel"].InnerText.Trim().ToLower());
            BarcodeData01.BarcodeValue = BarcodeDataXML["BarcodeValue"].InnerText.Trim();
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
            if (BarcodeAddDataXML != null && BarcodeAddDataXML.Count > 0)
            {
                string str_Bold = "", str_DefaultValue = "", str_ForeSize = "", str_Name = "", str_X = "", str_Y = "";
                for (int i = 0; i < BarcodeAddDataXML.Count; i++)
                {
                    BarcodeAddData BarcodeAddData_tmp = new BarcodeAddData();
                    
                    str_Bold = BarcodeAddDataXML[i]["Bold"].InnerXml;
                    str_DefaultValue = BarcodeAddDataXML[i]["DefaultValue"].InnerXml;                    
                    str_ForeSize = BarcodeAddDataXML[i]["ForeSize"].InnerXml;                    
                    str_Name = BarcodeAddDataXML[i]["Name"].InnerXml;                    
                    str_X = BarcodeAddDataXML[i]["X"].InnerXml.Trim();
                    str_Y = BarcodeAddDataXML[i]["Y"].InnerXml.Trim();

                    BarcodeAddData_tmp.Name = str_Name;
                    BarcodeAddData_tmp.DefaultValue = str_DefaultValue;
                    BarcodeAddData_tmp.ForeSize = int.Parse(str_ForeSize);
                    BarcodeAddData_tmp.X = int.Parse(str_X);
                    BarcodeAddData_tmp.Y = int.Parse(str_Y);

                    Label lab_tmp = new Label();
                    lab_tmp.AutoSize = true;
                    lab_tmp.Location = new Point(int.Parse(str_X), int.Parse(str_Y));
                    if (str_Bold.ToLower() == "true")
                    {
                        BarcodeAddData_tmp.Bold = true;
                        lab_tmp.Font = new Font("宋体", int.Parse(str_ForeSize), FontStyle.Bold);
                    }
                    else
                    {
                        BarcodeAddData_tmp.Bold = false;
                        lab_tmp.Font = new Font("宋体", int.Parse(str_ForeSize), FontStyle.Regular);
                    }                   
                    lab_tmp.Text = str_Name;
                    lab_tmp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseDown);
                    lab_tmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseMove);
                    lab_tmp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseUp);

                    Sl_Label.Add(str_Name, lab_tmp);
                    this.Sl_par.Add(str_Name, BarcodeAddData_tmp);
                    this.pan_design.Controls.Add(lab_tmp);
                    lab_tmp.BringToFront();
                }
            }

            #endregion

        }

        private void barcode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                barcode.Focus();
                
                this.pg_design.Tag = "BarcodeData";
                pg_design.SelectedObject = this.BarcodeData01;
                pg_design.Refresh();
            }
        }

        private void barcode_MouseMove(object sender, MouseEventArgs e)
        {
            barcode.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = barcode.Location.X + moveX;
                y = barcode.Location.Y + moveY;
                barcode.Location = new Point(x, y);                
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void barcode_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (barcode.Location.X < -40 || barcode.Location.X > this.pan_design.Width || barcode.Location.Y < -10 || barcode.Location.Y > pan_design.Height)
                {
                    barcode.Location = new Point(BarcodeData01.X, BarcodeData01.Y);
                }
                else
                {
                    BarcodeData01.X = barcode.Location.X;
                    BarcodeData01.Y = barcode.Location.Y;
                }
                this.pg_design.Refresh();
                this.pg_design.Refresh();
                isMove = false;
            }
        }


        private void pg_design_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string strtag = Convert.ToString(this.pg_design.Tag);
            if (strtag == "BarcodeAddData")
            {
                BarcodeAddData BarcodeAddDatatmp = (BarcodeAddData)pg_design.SelectedObject;
                
                //更新参数名字+关键字
                string old_key = Sl_par.GetKey(Sl_par.IndexOfValue(BarcodeAddDatatmp)).ToString();
                string new_key = BarcodeAddDatatmp.Name;
                Label lab_tmp = (Label)this.Sl_Label[old_key];
                if (old_key != new_key)
                {
                    Sl_par.Remove(old_key);
                    Sl_par.Add(new_key, BarcodeAddDatatmp);
                    Sl_Label.Remove(old_key);
                    Sl_Label.Add(new_key, lab_tmp);
                    lab_tmp.Text = new_key;
                } 
                
                lab_tmp.Location = new Point(BarcodeAddDatatmp.X, BarcodeAddDatatmp.Y);
                if (BarcodeAddDatatmp.Bold == true)
                {
                    lab_tmp.Font = new Font("宋体", BarcodeAddDatatmp.ForeSize, FontStyle.Bold);
                }
                else
                {
                    lab_tmp.Font = new Font("宋体", BarcodeAddDatatmp.ForeSize, FontStyle.Regular);
                }
            }
            else if (strtag == "BarcodeData")
            {
                reEncode();

            }
            else if (strtag == "DesignFormData")
            {
                this.pan_design.Height = (int)(dpiY * DesignFormData01.PrintHeight / (float)25.4 * DesignFormData01.DPI / dpiY);
                this.pan_design.Width = (int)(dpiX * DesignFormData01.PrintWidth / (float)25.4 * DesignFormData01.DPI / dpiX);

                //barcode.Height = DesignFormData01.BarCodeHeight;
                DesignFormData01.BarCodeWidth = DesignFormData01.BarCodeHeight * 2;
                //barcode.Width = DesignFormData01.BarCodeWidth;
                BarcodeData01.Height = DesignFormData01.BarCodeHeight;
                BarcodeData01.Width = DesignFormData01.BarCodeWidth;
                reEncode();
            }
            
        }

        private void pg_barcode_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //BarcodeData01.Alignment = "";
            reEncode();
        }

        private void tsm_add_Click(object sender, EventArgs e)
        {
            int labcount = 0,intlab=0;
            while (intlab == 0)
            {
                labcount++;
                if (Sl_Label["parameter" + labcount.ToString()] == null)
                {
                    intlab = 1;
                    //MessageBox.Show("对不起！自动增加遇到参数重名，请先修改成自定义参数名。");
                    //return;
                }
            }
            //this.dgv_01.RowCount++;
            string strname = "parameter" + labcount.ToString();
            //dgv_01.Rows[dgv_01.RowCount - 1].Cells["info_name"].Value = strname;
            //dgv_01.Rows[dgv_01.RowCount - 1].Cells["id"].Value = strname;
            Label lab_tmp = new Label();            
            lab_tmp.Text = strname;
            lab_tmp.AutoSize = true;
            lab_tmp.BackColor = Color.Transparent;
            lab_tmp.Location = new Point(20, 20);
            lab_tmp.Font = new Font("宋体", 15, FontStyle.Bold);
            lab_tmp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseDown);
            lab_tmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseMove);
            lab_tmp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_all_MouseUp);
            Sl_Label.Add(strname, lab_tmp);
            BarcodeAddData BarcodeAddData_tmp = new BarcodeAddData();
            BarcodeAddData_tmp.Name = strname;
            this.Sl_par.Add(strname, BarcodeAddData_tmp);
            this.pan_design.Controls.Add(lab_tmp);
            lab_tmp.BringToFront();
        }

        private void tsm_del_Click(object sender, EventArgs e)
        {
            if (pg_design.Tag !=null && this.pg_design.Tag == "BarcodeAddData")
            {
                BarcodeAddData BarcodeAddDatatmp = (BarcodeAddData)this.pg_design.SelectedObject;
                string str_info_name = BarcodeAddDatatmp.Name;
                Label lab_tmp = (Label)this.Sl_Label[str_info_name];
                this.pan_design.Controls.Remove(lab_tmp);
                Sl_Label.Remove(str_info_name);
                Sl_par.Remove(str_info_name);
            }
            else
            {
                MessageBox.Show("对不起！请先选定要删除的参数。");
            }

        }

        private void tsm_create_Click(object sender, EventArgs e)
        {
            string str_BarcodeData = BarcodeData01.GetXML();
            string str_DesignFormData = DesignFormData01.GetXML();
            string str_BarcodeAddData = "";
            if(this.Sl_par.Count>0)
            {
                str_BarcodeAddData = "<BarcodeAddData>";
                for(int i=0;i<Sl_par.Count;i++)
                {
                    BarcodeAddData BarcodeAddDatatmp = (BarcodeAddData)Sl_par.GetByIndex(i);
                    str_BarcodeAddData = str_BarcodeAddData + BarcodeAddDatatmp.GetXML();
                }
                str_BarcodeAddData = str_BarcodeAddData+ "</BarcodeAddData>";
            }
            rtb_xml.Text = "<Data>" + str_DesignFormData + str_BarcodeData + str_BarcodeAddData+"</Data>";
            UserXmlUpdate(sender, e, rtb_xml.Text);
        }

 

        private Label GetLabel(string strname)
        {            
            for(int i=0; i<pan_design.Controls.Count;i++)
            {
                Control ctmp = pan_design.Controls[i];
                if (ctmp.GetType().ToString() == "System.Windows.Forms.Label")
                {                    
                    Label lab_tmp = (Label)ctmp;
                    //lab_tmp.Tag = strlab;
                    if (lab_tmp.Text == strname) return lab_tmp;
                }
            }
            return null;
        }

        private void label_all_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lab_tmp = (Label)sender;
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                lab_tmp.Focus();
                //显示属性
                BarcodeAddData BarcodeAddDatatmp = (BarcodeAddData)this.Sl_par[lab_tmp.Text];
                this.pg_design.Tag = "BarcodeAddData";
                pg_design.SelectedObject = BarcodeAddDatatmp;
                pg_design.Refresh();
            }
        }

        private void label_all_MouseMove(object sender, MouseEventArgs e)
        {
            Label lab_tmp = (Label)sender;
            lab_tmp.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = lab_tmp.Location.X + moveX;
                y = lab_tmp.Location.Y + moveY;
                lab_tmp.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void label_all_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lab_tmp = (Label)sender;
                isMove = false;
                //显示属性
                BarcodeAddData BarcodeAddDatatmp = (BarcodeAddData)this.Sl_par[lab_tmp.Text];
                if (lab_tmp.Location.X < 0 || lab_tmp.Location.X > this.pan_design.Width || lab_tmp.Location.Y < 0 || lab_tmp.Location.Y > pan_design.Height)
                {
                    lab_tmp.Location = new Point(BarcodeAddDatatmp.X, BarcodeAddDatatmp.Y);
                }
                else
                {
                    BarcodeAddDatatmp.X = lab_tmp.Location.X;
                    BarcodeAddDatatmp.Y = lab_tmp.Location.Y;
                }
                this.pg_design.Refresh();
            }
        }



        private void tsm_print_Click(object sender, EventArgs e)
        {
            //this.printD01.Document = this.print01;            
            
            //print01.PrinterSettings.DefaultPageSettings.PrinterResolution=PrinterResolution
            printPD01.Document = this.print01;
            if (this.printPD01.ShowDialog() == DialogResult.OK)
            {
                print01.Print();
            }

        }

        private void print01_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap _NewBitmap = new Bitmap(this.pan_design.Width, pan_design.Height);
            //_NewBitmap.SetResolution(203, 203);
            pan_design.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            System.Drawing.Printing.PrinterResolution prnres = new System.Drawing.Printing.PrinterResolution();
            int iiix = print01.PrinterSettings.DefaultPageSettings.PrinterResolution.X;
            int iiiy = print01.PrinterSettings.DefaultPageSettings.PrinterResolution.Y;
            if (iiix != this.DesignFormData01.DPI)
            {
                MessageBox.Show("对不起！当前默认打印机分辨率和配置分辨率不符，肯能会导致打印失真。");
            }
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.DrawImage(_NewBitmap, 0, 0, dpiX * DesignFormData01.PrintWidth / (float)25.4, dpiY * DesignFormData01.PrintHeight / (float)25.4);

        }

        private void tsm_dprint_Click(object sender, EventArgs e)
        {
            SortedList sltmp = new SortedList();
            Barcode_print Barcode_print01 = new Barcode_print(this.rtb_xml.Text, null);
            Barcode_print01.ShowDialog();
        }

        private void pan_design_Click(object sender, EventArgs e)
        {
            this.pg_design.Tag = "DesignFormData";
            pg_design.SelectedObject = this.DesignFormData01;
            pg_design.Refresh();
        } 
    }
}
