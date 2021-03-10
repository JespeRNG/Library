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

namespace Library
{
    public partial class AddRecordWindow : Window
    {
        private int bookId { get; set; }
        private DataBase db = new DataBase();
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

            db.LoadBooks(BooksDataGrid, dt);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => this.Close();

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            db.AddRecord(readerId, bookId, DatePicker.SelectedDate.Value.ToString("dd.MM.yyyy"));
            this.Close();
        }

        private void BooksDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                // Getting list of readers
                List<Reader> list = context.Readers.ToList<Reader>();
                // Calling method for loading data of chosen reader
                bookId = list[BooksDataGrid.SelectedIndex].Id;
            }
        }
    }
}
