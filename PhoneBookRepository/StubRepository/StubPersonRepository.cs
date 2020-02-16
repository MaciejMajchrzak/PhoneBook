using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookRepository.Interfaces;
using PhoneBookRepository.Tables;

namespace PhoneBookRepository.StubRepository
{
    public class StubPersonRepository : IPersonRepository
    {
        public bool Add(Person person)
        {
            return true;
        }

        public List<Person> GetAll()
        {
            List<Person> people = new List<Person>();

            Person person = new Person()
            {
                Id = 1,
                FirstName = "Maciej",
                LastName = "Majchrzak",
                Phone = "570057635",
                Email = "maciek.majchrzak15@gmail.com",
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            people.Add(person);

            person = new Person()
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                Phone = "123456789",
                Email = "qwerty@ui.op",
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            people.Add(person);

            return people;
        }

        public Person GetOneById(int id)
        {
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Maciej",
                LastName = "Majchrzak",
                Phone = "570057635",
                Email = "maciek.majchrzak15@gmail.com",
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            return person;
        }

        public bool RemoveById(int id)
        {
            return true;
        }

        public bool Update(Person person)
        {
            return true;
        }
    }
}
