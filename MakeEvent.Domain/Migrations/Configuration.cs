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

            context.EventCategories.AddOrUpdate(c => c.Name,
                new EventCategory { Name = "Праздники" },
                new EventCategory { Name = "Концерты" },
                new EventCategory { Name = "Мастер-классы" },
                new EventCategory { Name = "Лекции" });

            context.Pages.AddOrUpdate(p => p.Name, 
                new Page { Name = "About", IsEditable = true },
                new Page { Name = "Help" , IsEditable = true});

            SeedUsers(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var roleStore   = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore   = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                // Add missing roles
                var adminRole = roleManager.FindByName("Admin");
                if (adminRole == null)
                {
                    adminRole = new IdentityRole("Admin");
                    roleManager.Create(adminRole);
                }

                var orgRole = roleManager.FindByName("Organization");
                if (orgRole == null)
                {
                    orgRole = new IdentityRole("Organization");
                    roleManager.Create(orgRole);
                }

                // Create test users
                var admin = userManager.FindByName("admin@event.com");
                if (admin == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        UserName = "admin@event.com",
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@event.com"
                    };
                    userManager.Create(newAdmin, "123456");
                    userManager.AddToRole(newAdmin.Id, "Admin");
                }

                var organization = userManager.FindByName("organization@event.com");
                if (organization == null)
                {
                    var newOrganization = new ApplicationUser()
                    {
                        UserName = "organization@event.com",
                        FirstName = "Organization",
                        LastName = "Organization",
                        Email = "organization@event.com"
                    };
                    userManager.Create(newOrganization, "123456");
                    userManager.AddToRole(newOrganization.Id, "Organization");
                }
            }
        }
    }
}

