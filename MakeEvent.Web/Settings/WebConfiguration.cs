using System.Web.Configuration;

namespace MakeEvent.Web.Settings
{
    public static class WebConfiguration
    {
        public static bool MigrateDatabaseToLatestVersion =>
            bool.Parse(WebConfigurationManager.AppSettings["MigrateDatabaseToLatestVersion"]);
    }
}