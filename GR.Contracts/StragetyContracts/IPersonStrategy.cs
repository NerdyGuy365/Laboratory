using GR.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Contracts.StragetyContracts
{
    /// <summary>
    /// The following contract is used for handling unique business related cases that deal with people's information.
    /// </summary>
    public interface IPersonStrategy
    {
        List<Person> GetBirthDates();

        List<Person> GetGenders();

        List<Person> GetNames();

        string SavePerson(Person person);

        string SavePeople(List<Person> people);
    }
}
