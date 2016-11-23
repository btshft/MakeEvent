using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Reflection;

    public sealed class Configuration : DbMigrationsConfiguration<MakeEvent.Domain.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextType = typeof(ApplicationDbContext);
            ContextKey = "MakeEvent.Domain.Migrations.Configuration";
            MigrationsNamespace = "MakeEvent.Domain.Migrations";
            MigrationsAssembly = Assembly.GetExecutingAssembly();
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MakeEvent.Domain.ApplicationDbContext context)
        {
            context.Languages.AddOrUpdate(p => p.Name, 
                new Language { ShortName = "EN", Name = "Английский"},
                new Language { ShortName = "RU", Name = "Русский" });

            context.Roles.AddOrUpdate(p => p.Name,
                new IdentityRole { Name = "Organization"},
                new IdentityRole { Name = "Admin"});

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
