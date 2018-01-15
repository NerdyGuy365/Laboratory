using GR.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Contracts.ServiceContracts
{
    /// <summary>
    /// The following contract is used for clients that want to call a service designed to work with people's information.
    /// </summary>
    public interface IPersonService
    {
        Task<List<Person>> GetBirthDates();

        Task<List<Person>> GetGenders();

        Task<List<Person>> GetNames();

        Task<string> PostRecord(Person person);

        Task<string> PostRecords(List<Person> people);
    }
}
