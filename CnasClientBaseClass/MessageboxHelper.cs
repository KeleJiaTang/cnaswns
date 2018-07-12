using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;


namespace Cnas.wns.CnasBaseClassClient
{
    public class CnasMessagebox
    {


        /// <summary>
        /// 提示信息窗体
        /// </summary>
        /// <param name="page">界面</param>
        /// <param name="content">提示内容</param>
        
        public static DialogResult ShowCueMessage(Form page, string content)
        {
            return ShowMessage(page, content, "提示信息", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        /// <summary>
        /// 错误信息的窗体
        /// </summary>
        /// <param name="page">界面</param>
        /// <param name="content">错误内容</param>
        /// <returns></returns>
        public static DialogResult ShowErrorMessage(Form page, string content)
        {
            return ShowMessage(page, content, "错误信息", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
       // public static DialogResult ShowErrorMessage


        public static DialogResult ShowMessage(Form page, string content, string title, MessageBoxButtons buttons, RadMessageIcon icon)
        {
            string aa = content, bb = title;
            return Telerik.WinControls.RadMessageBox.Show(page, aa, bb, buttons, icon, MessageBoxDefaultButton.Button1, RightToLeft.No);
        }













    }
}
