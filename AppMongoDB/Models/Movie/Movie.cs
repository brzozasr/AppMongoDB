﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongoDB.Models.Movie
{
    // The driver throws away not recognized elements
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        public ObjectId MovieId { get; set; }

        [BsonElement("title")] 
        public string Title { get; set; }

        [BsonElement("plot")] 
        public string Description { get; set; }

        [BsonElement("fullplot")]
        public string FullDescription { get; set; }

        [BsonElement("released")]
        public DateTime Released { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("poster")]
        public string PosterUrl { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("genres")] 
        public IEnumerable<string> Genres { get; set; }

        [BsonElement("cast")]
        public IEnumerable<string> Cast { get; set; }

        [BsonElement("languages")]
        public IEnumerable<string> Languages { get; set; }

        [BsonElement("directors")]
        public IEnumerable<string> Directors { get; set; }

        [BsonElement("writers")]
        public IEnumerable<string> Writers { get; set; }

        [BsonElement("countries")]
        public IEnumerable<string> Countries { get; set; }

        [BsonElement("awards")]
        public Awards MovieAwards { get; set; }

        // In this element driver is going to put all not assigned elements from document as dictionary
        //[BsonExtraElements]
        //public object[] Bucket { get; set; }
    }
}