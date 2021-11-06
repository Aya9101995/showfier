using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MWCore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "DatabasePage",
                url: "{lang}/{PageName}",
                defaults: new { controller = "Home", action = "Index", lang = "en", PageName = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "servicesDetails",
                url: "{lang}/Services/Details/{name}",
                defaults: new { controller = "Services", action = "Details", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FestivalsDetails",
                url: "{lang}/Festivals/Details/{name}",
                defaults: new { controller = "Festivals", action = "Details", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FineArtsDetails",
                url: "{lang}/FineArts/Details/{name}",
                defaults: new { controller = "FineArts", action = "Details", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "NewsDetails",
                url: "{lang}/News/Details/{name}",
                defaults: new { controller = "News", action = "Details", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MuseumsCategoryDetails",
                url: "{lang}/Museums/Details/{name}",
                defaults: new { controller = "Museums", action = "Details", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MuseumsDetails",
                url: "{lang}/Museums/MuseumsDetails/{name}",
                defaults: new { controller = "Museums", action = "MuseumsDetails", lang = "en", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                            name: "CompetitionsDetails",
                            url: "{lang}/Competitions/Details/{name}",
                            defaults: new { controller = "Competitions", action = "Details", lang = "en", name = UrlParameter.Optional }
                        );
            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", lang = "en" }
            );

        }
    }
}
