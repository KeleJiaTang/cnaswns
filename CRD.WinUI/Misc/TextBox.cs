/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CRD.WinUI.Misc
{
  public  class TextBox:System.Windows.Forms.TextBox
    {
      public TextBox()
          : base()
      {
         // this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
          this.BorderStyle = BorderStyle.FixedSingle;
          this.UpdateStyles();

      }

      protected override void WndProc(ref Message m)
      {

          base.WndProc(ref m);
          if (m.Msg == 0xf || m.Msg == 0x133)
          {
              Shared.ResetBorderColor(m, this);
          }
      }

    }
}
