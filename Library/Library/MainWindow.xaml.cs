﻿using System;
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

         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addWindow.Show();
        }
    }
}
