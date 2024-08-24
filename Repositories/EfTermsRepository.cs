using Library.DAL.Data;
using Library.Domain.Entities.Books;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Term"/> в контексте Entity Framework.
    /// Реализует интерфейс <see cref="IRepository{TEntity}"/> для выполнения операций CRUD.
    /// </summary>
    public class EfTermsRepository : IRepository<Term>
    {
        private readonly DbSet<Term> terms;

        public EfTermsRepository(LibraryContext libraryContext)
        {
            terms = libraryContext.Terms;
        }

        #region CRUD operations
        /// <summary>
        /// Проверяет, существует ли указанная сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если сущность существует, иначе <c>false</c>.</returns>
        public bool Contains(Term entity)
        {
            return terms.Contains(entity);
        }

        /// <summary>
        /// Возвращает количество сущностей в репозитории.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public int Count()
        {
            return terms.Count();
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Create(Term entity)
        {
            terms.Add(entity);
        }

        /// <summary>
        /// Удаляет сущность из репозитория по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Возвращает <c>true</c>, если сущность была успешно удалена, иначе <c>false</c>.</returns>
        public bool Delete(int id)
        {
            var term = terms.Find(id);
            if (term is null) return false;
            terms.Remove(term);
            return true;
        }

        /// <summary>
        /// Находит сущности, соответствующие указанному условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Запрос, содержащий сущности, соответствующие условию.</returns>
        public IQueryable<Term> Find(Expression<Func<Term, bool>> predicate)
        {
            return terms.Where(predicate);
        }

        /// <summary>
        /// Получает сущность по указанному идентификатору с возможностью включения связанных данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для получения.</param>
        /// <param name="includes">Имена связанных данных, которые следует включить.</param>
        /// <returns>Сущность с указанным идентификатором.</returns>
        public Term Get(int id, params string[] includes)
        {
            IQueryable<Term> query = terms;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(t => t.TermId == id);
        }

        /// <summary>
        /// Возвращает все сущности в репозитории.
        /// </summary>
        /// <returns>Запрос, содержащий все сущности.</returns>
        public IQueryable<Term> GetAll()
        {
            return terms.AsQueryable();
        }

        /// <summary>
        /// Обновляет существующую сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        public void Update(Term entity)
        {
            terms.Update(entity);
        }
        #endregion
    }

}
