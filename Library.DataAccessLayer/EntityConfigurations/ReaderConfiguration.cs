using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Library.DataAccessLayer
{
    public class ReaderConfiguration: EntityTypeConfiguration<Reader>
    {
        public ReaderConfiguration()
        {
            this.ToTable("Readers");
            this.Property(r => r.LastName).HasMaxLength(20);
            this.Property(r => r.MiddleName).HasMaxLength(20);
            this.Property(r => r.FirstName).HasMaxLength(20);
            this.HasKey(r => r.Id)
                .HasIndex(i => i.Id);
        }
    }
}