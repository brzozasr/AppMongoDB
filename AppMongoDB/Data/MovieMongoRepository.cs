using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoDbContext;
using MongoDB.Bson;
using MongoDB.Driver;
using Unity;

namespace AppMongoDB.Data
{
    public class MovieMongoRepository : IMongoRepository<Movie>
    {
        private IMongoCollection<Movie> _movieCollection;

        //public MovieMongoRepository()
        //{
        //}

        public MovieMongoRepository(IMongoDbManager mongoDbManager)
        {
            var client = mongoDbManager.GetMongoDbClient();
            var database = client.GetDatabase("sample_mflix");
            _movieCollection = database.GetCollection<Movie>("movies");
        }

        public async Task<IList<Movie>> GetAllData()
        {
            return await (await _movieCollection.FindAsync(_ => true)).ToListAsync();
            //return new List<Movie> {new Movie {MovieId = ObjectId.GenerateNewId()}};
        }

        public async Task<Movie> GetByObjectId(string objId)
        {
            if (ObjectId.TryParse(objId, out var objectId))
            {
                return await (await _movieCollection.FindAsync(x => x.MovieId == objectId)).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<Movie> GetOneByValue(string fieldName, dynamic fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldName) && fieldValue)
            {
                //var filter = new BsonDocument { { fieldName, fieldValue } };
                //return await (await _movieCollection.FindAsync(filter)).FirstOrDefaultAsync();
                var builder = Builders<Movie>.Filter;
                var query = builder.Eq(fieldName, fieldValue);
                return await (await _movieCollection.FindAsync<Movie>(query)).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByValue<T3>(string fieldName, T3 fieldValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertDoc(Movie document)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDoc<T4>(Movie document, Dictionary<string, T4> values)
        {
            throw new NotImplementedException();
        }
    }
}