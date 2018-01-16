using GR.Contracts.DataContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GR.Client.Console
{
    public class PersonHttpClient
    {
        //Private variables.
        private string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        /// <summary>
        /// 
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

        public async void PostRecord(Person person)
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records");

            //Since this is a service call...We want to give control back to the caller of this method.
            HttpResponseMessage response = await httpClient.PostData(person).ConfigureAwait(false);

            //Return the status code of the service call.
            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("Something went wrong in saving the data...Technicial support has been notified.");
        }
    }
}
