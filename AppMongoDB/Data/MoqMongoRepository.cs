using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMongoDB.Data
{
    public class MoqMongoRepository : IMongoRepository
    {
        public IList<Car> MoqData { get; } = new List<Car>();

        public MoqMongoRepository()
        {
            MoqData.Add(new Car { Brand = "Opel", Color = "Red", MaxSpeed = 120 });
            MoqData.Add(new Car { Brand = "Fiat", Color = "Blue", MaxSpeed = 140 });
            MoqData.Add(new Car { Brand = "Honda", Color = "White", MaxSpeed = 160 });
        }

        public IList<Car> GetData()
        {
            return MoqData;
        }
    }

    public class Car
    {
        public string Brand { get; set; }

        public string Color { get; set; }

        public int MaxSpeed { get; set; }
    }
}