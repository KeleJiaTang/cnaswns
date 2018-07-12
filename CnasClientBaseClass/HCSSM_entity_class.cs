using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Drawing;

namespace Cnas.wns.CnasBaseClassClient
{
    public class HCSSM_entity_class
    {


    }

    public class ImageAddData
    {
        //lab_tmp.Font.Size=9;
        //lab_tmp.ForeColor=Color.Black;            
        //lab_tmp.Font = new Font("宋体", 9, FontStyle.Bold); 
        private string strName = "";
        [CategoryAttribute("设置"), DefaultValueAttribute(""), ReadOnlyAttribute(true)]
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        private string strValue = "";
        [CategoryAttribute("设置"), DefaultValueAttribute("")]
        public string Value
        {
            get { return strValue; }
            set { strValue = value; }
        }  

        private int intX = 20;
        [CategoryAttribute("位置"), DefaultValueAttribute(20)]
        public int X
        {
            get { return intX; }
            set { intX = value; }
        }
        private int intY = 20;
        [CategoryAttribute("位置"), DefaultValueAttribute(20)]
        public int Y
        {
            get { return intY; }
            set { intY = value; }
        }

        private bool boBold = true;
        [CategoryAttribute("字体"), DefaultValueAttribute(true)]
        public bool Bold
        {
            get { return boBold; }
            set { boBold = value; }
        }

        private int intForeSize = 15;
        [CategoryAttribute("字体"), DefaultValueAttribute(11)]
        public int ForeSize
        {
            get { return intForeSize; }
            set { intForeSize = value; }
        }

        private Color colFontColor = Color.Red;
        [CategoryAttribute("参数"), DefaultValueAttribute("FFFF0000")]
        public Color FontColor
        {
            get { return colFontColor; }
            set { colFontColor = value; }
        }

        public string GetXML()
        {
            string strdata = "<ImageAddData>";
            strdata = strdata + "<Name>" + strName + "</Name>";
            strdata = strdata + "<Value>" + strValue + "</Value>";
            strdata = strdata + "<FontColor>" + colFontColor.ToArgb().ToString() + "</FontColor>";
            strdata = strdata + "<X>" + intX.ToString() + "</X>";
            strdata = strdata + "<Y>" + intY.ToString() + "</Y>";
            strdata = strdata + "<Bold>" + boBold.ToString() + "</Bold>";
            strdata = strdata + "<ForeSize>" + intForeSize.ToString() + "</ForeSize></ImageAddData>";
            return strdata;
        }
    }



    public class ImageData
    {
        private string strName = "";
        [CategoryAttribute("图片名"), DefaultValueAttribute(""), ReadOnlyAttribute(true)]
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        private int intH = 600;
        private int intW = 800;
        /// <summary>
        /// 设计界面高度
        /// </summary>
        [CategoryAttribute("图片大小"), DefaultValueAttribute(600), ReadOnlyAttribute(true)]
        public int Height
        {
            get { return intH; }
            set { intH = value; }
        }

        /// <summary>
        /// 设计界面宽度
        /// </summary>
        [CategoryAttribute("图片大小"), DefaultValueAttribute(800), ReadOnlyAttribute(true)]
        public int Width
        {
            get { return intW; }
            set { intW = value; }
        }    

        public string GetXML()
        {
            string strdata = "<ImageData>";
            strdata = strdata + "<Name>" + strName + "</Name>";
            strdata = strdata + "<Height>" + intH.ToString() + "</Height>";
            strdata = strdata + "<Width>" + intW.ToString() + "</Width></ImageData>";
            return strdata;
        }

    }




}
