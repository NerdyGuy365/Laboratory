using GR.Business;
using GR.Client.Console.SelfHostingREST;
using GR.Contracts.DataContracts;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GR.Client.Console
{
    public class Program
    {
        //Form scoper variables section.
        private static List<Person> _people = new List<Person>();
        private static PersonHttpClient _serviceClient = new PersonHttpClient();

        private static string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        private static Thread _serviceThread;

        public static void Main(string[] args)
        {
            try
            {
                //See Actions Folder in project.

                //Combine the 3 files into a single set of records.
                foreach(var file in args)
                    _people.AddRange(PersonHelpers.ParsePersonDataFromFile(file));

                //Start REST service.
                _serviceThread = new Thread(StartRESTService);
                _serviceThread.Start();
                Thread.Sleep(3000); 
                
                //Let's post at least 5 different lines to the service.
                var result = PostLine(1);
                result = PostLine(2);
                result = PostLine(3);
                result = PostLine(4);
                result = PostLine(5);

                System.Console.ReadLine();
            }
            catch(Exception ex)
            {
                //An exception can occur when dealing with files. 
                //Since this is a demo. Just throw a dummy message.
                System.Console.WriteLine("It looks like you might have have a file in the correct place. Please double check the LocalData folder.");
            }
        }

        /// <summary>
        /// This is a helper method used to post all data.
        /// </summary>
        /// <returns></returns>
        private static async Task<string> PostLine(int lineNumber)
        {
            try
            {
                return await _serviceClient.PostRecord(_people[lineNumber - 1]).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //Since the service will display a friendly error.
                //Let the service message inform the user.
                return ex.ToString();
            }
        }

        /// <summary>
        /// This method will start the REST service.
        /// </summary>
        private static void StartRESTService()
        {
            using (WebApp.Start<Startup>(_serviceEndPoint))
            {
                System.Console.WriteLine("Web Server is running.");
                System.Console.WriteLine("Press any key to quit.");
                System.Console.ReadLine();
            }
        }
    }
}
