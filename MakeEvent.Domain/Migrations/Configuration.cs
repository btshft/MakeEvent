using System.Collections.Generic;
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

            context.Pages.AddOrUpdate(p => p.Name, 
                new Page { Name = "About", IsEditable = true },
                new Page { Name = "Help" , IsEditable = true});

            SeedEventCategories(context);
            SeedUsers(context);
        }

        private void SeedEventCategories(ApplicationDbContext context)
        {
            var categoryCelebrations = new EventCategory { Id = 1 };
            var categoryLections    = new EventCategory { Id = 2 };
            var categoryWorkshops   = new EventCategory { Id = 3 };
            var categoryConcerts    = new EventCategory { Id = 4 };
            var unspecifiedCategory = new EventCategory { Id = 5, IsDefault = true };

            context.EventCategories.AddOrUpdate(c => c.Id,
                unspecifiedCategory,
                categoryConcerts,
                categoryCelebrations,
                categoryLections,
                categoryWorkshops);

            var localizations = new List<EventCategoryLocalization>
            {
                new EventCategoryLocalization { EventCategoryId = 5, Name = "Uncategorized", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = 5, Name = "Без категории", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = 1, Name = "Concerts", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = 1, Name = "Концерты", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = 2, Name = "Celebrations", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = 2, Name = "Праздники", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = 3, Name = "Lections", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = 3, Name = "Лекции", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = 4, Name = "Workshops", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = 4, Name = "Мастер-классы", LanguageId = 2 }
            };

            context.EventCategoryLocalizations.AddOrUpdate(c => c.Name, localizations.ToArray());

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

