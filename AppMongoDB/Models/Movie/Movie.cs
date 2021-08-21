using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongoDB.Models.Movie
{
    public class Movie
    {
        [BsonId]
        public ObjectId MovieId { get; set; }
    }
}