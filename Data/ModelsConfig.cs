using Library.Domain.Entities.Books;
using Library.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Data
{
    /// <summary>
    /// Класс конфигурации моделей.
    /// </summary>
    public static class ModelsConfig
    {
        // Конифигурация таблицы читателя.
        static public void UserConfig(EntityTypeBuilder<User> builder)
        {

        }

        // Конифигурация таблицы персонала.
        static public void StuffConfig(EntityTypeBuilder<Stuff> builder)
        {

        }

        // Конифигурация таблицы заявок на книгу.
        static public void RequestConfig(EntityTypeBuilder<Request> builder)
        {

        }

        // Конифигурация таблицы авторов книг.
        static public void AuthorConfig(EntityTypeBuilder<Author> builder)
        {

        }

        // Конифигурация таблицы книг.
        static public void BookConfig(EntityTypeBuilder<Book> builder)
        {

        }

        // Конифигурация таблицы историй книги.
        static public void BookHistoryConfig(EntityTypeBuilder<BookHistory> builder)
        {

        }

        // Конифигурация таблицы жанров.
        static public void GenreConfig(EntityTypeBuilder<Genre> builder)
        {

        }

        // Конифигурация таблицы стелажей.
        static public void RackConfig(EntityTypeBuilder<Rack> builder)
        {

        }

        // Конифигурация таблицы правил выдачи книг.
        static public void TermConfig(EntityTypeBuilder<Term> builder)
        {

        }
    }
}
