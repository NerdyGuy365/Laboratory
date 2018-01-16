using System;
using System.Collections.Generic;
using GR.Contracts.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GR.Client.Console.Tests
{
    [TestClass]
    public class RecordsControllerTests
    {        
        private List<Person> GetDummyData()
        {
            var people = new List<Person>();

            people.Add(new Person { FirstName = "Ali", LastName = "Baba", DateOfBirth = Convert.ToDateTime("01/01/1979"), FavoriteColor = "Red", Gender = "Male" });
            people.Add(new Person { FirstName = "Baba", LastName = "Clark", DateOfBirth = Convert.ToDateTime("01/01/1980"), FavoriteColor = "Blue", Gender = "Male" });
            people.Add(new Person { FirstName = "Clark", LastName = "Dawson", DateOfBirth = Convert.ToDateTime("01/01/1981"), FavoriteColor = "Green", Gender = "Male" });
            people.Add(new Person { FirstName = "Dawson", LastName = "Ells", DateOfBirth = Convert.ToDateTime("01/01/1982"), FavoriteColor = "Orange", Gender = "Male" });
            people.Add(new Person { FirstName = "Ells", LastName = "Falon", DateOfBirth = Convert.ToDateTime("01/01/1983"), FavoriteColor = "Purple", Gender = "Male" });
            people.Add(new Person { FirstName = "Falon", LastName = "Ginny", DateOfBirth = Convert.ToDateTime("01/01/1984"), FavoriteColor = "Silver", Gender = "Male" });

            people.Add(new Person { FirstName = "Ginny", LastName = "Helena", DateOfBirth = Convert.ToDateTime("01/01/1985"), FavoriteColor = "Yellow", Gender = "Female" });
            people.Add(new Person { FirstName = "Helena", LastName = "Illana", DateOfBirth = Convert.ToDateTime("01/01/1986"), FavoriteColor = "White", Gender = "Female" });
            people.Add(new Person { FirstName = "Illana", LastName = "Jane", DateOfBirth = Convert.ToDateTime("01/01/1987"), FavoriteColor = "Black", Gender = "Female" });
            people.Add(new Person { FirstName = "Jane", LastName = "Kelly", DateOfBirth = Convert.ToDateTime("01/01/1988"), FavoriteColor = "Maroon", Gender = "Female" });
            people.Add(new Person { FirstName = "Kelly", LastName = "Linda", DateOfBirth = Convert.ToDateTime("01/01/1989"), FavoriteColor = "Sky Blue", Gender = "Female" });
            people.Add(new Person { FirstName = "Linda", LastName = "Molly", DateOfBirth = Convert.ToDateTime("01/01/1990"), FavoriteColor = "Navy Blue", Gender = "Female" });

            return people;
        }

        [TestMethod()]
        public void Does_Save_Person_Store_Items_Without_Error()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Setup test.
            var people = GetDummyData().Take(2); //Let's only take 2 for our test.

            //Conduct Test Experiment.
            foreach (var person in people)
                controller.SavePerson(person);
        }
    }
}
