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

        [HttpPost]
        [Route("api/Mongo/GetManyByText/")]
        public async Task<IEnumerable<Movie>> GetManyByText([FromBody] SearchText text)
        {
            try
            {
                if (text != null)
                {
                    var movie = await _mongoRepository.GetManyByText(text.Text);
                    return movie;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        [HttpPatch]
        [Route("api/Mongo/InsertOneDoc/")]
        public async Task<bool> InsertOneDoc([FromBody] Movie movie)
        {
            try
            {
                return await _mongoRepository.InsertOneDoc(movie);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("api/Mongo/InsertManyDocs/")]
        public async Task<long> InsertManyDocs([FromBody] ICollection<Movie> movies)
        {
            try
            {
                return await _mongoRepository.InsertManyDocs(movies);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpPatch]
        [Route("api/Mongo/UpdateOneDoc/{objId}")]
        public async  Task<bool> UpdateOneDoc(string objId, [FromBody] Movie movie)
        {
            try
            {
                return await _mongoRepository.UpdateOneDoc(objId, movie);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
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
                if (text != null)
                {
                    return await _mongoRepository.DeleteManyConsistValue(text.Text);
                }

                return 0;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}