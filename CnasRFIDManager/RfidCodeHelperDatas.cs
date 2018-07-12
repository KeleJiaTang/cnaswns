using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Cnas.wns.CnasRFIDManager
{
	public class RfidCodeHelperDatas
	{
		/// <summary>
		/// 获取蓝牙设备返回数据类型 1表示开始2rfidDatas3表示扫描结束
		/// </summary>
		/// <param name="Datas"></param>
		/// <param name="rfidDatas"></param>
		/// <returns></returns>
		public static int DataType(string Datas,out Dictionary<string,string> rfidDatas)
		{
			rfidDatas = new Dictionary<string, string>();
			Regex reg = new Regex("(?<=\\{id:\")[A-Za-z0-9|\"|:|,]*(?=\"\\})");
			MatchCollection collocMatchs = reg.Matches(Datas, 0);
			foreach (var item in collocMatchs)
			{
				string key = Convert.ToString(item);
				string temp_key = key.Replace("value:", string.Empty).Replace("\"", string.Empty).ToUpper();
				string[] array_keys = temp_key.Split(',');
				if (array_keys.Length == 2)
				{
					if (!rfidDatas.ContainsKey(key))
					{
						rfidDatas.Add(array_keys[1], array_keys[0]);
					}
				}
			}
			return 2;
		}
	}
}
