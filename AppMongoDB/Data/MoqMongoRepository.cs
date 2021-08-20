using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMongoDB.Data
{
    public class MoqMongoRepository : IMongoRepository
    {
        public IList<object> MoqData { get; private set; } = new List<object>();

        public MoqMongoRepository()
        {
            MoqData.Add(new
            {
                ObId = 1,
                ObName = "Object nr 1"
            });
            MoqData.Add(new
            {
                ObId = 2,
                ObName = "Object nr 2"
            });
            MoqData.Add(new
            {
                ObId = 3,
                ObName = "Object nr 3"
            });
        }

        public IList<object> GetData()
        {
            return MoqData;
        }
    }
}