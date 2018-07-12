using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using Cnas.wns.CnasBaseInterface;

namespace Cnas.wns.CnasBaseClassServer
{
    public class CnasServerMethods : MarshalByRefObject,CnasHCSInterface
    {
       
            /// <summary>
            /// 检查配置数据
            /// </summary>
            /// <param name="ConSN">配置编码</param>
            /// <param name="inpar">参数</param>
            /// <returns>返回配置数据</returns>
            public string CheckSelectData(string ConSN, SortedList inpar)
            {
                string sqlstring = GetConfigData(ConSN);
                if (sqlstring == "" || (inpar != null && sqlstring.IndexOf('?') <= 0)) return "";

                if (inpar != null)//有输入参数的查询
                {
                    string[] strdata = sqlstring.Split('?');
                    sqlstring = "";
                    for (int i = 0; i < strdata.Length; i++)
                    {
                        if (i < inpar.Count)
                        {
                            sqlstring = sqlstring + strdata[i] + inpar.GetByIndex(i).ToString();
                        }
                        else
                        {
                            sqlstring = sqlstring + strdata[i];
                        }
                    }
                }
                return sqlstring;
            }

            /// <summary>
            /// 根据配置信息查询数据
            /// </summary>
            /// <param name="ConSN">配置编码</param>
            /// <param name="inpar">参数</param>
            /// <returns>返回数据集</returns>
            public DataTable SelectData(string ConSN, SortedList inpar)
            {
                string sqlstring = GetConfigData(ConSN);
                if (sqlstring == "" || (inpar != null && sqlstring.IndexOf('?') <= 0)) return null;

                if (inpar != null)//有输入参数的查询
                {
                    string[] strdata = sqlstring.Split('?');
                    sqlstring = "";
                    for (int i = 0; i < strdata.Length; i++)
                    {
                        if (i < inpar.Count)
                        {
                            sqlstring = sqlstring + strdata[i] + inpar.GetByIndex(i).ToString();
                        }
                        else
                        {
                            sqlstring = sqlstring + strdata[i];
                        }
                    }
                }

                try
                {
                    MySqlHelper mysql = new MySqlHelper();
                    DataTable mydatatable = new DataTable();
                    mydatatable = mysql.GetDataTable(System.Data.CommandType.Text, sqlstring, null);
                    //if (mydatatable == null) mydatatable = new DataTable();
                    return mydatatable;
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                    return null;
                }
            }

            /// <summary>
            /// 根据配置更新数据库
            /// </summary>
            /// <param name="uptype">1、1条；2、N+1/N+M条；3、N+N条</param>
            /// <param name="ConSN">配置编码</param>
            /// <param name="inpar">参数</param>
            /// <returns>返回更新结果</returns>
            public string CheckUPData(int uptype, string ConSN, SortedList inpar01, SortedList inpar02)
            {
                //string sqlstring = " INSERT INTO zb_goods_loss (goods_id,goods_name,goods_sn,sub_menber,cre_date,goods_unit,reg_id,loss_weight) VALUES(";
                string sqltou = "set names utf8; ";
                string sqlstring = GetConfigData(ConSN);
                if (sqlstring == "") return "";//获取不到语句

                if (inpar01 != null && inpar02 == null)//只有一个输入参数
                {
                    string[] strdata = sqlstring.Split('?');
                    sqlstring = "";
                    for (int uu = 0; uu < inpar01.Count; uu++)
                    {
                        SortedList struu01 = (SortedList)inpar01.GetByIndex(uu);
                        for (int i = 0; i < strdata.Length; i++)
                        {
                            if (i < struu01.Count)
                            {
                                sqlstring = sqlstring + strdata[i] + struu01.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata[i];
                            }
                        }
                    }

                }
                else if (inpar01 != null && inpar02 != null)//有两个输入参数“#”
                {
                    string[] strsqldata02 = sqlstring.Split('#');//只有两条记录
                    if (strsqldata02.Length != 2) return "";
                    string[] strdata01 = strsqldata02[0].Split('?');

                    sqlstring = "";
                    for (int uu = 0; uu < inpar01.Count; uu++)
                    {
                        SortedList struu01 = (SortedList)inpar01.GetByIndex(uu);
                        for (int i = 0; i < strdata01.Length; i++)
                        {
                            if (i < struu01.Count)
                            {
                                sqlstring = sqlstring + strdata01[i] + struu01.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata01[i];
                            }
                        }
                    }


                    string[] strdata02 = strsqldata02[1].Split('?');
                    for (int uu = 0; uu < inpar02.Count; uu++)
                    {
                        SortedList struu02 = (SortedList)inpar02.GetByIndex(uu);
                        for (int i = 0; i < strdata02.Length; i++)
                        {
                            if (i < struu02.Count)
                            {
                                sqlstring = sqlstring + strdata02[i] + struu02.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata02[i];
                            }
                        }
                    }

                }
                else
                {

                }

                return sqlstring;

            }

