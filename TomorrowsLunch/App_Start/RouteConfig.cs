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
                name: "Elements",
                url: "Home/Elements/{id}",
                defaults: new { controller = "Home", action = "Elements", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Generic",
                url: "Home/Generic/{id}",
                defaults: new { controller = "Home", action = "Generic", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "Login/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Registration",
                url: "Registration/{id}",
                defaults: new { controller = "User", action = "Registration", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditProfile",
                url: "EditProfile/{id}",
                defaults: new { controller = "User", action = "EditProfile", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Meals",
                url: "Meals/{action}/{id}",
                defaults: new { controller = "Meal", action = "Meals", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Ingredients",
                url: "Ingredients/{action}/{id}",
                defaults: new { controller = "Ingredient", action = "Ingredients", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
