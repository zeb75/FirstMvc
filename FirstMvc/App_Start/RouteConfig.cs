using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GuessingGameRule",
                url: "GuessingGame",
                defaults: new
                {
                    controller = "Projects",
                    action = "GuessingGame",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
             name: "FeverRule",
             url: "FeverCheck",
             defaults: new
                {
                    controller = "Projects",
                    action = "FeverCheck",
                    id = UrlParameter.Optional
                } 
             );

            routes.MapRoute(
             name: "PersonRule",
             url: "Staff",
             defaults: new
             {
                 controller = "Person",
                 action = "Index",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
             );
        }
    }
}
