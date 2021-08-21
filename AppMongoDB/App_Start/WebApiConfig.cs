using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.DI;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoContext;
using Unity;

namespace AppMongoDB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            // Web API registration dependency injection
            container.RegisterSingleton<IMongoDbConnectionString, MongoDbConnectionString>();
            container.RegisterType<IMongoDbClient, MongoDbClient>();
            container.RegisterType<IMongoRepository<Movie>, MoqMongoRepository>();

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
