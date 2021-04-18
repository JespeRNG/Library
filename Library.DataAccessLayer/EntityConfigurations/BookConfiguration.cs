using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.DataAccessLayer
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            this.ToTable("Books");
            this.Property(b => b.Name).HasMaxLength(20);
            this.HasKey(b => b.Id)
                .HasIndex(i => i.Id);
        }
    }
}
