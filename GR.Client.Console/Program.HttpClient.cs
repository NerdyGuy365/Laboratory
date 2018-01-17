using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
        public async Task<HttpResponseMessage> GetData()
        {
            //Create a new http client.
            using (var client = new HttpClient())
            {
                //We are working with JSON data.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_serviceEndPoint);

                //Hit the service.
                HttpResponseMessage response = await client.GetAsync("").ConfigureAwait(false);

                //Return the data we got back from the server.
                return response;
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
                //We are working with JSON data.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_serviceEndPoint);

                //Hit the service.
                HttpResponseMessage response = await client.PostAsJsonAsync("", poco).ConfigureAwait(false);

                //Return the response we got back from the server.
                return response;
            }
        }
    }
}
