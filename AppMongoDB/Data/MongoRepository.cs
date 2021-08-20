using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMongoDB.Data
{
    public class MongoRepository : IMongoRepository
    { 
        IList<Car> IMongoRepository.GetData()
        {
            throw new NotImplementedException();
        }
    }
}