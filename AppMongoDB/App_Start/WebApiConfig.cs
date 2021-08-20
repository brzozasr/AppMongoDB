using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.WebSockets;
using AppMongoDB.Data;
using AppMongoDB.DI;
using Microsoft.Extensions.DependencyInjection;

namespace AppMongoDB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var services = new ServiceCollection();
            var provider = services.AddTransientServiceCollection<IMongoRepository, MongoRepository>();

            var resolver = new DependencyInjection(provider);
            config.DependencyResolver = resolver;
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
