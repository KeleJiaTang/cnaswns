using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cnas.wns.CnasBaseClassClient
{


    /// <summary>
    /// 
    /// </summary>
    public class PromptMessageXmlHelper
    {
		private DataTable _promtMessaageData=null;
		/// <summary>
		/// 实例
		/// </summary>
		private static PromptMessageXmlHelper _instance=null;
		/// <summary>
		/// 默认实例
		/// </summary>
		public static PromptMessageXmlHelper Instance
		{
			get
			{
				if (_instance == null)
					_instance = new PromptMessageXmlHelper();
				return _instance;
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		private PromptMessageXmlHelper() 
		{ 
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, "PromptMessage");
			condition.Add(2, 0); //0默认中文,1英文
			//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-dialog-message-sec002", condition);
			_promtMessaageData =reCnasRemotCall.RemotInterface.SelectData("HCS-dialog-message-sec002", condition);
			
		}
        /// <summary>
        /// 根据XML节点的名称返回对应的提示信息
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="EnumPromptMessage">消息提示的类型</param>
        /// <returns>根据XML节点的名称返回对应的提示信息</returns>
        public string GetPromptMessage(string nodeName, EnumPromptMessage enumPromptMessage)
        {
			if (_promtMessaageData != null && _promtMessaageData.Rows.Count > 0)
			{
				DataRow[] array = _promtMessaageData.Select("message_node='" + nodeName + "' and message_type='"+(int)enumPromptMessage+"'");
				if (array != null && array.Length > 0)
				{
					return Convert.ToString(array[0]["message_value"]);
				}
				return string.Empty;
			}
            return string.Empty;
        }

        public  string GetPromptMessage(string noteName, EnumPromptMessage messageType, string[] param)
        {
			string txtValue = GetPromptMessage(noteName, messageType);
            string test = string.Format(txtValue, param);
            return test;
        }
    }

    /// <summary>
    /// 消息提示的类型
    /// </summary>
    public enum EnumPromptMessage
    {
        /// <summary>
        /// 普通的信息提醒
        /// </summary>
        warning = 0,
        /// <summary>
        /// 错误的信息提醒
        /// </summary>
        error = 1

    }



}
