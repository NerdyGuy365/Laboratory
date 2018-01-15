using GR.Business;
using GR.Common;
using GR.Contracts.DataContracts;
using GR.Contracts.ServiceContracts;
using GR.Data;
using GR.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GR.REST.Controllers
{
    /// <summary>
    /// The purpose of this class is to handle incoming request from a client.
    /// </summary>
    public class PersonController : ApiController
    {
        //Form scope variables
        private PersonManager _personManager;

        public PersonController()
        {
            //We can grab security information during the request from the client here.
            _personManager = new PersonManager("", "", new PersonRepository_XML_Persistence());
        }

        public PersonController(string persistencePath)
        {
            //We can grab security information during the request from the client here.
            _personManager = new PersonManager("", "", new PersonRepository_XML_Persistence(persistencePath));
        }

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Records/Birthdates")]
        public IHttpActionResult GetBirthDates()
        {
            try
            {
                return Ok(_personManager.GetBirthDates());
            }
            catch
            {
                //Return back data to the calling client.
                return InternalServerError(new Exception("Something unexpected has occurred...Support has been notified."));
            }
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Records/Genders")]
        public IHttpActionResult GetGenders()
        {
            try
            {
                return Ok(_personManager.GetGenders());
            }
            catch 
            {
                //Return back data to the calling client.
                return InternalServerError(new Exception("Something unexpected has occurred...Support has been notified."));
            }
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Records/Names")]
        public IHttpActionResult GetNames()
        {
            try
            {
                return Ok(_personManager.GetNames());
            }
            catch
            {
                //Return back data to the calling client.
                return InternalServerError(new Exception("Something unexpected has occurred...Support has been notified."));
            }
        }

        /// <summary>
        /// Used to save a person.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Records")]
        public IHttpActionResult SavePerson([FromBody]Person person)
        {
            try
            {
                return Ok(_personManager.SavePerson(person));
            }
            catch
            {
                //Return back data to the calling client.
                return InternalServerError(new Exception("Something unexpected has occurred...Support has been notified."));
            }
        }

        /// <summary>
        /// Used to save a listing of people.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RecordsMultiple")]
        public IHttpActionResult SavePeople([FromBody]List<Person> people)
        {
            try
            {
                return Ok(_personManager.SavePeople(people));
            }
            catch
            {
                //Return back data to the calling client.
                return InternalServerError(new Exception("Something unexpected has occurred...Support has been notified."));
            }
        }
    }
}
