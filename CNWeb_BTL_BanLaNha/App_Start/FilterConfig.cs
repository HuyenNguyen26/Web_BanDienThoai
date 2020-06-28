using System.Web;
using System.Web.Mvc;

namespace CNWeb_BTL_BanLaNha
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
