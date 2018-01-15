using GR.Common;
using GR.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Data.DataRepository_Contracts
{
    /// <summary>
    /// The following contract is used for data persistence handling.
    /// </summary>
    public interface IPersonDataRepository
    {
        List<Person> GetPeople(SortBy sortBy);

        string SavePerson(Person person);

        string SavePeople(List<Person> people);
    }
}

