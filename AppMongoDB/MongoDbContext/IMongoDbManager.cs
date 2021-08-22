using MongoDB.Driver;

namespace AppMongoDB.MongoDbContext
{
    public interface IMongoDbManager
    {
        IMongoClient GetMongoDbClient();
    }
}
