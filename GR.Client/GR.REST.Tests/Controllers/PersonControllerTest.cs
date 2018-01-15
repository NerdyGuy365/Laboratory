using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GR.REST;
using GR.REST.Controllers;
using System;
using GR.Business;
using GR.Data;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using GR.Contracts.DataContracts;

namespace GR.REST.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        /// <summary>
        /// The following helper method is used to clear out the xml persistence store.
        /// </summary>
        private void ClearPeople()
        {
            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\FileStructure.txt";
            string fileSave = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonRepository_XML_Persistence dataStrategy = new PersonRepository_XML_Persistence(fileSave);
            var people = PersonHelpers.ParsePersonDataFromFile(fileLoad);

            //Conduct Test Experiment.
            try
            {
                dataStrategy.ClearPeople();
            }
            catch 
            {
                //Do nothing... This is just clearing the data.
            }
        }

        /// <summary>
        /// The following helper method is used to create the data in the xml persistenc store.
        /// </summary>
        private string SavePeople()
        {
            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\FileStructure.txt";
            string fileSave = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonRepository_XML_Persistence dataStrategy = new PersonRepository_XML_Persistence(fileSave);
            var people = PersonHelpers.ParsePersonDataFromFile(fileLoad);

            //Conduct Test Experiment.
            dataStrategy.ClearPeople();
            var results = dataStrategy.SavePeople(people);

            //Return results.
            return results;
        }

        /// <summary>
        /// The following unit test will ensure data is saved correctly.
        /// </summary>
        [TestMethod()]
        public void Did_People_Save_Correctly()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\FileStructure.txt";
            string fileSave = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonController controller = new PersonController(fileSave);
            var people = PersonHelpers.ParsePersonDataFromFile(fileLoad);

            //Conduct Test Experiment.
            var results = (OkNegotiatedContentResult<string>)controller.SavePeople(people);

            //Determine Test Results

            //Make sure we have results.
            if (results == null || string.IsNullOrEmpty(results.Content))
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Make sure we got a success result back.
            Assert.IsTrue(results.Content.ToUpper() == "SUCCESS");
        }

        /// <summary>
        /// The following unit test will ensure data is saved correctly.
        /// </summary>
        [TestMethod()]
        public void Did_Person_Save_Correctly()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\FileStructure.txt";
            string fileSave = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonController controller = new PersonController(fileSave);
            var people = PersonHelpers.ParsePersonDataFromFile(fileLoad);

            //Conduct Test Experiment.
            var results = (OkNegotiatedContentResult<string>)controller.SavePerson(people[0]);

            //Determine Test Results

            //Make sure we have results.
            if (results == null || string.IsNullOrEmpty(results.Content))
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Make sure we got a success result back.
        }

        /// <summary>
        /// The following unit test will ensure that our business logic is working correctly.
        /// </summary>
        [TestMethod]
        public void Is_BirthDates_Sorted_Correctly()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //First we must ensure we have some data to work with.
            SavePeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonController controller = new PersonController(fileLoad);

            //Conduct Test Experiment.
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

        /// <summary>
        /// The following unit test will ensure that our business logic is working correctly.
        /// </summary>
        [TestMethod()]
        public void Is_Genders_Sorted_Correctly()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //First we must ensure we have some data to work with.
            SavePeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonController controller = new PersonController(fileLoad);

            //Conduct Test Experiment.
            var results = (OkNegotiatedContentResult<List<Person>>)controller.GetGenders();

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Content.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Since we can control the testing data.
            //We need to make sure the data is sorted by gender female first.
            //So let's check the first, second and third items in the list.
            Assert.IsTrue((results.Content[0].Gender == "Female" && results.Content[0].LastName == "Doe") && results.Content[1].Gender == "Female" && results.Content[2].Gender == "Male");
        }

        /// <summary>
        /// The following unit test will ensure that our business logic is working correctly.
        /// </summary>
        [TestMethod()]
        public void Is_Names_Sorted_Correctly()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //First we must ensure we have some data to work with.
            SavePeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonController controller = new PersonController(fileLoad);

            //Conduct Test Experiment.
            var results = (OkNegotiatedContentResult<List<Person>>)controller.GetNames();

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Content.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Since we can control the testing data.
            //We need to make sure the data is sorted by last name desc.
            //So let's check the first.
            Assert.IsTrue(results.Content[0].LastName == "Smith");
        }
    }
}
