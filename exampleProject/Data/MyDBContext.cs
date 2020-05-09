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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "qwerty";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }

    }
}
