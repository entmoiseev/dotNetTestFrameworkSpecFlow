using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using BookLibraryTestProject.Models;

namespace Library.Config
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=libraryappdb;Trusted_Connection=True;");
        }
    }
}
