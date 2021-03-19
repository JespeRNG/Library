using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class BookRepository : IBookRepository
    {
        private MyDbContext context = new MyDbContext();
        public DbSet<Book> Books()
        {
            return context.Books;
        }
    }
}
