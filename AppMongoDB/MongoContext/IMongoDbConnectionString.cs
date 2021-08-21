using Microsoft.Extensions.Configuration;

namespace AppMongoDB.MongoContext
{
    public interface IMongoDbConnectionString
    {
        IConfiguration GetMongoDbConnectionString();
    }
}
