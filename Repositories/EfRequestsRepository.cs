using Library.DAL.Data;
using Library.Domain.Entities.Users;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Request"/> в контексте Entity Framework.
    /// Реализует интерфейс <see cref="IRepository{TEntity}"/> для выполнения операций CRUD.
    /// </summary>
    public class EfRequestsRepository : IRepository<Request>
    {
        private readonly DbSet<Request> requests;

        public EfRequestsRepository(LibraryContext libraryContext)
        {
            requests = libraryContext.Requests;
        }

        #region CRUD operations

        /// <summary>
        /// Проверяет, существует ли указанная сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если сущность существует, иначе <c>false</c>.</returns>
        public bool Contains(Request entity)
        {
            return requests.Contains(entity);
        }

        /// <summary>
        /// Возвращает количество сущностей в репозитории.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public int Count()
        {
            return requests.Count();
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Create(Request entity)
        {
            requests.Add(entity);
        }

        /// <summary>
        /// Удаляет сущность из репозитория по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Возвращает <c>true</c>, если сущность была успешно удалена, иначе <c>false</c>.</returns>
        public bool Delete(int id)
        {
            var request = requests.Find(id);
            if (request is null) return false;
            requests.Remove(request);
            return true;
        }

        /// <summary>
        /// Находит сущности, соответствующие указанному условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Запрос, содержащий сущности, соответствующие условию.</returns>
        public IQueryable<Request> Find(Expression<Func<Request, bool>> predicate)
        {
            return requests.Where(predicate);
        }

        /// <summary>
        /// Получает сущность по указанному идентификатору с возможностью включения связанных данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для получения.</param>
        /// <param name="includes">Имена связанных данных, которые следует включить.</param>
        /// <returns>Сущность с указанным идентификатором.</returns>
        public Request Get(int id, params string[] includes)
        {
            IQueryable<Request> query = requests;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(r => r.RequestId == id);
        }

        /// <summary>
        /// Возвращает все сущности в репозитории.
        /// </summary>
        /// <returns>Запрос, содержащий все сущности.</returns>
        public IQueryable<Request> GetAll(params string[] includes)
        {

            IQueryable<Request> query = requests.AsQueryable();
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
        public void Update(Request entity)
        {
            requests.Update(entity);
        }

        #endregion
    }
}
