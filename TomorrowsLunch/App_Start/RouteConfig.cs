using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TomorrowsLunch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Elements",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Elements", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Generic",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Generic", id = UrlParameter.Optional }
            );


            //add routes for login

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Registration",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Registration", id = UrlParameter.Optional }
            );


        }
    }
}
