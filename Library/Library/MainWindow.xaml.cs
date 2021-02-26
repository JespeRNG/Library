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

            RecordsDt = new DataTable();
            RecordsDt.Columns.Add("Reader Name");
            RecordsDt.Columns.Add("Book");
            RecordsDt.Columns.Add("Date of Issue");
            RecordsDt.Columns.Add("Date Of Return");
            RecordsDt.Columns.Add("Returned");

            db.BindDataGrid(ReadersGrid, RecordsGrid, RecordsDt);
        }

        //Button addReader_Click()
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
    }
}
