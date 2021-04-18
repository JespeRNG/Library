using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using Library.DataAccessLayer;

namespace Library
{
    public partial class MainWindow : Window
    {
        private IReaderRepository readerRepo = new ReaderRepository();
        private IRecordRepository recordRepo = new RecordRepository();
        private IBookRepository bookRepo = new BookRepository();
        private IAuthorRepository authorRepo = new AuthorRepository();
        private IBookAuthorRepository bookAuthorRepo = new BookAuthorRepository();
        private DataBase db;
        private DataTable RecordsDt;
        private int readerId { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            RecordsDt = new DataTable();
            RecordsDt.Columns.Add("Reader Name");
            RecordsDt.Columns.Add("Book");
            RecordsDt.Columns.Add("Date of Issue");
            RecordsDt.Columns.Add("Date Of Return");
            RecordsDt.Columns.Add("Returned");

            db = new DataBase(readerRepo, recordRepo, bookRepo, authorRepo, bookAuthorRepo);
            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AddRecordBtn.IsEnabled = true;
                RemoveReadersButton.IsEnabled = true;
                // Getting list of readers
                List<Reader> list = db.GetReadersList();
                // Calling method for loading data of chosen reader
                db.ChooseReader(list[ReadersGrid.SelectedIndex].Id, RecordsGrid, RecordsDt);
                readerId = list[ReadersGrid.SelectedIndex].Id;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt); 
        }

        private void AddRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecordWindow wn = new AddRecordWindow(readerId);
            wn.ShowDialog();

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        private void RemoveReadersButton_Click(object sender, RoutedEventArgs e)
        {
            List<Reader> list = db.GetReadersList();
            db.DeleteReader(list[ReadersGrid.SelectedIndex]);
            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            List<Reader> list = db.GetReadersList();
            EditWindow editWindow = new EditWindow(list[ReadersGrid.SelectedIndex]);
            editWindow.ShowDialog();

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }
    }
}