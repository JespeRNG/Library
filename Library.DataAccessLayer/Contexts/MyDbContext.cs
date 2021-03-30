using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.DataAccessLayer
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new ReaderConfiguration());
            modelBuilder.Configurations.Add(new RecordConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new BookAuthorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}