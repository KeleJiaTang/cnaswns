using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cnas.wns.CnasWebAPI.Models
{
	public class ResponeModel
	{
		public string ErrorCode { get; set; }
		public string Message { get; set; }
		public DataTable Data { get; set; }
	}
}