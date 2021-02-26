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
        public MainWindow()
        {
            InitializeComponent();

<<<<<<< HEAD
=======
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
>>>>>>> 2d27976e1df0c83e241f1461adc19c430909295e
            RecordsDt = new DataTable();
            RecordsDt.Columns.Add("Reader Name");
            RecordsDt.Columns.Add("Book");
            RecordsDt.Columns.Add("Date of Issue");
            RecordsDt.Columns.Add("Date Of Return");
            RecordsDt.Columns.Add("Returned");
<<<<<<< HEAD
=======

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }
>>>>>>> 2d27976e1df0c83e241f1461adc19c430909295e

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        //Button addReader_Click()
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
<<<<<<< HEAD
=======
        }
        private void ReadersGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            //db.ChooseReader(RecordsDt);
>>>>>>> 2d27976e1df0c83e241f1461adc19c430909295e
        }
    }
}
