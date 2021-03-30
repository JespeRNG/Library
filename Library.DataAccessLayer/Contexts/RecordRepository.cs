using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class RecordRepository : IRecordRepository
    {
        private MyDbContext context = new MyDbContext();

        public void AddRecord(Record record)
        {
            foreach (Book el in context.Books)
                if (el.Id == record.BookId)
                    el.AvailableAmount--;

            context.Records.Add(record);
            context.SaveChanges();
        }

        public DbSet<Record> Records()
        {
            return context.Records;
        }
    }
}
