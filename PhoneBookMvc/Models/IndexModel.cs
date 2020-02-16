using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBookRepository.Interfaces;
using PhoneBookRepository.Tables;

namespace PhoneBookMvc.Models
{
    public class IndexModel
    {
        public List<Person> people { get; set; }

        public void Init(IPersonRepository personRepository)
        {
            people = personRepository.GetAll();
        }
    }
}
