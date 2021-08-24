using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.Models;
using AppMongoDB.Models.Movie;
using AppMongoDB.MongoDbContext;
using MongoDB.Bson;
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
        public async Task<IEnumerable<Movie>> Get(int limit = 50, int skip = 0)
        {
            try
            {
                int vLimit;
                int vSkip;

                if (limit > 0 && skip >= 0)
                {
                    vLimit = limit;
                    vSkip = skip;
                }
                else
                {
                    vLimit = 50;
                    vSkip = 0;
                }

                var movieCollection = await _mongoRepository.GetAllData(vLimit, vSkip);
                return movieCollection;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Mongo/GetByObjectId/{objId}")]
        public async Task<Movie> GetById(string objId)
        {
            try
            {
                var movie = await _mongoRepository.GetByObjectId(objId);
                return movie;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            
        }

        [HttpGet]
        [Route("api/Mongo/GetManyByFieldWithInt/{fieldName}/{fieldValue}")]
        public async Task<IEnumerable<Movie>> GetManyByFieldWithInt(string fieldName, int? fieldValue = null)
        {
            try
            {
                var movie = await _mongoRepository.GetManyByFieldWithInt(fieldName, fieldValue);
                return movie;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        [HttpGet]
        [Route("api/Mongo/GetManyByText/{searchedText}")]
        public async Task<IEnumerable<Movie>> GetManyByText(string searchedText)
        {
            try
            {
                var movie = await _mongoRepository.GetManyByText(searchedText);
                return movie;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        [Route("api/Mongo/DelByObjectId/{objId}")]
        public async Task<bool> ByObjectId(string objId)
        {
            try
            {
                return await _mongoRepository.DeleteById(objId);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Mongo/DeleteManyConsistValue/")]
        public async Task<long> DeleteManyConsistValued([FromBody] SearchText text)
        {
            try
            {
                return await _mongoRepository.DeleteManyConsistValue(text.Text);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}