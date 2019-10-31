using System.Web.Mvc;
using System.Web.Routing;

namespace OCMovers_MC4.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
               name: "FAQ",
               url: "Old-City-Movers-Frequently-Asked-Questions",
               defaults: new { controller = "FAQs", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Contact",
               url: "Contact-Old-City-Movers",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
           );
            
            routes.MapRoute(
                name: "Services",
                url: "Old-City-Movers-Services",
                defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "About",
                url: "About-Old-City-Movers",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EstimateForm",
                url: "Old-City-Movers-Estimate-Form",
                defaults: new { controller = "Estimate", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}