﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppMongoDB.Models;

namespace AppMongoDB.Data
{
    public static class MoqDataStore
    {
        public static IList<Person> People = GeneratePersons();
        //public static IList<Person> People = new List<Person>();

        private static IList<Person> GeneratePersons()
        {
            var personArray = new string[]
            {
                "Jan Kowalski",
                "Stefan Batory",
                "Anna Winnicka",
                "Bartosz Jarząbek",
                "Eliza Orzeszkowa",
                "Henryk Sienkiewicz",
                "Adam Słodowy"
            };

            var people = new List<Person>();
            Person person = null;

            for (int i = 0; i < personArray.Length; i++)
            {
                var personNames = personArray[i].Split(' ');

                if (personNames.Length == 2)
                {
                    person = new Person
                    {
                        Id = i + 1,
                        FirstName = personNames[0],
                        LastName = personNames[1]

                    };
                }

                people.Add(person);
            }

            return people;
        }
    }
}