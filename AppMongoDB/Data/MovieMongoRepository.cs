using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMongoDB.Models;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoDbContext;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using Unity;
using WebGrease.Css.Extensions;

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

        public async Task<IEnumerable<Movie>> GetManyByFieldWithInt(string fieldName, int? fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldName) && fieldValue != null)
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
                var filter = Builders<Movie>.Filter.Text('"' + searchedText + '"');
                var result = await (await _movieCollection.FindAsync(filter)).ToListAsync();


                if (result != null && result.Any())
                {
                    return result;
                }
            }

            return null;
        }

        public async Task<bool> DeleteById(string objId)
        {
            if (ObjectId.TryParse(objId, out var objectId))
            {
                var result = await _movieCollection.DeleteOneAsync(x => x.MovieId == objectId);

                if (result.IsAcknowledged && result.DeletedCount > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<long> DeleteManyConsistValue(string fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldValue) && fieldValue.Length > 4)
            {
                var filter = Builders<Movie>.Filter.Text('"' + fieldValue + '"');
               
                var countDel = await _movieCollection.DeleteManyAsync(filter);

                if (countDel.IsAcknowledged && countDel.DeletedCount > 0)
                {
                    return countDel.DeletedCount;
                }
              
            }

            return 0;
        }

        public async Task<bool> InsertOneDoc(Movie document)
        {
            if (document != null)
            {
                var objId = document.MovieId = ObjectId.GenerateNewId();

                await _movieCollection.InsertOneAsync(document);

                var isAdded = await (await _movieCollection.FindAsync(x => x.MovieId == objId)).AnyAsync();

                if (isAdded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<long> InsertManyDocs(ICollection<Movie> documents)
        {
            if (documents != null && documents.Any())
            {
                var collectionCounterBefore = await _movieCollection.CountDocumentsAsync(_ => true );
                var docsLength = documents.Count;
                await _movieCollection.InsertManyAsync(documents);
                var collectionCounterAfter = await _movieCollection.CountDocumentsAsync(_ => true);

                return collectionCounterAfter + docsLength == collectionCounterAfter ? docsLength : collectionCounterAfter - collectionCounterBefore;
            }

            return 0;
        }

        public async Task<bool> UpdateOneDoc(string objId, Movie document)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.MovieId, ObjectId.Parse(objId));

            var update = Builders<Movie>.Update;
            var updates = new List<UpdateDefinition<Movie>>();

            updates.Add(update.Set(x => x.Title, document.Title));
            updates.Add(update.Set(x => x.Description, document.Description));
            updates.Add(update.Set(x => x.FullDescription, document.FullDescription));
            updates.Add(update.Set(x => x.Released, document.Released));
            updates.Add(update.Set(x => x.Year, document.Year));
            updates.Add(update.Set(x => x.PosterUrl, document.PosterUrl));
            updates.Add(update.Set(x => x.Type, document.Type));
            updates.Add(update.Set(x => x.Genres, document.Genres));
            updates.Add(update.Set(x => x.Cast, document.Cast));
            updates.Add(update.Set(x => x.Languages, document.Languages));
            updates.Add(update.Set(x => x.Directors, document.Directors));
            updates.Add(update.Set(x => x.Writers, document.Writers));
            updates.Add(update.Set(x => x.Countries, document.Countries));
            updates.Add(update.Set(x => x.MovieAwards, document.MovieAwards));
            
            var record = await _movieCollection.UpdateOneAsync(filter, update.Combine(updates), new UpdateOptions {IsUpsert = true});

            if (record.IsAcknowledged && record.ModifiedCount > 0)
            {
                return true;
            }

            return false;

        }
    }
}