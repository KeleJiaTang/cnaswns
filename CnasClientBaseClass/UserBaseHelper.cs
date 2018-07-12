using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasBaseClassClient
{
    public class UserBaseHelper
    {

        static CnasRemotCall reCnasRemotCall = new CnasRemotCall();

        /// <summary>
        /// 检查 用户名 密码 是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static int CheckUserInfo(string userName, string passWord)
        {
            SortedList sltmp = new SortedList();
            sltmp.Add(0, userName);
            sltmp.Add(1, CnasClientMethods.GetMD5Hash(passWord).ToLower());

            string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-userdata-sec004", sltmp);

            DataTable dtSource = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec004", sltmp);
			int socurce = -1;
			if (dtSource != null && dtSource.Rows.Count > 0)
			{
				socurce = Convert.ToInt32(dtSource.Rows[0]["id"]);
			}
            return socurce;
        }


        /// <summary>
        /// 根据用户名，返回用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserBase UserInfoByUserName(string userName)
        {
            UserBase userBase = new CnasBaseClassClient.UserBase();

            SortedList sltmp = new SortedList();
            sltmp.Add(0, userName);

            //string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-userdata-sec001", sltmp);
            DataTable dtSource = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec001", sltmp);

            if (dtSource == null || dtSource.Rows.Count <= 0)
                return null;


            userBase.UserID = Convert.ToInt32(dtSource.Rows[0]["id"].ToString());
            userBase.UserName = dtSource.Rows[0]["user_name"].ToString();
            userBase.Userbcode = dtSource.Rows[0]["user_bcode"].ToString();

            userBase.UserType = Convert.ToInt32(dtSource.Rows[0]["user_type"].ToString());
            if (dtSource.Columns.Contains("location_id") && !(dtSource.Rows[0]["location_id"] is DBNull))
				userBase.LocationId = Convert.ToInt32(dtSource.Rows[0]["location_id"].ToString());
            if (dtSource.Columns.Contains("customer_id") && !(dtSource.Rows[0]["customer_id"] is DBNull))
                userBase.CustomerId = Convert.ToInt32(dtSource.Rows[0]["customer_id"].ToString());
			if (dtSource.Columns.Contains("location_area") && !(dtSource.Rows[0]["location_area"] is DBNull))
				userBase.LocationArea = Convert.ToInt32(dtSource.Rows[0]["location_area"].ToString());
			if (!(dtSource.Rows[0]["customer_code"] is DBNull))
				userBase.CustomerCode = Convert.ToString(dtSource.Rows[0]["customer_code"].ToString());
            return userBase;
        }

        public static UserBase GetUserByBarCode(string uBarCode)
        {
            UserBase userBase = null;
            SortedList sltmp = new SortedList();
            sltmp.Add(1, uBarCode);
            string testSQl = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-userdata-sec003", sltmp);
            DataTable dtSource = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec003", sltmp);
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                userBase = new UserBase();
                userBase.UserID = Convert.ToInt32(dtSource.Rows[0]["id"].ToString());
                userBase.UserName = dtSource.Rows[0]["user_name"].ToString();
                userBase.Userbcode = dtSource.Rows[0]["user_bcode"].ToString();
                userBase.LocationId = Convert.ToInt32(dtSource.Rows[0]["location_id"].ToString());
                userBase.UserType = Convert.ToInt32(dtSource.Rows[0]["user_type"].ToString());
                userBase.CustomerId = Convert.ToInt32(dtSource.Rows[0]["customer_id"].ToString());
				if (dtSource.Columns.Contains("location_area") && !(dtSource.Rows[0]["location_area"] is DBNull))
					userBase.LocationArea = Convert.ToInt32(dtSource.Rows[0]["location_area"].ToString());
            }
            return userBase;
        }
    }


    /// <summary>
    /// 用户基类
    /// </summary>
    public class UserBase
    {

        private int strUserID = 0;
        private string strUserName = "";
        private string userBcode = "";
        private int locationId = 0;
        private int _userType = 0;
        private int _customerId = 0;
		private int _locationArea = 2;
		private string _customerCode = string.Empty;

		public int LocationArea
		{
			get { return _locationArea; }
			set { _locationArea = value; }
		}

        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

		public string CustomerCode
		{
			get { return _customerCode; }
			set { _customerCode = value; }
		}

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return strUserID; }
            set { strUserID = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }


        /// <summary>
        /// 用户条码
        /// </summary>
        public string Userbcode
        {
            get { return userBcode; }
            set { userBcode = value; }
        }


        /// <summary>
        /// 使用地点
        /// </summary>
        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

    }
}
