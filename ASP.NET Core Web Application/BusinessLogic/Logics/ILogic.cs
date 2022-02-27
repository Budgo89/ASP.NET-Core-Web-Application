using BD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiServis.Logics
{
    public interface ILogic
    {
        Task<Person> GetPersonsId(int id);
        Task<Person> FindPersonsName(string name);
        Task<List<Person>> FindPersons(int skip, int take);
        Task AddPersons(Person person);
        Task UpdatePersons(Person person);
        Task DeletePersons(int id);
    }
}