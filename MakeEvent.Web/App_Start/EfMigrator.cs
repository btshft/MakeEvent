using System.Data.Entity.Migrations;
using System.Web.Configuration;

namespace MakeEvent.Web
{
    public static class EfMigrator
    {
        public static void Migrate(DbMigrationsConfiguration<Domain.ApplicationDbContext> configuration)
        {
            //var migrate = bool.Parse(
            //    WebConfigurationManager.AppSettings["MigrateDatabaseToLatestVersion"]);

            //if (migrate)
            //{
                var migrator = new DbMigrator(configuration);
                migrator.Update();
            //}
        }
    }
}