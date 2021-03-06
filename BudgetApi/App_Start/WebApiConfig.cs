﻿using System.Web.Http;

namespace BudgetApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
