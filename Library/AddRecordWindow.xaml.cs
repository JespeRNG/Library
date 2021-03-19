using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.DataAccessLayer;

namespace Library
{
    public partial class AddRecordWindow : Window
    {
        private IReaderRepository readerRepo = new ReaderRepository();
        private IRecordRepository recordRepo = new RecordRepository();
        private IBookRepository bookRepo = new BookRepository();
        private IAuthorRepository authorRepo = new AuthorRepository();
        private IBookAuthorRepository bookAuthorRepo = new BookAuthorRepository();
        private int bookId { get; set; }
        private DataBase db;
        private int readerId { get; set; }
        public AddRecordWindow(int readerId)
        {
            InitializeComponent();

            this.readerId = readerId;
            DataTable dt = new DataTable();
            dt.Columns.Add("Book name");
            dt.Columns.Add("Authors");
            dt.Columns.Add("Library code");
            dt.Columns.Add("Publication year");
            dt.Columns.Add("Publication place");
            dt.Columns.Add("Publishing name");
            dt.Columns.Add("Total amount");
            dt.Columns.Add("Available amount");

            db = new DataBase(readerRepo, recordRepo, bookRepo, authorRepo, bookAuthorRepo);
            db.LoadBooks(BooksDataGrid, dt);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => this.Close();

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            db.AddRecord(readerId, bookId, DatePicker.SelectedDate.Value.Date);
            this.Close();
        }

        private void BooksDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                List<Book> list = db.GetBooksList();
                // Calling method for loading data of chosen reader
                bookId = list[BooksDataGrid.SelectedIndex].Id;
            }
            catch (ArgumentOutOfRangeException) { }
        }
    }
}
