using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GR.Common;
using GR.Business;

namespace GR.Data.Tests
{
    /// <summary>
    /// The following class is used to test the data repository.
    /// </summary>
    [TestClass]
    public class PersonDataRepositoryTests
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
        /// The following test ensures we can correctly clear out our persistence xml data.
        /// </summary>
        [TestMethod()]
        public void Did_XML_Persistence_Clear_People_Data_Work()
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

            //Determine Test Results
            try
            {
                var results = dataStrategy.GetPeople(SortBy.BirthDates);

                //If the code lands here that's because no expection was generated.
                //We will assume the data strategy returned data.
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                //Pass the test. Because if it lands here.
                //We know there wasn't any data.
                Assert.IsTrue(true);
            }            
        }

        /// <summary>
        /// The following unit test will ensure data is saved correctly.
        /// </summary>
        [TestMethod()]
        public void Did_XML_Persistence_Save_People_Data_Work()
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

            //Determine Test Results

            //Make sure we have results.
            if (string.IsNullOrEmpty(results))
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Make sure we got a success result back.
            Assert.IsTrue(results.ToUpper() == "SUCCESS");
        }

        /// <summary>
        /// The following unit test will ensure data is saved correctly.
        /// </summary>
        [TestMethod()]
        public void Did_XML_Persistence_Save_Person_Data_Work()
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
            var results = dataStrategy.SavePerson(people[1]);

            //Determine Test Results

            //Make sure we have results.
            if (string.IsNullOrEmpty(results))
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Make sure we got a success result back.
            Assert.IsTrue(results.ToUpper() == "SUCCESS");
        }

        /// <summary>
        /// The following unit test will ensure data is saved correctly.
        /// </summary>
        [TestMethod()]
        public void Did_XML_Persistence_Return_Data_Work()
        {
            //We must clear out the persistence store first before we begin testing.
            ClearPeople();

            //First we must ensure we have some data to work with.
            SavePeople();

            //Local variables.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileLoad = path + @"\LocalData\FileStructure.txt";
            string fileSave = path + @"\LocalData\Demo.xml";

            //Setup Test
            PersonRepository_XML_Persistence dataStrategy = new PersonRepository_XML_Persistence(fileSave);

            //Conduct Test Experiment.
            var results = dataStrategy.GetPeople(SortBy.BirthDates);

            //Determine Test Results

            //Make sure we have results.
            if (results == null || results.Count == 0)
                Assert.IsTrue(true == false); //Test fails automatically with no data.

            //Make sure we at least got some strongly type data back.
            Assert.IsTrue(results.Count > 0);
        }        
    }
}
