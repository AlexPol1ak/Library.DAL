using Library.Domain.Entities.Books;
using Library.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.DAL.Data
{
    public class LibraryContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Stuff>  Stuff{ get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookHistory> BookHistories { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Rack> Racks { get; set; } = null!;
        public DbSet<Term> Terms { get; set; } = null!;

        public LibraryContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        /// <summary>
        /// Выполняет конфигруацию таблиц.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(ModelsConfig.UserConfig);
            modelBuilder.Entity<Stuff>(ModelsConfig.StuffConfig);
            modelBuilder.Entity<Request>(ModelsConfig.RequestConfig);
            modelBuilder.Entity<Author>(ModelsConfig.AuthorConfig);
            modelBuilder.Entity<Book>(ModelsConfig.BookConfig);
            modelBuilder.Entity<BookHistory>(ModelsConfig.BookHistoryConfig);
            modelBuilder.Entity<Genre>(ModelsConfig.GenreConfig);
            modelBuilder.Entity<Rack>(ModelsConfig.RackConfig);
            modelBuilder.Entity<Term>(ModelsConfig.TermConfig);
        }
    }
}
