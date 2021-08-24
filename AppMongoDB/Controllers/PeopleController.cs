using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AppMongoDB.Data;
using AppMongoDB.Models;

namespace AppMongoDB.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly MoqDataStore _moqData;

        public PeopleController(MoqDataStore moqData)
        {
            _moqData = moqData;
        }

        // GET api/<controller>
        public IList<Person> Get()
        {
            return _moqData.People;
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            return _moqData.People.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody] Person valuePerson)
        {
            int maxId = 0;

            if (_moqData.People.Any())
            {
                maxId = _moqData.People.Where(x => x.Id > 0).Max(x => x.Id);
            }

            valuePerson.Id = maxId + 1;
            _moqData.People.Add(valuePerson);
        }

        // DELETE api/<controller>/5
        public object Delete(int id)
        {
            var person = _moqData.People.FirstOrDefault(x => x.Id == id);

            if (person != null)
            {
                var index = _moqData.People.IndexOf(person);
                _moqData.People.RemoveAt(index);

                return new {Status = $"Person with ID {id} was removed"};
            }

            return new { Status = $"Person with ID {id} dose not exists" };
        }

        [HttpGet]
        [Route("api/People/GetAllFirstNames")]
        public IList<string> GatAllFirstNames()
        {
            var namesList = new List<string>();

            if (_moqData.People.Any())
            {
                foreach (var person in _moqData.People)
                {
                    namesList.Add(person.FirstName);
                }
            }

            return namesList;
        }

        [HttpPost]
        [Route("api/People/GetAllLastNames")]
        public IList<string> GatAllLastNames()
        {
            var namesList = new List<string>();

            if (_moqData.People.Any())
            {
                foreach (var person in _moqData.People)
                {
                    namesList.Add(person.LastName);
                }
            }

            return namesList;
        }

        [HttpGet]
        [Route("api/People/GetAge/{age:int}")]
        public IList<Person> GatAge(int age)
        {
            var ageList = new List<Person>();

            if (_moqData.People.Any())
            {
                var people = _moqData.People.Where(x => x.Age == age);
                ageList.AddRange(people);
            }

            return ageList;
        }
    }
}