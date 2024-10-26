using Library.DAL.Data;
using Library.Domain.Entities.Books;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Genre"/> в контексте Entity Framework.
    /// Реализует интерфейс <see cref="IRepository{TEntity}"/> для выполнения операций CRUD.
    /// </summary>
    public class EfGenresRepository : IRepository<Genre>
    {
        private readonly DbSet<Genre> genres;

        public EfGenresRepository(LibraryContext libraryContext)
        {
            genres = libraryContext.Genres;
        }

        #region CRUD operations
        /// <summary>
        /// Проверяет, существует ли указанная сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если сущность существует, иначе <c>false</c>.</returns>
        public bool Contains(Genre entity)
        {
            return genres.Contains(entity);
        }

        /// <summary>
        /// Возвращает количество сущностей в репозитории.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public int Count()
        {
            return genres.Count();
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Create(Genre entity)
        {
            genres.Add(entity);
        }

        /// <summary>
        /// Удаляет сущность из репозитория по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Возвращает <c>true</c>, если сущность была успешно удалена, иначе <c>false</c>.</returns>
        public bool Delete(int id)
        {
            var genre = genres.Find(id);
            if (genre is null) return false;
            genres.Remove(genre);
            return true;
        }

        /// <summary>
        /// Находит сущности, соответствующие указанному условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Запрос, содержащий сущности, соответствующие условию.</returns>
        public IQueryable<Genre> Find(Expression<Func<Genre, bool>> predicate)
        {
            return genres.Where(predicate);
        }

        /// <summary>
        /// Получает сущность по указанному идентификатору с возможностью включения связанных данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для получения.</param>
        /// <param name="includes">Имена связанных данных, которые следует включить.</param>
        /// <returns>Сущность с указанным идентификатором.</returns>
        public Genre Get(int id, params string[] includes)
        {
            IQueryable<Genre> query = genres;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(g => g.GenreId == id);
        }

        /// <summary>
        /// Возвращает все сущности в репозитории.
        /// </summary>
        /// <returns>Запрос, содержащий все сущности.</returns>
        public IQueryable<Genre> GetAll(params string[] includes)
        {
            IQueryable<Genre> query = genres.AsQueryable();
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
        public void Update(Genre entity)
        {
            genres.Update(entity);
        }

        #endregion
    }
}
