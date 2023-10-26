
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.Security;

namespace WebApi
{
    public static class WebApiConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registros", action = "Login", id = UrlParameter.Optional }
            );
        }

        //config.MapHttpAttributeRoutes();

        //config.MessageHandlers.Add(new TokenValidationHandler());

        //config.Routes.MapHttpRoute(
        //    name: "DefaultApi",
        //    routeTemplate: "api/{controller}/{id}",
        //    //defaults: new { id = RouteParameter.Optional }
        //    defaults: new { controller = "Productos", action = "Inicio", id = UrlParameter.Optional }
        //);





        //public static void Register(HttpConfiguration config)
        //{
        //    var cors = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cors);

        //    // Rutas de API web
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
    }
}
