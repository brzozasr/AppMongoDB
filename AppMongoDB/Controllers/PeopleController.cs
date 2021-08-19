using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.Models;

namespace AppMongoDB.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/<controller>
        public IList<Person> Get()
        {
            return MoqDataStore.People;
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            return MoqDataStore.People.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody] Person valuePerson)
        {
            int maxId = 0;

            if (MoqDataStore.People.Any())
            {
                maxId = MoqDataStore.People.Where(x => x.Id > 0).Max(x => x.Id);
            }

            valuePerson.Id = maxId + 1;
            MoqDataStore.People.Add(valuePerson);
        }

        // DELETE api/<controller>/5
        public object Delete(int id)
        {
            var person = MoqDataStore.People.FirstOrDefault(x => x.Id == id);

            if (person != null)
            {
                var index = MoqDataStore.People.IndexOf(person);
                MoqDataStore.People.RemoveAt(index);

                return new {Status = $"Person with ID {id} was removed"};
            }

            return new { Status = $"Person with ID {id} dose not exists" };
        }

    }
}