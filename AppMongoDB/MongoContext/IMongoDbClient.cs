using MongoDB.Driver;

namespace AppMongoDB.MongoContext
{
    public interface IMongoDbClient
    {
        IMongoClient GetMongoDbClient();
    }
}
