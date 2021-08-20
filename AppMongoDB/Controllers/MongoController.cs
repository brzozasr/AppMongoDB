using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AppMongoDB.Data;

namespace AppMongoDB.Controllers
{
    public class MongoController : ApiController
    {
        private readonly IMongoRepository _mongoRepository;

        public MongoController(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        // GET api/<controller>
        public IEnumerable<Car> Get()
        {
            return _mongoRepository.GetData();
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