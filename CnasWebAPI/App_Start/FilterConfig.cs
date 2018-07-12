using System.Web;
using System.Web.Mvc;

namespace Cnas.wns.CnasWebAPI
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}