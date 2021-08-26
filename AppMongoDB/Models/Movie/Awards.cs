using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongoDB.Models.Movie
{
    public class Awards
    {
        [BsonElement("wins")] 
        public int? Wins { get; set; }

        [BsonElement("nominations")]
        public int? Nominations { get; set; }

        [BsonElement("text")]
        public string NominationsDescription { get; set; }
    }
}