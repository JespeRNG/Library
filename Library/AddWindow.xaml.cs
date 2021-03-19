using Library.DataAccessLayer;
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
        private IReaderRepository readerRepo = new ReaderRepository();
        private IRecordRepository recordRepo = new RecordRepository();
        private IBookRepository bookRepo = new BookRepository();
        private IAuthorRepository authorRepo = new AuthorRepository();
        private IBookAuthorRepository bookAuthorRepo = new BookAuthorRepository();

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
            DataBase db = new DataBase(readerRepo, recordRepo, bookRepo, authorRepo, bookAuthorRepo);
            db.AddReader(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxMiddleName.Text, TextBoxTicketNumber.Text);
        }
    }
}