            /// <summary>
            /// 根据配置更新数据库
            /// </summary>
            /// <param name="uptype">1、1条；2、N+1/N+M条；3、N+N条</param>
            /// <param name="ConSN">配置编码</param>
            /// <param name="inpar">参数</param>
            /// <returns>返回更新结果</returns>
            public int UPData(int uptype, string ConSN, SortedList inpar01, SortedList inpar02)
            {
                //string sqlstring = " INSERT INTO zb_goods_loss (goods_id,goods_name,goods_sn,sub_menber,cre_date,goods_unit,reg_id,loss_weight) VALUES(";
                string sqltou = "set names utf8; ";
                string sqlstring = GetConfigData(ConSN);
                if (sqlstring == "") return -10;//获取不到语句

                if (inpar01 != null && inpar02 == null)//只有一个输入参数
                {
                    string[] strdata = sqlstring.Split('?');
                    sqlstring = "";
                    for (int uu = 0; uu < inpar01.Count; uu++)
                    {
                        SortedList struu01 = (SortedList)inpar01.GetByIndex(uu);

                        for (int i = 0; i < strdata.Length; i++)
                        {
                            if (i < struu01.Count)
                            {
                                sqlstring = sqlstring + strdata[i] + struu01.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata[i];
                            }
                        }
                    }
                }
                else if (inpar01 != null && inpar02 != null)//有两个输入参数“#”
                {
                    string[] strsqldata02 = sqlstring.Split('#');//只有两条记录
                    if (strsqldata02.Length != 2) return -1;
                    string[] strdata01 = strsqldata02[0].Split('?');

                    sqlstring = "";
                    for (int uu = 0; uu < inpar01.Count; uu++)
                    {
                        SortedList struu01 = (SortedList)inpar01.GetByIndex(uu);
                        for (int i = 0; i < strdata01.Length; i++)
                        {
                            if (i < struu01.Count)
                            {
                                sqlstring = sqlstring + strdata01[i] + struu01.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata01[i];
                            }
                        }
                    }


                    string[] strdata02 = strsqldata02[1].Split('?');
                    for (int uu = 0; uu < inpar02.Count; uu++)
                    {
                        SortedList struu02 = (SortedList)inpar02.GetByIndex(uu);
                        for (int i = 0; i < strdata02.Length; i++)
                        {
                            if (i < struu02.Count)
                            {
                                sqlstring = sqlstring + strdata02[i] + struu02.GetByIndex(i).ToString();
                            }
                            else
                            {
                                sqlstring = sqlstring + strdata02[i];
                            }
                        }
                    }

                }
                else
                {

                }

                try
                {
                    MySqlHelper mysql = new MySqlHelper();
                    return mysql.ExecuteNonQuery(CommandType.Text, sqltou + sqlstring, null);
                }
                catch (Exception ee)
                {
                    return -1;
                }
            }

			/// <summary>
			///  根据配置更新数据库
			/// </summary>
			/// <param name="conSN">配置编码</param>
			/// <param name="parameters">配置参数</param>
			/// <returns>更新结果</returns>
			public string CheckUPDataList(string conSN, SortedList parameters)
			{
				string sqlstring = GetConfigData(conSN);
				if (string.IsNullOrEmpty(sqlstring)) return string.Empty;
				if (parameters == null || parameters.Count < 1) return "parameters does not match sql.";

				string buildSQL = string.Empty;

				if (sqlstring.Contains("#"))
				{
					string[] subSqlData = sqlstring.Split('#');
					if (subSqlData.Length < parameters.Count) return "parameters does not match sql.";
					for (int i = 0; i < parameters.Count; i++)
					{
						SortedList param = parameters.GetByIndex(i) as SortedList;
						if (param != null && param.Count > 0)
						{
							int paramIndex = (int)parameters.GetKey(i);
							if (paramIndex - 1 > subSqlData.Length) return "parameters does not match sql.";
							string[] subSql = subSqlData[paramIndex - 1].Split('?');

							for (int j = 0; j < param.Count; j++)
							{
								SortedList pa = (SortedList)param.GetByIndex(j);
								for (int k = 0; k < subSql.Length; k++)
								{
									buildSQL = buildSQL + subSql[k];
									if (k < pa.Count)
										buildSQL += pa.GetByIndex(k).ToString();
								}
							}
						}
					}
				}
				else
				{
					string[] subSql = sqlstring.Split('?');
					for (int j = 0; j < parameters.Count; j++)
					{
						SortedList pa = (SortedList)parameters.GetByIndex(j);
						for (int k = 0; k < subSql.Length; k++)
						{
							buildSQL = buildSQL + subSql[k];
							if (k < pa.Count)
								buildSQL += pa.GetByIndex(k).ToString();
						}
					}
				}

				return buildSQL;
			}

