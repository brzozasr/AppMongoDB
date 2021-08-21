using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AppMongoDB.Data;
using AppMongoDB.Models.Movie;

namespace AppMongoDB.Controllers
{
    public class MongoController : ApiController
    {
        private readonly IMongoRepository<Movie> _mongoRepository;

        public MongoController(IMongoRepository<Movie> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            return Ok(_mongoRepository.GetAllData());
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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