using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoDbContext;
using Unity;

namespace AppMongoDB.Controllers
{
    public class MongoController : ApiController
    {
        private readonly IAppSettingsJsonValue _appSettingsJsonValue;
        private readonly IMongoRepository<Movie> _mongoRepository;

        public MongoController(IAppSettingsJsonValue appSettingsJsonValue, IMongoRepository<Movie> mongoRepository)
        {
            _appSettingsJsonValue = appSettingsJsonValue;
            _mongoRepository = mongoRepository;
        }

        // GET api/<controller>
        public async Task<IEnumerable<Movie>> Get()
        {
            //try
            //{
                var movieCollection = await _mongoRepository.GetAllData();
                return movieCollection.Where(x => x.Year.GetType().ToString() != "System.Int32");
            //}
            //catch (Exception e)
            //{
                //Console.WriteLine(e.Message);
                //return null; ;
            //}
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return _appSettingsJsonValue.GetAppSettingsJsonValue("MongoDBConnectionStrings:DefaultConnection");
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