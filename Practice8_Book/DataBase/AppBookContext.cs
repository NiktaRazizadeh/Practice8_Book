using Microsoft.EntityFrameworkCore;
using Practice8_Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.DataBase
{
    public class AppBookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public AppBookContext()
        {

        }
        public AppBookContext(DbContextOptions<AppBookContext>  options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(B => B.ToTable("Book"));
            modelBuilder.Entity<Book>(B => B.ToTable("Author"));
            modelBuilder.Entity<Book>(B => B.ToTable("Category"));
            modelBuilder.Entity<Book>(B => B.ToTable("Publications"));
            modelBuilder.Entity<Book>(B => B.ToTable("BookAuthor"));
            modelBuilder.Entity<Book>(B => B.ToTable("BookCategory"));
        }
    }
}
