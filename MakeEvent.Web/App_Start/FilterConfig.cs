using System.Web.Mvc;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleMvcExceptionAttribute());
        }
    }
}
