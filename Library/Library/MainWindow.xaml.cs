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


namespace Library
{
    public partial class MainWindow : Window
    {
        AddWindow addWindow = new AddWindow();
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
                    TicketNumber = 124,
                    DateOfTicketIssue = new DateTime(2021, 2, 23).ToString("dd.MM.yyyy")
                };

                context.Readers.Add(reader);
                context.SaveChanges();

                
            }*/

            bindDataGrid();
         }

        private void bindDataGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Readers]", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Readers");
            adapter.Fill(dt);
            con.Close();

            ReadersGrid.ItemsSource = dt.DefaultView;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {   
            addWindow.Show();
        }
    }
}