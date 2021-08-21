using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoContext;

namespace AppMongoDB.Controllers
{
    public class MongoController : ApiController
    {
        private readonly IMongoRepository<Movie> _mongoRepository;
        private IMongoDbConnectionString _connectionString;

        public MongoController(IMongoRepository<Movie> mongoRepository, IMongoDbConnectionString connectionString)
        {
            _mongoRepository = mongoRepository;
            _connectionString = connectionString;
        }

        // GET api/<controller>
        public async Task<IEnumerable<Movie>> Get()
        {
            try
            {
                var result = Task.Run(() => _mongoRepository.GetAllData());
                await Task.CompletedTask;
                return result.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null; ;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return _connectionString.GetMongoDbConnectionString()["MongoDBConnectionStrings:DefaultConnection"];
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}