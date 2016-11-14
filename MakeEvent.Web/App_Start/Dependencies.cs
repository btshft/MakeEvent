using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MakeEvent.Business;
using MakeEvent.Business.Filtering.Builders;
using MakeEvent.Business.Services.Implementations;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Domain;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using MakeEvent.Repository.Implementations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace MakeEvent.Web.IoC
{
    public static class Dependencies
    {
        public static Container Container 
            = new Container();

        public static void Register()
        {
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle(
                disposeInstanceWhenWebRequestEnds: true);

            // Register db-context
            Container.Register<DbContext, ApplicationDbContext>(Lifestyle.Scoped);

            // Register repositories
            Container.Register<IRepository, Repository<DbContext>>(Lifestyle.Scoped);

            // Register services
            Container.Register<IPageService, PageService>(Lifestyle.Scoped);

            // Register filter-builders
            Container.Register<Common.Filtering.Builder.IFilterBuilder<Page, PageFilter>, PageFilterBuilder>(Lifestyle.Scoped);

            // Register OWIN
            Container.Register<UserService>(Lifestyle.Scoped);
            Container.Register<SignInService>(Lifestyle.Scoped);

            Container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(Container.GetInstance<DbContext>()), Lifestyle.Scoped);

            Container.Register<IAuthenticationManager>(() =>
                Container.IsVerifying()
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);

            // Register MVC controllers
            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Register WebAPI controllers
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify
            Container.Verify();

            // Setup resolvers
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
            GlobalConfiguration.Configuration.DependencyResolver 
                = new SimpleInjectorWebApiDependencyResolver(Container);
        }
    }
}