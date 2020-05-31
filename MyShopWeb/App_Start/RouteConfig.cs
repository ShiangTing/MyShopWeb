using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyShopWeb
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
            //routes.MapRoute(
            //    name: "CategoryMenu",
            //    url: "Product/ProductPage/{id}",
            //    defaults: new { id = UrlParameter.Optional }
            //    );
            //routes.MapRoute(
            //    name: "Shopping",
            //    url: "{controller}/{action}/{id}/{quantity}",
            //     defaults: new { controller = "ShoppingCart", action = "AddToCart", id = UrlParameter.Optional, quantity = UrlParameter.Optional }
            //    );
        }
    }
}
