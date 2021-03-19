using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private MyDbContext context = new MyDbContext();
        public DbSet<BookAuthor> BooksAuthors()
        {
            return context.BooksAuthors;
        }
    }
}
