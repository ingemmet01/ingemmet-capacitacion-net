using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace Ingemmet.FirmaDocumento.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
            DevexpressBundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleConfig.RegisterBundles(BundleTable.Bundles);     
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}