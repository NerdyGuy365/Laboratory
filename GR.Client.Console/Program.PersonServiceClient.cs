using GR.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Client.Console
{
    public class PersonHttpClient
    {
        //Private variables.
        private string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        public async Task<List<Person>> GetBirthDates()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Birthdates");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<List<Person>> GetGenders()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Genders");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<List<Person>> GetNames()
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records/Names");

            //Since this is a service call...We want to give control back to the caller of this method
            return await httpClient.GetData().ConfigureAwait(false);
        }

        public async Task<string> PostRecord(Person person)
        {
            //Declare variables
            HttpClient<Person> httpClient = new HttpClient<Person>(_serviceEndPoint + "/Records");

            //Since this is a service call...We want to give control back to the caller of this method
            var result = await httpClient.PostData(person).ConfigureAwait(false);

            //Everything went ok.
            return "OK";
        }
    }
}
