using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppMongoDB.Models.Movie;

namespace AppMongoDB.Data
{
    public class MoqMongoRepository : IMongoRepository<Movie>
    {
        public IList<Movie> MoqData { get; } = new List<Movie>();

        public MoqMongoRepository()
        {
            
        }

        public Task<IList<Movie>> GetAllData()
        {
            throw new NotImplementedException();
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