using System.Web.Optimization;

namespace MakeEvent.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Styles/bootstrap-social.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));

            //Подключение Кендо 
            bundles.Add(new StyleBundle("~/Content/KendoStyles").Include(
               "~/Content/Styles/kendo.material.min.css",
               "~/Content/Styles/kendo.material.mobile.min.css",
               "~/Content/Styles/kendo.common.min.css",
               "~/Content/Styles/main.css"));
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo.all.min.js",
                 "~/Scripts/KendoSPA/KendoHelper.js"));

            //ViewModels
            bundles.Add(new ScriptBundle("~/Scripts/MainApp").Include(
                "~/Scripts/KendoSPA/ViewModels/MainApp/Init.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Index.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/About.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Contacts.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/News.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Events.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Organizations.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/NewsItem.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Event.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Organization.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/PersonalPage.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Enter.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/Register.js",
                "~/Scripts/KendoSPA/ViewModels/MainApp/AdminPage.js",
                 "~/Scripts/KendoSPA/ViewModels/MainApp/layout.js"
                ));
        }
    }
}
