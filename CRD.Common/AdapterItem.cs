/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Data;

namespace CRD.Common
{
    public class AdapterItem
    {
        public ManagementObject MO;
        public string Caption;

        public AdapterItem(string caption, ManagementObject mo)
        {
            this.Caption = caption;
            this.MO = mo;
        }
        public override string ToString()
        {
            return Caption;
        }

    }


}