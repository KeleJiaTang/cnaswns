using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cnas.wns.CnasBaseClassClient
{
    public static class CnasBaseData
    {
        private static string strUserID = "";
        private static string strUserName = "";
        private static string strSI_ID = "";
        private static string strImage_Path = "";
        private static int intIf_LoadData = 0;
        private static string _computerName = "";
		private static int _systemVersion = 1;
		private static string _macAddress = string.Empty;
        private static DataTable dtBaseDataTable = new DataTable();
        private static DataTable dtSystemInfoData = new DataTable();
        private static DataTable dtAppData = new DataTable();
		private static DataTable _userAccessCustomer = new DataTable();

        private static UserBase userBase = new UserBase();

		public static int SystemVersion
        {
			get { return _systemVersion; }
			set { _systemVersion = value; }
        }

		public static string ComputerName
		{
			get { return _computerName; }
			set { _computerName = value; }
		}

		public static string MacAddress
		{
			get { return _macAddress; }
			set { _macAddress = value; }
		}


        /// <summary>
        /// 用户ID
        /// </summary>
        public static string UserID
        {
            get { return strUserID; }
            set { strUserID = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }


       /// <summary>
       /// 获取用户基本信息
       /// </summary>
        public static UserBase UserBaseInfo
        {
            get { return userBase; }
            set { userBase = value; }
        }


        /// <summary>
        /// 系统ID
        /// </summary>
        public static string SystemID
        {
            get { 
                return strSI_ID; }
            set { 
                strSI_ID = value; }
        }
        /// <summary>
        /// 是否重新加载数据
        /// </summary>
        public static int If_LoadData
        {
            get
            {
                return intIf_LoadData;
            }
            set
            {
                intIf_LoadData = value;
            }
        }
        /// <summary>
        /// 系统数据ca_system_data
        /// </summary>
        public static DataTable SystemBaseData
        {
            get { return dtBaseDataTable; }
            set { dtBaseDataTable = value; }
        }

		/// <summary>
		/// 用户有全选的customer
		/// </summary>
		public static DataTable UserAccessCustomer
		{
			get { return _userAccessCustomer; }
			set { _userAccessCustomer = value; }
		}

        /// <summary>
        /// 系统信息ca_system_info
        /// </summary>
        public static DataTable SystemInfoData
        {
            get { return dtSystemInfoData; }
            set { dtSystemInfoData = value; }
        }
        /// <summary>
        /// APP数据
        /// </summary>
        public static DataTable AppData
        {
            get { return dtAppData; }
            set { dtAppData = value; }
        }

        /// <summary>
        /// 程序图片目录
        /// </summary>
        public static string Image_Path
        {
            get { return strImage_Path; }
            set { strImage_Path = value; }
        }

        private static string strFTP_Path = "ftp://dev.cnasis.cn/hcs/";
        /// <summary>
        /// FTP目录
        /// </summary>
        public static string FTP_Path
        {
            get { return strFTP_Path; }
            set { strFTP_Path = value; }
        }


        private static string strFTP_User = "cnasftp";
        /// <summary>
        /// FTP用户
        /// </summary>
        public static string FTP_User
        {
            get { return strFTP_User; }
            set { strFTP_User = value; }
        }

        private static string strFTP_PWD = "ftp123";
        /// <summary>
        /// FTP密码
        /// </summary>
        public static string FTP_PWD
        {
            get { return strFTP_PWD; }
            set { strFTP_PWD = value; }
        }

    }



    



















}
