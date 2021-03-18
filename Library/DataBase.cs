using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Library.DataAccessLayer;

namespace Library
{
    public class DataBase: IDbRepository
    {
        private DbActions db = new DbActions();
        private MyDbContext context = new MyDbContext();

        public DataBase()
        {
            db = new DbActions();
        }

        // Method for Setting/Refreshing data tables
        public void BindDataGrid(DataGrid ReadersGrid, DataGrid RecordsGrid, DataTable RecordsDt)
        {
            RecordsDt.Clear();

            context.Readers.Load();
            ReadersGrid.ItemsSource = context.Readers.Local;

            DataRow row;

           foreach (var record in context.Records.ToList<Record>()) // for every record in Records
           {
               var reader = (from r in context.Readers // Getting reader where reader.Id == record.ReaderId
                             where r.Id == record.ReaderId
                             select r).FirstOrDefault();
               var book = (from b in context.Books // Getting reader where reader.Id == record.ReaderId
                           where b.Id == record.BookId
                           select b).First();

               row = RecordsDt.NewRow();
               row["Reader Name"] = reader.LastName + ' ' + reader.FirstName[0] + ". " + reader.MiddleName[0] + '.';
               row["Book"] = '"' + book.Name + '"';
               row["Date of Issue"] = record.DateOfIssue;
               row["Date Of Return"] = record.DateOfReturn;

               if (!record.Returned)
                   row["Returned"] = "No";
               else
                   row["Returned"] = "Yes";
               RecordsDt.Rows.Add(row);
           }
           RecordsGrid.ItemsSource = RecordsDt.DefaultView;
        }

        public void LoadBooks(DataGrid DataGrid, DataTable DataTable)
        {
            DataTable.Clear();
            DataRow row;

            foreach (var record in context.Books.ToList<Book>()) // for every record in Records
            {
                var bookAuthor = (from a in context.BooksAuthors 
                                  where a.BookId == record.Id 
                                  select a.AuthorId).First();

                var author = (from a in context.Authors
                              where a.Id == bookAuthor
                              select a.LastName).First() + " " + (from a in context.Authors
                                                                  where a.Id == bookAuthor
                                                                  select a.FirstName).First();
                row = DataTable.NewRow();

                row["Book name"] = record.Name;
                row["Authors"] = author;
                row["Library code"] = record.LibraryCode;
                row["Publication year"] = record.PublicationYear;
                row["Publication place"] = record.PublicationPlace;
                row["Publishing name"] = record.PublishingName;
                row["Total amount"] = record.TotalAmount;
                row["Available amount"] = record.AvailableAmount;

                DataTable.Rows.Add(row);
            }
            DataGrid.ItemsSource = DataTable.DefaultView;
        }

        public void ChooseReader(int id, DataGrid RecordsGrid, DataTable RecordsDt)
        {
            RecordsDt.Clear();
            DataRow row;

            foreach (var record in db.GetRecordsList())
            {
                if(record.ReaderId == id)
                {
                    var reader = (from r in context.Readers
                                  where r.Id == id
                                  select r).First();
                    var book = (from b in context.Books
                                where b.Id == record.BookId
                                select b).First();

                    row = RecordsDt.NewRow();
                    row["Reader Name"] = reader.LastName + ' ' + reader.FirstName[0] + ". " + reader.MiddleName[0] + '.';
                    row["Book"] = '"' + book.Name + '"';
                    row["Date of Issue"] = record.DateOfIssue;
                    row["Date Of Return"] = record.DateOfReturn;
                    if (!record.Returned)
                        row["Returned"] = "No";
                    else
                        row["Returned"] = "Yes";
                    RecordsDt.Rows.Add(row);
                }
            }
            RecordsGrid.ItemsSource = RecordsDt.DefaultView;
        }

        public void AddReader(string firstName, string lastName, string middleName, string ticketNumber)
        {
            
            db.AddReader(firstName, lastName, middleName, ticketNumber);
        }

        public void AddRecord(int readerId, int bookId, string date)
        {
            db.AddRecord(readerId, bookId, date);
        }

        public void DeleteReader(int id)
        {
            db.DeleteReader(id);
        }

        public void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum)
        {
            db.EditReader(reader, lName, fName, mName, ticketNum);
        }

        public List<Record> GetRecords()
        {
            return db.GetRecordsList();
        }

        public List<Reader> GetReaders()
        {
            return db.GetReadersList();
        }

        public List<Book> GetBooks()
        {
            return db.GetBooksList();
        }
    }
}