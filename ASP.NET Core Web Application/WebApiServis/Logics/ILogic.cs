using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API_servis.Models;

namespace WebApiServis.Logics
{
    public interface ILogic
    {
        Task<Person> GetPersonsId(int id);
        Task<Person> FindPersonsName(string name);
        Task<List<Person>> FindPersons(int skip, int take);
        Task AddPersons(Person person);
        Task<string> UpdatePersons(Person person);
        Task DeletePersons(int id);
    }
}