using GR.Contracts.DataContracts;
using GR.Data;
using GR.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GR.Client.Console.SelfHostingREST
{
    /// <summary>
    /// The purpose of this class is to handle incoming request from a client.
    /// </summary>
    public class PersonREST : ApiController
    {
        //Form scope variables
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Records/Birthdate")]
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
        [Route("Records/Gender")]
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
        [Route("Records/Name")]
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
        [Route("Records")]
        public void SavePerson([FromBody]Person person)
        {
            _people.Add(person);
        }
    }
}
