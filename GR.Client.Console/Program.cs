using GR.Business;
using GR.Client.Console;
using GR.Contracts.DataContracts;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Net.Http;
using Owin;
using Microsoft.VisualBasic.FileIO;

namespace GR.Client.Console
{
    public partial class Program
    {
        //Form scoper variables section.
        private static List<Person> _people = new List<Person>();
        private static PersonHttpClient _serviceClient = new PersonHttpClient();

        private static string _serviceEndPoint = ConfigurationManager.AppSettings["RESTURI"];

        private static Thread _serviceThread;
        private static bool _serverReady = false;

        public static void Main(string[] args)
        {
            //Determine first how we want to sort the data.
            System.Console.WriteLine("How would you like to sort the data? Press G for Gender, N for Names or B for Birthdates");
            string sortOption = System.Console.ReadLine();

            try
            {
                //Combine the 3 files into a single set of records.
                foreach (var file in args)
                    _people.AddRange(ParsePersonDataFromFile(file));

                //Start REST service.
                _serviceThread = new Thread(StartService);
                _serviceThread.Start();

                //Wait until the server is ready.
                while (_serverReady == false)
                    Thread.Sleep(1000);

                //Server is ready....Now begin.
                Start(sortOption);
            }
            catch
            {
                //An exception can occur when dealing with files. 
                //Since this is a demo. Just throw a dummy message.
                System.Console.WriteLine("It looks like you might not have a file in the correct place. Please double check the LocalData folder.");
            }
        }

        /// <summary>
        /// The following method is used to hit the REST service and data data to the screen.
        /// </summary>
        /// <param name="sortOption"></param>
        private static async void DisplayData(SortBy sortOption)
        {
            //Let's grab the data and sort it correctly.
            List<Person> people = await GetData(sortOption);

            //Wait until all posting to the server is complete.
            while (_actionDone == false)
                Thread.Sleep(1000);

            //Print out values to screen.
            foreach (var person in people)
                System.Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Gender + " " + person.FavoriteColor + " " + person.DateOfBirth.ToShortDateString());
                System.Console.WriteLine("");
        }

        /// <summary>
        /// The following method will parse out the text from a delimited file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Person> ParsePersonDataFromFile(string filePath)
        {
            List<Person> people = new List<Person>();

            //Declare local variables
            string[] lineData = null;

            //Handle parsing out the data from the file.
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.Delimiters = new string[] { ",", " ", "|" };
                while (true)
                {
                    lineData = parser.ReadFields();
                    if (lineData == null)
                    {
                        break;
                    }

                    var person = new Person { LastName = lineData[0], FirstName = lineData[1], Gender = lineData[2], FavoriteColor = lineData[3], DateOfBirth = Convert.ToDateTime(lineData[4]) };
                    people.Add(person);
                }
            }

            return people;
        }

        /// <summary>
        /// This method will be posting some data and displaying it afterwards. 
        /// </summary>
        /// <param name="sortOption"></param>
        private static void Start(string sortOption)
        {
            //Let's post some data to the server.           
            PostData(15);
            
            //Wait until all posting to the server is complete.
            while (_actionDone == false)
                Thread.Sleep(1000);

            //Determine how the user wants to sort.
            //Display data to screen.
            switch(sortOption.ToUpper())
            {
                case "B": //Birthdates
                    DisplayData(SortBy.Birthdates);
                    break;

                case "G": //Genders
                    DisplayData(SortBy.Genders);
                    break;

                case "N": //Names
                default:
                    DisplayData(SortBy.Names);
                    break;
            }
        }
    }
}
