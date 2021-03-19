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
        public void AddRecord(int readerId, int bookId, DateTime date)
        {
            Record record = new Record()
            {
                ReaderId = readerId,
                BookId = bookId,
                DateOfIssue = DateTime.Today,
                DateOfReturn = date,
                Returned = false
            };

            foreach (Book el in context.Books)
                if (el.Id == bookId)
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
