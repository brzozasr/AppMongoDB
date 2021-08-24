using Microsoft.Extensions.Configuration;

namespace AppMongoDB.MongoDbContext
{
    public class AppSettingsJsonValue : IAppSettingsJsonValue
    {
        public string GetAppSettingsJsonValue(string appSettingsJsonValue)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
            return configuration[appSettingsJsonValue];
        }
    }
}