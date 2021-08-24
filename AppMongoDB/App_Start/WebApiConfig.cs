using System.Web.Http;
using AppMongoDB.Controllers;
using AppMongoDB.Data;
using AppMongoDB.DI;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoDbContext;
using Unity;
using Unity.Injection;

namespace AppMongoDB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            // Web API registration dependency injection
            container.RegisterSingleton<MoqDataStore>();
            container.RegisterType<IAppSettingsJsonValue, AppSettingsJsonValue>();
            container.RegisterType<IMongoDbManager, MongoDbManager>();
            container.RegisterType<IMongoRepository<Movie>, MovieMongoRepository>();

            //
            config.DependencyResolver = new UnityResolver(container);

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
