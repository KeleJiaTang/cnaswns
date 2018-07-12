using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasBaseClassClient
{

    /// <summary>
    /// 实用工具类
    /// 公共方法都放到这里统一调用
    /// </summary>
    public  static class CnasUtilityTools
    {
        #region 字符处理
        /// <summary>
        /// 验证传入字符串是否为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns>返回 true 表示字符串不是正整数</returns>
        public static bool IsNumeric(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

		public static bool IsContains(string parentString, string childString)
		{
			return parentString.Contains(string.Format("{0},", childString));
		}

        #endregion

        #region 网址处理
        /// <summary>
        /// 验证传入字符串是否为网址格式
        /// </summary>
        /// <param name="str">验证的字符串</param>
        /// <returns>返回 true 表示字符串不是网址</returns>
        public static bool IsWeb(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"http://([\w-]+\.)+[\w-]+(/[\w-\./?%=]*)?");
            return reg1.IsMatch(str);
        }
        #endregion

        #region 邮箱处理
        /// <summary>
        /// 验证传入字符串是否为邮箱格式
        /// </summary>
        /// <param name="str">验证的字符串</param>
        /// <returns>返回 true 表示字符串不是邮箱格式</returns>
        public static bool IsEmail(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            return reg1.IsMatch(str);
        }
        #endregion

		public static T FindControl<T>(Control parentControl, string controlName = "") where T : Control
		{
			T result = null;
			foreach (Control control in parentControl.Controls)
			{
				
				if (control is Panel || control is GroupBox)
				{
					result = FindControl<T>(control, controlName);
					if (result != null)
						break;
				}
				else if (control is T)
				{
					if (string.IsNullOrEmpty(controlName) || (!string.IsNullOrEmpty(controlName) && control.Name.Equals(controlName)))
					{
						result = control as T;
						break;
					}
				}
			}
			return result;
		}


        public static void MoveData(RadGridView dgv01, RadGridView dgv02, bool onlyMoveSelect, bool leftToRight)
        {
            RadGridView sourceGrid = leftToRight ? dgv01 : dgv02;
            RadGridView targetGrid = leftToRight ? dgv02 : dgv01;

            IList<GridViewRowInfo> sourceCollection = null;
            if (onlyMoveSelect)
                sourceCollection = sourceGrid.SelectedRows;
            else
                sourceCollection = sourceGrid.Rows;
            if (sourceCollection != null)
            {
                int count = sourceCollection.Count;

                for (int i = 0; i < count; i++)
                {
                    GridViewRowInfo row = sourceCollection[i] as GridViewRowInfo;
                    GridViewRowInfo newRow = targetGrid.Rows.AddNew();
                    if (row.Cells.Count == newRow.Cells.Count)
                    {
                        for (int j = 0; j < row.Cells.Count; j++)
                        {
                            newRow.Cells[j].Value = row.Cells[j].Value;
                        }
                    }
                    sourceGrid.Rows.Remove(row);
                    count--;
                    i--;
                }
            }
        }

		/// <summary>
		/// 将两个字符串按照格式拼起来
		/// </summary>
		/// <param name="firstString"></param>
		/// <param name="secondString"></param>
		/// <returns></returns>
		public static string ConcatTwoString(string firstString, string secondString)
		{
			return string.Format("{0}:{1}", firstString, secondString);
		}

		public static string GetFolderName(EUploadType upType)
		{
			string folderName = string.Empty;
			if (upType == EUploadType.Set)
			{
				folderName = "set/";
			}
			else if (upType == EUploadType.Instrument)
			{
				folderName = "instruments/";
			}
			else if (upType == EUploadType.SafetyTimeReport)
			{
				folderName = "safetyTimeReport/";
			}
			else if (upType == EUploadType.SterilizerResultMonitor)
			{
				folderName = "monitor/sterilizerResult/";
			}
			else if (upType == EUploadType.WashingResultMonitor)
			{
				folderName = "monitor/washingResult/";
			}
			else if (upType == EUploadType.SetResultMonitor)
			{
				folderName = "monitor/setsterilizerResult/";
			}
			else if(upType==EUploadType.Order)
			{
				folderName = "order/";
			}
			return folderName;
		}


		public static bool IsSameImage(Image image1, Image image2)
		{
			MemoryStream ms1 = new MemoryStream();
			MemoryStream ms2 = new MemoryStream();

			image1.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);
			image2.Save(ms2, System.Drawing.Imaging.ImageFormat.Bmp);
			byte[] im1 = ms1.GetBuffer();
			byte[] im2 = ms2.GetBuffer();
			if (im1.Length != im2.Length)
				return false;
			else
			{
				for (int i = 0; i < im1.Length; i++)
					if (im1[i] != im2[i])
						return false;
			}
			return true;
		}
    }
}
