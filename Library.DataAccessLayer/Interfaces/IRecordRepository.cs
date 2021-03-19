using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public interface IRecordRepository
    {
        void AddRecord(int readerId, int bookId, DateTime date);
        DbSet<Record> Records();
    }
}
