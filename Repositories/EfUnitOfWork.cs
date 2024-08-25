using Library.DAL.Data;
using Library.Domain.Entities.Books;
using Library.Domain.Entities.Users;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.DAL.Repositories
{
    public class EfUnitOfWork: IUnitOfWork
    {
        public string ConnectionString { get; private set; }
        public string Version { get; private set; }
        private readonly LibraryContext context;

        private IRepository<User> usersRepository;
        private IRepository<Stuff> stuffRepository;
        private IRepository<Request> requestsRepository;
        private IRepository<Author> authorsRepository;
        private IRepository<Book> booksRepository;
        private IRepository<BookHistory> bookHistoriesRepository;
        private IRepository<Genre> genresRepository;
        private IRepository<Rack> racksRepository;
        private IRepository<Term> termsRepository;

        public IRepository<User> UsersRepository => usersRepository ??= 
            new EfUsersRepository(context);
        public IRepository<Stuff> StuffRepository => stuffRepository ??= 
            new EfStuffRepository(context);
        public IRepository<Request> RequestsRepository => requestsRepository ??=
            new EfRequestsRepository(context);
        public IRepository<Author> AuthorsRepository => authorsRepository ??=
            new EfAuthorsRepository(context);
        public IRepository<Book> BooksRepository => booksRepository ??= 
            new EfBooksRepository(context);
        public IRepository<BookHistory> BookHistoriesRepository => bookHistoriesRepository ??=
            new EfBookHistoriesRepository(context);
        public IRepository<Genre> GenresRepository => genresRepository ??= 
            new EfGenresRepository(context);
        public IRepository<Rack> RacksRepository => racksRepository ??=
            new EfRacksRepository(context);
        public IRepository<Term> TermsRepository => termsRepository ??=
            new EfTermsRepository(context);

        public EfUnitOfWork(string connectionString, string version)
        {
            ConnectionString = connectionString;
            Version = version;

            context = new LibraryContext(ConnectionString, Version);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Загружает связанные сущности.
        /// </summary>
        /// <typeparam name="T">Основной тип сущности.</typeparam>
        /// <typeparam name="TProperty">Тип зависимой сущности.</typeparam>
        /// <param name="entity"></param>
        /// <param name="navigationProperty">
        /// Выражение, указывающее на коллекцию связанных сущностей
        /// </param>
        public void LoadRelatedEntities<T, TProperty>(T entity, Expression<Func<T, IEnumerable<TProperty>>> navigationProperty)
                 where T : class
                 where TProperty : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (navigationProperty == null)
            {
                throw new ArgumentNullException(nameof(navigationProperty));
            }

            context.Entry(entity).Collection(navigationProperty).Load();
        }
    }
}
