using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MakeEvent.Business.Filtering.Builders;
using MakeEvent.Business.Services.Implementations;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Domain;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Implementations;
using MakeEvent.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace MakeEvent.Web
{
    public static class Dependencies
    {
        public static void Configure()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle(
                disposeInstanceWhenWebRequestEnds: true);

            // Register db-context
            container.Register<DbContext, ApplicationDbContext>(Lifestyle.Scoped);

            // Register repositories
            container.Register<IRepository, Repository<DbContext>>(Lifestyle.Scoped);

            // Register services
            container.Register<IPageService,          PageService>(Lifestyle.Scoped);
            container.Register<IAuthorizationService, AuthorizationService>(Lifestyle.Scoped);
            container.Register<IOrganizationService,  OrganizationService>(Lifestyle.Scoped);
            container.Register<IEventService,         EventService>(Lifestyle.Scoped);
            container.Register<IEventCategoryService, EventCategoryService>(Lifestyle.Scoped);
            container.Register<INewsService,          NewsService>(Lifestyle.Scoped);
            container.Register<IImageService,         ImageService>(Lifestyle.Scoped);

            // Register filter-builders
            container.Register<Common.Filtering.Builder.IFilterBuilder<Page, PageFilter>, PageFilterBuilder>(
                Lifestyle.Scoped);
            container.Register<Common.Filtering.Builder.IFilterBuilder<Event, EventFilter>, EventFilterBuilder>(
                Lifestyle.Scoped);

            // Register OWIN
            container.Register<UserService>(Lifestyle.Scoped);
            container.Register<SignInService>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(container.GetInstance<DbContext>()), Lifestyle.Scoped);

            container.Register<IAuthenticationManager>(() =>
                container.IsVerifying()
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);

            // Register MVC controllers
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Register WebAPI controllers
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify
            container.Verify();

            // Setup resolvers
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver 
                = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}