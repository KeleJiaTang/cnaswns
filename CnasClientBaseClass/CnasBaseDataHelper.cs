using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasBaseClassClient
{
	public class CnasBaseDataHelper
	{
		/// <summary>
		/// 返回关于流程节点单个值
		/// </summary>
		/// <param name="type_code"></param>
		/// <param name="key_code"></param>
		/// <returns></returns>
		public static string Wf_SingleValue(string type_code,string key_code)
		{
			DataRow[] array = CnasBaseData.SystemBaseData.Select("type_code='" + type_code + "' and key_code='" + key_code + "'");
			if (array != null && array.Length > 0)
			{
				return Convert.ToString(array[0]["value_code"]).TrimEnd(',');
			}
			return string.Empty;
		}
	}
}
