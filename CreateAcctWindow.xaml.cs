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

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for CreateAcctWindow.xaml
    /// </summary>
    public partial class CreateAcctWindow : Window
    {
        public CreateAcctWindow()
        {
            InitializeComponent();
        }

        private void CreateAcctBtn_Click(object sender, RoutedEventArgs e)
        {
            //put some logic here, getters, setters, etc
            //UserAcctObj newacct = new UAO
            //insert into global UserAcct Dictionary
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        //first name of the account being created
        //code will run everytime the value is changed.
        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
