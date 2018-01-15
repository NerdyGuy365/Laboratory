using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;
using System.Security.Permissions;
using System.ServiceModel;
using GR.Contracts.StragetyContracts;
using GR.Contracts.DataContracts;
using GR.Business;
using GR.Data.DataRepository_Contracts;

namespace GR.Manager
{
    /// <summary>
    /// The purpose of the manager class is to be a gateway to the business logic.
    /// It regulates security access and handling expections
    /// </summary>
    public class PersonManager : ManagerBase, IPersonStrategy
    {
        //Form scope variables
        private string _userName = "";
        private string _password = "";

        private PersonStrategy _personStrategy;

        /// <summary>
        /// The following construction is a place where security information will be passed in.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public PersonManager(string userName, string password, IPersonDataRepository dataRepository)
        {
            _personStrategy = new PersonStrategy(dataRepository);

            _userName = userName;
            _password = password;
        }

        /// <summary>
        /// Used to get a listing of people sorted by birth dates.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetBirthDates()
        {
            try
            {
                //Check to see if we have access to call this piece of functionality.
                if (isAuthenticated(_userName, _password))
                {
                    return _personStrategy.GetBirthDates();
                }
            }
            catch (Exception ex)
            {
                //Log the exception so the business can become aware of the issue.
                LogExpection(ex);

                throw new Exception(ex.Message);
            }

            //User is assumed to be not allowed to access this method. So return back nothing.
            return null; 
        }

        /// <summary>
        /// Used to get a listing of people sorted by genders.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetGenders()
        {
            try
            {
                //Check to see if we have access to call this piece of functionality.
                if (isAuthenticated(_userName, _password))
                {
                    return _personStrategy.GetGenders();
                }
            }
            catch (Exception ex)
            {
                //Log the exception so the business can become aware of the issue.
                LogExpection(ex);

                throw new Exception(ex.Message);
            }

            //User is assumed to be not allowed to access this method. So return back nothing.
            return null;
        }

        /// <summary>
        /// Used to get a listing of people sorted by names.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetNames()
        {
            try
            {
                //Check to see if we have access to call this piece of functionality.
                if (isAuthenticated(_userName, _password))
                {
                    return _personStrategy.GetNames();
                }
            }
            catch (Exception ex)
            {
                //Log the exception so the business can become aware of the issue.
                LogExpection(ex);

                throw new Exception(ex.Message);
            }

            //User is assumed to be not allowed to access this method. So return back nothing.
            return null;
        }

        /// <summary>
        /// Used to save a person.
        /// </summary>
        /// <returns></returns>
        public string SavePerson(Person person)
        {
            try
            {
                //Check to see if we have access to call this piece of functionality.
                if (isAuthenticated(_userName, _password))
                {
                    return _personStrategy.SavePerson(person);
                }
            }
            catch (Exception ex)
            {
                //Log the exception so the business can become aware of the issue.
                LogExpection(ex);

                throw new Exception(ex.Message);
            }

            //User is assumed to be not allowed to access this method. So return back nothing.
            return null;
        }

        /// <summary>
        /// Used to save a listing of people.
        /// </summary>
        /// <returns></returns>
        public string SavePeople(List<Person> people)
        {
            try
            {
                //Check to see if we have access to call this piece of functionality.
                if (isAuthenticated(_userName, _password))
                {
                    return _personStrategy.SavePeople(people);
                }
            }
            catch (Exception ex)
            {
                //Log the exception so the business can become aware of the issue.
                LogExpection(ex);

                throw new Exception(ex.Message);
            }

            //User is assumed to be not allowed to access this method. So return back nothing.
            return null;
        }
    }
}
