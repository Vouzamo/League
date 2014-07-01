using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Data;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register Areas
            AreaRegistration.RegisterAllAreas();

            // Register Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register Bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize Database
            Database.SetInitializer(new DataInitializer());
        }
    }
}
