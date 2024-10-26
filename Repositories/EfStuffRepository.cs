using Library.DAL.Data;
using Library.Domain.Entities.Users;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Stuff"/> в контексте Entity Framework.
    /// Реализует интерфейс <see cref="IRepository{TEntity}"/> для выполнения операций CRUD.
    /// </summary>
    public class EfStuffRepository : IRepository<Stuff>
    {
        private readonly DbSet<Stuff> stuffs;

        public EfStuffRepository(LibraryContext libraryContext)
        {
            stuffs = libraryContext.Stuff;
        }

        #region CRUD operations

        /// <summary>
        /// Проверяет, существует ли указанная сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если сущность существует, иначе <c>false</c>.</returns>
        public bool Contains(Stuff entity)
        {
            return stuffs.Contains(entity);
        }

        /// <summary>
        /// Возвращает количество сущностей в репозитории.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public int Count()
        {
            return stuffs.Count();
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Create(Stuff entity)
        {
            stuffs.Add(entity);
        }

        /// <summary>
        /// Удаляет сущность из репозитория по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Возвращает <c>true</c>, если сущность была успешно удалена, иначе <c>false</c>.</returns>
        public bool Delete(int id)
        {
            var stuff = stuffs.Find(id);
            if (stuff is null) return false;
            stuffs.Remove(stuff);
            return true;
        }

        /// <summary>
        /// Находит сущности, соответствующие указанному условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Запрос, содержащий сущности, соответствующие условию.</returns>
        public IQueryable<Stuff> Find(Expression<Func<Stuff, bool>> predicate)
        {
            return stuffs.Where(predicate);
        }

        /// <summary>
        /// Получает сущность по указанному идентификатору с возможностью включения связанных данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для получения.</param>
        /// <param name="includes">Имена связанных данных, которые следует включить.</param>
        /// <returns>Сущность с указанным идентификатором.</returns>
        public Stuff Get(int id, params string[] includes)
        {
            IQueryable<Stuff> query = stuffs;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(s => s.UserId == id);
        }

        /// <summary>
        /// Возвращает все сущности в репозитории.
        /// </summary>
        /// <returns>Запрос, содержащий все сущности.</returns>
        public IQueryable<Stuff> GetAll(params string[] includes)
        {

            IQueryable<Stuff> query = stuffs.AsQueryable();
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
        public void Update(Stuff entity)
        {
            stuffs.Update(entity);
        }

        #endregion
    }
}
