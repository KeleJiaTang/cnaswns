using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
    public partial class ChartForm : Form
    {
        public ChartForm(string [] strvalue)
        {
            InitializeComponent();
            c1RG.Value = double.Parse(strvalue[0]);
            c1RadialGauge1.Value = double.Parse(strvalue[1]);
            c1RadialGauge2.Value = double.Parse(strvalue[2]);
            c1RadialGauge3.Value = double.Parse(strvalue[3]);
            c1RadialGauge4.Value = double.Parse(strvalue[4]);
            c1RadialGauge5.Value = double.Parse(strvalue[5]);
            c1RadialGauge6.Value = double.Parse(strvalue[6]);
        }
    }
}
