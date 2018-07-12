using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CnasUI
{
    public partial class TemplateForm : Telerik.WinControls.UI.RadForm
    {
        public TemplateForm()
        {
            //this.ThemeClassName = "Windows7";
            //ThemeResolutionService.ApplicationThemeName = "Windows7";
            InitializeComponent();
            //Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            

            Telerik.WinControls.Themes.Office2007SilverTheme officeTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.ThemeName = officeTheme.ThemeName;



        }
    }
}
