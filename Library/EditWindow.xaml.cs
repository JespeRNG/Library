using System;
using System.Collections.Generic;
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
    public partial class EditWindow : Window
    {
        private DataBase db = new DataBase();
        private Reader reader { get; set; }
        public EditWindow(Reader reader)
        {
            InitializeComponent();

            this.reader = reader;
            LNameTextBox.Text = reader.LastName;
            FNameTextBox.Text = reader.FirstName;
            MNameTextBox.Text = reader.MiddleName;
            TicketTextBox.Text = Convert.ToString(reader.TicketNumber);
        }

        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            db.EditReader(reader, LNameTextBox.Text, FNameTextBox.Text, MNameTextBox.Text, Convert.ToInt32(TicketTextBox.Text));
            this.Close();
        }
    }
}