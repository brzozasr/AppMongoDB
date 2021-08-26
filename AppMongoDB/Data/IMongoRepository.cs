using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMongoDB.Models.Movie;
using MongoDB.Bson;

namespace AppMongoDB.Data
{
    public interface IMongoRepository<T> where T : class
    {
        Task<IList<T>> GetAllData(int limit, int skip);

        Task<T> GetByObjectId(string objId);

        Task<IEnumerable<Movie>> GetManyByFieldWithInt(string fieldName, int? fieldValue);
        
        Task<IEnumerable<Movie>> GetManyByText(string searchedText);

        Task<bool> DeleteById(string objId);

        Task<long> DeleteManyConsistValue(string fieldValue);

        Task<bool> InsertOneDoc(T document);

        Task<long> InsertManyDocs(ICollection<Movie> documents);

        Task<bool> UpdateOneDoc(string objId, T document);
    }
    
}
