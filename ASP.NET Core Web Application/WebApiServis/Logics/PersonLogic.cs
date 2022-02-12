using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_servis.Models;
using WebApiServis.Repository;

namespace WebApiServis.Logics
{
    public class PersonLogic
    {
        private List<Person> data;

        public PersonLogic(PersonsRepository personsRepository)
        {
            data = personsRepository.data;
        }

        public async Task<Person> GetPersonsId(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public async Task<Person> FindPersonsName(string name)
        {
            return data.Find(x => x.FirstName == name);
        }

        public async Task<List<Person>> FindPersons(int skip, int take)
        {
            var list = new List<Person>();
            for (int i = skip; i <= take; i++)
            {
                list.Add(data.Find(x=>x.Id == i));
            }

            return list;
        }

        public async Task AddPersons(Person person)
        {
            var persons = new Person()
            {
                Id = GetId(person).Result,
                Age = person.Age,
                Company = person.Company,
                Email = person.Email,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            data.Add(persons);
        }

        public async Task<string> UpdatePersons(Person person)
        {
            
            if (data.Exists(x => x.Id == person.Id))
            {
                var persons = GetPersonsId(person.Id);
                persons.Result.Age = person.Age;
                persons.Result.Company = person.Company;
                persons.Result.FirstName = person.FirstName;
                persons.Result.LastName = person.LastName;
                return "Обновлено";
            }
            return "Элемент не найден";
        }

        public async Task DeletePersons(int id)
        {
            if (data.Exists(x => x.Id == id))
            {
                var persons = GetPersonsId(id);
                data.Remove(persons.Result);
            }
            return;
        }

        private async Task<int> GetId(Person person)
        {
            var idMax = data.Max(x => x.Id);
            if (data.Exists(x => x.Id == person.Id))
            {
                return idMax + 1;
            }

            return person.Id;
        }
    }
}
