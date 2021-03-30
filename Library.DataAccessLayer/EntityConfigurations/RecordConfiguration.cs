using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class RecordConfiguration : EntityTypeConfiguration<Record>
    {
        public RecordConfiguration()
        {
            this.ToTable("Records");
        }
    }
}
