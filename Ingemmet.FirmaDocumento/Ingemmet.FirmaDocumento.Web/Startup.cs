using Ingemmet.FirmaDocumento.Web.Infrastructure.Authorization;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartup(typeof(Ingemmet.FirmaDocumento.Web.Startup))]

namespace Ingemmet.FirmaDocumento.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            app.UseWebApi(new System.Web.Http.HttpConfiguration());
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = AppAuthenticationType.ApplicationCookie,
                LoginPath = new PathString("/authorization/signin"),
                CookieName = AppAuthenticationType.CookieName,
                CookieHttpOnly = true,
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromDays(1)
            });
        }
    }
}
