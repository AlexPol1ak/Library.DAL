﻿using Library.Domain.Entities.Books;
using Library.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DAL.Data
{
    /// <summary>
    /// Класс конфигурации моделей.
    /// </summary>
    public static class ModelsConfig
    {
        static int VarcharMaxLen = 45;
        static int TextMaxLen = 500;
        // Конфигурация таблицы читателя.
        static public void UserConfig(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.FirstName).HasMaxLength(VarcharMaxLen);
            builder.Property(u => u.LastName).HasMaxLength(VarcharMaxLen);
            builder.Property(u => u.Patronymic).HasMaxLength(VarcharMaxLen);
            builder.Property(u => u.Email).HasMaxLength(VarcharMaxLen);
            builder.Ignore(u => u.FullName);
            builder.Ignore(u => u.ShortName);
        }

        // Конфигурация таблицы персонала.
        static public void StuffConfig(EntityTypeBuilder<Stuff> builder)
        {
            builder.ToTable("Stuff");
            builder.HasKey(u => u.UserId);
            builder.Property(s => s.FirstName).HasMaxLength(VarcharMaxLen);
            builder.Property(s => s.LastName).HasMaxLength(VarcharMaxLen);
            builder.Property(s => s.Patronymic).HasMaxLength(VarcharMaxLen);
            builder.Property(s => s.Email).HasMaxLength(VarcharMaxLen);
            builder.HasIndex(s => s.Email).IsUnique();
            builder.Ignore(s => s.FullName);
            builder.Ignore(s => s.ShortName);
            builder.Property(s => s.Password).HasMaxLength(10 * VarcharMaxLen);
        }

        // Конфигурация таблицы авторов книг.
        static public void AuthorConfig(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.Property(a => a.FirstName).HasMaxLength(VarcharMaxLen);
            builder.Property(a => a.LastName).HasMaxLength(VarcharMaxLen);
            builder.Property(a => a.Patronymic).HasMaxLength(VarcharMaxLen);
            builder.Ignore(a => a.FullName);
            builder.Ignore(a => a.ShortName);

        }

        // Конфигурация таблицы книг.
        static public void BookConfig(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.Property(b => b.Name).HasMaxLength(VarcharMaxLen);
            builder.Property(b => b.Description).HasColumnType("TEXT").HasMaxLength(TextMaxLen);
            builder.Ignore(b => b.AuthorsShort);
        }

        // Конфигурация таблицы историй книги.
        static public void BookHistoryConfig(EntityTypeBuilder<BookHistory> builder)
        {
            builder.ToTable("BookHistories");
            builder.Property(bh => bh.Remarks).HasColumnType("TEXT").HasMaxLength(TextMaxLen);
        }

        // Конфигурация таблицы жанров.
        static public void GenreConfig(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.Name).HasMaxLength(VarcharMaxLen);
        }

        // Конфигурация таблицы стеллажей.
        static public void RackConfig(EntityTypeBuilder<Rack> builder)
        {
            builder.ToTable("Racks");
            builder.Property(r => r.Name).HasMaxLength(VarcharMaxLen);
        }

        // Конфигурация таблицы правил выдачи книг.
        static public void TermConfig(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Terms");
            builder.Property(r => r.ReadLocation).HasMaxLength(VarcharMaxLen);
        }
    }
}
