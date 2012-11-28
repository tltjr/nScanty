using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using nScanty.Data;

namespace nScanty
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "RSS",
                "rss",
                new {controller = "Home", action = "Rss"});

            routes.MapRoute(
                "Post",
                "Home/{year}/{month}/{slug}",
                new {controller = "Home", action = "Post" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterUser();
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }

        private static void RegisterUser()
        {
            var repo = new UserRepository();
            var username = ConfigurationManager.AppSettings["user"];
            var user = repo.GetUser(username);
            if (null != user) return;
	        var hashedPassword = ConfigurationManager.AppSettings["hashedPassword"];
	        if (!string.IsNullOrEmpty(hashedPassword))
	        {
		        repo.CreateUserWithHashedPassword(username, hashedPassword);
	        }
	        else
	        {
		        var password = ConfigurationManager.AppSettings["password"];
		        repo.CreateUser(username, password);
	        }
        }
    }
}