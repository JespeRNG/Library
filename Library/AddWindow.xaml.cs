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

namespace Library
{
    public partial class AddWindow : Window
    {
        
        public AddWindow()
        {
            InitializeComponent();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase addr = new DataBase();
            addr.AddReader(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxMiddleName.Text, TextBoxTicketNumber.Text);
        }
    }
}