using GR.Contracts.DataContracts;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Configuration;

using System.Net.Http;
using System.Threading.Tasks;

namespace GR.Client.Console
{
    public class PersonHttpClient
    {
        //Private variables.
        private string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetBirthDates()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Birthdates");

            //Since this is a service call...We want to give control back to the caller of this method.
            HttpResponseMessage response = await httpClient.GetData().ConfigureAwait(false);

            //Return the status code of the service call.
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Something went wrong in saving the data...Technicial support has been notified.");

            //Create a POCO from our results.
            var results = JsonConvert.DeserializeObject<List<Person>>(response.Content.ReadAsStringAsync().Result);

            //Return the results back to the caller.
            return results;
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetGenders()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Genders");

            //Since this is a service call...We want to give control back to the caller of this method.
            HttpResponseMessage response = await httpClient.GetData().ConfigureAwait(false);

            //Return the status code of the service call.
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Something went wrong in saving the data...Technicial support has been notified.");

            //Create a POCO from our results.
            var results = JsonConvert.DeserializeObject<List<Person>>(response.Content.ReadAsStringAsync().Result);

            //Return the results back to the caller.
            return results;
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetNames()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Names");

            //Since this is a service call...We want to give control back to the caller of this method.
            HttpResponseMessage response = await httpClient.GetData().ConfigureAwait(false);

            //Return the status code of the service call.
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Something went wrong in saving the data...Technicial support has been notified.");

            //Create a POCO from our results.
            var results = JsonConvert.DeserializeObject<List<Person>>(response.Content.ReadAsStringAsync().Result);

            //Return the results back to the caller.
            return results;
        }

        /// <summary>
        /// Used to save a person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<List<Person>> PostRecord(Person person)
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records");

            //Since this is a service call...We want to give control back to the caller of this method.
            HttpResponseMessage response = await httpClient.PostData(person).ConfigureAwait(false);

            //Return the status code of the service call.
            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("Something went wrong in saving the data...Technicial support has been notified.");

            //In a lot of situations after a post.
            //We can return back the object that was posted.
            //There are a lot of times state data could be altered.
            //Create a POCO from our results.
            var result = JsonConvert.DeserializeObject<List<Person>> (response.Content.ReadAsStringAsync().Result);

            //Return the result back to the caller.
            return result;
        }
    }
}
