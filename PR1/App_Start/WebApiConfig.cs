using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PR1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // ESTA OPCIÓN ES PARA USAR WEB API ROUTING DE WEB API 2
            config.MapHttpAttributeRoutes();

            // OPCION PARA USAR TABLA DE RUTAS DE WEB API 1, VAMOS A ELIMINAR PARA USAR SOLO WEB API ROUTING
            //config.Routes.MapHttpRoute(
             //   name: "DefaultApi",
             //   routeTemplate: "api/{controller}/{id}",
             //   defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
