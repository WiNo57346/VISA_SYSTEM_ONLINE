using System.Web;
using System.Web.Mvc;

namespace VISA_SYSTEM_ONLINE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
