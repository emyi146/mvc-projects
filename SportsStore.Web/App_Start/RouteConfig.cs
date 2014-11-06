using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Empty",
                url: "",
                defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 }
            );

            routes.MapRoute(
                name: "PagingRoute",
                url: "Page{page}",
                defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "CategoryRoute",
                url: "{category}",
                defaults: new { controller = "Product", action = "List", page = 1 }
            );

            routes.MapRoute(
                name: "CategoryPagingRoute",
                url: "{category}/Page{page}",
                defaults: new { controller = "Product", action = "List" },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}"
            );
        }
    }
}