using System;
using MongoDB.Driver;

namespace AppMongoDB.MongoDbContext
{
    public class MongoDbManager : IMongoDbManager
    {
        private readonly IAppSettingsJsonValue _connectionString;

        public MongoDbManager(IAppSettingsJsonValue connectionString)
        {
            _connectionString = connectionString;
        }

        public IMongoClient GetMongoDbClient()
        {
            try
            {
                return new MongoClient(_connectionString.GetAppSettingsJsonValue("MongoDBConnectionStrings:DefaultConnection"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}