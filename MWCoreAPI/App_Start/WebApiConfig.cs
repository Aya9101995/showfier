using MWCoreAPI.Models.APIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MWCoreAPI
{
    public class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }

        public static string UrlPrefixRelative
        {
            get { return "~/api"; }
        }
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new APIRequestAndResponseHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
            .Add(new RequestHeaderMapping("Accept",
                                          "text/html",
                                          StringComparison.InvariantCultureIgnoreCase,
                                          true,
                                          "application/json"));
        }
    }
}
