﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeEvent.Web.Startup))]
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