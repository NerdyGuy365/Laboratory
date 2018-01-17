using System;
using System.Collections.Generic;
using GR.Contracts.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

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
            Person person = (Person)GetDummyData().Take(1).Select(s => s).SingleOrDefault(); //Let's only one for our test.

            //Conduct Test Experiment.
            CreatedNegotiatedContentResult<List<Person>> result = (CreatedNegotiatedContentResult<List<Person>>)controller.SavePerson(person);

            //Make sure we got a success result back.
            Assert.IsTrue(result.Content != null && result.Content.Count > 0);
        }

        [TestMethod()]
        public void Does_Save_Person_Store_Items_Fail()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.
            ExceptionResult result = (ExceptionResult)controller.SavePerson(null);
            
            //Make sure we got a success result back.
            Assert.IsTrue(result.Exception != null);
        }

        [TestMethod()]
        public void Is_BirthDates_Sorted_Correctly()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.
            List<Person> people = (List<Person>)GetDummyData();

            controller.SavePerson(people[0]);
            controller.SavePerson(people[1]);
            controller.SavePerson(people[2]);
            controller.SavePerson(people[3]);
            controller.SavePerson(people[4]);
            controller.SavePerson(people[5]);
            controller.SavePerson(people[6]);
            controller.SavePerson(people[7]);
            controller.SavePerson(people[8]);
            controller.SavePerson(people[9]);
            controller.SavePerson(people[10]);
            controller.SavePerson(people[11]);

            var results = (OkNegotiatedContentResult<List<Person>>)controller.GetBirthDates();

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Content.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Since we can control the testing data.
            //We need to make sure the data is sorted by birth ascending.
            //So let's check the first and last birthdates to ensure this.
            Assert.IsTrue(results.Content[0].DateOfBirth.ToShortDateString() == "1/1/1979" && results.Content[4].DateOfBirth.ToShortDateString() == "1/1/1983");
        }

        [TestMethod()]
        public void Is_BirthDates_Sorted_Fail()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.         
            ExceptionResult result = (ExceptionResult)controller.GetBirthDates();

            //Determine Test Results

            //Make sure we got a success result back.
            Assert.IsTrue(result.Exception != null);
        }

        [TestMethod()]
        public void Is_Genders_Sorted_Correctly()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.
            List<Person> people = (List<Person>)GetDummyData(); 

            controller.SavePerson(people[0]);
            controller.SavePerson(people[1]);
            controller.SavePerson(people[2]);
            controller.SavePerson(people[3]);
            controller.SavePerson(people[4]);
            controller.SavePerson(people[5]);
            controller.SavePerson(people[6]);
            controller.SavePerson(people[7]);
            controller.SavePerson(people[8]);
            controller.SavePerson(people[9]);
            controller.SavePerson(people[10]);
            controller.SavePerson(people[11]);

            var results = (OkNegotiatedContentResult<List<Person>>)controller.GetGenders();

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Content.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Since we can control the testing data.
            //We need to make sure the data is sorted by gender female first.
            //So let's check the first one which should be female.
            //The fifth one should start the males.
            Assert.IsTrue((results.Content[0].Gender == "Female" && results.Content[0].LastName == "Helena") && results.Content[6].Gender == "Male");
        }

        [TestMethod()]
        public void Is_Genders_Sorted_Fail()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.         
            ExceptionResult result = (ExceptionResult)controller.GetGenders();

            //Determine Test Results

            //Make sure we got a success result back.
            Assert.IsTrue(result.Exception != null);
        }

        [TestMethod()]
        public void Is_Names_Sorted_Correctly()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.
            List<Person> people = (List<Person>)GetDummyData();

            controller.SavePerson(people[0]);
            controller.SavePerson(people[1]);
            controller.SavePerson(people[2]);
            controller.SavePerson(people[3]);
            controller.SavePerson(people[4]);
            controller.SavePerson(people[5]);
            controller.SavePerson(people[6]);
            controller.SavePerson(people[7]);
            controller.SavePerson(people[8]);
            controller.SavePerson(people[9]);
            controller.SavePerson(people[10]);
            controller.SavePerson(people[11]);

            var results = (OkNegotiatedContentResult<List<Person>>)controller.GetNames();

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Content.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Since we can control the testing data.
            //We need to make sure the data is sorted by last name desc.
            //So let's check the first.
            Assert.IsTrue(results.Content[0].LastName == "Molly");
        }

        [TestMethod()]
        public void Is_Names_Sorted_Fail()
        {
            //Local variables.
            RecordsController controller = new RecordsController();

            //Conduct Test Experiment.         
            ExceptionResult result = (ExceptionResult)controller.GetNames();

            //Determine Test Results

            //Make sure we got a success result back.
            Assert.IsTrue(result.Exception != null);
        }
    }
}
