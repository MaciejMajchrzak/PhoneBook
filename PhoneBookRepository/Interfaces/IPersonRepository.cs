using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookRepository.Tables;

namespace PhoneBookRepository.Interfaces
{
    public interface IPersonRepository
    {
        bool Add(Person person);
        List<Person> GetAll();
        Person GetOneById(int id);
        bool Update(Person person);
        bool RemoveById(int id);
    }
}
