using GR.Contracts.DataContracts;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Business
{
    public class PersonHelpers
    {
        /// <summary>
        /// A method of parsing out the text from a delimited file.
        /// Displaying that data to the user.
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
    }
}
