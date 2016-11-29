using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MakeEvent.Domain.Migrations;

namespace MakeEvent.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Dependencies.Configure();
            AutoMapperConfig.RegisterMappings();;
            EfMigrator.Migrate(new Configuration());
        }

        protected void Application_BeginRequest()
        {
            LocaleConfiguration.SetupLocale(allowedLocales: "en,ru");
        }
    }
}
