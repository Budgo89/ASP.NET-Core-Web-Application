using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BD.Models;
using BD.Repositorys;

namespace WebApiServis.Logics
{
    public class PersonLogic : ILogic
    {
        private List<Person> data;

        public PersonLogic(PersonsRepository personsRepository)
        {
            data = personsRepository.data;
        }

        public async Task<Person> GetPersonsId(int id)
        {
            var person = data.Find(x => x.Id == id);
            if (person != null)
            {
                return person;
            }

            return new Person();
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
                list.Add(data[i]);
            }

            return list;
        }

        public async Task AddPersons(Person person)
        {
            var persons = new Person()
            {
                Age = person.Age,
                Company = person.Company,
                Email = person.Email,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            data.Add(persons);
        }

        public async Task UpdatePersons(Person person)
        {
            
            if (data.Exists(x => x.Id == person.Id))
            {
                var persons = GetPersonsId(person.Id);
                persons.Result.Age = person.Age;
                persons.Result.Company = person.Company;
                persons.Result.FirstName = person.FirstName;
                persons.Result.LastName = person.LastName;
            }
            else new Exception("Элемент не найден");
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
        
    }
}
