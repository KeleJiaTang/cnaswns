using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseUC
{
    public partial class ReportBaseForm : TemplateForm
    {
        /// <summary>
        /// 存储过程名称
        /// </summary>
        public string IndicatorType
        {
            get;
            set;
        }
        /// <summary>
        /// 窗体显示名称
        /// </summary>
        public string FormName
        {
            get;
            set;
        }

        public ReportBaseForm()
        {
            InitializeComponent();
        }
    }
}
