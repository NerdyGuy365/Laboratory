using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace GR.Client.Console
{
    /// <summary>
    /// The following class object is used to handle REST http calls from a client to a server.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpClient<T>
    {
        //Private variables.
        private string _serviceEndPoint = "";

        /// <summary>
        /// A rest service cannot work without an endpoint.
        /// So we are going to make it an requirement to pass into the constructor.
        /// </summary>
        /// <param name="serviceEndPoint"></param>
        public HttpClient(string serviceEndPoint)
        {
            //Set the service end point.
            _serviceEndPoint = serviceEndPoint;
        }

        /// <summary>
        /// We are assuming that the service will return back JSON data.
        /// </summary>
        /// <param name="serviceEndPoint"></param>
        /// <returns></returns>
        public async Task<List<T>> GetData()
        {
            //Create a new http client.
            using (var client = new HttpClient())
            {
                //We are working with JSON data.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_serviceEndPoint);

                //Hit the service.
                var response = await client.GetStringAsync("").ConfigureAwait(false);
                List<T> value = JsonConvert.DeserializeObject<List<T>>(response);

                //Return the data we got back from the server.
                return value;
            }
        }

        /// <summary>
        /// We are posting JSON data to a service.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostData(T poco)
        {
            //Create a new http client.
            using (var client = new HttpClient())
            {
                //Hit the service.
                client.BaseAddress = new Uri(_serviceEndPoint);
                var response = await client.PostAsJsonAsync("", poco).ConfigureAwait(false);

                //Return the response we got back from the server.
                return new HttpResponseMessage(response.StatusCode);
            }
        }
    }
}
