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
                name: "Search",
                url: "tim-kiem/{keyword}",
                defaults: new { controller = "Product", action = "Search", keyword = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );


            routes.MapRoute(
                name: "DetailNews",
                url: "chi-tiet-tin/{alias}-{id}",
                defaults: new { controller = "Post", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );


            routes.MapRoute(
               name: "Success",
               url: "hoan-thanh",
               defaults: new { controller = "Payment", action = "Success", id = UrlParameter.Optional },
               namespaces: new string[] { "RemCua.Web.Controllers" }
           );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Cart", id = UrlParameter.Optional },
               namespaces: new string[] { "RemCua.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Category",
                url: "san-pham/{alias}-{id}",
                defaults: new { controller = "Product", action = "Category", alias = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );
            routes.MapRoute(
                name: "News",
                url: "tin-tuc",
                defaults: new { controller = "Post", action = "Post", alias = UrlParameter.Optional },
                namespaces: new string[] { "RemCua.Web.Controllers" }
            );

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
                name: "trangchu",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
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
