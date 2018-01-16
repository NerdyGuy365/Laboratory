using GR.Contracts.DataContracts;
using GR.Data;
using GR.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GR.Client.Console
{
    /// <summary>
    /// The purpose of this class is to handle incoming request from a client.
    /// </summary>
    public class RecordsController : ApiController
    {
        //Form scope variables
        private static List<Person> _people = new List<Person>();

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Birthdates")]
        public List<Person> GetBirthDates()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.
            if (_people == null || _people.Count == 0) throw new Exception("No records found");

            //Get results and sort correctly. 
            return _people.OrderBy(p => p.DateOfBirth).ToList();
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Genders")]
        public List<Person> GetGenders()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.l
            if (_people == null || _people.Count == 0) throw new Exception("No records found");

            //Get results and sort correctly.
            return _people.OrderBy(p => p.Gender).ThenBy(l => l.LastName).ToList();
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Names")]
        public List<Person> GetNames()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.
            if (_people == null || _people.Count == 0) throw new Exception("No records found");

            //Get results and sort correctly.
            return _people.OrderByDescending(p => p.LastName).ToList();
        }

        /// <summary>
        /// Used to save a person.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void SavePerson([FromBody]Person person)
        {
            _people.Add(person);
        }
    }
}
