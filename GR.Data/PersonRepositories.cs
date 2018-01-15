using GR.Common;
using GR.Contracts.DataContracts;
using GR.Data.DataRepository_Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace GR.Data
{
    /// <summary>
    /// The following stragety will be used to handle persistening data via SQL database.
    /// </summary>
    public class PersonRepository_SQL_Persistence : IPersonDataRepository
    {
        //Grab the connection string information from the app.config of the client.
        private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        /// <summary>
        /// Used to get a listing of people sorted by genders, birth dates and last names.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeople(SortBy sortBy)
        {
            //Local variables.
            List<Person> people = new List<Person>();
            StringBuilder query = new StringBuilder();

            #region Query

            //Begin building our SQL query to tell the database what data do we need.
            query.Append("Select FirstName, LastName, Gender, FavoriteColor, DateOfBirth From Person Order By ");

            //In the name of the factory pattern. Determine how we are going to sort.
            switch (sortBy)
            {
                case SortBy.Genders:
                    query.Append("Gender ASC, LastName ASC");

                    break;

                case SortBy.BirthDates:
                    query.Append("DateOfBirth ASC");

                    break;

                case SortBy.LastNames:
                    query.Append("LastName DESC");

                    break;
            }

            #endregion

            #region Data Access

            //Prepare opening a connection to our database.
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    //Let's offically open a connection.
                    connection.Open();

                    //Setup our SQL command.
                    SqlCommand command = new SqlCommand(query.ToString(), connection);
                    SqlDataReader reader = command.ExecuteReader();

                    //Now hit the database and bring back our data.
                    while (reader.Read())
                    {
                        Person person = new Person();

                        person.FirstName = "" + reader["FirstName"];
                        person.LastName = "" + reader["LastName"];
                        person.Gender = "" + reader["Gender"];
                        person.FavoriteColor = "" + reader["FavoriteColor"];
                        person.DateOfBirth = (DateTime)reader["DateOfBirth"];

                        people.Add(person);
                    }
                }
                catch
                {
                    //ADD SUPPORT HANDLING CODE HERE.

                    //Now throw the exception.
                    throw new Exception("There was a problem accessing the data. Support has been notified.");
                }
            }

            #endregion

            //Return listing of people.
            return people;
        }

        /// <summary>
        /// Used to save a new person.
        /// </summary>
        /// <returns></returns>
        public string SavePeople(List<Person> people)
        {
            //Save each person one by one.
            foreach (var person in people)
                SavePerson(person);

            //For demo purposes. We are just returning success.
            return "Success";
        }

        /// <summary>
        /// Used to save a listing of people.
        /// </summary>
        /// <returns></returns>
        public string SavePerson(Person person)
        {
            #region Query

            StringBuilder query = new StringBuilder();

            query.Append("INSERT INTO Person (FirstName, LastName, Gender, FavoriteColor, DateOfBirth) VALUES ('" + person.FirstName + "','" + person.LastName + "','" + person.Gender + "','" + person.DateOfBirth.ToString("M/d/yyyy", CultureInfo.InvariantCulture) + "'");

            #endregion

            #region Data Access

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {              
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query.ToString(), connection);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    //ADD SUPPORT HANDLING CODE HERE.

                    //Now throw the exception.
                    throw new Exception("There was a problem saving the data. Support has been notified.");
                }
            }

            #endregion

            //For demo purposes. We are just returning success.
            return "Success";
        }
    }

    /// <summary>
    /// The following stragety will be used to handle persistening data via XML data source.
    /// 
    /// FOR THIS DEMO...THIS IS OUR DEFAULT DATA SOURCE.
    /// </summary>
    public class PersonRepository_XML_Persistence : IPersonDataRepository
    {
        //Declare form scope variables.
        private string _persistencePath = "";

        public PersonRepository_XML_Persistence()
        {

        }

        /// <summary>
        /// Allow the caller of the data repository xml persistence stragety to be able to set the xml data source location manually.
        /// </summary>
        /// <param name="persistencePath"></param>
        public PersonRepository_XML_Persistence(string persistencePath)
        {
            _persistencePath = persistencePath;
        }

        /// <summary>
        /// Pull out the people related content from our xml data source.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public List<Person> GetPeople(SortBy sortBy)
        {
            //Local variables.
            List<Person> people = new List<Person>();            
            var serializer = new XmlSerializer(typeof(List<Person>));

            string filePath = "";

            if (!string.IsNullOrEmpty(_persistencePath))
            {
                filePath = _persistencePath;
            }
            else
            {
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/Demo.xml");
            }

            //Get a link to our xml data source.
            try
            {
                using (var reader = XmlReader.Create(filePath))
                {
                    //Pull out the xml string content from the file.
                    //Turn it back to a strongly type object.
                    people = (List<Person>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Return results.
            return people;
        }

        /// <summary>
        /// Used to save a new person.
        /// </summary>
        /// <returns></returns>
        public string SavePerson(Person person)
        {
            //Local variables.
            var serializer = new XmlSerializer(person.GetType());

            string filePath = "";

            if (!string.IsNullOrEmpty(_persistencePath))
            {
                filePath = _persistencePath;
            }
            else
            {
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/Demo.xml");
            }

            //Get a link to our xml data source.
            try
            {
                using (var writer = XmlWriter.Create(filePath))
                {
                    //Serialize the person to xml in the xml file.
                    serializer.Serialize(writer, person);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //For demo purposes. We are just returning success.
            return "Success";
        }

        /// <summary>
        /// Used to save a listing of people.
        /// </summary>
        /// <returns></returns>

        public string SavePeople(List<Person> people)
        {
            //Local variables.
            var serializer = new XmlSerializer(people.GetType());

            string filePath = "";

            if (!string.IsNullOrEmpty(_persistencePath))
            {
                filePath = _persistencePath;
            }
            else
            {
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/Demo.xml");
            }

            //Get a link to our xml data source.
            using (var writer = XmlWriter.Create(filePath))
            {
                //Serialize the listing of people to xml in the xml file.
                serializer.Serialize(writer, people);
            }

            //For demo purposes. We are just returning success.
            return "Success";
        }

        public string ClearPeople()
        {
            //Local variables.
            string filePath = "";
            var serializer = new XmlSerializer(this.GetType());

            if (!string.IsNullOrEmpty(_persistencePath))
            {
                filePath = _persistencePath;
            }
            else
            {
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/Demo.xml");
            }

            try
            {
                //Get a link to our xml data source.
                System.IO.File.WriteAllBytes(filePath, new byte[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //For demo purposes. We are just returning success.
            return "Success";
        }
    }
}
