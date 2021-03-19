using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public interface IAuthorRepository
    {
        DbSet<Author> Authors();
    }
}
