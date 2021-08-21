using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMongoDB.Data
{
    public interface IMongoRepository<T> where T : class
    {
        Task<IList<T>> GetAllData();

        Task<T> GetById(long id);

        Task<T> GetByValue<T2>(string fieldName, T2 fieldValue);

        Task<bool> DeleteById(long id);

        Task<bool> DeleteByValue<T3>(string fieldName, T3 fieldValue);

        Task<bool> InsertDoc(T document);

        Task<bool> UpdateDoc<T4>(T document, Dictionary<string, T4> values);
    }
    
}
