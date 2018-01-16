using GR.Contracts.DataContracts;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Client.Console
{
    /// <summary>
    /// This partial class should focus only on services concerns.
    /// </summary>
    public partial class Program
    {
        private static bool _actionDone = false;

        /// <summary>
        /// This method will start the REST service.
        /// </summary>
        private static void StartRESTService()
        {
            using (WebApp.Start<Startup>(url: _serviceEndPoint))
            {
                _serverReady = true;
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// Our standard generic get data method.
        /// </summary>
        /// <param name="sortOption"></param>
        private static async Task<List<Person>> GetData(SortBy sortOption)
        {            
            List<Person> people = null;

            _actionDone = false;

            //In the concept of a Factory...Decide on how we will sort it and sort it.
            switch (sortOption)
            {
                case SortBy.Birthdates:
                    people = await _serviceClient.GetBirthDates().ConfigureAwait(false);
                    break;

                case SortBy.Genders:
                    people = await _serviceClient.GetGenders().ConfigureAwait(false);
                    break;

                case SortBy.Names:
                default:
                    people =  await _serviceClient.GetNames().ConfigureAwait(false);
                    break;
            }

            _actionDone = true;

            return people;
        }


        /// <summary>
        /// This method will post a line number to our REST service.
        /// </summary>
        private static async void PostData(int numberOfLines)
        {
            _actionDone = false;

            //Begin posting lines to server.
            try
            {
                for (int i = 0; i < numberOfLines; i++)
                    await _serviceClient.PostRecord(_people[i]);
            }
            catch 
            {
                //This is just a demo message.
                throw new Exception("Something unexpected has happen during the service call....Please try again later");
            }

            //We are finished posting. Could use delegates as well to return an event if needed.
            _actionDone = true;            
        }
    }

    /// <summary>
    /// The purpose of this enum is to provide a univeral way of sorting.
    /// </summary>
    public enum SortBy
    {
        Birthdates,
        Genders,
        Names
    }
}
