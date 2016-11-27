using System.Linq;
using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Reflection;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private static readonly string DefaultPassword = "123456";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextType = typeof(ApplicationDbContext);
            ContextKey = "MakeEvent.Domain.Migrations.Configuration";
            MigrationsNamespace = "MakeEvent.Domain.Migrations";
            MigrationsAssembly = Assembly.GetExecutingAssembly();
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Languages.AddOrUpdate(p => p.Name, 
                new Language { ShortName = "EN", Name = "Английский"},
                new Language { ShortName = "RU", Name = "Русский" });

            context.Roles.AddOrUpdate(p => p.Name,
                new IdentityRole { Name = "Organization"},
                new IdentityRole { Name = "Admin"});

            context.EventCategories.AddOrUpdate(c => c.Name,
                new EventCategory { Name = "Праздники" },
                new EventCategory { Name = "Концерты" },
                new EventCategory { Name = "Мастер-классы" },
                new EventCategory { Name = "Лекции" });

            context.Pages.AddOrUpdate(p => p.Name, 
                new Page { Name = "About", IsEditable = true },
                new Page { Name = "Help" , IsEditable = true});

            var hasher = new PasswordHasher();

            var admin = new ApplicationUser
            {
                Email = "admin@event.com",
                UserName = "admin@event.com",
                FirstName = "Admin",
                LastName = "Admin",
                MiddleName = "Admin",
                PasswordHash = hasher.HashPassword(DefaultPassword)
            };

            var organization = new ApplicationUser
            {
                Email = "organization@event.com",
                UserName = "organization@event.com",
                FirstName = "Organization",
                LastName = "Organization",
                MiddleName = "Organization",
                PasswordHash = hasher.HashPassword(DefaultPassword)
            };

            context.Users.AddOrUpdate(c => c.UserName, admin, organization);

            var orgRole = context.Roles.Single(c => c.Name == "Organization");
            if (!context.Users.Find(organization.Id).Roles.Any(r => r.RoleId == orgRole.Id))
                orgRole.Users.Add(new IdentityUserRole { RoleId = orgRole.Id, UserId = organization.Id });

            var adminRole = context.Roles.Single(c => c.Name == "Admin");
            if (!context.Users.Find(admin.Id).Roles.Any(r => r.RoleId == adminRole.Id))
                adminRole.Users.Add(new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id });

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

