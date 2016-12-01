using System;
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
            var celebrationsKey = "Celebrations";
            var lectionsKey     = "Lections";
            var workshopsKey    = "Workshops";
            var concertsKey     = "Concerts";
            var unspectifiedKey = "Unspecified";

            var categoryCelebrations = new EventCategory { Key = celebrationsKey };
            var categoryLections     = new EventCategory { Key = lectionsKey };
            var categoryWorkshops    = new EventCategory { Key = workshopsKey };
            var categoryConcerts     = new EventCategory { Key = concertsKey };
            var unspecifiedCategory  = new EventCategory { Key = unspectifiedKey, IsDefault = true };

            context.EventCategories.AddOrUpdate(c => c.Key,
                unspecifiedCategory,
                categoryConcerts,
                categoryCelebrations,
                categoryLections,
                categoryWorkshops);

            context.SaveChanges();

            var celebrationsId = context.EventCategories.Single(c => c.Key == celebrationsKey).Id;
            var lectionsId     = context.EventCategories.Single(c => c.Key == lectionsKey).Id;
            var workshopsId    = context.EventCategories.Single(c => c.Key == workshopsKey).Id;
            var concertsId     = context.EventCategories.Single(c => c.Key == concertsKey).Id;
            var unspectifiedId = context.EventCategories.Single(c => c.Key == unspectifiedKey).Id;

            var localizations = new List<EventCategoryLocalization>
            {
                new EventCategoryLocalization { EventCategoryId = unspectifiedId, Key = "UnspecifiedEn", Name = "Uncategorized", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = unspectifiedId, Key = "UnspecifiedRu", Name = "Без категории", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = concertsId, Key = "ConcertsEn", Name = "Concerts", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = concertsId, Key = "ConcertsRu", Name = "Концерты", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = celebrationsId, Key = "CelebrationsEn", Name = "Celebrations", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = celebrationsId, Key = "CelebrationsRu", Name = "Праздники", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = lectionsId, Key = "LectionsEn", Name = "Lections", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = lectionsId, Key = "LectionsRu", Name = "Лекции", LanguageId = 2 },

                new EventCategoryLocalization { EventCategoryId = workshopsId, Key = "WorkshopsEn", Name = "Workshops", LanguageId = 1 },
                new EventCategoryLocalization { EventCategoryId = workshopsId, Key = "WorkshopsRu", Name = "Мастер-классы", LanguageId = 2 }
            };

            context.EventCategoryLocalizations.AddOrUpdate(c => c.Key, localizations.ToArray());

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
                        UserName  = "admin@event.com",
                        FirstName = "Admin",
                        LastName  = "Admin",
                        Email     = "admin@event.com"
                    };
                    userManager.Create(newAdmin, "123456");
                    userManager.AddToRole(newAdmin.Id, "Admin");
                }

                var organization = userManager.FindByName("organization@event.com");
                if (organization == null)
                {
                    var newOrganization = new ApplicationUser()
                    {
                        UserName  = "organization@event.com",
                        FirstName = "Organization",
                        LastName  = "Organization",
                        Email     = "organization@event.com"
                    };
                    userManager.Create(newOrganization, "123456");
                    userManager.AddToRole(newOrganization.Id, "Organization");
                }
            }
        }
    }
}

