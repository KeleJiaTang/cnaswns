using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.ComponentModel;
using System.Drawing.Imaging;

namespace Cnas.wns.CnasBaseUC
{
    public enum SizeTypes : int { P800x600, P720x540, P640x480, P560x420, P480x360, P320x240 };

    public class BaseUCData
    {
    }

    public class CameraData
    {
        //lab_tmp.Font.Size=9;
        //lab_tmp.ForeColor=Color.Black;            
        //lab_tmp.Font = new Font("宋体", 9, FontStyle.Bold); 
        private string strName = "";
        [CategoryAttribute("图像名称"), DefaultValueAttribute(""), ReadOnlyAttribute(true)]
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        private SizeTypes SizeTypestmp = SizeTypes.P800x600;
        [CategoryAttribute("图像大小"), DefaultValueAttribute(SizeTypes.P800x600)]
        public SizeTypes Size
        {
            get { return SizeTypestmp; }
            set { SizeTypestmp = value; }
        }        

        public string GetXML()
        {
            string strdata = "<CameraData>";
            strdata = strdata + "<Name>" + strName + "</Name>";
            strdata = strdata + "<Size>" + SizeTypestmp.ToString() + "</Size></CameraData>";
            return strdata;
        }
    }


    public class LabelData
    {
        //lab_tmp.Font.Size=9;
        //lab_tmp.ForeColor=Color.Black;            
        //lab_tmp.Font = new Font("宋体", 9, FontStyle.Bold); 
        private string strName = "";
        [CategoryAttribute("参数"), DefaultValueAttribute(""), ReadOnlyAttribute(true)]
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        private string strDefaultValue = "";
        [CategoryAttribute("参数"), DefaultValueAttribute("")]
        public string Value
        {
            get { return strDefaultValue; }
            set { strDefaultValue = value; }
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
        [CategoryAttribute("字体设置"), DefaultValueAttribute(true)]
        public bool Bold
        {
            get { return boBold; }
            set { boBold = value; }
        }

        private int intForeSize = 15;
        [CategoryAttribute("字体设置"), DefaultValueAttribute(11)]
        public int ForeSize
        {
            get { return intForeSize; }
            set { intForeSize = value; }
        }

        private Color colLabelColor = Color.Red;
        [CategoryAttribute("参数"), DefaultValueAttribute("FFFF0000")]
        public Color LabelColor
        {
            get { return colLabelColor; }
            set { colLabelColor = value; }
        }

        public string GetXML()
        {
            string strdata = "<LabelData>";
            strdata = strdata + "<Name>" + strName + "</Name>";
            strdata = strdata + "<Value>" + strDefaultValue + "</Value>";
            strdata = strdata + "<X>" + intX.ToString() + "</X>";
            strdata = strdata + "<Y>" + intY.ToString() + "</Y>";
            strdata = strdata + "<LabelColor>" + colLabelColor.ToArgb().ToString() + "</LabelColor>";
            strdata = strdata + "<Bold>" + boBold.ToString() + "</Bold>";
            strdata = strdata + "<ForeSize>" + intForeSize.ToString() + "</ForeSize></LabelData>";
            return strdata;
        }
    }

}
