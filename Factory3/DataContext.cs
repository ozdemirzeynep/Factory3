using Factory3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory3
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ysyasdb; User Id=sa; Password=123;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
