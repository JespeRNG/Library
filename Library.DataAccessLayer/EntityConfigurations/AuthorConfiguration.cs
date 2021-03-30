using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            this.ToTable("Authors");
        }
    }
}
