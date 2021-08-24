using System;
using System.Collections.Generic;
using System.Linq;
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

        public MovieMongoRepository(IMongoDbManager mongoDbManager)
        {
            var client = mongoDbManager.GetMongoDbClient();
            var database = client.GetDatabase("sample_mflix");
            _movieCollection = database.GetCollection<Movie>("movies");
        }

        public async Task<IList<Movie>> GetAllData(int limit, int skip)
        {
            return await _movieCollection.Find(_ => true).Limit(limit).Skip(skip).ToListAsync();
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

        public async Task<IEnumerable<Movie>> GetManyByFieldWithInt(string fieldName, int fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldName) && fieldValue > 0)
            {
                var filter = new BsonDocument (fieldName, fieldValue);
                var result = await (await _movieCollection.FindAsync(filter)).ToListAsync();

                if (result != null && result.Any())
                {
                    return result;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Movie>> GetManyByText(string searchedText)
        {
            if (!string.IsNullOrEmpty(searchedText))
            {
                var filter = Builders<Movie>.Filter.Text(searchedText);
                var result = await (await _movieCollection.FindAsync(filter)).ToListAsync();

                if (result != null && result.Any())
                {
                    return result;
                }
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