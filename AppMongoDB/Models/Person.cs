using System;

namespace AppMongoDB.Models
{
    public class Person
    {
        public int Id { get; set; } = 0;

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public int? Age { get; set; } = null;
    }
}