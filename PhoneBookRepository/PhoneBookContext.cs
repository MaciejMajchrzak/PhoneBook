using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhoneBookRepository.Tables;

namespace PhoneBookRepository
{
    public class PhoneBookContext:DbContext
    {
        private readonly string _connectionString;

        public PhoneBookContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
