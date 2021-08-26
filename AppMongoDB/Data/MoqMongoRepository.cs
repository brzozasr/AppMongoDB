using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using AppMongoDB.Models.Movie;
using MongoDB.Bson;

namespace AppMongoDB.Data
{
    public class MoqMongoRepository : IMongoRepository<Movie>
    {
        public IList<Movie> MoqData { get; } = new List<Movie>();

        public MoqMongoRepository()
        {
            Random rnd = new Random();
            MoqData.Add(
            new Movie
                {
                    MovieId = ObjectId.GenerateNewId(),
                    Title = "High and Dizzy",
                    Description = "A tipsy doctor encounters his patient sleepwalking on a building ledge, high above the street.",
                    FullDescription = "After a long wait, a young doctor finally has a patient come to his office. She is a young woman whose father has brought her to be treated for sleep-walking, but the father becomes annoyed with the doctor, and takes his daughter away. Soon afterward, the young doctor shares in a drinking binge with another doctor who has built a still in his office. After a series of misadventures, the two of them wind up in the same hotel where the daughter and her father are staying, leading to some hazardous predicaments.",
                    Released = new DateTime(rnd.Next(1950, 2021), rnd.Next(1, 13), rnd.Next(1, 29)),
                    Year = rnd.Next(1950, 2021).ToString(),
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BODliMjc3ODctYjhlOC00MDM5LTgzNmUtMjQ1MmViNDQ0NzlhXkEyXkFqcGdeQXVyNTM3MDMyMDQ@._V1_SY1000_SX677_AL_.jpg",
                    Type = "movie",
                    Genres = new List<string> { "Comedy", "Short" },
                    Cast = new List<string> {"Lon Chaney", "Leatrice Joy", "John Bowers", "Hardee Kirkland"},
                    Languages = new List<string> {"English", "Polish"},
                    Directors = new List<string> { "Charles Chaplin" },
                    Writers = new List<string> { "Charles Chaplin" },
                    Countries = new List<string> {"USA"},
                    MovieAwards = new Awards {Wins = 1, Nominations = 0, NominationsDescription = "1 win."}
            });
            MoqData.Add(
                new Movie
                {
                    MovieId = ObjectId.GenerateNewId(),
                    Title = "The Strong Man",
                    Description = "A meek Belgian soldier (Harry Langdon) fighting in World War I receives penpal letters and a photo from \"Mary Brown\", an American girl he has never met. He becomes infatuated with her by ...",
                    FullDescription = "A meek Belgian soldier (Harry Langdon) fighting in World War I receives penpal letters and a photo from \"Mary Brown\", an American girl he has never met. He becomes infatuated with her by long distance. After the war, the young Belgian journeys to America as assistant to a theatrical \"strong man\", Zandow the Great (Arthur Thalasso). While in America, he searches for Mary Brown... and he finds her, just as word comes that Zandow is incapacitated and the little nebbish must go on stage in his place.",
                    Released = new DateTime(rnd.Next(1950, 2021), rnd.Next(1, 13), rnd.Next(1, 29)),
                    Year = rnd.Next(1950, 2021).ToString(),
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTYyMjE0OTQ2NF5BMl5BanBnXkFtZTcwNTUxMDIzMQ@@._V1_SY1000_SX677_AL_.jpg",
                    Type = "movie",
                    Genres = new List<string> { "Comedy", "Drama" },
                    Cast = new List<string> { "Harry Langdon", "Priscilla Bonner", "Gertrude Astor", "William V. Mong" },
                    Languages = new List<string> { "English", "Belgian" },
                    Directors = new List<string> { "Frank Capra" },
                    Writers = new List<string> { "Arthur Ripley (story)", "Hal Conklin (adapted by)", "Robert Eddy (adapted by)", "Reed Heustis (titles by)", "Clarence Hennecke (adaptation)", "James Langdon (adaptation)", "Tim Whelan (adaptation)" },
                    Countries = new List<string> { "USA" },
                    MovieAwards = new Awards { Wins = 1, Nominations = 0, NominationsDescription = "1 win." }
                });
            MoqData.Add(
                new Movie
                {
                    MovieId = ObjectId.GenerateNewId(),
                    Title = "Sunrise",
                    Description = "A married farmer falls under the spell of a slatternly woma\n from the city, who tries to convince him to drown his wife.",
                    FullDescription = "In this fable-morality subtitled \"A Song of Two Humans\", the \"evil\" temptress is a city woman who bewitches farmer Anses and tries to convince him to murder his neglected wife, Indre.",
                    Released = new DateTime(rnd.Next(1950, 2021), rnd.Next(1, 13), rnd.Next(1, 29)),
                    Year = rnd.Next(1950, 2021).ToString(),
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDVkYmYwM2ItNzRiMy00NWQ4LTlhMjMtNDI1ZDYyOGVmMzJjXkEyXkFqcGdeQXVyNTgzMzU5MDI@._V1_SY1000_SX677_AL_.jpg",
                    Type = "movie",
                    Genres = new List<string> { "Drama", "Romance" },
                    Cast = new List<string> { "George O'Brien", "Janet Gaynor", "Margaret Livingston", "Bodil Rosing" },
                    Languages = new List<string> { "English", "French" },
                    Directors = new List<string> { "F.W. Murnau" },
                    Writers = new List<string> { "Carl Mayer (scenario)", "Hermann Sudermann (from an original theme by)", "Katherine Hilliker (titles)", "H.H. Caldwell (titles)" },
                    Countries = new List<string> { "USA", "France" },
                    MovieAwards = new Awards { Wins = 5, Nominations = 1, NominationsDescription = "Won 3 Oscars. Another 2 wins & 1 nomination." }
                });
        }

        public async Task<IList<Movie>> GetAllData(int limit, int skip)
        {
            var task = Task.Run(() => MoqData);
            await Task.CompletedTask;
            return task.Result;
        }

        public Task<Movie> GetByObjectId(string objId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetManyByFieldWithInt(string fieldName, int? fieldValue)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetManyByText(string searchedText)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(string objId)
        {
            throw new NotImplementedException();
        }

        public Task<long> DeleteManyConsistValue(string fieldValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertOneDoc(Movie document)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertManyDocs(ICollection<Movie> documents)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneDoc(string objId, Movie document)
        {
            throw new NotImplementedException();
        }
    }
}