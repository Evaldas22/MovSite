using System.Web;
using System.Web.Mvc;

namespace MovSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            // this filter blocks all http end-points
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
