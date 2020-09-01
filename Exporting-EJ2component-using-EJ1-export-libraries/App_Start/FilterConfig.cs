using System.Web;
using System.Web.Mvc;

namespace Exporting_EJ2component_using_EJ1_export_libraries
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
