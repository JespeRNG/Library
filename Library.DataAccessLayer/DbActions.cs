using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public class DbActions
    {
        private MyDbContext context = new MyDbContext();
        public void AddReader(string firstName, string lastName, string middleName, string ticketNumber)
        {
            Reader reader = new Reader
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                TicketNumber = Convert.ToInt32(ticketNumber),
                DateOfTicketIssue = DateTime.Now.ToString("dd.MM.yyyy")
            };

            context.Readers.Add(reader); //adding
            context.SaveChanges(); //saving changes
        }

        public void AddRecord(int readerId, int bookId, string date)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var record = new Record()
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    DateOfIssue = DateTime.Now.ToString("dd.MM.yyyy"),
                    DateOfReturn = date,
                    Returned = false
                };

                foreach (Book el in db.Books)
                    if (el.Id == bookId)
                        el.AvailableAmount--;

                db.Records.Add(record);
                db.SaveChanges();
            }
        }

        public void DeleteReader(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Reader reader = db.Readers.Find(id);
                db.Readers.Remove(reader);
                db.SaveChanges();
            }
        }

        public void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum)
        {
            using (MyDbContext db = new MyDbContext())
            {
                reader.LastName = lName;
                reader.FirstName = fName;
                reader.MiddleName = mName;
                reader.TicketNumber = ticketNum;

                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Record> GetRecordsList()
        {
            return context.Records.ToList<Record>();
        }

        public List<Reader> GetReadersList()
        {
            return context.Readers.ToList<Reader>();
        }

        public List<Book> GetBooksList()
        {
            return context.Books.ToList<Book>();
        }
    }
}