			/// <summary>
			///  根据配置更新数据库
			/// </summary>
			/// <param name="conSN">配置编码</param>
			/// <param name="parameters">配置参数</param>
			/// <returns>更新结果</returns>
			public int UPDataList(string conSN, SortedList parameters)
			{
				string sqltou = "set names utf8; ";
				string buildSQL = CheckUPDataList(conSN, parameters);

				try
				{
					MySqlHelper mysql = new MySqlHelper();
					return mysql.ExecuteNonQuery(CommandType.Text, sqltou + buildSQL, null);
				}
				catch (Exception ex)
				{
					return -1;
				}
			}

			public DataSet ExecuteProcedure(string procedureName, SortedList parameters)
			{
				if (parameters != null)
				{
					List<MySqlParameter> stortedParams = new List<MySqlParameter>();
					for (int i = 0; i < parameters.Count; i++)
					{
						MySqlParameter parameter = new MySqlParameter(parameters.GetKey(i).ToString(), parameters[parameters.GetKey(i)]);
						stortedParams.Add(parameter);
					}

					if (stortedParams != null && stortedParams.Count == parameters.Count)
					{
						try
						{
							MySqlHelper mysql = new MySqlHelper();
							return mysql.GetDataSet(CommandType.StoredProcedure, procedureName, stortedParams.ToArray());
						}
						catch (Exception ex)
						{
							return null;
						}
 					}
				}
				return null;
			}

            /// <summary>
            /// 获取配置信息
            /// </summary>
            /// <param name="ConSn">配置表SN码</param>
            /// <returns>配置信息</returns>
            private string GetConfigData(string ConSn)
            {
                string Sqlstring = "select Con_data from ca_config_sqldata where Con_Sn='" + ConSn + "';";
                try
                {
                    MySqlHelper mysql = new MySqlHelper();
                    DataTable mydatatable = new DataTable();
                    mydatatable = mysql.GetDataTable(System.Data.CommandType.Text, Sqlstring, null);
                    if (mydatatable == null || mydatatable.Rows.Count == 0)
                    {
                        return "";
                    }
                    else
                    {
                        return mydatatable.Rows[0]["Con_data"].ToString();
                    }
                }
                catch (Exception ee)
                {
                    return "";
                }
            }

			public int GetSerialNumber(int number, string type)
			{
				int result = -1;
				try
				{
					SortedList condition = new SortedList();
					condition.Add(1, number);
					condition.Add(2, type);
					condition.Add(3, type);
					string testSQL = CheckSelectData("HCS-serialnum-sec001", condition);
					DataTable data = SelectData("HCS-serialnum-sec001", condition);
					if (data != null && data.Rows.Count > 0
						&& data.Columns.Contains("max_num") && data.Rows[0]["max_num"] != null)
					{
						int.TryParse(data.Rows[0]["max_num"].ToString(), out result);
					}
				}
				catch (Exception)
				{
				}
				return result;
			}

            public SortedList GetSystemData(int intype, SortedList indata)
            {
                return null;
            }


            #region //生成入库编号 例如：20071118114255
            public static int int_count = 1;
            public string Get_SerialNumber(int intype)
            {
                if (intype == 1)
                {
                    if (int_count < 9999)
                    {
                        int_count++;
                    }
                    else
                    {
                        int_count = 1;
                    }
                    int intYear = DateTime.Now.Year;
                    int intMonth = DateTime.Now.Month;
                    int intDate = DateTime.Now.Day;
                    int intHour = DateTime.Now.Hour;
                    int intSecond = DateTime.Now.Second;
                    int intMinute = DateTime.Now.Minute;
                    string strTime = null;
                    strTime = intYear.ToString();
                    if (intMonth < 10)
                    {
                        strTime += "0" + intMonth.ToString();
                    }
                    else
                    {
                        strTime += intMonth.ToString();
                    }
                    if (intDate < 10)
                    {
                        strTime += "0" + intDate.ToString();
                    }
                    else
                    {
                        strTime += intDate.ToString();
                    }
                    if (intHour < 10)
                    {
                        strTime += "0" + intHour.ToString();
                    }
                    else
                    {
                        strTime += intHour.ToString();
                    }
                    if (intMinute < 10)
                    {

                        strTime += "0" + intMinute.ToString();
                    }
                    else
                    {
                        strTime += intMinute.ToString();
                    }
                    if (intSecond < 10)
                    {

                        strTime += "0" + intSecond.ToString();
                    }
                    else
                    {
                        strTime += intSecond.ToString();
                    }

                    strTime = strTime + int_count.ToString();
                    return strTime;
                }else if(intype==2)
                {
                    return System.Guid.NewGuid().ToString();
                }else
                {
                    return int_count.ToString();
                }

            }// end if 
            #endregion

    }
}
