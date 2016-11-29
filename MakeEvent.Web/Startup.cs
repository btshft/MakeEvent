using Microsoft.Owin;
using Owin;
using SimpleInjector.Extensions.ExecutionContextScoping;

[assembly: OwinStartup(typeof(MakeEvent.Web.Startup))]
namespace MakeEvent.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
