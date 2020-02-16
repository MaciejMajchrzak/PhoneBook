using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBookRepository.Interfaces;
using PhoneBookRepository.Tables;


namespace PhoneBookRepository.Repository
{
    public class EFPersonRepository : IPersonRepository
    {
        PhoneBookContext _phoneBookContext;

        public EFPersonRepository(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        public bool Add(Person person)
        {
            try
            {
                person.Created = DateTime.Now;

                person.Updated = DateTime.Now;

                _phoneBookContext.People.Add(person);

                _phoneBookContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Person> GetAll()
        {
            return _phoneBookContext.People.ToList();
        }

        public Person GetOneById(int id)
        {
            return _phoneBookContext.People.FirstOrDefault(p => p.Id == id);
        }

        public bool RemoveById(int id)
        {
            try
            {
                var obj = GetOneById(id);

                _phoneBookContext.People.Remove(obj);

                _phoneBookContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Person person)
        {
            try
            {
                var obj = GetOneById(person.Id);

                obj.FirstName = person.FirstName;

                obj.LastName = person.LastName;

                obj.Phone = person.Phone;

                obj.Email = person.Email;

                obj.Updated = DateTime.Now;

                _phoneBookContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _phoneBookContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
