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
    public class DataBase
    {
        private IReaderRepository readerRepo;
        private IRecordRepository recordRepo;
        private IBookRepository bookRepo;
        private IAuthorRepository authorRepo;
        private IBookAuthorRepository bookAuthorRepo;

        public DataBase(IReaderRepository readerRepo, IRecordRepository recordRepo, IBookRepository bookRepo, IAuthorRepository authorRepo, IBookAuthorRepository bookAuthorRepo)
        {
            this.readerRepo = readerRepo;
            this.recordRepo = recordRepo;
            this.bookRepo = bookRepo;
            this.authorRepo = authorRepo;
            this.bookAuthorRepo = bookAuthorRepo;
        }

        public void AddReader(Reader reader)
        {
            readerRepo.AddReader(reader);
        }

        public void AddRecord(Record record)
        {
            recordRepo.AddRecord(record);
        }

        public void DeleteReader(Reader reader)
        {
            readerRepo.DeleteReader(reader);
        }

        public void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum)
        {
            readerRepo.EditReader(reader, lName, fName, mName, ticketNum);
        }

        public void BindDataGrid(DataGrid ReadersGrid, DataGrid RecordsGrid, DataTable RecordsDt)
        {
            RecordsDt.Clear();

            readerRepo.Readers().Load();
            ReadersGrid.ItemsSource = readerRepo.Readers().Local;

            DataRow row;

            foreach (var record in recordRepo.Records().ToList<Record>()) // for every record in Records
            {
                var reader = (from r in readerRepo.Readers() // Getting reader where reader.Id == record.ReaderId
                              where r.Id == record.ReaderId
                              select r).FirstOrDefault();

                var book = (from b in bookRepo.Books() // Getting reader where reader.Id == record.ReaderId
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

            foreach (var record in bookRepo.Books().ToList()) // for every record in Records
            {
                var bookAuthor = (from a in bookAuthorRepo.BooksAuthors()
                                  where a.BookId == record.Id
                                  select a.AuthorId).First();

                var author = (from a in authorRepo.Authors()
                              where a.Id == bookAuthor
                              select a.LastName).First() + " " + (from a in authorRepo.Authors()
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

            foreach (var record in recordRepo.Records().ToList())
            {
                if (record.ReaderId == id)
                {
                    var reader = (from r in readerRepo.Readers()
                                  where r.Id == id
                                  select r).First();

                    var book = (from b in bookRepo.Books()
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

        public List<Reader> GetReadersList()
        {
            return readerRepo.Readers().ToList();
        }

        public List<Book> GetBooksList()
        {
            return bookRepo.Books().ToList();
        }
    }
}