using GR.Contracts.StragetyContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR.Contracts.DataContracts;
using GR.Data;
using GR.Data.DataRepository_Contracts;
using GR.Common;

namespace GR.Business
{
    /// <summary>
    /// The following class is used to define business strategies (logic).
    /// </summary>
    public class PersonStrategy : IPersonStrategy
    {
        //We need a way to handle data persistence.
        IPersonDataRepository _data;

        public PersonStrategy(IPersonDataRepository dataRepository)
        {
            //Set the data persistence to XML by default.
            _data = dataRepository;

            //If null was passed in as a data repository.
            //Then we will assume to use XML persistence by default.
            if (_data == null)
                _data = new PersonRepository_XML_Persistence();
        }

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetBirthDates()
        {
            //Get results 
            var results = _data.GetPeople(SortBy.BirthDates);

            //Did we get results back?
            if(results != null && results.Count > 0)
                return results.OrderBy(p => p.DateOfBirth).ToList();

            //No data loaded from data source.
            return null;
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetGenders()
        {
            //Get results 
            var results = _data.GetPeople(SortBy.Genders);

            //Did we get results back?
            if (results != null && results.Count > 0)
                return results.OrderBy(p => p.Gender).ThenBy(l => l.LastName).ToList();

            //No data loaded from data source.
            return null;
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetNames()
        {
            //Get results 
            var results = _data.GetPeople(SortBy.LastNames);

            //Did we get results back?
            if (results != null && results.Count > 0)
                return results.OrderByDescending(p => p.LastName).ToList();

            //No data loaded from data source.
            return null;
        }

        /// <summary>
        /// Used to save a new person.
        /// </summary>
        /// <returns></returns>
        public string SavePerson(Person person)
        {
            //Save a new person.
            return _data.SavePerson(person);
        }

        /// <summary>
        /// Used to save a listing of people.
        /// </summary>
        /// <returns></returns>
        public string SavePeople(List<Person> people)
        {
            //Save a listing of people.
            return _data.SavePeople(people);
        }
    }
}
