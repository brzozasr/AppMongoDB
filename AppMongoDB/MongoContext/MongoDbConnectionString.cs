using System.IO;
using Microsoft.Extensions.Configuration;

namespace AppMongoDB.MongoContext
{
    public class MongoDbConnectionString : IMongoDbConnectionString
    {
        public IConfiguration GetMongoDbConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            return configurationBuilder
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
        }
    }
}