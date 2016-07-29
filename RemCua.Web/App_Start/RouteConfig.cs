using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RemCua.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Page",
                url: "trang/{alias}",
                defaults: new { controller = "Page", action = "Page", alias = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );

            routes.MapRoute(
                name: "ViewDetail",
                url: "chi-tiet/{alias}-{id}",
                defaults: new { controller = "Product", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );
        }
    }
}
