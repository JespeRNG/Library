using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class BookAuthorConfiguration : EntityTypeConfiguration<BookAuthor>
    {
        public BookAuthorConfiguration()
        {
            this.ToTable("BookAuthors");
            this.HasKey(b => b.Id)
                .HasIndex(i => i.Id);
        }
    }
}
