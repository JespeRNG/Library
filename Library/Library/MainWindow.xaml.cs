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
<<<<<<< HEAD

=======
>>>>>>> bc660f6a5b013c6ea0d50d1053bd734f88fe1c45

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
                    LastName = "Fediuk",
                    FirstName = "Yaroslav",
                    MiddleName = "Viacheslavovich",
                    TicketNumber = 125,
                    DateOfTicketIssue = new DateTime(2021, 2, 23).ToString("dd.MM.yyyy")
                };

                context.Readers.Add(reader);
                context.SaveChanges();

                
            }*/

            bindDataGrid();
<<<<<<< HEAD
         }
=======
            //ReadersGrid.Columns[0].Visibility = Visibility.Hidden;
        }
>>>>>>> bc660f6a5b013c6ea0d50d1053bd734f88fe1c45

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
<<<<<<< HEAD
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {   
            addWindow.Show();
=======
            //ReadersGrid.Columns[0].Visibility = Visibility.Hidden;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
>>>>>>> bc660f6a5b013c6ea0d50d1053bd734f88fe1c45
        }
    }
}