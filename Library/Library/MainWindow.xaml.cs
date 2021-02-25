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

            bindDataGrid();
        }

        private void bindDataGrid()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                dbc.Readers.Load();
                ReadersGrid.ItemsSource = dbc.Readers.Local;

                DataRow row;
                DataTable dt = new DataTable();
                dt.Columns.Add("Reader Name");
                dt.Columns.Add("Book");
                dt.Columns.Add("Date of Issue");
                dt.Columns.Add("Date Of Return");
                dt.Columns.Add("Returned");

                foreach (var record in dbc.Records.ToList<Record>())
                {
                    var reader = (from r in dbc.Readers
                                  where r.Id == record.ReaderId
                                  select r).First();
                    var book = (from b in dbc.Books
                                where b.Id == record.BookId
                                select b).First();
                    row = dt.NewRow();
                    row["Reader Name"] = reader.LastName + ' ' + reader.FirstName[0] + ". " + reader.MiddleName[0] + '.';
                    row["Book"] = '"' + book.Name + '"';
                    row["Date of Issue"] = record.DateOfIssue;
                    row["Date Of Return"] = record.DateOfReturn;
                    if (!record.Returned)
                        row["Returned"] = "No";
                    else
                        row["Returned"] = "Yes";
                    dt.Rows.Add(row);
                }
                RecordsGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
    }
}
