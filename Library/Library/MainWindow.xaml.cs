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

namespace Library
{
    public partial class MainWindow : Window
    {
        private DataBase db = new DataBase();
        private DataTable RecordsDt;
        private int readerId { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            /*using (var context = new MyDbContext())
            {
                var reader = new Reader()
                {
                    LastName = "Polishchuk",
                    FirstName = "Andriy",
                    MiddleName = "Oleksiyovich",
                    TicketNumber = 126,
                    DateOfTicketIssue = new DateTime(2021, 2, 23).ToString("dd.MM.yyyy")
                };
                context.Readers.Add(reader);
                context.SaveChanges();
            }*/
            RecordsDt = new DataTable();
            RecordsDt.Columns.Add("Reader Name");
            RecordsDt.Columns.Add("Book");
            RecordsDt.Columns.Add("Date of Issue");
            RecordsDt.Columns.Add("Date Of Return");
            RecordsDt.Columns.Add("Returned");

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AddRecordBtn.IsEnabled = true;
                using (var context = new MyDbContext())
                {
                    // Getting list of readers
                    List<Reader> list = context.Readers.ToList<Reader>();
                    // Calling method for loading data of chosen reader
                    db.ChooseReader(list[ReadersGrid.SelectedIndex].Id, RecordsGrid, RecordsDt);
                    readerId = list[ReadersGrid.SelectedIndex].Id;
                }
            }
            catch (System.ArgumentOutOfRangeException) { }
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            //Refreshing Data Table after saving changes
            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt); 
        }

        private void AddRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecordWindow wn = new AddRecordWindow(readerId);
            wn.ShowDialog();
        }

        private void RemoveReadersButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                List<Reader> list = context.Readers.ToList<Reader>();
                db.DeleteReader(list[ReadersGrid.SelectedIndex].Id);
                db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
            }
        }
    }
}
