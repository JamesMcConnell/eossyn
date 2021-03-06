﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eossyn.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapHubs();
            routes.MapRoute("AllWorlds", "json/worlds", new { controller = "Json", action = "GetAllWorlds" }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("GetCharactersForWorld", "json/world/{worldId}/characters", new { controller = "Json", action = "GetCharactersForWorld" }, new { method = new HttpMethodConstraint("GET") });

            // User routes
            routes.MapRoute("GetUserConfig", "userjson/config", new { controller = "UserJson", action = "GetUserConfig" }, new { method = new HttpMethodConstraint("GET") });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}