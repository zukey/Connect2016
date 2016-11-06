using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PictureStampRally.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の構成とサービス

            // Web API のルート
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ScoreCheck",
                routeTemplate: "api/{controller}/Check/{themeImageId}",
                defaults: new { action = "Check", themeImageId = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                name: "ScoreRegist",
                routeTemplate: "api/{controller}/Regist/{themeImageId}",
                defaults: new { action = "Regist", themeImageId = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
