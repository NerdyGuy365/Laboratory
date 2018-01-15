using GR.Contracts.DataContracts;
using GR.Contracts.ServiceContracts;

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR.Common;

namespace GR.Business
{
    /// <summary>
    /// The following utility object is used make an HTTP connection to a service.
    /// </summary>
    public class PersonServiceClient : IPersonService
    {       
        //Private variables.
        private string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        public async Task<List<Person>> GetBirthDates()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "Records/Birthdates");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<List<Person>> GetGenders()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "Records/Genders");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<List<Person>> GetNames()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "Records/Names");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<string> PostRecord(Person person)
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "Records");

            //Since this is a service call...We want to give control back to the caller of this method
            var result = await httpClient.PostData(person).ConfigureAwait(false);

            //If the service did not return OK as status.
            //We want to ease the concerns of the user and tell them the service is down for maintainence.

            //Meanwhile... we internally let technical support know.
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("The service is currently down for maintainence...Please try again later.");

            //ADD TECHNICAL SUPPORT NOTIFICATION CODE HERE.

            return "OK";
        }

        public async Task<string> PostRecords(List<Person> people)
        {
            //Declare variables
            HttpClient<List<Person>> httpClient = new HttpClient<List<Person>>(_serviceEndPoint + "RecordsMultiple");

            //Since this is a service call...We want to give control back to the caller of this method
            var result = await httpClient.PostData(people).ConfigureAwait(false);

            //If the service did not return OK as status.
            //We want to ease the concerns of the user and tell them the service is down for maintainence.

            //Meanwhile... we internally let technical support know.
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("The service is currently down for maintainence...Please try again later.");

            //ADD TECHNICAL SUPPORT NOTIFICATION CODE HERE.

            return "OK";
        }
    }
}
