using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLySuKien
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                name: "event page",
                url: "PublicHome/Event/{page}",
                defaults: new { controller = "PublicHome", action = "Event", id = UrlParameter.Optional }
               );
            routes.MapRoute(
              name: "Categoy  page",
              url: "PublicCategory/GetCategoryById/{id}/{page}",
              defaults: new { controller = "PublicCategory", action = "GetCategoryById", id = UrlParameter.Optional }
             );
            routes.MapRoute(
             name: "Search event",
             url: "PublicEvent/Search/{page}/{name}",
             defaults: new { controller = "PublicEvent", action = "Search", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PublicHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
