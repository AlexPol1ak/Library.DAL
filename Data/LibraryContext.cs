﻿using Library.Domain.Entities.Books;
using Library.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Data
{
    /// <summary>
    /// Класс контекста базы данных.
    /// </summary>
    public class LibraryContext : DbContext
    {
        private string connectionString;
        private string version;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Stuff> Stuff { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookHistory> BookHistories { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Rack> Racks { get; set; } = null!;
        public DbSet<Term> Terms { get; set; } = null!;

        public LibraryContext(string connectionString, string version)
        {
            this.connectionString = connectionString;
            this.version = version;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(version)));
        }

        /// <summary>
        /// Выполняет конфигурацию таблиц.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(ModelsConfig.UserConfig);
            modelBuilder.Entity<Stuff>(ModelsConfig.StuffConfig);
            modelBuilder.Entity<Author>(ModelsConfig.AuthorConfig);
            modelBuilder.Entity<Book>(ModelsConfig.BookConfig);
            modelBuilder.Entity<BookHistory>(ModelsConfig.BookHistoryConfig);
            modelBuilder.Entity<Genre>(ModelsConfig.GenreConfig);
            modelBuilder.Entity<Rack>(ModelsConfig.RackConfig);
            modelBuilder.Entity<Term>(ModelsConfig.TermConfig);
            base.OnModelCreating(modelBuilder);
        }
    }
}
