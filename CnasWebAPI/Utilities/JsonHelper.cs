using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Cnas.wns.CnasWebAPI
{
	public class JsonHelper
	{
		public static Dictionary<string, string> GetJson(string jsonString)
		{
			Dictionary<string, string> jsonObject = null;
			if (!string.IsNullOrEmpty(jsonString))
			{
				DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
				MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
				jsonObject = (Dictionary<string, string>)ser.ReadObject(ms);
			}

			return jsonObject;
		}

		public static T GetJsonObject<T>(string jsonString)
		{
			T resultObject = default(T);
			try
			{
				if (!string.IsNullOrEmpty(jsonString))
				{
					DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
					MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
					resultObject = (T)ser.ReadObject(ms);
				}

			}
			catch (Exception)
			{
			}
			return resultObject;
		}


		public static string GetModel<T>(T model)
		{
			string jsonString = string.Empty;
			if (model != null)
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
				MemoryStream stream = new MemoryStream();
				serializer.WriteObject(stream, model);
				byte[] dataBytes = new byte[stream.Length];
				stream.Position = 0;
				stream.Read(dataBytes, 0, (int)stream.Length);
				jsonString = Encoding.UTF8.GetString(dataBytes);

				DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
			}

			return jsonString;
		}
	}
}