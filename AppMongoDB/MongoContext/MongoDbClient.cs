using System;
using MongoDB.Driver;

namespace AppMongoDB.MongoContext
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly MongoDbConnectionString _connectionString;

        public MongoDbClient(MongoDbConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IMongoClient GetMongoDbClient()
        {
            try
            {
                return new MongoClient(_connectionString.GetMongoDbConnectionString()["MongoDBConnectionStrings:DefaultConnection"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}