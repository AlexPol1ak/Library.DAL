using Library.DAL.Data;
using Library.Domain.Entities.Books;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Library.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Book"/> в контексте Entity Framework.
    /// Реализует интерфейс <see cref="IRepository{TEntity}"/> для выполнения операций CRUD.
    /// </summary>
    public class EfBooksRepository : IRepository<Book>
    {
        private readonly DbSet<Book> books;

        public EfBooksRepository(LibraryContext libraryContext)
        {
            books = libraryContext.Books;
        }

        #region CRUD operations
        /// <summary>
        /// Проверяет, существует ли указанная сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если сущность существует, иначе <c>false</c>.</returns>
        public bool Contains(Book entity)
        {
            return books.Contains(entity);
        }

        /// <summary>
        /// Возвращает количество сущностей в репозитории.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public int Count()
        {
            return books.Count();
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Create(Book entity)
        {
            books.Add(entity);
        }

        /// <summary>
        /// Удаляет сущность из репозитория по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Возвращает <c>true</c>, если сущность была успешно удалена, иначе <c>false</c>.</returns>
        public bool Delete(int id)
        {
            var book = books.Find(id);
            if (book is null) return false;
            books.Remove(book);
            return true;
        }

        /// <summary>
        /// Находит сущности, соответствующие указанному условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Запрос, содержащий сущности, соответствующие условию.</returns>
        public IQueryable<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return books.Where(predicate);
        }

        /// <summary>
        /// Получает сущность по указанному идентификатору с возможностью включения связанных данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для получения.</param>
        /// <param name="includes">Имена связанных данных, которые следует включить.</param>
        /// <returns>Сущность с указанным идентификатором.</returns>
        public Book Get(int id, params string[] includes)
        {
            IQueryable<Book> query = books;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(b => b.BookId == id);
        }

        /// <summary>
        /// Возвращает все сущности в репозитории.
        /// </summary>
        /// <returns>Запрос, содержащий все сущности.</returns>
        public IQueryable<Book> GetAll(params string[] includes)
        {
            IQueryable<Book> query = books.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        /// <summary>
        /// Обновляет существующую сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        public void Update(Book entity)
        {
            books.Update(entity);
        }
        #endregion
    }
}
