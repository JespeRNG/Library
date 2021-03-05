using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace Library
{
    public class DataBase
    {
        // Method for Setting/Refreshing data tables
        public void BindDataGrid(DataGrid ReadersGrid, DataGrid RecordsGrid, DataTable RecordsDt)
        {
            RecordsDt.Clear();
            using (MyDbContext dbc = new MyDbContext())
            {
                dbc.Readers.Load();
                ReadersGrid.ItemsSource = dbc.Readers.Local;

                DataRow row;

                foreach (var record in dbc.Records.ToList<Record>()) // for every record in Records
                {
                    var reader = (from r in dbc.Readers // Getting reader where reader.Id == record.ReaderId
                                  where r.Id == record.ReaderId
                                  select r).First();
                    var book = (from b in dbc.Books // Getting reader where reader.Id == record.ReaderId
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
        }

        public void LoadBooks(DataGrid DataGrid, DataTable DataTable)
        {
            DataTable.Clear();

            using (MyDbContext dbc = new MyDbContext())
            {
                DataRow row;

                foreach (var record in dbc.Books.ToList<Book>()) // for every record in Records
                {
                    var bookAuthor = (from a in dbc.BooksAuthors 
                                      where a.BookId == record.Id 
                                      select a.AuthorId).First();

                    var author = (from a in dbc.Authors
                                  where a.Id == bookAuthor
                                  select a.LastName).First() + " " + (from a in dbc.Authors
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
        }

        public void ChooseReader(int id, DataGrid RecordsGrid, DataTable RecordsDt)
        {
            RecordsDt.Clear();
            using (MyDbContext dbc = new MyDbContext())
            {
                DataRow row;

                foreach (var record in dbc.Records.ToList<Record>())
                {
                    if(record.ReaderId == id)
                    {
                        var reader = (from r in dbc.Readers
                                      where r.Id == id
                                      select r).First();
                        var book = (from b in dbc.Books
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
        }
        public void AddReader(string firstName, string lastName, string middleName, string ticketNumber)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Reader reader = new Reader { FirstName = firstName, LastName = lastName, MiddleName = middleName, TicketNumber = Convert.ToInt32(ticketNumber), DateOfTicketIssue = DateTime.Now.ToString("dd.MM.yyyy") };

                db.Readers.Add(reader); //adding
                db.SaveChanges(); //saving changes       
            }
            MessageBox.Show("Saved");
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
            MessageBox.Show("Deleted");
        }
    }
}
