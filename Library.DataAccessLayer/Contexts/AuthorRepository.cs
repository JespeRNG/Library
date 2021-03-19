using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        private MyDbContext context = new MyDbContext();

        public DbSet<Author> Authors()
        {
            return context.Authors;
        }
    }
}
