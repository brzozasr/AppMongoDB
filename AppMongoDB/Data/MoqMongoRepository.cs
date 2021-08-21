using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using AppMongoDB.Models.Movie;
using MongoDB.Bson;

namespace AppMongoDB.Data
{
    public class MoqMongoRepository : IMongoRepository<Movie>
    {
        public IList<Movie> MoqData { get; } = new List<Movie>();

        public MoqMongoRepository()
        {
            Random rnd = new Random();
            MoqData.Add(
            new Movie
                {
                    MovieId = ObjectId.GenerateNewId(),
                    Title = "High and Dizzy",
                    Description = "A tipsy doctor encounters his patient sleepwalking on a building ledge, high above the street.",
                    FullDescription = "After a long wait, a young doctor finally has a patient come to his office. She is a young woman whose father has brought her to be treated for sleep-walking, but the father becomes annoyed with the doctor, and takes his daughter away. Soon afterward, the young doctor shares in a drinking binge with another doctor who has built a still in his office. After a series of misadventures, the two of them wind up in the same hotel where the daughter and her father are staying, leading to some hazardous predicaments.",
                    Released = new DateTime(rnd.Next(1950, 2021), rnd.Next(1, 13), rnd.Next(1, 29))
            });
            MoqData.Add(
                new Movie
                {
                    MovieId = ObjectId.GenerateNewId(),
                    Title = "High and Dizzy",
                    Description = "A tipsy doctor encounters his patient sleepwalking on a building ledge, high above the street.",
                    FullDescription = "After a long wait, a young doctor finally has a patient come to his office. She is a young woman whose father has brought her to be treated for sleep-walking, but the father becomes annoyed with the doctor, and takes his daughter away. Soon afterward, the young doctor shares in a drinking binge with another doctor who has built a still in his office. After a series of misadventures, the two of them wind up in the same hotel where the daughter and her father are staying, leading to some hazardous predicaments.",
                    Released = new DateTime(rnd.Next(1950, 2021), rnd.Next(1, 13), rnd.Next(1, 29))
                });
        }

        public async Task<IList<Movie>> GetAllData()
        {
            var task = Task.Run(() => MoqData);
            await Task.CompletedTask;
            return task.Result;
        }

        public Task<Movie> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByValue<T2>(string fieldName, T2 fieldValue)
        {
            throw new NotImplementedException();
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