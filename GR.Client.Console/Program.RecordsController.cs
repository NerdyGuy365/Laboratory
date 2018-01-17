using GR.Contracts.DataContracts;

using System;
using System.Collections.Generic;
using System.Linq;

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
        public IHttpActionResult GetBirthDates()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.
            if (_people == null || _people.Count == 0) return InternalServerError(new Exception("No records found"));

            //Get results and sort correctly.

            //Return back 200.
            return Ok(_people.OrderBy(p => p.DateOfBirth).ToList());
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Genders")]
        public IHttpActionResult GetGenders()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.l
            if (_people == null || _people.Count == 0) return InternalServerError(new Exception("No records found"));

            //Get results and sort correctly.

            //Return back 200.
            return Ok(_people.OrderBy(p => p.Gender).ThenBy(l => l.LastName).ToList());
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Names")]
        public IHttpActionResult GetNames()
        {
            //Make sure we have something to return.
            //Let the client know if we don't.
            if (_people == null || _people.Count == 0) return InternalServerError(new Exception("No records found"));

            //Get results and sort correctly.

            //Return back 200.
            return Ok(_people.OrderByDescending(p => p.LastName).ToList());
        }

        /// <summary>
        /// Used to save a person.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SavePerson([FromBody]Person person)
        {
            //Make sure person is something.
            if (person == null) return InternalServerError(new Exception("Please pass in valid data"));

            //Add to in memory static collection.
            _people.Add(person);

            //Return back 201.
            return Created("",_people);
        }
    }
}
