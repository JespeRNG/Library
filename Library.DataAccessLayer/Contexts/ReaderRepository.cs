using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class ReaderRepository : IReaderRepository
    {
        private MyDbContext context = new MyDbContext();
        public void AddReader(Reader reader)
        {
            context.Readers.Add(reader); //adding
            context.SaveChanges(); //saving changes
        }

        public void DeleteReader(Reader reader)
        {
            context.Readers.Remove(reader);
            context.SaveChanges();
        }

        public void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum)
        {
            reader.LastName = lName;
            reader.FirstName = fName;
            reader.MiddleName = mName;
            reader.TicketNumber = ticketNum;

            context.Entry(reader).State = EntityState.Modified;
            context.SaveChanges();
        }

        public DbSet<Reader> Readers()
        {
            return context.Readers;
        }
    }
}
