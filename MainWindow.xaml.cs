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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            App.ListOpen();
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void LoadEngineer_Click(object sender, RoutedEventArgs e)
        {
            LoadEngineerWindow loadEngineerWindow = new LoadEngineerWindow(this);
            loadEngineerWindow.Show();
            this.Hide();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAcctBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateAcctWindow acctWindow = new CreateAcctWindow(this);
            acctWindow.Show();
            this.Hide();
        }
    }
}
