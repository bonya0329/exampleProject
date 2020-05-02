using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exampleProject.Models;

namespace exampleProject.Data
{
    public class MyDBContext : DbContext
    {

        public MyDBContext (DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public DbSet<exampleProject.Models.Student> Student { get; set; }

        public DbSet<exampleProject.Models.Department> Department { get; set; }

        public DbSet<exampleProject.Models.Employee> Employee { get; set; }

        public DbSet<exampleProject.Models.Author> Author { get; set; }

        public DbSet<exampleProject.Models.Book> Book { get; set; }
        public DbSet<exampleProject.Models.AuthorToBook> AuthorToBook { get; set; }
        public DbSet<exampleProject.Models.StudentAddress> StudentAddress { get; set; }
        //public object AuthorToBook { get; internal set; }

    }
}
